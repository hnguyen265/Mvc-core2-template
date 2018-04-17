using HSU.TS.Data.Interfaces;
using HSU.TS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;

namespace HSU.TS.Data.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private MyDbContext context ;
        public UnitOfWork(MyDbContext context)
        {
            this.context = context;
        }
        private IStudentRepository studentRepository;
        public IStudentRepository StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new StudentRepository(context);
                }
                return studentRepository;
            }
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
