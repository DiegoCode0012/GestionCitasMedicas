using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace GestionCitasMedicas.Models.TableViewModel
{
    public class CitaTableViewModel
    {
        public int id { get; set; }
        public int id_doctor { get; set; }
        public int id_paciente { get; set; }
       
        public Nullable<System.DateTime> fecha { get; set; }
       
        public Nullable<System.TimeSpan> horaInicio { get; set; }
       
        public Nullable<System.TimeSpan> horaFinal { get; set; }

        public virtual DOCTOR DOCTOR { get; set; }

      
        public virtual PACIENTE PACIENTE { get; set; }
    }
}