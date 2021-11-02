using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPCL_DP_Terminal.Models
{

    public class Terminal
    {
        public class Database_Status
        {
            public int Status { get; set; }
            public string Reason { get; set; }
        }

        public class GenerateBatchNo_Input
        {
            public Int64 TID { get; set; }
            public Int64 Outlet_Id { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }

        public class ChangeTerminalPin_Input
        {
            public int Old_Pin { get; set; }
            public int New_Pin { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }
        }

        public class GenerateBatchNo
        {
            public int Batch_Id { get; set; }

            public int Status { get; set; }
            
            public string Reason { get; set; }
        }

        public class BatchSettlement_Input
        {
            public string Batch_Id { get; set; }
            public int Reload_no_of_bills { get; set; }
            public decimal Reload_Amount { get; set; }
            public int Recharge_no_of_bills { get; set; }
            public decimal Recharge_Amount { get; set; }
            public int Sale_no_of_bills { get; set; }
            public decimal Sale_Amount { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }

        }

        public class BatchUpload_Input
        {
            public string Batch_Id { get; set; }
            public List<Transaction_Details> Transaction_Details { get; set; }
            //public List<Unmatched_Trasnactions> Unmatched_Trasnactions { get; set; }
            public Int64 TID { get; set; }
            public Int64 Outlet_Id { get; set; }
        }

        public class Transaction_Details
        {
            public Int64 Card_No { get; set; }
            public Int64 Mobile_No { get; set; }
            public decimal Amount { get; set; }
            public string Product_Name { get; set; }
            public string Sale_Type { get; set; }
            public Int32 ROC { get; set; }

        }
        public class Unmatched_Trasnactions
        {
            public Int64 Customer_Id { get; set; }
            public Int64 Mobile_No { get; set; }
            public string Transaction_Id { get; set; }
            public decimal Transaction_Amount { get; set; }
            public string Remarks { get; set; }
        }

        public class TerminalInput
        {

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

        }

        public class Terminal_Status
        {
            [JsonProperty("Terminal_Status_Type_Id")]
            public Int64 Terminal_Status_Type_Id { get; set; }

            [JsonProperty("Terminal_Status_Type_Name")]
            public string Terminal_Status_Type_Name { get; set; }
        }

        public class Get_All_Terminals
        {
            [JsonProperty("Terminal_Id")]
            public Int64 Terminal_Id { get; set; }

            [JsonProperty("Merchant_Id")]
            public Int64 Merchant_Id { get; set; }

            [JsonProperty("Approval_Date")]
            public DateTime Approval_Date { get; set; }

            [JsonProperty("Deployment_Status")]
            public string Deployment_Status { get; set; }

            [JsonProperty("Terminal_Issuance_Type")]
            public string Terminal_Issuance_Type { get; set; }

            [JsonProperty("Terminal_Status_Type_Name")]
            public string Terminal_Status_Type_Name { get; set; }

            [JsonProperty("Mapped_Store_Id")]
            public Int64 Mapped_Store_Id { get; set; }

            [JsonProperty("Service_Charge")]
            public decimal Service_Charge { get; set; }

            [JsonProperty("Route_Id")]
            public string Route_Id { get; set; }


            [JsonProperty("Effective_Date")]
            public DateTime Effective_Date { get; set; }

        }

        public class Get_All_Terminal_Input
        {

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Check_Report_Status")]
            public int Check_Report_Status { get; set; }

            [JsonProperty("Terminal_Status_Type_Name")]
            public string Terminal_Status_Type_Name { get; set; }

            [JsonProperty("Terminal_Id")]
            public Int64 Terminal_Id { get; set; }

            [JsonProperty("Merchant_Id")]
            public Int64 Merchant_Id { get; set; }

        }

        public class IAC_Input
        {
            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Terminal_Id")]
            public Int64 Terminal_Id { get; set; }

            [JsonProperty("Store_Id")]
            public Int64 Store_Id { get; set; }

        }

        public class IAC_Output
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }

        public class Unblock_Terminal_Input
        {
            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Terminal_Id")]
            public Int64 Terminal_Id { get; set; }


        }

        public class Unblock_Terminal_Output
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }

        public class Before_Terminal_Installation_Input
        {

            [JsonProperty("Merchant_Id")]
            public string Merchant_Id { get; set; }

            [JsonProperty("Zone_Id")]
            public string Zone_Id { get; set; }

            [JsonProperty("Region_Id")]
            public string Region_Id { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }


        }

        public class Before_Terminal_Installation_Output
        {

            [JsonProperty("Outlet_Name")]
            public string Outlet_Name { get; set; }

            [JsonProperty("Address")]
            public string Address { get; set; }

            [JsonProperty("City")]
            public string City { get; set; }

            [JsonProperty("District")]
            public string District { get; set; }

            [JsonProperty("State")]
            public string State { get; set; }

            [JsonProperty("Terminal_Id")]
            public string Terminal_Id { get; set; }

            [JsonProperty("LastMonth_Spend")]
            public string LastMonth_Spend { get; set; }

            [JsonProperty("Status")]
            public bool Status { get; set; }


        }

        public class Terminal_Installation_Request_Input
        {

            [JsonProperty("Merchant_Id")]
            public Int64 Merchant_Id { get; set; }

            [JsonProperty("Zone_Id")]
            public int Zone_Id { get; set; }

            [JsonProperty("Region_Id")]
            public int Region_Id { get; set; }

            [JsonProperty("TerminalIssuanceType")]
            public string TerminalIssuanceType { get; set; }

            [JsonProperty("TerminalType")]
            public string TerminalType { get; set; }

            [JsonProperty("Comments")]
            public string Comments { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

        }

        public class Terminal_Installation_Request_Output
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }

        public class Pending_Terminal_Installation_Input
        {

            [JsonProperty("Zone_Id")]
            public int Zone_Id { get; set; }

            [JsonProperty("Region_Id")]
            public int Region_Id { get; set; }

            [JsonProperty("From_Date")]
            public DateTime From_Date { get; set; }

            [JsonProperty("To_Date")]
            public DateTime To_Date { get; set; }

            [JsonProperty("Merchant_Id")]
            public Int64 Merchant_Id { get; set; }

            [JsonProperty("Terminal_Id")]
            public Int64 Terminal_Id { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }

        public class Pending_Terminal_Installation_Output
        {
            [JsonProperty("Merchant_Id")]
            public Int64 Merchant_Id { get; set; }

            [JsonProperty("Terminal_Id")]
            public Int64 Terminal_Id { get; set; }

            [JsonProperty("ZonalOffice")]
            public string ZonalOffice { get; set; }

            [JsonProperty("RegionalOffice")]
            public string RegionalOffice { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }

            [JsonProperty("TerminalTypeRequested")]
            public string TerminalTypeRequested { get; set; }

            [JsonProperty("CreatedBy")]
            public string CreatedBy { get; set; }

            [JsonProperty("CreatedOn")]
            public DateTime CreatedOn { get; set; }

        }

        public class Update_Pending_Terminal_Installation_Input
        {

            [JsonProperty("Merchant_Id")]
            public Int64 Merchant_Id { get; set; }

            [JsonProperty("Terminal_Id")]
            public Int64 Terminal_Id { get; set; }

            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public int Reason { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }

        public class Update_Pending_Terminal_Installation_Output
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }

        public class Before_Terminal_DE_Installation_Input
        {

            [JsonProperty("Merchant_Id")]
            public Int64 Merchant_Id { get; set; }

            [JsonProperty("Terminal_Id")]
            public Int64 Terminal_Id { get; set; }

            [JsonProperty("Zone_Id")]
            public int Zone_Id { get; set; }

            [JsonProperty("Region_Id")]
            public int Region_Id { get; set; }

            [JsonProperty("Deinstallation_Type")]
            public string Deinstallation_Type { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }

        public class Before_Terminal_DE_Installation_Output
        {
            [JsonProperty("OutletName")]
            public string OutletName { get; set; }

            [JsonProperty("Address")]
            public string Address { get; set; }

            [JsonProperty("City")]
            public string City { get; set; }

            [JsonProperty("District")]
            public string District { get; set; }

            [JsonProperty("State")]
            public string State { get; set; }

            [JsonProperty("TerminalId")]
            public Int64 TerminalId { get; set; }

            [JsonProperty("Zo")]
            public string Zo { get; set; }

            [JsonProperty("RO")]
            public string RO { get; set; }

            [JsonProperty("Createdon")]
            public DateTime Createdon { get; set; }
        }

        public class Terminal_DE_Installation_Input
        {


            [JsonProperty("Merchant_Id")]
            public Int64 Merchant_Id { get; set; }

            [JsonProperty("Terminal_Id")]
            public Int64 Terminal_Id { get; set; }

            [JsonProperty("Comments")]
            public string Comments { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

        }

        public class Terminal_DE_Installation_Output
        {

            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }

        public class Terminal_IDE_Installation_Pending_Input
        {

            [JsonProperty("Zone_Id")]
            public int Zone_Id { get; set; }

            [JsonProperty("Region_Id")]
            public int Region_Id { get; set; }

            [JsonProperty("From_Date")]
            public DateTime From_Date { get; set; }

            [JsonProperty("To_Date")]
            public DateTime To_Date { get; set; }

            [JsonProperty("Merchant_Id")]
            public Int64 Merchant_Id { get; set; }

            [JsonProperty("Terminal_Id")]
            public Int64 Terminal_Id { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }

        public class Terminal_IDE_Installation_Pending_Output
        {

            [JsonProperty("Merchant_Id")]
            public Int64 Merchant_Id { get; set; }

            [JsonProperty("Terminal_Id")]
            public Int64 Terminal_Id { get; set; }

            [JsonProperty("ZonalOffice")]
            public string ZonalOffice { get; set; }

            [JsonProperty("RegionalOffice")]
            public string RegionalOffice { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }

            [JsonProperty("TerminalTypeRequested")]
            public string TerminalTypeRequested { get; set; }

            [JsonProperty("CreatedBy")]
            public string CreatedBy { get; set; }

            [JsonProperty("CreatedOn")]
            public DateTime CreatedOn { get; set; }

        }

        public class Update_Pending_Terminal_IDE_Installation_Input
        {

            [JsonProperty("Merchant_Id")]
            public Int64 Merchant_Id { get; set; }

            [JsonProperty("Terminal_Id")]
            public Int64 Terminal_Id { get; set; }

            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public int Reason { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }


        }

        public class Update_Pending_Terminal_IDE_Installation_Output
        {

            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }


        }

        public class Pending_Terminal_Install_List_Input
        {
            [JsonProperty("ZO")]
            public string ZO { get; set; }

            [JsonProperty("RO")]
            public string RO { get; set; }

            [JsonProperty("From_Date")]
            public DateTime From_Date { get; set; }

            [JsonProperty("To_Date")]
            public DateTime To_Date { get; set; }

            [JsonProperty("Terminal")]
            public string Terminal { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }

        public class Pending_Terminal_Install_List_Output
        {
            [JsonProperty("TerminalType")]
            public string TerminalType { get; set; }

            [JsonProperty("MerchantId")]
            public Int64 MerchantId { get; set; }

            [JsonProperty("TerminalTypeRequested")]
            public string TerminalTypeRequested { get; set; }

            [JsonProperty("MerchantStatus")]
            public int MerchantStatus { get; set; }

            [JsonProperty("LastMonthSpend")]
            public decimal LastMonthSpend { get; set; }

            [JsonProperty("LastMonthNoOfTransaction")]
            public int LastMonthNoOfTransaction { get; set; }

            [JsonProperty("RequestType")]
            public string RequestType { get; set; }

            [JsonProperty("RequestedBy")]
            public string RequestedBy { get; set; }

            [JsonProperty("RequestedOn")]
            public DateTime RequestedOn { get; set; }
        }

        public class Approve_Terminal_Installtion_Request_Input
        {

            [JsonProperty("TerminalId")]
            public Int64 TerminalId { get; set; }

            [JsonProperty("StoreId")]
            public Int64 StoreId { get; set; }

            [JsonProperty("Comment")]
            public string Comment { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }

        public class Approve_Terminal_Installtion_Request_Output
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }

        public class Pending_Terminal_DE_Install_List_Input
        {
            [JsonProperty("ZO")]
            public string ZO { get; set; }

            [JsonProperty("RO")]
            public string RO { get; set; }

            [JsonProperty("From_Date")]
            public DateTime From_Date { get; set; }

            [JsonProperty("To_Date")]
            public DateTime To_Date { get; set; }

            [JsonProperty("MerchantId")]
            public Int64 MerchantId { get; set; }

            [JsonProperty("TerminalId")]
            public Int64 TerminalId { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }

        public class Pending_Terminal_DE_Install_List_Output
        {

            [JsonProperty("MerchantId")]
            public Int64 MerchantId { get; set; }

            [JsonProperty("TerminalId")]
            public string TerminalId { get; set; }

            [JsonProperty("OutletName")]
            public int OutletName { get; set; }

            [JsonProperty("LastQuarterSpend")]
            public decimal LastQuarterSpend { get; set; }

            [JsonProperty("LastQuarterNoOfTransaction")]
            public int LastQuarterNoOfTransaction { get; set; }

            [JsonProperty("ZO")]
            public string ZO { get; set; }

            [JsonProperty("RO")]
            public string RO { get; set; }

            [JsonProperty("RequestedBy")]
            public string RequestedBy { get; set; }

            [JsonProperty("RequestedOn")]
            public DateTime RequestedOn { get; set; }

            [JsonProperty("Comment")]
            public string Comment { get; set; }
        }

        public class Approve_Terminal_De_Installtion_Request_Input
        {
            [JsonProperty("TerminalId")]
            public Int64 TerminalId { get; set; }

            [JsonProperty("StoreId")]
            public Int64 StoreId { get; set; }

            [JsonProperty("Comment")]
            public string Comment { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }
        }

        public class Approve_Terminal_De_Installtion_Request_Output
        {
            [JsonProperty("Status")]
            public int Status { get; set; }

            [JsonProperty("Reason")]
            public string Reason { get; set; }
        }

        


        }
}