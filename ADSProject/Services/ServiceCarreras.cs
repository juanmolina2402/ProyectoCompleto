using ADSProject.DAL;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceCarreras
    {
        // Instancia para acceder a todos los metodos de la DAL

        public CarrerasDAL carrerasDal = new CarrerasDAL();

        // Para insertar carrera

        public int insertar(Carreras carreras)
        {
            try
            {
                return carrerasDal.insertarCarreras(carreras);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para modificar una carrera
        public int modificar(int id, Carreras carreras)
        {
            try
            {
                return carrerasDal.modificarCarreras(id, carreras);
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
                return carrerasDal.eliminarCarreras(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para obtener todos las carreras
        public List<Carreras> obtenerTodos()
        {
            return carrerasDal.obtenerTodos();
        }

        //Para obtener por ID

        public Carreras obtenerPorId(int id)
        {
            try
            {
                return carrerasDal.obtenerPorID(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}