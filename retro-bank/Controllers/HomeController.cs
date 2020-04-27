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
    public class HomeController : ApiController
    {
        
        [HttpGet]
        public List<Cliente> Index()
        {
            return Cliente.Lista();
        }
                
        [Route("{id}")]
        [HttpGet]
        public Cliente Get(int id)
        {
            return Cliente.Busca().Where(c => c.Id == id).First();
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
                       Conta = c.Conta,
                       Agencia = c.Agencia,
                       Id = c.Id,
                   }
               ).First();
                return ret;
            }
            catch
            {
                return new { Erro = "Login ou senha inválido" };
            }
        }

        /*[HttpPut]
        public ActionResult Alterar(int id)
        {
             var cliente = Cliente.Busca().Where(c => c.Id == id).First();
            //cliente.Nome = Request.QueryString["Nome"];
            //cliente.Nome = Request.Params["Nome"];

            cliente.Nome = Request["Nome"];
            //cliente.CPF = Request["CPF"];
            //cliente.Nome = cliente.Nome;

                       
            //cliente.Salvar();
            return Json(cliente);
        }

       

        //where c.Agencia == cliente.Agencia && c.Conta == cliente.Conta && c.Senha == cliente.Senha

        [HttpPost]
        public ActionResult Criar()
        {
            var cliente = new Cliente();
            cliente.Nome = Request["Nome"];
        
            //cliente.Telefone = Convert.ToInt32(Request["Telefone"]);
            cliente.Salvar();
            return Json(cliente);
        }

      */



        // ------------ Para popular o banco de dados: -----------


        /*
    public ActionResult Index()
    {

        var newCliente = new Cliente()
        {
            Nome = "jo",
            CPF = "234.467.444-90",
            Agencia = "101-0",
            Conta = "12345-7",
            Senha = "hahaha"

        }.Salvar();


        var clientes = Cliente.Lista();

        ViewBag.Title = "Home Page";
        ViewBag.clientes = clientes;

        return View();
    } */

    }
}
