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
    public class MateriasController : Controller
    {
        // Instancia del servicio encargado de proveer los metodos
        public ServiceMaterias servicio = new ServiceMaterias();
        public ServiceCarreras servicioCarreras = new ServiceCarreras();
        public MateriasController() { }

        [HttpGet]
        public ActionResult Index()
        {
            var materias = servicio.obtenerTodos(new string[] { "Carrera" });
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
            ViewBag.Carreras = servicioCarreras.obtenerTodos();
            return View(materias);
        }

        [HttpPost]
        public ActionResult Form(Materias materias)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = 0;
                    //Si el ID es 0; entonces e esta insertando
                    if (materias.id == 0)
                    {
                        id = servicio.insertar(materias);
                    }
                    else
                    {
                        //Si el ID es distinto de cero entonces estamos modificando
                        id = servicio.modificar(materias.id, materias);
                    }
                    if (id > 0)
                    {
                        //Si la operación fué exitosa, entonces devolvemos un codigo 200(sucess)
                        return new JsonHttpStatusResult(materias, HttpStatusCode.OK);
                    }
                    else
                    {
                        //Si la operacion no fue exitosa, entonces devolvemos un codigo 202(Accepted)
                        return new JsonHttpStatusResult(materias, HttpStatusCode.Accepted);
                    }
                }
                else
                {
                    //Si hubo errores en la validación, entonces devolvemos todos los errores del modelo con un código 400 (Badrequest)
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(temp => temp.Errors);
                    return new JsonHttpStatusResult(allErrors, HttpStatusCode.BadRequest);
                }
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return new JsonHttpStatusResult(materias, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public JsonResult Delete(int id, string operacion)
        {
            try
            {
                //variable que permite controlar si fue eliminado correctamente
                bool correcto = false;
                //Eliminar una carrera
                correcto = servicio.eliminar(id);

                //Si la eliminacion fue correcta
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
                //throw;
            }
        }
    }
}