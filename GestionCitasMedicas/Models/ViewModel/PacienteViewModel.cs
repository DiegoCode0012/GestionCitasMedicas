using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace GestionCitasMedicas.Models.ViewModel
{
    public class PacienteViewModel
    {
       

        public int id { get; set; }
        [Display(Name = "Nombre")]

        public string nombre { get; set; }
        [Display(Name = "Apellido")]

        public string apellido { get; set; }
        [Display(Name = "DNI")]

        public Nullable<int> dni { get; set; }
        [Display(Name = "telefono")]
        public Nullable<int> telefono { get; set; }
        [Display(Name = "gmail")]

        public string gmail { get; set; }
        [Display(Name = "contraseña")]

        public string contraseña { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CITAS> CITAS { get; set; }

        public override string ToString()
        {
            return gmail;
        }
    }
}