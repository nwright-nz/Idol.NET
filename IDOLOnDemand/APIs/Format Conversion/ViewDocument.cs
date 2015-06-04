using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDOLOnDemand.APIs
{
    //NOte: this call behaves a little differently in terms of the HTML returned. This isnt in the standard JSON response, it just returns a pure string.
    // the idol connect class handles this. No need to deserialize the synchronous call of this as its JUST string.
    public class ViewDocument
        
    {
        public class RequestParams
        {
            private string _file;
            private string _url;
            private string _reference;
            private string _highlight_text;
            private string _start_tag;
            private string _end_tag;
            private bool _raw_html;

            public bool Raw_Html
            {
                get { return _raw_html; }
                set { _raw_html = value; }
            }


            public string End_Tag
            {
                get { return _end_tag; }
                set { _end_tag = value; }
            }


            public string Start_Tag
            {
                get { return _start_tag; }
                set { _start_tag = value; }
            }


            public string Highlight_Text
            {
                get { return _highlight_text; }
                set { _highlight_text = value; }
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


    public class ViewDocumentOutputAsync
    {
        public class Action
        {
            public string result { get; set; }
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
