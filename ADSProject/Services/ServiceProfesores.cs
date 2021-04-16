using ADSProject.DAL;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceProfesores
    {
        // Instancia para acceder a todos los metodos de la DAL

        public ProfesoresDAL profesoresDal = new ProfesoresDAL();

        // Para insertar estudiante

        public int insertar(Profesores profesores)
        {
            try
            {
                return profesoresDal.insertarProfesores(profesores);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para modificar un estudiante
        public int modificar(int id, Profesores profesores)
        {
            try
            {
                return profesoresDal.modificarProfesores(id, profesores);
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
                return profesoresDal.eliminarProfesores(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para obtener todos los estudiantes
        public List<Profesores> obtenerTodos()
        {
            return profesoresDal.obtenerTodos();
        }

        //Para obtener por ID

        public Profesores obtenerPorId(int id)
        {
            try
            {
                return profesoresDal.obtenerPorID(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}