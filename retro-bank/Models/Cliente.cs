using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace retro_bank.Models
{
    public class Cliente
    {
        private static DBContext1 _db = new DBContext1();
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Senha { get; set; }
        public double SaldoI { get; set; }

        internal static Cliente BuscaPorId(int clienteId)
        {
            return Cliente.Busca().Where(c => c.Id == clienteId).First();
        }

        internal List<Extrato> ListaExtrato()
        {
            return Extrato.Lista(this.Id);
        }

        internal static double Saldo(int Id, double SaldoI)
        {
            return SaldoI + Transferencia.SaldoAtualizado(Id, SaldoI);
        }

        // public int TransferenciaId { get; set; }
        //public Transferencia Transferencia { get; set; }


        //public ICollection<Transferencia> Transferencias { get; set; }

        //  public ICollection<Extrato> Extratos { get; set; }

        public bool Salvar()
        {
            try
            {
                _db.Clientes.Add(this);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal void Apagar()
        {
            _db.Clientes.Remove(this);
            _db.SaveChanges();
        }

        public static List<Cliente> Lista() 
        { 
            return _db.Clientes.ToList(); 
        }

        public static DbSet<Cliente> Busca()
        {
            return _db.Clientes;
        }

    }


}