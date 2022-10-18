using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class VoucherDetailEL : VouchersEL
    {
        public Guid? IdVoucherDetail 
        { 
            get; 
            set; 
        }
        public string ColorTemprature
        {
            get;
            set;
        }

        public decimal Units
        {
            get;
            set;
        }
        public decimal ExtraAvailableQuantity
        {
            get;
            set;
        }
        public decimal IssuedExtraQuantity
        {
            get;
            set;
        }
        public Int64 CurrentStock
        {
            get;
            set;
        }
        public Int64 IssuanceDept
        {
            get;
            set;
        }
        public Int64 TotalCartons
        {
            get;
            set;
        }
        public Int64 Bonus
        {
            get;
            set;
        }
        public decimal TotalUnits
        {
            get;
            set;
        }
        public Int64 RemainingUnits
        {
            get;
            set;
        }
        public Int64 ClosingUnits
        {
            get;
            set;
        }

        ////Meter Yard Region
        #region Clothe Region
        public decimal MeterYardQty
        {
            get;
            set;
        }
        public decimal BariSize
        {
            get;
            set;
        }
        public decimal TotalBari
        {
            get;
            set;
        }
        public decimal TalliBariWidth
        {
            get;
            set;
        }
        public decimal TalliBariSize
        {
            get;
            set;
        }
        public decimal CalculatedQty
        {
            get;
            set;
        }
        public decimal RequiredQty
        {
            get;
            set;
        }
        public decimal TotalCuffs
        {
            get;
            set;
        }
        public decimal Dozen
        {
            get;
            set;
        }
        public decimal EstimatedQty
        {
            get;
            set;
        }
        #endregion



    }
}
