using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCookBook.Models;

namespace MyCookBook.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class UnitOfMeasureController : Controller
    {
        private RecipesDataContext db = new RecipesDataContext();

        //
        // GET: /UnitOfMeasure/

        public ActionResult Index()
        {
            return View(db.UnitOfMeasures.ToList());
        }

        //
        // GET: /UnitOfMeasure/Details/5

        public ActionResult Details(int id = 0)
        {
            UnitOfMeasure unitofmeasure = db.UnitOfMeasures.Find(id);
            if (unitofmeasure == null)
            {
                return HttpNotFound();
            }
            return View(unitofmeasure);
        }

        //
        // GET: /UnitOfMeasure/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UnitOfMeasure/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UnitOfMeasure unitofmeasure)
        {
            if (ModelState.IsValid)
            {
                db.UnitOfMeasures.Add(unitofmeasure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unitofmeasure);
        }

        //
        // GET: /UnitOfMeasure/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UnitOfMeasure unitofmeasure = db.UnitOfMeasures.Find(id);
            if (unitofmeasure == null)
            {
                return HttpNotFound();
            }
            return View(unitofmeasure);
        }

        //
        // POST: /UnitOfMeasure/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UnitOfMeasure unitofmeasure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unitofmeasure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unitofmeasure);
        }

        //
        // GET: /UnitOfMeasure/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UnitOfMeasure unitofmeasure = db.UnitOfMeasures.Find(id);
            if (unitofmeasure == null)
            {
                return HttpNotFound();
            }
            return View(unitofmeasure);
        }

        //
        // POST: /UnitOfMeasure/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnitOfMeasure unitofmeasure = db.UnitOfMeasures.Find(id);
            db.UnitOfMeasures.Remove(unitofmeasure);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}