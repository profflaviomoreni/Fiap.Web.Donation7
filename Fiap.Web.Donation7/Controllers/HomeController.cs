using Fiap.Web.Donation7.Data;
using Fiap.Web.Donation7.Models;
using Fiap.Web.Donation7.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fiap.Web.Donation7.Controllers
{
    public class HomeController : BaseController
    {

        private readonly ProdutoRepository _produtoRepository;

        public HomeController(DataContext dataContext)
        {
            _produtoRepository = new ProdutoRepository(dataContext);
        }


        public IActionResult Index()
        {
            var produtos = _produtoRepository.FindAllAvailablesForChangeWithCategoriaAndUsuario(UsuarioLogado);
            return View(produtos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
