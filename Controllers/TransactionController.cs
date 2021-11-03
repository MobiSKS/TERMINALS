using HPCL_DP_Terminal.App_Start;
using HPCL_DP_Terminal.Helpers;
using HPCL_DP_Terminal.MQSupportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using static HPCL_DP_Terminal.Models.Transaction;
using static HPCL_DP_Terminal.MQSupportClass.StatusMessage;

namespace HPCL_DP_Terminal.Controllers
{
    public class TransactionController : ApiController
    {
        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/get_transaction_detail_by_customerid_cardno_mobileno")]
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
        [Route("api/edc/transaction/get_statement_detail_by_customerid")]
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
        [Route("api/edc/transaction/ccms_sale_by_card")]
        public async Task<Object> CCMS_Sale_By_Card([FromBody] CCMSSaleByCard_Input ObjClass)
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
        [Route("api/edc/transaction/ccms_sale_by_mobile_no")]
        public async Task<Object> CCMS_Sale_By_Mobile_No([FromBody] CCMSSaleByMobileNo_Input ObjClass)
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


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/reload_api_by_cash")]
        public async Task<Object> Reload_Api_By_Cash([FromBody] ReloadApiByCash_Input ObjClass)
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
                    { "Recharge_Amount", ObjClass.Recharge_Amount },
                    { "Sale_Type", ObjClass.Sale_Type },
                    //{ "Transaction_Type", ObjClass.Transaction_Type },
                    { "Transaction_Id", ObjClass.Transaction_Id },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id },
                    { "Batch_Id", ObjClass.Batch_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Reload_Api_By_Cash", parameters)
               .With<Database_Status>()
               .With<ReloadApiByCash>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[1]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/reload_api_by_cheque")]
        public async Task<Object> Reload_Api_By_Cheque([FromBody] ReloadApiByCheque_Input ObjClass)
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
                    { "Recharge_Amount", ObjClass.Recharge_Amount },
                    { "Sale_Type", ObjClass.Sale_Type },
                    { "Transaction_Type", ObjClass.Transaction_Type },
                    { "Transaction_Id", ObjClass.Transaction_Id },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id },
                    { "Cheque_No", ObjClass.Cheque_No },
                    { "MICR_Code", ObjClass.MICR_Code }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Reload_Api_By_Cash", parameters)
               .With<ReloadApiByCheque>()
               .Execute());

                if (results[0].Cast<ReloadApiByCheque>().ToList().Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }




        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/reload_api_by_neft_rtgs")]
        public async Task<Object> Reload_Api_By_NEFT_RTGS([FromBody] ReloadApiByNEFTRTGS_Input ObjClass)
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
                    { "Recharge_Amount", ObjClass.Recharge_Amount },
                    { "Sale_Type", ObjClass.Sale_Type },
                    { "Transaction_Type", ObjClass.Transaction_Type },
                    { "Transaction_Id", ObjClass.Transaction_Id },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id },
                    { "Cheque_No", ObjClass.Cheque_No },
                    { "MICR_Code", ObjClass.MICR_Code }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Reload_Api_By_NEFT_RTGS", parameters)
               .With<ReloadApiByNEFTRTGS>()
               .Execute());

                if (results[0].Cast<ReloadApiByNEFTRTGS>().ToList().Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }



        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/card_sale_by_card")]
        public async Task<Object> Card_Sale_By_Card([FromBody] CardSaleByCard_Input ObjClass)
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
                    { "Product", ObjClass.Product },
                    { "Amount", ObjClass.Amount },
                    { "Sale_Type", ObjClass.Sale_Type },
                    { "Odometer_Reading", ObjClass.Odometer_Reading },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Card_Sale_By_Card", parameters)
               .With<CardSaleByCard>()
               .Execute());

                if (results[0].Cast<CardSaleByCard>().ToList().Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/credit_sale_by_card")]
        public async Task<Object> Credit_Sale_By_Card([FromBody] CreditSaleByCard_Input ObjClass)
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
                    { "Product", ObjClass.Product },
                    { "Amount", ObjClass.Amount },
                    { "Sale_Type", ObjClass.Sale_Type },
                    { "Odometer_Reading", ObjClass.Odometer_Reading },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Credit_Sale_By_Card", parameters)
               .With<CreditSaleByCard>()
               .Execute());

                if (results[0].Cast<CreditSaleByCard>().ToList().Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }



        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/dealer_credit_sale_by_card")]
        public async Task<Object> Dealer_Credit_Sale_By_Card([FromBody] DealerCreditSaleByCard_Input ObjClass)
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
                    { "Product", ObjClass.Product },
                    { "Amount", ObjClass.Amount },
                    { "Sale_Type", ObjClass.Sale_Type },
                    { "Odometer_Reading", ObjClass.Odometer_Reading },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Credit_Sale_By_Card", parameters)
               .With<DealerCreditSaleByCard>()
               .Execute());

                if (results[0].Cast<DealerCreditSaleByCard>().ToList().Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }



        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/card_sale_by_mobileno")]
        public async Task<Object> Card_Sale_By_MobileNo([FromBody] CardSaleByMobileNo_Input ObjClass)
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
                    //{ "OTP", ObjClass.OTP },
                    { "Product", ObjClass.Product },
                    { "Amount", ObjClass.Amount },
                    { "Sale_Type", ObjClass.Sale_Type },
                    { "Odometer_Reading", ObjClass.Odometer_Reading },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Card_Sale_By_MobileNo", parameters)
               .With<CardSaleByMobileNo>()
               .Execute());

                if (results[0].Cast<CardSaleByMobileNo>().ToList().Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }



        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/credit_sale_by_mobile_no")]
        public async Task<Object> Credit_Sale_By_Mobile_No([FromBody] CreditSaleByMobileNo_Input ObjClass)
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
                    //{ "OTP", ObjClass.OTP },
                    { "Product", ObjClass.Product },
                    { "Amount", ObjClass.Amount },
                    { "Sale_Type", ObjClass.Sale_Type },
                    { "Odometer_Reading", ObjClass.Odometer_Reading },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Credit_Sale_By_Mobile_No", parameters)
               .With<CreditSaleByMobileNo>()
               .Execute());

                if (results[0].Cast<CreditSaleByMobileNo>().ToList().Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }



        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/balance_transfer_by_card")]
        public async Task<Object> Balance_Transfer_By_Card([FromBody] BalanceTransferByCard_Input ObjClass)
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
                    { "Amount", ObjClass.Amount },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Balance_Transfer_By_Card", parameters)
               .With<Database_Status>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/balance_transfer_by_mobile_no")]
        public async Task<Object> Balance_Transfer_By_Mobile_No([FromBody] BalanceTransferByMobileNo_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Card_No", ObjClass.Mobile_No },
                    { "Amount", ObjClass.Amount },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Balance_Transfer_By_Mobile_No", parameters)
               .With<Database_Status>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/void_by_card")]
        public async Task<Object> Void_By_Card([FromBody] VoidByCard_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "ROC_No", ObjClass.ROC_No },
                    { "Card_No", ObjClass.Card_No },
                    { "Amount", ObjClass.Amount },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Transaction_Void_By_Card", parameters)
               .With<Database_Status>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/void_by_mobile_no")]
        public async Task<Object> Void_By_Mobile_No([FromBody] VoidByMobileNo_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "ROC_No", ObjClass.ROC_No },
                    { "Mobile_No", ObjClass.Mobile_No },
                    { "OTP", ObjClass.OTP },
                    { "Amount", ObjClass.Amount },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Void_By_Mobile_No", parameters)
               .With<Database_Status>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/save_tracking_detail_by_card")]
        public async Task<Object> Save_Tracking_Detail_By_Card([FromBody] SaveTrackingDetailByCard_Input ObjClass)
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
                    { "Odometer_Reading", ObjClass.Odometer_Reading },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Save_Tracking_Detail_By_Card", parameters)
               .With<Database_Status>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/save_tracking_detail_by_mobile_no")]
        public async Task<Object> Save_Tracking_Detail_By_Mobile_No([FromBody] SaveTrackingDetailByMobileNo_Input ObjClass)
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
                    { "Odometer_Reading", ObjClass.Odometer_Reading },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Save_Tracking_Detail_By_Mobile_No", parameters)
               .With<Database_Status>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/pay_merchant_by_pay_code")]
        public async Task<Object> Pay_Merchant_By_Pay_Code([FromBody] PayMerchantByPayCode_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {

                    { "Pay_Code", ObjClass.Pay_Code },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Pay_Merchant_By_Pay_Code", parameters)
               .With<Database_Status>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/reverse_pay_merchant_by_pay_code")]
        public async Task<Object> Reverse_Pay_Merchant_By_Pay_Code([FromBody] ReversePayMerchantByPayCode_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "ROC_No", ObjClass.ROC_No },
                    { "Pay_Code", ObjClass.Pay_Code },
                    { "Batch_Id", ObjClass.Batch_Id },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Reverse_Pay_Merchant_By_Pay_Code", parameters)
               .With<Database_Status>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }



        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/credit_sale_complete")]
        public async Task<Object> Credit_Sale_Complete([FromBody] CreditSaleComplete_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Control_Card_No", ObjClass.Control_Card_No },
                    { "Amount", ObjClass.Amount },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Credit_Sale_Complete", parameters)
               .With<Database_Status>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/redemption_api_by_card")]
        public async Task<Object> Redemption_Api_By_Card([FromBody] RedemptionApiByCard_Input ObjClass)
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
                    { "Fuel", ObjClass.Fuel },
                    { "Points_to_Redeem", ObjClass.Points_to_Redeem },
                    { "Amount", ObjClass.Amount },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Redemption_Api_By_Card", parameters)
               .With<Database_Status>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }


        


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/unblock_terminal_pin")]
        public async Task<Object> Unblock_Terminal_Pin([FromBody] UnblockTerminalPin_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "New_Pin", ObjClass.New_Pin },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Unblock_Terminal_Pin", parameters)
               .With<Database_Status>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/pay_card_fee")]
        public async Task<Object> Pay_Card_Fee([FromBody] PayCardFee_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Form_No", ObjClass.Form_No },
                    { "No_Of_Cards", ObjClass.No_Of_Cards },
                    { "Amount", ObjClass.Amount },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Pay_Card_Fee", parameters)
               .With<Database_Status>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }


        //[HttpPost]
        //[CustomAuthenticationFilter]
        //[Route("api/edc/transaction/save_operator_info")]
        //public async Task<Object> Save_Operator_Info([FromBody] SaveOperatorInfo_Ter_Input ObjClass)
        //{
        //    if (ObjClass == null)
        //    {
        //        return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
        //    }
        //    else
        //    {
        //        Dictionary<string, object> parameters = new Dictionary<string, object>
        //        {
        //            { "Operator_Id", ObjClass.Operator_Id },
        //            { "Username", ObjClass.Username },
        //            { "Password", ObjClass.Password },
        //            { "TID", ObjClass.TID },
        //            { "Outlet_Id", ObjClass.Outlet_Id }
        //        };

        //        var results = await Task.Run(() => new DefaultContext()
        //       .MultipleResults("Usp_Terminal_Save_Operator_Info", parameters)
        //       .With<Database_Status>()
        //       .Execute());

        //        if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
        //        else
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
        //    }
        //}



       


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/Save_DTP_Loyalty_By_Card")]
        public async Task<Object> Save_DTP_Loyalty_By_Card([FromBody] SaveDTPLoyaltyByCard_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "ROC_No", ObjClass.ROC_No },
                { "Card_no", ObjClass.Card_no },
                { "Amount", ObjClass.Amount },
                { "TID", ObjClass.TID },
                { "OutletId", ObjClass.OutletId }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Save_DTP_Loyalty_By_Card", parameters)
               .With<SaveDTPLoyaltyByCard>()
               .Execute());

                if (results[0].Cast<SaveDTPLoyaltyByCard>().ToList().Count == 0)
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
        [Route("api/edc/transaction/Save_DTP_Loyalty_By_Mobile_No")]
        public async Task<Object> Save_DTP_Loyalty_By_Mobile_No([FromBody] SaveDTPLoyaltyByMobileNo_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "ROC_No", ObjClass.ROC_No },
                { "Mobile_No", ObjClass.Mobile_no },
                { "Amount", ObjClass.Amount },
                { "TID", ObjClass.TID },
                { "OutletId", ObjClass.OutletId }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Save_DTP_Loyalty_By_Mobile_No", parameters)
               .With<SaveDTPLoyaltyByMobileNo>()
               .Execute());

                if (results[0].Cast<SaveDTPLoyaltyByMobileNo>().ToList().Count == 0)
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
        [Route("api/edc/transaction/Save_Non_DTP_Loyalty_By_Card")]
        public async Task<Object> Save_Non_DTP_Loyalty_By_Card([FromBody] SaveNonDTPLoyaltyByCard_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {

                { "Card_no", ObjClass.Card_no },
                { "Amount", ObjClass.Amount },
                { "TID", ObjClass.TID },
                { "OutletId", ObjClass.OutletId }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Save_Non_DTP_Loyalty_By_Card", parameters)
               .With<SaveNonDTPLoyaltyByCard>()
               .Execute());

                if (results[0].Cast<SaveNonDTPLoyaltyByCard>().ToList().Count == 0)
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
        [Route("api/edc/transaction/Save_Non_DTP_Loyalty_By_Mobile_No")]
        public async Task<Object> Save_Non_DTP_Loyalty_By_Mobile_No([FromBody] SaveNonDTPLoyaltyByMobileNo_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {

                { "Mobile_No", ObjClass.Mobile_No },
                { "Amount", ObjClass.Amount },
                { "TID", ObjClass.TID },
                { "OutletId", ObjClass.OutletId }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Save_Non_DTP_Loyalty_By_Mobile_No", parameters)
               .With<SaveNonDTPLoyaltyByMobileNo>()
               .Execute());

                if (results[0].Cast<SaveNonDTPLoyaltyByMobileNo>().ToList().Count == 0)
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
        [Route("api/edc/transaction/Get_Point_Equiv_Amt")]
        public async Task<Object> Get_Point_Equiv_Amt([FromBody] GetPointEquivAmtInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "card_no", ObjClass.Card_no },
                { "card_pin", ObjClass.Card_pin },
                { "fuel", ObjClass.Fuel },
                { "pointstoredeem", ObjClass.Pointstoredeem },
                { "TID", ObjClass.TID },
                { "OutletId", ObjClass.OutletId }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Get_Point_Equiv_Amt", parameters)
               .With<GetPointEquivAmt>()
               .Execute());

                if (results[0].Cast<GetPointEquivAmt>().ToList().Count == 0)
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
        [Route("api/edc/transaction/Get_CCMS_Balance_By_Card_No")]
        public async Task<Object> Get_CCMS_Balance_By_Card_No([FromBody] CCMSBalanceByCardNoInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Controlcardno", ObjClass.Controlcardno },
                { "Controlpin", ObjClass.Controlpin },
                { "TID", ObjClass.TID },
                { "OutletId", ObjClass.OutletId }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Get_CCMS_Balance_By_Card_No", parameters)
               .With<CCMSBalanceByCardNo>()
               .Execute());

                if (results[0].Cast<GetWalletBalanceLimit>().ToList().Count == 0)
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
        [Route("api/edc/transaction/Get_Loyalty_Balance_By_Card_No")]
        public async Task<Object> Get_Loyalty_Balance_By_Card_No([FromBody] LoyaltyBalanceByCardNoInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Controlcardno", ObjClass.Controlcardno },
                { "Controlpin", ObjClass.Controlpin },
                { "TID", ObjClass.TID },
                { "OutletId", ObjClass.OutletId }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Get_Loyalty_Balance_By_Card_No", parameters)
               .With<LoyaltyBalanceByCardNo>()
               .Execute());

                if (results[0].Cast<GetWalletBalanceLimit>().ToList().Count == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }


    }
}
