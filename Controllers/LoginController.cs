using HPCL_DP_Terminal.App_Start;
using HPCL_DP_Terminal.Helpers;
using HPCL_DP_Terminal.MQSupportClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static HPCL_DP_Terminal.Models.Login;
using static HPCL_DP_Terminal.MQSupportClass.StatusMessage;

namespace HPCL_DP_Terminal.Controllers
{
    public class LoginController : ApiController
    {
        //[HttpPost]
        //[CustomAuthenticationFilter]
        //[Route("api/edc/login/get_user_login")]
        //public async Task<Object> User_Login([FromBody] LoginInput ObjClass)
        //{

        //    if (ObjClass == null)
        //    {
        //        return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
        //    }
        //    else
        //    {
        //        Dictionary<string, object> parameters = new Dictionary<string, object>
        //            {
        //                { "username", ObjClass.Username },
        //                { "password", ObjClass.Password }
        //            };
        //        var results = await Task.Run(() => new DefaultContext()
        //       .MultipleResults("Usp_Login_Get_User_Login", parameters)
        //       .With<LoginOutput>()
        //       .Execute());
        //        List<LoginOutput> item = results[0].Cast<LoginOutput>().ToList();
        //        if (item.Count > 0)
        //        {
        //            if (results[0].Cast<LoginOutput>().ToList()[0].Status == 1)
        //                return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
        //            else if (results[0].Cast<LoginOutput>().ToList()[0].Status == 2)
        //                return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.User_deactivate, results[0]);
        //            else if (results[0].Cast<LoginOutput>().ToList()[0].Status == 3)
        //                return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Customer_deactivate, results[0]);
        //            else if (results[0].Cast<LoginOutput>().ToList()[0].Status == 4)
        //                return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Merchant_deactivate, results[0]);
        //            else return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
        //        }
        //        else return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
        //    }

        //}


        #region comment code
        //private readonly Variables ObjVariable = new Variables();
        //[NonAction]
        //public bool Return_Key(out string UserMessage, int Header_Parameter_Value, out int Status_Code,
        // string Useragent, string Userip, string Method_Name, string Userid, out string out_API_Key)
        //{
        //    bool IsResult = false;
        //    string API_Key = string.Empty;
        //    string Secret_Key = string.Empty;
        //    string StrMessage = string.Empty;
        //    int IntStatusCode = 0;
        //    var Requests = Request;
        //    var Header = Requests.Headers;
        //    try
        //    {
        //        if (Header_Parameter_Value == 0)
        //        {
        //            if (Header.Contains("API_Key"))
        //            {
        //                API_Key = Header.GetValues("API_Key").First();
        //            }
        //            if (Header.Contains("Secret_Key"))
        //            {
        //                Secret_Key = Header.GetValues("Secret_Key").First();
        //            }
        //            if (API_Key == "" && Secret_Key != "")
        //            {
        //                StrMessage = StatusInformation.API_Key_Is_Null.GetDisplayName();
        //                IntStatusCode = (int)StatusInformation.API_Key_Is_Null;
        //                IsResult = false;
        //            }
        //            else if (API_Key != "" && Secret_Key == "")
        //            {
        //                StrMessage = StatusInformation.Secret_Key_Is_Null.GetDisplayName();
        //                IntStatusCode = (int)StatusInformation.Secret_Key_Is_Null;
        //                IsResult = false;
        //            }

        //            else if (API_Key == "" && Secret_Key == "")
        //            {
        //                StrMessage = StatusInformation.API_Key_Secret_Key_Is_Null.GetDisplayName();
        //                IntStatusCode = (int)StatusInformation.API_Key_Secret_Key_Is_Null;
        //                IsResult = false;
        //            }
        //            else
        //            {
        //                bool IsAPI_Key_Validate = ObjVariable.Chk_API_Key_SecretKey_Validation(API_Key, Secret_Key);
        //                if (IsAPI_Key_Validate == true)
        //                {
        //                    IsResult = true;
        //                    StrMessage = StatusInformation.Success.GetDisplayName();
        //                    IntStatusCode = (int)StatusInformation.Success;
        //                }

        //                else
        //                {
        //                    IsResult = false;
        //                    StrMessage = StatusInformation.API_Key_Is_Secret_Key_Invalid.GetDisplayName();
        //                    IntStatusCode = (int)StatusInformation.API_Key_Is_Secret_Key_Invalid;
        //                }
        //            }


        //        }

        //        if (Header_Parameter_Value == 1)
        //        {
        //            if (Header.Contains("API_Key"))
        //            {
        //                API_Key = Header.GetValues("API_Key").First();
        //            }

        //            if (API_Key == "")
        //            {
        //                StrMessage = StatusInformation.API_Key_Is_Null.GetDisplayName();
        //                IntStatusCode = (int)StatusInformation.API_Key_Is_Null;
        //                IsResult = false;
        //            }
        //            else
        //            {
        //                bool IsAPI_Key_Validate = ObjVariable.Chk_APIKey_Validation(API_Key);
        //                if (IsAPI_Key_Validate == true)
        //                {
        //                    IsResult = true;
        //                    StrMessage = StatusInformation.Success.GetDisplayName();
        //                    IntStatusCode = (int)StatusInformation.Success;
        //                }
        //                else
        //                {
        //                    IsResult = false;
        //                    StrMessage = StatusInformation.API_Key_Is_Invalid.GetDisplayName();
        //                    IntStatusCode = (int)StatusInformation.API_Key_Is_Invalid;
        //                }

        //            }


        //        }

        //        if (Header_Parameter_Value == 2)
        //        {
        //            if (Header.Contains("Secret_Key"))
        //            {
        //                Secret_Key = Header.GetValues("Secret_Key").First();
        //            }

        //            if (Secret_Key == "")
        //            {
        //                StrMessage = StatusInformation.Secret_Key_Is_Null.GetDisplayName();
        //                IntStatusCode = (int)StatusInformation.Secret_Key_Is_Null;
        //                IsResult = false;
        //            }
        //            else
        //            {
        //                bool IsSecret_Key_Validate = ObjVariable.Chk_SecretKey_Validation(Secret_Key);
        //                if (IsSecret_Key_Validate == true)
        //                {
        //                    StrMessage = StatusInformation.Success.GetDisplayName();
        //                    IntStatusCode = (int)StatusInformation.Success;
        //                    IsResult = true;
        //                }
        //                else
        //                {
        //                    StrMessage = StatusInformation.Secret_Key_Is_Invalid.GetDisplayName();
        //                    IntStatusCode = (int)StatusInformation.Secret_Key_Is_Invalid;
        //                    IsResult = false;
        //                }

        //            }
        //        }
        //    }
        //    catch
        //    {
        //        StrMessage = StatusInformation.Internel_Error.GetDisplayName();
        //        IntStatusCode = (int)StatusInformation.Internel_Error;
        //        IsResult = false;
        //    }


        //    if (IsResult == true)
        //    {
        //        if (Useragent == null)
        //            Useragent = "";

        //        if (Userip == null)
        //            Userip = "";

        //        if (Userid == null)
        //            Userid = "";

        //        if (Useragent != "" && Userip != "" && Userid != "")
        //        {
        //            using (SqlConnection con = new SqlConnection(ObjVariable.GetConnection()))
        //            {
        //                using (SqlCommand cmd = new SqlCommand())
        //                {
        //                    con.Open();
        //                    cmd.Connection = con;
        //                    cmd.CommandText = "insert into tbl_api_entry(api_flag,useragent,Userip,userid) values('" + Method_Name + "','" + Useragent
        //                        + "','" + Userip + "','" + Userid + "')";
        //                    cmd.CommandType = CommandType.Text;
        //                    int i = cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    IsResult = true;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            IsResult = false;
        //            StrMessage = StatusInformation.User_Agentor_User_IP_User_Id_is_null.GetDisplayName();
        //            IntStatusCode = (int)StatusInformation.User_Agentor_User_IP_User_Id_is_null;
        //        }
        //    }

        //    UserMessage = StrMessage;
        //    Status_Code = IntStatusCode;
        //    out_API_Key = API_Key;
        //    return IsResult;
        //}
        #endregion

        //[HttpPost]
        //[CustomAuthenticationFilter]
        //[Route("api/edc/login/get_dashboard_data")]
        //public async Task<Object> GetDashboardData([FromBody] DashboardInput ObjClass)
        //{

        //    if (ObjClass == null)
        //    {
        //        return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
        //    }
        //    else
        //    {
        //        Dictionary<string, object> parameters = new Dictionary<string, object>
        //            {
        //                { "username", ObjClass.Username },
        //                { "userrole", ObjClass.Userrole },
        //            };
        //        var results = await Task.Run(() => new DefaultContext()
        //       .MultipleResults("Usp_Login_Get_Dashbaord_Data", parameters)
        //       .With<DashboardOutput>()
        //       .Execute());
        //        List<DashboardOutput> item = results[0].Cast<DashboardOutput>().ToList();
        //        if (item.Count > 0)
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
        //        else
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
        //    }

        //}

        //[HttpPost]
        //[CustomAuthenticationFilter]
        //[Route("api/edc/login/forgot_password")]
        //public async Task<Object> Forgot_Password([FromBody] ForgotPasswordInput ObjClass)
        //{
        //    if (ObjClass == null)
        //    {
        //        return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
        //    }
        //    else
        //    {
        //        Dictionary<string, object> parameters = new Dictionary<string, object>
        //        {
        //            { "Userid", ObjClass.Userid },
        //            { "User_Type", ObjClass.User_Type },
        //            { "Userid", ObjClass.Userid },
        //            { "Useremail", ObjClass.Useremail }
        //        };

        //        var results = await Task.Run(() => new DefaultContext()
        //       .MultipleResults("Usp_Login_Change_Password", parameters)
        //       .With<ForgotPasswordOutput>()
        //       .Execute());
        //        if (results[0].Cast<ForgotPasswordOutput>().ToList()[0].Status == 1)
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success_Message_Change_Password, results[0]);
        //        else
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
        //    }

        //}

        //[HttpPost]
        //[CustomAuthenticationFilter]
        //[Route("api/edc/login/change_password")]
        //public async Task<Object> Change_Password([FromBody] ChangePasswordInput ObjClass)
        //{

        //    if (ObjClass == null)
        //    {
        //        return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
        //    }
        //    else
        //    {
        //        Dictionary<string, object> parameters = new Dictionary<string, object>
        //        {
        //            { "user_mobile", ObjClass.User_mobile },
        //            { "User_Type", ObjClass.User_Type },
        //            { "Userid", ObjClass.Userid },
        //            { "oldpass", ObjClass.Oldpass },
        //            { "newpass", ObjClass.Newpass },
        //            { "Useragent", ObjClass.Useragent },
        //            { "Userip", ObjClass.Userip }
        //        };

        //        var results = await Task.Run(() => new DefaultContext()
        //       .MultipleResults("Usp_Login_Change_Password", parameters)
        //       .With<ChangePasswordOutput>()
        //       .Execute());
        //        if (results[0].Cast<ChangePasswordOutput>().ToList()[0].Status == 1)
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success_Message_Change_Password, results[0]);
        //        else
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
        //    }

        //}



        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/login/validate_pin")]
        public async Task<Object> Validate_Pin([FromBody] ValidatePinInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "CardNo", ObjClass.CardNo },
                    { "CardPin", ObjClass.CardPin },
                    { "TID", ObjClass.TID },
                    { "Merchant_Id", ObjClass.Merchant_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Login_Validate_Pin", parameters)
               .With<ValidatePinOutput>()
               .Execute());
                List<ValidatePinOutput> item = results[0].Cast<ValidatePinOutput>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/login/send_otp")]
        public object Send_OTP([FromBody] SendOTPInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> Body = new Dictionary<string, object>();

                DataSet ObjDataSet = CRUD.ReturnDataSet_Text("Usp_Login_Send_OTP @User_Mobile='" + ObjClass.User_Mobile + "',@TID='" + ObjClass.TID
                    + "',@Merchant_Id='" + ObjClass.Merchant_Id + "',@Role_id='" + ObjClass.Role_id + "',@User_Type='" + ObjClass.User_Type + "'");

                int Status = Convert.ToInt32(ObjDataSet.Tables[0].Rows[0]["Status"].ToString());
                string Reason = ObjDataSet.Tables[0].Rows[0]["Reason"].ToString();

                bool Output_Status;
                int Output_Id;
                if (ObjDataSet.Tables[0].Rows.Count > 0)
                {
                    if (Status == 1)
                    {
                        string Sender_Id = ObjDataSet.Tables[0].Rows[0]["Sender_Id"].ToString();
                        string Offer_SMS_Text = ObjDataSet.Tables[0].Rows[0]["Offer_SMS_Text"].ToString();
                        string SMS_API_URL = ObjDataSet.Tables[0].Rows[0]["sms_api_url"].ToString();
                        string OTP = ObjDataSet.Tables[0].Rows[0]["OTP"].ToString();
                        string Broadcast_id = ObjDataSet.Tables[0].Rows[0]["Broadcast_id"].ToString();
                        string Campaign_id = ObjDataSet.Tables[0].Rows[0]["campaign_id"].ToString();
                        string Offer_id = ObjDataSet.Tables[0].Rows[0]["Offer_id"].ToString();
                        Offer_SMS_Text = Offer_SMS_Text.Replace("[mobno]", ObjClass.User_Mobile.ToString()).Replace("[pwd]", OTP);

                        if (Offer_SMS_Text != "")
                        {
                            string URL = SMS_API_URL.Replace("[senderid]", Sender_Id).Replace("[mob]",
                                ObjClass.User_Mobile.ToString()).Replace("[msg]", System.Web.HttpUtility.UrlEncode(Offer_SMS_Text));

                            string SMSOutput = string.Empty;
                            string SMS_Status = string.Empty;


                            if (ObjClass.User_Mobile.ToString().Length >= 10)
                            {
                                string getmobileno = Variables.RightString(ObjClass.User_Mobile.ToString(), 10);
                                bool checkNo = Variables.IsPhoneNumber(getmobileno);
                                if (checkNo == true)
                                {
                                    Variables.PostSMSRequest(URL, out SMSOutput);

                                    if ((SMSOutput.ToUpper().Contains("ACCEPTED")) || (SMSOutput.ToUpper().Contains("TRUE")) || (SMSOutput.ToUpper().Contains("SUCCESS"))
                                     || (SMSOutput.ToUpper().Contains("DELIVER")) || (SMSOutput.ToUpper().Contains("SENT")))
                                        SMS_Status = "Sent.";
                                    else
                                        SMS_Status = "Failed.";
                                }
                                else
                                {
                                    SMS_Status = "Failed.";
                                    SMSOutput = "Invalid Mobile No";
                                }
                            }
                            else
                            {
                                Body.Add("OTP", "");
                                Body.Add("Reason", "Invalid mobile number");
                            }


                            string sqlMKGStatusAddOffer = "Insert into Tbl_mktg_Status(User_Id,Pin_number,Mobile_Number,Campaign_Id,Coupon_Id,sms_text,sms_status,sms_status_text,sms_flag,broadcast_id,SMS_status_desc,store_id) values('0','','91"
                                + ObjClass.User_Mobile + "','" + Campaign_id + "','" + Offer_id + "','" + Offer_SMS_Text.Replace("'", "''")
                                                  + "','" + SMS_Status + "','200',0,'" + Broadcast_id + "','" + SMSOutput + "','0')";

                            bool isSuccessAddOffer = CRUD.FunCRUD(sqlMKGStatusAddOffer);

                            if (isSuccessAddOffer == true && SMSOutput != "Invalid Mobile No")
                            {
                                CRUD.FunCRUD("insert into tbl_customer_get_otp(mobile_no,OTP,api_type) values('91" + ObjClass.User_Mobile + "','" + OTP
                                    + "','" + ObjClass.Flag_Type + "')");
                                Output_Status = true;
                                Output_Id = 1000;
                                Body.Add("OTP", OTP);
                                Body.Add("Reason", Reason);
                            }
                            else
                            {
                                Output_Status = false;
                                Output_Id = 1001;
                                Body.Add("OTP", "");
                                Body.Add("Reason", SMSOutput);

                            }
                        }

                        else
                        {
                            Output_Status = false;
                            Output_Id = 1001;
                            Body.Add("OTP", "");
                            Body.Add("Reason", Reason);
                        }
                    }
                    else
                    {
                        Output_Status = false;
                        Output_Id = 1001;
                        Body.Add("OTP", "");
                        Body.Add("Reason", Reason);
                    }

                }
                else
                {
                    Output_Status = false;
                    Output_Id = 1001;
                    Body.Add("OTP", "");
                    Body.Add("Reason", Reason);
                }

                return MessageHelper.Message(Request, HttpStatusCode.OK, Output_Status, Output_Id, Body);

                #region comment code
                //Dictionary<string, object> parameters = new Dictionary<string, object>
                //{
                //    { "User_Mobile", ObjClass.User_Mobile },
                //    { "TID", ObjClass.TID },
                //    { "Merchant_Id", ObjClass.Merchant_Id }
                //};

                // var results = await Task.Run(() => new DefaultContext()
                //.MultipleResults("Usp_Login_Send_OTP", parameters)
                //.With<SendOTPOutput>()
                //.Execute());
                // if (results[0].Cast<SendOTPOutput>().ToList()[0].Status == 1)

                //return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                // else
                //return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
                #endregion
            }

        }


        /*
        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/login/validate_otp")]
        public async Task<Object> Validate_OTP_Hppay([FromBody] Validate_OTP_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "User_Mobile", ObjClass.User_Mobile },
                    { "OTP", ObjClass.OTP }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Login_Validate_OTP_Terminal", parameters)
               .With<Validate_OTP>()
               .Execute());
                if (results[0].Cast<Validate_OTP>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        */

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/login/authenticate")]
        public async Task<Object> Authenticate([FromBody] AunticateInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "User_Mobile", ObjClass.User_Mobile },
                    { "OTP", ObjClass.OTP },
                    { "TID", ObjClass.TID },
                    { "Merchant_Id", ObjClass.Merchant_Id },
                    { "User_Type", ObjClass.User_Type },
                    { "Role_id", ObjClass.Role_id },
                    { "Flag_Type", ObjClass.Flag_Type }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Login_Authenticate", parameters)
               .With<AuthenticateOutput>()
               .Execute());
                if (results[0].Cast<AuthenticateOutput>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        //[HttpPost]
        //[CustomAuthenticationFilter]
        //[Route("api/edc/login/genrate_otp_dtplus")]
        //public async Task<Object> Genrate_OTP_DTPlus([FromBody] OTP_DTPlus_Input ObjClass)
        //{

        //    if (ObjClass == null)
        //    {
        //        return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
        //    }
        //    else
        //    {
        //        Dictionary<string, object> parameters = new Dictionary<string, object>
        //        {
        //            { "User_Mobile", ObjClass.User_Mobile },
        //            { "DeviceToken", ObjClass.DeviceToken }
        //        };

        //        var results = await Task.Run(() => new DefaultContext()
        //       .MultipleResults("Usp_Login_Genrate_OTP_DTPlus", parameters)
        //       .With<OTP_DTPlus_Output>()
        //       .Execute());
        //        List<OTP_DTPlus_Output> item = results[0].Cast<OTP_DTPlus_Output>().ToList();
        //        if (item.Count > 0)
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
        //        else
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
        //    }

        //}

        //[HttpPost]
        //[CustomAuthenticationFilter]
        //[Route("api/edc/login/validate_otp_dtplus")]
        //public async Task<Object> Validate_OTP_DTPlus([FromBody] Validate_OTP_DTPlus_Input ObjClass)
        //{

        //    if (ObjClass == null)
        //    {
        //        return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
        //    }
        //    else
        //    {
        //        Dictionary<string, object> parameters = new Dictionary<string, object>
        //        {
        //            { "User_Mobile", ObjClass.User_Mobile },
        //            { "OTP", ObjClass.OTP }
        //        };

        //        var results = await Task.Run(() => new DefaultContext()
        //       .MultipleResults("Usp_Login_Validate_OTP_DTPlus", parameters)
        //       .With<Validate_OTP_DTPlus_Output>()
        //       .Execute());
        //        if (results[0].Cast<Validate_OTP_DTPlus_Output>().ToList()[0].Status == 1)
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
        //        else
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
        //    }

        //}


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/login/set_all_configurations_for_terminal")]
        public async Task<Object> Set_All_Configurations_For_Terminal([FromBody] Set_All_Configurations_For_Terminal_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Merchant_Id", ObjClass.Merchant_Id },
                    { "TID", ObjClass.TID }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Login_Set_All_Configurations_For_Terminal", parameters)
               .With<Set_All_Configurations_For_Terminal_Output>()
               .Execute());

                List<Set_All_Configurations_For_Terminal_Output> item = results[0].Cast<Set_All_Configurations_For_Terminal_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

    }
}