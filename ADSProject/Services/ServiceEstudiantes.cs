using ADSProject.DAL;
using ADSProject.Models;
using ADSProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceEstudiantes
    {
        // Instancia para acceder a todos los metodos de la DAL

        //public EstudiantesDAL estudianteDal = new EstudiantesDAL();

        // Para insertar estudiante

        public int insertar(Estudiantes estudiantes)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    EstudiantesDAL dal = new EstudiantesDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.insertarEstudiantes(estudiantes);
                }
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
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    EstudiantesDAL dal = new EstudiantesDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.modificarEstudiante(id, estudiantes);
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
                    EstudiantesDAL dal = new EstudiantesDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.eliminarEstudiante(id);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para obtener todos los estudiantes
        public List<Estudiantes> obtenerTodos(string[] includes)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    EstudiantesDAL dal = new EstudiantesDAL(context);
                    return dal.obtenerTodos(includes);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para obtener por ID

        public Estudiantes obtenerPorId(int id)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    EstudiantesDAL dal = new EstudiantesDAL(context);

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