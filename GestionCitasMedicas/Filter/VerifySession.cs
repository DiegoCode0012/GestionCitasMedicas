using GestionCitasMedicas.Controllers;
using GestionCitasMedicas.Models;

using System.Web;
using System.Web.Mvc;

namespace GestionCitasMedicas.Filter
{
    public class VerifySession: ActionFilterAttribute

    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            var oUser = (PACIENTE)HttpContext.Current.Session["USER"]; //paciente
            var oAdmin = (string)HttpContext.Current.Session["ADMIN"];

            if (oUser == null && oAdmin ==null) {
                //si quieres acceder a todos los demas controladores te va a redirigir al login
                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            } else if (oUser != null || oAdmin != null) {
                //si despues de logearte quieres ir al login de nuevo
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }

            }
            /*
            if (oUser == null)
            {
                
                //si quieres acceder a todos los demas controladores te va a redirigir al login
                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }

            }/*
            else
            {
                //si despues de logearte quieres ir al login de nuevo
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }*/

            base.OnActionExecuting(filterContext); 
        }
    }
}