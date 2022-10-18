using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class OrdersEL : VoucherDetailEL
    {
        public Guid IdOrder
        {
            get;
            set;
        }
        public Int64 OrderNo
        {
            get;
            set;
        }

        public string CustomerPo
        {
            get;
            set;
        }
        public Int32 OrderType
        {
            get;
            set;
        }
        public Int32 OrderStatus
        {
            get;
            set;
        }
        public DateTime? OrderDate
        {
            get;
            set;
        }
        public DateTime? ProductionDate
        {
            get;
            set;
        }
        public DateTime? DeliveryDate
        {
            get;
            set;
        }
    }
}
