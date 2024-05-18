using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Atualizacao37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimentos_Fornecedor_FornecedorId",
                table: "Alimentos");

            migrationBuilder.DropIndex(
                name: "IX_Alimentos_FornecedorId",
                table: "Alimentos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_FornecedorId",
                table: "Alimentos",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alimentos_Fornecedor_FornecedorId",
                table: "Alimentos",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
