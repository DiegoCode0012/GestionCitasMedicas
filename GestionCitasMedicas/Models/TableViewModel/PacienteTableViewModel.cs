using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCitasMedicas.Models.TableViewModel
{
    public class PacienteTableViewModel
    {
       

        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Nullable<int> dni { get; set; }
        public Nullable<int> telefono { get; set; }
        public string gmail { get; set; }
        public string contraseña { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CITAS> CITAS { get; set; }

        public override string ToString()
        {
            return gmail;
        }
    }
}