using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Helpers
{
    public class AsyncJob
    {
        public class Job
        {
            public string jobID { get; set; }
        }

        public class JobResults
        {

            public class Document
            {
                public string content { get; set; }
            }

            public class Result
            {
                public List<Document> document { get; set; }
            }

            public class Action
            {
                public Result result { get; set; }
                public string status { get; set; }
                public string action { get; set; }
                public string version { get; set; }
            }

            public class Results
            {
                public List<Action> actions { get; set; }
                public string jobID { get; set; }
                public string status { get; set; }
            }
        }
    }
}
