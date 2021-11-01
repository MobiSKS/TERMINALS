using HPCL_DP_Terminal.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;

namespace HPCL_DP_Terminal.MQSupportClass
{

    public class Root
    {
        public String useragent;
        public String userip;
        public String userid;
    }

    public class CustomAuthenticationFilter : AuthorizeAttribute, IAuthenticationFilter
    {
        //public bool AllowMultiple
        //{
        //    get { return false; }
        //}

        //string[] TokenAndUser = null;
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {

            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            //var myModel = context.ActionContext.Request.Content.ReadAsStringAsync();

            Task<string> content = context.ActionContext.Request.Content.ReadAsStringAsync();
            string jsonData = content.Result;

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            jsonData = jsonData.Replace("'", "''");
            Root objObject = JsonConvert.DeserializeObject<Root>(jsonData, settings);

            if (authorization == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Authorization Header", request);
                return;
            }
            if (authorization.Scheme != "Bearer")
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid Authorization Scheme", request);
                return;
            }

            if (String.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Token", request);
                return;
            }



            string API_Key = string.Empty;
            if (request.Headers.Contains("API_Key"))
            {
                IEnumerable<string> headerValues = request.Headers.GetValues("API_Key");
                API_Key = headerValues.FirstOrDefault();
            }

            if (API_Key == "")
            {
                context.ErrorResult = new AuthenticationFailureResult("API Key is null.Please pass API Key", request);
            }
            else
            {
                string API_Key_Check = ConfigurationManager.AppSettings["API_Key"].Trim().ToString();
                if (API_Key == API_Key_Check)
                {
                    context.Principal = TokenManager.GetPrincipal(authorization.Parameter, objObject.useragent, objObject.userip);
                    if (context.Principal == null)
                    {
                        context.ErrorResult = new AuthenticationFailureResult("Unauthorized Access", request);
                    }
                }
                else
                {
                    context.ErrorResult = new AuthenticationFailureResult("API key is invalid", request);
                }
            }
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var result = await context.Result.ExecuteAsync(cancellationToken);
            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                result.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Basic", "realm=localhost"));
            }
            context.Result = new ResponseMessageResult(result);
        }

        public class AuthenticationFailureResult : IHttpActionResult
        {
            public string ReasonPhrase = string.Empty;
            public HttpRequestMessage Request { get; set; }

            public AuthenticationFailureResult(string reasonphrase, HttpRequestMessage request)
            {
                ReasonPhrase = reasonphrase;
                Request = request;
            }
            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(Execute());
            }

            public HttpResponseMessage Execute()
            {
                //HttpResponseMessage responemessage = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                //{
                //    RequestMessage = Request,
                //    ReasonPhrase = ReasonPhrase
                //};

                return Request.CreateResponse(HttpStatusCode.OK, new ServiceStatus()
                {
                    Status_Code = (int)HttpStatusCode.Unauthorized,
                    Message = "Token Expired",
                    Success = false,
                    Method_Name = Request.GetActionDescriptor().ActionName,
                    Data = new { Message = ReasonPhrase },
                    ReasonPhrase = "",
                    Model_State = null
                });
                //return responemessage;

            }



        }

    }
}