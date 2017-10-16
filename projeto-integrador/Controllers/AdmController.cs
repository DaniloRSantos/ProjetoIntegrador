using Projeto_Integrador.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Integrador.Controllers
{
    [Authentication]
    public class AdmController : Controller
    {
        // GET: Adm
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sobre()
        {
            return View();
        }
    }
}