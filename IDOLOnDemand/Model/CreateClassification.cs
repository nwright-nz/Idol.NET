using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDOLOnDemand.Response;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Exceptions;
using Newtonsoft.Json;


namespace IDOLOnDemand.Model
{
    public class CreateClassification
    {

        private readonly string SyncEndpoint = "/sync/createclassificationobjects/v1";
        private readonly string AsyncEndpoint = "/async/createclassificationobjects/v1";

        public string Name { get; set; }
        public string Description { get; set; }
        public string Additional { get; set; }
        

    public enum ClassificationType
    {
        collection_sequence,
        collection,
        condition,
        field_source,
        lexicon,
        lexicon_expression
    }

    private ClassificationType _type;

    public ClassificationType Type
    {
        get { return _type; }
        set { _type = value; }
    }
    



        public CreateClassificationResponse.Value Execute(IdolConnect ic)
        {
            var apiResults = ic.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<CreateClassificationResponse.Value>(apiResults);

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
