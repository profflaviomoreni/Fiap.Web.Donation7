using Fiap.Web.Donation7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation7.Controllers
{
    public class ProdutoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Lógica para obter a lista de produtos do banco de dados
            // SELECT * FROM Produtos

            var produtos = ListarProdutosMock();

            // retornar a lista de produtos para a view

            //ViewBag.Produtos = produtos;
            //TempData["Produtos"] = produtos;
            
            return View(produtos);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            // SELECT * FROM Produtos WHERE ProdutoId = id
            var produto = ListarProdutosMock().FirstOrDefault(p => p.ProdutoId == id);

            return View(produto);
        }


        [HttpPost]
        public IActionResult Edit(ProdutoModel produtoModel)
        {

            if ( string.IsNullOrEmpty(produtoModel.SugestaoTroca) )
            {
                ViewBag.ErrorMessage = "A sugestão de troca é obrigatória.";
                return View(produtoModel);
            } else {
                // UPDATE Produtos SET NomeProduto = produtoModel.NomeProduto, CategoriaId = produtoModel.CategoriaId, Disponivel = produtoModel.Disponivel, DataExpiracao = produtoModel.DataExpiracao WHERE ProdutoId = produtoModel.ProdutoId
                TempData["SuccessMessage"] = $"Produto {produtoModel.NomeProduto} alterado com sucesso";
                return RedirectToAction(nameof(Index));
            }            
        }


        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var produto = ListarProdutosMock().FirstOrDefault(p => p.ProdutoId == id);
            return View(produto);
        }




        private List<ProdutoModel> ListarProdutosMock() {
            var produtos = new List<ProdutoModel>{
                new ProdutoModel()
                {
                    ProdutoId = 1,
                    NomeProduto = "Iphone 11",
                    CategoriaId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 2,
                    NomeProduto = "Iphone 12",
                    CategoriaId = 2,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 3,
                    NomeProduto = "Iphone 13",
                    CategoriaId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 4,
                    NomeProduto = "Iphone 14",
                    CategoriaId = 1,
                    Disponivel = false,
                    DataExpiracao = DateTime.Now,
                },
            };

            return produtos;
        } 



    }
}
