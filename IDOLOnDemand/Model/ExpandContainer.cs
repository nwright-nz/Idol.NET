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
    public class ExpandContainer
    {

        public string SyncEndpoint = "/sync/expandcontainer/v1";
        public string AsyncEndpoint = "/async/expandcontainer/v1";

        public string Url { get; set; }
        public string File { get; set; }
        public string Reference { get; set; }
        public int Depth { get; set; }
        public string Password { get; set; }




        public ExpandContainerResponse.Value Response()
        {
            var apiResults = IdolConnect.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<ExpandContainerResponse.Value>(apiResults);

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
