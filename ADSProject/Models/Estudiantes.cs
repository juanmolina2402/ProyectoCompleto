using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADSProject.Models
{
    public class Estudiantes
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Código")]
        [MinLength(length: 12, ErrorMessage = "La longitud del campo no puede ser mayor a 12 caracteres.")]
        [MaxLength(length: 12, ErrorMessage = "La longitud del campo no puede ser mayor a 12 caracteres.")]
        public string codigo { get; set; }

        [Required]
        [Display(Name = "Email")]
        [MaxLength(length: 254, ErrorMessage = "La longitud del campo no puede ser mayor a 254 caracteres.")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Nombres")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres.")]
        public string nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres.")]
        public string apellidos { get; set; }
    }
}