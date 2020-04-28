using Microsoft.EntityFrameworkCore.Migrations;
using retro_bank.Models;

namespace retro_bank.Migrations.DBContext2Migrations
{
    public partial class SeedTransferencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            new Transferencia() { Valor = 100.00, Data = "27/04/2020 - 17:26" }.Salvar();
            new Transferencia() { Valor = 210.00, Data = "27/04/2020 - 17:33" }.Salvar();
            new Transferencia() { Valor = 1030.00, Data = "28/04/2020 - 01:59" }.Salvar();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
