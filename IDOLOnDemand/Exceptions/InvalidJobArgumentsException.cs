using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Exceptions
{
    class InvalidJobArgumentsException : Exception
    {
         public InvalidJobArgumentsException(string message)
        : base(message)
    {}
    }
}
