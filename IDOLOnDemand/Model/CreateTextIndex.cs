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
    public class CreateTextIndex
    {

        private readonly string SyncEndpoint = "/sync/createtextindex/v1";
        private readonly string AsyncEndpoint = "/async/createtextindex/v1";

        public string Index { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        private FlavorType _flavor;

        public FlavorType Flavor
        {
            get { return _flavor; }
            set { _flavor = value; }
        }




        public enum FlavorType
        {
            Querymanipulation,
            Custom_Fields,
            Explorer,
            Standard,
            Categorization
        }




        public CreateTextIndexResponse.Value Execute(IdolConnect ic)
        {
            var apiResults = ic.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<CreateTextIndexResponse.Value>(apiResults);

            if (deseriaizedResponse.error == 0)
            {
                return deseriaizedResponse;
            }
            else
            {

                throw new InvalidJobArgumentsException(deseriaizedResponse.actions[0].errors[0].reason);
            }


        }
    }


}
