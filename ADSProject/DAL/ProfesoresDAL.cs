using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.DAL
{
    public class ProfesoresDAL
    {
        //Listado de estudiantes a nivel de memoria del proyecto
        public static List<Profesores> lstProfesores = new List<Profesores>();

        public ProfesoresDAL() { }

        public int insertarProfesores(Profesores profesores)
        {
            try
            {
                //Si el listado tiene elementos, entonces se genera el ID
                if (lstProfesores.Count > 0)
                {
                    profesores.id = lstProfesores.Last().id + 1;
                }
                else
                {
                    //Si el listado esta vacio entonces el id será por default 1
                    profesores.id = 1;
                }
                lstProfesores.Add(profesores);
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
                //Buscando el indice en la ista
                lstProfesores[lstProfesores.FindIndex(temp => temp.id == id)] = profesores;
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
                //Buscando el indice en la ista
                lstProfesores.RemoveAt(lstProfesores.FindIndex(aux => aux.id == id));
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
            return lstProfesores;
        }

        //Para encontrar un estudiante por ID
        public Profesores obtenerPorID(int id)
        {
            try
            {
                var elementos = lstProfesores.Find(temp => temp.id == id);
                return elementos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}