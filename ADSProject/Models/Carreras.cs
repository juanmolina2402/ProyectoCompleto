using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADSProject.Models
{
    public class Carreras
    {
        public int id { get; set; }
        [Display(Name = "Código")]
        [MaxLength(length: 3, ErrorMessage = "La longitud del campo no puede ser mayor a 3 caracteres.")]
        [Required(ErrorMessage = "Este campo no puede quedar vacío")]
        public string codigo { get; set; }

        [Display(Name = "Nombre")]
        [MinLength(length: 5, ErrorMessage = "La longitud del campo no puede ser menor de 5 caracteres.")]
        [MaxLength(length: 40, ErrorMessage = "La longitud del campo no puede ser mayor a 40 caracteres.")]
        [Required]
        public string nombre { get; set; }
    }
}