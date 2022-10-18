using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class ProductionProcessDetailEL : ProductionProcessesEL
    {
        public Guid IdProductionProcessDetail
        {
            get;
            set;
        }
        public Guid IdPosting
        {
            get;
            set;
        }
        public string PStyle
        {
            get;
            set;
        }
        public Int64 PostingNo
        {
            get;
            set;
        }
        public Int32 GarmentWorkType
        {
            get;
            set;
        }
        public Int32 GType
        {
            get;
            set;
        }
        public Int32 Quality
        {
            get;
            set;
        }
        public Int64 Quantity
        {
            get;
            set;
        }
        public Int64 ReadyUnits
        {
            get;
            set;
        }
        public Int64 Rejection
        {
            get;
            set;
        }
        public Int64 BQuantity
        {
            get;
            set;
        }
        public Int64 RepairQuantity
        {
            get;
            set;
        }
        public Int64 PackingCartons
        {
            get;
            set;
        }
        public Decimal Meters
        {
            get;
            set;
        }
        public int Pieces
        {
            get;
            set;
        }
        public DateTime? WorkDate
        {
            get;
            set;
        }       
        public decimal Rate
        {
            get;
            set;
        }
        public decimal InspectorRate
        {
            get;
            set;
        }
        public decimal InspectorAmount
        {
            get;
            set;
        }
    }
}
