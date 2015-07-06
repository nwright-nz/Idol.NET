using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.APIs
{
    public class SentimentAnalysis
    {
        #region Request Parameters
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
        #endregion

//testing
    }


    #region Async Output
    public class SentimentAnalysisOutputAsync
    {
        public class Positive
        {
            public string sentiment { get; set; }
            public object topic { get; set; }
            public double score { get; set; }
            public string original_text { get; set; }
            public int original_length { get; set; }
            public string normalized_text { get; set; }
            public int normalized_length { get; set; }
        }

        public class Aggregate
        {
            public string sentiment { get; set; }
            public double score { get; set; }
        }

        public class Result
        {
            public List<Positive> positive { get; set; }
            public List<object> negative { get; set; }
            public Aggregate aggregate { get; set; }
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

    public class SentimentAnalysisOutput
    {
        public class Positive
        {
            public string sentiment { get; set; }
            public object topic { get; set; }
            public double score { get; set; }
            public string original_text { get; set; }
            public int original_length { get; set; }
            public string normalized_text { get; set; }
            public int normalized_length { get; set; }
        }

        public class Aggregate
        {
            public string sentiment { get; set; }
            public double score { get; set; }
        }

        public class RootObject
        {
            public List<Positive> positive { get; set; }
            public List<object> negative { get; set; }
            public Aggregate aggregate { get; set; }
        }
    }
    #endregion

}

