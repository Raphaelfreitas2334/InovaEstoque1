using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Atualização23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "QuantidadeAlimento",
                table: "Logs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "obsDeDevolucao",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "obsDeSaida",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeAlimento",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "obsDeDevolucao",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "obsDeSaida",
                table: "Logs");
        }
    }
}
