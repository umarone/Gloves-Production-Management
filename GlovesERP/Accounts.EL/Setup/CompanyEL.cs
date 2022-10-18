using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class CompanyEL
    {
        public Guid? IdCompany 
        { 
            get; 
            set; 
        }
        public string CompanyName 
        { 
            get; 
            set; 
        }
        public Int64 BookNo
        {
            get;
            set;
        }
        public string BookPeriod
        {
            get;
            set;
        }
        public bool IsActive 
        { 
            get; 
            set; 
        }
        public string Discription
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
