using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CricInfo.Migrations
{
    public partial class playerfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HowOut",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OutBy",
                table: "Players",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HowOut",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "OutBy",
                table: "Players");
        }
    }
}
