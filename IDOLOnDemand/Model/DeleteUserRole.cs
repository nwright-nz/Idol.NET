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
    public class DeleteUserRole : IIdolRequest
    {

        private readonly string SyncEndpoint = "/sync/deleterole/v1";
        private readonly string AsyncEndpoint = "/async/deleterole/v1";


        private string _store;
        private string _role;

        public DeleteUserRoleResponse.Value Execute(IdolConnect idolConnectionString, string UserStore, string UserRole)
        {
            _store = UserStore;
            _role = UserRole;

            var apiResults = idolConnectionString.Connect(this.ToParameterDictionary(), SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<DeleteUserRoleResponse.Value>(apiResults);

            if (deseriaizedResponse.status != "failed" & deseriaizedResponse.message != "role was deleted")
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
               {"store",_store},
               {"role",_role}

           };
        }
    }


}
