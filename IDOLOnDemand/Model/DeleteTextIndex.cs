﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDOLOnDemand.Exceptions;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Response;
using Newtonsoft.Json;


namespace IDOLOnDemand.Model
{
    public class DeleteTextIndex
    {

        private readonly string SyncEndpoint = "/sync/deletetextindex/v1";
        private readonly string AsyncEndpoint = "/async/deletetextindex/v1";

        public string Index { get; set; }
        public string Confirm { get; set; }
        



        public DeleteTextIndexResponse.Value Execute(IdolConnect ic)
        {
            var apiResults = ic.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<DeleteTextIndexResponse.Value>(apiResults);

            if (deseriaizedResponse.message == null & deseriaizedResponse.error == 0)
            {
                return deseriaizedResponse;
            }
            else
            {
                if (deseriaizedResponse.message != null)
                {
                    throw new APIFailedException(deseriaizedResponse.message);
                }
                else if (deseriaizedResponse.error == 4005)
                {
                    throw new InvalidJobArgumentsException(deseriaizedResponse.detail[0]);
                }

                else
                {
                    throw new InvalidJobArgumentsException(deseriaizedResponse.actions[0].errors[0].reason);
                }
            }

        }
    }


}
