using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MQWebAPI.Models
{
    public class Settings
    {
        public class SettingsInput
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

        }

        public class SettingsEntityGroupTypeInput
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

            [JsonProperty("Entity_Group")]
            public string Entity_Group { get; set; }

        }

        public class SettingsHeadOfficeInput
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

            [JsonProperty("HO_Code")]
            public Int64? HO_Code { get; set; }

            [JsonProperty("HO_Name")]
            public string HO_Name { get; set; }

            [JsonProperty("HO_Short_Name")]
            public string HO_Short_Name { get; set; }
        }

       

        public class SettingsStateInput
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

            [JsonProperty("State_Id")]
            public string State_Id { get; set; }
 
        }

        public class SettingsCustomerTypeInput
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

            [JsonProperty("Customer_Type_Id")]
            public Int64? Customer_Type_Id { get; set; }

            
        }

        public class SettingsEntityTypeInput
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


            [JsonProperty("Entity_Type_Id")]
            public Int64? Entity_Type_Id { get; set; }
 
        }

        public class SettingsRollNameInput
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

            [JsonProperty("Role_Name")]
            public Int64? Role_Name { get; set; }
        }

        public class SettingsDefaultvaluesCardInput
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

            [JsonProperty("Default_type")]
            public Int64? Default_type { get; set; }
        }



        public class ReturnStatusOutput
        {
            [JsonProperty("Success")]
            public bool Success { get; set; }

            [JsonProperty("Method_Name")]
            public string Method_Name { get; set; }

            [JsonProperty("Message")]
            public string Message { get; set; }

            [JsonProperty("Status_Code")]
            public Int64? Status_Code { get; set; }

            [JsonProperty("Data")]
            public object Data { get; set; }
        }

        public class Customer_Types
        {
            [JsonProperty("Customer_Type_Id")]
            public Int64? Customer_Type_Id { get; set; }

            [JsonProperty("Customer_Type_Name")]
            public string Customer_Type_Name { get; set; }
        }


        public class Customer_Sub_Types
        {
            [JsonProperty("Customer_Subtype_Name")]
            public string Customer_Subtype_Name { get; set; }

            [JsonProperty("Customer_Type_Id")]
            public Int64? Customer_Type_Id { get; set; }

            [JsonProperty("Customer_Subtype_Id")]
            public Int64? Customer_Subtype_Id { get; set; }
        }


        public class Customer_Tier_Details
        {
            [JsonProperty("Slab_Id")]
            public int? Slab_Id { get; set; }

            [JsonProperty("Slab_Name")]
            public string Slab_Name { get; set; }
        }


        public class Sales_Area
        {
            [JsonProperty("District_Code")]
            public Int64? District_Code { get; set; }

            [JsonProperty("District_Name")]
            public string District_Name { get; set; }

            [JsonProperty("State_Name")]
            public string State_Name { get; set; }
        }


        public class Country_Detail
        {
            [JsonProperty("Country_Id")]
            public int? Country_Id { get; set; }

            [JsonProperty("Country_Name")]
            public string Country_Name { get; set; }

            [JsonProperty("ISO_Country_Code")]
            public string ISO_Country_Code { get; set; }

            [JsonProperty("Country_Code")]
            public string Country_Code { get; set; }

        }


        public class State_Detail
        {
            [JsonProperty("State_Id")]
            public int? State_Id { get; set; }

            [JsonProperty("State_Name")]
            public string State_Name { get; set; }

            [JsonProperty("CountryRegCode")]
            public Int64? CountryRegCode { get; set; }

            [JsonProperty("ZOCode")]
            public Int64? ZOCode { get; set; }

            [JsonProperty("StateShortName")]
            public string StateShortName { get; set; }

            [JsonProperty("StateCode")]
            public Int64? StateCode { get; set; }

        }

        public class Zones_Detail
        {
            [JsonProperty("Zone_Id")]
            public int? Zone_Id { get; set; }

            [JsonProperty("Zone_Name")]
            public string Zone_Name { get; set; }

            [JsonProperty("Zone_ERPcode")]
            public string Zone_ERPcode { get; set; }

            [JsonProperty("Zone_Code")]
            public string Zone_Code { get; set; }

            [JsonProperty("Zone_Short_Name")]
            public string Zone_Short_Name { get; set; }

        }

        public class City_Detail
        {
            [JsonProperty("City_Id")]
            public int? City_Id { get; set; }

            [JsonProperty("City_Name")]
            public string City_Name { get; set; }

            [JsonProperty("State_Code")]
            public Int64? State_Code { get; set; }

            [JsonProperty("CityShortName")]
            public string CityShortName { get; set; }

            [JsonProperty("DistrictName")]
            public string DistrictName { get; set; }

            [JsonProperty("DistrictCode")]
            public Int64? DistrictCode { get; set; }

            [JsonProperty("CityCode")]
            public Int64? CityCode { get; set; }
        }

        public class Zonal_Office
        {
            [JsonProperty("ZO_Code")]
            public Int64? ZO_Code { get; set; }

            [JsonProperty("ZO_Name")]
            public string ZO_Name { get; set; }

            [JsonProperty("ZO_ShortName")]
            public string ZO_ShortName { get; set; }

            [JsonProperty("ZO_ERPCode")]
            public string ZO_ERPCode { get; set; }

            [JsonProperty("Country_Reg_Code")]
            public string Country_Reg_Code { get; set; }

        }

        public class SBU_Detail
        {
            [JsonProperty("SBU_Id")]
            public Int64? SBU_Id { get; set; }

            [JsonProperty("SBU_Name")]
            public string SBU_Name { get; set; }
        }

        public class Entity_Types
        {
            [JsonProperty("Entity_Type_Id")]
            public Int64? Entity_Type_Id { get; set; }

            [JsonProperty("Status_Id")]
            public Int64? Status_Id { get; set; }

            [JsonProperty("Status_Name")]
            public string Status_Name { get; set; }

            [JsonProperty("Status_Code")]
            public string Status_Code { get; set; }

            [JsonProperty("Status_Description")]
            public string Status_Description { get; set; }

            [JsonProperty("Entity_Status_Id")]
            public string Entity_Status_Id { get; set; }
        }


        public class All_Roll_Detail
        {
            [JsonProperty("Role_Id")]
            public int? Role_Id { get; set; }

            [JsonProperty("Role_Name")]
            public string Role_Name { get; set; }

            [JsonProperty("Role_Description")]
            public string Role_Description { get; set; }

            [JsonProperty("Group_Id")]
            public Int64? Group_Id { get; set; }

            [JsonProperty("Group_Name")]
            public string Group_Name { get; set; }

            [JsonProperty("Is_Aggregator_Role")]
            public Int64? Is_Aggregator_Role { get; set; }
        }

        public class District
        {
            [JsonProperty("District_Code")]
            public Int64? District_Code { get; set; }

            [JsonProperty("District_Name")]
            public string District_Name { get; set; }

            [JsonProperty("State_Name")]
            public string State_Name { get; set; }

            [JsonProperty("District_Short_Name")]
            public string District_Short_Name { get; set; }

            [JsonProperty("City_Code")]
            public Int64? City_Code { get; set; }

            [JsonProperty("RO_Code")]
            public Int64? RO_Code { get; set; }

            [JsonProperty("State_Code")]
            public Int64? State_Code { get; set; }
        }

        public class Default_Values_Card
        {
            [JsonProperty("Default_id")]
            public Int64? Default_id { get; set; }

            [JsonProperty("Default_name")]
            public string Default_name { get; set; }

            [JsonProperty("Default_value")]
            public string Default_value { get; set; }

            [JsonProperty("Default_type")]
            public string Default_type { get; set; }
        }

        public class All_HQZone_Mapping
        {
            [JsonProperty("HO_Code")]
            public Int64? HO_Code { get; set; }

            [JsonProperty("HO_Name")]
            public string HO_Name { get; set; }

            [JsonProperty("HO_Short_Name")]
            public string HO_Short_Name { get; set; }

            [JsonProperty("Zone_Id")]
            public int? Zone_Id { get; set; }

            [JsonProperty("Zone_name")]
            public string Zone_name { get; set; }
        }


        public class Head_Offices
        {
            [JsonProperty("HO_Code")]
            public Int64? HO_Code { get; set; }

            [JsonProperty("HO_Name")]
            public string HO_Name { get; set; }

            [JsonProperty("HO_Short_Name")]
            public string HO_Short_Name { get; set; }
        }

        public class Settings_Output
        {
            [JsonProperty("Status")]
            public int? Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }


        public class SettingsZOInput
        {

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("ZO_Code")]
            public int? ZO_Code { get; set; }

            [JsonProperty("ZO_Name")]
            public string ZO_Name { get; set; }

            [JsonProperty("ZO_Short_Name")]
            public string ZO_Short_Name { get; set; }

            [JsonProperty("ZO_ERP_Code")]
            public string ZO_ERP_Code { get; set; }

            [JsonProperty("State_Id")]
            public int? State_Id { get; set; }

            [JsonProperty("E_D_Status")]
            public int? E_D_Status { get; set; }
        }

        public class Regional_Office
        {
            [JsonProperty("RO_Code")]
            public Int64? RO_Code { get; set; }

            [JsonProperty("RO_Name")]
            public string RO_Name { get; set; }

            [JsonProperty("RO_Short_Name")]
            public string RO_Short_Name { get; set; }

            [JsonProperty("RO_ERP_Code")]
            public string RO_ERP_Code { get; set; }

            [JsonProperty("ZO_Code")]
            public Int64? ZO_Code { get; set; }


            [JsonProperty("HO_Code")]
            public Int64? HO_Code { get; set; }

            [JsonProperty("District_Code")]
            public Int64? District_Code { get; set; }

            
        }

        public class Regional_Office_Input
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

            [JsonProperty("RO_Code")]
            public Int64? RO_Code { get; set; }

            [JsonProperty("RO_Name")]
            public string RO_Name { get; set; }

            [JsonProperty("RO_Short_Name")]
            public string RO_Short_Name { get; set; }

            [JsonProperty("RO_ERP_Code")]
            public string RO_ERP_Code { get; set; }

            [JsonProperty("ZO_Code")]
            public Int64? ZO_Code { get; set; }


            [JsonProperty("HO_Code")]
            public Int64? HO_Code { get; set; }

            [JsonProperty("District_Code")]
            public Int64? District_Code { get; set; }

            [JsonProperty("E_D_Status")]
            public int? E_D_Status { get; set; }

        }


        public class State_Enable_Disable_Input
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

            [JsonProperty("State_Code")]
            public Int64? State_Code { get; set; }

            [JsonProperty("E_D_Status")]
            public int? E_D_Status { get; set; }

        }

        public class State_Input
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

            //[JsonProperty("State_Id")]
            //public int State_Id { get; set; }

            [JsonProperty("State_Name")]
            public string State_Name { get; set; }

            [JsonProperty("State_Code")]
            public Int64? State_Code { get; set; }

            [JsonProperty("State_Short_Name")]
            public string State_Short_Name { get; set; }

            [JsonProperty("Country_Reg_Code")]
            public Int64? Country_Reg_Code { get; set; }

            [JsonProperty("ZO_Code")]
            public Int64? ZO_Code { get; set; }

            //[JsonProperty("E_D_Status")]
            //public int E_D_Status { get; set; }

        }

        public class District_Input
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

            [JsonProperty("District_Code")]
            public Int64? District_Code { get; set; }

            [JsonProperty("District_Name")]
            public string District_Name { get; set; }

            [JsonProperty("District_Short_Name")]
            public string District_Short_Name { get; set; }

            [JsonProperty("City_Code")]
            public Int64? City_Code { get; set; }

            [JsonProperty("State_Code")]
            public Int64? State_Code { get; set; }

            [JsonProperty("RO_Code")]
            public Int64? RO_Code { get; set; }

            //[JsonProperty("E_D_Status")]
            //public int E_D_Status { get; set; }

        }


        public class District_Enable_Disable_Input
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

            [JsonProperty("District_Code")]
            public Int64? District_Code { get; set; }

            [JsonProperty("E_D_Status")]
            public int? E_D_Status { get; set; }

        }

        public class City_Input
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

            [JsonProperty("City_Id")]
            public int? City_Id { get; set; }

            [JsonProperty("City_Name")]
            public string City_Name { get; set; }

            [JsonProperty("City_Code")]
            public Int64? City_Code { get; set; }

            [JsonProperty("City_Short_Name")]
            public string City_Short_Name { get; set; }

            [JsonProperty("District_Code")]
            public Int64? District_Code { get; set; }

            [JsonProperty("State_Code")]
            public Int64? State_Code { get; set; }

            [JsonProperty("E_D_Status")]
            public int? E_D_Status { get; set; }

        }

        public class Entity_Type_Input
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

            [JsonProperty("Entity_Type")]
            public string Entity_Type { get; set; }

            [JsonProperty("Entity_Id")]
            public Int64? Entity_Id { get; set; }

            [JsonProperty("Action")]
            public string Action { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }

            [JsonProperty("Remarks")]
            public string Remarks { get; set; }

            [JsonProperty("Report_Check_Status")]
            public int? Report_Check_Status { get; set; }

            [JsonProperty("From_Date")]
            public string From_Date { get; set; }

            [JsonProperty("To_Date")]
            public string To_Date { get; set; }

        }


        public class Entity_Type_Output
        {

            [JsonProperty("Entity_Type")]
            public string Entity_Type { get; set; }

            [JsonProperty("Entity_Id")]
            public string Entity_Id { get; set; }

            [JsonProperty("Hotlist_Reactivate_Start_Date")]
            public DateTime Hotlist_Reactivate_Start_Date { get; set; }

            [JsonProperty("Action")]
            public string Action { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }

            [JsonProperty("Remarks")]
            public string Remarks { get; set; }

             

        }

        public class Merchant_Type
        {
            [JsonProperty("Merchant_Type_Id")]
            public int? Merchant_Type_Id { get; set; }

            [JsonProperty("Merchant_Type_Name")]
            public string Merchant_Type_Name { get; set; }
        }

        public class Vehicle_Type
        {
            [JsonProperty("Entity_Group")]
            public string Entity_Group { get; set; }

            [JsonProperty("Type_Id")]
            public string Type_Id { get; set; }

            [JsonProperty("Type_Name")]
            public string Type_Name { get; set; }
        }

        public class Proof_Type
        {
            [JsonProperty("Proof_Type_Id")]
            public Int64? Proof_Type_Id { get; set; }

            [JsonProperty("Proof_Type_Name")]
            public string Proof_Type_Name { get; set; }
           
        }


        public class Regional_office_details_Input
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

            [JsonProperty("Zone_code")]
            public Int64? Zone_code { get; set; }
        }


    }

}
