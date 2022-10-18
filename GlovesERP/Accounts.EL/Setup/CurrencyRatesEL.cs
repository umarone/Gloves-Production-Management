using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class CurrencyRatesEL : CurrencyEL
    {
        public Int64 IdCurrencyRates { get; set; }
        public decimal CurrencyRates { get; set; }
        public bool? IsCurrent { get; set; }
    }
}
