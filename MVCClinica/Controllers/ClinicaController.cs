using MVCClinica.Admin;
using MVCClinica.Data;
using MVCClinica.Filters;
using MVCClinica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCClinica.Controllers
{
    public class ClinicaController : Controller
    {
 
        public ActionResult Index()
        {
            return View("Index",AdmMedico.Listar());
        }
        
        [HttpGet]
        [MyFilterAction]
        public ActionResult Create()
        {
            Medico medico = new Medico();
            //retornamos la vista "Create" que tiene el objeto opera
            return View("Create", medico);
        }

        
        [HttpPost]      
        public ActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                AdmMedico.Crear(medico);
                return RedirectToAction("Index");
            }
            return View("create", medico);
        }
        //GET /Opera/Delete/Id
        [HttpGet]// default 
        public ActionResult Delete(int id)
        {
            Medico medico = AdmMedico.Listar(id);
            if (medico != null)
            {
                return View("Delete", medico);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // Medico/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = AdmMedico.Listar(id);
            AdmMedico.Eliminar(medico);
            return RedirectToAction("Index");

        }
        //GET /Opera/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Medico medico = AdmMedico.Buscar(id);
            if (medico != null)
            {
                return View("Edit", medico);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Medico medico)
        {
            if (ModelState.IsValid)
            {
                AdmMedico.Modificar(medico);
                return RedirectToAction("Index");
            }
            return View("Edit", medico);
        }

        public ActionResult Detail (int id)
        {
            Medico medico = AdmMedico.Listar(id);
            if (medico != null)
            {
                return View("Detail", medico);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult SearchByEspecialidad (int especialidadId)
        {
            if (especialidadId != 0)
            {
                return View("Index", AdmMedico.ListarEspecialidad(especialidadId));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult TraerNombreCompleto (string nombre, string apellido)
        {
            return View ("Index", AdmMedico.TraerPorNombreCompleto(nombre, apellido));
        }

    }
}