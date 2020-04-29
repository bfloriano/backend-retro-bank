using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using retro_bank.Models;

namespace retro_bank.Controllers
{

    [Route("extrato")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExtratoController : ApiController
    {
        [HttpGet]
        public List<Extrato> Index()
        {
            return Extrato.Lista();
        }

        [Route("extrato/{id}")]
        [HttpGet]
        public Extrato Get(int id)
        {
            return Extrato.Busca().Where(c => c.Id == id).First();
        }

        [HttpGet]
        [Route("clientes/extrato/{clienteId}")]

        public List<Extrato> GetExtrato(int clienteId)
        {
            return Extrato.Busca().Where(e => e.ClienteId == clienteId).ToList();

        }
           

    }
}
