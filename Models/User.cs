using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MQWebAPI.Models
{
    public class User
    {
        public class UserInput
        {
            //[JsonProperty("Username")]
            //public string Username { get; set; }

            [JsonProperty("Password")]
            public string Password { get; set; }

            //[JsonProperty("Email")]
            //public string Email { get; set; }

            [JsonProperty("Secret_Question")]
            public string Secret_Question { get; set; }

            [JsonProperty("Secret_Answer")]
            public string Secret_Answer { get; set; }

            [JsonProperty("Group_Id")]
            public Int64 Group_Id { get; set; }

            [JsonProperty("Group_Name")]
            public string Group_Name { get; set; }

            [JsonProperty("Zonal_Office")]
            public Int64 Zonal_Office { get; set; }

            [JsonProperty("Regional_Office")]
            public Int64 Regional_Office { get; set; }

            [JsonProperty("Customer_Type_Id")]
            public Int64 Customer_Type_Id { get; set; }

            [JsonProperty("Customer_SubType_Id")]
            public Int64 Customer_SubType_Id { get; set; }

            [JsonProperty("SalesArea")]
            public string SalesArea { get; set; }

            [JsonProperty("Form_Number")]
            public Int64 Form_Number { get; set; }

            [JsonProperty("Application_Date")]
            public DateTime Application_Date { get; set; }

            [JsonProperty("Signed_On")]
            public DateTime Signed_On { get; set; }

            [JsonProperty("Individual_Name")]
            public string Individual_Name { get; set; }

            [JsonProperty("Org_Name")]
            public string Org_Name { get; set; }

            [JsonProperty("Title")]
            public string Title { get; set; }

            [JsonProperty("Name_On_Card")]
            public string Name_On_Card { get; set; }

            [JsonProperty("Usage_Type")]
            public string Usage_Type { get; set; }

            [JsonProperty("Type_of_Business_Entity")]
            public string Type_of_Business_Entity { get; set; }

            [JsonProperty("Residence_Status")]
            public string Residence_Status { get; set; }

            [JsonProperty("Income_Tax_PAN")]
            public string Income_Tax_PAN { get; set; }

            [JsonProperty("Comm_Address1")]
            public string Comm_Address1 { get; set; }

            [JsonProperty("Comm_Address2")]
            public string Comm_Address2 { get; set; }

            [JsonProperty("Comm_Address3")]
            public string Comm_Address3 { get; set; }

            [JsonProperty("Comm_Location")]
            public string Comm_Location { get; set; }

            [JsonProperty("Comm_City")]
            public Int64 Comm_City { get; set; }

            [JsonProperty("Comm_PIN_Code")]
            public Int64 Comm_PIN_Code { get; set; }

            [JsonProperty("Comm_State")]
            public Int64 Comm_State { get; set; }

            [JsonProperty("Comm_District")]
            public Int64 Comm_District { get; set; }

            [JsonProperty("Comm_Std_Code")]
            public Int64 Comm_Std_Code { get; set; }

            [JsonProperty("Comm_Ph_Office")]
            public Int64 Comm_Ph_Office { get; set; }

            [JsonProperty("Comm_Mobile")]
            public Int64 Comm_Mobile { get; set; }

            [JsonProperty("Comm_Email")]
            public string Comm_Email { get; set; }

            [JsonProperty("Comm_Fax")]
            public Int64 Comm_Fax { get; set; }

            [JsonProperty("Perm_Address1")]
            public string Perm_Address1 { get; set; }

            [JsonProperty("Perm_Address2")]
            public string Perm_Address2 { get; set; }

            [JsonProperty("Perm_Address3")]
            public string Perm_Address3 { get; set; }

            [JsonProperty("Perm_Location")]
            public string Perm_Location { get; set; }

            [JsonProperty("Perm_City")]
            public Int64 Perm_City { get; set; }

            [JsonProperty("Perm_PIN_Code")]
            public Int64 Perm_PIN_Code { get; set; }

            [JsonProperty("Perm_State")]
            public Int64 Perm_State { get; set; }

            [JsonProperty("Perm_District")]
            public Int64 Perm_District { get; set; }

            [JsonProperty("Perm_Std_Code")]
            public Int64 Perm_Std_Code { get; set; }

            [JsonProperty("Perm_Ph_Office")]
            public Int64 Perm_Ph_Office { get; set; }

            [JsonProperty("Perm_Fax")]
            public Int64 Perm_Fax { get; set; }

            [JsonProperty("Area_Of_Operation")]
            public string Area_Of_Operation { get; set; }

            [JsonProperty("Number_Of_HCV_Owned")]
            public Int64 Number_Of_HCV_Owned { get; set; }

            [JsonProperty("Number_Of_HCV_Operated")]
            public Int64 Number_Of_HCV_Operated { get; set; }

            [JsonProperty("Number_Of_LCV_Owned")]
            public Int64 Number_Of_LCV_Owned { get; set; }

            [JsonProperty("Number_Of_LCV_Operated")]
            public Int64 Number_Of_LCV_Operated { get; set; }

            [JsonProperty("Number_Of_MUVSUV_Owned")]
            public Int64 Number_Of_MUVSUV_Owned { get; set; }

            [JsonProperty("Number_Of_MUVSUV_Operated")]
            public Int64 Number_Of_MUVSUV_Operated { get; set; }

            [JsonProperty("Number_Of_CarJeep_Owned")]
            public Int64 Number_Of_CarJeep_Owned { get; set; }

            [JsonProperty("Number_Of_CarJeep_Operated")]
            public Int64 Number_Of_CarJeep_Operated { get; set; }

            [JsonProperty("Fleet_Size")]
            public string Fleet_Size { get; set; }

            [JsonProperty("Type_Of_Fleet")]
            public string Type_Of_Fleet { get; set; }

            [JsonProperty("Number_Of_Card_Applied_For")]
            public Int64 Number_Of_Card_Applied_For { get; set; }

            [JsonProperty("Approx_Monthly_Spends_On_Fuel")]
            public Int64 Approx_Monthly_Spends_On_Fuel { get; set; }

            [JsonProperty("Approx_Monthly_Spends_On_Lubes")]
            public Int64 Approx_Monthly_Spends_On_Lubes { get; set; }

            [JsonProperty("DMA_Code")]
            public Int64 DMA_Code { get; set; }

            [JsonProperty("DME_Code")]
            public Int64 DME_Code { get; set; }

            [JsonProperty("Promo")]
            public Int64 Promo { get; set; }

            [JsonProperty("Received_Money")]
            public Int64 Received_Money { get; set; }

            [JsonProperty("Number_Of_Vehicles")]
            public Int64 Number_Of_Vehicles { get; set; }

            [JsonProperty("Payment_Mode")]
            public string Payment_Mode { get; set; }

            [JsonProperty("Key_Official_Title")]
            public string Key_Official_Title { get; set; }

            [JsonProperty("Individual_Initials")]
            public string Individual_Initials { get; set; }

            [JsonProperty("First_Name")]
            public string First_Name { get; set; }

            [JsonProperty("Middle_Name")]
            public string Middle_Name { get; set; }

            [JsonProperty("Last_Name")]
            public string Last_Name { get; set; }

            [JsonProperty("Fax")]
            public string Fax { get; set; }

            [JsonProperty("Designation")]
            public string Designation { get; set; }

            [JsonProperty("Key_Official_Std_Code")]
            public Int64 Key_Official_Std_Code { get; set; }

            [JsonProperty("Ph_Office")]
            public Int64 Ph_Office { get; set; }

            [JsonProperty("Date_Of_Anniversary")]
            public DateTime Date_Of_Anniversary { get; set; }

            [JsonProperty("Application_ReceivedOn_Date")]
            public DateTime Application_ReceivedOn_Date { get; set; }

            [JsonProperty("Mobile")]
            public Int64 Mobile { get; set; }

            [JsonProperty("Date_Of_Birth")]
            public DateTime Date_Of_Birth { get; set; }

            [JsonProperty("Bank_Name")]
            public string Bank_Name { get; set; }

            [JsonProperty("Branch_Name")]
            public string Branch_Name { get; set; }

            [JsonProperty("Branch_Code")]
            public string Branch_Code { get; set; }

            [JsonProperty("IFSC")]
            public string IFSC { get; set; }

            [JsonProperty("Bank_Account_No")]
            public Int64 Bank_Account_No { get; set; }

            [JsonProperty("Control_Card_No")]
            public Int64 Control_Card_No { get; set; }

            [JsonProperty("Control_Card_Pin")]
            public Int64 Control_Card_Pin { get; set; }

            [JsonProperty("Employee_No")]
            public string Employee_No { get; set; }

            [JsonProperty("Employee_Name")]
            public string Employee_Name { get; set; }

            [JsonProperty("Owner_Name")]
            public string Owner_Name { get; set; }

            [JsonProperty("Cheque_DD_No")]
            public string Cheque_DD_No { get; set; }

            [JsonProperty("Cheque_DD_Date")]
            public DateTime Cheque_DD_Date { get; set; }

            [JsonProperty("Cheque_Bank")]
            public string Cheque_Bank { get; set; }

            [JsonProperty("FSE_Name")]
            public string FSE_Name { get; set; }

            [JsonProperty("CreatedBy")]
            public string CreatedBy { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            public List<Card_Detail> Obj_Card_Detail { get; set; }

        }
        public class Card_Detail
        {
            [JsonProperty("Vehicle_No")]
            public string Vehicle_No { get; set; }

            [JsonProperty("Vehicle_Type")]
            public string Vehicle_Type { get; set; }

            [JsonProperty("Vehicle_Make")]
            public string Vehicle_Make { get; set; }

            [JsonProperty("Year_Of_Registration")]
            public string Year_Of_Registration { get; set; }
        }

        public class Edit_User_Input
        {
            //[JsonProperty("Username")]
            //public string Username { get; set; }

            [JsonProperty("Customer_id")]
            public Int64 Customer_id { get; set; }

            [JsonProperty("Password")]
            public string Password { get; set; }

            //[JsonProperty("Email")]
            //public string Email { get; set; }

            [JsonProperty("Secret_Question")]
            public string Secret_Question { get; set; }

            [JsonProperty("Secret_Answer")]
            public string Secret_Answer { get; set; }

            [JsonProperty("Group_Id")]
            public Int64 Group_Id { get; set; }

            [JsonProperty("Group_Name")]
            public string Group_Name { get; set; }

            [JsonProperty("Zonal_Office")]
            public Int64 Zonal_Office { get; set; }

            [JsonProperty("Regional_Office")]
            public Int64 Regional_Office { get; set; }

            [JsonProperty("Customer_Type_Id")]
            public Int64 Customer_Type_Id { get; set; }

            [JsonProperty("Customer_SubType_Id")]
            public Int64 Customer_SubType_Id { get; set; }

            [JsonProperty("SalesArea")]
            public string SalesArea { get; set; }

            [JsonProperty("Form_Number")]
            public Int64 Form_Number { get; set; }

            [JsonProperty("Application_Date")]
            public DateTime Application_Date { get; set; }

            [JsonProperty("Signed_On")]
            public DateTime Signed_On { get; set; }

            [JsonProperty("Individual_Name")]
            public string Individual_Name { get; set; }

            [JsonProperty("Org_Name")]
            public string Org_Name { get; set; }

            [JsonProperty("Title")]
            public string Title { get; set; }

            [JsonProperty("Name_On_Card")]
            public string Name_On_Card { get; set; }

            [JsonProperty("Usage_Type")]
            public string Usage_Type { get; set; }

            [JsonProperty("Type_of_Business_Entity")]
            public string Type_of_Business_Entity { get; set; }

            [JsonProperty("Residence_Status")]
            public string Residence_Status { get; set; }

            [JsonProperty("Income_Tax_PAN")]
            public string Income_Tax_PAN { get; set; }

            [JsonProperty("Comm_Address1")]
            public string Comm_Address1 { get; set; }

            [JsonProperty("Comm_Address2")]
            public string Comm_Address2 { get; set; }

            [JsonProperty("Comm_Address3")]
            public string Comm_Address3 { get; set; }

            [JsonProperty("Comm_Location")]
            public string Comm_Location { get; set; }

            [JsonProperty("Comm_City")]
            public Int64 Comm_City { get; set; }

            [JsonProperty("Comm_PIN_Code")]
            public Int64 Comm_PIN_Code { get; set; }

            [JsonProperty("Comm_State")]
            public Int64 Comm_State { get; set; }

            [JsonProperty("Comm_District")]
            public Int64 Comm_District { get; set; }

            [JsonProperty("Comm_Std_Code")]
            public Int64 Comm_Std_Code { get; set; }

            [JsonProperty("Comm_Ph_Office")]
            public Int64 Comm_Ph_Office { get; set; }

            [JsonProperty("Comm_Mobile")]
            public Int64 Comm_Mobile { get; set; }

            [JsonProperty("Comm_Email")]
            public string Comm_Email { get; set; }

            [JsonProperty("Comm_Fax")]
            public Int64 Comm_Fax { get; set; }

            [JsonProperty("Perm_Address1")]
            public string Perm_Address1 { get; set; }

            [JsonProperty("Perm_Address2")]
            public string Perm_Address2 { get; set; }

            [JsonProperty("Perm_Address3")]
            public string Perm_Address3 { get; set; }

            [JsonProperty("Perm_Location")]
            public string Perm_Location { get; set; }

            [JsonProperty("Perm_City")]
            public Int64 Perm_City { get; set; }

            [JsonProperty("Perm_PIN_Code")]
            public Int64 Perm_PIN_Code { get; set; }

            [JsonProperty("Perm_State")]
            public Int64 Perm_State { get; set; }

            [JsonProperty("Perm_District")]
            public Int64 Perm_District { get; set; }

            [JsonProperty("Perm_Std_Code")]
            public Int64 Perm_Std_Code { get; set; }

            [JsonProperty("Perm_Ph_Office")]
            public Int64 Perm_Ph_Office { get; set; }

            [JsonProperty("Perm_Fax")]
            public Int64 Perm_Fax { get; set; }

            [JsonProperty("Area_Of_Operation")]
            public string Area_Of_Operation { get; set; }

            [JsonProperty("Number_Of_HCV_Owned")]
            public Int64 Number_Of_HCV_Owned { get; set; }

            [JsonProperty("Number_Of_HCV_Operated")]
            public Int64 Number_Of_HCV_Operated { get; set; }

            [JsonProperty("Number_Of_LCV_Owned")]
            public Int64 Number_Of_LCV_Owned { get; set; }

            [JsonProperty("Number_Of_LCV_Operated")]
            public Int64 Number_Of_LCV_Operated { get; set; }

            [JsonProperty("Number_Of_MUVSUV_Owned")]
            public Int64 Number_Of_MUVSUV_Owned { get; set; }

            [JsonProperty("Number_Of_MUVSUV_Operated")]
            public Int64 Number_Of_MUVSUV_Operated { get; set; }

            [JsonProperty("Number_Of_CarJeep_Owned")]
            public Int64 Number_Of_CarJeep_Owned { get; set; }

            [JsonProperty("Number_Of_CarJeep_Operated")]
            public Int64 Number_Of_CarJeep_Operated { get; set; }

            [JsonProperty("Fleet_Size")]
            public string Fleet_Size { get; set; }

            [JsonProperty("Type_Of_Fleet")]
            public string Type_Of_Fleet { get; set; }

            [JsonProperty("Number_Of_Card_Applied_For")]
            public Int64 Number_Of_Card_Applied_For { get; set; }

            [JsonProperty("Approx_Monthly_Spends_On_Fuel")]
            public Int64 Approx_Monthly_Spends_On_Fuel { get; set; }

            [JsonProperty("Approx_Monthly_Spends_On_Lubes")]
            public Int64 Approx_Monthly_Spends_On_Lubes { get; set; }

            [JsonProperty("DMA_Code")]
            public Int64 DMA_Code { get; set; }

            [JsonProperty("DME_Code")]
            public Int64 DME_Code { get; set; }

            [JsonProperty("Promo")]
            public Int64 Promo { get; set; }

            [JsonProperty("Received_Money")]
            public Int64 Received_Money { get; set; }

            [JsonProperty("Number_Of_Vehicles")]
            public Int64 Number_Of_Vehicles { get; set; }

            [JsonProperty("Payment_Mode")]
            public string Payment_Mode { get; set; }

            [JsonProperty("Key_Official_Title")]
            public string Key_Official_Title { get; set; }

            [JsonProperty("Individual_Initials")]
            public string Individual_Initials { get; set; }

            [JsonProperty("First_Name")]
            public string First_Name { get; set; }

            [JsonProperty("Middle_Name")]
            public string Middle_Name { get; set; }

            [JsonProperty("Last_Name")]
            public string Last_Name { get; set; }

            [JsonProperty("Fax")]
            public string Fax { get; set; }

            [JsonProperty("Designation")]
            public string Designation { get; set; }

            [JsonProperty("Key_Official_Std_Code")]
            public Int64 Key_Official_Std_Code { get; set; }

            [JsonProperty("Ph_Office")]
            public Int64 Ph_Office { get; set; }

            [JsonProperty("Date_Of_Anniversary")]
            public DateTime Date_Of_Anniversary { get; set; }

            [JsonProperty("Application_ReceivedOn_Date")]
            public DateTime Application_ReceivedOn_Date { get; set; }

            [JsonProperty("Mobile")]
            public Int64 Mobile { get; set; }

            [JsonProperty("Date_Of_Birth")]
            public DateTime Date_Of_Birth { get; set; }

            [JsonProperty("Bank_Name")]
            public string Bank_Name { get; set; }

            [JsonProperty("Branch_Name")]
            public string Branch_Name { get; set; }

            [JsonProperty("Branch_Code")]
            public string Branch_Code { get; set; }

            [JsonProperty("IFSC")]
            public string IFSC { get; set; }

            [JsonProperty("Bank_Account_No")]
            public Int64 Bank_Account_No { get; set; }

            [JsonProperty("Control_Card_No")]
            public Int64 Control_Card_No { get; set; }

            [JsonProperty("Control_Card_Pin")]
            public Int64 Control_Card_Pin { get; set; }

            [JsonProperty("Employee_No")]
            public string Employee_No { get; set; }

            [JsonProperty("Employee_Name")]
            public string Employee_Name { get; set; }

            [JsonProperty("Owner_Name")]
            public string Owner_Name { get; set; }

            [JsonProperty("Cheque_DD_No")]
            public string Cheque_DD_No { get; set; }

            [JsonProperty("Cheque_DD_Date")]
            public DateTime Cheque_DD_Date { get; set; }

            [JsonProperty("Cheque_Bank")]
            public string Cheque_Bank { get; set; }

            [JsonProperty("FSE_Name")]
            public string FSE_Name { get; set; }

            [JsonProperty("CreatedBy")]
            public string CreatedBy { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            public List<Card_Detail> Obj_Card_Detail { get; set; }

        }

        public class ReturnCustomerRegistrationStatusOutput
        {
            [JsonProperty("Success")]
            public bool Success { get; set; }

            [JsonProperty("Message")]
            public string Message { get; set; }

            [JsonProperty("Status_Code")]
            public Int64 Status_Code { get; set; }

            [JsonProperty("Method_Name")]
            public string Method_Name { get; set; }

            public User_Info Data { get; set; }


        }
        public class User_Info
        {

            [JsonProperty("First_Name")]
            public string First_Name { get; set; }

            [JsonProperty("Last_Name")]
            public string Last_Name { get; set; }

            [JsonProperty("User_Email")]
            public string User_Email { get; set; }


            [JsonProperty("User_Mobile")]
            public Int64 User_Mobile { get; set; }


            [JsonProperty("DOB")]
            public DateTime DOB { get; set; }


            [JsonProperty("Pincode")]
            public Int64 Pincode { get; set; }

            [JsonProperty("User_Token")]
            public string User_Token { get; set; }

            [JsonProperty("User_Refferal_Code")]
            public string User_Refferal_Code { get; set; }

            [JsonProperty("Unique_No")]
            public string Unique_No { get; set; }

        }
        public class Input_Detail
        {

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }
        public class Get_Pending_Input_Detail
        {

            [JsonProperty("Statusflag")]
            public string Statusflag { get; set; }

            [JsonProperty("CreatedBy")]
            public string CreatedBy { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }
        public class Input_Manage_Role
        {
            [JsonProperty("User_Name")]
            public string User_Name { get; set; }

            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("Password")]
            public string Password { get; set; }

            [JsonProperty("Secret_Question")]
            public string Secret_Question { get; set; }

            [JsonProperty("Secret_Answer")]
            public string Secret_Answer { get; set; }

            [JsonProperty("Role_Id")]
            public int Role_Id { get; set; }

            [JsonProperty("HQ_Id")]
            public int HQ_Id { get; set; }

            [JsonProperty("Zone_Id")]
            public int Zone_Id { get; set; }

            [JsonProperty("Region_Id")]
            public int Region_Id { get; set; }

            [JsonProperty("Firstname")]
            public string Firstname { get; set; }

            [JsonProperty("Lastname")]
            public string Lastname { get; set; }

            [JsonProperty("Mobileno")]
            public string Mobileno { get; set; }

            [JsonProperty("Id_proof")]
            public string Id_proof { get; set; }

            [JsonProperty("Id_proof_number")]
            public string Id_proof_number { get; set; }
            /*
            [JsonProperty("Id_proof_image")]
            public IFormFile Id_proof_image { get; set; }*/

            [JsonProperty("Address_proof")]
            public string Address_proof { get; set; }

            [JsonProperty("Address_proof_number")]
            public string Address_proof_number { get; set; }
            /*
            [JsonProperty("Address_proof_image")]
            public IFormFile Address_proof_image { get; set; }*/

            [JsonProperty("RBE_Id")]
            public string RBE_Id { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty]
            public string Userid { get; set; }
        }
        public class Output_Manage_Role
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }
        public class Input_Add_Edit_Manage_Role
        {

            [JsonProperty("Role_Id")]
            public int Role_Id { get; set; }

            [JsonProperty("Page_Name")]
            public string Page_Name { get; set; }

            [JsonProperty("View_Permission")]
            public string View_Permission { get; set; }

            [JsonProperty("Add_Permission")]
            public string Add_Permission { get; set; }

            [JsonProperty("Update_Permission")]
            public string Update_Permission { get; set; }

            [JsonProperty("Delete_Permission")]
            public string Delete_Permission { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

        }
        public class Output_Add_Edit_Manage_Role
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }

        }
        public class Input_Hpcl_User_Loc_Role
        {

            [JsonProperty("First_Name")]
            public string First_Name { get; set; }

            [JsonProperty("Middle_Name")]
            public string Middle_Name { get; set; }

            [JsonProperty("Last_Name")]
            public string Last_Name { get; set; }

            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("Comment")]
            public string Comment { get; set; }

            [JsonProperty("Role_Id")]
            public int Role_Id { get; set; }

            [JsonProperty("HQ_Id")]
            public int HQ_Id { get; set; }

            [JsonProperty("Zone_Id")]
            public int Zone_Id { get; set; }

            [JsonProperty("Region_Id")]
            public int Region_Id { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }
        public class Output_Hpcl_User_Loc_Role
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }

        }
        public class Input_KYC_Detail_By_User
        {

            [JsonProperty("Admin_Id")]
            public int Admin_Id { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }
        public class Input_Approve_Admin_User
        {
            [JsonProperty("username")]
            public int Username { get; set; }

            [JsonProperty("Comments")]
            public string Comments { get; set; }

            [JsonProperty("Approvalstatus")]
            public string Approvalstatus { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }
        public class Output_Approve_Admin_User 
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }

        }
        public class ReturnManageRoleOutput
        {
            [JsonProperty("Success")]
            public bool Success { get; set; }

            [JsonProperty("Message")]
            public string Message { get; set; }

            [JsonProperty("Status_Code")]
            public Int64 Status_Code { get; set; }

            [JsonProperty("Method_Name")]
            public string Method_Name { get; set; }

        }
        public class GetPendingUserList_Output
        {
            [JsonProperty("Address")]
            public string Address { get; set; }

            [JsonProperty("FirstName")]
            public string FirstName { get; set; }

            [JsonProperty("UserName")]
            public string UserName { get; set; }

            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("Mobileno")]
            public string Mobileno { get; set; }

            [JsonProperty("RefNo")]
            public string RefNo { get; set; }

            [JsonProperty("FormNo")]
            public string FormNo { get; set; }

            [JsonProperty("CustomerType")]
            public string CustomerType { get; set; }

            [JsonProperty("MakerComment")]
            public string MakerComment { get; set; }

            [JsonProperty("RequestedOn")]
            public DateTime RequestedOn { get; set; }

            [JsonProperty("RequestedBy")]
            public string RequestedBy { get; set; }
        }
        public class ReturnKYCDetailUserListOutput
        {
            [JsonProperty("Success")]
            public bool Success { get; set; }

            [JsonProperty("Message")]
            public string Message { get; set; }

            [JsonProperty("Status_Code")]
            public Int64 Status_Code { get; set; }

            [JsonProperty("Method_Name")]
            public string Method_Name { get; set; }

            public List<KYCDetailUserList> KYC__Detail_User_List = new List<KYCDetailUserList>();
        }
        public class KYCDetailUserList
        {
            [JsonProperty("Role")]
            public string Role { get; set; }

            [JsonProperty("Location")]
            public string Location { get; set; }

            [JsonProperty("POIProof")]
            public string POIProof { get; set; }

            [JsonProperty("POI_Document_No")]
            public string POI_Document_No { get; set; }

            [JsonProperty("POI_Front_Photo")]
            public string POI_Front_Photo { get; set; }

            [JsonProperty("POI_Back_Photo")]
            public string POI_Back_Photo { get; set; }

            [JsonProperty("POAProof")]
            public string POAProof { get; set; }

            [JsonProperty("POA_Document_No")]
            public string POA_Document_No { get; set; }

            [JsonProperty("POA_Front_Photo")]
            public string POA_Front_Photo { get; set; }

            [JsonProperty("POA_Back_Photo")]
            public string POA_Back_Photo { get; set; }
        }
        public class CheckFormNoInput
        {
            [JsonProperty("FormNo")]
            public int FormNo { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

        }
        public class CheckFormNoOutput
        {
            public string Value { get; set; }
        }
        public class UpdateEmail_Input
        {
            [JsonProperty("Username")]
            public int Username { get; set; }

            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }
        public class UpdateEmail_Output
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }
        public class DisableUser_Input
        {
            [JsonProperty("Username")]
            public int Username { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }
        public class DisableUser_Output
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }

        }
        public class SearchUserInput
        {

            [JsonProperty("Username")]
            public Int64? Username { get; set; }

            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("Lastlogindate")]
            public string Lastlogindate { get; set; }

            [JsonProperty("Userrole")]
            public string Userrole { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }


        }
        public class SearchUserOutput
        {

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("Lastlogindate")]
            public DateTime? Lastlogindate { get; set; }

            [JsonProperty("Userrole")]
            public string Userrole { get; set; }

        }

        public class AddCardInput
        {

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Username")]
            public Int64? Username { get; set; }

            [JsonProperty("Customerrefno")]
            public string Customerrefno { get; set; }

            [JsonProperty("Mobile_No")]
            public Int64? Mobile_No { get; set; }

            [JsonProperty("Customername")]
            public string Customername { get; set; }

            [JsonProperty("Name_As_On_Card")]
            public string Name_As_On_Card { get; set; }

            [JsonProperty("No_Of_Card")]
            public string No_Of_Card { get; set; }

            [JsonProperty("Card_Type")]
            public string Card_Type { get; set; }

            [JsonProperty("Card_Type_Status")]
            public string Card_Type_Status { get; set; }

            [JsonProperty("Createdby")]
            public string Createdby { get; set; }

            [JsonProperty("Payment_Type")]
            public string Payment_Type { get; set; }


            public List<Add_Card_Detail> Obj_Card_Detail { get; set; }
        }
        public class Add_Card_Detail
        {

            [JsonProperty("Vehicle_No")]
            public string Vehicle_No { get; set; }

            [JsonProperty("Vehicle_Type")]
            public string Vehicle_Type { get; set; }

            [JsonProperty("Vehicle_Year_Registration")]
            public int? Vehicle_Year_Registration { get; set; }

            [JsonProperty("Vehicle_Manufacturer")]
            public string Vehicle_Manufacturer { get; set; }

            [JsonProperty("Issue_Date")]
            public DateTime Issue_Date { get; set; }

            [JsonProperty("Expiry_Date")]
            public DateTime Expiry_Date { get; set; }
        }
        public class AddCardOutput
        {

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("Lastlogindate")]
            public string Lastlogindate { get; set; }

            [JsonProperty("Userrole")]
            public string Userrole { get; set; }

        }
        public class UploadRcDoc_Input
        {
            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Refno")]
            public string Refno { get; set; }

            [JsonProperty("Addressidproof")]
            public string Addressidproof { get; set; }

            [JsonProperty("Filename")]
            public string Filename { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }
        public class UploadRcDoc_Output
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }
        public class TrackApplicationForm_Input
        {

            [JsonProperty("Username")]
            public Int64 Username { get; set; }

            [JsonProperty("FormNo")]
            public Int64 FormNo { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }


        }
        public class TrackApplicationForm_Output
        {

            [JsonProperty("FormNo")]
            public string FormNo { get; set; }

            [JsonProperty("Finalstatus")]
            public int? Finalstatus { get; set; }

        }
        public class SearchCustomerProfile_Input
        {
            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Name_On_Card")]
            public string Name_On_Card { get; set; }

            [JsonProperty("CustomerType")]
            public string CustomerType { get; set; }

            [JsonProperty("Customersubtype")]
            public string Customersubtype { get; set; }

            [JsonProperty("Groupid")]
            public int? Groupid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }
        public class SearchCustomerProfile_Output
        {


            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }

            [JsonProperty("Customer_id")]
            public string Customer_id { get; set; }

            [JsonProperty("Password")]
            public string Password { get; set; }

            //[JsonProperty("Email")]
            //public string Email { get; set; }

            [JsonProperty("Secret_Question")]
            public string Secret_Question { get; set; }

            [JsonProperty("Secret_Answer")]
            public string Secret_Answer { get; set; }

            [JsonProperty("Group_Id")]
            public string Group_Id { get; set; }

            [JsonProperty("Group_Name")]
            public string Group_Name { get; set; }

            [JsonProperty("Zonal_Office")]
            public string Zonal_Office { get; set; }

            [JsonProperty("Regional_Office")]
            public string Regional_Office { get; set; }

            [JsonProperty("Customer_Type_Id")]
            public string Customer_Type_Id { get; set; }

            [JsonProperty("Customer_SubType_Id")]
            public string Customer_SubType_Id { get; set; }

            [JsonProperty("SalesArea")]
            public string SalesArea { get; set; }

            [JsonProperty("Form_Number")]
            public string Form_Number { get; set; }

            [JsonProperty("Application_Date")]
            public string Application_Date { get; set; }

            [JsonProperty("Signed_On")]
            public string Signed_On { get; set; }

            [JsonProperty("Individual_Name")]
            public string Individual_Name { get; set; }

            [JsonProperty("Org_Name")]
            public string Org_Name { get; set; }

            [JsonProperty("Title")]
            public string Title { get; set; }

            [JsonProperty("Name_On_Card")]
            public string Name_On_Card { get; set; }

            [JsonProperty("Usage_Type")]
            public string Usage_Type { get; set; }

            [JsonProperty("Type_of_Business_Entity")]
            public string Type_of_Business_Entity { get; set; }

            [JsonProperty("Residence_Status")]
            public string Residence_Status { get; set; }

            [JsonProperty("Income_Tax_PAN")]
            public string Income_Tax_PAN { get; set; }

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

            [JsonProperty("Comm_PIN_Code")]
            public string Comm_PIN_Code { get; set; }

            [JsonProperty("Comm_State")]
            public string Comm_State { get; set; }

            [JsonProperty("Comm_District")]
            public string Comm_District { get; set; }

            [JsonProperty("Comm_Std_Code")]
            public string Comm_Std_Code { get; set; }

            [JsonProperty("Comm_Ph_Office")]
            public string Comm_Ph_Office { get; set; }

            [JsonProperty("Comm_Mobile")]
            public string Comm_Mobile { get; set; }

            [JsonProperty("Comm_Email")]
            public string Comm_Email { get; set; }

            [JsonProperty("Comm_Fax")]
            public string Comm_Fax { get; set; }

            [JsonProperty("Perm_Address1")]
            public string Perm_Address1 { get; set; }

            [JsonProperty("Perm_Address2")]
            public string Perm_Address2 { get; set; }

            [JsonProperty("Perm_Address3")]
            public string Perm_Address3 { get; set; }

            [JsonProperty("Perm_Location")]
            public string Perm_Location { get; set; }

            [JsonProperty("Perm_City")]
            public string Perm_City { get; set; }

            [JsonProperty("Perm_PIN_Code")]
            public string Perm_PIN_Code { get; set; }

            [JsonProperty("Perm_State")]
            public string Perm_State { get; set; }

            [JsonProperty("Perm_District")]
            public string Perm_District { get; set; }

            [JsonProperty("Perm_Std_Code")]
            public string Perm_Std_Code { get; set; }

            [JsonProperty("Perm_Ph_Office")]
            public string Perm_Ph_Office { get; set; }

            [JsonProperty("Perm_Fax")]
            public string Perm_Fax { get; set; }

            [JsonProperty("Area_Of_Operation")]
            public string Area_Of_Operation { get; set; }

            [JsonProperty("Number_Of_HCV_Owned")]
            public string Number_Of_HCV_Owned { get; set; }

            [JsonProperty("Number_Of_HCV_Operated")]
            public string Number_Of_HCV_Operated { get; set; }

            [JsonProperty("Number_Of_LCV_Owned")]
            public string Number_Of_LCV_Owned { get; set; }

            [JsonProperty("Number_Of_LCV_Operated")]
            public string Number_Of_LCV_Operated { get; set; }

            [JsonProperty("Number_Of_MUVSUV_Owned")]
            public string Number_Of_MUVSUV_Owned { get; set; }

            [JsonProperty("Number_Of_MUVSUV_Operated")]
            public string Number_Of_MUVSUV_Operated { get; set; }

            [JsonProperty("Number_Of_CarJeep_Owned")]
            public string Number_Of_CarJeep_Owned { get; set; }

            [JsonProperty("Number_Of_CarJeep_Operated")]
            public string Number_Of_CarJeep_Operated { get; set; }

            [JsonProperty("Fleet_Size")]
            public string Fleet_Size { get; set; }

            [JsonProperty("Type_Of_Fleet")]
            public string Type_Of_Fleet { get; set; }

            [JsonProperty("Number_Of_Card_Applied_For")]
            public string Number_Of_Card_Applied_For { get; set; }

            [JsonProperty("Approx_Monthly_Spends_On_Fuel")]
            public string Approx_Monthly_Spends_On_Fuel { get; set; }

            [JsonProperty("Approx_Monthly_Spends_On_Lubes")]
            public string Approx_Monthly_Spends_On_Lubes { get; set; }

            [JsonProperty("DMA_Code")]
            public string DMA_Code { get; set; }

            [JsonProperty("DME_Code")]
            public string DME_Code { get; set; }

            [JsonProperty("Promo")]
            public string Promo { get; set; }

            [JsonProperty("Received_Money")]
            public string Received_Money { get; set; }

            [JsonProperty("Number_Of_Vehicles")]
            public string Number_Of_Vehicles { get; set; }

            [JsonProperty("Payment_Mode")]
            public string Payment_Mode { get; set; }

            [JsonProperty("Key_Official_Title")]
            public string Key_Official_Title { get; set; }

            [JsonProperty("Individual_Initials")]
            public string Individual_Initials { get; set; }

            [JsonProperty("First_Name")]
            public string First_Name { get; set; }

            [JsonProperty("Middle_Name")]
            public string Middle_Name { get; set; }

            [JsonProperty("Last_Name")]
            public string Last_Name { get; set; }

            [JsonProperty("Fax")]
            public string Fax { get; set; }

            [JsonProperty("Designation")]
            public string Designation { get; set; }

            [JsonProperty("Key_Official_Std_Code")]
            public string Key_Official_Std_Code { get; set; }

            [JsonProperty("Ph_Office")]
            public string Ph_Office { get; set; }

            [JsonProperty("Date_Of_Anniversary")]
            public string Date_Of_Anniversary { get; set; }

            [JsonProperty("Application_ReceivedOn_Date")]
            public string Application_ReceivedOn_Date { get; set; }

            [JsonProperty("Mobile")]
            public string Mobile { get; set; }

            [JsonProperty("Date_Of_Birth")]
            public string Date_Of_Birth { get; set; }

            [JsonProperty("Bank_Name")]
            public string Bank_Name { get; set; }

            [JsonProperty("Branch_Name")]
            public string Branch_Name { get; set; }

            [JsonProperty("Branch_Code")]
            public string Branch_Code { get; set; }

            [JsonProperty("IFSC")]
            public string IFSC { get; set; }

            [JsonProperty("Bank_Account_No")]
            public string Bank_Account_No { get; set; }

            [JsonProperty("Control_Card_No")]
            public string Control_Card_No { get; set; }

            [JsonProperty("Control_Card_Pin")]
            public string Control_Card_Pin { get; set; }

            [JsonProperty("Employee_No")]
            public string Employee_No { get; set; }

            [JsonProperty("Employee_Name")]
            public string Employee_Name { get; set; }

            [JsonProperty("Owner_Name")]
            public string Owner_Name { get; set; }

            [JsonProperty("Cheque_DD_No")]
            public string Cheque_DD_No { get; set; }

            [JsonProperty("Cheque_DD_Date")]
            public string Cheque_DD_Date { get; set; }

            [JsonProperty("Cheque_Bank")]
            public string Cheque_Bank { get; set; }

            [JsonProperty("FSE_Name")]
            public string FSE_Name { get; set; }

            [JsonProperty("CreatedBy")]
            public string CreatedBy { get; set; }

            [JsonProperty("Comm_State_name")]
            public string Comm_State_name { get; set; }

            [JsonProperty("Comm_District_name")]
            public string Comm_District_name { get; set; }

            [JsonProperty("Perm_State_name")]
            public string Perm_State_name { get; set; }

            [JsonProperty("Perm_District_name")]
            public string Perm_District_name { get; set; }

        }
        public class Operator_Login_Input
        {
            [JsonProperty("Username")]
            public string Username { get; set; }

            [JsonProperty("Password")]
            public string Password { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }
        public class Operator_Login_Output
        {
            [JsonProperty("OutletId")]
            public string OutletId { get; set; }

            [JsonProperty("TID")]
            public string TID { get; set; }

            [JsonProperty("BatchId")]
            public string BatchId { get; set; }
        }
        public class Vechile_Tracking_Input
        {
            [JsonProperty("ZO")]
            public string ZO { get; set; }

            [JsonProperty("RO")]
            public string RO { get; set; }

            [JsonProperty("MerchantId")]
            public string MerchantId { get; set; }

            [JsonProperty("CustomerId")]
            public string CustomerId { get; set; }

            [JsonProperty("VechileNo")]
            public string VechileNo { get; set; }

            [JsonProperty("OnlyVehicleTracking")]
            public string OnlyVehicleTracking { get; set; }

            [JsonProperty("From_Date")]
            public DateTime From_Date { get; set; }

            [JsonProperty("To_Date")]
            public DateTime To_Date { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }
        public class Vechile_Tracking_Output
        {
            [JsonProperty("VehicleNo")]
            public string VehicleNo { get; set; }

            [JsonProperty("MerchantId")]
            public string MerchantId { get; set; }

            [JsonProperty("Merchant")]
            public string Merchant { get; set; }

            [JsonProperty("City")]
            public string City { get; set; }

            [JsonProperty("District")]
            public string District { get; set; }

            [JsonProperty("State")]
            public string State { get; set; }

            [JsonProperty("Amount")]
            public decimal? Amount { get; set; }

            [JsonProperty("TxnDate")]
            public DateTime? TxnDate { get; set; }

            [JsonProperty("OdometerReading")]
            public string OdometerReading { get; set; }

        }
        public class CheckMobileNo_Input
        {
            [JsonProperty("MobileNo")]
            public Int64 MobileNo { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }
        public class CheckMobileNo_Output
        {
            [JsonProperty("IsExist")]
            public bool IsExist { get; set; }

        }
        public class SaveOperatorInfo_Input
        {
            [JsonProperty("OperatorId")]
            public int OperatorId { get; set; }

            [JsonProperty("UserName")]
            public string UserName { get; set; }

            [JsonProperty("Password")]
            public string Password { get; set; }

            [JsonProperty("TerminalId")]
            public Int64 TerminalId { get; set; }

            [JsonProperty("OutletId")]
            public Int64 OutletId { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }
        public class SaveOperatorInfo_Output
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }


        public class View_Pending_Parent_Customer_Approval_Input
        {

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }
        public class View_Pending_Parent_Customer_Approval
        {
            [JsonProperty("Customer_Id")]
            public string Customer_Id { get; set; }

            [JsonProperty("Individual_name")]
            public string Individual_name { get; set; }

            [JsonProperty("Zone_name")]
            public string Zone_name { get; set; }

            [JsonProperty("ROName")]
            public string ROName { get; set; }

            [JsonProperty("City")]
            public string City { get; set; }

            [JsonProperty("Created_On")]
            public string Created_On { get; set; }

            [JsonProperty("Createdby")]
            public string Createdby { get; set; }

        }


        public class Approve_Pending_Parent_Customer_Input
        {
            [JsonProperty("CustomerId")]
            public Int64 CustomerId { get; set; }

            [JsonProperty("Comments")]
            public string Comments { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }
        public class View_pending_parent_customer_authorization_Input
        {

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class View_pending_parent_customer_authorization
        {

            [JsonProperty("customer_id")]
            public string Customer_id { get; set; }

            [JsonProperty("Individual_name")]
            public string Individual_name { get; set; }

            [JsonProperty("Zone_name")]
            public string Zone_name { get; set; }

            [JsonProperty("ROName")]
            public string ROName { get; set; }

            [JsonProperty("City")]
            public string City { get; set; }

            [JsonProperty("Created_On")]
            public string Created_On { get; set; }

            [JsonProperty("createdby")]
            public string Createdby { get; set; }

            [JsonProperty("ApprovedOn")]
            public string ApprovedOn { get; set; }

            [JsonProperty("ApprovedBy")]
            public string ApprovedBy { get; set; }
        }

        public class Authorize_pending_parent_customer_Input
        {
            [JsonProperty("CustomerId")]
            public Int64 CustomerId { get; set; }

            [JsonProperty("Comments")]
            public string Comments { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }


        public class Approve_pending_aggregator_parent_customer_Input
        {
            [JsonProperty("CustomerId")]
            public Int64 CustomerId { get; set; }

            [JsonProperty("Comments")]
            public string Comments { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }
        public class DataInsertion
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }

        public class View_pending_aggregator_parent_customer_approval_Input
        {            

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }
        public class View_pending_aggregator_parent_customer_approval
        {
            [JsonProperty("Customer_id")]
            public string Customer_id { get; set; }

            [JsonProperty("Individual_name")]
            public string Individual_name { get; set; }

            [JsonProperty("Zone_name")]
            public string Zone_name { get; set; }

            [JsonProperty("ROName")]
            public string ROName { get; set; }

            [JsonProperty("City")]
            public string City { get; set; }

            [JsonProperty("Created_On")]
            public string Created_On { get; set; }

            [JsonProperty("Createdby")]
            public string Createdby { get; set; }

        }




        public class View_pending_aggregator_child_customer_verify_approve_Input
        {
            [JsonProperty("State")]
            public int State { get; set; }

            [JsonProperty("FormNo")]
            public string FormNo { get; set; }

            [JsonProperty("CustomerName")]
            public string CustomerName { get; set; }

            [JsonProperty("Mode")]
            public string Mode { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }


        public class View_pending_aggregator_child_customer_verify_approve
        {
            [JsonProperty("FormNo")]
            public int FormNo { get; set; }

            [JsonProperty("Customer_id")]
            public string Customer_id { get; set; }

            [JsonProperty("Customer_name")]
            public string Customer_name { get; set; }

            [JsonProperty("Address")]
            public string Address { get; set; }

            [JsonProperty("Phone_no")]
            public string Phone_no { get; set; }

            [JsonProperty("Mobile_no")]
            public string Mobile_no { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }

        public class Verify_approve_pending_aggregator_child_customer_Input
        {
            [JsonProperty("Customer_Id")]
            public int Customer_Id { get; set; }

            [JsonProperty("Comments")]
            public string Comments { get; set; }           

            [JsonProperty("Mode")]
            public string Mode { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }


        public class Create_OEM_Manager_Role_Input
        {
            [JsonProperty("User_role")]
            public int User_role { get; set; }

            //[JsonProperty("Dealer_code")]
            //public string Dealer_code { get; set; }

            //[JsonProperty("Dealer_name")]
            //public string Dealer_name { get; set; }

            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("Mobile_No")]
            public string Mobile_No { get; set; }

            [JsonProperty("HQ")]
            public string HQ { get; set; }

            [JsonProperty("Zone")]
            public string Zone { get; set; }

            [JsonProperty("Region")]
            public string Region { get; set; }

            [JsonProperty("City")]
            public string City { get; set; }

            [JsonProperty("State")]
            public string State { get; set; }

            //[JsonProperty("District")]
            //public string District { get; set; }

            [JsonProperty("Address1")]
            public string Address1 { get; set; }

            [JsonProperty("Address2")]
            public string Address2 { get; set; }

            [JsonProperty("Address3")]
            public string Address3 { get; set; }

            [JsonProperty("Group_id")]
            public string Group_id { get; set; }

            [JsonProperty("Group_name")]
            public string Group_name { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }

    }
}