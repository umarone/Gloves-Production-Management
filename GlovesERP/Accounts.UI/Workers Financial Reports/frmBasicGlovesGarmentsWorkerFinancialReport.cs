using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.BLL;
using Accounts.EL;
using MetroFramework.Forms;
using MetroFramework.Controls;
using Accounts.Common;

namespace Accounts.UI
{
    public partial class frmBasicGlovesGarmentsWorkerFinancialReport : MetroForm
    {
        #region Variables
        frmPrintGlovesGarmentsWrokerReports frmprint;
        frmFindAccounts frmfindAccounts;
        Guid IdArticle;
        string AccountNo;
        public int ProductionType { get; set; }
        public Int32 GPType { get; set; }
        public bool IsOut { get; set; }
        #endregion
        public frmBasicGlovesGarmentsWorkerFinancialReport()
        {
            InitializeComponent();
        }
        private void frmBasicGlovesGarmentsWorkerFinancialReport_Load(object sender, EventArgs e)
        {
            this.grdWork.AutoGenerateColumns = false;
            this.grdLoanDetail.AutoGenerateColumns = false;
            this.grdAdvancesDetail.AutoGenerateColumns = false;
            this.grdPaymentDetail.AutoGenerateColumns = false;
            LoadStepsByType();
            if (GPType == 1)
            {
                this.Text = "Gloves Workers Financial Report";
            }
            else
            {
                this.Text = "Garments Workers Financial Report";
            }
            
        }
        private void ShowHideColumns()
        {
            if (ProductionType == 2)
            {
                grdWork.Columns["colItemName"].Visible = false;

                grdWork.Columns["colArticleName"].Visible = true;
                grdWork.Columns["colBrandName"].Visible = true;
            }
        }
        private void LoadStepsByType()
        {
            if (GPType == 1)
            {
                cbxProductionType.Items.Add("");
                cbxProductionType.Items.Add("Cuff Cutting");
                cbxProductionType.Items.Add("Talli Cutting");
                cbxProductionType.Items.Add("Cuff Printing");
                cbxProductionType.Items.Add("OverLock");
                cbxProductionType.Items.Add("Magzi/Tape");
            }           
        }
        private void AccEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindAccounts = new frmFindAccounts();
            frmfindAccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccounts_ExecuteFindAccountEvent);
            frmfindAccounts.ShowDialog();
        }
        private void AccEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                frmfindAccounts = new frmFindAccounts();
                frmfindAccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccounts_ExecuteFindAccountEvent);
                frmfindAccounts.SearchText = e.KeyChar.ToString();
                frmfindAccounts.ShowDialog(this);
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
            var manager = new ProductionIssuanceHeadBLL();
            AccountNo = oelAccount.AccountNo;
            AccEditBox.Text = oelAccount.AccountName;            
        }
        private void btnLoadbyFilter_Click(object sender, EventArgs e)
        {
            var manager = new ProductionIssuanceHeadBLL();
            List<VoucherDetailEL> list = manager.GetGlovesGarmentsWorkerFinancialReport(cbxProductionType.SelectedIndex,AccountNo,Operations.IdCompany,GPType,Convert.ToDateTime(StartDate.Value.ToShortDateString()),Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            if(list.Count > 0)
            {
                grdWork.DataSource = list;   
                FillLoansDetail();
                FillAdvancesDetail();
                FillPaymentsDetail();
            }
        }
        private void FillLoansDetail()
        {
            var manager = new TransactionBLL();
            List<TransactionsEL> list = manager.GetDateWiseEmployeesLoans(Operations.IdCompany, AccountNo, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            grdLoanDetail.DataSource = list;
        }
        private void FillAdvancesDetail()
        {
            var manager = new TransactionBLL();
            List<TransactionsEL> list = manager.GetDateWiseEmployeesAdvances(Operations.IdCompany, AccountNo, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            grdAdvancesDetail.DataSource = list;
        }
        private void FillPaymentsDetail()
        {
            var manager = new TransactionBLL();
            List<TransactionsEL> list = manager.GetDateWiseEmployeesPaymentDetail(Operations.IdCompany, AccountNo, "GlovesGarments", Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            grdPaymentDetail.DataSource = list;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmprint = new frmPrintGlovesGarmentsWrokerReports();
            frmprint.AccountNo = AccountNo;
            frmprint.StartDate = Convert.ToDateTime(StartDate.Value.ToShortDateString());
            frmprint.EndDate = Convert.ToDateTime(EndDate.Value.ToShortDateString());
            frmprint.ProductionType = GPType;
            frmprint.OperationType = cbxProductionType.SelectedIndex;
            frmprint.WorkType = "GlovesGarments";
            frmprint.ShowDialog();
        }            
    }
}
