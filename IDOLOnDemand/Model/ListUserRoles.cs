using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDOLOnDemand.Exceptions;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Response;
using Newtonsoft.Json;


namespace IDOLOnDemand.Model
{
    public class ListUserRoles : IIdolRequest
    {

        private readonly string SyncEndpoint = "/sync/listuserroles/v1";
        private readonly string AsyncEndpoint = "/async/listuserroles/v1";


        private string _store;
        private string _users;
        private string _roles;




        public ListUserRolesResponse.Value Execute(IdolConnect idolConnectionString, string UserStore, string Users = "", string Roles = "")
        {
            _store = UserStore;
            _users = Users;
            _roles = Roles;


            var apiResults = idolConnectionString.Connect(this.ToParameterDictionary(), SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<ListUserRolesResponse.Value>(apiResults);

            if (deseriaizedResponse.error == 0)
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
               {"store",_store},
               {"users",_users},
               {"roles",_roles}

           };
        }
    }


}
