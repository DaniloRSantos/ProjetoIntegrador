using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto_Integrador.Models.Database;
using Projeto_Integrador.Attributes;

namespace Projeto_Integrador.Controllers
{
    [Authentication]
    public class GrupoMuscularController : Controller
    {
        private Entities db = new Entities();

        // GET: GRUPO_MUSCULAR
        public ActionResult Index()
        {
            return View(db.GRUPO_MUSCULAR.ToList());
        }

        // GET: GRUPO_MUSCULAR/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRUPO_MUSCULAR gRUPO_MUSCULAR = db.GRUPO_MUSCULAR.Find(id);
            if (gRUPO_MUSCULAR == null)
            {
                return HttpNotFound();
            }
            return View(gRUPO_MUSCULAR);
        }

        // GET: GRUPO_MUSCULAR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GRUPO_MUSCULAR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_GRUPOMUSCULAR,NOM_GRUPOMUSCULAR")] GRUPO_MUSCULAR gRUPO_MUSCULAR)
        {
            if (ModelState.IsValid)
            {
                db.GRUPO_MUSCULAR.Add(gRUPO_MUSCULAR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gRUPO_MUSCULAR);
        }

        // GET: GRUPO_MUSCULAR/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRUPO_MUSCULAR gRUPO_MUSCULAR = db.GRUPO_MUSCULAR.Find(id);
            if (gRUPO_MUSCULAR == null)
            {
                return HttpNotFound();
            }
            return View(gRUPO_MUSCULAR);
        }

        // POST: GRUPO_MUSCULAR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_GRUPOMUSCULAR,NOM_GRUPOMUSCULAR")] GRUPO_MUSCULAR gRUPO_MUSCULAR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gRUPO_MUSCULAR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gRUPO_MUSCULAR);
        }

        // GET: GRUPO_MUSCULAR/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRUPO_MUSCULAR gRUPO_MUSCULAR = db.GRUPO_MUSCULAR.Find(id);
            if (gRUPO_MUSCULAR == null)
            {
                return HttpNotFound();
            }
            return View(gRUPO_MUSCULAR);
        }

        // POST: GRUPO_MUSCULAR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            GRUPO_MUSCULAR gRUPO_MUSCULAR = db.GRUPO_MUSCULAR.Find(id);
            db.GRUPO_MUSCULAR.Remove(gRUPO_MUSCULAR);
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
