using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignment.Helpers.Interface
{
    public interface IHtmlDocumentHelper
    {
        // HtmlDocument from HtmlAgilityPack
        List<string> GetExternalLinks(string url, HtmlDocument document);
        bool IsValid(HtmlDocument document);
        void SanitizeContent(HtmlDocument document);
    }
}
