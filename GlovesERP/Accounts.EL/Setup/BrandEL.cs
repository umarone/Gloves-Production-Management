using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounts.EL;

namespace Accounts
{
    public class BrandEL : AccountsEL
    {
        public Guid IdBrand { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
    }
}
