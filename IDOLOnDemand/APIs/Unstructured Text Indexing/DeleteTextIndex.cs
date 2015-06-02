using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDOLOnDemand.APIs
{
    #region Request Params
    public class DeleteTextIndex
    {
       
        public class RequestParams
        {
            private string _index;
            private string _confirm;

            public string Confirm
            {
                get { return _confirm; }
                set { _confirm = value; }
            }
            

            public string Index
            {
                get { return _index; }
                set { _index = value; }
            }

        }
       



    }
    #endregion

    #region Sync Output
    public class DeleteTextIndexOutput
    {
        public class RootObject
        {
            public bool deleted { get; set; }
            public string confirm { get; set; }
            
            public string index { get; set; }
        }

    }
    #endregion

    #region AsyncOutput
    public class DeleteTextIndexOutputAsync
    {
        public class Result
        {
            public bool deleted { get; set; }
            public string confirm { get; set; }
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
