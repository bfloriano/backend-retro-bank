﻿using System;
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

        [HttpGet]
        [Route("extrato/{clienteId}")]
        public object Index(int clienteId)
        {
            var cliente = Cliente.BuscaPorId(clienteId);

            var Saldo = Extrato.SaldoPorClienteId(clienteId);
            //var extrato = cliente.ListaExtrato();


        return Saldo; 


        }

    }
}
