using ADSProject.DAL;
using ADSProject.Models;
using ADSProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceMaterias
    {
        // Instancia para acceder a todos los metodos de la DAL

        //public MateriasDAL materiasDal = new MateriasDAL();

        // Para insertar carrera

        public int insertar(Materias materias)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    MateriasDAL dal = new MateriasDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.insertarMaterias(materias);
                }
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
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    MateriasDAL dal = new MateriasDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.modificarMaterias(id, materias);
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
                    MateriasDAL dal = new MateriasDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.eliminarMaterias(id);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Materias> obtenerTodos()
        {
            //Inicializar el proceso para conectarnos a la bd
            using (MyDbContext context = new MyDbContext())
            {
                //crear instancia de la DAL y le pasamos el context
                MateriasDAL dal = new MateriasDAL(context);
                //Llamada para obtener el metodo de todos los registros
                return dal.obtenerTodos();
            }
        }

        //Para obtener todos las carreras
        public List<Materias> obtenerTodos(string[] includes)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    MateriasDAL dal = new MateriasDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.obtenerTodos(includes);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Para obtener por ID

        public Materias obtenerPorId(int id)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    MateriasDAL dal = new MateriasDAL(context);

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