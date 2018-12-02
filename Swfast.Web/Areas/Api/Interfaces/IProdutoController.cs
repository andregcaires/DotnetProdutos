using Swfast.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Swfast.Web.Areas.Api.Interfaces
{
    public interface IProdutoController
    {
        IEnumerable<Produto> Get();

        Produto Get(int id);

        IHttpActionResult Post(Produto item);

        IHttpActionResult Put(int id, Produto item);

        IHttpActionResult Delete(int id);
    }
}
