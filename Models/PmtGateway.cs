using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MQWebAPI.Models
{
    public class PmtGateway
    {
        public class Create_Validate_Initiate_Checksumhash_Input
        {

            [JsonProperty("Mid")]
            public string Mid { get; set; }

            [JsonProperty("Checksum")]
            public string Checksum { get; set; }

            [JsonProperty("Merchant_Key")]
            public string Merchant_Key { get; set; }


            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }


            [JsonProperty("RequestType")]
            public string RequestType { get; set; }

            [JsonProperty("WebsiteName")]
            public string WebsiteName { get; set; }

            [JsonProperty("CallbackUrl")]
            public string CallbackUrl { get; set; }


            [JsonProperty("Value")]
            public string Value { get; set; }


            [JsonProperty("Currency")]
            public string Currency { get; set; }


            [JsonProperty("CustId")]
            public string CustId { get; set; }


            [JsonProperty("OrderId")]
            public string OrderId { get; set; }


        }

      

        public class Create_Checksumhash_Output
        {

            [JsonProperty("Checksum")]
            public string Checksum { get; set; }


        }
        }

}