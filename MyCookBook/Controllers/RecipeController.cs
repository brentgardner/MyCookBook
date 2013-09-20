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
    public class RecipeController : Controller
    {
        private RecipesDataContext db = new RecipesDataContext();

        //
        // GET: /Recipe/
        [Authorize]
        public ActionResult Index()
        {
            var recipes = db.Recipes.Include(r => r.User).Include(r => r.Category).Include(r => r.MealType);
            return View(recipes.ToList());
        }

        //
        // GET: /Recipe/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        //
        // GET: /Recipe/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.MealTypeId = new SelectList(db.MealTypes, "MealTypeId", "Name");
            return View();
        }

        //
        // POST: /Recipe/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", recipe.UserId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", recipe.CategoryId);
            ViewBag.MealTypeId = new SelectList(db.MealTypes, "MealTypeId", "Name", recipe.MealTypeId);
            return View(recipe);
        }

        //
        // GET: /Recipe/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", recipe.UserId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", recipe.CategoryId);
            ViewBag.MealTypeId = new SelectList(db.MealTypes, "MealTypeId", "Name", recipe.MealTypeId);
            return View(recipe);
        }

        //
        // POST: /Recipe/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", recipe.UserId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", recipe.CategoryId);
            ViewBag.MealTypeId = new SelectList(db.MealTypes, "MealTypeId", "Name", recipe.MealTypeId);
            return View(recipe);
        }

        //
        // GET: /Recipe/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        //
        // POST: /Recipe/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
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