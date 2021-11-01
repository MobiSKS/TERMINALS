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
using static MQWebAPI.Models.RBE;
using static MQWebAPI.MQSupportClass.StatusMessage;

namespace MQWebAPI.Controllers
{
    public class RBEController : ApiController
    {


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/rbe/get_all_rbe_list")]
        public async Task<Object> Get_All_RBE_List([FromBody] Get_All_RBE_List_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_RBE_Get_All_RBE_List]", parameters)
               .With<Get_All_RBE_List>()
               .Execute());
                List<Get_All_RBE_List> item = results[0].Cast<Get_All_RBE_List>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail,  results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/rbe/get_all_rbe_list_changemob")]
        public async Task<Object> Get_All_RBE_List_Changemob([FromBody] Get_All_RBE_List_Changemob_Input ObjClass)
        {
             if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                     {
                    { "RBEid", ObjClass.RBEid },
                    { "ApprovalStatus", ObjClass.ApprovalStatus },
                    { "FirstName", ObjClass.FirstName }
                };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_RBE_Get_All_RBE_List_Changemob]", parameters)
               .With<Get_All_RBE_List_Changemob>()
               .Execute());
                List<Get_All_RBE_List_Changemob> item = results[0].Cast<Get_All_RBE_List_Changemob>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK,  true, (int)StatusInformation.Success,  results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK,  false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/rbe/approve_changed_rbe")]
        public async Task<Object> Approve_Changed_RBE([FromBody] Approve_Changed_RBE_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "newrbemobileno", ObjClass.newrbemobileno },
                    { "oldrbemobileno", ObjClass.oldrbemobileno },
                    { "oldrbename", ObjClass.oldrbename },
                    { "fromlocation", ObjClass.fromlocation },
                    { "tolocation", ObjClass.tolocation },
                    { "approvaltype", ObjClass.approvaltype }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_RBE_Approve_Changed_RBE", parameters)
               .With<Approve_Changed_RBE>()
               .Execute());

                if (results[0].Cast<Approve_Changed_RBE>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/rbe/get_enroll_newCards")]
        public async Task<Object> Get_Enroll_NewCards([FromBody] Get_Enroll_NewCards_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "CreatedBy", ObjClass.CreatedBy }
                };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_RBE_Get_Enroll_NewCards]", parameters)
               .With<Get_Enroll_NewCards>()
               .Execute());
                List<Get_Enroll_NewCards> item = results[0].Cast<Get_Enroll_NewCards>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/rbe/get_rbe_dashboard")]
        public async Task<Object> Get_RBE_Dashboard([FromBody] Get_RBE_Dashboard_Input ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Userid", ObjClass.Userid }
                };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_RBE_Get_RBE_Dashboard]", parameters)
               .With<Get_RBE_Dashboard>()
               .Execute());
                List<Get_RBE_Dashboard> item = results[0].Cast<Get_RBE_Dashboard>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }
    }
}
