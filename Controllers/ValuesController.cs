using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCOREDATABASE.Models;
using Newtonsoft.Json;

namespace ASPNETCOREDATABASE.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            using (var db = new InventoryContext())
            {
                //Test Mode 
                //Creating a list of type Detail to hold a new instance of a class
                //What is an instance of a class?
                //It's an Object
                List<Detail> detail2 = new List<Detail>();

                //Adding onto the detail2 list
                detail2.Add(
                    //I'm adding a new instance of the Detail class
                    new Detail { Description = "description", Brand = "KORG", Quantity = 3, UPC = 12345, SalePrice = 49.99, WholePrice = 29.99, Comment = "comment of detail", Size = "4/4"}
                );

                List<MusicType> music = new List<MusicType>();

                music.Add(
                    new MusicType { Title = "title", Description = "description", Quantity = 4, Price = 15.25, Comment = "comment on music" }
                );

                var jsonResultInventory = new Inventory
                {
                    Name = "First Inventory Item",
                    Time = DateTime.Now,
                    Detail = detail2,
                    MusicType = music
                };

                return JsonConvert.SerializeObject(jsonResultInventory);

                //Query 
                var inventoryInfo = db.Inventories.Where(x => x.InventoryId == 7);

                if (inventoryInfo.Count() > 0)
                {
                    var record = inventoryInfo.FirstOrDefault();
                    Console.WriteLine("ID: {0} URL {1} ", record.InventoryId, record.Name);


                    //Update the record
                    record.Name = "Changed Inventory Item";
                    db.Inventories.Update(record);
                    db.SaveChanges();

                    var response = "ID: " + record.InventoryId + " URL: " + record.Name;
                    return response;
                }
                else
                {
                    //create a list of MusicType
                    // List<MusicType> musictype = new List<MusicType>();
                    //Create a new list of Type Detail
                    List<Detail> detail = new List<Detail>();
                    detail.Add(new Detail { Description = "description", Quantity = 4, UPC = 1234, Comment = "comment of detail" });

                    //Add a new record
                    db.Inventories.Add(new Inventory
                    {
                        Name = "First Inventory Item",
                        Detail = detail
                    });

                    var count = db.SaveChanges();
                    Console.WriteLine("{0} records saved to database", count);

                    Console.WriteLine();
                    Console.WriteLine("All inventories in database: ");
                    foreach (var inventoryItem in db.Inventories)
                    {
                        Console.WriteLine(" - {0}", inventoryItem.Name);
                    }
                }

                return Json(inventoryInfo.FirstOrDefault()).ToString();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        // public void Post([FromBody]string value)
        // {
        // }
        public IActionResult POST([FromBody] Inventory inventory)
        {
            using (var db = new InventoryContext())
            {
                try
                {
                    //Add a new record
                    db.Inventories.Add(inventory);
                    db.SaveChanges();
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                    Json(error.ToString());
                }
            }

            return Json("DONE");
        }
        //     switch(music.Description)
        //     {
        //         case "cd":
        //            music.Price = 16.89;
        //            break;
        //         case "record":
        //             music.Price = 25.00;
        //             break;
        //         case "cassette":
        //             music.Price = 9.79;
        //             break;       
        //         default:
        //             music.Comment = "Item not found.";
        //             break;    
        //     }

        //     // if (music.Description == "cd")
        //     // {
        //     //     music.Price = 16.89;
        //     // } else if (music.Description == "record")
        //     // {
        //     //     music.Price = 25.00;
        //     // } else if (music.Description == "cassette")
        //     // {
        //     //     music.Price = 9.79;
        //     // }

        //     if (music.Quantity < 2)
        //     {
        //         music.Comment = "Less than two of product in stock. Order more now.";
        //         music.Price = (music.Price + 7.00);
        //     } else {
        //         music.Comment = "No need to order any more of this right now.";
        //     }

        //     return Json(music);
        // }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
