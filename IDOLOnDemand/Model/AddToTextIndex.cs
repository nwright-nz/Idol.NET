using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IDOLOnDemand.Response;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Exceptions;

namespace IDOLOnDemand.Model
{
    public class AddToTextIndex
    {

        public string SyncEndpoint = "/sync/addtotextindex/v1";
        public string AsyncEndpoint = "/async/addtotextindex/v1";

        public string Url { get; set; }
        public string Json { get; set; }
        public string File { get; set; }
        public string Reference { get; set; }
        public string AdditionalMetadata { get; set; }
        public string Reference_Prefix { get; set; }
        public string Index { get; set; }


        public enum Duplicate
        {
            duplicate,
            replace
        }

        private Duplicate _duplicate_mode;

        public Duplicate DuplicateMode
        {
            get { return _duplicate_mode; }
            set { _duplicate_mode = value; }
        }



        public AddToTextIndexResponse.Value Response()
        {
            var apiResults = IdolConnect.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<AddToTextIndexResponse.Value>(apiResults);

            if (deseriaizedResponse.message == null & deseriaizedResponse.error == 0)
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
                    if (deseriaizedResponse.detail.Count == 1)
                    {
                        throw new InvalidJobArgumentsException(deseriaizedResponse.detail[0]);
                       
                        
                    }
                    else
                    {
                        throw new InvalidJobArgumentsException(deseriaizedResponse.actions[0].errors[0].reason);
                    }
                }
            }

        }
    }


}
