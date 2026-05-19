using Fiap.Web.Donation7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation7.Controllers
{
    public class ClienteController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Cadastrar(ClienteModel cliente)
        {
            //var nome = Request.Form["nome"];
            //var sobrenome = Request.Form["sobrenome"];

            // ... processamento dos dados, como salvar no banco de dados, etc.
            // INSERT into Cliente (Nome, Sobrenome) VALUES (nome, sobrenome)

            return View("Sucesso");
        }


        [HttpGet]
        public IActionResult Help()
        {
            return View();
        }

    }
}
