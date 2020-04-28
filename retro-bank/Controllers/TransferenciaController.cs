using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using retro_bank.Models;

namespace retro_bank.Controllers
{
    //[Route("")]
    [Route("transferencia")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TransferenciaController : ApiController
    {
        [HttpGet]
        public List<Transferencia> Index()
        {
            return Transferencia.Lista();
        }

        [Route("transferencia/{id}")]
        [HttpGet]
        public Transferencia Get(int id)
        {
            return Transferencia.Busca().Where(c => c.Id == id).First();
        }

        /*
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
                       CPF = c.CPF,
                       Agencia = c.Agencia,
                       Conta = c.Conta,
                       Senha = c.Senha,
                       Id = c.Id,
                   }
               ).First();
                return ret;
            }
            catch
            {
                return new { Erro = "CPF ou senha inválido" };
            }
        }*/
    }
}