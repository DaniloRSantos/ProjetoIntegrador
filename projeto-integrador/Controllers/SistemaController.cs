using Projeto_Integrador.Attributes;
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
    [Authentication]
    public class SistemaController : Controller
    {
        private IReporitorioSistema repositorioSistema;

        public SistemaController()
        {
            repositorioSistema = new EFRepositorioSistema();
        }

        // GET: Sistema
        public ActionResult Inicio()
        {
            long CPF = (long)Session["CPF_Usuario"];

            TREINAMENTO dadosTreinamento = repositorioSistema.ProcurarProximoTreinamento(CPF);
            EXERCICIO dadosExercicio = repositorioSistema.ProcurarExercicioPorCodigo(dadosTreinamento.COD_EXERCICIO);

            ViewBag.NomeExercicio = dadosExercicio.NOM_EXERCICIO;
            ViewBag.RepeticoesExercicio = dadosTreinamento.REP_TREINAMENTO;
            ViewBag.SeriesExercicio = dadosTreinamento.SER_TREINAMENTO;

            return View();
        }

        public ActionResult Sobre()
        {
            return View();
        }
    }
}