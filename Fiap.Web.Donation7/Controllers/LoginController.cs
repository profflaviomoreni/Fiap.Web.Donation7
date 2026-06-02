using Fiap.Web.Donation7.Controllers.Filters;
using Fiap.Web.Donation7.Data;
using Fiap.Web.Donation7.Models;
using Fiap.Web.Donation7.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation7.Controllers
{
    public class LoginController : Controller
    {

        private readonly UsuarioRepository _usuarioRepository;

        public LoginController(DataContext dataContext)
        {
            _usuarioRepository = new UsuarioRepository(dataContext);
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioModel usuarioModel)
        {
            try
            {

                if (    usuarioModel != null && 
                        ! string.IsNullOrEmpty(usuarioModel.Email) && 
                        ! string.IsNullOrEmpty(usuarioModel.Senha) )
                {

                    var usuario = _usuarioRepository.FindByEmailAndSenha(usuarioModel.Email, usuarioModel.Senha);

                    if (usuario != null)
                    {

                        HttpContext.Session.SetInt32("UsuarioId", usuario.UsuarioId);
                        HttpContext.Session.SetString("UsuarioNome", usuario.Nome);
                        HttpContext.Session.SetString("UsuarioEmail", usuario.Email);

                        return RedirectToAction(nameof(Index), "Home");
                    } else
                    {
                        throw new Exception("Usuário ou senha inválidos.");
                    }


                    

                } else
                {
                    throw new Exception("Email e senha são obrigatórios.");
                }

            }
            catch (Exception ex) { 
                ViewBag.Mensagem = $"Erro: {ex.Message}";
                return View(nameof(Index), usuarioModel);
            }

        }


        [Auth]
        [HttpGet]
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index), "Home");
        }

    }
}
