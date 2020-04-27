using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace retro_bank.Models
{
    public class Transferencia
    {
        private static DBContext _db = new DBContext();
        public int Id { get; set; }
        public double Valor { get; set; }
        public string Data { get; set; }




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
}