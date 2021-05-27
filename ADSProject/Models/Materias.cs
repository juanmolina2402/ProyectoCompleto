﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSProject.Models
{
    [Table("Materias")]
    public class Materias
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres.")]
        public string nombre { get; set; }

        [Display(Name = "Carrera")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int IdCarrera { get; set; }
        [ForeignKey("IdCarrera")]
        public Carreras Carrera { get; set; }
    }
}