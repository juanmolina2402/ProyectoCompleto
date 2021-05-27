﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSProject.Models
{
    [Table("Estudiantes")]
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

        [Display(Name = "Carrera")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int IdCarrera { get; set; }
        [ForeignKey("IdCarrera")]
        public Carreras Carrera { get; set; }
    }
}