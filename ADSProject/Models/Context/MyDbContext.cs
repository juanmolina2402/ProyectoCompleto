using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ADSProject.Models.Context
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(): base("DefaultConnection") { }

        public DbSet<Carreras> Carrera {get; set;}
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Materias> Materias { get; set; }
        public DbSet<Profesores> Profesores { get; set; }
        public DbSet<Grupos> Grupos { get; set; }
    }
}