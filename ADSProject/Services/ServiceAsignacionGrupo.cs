using ADSProject.DAL;
using ADSProject.Models;
using ADSProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceAsignacionGrupo
    {
        //Método para obtener todas las Carreras
        public List<AsignacionGrupo> obtenerTodos()
        {
            try
            {
                // Se inicializa el contexto que nos permitirá conectarnos con la BD
                using (MyDbContext context = new MyDbContext())
                {
                    //Se crea la instancia del DAL
                    //Y se le pasa el contexto de la BD
                    AsignacionGrupoDAL dal = new AsignacionGrupoDAL(context);
                    //Se llama el método para obtener todos los registros
                    return dal.obtenerTodos();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Método para buscar AsignacionGrupo por el Id
        public AsignacionGrupo obtenerPorId(int Id)
        {
            try
            {
                // Se inicializa el contexto que nos permitirá conectarnos con la BD
                using (MyDbContext context = new MyDbContext())
                {
                    //Se crea la instancia del DAL
                    //Y se le pasa el contexto de la BD
                    AsignacionGrupoDAL dal = new AsignacionGrupoDAL(context);
                    //Se llama el método para obtener un registro por Id
                    return dal.obtenerPorId(Id);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Método para insertar una AsignacionGrupo
        public int Insertar(AsignacionGrupo model)
        {
            try
            {
                // Se inicializa el contexto que nos permitirá conectarnos con la BD
                using (MyDbContext context = new MyDbContext())
                {
                    //Se crea la instancia del DAL
                    //Y se le pasa el contexto de la BD
                    AsignacionGrupoDAL dal = new AsignacionGrupoDAL(context);
                    //Se llama el método para insertar la AsignacionGrupo
                    return dal.Insertar(model);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Método para insertar una AsignacionGrupo
        public void Insertar(Grupos model)
        {
            try
            {
                // Se inicializa el contexto que nos permitirá conectarnos con la BD
                using (MyDbContext context = new MyDbContext())
                {
                    //Se crea la instancia del DAL
                    //Y se le pasa el contexto de la BD
                    AsignacionGrupoDAL dal = new AsignacionGrupoDAL(context);
                    //Se llama el método para insertar la AsignacionGrupo
                    dal.Eliminar(model.id);
                    if (model.AsignacionGrupos != null)
                    {
                        dal.Insertar(model.AsignacionGrupos);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Método para eliminar una AsignacionGrupo
        public bool Eliminar(int IdGrupo)
        {
            try
            {
                // Se inicializa el contexto que nos permitirá conectarnos con la BD
                using (MyDbContext context = new MyDbContext())
                {
                    //Se crea la instancia del DAL
                    //Y se le pasa el contexto de la BD
                    AsignacionGrupoDAL dal = new AsignacionGrupoDAL(context);
                    //Se llama el método para modificar la AsignacionGrupo
                    return dal.Eliminar(IdGrupo);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}