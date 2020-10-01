using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResraurantWebApp.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user,string password)
        {
            try
            {
                using (Models.restauranteEntities1 db = new Models.restauranteEntities1())
                {

                    var oUser = (from r in db.users
                                 where r.email == user.Trim() && r.password == password.Trim()
                                 select r).FirstOrDefault();

                    if(oUser == null)
                    {
                        ViewBag.Error = "Usuario o Contraseña Inválida";
                        return View();
                    }

                    Session["user"] = oUser;


                }




                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View();
            }
        }



    }
}