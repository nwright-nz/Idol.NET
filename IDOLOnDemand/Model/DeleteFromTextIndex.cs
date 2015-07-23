using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Response;
using IDOLOnDemand.Exceptions;
using Newtonsoft.Json;


namespace IDOLOnDemand.Model
{
    public class DeleteFromTextIndex
    {

        public string SyncEndpoint = "/sync/deletefromtextindex/v1";
        public string AsyncEndpoint = "/async/deletefromtextindex/v1";

        public string Index { get; set; }
        public string Index_Reference { get; set; }
        public bool Delete_All_Documents { get; set; }
       




        public DeleteFromTextIndexResponse.Value Execute()
        {
            var apiResults = IdolConnect.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<DeleteFromTextIndexResponse.Value>(apiResults);

            if (deseriaizedResponse.message == null & deseriaizedResponse.error != 4005)
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
