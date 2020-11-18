using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelBlog.Common
{
    public class TrackAccess : ActionFilterAttribute, IExceptionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //base.OnActionExecuted(filterContext);

            string message = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + " "
                + filterContext.ActionDescriptor.ActionName + " "
                + DateTime.Now.ToString() + "\n";
            LogAccess(message);

        }
        public void OnException(ExceptionContext filterContext)
        {
            //throw new NotImplementedException();

            string message = filterContext.RouteData.Values["controller"].ToString() + " "
                + filterContext.RouteData.Values["action"].ToString() + " "
                + filterContext.Exception.Message + " "
                + DateTime.Now.ToString() + "\n";
            LogAccess(message);
        }

        private void LogAccess(string data)
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Logs/Access.txt"), data);
        }
    }
}