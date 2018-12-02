using Swfast.Data.Repositories;
using Swfast.Domain.Models;
using Swfast.Web.Areas.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Swfast.Web.Areas.Api.Controllers
{
    public class ProdutoController : ApiController, IProdutoController
    {
        private readonly IRepository<Produto> _repo;

        public ProdutoController(IRepository<Produto> repo)
        {
            _repo = repo;
        }

        // GET: api/Produto
        public IEnumerable<Produto> Get()
        {
            return _repo.GetAll();
        }

        // GET: api/Produto/5
        [ResponseType(typeof(Produto))]
        public Produto Get(int id)
        {
            Produto item = _repo.GetById(id);
            if (item == null)
            {
                return null;// NotFound();
            }

            return item; // Ok(item);
        }

        // POST: api/Produto
        [ResponseType(typeof(Produto))]
        public IHttpActionResult Post(Produto item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Insert(item);

            return CreatedAtRoute("Post", new { id = item.Id }, item);
        }

        // PUT: api/Produto/5
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult Put(int id, Produto item)
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

        // DELETE: api/Produto/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult Delete(int id)
        {
            Produto item = _repo.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            _repo.Delete(item);

            return Ok(item);
        }
    }
}