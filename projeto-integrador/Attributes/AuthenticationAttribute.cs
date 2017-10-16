using Projeto_Integrador.Repository.EFRepository;
using Projeto_Integrador.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Integrador.Attributes
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session["CPF_Usuario"] == null)
            {
                context.Result = new RedirectResult(string.Format("/Conta/Entrar", context.HttpContext.Request.Url.AbsolutePath));
            }             
        }
    }
}