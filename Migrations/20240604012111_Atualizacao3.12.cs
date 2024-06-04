using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Atualizacao312 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Alimentos_IdAlimento",
                table: "Logs");

            migrationBuilder.AddColumn<double>(
                name: "QuantidadeAnterior",
                table: "Logs",
                type: "float",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Alimentos_IdAlimento",
                table: "Logs",
                column: "IdAlimento",
                principalTable: "Alimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Alimentos_IdAlimento",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "QuantidadeAnterior",
                table: "Logs");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Alimentos_IdAlimento",
                table: "Logs",
                column: "IdAlimento",
                principalTable: "Alimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
