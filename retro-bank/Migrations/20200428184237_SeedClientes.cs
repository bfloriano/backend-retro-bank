using Microsoft.EntityFrameworkCore.Migrations;
using retro_bank.Models;

namespace retro_bank.Migrations
{
    public partial class SeedClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            new Cliente() { Nome = "Bruna Floriano", Agencia = "001", Conta = "123456", CPF = "111.111.111-11", Senha = "12345", SaldoI = 100.76 }.Salvar();
            new Cliente() { Nome = "Andreza Amorim", Agencia = "001", Conta = "543210", CPF = "222.222.222-22", Senha = "12345", SaldoI = 0.76 }.Salvar();
            new Cliente() { Nome = "Natalia Thomé", Agencia = "002", Conta = "638304", CPF = "333.333.333-33", Senha = "12345", SaldoI = 7600.98 }.Salvar();
            new Cliente() { Nome = "Renata Secco", Agencia = "002", Conta = "107128", CPF = "444.444.444-44", Senha = "12345", SaldoI = 500.00 }.Salvar();
            new Cliente() { Nome = "Joanilza Bockhorny", Agencia = "002", Conta = "909090", CPF = "555.555.555-55", Senha = "12345", SaldoI = 70.00 }.Salvar();

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
