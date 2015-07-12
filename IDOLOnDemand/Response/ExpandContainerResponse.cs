using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Response
{
    public class ExpandContainerResponse
    {
        public class Value
        {
            public List<File> files { get; set; }
            public string message { get; set; }
            public int error { get; set; }
            public string reason { get; set; }
            public List<string> detail { get; set; }
        }


        public class File
        {
            public string name { get; set; }
            public string reference { get; set; }
            public int size { get; set; }
        }

      
        
    }
}
