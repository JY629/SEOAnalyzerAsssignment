using System.Threading.Tasks;
using System.Web.Mvc;
using TestAssignment.Helpers.Interface;
using TestAssignment.Interface;
using TestAssignment.Models;

namespace TestAssignment.Controllers
{
    public class AnalyzerController : Controller
    {
        private IWordCount wordService;
        private IJsonResponseFormatHelper responseFormatHelper;

        public ActionResult Index()
        {
            return View();
        }

        public AnalyzerController(IWordCount wordService, IJsonResponseFormatHelper responseFormatHelper)
        {
            this.wordService = wordService;
            this.responseFormatHelper = responseFormatHelper;
        }

        //Methods for analyzing words
        [HttpPost]
        public async Task<ActionResult> CountWords(InputText model)
        {
            var result = new AnalyzeResult();
            result.ResponseStatus = Status.NotSpecified;
            result.ResponseStatusMsg = string.Empty;

            //Option 1: Analyze Plain text (english)
            if (!string.IsNullOrEmpty(model.Text))
            {
                result.WordsFrequencies = wordService.GetWordsFrequenciesFromText(model.Text);
            }
            //Option 2: Analyze URL
            else if (!string.IsNullOrEmpty(model.ExternlLink))
            {
                result.ExternalSourceUrl = model.ExternlLink;
                var source = await wordService.GetRemoteData(model.ExternlLink);
                result.ResponseStatus = source.Status;
                result.ResponseStatusMsg = source.StatusMsg;
                if (result.ResponseStatus == Status.Success)
                {
                    result.WordsFrequencies = wordService.GetWordsFrequenciesFromExternalSource(source.Document);
                    //Option 1: Look up meta tag keywords
                    if (model.CountWordsInMeta)
                    {
                        result.MetaKeywordsFrequencies = wordService.GetMetaKeywordsFrequencies(source.Document, result.WordsFrequencies);
                    }

                    //Option 2: Get external link list
                    if (model.IncludeExternalLinks)
                    {
                        result.ExternalLinks = wordService.GetExternalLinks(model.ExternlLink, source.Document);
                    }
                }
            }


            var jsonResult = this.responseFormatHelper.GetJsonParsedModel(result);

            return this.Json(jsonResult);
        }
    }
}