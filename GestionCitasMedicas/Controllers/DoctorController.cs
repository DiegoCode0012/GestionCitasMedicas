using GestionCitasMedicas.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GestionCitasMedicas.Controllers
{
    public class DoctorController : Controller
    {
        hospitalEntities db = new hospitalEntities();

        public ActionResult Index(int? pageSize, int? page)

        {
            pageSize = (pageSize ?? 3);
            page = (page ?? 1);
            ViewBag.PageSize = pageSize; //cuantas se van a mostrar, pageValue= en que pagina estamos , pageSize= todas las paginas que se mostrara
            return View(db.DOCTOR.OrderBy(i => i.idDoctor).ToPagedList(page.Value, pageSize.Value));
        }

        public ActionResult Add()
        {
            ViewBag.id_especialidad = new SelectList(db.ESPECIALIDAD, "id_especialidad", "nombre");
            return View();
        }


        [HttpPost]
        public ActionResult Add(DOCTOR Doctor)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.id_especialidad = new SelectList(db.ESPECIALIDAD, "id_especialidad", "nombre");
              System.Diagnostics.Debug.WriteLine("Probando" + Doctor.idDoctor);
                Debug.Write("esto exitste? " + Doctor.idDoctor);

                return View(Doctor);
            }
            else {

                db.DOCTOR.Add(Doctor);
                db.SaveChanges();
                return Redirect(Url.Content("~/Doctor/Index"));
            }

        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR doctor = db.DOCTOR.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            db.DOCTOR.Remove(doctor);
            db.SaveChanges();
            return Redirect(Url.Content("~/Doctor/Index"));
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR doctor = db.DOCTOR.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_especialidad = new SelectList(db.ESPECIALIDAD, "id_especialidad", "nombre",doctor.id_especialidad);
            return View(doctor);
        }

        [HttpPost]
        public ActionResult Edit(DOCTOR doctor)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.id_especialidad = new SelectList(db.ESPECIALIDAD, "id_especialidad", "nombre");
                return View(doctor);

            }
            else {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }


        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR doctor = db.DOCTOR.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }





    }
}