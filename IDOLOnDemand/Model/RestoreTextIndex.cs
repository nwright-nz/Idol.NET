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
    public class RestoreTextIndex
    {

        public string SyncEndpoint = "/sync/restoretextindex/v1";
        public string AsyncEndpoint = "/async/restoretextindex/v1";

       
        public string Index { get; set; }
        public string New_Index { get; set; }
        public string Date { get; set; }


       

        public RestoreTextIndexResponse.Value Execute(IdolConnect ic)
        {
            var apiResults = ic.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<RestoreTextIndexResponse.Value>(apiResults);
               


            if (deseriaizedResponse.status != "failed" & deseriaizedResponse.error != 4005)
            {
                return deseriaizedResponse;
            }
            else
            {
                if (deseriaizedResponse.message != null)
                {
                    throw new APIFailedException(deseriaizedResponse.message);
                    
                }
                else if (deseriaizedResponse.error == 4005)
                {
                    throw new InvalidJobArgumentsException("Error with job arguments - perhaps missing a required value?");
                    //had to do the above due to conflicts with the 'detail' some error results would use detail in the root object
                    //but some results would use detail as a property of actions.errors
                }
                else
                {
                    if (deseriaizedResponse.actions[0].errors[0].DetailsJson.GetType() == typeof(string))
                    {
                        throw new InvalidJobArgumentsException(deseriaizedResponse.actions[0].errors[0].reason);
                    }
                    else
                    {
                        throw new InvalidJobArgumentsException(deseriaizedResponse.actions[0].errors[0].DetailsJson.ToString());

                    }
                   
                }
            }

        }
    }


}
