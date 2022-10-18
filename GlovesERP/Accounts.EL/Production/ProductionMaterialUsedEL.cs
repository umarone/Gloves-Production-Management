using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class ProductionMaterialUsedEL : ProductionProcessesEL
    {
        public Guid IdMaterialUsed
        {
            get;
            set;

        }
        public Decimal UsedQuantity
        {
            get;
            set;
        }
        public decimal Rate
        {
            get;
            set;
        }
        public decimal CurrentValue
        {
            get;
            set;
        }
    }
}
