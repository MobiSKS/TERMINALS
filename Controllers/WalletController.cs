using HPCL_DP_Terminal.App_Start;
using HPCL_DP_Terminal.Helpers;
using HPCL_DP_Terminal.Models;
using HPCL_DP_Terminal.MQSupportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using static HPCL_DP_Terminal.MQSupportClass.StatusMessage;

namespace HPCL_DP_Terminal.Controllers
{
    public class WalletController : ApiController
    {
        /*

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/set_sale_limits_of_cards")]
        public async Task<Object> Set_Sale_Limits_Of_Cards([FromBody] SaleLimitsofCards ObjClass)
        {
            //var actionName = this.ActionContext.ActionDescriptor.ActionName;
            //var controllerName = this.ControllerContext.ControllerDescriptor.ControllerName;


            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {

                 { "cardno", ObjClass.Card_no },
                 { "mobileno", ObjClass.Mobile_no },
                 { "vehicleno", ObjClass.Vehicle_no },
                 { "typeoflimit", ObjClass.Type_of_limit },
                 { "limitvalue", ObjClass.Limit_value }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Cardlimit_Mapping", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/set_ccms_limits_for_all_cards")]
        public async Task<Object> Set_CCMS_Limits_For_All_Cards([FromBody] CCMSLimitsforAllCards ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "CCMSDailyLimit", ObjClass.Limitvalue },
                { "customer_id", ObjClass.Customer_id },
                { "typeoflimit", ObjClass.Typeoflimit }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_Wallet_CCMS_Limits_For_All_Cards]", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, null);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/set_ccms_limits_for_indv_cards")]
        public async Task<Object> Set_CCMS_Limits_For_Indv_Cards([FromBody] CCMSLimitsforIndvCards ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "CCMSDailyLimit", ObjClass.Limitvalue },
                { "customer_id", ObjClass.Customer_id },
                 { "cardno", ObjClass.Cardno }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_Wallet_CCMS_Limits_For_Indv_Cards]", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, null);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/set_all_limits_for_indv_cards")]
        public async Task<Object> Set_All_Limits_For_Indv_Cards([FromBody] Set_All_Limits_for_Indv_Cards ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                var dtDBR = new System.Data.DataTable("udt_indv_card_det");
                dtDBR.Columns.Add("Cardno", typeof(Int64));
                dtDBR.Columns.Add("Mobileno", typeof(Int64));
                dtDBR.Columns.Add("Typeoflimit", typeof(string));
                dtDBR.Columns.Add("Limitvalue", typeof(decimal));

                if (ObjClass.Indv_card_Det != null)
                {
                    foreach (Indv_Card_Det item in ObjClass.Indv_card_Det)
                    {
                        System.Data.DataRow dr = dtDBR.NewRow();
                        dr["Cardno"] = item.Card_no;
                        dr["Mobileno"] = item.Mobileno;
                        dr["Typeoflimit"] = item.Typeoflimit;
                        dr["Limitvalue"] = item.Limitvalue;
                        dtDBR.Rows.Add(dr);
                        dtDBR.AcceptChanges();
                    }
                }

                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "CustomerId", ObjClass.Customer_id },
                { "Indv_card_Det", dtDBR }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_Wallet_Set_all_limits_for_indv_cards]", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, null);
                }
            }
        }




        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/search_card_mapping")]
        public async Task<Object> Search_Card_Mapping([FromBody] SearchcardmappingInput ObjClass)
        {

            //CRUD.InsertAPIEntryLogFile(MethodName, JsonConvert.SerializeObject(ObjClass), "Input Wallet Request", ObjClass.Useragent, ObjClass.Userip, ObjClass.Userid);

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                    null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "merchantid", ObjClass.Merchantid },
                { "customerid", ObjClass.Customer_id },
                { "cardno", ObjClass.Card_no }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_Wallet_Search_Card_Mapping]", parameters)
               .With<Searchcardmapping>()
               .Execute());

                if (results[0].Cast<Searchcardmapping>().ToList().Count == 0)
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
        [Route("api/edc/wallet/delete_card_mapping")]
        public async Task<Object> Delete_Card_Mapping([FromBody] Deletecardmapping ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "merchantid", ObjClass.Merchantid },
                { "customer_id", ObjClass.Customer_id },
                { "cardno", ObjClass.Cardno }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_Wallet_Delete_Card_Mapping]", parameters)
               .With<DataInsertion>()
               .Execute());


                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, null);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/get_all_cards_by_customer_id")]
        public async Task<Object> Get_All_Cards_By_Customer_Id([FromBody] AllcardsbycustomeridInput ObjClass)
        {



            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                    null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "customer_id", ObjClass.Customer_id }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_Wallet_All_Cards_By_Customer_Id]", parameters)
               .With<Allcardsbycustomerid>()
               .With<Cardarr>()
               .Execute());

                var output = new Allcardsbycustomerid()
                {
                    Customer_Id = results[0].Cast<Allcardsbycustomerid>().ToList()[0].Customer_Id,
                    Customer_Name = results[0].Cast<Allcardsbycustomerid>().ToList()[0].Customer_Name,
                    ZO = results[0].Cast<Allcardsbycustomerid>().ToList()[0].ZO,
                    RO = results[0].Cast<Allcardsbycustomerid>().ToList()[0].RO,
                    Cardarr = results[1].Cast<Cardarr>().ToList(),// results[0],              
                };

                if (results[0].Cast<Allcardsbycustomerid>().ToList().Count == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, output);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/map_card_to_merchant")]
        public async Task<Object> Map_Card_To_Merchant([FromBody] MapcardtomerchantInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "merchantid", ObjClass.Merchant_id },
                { "customerid", ObjClass.Customer_id },
                { "cardno", ObjClass.Card_no },
                { "vehicleno", ObjClass.Vehicle_no },
                { "typeofmapping", ObjClass.Type_of_mapping }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Map_Card_To_Merchant", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, null);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/deactivate_reactivate_cards")]
        public async Task<Object> Deactivate_Reactivate_Cards([FromBody] DeactivateReactivatecardsInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "cardno", ObjClass.Cardno },
                { "vehicleno", ObjClass.Vehicleno },
                { "mobileno", ObjClass.Mobileno },
                { "status", ObjClass.Status }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Deactivate_Reactivate_Cards", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, null);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/get_enabled_services")]
        public async Task<Object> Get_Enabled_Services([FromBody] Get_Enabled_ServicesInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "cardno", ObjClass.Cardno },
                { "mobileno", ObjClass.Mobileno },
                { "customerid", ObjClass.Customer_id },

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Get_Enabled_Services", parameters)
               .With<Getenabledservices>()
               .Execute());

                if (results[0].Cast<Getenabledservices>().ToList().Count == 0)
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
        [Route("api/edc/wallet/updating_services")]
        public async Task<Object> Updating_Services([FromBody] UpdatingServicesInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                    null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "mobileno", ObjClass.Mobileno },
                { "customerid", ObjClass.Customer_id },
                { "cardno", ObjClass.Cardno },
                { "serviceid", ObjClass.Servicesarr },
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_UpdatingServices", parameters)
               .With<Getenabledservices>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, null);
                }
            }
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/replacement_cards")]
        public async Task<Object> Replacement_Cards([FromBody] ReplacementCardsInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                    null);
            }
            else
            {

                var dtDBR = new System.Data.DataTable("udt_card_no");
                dtDBR.Columns.Add("Card_No", typeof(Int64));

                var dtDBR_New = new System.Data.DataTable("udt_card_no");
                dtDBR_New.Columns.Add("Card_No", typeof(Int64));


                if (ObjClass.Newcardnoarr != null)
                {
                    foreach (ArrCardNo item in ObjClass.Newcardnoarr)
                    {
                        System.Data.DataRow dr = dtDBR_New.NewRow();
                        dr["Card_No"] = item.Card_No;

                        dtDBR_New.Rows.Add(dr);
                        dtDBR_New.AcceptChanges();
                    }
                }


                if (ObjClass.Oldcardnoarr != null)
                {
                    foreach (ArrCardNo item in ObjClass.Oldcardnoarr)
                    {
                        System.Data.DataRow dr = dtDBR.NewRow();
                        dr["Card_No"] = item.Card_No;

                        dtDBR.Rows.Add(dr);
                        dtDBR.AcceptChanges();
                    }
                }


                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {

                { "customerid", ObjClass.Customer_id },
                { "Oldcardnoarr", ObjClass.Oldcardnoarr },
                { "Newcardnoarr", ObjClass.Newcardnoarr },
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_ReplacementCards", parameters)
               .With<Getenabledservices>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, null);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/Search_Card")]
        public async Task<Object> Search_Card([FromBody] SearchCardInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {

                { "customerid", ObjClass.Customer_id },
                { "mobileno", ObjClass.Mobileno },
                { "cardno", ObjClass.Cardno },
                { "vehicleno", ObjClass.Vehicleno }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Search_Card", parameters)
               .With<SearchCard>()
               .Execute());

                if (results[0].Cast<SearchCard>().ToList().Count == 0)
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
        [Route("api/edc/wallet/Get_Card_details_By_CardNo")]
        public async Task<Object> Get_Card_details_By_CardNo([FromBody] CarddetailsByCardNoInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {

                { "cardno", ObjClass.Cardno },
                { "vehicleno", ObjClass.Vehicleno }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Card_details_By_Card_No", parameters)
               .With<CarddetailsByCardNo>()
               .Execute());

                if (results[0].Cast<CarddetailsByCardNo>().ToList().Count == 0)
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
        [Route("api/edc/wallet/View_Card_Limits")]
        public async Task<Object> View_Card_Limits([FromBody] ViewCardLimitsInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "customer_id", ObjClass.Customer_id }
                //{ "mobileno", ObjClass.mobileno },
                //{ "cardno", ObjClass.cardno },
                //{ "vehicleno", ObjClass.vehicleno }
                };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_View_Card_Limits", parameters)
               .With<ViewCardLimits>()
               .Execute());

                if (results[0].Cast<ViewCardLimits>().ToList().Count == 0)
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
        [Route("api/edc/wallet/Map_Mobile_No")]
        public async Task<Object> Map_Mobile_No([FromBody] Map_Mobile_NoInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "mobileno", ObjClass.Mobileno },
                { "cardno", ObjClass.Cardno },
                { "vehicleno", ObjClass.Vehicleno }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Map_Mobile_No", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, null);
                }
            }
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/Get_Balance_by_Customerid")]
        public async Task<Object> Get_Balance_by_Customerid([FromBody] BalancebyCustomeridInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "customer_id", ObjClass.Customer_id }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Get_Balance_by_Customerid", parameters)
               .With<BalancebyCustomerid>()
               .Execute());

                if (results[0].Cast<BalancebyCustomerid>().ToList().Count == 0)
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
        [Route("api/edc/wallet/Get_CCMS_Balance_Detail_by_Customerid")]
        public async Task<Object> Get_CCMS_Balance_Detail_by_Customerid([FromBody] BalancebyCustomeridInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "customer_id", ObjClass.Customer_id }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Get_CCMS_Balance_Detail_by_Customerid", parameters)
               .With<CCMSBalanceDetailbyCustomerid>()
               .Execute());

                if (results[0].Cast<CCMSBalanceDetailbyCustomerid>().ToList().Count == 0)
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
        [Route("api/edc/wallet/Get_Drive_stars_Detail_by_Customerid")]
        public async Task<Object> Get_Drive_stars_Detail_by_Customerid([FromBody] BalancebyCustomeridInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "customer_id", ObjClass.Customer_id }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Get_Drive_stars_Detail_by_Customerid", parameters)
               .With<DrivestarsDetailbyCustomerid>()
               .Execute());

                if (results[0].Cast<DrivestarsDetailbyCustomerid>().ToList().Count == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }

        */

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/get_wallet_balance_limit")]
        public async Task<Object> Get_wallet_balance_limit([FromBody] GetWalletBalanceLimitInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Card_no", ObjClass.Card_no }
                //{ "tid", ObjClass.TID },
                //{ "outletid", ObjClass.Outlet_id }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Get_wallet_balance_limit", parameters)
               .With<GetWalletBalanceLimit>()
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
        [Route("api/edc/wallet/get_wallet_balance_by_mobileno")]
        public async Task<Object> Get_wallet_balance_by_MobileNo([FromBody] GetWalletBalanceByMobileInput ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "mobileno", ObjClass.Mobileno }
                //{ "tid", ObjClass.TID },
                //{ "outletid", ObjClass.Outlet_id }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Get_wallet_balance_by_MobileNo", parameters)
               .With<GetWalletBalanceLimit>()
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
        [Route("api/edc/wallet/check_transaction_valuevslimit")]
        public async Task<Object> Check_Transaction_ValuevsLimit([FromBody] CheckTransactionValuevsLimit_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {

                { "Card_No", ObjClass.Card_No },
                { "Sale_Amount", ObjClass.Sale_Amount }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Check_Transaction_ValuevsLimit", parameters)
               .With<CheckTransactionValuevsLimit>()
               .Execute());

                if (results[0].Cast<CheckTransactionValuevsLimit>().ToList().Count == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }


        //[HttpPost]
        //[CustomAuthenticationFilter]
        //[Route("api/edc/wallet/Get_Loyalty_Balance_By_Card_No")]
        //public async Task<Object> Get_Loyalty_Balance_By_Card_No([FromBody] LoyaltyBalanceByCardNoInput ObjClass)
        //{

        //    if (ObjClass == null)
        //    {
        //        return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
        //    }
        //    else
        //    {
        //        Dictionary<string, object> parameters = new Dictionary<string, object>()
        //    {
        //        { "Controlcardno", ObjClass.Controlcardno },
        //        { "Controlpin", ObjClass.Controlpin },
        //        //{ "TID", ObjClass.TID },
        //        //{ "OutletId", ObjClass.OutletId }

        //    };

        //        var results = await Task.Run(() => new DefaultContext()
        //       .MultipleResults("Usp_Wallet_Get_Loyalty_Balance_By_Card_No", parameters)
        //       .With<LoyaltyBalanceByCardNo>()
        //       .Execute());

        //        if (results[0].Cast<GetWalletBalanceLimit>().ToList().Count == 0)
        //        {
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
        //        }
        //        else
        //        {
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
        //        }
        //    }
        //}


        //[HttpPost]
        //[CustomAuthenticationFilter]
        //[Route("api/edc/wallet/Get_CCMS_Balance_By_Card_No")]
        //public async Task<Object> Get_CCMS_Balance_By_Card_No([FromBody] CCMSBalanceByCardNoInput ObjClass)
        //{

        //    if (ObjClass == null)
        //    {
        //        return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
        //    }
        //    else
        //    {
        //        Dictionary<string, object> parameters = new Dictionary<string, object>()
        //    {
        //        { "Controlcardno", ObjClass.Controlcardno },
        //        { "Controlpin", ObjClass.Controlpin }//,
        //        //{ "TID", ObjClass.TID },
        //        //{ "OutletId", ObjClass.OutletId }

        //    };

        //        var results = await Task.Run(() => new DefaultContext()
        //       .MultipleResults("Usp_Wallet_Get_CCMS_Balance_By_Card_No", parameters)
        //       .With<CCMSBalanceByCardNo>()
        //       .Execute());

        //        if (results[0].Cast<GetWalletBalanceLimit>().ToList().Count == 0)
        //        {
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
        //        }
        //        else
        //        {
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
        //        }
        //    }
        //}
        
        /*

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/Request_otc_card_by_region")]
        public async Task<Object> Request_otc_card_by_region([FromBody] Request_otc_card_by_region_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "region_id", ObjClass.Region_id },
                { "no_of_otc_cards", ObjClass.No_Of_OTC_Cards },
                { "otc_type", ObjClass.OTC_Type }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Request_otc_card_by_merchant", parameters) //Usp_Wallet_Request_otc_card_by_region
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, null);
                }
            }
        }



        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/Request_otc_card_by_merchant")]
        public async Task<Object> Request_otc_card_by_merchant([FromBody] Request_otc_card_by_merchant_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "merchant_id", ObjClass.Merchant_Id },
                { "no_of_otc_cards", ObjClass.No_Of_OTC_Cards },
                { "otc_type", ObjClass.OTC_Type }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Request_otc_card_by_merchant", parameters) //Usp_Wallet_Request_otc_card_by_region
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, null);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/view_requested_otc_card_by_region")]
        public async Task<Object> View_Requested_OTC_Card_By_Region([FromBody] Viewrequestedotccardbyregion_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "region_id", ObjClass.Region_id },
                { "card_type", ObjClass.Card_Type }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_view_requested_otc_card_by_region", parameters)
               .With<Viewrequestedotccardbyregion>()
               .Execute());

                if (results[0].Cast<Viewrequestedotccardbyregion>().ToList().Count == 0)
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
        [Route("api/edc/wallet/Get_Point_Equiv_Amt")]
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
                { "pointstoredeem", ObjClass.Pointstoredeem }
                //{ "tid", ObjClass.TID },
                //{ "outletid", ObjClass.Outlet_id }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Get_Point_Equiv_Amt", parameters)
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
        [Route("api/edc/wallet/Save_DTP_Loyalty_By_Card")]
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
                { "Amount", ObjClass.Amount }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Save_DTP_Loyalty_By_Card", parameters)
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
        [Route("api/edc/wallet/Save_DTP_Loyalty_By_Mobile_No")]
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
                { "Amount", ObjClass.Amount }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Save_DTP_Loyalty_By_Mobile_No", parameters)
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
        [Route("api/edc/wallet/Save_Non_DTP_Loyalty_By_Card")]
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
                { "Amount", ObjClass.Amount }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Save_Non_DTP_Loyalty_By_Card", parameters)
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
        [Route("api/edc/wallet/Save_Non_DTP_Loyalty_By_Mobile_No")]
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
                { "Amount", ObjClass.Amount }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Save_Non_DTP_Loyalty_By_Mobile_No", parameters)
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
        [Route("api/edc/wallet/Add_On_Card_Aggregator_Customer")]
        public async Task<Object> Add_On_Card_Aggregator_Customer([FromBody] Add_On_Card_Aggregator_Customer_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "NumberOfCard", ObjClass.NumberOfCard },
                { "CardPreference", ObjClass.CardPreference },
                { "CardArray", ObjClass.CardArray }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_User_Add_On_Card_Aggregator_Customer]", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/List_of_Pending_Card")]
        public async Task<Object> List_of_Pending_Card([FromBody] List_of_Pending_Card_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {

                { "CustomerId", ObjClass.Customer_id },
                { "Fromdate", ObjClass.From_date },
                { "Todate", ObjClass.To_date },
                { "FormNo", ObjClass.Form_No }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_List_of_Pending_Card", parameters)
               .With<List_of_Pending_Card>()
               .Execute());

                if (results[0].Cast<List_of_Pending_Card>().ToList().Count == 0)
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
        [Route("api/edc/wallet/Verify_Pending_Addon_Card_of_Aggregator")]
        public async Task<Object> Verify_Pending_Addon_Card_of_Aggregator([FromBody] Verify_Pending_Addon_Card_of_Aggregator_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "CustomerId", ObjClass.Customer_id },
                { "FormNo", ObjClass.FormNumber }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_Wallet_Verify_Pending_Addon_Card_of_Aggregator]", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/Approve_Card_for_Aggregation_Customer")]
        public async Task<Object> Approve_Card_for_Aggregation_Customer([FromBody] Approve_Card_for_Aggregation_Customer_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null,
                     null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "CustomerId", ObjClass.Customer_id },
                { "FormNo", ObjClass.FormNumber }

            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_Wallet_Approve_Card_for_Aggregation_Customer]", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/update_ccms_balance")]
        public async Task<Object> Update_CCMS_Balance([FromBody] UpdateCCMSBalance_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null
                    , null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {

                        { "Customer_Id", ObjClass.Customer_Id },
                        { "Amount", ObjClass.Amount },
                        { "Currency", ObjClass.Currency },
                        { "Paymentmode", ObjClass.Paymentmode },
                        { "Gatewayname", ObjClass.Gatewayname },
                        { "Bankname", ObjClass.Bankname },
                        { "TxnID", ObjClass.TxnID },
                        { "OrderID", ObjClass.OrderID },
                        { "TxnDate", ObjClass.TxnDate }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("[Usp_Wallet_Update_CCMS_Balance]", parameters)
               .With<DataInsertion>()
               .Execute());

                if (results[0].Cast<DataInsertion>().ToList()[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, results[0]);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/ccms_to_card_balance_transfer")]
        public async Task<Object> CCMS_To_Card_Balance_Transfer([FromBody] CCMSToCardBalanceTransfer_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Customer_Id", ObjClass.Customer_Id },
                { "Card_Number", ObjClass.Card_Number },
                { "Amount", ObjClass.Amount }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_CCMS_To_Card_Balance_Transfer", parameters)
               .With<CCMSToCardBalanceTransfer>()
               .Execute());

                List<CCMSToCardBalanceTransfer> item = results[0].Cast<CCMSToCardBalanceTransfer>().ToList();

                if (item[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, item[0].Reason);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/edc/wallet/card_to_card_balance_transfer")]
        public async Task<Object> Card_To_Card_Balance_Transfer([FromBody] CardToCardBalanceTransfer_Input ObjClass)
        {

            if (ObjClass == null)
            {
                return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
            }
            else
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Customer_Id", ObjClass.Customer_Id },
                { "From_Card_Number", ObjClass.From_Card_Number },
                { "To_Card_Number", ObjClass.To_Card_Number },
                { "Amount", ObjClass.Amount }
            };

                var results = await Task.Run(() => new DefaultContext()
               .MultipleResults("Usp_Wallet_Card_To_Card_Balance_Transfer", parameters)
               .With<CardToCardBalanceTransfer>()
               .Execute());

                List<CardToCardBalanceTransfer> item = results[0].Cast<CardToCardBalanceTransfer>().ToList();

                if (item[0].Status == 0)
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Database_Response, item[0].Reason);
                }
                else
                {
                    return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, results[0]);
                }
            }
        }

        */

        //[HttpPost]
        //[CustomAuthenticationFilter]
        //[Route("api/hppay/wallet/get_pending_ccms_recharge_through_eft")]
        //public async Task<Object> Get_Pending_CCMS_Recharge_Through_EFT([FromBody] GetPendingCCMSRechargethroughEFT_Input ObjClass)
        //{

        //    if (ObjClass == null)
        //    {
        //        return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
        //    }
        //    else
        //    {
        //        Dictionary<string, object> parameters = new Dictionary<string, object>()
        //    {
        //        { "Batch_Code", ObjClass.Mobile_No },
        //        { "From_Date", ObjClass.From_Date },
        //        { "To_Date", ObjClass.To_Date }
        //    };

        //        var results = await Task.Run(() => new DefaultContext()
        //       .MultipleResults("Usp_Wallet_Get_Pending_CCMS_Recharge_Through_EFT", parameters)
        //       .With<GetPendingCCMSRechargethroughEFT>()
        //       .With<CCMSRechargethroughEFT_Customer>()
        //       .Execute());

        //        var output = new GetPendingCCMSRechargethroughEFT()
        //        {
        //            Total_Pending_Amt = results[0].Cast<GetPendingCCMSRechargethroughEFT>().ToList()[0].Total_Pending_Amt,
        //            Total_Pending_Records = results[0].Cast<GetPendingCCMSRechargethroughEFT>().ToList()[0].Total_Pending_Records,
        //            Customer = results[1].Cast<CCMSRechargethroughEFT_Customer>().ToList()
        //        };


        //        if (results[0].Cast<GetPendingCCMSRechargethroughEFT>().ToList().Count == 0)
        //        {
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, null);
        //        }
        //        else
        //        {
        //            return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, output);
        //        }
        //    }
        //}


    }
}
