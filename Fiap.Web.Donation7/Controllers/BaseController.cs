using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation7.Controllers
{
    public class BaseController : Controller
    {
        
        protected int UsuarioLogado => HttpContext.Session.GetInt32("UsuarioId") ?? 0;

        protected string UsuarioNome => HttpContext.Session.GetString("UsuarioNome") ?? string.Empty;

        protected string UsuarioEmail => HttpContext.Session.GetString("UsuarioEmail") ?? string.Empty;

        protected bool IsUserLoggedIn => UsuarioLogado > 0;


    }
}
