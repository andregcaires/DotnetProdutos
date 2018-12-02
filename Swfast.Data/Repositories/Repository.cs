using Microsoft.EntityFrameworkCore;
using Swfast.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swfast.Data.Repositories
{
    // repositório genérico para CRUD básico
    public class Repository<T> : IRepository<T> where T : Entity
    {

        private readonly SwfastContext _context;

        public Repository(SwfastContext context)
        {
            _context = context;
        }

        public void Delete(T instance)
        {

            _context.Set<T>().Remove(instance);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T instance)
        {
            _context.Set<T>().Add(instance);
            _context.SaveChanges();
        }

        public void Update(T instance)
        {
            //_context.Set<T>().Update(instance);
            _context.Entry(instance).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
