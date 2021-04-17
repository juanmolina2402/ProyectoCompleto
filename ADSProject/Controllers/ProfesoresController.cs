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
    public class ProfesoresController : Controller
    {
        // Instancia del servicio encargado de proveer los metodos
        public ServiceProfesores servicio = new ServiceProfesores();
        public ProfesoresController() { }

        [HttpGet]
        public ActionResult Index()
        {
            var profesores = servicio.obtenerTodos();
            return View(profesores);
        }

        [HttpGet]
        public ActionResult Form(int? id, Operaciones operaciones)
        {
            var profesores = new Profesores();
            //Si el id tiene un valor; entonces se procede a buscar un estudiante
            if (id.HasValue)
            {
                profesores = servicio.obtenerPorId(id.Value);
            }
            //Indica si la operacion que estamos realizando en el formulario
            ViewData["Operacion"] = operaciones;
            return View(profesores);
        }

        [HttpPost]
        public ActionResult Form(Profesores profesores)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Si el ID es 0; entonces e esta insertando
                    if (profesores.id == 0)
                    {
                        servicio.insertar(profesores);
                    }
                    else
                    {
                        //Si el ID es distinto de cero entonces estamos modificando
                        servicio.modificar(profesores.id, profesores);
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
                //Eliminar un profesor
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