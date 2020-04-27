﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace retro_bank.Models
{
    public class Cliente
    {
        private static DBContext _db = new DBContext();
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Senha { get; set; }

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

        public static List<Cliente> Lista() { return _db.Clientes.ToList(); }

        public static DbSet<Cliente> Busca()
        {
            return _db.Clientes;
        }

    }


}