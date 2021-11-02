using HPCL_DP_Terminal.App_Start;
using HPCL_DP_Terminal.Helpers;
using HPCL_DP_Terminal.MQSupportClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static HPCL_DP_Terminal.Models.User;
using static HPCL_DP_Terminal.MQSupportClass.StatusMessage;

namespace HPCL_DP_Terminal.Controllers
{
    public class UserController : ApiController
    {
        private readonly Variables ObjVariable = new Variables();
        SqlTransaction Transaction;
        SqlCommand Cmd;
        SqlConnection Sqlcon;
        SqlDataAdapter Adp;
        public DataSet INSERT_CUSTOMER_USER_REGISTRATION(UserInput inputVariables, string API_Unique_No, out string Infomessage, string MethodName)
        {
            DataSet DsData = new DataSet();
            string Info_message = string.Empty;
            try
            {
                Sqlcon = new SqlConnection(CRUD.GetConnection());
                Cmd = new SqlCommand();
                Sqlcon.Open();
                Cmd.Connection = Sqlcon;
                Cmd.CommandText = "Usp_User_Check_Insert";
                Cmd.CommandType = CommandType.StoredProcedure;
                Transaction = Sqlcon.BeginTransaction();
                Cmd.Transaction = Transaction;
                Cmd.Connection = Sqlcon;
                Cmd.CommandText = "Usp_User_Check_Insert";
                Cmd.Parameters.AddWithValue("@Password", inputVariables.Password);
                Cmd.Parameters.AddWithValue("@Secret_Question", inputVariables.Secret_Question);
                Cmd.Parameters.AddWithValue("@Secret_Answer", inputVariables.Secret_Answer);
                Cmd.Parameters.AddWithValue("@Customer_Group_Id", inputVariables.Group_Id);
                Cmd.Parameters.AddWithValue("@Customer_Group_Name", inputVariables.Group_Name);
                Cmd.Parameters.AddWithValue("@ZOCode", inputVariables.Zonal_Office);
                Cmd.Parameters.AddWithValue("@ROCode", inputVariables.Regional_Office);
                Cmd.Parameters.AddWithValue("@Customer_Type_Id", inputVariables.Customer_Type_Id);
                Cmd.Parameters.AddWithValue("@Customer_SubType_Id", inputVariables.Customer_SubType_Id);
                Cmd.Parameters.AddWithValue("@SalesArea", inputVariables.SalesArea);
                Cmd.Parameters.AddWithValue("@Form_Id", inputVariables.Form_Number);
                Cmd.Parameters.AddWithValue("@Application_Date", inputVariables.Application_Date);
                Cmd.Parameters.AddWithValue("@Signed_On", inputVariables.Signed_On);
                Cmd.Parameters.AddWithValue("@Individual_Name", inputVariables.Individual_Name);
                Cmd.Parameters.AddWithValue("@Org_Name", inputVariables.Org_Name);
                Cmd.Parameters.AddWithValue("@Title", inputVariables.Title);
                Cmd.Parameters.AddWithValue("@Name_On_Card", inputVariables.Name_On_Card);
                Cmd.Parameters.AddWithValue("@Usage_Type", inputVariables.Usage_Type);
                Cmd.Parameters.AddWithValue("@Type_of_Business_Entity", inputVariables.Type_of_Business_Entity);
                Cmd.Parameters.AddWithValue("@Residence_Status", inputVariables.Residence_Status);
                Cmd.Parameters.AddWithValue("@Income_Tax_PAN", inputVariables.Income_Tax_PAN);
                Cmd.Parameters.AddWithValue("@floor_flat", inputVariables.Comm_Address1);
                Cmd.Parameters.AddWithValue("@building", inputVariables.Comm_Address2);
                Cmd.Parameters.AddWithValue("@street", inputVariables.Comm_Address3);
                Cmd.Parameters.AddWithValue("@Comm_Location", inputVariables.Comm_Location);
                Cmd.Parameters.AddWithValue("@City", inputVariables.Comm_City);
                Cmd.Parameters.AddWithValue("@PostalCode", inputVariables.Comm_PIN_Code);
                Cmd.Parameters.AddWithValue("@state", inputVariables.Comm_State);
                Cmd.Parameters.AddWithValue("@district", inputVariables.Comm_District);
                Cmd.Parameters.AddWithValue("@stdcode", inputVariables.Comm_Std_Code);
                Cmd.Parameters.AddWithValue("@Comm_Ph_Office", inputVariables.Comm_Ph_Office);
                Cmd.Parameters.AddWithValue("@MobileNo", inputVariables.Comm_Mobile);
                Cmd.Parameters.AddWithValue("@Email", inputVariables.Comm_Email);
                Cmd.Parameters.AddWithValue("@fax", inputVariables.Comm_Fax);
                Cmd.Parameters.AddWithValue("@Perm_Address1", inputVariables.Perm_Address1);
                Cmd.Parameters.AddWithValue("@Perm_Address2", inputVariables.Perm_Address2);
                Cmd.Parameters.AddWithValue("@Perm_Address3", inputVariables.Perm_Address3);
                Cmd.Parameters.AddWithValue("@Perm_Location", inputVariables.Perm_Location);
                Cmd.Parameters.AddWithValue("@Perm_City", inputVariables.Perm_City);
                Cmd.Parameters.AddWithValue("@Perm_PINCode", inputVariables.Perm_PIN_Code);
                Cmd.Parameters.AddWithValue("@Perm_State", inputVariables.Perm_State);
                Cmd.Parameters.AddWithValue("@Perm_District", inputVariables.Perm_District);
                Cmd.Parameters.AddWithValue("@Perm_stdcode", inputVariables.Perm_Std_Code);
                Cmd.Parameters.AddWithValue("@Perm_Phoneno", inputVariables.Perm_Ph_Office);
                Cmd.Parameters.AddWithValue("@Perm_Fax", inputVariables.Perm_Fax);
                Cmd.Parameters.AddWithValue("@Area_Of_Operation", inputVariables.Area_Of_Operation);
                Cmd.Parameters.AddWithValue("@Num_of_HCVOwned", inputVariables.Number_Of_HCV_Owned);
                Cmd.Parameters.AddWithValue("@Num_of_HCVOperated", inputVariables.Number_Of_HCV_Operated);
                Cmd.Parameters.AddWithValue("@Num_of_LCVOwned", inputVariables.Number_Of_LCV_Owned);
                Cmd.Parameters.AddWithValue("@Num_of_LCVOperated", inputVariables.Number_Of_LCV_Operated);
                Cmd.Parameters.AddWithValue("@Num_of_MUVSUV_Owned", inputVariables.Number_Of_MUVSUV_Owned);
                Cmd.Parameters.AddWithValue("@Num_of_MUVSUV_Operated", inputVariables.Number_Of_MUVSUV_Operated);
                Cmd.Parameters.AddWithValue("@Num_of_CarJeep_Owned", inputVariables.Number_Of_CarJeep_Owned);
                Cmd.Parameters.AddWithValue("@Num_of_CarJeep_Operated", inputVariables.Number_Of_CarJeep_Operated);
                Cmd.Parameters.AddWithValue("@Fleet_Size", inputVariables.Fleet_Size);
                Cmd.Parameters.AddWithValue("@Type_Of_Fleet", inputVariables.Type_Of_Fleet);
                Cmd.Parameters.AddWithValue("@Num_of_Card_applied_for", inputVariables.Number_Of_Card_Applied_For);
                Cmd.Parameters.AddWithValue("@Approx_Monthly_Spends_On_Fuel", inputVariables.Approx_Monthly_Spends_On_Fuel);
                Cmd.Parameters.AddWithValue("@Approx_Monthly_Spends_On_Lubes", inputVariables.Approx_Monthly_Spends_On_Lubes);
                Cmd.Parameters.AddWithValue("@DMA_Code", inputVariables.DMA_Code);
                Cmd.Parameters.AddWithValue("@DME_Code", inputVariables.DME_Code);
                Cmd.Parameters.AddWithValue("@Promo", inputVariables.Promo);
                Cmd.Parameters.AddWithValue("@Received_Money", inputVariables.Received_Money);
                Cmd.Parameters.AddWithValue("@Num_of_vehicles", inputVariables.Number_Of_Vehicles);
                Cmd.Parameters.AddWithValue("@Payment_Mode", inputVariables.Payment_Mode);
                Cmd.Parameters.AddWithValue("@KO_title", inputVariables.Key_Official_Title);
                Cmd.Parameters.AddWithValue("@KO_Indv_initials", inputVariables.Individual_Initials);
                Cmd.Parameters.AddWithValue("@KO_firstname", inputVariables.First_Name);
                Cmd.Parameters.AddWithValue("@KO_middlename", inputVariables.Middle_Name);
                Cmd.Parameters.AddWithValue("@KO_lastname", inputVariables.Last_Name);
                Cmd.Parameters.AddWithValue("@KO_fax", inputVariables.Fax);
                Cmd.Parameters.AddWithValue("@KO_Designation", inputVariables.Designation);
                Cmd.Parameters.AddWithValue("@KO_stdcode", inputVariables.Key_Official_Std_Code);
                Cmd.Parameters.AddWithValue("@KO_phoneno", inputVariables.Ph_Office);
                Cmd.Parameters.AddWithValue("@KO_DOA", inputVariables.Date_Of_Anniversary);
                Cmd.Parameters.AddWithValue("@KO_Appln_ReceivedOn", inputVariables.Application_ReceivedOn_Date);
                Cmd.Parameters.AddWithValue("@KO_Mobileno", inputVariables.Mobile);
                Cmd.Parameters.AddWithValue("@KO_DOB", inputVariables.Date_Of_Birth);
                Cmd.Parameters.AddWithValue("@Bank_Name", inputVariables.Bank_Name);
                Cmd.Parameters.AddWithValue("@Branch_Name", inputVariables.Branch_Name);
                Cmd.Parameters.AddWithValue("@Branch_Code", inputVariables.Branch_Code);
                Cmd.Parameters.AddWithValue("@Branch_IFSC", inputVariables.IFSC);
                Cmd.Parameters.AddWithValue("@Bank_Account_No", inputVariables.Bank_Account_No);
                Cmd.Parameters.AddWithValue("@Control_Card_No", inputVariables.Control_Card_No);
                Cmd.Parameters.AddWithValue("@Control_Card_Pin", inputVariables.Control_Card_Pin);
                Cmd.Parameters.AddWithValue("@Employee_No", inputVariables.Employee_No);
                Cmd.Parameters.AddWithValue("@Employee_Name", inputVariables.Employee_Name);
                Cmd.Parameters.AddWithValue("@Owner_Name", inputVariables.Owner_Name);
                Cmd.Parameters.AddWithValue("@Cheque_DD_No", inputVariables.Cheque_DD_No);
                Cmd.Parameters.AddWithValue("@Cheque_DD_Date", inputVariables.Cheque_DD_Date);
                Cmd.Parameters.AddWithValue("@Cheque_Bank", inputVariables.Cheque_Bank);
                Cmd.Parameters.AddWithValue("@FSE_Name", inputVariables.FSE_Name);
                Cmd.Parameters.AddWithValue("@CreatedBy", inputVariables.CreatedBy);
                Cmd.Parameters.AddWithValue("@Useragent", inputVariables.Useragent);
                Cmd.Parameters.AddWithValue("@Userip", inputVariables.Userip);
                Cmd.Parameters.AddWithValue("@API_Unique_No", API_Unique_No);

                Adp = new SqlDataAdapter(Cmd);
                Cmd.CommandType = CommandType.StoredProcedure;
                Adp.Fill(DsData);
                
                int Count1 = 1;
                int Count2 = 1;
                string SQL_Insert_Card_Details = string.Empty;
                string SQL_Insert_Card_Details_Mapping = string.Empty;
                string Statusflag = DsData.Tables[0].Rows[0]["statusflag"].ToString();
                if (Statusflag == "1" && inputVariables.Customer_Type_Id != 945 && inputVariables.Customer_SubType_Id != 913)
                {
                    string Customer_Id = DsData.Tables[0].Rows[0]["Customer_Id"].ToString();
                    string Card_no = DsData.Tables[0].Rows[0]["Card_no"].ToString();
                    if (inputVariables.Obj_Card_Detail != null)
                    {
                        foreach (var data in inputVariables.Obj_Card_Detail)
                        {
                            string Vehicle_Make = data.Vehicle_Make;
                            string Vehicle_No = data.Vehicle_No;
                            string Vehicle_Type = data.Vehicle_Type;
                            string Year_Of_Registration = data.Year_Of_Registration;

                            SQL_Insert_Card_Details += "exec Usp_User_Insert_Customer_Card_Details @Card_no='" + Card_no + "',@Card_pin='0000',@group_id='" + inputVariables.Group_Id + "',@group_name='" + inputVariables.Group_Name + "',@customer_id='" + Customer_Id + "',@ZOCode='" + inputVariables.Zonal_Office + "',@ROCode='" + inputVariables.Regional_Office
                                + "',@card_type='801',@form_id='" + inputVariables.Form_Number + "',@vehicle_no='" + Vehicle_No + "',@vehicle_type='" + Vehicle_Type
                                + "',@issue_date='',@expiry_date='',@card_status='9',@Vehicle_yr_of_reg='" + Year_Of_Registration + "',@vehicle_manufacturer='" + Vehicle_Make + "',@Card_type_status='0',@mobileno='" + inputVariables.Mobile
                                + "',@vin_no='',@Card_Preference_Type='',@RCDoc='',@Type_of_limit='',@isAttached='0',@Vehicle_tracking='',@CreatedBy='" + inputVariables.CreatedBy + "',@LastModifiedOn='',@LastModifiedBy='',@ExtraParam1='0',@ExtraParam2='0',@ExtraParam3='',@ExtraParam4='',@ExtraParam5='',@ExtraParam6='',@salesArea='" + inputVariables.SalesArea
                                + "',@Activation_date='',@Approved_on='',@ApprovedBy='',@API_Unique_No='" + API_Unique_No + "';";
                        }
                    }

                    if (SQL_Insert_Card_Details.Length > 0)
                    {
                        //CRUD.FunCRUD(SQL_Insert_Card_Details);
                        Count1 = 0;
                        new SqlCommand();
                        Cmd.CommandType = CommandType.Text;
                        Cmd.CommandText = SQL_Insert_Card_Details;
                        Count1 = Convert.ToInt32(Cmd.ExecuteNonQuery());
                    }

                    SQL_Insert_Card_Details_Mapping += "exec Usp_User_Customer_Cardlimit_Mapping @Card_no='" + Card_no + "',@group_id='" + inputVariables.Group_Id + "',@group_name='" + inputVariables.Group_Name
                        + "',@customer_id='" + Customer_Id + "',@SingleTransactionLimit='0',@DailyTransactionLimit='0',@MonthlyTransactionLimit='0',@CCMSUnlimited='0',@CCMSDailyLimit='0',@CCMSMonthlyLimit='0',@CCMSOneTime='0',@CCMSAnnual='0',@DailyCreditLimit='0',@CentralCreditLimit='0',@PetrolLimit='0',@DieselLimit='0',@CNGLimit='0',@Petrol_Diesel_Limit='0',@Petrol_CNG_Limit='0',@Diesel_CNG_Limit='0',@Any_Fuel_Limit='0',@SingleQuantityLimit='0',@DailyQuantityLimit='0',@MonthlyQuantityLimit='0',@OnetimeQuantityLimit='0',@UnlimitedQuantityLimit='0',@CreatedBy='" + inputVariables.CreatedBy
                        + "',@LastModifiedOn='',@LastModifiedBy='',@ExtraParam1='0',@ExtraParam2='0',@ExtraParam3='',@ExtraParam4='',@ExtraParam5='',@ExtraParam6='',@API_Unique_No='" + API_Unique_No + "';";

                    if (SQL_Insert_Card_Details_Mapping.Length > 0)
                    {
                        //CRUD.FunCRUD(SQL_Insert_Card_Details_Mapping);
                        Count2 = 0;
                        new SqlCommand();
                        Cmd.CommandType = CommandType.Text;
                        Cmd.CommandText = SQL_Insert_Card_Details_Mapping;
                        Count2 = Convert.ToInt32(Cmd.ExecuteNonQuery());
                    }

                    if (Count1 > 0 && Count2 > 0)
                    {
                        Cmd.Transaction.Commit();
                    }

                }
                else
                {
                    Cmd.Transaction.Commit();
                }
            }
            catch (Exception EX)
            {
                Cmd.Transaction.Rollback();
                DsData = null;
                Info_message = EX.Message;
                CRUD.InsertAPIEntryLogFile(MethodName, JsonConvert.SerializeObject(inputVariables), EX.Message,
                    inputVariables.Useragent, inputVariables.Userip, inputVariables.Userid);
            }
            Infomessage = Info_message;

            Sqlcon.Close();
            Adp.Dispose();
            Sqlcon.Dispose();
            return DsData;
        }

        /*
        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/customer_user_registration")]
        public HttpResponseMessage CUSTOMER_USER_REGISTRATION([FromBody] UserInput ObjClass)
        {

            string MethodName = "INSERT_CUSTOMER_USER_REGISTRATION";
            User_Info Obj_Data = new User_Info();
            string API_Unique_No = ObjVariable.FunGenerateStringUId();
            DataSet ds = INSERT_CUSTOMER_USER_REGISTRATION(ObjClass, API_Unique_No, out string Infomessage, MethodName);
            if (ds != null)
            {

                Infomessage = ds.Tables[0].Rows[0]["infomessage"].ToString();
                string Status_Code = ds.Tables[0].Rows[0]["status_code"].ToString();
                string Statusflag = ds.Tables[0].Rows[0]["statusflag"].ToString();
                string Customer_Id = ds.Tables[0].Rows[0]["Customer_Id"].ToString();

                if (Statusflag == "1")
                {

                    Obj_Data.DOB = ObjClass.Date_Of_Birth;
                    Obj_Data.First_Name = ObjClass.First_Name;
                    Obj_Data.Last_Name = ObjClass.Last_Name;
                    Obj_Data.Pincode = ObjClass.Perm_PIN_Code;
                    Obj_Data.User_Email = ObjClass.Comm_Email;
                    Obj_Data.User_Mobile = ObjClass.Mobile;
                    Obj_Data.User_Refferal_Code = Customer_Id;
                    Obj_Data.User_Token = API_Unique_No;
                    Obj_Data.Unique_No = API_Unique_No;
                    #region SMS Send Commnet Code

                    //string customer_sms_message = ds.Tables[0].Rows[0]["customer_sms_message"].ToString();
                    //string Sender_Id = ds.Tables[0].Rows[0]["Sender_Id"].ToString();
                    //string sms_api_url = ds.Tables[0].Rows[0]["sms_api_url"].ToString();
                    //string url = string.Empty;
                    //string smsOutput = string.Empty;
                    //string SMS_Status = string.Empty;
                    //string country_code = ds.Tables[0].Rows[0]["country_code"].ToString();
                    //string mobileNo = country_code + ObjClass.Mobile;
                    //string Store_Id = ds.Tables[0].Rows[0]["Store_Id"].ToString();
                    //string User_Id = ds.Tables[0].Rows[0]["UserId"].ToString();
                    //string UniqueNum = ds.Tables[0].Rows[0]["UniqueNum"].ToString();

                    //url = sms_api_url.Replace("[senderid]", Sender_Id).Replace("[mob]", ObjClass.Mobile.ToString()).Replace("[msg]",
                    //      HttpUtility.UrlEncode(customer_sms_message));

                    //if (ObjClass.Mobile.ToString().Length >= 10)
                    //{
                    //    string getmobileno = RightString(ObjClass.Mobile.ToString(), 10);
                    //    bool checkNo = IsPhoneNumber(getmobileno);
                    //    if (checkNo == true)
                    //    {
                    //        PostSMSRequest(url, out smsOutput);

                    //        if ((smsOutput.ToUpper().Contains("ACCEPTED")) || (smsOutput.ToUpper().Contains("TRUE")) || (smsOutput.ToUpper().Contains("SUCCESS"))
                    //            || (smsOutput.ToUpper().Contains("DELIVER")) || (smsOutput.ToUpper().Contains("SENT")))
                    //            SMS_Status = "Sent.";
                    //        else
                    //            SMS_Status = "Failed.";
                    //    }
                    //    else
                    //    {
                    //        SMS_Status = "Failed.";
                    //        smsOutput = "Invalid Mobile No";
                    //    }
                    //}

                    //else
                    //{
                    //    SMS_Status = "Failed.";
                    //    smsOutput = "Invalid Mobile No";
                    //}



                    //string sqlsmstextstatusquery = "Insert into tbl_smstext_status(MobileNo,Loyalty_id,SMS_Text,SMS_Status,sms_status_text,status_flag,SMS_status_desc,user_id,store_id) values('" + ObjClass.Mobile.ToString()
                    //  + "','" + UniqueNum + "','" + customer_sms_message.Replace("'", "''") + "','" + SMS_Status + "','200 OK',0,'" + smsOutput + "','" + User_Id + "','" + Store_Id + "')";
                    //bool isSuccess = ObjCRUD.FunCRUD(sqlsmstextstatusquery);

                    // ------------------------------ Secondary

                    //string Add_offer_sms_message = ds.Tables[0].Rows[0]["Add_offer_sms_message"].ToString();
                    //string campaign_id = ds.Tables[0].Rows[0]["campaign_id"].ToString();
                    //string coupon_id = ds.Tables[0].Rows[0]["coupon_id"].ToString();
                    //string Broadcast_id = ds.Tables[0].Rows[0]["Broadcast_id"].ToString();


                    //if (Add_offer_sms_message != "")
                    //{

                    //    url = sms_api_url.Replace("[senderid]", Sender_Id).Replace("[mob]", objClass[i].customer_mobile).Replace("[msg]", HttpUtility.UrlEncode(Add_offer_sms_message));

                    //    PostSMSRequest(url, out smsOutput);
                    //    if ((smsOutput.ToUpper().Contains("ACCEPTED")) || (smsOutput.ToUpper().Contains("TRUE")) || (smsOutput.ToUpper().Contains("SUCCESS")) || (smsOutput.ToUpper().Contains("DELIVER")) || (smsOutput.ToUpper().Contains("SENT")))
                    //        SMS_Status = "Sent.";
                    //    else
                    //        SMS_Status = smsOutput;

                    //    string sqlMKGStatusAddOffer = "Insert into Tbl_mktg_Status(User_Id,Pin_number,Mobile_Number,Campaign_Id,Coupon_Id,sms_text,sms_status,sms_status_text,sms_flag,broadcast_id,SMS_status_desc,store_id) values('" + User_Id + "','','" + mobileNo + "','" + campaign_id + "','" + coupon_id + "','" + Add_offer_sms_message.Replace("'", "''")
                    //        + "','" + SMS_Status + "','200 OK',0,'" + Broadcast_id + "','" + smsOutput + "','" + Store_Id + "')";

                    //    bool isSuccessAddOffer = objDataInteraction.funCRUD(sqlMKGStatusAddOffer);
                    //}

                    //string reg_points_sms_status = ds.Tables[0].Rows[0]["reg_points_sms_status"].ToString();
                    //if (reg_points_sms_status.ToUpper() == "ENABLE")
                    //{
                    //    string offer_sms_text_IsEnabled = ds.Tables[0].Rows[0]["offer_sms_text_IsEnabled"].ToString();
                    //    string campaign_id_IsEnabled = ds.Tables[0].Rows[0]["campaign_id_IsEnabled"].ToString();
                    //    string offer_id_IsEnabled = ds.Tables[0].Rows[0]["offer_id_IsEnabled"].ToString();
                    //    string Broadcast_id_IsEnabled = ds.Tables[0].Rows[0]["Broadcast_id"].ToString();

                    //    if (offer_sms_text_IsEnabled != "")
                    //    {

                    //        url = sms_api_url.Replace("[senderid]", Sender_Id).Replace("[mob]", objClass[i].customer_mobile).Replace("[msg]", HttpUtility.UrlEncode(offer_sms_text_IsEnabled));

                    //        PostSMSRequest(url, out smsOutput);
                    //        if ((smsOutput.ToUpper().Contains("ACCEPTED")) || (smsOutput.ToUpper().Contains("TRUE")) || (smsOutput.ToUpper().Contains("SUCCESS")) || (smsOutput.ToUpper().Contains("DELIVER")) || (smsOutput.ToUpper().Contains("SENT")))
                    //            SMS_Status = "Sent.";
                    //        else
                    //            SMS_Status = smsOutput;

                    //        string sqlMKGStatusEnabled = "Insert into Tbl_mktg_Status(User_Id,Pin_number,Mobile_Number,Campaign_Id,Coupon_Id,sms_text,sms_status,sms_status_text,sms_flag,broadcast_id,SMS_status_desc,store_id) values('" + User_Id + "','','" + mobileNo + "','" + campaign_id_IsEnabled + "','" + offer_id_IsEnabled + "','" + offer_sms_text_IsEnabled.Replace("'", "''")
                    //      + "','" + SMS_Status + "','200 OK',0,'" + Broadcast_id_IsEnabled + "','" + smsOutput + "','" + Store_Id + "')";

                    //        bool isSuccessEnabled = objDataInteraction.funCRUD(sqlMKGStatusEnabled);
                    //    }
                    //}

                    //string reg_offer = ds.Tables[0].Rows[0]["reg_offer"].ToString();

                    //if (reg_offer.ToLower() == "offer")
                    //{

                    //    string offer_sms_text_Offer = ds.Tables[0].Rows[0]["offer_sms_text_Offer"].ToString();
                    //    string campaign_id_Offer = ds.Tables[0].Rows[0]["campaign_id_Offer"].ToString();
                    //    string offer_id_Offer = ds.Tables[0].Rows[0]["offer_id_Offer"].ToString();
                    //    string Pin_Number = ds.Tables[0].Rows[0]["Pin_Number"].ToString();
                    //    string expiry_dt = ds.Tables[0].Rows[0]["expiry_dt"].ToString();

                    //    if (offer_sms_text_Offer != "")
                    //    {

                    //        url = sms_api_url.Replace("[senderid]", Sender_Id).Replace("[mob]", objClass[i].customer_mobile).Replace("[msg]", HttpUtility.UrlEncode(offer_sms_text_Offer));

                    //        PostSMSRequest(url, out smsOutput);
                    //        if ((smsOutput.ToUpper().Contains("ACCEPTED")) || (smsOutput.ToUpper().Contains("TRUE")) || (smsOutput.ToUpper().Contains("SUCCESS")) || (smsOutput.ToUpper().Contains("DELIVER")) || (smsOutput.ToUpper().Contains("SENT")))
                    //            SMS_Status = "Sent.";
                    //        else
                    //            SMS_Status = smsOutput;

                    //        string sqlOfferInsertQuery = "Insert into Tbl_Status(User_Id,Pin_number,Mobile_Number,Campaign_Id,Coupon_Id,sms_text,sms_status,sms_status_text,sms_flag,broadcast_id,expired_on,SMS_status_desc,store_id) values('" + User_Id + "','" + Pin_Number + "','" + mobileNo + "','" + campaign_id_Offer + "','" + offer_id_Offer
                    //            + "','" + offer_sms_text_Offer.Replace("'", "''") + "','" + SMS_Status + "','200 OK',0,1,'" + expiry_dt + "','" + smsOutput + "','" + Store_Id + "')";

                    //        bool isSuccessOffer = objDataInteraction.funCRUD(sqlOfferInsertQuery);
                    //    }
                    //}

                    #endregion

                    return Request.CreateResponse(HttpStatusCode.OK, new ReturnCustomerRegistrationStatusOutput()
                    {
                        Message = Infomessage,
                        Method_Name = MethodName,
                        Status_Code = Convert.ToInt32(Status_Code),
                        Success = true,
                        Data = Obj_Data,
                    });

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new ReturnCustomerRegistrationStatusOutput()
                    {
                        Message = Infomessage,
                        Method_Name = MethodName,
                        Status_Code = Convert.ToInt32(Status_Code),
                        Success = false,
                        Data = Obj_Data,
                    });
                }


            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ReturnCustomerRegistrationStatusOutput()
                {
                    Message = Infomessage,
                    Method_Name = MethodName,
                    Status_Code = (int)StatusInformation.Fail,
                    Success = false,
                    Data = Obj_Data,
                });
            }




        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/edit_user")]
        public async Task<Object> Edit_User([FromBody] Edit_User_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                string Card_Update_Str = "";
                string Card_Update_Str_logs = "";
                if (ObjClass.Obj_Card_Detail != null)
                {
                    foreach (var data in ObjClass.Obj_Card_Detail)
                    {
                        Card_Update_Str += " update Tbl_customer_card_details set vehicle_manufacturer='" + data.Vehicle_Make + "', vehicle_type='" + data.Vehicle_Type + "', Vehicle_yr_of_reg='" + data.Year_Of_Registration + "', group_id='" + ObjClass.Group_Id + "',group_name='" + ObjClass.Group_Name + "',ZOCode='" + ObjClass.Zonal_Office + "',ROCode='" + ObjClass.Regional_Office + "',form_id='" + ObjClass.Form_Number + "',CreatedBy='" + ObjClass.CreatedBy + "',salesArea='" + ObjClass.SalesArea + "' where Customer_id='" + ObjClass.Customer_id + "' and vehicle_no='" + data.Vehicle_No + "'";
                        Card_Update_Str_logs += " or Vehicle_No='" + data.Vehicle_No + "'";
                    }
                }
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {

                         { "Customer_id", ObjClass.Customer_id },
                         { "Password", ObjClass.Password },
                         { "Secret_Question", ObjClass.Secret_Question },
                         { "Secret_Answer", ObjClass.Secret_Answer },
                         { "Customer_Group_Id", ObjClass.Group_Id },
                         { "Customer_Group_Name", ObjClass.Group_Name },
                         { "ZOCode", ObjClass.Zonal_Office },
                         { "ROCode", ObjClass.Regional_Office },
                         { "Customer_Type_Id", ObjClass.Customer_Type_Id },
                         { "Customer_SubType_Id", ObjClass.Customer_SubType_Id },
                         { "SalesArea", ObjClass.SalesArea },
                         { "Form_Id", ObjClass.Form_Number },
                         { "Application_Date", ObjClass.Application_Date },
                         { "Signed_On", ObjClass.Signed_On },
                         { "Individual_Name", ObjClass.Individual_Name },
                         { "Org_Name", ObjClass.Org_Name },
                         { "Title", ObjClass.Title },
                         { "Name_On_Card", ObjClass.Name_On_Card },
                         { "Usage_Type", ObjClass.Usage_Type },
                         { "Type_of_Business_Entity", ObjClass.Type_of_Business_Entity },
                         { "Residence_Status", ObjClass.Residence_Status },
                         { "Income_Tax_PAN", ObjClass.Income_Tax_PAN },
                         { "floor_flat", ObjClass.Comm_Address1 },
                         { "building", ObjClass.Comm_Address2 },
                         { "street", ObjClass.Comm_Address3 },
                         { "Comm_Location", ObjClass.Comm_Location },
                         { "City", ObjClass.Comm_City },
                         { "PostalCode", ObjClass.Comm_PIN_Code },
                         { "state", ObjClass.Comm_State },
                         { "district", ObjClass.Comm_District },
                         { "stdcode", ObjClass.Comm_Std_Code },
                         { "Comm_Ph_Office", ObjClass.Comm_Ph_Office },
                         { "MobileNo", ObjClass.Comm_Mobile },
                         { "Email", ObjClass.Comm_Email },
                         { "fax", ObjClass.Comm_Fax },
                         { "Perm_Address1", ObjClass.Perm_Address1 },
                         { "Perm_Address2", ObjClass.Perm_Address2 },
                         { "Perm_Address3", ObjClass.Perm_Address3 },
                         { "Perm_Location", ObjClass.Perm_Location },
                         { "Perm_City", ObjClass.Perm_City },
                         { "Perm_PINCode", ObjClass.Perm_PIN_Code },
                         { "Perm_State", ObjClass.Perm_State },
                         { "Perm_District", ObjClass.Perm_District },
                         { "Perm_stdcode", ObjClass.Perm_Std_Code },
                         { "Perm_Phoneno", ObjClass.Perm_Ph_Office },
                         { "Perm_Fax", ObjClass.Perm_Fax },
                         { "Area_Of_Operation", ObjClass.Area_Of_Operation },
                         { "Num_of_HCVOwned", ObjClass.Number_Of_HCV_Owned },
                         { "Num_of_HCVOperated", ObjClass.Number_Of_HCV_Operated },
                         { "Num_of_LCVOwned", ObjClass.Number_Of_LCV_Owned },
                         { "Num_of_LCVOperated", ObjClass.Number_Of_LCV_Operated },
                         { "Num_of_MUVSUV_Owned", ObjClass.Number_Of_MUVSUV_Owned },
                         { "Num_of_MUVSUV_Operated", ObjClass.Number_Of_MUVSUV_Operated },
                         { "Num_of_CarJeep_Owned", ObjClass.Number_Of_CarJeep_Owned },
                         { "Num_of_CarJeep_Operated", ObjClass.Number_Of_CarJeep_Operated },
                         { "Fleet_Size", ObjClass.Fleet_Size },
                         { "Type_Of_Fleet", ObjClass.Type_Of_Fleet },
                         { "Num_of_Card_applied_for", ObjClass.Number_Of_Card_Applied_For },
                         { "Approx_Monthly_Spends_On_Fuel", ObjClass.Approx_Monthly_Spends_On_Fuel },
                         { "Approx_Monthly_Spends_On_Lubes", ObjClass.Approx_Monthly_Spends_On_Lubes },
                         { "DMA_Code", ObjClass.DMA_Code },
                         { "DME_Code", ObjClass.DME_Code },
                         { "Promo", ObjClass.Promo },
                         { "Received_Money", ObjClass.Received_Money },
                         { "Num_of_vehicles", ObjClass.Number_Of_Vehicles },
                         { "Payment_Mode", ObjClass.Payment_Mode },
                         { "KO_title", ObjClass.Key_Official_Title },
                         { "KO_Indv_initials", ObjClass.Individual_Initials },
                         { "KO_firstname", ObjClass.First_Name },
                         { "KO_middlename", ObjClass.Middle_Name },
                         { "KO_lastname", ObjClass.Last_Name },
                         { "KO_fax", ObjClass.Fax },
                         { "KO_Designation", ObjClass.Designation },
                         { "KO_stdcode", ObjClass.Key_Official_Std_Code },
                         { "KO_phoneno", ObjClass.Ph_Office },
                         { "KO_DOA", ObjClass.Date_Of_Anniversary },
                         { "KO_Appln_ReceivedOn", ObjClass.Application_ReceivedOn_Date },
                         { "KO_Mobileno", ObjClass.Mobile },
                         { "KO_DOB", ObjClass.Date_Of_Birth },
                         { "Bank_Name", ObjClass.Bank_Name },
                         { "Branch_Name", ObjClass.Branch_Name },
                         { "Branch_Code", ObjClass.Branch_Code },
                         { "Branch_IFSC", ObjClass.IFSC },
                         { "Bank_Account_No", ObjClass.Bank_Account_No },
                         { "Control_Card_No", ObjClass.Control_Card_No },
                         { "Control_Card_Pin", ObjClass.Control_Card_Pin },
                         { "Employee_No", ObjClass.Employee_No },
                         { "Employee_Name", ObjClass.Employee_Name },
                         { "Owner_Name", ObjClass.Owner_Name },
                         { "Cheque_DD_No", ObjClass.Cheque_DD_No },
                         { "Cheque_DD_Date", ObjClass.Cheque_DD_Date },
                         { "Cheque_Bank", ObjClass.Cheque_Bank },
                         { "FSE_Name", ObjClass.FSE_Name },
                         { "CreatedBy", ObjClass.CreatedBy },
                         { "Useragent", ObjClass.Useragent },
                         { "Userip", ObjClass.Userip },
                         { "Card_Update_Str", Card_Update_Str },
                         { "Card_Update_Str_logs", Card_Update_Str_logs },
                         { "Userid", ObjClass.@Userid }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Edit_User", parameters)
               .With<User_Info>()
               .Execute());
                List<User_Info> item = results[0].Cast<User_Info>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/create_manage_role")]
        public async Task<Object> CREATE_MANAGE_ROLE([FromBody] Input_Manage_Role ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                //var Image_Id_proof_image = ObjClass.Id_proof_image;
                //var Image_Address_proof_image = ObjClass.Address_proof_image;

                //var FilePath_Image_Id_proof_image = Path.Combine("Upload_Document/Upload_Id_proof", Image_Id_proof_image.FileName + "_" + ObjClass.Id_proof_number + "_" + ObjClass.Mobileno);
                //var FilePath_Image_Address_proof_image = Path.Combine("Upload_Document/Upload_Address_proof", Image_Address_proof_image.FileName + "_" + ObjClass.Address_proof_number + "_" + ObjClass.Mobileno);

                //if (Image_Id_proof_image.Length > 0)
                //{
                //    using (var fileStream = new FileStream(FilePath_Image_Id_proof_image, FileMode.Create))
                //    {
                //        Image_Id_proof_image.CopyTo(fileStream);
                //    }
                //}
                //if (Image_Address_proof_image.Length > 0)
                //{
                //    using (var fileStream = new FileStream(FilePath_Image_Address_proof_image, FileMode.Create))
                //    {
                //        Image_Address_proof_image.CopyTo(fileStream);
                //    }
                //}
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "Login_Name", ObjClass.User_Name },
                        { "Email", ObjClass.Email },
                        { "Password", ObjClass.Password },
                        { "Secret_Question", ObjClass.Secret_Question },
                        { "Secret_Answer", ObjClass.Secret_Answer },
                        { "Role_Id", ObjClass.Role_Id },
                        { "HQ_Id",ObjClass.HQ_Id},
                        { "Zone_Id", ObjClass.Zone_Id },
                        { "Region_Id", ObjClass.Region_Id },
                         { "Userid", ObjClass.Userid },
                         { "Firstname", ObjClass.Firstname },
                         { "Lastname", ObjClass.Lastname },
                         { "Mobileno", ObjClass.Mobileno },
                         { "Id_proof", ObjClass.Id_proof },
                         { "Id_proof_number", ObjClass.Id_proof_number },
                         //{ "Id_proof_image_path", FilePath_Image_Id_proof_image },
                         { "Address_proof", ObjClass.Address_proof },
                         { "Address_proof_number", ObjClass.Address_proof_number }
                         //{ "Address_proof_image_path", FilePath_Image_Address_proof_image }
                         //{ "RBE_Id", ObjClass.RBE_Id }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Create_Manage_Role_Insert", parameters)
               .With<Output_Manage_Role>()
               .Execute());
                if (results[0].Cast<Output_Manage_Role>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/add_edit_manage_role")]
        public async Task<Object> ADD_EDIT_MANAGE_ROLE([FromBody] Input_Add_Edit_Manage_Role ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "Role_Id", ObjClass.Role_Id },
                        { "Page_Name", ObjClass.Page_Name },
                        { "View_Permission", ObjClass.View_Permission },
                        { "Add_Permission", ObjClass.Add_Permission },
                        { "Update_Permission", ObjClass.Update_Permission },
                        { "Delete_Permission", ObjClass.Delete_Permission },
                         { "Userid", ObjClass.Userid }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Add_Edit_Manage_Role_Insert", parameters)
               .With<Output_Add_Edit_Manage_Role>()
               .Execute());
                if (results[0].Cast<Output_Add_Edit_Manage_Role>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/create_hpcl_user_loc_role")]
        public async Task<Object> CREATE_HPCL_USER_LOC_ROLE([FromBody] Input_Hpcl_User_Loc_Role ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "First_Name", ObjClass.First_Name },
                        { "Middle_Name", ObjClass.Middle_Name },
                        { "Last_Name", ObjClass.Last_Name },
                        { "Email", ObjClass.Email },
                        { "Comment", ObjClass.Comment },
                        { "Role_Id", ObjClass.Role_Id },
                        { "HQ_Id", ObjClass.HQ_Id },
                        { "Zone_Id", ObjClass.Zone_Id },
                        { "Region_Id", ObjClass.Region_Id },
                         { "Userid", ObjClass.Userid }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Create_Hpcl_User_Loc_Role_Insert", parameters)
               .With<Output_Hpcl_User_Loc_Role>()
               .Execute());
                if (results[0].Cast<Output_Hpcl_User_Loc_Role>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/get_pending_user_list")]
        public async Task<Object> Get_Pending_User_List([FromBody] Get_Pending_Input_Detail ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "CreatedBy", ObjClass.CreatedBy },
                        { "Statusflag", ObjClass.Statusflag }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Get_Pedning_User_List", parameters)
               .With<GetPendingUserList_Output>()
               .Execute());
                List<GetPendingUserList_Output> item = results[0].Cast<GetPendingUserList_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/get_kyc_detail_by_user")]
        public async Task<Object> Get_KYC_Detail_By_User([FromBody] Input_KYC_Detail_By_User ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "Admin_Id", ObjClass.Admin_Id }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Get_KYC_Detail_User_List", parameters)
               .With<KYCDetailUserList>()
               .Execute());
                List<KYCDetailUserList> item = results[0].Cast<KYCDetailUserList>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/approve_admin_user")]
        public async Task<Object> APPROVE_ADMIN_USER([FromBody] Input_Approve_Admin_User ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "username", ObjClass.Username },
                        { "comments", ObjClass.Comments },
                        { "approvalstatus", ObjClass.Approvalstatus },
                         { "Userid", ObjClass.Userid }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Approve_Admin_User_Update", parameters)
               .With<Output_Approve_Admin_User>()
               .Execute());
                if (results[0].Cast<Output_Approve_Admin_User>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/check_form_no")]
        public async Task<Object> Check_Form_No([FromBody] CheckFormNoInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "FormNo", ObjClass.FormNo }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Get_Form_Status", parameters)
               .With<CheckFormNoOutput>()
               .Execute());
                List<CheckFormNoOutput> item = results[0].Cast<CheckFormNoOutput>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/update_email_by_user_id")]
        public async Task<Object> Update_Email([FromBody] UpdateEmail_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "username", ObjClass.Username },
                    { "email", ObjClass.Email },
                    { "Useragent", ObjClass.Useragent },
                    { "Userip", ObjClass.Userip },
                    { "Userid", ObjClass.Userid }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Update_Email_By_User_Id", parameters)
               .With<UpdateEmail_Output>()
               .Execute());
                if (results[0].Cast<UpdateEmail_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/disable_user_by_user_id")]
        public async Task<Object> Disable_User([FromBody] DisableUser_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "username", ObjClass.Username },
                        { "Userid", ObjClass.Userid }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Disable_User_By_User_Id", parameters)
               .With<DisableUser_Output>()
               .Execute());
                if (results[0].Cast<DisableUser_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/search_user")]
        public async Task<Object> Search_User([FromBody] SearchUserInput ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "username", ObjClass.Username },
                        { "email", ObjClass.Email },
                        { "lastlogindate", ObjClass.Lastlogindate },
                        { "userrole", ObjClass.Userrole }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Search_User", parameters)
               .With<SearchCustomerProfile_Output>()
               .Execute());
                List<SearchCustomerProfile_Output> item = results[0].Cast<SearchCustomerProfile_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/add_card")]
        public async Task<Object> ADD_CARD([FromBody] AddCardInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                string SQL_Insert_Card_Details = string.Empty;
                if (ObjClass.Obj_Card_Detail != null)
                {
                    foreach (var data in ObjClass.Obj_Card_Detail)
                    {

                        SQL_Insert_Card_Details += "exec Usp_User_Add_Card @username='" + ObjClass.Username + "',@customerrefno='" + ObjClass.Customerrefno + "',@Customername='" + ObjClass.Customername + "',@Name_As_On_Card='" + ObjClass.Name_As_On_Card + "',@No_Of_Card='" + ObjClass.No_Of_Card + "',@Card_Type='" + ObjClass.Card_Type + "',@Card_Type_Status='" + ObjClass.Card_Type_Status + "',@Createdby='" + ObjClass.Createdby
                            + "',@Payment_Type='" + ObjClass.Payment_Type + "',@Vehicle_No='" + data.Vehicle_No + "',@Vehicle_Type='" + data.Vehicle_Type
                            + "',@Vehicle_Year_Registration='" + data.Vehicle_Year_Registration + "',@Vehicle_Manufacturer='" + data.Vehicle_Manufacturer + "',@Mobile_No='0',@Issue_Date='" + data.Issue_Date
                            + "',@Expiry_Date='" + data.Expiry_Date + "',@userid='" + ObjClass.Userid + "';";
                    }
                    if (SQL_Insert_Card_Details.Length > 0)
                    {
                        CRUD.FunCRUD(SQL_Insert_Card_Details);
                    }
                }
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {

                        { "username", ObjClass.Username },
                        { "customerrefno", ObjClass.Customerrefno },
                        { "Userid", ObjClass.Userid }
            };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Add_Card_Multiple", parameters)
               .With<AddCardOutput>()
               .Execute());
                List<AddCardOutput> item = results[0].Cast<AddCardOutput>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success_ADD_CARD, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/upload_rc_doc")]
        public async Task<Object> Upload_Rc_Doc([FromBody] UploadRcDoc_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Userid", ObjClass.Userid },
                    { "refno", ObjClass.Refno },
                    { "addressidproof", ObjClass.Addressidproof },
                    { "filename", ObjClass.Filename }

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Upload_RC_Doc", parameters)
               .With<UploadRcDoc_Output>()
               .Execute());

                if (results[0].Cast<UploadRcDoc_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/track_application_form_no")]
        public async Task<Object> TrackApplication_FormNo([FromBody] TrackApplicationForm_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "username", ObjClass.Username },
                        { "formNo", ObjClass.FormNo },
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Track_Application_Form_No", parameters)
               .With<TrackApplicationForm_Output>()
               .Execute());
                List<TrackApplicationForm_Output> item = results[0].Cast<TrackApplicationForm_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/search_customer_profile")]
        public async Task<Object> SearchCustomerProfile([FromBody] SearchCustomerProfile_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "Userid", ObjClass.Userid },
                        { "Name_On_Card", ObjClass.Name_On_Card },
                        { "CustomerType", ObjClass.CustomerType },
                        { "Customersubtype", ObjClass.Customersubtype },
                        { "Groupid", ObjClass.Groupid }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Search_Customer_Profile", parameters)
               .With<SearchCustomerProfile_Output>()
               .Execute());
                List<SearchCustomerProfile_Output> item = results[0].Cast<SearchCustomerProfile_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }
        */

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/operator_login")]
        public async Task<Object> Operator_Login([FromBody] Operator_Login_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "username", ObjClass.Username },
                        { "password", ObjClass.Password },
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Operator_Login", parameters)
               .With<Operator_Login_Output>()
               .Execute());
                List<Operator_Login_Output> item = results[0].Cast<Operator_Login_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [CustomAuthenticationFilter]
        [Route("api/edc/user/save_operator_info")]
        public async Task<Object> SaveOperatorInfo([FromBody] SaveOperatorInfo_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "OperatorId", ObjClass.OperatorId },
                    { "UserName", ObjClass.UserName },
                    { "Password", ObjClass.Password },
                    { "TerminalId", ObjClass.TerminalId },
                    { "OutletId", ObjClass.OutletId },
                    { "Userid", ObjClass.Userid }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Save_Operator_Info", parameters)
               .With<SaveOperatorInfo_Output>()
               .Execute());
                if (results[0].Cast<SaveOperatorInfo_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        /*

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/get_vechile_tracking_by_customerid")]
        public async Task<Object> GetVehicleTrackingbyCustomerId([FromBody] Vechile_Tracking_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "ZO", ObjClass.ZO },
                        { "RO", ObjClass.RO },
                        { "MerchantId", ObjClass.MerchantId },
                        { "CustomerId", ObjClass.CustomerId },
                        { "VechileNo", ObjClass.VechileNo },
                        { "OnlyVehicleTracking", ObjClass.OnlyVehicleTracking },
                        { "From_Date", ObjClass.From_Date },
                        { "To_Date", ObjClass.To_Date }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_Get_Vechile_Tracking_By_CustomerId", parameters)
               .With<Vechile_Tracking_Output>()
               .Execute());
                List<Vechile_Tracking_Output> item = results[0].Cast<Vechile_Tracking_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/check_mobileno")]
        public async Task<Object> CheckMobileNo([FromBody] CheckMobileNo_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "MobileNo", ObjClass.MobileNo }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_User_CheckMobileNo", parameters)
               .With<CheckMobileNo_Output>()
               .Execute());
                List<CheckMobileNo_Output> item = results[0].Cast<CheckMobileNo_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/View_Pending_Parent_Customer_Approval")]
        public async Task<Object> View_Pending_Parent_Customer_Approval([FromBody] View_Pending_Parent_Customer_Approval_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_User_View_Pending_Parent_Customer_Approval]", parameters)
               .With<View_Pending_Parent_Customer_Approval>()
               .Execute());

                if (results[0].Cast<View_Pending_Parent_Customer_Approval>().ToList().Count == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/Approve_Pending_Parent_Customer")]
        public async Task<Object> Approve_Pending_Parent_Customer([FromBody] Approve_Pending_Parent_Customer_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "CustomerId", ObjClass.CustomerId },
                { "Comments", ObjClass.Comments }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_User_Approve_Pending_Parent_Customer]", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/View_pending_parent_customer_authorization")]
        public async Task<Object> View_pending_parent_customer_authorization([FromBody] View_pending_parent_customer_authorization_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_User_View_pending_parent_customer_authorization]", parameters)
               .With<View_pending_parent_customer_authorization>()
               .Execute());

                if (results[0].Cast<View_pending_parent_customer_authorization>().ToList().Count == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/Authorize_pending_parent_customer")]
        public async Task<Object> Authorize_pending_parent_customer([FromBody] Authorize_pending_parent_customer_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "CustomerId", ObjClass.CustomerId },
                { "Comments", ObjClass.Comments }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_User_Authorize_pending_parent_customer]", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/View_pending_aggregator_parent_customer_approval")]
        public async Task<Object> View_pending_aggregator_parent_customer_approval([FromBody] View_pending_aggregator_parent_customer_approval_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_User_View_pending_aggregator_parent_customer_approval]", parameters)
               .With<View_pending_aggregator_parent_customer_approval>()
               .Execute());

                if (results[0].Cast<View_pending_aggregator_parent_customer_approval>().ToList().Count == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/Approve_pending_aggregator_parent_customer")]
        public async Task<Object> Approve_pending_aggregator_parent_customer([FromBody] Approve_pending_aggregator_parent_customer_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "CustomerId", ObjClass.CustomerId },
                { "Comments", ObjClass.Comments }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_User_Approve_pending_aggregator_parent_customer]", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/View_pending_aggregator_child_customer_verify_approve")]
        public async Task<Object> View_pending_aggregator_child_customer_verify_approve([FromBody] View_pending_aggregator_child_customer_verify_approve_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "State", ObjClass.State },
                { "FomNo", ObjClass.FormNo },
                { "CustomerName", ObjClass.CustomerName },
                { "Mode", ObjClass.Mode }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_User_View_pending_aggregator_child_customer_verify_approve]", parameters)
               .With<View_pending_aggregator_child_customer_verify_approve>()
               .Execute());

                if (results[0].Cast<View_pending_aggregator_child_customer_verify_approve>().ToList().Count == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/Verify_approve_pending_aggregator_child_customer")]
        public async Task<Object> Verify_approve_pending_aggregator_child_customer([FromBody] Verify_approve_pending_aggregator_child_customer_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "CustomerId", ObjClass.Customer_Id },
                { "Comments", ObjClass.Comments },
                { "Mode", ObjClass.Mode }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_User_Verify_approve_pending_aggregator_child_customer]", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList().Count == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/user/Create_OEM_Manager_Role")]
        public async Task<Object> Create_OEM_Manager_Role([FromBody] Create_OEM_Manager_Role_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "User_role", ObjClass.User_role },
                //{ "Dealer_code", ObjClass.Dealer_code },
                //{ "Dealer_name", ObjClass.Dealer_name },
                { "Email", ObjClass.Email },
                { "Mobile_No", ObjClass.Mobile_No },
                { "HQ", ObjClass.HQ },
                { "Zone", ObjClass.Zone },
                { "Region", ObjClass.Region },
                { "City", ObjClass.City },
                { "State", ObjClass.State },
                //{ "District", ObjClass.District },
                { "Address1", ObjClass.Address1 },
                { "Address2", ObjClass.Address2 },
                { "Address3", ObjClass.Address3 },
                { "Group_id", ObjClass.Group_id },
                { "Group_name", ObjClass.Group_name }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_User_Create_OEM_Manager_Role]", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList().Count == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }

        */

    }
}
