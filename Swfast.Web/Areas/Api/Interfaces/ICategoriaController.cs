using Swfast.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Swfast.Web.Areas.Api.Interfaces
{
    public interface ICategoriaController
    {
        IEnumerable<Categoria> Get();

        Categoria Get(int id);

        IHttpActionResult Post(Categoria item);

        //IHttpActionResult PutCategoria(int id, Categoria categoria);
        IHttpActionResult Put(int id, Categoria categoria);

        IHttpActionResult Delete(int id);


    }
}
