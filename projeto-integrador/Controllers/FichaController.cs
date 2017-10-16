using Projeto_Integrador.Models.Database;
using Projeto_Integrador.Repository.EFRepository;
using Projeto_Integrador.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Integrador.Controllers
{
    public class FichaController : Controller
    {
        private Entities db = new Entities();

        // GET: Ficha
        public ActionResult Index()
        {
            ViewBag.CPF_PESSOA = new SelectList(db.PESSOA, "CPF_PESSOA", "NOM_PESSOA");
            return View();
        }

        [HttpPost]
    public JsonResult CadastrarAluExpecifico(long? CPF)
        {
            if (CPF == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}