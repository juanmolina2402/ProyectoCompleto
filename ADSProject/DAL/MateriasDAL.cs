using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.DAL
{
    public class MateriasDAL
    {
        //Listado de carreras a nivel de memoria del proyecto
        public static List<Materias> lstMaterias = new List<Materias>();

        public MateriasDAL() { }

        public int insertarMaterias(Materias materias)
        {
            try
            {
                //Si el listado tiene elementos, entonces se genera el ID
                if (lstMaterias.Count > 0)
                {
                    materias.id = lstMaterias.Last().id + 1;
                }
                else
                {
                    //Si el listado esta vacio entonces el id será por default 1
                    materias.id = 1;
                }
                lstMaterias.Add(materias);
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
                //Buscando el indice en la ista
                lstMaterias[lstMaterias.FindIndex(temp => temp.id == id)] = materias;
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
                //Buscando el indice en la ista
                lstMaterias.RemoveAt(lstMaterias.FindIndex(aux => aux.id == id));
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
            return lstMaterias;
        }

        //Para encontrar una carrera por ID
        public Materias obtenerPorID(int id)
        {
            try
            {
                var elementos = lstMaterias.Find(temp => temp.id == id);
                return elementos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}