using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class OpeningBalanceEL : UsersEL
    {
        public Guid IdOpeningBalance { get; set; }
        public Guid IdTransaction { get; set; }
        public Guid IdStockReceipt { get; set; }
        public Int64 BookNo { get; set; }
        public string AccountNo { get; set; }
        public string LinkAccountNo { get; set; }
        public string AccountName { get; set; }
        public Int32 IdHead { get; set; }
        public string EmpCode { get; set; }
        public Int64 Units { get; set; }
        public decimal Amount { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public bool IsCurrent {get; set;}
        public string Description { get; set; }
        public string SettlementType { get; set; }              
        public bool IsNew { get; set; }
        public DateTime OpeningBalanceDate { get; set; }
    }
}
