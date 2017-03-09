using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace ASPNETCOREDATABASE.Models
{

    public class Inventory
    {
        public int InventoryId { get; set; }
        public string Name { get; set; } //Type of Music (classical, rock, pop, etc)
        public DateTime Time { get; set; }
        public List<Detail> Detail { get; set; }
        public List<MusicType> MusicType { get; set; }
    }

    public class Detail
    {
        public int DetailId { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int UPC { get; set; }
        public string Size { get; set; }
        public double SalePrice { get; set; }
        public double WholePrice { get; set; }
        public string Comment { get; set; }
        public Inventory Inventory { get; set; }
    }

    public class MusicType
    {
        public int MusicTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; } 
        public string Comment { get; set; }
        public Inventory Inventory { get; set; }
    }

    public class InventoryContext : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<MusicType> MusicTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Inventory.db");
        }
    }
}