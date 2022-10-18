using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
   public class TransactionsEL : VoucherDetailEL
   {
       #region Transactions
       public Guid TransactionID
       {
           get;
           set;
       }
       public Guid IdDetail
       {
           get;
           set;
       }
       public string AccountName
       {
           get;
           set;
       }
       public string AccountType
       {
           get;
           set;
       }
       public long TotalSales
       {
           get;
           set;
       }
       public long TotalRecieveables
       {
           get;
           set;
       }
       public long TotalRecieved
       {
           get;
           set;
       }
       public long TotalReturns
       {
           get;
           set;
       }
       public long TotalPayables
       {
           get;
           set;
       }
       public int Seq
        {
            get;
            set;
        }
       public decimal OpeningBalance
       {
           get;
           set;
       }
       public decimal unitprice
       {
           get;
           set;
       }
        public decimal Qty
        {
            get;
            set;
        }
        public bool IsNew { get; set; }
      #endregion
    }
}
