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

        internal DbSet<T> _dbSet;
        internal MyDbContext _context;


        public Repository(MyDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
       // protected void Save() => _context.SaveChanges();

        public int Count(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate).Count();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
           // Save();
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
          //  Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }


        public void Update(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            entry.State = EntityState.Modified;
          //  Save();
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            //Save();
        }

        public void AddRange(IEnumerable entities)
        {
            _context.AddRange(entities);
          //  Save();
        }

        public void Remove(object Id)
        {
            this.Remove(_dbSet.Find(Id));
          //  Save();
        }

        public T GetById(long id)
        {
            return  _dbSet.Find(id);
        }
        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
