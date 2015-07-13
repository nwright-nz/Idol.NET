using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Response
{
    public class ListUserRolesResponse
    {
        public class Value
        {
            public string message { get; set; }
            public int error { get; set; }
            public string reason { get; set; }
            public List<string> detail { get; set; }
            public List<UserRole> userRoles { get; set; }
            public List<Action> actions { get; set; }
            public string status { get; set; }

        }

        public class UserRole
        {
            public string user { get; set; }
            public List<string> roles { get; set; }
        }
            
    }
}
