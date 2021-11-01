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
        [Route("api/terminals/generate_batch_no")]
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
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }

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
        [Route("api/terminals/get_all_terminal_status")]
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
        [Route("api/terminals/get_all_terminals")]
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
        [Route("api/terminals/insert_and_update_iac")]
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
        [Route("api/terminals/unblock_terminal")]
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
        [Route("api/terminals/get_details_before_terminal_installation_request")]
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
        [Route("api/terminals/terminal_installation_request")]
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
        [Route("api/terminals/get_pending_terminal_installation")]
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
        [Route("api/terminals/update_pending_terminal_installation")]
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
        [Route("api/terminals/get_details_before_terminal_de_installation_request")]
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
        [Route("api/terminals/terminal_de_installation_request")]
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
        [Route("api/terminals/terminal_ide_installation_pending")]
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
        [Route("api/terminals/update_pending_terminal_ide_installation")]
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
        [Route("api/terminals/get_pending_terminal_install_list")]
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
        [Route("api/terminals/approve_terminal_installation_request")]
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
        [Route("api/terminals/get_pending_terminal_de_install_list")]
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
        [Route("api/terminals/approve_terminal_de_installation_request")]
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



        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/terminals/reload_api_by_cash")]
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
                    { "Transaction_Type", ObjClass.Transaction_Type },
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

                if (results[0].Cast<Database_Status>().ToList()[0].Status==1 )
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[1]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, results[0].Cast<Database_Status>().ToList()[0].Reason);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/terminals/reload_api_by_cheque")]
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
        [Route("api/terminals/reload_api_by_neft_rtgs")]
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
        [Route("api/terminals/card_sale_by_card")]
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
        [Route("api/terminals/credit_sale_by_card")]
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
        [Route("api/terminals/dealer_credit_sale_by_card")]
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
        [Route("api/terminals/card_sale_by_mobileno")]
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
        [Route("api/terminals/credit_sale_by_mobile_no")]
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
        [Route("api/terminals/balance_transfer_by_card")]
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
        [Route("api/terminals/balance_transfer_by_mobile_no")]
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
        [Route("api/terminals/void_by_card")]
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
               .MultipleResults("Usp_Terminal_Void_By_Card", parameters)
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
        [Route("api/terminals/void_by_mobile_no")]
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
        [Route("api/terminals/save_tracking_detail_by_card")]
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
        [Route("api/terminals/save_tracking_detail_by_mobile_no")]
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
        [Route("api/terminals/pay_merchant_by_pay_code")]
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
        [Route("api/terminals/reverse_pay_merchant_by_pay_code")]
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
        [Route("api/terminals/credit_sale_complete")]
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
        [Route("api/terminals/redemption_api_by_card")]
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
        [Route("api/terminals/Change_Terminal_Pin")]
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
                    { "Outlet_Id", ObjClass.Outlet_Id }
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


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/terminals/unblock_terminal_pin")]
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
        [Route("api/terminals/pay_card_fee")]
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


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/terminals/save_operator_info")]
        public async Task<Object> Save_Operator_Info([FromBody] SaveOperatorInfo_Ter_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Operator_Id", ObjClass.Operator_Id },
                    { "Username", ObjClass.Username },
                    { "Password", ObjClass.Password },
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Save_Operator_Info", parameters)
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
        [Route("api/terminals/batch_settlement")]
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
                    { "TID", ObjClass.TID },
                    { "Outlet_Id", ObjClass.Outlet_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Terminal_Batch_Settlement", parameters)
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
        [Route("api/terminals/Save_DTP_Loyalty_By_Card")]
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
        [Route("api/terminals/Save_DTP_Loyalty_By_Mobile_No")]
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
        [Route("api/terminals/Save_Non_DTP_Loyalty_By_Card")]
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
        [Route("api/terminals/Save_Non_DTP_Loyalty_By_Mobile_No")]
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
        [Route("api/terminals/Get_Point_Equiv_Amt")]
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
        [Route("api/terminals/Get_CCMS_Balance_By_Card_No")]
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
        [Route("api/terminals/Get_Loyalty_Balance_By_Card_No")]
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
