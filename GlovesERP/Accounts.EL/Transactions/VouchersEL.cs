using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class VouchersEL : ItemsEL
    {
        public Guid IdVoucher 
        { 
            get; 
            set; 
        }
        public Guid IdOrder
        {
            get;
            set;
        }
        public string CurrencyName
        {
            get;
            set;
        }
        public Int64 IdCurrency
        {
            get;
            set;
        }
        public Int64 IdCurrencyRate
        {
            get;
            set;
        }
        public Guid IdRequisition
        {
            get;
            set;
        }
        public Guid IdDepartment
        {
            get;
            set;
        }
        public int IdProductionDepartment
        {
            get;
            set;
        }
        public int IdHeadDepartment
        {
            get;
            set;
        }
        public Int64 VoucherNo
        {
            get;
            set;
        }
        public Int64 BookNo
        {
            get;
            set;
        }
        public Int64 OperationType
        {
            get;
            set;
        }        
        public Int64 SampleNo
        {
            get;
            set;
        }
        public string PaymentTerms
        {
            get;
            set;
        }
        public string DeliveryTerms
        {
            get;
            set;
        }
        public string IssuanceWidth
        {
            get;
            set;
        }
        public string DayBook
        {
            get;
            set;
        }
        public int WorkType
        {
            get;
            set;
        }
        public bool? IsClaimed
        {
            get;
            set;
        }
        public bool? IsPlain
        {
            get;
            set;
        }
        public Int32 ProcessType
        {
            get;
            set;
        }
        public Int32 Purchaser
        {
            get;
            set;
        }
        public bool IsNetTransaction
        {
            get;
            set;
        }
        public Int32 Seller
        {
            get;
            set;
        }
        public Int32 SaleType
        {
            get;
            set;
        }
        public Int32 GPType
        {
            get;
            set;
        }
        public string GatePassType
        {
            get;
            set;
        }
        public string PoNumber
        {
            get;
            set;
        }
        public Int64 TotalSales
        {
            get;
            set;
        }
        public Int64 TotalSalesReturn
        {
            get;
            set;
        }
        public string DemandNo
        {
            get;
            set;
        }
        public string OutWardGatePassNo
        {
            get;
            set;
        }
        public string InWardGatePassNo
        {
            get;
            set;
        }
        public Guid IdUser
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }
        public string WorkDate
        {
            get;
            set;
        }
        public DateTime? VDate
        {
            get;
            set;
        }
        public string ChequeNo
        {
            get;
            set;
        }
        public string BillNo
        {
            get;
            set;
        }
        public string VehicalNo
        {
            get;
            set;
        }
        public Int32 VehicalType
        {
            get;
            set;
        }
        public decimal Weight
        {
            get;
            set;
        }
        public int PurchaseType
        {
            get;
            set;
        }
        public decimal OpeningStock
        {
            get;
            set;
        }
        public decimal StockOut
        {
            get;
            set;
        }
        public decimal StockIn
        {
            get;
            set;
        }
        public decimal RemainingStock
        {
            get;
            set;
        }
        public string BatchNo
        {
            get;
            set;
        }
        public Int64 ProductionBatchNo
        {
            get;
            set;
        }
        public Int64 MemoSaleNo
        {
            get;
            set;
        }
        public string VDiscription
        {
            get;
            set;
        }
        public decimal ClosingBalance
        {
            get;
            set;
        }
        public decimal Debit
        {
            get;
            set;
        }
        public decimal Credit
        {
            get;
            set;
        }
        public decimal BillAmount
        {
            get;
            set;
        }
        public decimal Amount
        {
            get;
            set;
        }
        public decimal TotalAmount
        {
            get;
            set;
        }
        public decimal LabourCost
        {
            get;
            set;
        }
        public decimal MaterialsCost
        {
            get;
            set;
        }
        public decimal VAT
        {
            get;
            set;
        }
        public decimal VATAmount
        {
            get;
            set;
        }
        public decimal CashPaid
        {
            get;
            set;
        }
        public decimal Discount
        {
            get;
            set;
        }
        public decimal TotalDiscount
        {
            get;
            set;
        }
        public decimal TotalFreight
        {
            get;
            set;
        }
        public decimal ExtraDiscount
        {
            get;
            set;
        }
        public decimal BillAmountAfterDiscount
        {
            get;
            set;
        }
        public decimal NetSaleAmount
        {
            get;
            set;
        }
        public decimal FlatDiscount
        {
            get;
            set;
        }
        public decimal DiscountAmount
        {
            get;
            set;
        }
        public decimal NetAmount
        {
            get;
            set;
        }
        public bool IsSold
        {
            get;
            set;
        }
        public bool IsImport
        {
            get;
            set;
        }
        public bool Posted
        {
            get;
            set;
        }
        public bool? IsDeleted
        {
            get;
            set;
        }
        public string VoucherType
        {
            get;
            set;
        }
        public string JVType
        {
            get;
            set;
        }
        public string PersonName
        {
            get;
            set;
        }
        public Int64 Transactiondays
        {
            get;
            set;
        }
        public Int64 RemainingDays
        {
            get;
            set;
        }
        public Boolean? IsRecieved
        {
            get;
            set;
        }
        public Int32 ReturnType
        {
            get;
            set;
        }
        public string Narration
        {
            get;
            set;
        }
        public Int32? AdjustmentType
        {
            get;
            set;
        }
        public string TransactionType
        {
            get;
            set;
        }
        public string SettlementType
        {
            get;
            set;
        }
        public decimal TotalUnits { get; set; }
        public decimal TotalRate { get; set; }
        public bool IsAuthorized { get; set; }
        public decimal ActualWidth { get; set; }
        public decimal OutWidth { get; set; }
        public decimal Diff { get; set; }
        public decimal SideAmount { get; set; }
        public decimal NewCost { get; set; }
        public decimal AVGSideRate { get; set; }
        public string BalanceType { get; set; }
        public string TypedClosingBalance { get; set; }
        #region ExportInvoiceParams
        public int InvoiceType { get; set; }
        public string SystemInvoiceNo { get; set; }
        public int HeadSeller {get; set;} 
        public string ShortCode { get; set; }
        public int BillType { get; set; }
        public string BillNumber { get; set; }
        public DateTime? BillDate { get; set; }
        public string FormE { get; set; }
        public DateTime? FormDate { get; set; }
        public string IncoTerms { get; set; }
        public string OrderDestination { get; set; }
        public string DischargePort { get; set; }
	    public int WearType { get; set; }
        public Int64 TotalCartons { get; set; }
        public decimal ForeignAmount { get; set; }
            
        #endregion
    }
}
