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

        [HttpPost]
        [Route("clientes/login")]
        public object Login([FromBody] Cliente cliente)
        {
           //try
           //{
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
           //}
           //catch
           //{
           //     return new { Erro = "CPF ou senha inválido" };
           //}
        }

        [HttpPost]
        [Route("clientes/create")]
        public void Create([FromBody] Cliente cliente)
        {
            try
            {
                Cliente.Criar(
                    cliente.Nome,
                    cliente.CPF,
                    cliente.Agencia,
                    cliente.Conta,
                    cliente.Senha);
            }
            catch
            {
                //new { Erro = "Não foi possível criar a conta. Tente novamente" };
            }
        }


        /*
         
      [HttpDelete]
      [Route("clientes/{id}")]
      public void Delete([FromUri] Cliente cliente)
      {
          Cliente.Apagar();
      }


      [HttpPut]
      Atualizacao de dados

   
      */

    }


}
