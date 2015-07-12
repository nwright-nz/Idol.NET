using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Response
{
    public class QueryTextIndexResponse
    {
        public class Document
        {
            public string reference { get; set; }
            public double weight { get; set; }
            public List<string> links { get; set; }
            public string index { get; set; }
            public string title { get; set; }
            public string summary { get; set; }
        }

        public class Detail
        {
            public int error { get; set; }
            public string key { get; set; }
        }

        public class Value
        {
            public List<Document> documents { get; set; }
            public int totalhits { get; set; }
            public string message { get; set; }
            public Detail detail { get; set; }
        }
    }
}
