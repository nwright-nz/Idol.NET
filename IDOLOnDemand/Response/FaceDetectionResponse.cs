using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Response
{
    public class FaceDetectionResponse
    {
        public class AdditionalInformation
        {
            public string age { get; set; }
        }

        public class Face
        {
            public int left { get; set; }
            public int top { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public AdditionalInformation additional_information { get; set; }
        }

        public class Value
        {
            public List<Face> face { get; set; }
            public string message { get; set; }

            public int error { get; set; }
            public string reason { get; set; }
            public List<string> detail { get; set; }
        }
    }
}
