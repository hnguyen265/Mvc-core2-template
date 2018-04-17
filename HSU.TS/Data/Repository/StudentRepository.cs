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
        private readonly MyDbContext context;
        public StudentRepository(MyDbContext context):base(context)
        {
            this.context = context;
        }

        public IEnumerable<Student> GetStudentRegisterByDate(DateTime fromDateTime, DateTime toDateTime)
        {
           return context.Students.Where(x => x.DateRegister >= fromDateTime && x.DateRegister <= toDateTime).ToList<Student>();
        }
    }

}
