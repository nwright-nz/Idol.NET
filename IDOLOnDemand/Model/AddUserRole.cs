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
    public class AddUserRole : IIdolRequest
    {

        private readonly string SyncEndpoint = "/sync/addrole/v1";
        private readonly string AsyncEndpoint = "/async/addrole/v1";

        private string _store;
        private string _role;
      
        public AddUserRoleResponse.Value Execute(IdolConnect ic, string UserStore, string UserRole)
        {
            _store = UserStore;
            _role = UserRole;

            var apiResults = ic.Connect(this.ToParameterDictionary(), SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<AddUserRoleResponse.Value>(apiResults);

            if (deseriaizedResponse.message == "role was added")
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
               { "Store", _store},
               { "Role" , _role}

           };
        }
    }


}
