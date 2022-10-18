using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class ModelEL : BrandEL
    {
        public Guid IdModel { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }
    }
}
