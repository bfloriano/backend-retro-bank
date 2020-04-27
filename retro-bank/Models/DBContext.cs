using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace retro_bank.Models
{
    public class DBContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = "";
            try
            {
                config = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;
            }
            catch
            {
                //config = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Retro_Bank_Clientes;Data Source=WIN-VWQVJHQQJK\SQLEXPRESS";
                config = @"Server=tcp:retro-bank.database.windows.net,1433;Initial Catalog=retro-bank; Initial Catalog=api-tranferencia;Persist Security Info=True;User ID=bfloriano;Password=Avanade@2020; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
            optionsBuilder.UseSqlServer(config);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
        //public DbSet<Extrato> Extrato { get; set; }
 


    }
}
