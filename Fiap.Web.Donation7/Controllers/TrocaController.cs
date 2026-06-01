using Fiap.Web.Donation7.Data;
using Fiap.Web.Donation7.Models;
using Fiap.Web.Donation7.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation7.Controllers
{
    public class TrocaController : Controller
    {
        private readonly int UsuarioLogado = 1; // Simulando um usuário logado com ID 1

        private readonly ProdutoRepository _produtoRepository;
        private readonly TrocaRepository _trocaRepository;

        public TrocaController(DataContext dataContext)
        {
            _produtoRepository = new ProdutoRepository(dataContext);
            _trocaRepository = new TrocaRepository(dataContext);
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var trocaModel = new TrocaModel();
            trocaModel.ProdutoEscolhido = _produtoRepository.FindById(id);
            
            var meusProdutos = _produtoRepository.FindAllAvailablesWithCategoriaAndUsuarioByUserId(UsuarioLogado);
            ViewBag.MeusProdutos = new SelectList(meusProdutos, "ProdutoId", "NomeProduto");

            return View(trocaModel);
        }


        [HttpPost]
        public IActionResult Index(TrocaModel trocaModel)
        {
            try
            {
                var produtoEscolhido = _produtoRepository.FindById(trocaModel.ProdutoIdEscolhido);
                var produtoMeu = _produtoRepository.FindById(trocaModel.ProdutoIdMeu);

                if ( ! produtoEscolhido.Disponivel  )
                {
                    throw new Exception("Produto escolhido não está disponível para troca.");
                }

                if (!produtoMeu.Disponivel)
                {
                    throw new Exception("O meu produto não está disponível para troca.");
                }

                if ( (produtoMeu.Valor / produtoEscolhido.Valor) < 0.9 )
                {
                    throw new Exception("O valor do seu produto é muito inferior ao valor do produto escolhido. A diferença deve ser no máximo 10%.");
                }


                if (produtoMeu.UsuarioId != UsuarioLogado)
                {
                    throw new Exception("Possível Fraude, você escolheu um produto que não é seu.");
                }

                if (produtoEscolhido.UsuarioId == UsuarioLogado)
                {
                    throw new Exception("Não é possível escolher um produto que você mesmo cadastrou.");
                }

                produtoEscolhido.Disponivel = false;
                _produtoRepository.Update(produtoEscolhido);

                produtoMeu.Disponivel = false;
                _produtoRepository.Update(produtoMeu);


                trocaModel.TrocaStatus = TrocaStatus.Iniciado;
                _trocaRepository.Insert(trocaModel);

                TempData["MensagemSucesso"] = "Troca iniciada com sucesso! O produto escolhido agora está indisponível para outros usuários.";
            } catch (Exception ex) {
                TempData["MensagemErro"] = $"Erro ao iniciar a troca: {ex.Message}";
            }

            return RedirectToAction(nameof(Index), "Home");

        }

    }
}
