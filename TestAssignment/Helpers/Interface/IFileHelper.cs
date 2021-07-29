using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAssignment.Interface
{
    public interface IFileHelper
    {
        HashSet<string> GetUniqueResultsFromJson(string path);
        List<string> LoadData(string path);
    }
}