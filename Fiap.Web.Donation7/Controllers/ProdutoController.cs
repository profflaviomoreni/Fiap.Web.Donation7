using Fiap.Web.Donation7.Data;
using Fiap.Web.Donation7.Models;
using Fiap.Web.Donation7.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation7.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ProdutoRepository _produtoRepository;

        public ProdutoController(DataContext dataContext)
        {
            _produtoRepository = new ProdutoRepository(dataContext);
        }



        [HttpGet]
        public IActionResult Index()
        {
            var produtos = _produtoRepository.FindAll();
            return View(produtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(ProdutoModel produtoModel)
        {
            if ( ModelState.IsValid ) {
                _produtoRepository.Insert(produtoModel);
                TempData["SuccessMessage"] = $"Produto {produtoModel.NomeProduto} cadastrado com sucesso";
                return RedirectToAction(nameof(Index));
            } else {
                return View(produtoModel);
            }

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produto = _produtoRepository.FindById(id);
            return View(produto);
        }


        [HttpPost]
        public IActionResult Edit(ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                _produtoRepository.Update(produtoModel);
                TempData["SuccessMessage"] = $"Produto {produtoModel.NomeProduto} alterado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(produtoModel);
            }
        }



        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var produto = _produtoRepository.FindById(id);
            return View(produto);
        }



    }
}
