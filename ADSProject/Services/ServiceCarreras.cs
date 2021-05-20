using ADSProject.DAL;
using ADSProject.Models;
using ADSProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceCarreras
    {
        // Instancia para acceder a todos los metodos de la DAL

        //public CarrerasDAL carrerasDal = new CarrerasDAL();

        // Para insertar carrera

        public int insertar(Carreras carreras)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    CarrerasDAL dal = new CarrerasDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.insertarCarreras(carreras);
                }
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
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    CarrerasDAL dal = new CarrerasDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.modificarCarreras(id, carreras);
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
                    CarrerasDAL dal = new CarrerasDAL(context);

                    //llamada al metodo para obtener todos los registros
                    return dal.eliminarCarreras(id);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para obtener todos las carreras
        public List<Carreras> obtenerTodos()
        {
            try
            {
                //Inicializar el contexto que nos permitira conectarnos con la bd
                using (MyDbContext context = new MyDbContext()){
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    CarrerasDAL dal = new CarrerasDAL(context);

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

        public Carreras obtenerPorId(int id)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    //crear instancia de la DAL y se pasa el contexto de la bd
                    CarrerasDAL dal = new CarrerasDAL(context);

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