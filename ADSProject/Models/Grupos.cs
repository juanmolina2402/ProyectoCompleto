using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Models
{
    public class Grupos
    {
        public int id { get; set; }
        public int idCarrera { get; set; }
        public int idMateria { get; set; }
        public int idProfesor { get; set; }
        public int ciclo { get; set; }
        public int anio { get; set; }
    }
}