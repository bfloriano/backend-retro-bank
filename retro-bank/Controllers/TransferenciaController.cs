using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using retro_bank.Models;

namespace retro_bank.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class TransferenciaController : ApiController
    {
       
        [Route("transferencia")]
        [HttpPost]
        public void FazerTransferencia([FromBody] TransferenciaPost transrefenciaPost)
        {
            Transferencia.FazerTranferecia(
                transrefenciaPost.clienteRemetenteId,
                transrefenciaPost.clienteDestinatarioId, 
                transrefenciaPost.valor);
        }

        [Route("transferencia/{id}")]
        [HttpGet]
        public Transferencia Get(int id)
        {
            return Transferencia.Busca().Where(c => c.Id == id).First();
        }

    }

    public class TransferenciaPost
    {
        public int clienteRemetenteId { get; set; }
        public int clienteDestinatarioId { get; set; }
        public double valor { get; set; }
    }
}