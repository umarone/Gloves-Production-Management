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
    public partial class frmProductionWorkerReport : MetroForm
    {
        string AccountNo;
        int ProductionType;
        public frmProductionWorkerReport()
        {
            InitializeComponent();
        }
        private void frmTanneryWorkerReport_Load(object sender, EventArgs e)
        {
            this.grdWorkerReport.AutoGenerateColumns = false;
        }
        private void chkProduction_CheckedChanged(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroCheckBox chk = sender as MetroFramework.Controls.MetroCheckBox;
            if (chk != null)
            {
                if (chk.Name == "chkGloves")
                {
                    ProductionType = 1;
                    chkGarments.Checked = false;
                }
                else if (chk.Name == "chkGarments")
                {
                    ProductionType = 2;
                    chkGloves.Checked = false;
                }
            }
        }
        private void btnGetReport_Click(object sender, EventArgs e)
        {
            var manager = new ProductionProcessDetailBLL();
            List<ProductionProcessDetailEL> list = manager.GetVendorDateWiseWorkReport(AccountNo,ProductionType,startDate.Value,endDate.Value);
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
        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            CustEditBox.Text = oelAccount.AccountName;
            AccountNo = oelAccount.AccountNo;
        }
    }
}
