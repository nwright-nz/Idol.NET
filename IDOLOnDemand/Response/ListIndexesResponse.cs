using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Response
{
    public class ListIndexesResponse
    {
        public class Value
        {
            public string message { get; set; }
            public int error { get; set; }
            public string reason { get; set; }
            public List<string> detail { get; set; }
            public List<PublicIndex> public_index { get; set; }
            public List<Index> index { get; set; }
        }

        public class PublicIndex
        {
            public string index { get; set; }
            public string description { get; set; }
            public string type { get; set; }
        }

        public class Index
        {
            public string index { get; set; }
            public string type { get; set; }
            public string flavor { get; set; }
            public object description { get; set; }
            public string date_created { get; set; }
        }

        
    }
}
