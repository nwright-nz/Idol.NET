using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Response
{
    public class ErrorResponse
    {
       
        public class Error
        {
           
            public int error { get; set; }
            public string reason { get; set; }
            public List<string> details { get; set; }
        }
    }
}
