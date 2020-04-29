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



        public static List<Cliente> Lista()
        {
            return _db.Clientes.ToList();
        }

        public static DbSet<Cliente> Busca()
        {
            return _db.Clientes;
        }

        internal static Cliente BuscaPorId(int clienteId)
        {
            var cliente = Cliente.Busca().Where(c => c.Id == clienteId).First();
            cliente.SaldoI = Cliente.SaldoPorId(cliente.Id);
            return cliente;
        }

        internal static double SaldoPorId(int clienteId)
        {
            //var cliente = Cliente.Busca().Where(c => c.Id == clienteId).First();
            return Extrato.SaldoPorClienteId(clienteId);
        }

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

      
    }

}