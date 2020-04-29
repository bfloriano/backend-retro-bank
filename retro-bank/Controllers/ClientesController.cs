using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using retro_bank.Models;

namespace retro_bank.Controllers
{
    [Route("")]
    [Route("clientes")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientesController : ApiController
    {
        
        [HttpGet]
        public List<Cliente> Index()
        {
            return Cliente.Lista();
            
        }
                
        [Route("clientes/{id}")]
        [HttpGet]
        public Cliente Get(int id)
        {
            return Cliente.BuscaPorId(id);
        }

        [Route("clientes/{id}/saldo")]
        [HttpGet]
        public object Saldo(int clienteId)
        {
            return new
            {
                Saldo = Cliente.SaldoPorId(clienteId)
            };
        }

        [HttpPost]
        [Route("clientes/login")]
        public object Login([FromBody] Cliente cliente)
        {
            try
            {
                var ret = (
                   from c in Cliente.Busca()
                   where c.CPF == cliente.CPF && c.Senha == cliente.Senha
                   select new
                   {
                       Nome = c.Nome,
                       Agencia = c.Agencia,
                       Conta = c.Conta,
                       Id = c.Id,
                   }
               ).First();
                return ret;
            }
            catch
            {
                return new { Erro = "CPF ou senha inválido" };
            }
        }

        /*
        [HttpPut]
        Atualizacao de dados
       
        [HttpPost]
        Criacao de usuarios
        */

    }
}
