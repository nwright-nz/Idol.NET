using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Response
{
    public class BarcodeRecognitionResponse
    {
        public class AdditionalInformation
        {
            public string country { get; set; }
        }

        public class Barcode
        {
            public string text { get; set; }
            public string barcode_type { get; set; }
            public int left { get; set; }
            public int top { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public AdditionalInformation additional_information { get; set; }
        }

        public class Value
        {
            public List<Barcode> barcode { get; set; }
            public string message { get; set; }

            public int error { get; set; }
            public string reason { get; set; }
            public List<string> detail { get; set; }
        }

    }
}
