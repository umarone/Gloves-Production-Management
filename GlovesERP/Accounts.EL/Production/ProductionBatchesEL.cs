using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class ProductionBatchesEL : VouchersEL
    {
        public Guid IdBatch { get; set; }
        public string BatchNumber { get; set; }
        public string OutWardStatus { get; set; }
        public string InWardStatus { get; set; }
        public int BatchStatus { get; set; }
        public string BatchCompletionStatus { get; set; }
        public int ProductionType { get; set; }
        public decimal BatchCost { get; set; }

    }
}
