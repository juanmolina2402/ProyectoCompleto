using ADSProject.DAL;
using ADSProject.Models;
using ADSProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceGrupos
    {
        // Instancia para acceder a todos los metodos de la DAL

        //public GruposDAL gruposDal = new GruposDAL();

        // Para insertar grupo

        public int insertar(Grupos grupos)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    GruposDAL dal = new GruposDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.insertarGrupos(grupos);
                }
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
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    GruposDAL dal = new GruposDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.modificarGrupos(id, grupos);
                }
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
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    GruposDAL dal = new GruposDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.eliminarGrupos(id);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para obtener todos los estudiantes
        public List<Grupos> obtenerTodos()
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    GruposDAL dal = new GruposDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.obtenerTodos();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Grupos> obtenerTodos(string[] includes)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    GruposDAL dal = new GruposDAL(context);
                    return dal.obtenerTodos(includes);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Grupos obtenerPorId(int id)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    GruposDAL dal = new GruposDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.obtenerPorId(id);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para obtener por ID

        public Grupos obtenerPorId(int id, string[] includes)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    GruposDAL dal = new GruposDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.obtenerPorId(id, includes);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}