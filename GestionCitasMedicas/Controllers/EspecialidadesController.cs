using GestionCitasMedicas.Models;
using PagedList;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;

namespace GestionCitasMedicas.Controllers
{
    public class EspecialidadesController : Controller
    {

        hospitalEntities db = new hospitalEntities();
        // GET: Especialidades
        public ActionResult Index(int? pageSize, int? page)

        {
            pageSize = (pageSize ?? 3);
            page = (page ?? 1);
            ViewBag.PageSize = pageSize; //cuantas se van a mostrar, pageValue= en que pagina estamos , pageSize= todas las paginas que se mostrara
            return View(db.ESPECIALIDAD.OrderBy(i => i.id_especialidad).ToPagedList(page.Value, pageSize.Value));
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ESPECIALIDAD Especialidad, HttpPostedFileBase ImageFile)
        {

            if (!ModelState.IsValid)
            {

                return View(Especialidad);
            }
            else
            {
                if (ImageFile != null)
                {
                    Especialidad.image = ImageFile.FileName;
                    string path = Server.MapPath("~/Image/" + ImageFile.FileName);
                    ImageFile.SaveAs(path);
                }


                db.ESPECIALIDAD.Add(Especialidad);
                db.SaveChanges();

                ModelState.Clear();
                return Redirect(Url.Content("~/Especialidades/Index"));
            }
        }

        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESPECIALIDAD especial = db.ESPECIALIDAD.Find(id);
            if (especial == null)
            {
                return HttpNotFound();
            }
            return View(especial);


        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESPECIALIDAD especial = db.ESPECIALIDAD.Find(id);
            if (especial == null)
            {
                return HttpNotFound();
            }
            db.ESPECIALIDAD.Remove(especial);
            db.SaveChanges();
            return Redirect("~/Especialidades/");


        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            return View(db.ESPECIALIDAD.Where(x => x.id_especialidad == id).FirstOrDefault());


        }

        [HttpPost]
        public ActionResult Edit(ESPECIALIDAD x, HttpPostedFileBase ImageFile)
        {
            if (!ModelState.IsValid)
            {

                return View(x);
            }
            else
            {
                if (ImageFile != null)
                {
                    x.image = ImageFile.FileName;
                    string path = Server.MapPath("~/Image/" + ImageFile.FileName);
                    ImageFile.SaveAs(path);
                }
              
                db.Entry(x).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();
                return Redirect(Url.Content("~/Especialidades"));


                /*
                    string filename = Path.GetFileNameWithoutExtension(e.ImageFile.FileName);
                    string extension = Path.GetExtension(e.ImageFile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    e.image = "../Image/" + filename; // registra el nombre que aparecera en base de datos
                    filename = Path.Combine(Server.MapPath("../Image/"), filename);
                    db.Entry(e).State = EntityState.Modified;
                    db.SaveChanges();
                */

            }


        }

    }
}