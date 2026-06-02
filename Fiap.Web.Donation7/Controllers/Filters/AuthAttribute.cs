using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fiap.Web.Donation7.Controllers.Filters
{
    public class AuthAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;

            if (session != null)
            {

                int usuarioLogado = session.GetInt32("UsuarioId") ?? 0;
                if (usuarioLogado <= 0)
                {
                    context.Result = new RedirectToActionResult("Index", "Login", null);
                }

            } else
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }


            base.OnActionExecuting(context); // Segue para a ação do controller ou procedimento pedido

        }

    }
}
