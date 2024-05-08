using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class CriadoTabelaDeLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FornecedorNome",
                table: "Alimentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogsModelId",
                table: "Alimentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioCadastrou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAlimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeAlimeto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioEditou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioRetirou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioDevolvel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataRetira = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDevolve = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuantidadeAlimento = table.Column<int>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_LogsModelId",
                table: "Alimentos",
                column: "LogsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alimentos_Logs_LogsModelId",
                table: "Alimentos",
                column: "LogsModelId",
                principalTable: "Logs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimentos_Logs_LogsModelId",
                table: "Alimentos");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Alimentos_LogsModelId",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "FornecedorNome",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "LogsModelId",
                table: "Alimentos");
        }
    }
}
