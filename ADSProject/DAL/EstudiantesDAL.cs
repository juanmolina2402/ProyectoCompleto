using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.DAL
{
    public class EstudiantesDAL
    {
        //Listado de estudiantes a nivel de memoria del proyecto
        public static List<Estudiantes> lstEstudiantes = new List<Estudiantes>();

        public EstudiantesDAL() { }

        public int insertarEstudiantes(Estudiantes estudiantes)
        {
            try
            {
                //Si el listado tiene elementos, entonces se genera el ID
                if(lstEstudiantes.Count > 0)
                {
                    estudiantes.id = lstEstudiantes.Last().id + 1;
                }
                else
                {
                    //Si el listado esta vacio entonces el id será por default 1
                    estudiantes.id = 1;
                }
                lstEstudiantes.Add(estudiantes);
                return estudiantes.id;
               
            }catch(Exception ex)
            {
                throw;
            }
        }

        public int modificarEstudiante(int id, Estudiantes estudiantes)
        {
            try
            {
                //Buscando el indice en la ista
                lstEstudiantes[lstEstudiantes.FindIndex(temp => temp.id == id)] = estudiantes;
                return estudiantes.id;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        //Para eliminar un estudiante del listado
        public bool eliminarEstudiante(int id)
        {
            try
            {
                //Buscando el indice en la ista
                lstEstudiantes.RemoveAt(lstEstudiantes.FindIndex(aux => aux.id == id));
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para listar todos los estudiantes
        public List <Estudiantes> obtenerTodos()
        {
            return lstEstudiantes;  
        }

        //Para encontrar un estudiante por ID
        public Estudiantes obtenerPorID(int id)
        {
            try
            {
                var elementos = lstEstudiantes.Find(temp => temp.id == id);
                return elementos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}