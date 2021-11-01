using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MQWebAPI.Models
{
    public class RBE
    {
        public class Get_All_RBE_List_Input
        {

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

        }

        public class Get_All_RBE_List_Changemob_Input
        {

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("RBEid")]
            public Int32 RBEid { get; set; }

            [JsonProperty("ApprovalStatus")]
            public string ApprovalStatus { get; set; }

            [JsonProperty("FirstName")]
            public string FirstName { get; set; }

        }

        public class Approve_Changed_RBE_Input
        {

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("newrbemobileno")]
            public string newrbemobileno { get; set; }

            [JsonProperty("oldrbemobileno")]
            public string oldrbemobileno { get; set; }

            [JsonProperty("oldrbename")]
            public string oldrbename { get; set; }

            [JsonProperty("fromlocation")]
            public string fromlocation { get; set; }

            [JsonProperty("tolocation")]
            public string tolocation { get; set; }

            [JsonProperty("approvaltype")]
            public string approvaltype { get; set; }

        }

        public class Get_Enroll_NewCards_Input
        {

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("CreatedBy")]
            public string CreatedBy { get; set; }
        }

        public class Get_RBE_Dashboard_Input
        {

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }
        public class Get_All_RBE_List
        {
            [JsonProperty("RBEid")]
            public Int32 RBEid { get; set; }

            [JsonProperty("NewRBE_UserMobileno")]
            public string NewRBE_UserMobileno { get; set; }

            [JsonProperty("NewRBE_Username")]
            public string NewRBE_Username { get; set; }

            [JsonProperty("PrevRBE_UserMobileno")]
            public string PrevRBE_UserMobileno { get; set; }

            [JsonProperty("PrevRBE_Username")]
            public string PrevRBE_Username { get; set; }

            [JsonProperty("FromLocation")]
            public string FromLocation { get; set; }

            [JsonProperty("ToLocation")]
            public string ToLocation { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }

        }

        public class Get_All_RBE_List_Changemob
        {
            [JsonProperty("RBEid")]
            public Int32 RBEid { get; set; }

            [JsonProperty("NewRBE_UserMobileno")]
            public string NewRBE_UserMobileno { get; set; }

            [JsonProperty("NewRBE_Username")]
            public string NewRBE_Username { get; set; }

            [JsonProperty("PrevRBE_UserMobileno")]
            public string PrevRBE_UserMobileno { get; set; }

            [JsonProperty("Region")]
            public string Region { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }

        }

        public class Approve_Changed_RBE
        {

            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }

        }
        public class Get_Enroll_NewCards
        {

            [JsonProperty("Enroll_date")]
            public string Enroll_date { get; set; }

            [JsonProperty("Ref_no")]
            public string Ref_no { get; set; }

            [JsonProperty("Customer_name")]
            public string Customer_name { get; set; }

            [JsonProperty("Form_number")]
            public Int64 Form_number { get; set; }

            [JsonProperty("Customer_id")]
            public Int64 Customer_id { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("Number_of_cards")]
            public int Number_of_cards { get; set; }

            [JsonProperty("Customer_status")]
            public string Customer_status { get; set; }

            [JsonProperty("Card_status")]
            public string Card_status { get; set; }

        }

        public class Get_RBE_Dashboard
        {

            [JsonProperty("New_Enrollments")]
            public int New_Enrollments { get; set; }

            [JsonProperty("New_Cards")]
            public int New_Cards { get; set; }
        }
    }
}