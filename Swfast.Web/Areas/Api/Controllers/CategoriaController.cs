using Swfast.Data.Repositories;
using Swfast.Domain.Models;
using Swfast.Web.Areas.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Swfast.Web.Areas.Api.Controllers
{
    public class CategoriaController : ApiController, ICategoriaController
    {
        private readonly IRepository<Categoria> _repo;

        public CategoriaController(IRepository<Categoria> repo)
        {
            _repo = repo;
        }

        // GET: api/Categoria
        public IEnumerable<Categoria> Get()
        {
            return _repo.GetAll();
        }

        // GET: api/Categoria/5
        [ResponseType(typeof(Categoria))]
        public Categoria Get(int id)
        {
            Categoria item = _repo.GetById(id);
            if (item == null)
            {
                return null;// NotFound();
            }

            return item; // Ok(item);
        }

        // POST: api/Categoria
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult Post(Categoria item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Insert(item);

            return CreatedAtRoute("Post", new { id = item.Id }, item);
        }

        // PUT: api/Categoria/5
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult Put(int id, Categoria item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            _repo.Update(item);


            if (_repo.GetById(id) == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // DELETE: api/Categoria/5
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult Delete(int id)
        {
            Categoria item = _repo.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            _repo.Delete(item);

            return Ok(item);
        }
    }
}
