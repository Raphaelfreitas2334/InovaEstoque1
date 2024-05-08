using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class CriandoTabelaAlimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeAlimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataVencimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unidadeMedida = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    quantidadeMaxima = table.Column<double>(type: "float", nullable: true),
                    quantidadeMinima = table.Column<double>(type: "float", nullable: true),
                    quantidadeAtual = table.Column<double>(type: "float", nullable: true),
                    IDusuario = table.Column<int>(type: null, nullable: true),
                    UsuarioNome = table.Column<string>(type: null, nullable: true),
                    usuario = table.Column<string>(type: null, maxLength: 2, nullable: true),
                    usuarioId = table.Column<int>(type: null, nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimentos");
        }
    }
}
