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
    public class SpeechRecognition
    {
        public enum LanguageSelection
        {
            [EnumMember(Value = "english")]
            Eng,
            [EnumMember(Value = "fre")]
            Fre,
            [EnumMember(Value = "spa")]
            Spa,
            [EnumMember(Value = "ger")]
            Ger,
            [EnumMember(Value = "ita")]
            Ita,
            [EnumMember(Value = "chi")]
            Chi,
            [EnumMember(Value = "por")]
            Por,
            [EnumMember(Value = "dut")]
            Dut,
            [EnumMember(Value = "rus")]
            Rus,
            [EnumMember(Value = "cze")]
            Cze,
            [EnumMember(Value = "tur")]
            Tur

        }

        private LanguageSelection _language;

        public LanguageSelection Language
        {
            get { return _language; }
            set { _language = value; }
        }
        
        public int Interval { get; set; }
        public string File { get; set; }
        public string Reference { get; set; }
        public string Url { get; set; }

        private readonly string SyncEndpoint = "/sync/recognizespeech/v1";
        private readonly string AsyncEndpoint = "/async/recognizespeech/v1";

        // public SpeechRecognitionResponse.Value Response()
        //{
        //    var apiResults = ic.Connect(this, SyncEndpoint);
        //    var deseriaizedResponse = JsonConvert.DeserializeObject<SentimentAnalysisResponse.Value>(apiResults);
        
        //    if (deseriaizedResponse.message == null & deseriaizedResponse.detail == null)
        //    {
        //       // return deseriaizedResponse;
        //    }
        //    else
        //    {
        //        if (deseriaizedResponse.message != null)
        //        {
        //            throw new APIFailedException(deseriaizedResponse.message);
        //        }
        //        else
        //        {
        //            throw new InvalidJobArgumentsException(deseriaizedResponse.detail[0]);
        //        }
        //    }

        //}
    }
    
   
}
