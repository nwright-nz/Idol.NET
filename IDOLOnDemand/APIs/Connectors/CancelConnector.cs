using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.APIs.Connectors
{
    public class CancelConnector
    {
        public class Connector
        {
            public string type { get; set; }
        }

        public class StoppedSchedule
        {
            public string type { get; set; }
        }

        public class Properties
        {
            public Connector connector { get; set; }
            public StoppedSchedule stopped_schedule { get; set; }
        }

        public class RootObject
        {
            public string type { get; set; }
            public Properties properties { get; set; }
            public List<string> required { get; set; }
        }
    }
}
