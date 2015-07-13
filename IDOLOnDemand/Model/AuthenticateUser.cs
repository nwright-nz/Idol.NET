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
    public class AuthenticateUser
    {

        public string SyncEndpoint = "/sync/authenticate/v1";
        public string AsyncEndpoint = "/async/authenticate/v1";

        public enum AuthMechanism
        {
            simple
        }

        public string Store { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        private AuthMechanism _mechanism;

        public AuthMechanism Mechanism
        {
            get { return _mechanism; }
            set { _mechanism = value; }
        }





        public AuthenticateUserResponse.Value Response()
        {
            var apiResults = IdolConnect.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<AuthenticateUserResponse.Value>(apiResults);

            if (deseriaizedResponse.success == true | deseriaizedResponse.success == false)
            {
                return deseriaizedResponse;
            }
            else
            {
                if (deseriaizedResponse.status == "failed")
                {
                    throw new InvalidJobArgumentsException(deseriaizedResponse.actions[0].errors[0].reason);
                   
                }
                else
                {
                    throw new InvalidJobArgumentsException(deseriaizedResponse.status);
                }
            }

        }
    }


}
