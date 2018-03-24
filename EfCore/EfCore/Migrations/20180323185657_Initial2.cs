using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCore.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "Persons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Persons");
        }
    }
}
