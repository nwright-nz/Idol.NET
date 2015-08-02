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
    public class ListUserStores : IIdolRequest
    {

        private readonly string SyncEndpoint = "/sync/liststores/v1";
        private readonly string AsyncEndpoint = "/async/liststores/v1";

       
        public ListUserStoresResponse.Value Execute(IdolConnect idolConnectionString)
        {
            var apiResults = idolConnectionString.Connect(this.ToParameterDictionary(), SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<ListUserStoresResponse.Value>(apiResults);

            if (deseriaizedResponse.message == null & deseriaizedResponse.detail == null)
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
                    throw new InvalidJobArgumentsException(deseriaizedResponse.detail[0]);
                }
            }

        }

        public Dictionary<string, string> ToParameterDictionary()
        {
            return new Dictionary<string, string> { };
        }
    }


}
