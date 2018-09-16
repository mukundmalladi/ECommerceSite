using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using log4net.Core;

namespace EcommerceMvc
{
    public class ExceptionHandle : HandleErrorAttribute
    {
        //private ILogger _logger;
        //public Exception(ILogger logger)
        //{
        //    _logger = logger;
        //}
        public override void OnException(ExceptionContext filterContext)
        {
            var message = filterContext.Exception.Message;
            var stackTrace = filterContext.Exception.StackTrace;
            var innerException = filterContext.Exception.InnerException != null ? filterContext.Exception.InnerException : null;
            
            File.WriteAllLines("Error.txt", new []{string.Format("message: {0}", message), string.Format("stracktrace: {0}", stackTrace), string.Format("innerException: {0}", innerException) });

        }
    }
}