using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.EL;
using Accounts.BLL;
using Accounts.Common;
using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmProcessWiseItemStock : MetroForm
    {
        #region        
        public Guid IdItem { get; set; }
        public string ItemName { get; set; }
        public int ProcessIndex { get; set; }
        DataTable dt;
        #endregion
        public frmProcessWiseItemStock()
        {
            InitializeComponent();
        }
        private void frmProcessWiseItemStock_Load(object sender, EventArgs e)
        {
            this.grdProcessStock.AutoGenerateColumns = false;
            this.Text = ItemName + " Stock Report"  ;
            LoadItemWiseStock();
        }
        private void LoadItemWiseStock()
        {           
            var manager = new ProductionIssuanceHeadBLL();                   
            List<VoucherDetailEL> list = manager.GetProcessWiseStockByItem(IdItem, ProcessIndex);
            if (list.Count > 0)
            {
                SimplifyData(list);
            }
        }     
        private void SimplifyData(List<VoucherDetailEL> list)
        {
            decimal DebitStock = 0, CreditStock = 0, Balance = 0, Qty = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (Validation.GetSafeDecimal(list[i].OpeningStock) != 0)
                {
                    CreditStock = Validation.GetSafeLong(list[i].OpeningStock);
                    Balance += CreditStock;
                    Qty += CreditStock;
                    list[i].Balance = Math.Abs(Qty);
                }
                if (Validation.GetSafeDecimal(list[i].StockIn) != 0)
                {
                    CreditStock = Validation.GetSafeLong(list[i].StockIn);
                    Balance += CreditStock;
                    Qty += CreditStock;
                    list[i].Balance = Math.Abs(Qty);
                }
                if (Validation.GetSafeDecimal(list[i].StockOut) != 0)
                {
                    DebitStock = Validation.GetSafeLong(list[i].StockOut);
                    Balance -= DebitStock;
                    Qty -= DebitStock;
                    list[i].Balance = Qty;
                }
            }
            grdProcessStock.DataSource = list;
        }        
    }
}
