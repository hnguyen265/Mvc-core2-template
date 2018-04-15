using HSU.TS.Data.Interfaces;
using HSU.TS.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSU.TS.Data.Repository
{

    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly MyDbContext _dbContext;
        public StudentRepository(MyDbContext context):base(context)
        {
            _dbContext = context;
        }

     
    }

}
