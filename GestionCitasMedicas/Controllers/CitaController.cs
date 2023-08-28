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
    public class CitaController : Controller
    {
        /* Debug.Write("esto exitste? " + id);
                System.Diagnostics.Debug.WriteLine("Probando" + id);*/

        hospitalEntities db = new hospitalEntities();


        public ActionResult Index(int? pageSize, int? page)
        {
            pageSize = (pageSize ?? 3);
            page = (page ?? 1);
            ViewBag.PageSize = pageSize; //cuantas se van a mostrar, pageValue= en que pagina estamos , pageSize= todas las paginas que se mostrara
            return View(db.CITAS.OrderBy(i=>i.id).ToPagedList(page.Value, pageSize.Value));
        }
        public JsonResult GetListaHorario(int? id_doctor,DateTime? valorDate) {
            db.Configuration.ProxyCreationEnabled = false;                        
            List<HORARIO> horarios = db.HORARIO.Where(l => l.id_doctor == id_doctor && l.fecha == valorDate && l.disponibilidad=="D").ToList();
            return Json(horarios, JsonRequestBehavior.AllowGet);
        }
            

        public JsonResult GetDoctores(int? id_especialidad){
            db.Configuration.ProxyCreationEnabled = false;
            List<DOCTOR> doctores = db.DOCTOR.Where(x => x.id_especialidad== id_especialidad).ToList();
            return Json(doctores, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add()
        {
            // primero va la lista, luego el ID de esa entidad y luego el atributo que queremos mostrar
            ViewBag.id_paciente = new SelectList(db.PACIENTE, "id", "nombre");
            ViewBag.id_especialidad = new SelectList(db.ESPECIALIDAD, "id_especialidad", "nombre");
            return View();
        }

       
        [HttpPost]
        public ActionResult Add([Bind(Include = "id,id_doctor,id_paciente,fecha,id_horario")] CITAS cita, int? radio_group)
        {
            ViewBag.id_horario = new SelectList(db.HORARIO, "id_horario", "id_horario", cita.id_horario);
            ViewBag.id_paciente = new SelectList(db.PACIENTE, "id", "nombre", cita.id_paciente);
            if (ModelState.IsValid && radio_group > 0)
            {
                cita.id_horario = radio_group;
                db.CITAS.Add(cita);
                HORARIO h = db.HORARIO.Find(radio_group);
                h.disponibilidad = "O";
                db.SaveChanges();
                return Redirect(Url.Content("~/Cita/Index"));
            }
            else {

                return View(cita);
            }
       
        } 
        public ActionResult Delete(int? id)
        {
            if (id ==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITAS cita = db.CITAS.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            cita.HORARIO.disponibilidad = "D";
            db.SaveChanges();
            db.CITAS.Remove(cita);
            db.SaveChanges();
            return Redirect("~/Cita/");
        }

    }










}

