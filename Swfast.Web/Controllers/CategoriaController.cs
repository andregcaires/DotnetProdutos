using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Swfast.Domain.Models;
using Swfast.Web.Areas.Api.Controllers;
using Swfast.Web.Areas.Api.Interfaces;

namespace Swfast.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaController apiController;

        public CategoriaController(ICategoriaController apiController)
        {
            this.apiController = apiController;
        }

        // GET: Categoria
        public ActionResult Index()
        {
            //return View(new Areas.Api.Controllers.CategoriaController().Get());
            return View(apiController.Get());
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            Categoria item = (Categoria) apiController.Get(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Categoria item)
        {
            if (ModelState.IsValid)
            {
                apiController.Post(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            Categoria item = (Categoria) apiController.Get(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Categoria item)
        {
            if (ModelState.IsValid)
            {
                apiController.Post(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            Categoria item = (Categoria)apiController.Get(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            apiController.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
