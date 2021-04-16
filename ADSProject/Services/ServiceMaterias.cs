using ADSProject.DAL;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceMaterias
    {
        // Instancia para acceder a todos los metodos de la DAL

        public MateriasDAL materiasDal = new MateriasDAL();

        // Para insertar carrera

        public int insertar(Materias materias)
        {
            try
            {
                return materiasDal.insertarMaterias(materias);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para modificar una carrera
        public int modificar(int id, Materias materias)
        {
            try
            {
                return materiasDal.modificarMaterias(id, materias);
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
                return materiasDal.eliminarMaterias(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para obtener todos las carreras
        public List<Materias> obtenerTodos()
        {
            return materiasDal.obtenerTodos();
        }

        //Para obtener por ID

        public Materias obtenerPorId(int id)
        {
            try
            {
                return materiasDal.obtenerPorID(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}