using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.APIs
{
    public class SpeechRecognition
        
    {
        #region Parameters for request
        public class RequestParams
        {
            private string _url;

            public string URL
            {
                get { return _url; }
                set { _url = value; }
            }


            private string _reference;

            public string Reference
            {
                get { return _reference; }
                set { _reference = value; }
            }

            private string _file;

            public string File
            {
                get { return _file; }
                set { _file = value; }
            }


            private int _interval;

            public int Interval
            {
                get { return _interval; }
                set { _interval = value; }
            }


            private string _language;

            public string Language
            {
                get { return _language; }
                set { _language = value; }
            }





        }
        #endregion Parameters for request
    }
    #region Async Output
    public class SpeechRecognitionOutput
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

        public class RootObject
        {
            public List<Action> actions { get; set; }
            public string jobID { get; set; }
            public string status { get; set; }
        }
    }
#endregion Async Output

}
