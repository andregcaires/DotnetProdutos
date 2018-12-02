using Swfast.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swfast.Data.Repositories
{
    public interface IProdutoRepository
    {
        List<Produto> GetAll();

        Produto GetById(int id);

        void Insert(Produto instance);

        void Update(Produto instance);

        void Delete(Produto instance);
    }
}
