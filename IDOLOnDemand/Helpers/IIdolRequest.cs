using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Helpers
{
    public interface IIdolRequest
    {
        Dictionary<string, string> ToParameterDictionary();

    }
}
