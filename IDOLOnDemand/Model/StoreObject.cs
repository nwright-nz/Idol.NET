using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDOLOnDemand.Response;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Exceptions;
using Newtonsoft.Json;

namespace IDOLOnDemand.Model
{
    public class StoreObject
    {

        public string SyncEndpoint = "/sync/storeobject/v1";
        public string AsyncEndpoint = "/async/storeobject/v1";

        public string Url { get; set; }
        public string File { get; set; }
        public string Reference { get; set; }




        public StoreObjectResponse.Value Response()
        {
            var apiResults = IdolConnect.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<StoreObjectResponse.Value>(apiResults);

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
