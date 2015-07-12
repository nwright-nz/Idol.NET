using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IDOLOnDemand.Response;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Exceptions;

namespace IDOLOnDemand.Model
{
    public class OCRDocument
    {

        public string SyncEndpoint = "/sync/ocrdocument/v1";
        public string AsyncEndpoint = "/async/ocrdocument/v1";



        public enum ImageMode
        {
            document_photo,
            document_scan,
            scene_photo,
            subtitle
        }


        private ImageMode _mode;

        public ImageMode Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public string Url { get; set; }
        
        public string File { get; set; }
        public string Reference { get; set; }




        public OCRDocumentResponse.Value Response()
        {
            var apiResults = IdolConnect.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<OCRDocumentResponse.Value>(apiResults);

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
