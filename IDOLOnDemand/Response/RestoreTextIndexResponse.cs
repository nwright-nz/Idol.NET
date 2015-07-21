using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IDOLOnDemand.Helpers;

namespace IDOLOnDemand.Response
{
    public class RestoreTextIndexResponse
    {
        public class Value
        {
            public string message { get; set; }
            public int error { get; set; }
            public string reason { get; set; }
           // public List<string> detail { get; set; }
            public List<Action> actions { get; set; }
            public string status { get; set; }
            public string restored { get; set; }
        }

        public class Detail
        {
            public string message { get; set; }     
            public string date { get; set; }
        }

        public class Error
        {
            public int error { get; set; }
            public string reason { get; set; }

            
            public Detail Detail { 
                get
                {
                    var test = this.DetailsJson.ToString();
                    if (test.GetType() == typeof(string))
                    {
                        return new Detail();
                    }
                    else
                    {
                        return JsonConvert.DeserializeObject<Detail>(test);

                    }
                }
               
            }

            [JsonProperty(PropertyName="detail")]
            public object DetailsJson { get; set; }
        }

        public class Action
        {
            public List<Error> errors { get; set; }
            public string status { get; set; }
            public string action { get; set; }
            public string version { get; set; }
        }

      
    }
}
