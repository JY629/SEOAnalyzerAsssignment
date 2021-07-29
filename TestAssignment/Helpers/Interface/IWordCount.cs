using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestAssignment.Models;

namespace TestAssignment.Interface
{
    public interface IWordCount
    {
        IList<string> GetExternalLinks(string url, HtmlDocument document);
        IDictionary<string, int> GetMetaKeywordsFrequencies(HtmlDocument document, IDictionary<string, int> wordsCountDictionary);
        Task<ExternalSourceInfoModel> GetRemoteData(string url);
        IDictionary<string, int> GetWordsFrequenciesFromExternalSource(HtmlDocument document);
        IDictionary<string, int> GetWordsFrequenciesFromText(string text);
    }
}