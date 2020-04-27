using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;
using retro_bank.Models;

namespace retro_bank.Migrations
{
    public partial class SeedClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            new Cliente() { Nome = "Bruna", Agencia = "001", Conta = "12345", CPF = "111.111", Senha = "12345" }.Salvar();
            new Cliente() { Nome = "Andreza", Agencia = "001", Conta = "54321", CPF = "111.222", Senha = "12345" }.Salvar();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            Cliente.Busca().Where(c => c.Nome == "Bruna").First().Apagar();
            Cliente.Busca().Where(c => c.Nome == "Andreza").First().Apagar();
        }
    }
}
