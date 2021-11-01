using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MQWebAPI.Models
{
    public class Audit
    {
        public class CardLimitAuditTrail_Input
        {
            [JsonProperty("Cardno")]
            public string Cardno { get; set; }

            [JsonProperty("customerid")]
            public string Customerid { get; set; }

            [JsonProperty("Fromdate")]
            public DateTime Fromdate { get; set; }

            [JsonProperty("Todate")]
            public DateTime Todate { get; set; }

            [JsonProperty("Limittype")]
            public string Limittype { get; set; }

            [Required]
            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [Required]
            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [Required]
            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }
        


    }
}