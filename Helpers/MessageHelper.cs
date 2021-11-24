using System;
using System.Net.Http;
using System.Net;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using static HPCL_DP_Terminal.MQSupportClass.StatusMessage;
using HPCL_DP_Terminal.App_Start;
using System.Web.Http.ModelBinding;
using System.Collections.Generic;

namespace HPCL_DP_Terminal.Helpers
{
    public class MessageHelper
    {
        /// <summary>
        /// succes message
        /// </summary>
        /// <param name="request"></param>
        /// <param name="StatusCode"></param>
        /// <param name="Message"></param>
        /// <param name="customData"></param>
        /// <param name="Success"></param>
        /// <param name="httpstatusCode"></param>
        /// <returns></returns>
        public static HttpResponseMessage Message(HttpRequestMessage request, HttpStatusCode httpstatusCode, bool Success,
            int StatusCode, object customData = null, ModelStateDictionary ObjModelState = null)
        {
            return request.CreateResponse(httpstatusCode, new ApiResponseMessage()
            {
               
                 Method_Name = request.GetActionDescriptor().ActionName,
                Success = Success,
                Status_Code = StatusCode,
                Message = StatusCode==1026? Convert.ToString(customData):((StatusInformation)StatusCode).GetDisplayName(),
                Data = StatusCode == 1026 ? new List<string>(): customData,
                Model_State = ObjModelState,

            });
        }


    }


    #region Status Object Class
    /// <summary>
    /// Public class to return input status
    /// </summary>
    [Serializable]
    [DataContract]
    public class ApiResponseMessage
    {
        #region Public properties.
        /// <summary>
        /// Get/Set property for accessing Status Code
        /// </summary>
        [JsonProperty("Success")]
        [DataMember]
        public bool Success { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Code
        /// </summary>
        [JsonProperty("Status_Code")]
        [DataMember]
        public int Status_Code { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>
        [JsonProperty("Message")]
        [DataMember]
        public string Message { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>
        [JsonProperty("Method_Name")]
        [DataMember]
        public string Method_Name { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>
        [JsonProperty("Data")]
        [DataMember]
        public object Data { get; set; }

        [JsonProperty("Model_State")]
        [DataMember]
        public ModelStateDictionary Model_State { get; set; }


        #endregion
    }

    #endregion
}