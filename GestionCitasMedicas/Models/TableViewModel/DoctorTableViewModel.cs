using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace GestionCitasMedicas.Models.TableViewModel
{
    public class DoctorTableViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Nullable<int> telefono { get; set; }
        public int id_especialidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CITAS> CITAS { get; set; }
        public virtual ESPECIALIDAD ESPECIALIDAD { get; set; }
    }
}