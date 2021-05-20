using ADSProject.Models;
using ADSProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.DAL
{
    public class ProfesoresDAL
    {
        //Listado de estudiantes a nivel de memoria del proyecto
        //public static List<Profesores> lstProfesores = new List<Profesores>();

        private MyDbContext _context;

        public ProfesoresDAL(MyDbContext context) { _context = context; }

        public int insertarProfesores(Profesores profesores)
        {
            try
            {
                //Se agrega carrera que se insertará
                _context.Profesores.Add(profesores);

                //Se guardan los cambios en la bd
                _context.SaveChanges();

                //Se retorna el ID de el registro recien insertada
                return profesores.id;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int modificarProfesores(int id, Profesores profesores)
        {
            try
            {
                var currentItem = _context.Profesores.SingleOrDefault(temp => temp.id == id);

                //Trasladar los valores de los registros que queremos modificar al registro que acabamos de consultar
                _context.Entry(currentItem).CurrentValues.SetValues(profesores);

                //Guardar los cambios en la bd
                _context.SaveChanges();

                //retornamos el ID de la carrera recien modificada
                return profesores.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para eliminar un estudiante del listado
        public bool eliminarProfesores(int id)
        {
            try
            {
                //Se consulta la carrera que se quiere eliminar por el ID
                var item = _context.Profesores.SingleOrDefault(x => x.id == id);

                //Remover la carrera recien consultada
                _context.Profesores.Remove(item);

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
        public List<Profesores> obtenerTodos()
        {
            //Se consultan todos los registros de carrera
            var listado = _context.Profesores.ToList();
            //Retorno el listado de registros.
            return listado;
        }

        //Para encontrar un estudiante por ID
        public Profesores obtenerPorID(int id)
        {
            try
            {
                var elementos = _context.Profesores.SingleOrDefault(temp => temp.id == id);
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