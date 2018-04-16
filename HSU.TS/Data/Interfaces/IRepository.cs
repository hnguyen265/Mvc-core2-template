using System;
using System.Collections;
using System.Collections.Generic;

namespace HSU.TS.Data.Interfaces
{

    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        T GetById(int id);
        void Add(T entity);
        void AddRange(IEnumerable entities);
        void Update(T entity);
        void Remove(object Id);
        void Remove(T entity);
        int Count(Func<T, bool> predicate);
    }

}
