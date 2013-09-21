﻿using System.Data;
using System.Linq;
using System.Web.Mvc;
using MyCookBook.Models;

namespace MyCookBook.Controllers
{
     [Authorize(Roles = "Administrator")]
    public class IngredientController : Controller
    {
        private RecipesDataContext db = new RecipesDataContext();

        //
        // GET: /INgredient/

        public ActionResult Index()
        {
            return View(db.Ingredients.ToList());
        }

        //
        // GET: /INgredient/Details/5

        public ActionResult Details(int id = 0)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        //
        // GET: /INgredient/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /INgredient/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                db.Ingredients.Add(ingredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingredient);
        }

        //
        // GET: /INgredient/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        //
        // POST: /INgredient/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

        //
        // GET: /INgredient/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        //
        // POST: /INgredient/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            db.Ingredients.Remove(ingredient);
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