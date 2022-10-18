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
    public partial class frmProductRubberingStock : MetroForm
    {
        Guid IdItem;
        frmStockAccounts frmstockaccounts;
        DataTable dtDetail;
        DataTable dtSummary;
        public frmProductRubberingStock()
        {
            InitializeComponent();
        }
        private void frmPartyRubberingStock_Load(object sender, EventArgs e)
        {
            this.grdRubberingSummary.AutoGenerateColumns = false;
            this.grdRubberingDetail.AutoGenerateColumns = false;
        }
        private void chkApplyDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApplyDateFilter.Checked)
            {
                pnlDate.Enabled = true;
            }
            else
            {
                pnlDate.Enabled = false;
            }
        }          
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new ProcessDetailBLL();
            if (!chkApplyDateFilter.Checked)
            {
                List<VoucherDetailEL> listDetail = manager.GetRubberizingStockByItem(Operations.IdCompany, IdItem);
                List<VoucherDetailEL> listSummary = manager.GetRubberizingItemSummary(Operations.IdCompany, IdItem);
                if (listDetail.Count > 0)
                {
                    PopulateDetailStock(listDetail);
                }               
                if (listSummary.Count > 0)
                {
                    PopulateSummaryStock(listSummary);
                }               
            }
            else
            {
               
            }
        }
        private void btnLoadbyFilter_Click(object sender, EventArgs e)
        {
            var manager = new ProcessDetailBLL();
            List<VoucherDetailEL> listDetail = manager.GetRubberizingStockByItemAndDate(Operations.IdCompany, IdItem, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            List<VoucherDetailEL> listSummary = manager.GetRubberizingItemSummaryAndDate(Operations.IdCompany, IdItem, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            if (listDetail.Count > 0)
            {
                PopulateDetailStock(listDetail);
            }
            if (listSummary.Count > 0)
            {
                PopulateSummaryStock(listSummary);
            }
        }
        private void PopulateDetailStock(List<VoucherDetailEL> lstStock)
        {
            dtDetail = new DataTable();
            decimal DebitStock = 0, CreditStock = 0, Balance = 0, Qty = 0;
            ////if (lstStock.Count > 0)
            ////{
            ////    grdTotalStock.DataSource = lstStock;                
            ////}
            dtDetail.Columns.Clear();
            dtDetail.Rows.Clear();
            dtDetail.Clear();
            dtDetail.Columns.Add("VoucherNo");
            dtDetail.Columns.Add("Date");
            dtDetail.Columns.Add("ItemName");
            dtDetail.Columns.Add("GatePassType");
            dtDetail.Columns.Add("Units");
            dtDetail.Columns.Add("Balance");

            for (int i = 0; i < lstStock.Count; i++)
            {
                // Add rows.
                DataRow dr = dtDetail.NewRow();
                dr[0] = lstStock[i].VoucherNo;
                dr[1] = lstStock[i].Date;
                dr[2] = lstStock[i].ItemName;
                dr[3] = lstStock[i].GatePassType;
                dr[4] = lstStock[i].Units;
                if (Validation.GetSafeString(lstStock[i].GatePassType) == "Stock In")
                {
                    CreditStock = Validation.GetSafeLong(lstStock[i].Units);
                    Balance -= CreditStock;
                    Qty -= CreditStock;
                    dr[5] = Qty;
                }
                if (Validation.GetSafeString(lstStock[i].GatePassType) == "Stock Out")
                {
                    DebitStock = Validation.GetSafeLong(lstStock[i].Units);
                    Balance += DebitStock;
                    Qty += DebitStock;
                    dr[5] = Qty;                    
                }
                //dr[5] = lstStock[i].Balance;
                dtDetail.Rows.Add(dr);
            }
            if (dtDetail.Rows.Count > 0)
            {
                grdRubberingDetail.DataSource = dtDetail;
            }
            else
            {
                grdRubberingDetail.DataSource = null;
            }
        }
        private void PopulateSummaryStock(List<VoucherDetailEL> lstStock)
        {
            dtSummary = new DataTable();
            ////if (lstStock.Count > 0)
            ////{
            ////    grdTotalStock.DataSource = lstStock;                
            ////}
            dtSummary.Columns.Clear();
            dtSummary.Rows.Clear();
            dtSummary.Clear();
            dtSummary.Columns.Add("AccountName");
            dtSummary.Columns.Add("ItemName");
            dtSummary.Columns.Add("StockOut");
            dtSummary.Columns.Add("StockIn");
            dtSummary.Columns.Add("RemainingStock");

            for (int i = 0; i < lstStock.Count; i++)
            {
                // Add rows.
                DataRow dr = dtSummary.NewRow();
                dr[0] = lstStock[i].AccountName;
                dr[1] = lstStock[i].ItemName;
                dr[2] = lstStock[i].StockOut;
                dr[3] = lstStock[i].StockIn;
                dr[4] = lstStock[i].RemainingStock;
                dtSummary.Rows.Add(dr);
            }
            if (dtSummary.Rows.Count > 0)
            {
                grdRubberingSummary.DataSource = dtSummary;
            }
            else
            {
                grdRubberingSummary.DataSource = null;
            }
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dtDetail);
            DV.RowFilter = string.Format("ItemName LIKE '%{0}%'", txtsearch.Text);
            grdRubberingDetail.DataSource = DV;
        }
        private void txtSearchByItem_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dtSummary);
            DV.RowFilter = string.Format("ItemName LIKE '%{0}%'", txtSearchByItem.Text);
            grdRubberingSummary.DataSource = DV;
        }
        private void txtProduct_ButtonClick(object sender, EventArgs e)
        {
            frmstockaccounts = new frmStockAccounts();
            frmstockaccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockaccounts_ExecuteFindStockAccountEvent);
            frmstockaccounts.ShowDialog();
        }
        void frmstockaccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            IdItem = oelItems.IdItem;
            txtProduct.Text = oelItems.ItemName;
        }
    }
}
