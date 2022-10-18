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
    public partial class frmRepairStockReport : MetroForm
    {
        Guid IdItem;
        public int ProductionType { get; set; }
        public int TabType { get; set; }
        frmStockAccounts frmstockaccounts;
        DataTable dtDetail;
        DataTable dtSummary;
        frmFindAccounts frmAccounts;
        public frmRepairStockReport()
        {
            InitializeComponent();
        }
        private void frmRepairStockReport_Load(object sender, EventArgs e)
        {
            this.grdRepairSummary.AutoGenerateColumns = false;
            this.grdRepairDetail.AutoGenerateColumns = false;
            this.grdRepairDetail.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.grdRejectionSummary.AutoGenerateColumns = false;
            this.grdRejectionDetail.AutoGenerateColumns = false;

            if (TabType == 1 && ProductionType == 1)
            {
                tabRepairRejection.TabPages.Remove(tabRejection);
                this.Text = "Gloves Repair Stock";
            }
            else if (TabType == 1 && ProductionType == 2)
            {
                tabRepairRejection.TabPages.Remove(tabRejection);
                this.Text = "Garments Repair Stock";
            }
            else if (TabType == 2 && ProductionType == 1)
            {
                tabRepairRejection.TabPages.Remove(tabRepair);
                this.Text = "Gloves Rejection Stock";
            }
            else if (TabType == 2 && ProductionType == 2)
            {
                tabRepairRejection.TabPages.Remove(tabRepair);
                this.Text = "Garments Rejection Stock";
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new ProductionProcessDetailBLL();
            List<VoucherDetailEL> listDetail = null;
            List<VoucherDetailEL> listSummary = null;
            if (TabType == 1)
            {
                listDetail = manager.GetRepairStockByArticle(IdItem, ProductionType);
                listSummary = manager.GetRepairStockForAllArticles(ProductionType);
                if (listDetail.Count > 0)
                {
                    PopulateDetailStock(listDetail, 1);
                }
                else
                {
                    grdRepairDetail.DataSource = null;
                }
                if (listSummary.Count > 0)
                {
                    grdRepairSummary.DataSource = listSummary;
                }
                else
                {
                    grdRepairSummary.DataSource = null;
                }
            }
            else
            {
                listDetail = manager.GetReadyToPackingStockByArticle(IdItem, ProductionType);
                listSummary = manager.GetReadyToPackingStockForAllArticles(ProductionType);
                if (listDetail.Count > 0)
                {
                    PopulateDetailStock(listDetail, 2);
                }
                if (listSummary.Count > 0)
                {
                    grdRejectionSummary.DataSource = listSummary;
                }
            }

        }
        private void PopulateDetailStock(List<VoucherDetailEL> lstStock, int j)
        {
            dtDetail = new DataTable();
            decimal DebitStock = 0, CreditStock = 0, Balance = 0, Qty = 0;
            ////if (lstStock.Count > 0)
            ////{s
            ////    grdTotalStock.DataSource = lstStock;                
            ////}
            dtDetail.Columns.Clear();
            dtDetail.Rows.Clear();
            dtDetail.Clear();
            dtDetail.Columns.Add("WorkDate");
            dtDetail.Columns.Add("Units");
            dtDetail.Columns.Add("Qty");
            dtDetail.Columns.Add("Balance");

            for (int i = 0; i < lstStock.Count; i++)
            {
                // Add rows.
                DataRow dr = dtDetail.NewRow();
                dr[0] = lstStock[i].WorkDate;
                dr[1] = lstStock[i].Units;
                dr[2] = lstStock[i].Qty;
                if (Validation.GetSafeString(lstStock[i].GatePassType) == "Out")
                {
                    CreditStock = Validation.GetSafeLong(lstStock[i].Qty);
                    Balance -= CreditStock;
                    Qty -= CreditStock;
                    dr[3] = Math.Abs(Qty);
                }
                if (Validation.GetSafeString(lstStock[i].GatePassType) == "In")
                {
                    DebitStock = Validation.GetSafeLong(lstStock[i].Units);
                    Balance += DebitStock;
                    Qty += DebitStock;
                    dr[3] = Math.Abs(Qty);
                }
                dtDetail.Rows.Add(dr);
            }
            if (j == 1)
            {
                if (dtDetail.Rows.Count > 0)
                {
                    grdRepairDetail.DataSource = dtDetail;
                }
                else
                {
                    grdRepairDetail.DataSource = null;
                }
            }
            else
            {
                if (dtDetail.Rows.Count > 0)
                {
                    grdRejectionDetail.DataSource = dtDetail;
                }
                else
                {
                    grdRejectionDetail.DataSource = null;
                }
            }
        }
        //private void PopulateSummaryStock(List<VoucherDetailEL> lstStock, int i)
        //{
        //    dtSummary = new DataTable();
        //    ////if (lstStock.Count > 0)
        //    ////{
        //    ////    grdTotalStock.DataSource = lstStock;                
        //    ////}
        //    dtSummary.Columns.Clear();
        //    dtSummary.Rows.Clear();
        //    dtSummary.Clear();
        //    dtSummary.Columns.Add("ItemName");
        //    dtSummary.Columns.Add("StockOut");
        //    dtSummary.Columns.Add("StockIn");
        //    dtSummary.Columns.Add("RemainingStock");

        //    for (int i = 0; i < lstStock.Count; i++)
        //    {
        //        // Add rows.
        //        DataRow dr = dtSummary.NewRow();
        //        dr[0] = lstStock[i].AccountName;
        //        dr[1] = lstStock[i].ItemName;
        //        dr[2] = lstStock[i].StockOut;
        //        dr[3] = lstStock[i].StockIn;
        //        dr[4] = lstStock[i].RemainingStock;
        //        dtSummary.Rows.Add(dr);
        //    }
        //    if (dtSummary.Rows.Count > 0)
        //    {
        //        grdInspectionSummary.DataSource = dtSummary;
        //    }
        //    else
        //    {
        //        grdInspectionSummary.DataSource = null;
        //    }
        //}
        private void txtProduct_ButtonClick(object sender, EventArgs e)
        {
            frmstockaccounts = new frmStockAccounts();
            frmstockaccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockaccounts_ExecuteFindStockAccountEvent);
            frmstockaccounts.ShowDialog();
        }
        private void txtProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtProduct.Text == string.Empty)
                {
                    txtProduct.Focus();
                }
                else
                    btnLoad.Focus();
            }
            else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                frmstockaccounts = new frmStockAccounts();
                frmstockaccounts.SearchText = e.KeyChar.ToString();
                frmstockaccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockaccounts_ExecuteFindStockAccountEvent);
                frmstockaccounts.ShowDialog();
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == (char)Keys.Back)
            {

            }
            else
                e.Handled = true;
        }
        void frmstockaccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            IdItem = oelItems.IdItem;
            txtProduct.Text = oelItems.ItemName;
        }

        private void CustEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmAccounts = new frmFindAccounts();
            frmAccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccounts_ExecuteFindAccountEvent);
            frmAccounts.ShowDialog();
        }

        void frmAccounts_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            var manager = new ProductionProcessDetailBLL();
            List<VoucherDetailEL> listDetail = null;
            if (TabType == 1)
            {
                listDetail = manager.GetRepairStockByArticleAndWorker(IdItem, ProductionType, oelAccount.AccountNo);
                if (listDetail.Count > 0)
                {
                    PopulateDetailStock(listDetail, 1);
                }
                else
                {
                    grdRejectionDetail.DataSource = null;
                }
            }
            else
            {

            }
        }
    }
}
