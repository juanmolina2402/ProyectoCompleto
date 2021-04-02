using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.DAL
{
    public class CarrerasDAL
    {
        //Listado de carreras a nivel de memoria del proyecto
        public static List<Carreras> lstCarreras = new List<Carreras>();

        public CarrerasDAL() { }

        public int insertarCarreras(Carreras carreras)
        {
            try
            {
                //Si el listado tiene elementos, entonces se genera el ID
                if (lstCarreras.Count > 0)
                {
                    carreras.id = lstCarreras.Last().id + 1;
                }
                else
                {
                    //Si el listado esta vacio entonces el id será por default 1
                    carreras.id = 1;
                }
                lstCarreras.Add(carreras);
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
                //Buscando el indice en la ista
                lstCarreras[lstCarreras.FindIndex(temp => temp.id == id)] = carreras;
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
                //Buscando el indice en la ista
                lstCarreras.RemoveAt(lstCarreras.FindIndex(aux => aux.id == id));
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
            return lstCarreras;
        }

        //Para encontrar una carrera por ID
        public Carreras obtenerPorID(int id)
        {
            try
            {
                var elementos = lstCarreras.Find(temp => temp.id == id);
                return elementos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}