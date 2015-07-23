using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Response
{
    public class CreateClassificationResponse
    {
        public class Value
        {
            public string message { get; set; }
            public int error { get; set; }
            public string reason { get; set; }
            public List<string> detail { get; set; }
        }
        public class Additional2
        {
            public object order { get; set; }
            public string target { get; set; }
            public object @operator { get; set; }
            public string value { get; set; }
            public object language { get; set; }
            public object notes { get; set; }
            public object condition { get; set; }
            public string type { get; set; }
            public bool is_fragment { get; set; }
            public bool include_descendants { get; set; }
            public object parent_condition_id { get; set; }
            public object children { get; set; }
            public string field { get; set; }
        }

        public class Condition
        {
            public int id { get; set; }
            public object name { get; set; }
            public object description { get; set; }
            public string type { get; set; }
            public Additional2 additional { get; set; }
        }

        public class Additional
        {
            public Condition condition { get; set; }
        }

        public class RootObject
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public Additional additional { get; set; }

        }
    }
}
