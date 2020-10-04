using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantWebApp.Controllers
{
    public class AccessController : Controller
    {


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string user, string password)
        {
            try
            {
                using (Models.skfEntities db = new Models.skfEntities())
                {

                    var oUser = (from r in db.users
                                 where r.email == user.Trim() && r.password == password.Trim()
                                 select r).FirstOrDefault();

                    if (oUser == null)
                    {
                        ViewBag.Error = "Usuario o Contraseña Inválida";

                        return View();
                    }

                    Session["user"] = oUser;


                }




                return RedirectToAction("Administrator", "Home");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View();
            }
        }

    }
}