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
    public class AddUserToStore : IIdolRequest
    {

       const string SyncEndpoint = "/sync/adduser/v1";
       const string AsyncEndpoint = "/async/adduser/v1";

       private string _store;
       private string _email;
       private string _password;
        




        public AddUserToStoreResponse.Value Execute(IdolConnect idolConnectionString, string UserStore, string UserEmail, string UserPassword)
        {
            _store = UserStore;
            _email = UserEmail;
            _password = UserPassword;

            var apiResults = idolConnectionString.Connect(this.ToParameterDictionary(), SyncEndpoint);
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

        public Dictionary<string, string> ToParameterDictionary()
        {
            return new Dictionary<string, string>
           {
               {"store", _store},
               {"email", _email},
               {"password", _password}
           };
        }
    }


}
