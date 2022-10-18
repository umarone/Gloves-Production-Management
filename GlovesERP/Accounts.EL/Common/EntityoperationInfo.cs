﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class EntityoperationInfo
    {
        public Guid ID
        {
            get;
            set;
        }
        public Int64 Number
        {
            get;
            set;
        }
        public Decimal OperationCost
        {
            get;
            set;
        }
        public bool IsSuccess
        {
            get;
            set;
        }
    }
}
