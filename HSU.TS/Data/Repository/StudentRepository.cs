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
        public StudentRepository(MyDbContext context) : base(context)
        {
        }

        public IEnumerable<Student> FindWithStudent(Func<Student, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllWithStudent()
        {
            throw new NotImplementedException();
        }
    }

}
