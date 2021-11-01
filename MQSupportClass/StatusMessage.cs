

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HPCL_DP_Terminal.MQSupportClass
{
    public class StatusMessage
    { 
        public enum StatusInformation
        {
            [Display(Name = "Record Found")] Success = 1000,
            [Display(Name = "Record Not Found")] Fail = 1001,
            [Display(Name = "API Key and Secret Key is null.Please Pass API Key and Secret Key")] API_Key_Secret_Key_Is_Null = 1002,
            [Display(Name = "API Key is Null.Please Pass API Key")] API_Key_Is_Null = 1003,
            [Display(Name = "Secret Key is Null.Please pass Secret Key")] Secret_Key_Is_Null = 1004,
            [Display(Name = "Please Try Again")] Internel_Error = 1005,
            [Display(Name = "API Key or Secret Key is Invalid")] API_Key_Is_Secret_Key_Invalid = 1006,
            [Display(Name = "API Key is Invalid")] API_Key_Is_Invalid = 1007,
            [Display(Name = "Secret Key is Invalid")] Secret_Key_Is_Invalid = 1008,
            [Display(Name = "Exception Code")] Exception_Code = 1009,
            [Display(Name = "Enter 10 Digit Mobile Number")] Enter_10_Digit_Mobile_Number = 1010,
            [Display(Name = "Non Numeric Value")] Non_Numeric_Value = 1011,
            [Display(Name = "Mobile Number Start With 6,7,8,9")] Mobile_Number_Start_With_6_7_8_9 = 1012,
            [Display(Name = "Mobile Number Card Already Exists")] Mobile_Number_Card_Already_Exists = 1013,
            [Display(Name = "Customer Id Already Exists")] Customer_Id_Already_Exists = 1014,
            [Display(Name = "Customer Type is Not Match With Our Master")] Customer_Type_Is_Not_Match_With_Our_Master = 1015,
            [Display(Name = "User Agent or User IP or User Id is Null")] User_Agentor_User_IP_User_Id_is_null = 1016,
            [Display(Name = "Request JSON Body Is Null")] Request_JSON_Body_Is_Null = 1017,
            [Display(Name = "Role Created Successfully")] Success_Message_Manage_Role_Creation = 1018,
            [Display(Name = "Role Added or Edited Successfully")] Success_Message_Add_Edit_Manage_Role_Creation = 1019,
            [Display(Name = "HPCL User Location Role Created Successfully")] Success_Message_Hpcl_User_Loc_Role_Creation = 1020,
            [Display(Name = "Admin User Approved Successfully")] Success_Message_Approve_Admin_User = 1021,
            [Display(Name = "Mail Sent Succesfully")] Success_Message_Forgot_Password = 1022,
            [Display(Name = "Logout Successfully")] Success_Message_Change_Password = 1023,
            [Display(Name = "Card Added Successfully")] Success_ADD_CARD = 1024,
            [Display(Name = "Manadatory Feild Required")] Manadatory_Feild_Required = 1025,
            [Display(Name = "Database Response")] Database_Response = 1026,
            [Display(Name = "User was deactivated")] User_deactivate = 1027,
            [Display(Name = "Customer was deactivate")] Customer_deactivate = 1028,
            [Display(Name = "Merchant was deactivate")] Merchant_deactivate = 1029,
            None = int.MaxValue
        }

    }
}