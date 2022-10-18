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
    public partial class frmArticleStock : MetroForm
    {
        #region
        frmStockAccounts frmstockAccounts;
        frmFindAccounts frmfindAccounts;
        Guid IdArticle;
        string AccountNo;
        public int ProductionType { get; set; }
        #endregion
        public frmArticleStock()
        {
            InitializeComponent();
        }

        private void frmArticleStock_Load(object sender, EventArgs e)
        {
            this.grdArticles.AutoGenerateColumns = false;
            if (ProductionType == 1)
            {
                this.Text = "Gloves Article Stock Report";
            }
            else
            {
                this.Text = "Garments Article Stock Report";
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new ProductionProcessDetailBLL();//ProductionIssuanceHeadBLL();
            List<VoucherDetailEL> list = manager.GetArticleWiseInOutStock(IdArticle, ProductionType);//GetArticleWiseInOutStock(IdArticle, ProductionType);
            if (list.Count > 0)
            {
                SimplifyData(list);
            }
        }

        private void btnLoadbyFilter_Click(object sender, EventArgs e)
        {
            var manager = new ProductionProcessDetailBLL(); //ProductionIssuanceHeadBLL();
            List<VoucherDetailEL> list = manager.GetArticleDateWiseInOutStock(IdArticle, ProductionType, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            if (list.Count > 0)
            {
                SimplifyData(list);
            }
        }
        private void chkApplyDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApplyDateFilter.Checked)
            {
                pnlDate.Enabled = true;
                btnLoad.Enabled = false;
            }
            else
            {
                pnlDate.Enabled = false;
                btnLoad.Enabled = true;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            grdArticles.DataSource = null;
            AccEditBox.Text = string.Empty;
            AccountNo = string.Empty;
        }

        private void txtArticleName_ButtonClick(object sender, EventArgs e)
        {
            frmstockAccounts = new frmStockAccounts();
            frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
            frmstockAccounts.ShowDialog();
        }
        private void txtArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                frmstockAccounts = new frmStockAccounts();
                frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                frmstockAccounts.SearchText = e.KeyChar.ToString();
                frmstockAccounts.ShowDialog(this);
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == (char)Keys.Back)
            {

            }
            else
                e.Handled = true;
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            if (oelItems != null)
            {
                IdArticle = oelItems.IdItem;
                txtArticleName.Text = oelItems.ItemName;
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
            var manager = new ProductionIssuanceHeadBLL();
            AccountNo = oelAccount.AccountNo;
            AccEditBox.Text = oelAccount.AccountName;
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            if (!chkApplyDateFilter.Checked)
            {
                list = manager.GetWorkInProcessReportByWorker(IdArticle, ProductionType, AccountNo);
            }
            else
            {
                list = manager.GetDateWiseWorkInProcessReportByWorker(IdArticle, ProductionType, AccountNo, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            }
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
                if (Validation.GetSafeDecimal(list[i].StockOut) == 0)
                {
                    CreditStock = Validation.GetSafeLong(list[i].StockIn);
                    Balance += CreditStock;
                    Qty += CreditStock;
                    list[i].Balance = Math.Abs(Qty);
                }
                if (Validation.GetSafeDecimal(list[i].StockIn) == 0)
                {
                    DebitStock = Validation.GetSafeLong(list[i].StockOut);
                    Balance -= DebitStock;
                    Qty -= DebitStock;
                    list[i].Balance = Math.Abs(Qty);
                }
            }
            if (list.Count > 0)
            {
                grdArticles.DataSource = list;
                txtTotalIn.Text = list.Sum(x => x.StockIn).ToString();
                txtTotalOut.Text = list.Sum(x => x.StockOut).ToString();
                txtBalance.Text = (Validation.GetSafeDecimal(txtTotalIn.Text) - Validation.GetSafeDecimal(txtTotalOut.Text)).ToString();
            }
            else
            {
                txtTotalIn.Text = string.Empty;
                txtTotalOut.Text = string.Empty;
                txtBalance.Text = string.Empty;

            }
        }        
    }
}
