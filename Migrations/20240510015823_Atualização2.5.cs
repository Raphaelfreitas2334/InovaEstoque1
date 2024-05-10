using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Atualização25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "DataDevolve",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "DataRetira",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "UsuarioDevolvel",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "UsuarioEditou",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "UsuarioNome",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "UsuarioRetirou",
                table: "Alimentos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Alimentos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDevolve",
                table: "Alimentos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRetira",
                table: "Alimentos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioDevolvel",
                table: "Alimentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioEditou",
                table: "Alimentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioNome",
                table: "Alimentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioRetirou",
                table: "Alimentos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
