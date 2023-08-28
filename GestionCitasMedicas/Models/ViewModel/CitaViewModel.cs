using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace GestionCitasMedicas.Models.ViewModel
{
    public class CitaViewModel
    {
        public int id { get; set; }
        public int id_doctor { get; set; }
        public int id_paciente { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> fecha { get; set; }
        [Required]
        [Display(Name = "Hora Inicio")]
        public Nullable<System.TimeSpan> horaInicio { get; set; }
        [Required]
        [Display(Name = "Hora Final")]
        public Nullable<System.TimeSpan> horaFinal { get; set; }

        [Required]
        [Display(Name = "Doctor")]
        public virtual DoctorViewModel DOCTOR { get; set; }

        [Required]
        [Display(Name = "Paciente")]
        public virtual PacienteViewModel PACIENTE { get; set; }
    }
}