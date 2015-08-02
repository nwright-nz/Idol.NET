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
    public class AuthenticateUser : IIdolRequest
    {

        const string SyncEndpoint = "/sync/authenticate/v1";
        const string AsyncEndpoint = "/async/authenticate/v1";

        public enum AuthMechanism
        {
            simple
        }

        private string _store;
        private string _user;
        private string _password;

        private AuthMechanism _mechanism;

        public AuthMechanism Mechanism
        {
            get { return _mechanism; }
            set { _mechanism = value; }
        }





        public AuthenticateUserResponse.Value Execute(IdolConnect ic, string UserStore, string User, string Password, AuthMechanism mech)
        {
            _store = UserStore;
            _password = Password;
            _user = User;

            var apiResults = ic.Connect(this.ToParameterDictionary(), SyncEndpoint);
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

        public Dictionary<string, string> ToParameterDictionary()
        {

            return new Dictionary<string, string>
            {
                {"store", _store},
                {"user", _user},
                {"password", _password},
                {"mechanism", _mechanism.ToString()}


            };
        }
    }


}
