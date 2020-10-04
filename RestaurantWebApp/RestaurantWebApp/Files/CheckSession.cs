using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantWebApp.Controllers;
using RestaurantWebApp.Models;

namespace RestaurantWebApp.Files
{
    public class CheckSession : ActionFilterAttribute
    {

        private users oUser;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);


                oUser = (users)HttpContext.Current.Session["user"];
                if (oUser == null)
                {
                    if (filterContext.Controller is AccessController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Access/Login");
                    }
                }
            }
            catch (Exception)
            {

                filterContext.Result = new RedirectResult("~/Access/Login");
            }
        }
    }
}