using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDOLOnDemand.APIs
{
    #region Request params
    public class DeleteDocumentFromIndex
    {
        
        public class RequestParams
        {
            private string _index;
            private string _index_reference; //this should really be an array to do multiple deletes of documents.

            public string Index_Reference
            {
                get { return _index_reference; }
                set { _index_reference = value; }
            }

            public string Index
            {
                get { return _index; }
                set { _index = value; }
            }

        }



    }
    #endregion

    public class DeleteDocumentFromIndexOutput
    {
        public class RootObject
        {
            public string index { get; set; }
            public int documents_deleted { get; set; }
        }
    }


    public class DeleteDocumentFromIndecAsync
    {
        public class Result
        {
            public string index { get; set; }
            public int documents_deleted { get; set; }
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
