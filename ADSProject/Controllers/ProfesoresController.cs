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
                    int id = 0;
                    //Si el ID es 0; entonces e esta insertando
                    if (profesores.id == 0)
                    {
                        id = servicio.insertar(profesores);
                    }
                    else
                    {
                        //Si el ID es distinto de cero entonces estamos modificando
                        id = servicio.modificar(profesores.id, profesores);
                    }
                    if (id > 0)
                    {
                        //Si la operación fué exitosa, entonces devolvemos un codigo 200(sucess)
                        return new JsonHttpStatusResult(profesores, HttpStatusCode.OK);
                    }
                    else
                    {
                        //Si la operacion no fue exitosa, entonces devolvemos un codigo 202(Accepted)
                        return new JsonHttpStatusResult(profesores, HttpStatusCode.Accepted);
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
                return new JsonHttpStatusResult(profesores, HttpStatusCode.InternalServerError);
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