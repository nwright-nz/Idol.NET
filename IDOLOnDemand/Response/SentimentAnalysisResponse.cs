using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IDOLOnDemand.Response
{
    public class SentimentAnalysisResponse : ErrorResponse
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

        
        public class Value
        {
            public List<Positive> positive { get; set; }
            public List<object> negative { get; set; }
            public Aggregate aggregate { get; set; }
            public string message { get; set; }

            public int error { get; set; }
            public string reason { get; set; }
            public List<string> detail { get; set; }
          

        }
    }
}
