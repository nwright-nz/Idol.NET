using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IDOLOnDemand.Response;
using IDOLOnDemand.Exceptions;
using IDOLOnDemand.Helpers;


namespace IDOLOnDemand.Model
{
    public class ListUsers: IIdolRequest
    {

        private readonly string SyncEndpoint = "/sync/listusers/v1";
        private readonly string AsyncEndpoint = "/async/listusers/v1";

        private string _store;





        public ListUsersResponse.Value Execute(IdolConnect idolConnectionString, string UserStore)
        {
            _store = UserStore;

            var apiResults = idolConnectionString.Connect(this.ToParameterDictionary(), SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<ListUsersResponse.Value>(apiResults);


            if (deseriaizedResponse.detail == null & deseriaizedResponse.status == null)
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

        public Dictionary<string, string> ToParameterDictionary()
        {
            return new Dictionary<string, string>
            {
                {"store",_store}
            };
        }
    }


}
