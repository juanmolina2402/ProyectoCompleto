using ADSProject.Models;
using ADSProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.DAL
{
    public class MateriasDAL
    {
        //Listado de carreras a nivel de memoria del proyecto
        //public static List<Materias> lstMaterias = new List<Materias>();

        private MyDbContext _context;

        public MateriasDAL(MyDbContext context) { _context = context; }

        public int insertarMaterias(Materias materias)
        {
            try
            {
                //Se agrega carrera que se insertará
                _context.Materias.Add(materias);

                //Se guardan los cambios en la bd
                _context.SaveChanges();

                //Se retorna el ID de el registro recien insertada
                return materias.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int modificarMaterias(int id, Materias materias)
        {
            try
            {
                //Primero se consulta la carrera
                var currentItem = _context.Materias.SingleOrDefault(temp => temp.id == id);

                //Trasladar los valores de los registros que queremos modificar al registro que acabamos de consultar
                _context.Entry(currentItem).CurrentValues.SetValues(materias);

                //Guardar los cambios en la bd
                _context.SaveChanges();

                //retornamos el ID de la carrera recien modificada
                return materias.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para eliminar una carrera del listado
        public bool eliminarMaterias(int id)
        {
            try
            {
                //Se consulta la carrera que se quiere eliminar por el ID
                var item = _context.Materias.SingleOrDefault(x => x.id == id);

                //Remover la carrera recien consultada
                _context.Materias.Remove(item);

                //Se guardan los cambios en la bd
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para listar todos las carreras
        public List<Materias> obtenerTodos()
        {
            try
            {
                //Se consultan todos los registros de carrera
                var listado = _context.Materias.ToList();
                //Retorno el listado de registros.
                return listado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Para encontrar una carrera por ID
        public Materias obtenerPorID(int id)
        {
            try
            {
                var elementos = _context.Materias.SingleOrDefault(temp => temp.id == id);
                return elementos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}