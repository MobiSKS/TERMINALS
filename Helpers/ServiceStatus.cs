using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Web.Http.ModelBinding;

namespace HPCL_DP_Terminal.Helpers
{
    
    [Serializable]
    [DataContract]
    public class ServiceStatus
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

        [JsonProperty("ReasonPhrase")]

        [DataMember]
        public string ReasonPhrase { get; set; }

        [JsonProperty("Model_State")]
        [DataMember]
        public ModelStateDictionary Model_State { get; set; }

        #endregion

    }

}