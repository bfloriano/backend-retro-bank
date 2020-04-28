using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;
using retro_bank.Models;

namespace retro_bank.Migrations
{
    public partial class SeedExtrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            new Extrato()
            {
                ClienteId = Cliente.Busca().First().Id,
                Valor = 1000.00,
                Descricao = "credito aula",
                Tipo = TipoOperacao.Credito,
            }.Salvar();

            new Extrato()
            {
                ClienteId = Cliente.Busca().First().Id,
                Valor = 70.00,
                Descricao = "lanche BurgerQueen",
                Tipo = TipoOperacao.Debito,
            }.Salvar();

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
