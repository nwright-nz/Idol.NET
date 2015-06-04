using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDOLOnDemand.APIs
{
    public class OCRDocument
    {
        public class RequestParams
        {
            private string _file;
            private string _url;
            private string _reference;
            private string _mode;

            public string Mode // see for modes https://www.idolondemand.com/developer/apis/ocrdocument#request
            {
                get { return _mode; }
                set { _mode = value; }
            }



            public string Reference
            {
                get { return _reference; }
                set { _reference = value; }
            }


            public string URL
            {
                get { return _url; }
                set { _url = value; }
            }


            public string File
            {
                get { return _file; }
                set { _file = value; }
            }

        }
    }

    public class OCRDocumentOutput
    {
        public class TextBlock
        {
            public string text { get; set; }
            public int left { get; set; }
            public int top { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class RootObject
        {
            public List<TextBlock> text_block { get; set; }
        }

    }

    public class OCRDocumentOutputAsync
    {
        public class Result
        {
            public List<object> text_block { get; set; }
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
