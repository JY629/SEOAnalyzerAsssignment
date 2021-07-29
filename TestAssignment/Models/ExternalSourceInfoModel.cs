using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAssignment.Models
{
    public class ExternalSourceInfoModel
    {
        public HtmlDocument Document { get; set; }

        public Status Status { get; set; }

        public string StatusMsg { get; set; }
    }
}