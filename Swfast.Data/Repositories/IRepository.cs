using System;
using System.Collections.Generic;
using System.Text;

namespace Swfast.Data.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        T GetById(int id);

        void Insert(T instance);

        void Update(T instance);

        void Delete(T instance);
    }
}
