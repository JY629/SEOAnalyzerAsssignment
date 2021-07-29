using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAssignment.Interface
{
    public class ConfigHelper : IConfigHelper
    {
        public string GetValue(string paramName)
        {
            return ConfigurationManager.AppSettings[paramName];
        }

        public int GetValueId(string paramName)
        {
            return int.Parse(GetValue(paramName));
        }
    }
}