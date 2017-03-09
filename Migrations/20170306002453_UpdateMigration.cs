using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNETCOREDATABASE.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Inventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Details",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SalePrice",
                table: "Details",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WholePrice",
                table: "Details",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "WholePrice",
                table: "Details");
        }
    }
}
