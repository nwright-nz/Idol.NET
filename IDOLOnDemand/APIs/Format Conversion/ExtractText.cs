using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDOLOnDemand.APIs
{
    public class ExtractText
    {
        public class RequestParams
        {
            private string _file;
            private string _url;
            private string _reference;
            private bool _extract_text;
            private bool _extract_metadata;
            private bool _extract_xmlattributes;
            private string _additional_metadata; //not implemented
            private string _reference_prefix; //not implemented
            private string _password; //not implemented

            public string Password
            {
                get { return _password; }
                set { _password = value; }
            }


            public string Reference_Prefix
            {
                get { return _reference_prefix; }
                set { _reference_prefix = value; }
            }


            public string Additional_metadata
            {
                get { return _additional_metadata; }
                set { _additional_metadata = value; }
            }


            public bool Extract_XmlAttributes
            {
                get { return _extract_xmlattributes; }
                set { _extract_xmlattributes = value; }
            }


            public bool Extract_Metadata
            {
                get { return _extract_metadata; }
                set { _extract_metadata = value; }
            }


            public bool Extract_Text
            {
                get { return _extract_text; }
                set { _extract_text = value; }
            }


            public string Reference
            {
                get { return _reference; }
                set { _reference = value; }
            }


            public string URL
            {
                get { return _url; }
                set { _url = value; }
            }


            public string File
            {
                get { return _file; }
                set { _file = value; }
            }

        }
    }

    public class ExtractTextOutput
    {
        public class Document
        {
            public string reference { get; set; }
            public string doc_iod_reference { get; set; }
            public List<string> app_name { get; set; }
            public List<string> author { get; set; }
            public List<string> char_count { get; set; }
            public List<string> code_page { get; set; }
            public List<string> company { get; set; }

            public List<string> contenttype { get; set; }
            public List<string> created_date { get; set; }
            public List<string> document_attributes { get; set; }
            public List<int> keyview_class { get; set; }
            public List<int> original_size { get; set; }
            public List<int> keyview_type { get; set; }
            public List<string> edit_time { get; set; }
            public List<string> heading_pairs { get; set; }
            public List<string> last_author { get; set; }
            public List<string> last_printed { get; set; }
            public List<int> modified_date { get; set; }
            public List<string> line_count { get; set; }
            public List<string> links_dirty { get; set; }
            public List<string> page_count { get; set; }
            public List<string> par_count { get; set; }
            public List<string> rev_number { get; set; }
            public List<string> scale_crop { get; set; }
            public List<string> security { get; set; }
            public List<string> tempextractionfilename { get; set; }
            public List<string> template { get; set; }
            public string title { get; set; }
            public List<string> titles_of_parts { get; set; }
            public List<string> word_count { get; set; }
            public List<string> xml_parsing_section { get; set; }
            public string content { get; set; }
        }

        public class RootObject
        {
            public List<Document> document { get; set; }
            public List<string> md5sum { get; set; }
        }
    }

    public class ExtractTextOutputAsync
    {
        public class Document
        {
            public string reference { get; set; }
            public string doc_iod_reference { get; set; }
            public List<string> app_name { get; set; }
            public List<string> author { get; set; }
            public List<string> char_count { get; set; }
            public List<string> code_page { get; set; }
            public List<string> company { get; set; }
            public List<string> contenttype { get; set; }
            public List<string> created_date { get; set; }
            public List<string> document_attributes { get; set; }
            public List<int> keyview_class { get; set; }
            public List<int> original_size { get; set; }
            public List<int> keyview_type { get; set; }
            public List<string> edit_time { get; set; }
            public List<string> heading_pairs { get; set; }
            public List<string> last_author { get; set; }
            public List<string> last_printed { get; set; }
            public List<int> modified_date { get; set; }
            public List<string> line_count { get; set; }
            public List<string> links_dirty { get; set; }
            public List<string> page_count { get; set; }
            public List<string> par_count { get; set; }
            public List<string> rev_number { get; set; }
            public List<string> scale_crop { get; set; }
            public List<string> security { get; set; }
            public List<string> tempextractionfilename { get; set; }
            public List<string> template { get; set; }
            public string title { get; set; }
            public List<string> titles_of_parts { get; set; }
            public List<string> word_count { get; set; }
            public List<string> xml_parsing_section { get; set; }
            public string content { get; set; }
        }

        public class Result
        {
            public List<Document> document { get; set; }
            public List<string> md5sum { get; set; }
        }

        public class Action
        {
            public Result result { get; set; }
            public string status { get; set; }
            public string action { get; set; }
            public string version { get; set; }
        }

        public class RootObject
        {
            public List<Action> actions { get; set; }
            public string jobID { get; set; }
            public string status { get; set; }
        }
    }
}
