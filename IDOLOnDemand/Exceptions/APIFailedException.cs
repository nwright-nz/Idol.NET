using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Exceptions
{
    public class APIFailedException: Exception
    {
         public APIFailedException(string message)
        : base(message)
    {}

    
    }


}
