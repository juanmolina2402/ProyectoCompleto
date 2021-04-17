using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADSProject.Models
{
    public class Materias
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres.")]
        public string nombre { get; set; }
    }
}