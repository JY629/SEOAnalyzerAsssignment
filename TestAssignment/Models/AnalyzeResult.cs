using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAssignment.Models
{
    public class AnalyzeResult 
    {
        public IDictionary<string, int> WordsFrequencies { get; set; }

        public IDictionary<string, int> MetaKeywordsFrequencies { get; set; }

        public string ExternalSourceUrl { get; set; }

        public Status ResponseStatus { get; set; }

        public string ResponseStatusMsg { get; set; }

        public IEnumerable<string> ExternalLinks { get; set; }
    }
}