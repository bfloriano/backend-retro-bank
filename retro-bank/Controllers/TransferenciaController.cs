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

        [Route("transferencia/fazer")]
        [HttpPost]
        public void FazerTransferencia(int clienteRemetenteId, int clienteDestinatarioId, double valor)
        {
            Transferencia.FazerTranferecia(clienteRemetenteId, clienteDestinatarioId, valor);
        }

    }
}