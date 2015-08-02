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
    public class ListRoles :IIdolRequest
    {

        private readonly string SyncEndpoint = "/sync/listroles/v1";
        private readonly string AsyncEndpoint = "/async/listroles/v1";


        private string _store;

        public ListRolesResponse.Value Execute(IdolConnect idolConnectionString, string UserStore)
        {
            _store = UserStore;

            var apiResults = idolConnectionString.Connect(this.ToParameterDictionary(), SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<ListRolesResponse.Value>(apiResults);

            if (deseriaizedResponse.message == null & deseriaizedResponse.detail == null)
            {
                return deseriaizedResponse;
            }
            else
            {
               
                    throw new InvalidJobArgumentsException(deseriaizedResponse.detail[0]);
               
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
