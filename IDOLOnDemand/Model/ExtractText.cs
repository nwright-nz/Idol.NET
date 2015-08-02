using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IDOLOnDemand.Exceptions;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Response;


namespace IDOLOnDemand.Model
{
    public class ExtractText
    {

        private readonly string SyncEndpoint = "/sync/extracttext/v1";
        private readonly string AsyncEndpoint = "/async/extracttext/v1";

        public string Url { get; set; }
        public string File { get; set; }
        public string Reference { get; set; }
        public bool Extract_Text { get; set; }
        public bool Extract_Metadata { get; set; }
        public bool Extract_Xmlattributes { get; set; }
        public string Additional_Metadata { get; set; }
        public string Reference_Prefix { get; set; }
        public string Password { get; set; }





        public ExtractTextResponse.Value Execute(IdolConnect ic)
        {
            var apiResults = ic.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<ExtractTextResponse.Value>(apiResults);

            if (deseriaizedResponse.message == null & deseriaizedResponse.detail == null)
            {
                return deseriaizedResponse;
            }
            else
            {
                if (deseriaizedResponse.message != null)
                {
                    throw new APIFailedException(deseriaizedResponse.message);
                }
                else
                {
                    throw new InvalidJobArgumentsException(deseriaizedResponse.detail[0]);
                }
            }

        }
    }


}
