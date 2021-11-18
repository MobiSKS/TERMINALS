using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HPCL_DP_Terminal.Models
{
    public class Login
    {
        public class LoginInput
        {
            [Required]
            [JsonProperty("Username")]
            public string Username { get; set; }

            [Required]
            [JsonProperty("Password")]
            public string Password { get; set; }

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
        public class LoginOutput
        {


            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }


            [JsonProperty("Userid")]
            public string Userid { get; set; }

             
            [JsonProperty("Username")]
            public string Username { get; set; }


            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("Userrole")]
            public string Userrole { get; set; }

            //[JsonProperty("Token")]
            //public string Token { get; set; }

        }
        public class DashboardInput
        {
            [Required]
            [JsonProperty("Username")]
            public string Username { get; set; }

            [JsonProperty("Userrole")]
            public string Userrole { get; set; }

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
        public class DashboardOutput
        {
            [JsonProperty("Username")]
            public string Username { get; set; }

            [JsonProperty("Userrole")]
            public string Userrole { get; set; }

            [JsonProperty("Useremailid")]
            public string Useremailid { get; set; }

            [JsonProperty("Usermobile")]
            public string Usermobile { get; set; }

            [JsonProperty("Userid")]
            public int? Userid { get; set; }

            [JsonProperty("Ccmsbalance")]
            public decimal? Ccmsbalance { get; set; }

            [JsonProperty("Cardbalance")]
            public decimal? Cardbalance { get; set; }

            [JsonProperty("Driverstars")]
            public decimal? Driverstars { get; set; }
        }
        public class ForgotPasswordInput
        {
            [Required]
            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("User_Type")]
            public int User_Type { get; set; }

            [JsonProperty("Useremail")]
            public string Useremail { get; set; }

            [Required]
            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [Required]
            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }
        public class ForgotPasswordOutput
        {
            [JsonProperty("Status")]
            public int? Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }
        public class ChangePasswordInput
        {

            [JsonProperty("User_mobile")]
            public string User_mobile { get; set; }

            [JsonProperty("User_Type")]
            public int? User_Type { get; set; }

            [JsonProperty("Oldpass")]
            public string Oldpass { get; set; }

            [JsonProperty("Newpass")]
            public string Newpass { get; set; }

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
        public class ChangePasswordOutput
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }
        public class ValidatePinInput
        {

            [JsonProperty("CardNo")]
            public Int64 CardNo { get; set; }

            [JsonProperty("CardPin")]
            public int CardPin { get; set; }

            [JsonProperty("TID")]
            public Int64 TID { get; set; }

            [JsonProperty("OutletId")]
            public string OutletId { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }
        public class ValidatePinOutput
        {
            /*
            [JsonProperty("Id")]
            public string Id { get; set; }

            [JsonProperty("Card_no")]
            public Int64 Card_no { get; set; }

            [JsonProperty("Card_pin")]
            public string Card_pin { get; set; }

            [JsonProperty("Group_id")]
            public string Group_id { get; set; }

            [JsonProperty("Group_name")]
            public string Group_name { get; set; }

            [JsonProperty("Customer_id")]
            public Int64 Customer_id { get; set; }

            [JsonProperty("ZOCode")]
            public string ZOCode { get; set; }

            [JsonProperty("ROCode")]
            public string ROCode { get; set; }

            [JsonProperty("Card_type")]
            public int Card_type { get; set; }

            [JsonProperty("Form_id")]
            public string Form_id { get; set; }

            [JsonProperty("Vehicle_no")]
            public string Vehicle_no { get; set; }

            [JsonProperty("Vehicle_type")]
            public int Vehicle_type { get; set; }

            [JsonProperty("Issue_date")]
            public DateTime? Issue_date { get; set; }

            [JsonProperty("Expiry_date")]
            public DateTime? Expiry_date { get; set; }

            [JsonProperty("Card_status")]
            public string Card_status { get; set; }

            [JsonProperty("Vehicle_yr_of_reg")]
            public string Vehicle_yr_of_reg { get; set; }

            [JsonProperty("Vehicle_manufacturer")]
            public string Vehicle_manufacturer { get; set; }

            [JsonProperty("Card_type_status")]
            public string Card_type_status { get; set; }

            [JsonProperty("Mobileno")]
            public string Mobileno { get; set; }

            [JsonProperty("Vin_no")]
            public string Vin_no { get; set; }

            [JsonProperty("Card_Preference_Type")]
            public string Card_Preference_Type { get; set; }

            [JsonProperty("RCDoc")]
            public string RCDoc { get; set; }

            [JsonProperty("Type_of_limit")]
            public string Type_of_limit { get; set; }

            [JsonProperty("IsAttached")]
            public string IsAttached { get; set; }

            [JsonProperty("Vehicle_tracking")]
            public string Vehicle_tracking { get; set; }

            [JsonProperty("status_flag")]
            public int Status_flag { get; set; }

            [JsonProperty("created_on")]
            public DateTime? Created_on { get; set; }

            [JsonProperty("CreatedBy")]
            public string CreatedBy { get; set; }

            [JsonProperty("LastModifiedOn")]
            public DateTime? LastModifiedOn { get; set; }

            [JsonProperty("LastModifiedBy")]
            public int LastModifiedBy { get; set; }

            [JsonProperty("SalesArea")]
            public string SalesArea { get; set; }

            [JsonProperty("Activation_date")]
            public DateTime? Activation_date { get; set; }

            [JsonProperty("Approved_on")]
            public DateTime? Approved_on { get; set; }

            [JsonProperty("ApprovedBy")]
            public string ApprovedBy { get; set; }

            [JsonProperty("DeactivatedCard_No")]
            public string DeactivatedCard_No { get; set; }
            */
            public bool Pin_Found { get; set; }
        }
        public class SendOTPInput
        {

            [Required]
            [JsonProperty("User_Mobile")]
            public Int64 User_Mobile { get; set; }

            [JsonProperty("TID")]
            public Int64 TID { get; set; }

            [JsonProperty("OutletId")]
            public string OutletId { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Flag_Type")]
            public string Flag_Type { get; set; }

            [JsonProperty("Role_id")]
            public int Role_id { get; set; }

            [JsonProperty("User_Type")]
            public int User_Type { get; set; }

        }
        public class SendOTPOutput
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }


        public class Validate_OTP_Input
        {

            [JsonProperty("User_Mobile")]
            public Int64 User_Mobile { get; set; }

            [JsonProperty("OTP")]
            public Int64 OTP { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }

        public class Validate_OTP
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
            [JsonProperty("Title")]
            public string Title { get; set; }

            [JsonProperty("First_name")]
            public string First_name { get; set; }

            [JsonProperty("Last_name")]
            public string Last_name { get; set; }

            [JsonProperty("User_email")]
            public string User_email { get; set; }

            [JsonProperty("User_mobile")]
            public Int64 User_mobile { get; set; }

            [JsonProperty("Dob")]
            public string Dob { get; set; }

            [JsonProperty("Pincode")]
            public string Pincode { get; set; }

            [JsonProperty("Gender")]
            public string Gender { get; set; }

            [JsonProperty("Address")]
            public string Address { get; set; }

            [JsonProperty("Vehicle_no")]
            public string Vehicle_no { get; set; }

            [JsonProperty("Fasttag_no")]
            public string Fasttag_no { get; set; }

            [JsonProperty("Payback_cardno")]
            public string Payback_cardno { get; set; }

            [JsonProperty("ReferralCode")]
            public string ReferralCode { get; set; }

            [JsonProperty("CustomerType")]
            public string CustomerType { get; set; }

            [JsonProperty("Active_Paycode_Balance")]
            public Single Active_Paycode_Balance { get; set; }
        }


        public class AunticateInput
        {
            [JsonProperty("User_Mobile")]
            public Int64 User_Mobile { get; set; }

            [JsonProperty("OTP")]
            public int OTP { get; set; }

            [JsonProperty("TID")]
            public Int64 TID { get; set; }

            [JsonProperty("OutletId")]
            public string OutletId { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Role_id")]
            public int Role_id { get; set; }

            [JsonProperty("User_Type")]
            public int User_Type { get; set; }

            [JsonProperty("Flag_Type")]
            public string Flag_Type { get; set; }
        }
        public class AuthenticateOutput
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }
        public class OTP_DTPlus_Input
        {

            [JsonProperty("User_Mobile")]
            public Int64 User_Mobile { get; set; }

            [JsonProperty("DeviceToken")]
            public string DeviceToken { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }
        public class OTP_DTPlus_Output
        {
            [JsonProperty("OTP")]
            public Int64 OTP { get; set; }
        }

        public class Set_All_Configurations_For_Terminal_Input
        {
            [Required]
            [JsonProperty("Outlet_Id")]
            public Int64 Outlet_Id { get; set; }

            [Required]
            [JsonProperty("TID")]
            public Int64 TID { get; set; }

            [Required]
            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [Required]
            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [Required]
            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }

        public class Validate_OTP_DTPlus_Input
        {

            [JsonProperty("User_Mobile")]
            public Int64 User_Mobile { get; set; }

            [JsonProperty("OTP")]
            public Int64 OTP { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }
        public class Validate_OTP_DTPlus_Output
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }

        //[RegularExpression("^[0-9]*$")]
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")] 
        //[StringLength(7), Required]
        //[Range(0, 99)]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        // [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")] : First Charchetr alpabetical
        public class Set_All_Configurations_For_Terminal_Output
        {
            [JsonProperty("Max_Cash_Limit")]
            public decimal? Max_Cash_Limit { get; set; }

            [JsonProperty("Max_Loyalty_Limit")]
            public decimal? Max_Loyalty_Limit { get; set; }

            [JsonProperty("Recharge_Limit")]
            public decimal? Recharge_Limit { get; set; }

            [JsonProperty("Sale_Limit")]
            public decimal? Sale_Limit { get; set; }

            [JsonProperty("Settlement_Time")]
            public string Settlement_Time { get; set; }

            [JsonProperty("Settlement_Time_Limit")]
            public string Settlement_Time_Limit { get; set; }

            [JsonProperty("Batch_Size")]
            public decimal? Batch_Size { get; set; }

            [JsonProperty("Is_Fleet_Allow")]
            public decimal? Is_Fleet_Allow { get; set; }

            [JsonProperty("Is_HPPay_Allow")]
            public decimal? Is_HPPay_Allow { get; set; }

            [JsonProperty("Is_Payback_Allow")]
            public decimal? Is_Payback_Allow { get; set; }

            [JsonProperty("Is_Loyalty_Redeem_Allow")]
            public decimal? Is_Loyalty_Redeem_Allow { get; set; }

            [JsonProperty("Is_Sale_Allow")]
            public decimal? Is_Sale_Allow { get; set; }

            [JsonProperty("Is_Recharge_Allow")]
            public decimal? Is_Recharge_Allow { get; set; }

            [JsonProperty("Is_CreditSale_Allow")]
            public decimal? Is_CreditSale_Allow { get; set; }

            [JsonProperty("Is_Unblock_CADPin_Allow")]
            public decimal? Is_Unblock_CADPin_Allow { get; set; }

            [JsonProperty("Is_Unblock_CardPin_Allow")]
            public decimal? Is_Unblock_CardPin_Allow { get; set; }

            [JsonProperty("Is_SettlementPwdPrompt_Allow")]
            public decimal? Is_SettlementPwdPrompt_Allow { get; set; }


        }

    }
}