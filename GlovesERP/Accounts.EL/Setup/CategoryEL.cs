using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class CategoryEL : BrandEL
    {
        public Guid IdCategory { get; set; }        
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int BossCategory { get; set; }
    }
}
