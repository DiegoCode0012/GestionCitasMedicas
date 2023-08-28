using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace GestionCitasMedicas.Models.ViewModel
{
    public class DoctorViewModel
    {
        public int id { get; set; }
        [Display(Name = "Nombre:")]
        public string nombre { get; set; }
        [Display(Name = "Apellido:")]
        public string apellido { get; set; }
        [Display(Name = "Apellido:")]
        public Nullable<int> telefono { get; set; }
        public int id_especialidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CITAS> CITAS { get; set; }
        public virtual EspecialidadViewModel ESPECIALIDAD { get; set; }
    }
}