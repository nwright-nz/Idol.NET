using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDOLOnDemand.APIs
{
    public class CreateTextIndex
    {

         #region Request Parameters
        public class RequestParams
        {
            private string _description;
            private string _index;
            private string _flavor;

            public string Flavor
            {
                get { return _flavor; }
                set { _flavor = value; }
            }


            public string Index
            {
                get { return _index; }
                set { _index = value; }
            }


            public string Description
            {
                get { return _description; }
                set { _description = value; }
            }


        }
#endregion
    }

    #region Sync Output
    public class CreateTextIndexOutput
    {
        public class RootObject
        {
            public string message { get; set; }
            public string index { get; set; }
            public int error { get; set; }
            public string reason { get; set; }
            public List<Action> actions { get; set; }
            public string status { get; set; }
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
#endregion


    #region Async Output
    public class CreateTextIndexAsyncOutput
    {
        public class Result
        {
            public string message { get; set; }
            public string index { get; set; }
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



#endregion
}
