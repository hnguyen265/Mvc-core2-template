using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HSU.TS.Data.Model
{
    public class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; }
        [Range(0, 10, ErrorMessage = "Please enter valid Number[0-10]")]
        public int? Order { get; set; } = 0;
        public int? Public { get; set; } = 1;

    }
}
