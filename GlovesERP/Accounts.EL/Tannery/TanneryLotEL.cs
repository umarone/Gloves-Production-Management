using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class TanneryLotEL : TanneryLotQualityEL
    {
        public Guid IdLot
        {
            get;
            set;
        }
        public Int64 LotNo
        {
            get;
            set;
        }
        public DateTime? LotDate
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public Int32 LotType
        {
            get;
            set;
        }
        public string LotTypeDiscription
        {
            get;
            set;
        }
        public decimal LotWeight
        {
            get;
            set;
        }
        public DateTime? CloseDate
        {
            get;
            set;
        }
    }
}
