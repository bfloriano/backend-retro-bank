using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace retro_bank.Migrations
{
    public partial class ClientesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Agencia = table.Column<string>(nullable: true),
                    Conta = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    SaldoI = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Extratos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extratos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transferencias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    ClienteRemetenteId = table.Column<int>(nullable: false),
                    ClienteDestinatarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencias", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Extratos");

            migrationBuilder.DropTable(
                name: "Transferencias");
        }
    }
}
