using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantWebApp.Files;
using RestaurantWebApp.Models;

namespace RestaurantWebApp.Controllers
{
    public class AdministratorController : Controller
    {

        
        public ActionResult Administrator()
        {
            return View();
        }


        public ActionResult GetData()
        {
            using(skfEntities db = new skfEntities())
            {
                List<users> userList = db.users.ToList<users>();
                return Json(new { data = userList },JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            return View(new users());
        }


        [HttpPost]
        public ActionResult AddOrEdit(users user)
        {
            using(skfEntities db = new skfEntities())
            {
                db.users.Add(user);
                db.SaveChanges();
                return Json(new { sucess = true, message = "Registro añadido exitosamente" },JsonRequestBehavior.AllowGet);
            }



            return View();
        }

    }
}