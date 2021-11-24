using HPCL_DP_Terminal.App_Start;
using HPCL_DP_Terminal.Helpers;
using HPCL_DP_Terminal.Models;
using HPCL_DP_Terminal.MQSupportClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static HPCL_DP_Terminal.Models.Terminal;
using static HPCL_DP_Terminal.MQSupportClass.StatusMessage;

namespace HPCL_DP_Terminal.Controllers
{
    public class TerminalController : ApiController
    {


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/generate_batch_no")]
        public async Task<Object> Generate_Batch_No([FromBody] GenerateBatchNo_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Terminal_Id", ObjClass.Terminal_Id },
                    { "Merchant_Id", ObjClass.Merchant_Id }

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Generate_Batch_No", parameters)
               .With<GenerateBatchNo>()
               .Execute());

                if (results[0].Cast<GenerateBatchNo>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<GenerateBatchNo>().ToList()[0].Reason);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/transaction/batch_settlement")]
        public async Task<Object> Batch_Settlement([FromBody] BatchSettlement_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Batch_Id", ObjClass.Batch_Id },
                    { "Reload_no_of_bills", ObjClass.Reload_no_of_bills },
                    { "Reload_Amount", ObjClass.Reload_Amount },
                    { "Recharge_no_of_bills", ObjClass.Recharge_no_of_bills },
                    { "Recharge_Amount", ObjClass.Recharge_Amount },
                    { "Sale_no_of_bills", ObjClass.Sale_no_of_bills },
                    { "Sale_Amount", ObjClass.Sale_Amount },
                    { "Terminal_Id", ObjClass.TID },
                    { "Merchant_Id", ObjClass.Merchant_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Batch_Settlement", parameters)
               .With<Database_Status>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Transaction_Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/batch_upload")]
        public async Task<Object> Batch_Upload([FromBody] BatchUpload_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {

                var dtDBR = new System.Data.DataTable("udt_Batch_Upload_Transaction_Det");
                dtDBR.Columns.Add("Card_No", typeof(Int64));
                dtDBR.Columns.Add("Mobile_No", typeof(Int64));
                dtDBR.Columns.Add("Amount", typeof(decimal));
                dtDBR.Columns.Add("Product_Name", typeof(string));
                dtDBR.Columns.Add("Sale_Type", typeof(string));
                dtDBR.Columns.Add("ROC", typeof(Int32));

                if (ObjClass.Transaction_Details != null)
                {
                    foreach (Transaction_Details item in ObjClass.Transaction_Details)
                    {
                        System.Data.DataRow dr = dtDBR.NewRow();
                        dr["Card_No"] = item.Card_No;
                        dr["Mobile_No"] = item.Mobile_No;
                        dr["Amount"] = item.Amount;
                        dr["Product_Name"] = item.Product_Name;
                        dr["Sale_Type"] = item.Sale_Type;
                        dr["ROC"] = item.ROC;
                        dtDBR.Rows.Add(dr);
                        dtDBR.AcceptChanges();
                    }
                }


                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Batch_Id", ObjClass.Batch_Id },
                    { "Transaction_Details", dtDBR },
                    //{ "Unmatched_Trasnactions", ObjClass.Unmatched_Trasnactions },
                    { "Terminal_Id", ObjClass.TID },
                    { "Merchant_Id", ObjClass.Merchant_Id }                   

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Batch_Upload", parameters)
               .With<GenerateBatchNo>()
               .Execute());

                if (results[0].Cast<GenerateBatchNo>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<GenerateBatchNo>().ToList()[0].Reason);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/Change_Terminal_Pin")]
        public async Task<Object> Change_Terminal_Pin([FromBody] ChangeTerminalPin_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Old_Pin", ObjClass.Old_Pin },
                    { "New_Pin", ObjClass.New_Pin },
                    { "TID", ObjClass.TID },
                    { "Merchant_Id", ObjClass.Merchant_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Change_Terminal_Pin", parameters)
               .With<Database_Status>()
               .Execute());

                if (results[0].Cast<Database_Status>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }

        /*
        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/get_all_terminal_status")]
        public async Task<Object> Get_All_Terminal_Status([FromBody] TerminalInput ObjClass)
        {
            string MethodName = this.ActionContext.ActionDescriptor.ActionName;
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Get_All_Terminal_Status", parameters)
               .With<Terminal_Status>()
               .Execute());
                List<Terminal_Status> item = results[0].Cast<Terminal_Status>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/get_all_terminals")]
        public async Task<Object> Get_All_Terminals([FromBody] Get_All_Terminal_Input ObjClass)
        {
            string MethodName = this.ActionContext.ActionDescriptor.ActionName;
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "Check_Report_Status", ObjClass.Check_Report_Status },
                        { "Terminal_Status_Type_Name", ObjClass.Terminal_Status_Type_Name },
                        { "Terminal_Id", ObjClass.Terminal_Id },
                        { "Merchant_Id", ObjClass.Merchant_Id }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Get_All_Terminals", parameters)
               .With<Get_All_Terminals>()
               .Execute());
                List<Get_All_Terminals> item = results[0].Cast<Get_All_Terminals>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/insert_and_update_iac")]
        public async Task<Object> Insert_And_Update_IAC([FromBody] IAC_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Terminal_Id", ObjClass.Terminal_Id },
                    { "Store_Id", ObjClass.Store_Id }

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Insert_and_Update_IAC", parameters)
               .With<IAC_Output>()
               .Execute());

                if (results[0].Cast<IAC_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/unblock_terminal")]
        public async Task<Object> Unblock_Terminal([FromBody] Unblock_Terminal_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Terminal_Id", ObjClass.Terminal_Id }

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Unblock_Terminal", parameters)
               .With<Unblock_Terminal_Output>()
               .Execute());

                if (results[0].Cast<Unblock_Terminal_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/get_details_before_terminal_installation_request")]
        public async Task<Object> GetDetailsBeforeTerminalInstallationRequest([FromBody] Before_Terminal_Installation_Input ObjClass)
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
                    { "Zone_Id", ObjClass.Zone_Id },
                    { "Region_Id", ObjClass.Region_Id }

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Before_Terminal_Installation_Request", parameters)
               .With<Before_Terminal_Installation_Output>()
               .Execute());
                List<Before_Terminal_Installation_Output> item = results[0].Cast<Before_Terminal_Installation_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/terminal_installation_request")]
        public async Task<Object> TerminalInstallationRequest([FromBody] Terminal_Installation_Request_Input ObjClass)
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
                    { "Zone_Id", ObjClass.Zone_Id },
                    { "Region_Id", ObjClass.Region_Id },
                    { "TerminalIssuanceType", ObjClass.TerminalIssuanceType },
                    { "TerminalType", ObjClass.TerminalType },
                    { "Comments", ObjClass.Comments }

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Terminal_Installation_Request", parameters)
               .With<Terminal_Installation_Request_Output>()
               .Execute());
                if (results[0].Cast<Terminal_Installation_Request_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/get_pending_terminal_installation")]
        public async Task<Object> GetPendingTerminalInstallation([FromBody] Pending_Terminal_Installation_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Zone_Id", ObjClass.Zone_Id },
                    { "Region_Id", ObjClass.Region_Id },
                    { "From_Date", ObjClass.From_Date },
                    { "To_Date", ObjClass.To_Date },
                    { "Merchant_Id", ObjClass.Merchant_Id },
                    { "Terminal_Id", ObjClass.Terminal_Id }

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Pending_Terminal_Installation", parameters)
               .With<Pending_Terminal_Installation_Output>()
               .Execute());
                List<Pending_Terminal_Installation_Output> item = results[0].Cast<Pending_Terminal_Installation_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/update_pending_terminal_installation")]
        public async Task<Object> UpdatePendingTerminalInstallation([FromBody] Update_Pending_Terminal_Installation_Input ObjClass)
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
                    { "Terminal_Id", ObjClass.Terminal_Id },
                    { "Status", ObjClass.Status },
                    { "Reason", ObjClass.Reason }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Update_Pending_Terminal_Installation", parameters)
               .With<Update_Pending_Terminal_Installation_Output>()
               .Execute());
                if (results[0].Cast<Update_Pending_Terminal_Installation_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/get_details_before_terminal_de_installation_request")]
        public async Task<Object> GetDetailsBeforeTerminalDeInstallationRequest([FromBody] Before_Terminal_DE_Installation_Input ObjClass)
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
                    { "Zone_Id", ObjClass.Zone_Id },
                    { "Region_Id", ObjClass.Region_Id },
                    { "Deinstallation_Type", ObjClass.Deinstallation_Type },
                    { "Terminal_Id", ObjClass.Terminal_Id }

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Before_Terminal_DE_Installation_Request", parameters)
               .With<Before_Terminal_DE_Installation_Output>()
               .Execute());
                List<Before_Terminal_DE_Installation_Output> item = results[0].Cast<Before_Terminal_DE_Installation_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/terminal_de_installation_request")]
        public async Task<Object> TerminalDEInstallationRequest([FromBody] Terminal_DE_Installation_Input ObjClass)
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
                    { "Terminal_Id", ObjClass.Terminal_Id },
                    { "Comments", ObjClass.Comments }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Terminal_DE_Installation_Request", parameters)
               .With<Terminal_DE_Installation_Output>()
               .Execute());

                if (results[0].Cast<Terminal_DE_Installation_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/terminal_ide_installation_pending")]
        public async Task<Object> TerminalDEInstallationPending([FromBody] Terminal_IDE_Installation_Pending_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Zone_Id", ObjClass.Zone_Id },
                    { "Region_Id", ObjClass.Region_Id },
                    { "From_Date", ObjClass.From_Date },
                    { "To_Date", ObjClass.To_Date },
                    { "Merchant_Id", ObjClass.Merchant_Id },
                    { "Terminal_Id", ObjClass.Terminal_Id }

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Terminal_IDE_Installation_Pending", parameters)
               .With<Terminal_IDE_Installation_Pending_Output>()
               .Execute());
                List<Terminal_IDE_Installation_Pending_Output> item = results[0].Cast<Terminal_IDE_Installation_Pending_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/update_pending_terminal_ide_installation")]
        public async Task<Object> UpdatePendingTerminalDEInstallation([FromBody] Update_Pending_Terminal_IDE_Installation_Input ObjClass)
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
                    { "Terminal_Id", ObjClass.Terminal_Id },
                    { "Status", ObjClass.Status },
                    { "Reason", ObjClass.Reason }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Update_pending_Terminal_IDE_Installation", parameters)
               .With<Update_Pending_Terminal_IDE_Installation_Output>()
               .Execute());

                if (results[0].Cast<Update_Pending_Terminal_IDE_Installation_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/get_pending_terminal_install_list")]
        public async Task<Object> GetPendingTerminalsInstallList([FromBody] Pending_Terminal_Install_List_Input ObjClass)
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
                    { "From_Date", ObjClass.From_Date },
                    { "To_Date", ObjClass.To_Date },
                    { "Terminal", ObjClass.Terminal }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Get_Pending_Terminal_Install_List", parameters)
               .With<Pending_Terminal_Install_List_Output>()
               .Execute());
                List<Pending_Terminal_Install_List_Output> item = results[0].Cast<Pending_Terminal_Install_List_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/approve_terminal_installation_request")]
        public async Task<Object> ApproveTerminalInstallationRequest([FromBody] Approve_Terminal_Installtion_Request_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "TerminalId", ObjClass.TerminalId },
                    { "StoreId", ObjClass.StoreId },
                    { "Comment", ObjClass.Comment },
                    { "Status", ObjClass.Status }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Approve_Terminal_Installation_Request", parameters)
               .With<Approve_Terminal_Installtion_Request_Output>()
               .Execute());
                if (results[0].Cast<Approve_Terminal_Installtion_Request_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [Route("api/edc/terminals/get_pending_terminal_de_install_list")]
        public async Task<Object> GetPendingTerminalsDeInstallList([FromBody] Pending_Terminal_DE_Install_List_Input ObjClass)
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
                    { "From_Date", ObjClass.From_Date },
                    { "To_Date", ObjClass.To_Date },
                    { "MerchantId", ObjClass.MerchantId },
                    { "TerminalId", ObjClass.TerminalId }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Get_Pending_Terminal_De_Install_List", parameters)
               .With<Pending_Terminal_DE_Install_List_Output>()
               .Execute());
                List<Pending_Terminal_DE_Install_List_Output> item = results[0].Cast<Pending_Terminal_DE_Install_List_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/terminals/approve_terminal_de_installation_request")]
        public async Task<Object> ApproveTerminalDeInstallationRequest([FromBody] Approve_Terminal_De_Installtion_Request_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "TerminalId", ObjClass.TerminalId },
                    { "StoreId", ObjClass.StoreId },
                    { "Comment", ObjClass.Comment },
                    { "Status", ObjClass.Status }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Approve_De_Terminal_Installation_Request", parameters)
               .With<Approve_Terminal_De_Installtion_Request_Output>()
               .Execute());
                if (results[0].Cast<Approve_Terminal_De_Installtion_Request_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        */
        



    }
}
