using ADSProject.Models;
using ADSProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ADSProject.DAL
{
    public class EstudiantesDAL
    {
        //Listado de estudiantes a nivel de memoria del proyecto
        //public static List<Estudiantes> lstEstudiantes = new List<Estudiantes>();

        private MyDbContext _context;

        public EstudiantesDAL(MyDbContext context) { _context = context; }

        public int insertarEstudiantes(Estudiantes estudiantes)
        {
            try
            {
                //Se agrega carrera que se insertará
                _context.Estudiantes.Add(estudiantes);

                //Se guardan los cambios en la bd
                _context.SaveChanges();

                //Se retorna el ID de el registro recien insertada
                return estudiantes.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int modificarEstudiante(int id, Estudiantes estudiantes)
        {
            try
            {
                //Primero se consulta la carrera
                var currentItem = _context.Estudiantes.SingleOrDefault(temp => temp.id == id);

                //Trasladar los valores de los registros que queremos modificar al registro que acabamos de consultar
                _context.Entry(currentItem).CurrentValues.SetValues(estudiantes);

                //Guardar los cambios en la bd
                _context.SaveChanges();

                //retornamos el ID de la carrera recien modificada
                return estudiantes.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para eliminar un estudiante del listado
        public bool eliminarEstudiante(int id)
        {
            try
            {
                //Se consulta la carrera que se quiere eliminar por el ID
                var item = _context.Estudiantes.SingleOrDefault(x => x.id == id);

                //Remover la carrera recien consultada
                _context.Estudiantes.Remove(item);

                //Se guardan los cambios en la bd
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para listar todos los estudiantes
        public List <Estudiantes> obtenerTodos(string[] includes)
        {
            try
            {
                //Se consultan todos los registros de carrera
                var listado = _context.Estudiantes.AsQueryable();
                foreach (var include in includes)
                {
                    listado = listado.Include(include);
                }
                //Retorno el listado de registros.
                return listado.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Para encontrar un estudiante por ID
        public Estudiantes obtenerPorID(int id)
        {
            try
            {
                var elementos = _context.Estudiantes.SingleOrDefault(temp => temp.id == id);
                // Se retornan los registros
                return elementos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}