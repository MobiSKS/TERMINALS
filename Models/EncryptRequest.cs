using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPCL_DP_Terminal.Models
{
    public class EncryptRequest
    {
        public class Encrypt_Request_Input
        {

            [JsonProperty("CETTxnMerchantId")]
            public string CETTxnMerchantId { get; set; }

            [JsonProperty("ValueStringToEncrypt")]
            public string ValueStringToEncrypt { get; set; }

            [JsonProperty("PBPrivateKey")]
            public string PBPrivateKey { get; set; }

            [JsonProperty("PBpartnerAuthKey")]
            public string PBpartnerAuthKey { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }

    }
}