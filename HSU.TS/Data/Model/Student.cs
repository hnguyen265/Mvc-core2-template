using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HSU.TS.Data.Model
{
    public class Student
    {
        public long Id { get; set; }
        [Required, MinLength(1), MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MinLength(1), MaxLength(50)]
        public string LastName { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime LastDateUpdate { get; set; }


    }
}
