using Microsoft.EntityFrameworkCore;
using Swfast.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swfast.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        private readonly SwfastContext _context;

        public ProdutoRepository(SwfastContext context) : base(context)
        {
            _context = context;
        }

        public void Delete(Produto instance)
        {
            base.Delete(instance);
        }

        public override List<Produto> GetAll()
        {
            return _context.Produto.Include(p => p.Categoria).ToList();
        }

        public void Insert(Produto instance)
        {
            base.Insert(instance);
        }

        public void Update(Produto instance)
        {
            base.Update(instance);
        }
    }
}
