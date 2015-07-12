using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDOLOnDemand.Response
{
    public class ExtractTextResponse
    {
        public class Value
        {
             public List<Document> document { get; set; }
            public List<string> md5sum { get; set; }
            public string message { get; set; }
            public int error { get; set; }
            public string reason { get; set; }
            public List<string> detail { get; set; }
        }

        public class Document
{
    public string reference { get; set; }
    public string doc_iod_reference { get; set; }
    public List<string> cleartype { get; set; }
    public List<string> contenttype { get; set; }
    public List<string> description { get; set; }
    public List<string> document_attributes { get; set; }
    public List<int> keyview_class { get; set; }
    public List<int> original_size { get; set; }
    public List<int> keyview_type { get; set; }
    public List<string> keywords { get; set; }
    public List<string> msapplicationtile_color { get; set; }
    public List<string> msapplicationtile_image { get; set; }
    public List<string> robots { get; set; }
    public List<string> tempextractionfilename { get; set; }
    public string title { get; set; }
    public List<string> twitter_widgets_csp { get; set; }
    public List<string> viewport { get; set; }
    public List<string> xml_parsing_section { get; set; }
    public List<string> name { get; set; }
    public string content { get; set; }


    }
}
}

