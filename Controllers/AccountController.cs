using Microsoft.OpenApi.Extensions;
using HPCL_DP_Terminal.MQSupportClass;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static HPCL_DP_Terminal.MQSupportClass.StatusMessage;
using static HPCL_DP_Terminal.MQSupportClass.TokenManager;

namespace HPCL_DP_Terminal.Controllers
{
    public class AccountController : ApiController
    {
        private readonly Variables ObjVariable = new Variables();


        public bool Return_Key(out string UserMessage, int Header_Parameter_Value, out int Status_Code,
         string Useragent, string Userip, string Method_Name, string Userid)
        {
            bool IsResult = false;
            string API_Key = string.Empty;
            string Secret_Key = string.Empty;
            string StrMessage = string.Empty;
            int IntStatusCode = 0;
            var Requests = Request;
            var Header = Requests.Headers;
            try
            {
                if (Header_Parameter_Value == 0)
                {
                    if (Header.Contains("API_Key"))
                    {
                        API_Key = Header.GetValues("API_Key").First();
                    }
                    if (Header.Contains("Secret_Key"))
                    {
                        Secret_Key = Header.GetValues("Secret_Key").First();
                    }
                    if (API_Key == "" && Secret_Key != "")
                    {
                        StrMessage = StatusInformation.API_Key_Is_Null.GetDisplayName();
                        IntStatusCode = (int)StatusInformation.API_Key_Is_Null;
                        IsResult = false;
                    }
                    else if (API_Key != "" && Secret_Key == "")
                    {
                        StrMessage = StatusInformation.Secret_Key_Is_Null.GetDisplayName();
                        IntStatusCode = (int)StatusInformation.Secret_Key_Is_Null;
                        IsResult = false;
                    }

                    else if (API_Key == "" && Secret_Key == "")
                    {
                        StrMessage = StatusInformation.API_Key_Secret_Key_Is_Null.GetDisplayName();
                        IntStatusCode = (int)StatusInformation.API_Key_Secret_Key_Is_Null;
                        IsResult = false;
                    }
                    else
                    {
                        bool IsAPI_Key_Validate = ObjVariable.Chk_API_Key_SecretKey_Validation(API_Key, Secret_Key);
                        if (IsAPI_Key_Validate == true)
                        {
                            IsResult = true;
                            StrMessage = StatusInformation.Success.GetDisplayName();
                            IntStatusCode = (int)StatusInformation.Success;
                        }

                        else
                        {
                            IsResult = false;
                            StrMessage = StatusInformation.API_Key_Is_Secret_Key_Invalid.GetDisplayName();
                            IntStatusCode = (int)StatusInformation.API_Key_Is_Secret_Key_Invalid;
                        }
                    }


                }

                if (Header_Parameter_Value == 1)
                {
                    if (Header.Contains("API_Key"))
                    {
                        API_Key = Header.GetValues("API_Key").First();
                    }

                    if (API_Key == "")
                    {
                        StrMessage = StatusInformation.API_Key_Is_Null.GetDisplayName();
                        IntStatusCode = (int)StatusInformation.API_Key_Is_Null;
                        IsResult = false;
                    }
                    else
                    {
                        bool IsAPI_Key_Validate = ObjVariable.Chk_APIKey_Validation(API_Key);
                        if (IsAPI_Key_Validate == true)
                        {
                            IsResult = true;
                            StrMessage = StatusInformation.Success.GetDisplayName();
                            IntStatusCode = (int)StatusInformation.Success;
                        }
                        else
                        {
                            IsResult = false;
                            StrMessage = StatusInformation.API_Key_Is_Invalid.GetDisplayName();
                            IntStatusCode = (int)StatusInformation.API_Key_Is_Invalid;
                        }

                    }


                }

                if (Header_Parameter_Value == 2)
                {
                    if (Header.Contains("Secret_Key"))
                    {
                        Secret_Key = Header.GetValues("Secret_Key").First();
                    }

                    if (Secret_Key == "")
                    {
                        StrMessage = StatusInformation.Secret_Key_Is_Null.GetDisplayName();
                        IntStatusCode = (int)StatusInformation.Secret_Key_Is_Null;
                        IsResult = false;
                    }
                    else
                    {
                        bool IsSecret_Key_Validate = ObjVariable.Chk_SecretKey_Validation(Secret_Key);
                        if (IsSecret_Key_Validate == true)
                        {
                            StrMessage = StatusInformation.Success.GetDisplayName();
                            IntStatusCode = (int)StatusInformation.Success;
                            IsResult = true;
                        }
                        else
                        {
                            StrMessage = StatusInformation.Secret_Key_Is_Invalid.GetDisplayName();
                            IntStatusCode = (int)StatusInformation.Secret_Key_Is_Invalid;
                            IsResult = false;
                        }

                    }
                }
            }
            catch
            {
                StrMessage = StatusInformation.Internel_Error.GetDisplayName();
                IntStatusCode = (int)StatusInformation.Internel_Error;
                IsResult = false;
            }


            if (IsResult == true)
            {
                if (Useragent == null)
                    Useragent = "";

                if (Userip == null)
                    Userip = "";

                if (Userid == null)
                    Userid = "";

                if (Userid == "")
                    Userid = DateTime.Now.ToString("yyyyMMddHHmmss");

                if (Useragent != "" && Userip != "" && Userid != "")
                {
                    using (SqlConnection con = new SqlConnection(ObjVariable.GetConnection()))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "insert into tbl_api_entry(api_flag,useragent,Userip,userid) values('" + Method_Name + "','" + Useragent
                                + "','" + Userip + "','" + Userid + "')";
                            cmd.CommandType = CommandType.Text;
                            int i = cmd.ExecuteNonQuery();
                            con.Close();
                            IsResult = true;
                        }
                    }
                }
                else
                {
                    IsResult = false;
                    StrMessage = StatusInformation.User_Agentor_User_IP_User_Id_is_null.GetDisplayName();
                    IntStatusCode = (int)StatusInformation.User_Agentor_User_IP_User_Id_is_null;
                }
            }

            UserMessage = StrMessage;
            Status_Code = IntStatusCode;
            return IsResult;
        }

        [HttpPost]
        [Route("api/edc/terminals/generatetoken")]
        public HttpResponseMessage ValidLogin(GenerateTokenInput ObjClass)
        {
            string MethodName = "GENERATE_TOKEN";
            try
            {

                var request = Request;
                var headers = request.Headers;
                string API_Key = string.Empty;
                string Secret_Key = string.Empty;
                byte[] bytes = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60, 62, 64, 66, 68, 70 };
                string SecretKey = Convert.ToBase64String(bytes);
                bool IsResult = Return_Key(out string UserMessage, 0, out int IntStatusCode, ObjClass.Useragent, ObjClass.Userip, MethodName, ObjClass.Userid);

                if (IsResult == true)
                {
                    //TokenManager.Secret = objVariable.StrSecretKey;
                    TokenManager.Secret = SecretKey;
                    return Request.CreateResponse(HttpStatusCode.OK, new ReturnGenerateTokenStatusOutput()
                    {
                        Message = StatusInformation.Success.GetDisplayName(),
                        Method_Name = MethodName,
                        Status_Code = (int)StatusInformation.Success,
                        Success = true,
                        Token = TokenManager.GenerateToken(ObjClass.Useragent, ObjClass.Userip),
                        Model_State = ModelState,
                    });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new ReturnGenerateTokenStatusOutput()
                    {
                        Message = UserMessage,
                        Method_Name = MethodName,
                        Status_Code = IntStatusCode,
                        Success = false,
                        Token = "",
                        Model_State = ModelState,
                    });
                }

            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ReturnGenerateTokenStatusOutput()
                {
                    Message = Ex.Message,
                    Method_Name = MethodName,
                    Status_Code = (int)StatusInformation.Exception_Code,
                    Success = false,
                    Token = "",
                    Model_State = ModelState,
                });
            }
        }
    }
}
