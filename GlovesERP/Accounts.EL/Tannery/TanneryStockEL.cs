using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class TanneryStockEL
    {
        public string AccountName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime? StockDate { get; set; }
        public decimal Units { get; set; }
        public decimal Value { get; set; }
        public Int64 LotNo { get; set; }
    }
}
