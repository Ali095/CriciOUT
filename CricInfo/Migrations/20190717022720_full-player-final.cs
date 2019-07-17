using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CricInfo.Migrations
{
    public partial class fullplayerfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Bowls_BowlId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Scores_ScoreId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_ScoreId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "ScoreId",
                table: "Players",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BowlId",
                table: "Players",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Players_ScoreId",
                table: "Players",
                column: "ScoreId",
                unique: true,
                filter: "[ScoreId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Bowls_BowlId",
                table: "Players",
                column: "BowlId",
                principalTable: "Bowls",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Scores_ScoreId",
                table: "Players",
                column: "ScoreId",
                principalTable: "Scores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Bowls_BowlId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Scores_ScoreId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_ScoreId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "ScoreId",
                table: "Players",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BowlId",
                table: "Players",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_ScoreId",
                table: "Players",
                column: "ScoreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Bowls_BowlId",
                table: "Players",
                column: "BowlId",
                principalTable: "Bowls",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Scores_ScoreId",
                table: "Players",
                column: "ScoreId",
                principalTable: "Scores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
