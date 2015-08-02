using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDOLOnDemand.Response;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Exceptions;
using Newtonsoft.Json;


namespace IDOLOnDemand.Response
{
    public class AddUserToStore
    {

        public string SyncEndpoint = "/sync/adduser/v1";
        public string AsyncEndpoint = "/async/adduser/v1";

        public string Store { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        




        public AddUserToStoreResponse.Value Execute(IdolConnect ic)
        {
            var apiResults = ic.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<AddUserToStoreResponse.Value>(apiResults);

            if (deseriaizedResponse.message == "user was added")
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
                        throw new InvalidJobArgumentsException(deseriaizedResponse.actions[0].errors[0].reason);
                    }


                }
            }

        }
    }


}
