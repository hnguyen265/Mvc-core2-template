using HSU.TS.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSU.TS.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MyDbContext _context;
        protected DbSet<T> _dbSet;

        public Repository(MyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        protected void Save() => _context.SaveChanges();

        public int Count(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate).Count();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void AddRange(IEnumerable entities)
        {
            _context.AddRange(entities);
            Save();
        }

        public void Remove(object Id)
        {     
            this.Remove(_dbSet.Find(Id));
            Save();
        }
    }
}
//http://www.dotnettricks.com/learn/mvc/implementing-repository-and-unit-of-work-patterns-with-mvc
//http://www.c-sharp.vn/entity-framework/repository-va-unit-of-work-c36aeb
