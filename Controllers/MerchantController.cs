using MQWebAPI.App_Start;
using MQWebAPI.Helpers;
using MQWebAPI.MQSupportClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Globalization;
using static MQWebAPI.MQSupportClass.StatusMessage;
using static MQWebAPI.Models.Merchant;

namespace MQWebAPI.Controllers
{
    public class MerchantController : ApiController
    {
        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/search_merchant")]
        public async Task<Object> Search_Merchant([FromBody] SearchMerchantInput ObjClass)
        {
           if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "merchantid", ObjClass.Merchantid },
                { "stateid", ObjClass.Stateid },
                { "cityid", ObjClass.Cityid },
                { "districtid", ObjClass.Districtid },
                { "highwayno", ObjClass.Highway_no },
                { "highwayname", ObjClass.Highway }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_Search_Merchant", parameters)
               .With<SearchMerchant>()
               .Execute());

                if (results[0].Cast<SearchMerchant>().ToList().Count == 0)
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
        [Route("api/dtplus/merchant/map_mobile_dispenser_merchants")]
        public async Task<Object> Map_Mobile_Dispenser_Mrchants([FromBody] Map_Mobile_Dispenser_Merchants_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "MobileDispenser_id", ObjClass.MobileDispenserId },
                    { "Store_Id", ObjClass.MerchantId },
                    { "Createdby", ObjClass.CreatedBy },
                    { "Userid", ObjClass.Userid }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_Map_Mobile_Dispenser_Merchants", parameters)
               .With<Map_Mobile_Dispenser_Merchants>()
               .Execute());

                if (results[0].Cast<Map_Mobile_Dispenser_Merchants>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/get_mapped_mobile_dispenser_merchants")]
        public async Task<Object> Get_Mapped_Mobile_Dispenser_Merchants([FromBody] Get_Mapped_Mobile_Dispenser_Merchants_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "MobileDispenserId", ObjClass.MobileDispenserId }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_Get_Mapped_Mobile_Dispenser_Merchants", parameters)
               .With<Get_Mapped_Mobile_Dispenser_Merchants>()
               .Execute());
                 List<Get_Mapped_Mobile_Dispenser_Merchants> item = results[0].Cast<Get_Mapped_Mobile_Dispenser_Merchants>().ToList();
                  if (item.Count > 0)
                      return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                  else
                      return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/get_rejected_merchants")]
        public async Task<Object> Get_Rejected_Merchants([FromBody] Get_Rejected_Merchants_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "FromDate", ObjClass.FromDate },
                    { "ToDate", ObjClass.ToDate }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_Get_Rejected_Merchants", parameters)
               .With<Get_Rejected_Merchants>()
               .Execute());

                List<Get_Rejected_Merchants> item = results[0].Cast<Get_Rejected_Merchants>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/create_merchant")]
        public async Task<Object> Create_Merchant([FromBody] Create_Merchant_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"OutletName", ObjClass.OutletName },
                    {"Perm_Address1", ObjClass.Perm_Address1 },
                    {"Perm_Address2", ObjClass.Perm_Address2 },
                    {"Perm_Address3", ObjClass.Perm_Address3 },
                    {"Perm_Location", ObjClass.Perm_Location },
                    {"Perm_District", ObjClass.Perm_District },
                    {"Perm_City", ObjClass.Perm_City },
                    {"Perm_State", ObjClass.Perm_State },
                    {"Perm_PIN_Code", ObjClass.Perm_PIN_Code },
                    {"Perm_std_code", ObjClass.Perm_std_code },
                    {"Perm_Ph_Off", ObjClass.Perm_Ph_Off },
                    {"Perm_fax", ObjClass.Perm_fax },
                    {"ERP_Code", ObjClass.ERP_Code },
                    {"Outlet_Category", ObjClass.Outlet_Category },
                    {"PANNo", ObjClass.PANNo },
                    {"GSTNo", ObjClass.GSTNo },
                    {"Dealer_name", ObjClass.Dealer_name },
                    {"Highway_Name", ObjClass.Highway_Name },
                    {"Highway_No", ObjClass.Highway_No },
                    {"CautionAmt_DTP", ObjClass.CautionAmt_DTP },
                    {"CautionAmt_HP", ObjClass.CautionAmt_HP },
                    {"LPGSale", ObjClass.LPGSale },
                    {"MSSale", ObjClass.MSSale },
                    {"SBU_TYpe", ObjClass.SBU_TYpe },
                    {"MonthlyHSD", ObjClass.MonthlyHSD },
                    {"Zonal_Office", ObjClass.Zonal_Office },
                    {"Regional_Office", ObjClass.Regional_Office },
                    {"SalesArea", ObjClass.SalesArea },
                    {"Comm_Address1", ObjClass.Comm_Address1 },
                    {"Comm_Address2", ObjClass.Comm_Address2 },
                    {"Comm_Address3", ObjClass.Comm_Address3 },
                    {"Comm_Location", ObjClass.Comm_Location },
                    {"Comm_City", ObjClass.Comm_City },
                    {"Comm_State", ObjClass.Comm_State },
                    {"Comm_District", ObjClass.Comm_District },
                    {"Comm_PIN_Code", ObjClass.Comm_PIN_Code },
                    {"Comm_std_code", ObjClass.Comm_std_code },
                    {"Comm_Ph_Off", ObjClass.Comm_Ph_Off },
                    {"Comm_Fax", ObjClass.Comm_Fax },
                    {"NoofLiveTerminals", ObjClass.NoofLiveTerminals },
                    {"Terminal_Type", ObjClass.Terminal_Type },
                    {"CreatedBy", ObjClass.CreatedBy },
                    {"Merchant_Type_Id", ObjClass.Merchant_Type_Id },
                    {"Comm_Mobile", ObjClass.Comm_Mobile },
                    {"Comm_Email", ObjClass.Comm_Email },
                    {"Name", ObjClass.Name },
                    {"email", ObjClass.Email },
                    {"Mobile", ObjClass.Mobile },
                    {"groupid", ObjClass.Groupid },
                    {"groupname", ObjClass.Groupname },
                    {"password_val", ObjClass.Store_password },
                    {"Userid", ObjClass.Userid }

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_Create_Merchant", parameters)
               .With<Create_Merchant>()
               .Execute());

                if (results[0].Cast<Create_Merchant>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/get_merchant")]
        public async Task<Object> Get_Merchant([FromBody] Get_Merchant_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Merchantid", ObjClass.Merchantid }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_Get_Merchant", parameters)
               .With<Get_Merchant>()
               .Execute());

                List<Get_Merchant> item = results[0].Cast<Get_Merchant>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/approve_merchant")]
        public async Task<Object> Approve_Merchant([FromBody] Approve_Merchant_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "storecode", ObjClass.Storecode },
                    { "Comments", ObjClass.Comments },
                    { "approvaltype", ObjClass.Status },
                    {"Userid", ObjClass.Userid }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_Approve_Merchant", parameters)
               .With<Approve_Merchant>()
               .Execute());

                if (results[0].Cast<Approve_Merchant>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/get_approve_merchants_list")]
        public async Task<Object> Get_Approve_Merchants_List([FromBody] Get_Approve_Merchants_List_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Merchant_Type_Id", ObjClass.Merchantcategory },
                    { "FromDate", ObjClass.FromDate },
                    { "ToDate", ObjClass.ToDate }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_Get_Approve_Merchants_List", parameters)
               .With<Get_Approve_Merchants_List>()
               .Execute());

                List<Get_Approve_Merchants_List> item = results[0].Cast<Get_Approve_Merchants_List>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/update_merchant")]
        public async Task<Object> Update_Merchant([FromBody] Update_Merchant_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"Merchantid", ObjClass.Merchantid },
                    {"OutletName", ObjClass.OutletName },
                    {"Perm_Address1", ObjClass.Perm_Address1 },
                    {"Perm_Address2", ObjClass.Perm_Address2 },
                    {"Perm_Address3", ObjClass.Perm_Address3 },
                    {"Perm_Location", ObjClass.Perm_Location },
                    {"Perm_District", ObjClass.Perm_District },
                    {"Perm_City", ObjClass.Perm_City },
                    {"Perm_State", ObjClass.Perm_State },
                    {"Perm_PIN_Code", ObjClass.Perm_PIN_Code },
                    {"Perm_std_code", ObjClass.Perm_std_code },
                    {"Perm_Ph_Off", ObjClass.Perm_Ph_Off },
                    {"Perm_fax", ObjClass.Perm_fax },
                    {"ERP_Code", ObjClass.ERP_Code },
                    {"Outlet_Category", ObjClass.Outlet_Category },
                    {"PANNo", ObjClass.PANNo },
                    {"GSTNo", ObjClass.GSTNo },
                    {"Dealer_name", ObjClass.Dealer_name },
                    {"Highway_Name", ObjClass.Highway_Name },
                    {"Highway_No", ObjClass.Highway_No },
                    {"CautionAmt_DTP", ObjClass.CautionAmt_DTP },
                    {"CautionAmt_HP", ObjClass.CautionAmt_HP },
                    {"LPGSale", ObjClass.LPGSale },
                    {"MSSale", ObjClass.MSSale },
                    {"SBU_TYpe", ObjClass.SBU_TYpe },
                    {"MonthlyHSD", ObjClass.MonthlyHSD },
                    {"Zonal_Office", ObjClass.Zonal_Office },
                    {"Regional_Office", ObjClass.Regional_Office },
                    {"SalesArea", ObjClass.SalesArea },
                    {"Comm_Address1", ObjClass.Comm_Address1 },
                    {"Comm_Address2", ObjClass.Comm_Address2 },
                    {"Comm_Address3", ObjClass.Comm_Address3 },
                    {"Comm_Location", ObjClass.Comm_Location },
                    {"Comm_City", ObjClass.Comm_City },
                    {"Comm_State", ObjClass.Comm_State },
                    {"Comm_District", ObjClass.Comm_District },
                    {"Comm_PIN_Code", ObjClass.Comm_PIN_Code },
                    {"Comm_std_code", ObjClass.Comm_std_code },
                    {"Comm_Ph_Off", ObjClass.Comm_Ph_Off },
                    {"Comm_Fax", ObjClass.Comm_Fax },
                    {"NoofLiveTerminals", ObjClass.NoofLiveTerminals },
                    {"Terminal_Type", ObjClass.Terminal_Type },
                    {"CreatedBy", ObjClass.CreatedBy },
                    {"Merchant_Type_Id", ObjClass.Merchant_Type_Id },
                    {"Comm_Mobile", ObjClass.Comm_Mobile },
                    {"Comm_Email", ObjClass.Comm_Email },
                    {"Name", ObjClass.Name },
                    {"email", ObjClass.Email },
                    {"Mobile", ObjClass.Mobile },
                    {"groupid", ObjClass.Groupid },
                    {"groupname", ObjClass.Groupname },
                    {"password_val", ObjClass.Store_password },
                    {"Userid", ObjClass.Userid }

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_Update_Merchant", parameters)
               .With<Update_Merchant>()
               .Execute());

                if (results[0].Cast<Update_Merchant>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/get_pending_mobile_dispensers_list")]
        public async Task<Object> Get_Pending_Mobile_Dispensers_List([FromBody] Get_Pending_Mobile_Dispensers_List_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "MobileDispenserId", ObjClass.MobileDispenserId },
                    { "FromDate", ObjClass.FromDate },
                    { "ToDate", ObjClass.ToDate }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_Get_Pending_Mobile_Dispensers_List", parameters)
               .With<Get_Pending_Mobile_Dispensers_List>()
               .Execute());

                List<Get_Pending_Mobile_Dispensers_List> item = results[0].Cast<Get_Pending_Mobile_Dispensers_List>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/approve_pending_mobile_dispenser")]
        public async Task<Object> Approve_Pending_Mobile_Dispenser([FromBody] Approve_Pending_Mobile_Dispenser_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "MobileDispenserId", ObjClass.MobileDispenserId },
                    { "Remarks", ObjClass.Remarks },
                    { "Status", ObjClass.Status },
                    { "Userid", ObjClass.Userid }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_Approve_Pending_Mobile_Dispenser", parameters)
               .With<Approve_Pending_Mobile_Dispenser>()
               .Execute());

                List<Approve_Pending_Mobile_Dispenser> item = results[0].Cast<Approve_Pending_Mobile_Dispenser>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/list_of_hotlisted_merchants")]
        public async Task<Object> List_Of_Hotlisted_Merchants([FromBody] List_Of_Hotlisted_Merchants_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                String[] strlist = ObjClass.HotList_Month_Year.Split('-');
                int month_val = DateTime.ParseExact(strlist[0].ToString(), "MMMM", new CultureInfo("en-US")).Month;
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "MerchantId", ObjClass.MerchantId },
                    { "Merchant_ZO", ObjClass.Merchant_ZO },
                    { "Merchant_RO", ObjClass.Merchant_RO },
                    { "HotList_Year", strlist[1].ToString()},
                    { "HotList_Month", month_val},
                    { "Status", ObjClass.Status }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_List_Of_Hotlisted_Merchants", parameters)
               .With<List_Of_Hotlisted_Merchants>()
               .Execute());

                List<List_Of_Hotlisted_Merchants> item = results[0].Cast<List_Of_Hotlisted_Merchants>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/approve_reject_hotlisted_merchant")]
        public async Task<Object> Approve_Reject_Hotlisted_Merchant ([FromBody] Approve_Reject_Hotlisted_Merchant_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "MerchantId", ObjClass.MerchantId },
                    { "Status", ObjClass.Status },
                    { "Remarks", ObjClass.Remarks },
                    { "Userid", ObjClass.Userid }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_Approve_Reject_Hotlisted_Merchant", parameters)
               .With<Approve_Reject_Hotlisted_Merchant>()
               .Execute());

                List<Approve_Reject_Hotlisted_Merchant> item = results[0].Cast<Approve_Reject_Hotlisted_Merchant>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/list_of_mobiledispenser_merchant_terminal_mapping")]
        public async Task<Object> List_Of_Mobiledispenser_Merchant_Terminal_Mapping([FromBody] List_Of_Mobiledispenser_Merchant_Terminal_Mapping_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "MobileDispenserId", ObjClass.MobileDispenserId },
                    { "FromDate", ObjClass.FromDate },
                    { "ToDate", ObjClass.ToDate }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_List_Of_Mobiledispenser_Merchant_Terminal_Mapping", parameters)
               .With<List_Of_Mobiledispenser_Merchant_Terminal_Mapping>()
               .Execute());

                List<List_Of_Mobiledispenser_Merchant_Terminal_Mapping> item = results[0].Cast<List_Of_Mobiledispenser_Merchant_Terminal_Mapping>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/approve_reject_mobiledispenser_merchant_terminal_mapping")]
        public async Task<Object> Approve_Reject_Mobiledispenser_Merchant_Terminal_Mapping([FromBody] Approve_Reject_Mobiledispenser_Merchant_Terminal_Mapping_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "MobileDispenserId", ObjClass.MobileDispenserId },
                    { "MerchantId", ObjClass.MerchantId },
                    { "TerminalId", ObjClass.TerminalId },
                    { "Status", ObjClass.Status },
                    { "Remarks", ObjClass.Remarks },
                    { "Userid", ObjClass.Userid }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_Approve_Reject_Mobiledispenser_Merchant_Terminal_Mapping", parameters)
               .With<Approve_Reject_Mobiledispenser_Merchant_Terminal_Mapping>()
               .Execute());

                List<Approve_Reject_Mobiledispenser_Merchant_Terminal_Mapping> item = results[0].Cast<Approve_Reject_Mobiledispenser_Merchant_Terminal_Mapping>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/merchant/search_by_merchant")]
        public async Task<Object> Search_By_Merchant([FromBody] Search_By_Merchant_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Merchantid", ObjClass.Merchantid },
                    { "ERPCode", ObjClass.ERPCode },
                    { "Outlet_name", ObjClass.Outlet_name },
                    { "City", ObjClass.City },
                    { "Highway_No", ObjClass.Highway_No},
                    { "Status", ObjClass.Status}
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Merchant_Search_By_Merchant", parameters)
               .With<Search_By_Merchant>()
               .Execute());

                List<Search_By_Merchant> item = results[0].Cast<Search_By_Merchant>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }
    }
}
