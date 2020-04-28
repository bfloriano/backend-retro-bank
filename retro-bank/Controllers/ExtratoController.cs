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

    //[Route("extrato")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExtratoController : ApiController
    {
        [HttpGet]
        [Route("extrato/{clienteId}")]
        public object Index(int clienteId)
        {
            var cliente = Cliente.BuscaPorId(clienteId);
            return new
            {
                //Saldo = cliente.Saldo(clienteId),
                Extrato = cliente.ListaExtrato()
            };

        }

    }
}
