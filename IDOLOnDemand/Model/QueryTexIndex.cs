using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDOLOnDemand.Helpers;
using IDOLOnDemand.Endpoints;
using IDOLOnDemand.Response;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.ComponentModel;
using IDOLOnDemand.Exceptions;

namespace IDOLOnDemand.Model
{
    public class QueryTexIndex
    {
       

        #region Enums
        /// <summary>
        /// The type of summary to create for result documents.
        /// </summary>
        public enum SummaryResults
        {
            /// <summary>
            /// Concept Summary: Contains sentences that are typical of the result content. These sentences can be from different parts of the result document
            /// </summary>
            [EnumMember(Value = "Concept")]
            Concept,
            /// <summary>
            /// Context Summary: 
            /// Contains sentences that are typical of the result content, biased by the terms in the query text.
            /// </summary>
            [EnumMember(Value = "Context")]
            Context,
            /// <summary>
            /// Quick Summary: The first few sentences of the document.
            /// </summary>
            [EnumMember(Value = "Quick")]
            Quick,
            /// <summary>
            /// No summary
            /// </summary>
            [EnumMember(Value = "Off")]
            Off
        }


        /// <summary>
        /// The types of fields and content to display in the results.
        /// </summary>
        public enum PrintType
        {
            /// <summary>
            /// All fields
            /// </summary>
            [EnumMember(Value = "All")]
            All,
            /// <summary>
            /// All fields and all sections.
            /// </summary>
            [EnumMember(Value = "All_Sections")]
            All_Sections,
            /// <summary>
            /// Date fields.
            /// </summary>
            [EnumMember(Value = "Date")]
            Date,
            /// <summary>
            /// Print fields listed in the print_fields parameter.
            /// </summary>
            [EnumMember(Value = "Fields")]
            Fields,
            /// <summary>
            /// Do not print content fields.
            /// </summary>
            [EnumMember(Value = "None")]
            None,
            /// <summary>
            /// Do not print results.
            /// </summary>
            [EnumMember(Value = "No_Results")]
            No_Results,
            /// <summary>
            /// Parametric fields.
            /// </summary>
            [EnumMember(Value = "Parametric")]
            Parametric,
            /// <summary>
            /// Reference fields.
            /// </summary>
            [EnumMember(Value = "Reference")]
            Reference

        }
        /// <summary>
        /// The highlighting option to use for the result text.
        /// </summary>
        public enum HighlightText
        {
            /// <summary>
            /// No Highlighting
            /// </summary>
            [EnumMember(Value = "Off")]
            Off,
            /// <summary>
            /// Terms that match the query text
            /// </summary>
            [EnumMember(Value = "Terms")]
            Terms,
            /// <summary>
            /// Sentences that contain query terms
            /// </summary>
            [EnumMember(Value = "Sentences")]
            Sentences
        }

        /// <summary>
        /// The criteria to use for the result display order. By default, results are displayed in order of relevance.
        /// </summary>
        public enum SortType
        {
            /// <summary>
            /// Relevance order (most relevant first).
            /// </summary>
            [EnumMember(Value = "Relevance")]
            Relevance,
            /// <summary>
            /// Relevance order (least relevant first).
            /// </summary>
            [EnumMember(Value = "Reverse_Relevance")]
            Reverse_Relevance,
            /// <summary>
            /// Date order (most recent first).
            /// </summary>
            [EnumMember(Value = "Date")]
            Date,
            /// <summary>
            /// Date order (oldest first).
            /// </summary>
            [EnumMember(Value = "Reverse_Date")]
            Reverse_Date,
            /// <summary>
            /// Order by the standard relevance adjustment field.
            /// </summary>
            [EnumMember(Value = "Autn_Rank")]
            Autn_Rank,
            /// <summary>
            /// No sorting.
            /// </summary>
            [EnumMember(Value = "Off")]
            Off
        }


        private PrintType _print;
        private SortType _sort;
        private SummaryResults _summary;
        private HighlightText _highlight;



        #endregion Enums

        #region properties

        public string SyncEndpoint = "/sync/querytextindex/v1";
        public string AsyncEndpoint = "/async/querytextindex/v1";

        
        ///<summary> The query text</summary>
        public string Text { get; set; }

        //<summary> A file containing the query text. Multi part POST only.</summary>
        public string File { get; set; }

        public string Reference { get; set; } //<summary> The query text</summary>
        public string Url { get; set; } //<summary> The query text</summary>
        public string Field_Text { get; set; } //<summary> The query text</summary>
        public int Start { get; set; }
        public int Max_Page_Results { get; set; }
        public int Absolute_Max_Results { get; set; }
        public string Indexes { get; set; }
        public string Query_Profile { get; set; }
        public string Print_Fields { get; set; }
        public string Min_Date { get; set; }
        public string Max_Date { get; set; }
        public string Min_Score { get; set; }
        public bool Total_Results { get; set; }
        public string Start_Tag { get; set; }


        public PrintType Print
        {
            get { return _print; }
            set { _print = value; }
        }

        public SortType Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        public HighlightText Highlight
        {
            get { return _highlight; }
            set { _highlight = value; }
        }

        public SummaryResults Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }

        #endregion

        public QueryTextIndexResponse.Value Execute(IdolConnect ic)
        {
            var apiResults = ic.Connect(this, SyncEndpoint);
            var deseriaizedResponse = JsonConvert.DeserializeObject<QueryTextIndexResponse.Value>(apiResults);

            if (deseriaizedResponse.message == null)
            {
                return deseriaizedResponse;
            }
            else
            {
                throw new APIFailedException(deseriaizedResponse.message);
            }
        }
    }
}
