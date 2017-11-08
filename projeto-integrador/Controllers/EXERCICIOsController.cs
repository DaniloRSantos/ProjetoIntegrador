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
    [Authentication]
    public class ExerciciosController : Controller
    {
        private Entities db = new Entities();

        // GET: EXERCICIOs
        public ActionResult Index()
        {
            var eXERCICIO = db.EXERCICIO.Include(e => e.GRUPO_MUSCULAR);
            return View(eXERCICIO.ToList());
        }

        // GET: EXERCICIOs/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXERCICIO eXERCICIO = db.EXERCICIO.Find(id);
            if (eXERCICIO == null)
            {
                return HttpNotFound();
            }
            return View(eXERCICIO);
        }

        // GET: EXERCICIOs/Create
        public ActionResult Create()
        {
            ViewBag.COD_GRUMUSC = new SelectList(db.GRUPO_MUSCULAR, "COD_GRUPOMUSCULAR", "NOM_GRUPOMUSCULAR");
            return View();
        }

        // POST: EXERCICIOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_EXERCICIO,COD_GRUMUSC,NOM_EXERCICIO,SIG_EXERCICIO,STA_EXERCICIO,TIP_EXERCICIO")] EXERCICIO eXERCICIO)
        {
            if (ModelState.IsValid)
            {
                db.EXERCICIO.Add(eXERCICIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_GRUMUSC = new SelectList(db.GRUPO_MUSCULAR, "COD_GRUPOMUSCULAR", "NOM_GRUPOMUSCULAR", eXERCICIO.COD_GRUMUSC);
            return View(eXERCICIO);
        }

        // GET: EXERCICIOs/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXERCICIO eXERCICIO = db.EXERCICIO.Find(id);
            if (eXERCICIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_GRUMUSC = new SelectList(db.GRUPO_MUSCULAR, "COD_GRUPOMUSCULAR", "NOM_GRUPOMUSCULAR", eXERCICIO.COD_GRUMUSC);
            return View(eXERCICIO);
        }

        // POST: EXERCICIOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_EXERCICIO,COD_GRUMUSC,NOM_EXERCICIO,SIG_EXERCICIO,STA_EXERCICIO,TIP_EXERCICIO")] EXERCICIO eXERCICIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eXERCICIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_GRUMUSC = new SelectList(db.GRUPO_MUSCULAR, "COD_GRUPOMUSCULAR", "NOM_GRUPOMUSCULAR", eXERCICIO.COD_GRUMUSC);
            return View(eXERCICIO);
        }

        // GET: EXERCICIOs/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXERCICIO eXERCICIO = db.EXERCICIO.Find(id);
            if (eXERCICIO == null)
            {
                return HttpNotFound();
            }
            return View(eXERCICIO);
        }

        // POST: EXERCICIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            EXERCICIO eXERCICIO = db.EXERCICIO.Find(id);
            db.EXERCICIO.Remove(eXERCICIO);
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
