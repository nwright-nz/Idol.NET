using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IDOLOnDemand.Exceptions;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Response;


namespace IDOLOnDemand.Model
{
    public class DeleteUserStore : IIdolRequest
    {

        private readonly string SyncEndpoint = "/sync/deletestore/v1";
        private readonly string AsyncEndpoint = "/async/deletestore/v1";


        private string _store;

        public DeleteUserStoreResponse.Value Execute(IdolConnect idolConnectionString, string UserStore)
        {
            _store = UserStore;

            var apiResults = idolConnectionString.Connect(this.ToParameterDictionary(), SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<DeleteUserStoreResponse.Value>(apiResults);

            if (deseriaizedResponse.message == "store was deleted")
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
                {"store", _store}

            };
        }
    }


}
