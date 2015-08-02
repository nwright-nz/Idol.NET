using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace IDOLOnDemand.Authenticator
{
    public interface IIdolAuthenticator
    {
        void Sign(RestRequest request);
    }

    public class ApiKeyAuthenticator : IIdolAuthenticator
    {
        private readonly string _apiKey;

        public ApiKeyAuthenticator(string apiKey)
        {
            _apiKey = apiKey;
        }


        public void Sign(RestRequest request)
        {
            request.AddParameter("apikey", _apiKey);

        }

       
    }


}
