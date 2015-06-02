using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDOLOnDemand.APIs
{
    public class GetIndexInfo
    {
        #region Request Params
        public class RequestParams
        {
            private string _index;

            public string Index
            {
                get { return _index; }
                set { _index = value; }
            }


        }

        #endregion



    }

    public class GetIndexInfoOutput
    {
        public class RootObject
        {
            public int total_documents { get; set; }
            public int total_index_size { get; set; }
            public int __invalid_name__24hr_index_updates { get; set; }
            public int component_count { get; set; }
        }   
    }


    public class GetIndexInfoOutputAsync
    {
        public class Result
        {
            public int total_documents { get; set; }
            public int total_index_size { get; set; }
            public int __invalid_name__24hr_index_updates { get; set; }
            public int component_count { get; set; }
        }

        public class Action
        {
            public Result result { get; set; }
            public string status { get; set; }
            public string action { get; set; }
            public string version { get; set; }
        }

        public class RootObject
        {
            public List<Action> actions { get; set; }
            public string jobID { get; set; }
            public string status { get; set; }
        }
    }
}
