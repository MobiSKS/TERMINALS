using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Web.Http.Tracing;
using System.Web.Http;
using HPCL_DP_Terminal.Helpers;
using System.Net;
using static HPCL_DP_Terminal.MQSupportClass.StatusMessage;
using System.Threading.Tasks;

namespace HPCL_DP_Terminal.ActionFilters
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());
            var trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();
            NLog.MappedDiagnosticsLogicalContext.Set("methodName", filterContext.ActionDescriptor.ActionName);
            trace.Info(filterContext.Request, "Controller : " + filterContext.ControllerContext.ControllerDescriptor.ControllerType.FullName + Environment.NewLine + "Action : " + filterContext.ActionDescriptor.ActionName, "JSON", filterContext.ActionArguments);

            if (filterContext.ModelState.IsValid == false)
            {
                filterContext.Response = MessageHelper.Message(filterContext.Request, HttpStatusCode.OK, false, (int)StatusInformation.Manadatory_Feild_Required, null, filterContext.ModelState);
            }
        }

        //public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        //{
        //    GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());
        //    var trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();
        //    NLog.MappedDiagnosticsLogicalContext.Set("methodName", filterContext.ActionContext.ActionDescriptor.ActionName);
        //    trace.Info(filterContext.Request, "Controller : "
        //        + filterContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerType.FullName
        //        + Environment.NewLine + "Action : "
        //        + filterContext.ActionContext.ActionDescriptor.ActionName, "JSON", filterContext.ActionContext.ActionArguments);
        //}
    }
}