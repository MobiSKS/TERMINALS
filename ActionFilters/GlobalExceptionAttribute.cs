using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Web.Http.Tracing;
using HPCL_DP_Terminal.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
 
using HPCL_DP_Terminal.ErrorHelper;
using static HPCL_DP_Terminal.MQSupportClass.StatusMessage;
using HPCL_DP_Terminal.MQSupportClass;
using System.Net;
using System.Data.SqlClient;

namespace HPCL_DP_Terminal.ActionFilters
{

    /// <summary>  
    /// Action filter to handle for Global application errors.  
    /// </summary>  
    public class GlobalExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());
            var trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();
            trace.Error(context.Request, "Controller : " + context.ActionContext.ControllerContext.ControllerDescriptor.ControllerType.FullName + Environment.NewLine + "Action : " + context.ActionContext.ActionDescriptor.ActionName, context.Exception);

            var exceptionType = context.Exception.GetType();
            HttpResponseMessage httpResponseMessage = null;

            if (exceptionType == typeof(ValidationException))
            {
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(context.Exception.Message), ReasonPhrase = "ValidationException" };
            }
            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                httpResponseMessage = CreateHttpResponseMessage(context.Request, HttpStatusCode.Unauthorized, (int)StatusInformation.Exception_Code, "UnAuthorized", "UnAuthorized Access", context.ActionContext.ActionDescriptor.ActionName, "[]");
            }
            else if (exceptionType == typeof(ApiException))
            {
                if (context.Exception is ApiException webapiException)
                    httpResponseMessage = CreateHttpResponseMessage(context.Request, webapiException.HttpStatus, (int)StatusInformation.Exception_Code, webapiException.ErrorDescription, webapiException.ReasonPhrase, context.ActionContext.ActionDescriptor.ActionName, "[]");
            }
            else if (exceptionType == typeof(ApiBusinessException))
            {
                if (context.Exception is ApiBusinessException businessException)
                    httpResponseMessage = CreateHttpResponseMessage(context.Request, businessException.HttpStatus, (int)StatusInformation.Exception_Code, businessException.ErrorDescription, businessException.ReasonPhrase, context.ActionContext.ActionDescriptor.ActionName, "[]");
            }
            else if (exceptionType == typeof(ApiDataException))
            {
                if (context.Exception is ApiDataException dataException)
                    httpResponseMessage = CreateHttpResponseMessage(context.Request, dataException.HttpStatus, (int)StatusInformation.Exception_Code, dataException.ErrorDescription, dataException.ReasonPhrase, context.ActionContext.ActionDescriptor.ActionName, "[]");
            }

            else if (exceptionType == typeof(NullReferenceException))
            {
                if (context.Exception is NullReferenceException)
                {
                    httpResponseMessage = CreateHttpResponseMessage(context.Request, HttpStatusCode.NotAcceptable, (int)StatusInformation.Request_JSON_Body_Is_Null, "Request body is null", "Request body is null", context.ActionContext.ActionDescriptor.ActionName, "[]");
                }
            }
            else if (exceptionType == typeof(SqlException))
            {
                if (context.Exception is SqlException)
                {
                    httpResponseMessage = CreateHttpResponseMessage(context.Request, HttpStatusCode.NotAcceptable, (int)StatusInformation.Exception_Code, "Something went wrong...", "Error in DB", context.ActionContext.ActionDescriptor.ActionName, "[]");
                }
            }
            else
            {
                httpResponseMessage = CreateHttpResponseMessage(context.Request, HttpStatusCode.InternalServerError, (int)StatusInformation.Exception_Code, context.Exception.Message.ToString(), "UnAuthorized Access", context.ActionContext.ActionDescriptor.ActionName, "[]");
            }

            context.Response = httpResponseMessage;
        }

        public HttpResponseMessage CreateHttpResponseMessage(HttpRequestMessage request, HttpStatusCode statusCode, int intStatusCode, string StatusMessage, string ReasonPhrase, string Method_name, object Data, bool Success = false)
        {
            //CRUD.InsertAPIEntryLogFile(Method_name, "", StatusMessage, "", "", "");
            return request.CreateResponse(statusCode, new ServiceStatus() { Status_Code = intStatusCode, Message = StatusMessage, ReasonPhrase = ReasonPhrase, Success = Success, Method_Name = Method_name, Data = Data });
        }

    }
}