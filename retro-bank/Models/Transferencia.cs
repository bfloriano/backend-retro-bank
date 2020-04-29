using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Microsoft.EntityFrameworkCore;

namespace retro_bank.Models
{
    public class Transferencia
    {
        private static DBContext1 _db = new DBContext1();

        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; internal set; }
        public int ClienteRemetenteId { get; set; }
        public int ClienteDestinatarioId { get; set; }


        internal Cliente ClienteDestinatario()
        {
            return Cliente.BuscaPorId(this.ClienteDestinatarioId);
        }

        internal Cliente ClienteRemetente()
        {
            return Cliente.BuscaPorId(this.ClienteRemetenteId);
        }

        internal static List<Transferencia> Lista()
        {
            return _db.Transferencias.ToList();
        }

        public static DbSet<Transferencia> Busca()
        {
            return _db.Transferencias;
        }

        internal bool Salvar()
        {
            try
            {
                _db.Transferencias.Add(this);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static void FazerTranferecia(int clienteRemetenteId,  int clienteDestinatarioId, double valor)
        {
            var transferencia = new Transferencia()
            {
                ClienteDestinatarioId = clienteDestinatarioId,
                ClienteRemetenteId = clienteRemetenteId,
                Valor = valor,
                Data = DateTime.Now,
            };
            transferencia.Salvar();

            Extrato.EfetuarTransferencia(transferencia);
        }
    }

















    /* internal static void Dataa()
     {
         DateTime data = DateTime.Now;
     }*/






    /*
     * 
     * 
     *  internal static double SaldoAtualizado(int ClienteRemetenteId, double Valor)
    {
        double valorI = Extrato.SaldoPorClienteId(ClienteRemetenteId) - Valor;

        return valorI;
    }

    internal double SaldoAtualizadoDestinatario(int ClienteDestinatarioId)
    {
        double valorI = Cliente.Saldo(this.ClienteDestinatarioId);

        return valorI + Valor;
    }*/

    // public ICollection<Cliente> Clientes { get; set; }

    // public Cliente Cliente { get; set; }
    //[ForeignKey("Cliente")]

}

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClienteTransferencia>()
            .HasKey(bc => new
            {
                bc.ClienteId,
                bc.TransfeenciaId
            });
        modelBuilder.Entity<ClienteTransferencia>()
            .HasOne(bc => bc.Cliente)
            .WithMany(b => b.BookCategories)
            .HasForeignKey(bc => bc.BookId);
        modelBuilder.Entity<ClienteTransferencia>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);
    }*/
