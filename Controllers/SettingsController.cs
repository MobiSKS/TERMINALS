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
using static MQWebAPI.Models.Settings;
using static MQWebAPI.MQSupportClass.StatusMessage;

namespace MQWebAPI.Controllers
{
    public class SettingsController : ApiController
    {


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_customer_type")]
        public async Task<Object> Customer_Types([FromBody] SettingsInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_Settings_Get_Customer_Type]", parameters)
               .With<Customer_Types>()
               .Execute());
                List<Customer_Types> item = results[0].Cast<Customer_Types>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_customer_sub_type")]
        public async Task<Object> Customer_Sub_Types([FromBody] SettingsCustomerTypeInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "customer_type_id", ObjClass.Customer_Type_Id }
                    };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_Customer_Sub_Type", parameters)
               .With<Customer_Sub_Types>()
               .Execute());
                List<Customer_Sub_Types> item = results[0].Cast<Customer_Sub_Types>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }


        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_customer_tier")]
        public async Task<Object> Customer_Tier([FromBody] SettingsInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_Customer_Slab", parameters)
               .With<Customer_Tier_Details>()
               .Execute());
                List<Customer_Tier_Details> item = results[0].Cast<Customer_Tier_Details>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_sales_area")]
        public async Task<Object> Get_Sales_Area([FromBody] SettingsInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_District", parameters)
               .With<Sales_Area>()
               .Execute());
                List<Sales_Area> item = results[0].Cast<Sales_Area>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_country")]
        public async Task<Object> Get_Country([FromBody] SettingsInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_Country", parameters)
               .With<Country_Detail>()
               .Execute());
                List<Country_Detail> item = results[0].Cast<Country_Detail>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }


        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_state")]
        public async Task<Object> Get_State([FromBody] SettingsInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_State", parameters)
               .With<State_Detail>()
               .Execute());
                List<State_Detail> item = results[0].Cast<State_Detail>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_zone")]
        public async Task<Object> Get_Zone([FromBody] SettingsInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_Zones", parameters)
               .With<Zones_Detail>()
               .Execute());
                List<Zones_Detail> item = results[0].Cast<Zones_Detail>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_city")]
        public async Task<Object> Get_City([FromBody] SettingsStateInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "State_Id", ObjClass.State_Id },

                    };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_City", parameters)
               .With<City_Detail>()
               .Execute());
                List<City_Detail> item = results[0].Cast<City_Detail>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }


        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_zonal_office")]
        public async Task<Object> Get_Zonal_Office([FromBody] SettingsInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_Zonal_Office", parameters)
               .With<Zonal_Office>()
               .Execute());
                List<Zonal_Office> item = results[0].Cast<Zonal_Office>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_sbu")]
        public async Task<Object> Get_SBU([FromBody] SettingsInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_SBU", parameters)
               .With<SBU_Detail>()
               .Execute());
                List<SBU_Detail> item = results[0].Cast<SBU_Detail>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_customer_status")]
        public async Task<Object> Get_Customer_Status([FromBody] SettingsEntityTypeInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "EntityType_id", ObjClass.Entity_Type_Id },
                    };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_Entity_Types", parameters)
               .With<Entity_Types>()
               .Execute());
                List<Entity_Types> item = results[0].Cast<Entity_Types>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }


        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_all_roles")]
        public async Task<Object> Get_All_Roles([FromBody] SettingsRollNameInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "Role_Name", ObjClass.Role_Name },

                    };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_All_Roles", parameters)
               .With<All_Roll_Detail>()
               .Execute());
                List<All_Roll_Detail> item = results[0].Cast<All_Roll_Detail>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }


        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_district")]
        public async Task<Object> Get_District([FromBody] SettingsInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_District", parameters)
               .With<District>()
               .Execute());
                List<District> item = results[0].Cast<District>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_defaultvalues_card")]
        public async Task<Object> Get_Defaultvalues_Card([FromBody] SettingsDefaultvaluesCardInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {

                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "Default_Type", ObjClass.Default_type },

                    };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_Defaultvalues_Card", parameters)
               .With<Default_Values_Card>()
               .Execute());

                List<Default_Values_Card> item = results[0].Cast<Default_Values_Card>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_all_hqzone_mapping")]
        public async Task<Object> Get_All_HQZone_Mapping([FromBody] SettingsInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_All_HQZone_Mapping", parameters)
               .With<All_HQZone_Mapping>()
               .Execute());

                List<All_HQZone_Mapping> item = results[0].Cast<All_HQZone_Mapping>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_head_offices")]
        public async Task<Object> Get_Head_Offices([FromBody] SettingsInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_Head_Offices", parameters)
               .With<Head_Offices>()
               .Execute());

                List<Head_Offices> item = results[0].Cast<Head_Offices>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/update_head_offices")]
        public async Task<Object> Update_Head_Offices([FromBody] SettingsHeadOfficeInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "HO_Code", ObjClass.HO_Code },
                    { "HO_Name", ObjClass.HO_Name },
                    { "HO_Short_Name", ObjClass.HO_Short_Name }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Update_Head_Offices", parameters)
               .With<Settings_Output>()
               .Execute());
                if (results[0].Cast<Settings_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/insert_and_update_zone")]
        public async Task<Object> Insert_And_Update_Zone([FromBody] SettingsZOInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "ZO_Code", ObjClass.ZO_Code },
                    { "ZO_Name", ObjClass.ZO_Name },
                    { "ZO_Short_Name", ObjClass.ZO_Short_Name },
                    { "ZO_ERP_Code", ObjClass.ZO_ERP_Code },
                    { "State_Id", ObjClass.State_Id }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Insert_and_Update_Zone", parameters)
               .With<Settings_Output>()
               .Execute());

                if (results[0].Cast<Settings_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/enabled_disabled_zone")]
        public async Task<Object> Enabled_Disabled_Zone([FromBody] SettingsZOInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "ZO_Code", ObjClass.ZO_Code },
                    { "E_D_Status", ObjClass.E_D_Status }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Enabled_Disabled_Zone", parameters)
               .With<Settings_Output>()
               .Execute());

                if (results[0].Cast<Settings_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_regional_office_details")]
        public async Task<Object> Get_Regional_Office_Details([FromBody] Regional_office_details_Input ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Zone_code", ObjClass.Zone_code }
                };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_Regional_Office_Details", parameters)
               .With<Regional_Office>()
               .Execute());

                List<Regional_Office> item = results[0].Cast<Regional_Office>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/insert_and_update_regional_office")]
        public async Task<Object> Insert_And_Update_Regional_Office([FromBody] Regional_Office_Input ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "RO_Code", ObjClass.RO_Code },
                    { "RO_Name", ObjClass.RO_Name },
                    { "RO_Short_Name", ObjClass.RO_Short_Name },
                    { "RO_ERP_Code", ObjClass.RO_ERP_Code },
                    { "ZO_Code", ObjClass.ZO_Code },
                    { "HO_Code", ObjClass.HO_Code },
                    { "District_Code", ObjClass.District_Code },

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Insert_and_Update_Regional", parameters)
               .With<Settings_Output>()
               .Execute());

                if (results[0].Cast<Settings_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/enabled_disabled_regional_office")]
        public async Task<Object> Enabled_Disabled_Regional_Office([FromBody] Regional_Office_Input ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "RO_Code", ObjClass.RO_Code },
                    { "E_D_Status", ObjClass.E_D_Status }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Enabled_Disabled_Regional_Office", parameters)
               .With<Settings_Output>()
               .Execute());

                if (results[0].Cast<Settings_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/insert_and_update_state")]
        public async Task<Object> Insert_And_Update_State([FromBody] State_Input ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    //{ "State_Id", ObjClass.State_Id },
                    { "State_Name", ObjClass.State_Name },
                    { "State_Code", ObjClass.State_Code },
                    { "State_Short_Name", ObjClass.State_Short_Name },
                    { "Country_Reg_Code", ObjClass.Country_Reg_Code },
                    { "ZO_Code", ObjClass.ZO_Code },

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Insert_and_Update_State", parameters)
               .With<Settings_Output>()
               .Execute());

                if (results[0].Cast<Settings_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/enabled_disabled_state")]
        public async Task<Object> Enabled_Disabled_State([FromBody] State_Enable_Disable_Input ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "State_Code", ObjClass.State_Code },
                    { "E_D_Status", ObjClass.E_D_Status }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Enabled_Disabled_State", parameters)
               .With<Settings_Output>()
               .Execute());

                if (results[0].Cast<Settings_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/insert_and_update_district")]
        public async Task<Object> Insert_And_Update_District([FromBody] District_Input ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "District_Code", ObjClass.District_Code },
                    { "District_Name", ObjClass.District_Name },
                    { "District_Short_Name", ObjClass.District_Short_Name },
                    { "City_Code", ObjClass.City_Code },
                    { "State_Code", ObjClass.State_Code },
                    { "RO_Code", ObjClass.RO_Code },

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Insert_and_Update_District", parameters)
               .With<Settings_Output>()
               .Execute());

                if (results[0].Cast<Settings_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/enabled_disabled_district")]
        public async Task<Object> Enabled_Disabled_District([FromBody] District_Enable_Disable_Input ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "District_Code", ObjClass.District_Code },
                    { "E_D_Status", ObjClass.E_D_Status }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Enabled_Disabled_District", parameters)
               .With<Settings_Output>()
               .Execute());

                if (results[0].Cast<Settings_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/insert_and_update_city")]
        public async Task<Object> Insert_And_Update_City([FromBody] City_Input ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "City_Id", ObjClass.City_Id },
                    { "City_Name", ObjClass.City_Name },
                    { "City_Code", ObjClass.City_Code },
                    { "City_Short_Name", ObjClass.City_Short_Name },
                    { "District_Code", ObjClass.District_Code },
                    { "State_Code", ObjClass.State_Code },

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Insert_and_Update_City", parameters)
               .With<Settings_Output>()
               .Execute());

                if (results[0].Cast<Settings_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/enabled_disabled_city")]
        public async Task<Object> Enabled_Disabled_City([FromBody] City_Input ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "City_Id", ObjClass.City_Id },
                    { "E_D_Status", ObjClass.E_D_Status }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Enabled_Disabled_City", parameters)
               .With<Settings_Output>()
               .Execute());

                if (results[0].Cast<Settings_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/activate_deactivate_entity")]
        public async Task<Object> Activate_Deactivate_Entity([FromBody] Entity_Type_Input ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Entity_Type", ObjClass.Entity_Type },
                    { "Entity_Id", ObjClass.Entity_Id },
                    { "Action", ObjClass.Action },
                    { "Reason", ObjClass.Reason },
                    { "Remarks", ObjClass.Remarks },
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Activate_Deactivate_Entity", parameters)
               .With<Settings_Output>()
               .Execute());

                if (results[0].Cast<Settings_Output>().ToList()[0].Status == 1)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_activate_deactivate_entity")]
        public async Task<Object> Get_Activate_Deactivate_Entity([FromBody] Entity_Type_Input ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Entity_Type", ObjClass.Entity_Type },
                    { "Entity_Id", ObjClass.Entity_Id },
                    { "Report_Check_Status", ObjClass.Report_Check_Status },
                    { "From_Date", ObjClass.From_Date },
                    { "To_Date", ObjClass.To_Date },

                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_Activate_Deactivate_Entity", parameters)
               .With<Regional_Office>()
               .Execute());

                List<Entity_Type_Output> item = results[0].Cast<Entity_Type_Output>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_merchant_type")]
        public async Task<Object> Get_Merchant_Type([FromBody] SettingsInput ObjClass)
        {
            
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Settings_Get_Merchant_Type", parameters)
               .With<Merchant_Type>()
               .Execute());
                List<Merchant_Type> item = results[0].Cast<Merchant_Type>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_entity_type")]
        public async Task<Object> Get_Entity_Type([FromBody] SettingsEntityGroupTypeInput ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Entity_Group", ObjClass.Entity_Group },

                };
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Setting_Get_Type", parameters)
               .With<Vehicle_Type>()
               .Execute());
                List<Vehicle_Type> item = results[0].Cast<Vehicle_Type>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/dtplus/settings/get_id_proofs_list")]
        public async Task<Object> Get_Id_Proofs_List([FromBody] SettingsInput ObjClass)
        {
            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Setting_Get_Id_Proofs_List", parameters)
               .With<Proof_Type>()
               .Execute());
                List<Proof_Type> item = results[0].Cast<Proof_Type>().ToList();
                if (item.Count > 0)
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                else
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
            }

        }


    }
}
