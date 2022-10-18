using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class ProcessesEL
    {
        public Guid IdProcess
        {
            get;
            set;
        }
        public string ProcessCode
        {
            get;
            set;
        }
        public Int32 ProcessType
        {
            get;
            set;
        }
        public decimal ProcessRate
        {
            get;
            set;
        }
        public string ProcessName
        {
            get;
            set;
        }
        public string Discription
        {
            get;
            set;
        }
        public DateTime? CreatedDateTime
        {
            get;
            set;
        }

    }
}
