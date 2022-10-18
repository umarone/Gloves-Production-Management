using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class GroupsEL : ItemsEL
    {
        public Guid IdGroup { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
    }
}
