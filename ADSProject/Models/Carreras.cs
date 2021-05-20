using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSProject.Models
{
    [Table("Carreras")]
    public class Carreras
    {    
        public int id { get; set; }

        [Required]
        [Display(Name = "Código")]
        [MaxLength(length: 3, ErrorMessage = "La longitud del campo no puede ser mayor a 3 caracteres.")]   
        public string codigo { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(length: 40, ErrorMessage = "La longitud del campo no puede ser mayor a 40 caracteres.")]
        public string nombre { get; set; }
    }
}