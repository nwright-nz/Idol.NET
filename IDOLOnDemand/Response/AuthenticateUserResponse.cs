using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Response
{
    public class AuthenticateUserResponse
    {
        public class Value
        {
            public string message { get; set; }
            public int error { get; set; }
            public string reason { get; set; }
            public List<string> detail { get; set; }
            public bool success { get; set; }
            public Token token { get; set; }
            public List<Action> actions { get; set; }
            public string status { get; set; }
        }

        public class Data
        {
            public string user { get; set; }
        }

        public class Token
        {
            public int expiry { get; set; }
            public string secretId { get; set; }
            public Data data { get; set; }
            public string hash { get; set; }
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
