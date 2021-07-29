using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAssignment.Models
{
    public class InputText
    {
        public string Text { get; set; }

        public string ExternlLink { get; set; }

        public bool CountWordsInMeta { get; set; }

        public bool IncludeExternalLinks { get; set; }
    }
}