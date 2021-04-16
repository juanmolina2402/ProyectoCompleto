using ADSProject.DAL;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceGrupos
    {
        // Instancia para acceder a todos los metodos de la DAL

        public GruposDAL gruposDal = new GruposDAL();

        // Para insertar grupo

        public int insertar(Grupos grupos)
        {
            try
            {
                return gruposDal.insertarGrupos(grupos);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para modificar un estudiante
        public int modificar(int id, Grupos grupos)
        {
            try
            {
                return gruposDal.modificarGrupos(id, grupos);
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
                return gruposDal.eliminarGrupos(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para obtener todos los estudiantes
        public List<Grupos> obtenerTodos()
        {
            return gruposDal.obtenerTodos();
        }

        //Para obtener por ID

        public Grupos obtenerPorId(int id)
        {
            try
            {
                return gruposDal.obtenerPorID(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}