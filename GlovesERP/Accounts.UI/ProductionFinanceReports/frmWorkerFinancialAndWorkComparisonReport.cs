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
    public partial class frmWorkerFinancialAndWorkComparisonReport : MetroForm
    {
        #region Variables
        string AccountNo = string.Empty;
        string WorkType = string.Empty;
        frmFindAccounts frmAccount;
        #endregion
        public frmWorkerFinancialAndWorkComparisonReport()
        {
            InitializeComponent();
        }

        private void frmWorkerFinancialAndWorkComparisonReport_Load(object sender, EventArgs e)
        {
            grdWorkerFinance.AutoGenerateColumns = false;
            grdWorkerReport.AutoGenerateColumns = false;
            lblFinancialExpense.Visible = false;
            lblWorkerAmount.Visible = false;
            lblWorkerExpenses.Visible = false;
            lblWorkerTotalAmount.Visible = false;
        }    
        private void EmpEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmAccount = new frmFindAccounts();
            frmAccount.SearchText = "";
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            EmpEditBox.Text = oelAccount.AccountName;
            AccountNo = oelAccount.AccountNo;
        }

        private void btnGetComparison_Click(object sender, EventArgs e)
        {
            var manager = new PersonsBLL();
            List<PersonsEL> oelPerson = manager.GetPersonByAccount(Operations.IdCompany,AccountNo);
            if (oelPerson != null)
            {
                if (oelPerson[0].IdDepartment == Guid.Empty)
                {
                    MessageBox.Show("Person Does not have any department....");
                }
                else
                {
                    var DManager = new ProcessesBLL();
                    WorkType = DManager.GetProcessById(oelPerson[0].IdDepartment)[0].ProcessName;
                    LoadWorkerDetailReport();
                    LoadWorkerFinancialReport();
                }
            }
        }
        private void LoadWorkerDetailReport()
        {
            var Lotmanager = new TanneryLotDetailBLL();
            var ProcessManager = new TanneryProcessDetailsBLL();
            if (WorkType == "Drumming" || WorkType == "Buffing" || WorkType == "Cutting")
            {
                //List<TanneryLotDetailEL> list = Lotmanager.GetLotWorkersDetailReport(AccountNo, WorkType, Convert.ToDateTime(startDate.Value.ToShortDateString()), Convert.ToDateTime(endDate.Value.ToShortDateString()));
                List<TanneryLotDetailEL> list = Lotmanager.GetLotWorkerWiseComparisonReport(AccountNo, WorkType, Convert.ToDateTime(startDate.Value.ToShortDateString()), Convert.ToDateTime(endDate.Value.ToShortDateString()));
                if (list.Count > 0)
                {
                    grdWorkerReport.DataSource = list;
                    lblWorkerTotalAmount.Visible = true;
                    lblWorkerAmount.Visible = true;

                    lblWorkerAmount.Text = list.Sum(x => x.Amount).ToString();
                }
                else
                {
                    grdWorkerReport.DataSource = null;
                    lblWorkerTotalAmount.Visible = false;
                    lblWorkerAmount.Visible = false;
                }
            }
            else
            {
                List<TanneryProcessDetailsEL> list = ProcessManager.GetProcessesWorkersDetailReport(AccountNo, WorkType, Convert.ToDateTime(startDate.Value.ToShortDateString()), Convert.ToDateTime(endDate.Value.ToShortDateString()));
                if (list.Count > 0)
                {
                    grdWorkerReport.DataSource = list;
                    lblWorkerTotalAmount.Visible = true;
                    lblWorkerAmount.Visible = true;

                    lblWorkerAmount.Text = list.Sum(x => x.Amount).ToString();
                }
                else
                {
                    grdWorkerReport.DataSource = null;
                    lblWorkerTotalAmount.Visible = false;
                    lblWorkerAmount.Visible = false;
                }
            }
        }
        private void LoadWorkerFinancialReport()
        {
            var manager = new TransactionBLL();
            List<TransactionsEL> list = manager.GetDateWiseTransactionsByAccount(Operations.IdCompany, AccountNo, Convert.ToDateTime(startDate.Value), Convert.ToDateTime(endDate.Value));
            if (list.Count > 0)
            {
                grdWorkerFinance.DataSource = list;
                lblFinancialExpense.Visible = true;
                lblWorkerExpenses.Visible = true;

                lblWorkerExpenses.Text = list.Sum(x => x.Debit).ToString();
            }
            else
            {
                grdWorkerFinance.DataSource = null;
                lblFinancialExpense.Visible = false;
                lblWorkerExpenses.Visible = false;
            }
        }
    }
}
