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
    public partial class frmStitcherWiseRepairReport : MetroForm
    {
        frmFindAccounts frmfindAccounts;
        public int ProductionType { get; set; }
        string AccountNo;
        DataTable dtDetail;
        DataTable dtSummary;
        public frmStitcherWiseRepairReport()
        {
            InitializeComponent();
        }
        private void frmStitcherWiseRepairReport_Load(object sender, EventArgs e)
        {
            grdRepairDetail.AutoGenerateColumns = false;
            grdRepairSummary.AutoGenerateColumns = false;
            if (ProductionType == 1)
            {
                this.Text = "Gloves Maker Repair Stock";
            }
            else if (ProductionType == 2)
            {
                this.Text = "Garments Maker Repair Stock";
            }
        }
        private void CustEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindAccounts = new frmFindAccounts();
            frmfindAccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccounts_ExecuteFindAccountEvent);
            frmfindAccounts.ShowDialog();
        }
        private void CustEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (CustEditBox.Text == string.Empty)
                    {
                    CustEditBox.Focus();
                    }
                    else
                        btnGetReport.Focus();
                }
                else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmfindAccounts = new frmFindAccounts();
                    frmfindAccounts.SearchText = e.KeyChar.ToString();
                    frmfindAccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccounts_ExecuteFindAccountEvent);
                    frmfindAccounts.ShowDialog();
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            
        }
        void frmfindAccounts_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            CustEditBox.Text = oelAccount.AccountName;
            AccountNo = oelAccount.AccountNo;
        }
        private void btnGetReport_Click(object sender, EventArgs e)
        {
            var manager = new ProductionProcessDetailBLL();
            List<VoucherDetailEL> listDetail = null;
            List<VoucherDetailEL> listSummary = null;
            listDetail = manager.GetRepairStockByStitcher(AccountNo, ProductionType);
            listSummary = manager.GetRepairStockForAllArticlesByStitcher(ProductionType,AccountNo);
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
            dtDetail.Columns.Add("ItemName");
            dtDetail.Columns.Add("Units");
            dtDetail.Columns.Add("Qty");
            dtDetail.Columns.Add("Balance");

            for (int i = 0; i < lstStock.Count; i++)
            {
                // Add rows.
                DataRow dr = dtDetail.NewRow();
                dr[0] = lstStock[i].WorkDate;
                dr[1] = lstStock[i].ItemName;
                dr[2] = lstStock[i].Units;
                dr[3] = lstStock[i].Qty;
                if (Validation.GetSafeString(lstStock[i].GatePassType) == "Out")
                {
                    CreditStock = Validation.GetSafeLong(lstStock[i].Qty);
                    Balance -= CreditStock;
                    Qty -= CreditStock;
                    dr[4] = Math.Abs(Qty);
                }
                if (Validation.GetSafeString(lstStock[i].GatePassType) == "In")
                {
                    DebitStock = Validation.GetSafeLong(lstStock[i].Units);
                    Balance += DebitStock;
                    Qty += DebitStock;
                    dr[4] = Math.Abs(Qty);
                }
                dtDetail.Rows.Add(dr);
            }
            if (dtDetail.Rows.Count > 0)
            {
                grdRepairDetail.DataSource = dtDetail;
            }
            else
            {
                grdRepairDetail.DataSource = null;
            }
        }        
    }
}
