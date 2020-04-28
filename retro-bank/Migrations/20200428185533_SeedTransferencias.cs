using Microsoft.EntityFrameworkCore.Migrations;
using retro_bank.Models;

namespace retro_bank.Migrations
{
    public partial class SeedTransferencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            new Transferencia()
            {
                ClienteRemetenteId = Cliente.Busca().Find(3).Id,
                Valor = 1000.00,
                ClienteDestinatarioId = Cliente.Busca().Find(1).Id,
            }.Salvar();

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
