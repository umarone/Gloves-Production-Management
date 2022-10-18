using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class RequisitionEL : VoucherDetailEL
    {
        public Guid IdRequisition
        {
            get;
            set;
        }
        public Guid IdOrder
        {
            get;
            set;
        }
        public Int64 ReqNo
        {
            get;
            set;
        }

        public string CustomerPo
        {
            get;
            set;
        }
        public Int32 ReqType
        {
            get;
            set;
        }
        public Int32 ReqStatus
        {
            get;
            set;
        }
        public DateTime? ReqDate
        {
            get;
            set;
        }
    }
}
