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
    public class EstudiantesController : Controller
    {
        // Instancia del servicio encargado de proveer los metodos
        public ServiceEstudiantes servicio = new ServiceEstudiantes();
        public EstudiantesController() { }

        [HttpGet]
        public ActionResult Index()
        {
            var estudiantes = servicio.obtenerTodos();
            return View(estudiantes);
        }

        [HttpGet]
        public ActionResult Form(int? id, Operaciones operaciones)
        {
            var estudiantes = new Estudiantes();
            //Si el id tiene un valor; entonces se procede a buscar un estudiante
            if (id.HasValue)
            {
                estudiantes = servicio.obtenerPorId(id.Value);
            }
            //Indica si la operacion que estamos realizando en el formulario
            ViewData["Operacion"] = operaciones;
            return View(estudiantes);
        }

        [HttpPost]
        public ActionResult Form(Estudiantes estudiantes)
        {
            try
            {
                //Si el ID es 0; entonces e esta insertando
                if(estudiantes.id == 0)
                {
                    servicio.insertar(estudiantes);
                }else
                {
                    //Si el ID es distinto de cero entonces estamos modificando
                    servicio.modificar(estudiantes.id, estudiantes);
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
                //Eliminar un estudiante
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