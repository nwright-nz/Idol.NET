using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDOLOnDemand.APIs;
using IDOLOnDemand.Helpers;
using RestSharp;

namespace IDOLOnDemandTestHarnessConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            //SpeechRecoginition.RequestParams request = new SpeechRecoginition.RequestParams();

            //request.URL = "https://www.idolondemand.com/sample-content/videos/hpnext.mp4";
            //request.Language = "en-US";
            //request.Interval = -1;

            SentimentAnalysis.RequestParams request = new SentimentAnalysis.RequestParams();
            request.Text = "This is a test to see if a sentiment is returned from this message. I hope so because this is a good message";
            request.Language = "eng";





            IdolConnect ic = new IdolConnect();
            ic.ApiKey = "8d8f4e0b-5a1d-41cd-8b33-2686ae9abc83";
            ic.Sync = "async";
            //var function = EnumUtils.stringValueOf(ApiType.SPEECHRECOGNITION);
            var function = EnumUtils.stringValueOf(ApiType.SENTIMENTANALYSIS);

            var response = ic.Connect(function, ic, request);

            SpeechRecoginition.RootObject sr = SimpleJson.DeserializeObject<SpeechRecoginition.RootObject>(response);


            
            
        }
    }
}
