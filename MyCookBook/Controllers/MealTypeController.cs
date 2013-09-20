using System.Data;
using System.Linq;
using System.Web.Mvc;
using MyCookBook.Models;

namespace MyCookBook.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MealTypeController : Controller
    {
        private RecipesDataContext db = new RecipesDataContext();

        //
        // GET: /MealType/
       
        public ActionResult Index()
        {
            return View(db.MealTypes.ToList());
        }

        //
        // GET: /MealType/Details/5
     
        public ActionResult Details(int id = 0)
        {
            MealType mealtype = db.MealTypes.Find(id);
            if (mealtype == null)
            {
                return HttpNotFound();
            }
            return View(mealtype);
        }

        //
        // GET: /MealType/Create
        
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MealType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create(MealType mealtype)
        {
            if (ModelState.IsValid)
            {
                db.MealTypes.Add(mealtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mealtype);
        }

        //
        // GET: /MealType/Edit/5
         
        public ActionResult Edit(int id = 0)
        {
            MealType mealtype = db.MealTypes.Find(id);
            if (mealtype == null)
            {
                return HttpNotFound();
            }
            return View(mealtype);
        }

        //
        // POST: /MealType/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Edit(MealType mealtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mealtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mealtype);
        }

        //
        // GET: /MealType/Delete/5
         [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id = 0)
        {
            MealType mealtype = db.MealTypes.Find(id);
            if (mealtype == null)
            {
                return HttpNotFound();
            }
            return View(mealtype);
        }

        //
        // POST: /MealType/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
       
        public ActionResult DeleteConfirmed(int id)
        {
            MealType mealtype = db.MealTypes.Find(id);
            db.MealTypes.Remove(mealtype);
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