﻿using System;
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
    public class ProdutoController : Controller
    {
        private readonly IProdutoController apiController;

        public ProdutoController(IProdutoController apiController)
        {
            this.apiController = apiController;
        }

        // GET: Produto
        public ActionResult Index()
        {
            //return View(new Areas.Api.Controllers.ProdutoController().Get());
            return View(apiController.Get());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            Produto item = apiController.Get(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Preco")] Produto item)
        {
            if (ModelState.IsValid)
            {
                apiController.Post(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            Produto item = apiController.Get(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Preco")] int id, Produto item)
        {
            if (ModelState.IsValid)
            {
                apiController.Put(id, item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            Produto item = apiController.Get(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            apiController.Delete(id);
            return RedirectToAction("Index");
        }
    }
}