using ADSProject.DAL;
using ADSProject.Models;
using ADSProject.Services;
using ADSProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADSProject.Controllers
{
    public class GruposController : Controller
    {

        // Instancia del servicio encargado de proveer los metodos1
        public CarrerasDAL carrerasDal = new CarrerasDAL();
        public MateriasDAL materiasDal = new MateriasDAL();
        public ProfesoresDAL profesoresDal = new ProfesoresDAL();
        public ServiceGrupos servicio = new ServiceGrupos();
        public GruposController() { }

        [HttpGet]
        public ActionResult Index()
        {
            var grupos = servicio.obtenerTodos();
            return View(grupos);
        }

        [HttpGet]
        public ActionResult Form(int? id, Operaciones operaciones)
        {          
            var grupos = new Grupos();
            List<Carreras> lstCarreras = carrerasDal.obtenerTodos();
            List<Materias> lstMaterias = materiasDal.obtenerTodos();
            List<Profesores> lstProfesores = profesoresDal.obtenerTodos();
            //Si el id tiene un valor; entonces se procede a buscar una carrera
            if (id.HasValue)
            {
                grupos = servicio.obtenerPorId(id.Value);
            }
            //Indica si la operacion que estamos realizando en el formulario
            ViewBag.Carreras = lstCarreras;
            ViewBag.Materias = lstMaterias;
            ViewBag.Profesores = lstProfesores;
            ViewData["Operacion"] = operaciones;
            return View(grupos);
        }

        [HttpPost]
        public ActionResult Form(Grupos grupos)
        {
            try
            {
                //Si el ID es 0; entonces e esta insertando
                if (grupos.id == 0)
                {
                    servicio.insertar(grupos);
                }
                else
                {
                    //Si el ID es distinto de cero entonces estamos modificando
                    servicio.modificar(grupos.id, grupos);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                //Eliminar un grupo
                servicio.eliminar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}