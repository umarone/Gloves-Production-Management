using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class OrdersDetailEL : OrdersEL
    {
        public Guid IdOrderDetail
        {
            get;
            set;
        }
        public Guid IdSize
        {
            get;
            set;
        }
        public string Configuration 
        {
            get; 
            set; 
        }
        public string Color
        {
            get;
            set;
        }
        public Int64 Quantity
        {
            get;
            set;
        }
        public Int64 DeliveredQuantity 
        { 
            get; 
            set; 
        }
        public Int64 DeliveredRemainderQuantity
        {
            get;
            set;
        }
    }
}
