using GestionCitasMedicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionCitasMedicas.Controllers
{
    public class AccessController : Controller
    {
        hospitalEntities db = new hospitalEntities();
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (hospitalEntities db = new hospitalEntities())
                {
                    var list = from u in db.PACIENTE
                               where u.gmail == user && u.contraseña == password
                               select u;
                    if (list.Count() > 0)
                    {
                        PACIENTE ObjetoUser = list.First();
                        Session["USER"] = ObjetoUser;
                        return Content("1");
                    } else if (user=="ADMIN" && password=="123456") {
                        Session["ADMIN"] = "Administrador";
                        return Content("1");

                    }
                    else
                    {
                        return Content("Usuario invalido");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: " + ex.Message);
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home"); //manda a home pero como no hay sessiones ahora lo manda al login por los filtros
        }
    }
}