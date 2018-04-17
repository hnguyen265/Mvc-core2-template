using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSU.TS.Data.Configurations
{
    public class SessionConfig
    {
        public string Id { get; set; }
        public FirstMessage FirstMessage { get; set; }
    }
    public class FirstMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
}



