using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class TanneryProcessesHeadEL : VoucherDetailEL
    {
        public string VehicleNo
        {
            get;
            set;
        }
        public bool? IsComplete
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
    

