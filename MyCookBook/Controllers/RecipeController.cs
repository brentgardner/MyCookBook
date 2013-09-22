using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MyCookBook.Models;

namespace MyCookBook.Controllers
{
    [Authorize(Roles = "users")]
    public class RecipeController : Controller
    {
        private RecipesDataContext db = new RecipesDataContext();

        //
        // GET: /Recipe/
       
        public ActionResult Index()
        {
            var recipes = db.Recipes.Include(r => r.User).Include(r => r.Category).Include(r => r.MealType).Include(r => r.Ingredients);
            return View(recipes.ToList());
        }

        //
        // GET: /Recipe/Details/5
  
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
        
        public ActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipe);
                foreach (var ingredient in recipe.Ingredients)
                {
                    db.Ingredients.Add(ingredient);
                }

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