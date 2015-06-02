using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDOLOnDemand.APIs
{
    public class AddTextToIndex
    {
        #region Request Params
        public class RequestParams
        {
            private string _json;
            private string  _text;
            private string  _URL;
            private string _reference; //not implemented
            private string _additional_Metadata;
            private string _duplicate_mode; // not implementd (and it should be an array)
            private string _reference_prefix; //not implemented (and it should be an array)
            private string _index;

            public string Index
            {
                get { return _index; }
                set { _index = value; }
            }

            public string Reference_Prefix
            {
                get { return _reference_prefix; }
                set { _reference_prefix = value; }
            }



            public string Duplicate_Mode
            {
                get { return _duplicate_mode; }
                set { _duplicate_mode = value; }
            }
                
            public string Additional_Metadata
            {
                get { return _additional_Metadata; }
                set { _additional_Metadata = value; }
            }
            
            
            public string Reference
            {
                get { return _reference; }
                set { _reference = value; }
            }
            
            public string  URL
            {
                get { return _URL; }
                set { _URL = value; }
            }

            public string  Text
            {
                get { return _text; }
                set { _text = value; }
            }


            public string Json
            {
                get { return _json; }
                set { _json = value; }
            }


        }
        #endregion
    }

    #region Async Output
    public class AddTextToIndexOutputAsync
    {
        public class Reference
        {
            public string reference { get; set; }
            public int id { get; set; }
        }

        public class Result
        {
            public string index { get; set; }
            public List<Reference> references { get; set; }
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

    #region Sync Output
    public class AddTextToIndexOutput
    {

    }


    #endregion

}
