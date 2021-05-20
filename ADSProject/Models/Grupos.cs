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

        [Required]
        [Display(Name = "Id Carrera")]
        public int idCarrera { get; set; }

        [Required]
        [Display(Name = "Id Materia")]
        public int idMateria { get; set; }

        [Required]
        [Display(Name = "Id Profesor")]
        public int idProfesor { get; set; }

        [Required]
        [Display(Name = "Ciclo")]
        public int ciclo { get; set; }

        [Required]
        [Display(Name = "Año")]
        public int anio { get; set; }
    }
}