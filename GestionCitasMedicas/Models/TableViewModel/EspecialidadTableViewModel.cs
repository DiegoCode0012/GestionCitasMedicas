using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace GestionCitasMedicas.Models.TableViewModel
{
    public class EspecialidadTableViewModel
    {
        public int id { get; set; }
  
        public string nombre { get; set; }

        public string image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCTOR> DOCTOR { get; set; }
    }
}