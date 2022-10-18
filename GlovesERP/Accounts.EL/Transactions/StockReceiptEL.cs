using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class StockReceiptEL : VouchersEL
    {
        public Guid IdStockReceipt
        {
            get;
            set;
        }
        public Guid IdUser
        {
            get;
            set;
        }
        public string ItemNo
        {
            get;
            set;
        }
        public string Power
        {
           get;
           set;
        }
        public string ColorTemperature
        {
            get;
            set;
        }
        public string PackingSize
        {
            get;
            set;
        }
        public string BatchNo
        {
            get;
            set;
        } 
        public Int64 Units
        {
            get;
            set;
        }
        public Int64 RemainingUnits
        {
            get;
            set;
        }
        public DateTime StockDate
        {
            get;
            set;
        }
        public string ActionType
        {
            get;
            set;
        }
        public decimal CuttingQuantity { get; set; }
        public decimal Opening
        {
            get;
            set;
        }
        public decimal Purchases
        {
            get;
            set;
        }
        public decimal Returns
        {
            get;
            set;
        }
        public decimal Sales
        {
            get;
            set;
        }
        public decimal SalesReturn
        {
            get;
            set;
        }
        public decimal Samples
        {
            get;
            set;
        }
        public decimal SamplesReturn
        {
            get;
            set;
        }
        public decimal TanneryUsed
        {
            get;
            set;
        }
        public decimal SoldIn
        {
            get;
            set;
        }
        public decimal PurchasesReturn
        {
            get;
            set;
        }
        public decimal RubberingIn
        {
            get;
            set;
        }
        public decimal RubberingOut
        {
            get;
            set;
        }
        public decimal RubberingSideCutting
        {
            get;
            set;
        }        
        public decimal ProductionIn
        {
            get;
            set;
        }
        public decimal ProductionOut
        {
            get;
            set;
        }
        public decimal JvIn
        {
            get;
            set;
        }
        public decimal JvOut
        {
            get;
            set;
        }
        public decimal Closing
        {
            get;
            set;
        }
        public decimal AVR
        {
            get;
            set;
        }
        public decimal NVR
        {
            get;
            set;
        }
        public decimal DyingUnits
        {
            get;
            set;
        }
    }
}
