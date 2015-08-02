using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDOLOnDemand.Exceptions;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Response;
using Newtonsoft.Json;


namespace IDOLOnDemand.Model
{
    public class ListUserRoles
    {

        public string SyncEndpoint = "/sync/listuserroles/v1";
        public string AsyncEndpoint = "/async/listuserroles/v1";

       
        public string Store { get; set; }
        public string Users { get; set; }
        public string Roles { get; set; }




        public ListUserRolesResponse.Value Execute(IdolConnect ic)
        {
            var apiResults = ic.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<ListUserRolesResponse.Value>(apiResults);

            if (deseriaizedResponse.status != "failed" & deseriaizedResponse.status != null)
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
