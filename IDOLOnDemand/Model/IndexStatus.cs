using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDOLOnDemand.Response;
using IDOLOnDemand.Exceptions;
using IDOLOnDemand.Helpers;
using Newtonsoft.Json;


namespace IDOLOnDemand.Model
{
    public class IndexStatus
    {

        public string SyncEndpoint = "/sync/indexstatus/v1";
        public string AsyncEndpoint = "/async/indexstatus/v1";

        public string Index { get; set; }
       



        public IndexStatusResponse.Value Execute()
        {
            var apiResults = IdolConnect.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<IndexStatusResponse.Value>(apiResults);

            if (deseriaizedResponse.detail == null)
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
