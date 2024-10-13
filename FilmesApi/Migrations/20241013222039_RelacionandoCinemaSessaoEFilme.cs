﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    public partial class RelacionandoCinemaSessaoEFilme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "Sessoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SessaoId",
                table: "Cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_CinemaId",
                table: "Sessoes",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaId",
                table: "Sessoes",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaId",
                table: "Sessoes");

            migrationBuilder.DropIndex(
                name: "IX_Sessoes_CinemaId",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "SessaoId",
                table: "Cinemas");
        }
    }
}
