using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HPCL_DP_Terminal.Models
{
    public class Transaction
    {
        public class TrnsactionDetail_Input
        {
            [JsonProperty("CustomerId_CardNo_MobileNo")]
            public string CustomerId_CardNo_MobileNo { get; set; }

            [JsonProperty("From_Date")]
            public DateTime? From_Date { get; set; }

            [JsonProperty("To_Date")]
            public DateTime? To_Date { get; set; }

            [JsonProperty("Transaction_Type")]
            public string Transaction_Type { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }
        public class TransactionDetail_Output
        {
            [JsonProperty("TerminalId")]
            public string TerminalId { get; set; }

            [JsonProperty("Merchant")]
            public string Merchant { get; set; }

            [JsonProperty("BatchId")]
            public string BatchId { get; set; }

            [JsonProperty("ROC")]
            public string ROC { get; set; }

            [JsonProperty("AccountNo")]
            public string AccountNo { get; set; }

            [JsonProperty("VechileNo")]
            public string VechileNo { get; set; }

            [JsonProperty("TxnDate")]
            public DateTime TxnDate { get; set; }

            [JsonProperty("TxnType")]
            public string TxnType { get; set; }

            [JsonProperty("Product")]
            public string Product { get; set; }

            [JsonProperty("Price")]
            public decimal? Price { get; set; }

            [JsonProperty("Volume")]
            public string Volume { get; set; }

            [JsonProperty("Currency")]
            public string Currency { get; set; }

            [JsonProperty("ServiceCharge")]
            public decimal? ServiceCharge { get; set; }

            [JsonProperty("Amount")]
            public decimal? Amount { get; set; }

            [JsonProperty("Discount")]
            public string Discount { get; set; }

            [JsonProperty("OdometerReading")]
            public string OdometerReading { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }
        }
        public class StatementDetail_Input
        {

            [JsonProperty("CustomerId")]
            public string CustomerId { get; set; }

            [JsonProperty("From_Date")]
            public DateTime? From_Date { get; set; }

            [JsonProperty("To_Date")]
            public DateTime? To_Date { get; set; }

            [JsonProperty("Transaction_Type")]
            public string Transaction_Type { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }
        public class StatementDetail_Output
        {
            [JsonProperty("OpeningStatement")]
            public decimal? OpeningStatement { get; set; }

            [JsonProperty("Credit")]
            public int Credit { get; set; }

            [JsonProperty("Debit")]
            public int Debit { get; set; }

            [JsonProperty("ClosingStatement")]
            public decimal? ClosingStatement { get; set; }

            [JsonProperty("Drivestars")]
            public string Drivestars { get; set; }

            [JsonProperty("TxnDate")]
            public DateTime TxnDate { get; set; }

            [JsonProperty("TxnType")]
            public string TxnType { get; set; }

            [JsonProperty("Product")]
            public string Product { get; set; }

            [JsonProperty("Price")]
            public decimal? Price { get; set; }

            [JsonProperty("Volume")]
            public string Volume { get; set; }

            [JsonProperty("Currency")]
            public string Currency { get; set; }

            [JsonProperty("ServiceCharge")]
            public decimal? ServiceCharge { get; set; }

            [JsonProperty("Amount")]
            public decimal? Amount { get; set; }

            [JsonProperty("Discount")]
            public string Discount { get; set; }

            [JsonProperty("OdometerReading")]
            public string OdometerReading { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }
        }

        public class CCMSSaleByCard_Input
        {
            public Int64 Card_No { get; set; }
            public string Product { get; set; }
            public decimal Amount { get; set; }
            public string Sale_Type { get; set; }
            public int Card_Pin { get; set; }
            public int Terminal_Pin { get; set; }
            public decimal Odometer_Reading { get; set; }
            public int TID { get; set; }
            public string OutletId { get; set; }
            public string Batch_Id { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class CCMSSaleByCard
        {
            public string Transaction_Id { get; set; }

            public string Transaction_Date { get; set; }

            public decimal Transaction_Amount { get; set; }

            public string Product { get; set; }

            public string Batch_Id { get; set; }
        }



        public class CCMSSaleByMobileNo_Input
        {
            [JsonProperty("Mobile_No")]
            public Int64 Mobile_No { get; set; }

            [JsonProperty("OTP")]
            public int OTP { get; set; }

            [JsonProperty("Product")]
            public string Product { get; set; }

            [JsonProperty("Amount")]
            public decimal Amount { get; set; }

            [JsonProperty("Sale_Type")]
            public string Sale_Type { get; set; }

            [JsonProperty("Terminal_Pin")]
            public int Terminal_Pin { get; set; }

            [JsonProperty("Odometer_Reading")]
            public decimal Odometer_Reading { get; set; }

            [JsonProperty("TID")]
            public int TID { get; set; }

            [JsonProperty("OutletId")]
            public string OutletId { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Type")]
            public int Type { get; set; }

            public string Batch_Id { get; set; }
        }

        public class CCMSSaleByMobileNo
        {
            
            public string Transaction_Id { get; set; }

            public string Transaction_Date { get; set; }

            public decimal Transaction_Amount { get; set; }

            public string Product { get; set; }

            public string Reason { get; set; }

            public string Passcode { get; set; }

            public int Status { get; set; }
        }

        public class ReloadApiByCash_Input
        {
            [Required(ErrorMessage = "Card No Required")]
            public Int64 Card_No { get; set; }

            [Required(ErrorMessage = "Recharge Amount Required")]
            public decimal Recharge_Amount { get; set; }

            [Required(ErrorMessage = "Sale Type Required")]
            public string Sale_Type { get; set; }

            [Required(ErrorMessage = "Transaction Type Required")]
            public string Transaction_Type { get; set; }
            [Required(ErrorMessage = "Transaction Id Required")]
            public string Transaction_Id { get; set; }

            [Required(ErrorMessage = "Terminal Id Required")]
            public Int64 TID { get; set; }
            [Required(ErrorMessage = "Outlet Id Required")]
            public Int64 Outlet_Id { get; set; }
            [Required(ErrorMessage = "Batch Id Required")]
            public Int64 Batch_Id { get; set; }            
            public string Userid { get; set; }            
            public string Useragent { get; set; }            
            public string Userip { get; set; }
        }

        public class ReloadApiByCash
        {
            public string Transaction_Id { get; set; }
            public string Transaction_Date { get; set; }
            public decimal Transaction_Amount { get; set; }
            public Int64 Batch_Id { get; set; }
            //public string Product { get; set; }


        }


        public class ReloadApiByCheque_Input
        {
            [Required(ErrorMessage = "Card No Required")]
            public Int64 Card_No { get; set; }
            public decimal Recharge_Amount { get; set; }
            public string Sale_Type { get; set; }
            public string Transaction_Type { get; set; }
            public string Transaction_Id { get; set; }
            public Int64 TID { get; set; }
            [Required(ErrorMessage = "Outlet Id Required")]
            public Int64 Outlet_Id { get; set; }
            [Required(ErrorMessage = "Batch Id Required")]
            public Int64 Batch_Id { get; set; }
            public string Cheque_No { get; set; }
            public string MICR_Code { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class ReloadApiByCheque
        {
            public string Transaction_Id { get; set; }
            public string Transaction_Date { get; set; }
            public decimal Transaction_Amount { get; set; }
            public Int64 Batch_Id { get; set; }
        }


        public class ReloadApiByNEFTRTGS_Input
        {
            public Int32 Card_No { get; set; }
            public decimal Recharge_Amount { get; set; }
            public string Sale_Type { get; set; }
            public string Transaction_Type { get; set; }
            public string Transaction_Id { get; set; }
            public string TID { get; set; }
            public string Outlet_Id { get; set; }
            public string Cheque_No { get; set; }
            public string MICR_Code { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class ReloadApiByNEFTRTGS
        {
            public string Transaction_Id { get; set; }
            public string Transaction_Date { get; set; }
            public decimal Transaction_Amount { get; set; }
            public string Product { get; set; }
            public string Batch_Id { get; set; }
        }



        public class CardSaleByCard_Input
        {
            public Int32 Card_No { get; set; }
            public string Product { get; set; }
            public decimal Amount { get; set; }
            public string Sale_Type { get; set; }
            public string Odometer_Reading { get; set; }
            public string TID { get; set; }
            public string Outlet_Id { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class CardSaleByCard
        {
            public string Transaction_Id { get; set; }
            public string Transaction_Date { get; set; }
            public decimal Transaction_Amount { get; set; }
            public string Product { get; set; }
            public string Batch_Id { get; set; }
        }


        public class CreditSaleByCard_Input
        {
            public Int32 Card_No { get; set; }
            public string Product { get; set; }
            public decimal Amount { get; set; }
            public string Sale_Type { get; set; }
            public string Odometer_Reading { get; set; }
            public string TID { get; set; }
            public string Outlet_Id { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class CreditSaleByCard
        {
            public string Transaction_Id { get; set; }
            public string Transaction_Date { get; set; }
            public decimal Transaction_Amount { get; set; }
            public string Product { get; set; }
            public string Batch_Id { get; set; }
        }



        public class DealerCreditSaleByCard_Input
        {
            public Int32 Card_No { get; set; }
            public string Product { get; set; }
            public decimal Amount { get; set; }
            public string Sale_Type { get; set; }
            public int? Token_No { get; set; }
            public string Odometer_Reading { get; set; }
            public string TID { get; set; }
            public string Outlet_Id { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class DealerCreditSaleByCard
        {
            public string Transaction_Id { get; set; }
            public string Transaction_Date { get; set; }
            public decimal Transaction_Amount { get; set; }
            public string Product { get; set; }
            public string Batch_Id { get; set; }
        }


        public class CardSaleByMobileNo_Input
        {
            public Int32 Mobile_No { get; set; }
            //public int OTP { get; set; }
            public string Product { get; set; }
            public decimal Amount { get; set; }
            public string Sale_Type { get; set; }
            public string Odometer_Reading { get; set; }
            public string TID { get; set; }
            public string Outlet_Id { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class CardSaleByMobileNo
        {
            public string Transaction_Id { get; set; }
            public string Transaction_Date { get; set; }
            public decimal Transaction_Amount { get; set; }
            public string Product { get; set; }
            public string Batch_Id { get; set; }
        }


        public class CreditSaleByMobileNo_Input
        {
            public Int32 Mobile_No { get; set; }
            //public int OTP { get; set; }
            public string Product { get; set; }
            public decimal Amount { get; set; }
            public string Sale_Type { get; set; }
            public string Odometer_Reading { get; set; }
            public string TID { get; set; }
            public string Outlet_Id { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class CreditSaleByMobileNo
        {
            public string Transaction_Id { get; set; }
            public string Transaction_Date { get; set; }
            public decimal Transaction_Amount { get; set; }
            public string Product { get; set; }
            public string Batch_Id { get; set; }
        }


        public class DealerCreditSaleByMobileNo_Input
        {
            public Int32 Mobile_No { get; set; }
            //public int OTP { get; set; }
            public string Product { get; set; }
            public decimal Amount { get; set; }
            public string Sale_Type { get; set; }
            public int? Token_No { get; set; }
            public int? Terminal_Pin { get; set; }
            public string Odometer_Reading { get; set; }
            public string TID { get; set; }
            public string Outlet_Id { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class DealerCreditSaleByMobileNo
        {
            public string Transaction_Id { get; set; }
            public string Transaction_Date { get; set; }
            public decimal Transaction_Amount { get; set; }
            public string Product { get; set; }
            public string Batch_Id { get; set; }
        }

        public class BalanceTransferByCard_Input
        {
            public Int32 Card_No { get; set; }
            public decimal Amount { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }

        public class BalanceTransferByMobileNo_Input
        {
            public Int32 Mobile_No { get; set; }
            public decimal Amount { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }
        public class VoidByCard_Input
        {
            public Int32 ROC_No { get; set; }
            public Int32 Card_No { get; set; }
            public decimal Amount { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }

        public class VoidByMobileNo_Input
        {
            public Int32 ROC_No { get; set; }
            public Int32 Mobile_No { get; set; }
            public int OTP { get; set; }
            public decimal Amount { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }


        public class SaveTrackingDetailByCard_Input
        {
            public Int32 Card_No { get; set; }
            public decimal Odometer_Reading { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }
            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

        }


        public class SaveTrackingDetailByMobileNo_Input
        {
            public Int32 Mobile_No { get; set; }
            public int OTP { get; set; }
            public decimal Odometer_Reading { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }
            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class PayMerchantByPayCode_Input
        {
            public string Pay_Code { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }
            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class ReversePayMerchantByPayCode_Input
        {
            public Int32 ROC_No { get; set; }
            public string Pay_Code { get; set; }
            public string Batch_Id { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }
            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class CreditSaleComplete_Input
        {
            public Int32 Control_Card_No { get; set; }
            public decimal Amount { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }
            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class RedemptionApiByCard_Input
        {
            public Int32 Card_No { get; set; }
            public string Fuel { get; set; }
            public int Points_to_Redeem { get; set; }
            public decimal Amount { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }
            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

       

        public class UnblockTerminalPin_Input
        {
            public int New_Pin { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }

        public class PayCardFee_Input
        {
            [RegularExpression(@"^[0-9]+$", ErrorMessage = "Form No numbers only.")]
            public Int64 Form_No { get; set; }

            [Required(ErrorMessage = "No Of Cards Required")]
            public int No_Of_Cards { get; set; }
            public decimal Amount { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
        }


        public class SaveOperatorInfo_Ter_Input
        {
            public Int32 Operator_Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public Int32 TID { get; set; }
            public Int32 Outlet_Id { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }
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


        public class Database_Status
        {
            public int Status { get; set; }
            public string Reason { get; set; }
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

    }
}