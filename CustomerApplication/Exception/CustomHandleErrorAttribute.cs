using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerApplication.Exception
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {

        public override void OnException(ExceptionContext filterContext)
        {
            //Log Errors
            base.OnException(filterContext);
        }
    }
}