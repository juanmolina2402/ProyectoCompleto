using ADSProject.DAL;
using ADSProject.Models;
using ADSProject.Models.Context;
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
    public class GruposController : Controller
    {
        // Instancia del servicio encargado de proveer los metodos1
        public ServiceGrupos servicio = new ServiceGrupos();
        public ServiceCarreras servicioCarreras = new ServiceCarreras();
        public ServiceMaterias servicioMaterias = new ServiceMaterias();
        public ServiceProfesores servicioProfesores = new ServiceProfesores();
        public GruposController() { }

        [HttpGet]
        public ActionResult Index()
        {
            var grupos = servicio.obtenerTodos(new string[] { "Carrera" , "Materia", "Profesor" });
            return View(grupos);
        }

        [HttpGet]
        public ActionResult Form(int? id, Operaciones operaciones)
        {          
            var grupos = new Grupos();            
            //Si el id tiene un valor; entonces se procede a buscar una carrera
            if (id.HasValue)
            {
                grupos = servicio.obtenerPorId(id.Value);
            }
            ViewData["Operacion"] = operaciones;
            ViewBag.Carrera = servicioCarreras.obtenerTodos();            ViewBag.Materia = servicioMaterias.obtenerTodos();
            ViewBag.Profesor = servicioProfesores.obtenerTodos();
            return View(grupos);
        }

        [HttpPost]
        public ActionResult Form(Grupos grupos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = 0;
                    //Si el ID es 0; entonces e esta insertando
                    if (grupos.id == 0)
                    {
                        id = servicio.insertar(grupos);
                    }
                    else
                    {
                        //Si el ID es distinto de cero entonces estamos modificando
                        id = servicio.modificar(grupos.id, grupos);
                    }
                    if (id > 0)
                    {
                        //Si la operación fué exitosa, entonces devolvemos un codigo 200(sucess)
                        return new JsonHttpStatusResult(grupos, HttpStatusCode.OK);
                    }
                    else
                    {
                        //Si la operacion no fue exitosa, entonces devolvemos un codigo 202(Accepted)
                        return new JsonHttpStatusResult(grupos, HttpStatusCode.Accepted);
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
                return new JsonHttpStatusResult(grupos, HttpStatusCode.InternalServerError);
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