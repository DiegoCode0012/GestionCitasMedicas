using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using GestionCitasMedicas.Models;
using PagedList;

namespace GestionCitasMedicas.Controllers
{
    public class HorarioController : Controller
    {
        private hospitalEntities db = new hospitalEntities();

        // GET: Horario
        public ActionResult Index(int? pageSize, int? page)
        {
            pageSize = (pageSize ?? 3);
            page = (page ?? 1);
            ViewBag.PageSize = pageSize; //cuantas se van a mostrar, pageValue= en que pagina estamos , pageSize= todas las paginas que se mostrara
            return View(db.HORARIO.OrderBy(i=>i.id_horario).ToPagedList(page.Value, pageSize.Value));
        }


        // GET: Horario/Create
        public ActionResult Add()
        {
            ViewBag.id_doctor = new SelectList(db.DOCTOR, "idDoctor", "nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Add(HORARIO hORARIO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.id_doctor = new SelectList(db.DOCTOR, "idDoctor", "nombre", hORARIO.id_doctor);
               // ModelState.AddModelError();
                return View(hORARIO);
            }
            else {
            hORARIO.horaFinal = hORARIO.horaInicio+ TimeSpan.FromHours(1);
            hORARIO.disponibilidad = "D";
            db.HORARIO.Add(hORARIO);
            db.SaveChanges();
            return Redirect(Url.Content("~/Horario/Index"));
            }
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORARIO hORARIO = db.HORARIO.Find(id);
            if (hORARIO == null)
            {
                return HttpNotFound();
            }
            db.HORARIO.Remove(hORARIO);
            db.SaveChanges();
            return Redirect(Url.Content("~/Horario/Index"));
        }     
    }
}
