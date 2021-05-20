using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADSProject.Models.Context;

namespace ADSProject.DAL
{
    public class CarrerasDAL
    {
        //Listado de carreras a nivel de memoria del proyecto
        //public static List<Carreras> lstCarreras = new List<Carreras>();

        //Instancia del contexto que nos permite conectarnos a la BD
        private MyDbContext _context;

        //En este constructor se recibe el contexto que se manda desde el servicio
        public CarrerasDAL(MyDbContext context) { _context = context; }

        public int insertarCarreras(Carreras carreras)
        {
            try
            {
                //Se agrega carrera que se insertará
                _context.Carrera.Add(carreras);

                //Se guardan los cambios en la bd
                _context.SaveChanges();

                //Se retorna el ID de el registro recien insertada
                return carreras.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int modificarCarreras(int id, Carreras carreras)
        {
            try
            {
                //Primero se consulta la carrera
                var currentItem = _context.Carrera.SingleOrDefault(temp => temp.id == id);

                //Trasladar los valores de los registros que queremos modificar al registro que acabamos de consultar
                _context.Entry(currentItem).CurrentValues.SetValues(carreras);

                //Guardar los cambios en la bd
                _context.SaveChanges();

                //retornamos el ID de la carrera recien modificada
                return carreras.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para eliminar una carrera del listado
        public bool eliminarCarreras(int id)
        {
            try
            {
                //Se consulta la carrera que se quiere eliminar por el ID
                var item = _context.Carrera.SingleOrDefault(x => x.id == id);

                //Remover la carrera recien consultada
                _context.Carrera.Remove(item);

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
        public List<Carreras> obtenerTodos()
        {
            try
            {
                //Se consultan todos los registros de carrera
                var listado = _context.Carrera.ToList();
                //Retorno el listado de registros.
                return listado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Para encontrar una carrera por ID
        public Carreras obtenerPorID(int id)
        {
            try
            {
                // Se obtiene el registro usando el ID
                var elementos = _context.Carrera.SingleOrDefault(temp => temp.id == id);
                // Se retornan los registros
                return elementos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}