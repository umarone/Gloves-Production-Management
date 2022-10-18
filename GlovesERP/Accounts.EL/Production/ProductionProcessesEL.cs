using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class ProductionProcessesEL : ProductionProcessesHeadEL
    {
        public Guid IdProductionProcess
        {
            get;
            set;
        }

        public string ProductionProcessName
        {
            get;
            set;
        }
    }
}
