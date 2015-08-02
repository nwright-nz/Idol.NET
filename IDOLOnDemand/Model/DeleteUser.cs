using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IDOLOnDemand.Response;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Exceptions;


namespace IDOLOnDemand.Model
{
    public class DeleteUser : IIdolRequest
    {

        private readonly string SyncEndpoint = "/sync/deleteuser/v1";
        private readonly string AsyncEndpoint = "/async/deleteuser/v1";

        private string _store;
        private string _email;
     

        public DeleteUserResponse.Value Execute(IdolConnect idolConnectionString, string UserStore, string UserEmail)
        {
            _store = UserStore;
            _email = UserEmail;

            var apiResults = idolConnectionString.Connect(this.ToParameterDictionary(), SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<DeleteUserResponse.Value>(apiResults);

            if (deseriaizedResponse.message != "user was deleted" & deseriaizedResponse.status != "failed")
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
                    throw new InvalidJobArgumentsException(deseriaizedResponse.actions[0].errors[0].reason);
                }
            }

        }

        public Dictionary<string, string> ToParameterDictionary()
        {
            return new Dictionary<string, string>
           {
               {"store", _store},
               {"email", _email}

           };
        }
    }


}
