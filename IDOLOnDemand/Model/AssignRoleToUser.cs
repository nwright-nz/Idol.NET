using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDOLOnDemand.Response;
using IDOLOnDemand.Exceptions;
using IDOLOnDemand.Helpers;
using Newtonsoft.Json;



namespace IDOLOnDemand.Model
{
    public class AssignRoleToUser : IIdolRequest
    {

        const string SyncEndpoint = "/sync/assignrole/v1";
        const string AsyncEndpoint = "/async/assignrole/v1";

        private string _store;
        private string _user;
        private string _role;

        public AssignRoleToUserResponse.Value Execute(IdolConnect idolConnectionString, string UserStore, string User, string RoleToAdd)
        {
            _store=UserStore;
            _user = User;
            _role = RoleToAdd;

            var apiResults = idolConnectionString.Connect(this.ToParameterDictionary(), SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<AssignRoleToUserResponse.Value>(apiResults);

            if (deseriaizedResponse.message == "role now assigned")
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
                        string errors = "";
                        foreach (var x in deseriaizedResponse.actions[0].errors)
                        {
                            errors = errors + " - " + x.reason;
                        }
                        throw new InvalidJobArgumentsException(errors);
                    }


                }

            }
        }



        public Dictionary<string, string> ToParameterDictionary()
        {
            return new Dictionary<string, string>
            {
                {"store", _store},
                {"role",_role},
                {"user",_user}

            };
           
        }
    }
}

