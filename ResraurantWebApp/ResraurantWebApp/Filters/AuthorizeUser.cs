using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResraurantWebApp.Models;

namespace ResraurantWebApp.Filters
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private users oUser;
        Models.restauranteEntities1 db = new restauranteEntities1();
        public int idRole;

        public AuthorizeUser(int idRole = 0)
        {
            this.idRole = idRole;
        }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string roleName = "";
            string moduleName = "";

            try
            {
                oUser = (users)HttpContext.Current.Session["user"];
                var roleList = from r in db.role
                          where r.id == oUser.idRol
                          && r.id == idRole
                          select r;

                if (roleList.ToList().Count() < 1)
                {
                    //var oRole = db.role.Find(idRol);

                    var oOperacion = db.role.Find(idRole);
                    int? idModulo = oOperacion.id;
                    roleName = getNombreDeOperacion(idRole);
                    moduleName = getNombreDelModulo(idModulo);
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + roleName + "&modulo=" + idModulo + "&msjeErrorExcepcion=");

                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=");



                }

            }
            catch (Exception ex)
            {

                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + roleName + "&modulo=" + moduleName + "&msjeErrorExcepcion=" + ex.Message);
            }
        }


        public string getNombreDeOperacion(int idOperacion)
        {
            var ope = from op in db.role
                      where op.id == idOperacion
                      select op.name;
            String nombreOperacion;
            try
            {
                nombreOperacion = ope.First();
            }
            catch (Exception)
            {
                nombreOperacion = "";
            }
            return nombreOperacion;
        }

        public string getNombreDelModulo(int? idModulo)
        {
            var modulo = from m in db.role
                         where m.id == idModulo
                         select m.name;
            String nombreModulo;
            try
            {
                nombreModulo = modulo.First();
            }
            catch (Exception)
            {
                nombreModulo = "";
            }
            return nombreModulo;
        }

    }
}