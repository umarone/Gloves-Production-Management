using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class TradingEL : CompanyEL
    {
        public Guid IdTrading 
        {
            get;
            set;
        }
        public string TradingCode 
        { 
            get;
            set; 
        }
        public string TradingName 
        { 
            get; 
            set;
        }
        public string TradingDiscription
        {
            get;
            set;
        }
    }
}
