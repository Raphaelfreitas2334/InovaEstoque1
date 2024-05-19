using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Atualizacao311 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimentos_Usuario_usuarioId",
                table: "Alimentos");

            migrationBuilder.DropIndex(
                name: "IX_Alimentos_usuarioId",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "IDusuario",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Alimentos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDusuario",
                table: "Alimentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Alimentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_usuarioId",
                table: "Alimentos",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alimentos_Usuario_usuarioId",
                table: "Alimentos",
                column: "usuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
