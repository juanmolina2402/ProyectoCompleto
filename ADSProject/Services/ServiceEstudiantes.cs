using ADSProject.DAL;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceEstudiantes
    {
        // Instancia para acceder a todos los metodos de la DAL

        public EstudiantesDAL estudianteDal = new EstudiantesDAL();

        // Para insertar estudiante

        public int insertar(Estudiantes estudiantes)
        {
            try
            {
                return estudianteDal.insertarEstudiantes(estudiantes);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        //Para modificar un estudiante
        public int modificar(int id, Estudiantes estudiantes)
        {
            try
            {
                return estudianteDal.modificarEstudiante(id, estudiantes);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool eliminar(int id)
        {
            try
            {
                return estudianteDal.eliminarEstudiante(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para obtener todos los estudiantes
        public List<Estudiantes> obtenerTodos()
        {      
            return estudianteDal.obtenerTodos(); 
        }

        //Para obtener por ID

        public Estudiantes obtenerPorId(int id)
        {
            try
            {
                return estudianteDal.obtenerPorID(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}