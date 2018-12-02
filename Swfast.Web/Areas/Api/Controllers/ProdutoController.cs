using Swfast.Data.Repositories;
using Swfast.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Swfast.Web.Areas.Api.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly IRepository<Produto> _repo;

        public ProdutoController(IRepository<Produto> repo)
        {
            _repo = repo;
        }


        // GET api/<controller>
        public IEnumerable<Produto> Get()
        {
            return _repo.GetAll();
        }

        // GET api/<controller>/5
        public Produto Get(int id)
        {

            Produto produto = _repo.GetById(id);

            if (produto == null)
            {
                return null;
            }

            return produto;
        }
    

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Produto item)
        {
            //if(Model)
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Produto item)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}