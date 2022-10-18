using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class CurrencyEL : UsersEL
    {
        public Int64 IdCurrency { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
