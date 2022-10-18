using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class ItemFormulaEL : ItemsEL
    {
        public Guid IdCalculation
        {
            get;
            set;
        }
        public string MaterialType
        {
            get;
            set;
        }
        public string OperationType
        {
            get;
            set;
        }
        public Int32 PerUnitTotal
        {
            get;
            set;
        }
        public decimal TotalExactQty
        {
            get;
            set;
        }
        public decimal TotalQty
        {
            get;
            set;
        }
    }
}
