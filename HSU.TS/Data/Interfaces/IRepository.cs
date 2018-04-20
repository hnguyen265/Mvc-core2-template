using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HSU.TS.Data.Interfaces
{

    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Func<T, bool> predicate);
        Task<T> GetByIdAsync(long id);
        T GetById(long id);
        void Add(T entity);
        void AddRange(IEnumerable entities);
        void Update(T entity);
        void Remove(object Id);
        void Remove(T entity);
        int Count(Func<T, bool> predicate);
    }

}
