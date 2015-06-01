using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.APIs
{
    public class SentimentAnalysis
    {
        public class RequestParams
        {
            private string _url;
            private string _text;
            private string _file;
            private string _reference;
            private string _language;


            public string Text
            {
                get { return _text; }
                set { _text = value; }
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

            public string Reference
            {
                get { return _reference; }
                set { _reference = value; }
            }

            public string Language
            {
                get { return _language; }
                set { _language = value; }
            }

        }

        public class SAAggregate
        {
            public string sentiment { get; set; }
            public int score { get; set; }
        }

        public class SentimentAnalysisResult
        {
            public List<object> positive { get; set; }
            public List<object> negative { get; set; }
            public SAAggregate aggregate { get; set; }
        }
    }
}

