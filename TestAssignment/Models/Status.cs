using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAssignment.Models
{
    public enum Status
    {
        NotSpecified = 0, //default value
        NotResolved = 1,
        Canceled = 2,
        Failed = 3,
        Success = 4,
    }
}