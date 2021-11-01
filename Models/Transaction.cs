using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MQWebAPI.Models
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

            public string Reason { get; set; }

            public int Status { get; set; }
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



    }
}