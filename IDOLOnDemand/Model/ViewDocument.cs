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
    public class ViewDocument
    {

        public string SyncEndpoint = "/sync/viewdocument/v1";
        public string AsyncEndpoint = "/async/viewdocument/v1";

        public string Url { get; set; }
        public string File { get; set; }
        public string Reference { get; set; }
        public bool Raw_Html { get; set; }
        public string Highlight_Expression { get; set; }
        public string Start_Tag { get; set; }
        public string End_Tag { get; set; }




        public string Execute(IdolConnect ic)
        {
            //Response is slightly different here as the result is just html string, not a json response.
            //left error checking in just in case.

            var apiResults = ic.Connect(this, SyncEndpoint);
            ViewDocumentResponse.Value deseriaizedResponse = new ViewDocumentResponse.Value();

            try
            {
                deseriaizedResponse = JsonConvert.DeserializeObject<ViewDocumentResponse.Value>(apiResults);
            }

            catch
            {
                return apiResults;
            }



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
