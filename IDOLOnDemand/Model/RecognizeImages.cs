using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using IDOLOnDemand.Exceptions;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Response;
using Newtonsoft.Json;


namespace IDOLOnDemand.Model
{
    public class RecognizeImages
    {

        public string SyncEndpoint = "/sync/recognizeimages/v1";
        public string AsyncEndpoint = "/async/recognizeimages/v1";



        public enum Image
        {
            Simple,
            Complex_2d,
            Complex_3d
            
        }

        private Image _image_type;

        public Image ImageType
        {
            get { return _image_type; }
            set { _image_type = value; }
        }
        
        public string Url { get; set; }
        public string Indexes { get; set; }
        public string File { get; set; }
        public string Reference { get; set; }
        private List<string> _match_image;

        public List<string> Match_Image
        {
            get { return _match_image; }
            set { _match_image = value; }
        }
        




        public RecognizeImagesResponse.Value Response()
        {
            var apiResults = IdolConnect.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<RecognizeImagesResponse.Value>(apiResults);

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
