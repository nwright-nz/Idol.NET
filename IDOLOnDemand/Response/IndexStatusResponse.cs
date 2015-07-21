using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Response
{
    public class IndexStatusResponse
    {
        public class Value
        {
            public string message { get; set; }
            public int error { get; set; }
            public string reason { get; set; }
            public List<string> detail { get; set; }
            public int total_documents { get; set; }
            public int total_index_size { get; set; }
            public int _24hr_index_updates { get; set; }
            public int component_count { get; set; }
        }
    }
}
