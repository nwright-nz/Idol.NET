using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Response
{
    public class RecognizeImagesResponse
    {

        public class Corner
        {
            public int x { get; set; }
            public int y { get; set; }
        }

        public class Object
        {
            public string name { get; set; }
            public string unique_name { get; set; }
            public string db { get; set; }
            public List<Corner> corners { get; set; }
        }


        public class Value
        {
            public List<Object> @object { get; set; }
            public string message { get; set; }
            public int error { get; set; }
            public string reason { get; set; }
            public List<string> detail { get; set; }
        }
    }
}
