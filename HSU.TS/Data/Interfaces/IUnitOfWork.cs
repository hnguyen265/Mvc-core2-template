using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSU.TS.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       
        int SaveChanges();
    }
}
