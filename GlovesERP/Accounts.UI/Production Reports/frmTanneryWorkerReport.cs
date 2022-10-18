using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.EL;
using Accounts.Common;
using Accounts.BLL;
using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmTanneryWorkerReport : MetroForm
    {
        string AccountNo;
        bool WorkType;
        frmTanneryWorkerDetailReport TWDR = null;
        public frmTanneryWorkerReport()
        {
            InitializeComponent();
        }
        private void frmTanneryWorkerReport_Load(object sender, EventArgs e)
        {
            this.grdWorkerReport.AutoGenerateColumns = false;
        }
        private void chkLots_CheckedChanged(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroCheckBox chk = sender as MetroFramework.Controls.MetroCheckBox;
            if (chk != null)
            {
                if (chk.Name == "chkLots")
                {
                    WorkType = true;
                    chkOthers.Checked = false;
                }
                else if (chk.Name == "chkOthers")
                {
                    WorkType = false;
                    chkLots.Checked = false;
                }
            }
        }
        private void btnGetReport_Click(object sender, EventArgs e)
        {
            var manager = new TanneryProcessDetailsBLL();
            List<TanneryProcessDetailsEL> list = manager.GetVendorDateWiseWorkReport(AccountNo, WorkType, Convert.ToDateTime(startDate.Value.ToShortDateString()), Convert.ToDateTime(endDate.Value.ToShortDateString()));
            if (list.Count > 0)
            {
                this.grdWorkerReport.DataSource = list;
            }
            else
            {
                this.grdWorkerReport.DataSource = null;
            }
        }
        frmFindAccounts frmAccount;
        private void CustEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmAccount = new frmFindAccounts();
            frmAccount.SearchText = "";
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        private void CustEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnGetReport.Focus();
            }
            else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                e.Handled = true;
                frmAccount = new frmFindAccounts();
                frmAccount.SearchText = e.KeyChar.ToString();
                frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                frmAccount.ShowDialog();

            }
            else
                e.Handled = false;

        }
        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            CustEditBox.Text = oelAccount.AccountName;
            AccountNo = oelAccount.AccountNo;
        }

        private void grdWorkerReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                e.Value = "View Detail";
            }
        }

        private void grdWorkerReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                TWDR = new frmTanneryWorkerDetailReport();
                TWDR.startDate = Convert.ToDateTime(startDate.Value.ToShortDateString());
                TWDR.endDate = Convert.ToDateTime(endDate.Value.ToShortDateString());
                TWDR.WorkType = Validation.GetSafeString(grdWorkerReport.Rows[e.RowIndex].Cells["colWorkType"].Value);
                TWDR.AccountNo = AccountNo;
                TWDR.AccountName = Validation.GetSafeString(grdWorkerReport.Rows[e.RowIndex].Cells["colAccountName"].Value);
                TWDR.ShowDialog();
            }
        }
    }
}
