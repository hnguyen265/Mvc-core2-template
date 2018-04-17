using HSU.TS.Data.Model;
using System;
using System.Collections.Generic;

namespace HSU.TS.Data.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetStudentRegisterByDate(DateTime fromDateTime, DateTime toDateTime);
    }

}
