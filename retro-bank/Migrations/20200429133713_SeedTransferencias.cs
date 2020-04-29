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
                ClienteDestinatarioId = Cliente.Busca().Find(1).Id,
                Valor = 2000.00,
            }.Salvar();

            new Transferencia()
            {
                ClienteRemetenteId = Cliente.Busca().Find(3).Id,
                ClienteDestinatarioId = Cliente.Busca().Find(2).Id,
                Valor = 2000.00,
            }.Salvar();

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
