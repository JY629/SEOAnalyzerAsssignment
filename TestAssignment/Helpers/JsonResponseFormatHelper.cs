using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAssignment.Helpers.Interface;
using TestAssignment.Models;

namespace TestAssignment.Helpers
{
    public class JsonResponseFormatHelper : IJsonResponseFormatHelper
    {
        public string GetJsonParsedModel(AnalyzeResult inputModel)
        {
            var formatModel = new FriendlyJsonFormatModel();
            formatModel.ExternalSourceUrl = inputModel.ExternalSourceUrl;
            formatModel.ResponseStatus = inputModel.ResponseStatus.ToString();
            formatModel.ResponseStatusMsg = inputModel.ResponseStatusMsg;
            if (inputModel.WordsFrequencies != null)
            {
                formatModel.WordsFrequencies = inputModel.WordsFrequencies.Select(c => new DictEntry { Key = c.Key, Value = c.Value }).ToList();
            }

            if (inputModel.MetaKeywordsFrequencies != null)
            {
                formatModel.MetaKeywordsFrequencies = inputModel.MetaKeywordsFrequencies.Select(c => new DictEntry { Key = c.Key, Value = c.Value }).ToList();
            }

            if (inputModel.ExternalLinks != null)
            {
                formatModel.ExternalLinks = inputModel.ExternalLinks.Select(c => new DictEntry { Key = c }).ToList();
            }

            var jsonResult = JsonConvert.SerializeObject(formatModel);

            return jsonResult;
        }
    }
}