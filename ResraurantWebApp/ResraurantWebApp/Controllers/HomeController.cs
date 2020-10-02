using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResraurantWebApp.Filters;

namespace ResraurantWebApp.Controllers
{
    public class HomeController : Controller
    {

        [AuthorizeUser(idRole:1)]
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeUser(idRole:2)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AuthorizeUser(idRole:3)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        
    }
}