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
    public class CarrerasController : Controller
    {
        // Instancia del servicio encargado de proveer los metodos
        public ServiceCarreras servicio = new ServiceCarreras();
        public CarrerasController() { }

        [HttpGet]
        public ActionResult Index()
        {
            var carreras = servicio.obtenerTodos();
            return View(carreras);
        }

        [HttpGet]
        public ActionResult Form(int? id, Operaciones operaciones)
        {
            var carreras = new Carreras();
            //Si el id tiene un valor; entonces se procede a buscar una carrera
            if (id.HasValue)
            {
                carreras = servicio.obtenerPorId(id.Value);
            }
            //Indica si la operacion que estamos realizando en el formulario
            ViewData["Operacion"] = operaciones;
            return View(carreras);
        }

        [HttpPost]
        public ActionResult Form(Carreras carreras)
        {
            try
            {
                //Si el ID es 0; entonces e esta insertando
                if (carreras.id == 0)
                {
                    servicio.insertar(carreras);
                }
                else
                {
                    //Si el ID es distinto de cero entonces estamos modificando
                    servicio.modificar(carreras.id, carreras);
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