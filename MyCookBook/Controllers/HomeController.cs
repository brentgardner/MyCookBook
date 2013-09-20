using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCookBook.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to MyCookBook";

            return View();
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "MyCookbook is a recipe sharing application.";

            return View();
        }

        
        public ActionResult Contact()
        {
            ViewBag.Message = "Don't contact us.";

            return View();
        }
    }
}
