using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using IDOLOnDemand.Response;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Exceptions;


namespace IDOLOnDemand.Model
{
    public class FaceDetection
    {

        public string SyncEndpoint = "/sync/detectfaces/v1";
        public string AsyncEndpoint = "/async/detectfaces/v1";

        public string Url { get; set; }
        public bool Additional { get; set; }
        public string File { get; set; }
        public string Reference { get; set; }




        public FaceDetectionResponse.Value Execute()
        {
            var apiResults = IdolConnect.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<FaceDetectionResponse.Value>(apiResults);

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
