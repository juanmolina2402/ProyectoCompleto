using ADSProject.DAL;
using ADSProject.Models;
using ADSProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceProfesores
    {
        // Instancia para acceder a todos los metodos de la DAL

        //public ProfesoresDAL profesoresDal = new ProfesoresDAL();

        // Para insertar estudiante

        public int insertar(Profesores profesores)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    ProfesoresDAL dal = new ProfesoresDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.insertarProfesores(profesores);
                }
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
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    ProfesoresDAL dal = new ProfesoresDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.modificarProfesores(id, profesores);
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
                    ProfesoresDAL dal = new ProfesoresDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.eliminarProfesores(id);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para obtener todos los estudiantes
        public List<Profesores> obtenerTodos()
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    ProfesoresDAL dal = new ProfesoresDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.obtenerTodos();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Para obtener por ID

        public Profesores obtenerPorId(int id)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    ProfesoresDAL dal = new ProfesoresDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.obtenerPorID(id);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}