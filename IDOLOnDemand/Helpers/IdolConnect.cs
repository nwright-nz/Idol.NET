using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Reflection;
using System.ComponentModel;


namespace IDOLOnDemand.Helpers
{

    public enum ApiType
    {
        [DescriptionAttribute("analyzesentiment")]
        SENTIMENTANALYSIS,
        [DescriptionAttribute("recognizespeech")]
        SPEECHRECOGNITION,
        [DescriptionAttribute("createtextindex")]
        CREATETEXTINDEX,
        [DescriptionAttribute("addtotextindex")]
        ADDTOTEXTINDEX,
        [DescriptionAttribute("indexstatus")]
        GETINDEXINFO,
        [DescriptionAttribute("deletetextindex")]
        DELETEINDEX,
        [DescriptionAttribute("deletefromtextindex")]
        DELETEFROMINDEX,
        [DescriptionAttribute("ocrdocument")]
        OCDDOCUMENT,
        [DescriptionAttribute("extracttext")]
        EXTRACTTEXT
    }

    public class IdolConnect
    {
        const string apiURL = "https://api.idolondemand.com/";
        private string _apiKey;
        private string _sync;



        public string Sync
        {
            get { return _sync; }
            set { _sync = value; }
        }


        public string ApiKey
        {
            get { return _apiKey; }
            set { _apiKey = value; }
        }




        public string Connect(string apiFunction, IdolConnect connectionDetails, object requestParams)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();


            string properties = "";
            foreach (var item in requestParams.GetType().GetProperties())
            {
                if (item.GetValue(requestParams, null) == null)
                {
                    //ignore param
                }
                else
                {
                    parameters.Add(item.Name, item.GetValue(requestParams, null).ToString());
                    // properties += item.Name + "=" + item.GetValue(requestParams, null) + "&";
                }
            }



            properties += "apikey=" + connectionDetails.ApiKey;



            if (Sync == "sync")
            {
                var client = new RestClient(apiURL);
                var request = new RestRequest("1/api/" + Sync + "/" + apiFunction + "/v1", Method.POST);

                foreach (var entry in parameters)
                {
                    request.AddParameter(entry.Key, entry.Value);
                }
                request.AddParameter("apikey", ApiKey);

                var response = client.Execute(request);
                var content = response.Content;
                return content;


            }


            else
            {
                //submit job and get job id
                var asyncClient = new RestClient(apiURL);
                var asyncRequest = new RestRequest("1/api/" + Sync + "/" + apiFunction + "/v1", Method.POST);

                foreach (var entry in parameters)
                {
                    asyncRequest.AddParameter(entry.Key, entry.Value);
                }

                asyncRequest.AddParameter("apikey", ApiKey);
                var asyncResponse = asyncClient.Execute(asyncRequest);
                var asyncContent = asyncResponse.Content;

                AsyncJob.Job asyncJob = SimpleJson.DeserializeObject<AsyncJob.Job>(asyncContent);

                //get job status
                string id = asyncJob.jobID;
                var results = new RestRequest("1/job/status/" + id, Method.GET);
                results.AddParameter("apikey", ApiKey);

                var resultsResponse = asyncClient.Execute(results);
                var resultsContent = resultsResponse.Content;

                AsyncJob.JobResults.Results jr = SimpleJson.DeserializeObject<AsyncJob.JobResults.Results>(resultsContent);
                string status = string.Empty;
                string res = string.Empty;

                while (jr.status == "queued" | jr.status == "in progress")
                {
                    resultsResponse = asyncClient.Execute(results);
                    resultsContent = resultsResponse.Content;
                  //  res = resultsContent;
                    jr = SimpleJson.DeserializeObject<AsyncJob.JobResults.Results>(resultsContent);


                }

                if (jr.status == "finished")
                {



                    return resultsContent;
;

                }

            }







            return null;
        }

    }
}
