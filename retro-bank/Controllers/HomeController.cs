using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using retro_bank.Models;

namespace retro_bank.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return Json(Cliente.Lista(), JsonRequestBehavior.AllowGet);
        }
                
        [HttpGet]
        public ActionResult Get(int id)
        {
            return Json(Cliente.Busca().Where(c => c.Id == id).First(), JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public ActionResult Alterar(int id)
        {
            var cliente = Cliente.Busca().Where(c => c.Id == id).First();
            // Request.QueryString
            cliente.Nome = Request.Params["Nome"];
            
            //cliente.Nome = Request["Nome"];
            //cliente.CPF = Request["CPF"];
            
            //cliente.Telefone = Convert.ToInt32(Request["Telefone"]);
            return Json(cliente);
        }

        [HttpPost]
        public ActionResult Criar()
        {
            var cliente = new Cliente();
            cliente.Nome = Request["Nome"];
        
            //cliente.Telefone = Convert.ToInt32(Request["Telefone"]);
            cliente.Salvar();
            return Json(cliente);
        }

      



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
