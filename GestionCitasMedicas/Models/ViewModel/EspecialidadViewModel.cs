using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace GestionCitasMedicas.Models.ViewModel
{
    public class EspecialidadViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Especialidad")]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos 1 caracter", MinimumLength = 1)]
        public string nombre { get; set; }
        [Display(Name = "Suba una Imagen")]
        public string image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCTOR> DOCTOR { get; set; }
    }
}