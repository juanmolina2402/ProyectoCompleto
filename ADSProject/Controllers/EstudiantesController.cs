using ADSProject.Models;
using ADSProject.Services;
using ADSProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ADSProject.Controllers
{
    public class EstudiantesController : Controller
    {
        // Instancia del servicio encargado de proveer los metodos
        public ServiceEstudiantes servicio = new ServiceEstudiantes();
        public ServiceCarreras servicioCarreras = new ServiceCarreras();
        public EstudiantesController() { }

        [HttpGet]
        public ActionResult Index()
        {
            var estudiantes = servicio.obtenerTodos(new string[] { "Carrera" });
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

            //Carreras para llenar el listado de carreras
            ViewBag.Carreras = servicioCarreras.obtenerTodos();
            return View(estudiantes);
        }

        [HttpPost]
        public ActionResult Form(Estudiantes estudiantes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = 0;
                    //Si el ID es 0; entonces e esta insertando
                    if (estudiantes.id == 0)
                    {
                        id = servicio.insertar(estudiantes);
                    }
                    else
                    {
                        //Si el ID es distinto de cero entonces estamos modificando
                        id= servicio.modificar(estudiantes.id, estudiantes);
                    }

                    if (id > 0)
                    {
                        //Si la operación fué exitosa, entonces devolvemos un codigo 200(sucess)
                        return new JsonHttpStatusResult(estudiantes, HttpStatusCode.OK);
                    }
                    else
                    {
                        //Si la operacion no fue exitosa, entonces devolvemos un codigo 202(Accepted)
                        return new JsonHttpStatusResult(estudiantes, HttpStatusCode.Accepted);
                    }
                }
                else
                {
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(temp => temp.Errors);
                    return new JsonHttpStatusResult(allErrors, HttpStatusCode.BadRequest);
                }
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return new JsonHttpStatusResult(estudiantes, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public JsonResult Delete(int id, string operacion)
        {
            try
            {
                bool correcto = false;
                //Eliminar una carrera
                correcto = servicio.eliminar(id);
                //Eliminar un estudiante           
                if (correcto)
                {
                    //Se devuelve el id del elemento eliminado y se retorna un codigo 200 (succes)
                    return new JsonHttpStatusResult(new { id }, HttpStatusCode.OK);
                }
                else
                {
                    //Si no se puede eliminar, entonces se retorna un codigo 202(accepted)
                    return new JsonHttpStatusResult(new { id }, HttpStatusCode.Accepted);
                }
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return new JsonHttpStatusResult(new { id }, HttpStatusCode.InternalServerError);
            }
        }
    }
}