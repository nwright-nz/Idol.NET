using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDOLOnDemand.Exceptions;
using IDOLOnDemand.Helpers;
using Newtonsoft.Json;
using IDOLOnDemand.Response;
using System.Runtime.Serialization;



namespace IDOLOnDemand.Model
{
    public class BarcodeRecognition
    {

        private readonly string SyncEndpoint = "/sync/recognizebarcodes/v1";
        private readonly string AsyncEndpoint = "/async/recognizebarcodes/v1";

        #region Enums
        [DataContract]
        public enum BarcodeType
        {
            //NOTE: because the API uses parameters with special characters (most notably - ) I cant use the normal enum method
            //for these values. Probably not really a big deal as all or all1d,all2d,qr are the most common ones and should be 
            //sufficient for this library.

            [EnumMember(Value="All")]
            All,
            [EnumMember(Value = "all1d")]
            all1d,
            [EnumMember(Value="All2D")]
            All2D,
            [EnumMember(Value = "codabar")]
            codabar,
            //[EnumMember(Value = "code-128")]
            //code128,
            //[EnumMember(Value = "code-39")]
            //code39,
            //[EnumMember(Value = "code-93")]
            //code93,
            //[EnumMember(Value = "datalogic 2/5")]
            //datalogic25,
            //[EnumMember(Value = "data matrix")]
            //datamatrix,
            //[EnumMember(Value = "ean-128")]
            //ean128,
            //[EnumMember(Value = "ean-13")]
            //ean13,
            //[EnumMember(Value = "ean-2")]
            //ean2,
            //[EnumMember(Value = "ean-5")]
            //ean5,
            //[EnumMember(Value = "ean-8")]
            //ean8,
            //[EnumMember(Value = "iata 2/5")]
            //iata25,
            //[EnumMember(Value = "industrial 2/5")]
            //industrial25,
            //[EnumMember(Value = "matrix 2/5")]
            //matrix25,
            //[EnumMember(Value = "patch code")]
            //patchcode,
            //[EnumMember(Value = "pdf417")]
            //pdf417,
            [EnumMember(Value = "qr")]
            qr,
            [EnumMember(Value = "ucc")]
            ucc
            //[EnumMember(Value = "upc-a")]
            //upca,
            //[EnumMember(Value = "upc-b")]
            //upcb
        }

        public enum Orientation
        {
            [EnumMember(Value="upright")]
            Upright,
            [EnumMember(Value="any")]
            Any
        }

        #endregion Enums


        private Orientation _barcode_orientation;

        public Orientation Barcode_Orientation
        {
            get { return _barcode_orientation; }
            set { _barcode_orientation = value; }
        }

        private BarcodeType _barcode_type;

        public BarcodeType Barcode_Type
        {
            get { return _barcode_type; }
            set { _barcode_type = value; }
        }


        public string Url { get; set; }
        public string File { get; set; }
        public string Reference { get; set; }


        public BarcodeRecognitionResponse.Value Execute(IdolConnect ic)
        {
            var apiResults = ic.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<BarcodeRecognitionResponse.Value>(apiResults);

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
