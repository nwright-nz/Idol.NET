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
    public class UnassignUserRole : IIdolRequest
    {

        private readonly string SyncEndpoint = "/sync/unassignrole/v1";
        private readonly string AsyncEndpoint = "/async/unassignrole/v1";


        private string _store;
        private string _user;
        private string _role;

        public UnassignUserRoleResponse.Value Execute(IdolConnect idolConnectionString, string UserStore, string UserEmail, string RoleToUnassign)
        {
            _store = UserStore;
            _user = UserEmail;
            _role = RoleToUnassign;

            var apiResults = idolConnectionString.Connect(this.ToParameterDictionary(), SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<UnassignUserRoleResponse.Value>(apiResults);

            if (deseriaizedResponse.message != null)
            {
                return deseriaizedResponse;
            }
            else
            {
                if (deseriaizedResponse.error == 4005)
                {
                    throw new InvalidJobArgumentsException(deseriaizedResponse.detail[0]);
                   
                }
                else
                {
                    throw new APIFailedException(deseriaizedResponse.message);
                }
            }

        }

        public Dictionary<string, string> ToParameterDictionary()
        {
            return new Dictionary<string, string>
            {
                {"store",_store},
                {"role",_role},
                {"user",_user}
            };
        }
    }


}
