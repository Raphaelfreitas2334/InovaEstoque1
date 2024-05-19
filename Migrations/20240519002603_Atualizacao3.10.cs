using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Atualizacao310 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numeroResidencia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funcao = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeAlimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataVencimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unidadeMedida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantidadeMaxima = table.Column<double>(type: "float", nullable: true),
                    quantidadeMinima = table.Column<double>(type: "float", nullable: true),
                    quantidadeAtual = table.Column<double>(type: "float", nullable: true),
                    quantidadeRetirada = table.Column<double>(type: "float", nullable: true),
                    quantidadeDevolvida = table.Column<double>(type: "float", nullable: true),
                    obsDeSaida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obsDeDevolucao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FornecedorId = table.Column<int>(type: "int", nullable: false),
                    FornecedorNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IDusuario = table.Column<int>(type: "int", nullable: true),
                    usuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alimentos_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fornecimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFornecedor = table.Column<int>(type: "int", nullable: false),
                    NomeFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroResidencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAlimento = table.Column<int>(type: "int", nullable: false),
                    NomeAlimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataVencimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadeMedida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantidadeFornecida = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecimentos_Alimentos_IdAlimento",
                        column: x => x.IdAlimento,
                        principalTable: "Alimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fornecimentos_Fornecedor_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioCadastrou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeAlimeto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioEditou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioRetirou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioDevolvel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioRemovel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataRetira = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDevolve = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataRemovel = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuantidadeAlimento = table.Column<double>(type: "float", nullable: true),
                    obsDeSaida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obsDeDevolucao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAlimento = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Alimentos_IdAlimento",
                        column: x => x.IdAlimento,
                        principalTable: "Alimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Logs_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_usuarioId",
                table: "Alimentos",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecimentos_IdAlimento",
                table: "Fornecimentos",
                column: "IdAlimento");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecimentos_IdFornecedor",
                table: "Fornecimentos",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_IdAlimento",
                table: "Logs",
                column: "IdAlimento");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UsuarioId",
                table: "Logs",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecimentos");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Alimentos");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
