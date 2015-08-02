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
    public class AddUserStore : IIdolRequest
    {

        private readonly string SyncEndpoint = "/sync/addstore/v1";
        private readonly string AsyncEndpoint = "/async/addstore/v1";

        private string _store;



        public AddUserStoreResponse.Value Execute(IdolConnect ic, string UserStoreToCreate)

        {
            _store = UserStoreToCreate;

            var apiResults = ic.Connect(this.ToParameterDictionary(), SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<AddUserStoreResponse.Value>(apiResults);

            if (deseriaizedResponse.message == "store was added")
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
               {"store", _store}

           };
        }
    }


}
