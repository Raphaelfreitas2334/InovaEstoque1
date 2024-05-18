using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Atualizacao36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "unidadeMedida",
                table: "Fornecimentos",
                newName: "UnidadeMedida");

            migrationBuilder.RenameColumn(
                name: "nomeAlimento",
                table: "Fornecimentos",
                newName: "NomeAlimento");

            migrationBuilder.RenameColumn(
                name: "dataVencimento",
                table: "Fornecimentos",
                newName: "DataVencimento");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimentos_Fornecedor_FornecedorId",
                table: "Alimentos");

            migrationBuilder.DropIndex(
                name: "IX_Alimentos_FornecedorId",
                table: "Alimentos");

            migrationBuilder.RenameColumn(
                name: "UnidadeMedida",
                table: "Fornecimentos",
                newName: "unidadeMedida");

            migrationBuilder.RenameColumn(
                name: "NomeAlimento",
                table: "Fornecimentos",
                newName: "nomeAlimento");

            migrationBuilder.RenameColumn(
                name: "DataVencimento",
                table: "Fornecimentos",
                newName: "dataVencimento");
        }
    }
}
