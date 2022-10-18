using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class RequisitionDetailEL : RequisitionEL
    {
        public Guid IdRequisitionDetail
        {
            get;
            set;
        }
        public Guid IdArticle
        {
            get;
            set;
        }
        public Guid IdSize
        {
            get;
            set;
        }
        public string Color
        {
            get;
            set;
        }
        public Int64 Quantity
        {
            get;
            set;
        }
        public Int64 Small
        {
            get;
            set;
        }
        public Int64 Medium
        {
            get;
            set;
        }
        public Int64 Large
        {
            get;
            set;
        }
        public Int64 XLarge
        {
            get;
            set;
        }
        public Int64 DoubleXLarge
        {
            get;
            set;
        }
        public Int64 TripleXLarge
        {
            get;
            set;
        }
        public Int64 FourthXLarge
        {
            get;
            set;
        }
        public Int64 FifthXLarge
        {
            get;
            set;
        }
        public Int64 TotalBreakup
        {
            get;
            set;
        }
        public decimal Dying
        {
            get;
            set;
        }
        public decimal AvgRate
        {
            get;
            set;
        }
        public decimal TotalAvgRate
        {
            get;
            set;
        }
        public Int64 ReqDetailType
        {
            get;
            set;
        }
    }
}
