using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.APIs
{
    public class SpeechRecoginition
    {

        
        public class RequestParams
        {
            private string _url;

            public string URL
            {
                get { return _url; }
                set { _url = value; }
            }


            private string _reference;

            public string Reference
            {
                get { return _reference; }
                set { _reference = value; }
            }

            private string _file;

            public string File
            {
                get { return _file; }
                set { _file = value; }
            }


            private int _interval;

            public int Interval
            {
                get { return _interval; }
                set { _interval = value; }
            }


            private string _language;

            public string Language
            {
                get { return _language; }
                set { _language = value; }
            }





        }





        public class Offset
        {
            public string type { get; set; }
        }

        public class Content
        {
            public string type { get; set; }
        }

        public class Properties
        {
            public Offset offset { get; set; }
            public Content content { get; set; }
        }

        public class Items
        {
            public string type { get; set; }
            public Properties properties { get; set; }
            public List<string> required { get; set; }
        }

        public class Document
        {
            public string type { get; set; }
            public Items items { get; set; }
        }

        public class ObjectProperties
        {
            public Document document { get; set; }
        }

        public class RootObject
        {
            public string type { get; set; }
            public ObjectProperties properties { get; set; }
            public List<string> required { get; set; }
        }
    }
}
