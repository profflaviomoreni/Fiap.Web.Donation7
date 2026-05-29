using Fiap.Web.Donation7.Data;
using Fiap.Web.Donation7.Models;
using Fiap.Web.Donation7.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation7.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ProdutoRepository _produtoRepository;

        private readonly CategoriaRepository _categoriaRepository;

        public ProdutoController(DataContext dataContext)
        {
            _produtoRepository = new ProdutoRepository(dataContext);
            _categoriaRepository = new CategoriaRepository(dataContext);
        }



        [HttpGet]
        public IActionResult Index()
        {
            //var produtos = _produtoRepository.FindAllAvailableWithCategoriasAndUsuarios();
            //var produtos = _produtoRepository.FindAllWithCategoriasAndUsuariosByName("iphone");
            var produtos = _produtoRepository.FindAllWithCategoriasAndUsuarios();
            return View(produtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarregarCategorias();
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
                CarregarCategorias();
                return View(produtoModel);
            }

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            CarregarCategorias();
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
                CarregarCategorias();
                return View(produtoModel);
            }
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            _produtoRepository.Delete(id);
            TempData["SuccessMessage"] = $"Produto removido com sucesso";
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var produto = _produtoRepository.FindById(id);
            return View(produto);
        }



        private void CarregarCategorias()
        {
            var categorias = _categoriaRepository.FindAll();
            var selectCategorias = new SelectList(categorias, "CategoriaId", "NomeCategoria");
            ViewBag.Categorias = selectCategorias;
        }

    }
}
