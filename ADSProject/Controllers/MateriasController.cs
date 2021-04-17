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
    public class MateriasController : Controller
    {
        // Instancia del servicio encargado de proveer los metodos
        public ServiceMaterias servicio = new ServiceMaterias();
        public MateriasController() { }

        [HttpGet]
        public ActionResult Index()
        {
            var materias = servicio.obtenerTodos();
            return View(materias);
        }

        [HttpGet]
        public ActionResult Form(int? id, Operaciones operaciones)
        {
            var materias = new Materias();
            //Si el id tiene un valor; entonces se procede a buscar una carrera
            if (id.HasValue)
            {
                materias = servicio.obtenerPorId(id.Value);
            }
            //Indica si la operacion que estamos realizando en el formulario
            ViewData["Operacion"] = operaciones;
            return View(materias);
        }

        [HttpPost]
        public ActionResult Form(Materias materias)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Si el ID es 0; entonces e esta insertando
                    if (materias.id == 0)
                    {
                        servicio.insertar(materias);
                    }
                    else
                    {
                        //Si el ID es distinto de cero entonces estamos modificando
                        servicio.modificar(materias.id, materias);
                    }
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
                //Eliminar una carrera
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