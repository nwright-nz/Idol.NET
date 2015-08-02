using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Reflection;
using System.ComponentModel;
using System.Configuration;
using IDOLOnDemand.Authenticator;




namespace IDOLOnDemand.Helpers
{

    public class IdolConnect : IDOLOnDemand.Endpoints.QueryTextIndexEndpoint
    {
        private readonly Uri _baseIdolUri;
        private readonly IIdolAuthenticator _authenticator;


        public IdolConnect(Uri baseIdolUri, IIdolAuthenticator authenticator)
        {
            _baseIdolUri = baseIdolUri;
            _authenticator = authenticator;
        }
    

        public string Connect(object requestParams, string endpoint) //old version
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (var item in requestParams.GetType().GetProperties())
            {
                if (item.GetValue(requestParams, null) != null)
                {
                    parameters.Add(item.Name, item.GetValue(requestParams, null).ToString());
                }
            }
            return MakeHttpRequest(parameters, endpoint);

        }

        public string Connect(Dictionary<string, string> requestParams, string endpoint)
        {
            //foreach (var item in requestParams)
            //{
            //    if (item.Value == null)
            //    {
            //        item.Value = string.Empty();
            //    }
            //}
            return MakeHttpRequest(requestParams, endpoint);

        }

        public string Connect(Dictionary<string, string> requestParams, IInputSource inputSource, string endpoint)
        {
            requestParams.Add(inputSource.Key, inputSource.Value);

            //foreach (var item in requestParams)
            //{
            //    if (item.Value == null)
            //    {
            //        requestParams.Remove(item.Key);
            //    }
            //}
            return MakeHttpRequest(requestParams, endpoint);

        }




        private string MakeHttpRequest(Dictionary<string, string> requestParams, string endpoint)
        {

            var client = new RestClient(_baseIdolUri);
            var request = new RestRequest(endpoint, Method.POST);

            foreach (var entry in requestParams)
            {
                //check if parameter has multi values - | is the delimiter for these

                if (entry.Value != null)
                {
                    var splitArray = entry.Value.Split('|');
                    if (splitArray.Count() > 1)
                    {
                        foreach (var x in splitArray)
                        {
                            request.AddParameter(entry.Key, x);
                        }

                    }
                    else
                    {
                        request.AddParameter(entry.Key, entry.Value);
                    }
                }
            }
            _authenticator.Sign(request);

            var response = client.Execute(request);


            var content = response.Content;
            return content;
        }

    }
}
