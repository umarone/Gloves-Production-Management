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
    public partial class frmPartyRubberingStock : MetroForm
    {
        #region Variables
        string AccountNo;
        frmFindAccounts frmfindAccounts;
        frmStockAccounts frmstockaccounts;
        DataTable dtDetail;
        DataTable dtSummary;
        #endregion
        public frmPartyRubberingStock()
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
        private void AccEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindAccounts = new frmFindAccounts();
            frmfindAccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccounts_ExecuteFindAccountEvent);
            frmfindAccounts.ShowDialog();
        }
        void frmfindAccounts_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            AccountNo = oelAccount.AccountNo;
            AccEditBox.Text = oelAccount.AccountName;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new ProcessDetailBLL();
            if (!chkApplyDateFilter.Checked)
            {
                List<VoucherDetailEL> listDetail = manager.GetRubberizingStockByParty(Operations.IdCompany, AccountNo);
                List<VoucherDetailEL> listSummary = manager.GetRubberizingPartySummary(Operations.IdCompany, AccountNo);
                if (listDetail.Count > 0)
                {
                    listDetail.GroupBy(x => x.AccountName);
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
            List<VoucherDetailEL> listDetail = manager.GetRubberizingStockByPartyAndDate(Operations.IdCompany, AccountNo, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            List<VoucherDetailEL> listSummary = manager.GetRubberizingStockByPartySummaryAndDate(Operations.IdCompany, AccountNo, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
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
            decimal DebitStock = 0, CreditStock = 0, Balance = 0, Qty = 0, TotalValue = 0;
            string ItemName = lstStock[0].ItemName;
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
                //if (ItemName != lstStock[i].ItemName)
                //{
                //    Qty = 0;
                //    dr[5] = Qty;
                //}
                //if (Validation.GetSafeString(lstStock[i].GatePassType) == "Stock In")
                //{
                //    CreditStock = Validation.GetSafeLong(lstStock[i].Units);
                //    Balance -= CreditStock;
                //    if (Qty == 0)
                //        Qty = CreditStock;
                //    else
                //        Qty -= CreditStock;
                //    dr[5] = Qty;
                //}
                //if (Validation.GetSafeString(lstStock[i].GatePassType) == "Stock Out")
                //{
                //    DebitStock = Validation.GetSafeLong(lstStock[i].Units);
                //    Balance += DebitStock;
                //    Qty += DebitStock;
                //    dr[5] = Qty;                    
                //}
                //dr[5] = lstStock[i].Balance;
                dtDetail.Rows.Add(dr);
            }
            bool isalready = false;
            if (dtDetail.Rows.Count > 0)
            {
                grdRubberingDetail.DataSource = dtDetail;                
                for (int i = 0; i < lstStock.Count; i++)
                {
                    //ItemName = lstStock[i].ItemName;
                    //int ItemCount = lstStock.FindAll(x => x.ItemName == ItemName).Count;
                    //if (ItemCount >= 2 && isalready == false)
                    //{
                    //    isalready = true;
                    //    Qty = 0;
                    //    Balance = 0;
                    //}
                    //else if (ItemCount == 1)
                    //{
                    //    Qty = 0;
                    //    Balance = 0;
                    //}
                    //if (ItemCount >= 2)
                    //{
                    //    isalready = true;
                    //    Qty = 0;
                    //}
                    if (Validation.GetSafeString(lstStock[i].GatePassType) == "Stock In")
                    {
                        CreditStock = Validation.GetSafeLong(lstStock[i].Units);
                        Balance -= CreditStock;
                        if (Qty == 0)
                            Qty = CreditStock;
                        else
                            Qty -= CreditStock;
                        grdRubberingDetail.Rows[i].Cells["colBalance"].Value = Qty;
                    }
                    if (Validation.GetSafeString(lstStock[i].GatePassType) == "Stock Out")
                    {
                        DebitStock = Validation.GetSafeLong(lstStock[i].Units);
                        Balance += DebitStock;
                        Qty += DebitStock;
                        grdRubberingDetail.Rows[i].Cells["colBalance"].Value = Qty;
                    }
                }
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
            dtSummary.Columns.Add("ItemName");
            dtSummary.Columns.Add("StockOut");
            dtSummary.Columns.Add("StockIn");
            dtSummary.Columns.Add("RemainingStock");

            for (int i = 0; i < lstStock.Count; i++)
            {
                // Add rows.
                DataRow dr = dtSummary.NewRow();
                dr[0] = lstStock[i].ItemName;
                dr[1] = lstStock[i].StockOut;
                dr[2] = lstStock[i].StockIn;
                dr[3] = lstStock[i].RemainingStock;
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
        private void AccEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (AccEditBox.Text != string.Empty)
                {
                    btnLoad.Focus();
                }
            }
            else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                e.Handled = true;
                frmfindAccounts = new frmFindAccounts();
                frmfindAccounts.SearchText = e.KeyChar.ToString();
                frmfindAccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccounts_ExecuteFindAccountEvent);
                frmfindAccounts.ShowDialog();

            }
            else
                e.Handled = false;
        }

        
        private void txtProduct_ButtonClick(object sender, EventArgs e)
        {
            frmstockaccounts = new frmStockAccounts();
            frmstockaccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockaccounts_ExecuteFindStockAccountEvent);
            frmstockaccounts.ShowDialog();
        }
        void frmstockaccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            if (grdRubberingDetail.Rows.Count > 0)
            {
                var manager = new ProcessDetailBLL();
                txtProduct.Text = oelItems.ItemName;
                if (!chkApplyDateFilter.Checked)
                {
                    List<VoucherDetailEL> listDetail = manager.GetRubberizingStockByItemAndParty(Operations.IdCompany, oelItems.IdItem,AccountNo);
                    if (listDetail.Count > 0)
                    {
                        PopulateDetailStock(listDetail);
                    }
                }
                else
                {
                    List<VoucherDetailEL> listDetail = manager.GetRubberizingStockByItemAndDateAndParty(Operations.IdCompany, oelItems.IdItem, AccountNo, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
                    PopulateDetailStock(listDetail);
                }
            }
            else
            {
            }
        }        
    }
}
