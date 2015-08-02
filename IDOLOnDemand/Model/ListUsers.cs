using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IDOLOnDemand.Response;
using IDOLOnDemand.Exceptions;
using IDOLOnDemand.Helpers;


namespace IDOLOnDemand.Model
{
    public class ListUsers
    {

        public string SyncEndpoint = "/sync/listusers/v1";
        public string AsyncEndpoint = "/async/listusers/v1";

        public string Store { get; set; }





        public ListUsersResponse.Value Execute(IdolConnect ic)
        {
            var apiResults = ic.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<ListUsersResponse.Value>(apiResults);


            if (deseriaizedResponse.detail == null & deseriaizedResponse.status == null)
            {
                return deseriaizedResponse;
            }
            else
            {
                if (deseriaizedResponse.error.Equals(4005))
                {
                    throw new APIFailedException(deseriaizedResponse.detail[0]);
                }
                else
                {
                    throw new InvalidJobArgumentsException("Invalid job arguments");
                }
            }

        }
    }


}
