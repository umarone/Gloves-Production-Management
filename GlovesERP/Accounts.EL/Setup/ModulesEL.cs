using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class ModulesEL : UsersEL
    {
        public Guid IdModule 
        { 
            get; 
            set; 
        }
        public string ModuleName
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
