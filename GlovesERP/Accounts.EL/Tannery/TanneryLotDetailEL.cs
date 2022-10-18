using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class TanneryLotDetailEL : TanneryLotEL
    {
        public Guid IdLotDetail
        {
            get;
            set;
        }
        public int ProcessType
        {
            get;
            set;
        }
        public int SeqNo
        {  
            get;
            set;
        }
        public Int64 PostingNo
        {
            get;
            set;
        }
        public Guid IdPosting
        {
            get;
            set;
        }
        public String Uom
        {
            get;
            set;
        }
        public decimal Weight
        {
            get;
            set;
        }
        public int Pieces 
        { 
            get; 
            set; 
        }
        public int PPieces
        {
            get;
            set;
        }
        public Int64 Galma
        {
            get;
            set;
        }
        public Int64 Puttha
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
        public int GalmaPieces
        {
            get;
            set;
        }
        public int PutthaPieces
        {
            get;
            set;
        }
        public int DGalma
        {
            get;
            set;
        }
        public decimal CuttingRateValue
        {
            get;
            set;
        }
        public int Cutting
        {
            get;
            set;
        }
        public int CuttingStock
        {
            get;
            set;
        }
        public decimal CuttingStockValue 
        { 
            get; 
            set; 
        }
        public decimal Money
        {
            get;
            set;
        }
        public DateTime? WorkingDate
        {
            get;
            set;
        }
    }
}
