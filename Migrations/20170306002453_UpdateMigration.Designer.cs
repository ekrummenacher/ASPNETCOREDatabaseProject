﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ASPNETCOREDATABASE.Models;

namespace ASPNETCOREDATABASE.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20170306002453_UpdateMigration")]
    partial class UpdateMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("ASPNETCOREDATABASE.Models.Detail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<string>("Comment");

                    b.Property<string>("Description");

                    b.Property<int?>("InventoryId");

                    b.Property<int>("Quantity");

                    b.Property<double>("SalePrice");

                    b.Property<int>("UPC");

                    b.Property<double>("WholePrice");

                    b.HasKey("DetailId");

                    b.HasIndex("InventoryId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("ASPNETCOREDATABASE.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("Time");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("ASPNETCOREDATABASE.Models.Detail", b =>
                {
                    b.HasOne("ASPNETCOREDATABASE.Models.Inventory", "Inventory")
                        .WithMany("Detail")
                        .HasForeignKey("InventoryId");
                });
        }
    }
}
