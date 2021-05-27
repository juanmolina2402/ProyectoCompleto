using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSProject.Models
{
    [Table("Grupos")]
    public class Grupos
    {
        public int id { get; set; }

        [Display(Name = "Carrera")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int IdCarrera { get; set; }
        [ForeignKey("IdCarrera")]
        public Carreras Carrera { get; set; }

        [Display(Name = "Materia")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int idMateria { get; set; }
        [ForeignKey("idMateria")]
        public Materias Materia { get; set; }

        [Display(Name = "Profesor")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int idProfesor { get; set; }
        [ForeignKey("idProfesor")]
        public Profesores Profesor { get; set; }

        [Required]
        [Display(Name = "Ciclo")]
        public int ciclo { get; set; }

        [Required]
        [Display(Name = "Año")]
        public int anio { get; set; }
    }
}