using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Response
{
    public class AssignRoleToUserResponse
    {
        public class Value
        {
            public string message { get; set; }
            public int error { get; set; }
            public string reason { get; set; }
            public List<string> detail { get; set; }
            public List<Action> actions { get; set; }
            public string status { get; set; }
            public string store { get; set; }
            public string role { get; set; }
            public string user { get; set; }

        }


        public class Error
        {
            public int error { get; set; }
            public string reason { get; set; }
            public string detail { get; set; }
        }

        public class Action
        {
            public List<Error> errors { get; set; }
            public string status { get; set; }
            public string action { get; set; }
            public string version { get; set; }
        }

        
    }
}
