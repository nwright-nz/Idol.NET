using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDOLOnDemand.Response;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Exceptions;

namespace IDOLOnDemand.Model
{
    public class SentimentAnalysis
    {
        #region Enums
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

        #endregion Enums

        private LanguageSelection _language;

        private readonly string SyncEndpoint = "/sync/analyzesentiment/v1";
        private readonly string AsyncEndpoint = "/async/analyzesentiment/v1";

        public string Url { get; set; }
        public string Text { get; set; }
        public string File { get; set; }
        public string Reference { get; set; }

        public LanguageSelection Language
        {
            get { return _language; }
            set { _language = value; }
        }






        public SentimentAnalysisResponse.Value Execute(IdolConnect ic)
        {
            var apiResults = ic.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<SentimentAnalysisResponse.Value>(apiResults);
        
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
