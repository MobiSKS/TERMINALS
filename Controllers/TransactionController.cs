using MQWebAPI.App_Start;
using MQWebAPI.Helpers;
using MQWebAPI.MQSupportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using static MQWebAPI.Models.Transaction;
using static MQWebAPI.MQSupportClass.StatusMessage;

namespace MQWebAPI.Controllers
{
    public class TransactionController : ApiController
    {
        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/transaction/get_transaction_detail_by_customerid_cardno_mobileno")]
        public async Task<Object> Get_Transaction_Detail_By_CustomerId_CardNo_Mobile_No([FromBody] TrnsactionDetail_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "CustomerId_CardNo_MobileNo", ObjClass.CustomerId_CardNo_MobileNo },
                        { "From_Date", ObjClass.From_Date },
                        { "To_Date", ObjClass.To_Date },
                        { "Transaction_Type" , ObjClass.Transaction_Type }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Transaction_Get_Transaction_Detail_By_CustomerId_CardNo_Mobile_No", parameters)
               .With<TransactionDetail_Output>()
               .Execute());
                List<TransactionDetail_Output> item = results[0].Cast<TransactionDetail_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/transaction/get_statement_detail_by_customerid")]
        public async Task<Object> GetStatementDetailbyCustomerId([FromBody] StatementDetail_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "CustomerId", ObjClass.CustomerId },
                        { "From_Date", ObjClass.From_Date },
                        { "To_Date", ObjClass.To_Date },
                        { "Transaction_Type", ObjClass.Transaction_Type }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Transaction_Get_Statement_Detail_By_CustomerId", parameters)
               .With<StatementDetail_Output>()
               .Execute());
                List<StatementDetail_Output> item = results[0].Cast<StatementDetail_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }



        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/transaction/ccmssale_by_card")]
        public async Task<Object> CCMSSale_By_Card([FromBody] CCMSSaleByCard_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "Card_No", ObjClass.Card_No },
                        { "Card_Pin", ObjClass.Card_Pin },
                        { "Product", ObjClass.Product },
                        { "Amount", ObjClass.Amount },
                        { "Sale_Type", ObjClass.Sale_Type },
                        { "TID", ObjClass.TID },
                        { "Terminal_Pin", ObjClass.Terminal_Pin },
                        { "Odometer_Reading", ObjClass.Odometer_Reading },
                        { "OutletId", ObjClass.OutletId },
                        { "Batch_Id",ObjClass.Batch_Id}
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Transaction_CCMSSale_By_Card", parameters)
               .With<CCMSSaleByCard>()
               .Execute());
                //List<CCMSSaleByCard> item = results[0].Cast<CCMSSaleByCard>().ToList();
                //if (item.Count > 0)
                if (results[0].Cast<CCMSSaleByCard>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }



        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/transaction/ccmssale_by_mobile_no")]
        public async Task<Object> CCMSSale_By_Mobile_No([FromBody] CCMSSaleByMobileNo_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "Mobile_No", ObjClass.Mobile_No },
                        { "OTP", ObjClass.OTP },
                        { "Product", ObjClass.Product },
                        { "Amount", ObjClass.Amount },
                        { "Sale_Type", ObjClass.Sale_Type },
                        { "TID", ObjClass.TID },
                        { "Terminal_Pin", ObjClass.Terminal_Pin },
                        { "Odometer_Reading", ObjClass.Odometer_Reading },
                        { "OutletId", ObjClass.OutletId },
                        { "Type", ObjClass.Type },
                        { "Batch_Id",ObjClass.Batch_Id}
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Transaction_CCMSSale_By_Mobile_No", parameters)
               .With<CCMSSaleByMobileNo>()
               .Execute());
                //List<CCMSSaleByMobileNo> item = results[0].Cast<CCMSSaleByMobileNo>().ToList();

                if (results[0].Cast<CCMSSaleByMobileNo>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }





    }
}
