using ADSProject.Models;
using ADSProject.Services;
using ADSProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

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
            {   //Validamos que el modelo carrera sea válido
                //Segun las validaciones que le agregamos anteriormente
                if (ModelState.IsValid) {
                    //Esta variable nos sirve para saber si una carrera ha sido insertado correctamente.
                    int id = 0;
                    //Si el ID es 0; entonces e esta insertando
                    if (carreras.id == 0)
                    {
                        id = servicio.insertar(carreras);
                    }
                    else
                    {
                        //Si el ID es distinto de cero entonces estamos modificando
                        id = servicio.modificar(carreras.id, carreras);
                    }

                    // Si el id es mayoir a cero, entonces la operación es correcta.
                    if (id > 0)
                    {
                        //Si la operación fué exitosa, entonces devolvemos un codigo 200(sucess)
                        return new JsonHttpStatusResult(carreras, HttpStatusCode.OK);
                    }
                    else
                    {
                        //Si la operacion no fue exitosa, entonces devolvemos un codigo 202(Accepted)
                        return new JsonHttpStatusResult(carreras, HttpStatusCode.Accepted);
                    }
                }else
                {
                    //Si hubo errores en la validación, entonces devolvemos todos los errores del modelo con un código 400 (Badrequest)
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(temp => temp.Errors);
                    return new JsonHttpStatusResult(allErrors, HttpStatusCode.BadRequest);
                }
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return new JsonHttpStatusResult(carreras, HttpStatusCode.InternalServerError);
                //throw;
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