using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Response
{
    public class ListResourcesResponse
    {
        public class Value
        {
            public string message { get; set; }
            public int error { get; set; }
            public string reason { get; set; }
            public List<string> detail { get; set; }
            public List<PublicResource> public_resources { get; set; }
            public List<PrivateResource> private_resources { get; set; }
        }

        public class PublicResource
        {
            public string resource { get; set; }
            public string description { get; set; }
            public string type { get; set; }
        }

        public class PrivateResource
        {
            public string resource { get; set; }
            public string type { get; set; }
            public string flavor { get; set; }
            public object description { get; set; }
            public string date_created { get; set; }
        }

        
    }
}
