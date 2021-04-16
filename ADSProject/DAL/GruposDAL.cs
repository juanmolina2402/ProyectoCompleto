using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.DAL
{
    public class GruposDAL
    {
        public static List<Grupos> lstGrupos = new List<Grupos>();

        public GruposDAL() { }

        public int insertarGrupos(Grupos grupos)
        {
            try
            {
                //Si el listado tiene elementos, entonces se genera el ID
                if (lstGrupos.Count > 0)
                {
                    grupos.id = lstGrupos.Last().id + 1;
                }
                else
                {
                    //Si el listado esta vacio entonces el id será por default 1
                    grupos.id = 1;
                }
                lstGrupos.Add(grupos);
                return grupos.id;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int modificarGrupos(int id, Grupos grupos)
        {
            try
            {
                //Buscando el indice en la ista
                lstGrupos[lstGrupos.FindIndex(temp => temp.id == id)] = grupos;
                return grupos.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para eliminar una carrera del listado
        public bool eliminarGrupos(int id)
        {
            try
            {
                //Buscando el indice en la ista
                lstGrupos.RemoveAt(lstGrupos.FindIndex(aux => aux.id == id));
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Para listar todos las carreras
        public List<Grupos> obtenerTodos()
        {
            return lstGrupos;
        }

        //Para encontrar una carrera por ID
        public Grupos obtenerPorID(int id)
        {
            try
            {
                var elementos = lstGrupos.Find(temp => temp.id == id);
                return elementos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}