using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAssignment.Interface
{
    public interface IConfigHelper
    {
        string GetValue(string paramName);
        int GetValueId(string paramName);
    }
}