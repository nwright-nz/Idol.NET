using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IDOLOnDemand.Helpers
{
    public static class Tools
    {
        public static bool IsList(object o)
        {
            return o is IList &&
            o.GetType().IsGenericType &&
            o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
            
        }
    }
}
