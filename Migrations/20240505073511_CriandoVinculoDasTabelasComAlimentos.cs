using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class CriandoVinculoDasTabelasComAlimentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantidadeDevolvida",
                table: "Alimentos");

            migrationBuilder.RenameColumn(
                name: "dataSaida",
                table: "Alimentos",
                newName: "obsDeDevolucao");

            migrationBuilder.RenameColumn(
                name: "dataDevolucao",
                table: "Alimentos",
                newName: "UsuarioRetirou");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "unidadeMedida",
                table: "Alimentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "quantidadeMinima",
                table: "Alimentos",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "quantidadeMaxima",
                table: "Alimentos",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "quantidadeAtual",
                table: "Alimentos",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "nomeAlimento",
                table: "Alimentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "dataVencimento",
                table: "Alimentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Alimentos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
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

            migrationBuilder.AddColumn<int>(
                name: "Fornecedorid",
                table: "Alimentos",
                type: "int",
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

            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_Fornecedorid",
                table: "Alimentos",
                column: "Fornecedorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Alimentos_Fornecedor_Fornecedorid",
                table: "Alimentos",
                column: "Fornecedorid",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimentos_Fornecedor_Fornecedorid",
                table: "Alimentos");

            migrationBuilder.DropIndex(
                name: "IX_Alimentos_Fornecedorid",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "DataDevolve",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "DataRetira",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "Fornecedorid",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "UsuarioDevolvel",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "UsuarioEditou",
                table: "Alimentos");

            migrationBuilder.RenameColumn(
                name: "obsDeDevolucao",
                table: "Alimentos",
                newName: "dataSaida");

            migrationBuilder.RenameColumn(
                name: "UsuarioRetirou",
                table: "Alimentos",
                newName: "dataDevolucao");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "unidadeMedida",
                table: "Alimentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "quantidadeMinima",
                table: "Alimentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "quantidadeMaxima",
                table: "Alimentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "quantidadeAtual",
                table: "Alimentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nomeAlimento",
                table: "Alimentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "dataVencimento",
                table: "Alimentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "quantidadeDevolvida",
                table: "Alimentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
