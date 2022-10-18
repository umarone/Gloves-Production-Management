using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class ProductionOverHeadEL : AccountsEL
    {
        public Guid IdProductionOverHead 
        {
            get; 
            set; 
        }
        public Guid IdVoucher
        {
            get;
            set;
        }
        public Decimal OverHeadCost
        {
            get;
            set;
        }
        public Int32 ProcessType
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public bool IsNew
        {
            get;
            set;
        }
        public DateTime? OverHeadDate
        {
            get;
            set;
        }
    }
}
