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
        private IReporitorioSistema repositorioSistema;

        public FichaController()
        {
            repositorioSistema = new EFRepositorioSistema();
        }
        // GET: Ficha
        public ActionResult Index()
        {
            ViewBag.CPF_PESSOA = new SelectList(db.PESSOA, "CPF_PESSOA", "NOM_PESSOA");
            return View();
        }

        [HttpPost]
    public JsonResult CadastrarAluExpecifico(long? CPF)
        {
            var ficha = repositorioSistema.VerificarExistenciaFicha(CPF);
            Session["CPF_Aluno"] = CPF;
            if (ficha == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);            
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
          
        }

        public ActionResult FichasAluno()
        {
            var DadosTreinamento = db.FICHA_SIGLA;
           return View(DadosTreinamento.ToList());
        }

        [HttpPost]
        public JsonResult CadastrarFicha(long? CPF)
        {
            var Ficha = db.FICHA;
            var FichaCont = (int)Ficha.Count();
            FICHA dados = new FICHA();
            long CPF_Convertido = (long)CPF;
            short FichaContConvertido = (short)FichaCont;
            
            dados.CPF_ALUNO = CPF_Convertido;
            dados.COD_FICHA = FichaContConvertido++;
            dados.DTAINI_FICHA = DateTime.Now;

            db.FICHA.Add(dados);
            db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CadastroTipoTreino(long? Cpf, int? Qtd_repet, string TipoSigla)
        {
            var Ficha = db.FICHA_SIGLA;
            FICHA_SIGLA dados = new FICHA_SIGLA();
            long CPF_Convertido = (long)Cpf;
            var CodFicha = db.FICHA.SqlQuery("SELECT COD_FICHA FROM FICHA WHERE DTAFIM_FICHA IS NULL");

            dados.CPF_ALUNO = CPF_Convertido;
            //dados.COD_FICHA = (short)CodFicha;
            dados.QTD_REPET_SIGLA = (byte)Qtd_repet;
            dados.TIPO_SIGLA = TipoSigla;
            db.FICHA_SIGLA.Add(dados);
            db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}