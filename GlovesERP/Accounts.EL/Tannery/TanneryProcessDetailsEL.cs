using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class TanneryProcessDetailsEL : TanneryProcessesEL
    {
        public Guid IdProcessDetail
        {
            get;
            set;
        }
        public Int64 IdPosting
        {
            get;
            set;
        }
        public Int64 PostingNo 
        { 
            get; 
            set; 
        }
        public Guid IdItem
        {
            get;
            set;
        }
        public string LOT
        {
            get;
            set;
        }
        public string Quality
        {
            get;
            set;
        }
        public Int64 Galma
        {
            get;
            set;
        }
        public Int64 GalmaPieces
        {
            get;
            set;
        }
        public Int64 Puttha
        {
            get;
            set;
        }
        public Int64 PutthaPieces
        {
            get;
            set;
        }
        public Int64 SGalma
        {
            get;
            set;
        }
        public Int64 SPuttha
        {
            get;
            set;
        }
        public Int64 DGalma
        {
            get;
            set;
        }
        public Int64 DPuttha
        {
            get;
            set;
        }
        public Int64 Pieces
        {
            get;
            set;
        }
        public DateTime WorkDate
        {
            get;
            set;
        }
        public DateTime? WorkingDate
        {
            get;
            set;
        }
        public Int64 SSet
        {
            get;
            set;
        }
        public decimal Rate
        {
            get;
            set;
        }
    }
}
