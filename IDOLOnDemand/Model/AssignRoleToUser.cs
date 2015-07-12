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
    public class AssignRoleToUser
    {

        public string SyncEndpoint = "/sync/assignrole/v1";
        public string AsyncEndpoint = "/async/assignrole/v1";

        public string Store { get; set; }
        public string User { get; set; }
        public string Role { get; set; }





        public AssignRoleToUserResponse.Value Response()
        {
            var apiResults = IdolConnect.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<AssignRoleToUserResponse.Value>(apiResults);

            if (deseriaizedResponse.message == "role now assigned")
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
                    if (deseriaizedResponse.reason == "Invalid job action parameters")
                    {
                        throw new InvalidJobArgumentsException(deseriaizedResponse.detail[0]);
                    }
                    else
                    {
                        string errors = "";
                        foreach (var x in deseriaizedResponse.actions[0].errors)
                        {
                            errors = errors + " - " + x.reason;
                        }
                        throw new InvalidJobArgumentsException(errors);
                    }


                }

            }
        }


    }
}

