
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MQWebAPI.Models
{
    public class Merchant
    {
        public class SearchMerchantInput
        {
            public Int64 Merchantid { get; set; }
            public string Stateid { get; set; }
            public string Districtid { get; set; }
            public string Cityid { get; set; }
            public string Highway { get; set; }
            public string Highway_no { get; set; }
            public string Useragent { get; set; }
            public string Userip { get; set; }
            public string Userid { get; set; }
        }
        public class Map_Mobile_Dispenser_Merchants_Input
        {
            public int MobileDispenserId { get; set; }
            public Int64 MerchantId { get; set; }
            public string CreatedBy { get; set; }
            public string Useragent { get; set; }
            public string Userip { get; set; }
            public string Userid { get; set; }
        }
        public class Get_Mapped_Mobile_Dispenser_Merchants_Input
        {
            public string MobileDispenserId { get; set; }
            public string Useragent { get; set; }
            public string Userip { get; set; }
            public string Userid { get; set; }
        }
        public class Get_Rejected_Merchants_Input
        {
            public string FromDate { get; set; }
            public string ToDate { get; set; }
            public string Useragent { get; set; }
            public string Userip { get; set; }
            public string Userid { get; set; }
        }
        public class Create_Merchant_Input
        {

            [Required]
            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [Required]
            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [Required]
            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [Required]
            [JsonProperty("OutletName")]
            public string OutletName { get; set; }

            [Required]
            [JsonProperty("Perm_Address1")]
            public string Perm_Address1 { get; set; }

            [Required]
            [JsonProperty("Perm_Address2")]
            public string Perm_Address2 { get; set; }

            [Required]
            [JsonProperty("Perm_Address3")]
            public string Perm_Address3 { get; set; }

            [Required]
            [JsonProperty("Perm_Location")]
            public string Perm_Location { get; set; }

            [Required]
            [JsonProperty("Perm_District")]
            public string Perm_District { get; set; }

            [Required]
            [JsonProperty("Perm_City")]
            public string Perm_City { get; set; }

            [Required]
            [JsonProperty("Perm_State")]
            public string Perm_State { get; set; }

            [Required]
            [JsonProperty("Perm_PIN_Code")]
            public string Perm_PIN_Code { get; set; }

            [Required]
            [JsonProperty("Perm_std_code")]
            public int Perm_std_code { get; set; }

            [Required]
            [JsonProperty("Perm_Ph_Off")]
            public string Perm_Ph_Off { get; set; }

            [Required]
            [JsonProperty("Perm_fax")]
            public int Perm_fax { get; set; }

            [Required]
            [JsonProperty("ERP_Code")]
            public string ERP_Code { get; set; }

            [Required]
            [JsonProperty("Outlet_Category")]
            public string Outlet_Category { get; set; }

            [Required]
            [JsonProperty("PANNo")]
            public string PANNo { get; set; }

            [Required]
            [JsonProperty("GSTNo")]
            public string GSTNo { get; set; }

            [Required]
            [JsonProperty("Dealer_name")]
            public string Dealer_name { get; set; }

            [Required]
            [JsonProperty("Highway_Name")]
            public string Highway_Name { get; set; }

            [Required]
            [JsonProperty("Highway_No")]
            public string Highway_No { get; set; }

            [Required]
            [JsonProperty("CautionAmt_DTP")]
            public double CautionAmt_DTP { get; set; }

            [Required]
            [JsonProperty("CautionAmt_HP")]
            public double CautionAmt_HP { get; set; }

            [Required]
            [JsonProperty("LPGSale")]
            public double LPGSale { get; set; }

            [Required]
            [JsonProperty("MSSale")]
            public double MSSale { get; set; }

            [Required]
            [JsonProperty("SBU_TYpe")]
            public string SBU_TYpe { get; set; }

            [Required]
            [JsonProperty("MonthlyHSD")]
            public string MonthlyHSD { get; set; }

            [Required]
            [JsonProperty("Zonal_Office")]
            public string Zonal_Office { get; set; }

            [Required]
            [JsonProperty("Regional_Office")]
            public string Regional_Office { get; set; }

            [Required]
            [JsonProperty("SalesArea")]
            public string SalesArea { get; set; }

            [JsonProperty("Comm_Address1")]
            public string Comm_Address1 { get; set; }

            [JsonProperty("Comm_Address2")]
            public string Comm_Address2 { get; set; }

            [JsonProperty("Comm_Address3")]
            public string Comm_Address3 { get; set; }

            [JsonProperty("Comm_Location")]
            public string Comm_Location { get; set; }

            [JsonProperty("Comm_City")]
            public string Comm_City { get; set; }

            [JsonProperty("Comm_State")]
            public string Comm_State { get; set; }

            [JsonProperty("Comm_District")]
            public string Comm_District { get; set; }

            [JsonProperty("Comm_PIN_Code")]
            public int? Comm_PIN_Code { get; set; }

            [JsonProperty("Comm_std_code")]
            public int? Comm_std_code { get; set; }

            [JsonProperty("Comm_Ph_Off")]
            public Int64? Comm_Ph_Off { get; set; }

            [JsonProperty("Comm_Fax")]
            public Int64? Comm_Fax { get; set; }

            [Required]
            [JsonProperty("NoofLiveTerminals")]
            public Int64 NoofLiveTerminals { get; set; }

            [Required]
            [JsonProperty("Terminal_Type")]
            public string Terminal_Type { get; set; }

            [Required]
            [JsonProperty("CreatedBy")]
            public int CreatedBy { get; set; }

            [Required]
            [JsonProperty("Merchant_Type_Id")]
            public string Merchant_Type_Id { get; set; }

            [JsonProperty("Comm_Mobile")]
            public string Comm_Mobile { get; set; }

            [JsonProperty("Comm_Email")]
            public string Comm_Email { get; set; }

            [Required]
            [JsonProperty("Name")]
            public string Name { get; set; }

            [Required]
            [JsonProperty("Email")]
            public string Email { get; set; }

            [Required]
            [JsonProperty("Mobile")]
            public string Mobile { get; set; }

            [Required]
            [JsonProperty("Groupid")]
            public int Groupid { get; set; }

            [Required]
            [JsonProperty("Groupname")]
            public string Groupname { get; set; }

            [Required]
            [JsonProperty("Store_password")]
            public string Store_password { get; set; }

        }

        public class Update_Merchant_Input
        {
            [Required]
            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [Required]
            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [Required]
            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [Required]
            [JsonProperty("Merchantid")]
            public Int64 Merchantid { get; set; }

            [Required]
            [JsonProperty("OutletName")]
            public string OutletName { get; set; }

            [Required]
            [JsonProperty("Perm_Address1")]
            public string Perm_Address1 { get; set; }

            [Required]
            [JsonProperty("Perm_Address2")]
            public string Perm_Address2 { get; set; }

            [Required]
            [JsonProperty("Perm_Address3")]
            public string Perm_Address3 { get; set; }

            [Required]
            [JsonProperty("Perm_Location")]
            public string Perm_Location { get; set; }

            [Required]
            [JsonProperty("Perm_District")]
            public string Perm_District { get; set; }

            [Required]
            [JsonProperty("Perm_City")]
            public string Perm_City { get; set; }

            [Required]
            [JsonProperty("Perm_State")]
            public string Perm_State { get; set; }

            [Required]
            [JsonProperty("Perm_PIN_Code")]
            public string Perm_PIN_Code { get; set; }

            [Required]
            [JsonProperty("Perm_std_code")]
            public int Perm_std_code { get; set; }

            [Required]
            [JsonProperty("Perm_Ph_Off")]
            public string Perm_Ph_Off { get; set; }

            [Required]
            [JsonProperty("Perm_fax")]
            public int Perm_fax { get; set; }

            [Required]
            [JsonProperty("ERP_Code")]
            public string ERP_Code { get; set; }

            [Required]
            [JsonProperty("Outlet_Category")]
            public string Outlet_Category { get; set; }

            [Required]
            [JsonProperty("PANNo")]
            public string PANNo { get; set; }

            [Required]
            [JsonProperty("GSTNo")]
            public string GSTNo { get; set; }

            [Required]
            [JsonProperty("Dealer_name")]
            public string Dealer_name { get; set; }

            [Required]
            [JsonProperty("Highway_Name")]
            public string Highway_Name { get; set; }

            [Required]
            [JsonProperty("Highway_No")]
            public string Highway_No { get; set; }

            [Required]
            [JsonProperty("CautionAmt_DTP")]
            public double CautionAmt_DTP { get; set; }

            [Required]
            [JsonProperty("CautionAmt_HP")]
            public double CautionAmt_HP { get; set; }

            [Required]
            [JsonProperty("LPGSale")]
            public double LPGSale { get; set; }

            [Required]
            [JsonProperty("MSSale")]
            public double MSSale { get; set; }

            [Required]
            [JsonProperty("SBU_TYpe")]
            public string SBU_TYpe { get; set; }

            [Required]
            [JsonProperty("MonthlyHSD")]
            public string MonthlyHSD { get; set; }

            [Required]
            [JsonProperty("Zonal_Office")]
            public string Zonal_Office { get; set; }

            [Required]
            [JsonProperty("Regional_Office")]
            public string Regional_Office { get; set; }

            [Required]
            [JsonProperty("SalesArea")]
            public string SalesArea { get; set; }

            [JsonProperty("Comm_Address1")]
            public string Comm_Address1 { get; set; }

            [JsonProperty("Comm_Address2")]
            public string Comm_Address2 { get; set; }

            [JsonProperty("Comm_Address3")]
            public string Comm_Address3 { get; set; }

            [JsonProperty("Comm_Location")]
            public string Comm_Location { get; set; }

            [JsonProperty("Comm_City")]
            public string Comm_City { get; set; }

            [JsonProperty("Comm_State")]
            public string Comm_State { get; set; }

            [JsonProperty("Comm_District")]
            public string Comm_District { get; set; }

            [JsonProperty("Comm_PIN_Code")]
            public int? Comm_PIN_Code { get; set; }

            [JsonProperty("Comm_std_code")]
            public int? Comm_std_code { get; set; }

            [JsonProperty("Comm_Ph_Off")]
            public Int64? Comm_Ph_Off { get; set; }

            [JsonProperty("Comm_Fax")]
            public Int64? Comm_Fax { get; set; }

            [Required]
            [JsonProperty("NoofLiveTerminals")]
            public Int64 NoofLiveTerminals { get; set; }

            [Required]
            [JsonProperty("Terminal_Type")]
            public string Terminal_Type { get; set; }

            [Required]
            [JsonProperty("CreatedBy")]
            public int CreatedBy { get; set; }

            [Required]
            [JsonProperty("Merchant_Type_Id")]
            public string Merchant_Type_Id { get; set; }

            [JsonProperty("Comm_Mobile")]
            public string Comm_Mobile { get; set; }

            [JsonProperty("Comm_Email")]
            public string Comm_Email { get; set; }

            [Required]
            [JsonProperty("Name")]
            public string Name { get; set; }

            [Required]
            [JsonProperty("Email")]
            public string Email { get; set; }

            [Required]
            [JsonProperty("Mobile")]
            public string Mobile { get; set; }

            [Required]
            [JsonProperty("Groupid")]
            public int Groupid { get; set; }

            [Required]
            [JsonProperty("Groupname")]
            public string Groupname { get; set; }

            [Required]
            [JsonProperty("Store_password")]
            public string Store_password { get; set; }

        }
        public class Get_Merchant_Input
        {
            public Int64 Merchantid { get; set; }
            public string Useragent { get; set; }
            public string Userip { get; set; }
            public string Userid { get; set; }
        }

        public class Approve_Merchant_Input
        {
            public string Storecode { get; set; }
            public string Comments { get; set; }
            public string Status { get; set; }
            public string Useragent { get; set; }
            public string Userip { get; set; }
            public string Userid { get; set; }
        }
        public class Get_Approve_Merchants_List_Input
        {
            public string Merchantcategory { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
            public string Useragent { get; set; }
            public string Userip { get; set; }
            public string Userid { get; set; }
        }
        public class Approve_Pending_Mobile_Dispenser_Input
        {
            public Int64 MobileDispenserId { get; set; }
            public string Remarks { get; set; }
            public string Status { get; set; }
            public string Useragent { get; set; }
            public string Userip { get; set; }
            public string Userid { get; set; }
        }   
        public class Get_Pending_Mobile_Dispensers_List_Input
        {
            public Int64 MobileDispenserId { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
            public string Useragent { get; set; }
            public string Userip { get; set; }
            public string Userid { get; set; }
        }

        public class List_Of_Hotlisted_Merchants_Input
        {
            public Int64 MerchantId { get; set; }
            public string Merchant_ZO { get; set; }
            public string Merchant_RO { get; set; }
            public string HotList_Month_Year { get; set; }
            public string Status { get; set; }
            public string Useragent { get; set; }
            public string Userip { get; set; }
            public string Userid { get; set; }
        }
        public class Approve_Reject_Hotlisted_Merchant_Input
        {
            public Int64 MerchantId { get; set; }
            public string Status { get; set; }
            public string Remarks { get; set; }
            public string Useragent { get; set; }
            public string Userip { get; set; }
            public string Userid { get; set; }
        }
        public class List_Of_Mobiledispenser_Merchant_Terminal_Mapping_Input
        {
            public Int64 MobileDispenserId { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
            public string Useragent { get; set; }
            public string Userip { get; set; }
            public string Userid { get; set; }
        }
        public class Approve_Reject_Mobiledispenser_Merchant_Terminal_Mapping_Input
        {
            public Int64 MobileDispenserId { get; set; }
            public Int64 MerchantId { get; set; }
            public Int64 TerminalId { get; set; }
            public string Status { get; set; }
            public string Remarks { get; set; }
            public string Useragent { get; set; }
            public string Userip { get; set; }
            public string Userid { get; set; }
        }
        public class Search_By_Merchant_Input
        {
            public Int64 Merchantid { get; set; }
            public string ERPCode { get; set; }
            public string Outlet_name { get; set; }
            public string City { get; set; }
            public string Highway_No { get; set; }
            public string Status { get; set; }

        }
        public class SearchMerchant
        {
            public string Merchantid { get; set; }
            public string Merchantname { get; set; }
            public string Outlet_name { get; set; }
            public string Address { get; set; }

        }
        public class Map_Mobile_Dispenser_Merchants
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }

        }

        public class Get_Mapped_Mobile_Dispenser_Merchants
        {
            [JsonProperty("MobileDispenserId")]
            public decimal MobileDispenserId { get; set; }

            [JsonProperty("MappedMerchantId")]
            public int MappedMerchantId { get; set; }

            [JsonProperty("RequestedDate")]
            public string RequestedDate { get; set; }

            [JsonProperty("RequestedBy")]
            public string RequestedBy { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }

            [JsonProperty("ModifiedDate")]
            public string ModifiedDate { get; set; }

            [JsonProperty("ModifiedBy")]
            public string ModifiedBy { get; set; }

            [JsonProperty("Remarks")]
            public string Remarks { get; set; }

        }
        public class Get_Rejected_Merchants
        {
            [JsonProperty("ERP_Code")]
            public string ERP_Code {get; set; }

            [JsonProperty("Regional_Office")]
            public string Regional_Office { get; set; }

            [JsonProperty("OutletName")]
            public string OutletName { get; set; }

            [JsonProperty("Merchant_Type")]
            public string Merchant_Type { get; set; }

            [JsonProperty("City")]
            public string City { get; set; }

            [JsonProperty("CreationDate")]
            public string CreationDate { get; set; }

            [JsonProperty("RejectedDate")]
            public string RejectedDate { get; set; }

            [JsonProperty("Comments")]
            public string Comments { get; set; }

        }
        public class Create_Merchant
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }

        }

        public class Get_Merchant
        {
            [JsonProperty("Merchantid")]
            public Int64 Merchantid { get; set; }

            [JsonProperty("OutletName")]
            public string OutletName { get; set; }

            [JsonProperty("Perm_Address1")]
            public string Perm_Address1 { get; set; }

            [JsonProperty("Perm_Address2")]
            public string Perm_Address2 { get; set; }

            [JsonProperty("Perm_Address3")]
            public string Perm_Address3 { get; set; }

            [JsonProperty("Perm_Location")]
            public string Perm_Location { get; set; }

            [JsonProperty("Perm_District")]
            public string Perm_District { get; set; }

            [JsonProperty("Perm_City")]
            public string Perm_City { get; set; }

            [JsonProperty("Perm_State")]
            public string Perm_State { get; set; }

            [JsonProperty("Perm_PIN_Code")]
            public string Perm_PIN_Code { get; set; }

            [JsonProperty("Perm_std_code")]
            public string Perm_std_code { get; set; }

            [JsonProperty("Perm_Ph_Off")]
            public string Perm_Ph_Off { get; set; }

            [JsonProperty("Perm_fax")]
            public string Perm_fax { get; set; }

            [JsonProperty("ERP_Code")]
            public string ERP_Code { get; set; }

            [JsonProperty("Outlet_Category")]
            public string Outlet_Category { get; set; }

            [JsonProperty("PANNo")]
            public string PANNo { get; set; }

            [JsonProperty("GSTNo")]
            public string GSTNo { get; set; }

            [JsonProperty("Dealer_name")]
            public string Dealer_name { get; set; }

            [JsonProperty("Highway_Name")]
            public string Highway_Name { get; set; }

            [JsonProperty("Highway_No")]
            public string Highway_No { get; set; }

            [JsonProperty("CautionAmt_DTP")]
            public decimal CautionAmt_DTP { get; set; }

            [JsonProperty("CautionAmt_HP")]
            public decimal CautionAmt_HP { get; set; }

            [JsonProperty("LPGSale")]
            public decimal LPGSale { get; set; }

            [JsonProperty("MSSale")]
            public decimal MSSale { get; set; }

            [JsonProperty("SBU_TYpe")]
            public string SBU_TYpe { get; set; }

            [JsonProperty("MonthlyHSD")]
            public string MonthlyHSD { get; set; }

            [JsonProperty("Zonal_Office")]
            public string Zonal_Office { get; set; }

            [JsonProperty("Regional_Office")]
            public string Regional_Office { get; set; }

            [JsonProperty("SalesArea")]
            public string SalesArea { get; set; }

            [JsonProperty("Comm_Address1")]
            public string Comm_Address1 { get; set; }

            [JsonProperty("Comm_Address2")]
            public string Comm_Address2 { get; set; }

            [JsonProperty("Comm_Address3")]
            public string Comm_Address3 { get; set; }

            [JsonProperty("Comm_Location")]
            public string Comm_Location { get; set; }

            [JsonProperty("Comm_City")]
            public string Comm_City { get; set; }

            [JsonProperty("Comm_State")]
            public string Comm_State { get; set; }

            [JsonProperty("Comm_District")]
            public string Comm_District { get; set; }

            [JsonProperty("Comm_PIN_Code")]
            public string Comm_PIN_Code { get; set; }

            [JsonProperty("Comm_std_code")]
            public string Comm_std_code { get; set; }

            [JsonProperty("Comm_Ph_Off")]
            public string Comm_Ph_Off { get; set; }

            [JsonProperty("Comm_Fax")]
            public string Comm_Fax { get; set; }

            [JsonProperty("NoofLiveTerminals")]
            public Single NoofLiveTerminals { get; set; }

            [JsonProperty("Terminal_Type")]
            public string Terminal_Type { get; set; }

            [JsonProperty("CreatedBy")]
            public string CreatedBy { get; set; }

            [JsonProperty("Merchant_Type_Id")]
            public string Merchant_Type_Id { get; set; }

            [JsonProperty("Comm_Mobile")]
            public string Comm_Mobile { get; set; }

            [JsonProperty("Comm_Email")]
            public string Comm_Email { get; set; }

            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("Mobile")]
            public string Mobile { get; set; }

            [JsonProperty("Groupid")]
            public int Groupid { get; set; }

            [JsonProperty("Groupname")]
            public string Groupname { get; set; }

            [JsonProperty("Store_password")]
            public string Store_password { get; set; }

        }
        public class Approve_Merchant
        {

            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }

        }
        public class Get_Approve_Merchants_List
        {
            [JsonProperty("ERPCode")]
            public string ERPCode { get; set; }

            [JsonProperty("RO")]
            public string RO { get; set; }

            [JsonProperty("Outlet_name")]
            public string Outlet_name { get; set; }

            [JsonProperty("City")]
            public string City { get; set; }

            [JsonProperty("Merchant_Type")]
            public string Merchant_Type { get; set; }

            [JsonProperty("CreatedOn")]
            public string CreatedOn { get; set; }

            [JsonProperty("CreatedBy")]
            public string CreatedBy { get; set; }

        }

        public class Update_Merchant
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }

        }

        public class Get_Pending_Mobile_Dispensers_List
        {
            [JsonProperty("MobileDispenserId")]
            public Int64 MobileDispenserId { get; set; }

            [JsonProperty("MappedMerchantId")]
            public int MappedMerchantId { get; set; }

            [JsonProperty("RequestedDate")]
            public string RequestedDate { get; set; }

            [JsonProperty("RequestedBy")]
            public string RequestedBy { get; set; }

            }
            public class Approve_Pending_Mobile_Dispenser
            {
                [JsonProperty("Status")]
                public int Status { get; set; }

                [JsonProperty("Reason")]
                public string Reason { get; set; }

            }

        public class List_Of_Hotlisted_Merchants
        {
            [JsonProperty("MerchantId")]
            public Int64 MerchantId { get; set; }

            [JsonProperty("Retail_Outlet_Name")]
            public string Retail_Outlet_Name { get; set; }

            [JsonProperty("Reason_for_HotListing")]
            public string Reason_for_HotListing { get; set; }

            [JsonProperty("HotListed_Date")]
            public string HotListed_Date { get; set; }

            [JsonProperty("Remark_by_MO")]
            public string Remark_by_MO { get; set; }

            [JsonProperty("Requested_Date")]
            public string Requested_Date { get; set; }

            [JsonProperty("Requested_By")]
            public string Requested_By { get; set; }

        }
        public class Approve_Reject_Hotlisted_Merchant
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }

        }
        public class List_Of_Mobiledispenser_Merchant_Terminal_Mapping
        {
            [JsonProperty("MobileDispenserId")]
            public Int64 MobileDispenserId { get; set; }

            [JsonProperty("MerchantId")]
            public Int64 MerchantId { get; set; }

            [JsonProperty("TerminalId")]
            public Int64 TerminalId { get; set; }

            [JsonProperty("Service_Charge")]
            public string Service_Charge { get; set; }

            [JsonProperty("Route_Id")]
            public string Route_Id { get; set; }

            [JsonProperty("Requested_Date")]
            public string Requested_Date { get; set; }

            [JsonProperty("Requested_By")]
            public string Requested_By { get; set; }

        }
        public class Approve_Reject_Mobiledispenser_Merchant_Terminal_Mapping
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }

        }

        public class Search_By_Merchant
        {
            [JsonProperty("MerchantId")]
            public Int64 MerchantId { get; set; }

            [JsonProperty("ERP_Code")]
            public string ERP_Code { get; set; }

            [JsonProperty("Regional_Office")]
            public string Regional_Office { get; set; }

            [JsonProperty("OutletName")]
            public string OutletName { get; set; }

            [JsonProperty("Merchant_Type")]
            public string Merchant_Type { get; set; }

            [JsonProperty("City")]
            public string City { get; set; }

            [JsonProperty("State")]
            public string State { get; set; }

            [JsonProperty("ROCode")]
            public string ROCode { get; set; }

            [JsonProperty("Sales_Area")]
            public string Sales_Area { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }

            [JsonProperty("Highway_no")]
            public string Highway_no { get; set; }

        }
    }
}