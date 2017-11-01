using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto_Integrador.Models.Database;

namespace Projeto_Integrador.Controllers
{
    public class PessoasController : Controller
    {
        private Entities db = new Entities();

        // GET: PESSOAs
        public ActionResult Index()
        {
            var pESSOA = db.PESSOA.Include(p => p.ALUNO).Include(p => p.FUNCIONARIO);
            return View(pESSOA.ToList());
        }

        // GET: PESSOAs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PESSOA pESSOA = db.PESSOA.Find(id);
            if (pESSOA == null)
            {
                return HttpNotFound();
            }
            return View(pESSOA);
        }

        // GET: PESSOAs/Create
        public ActionResult Create()
        {
            ViewBag.CPF_PESSOA = new SelectList(db.ALUNO, "CPF_ALUNO", "CPF_ALUNO");
            ViewBag.CPF_PESSOA = new SelectList(db.FUNCIONARIO, "CPF_PESSOA", "CTP_PESSOA");
            return View();
        }

        // POST: PESSOAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMA_PESSOA,SEN_PESSOA,NOM_PESSOA,SNO_PESSOA,DCA_PESSOA,CPF_PESSOA,RG_PESSOA,DNA_PESSOA,SEX_PESSOA,PAI_PESSOA,CID_PESSOA,BAI_PESSOA,END_PESSOA,NEN_PESSOA,CEP_PESSOA,TEL_PESSOA,TEM_PESSOA")] PESSOA pESSOA)
        {
            if (ModelState.IsValid)
            {
                db.PESSOA.Add(pESSOA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CPF_PESSOA = new SelectList(db.ALUNO, "CPF_ALUNO", "CPF_ALUNO", pESSOA.CPF_PESSOA);
            ViewBag.CPF_PESSOA = new SelectList(db.FUNCIONARIO, "CPF_PESSOA", "CTP_PESSOA", pESSOA.CPF_PESSOA);
            return View(pESSOA);
        }

        // GET: PESSOAs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PESSOA pESSOA = db.PESSOA.Find(id);
            if (pESSOA == null)
            {
                return HttpNotFound();
            }
            ViewBag.CPF_PESSOA = new SelectList(db.ALUNO, "CPF_ALUNO", "CPF_ALUNO", pESSOA.CPF_PESSOA);
            ViewBag.CPF_PESSOA = new SelectList(db.FUNCIONARIO, "CPF_PESSOA", "CTP_PESSOA", pESSOA.CPF_PESSOA);
            return View(pESSOA);
        }

        // POST: PESSOAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CPF_PESSOA,NOM_PESSOA,SNO_PESSOA,DNA_PESSOA,DCA_PESSOA,SEX_PESSOA,PAI_PESSOA,CID_PESSOA,BAI_PESSOA,END_PESSOA,NEN_PESSOA,CEP_PESSOA,TEL_PESSOA,TEM_PESSOA,RG_PESSOA,SEN_PESSOA,EMA_PESSOA,FPE_PESSOA")] PESSOA pESSOA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pESSOA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CPF_PESSOA = new SelectList(db.ALUNO, "CPF_ALUNO", "CPF_ALUNO", pESSOA.CPF_PESSOA);
            ViewBag.CPF_PESSOA = new SelectList(db.FUNCIONARIO, "CPF_PESSOA", "CTP_PESSOA", pESSOA.CPF_PESSOA);
            return View(pESSOA);
        }

        // GET: PESSOAs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PESSOA pESSOA = db.PESSOA.Find(id);
            if (pESSOA == null)
            {
                return HttpNotFound();
            }
            return View(pESSOA);
        }

        // POST: PESSOAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PESSOA pESSOA = db.PESSOA.Find(id);
            db.PESSOA.Remove(pESSOA);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
