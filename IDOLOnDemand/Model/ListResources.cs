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
    public class ListResources
    {

        public string SyncEndpoint = "/sync/listresources/v1";
        public string AsyncEndpoint = "/async/listresources/v1";

        public enum FlavorTypes
        {
            standard,
            explorer,
            categorization,
            custom_fields,
            querymanipulation,
            web_cloud,
            filesystem_onsite
        }

        public enum Types
        {
            content,
            connector
        }


        private Types _type;

        public Types Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private FlavorTypes _flavor;

        public FlavorTypes Flavor
        {
            get { return _flavor; }
            set { _flavor = value; }
        }




        public ListResourcesResponse.Value Execute(IdolConnect ic)
        {
            var apiResults = ic.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<ListResourcesResponse.Value>(apiResults);

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
    }


}
