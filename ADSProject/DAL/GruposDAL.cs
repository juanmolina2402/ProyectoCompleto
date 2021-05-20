using ADSProject.Models;
using ADSProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.DAL
{
    public class GruposDAL
    {
        //public static List<Grupos> lstGrupos = new List<Grupos>();

        private MyDbContext _context;
        public GruposDAL(MyDbContext context) { _context = context; }

        public int insertarGrupos(Grupos grupos)
        {
            try
            {
                //Se agrega carrera que se insertará
                _context.Grupos.Add(grupos);

                //Se guardan los cambios en la bd
                _context.SaveChanges();

                //Se retorna el ID de el registro recien insertada
                return grupos.id;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int modificarGrupos(int id, Grupos grupos)
        {
            try
            {
                //Primero se consulta la carrera
                var currentItem = _context.Grupos.SingleOrDefault(temp => temp.id == id);

                //Trasladar los valores de los registros que queremos modificar al registro que acabamos de consultar
                _context.Entry(currentItem).CurrentValues.SetValues(grupos);

                //Guardar los cambios en la bd
                _context.SaveChanges();

                //retornamos el ID de la carrera recien modificada
                return grupos.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para eliminar una carrera del listado
        public bool eliminarGrupos(int id)
        {
            try
            {
                //Se consulta la carrera que se quiere eliminar por el ID
                var item = _context.Grupos.SingleOrDefault(x => x.id == id);

                //Remover la carrera recien consultada
                _context.Grupos.Remove(item);

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
        public List<Grupos> obtenerTodos()
        {
            try
            {
                //Se consultan todos los registros de carrera
                var listado = _context.Grupos.ToList();
                //Retorno el listado de registros.
                return listado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Para encontrar una carrera por ID
        public Grupos obtenerPorID(int id)
        {
            try
            {
                // Se obtiene el registro usando el ID
                var elementos = _context.Grupos.SingleOrDefault(temp => temp.id == id);
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