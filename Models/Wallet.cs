using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HPCL_DP_Terminal.Models
{
    public class SaleLimitsofCards
    {   
        public string Vehicle_no { get; set; }
        public Int64 Mobile_no { get; set; }
        public Int64 Card_no { get; set; }
        public string Type_of_limit { get; set; }
        public decimal Limit_value { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
        
        
    }

    public class CCMSLimitsforAllCards
    {        
        public Int64 Customer_id { get; set; }        
        public string Typeoflimit { get; set; }
        public decimal Limitvalue { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
    }


    public class CCMSLimitsforIndvCards
    {
        
        public string Cardno { get; set; }
        public Int64 Customer_id { get; set; }
        //public string Mobileno { get; set; }
        //public string Vehicleno { get; set; }
        public string Typeoflimit { get; set; }
        public decimal Limitvalue { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
    }


    public class Set_All_Limits_for_Indv_Cards
    {
        public Int64 Customer_id { get; set; }
        public List<Indv_Card_Det> Indv_card_Det { get; set; }
        //public Int64 Card_no { get; set; }
        //public Int64 Mobileno { get; set; }
        //public string Typeoflimit { get; set; }
        //public decimal Limitvalue { get; set; }
        //public Decimal CCMSUnlimited { get; set; }
        //public Decimal CCMSDailyLimit { get; set; }
        //public Decimal CCMSMonthlyLimit { get; set; }
        //public Decimal CCMSOneTime { get; set; }
        //public Decimal CCMSAnnual { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
    }

    public class Indv_Card_Det
    {
        public Int64 Card_no { get; set; }
        public Int64 Mobileno { get; set; }
        public string Typeoflimit { get; set; }
        public decimal Limitvalue { get; set; }
    }

        public class SearchcardmappingInput
    {
        public Int64 Customer_id { get; set; }
        public Int64 Card_no { get; set; }
        public int Merchantid { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
    }

    public class Searchcardmapping
    {
        public string Userid { get; set; }
        public string Cardno { get; set; }
        public string Merchantid { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
    }

    public class Deletecardmapping
    {
        public Int64 Customer_id { get; set; }
        public string Cardno { get; set; }
        public string Merchantid { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
    }



    public class AllcardsbycustomeridInput
    {
        public Int64 Customer_id { get; set; }
        public string Userid { get; set; }        
        public string Useragent { get; set; }
        public string Userip { get; set; }
    }

    public class Allcardsbycustomerid
    {
        public Int64 Customer_Id { get; set; }
        public string ZO { get; set; }
        public string RO { get; set; }
        public string Customer_Name { get; set; }
        public List<Cardarr> Cardarr { get; set; }

    }

    public class Cardarr
    {
        public string Cardno { get; set; }
        public string Vehicleno { get; set; }
        public string Last_transaction_date { get; set; }
        public Int64 Mobile_No { get; set; }
    }

    public class MapcardtomerchantInput
    {
        public string Merchant_id { get; set; }
        public Int64 Customer_id { get; set; }
        public string Card_no { get; set; }
        public string Vehicle_no { get; set; }
        public string Type_of_mapping { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }

    }

    public class DeactivateReactivatecardsInput
    {
        public string Mobileno { get; set; }        
        public string Cardno { get; set; }
        public string Vehicleno { get; set; }
        public string Status { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
    }

    public class Get_Enabled_ServicesInput
    {
        public string Cardno { get; set; }
        public Int64 Customer_id { get; set; }
        public string Mobileno { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
    }


    public class Getenabledservices
    {
        public string Serviceid { get; set; }
        public string ServiceName { get; set; }
       
    }

    public class DataInsertion
    {
        public int Status { get;set; }
        public string Reason { get; set; }
    }

    public class UpdatingServicesInput
    {
        public string Cardno { get; set; }
        public Int64 Customer_id { get; set; }
        public string Mobileno { get; set; }
        public string Servicesarr { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }

    }


    public class ReplacementCardsInput
    {
        public Int64 Customer_id { get; set; }
        public List<ArrCardNo> Oldcardnoarr { get; set; }
        public List<ArrCardNo> Newcardnoarr { get; set; }

        [Required]
        public string Useragent { get; set; }

        [Required]
        public string Userip { get; set; }

        [Required]
        public string Userid { get; set; }
    }

    public class ArrCardNo
    {
        public string Card_No { get; set; }
    }


    public class SearchCardInput
    {
        public Int64? Customer_id { get; set; }
        public Int64? Mobileno { get; set; }
        public Int64? Cardno { get; set; }
        public string Vehicleno { get; set; }

        [Required]
        public string Useragent { get; set; }

        [Required]
        public string Userip { get; set; }

        [Required]
        public string Userid { get; set; }
    }

    public class CarddetailsByCardNoInput
    {   
        public Int64 Cardno { get; set; }
        public string Vehicleno { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
    }


    public class CarddetailsByCardNo
    {
        public Int64? Customer_id { get; set; }
        public Int64? Card_no { get; set; }
        public string Card_status { get; set; }
        public int Card_type { get; set; }
        public decimal? Form_id { get; set; }
        public string Vehicle_no { get; set; }
        public int? Vehicle_type { get; set; }
        public string Issue_date { get; set; }
        public string Expirydt { get; set; }
        public decimal? Vehicle_yr_of_reg { get; set; }
        public string Vehicle_manufacturer { get; set; }
        public decimal? IsAttached { get; set; }
        public decimal? Mobileno { get; set; }
        public string Vin_no { get; set; }
        public decimal? DailyCreditLimit { get; set; }
        public decimal? CardBalance { get; set; }

    }


    public class ViewCardLimitsInput
    {
        public Int64? Customer_id { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
    }

    public class ViewCardLimits
    {
        public Int64? Card_no { get; set; }
        public string Vehicle_no { get; set; }
        public decimal? SingleTransactionLimit { get; set; }
        public decimal? DailyTransactionLimit { get; set; }
        public decimal? DailyTransactionBalance { get; set; }
        public decimal? MonthlySaleBalance { get; set; }
        public decimal? AvailableCCMS { get; set; }
        public string Type_of_limit { get; set; }
        public decimal? IsAttached { get; set; }
        public decimal? Mobileno { get; set; }
        public decimal? CCMSDailyLimit { get; set; }
        public decimal? MonthlyTransactionLimit { get; set; }
       
        //CCMSDailyLimit,MonthlyTransactionLimit,DailyTransactionLimit
    }



    public class SearchCard
    {
        public Int64? Customer_id { get; set; }
        public Int64? Card_no { get; set; }
        public int? Card_type { get; set; }
        public string Vehicle_no { get; set; }
        public int? Vehicle_type { get; set; }
        public string Issue_date { get; set; }
        public string Expiry_date { get; set; }
        public string Card_status { get; set; }
        public decimal? Vehicle_yr_of_reg { get; set; }
        public string Vehicle_manufacturer { get; set; }
        public decimal? IsAttached { get; set; }
        public decimal? Mobileno { get; set; }
        public string Vin_no { get; set; }
        public decimal? SingleTransactionLimit { get; set; }
        public decimal? DailyTransactionLimit { get; set; }
        public decimal? MonthlyTransactionLimit { get; set; }

    }


    public class Map_Mobile_NoInput
    {
        public string Mobileno { get; set; }
        public string Cardno { get; set; }
        public string Vehicleno { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
    }

    public class BalancebyCustomeridInput
    {        
        public Int64? Customer_id { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
    }


    public class BalancebyCustomerid
    {
        public UInt64 Customer_id { get; set; }
        public decimal? CardBalance { get; set; }
        public decimal? Ccmsbalance { get; set; }
        public decimal? Drivestars { get; set; }
        public decimal? Expireddrivestars { get; set; }
        public decimal? Expiringdrivestars { get; set; }
        public decimal? Dailycashlimit { get; set; }
        public decimal? Dailycashlimitbalance { get; set; }

    }


    public class CCMSBalanceDetailbyCustomerid
    {        
        public string Mode { get; set; }
        public string Description { get; set; }
        public string TransactionDate { get; set; }
        public decimal? Openingbalance { get; set; }
        public string Postmethod { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Closingbalance { get; set; }

    }


    public class DrivestarsDetailbyCustomerid
    {
        public string Mode { get; set; }
        public string Description { get; set; }
        public string TransactionDate { get; set; }
        public decimal? Openingbalance { get; set; }
        public string Postmethod { get; set; }
        public decimal? Driver_stars { get; set; }
        public decimal? Closingbalance { get; set; }

    }


    public class GetWalletBalanceLimitInput
    {
        public Int64? Card_no { get; set; }
        //public Int64 TID { get; set; }
        //public string Outlet_id { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
    }

    public class GetWalletBalanceByMobileInput
    {
        public Int64 Mobileno { get; set; }
        public Int64 TID { get; set; }
        public string Outlet_id { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
    }
    


    public class GetWalletBalanceLimit
    { 
        public Decimal SingleTransactionLimit { get; set; }
        public Decimal DailyTransactionLimit { get; set; }
        public Decimal MonthlyTransactionLimit { get; set; }
        public Decimal CCMSUnlimited { get; set; }
        public Decimal CCMSDailyLimit { get; set; }
        public Decimal CCMSMonthlyLimit { get; set; }
        public Decimal CCMSOneTime { get; set; }
        public Decimal CCMSAnnual { get; set; }
        public Decimal DailyCreditLimit { get; set; }
        public Decimal CentralCreditLimit { get; set; }
        public Decimal PetrolLimit { get; set; }
        public Decimal DieselLimit { get; set; }
        public Decimal CNGLimit { get; set; }
        public Decimal Petrol_Diesel_Limit { get; set; }
        public Decimal Petrol_CNG_Limit { get; set; }
        public Decimal Diesel_CNG_Limit { get; set; }
        public Decimal Any_Fuel_Limit { get; set; }
        public Decimal SingleQuantityLimit { get; set; }
        public Decimal DailyQuantityLimit { get; set; }
        public Decimal MonthlyQuantityLimit { get; set; }
        public Decimal OnetimeQuantityLimit { get; set; }
        public Decimal UnlimitedQuantityLimit { get; set; }

        //-------------------------        
        public Decimal CCMS_balance { get; set; }
        public Decimal Drive_stars { get; set; }
        public Decimal Expire_drive_stars { get; set; }
        public Decimal Expiring_drive_stars { get; set; }
        public Decimal Daily_cash_limit { get; set; }
        public Decimal Daily_cash_limit_balance { get; set; }
    }

    public class LoyaltyBalanceByCardNoInput
    {
        public Int64 Controlcardno { get; set; }
        public int Controlpin { get; set; }
        public int TID { get; set; }
        public int OutletId { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
    }


    public class LoyaltyBalanceByCardNo
    {
        public decimal Drive_stars { get; set; }
    }

    public class CCMSBalanceByCardNoInput
    {
        public Int64 Controlcardno { get; set; }
        public int Controlpin { get; set; }
        public int TID { get; set; }
        public int OutletId { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
    }

    public class CCMSBalanceByCardNo
    {
        public decimal CCMS_balance { get; set; }
    }


    public class Request_otc_card_by_region_Input
    {
        public int Region_id { get; set; }
        public int No_Of_OTC_Cards { get; set; }
        public string OTC_Type { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
    }

    public class Request_otc_card_by_merchant_Input
    {
        public int Merchant_Id { get; set; }
        public int No_Of_OTC_Cards { get; set; }
        public string OTC_Type { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
    }


    public class Viewrequestedotccardbyregion_Input
    {
        public int Region_id { get; set; }
        public int Card_Type { get; set; }        
        public string Useragent { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
    }

    public class Viewrequestedotccardbyregion
    {
        public string Zone { get; set; }
        public string Region { get; set; }
        public string Customer_id { get; set; }
        public string Customer_Name { get; set; }
        public Int64 Card_Number { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Useragent { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
    }
    public class GetPointEquivAmtInput
    {
        public int Card_no { get; set; }
        public int Card_pin { get; set; }
        public string Fuel { get; set; }
        public int Pointstoredeem { get; set; }
        public int TID { get; set; }
        public int OutletId { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
    }

    public class GetPointEquivAmt
    {
        public int Points { get; set; }
        public int Actual_points { get; set; }
        public decimal Amount { get; set; }
        public decimal Message { get; set; }
    }

    public class SaveDTPLoyaltyByCard_Input
    {
        public int? ROC_No { get; set; }
        public Int64? Card_no { get; set; }
        public decimal? Amount { get; set; }
        public int? Terminal_Pin { get; set; }
        public int? TID { get; set; }
        public int? OutletId { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
    }

    public class SaveDTPLoyaltyByCard
    {
        public string TransactionDate { get; set; }
        public string Batchid { get; set; }
        public decimal TransactionAmount { get; set; }
        
    }


    public class SaveDTPLoyaltyByMobileNo_Input
    {
        public int ROC_No { get; set; }
        public Int64 Mobile_no { get; set; }
        public decimal Amount { get; set; }
        public int Terminal_Pin { get; set; }
        public int OTP { get; set; }
        public int TID { get; set; }
        public int OutletId { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
    }

    public class SaveDTPLoyaltyByMobileNo
    {
        public string TransactionDate { get; set; }
        public string Batchid { get; set; }
        public decimal TransactionAmount { get; set; }
    }


    public class SaveNonDTPLoyaltyByCard_Input
    {       
        public Int64? Card_no { get; set; }
        public decimal? Amount { get; set; }
        public int? Terminal_Pin { get; set; }      
        public int? TID { get; set; }
        public int? OutletId { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
    }


    public class SaveNonDTPLoyaltyByCard
    {
        public string TransactionDate { get; set; }
        public string Batchid { get; set; }
        public decimal TransactionAmount { get; set; }
    }

    public class SaveNonDTPLoyaltyByMobileNo_Input
    {
        public Int64 Mobile_No { get; set; }
        public decimal? Amount { get; set; }
        public int? Terminal_Pin { get; set; }
        public int? TID { get; set; }
        public int? OutletId { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
    }


    public class SaveNonDTPLoyaltyByMobileNo
    {
        public string TransactionDate { get; set; }
        public string Batchid { get; set; }
        public decimal TransactionAmount { get; set; }
    }

    public class CheckTransactionValuevsLimit_Input
    {
        public Int64 Card_No { get; set; }       
        public decimal Sale_Amount { get; set; }
        public int TID { get; set; }
        public int OutletId { get; set; }
        public string Userip { get; set; }
        public string Userid { get; set; }
        public string Useragent { get; set; }
    }

    public class CheckTransactionValuevsLimit
    {
        public bool Status { get; set; }
        public string Message { get; set; }        
    }


    public class Add_On_Card_Aggregator_Customer_Input
    {
        [JsonProperty("NumberOfCard")]
        public int NumberOfCard { get; set; }

        [JsonProperty("CardPreference")]
        public string CardPreference { get; set; }

        [JsonProperty("CardArray")]
        public List<CardInfo> CardArray { get; set; }

        [JsonProperty("Userid")]
        public string Userid { get; set; }

        [JsonProperty("Useragent")]
        public string Useragent { get; set; }

        [JsonProperty("Userip")]
        public string Userip { get; set; }
    }

    public class CardInfo
    {
        [JsonProperty("Vehicle_No")]
        public string Vehicle_No { get; set; }

        [JsonProperty("VehicleType")]
        public string VehicleType { get; set; }

        [JsonProperty("Vehicle_Manufacturer")]
        public string Vehicle_Manufacturer { get; set; }

        [JsonProperty("Vehicle_yr_of_reg")]
        public string Vehicle_yr_of_reg { get; set; }

        [JsonProperty("Mobile_No")]
        public Int64 Mobile_No { get; set; }

        [JsonProperty("RCcopy")]
        public string RCcopy { get; set; }


    }

    public class List_of_Pending_Card_Input
    {
        [JsonProperty("Customer_id")]
        public Int64 Customer_id { get; set; }

        [JsonProperty("From_date")]
        public string From_date { get; set; }

        [JsonProperty("To_date")]
        public string To_date { get; set; }

        [JsonProperty("Form_No")]
        public string Form_No { get; set; }

        [JsonProperty("Userid")]
        public string Userid { get; set; }

        [JsonProperty("Useragent")]
        public string Useragent { get; set; }

        [JsonProperty("Userip")]
        public string Userip { get; set; }
    }


    public class List_of_Pending_Card
    {
        [JsonProperty("Customer_id")]
        public Int64 Customer_id { get; set; }

        [JsonProperty("Card_no")]
        public Int64 Card_no { get; set; }

    }

    public class Verify_Pending_Addon_Card_of_Aggregator_Input
    {
        [JsonProperty("Customer_id")]
        public Int64 Customer_id { get; set; }

        [JsonProperty("FormNumber")]
        public Int64 FormNumber { get; set; }

        [JsonProperty("Userid")]
        public string Userid { get; set; }

        [JsonProperty("Useragent")]
        public string Useragent { get; set; }

        [JsonProperty("Userip")]
        public string Userip { get; set; }

    }

    public class Approve_Card_for_Aggregation_Customer_Input
    {
        [JsonProperty("Customer_id")]
        public Int64 Customer_id { get; set; }

        [JsonProperty("FormNumber")]
        public Int64 FormNumber { get; set; }

        [JsonProperty("Userid")]
        public string Userid { get; set; }

        [JsonProperty("Useragent")]
        public string Useragent { get; set; }

        [JsonProperty("Userip")]
        public string Userip { get; set; }

    }

    public class UpdateCCMSBalance_Input
    {

        [JsonProperty("Customer_Id")]
        public Int64 Customer_Id { get; set; }

        [JsonProperty("Amount")]
        public decimal? Amount { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("Paymentmode")]
        public string Paymentmode { get; set; }

        [JsonProperty("Gatewayname")]
        public string Gatewayname { get; set; }

        [JsonProperty("Bankname")]
        public string Bankname { get; set; }

        [JsonProperty("TxnID")]
        public string TxnID { get; set; }

        [JsonProperty("OrderID")]
        public string OrderID { get; set; }

        [JsonProperty("TxnDate")]
        public string TxnDate { get; set; }

        [JsonProperty("Userid")]
        public string Userid { get; set; }

        [JsonProperty("Useragent")]
        public string Useragent { get; set; }

        [JsonProperty("Userip")]
        public string Userip { get; set; }

    }


    public class GetPendingCCMSRechargethroughEFT_Input
    {
        [JsonProperty("Batch_Code")]
        public Int64 Batch_Code { get; set; }

        [JsonProperty("From_Date")]
        public string From_Date { get; set; }

        [JsonProperty("To_Date")]
        public string To_Date { get; set; }

        [JsonProperty("Control_Card_No")]
        public Int64 Control_Card_No { get; set; }

        [JsonProperty("UTR_No")]
        public string UTR_No { get; set; }

        [JsonProperty("ICICI_Ref_No")]
        public string ICICI_Ref_No { get; set; }

        [JsonProperty("CCMS_Recharge_Request_Type")]
        public string CCMS_Recharge_Request_Type { get; set; }

        [JsonProperty("Userid")]
        public string Userid { get; set; }

        [JsonProperty("Useragent")]
        public string Useragent { get; set; }

        [JsonProperty("Userip")]
        public string Userip { get; set; }
    }

    public class GetPendingCCMSRechargethroughEFT
    {
        [JsonProperty("Total_Pending_Records")]
        public int Total_Pending_Records { get; set; }

        [JsonProperty("Total_Pending_Amt")]
        public decimal Total_Pending_Amt { get; set; }

        [JsonProperty("Customer")]
        public List<CCMSRechargethroughEFT_Customer> Customer { get; set; }

    }

    public class CCMSRechargethroughEFT_Customer
    {
        public Int64 Customer_Id { get; set; }
        public Int64 Mobile_No { get; set; }
        public string Txn_Date { get; set; }
        public decimal Amount { get; set; }
        public string Requested_By { get; set; }
        public string Requested_On { get; set; }
        public string Sender_Name { get; set; }
        public string Comments { get; set; }
    }

    public class CCMSToCardBalanceTransfer_Input
    {
        public Int64 Customer_Id { get; set; }
        public Int64 Card_Number { get; set; }
        public decimal Amount { get; set; }

        [JsonProperty("Userid")]
        public string Userid { get; set; }

        [JsonProperty("Useragent")]
        public string Useragent { get; set; }

        [JsonProperty("Userip")]
        public string Userip { get; set; }
    }

    public class CCMSToCardBalanceTransfer
    {
        public int Status { get; set; }
        public string Reason { get; set; }
    }


    public class CardToCardBalanceTransfer_Input
    {
        public Int64 Customer_Id { get; set; }
        public Int64 From_Card_Number { get; set; }
        public Int64 To_Card_Number { get; set; }
        public decimal Amount { get; set; }

        [JsonProperty("Userid")]
        public string Userid { get; set; }

        [JsonProperty("Useragent")]
        public string Useragent { get; set; }

        [JsonProperty("Userip")]
        public string Userip { get; set; }
    }

    public class CardToCardBalanceTransfer
    {
        public int Status { get; set; }
        public string Reason { get; set; }
    }

}