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
    public partial class frmUserActivityReport : MetroForm
    {
        #region Variables
        string VoucherType = string.Empty;
        string StockVoucherType = string.Empty;
        string TanneryType = string.Empty;
        #endregion
        #region Form Events
        public frmUserActivityReport()
        {
            InitializeComponent();
        }

        private void frmUserActivityReport_Load(object sender, EventArgs e)
        {
            this.grdFindAccounts.AutoGenerateColumns = false;
            this.grdFinancialActivities.AutoGenerateColumns = false;
            this.grdStockActivities.AutoGenerateColumns = false;
            this.grdTanneryActivities.AutoGenerateColumns = false;
            LoadAllSystemUsers();
        }
        #endregion
        #region General Events
        private void LoadAllSystemUsers()
        {
            var manager = new UsersBLL();
            List<UsersEL> list = manager.GetAllUsers();
            if (list.Count > 0)
            {
                list.Insert(0, new UsersEL() { UserId = Guid.Empty, UserName = "Select User" });

                cbxUsers.DisplayMember = "UserName";
                cbxUsers.ValueMember = "UserId";
                cbxUsers.DataSource = list;
            }
        }
        #endregion
        #region Buttons Events
        private void btnAccountsActivities_Click(object sender, EventArgs e)
        {
            var Manager = new AccountsBLL();
            try
            {
                List<AccountsEL> list = null;
                if (cbxUsers.Text == "Select User")
                {
                    MessageBox.Show("Please Select User.....");
                    grdFindAccounts.DataSource = null;
                    return;
                }
                if (!chkAllAccounts.Checked)
                {
                    list = Manager.GetAllAccountsByUserAndDateForActivityLogger(Validation.GetSafeGuid(cbxUsers.SelectedValue), Convert.ToDateTime(dtActivity.Value.ToShortDateString()));
                }
                else
                {
                    list = Manager.GetAllAccountsByUserForActivityLogger(Validation.GetSafeGuid(cbxUsers.SelectedValue));
                }
                if (list.Count > 0)
                {
                    grdFindAccounts.DataSource = list;
                    lblTotalsum.Text = list.Count.ToString();
                }
                else
                {
                    grdFindAccounts.DataSource = null;
                    lblTotalsum.Text = "0";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnLoadFinancialActivities_Click(object sender, EventArgs e)
        {
            var Manager = new TransactionBLL();
            List<TransactionsEL> list = null;
            if (cbxUsers.Text == "Select User")
            {
                MessageBox.Show("Please Select User.....");
                grdFinancialActivities.DataSource = null;
                return;
            }
            if (!chkPaymentActivities.Checked && !chkReceiptActivities.Checked && !chkBankPaymentActivities.Checked && !chkBankReceiptActivities.Checked && chkJournalActivities.Checked)
            {
                MessageBox.Show("Please Select Activity Type...");
                return;
            }
            list = Manager.GetVouchersByUserAndDateForActivity(Validation.GetSafeGuid(cbxUsers.SelectedValue), Convert.ToDateTime(dtActivity.Value.ToShortDateString()), VoucherType);
            if (list.Count > 0)
            {
                grdFinancialActivities.DataSource = list;
                lblTotalsum.Text = list.Count.ToString();
            }
            else
            {
                grdFinancialActivities.DataSource = null;
                lblTotalsum.Text = "0";
            }
        }
        private void btnLoadStockActivity_Click(object sender, EventArgs e)
        {
            var Manager = new VoucherBLL();
            List<VouchersEL> list = null;
            if (cbxUsers.Text == "Select User")
            {
                MessageBox.Show("Please Select User.....");
                grdStockActivities.DataSource = null;
                return;
            }
            if (!chkPurchaseActivities.Checked && !chkPurchasesReturnActivity.Checked && !chkStockSaleActivites.Checked && !chkStockReturnAcitvities.Checked)
            {
                MessageBox.Show("Please Select Stock Activity Type...");
                return;
            }
            list = Manager.GetStockVouchersByUserAndDateForActivity(Validation.GetSafeGuid(cbxUsers.SelectedValue), Convert.ToDateTime(dtActivity.Value.ToShortDateString()), StockVoucherType);
            if (list.Count > 0)
            {
                grdStockActivities.DataSource = list;
                lblTotalsum.Text = list.Count.ToString();
            }
            else
            {
                grdStockActivities.DataSource = null;
                lblTotalsum.Text = "0";
            }
        }
        private void btnLoadTanneryActivities_Click(object sender, EventArgs e)
        {
            var Manager = new TanneryLotDetailBLL();
            List<TanneryLotDetailEL> list = null;
            if (cbxUsers.Text == "Select User")
            {
                MessageBox.Show("Please Select User.....");
                grdTanneryActivities.DataSource = null;
                return;
            }
            if (!chkTrimmingActivities.Checked && !chkSplittingActivities.Checked && !chkRetrimmingActivities.Checked && !chkShavingActivities.Checked
                && !chkDrummingActivities.Checked && !chkBuffingActivities.Checked && !chkCuttingActivities.Checked)
            {
                MessageBox.Show("Please Select Stock Activity Type...");
                return;
            }

            list = Manager.GetTanneryDetailsByUserAndDateForActivity(Validation.GetSafeGuid(cbxUsers.SelectedValue), Convert.ToDateTime(dtActivity.Value.ToShortDateString()), TanneryType);
            if (list != null && list.Count > 0)
            {
                grdTanneryActivities.DataSource = list;
                lblTotalsum.Text = list.Count.ToString();
            }
            else
            {
                lblTotalsum.Text = "0";
            }

        }
        #endregion
        #region CheckBox Events
        private void chkAllAccounts_CheckedChanged(object sender, EventArgs e)
        {
            grdFindAccounts.DataSource = null;
        }
        private void chkPaymentActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPaymentActivities.Checked)
            {
                chkReceiptActivities.Checked = false;
                chkBankPaymentActivities.Checked = false;
                chkBankReceiptActivities.Checked = false;
                chkJournalActivities.Checked = false;

                grdFinancialActivities.DataSource = null;
            }
            VoucherType = "PaymentVoucher";
        }
        private void chkReceiptActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReceiptActivities.Checked)
            {
                chkPaymentActivities.Checked = false;
                chkBankPaymentActivities.Checked = false;
                chkBankReceiptActivities.Checked = false;
                chkJournalActivities.Checked = false;

                grdFinancialActivities.DataSource = null;
            }
            VoucherType = "CashReceiptVoucher";
        }
        private void chkBankPaymentActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBankPaymentActivities.Checked)
            {
                chkReceiptActivities.Checked = false;
                chkPaymentActivities.Checked = false;
                chkBankReceiptActivities.Checked = false;
                chkJournalActivities.Checked = false;

                grdFinancialActivities.DataSource = null;
            }
            VoucherType = "BankPaymentVoucher";
        }
        private void chkBankReceiptActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBankReceiptActivities.Checked)
            {
                chkReceiptActivities.Checked = false;
                chkBankPaymentActivities.Checked = false;
                chkPaymentActivities.Checked = false;
                chkJournalActivities.Checked = false;

                grdFinancialActivities.DataSource = null;
            }
            VoucherType = "BankReceiptVoucher";
        }
        private void chkJournalActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (chkJournalActivities.Checked)
            {
                chkReceiptActivities.Checked = false;
                chkBankPaymentActivities.Checked = false;
                chkBankReceiptActivities.Checked = false;
                chkPaymentActivities.Checked = false;

                grdFinancialActivities.DataSource = null;
            }
            VoucherType = "JournalVoucher";
        }
        #endregion
        #region Stock CheckBoxes Events
        private void chkPurchaseActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPurchaseActivities.Checked)
            {
                chkPurchasesReturnActivity.Checked = false;
                chkStockSaleActivites.Checked = false;
                chkStockReturnAcitvities.Checked = false;
            }
            StockVoucherType = "Purchases";
        }
        private void chkPurchasesReturnActivity_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPurchasesReturnActivity.Checked)
            {
                chkPurchaseActivities.Checked = false;
                chkStockSaleActivites.Checked = false;
                chkStockReturnAcitvities.Checked = false;
            }
            StockVoucherType = "Purchases Return";
        }
        private void chkStockSaleActivites_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStockSaleActivites.Checked)
            {
                chkPurchaseActivities.Checked = false;
                chkPurchasesReturnActivity.Checked = false;
                chkStockReturnAcitvities.Checked = false;
            }
            StockVoucherType = "Sales";
        }
        private void chkStockReturnAcitvities_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStockReturnAcitvities.Checked)
            {
                chkPurchaseActivities.Checked = false;
                chkStockSaleActivites.Checked = false;
                chkPurchasesReturnActivity.Checked = false;
            }
            StockVoucherType = "Sales Return";
        }
        #endregion
        #region Tannery CheckBoxes Events
        private void chkTrimmingActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrimmingActivities.Checked)
            {
                chkSplittingActivities.Checked = false;
                chkRetrimmingActivities.Checked = false;
                chkShavingActivities.Checked = false;
                chkDrummingActivities.Checked = false;
                chkBuffingActivities.Checked = false;
                chkCuttingActivities.Checked = false;
                TanneryType = "Trimming";
            }
            grdTanneryActivities.DataSource = null;
        }
        private void chkSplittingActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSplittingActivities.Checked)
            {
                chkTrimmingActivities.Checked = false;
                chkRetrimmingActivities.Checked = false;
                chkShavingActivities.Checked = false;
                chkDrummingActivities.Checked = false;
                chkBuffingActivities.Checked = false;
                chkCuttingActivities.Checked = false;

                TanneryType = "Splitting";
            }
            grdTanneryActivities.DataSource = null;
        }
        private void chkRetrimmingActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRetrimmingActivities.Checked)
            {
                chkTrimmingActivities.Checked = false;
                chkSplittingActivities.Checked = false;
                chkShavingActivities.Checked = false;
                chkDrummingActivities.Checked = false;
                chkBuffingActivities.Checked = false;
                chkCuttingActivities.Checked = false;

                TanneryType = "ReTrimming";
            }
            grdTanneryActivities.DataSource = null;
        }
        private void chkShavingActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShavingActivities.Checked)
            {
                chkSplittingActivities.Checked = false;
                chkRetrimmingActivities.Checked = false;
                chkTrimmingActivities.Checked = false;
                chkDrummingActivities.Checked = false;
                chkBuffingActivities.Checked = false;
                chkCuttingActivities.Checked = false;

                TanneryType = "Shaving";
            }
            grdTanneryActivities.DataSource = null;
        }
        private void chkDrummingActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrummingActivities.Checked)
            {

                chkSplittingActivities.Checked = false;
                chkRetrimmingActivities.Checked = false;
                chkShavingActivities.Checked = false;
                chkTrimmingActivities.Checked = false;
                chkBuffingActivities.Checked = false;
                chkCuttingActivities.Checked = false;

                TanneryType = "Drumming";
            }
            grdTanneryActivities.DataSource = null;
        }
        private void chkBuffingActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBuffingActivities.Checked)
            {
                chkSplittingActivities.Checked = false;
                chkRetrimmingActivities.Checked = false;
                chkShavingActivities.Checked = false;
                chkTrimmingActivities.Checked = false;
                chkCuttingActivities.Checked = false;
                chkDrummingActivities.Checked = false;

                TanneryType = "Buffing";
            }
            grdTanneryActivities.DataSource = null;
        }
        private void chkCuttingActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCuttingActivities.Checked)
            {

                chkSplittingActivities.Checked = false;
                chkRetrimmingActivities.Checked = false;
                chkShavingActivities.Checked = false;
                chkTrimmingActivities.Checked = false;
                chkDrummingActivities.Checked = false;
                chkBuffingActivities.Checked = false;

                TanneryType = "Cutting";
            }
            grdTanneryActivities.DataSource = null;
        }
        #endregion
        #region Tab Events
        private void tabUserActivity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
