using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class ProductionProcessesHeadEL : VoucherDetailEL
    {
        public string CustomerPO
        {
            get;
            set;
        }
        public Int32 ProductionType
        {
            get;
            set;
        }
        public DateTime VDate
        {
            get;
            set;
        }
        public DateTime CloseDate
        {
            get;
            set;
        }
    }
}
