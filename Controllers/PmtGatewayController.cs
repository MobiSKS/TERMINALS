using MQWebAPI.App_Start;
using MQWebAPI.Helpers;
using MQWebAPI.MQSupportClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static MQWebAPI.Models.PmtGateway;
using static MQWebAPI.MQSupportClass.StatusMessage;

namespace MQWebAPI.Controllers
{
    public class PmtGatewayController : ApiController
    {
        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/gateway/create_checksumhash")]
        public object Create_Checksumhash([FromBody] Create_Validate_Initiate_Checksumhash_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {

                Dictionary<string, object> body = new Dictionary<string, object>();
                Dictionary<string, string> txnAmount = new Dictionary<string, string>
                {
                    { "value", ObjClass.Value },
                    { "currency", ObjClass.Currency }
                };
                Dictionary<string, string> userInfo = new Dictionary<string, string>
                {
                    { "custId", ObjClass.CustId }
                };
                body.Add("requestType", ObjClass.RequestType);
                body.Add("mid", ObjClass.Mid);
                body.Add("websiteName", ObjClass.WebsiteName);
                body.Add("orderId", ObjClass.OrderId);
                body.Add("txnAmount", txnAmount);
                //body.Add("txnAmount", ObjClass.TxnAmount);
                body.Add("userInfo", userInfo);
                body.Add("callbackUrl", ObjClass.CallbackUrl);

                string PaytmChecksum = Paytm.Checksum.generateSignature(JsonConvert.SerializeObject(body), ObjClass.Merchant_Key);
                if (PaytmChecksum != "")
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, PaytmChecksum);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, PaytmChecksum);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/gateway/validate_checksumhash")]
        public object Validate_Checksumhash([FromBody] Create_Validate_Initiate_Checksumhash_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {

                Dictionary<string, object> body = new Dictionary<string, object>();

                Dictionary<string, string> txnAmount = new Dictionary<string, string>
                {
                    { "value", ObjClass.Value },
                    { "currency", ObjClass.Currency }
                };
                Dictionary<string, string> userInfo = new Dictionary<string, string>
                {
                    { "custId", ObjClass.CustId }
                };
                body.Add("requestType", ObjClass.RequestType);
                body.Add("mid", ObjClass.Mid);
                body.Add("websiteName", ObjClass.WebsiteName);
                body.Add("orderId", ObjClass.OrderId);
                body.Add("txnAmount", txnAmount);
                //body.Add("txnAmount", ObjClass.TxnAmount);
                body.Add("userInfo", userInfo);
                body.Add("callbackUrl", ObjClass.CallbackUrl);

                bool IsVerifySignature = Paytm.Checksum.verifySignature(JsonConvert.SerializeObject(body), ObjClass.Merchant_Key, ObjClass.Checksum);
                if (IsVerifySignature)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, "Checksum Matched");
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, "Checksum Mismatched");
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/gateway/initiate_transaction")]
        public object Initiate_Transaction([FromBody] Create_Validate_Initiate_Checksumhash_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {

                Dictionary<string, object> body = new Dictionary<string, object>();
                Dictionary<string, string> head = new Dictionary<string, string>();
                Dictionary<string, object> requestBody = new Dictionary<string, object>();

                Dictionary<string, string> txnAmount = new Dictionary<string, string>
                {
                    { "value", ObjClass.Value },
                    { "currency", ObjClass.Currency }
                };
                Dictionary<string, string> userInfo = new Dictionary<string, string>
                {
                    { "custId", ObjClass.CustId }
                };
                body.Add("requestType", ObjClass.RequestType);
                body.Add("mid", ObjClass.Mid);
                body.Add("websiteName", ObjClass.WebsiteName);
                body.Add("orderId", ObjClass.OrderId);
                body.Add("txnAmount", txnAmount);
                //body.Add("txnAmount", ObjClass.TxnAmount);
                body.Add("userInfo", userInfo);
                body.Add("callbackUrl", ObjClass.CallbackUrl);
                string PaytmChecksum = Paytm.Checksum.generateSignature(JsonConvert.SerializeObject(body), ObjClass.Merchant_Key);
                head.Add("signature", PaytmChecksum);
                requestBody.Add("body", body);
                requestBody.Add("head", head);

                string post_data = JsonConvert.SerializeObject(requestBody);

                string PaytmPaymentURL = ConfigurationManager.AppSettings["PaytmPaymentURL"].ToString();
                string URL = PaytmPaymentURL + "mid=" + ObjClass.Mid + "&orderId=" + ObjClass.OrderId + "";

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(URL);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                webRequest.ContentLength = post_data.Length;

                using (StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestWriter.Write(post_data);
                }

                var ResponseData = string.Empty;
                using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                {
                    ResponseData = responseReader.ReadToEnd();
                }

                if (ResponseData != "")
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, JsonConvert.DeserializeObject(ResponseData));
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, JsonConvert.DeserializeObject(ResponseData));
            }

        }


    }
}
