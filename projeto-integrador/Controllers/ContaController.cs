using Projeto_Integrador.Attributes;
using Projeto_Integrador.Models.Database;
using Projeto_Integrador.Models.ViewModels;
using Projeto_Integrador.Repository.EFRepository;
using Projeto_Integrador.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Integrador.Controllers
{
    public class ContaController : Controller
    {
        private IRepositorioConta repositorioConta;

        public ContaController()
        {
            repositorioConta = new EFRepositorioConta();
        }

        // GET: Conta
        public ActionResult Entrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrar(LoginModel model)
        {
            var loginRealizado = RealizarLogin(model);
            if (loginRealizado)
            {
                long CPF = (long)Session["CPF_Usuario"];
                var dados = repositorioConta.VerificaTipoUsuario(CPF);
                if (dados == false)
                { 
                return RedirectToAction("Inicio", "Sistema");
                }
                else
                {
                    return RedirectToAction("Index", "Adm");
                }
            }

            ModelState.Clear();
            ModelState.AddModelError("", "Usuário ou Senha incorretos!");
            return View(model);
        }

        private bool RealizarLogin(LoginModel model)
        {

            if (repositorioConta.VerificaDadosLogin(model.Email, model.Senha))
            {
                PESSOA usuario = repositorioConta.ProcuraUsuarioPorEmail(model.Email);
                Session["CPF_Usuario"] = usuario.CPF_PESSOA;
                return true;
            }
            return false;
        }

        public ActionResult Sair()
        {
            Session["CPF_Usuario"] = null;
            return RedirectToAction("Entrar");
        }
    }
}