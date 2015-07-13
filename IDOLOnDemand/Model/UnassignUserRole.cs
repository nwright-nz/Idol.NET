using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Exceptions;
using IDOLOnDemand.Response;
using Newtonsoft.Json;


namespace IDOLOnDemand.Model
{
    public class UnassignUserRole
    {

        public string SyncEndpoint = "/sync/unassignrole/v1";
        public string AsyncEndpoint = "/async/unassignrole/v1";

       
        public string Store { get; set; }
        public string User { get; set; }
        public string Role { get; set; }




        public UnassignUserRoleResponse.Value Execute()
        {
            var apiResults = IdolConnect.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<UnassignUserRoleResponse.Value>(apiResults);

            if (deseriaizedResponse.message != null)
            {
                return deseriaizedResponse;
            }
            else
            {
                if (deseriaizedResponse.error == 4005)
                {
                    throw new InvalidJobArgumentsException(deseriaizedResponse.detail[0]);
                   
                }
                else
                {
                    throw new APIFailedException(deseriaizedResponse.message);
                }
            }

        }
    }


}
