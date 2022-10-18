using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class TanneryProcessesEL : TanneryProcessesHeadEL
    {
        public Guid IdProcess
        {
            get;
            set;
        }

        public string ProcessName
        {
            get;
            set;
        }
    }
}
