using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Atualizacao38 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FornecedorId",
                table: "Alimentos",
                newName: "NumeroFornecedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroFornecedor",
                table: "Alimentos",
                newName: "FornecedorId");
        }
    }
}
