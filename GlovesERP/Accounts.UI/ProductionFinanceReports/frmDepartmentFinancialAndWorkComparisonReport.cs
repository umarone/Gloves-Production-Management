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
    public partial class frmDepartmentFinancialAndWorkComparisonReport : MetroForm
    {
        #region Variables
        string AccountNo = string.Empty;
        string WorkType = string.Empty;
        public int HeadDepartment { get; set; }
        #endregion
        public frmDepartmentFinancialAndWorkComparisonReport()
        {
            InitializeComponent();
        }
        private void frmDepartmentFinancialAndWorkComparisonReport_Load(object sender, EventArgs e)
        {
            grdWorkerFinance.AutoGenerateColumns = false;
            grdWorkerReport.AutoGenerateColumns = false;
            lblFinancialExpense.Visible = false;
            lblWorkerAmount.Visible = false;
            lblWorkerExpenses.Visible = false;
            lblWorkerTotalAmount.Visible = false;
            LoadAllDepartments();
        }
        private void LoadAllDepartments()
        {
            var manager = new ProcessesBLL();
            List<ProcessesEL> list = manager.GetAllDepartmentsByType(HeadDepartment); //manager.GetAllProcesses();
            if (list.Count > 0)
            {
                list.Insert(0, new ProcessesEL() { IdProcess = Guid.Empty, ProcessName = "Select Department" });
                cbxDepartments.DataSource = list;
                cbxDepartments.DisplayMember = "ProcessName";
                cbxDepartments.ValueMember = "IdProcess";
            }
        }
        private void btnGetComparison_Click(object sender, EventArgs e)
        {
            WorkType = cbxDepartments.Text;
            LoadWorkerDetailReport();
            LoadWorkerFinancialReport();
        }
        private void LoadWorkerDetailReport()
        {
            var Lotmanager = new TanneryLotDetailBLL();
            var ProcessManager = new TanneryProcessDetailsBLL();
            if (WorkType == "Drumming" || WorkType == "Buffing" || WorkType == "Cutting")
            {
                List<TanneryLotDetailEL> list = Lotmanager.GetDateWiseDepartmentLotsWork(Operations.IdCompany, Validation.GetSafeGuid(cbxDepartments.SelectedValue), Convert.ToDateTime(startDate.Value.ToShortDateString()), Convert.ToDateTime(endDate.Value.ToShortDateString()));
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
                List<TanneryProcessDetailsEL> list = ProcessManager.GetDateWiseDepartmentProcessWork(Operations.IdCompany, Validation.GetSafeGuid(cbxDepartments.SelectedValue), Convert.ToDateTime(startDate.Value.ToShortDateString()), Convert.ToDateTime(endDate.Value.ToShortDateString()));
                if (list.Count > 0)
                {
                    grdWorkerReport.DataSource = list;
                    lblWorkerTotalAmount.Visible = true;
                    lblWorkerTotalAmount.Visible = true;

                    lblWorkerAmount.Text = list.Sum(x => x.Amount).ToString();
                }
                else
                {
                    grdWorkerReport.DataSource = null;
                    lblWorkerTotalAmount.Visible = false;
                    lblWorkerTotalAmount.Visible = false;
                }
            }
        }
        private void LoadWorkerFinancialReport()
        {
            var manager = new TransactionBLL();
            List<TransactionsEL> list = manager.GetDateWiseDepartmentTransactions(Operations.IdCompany, Validation.GetSafeGuid(cbxDepartments.SelectedValue), Convert.ToDateTime(startDate.Value), Convert.ToDateTime(endDate.Value));
            if (list.Count > 0)
            {
                grdWorkerFinance.DataSource = list;
                lblFinancialExpense.Visible = true;
                lblWorkerExpenses.Visible = true;

                lblWorkerExpenses.Text = (list.Sum(x => x.Debit) - list.Sum(x => x.Credit)).ToString(); 
            }
            else
            {
                grdWorkerFinance.DataSource = null;
                lblFinancialExpense.Visible = false;
                lblWorkerExpenses.Visible = false;
            }
        }
        private void cbxDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdWorkerFinance.DataSource = null;
            grdWorkerReport.DataSource = null;
            if (cbxDepartments.Text == "Trimming")
            {
                grdWorkerReport.Columns["colGalma"].Visible = true;
                grdWorkerReport.Columns["colPuttha"].Visible = true;

                grdWorkerReport.Columns["colSPuttha"].Visible = false;
                grdWorkerReport.Columns["colSGalma"].Visible = false;
                grdWorkerReport.Columns["colDGalma"].Visible = false;
                grdWorkerReport.Columns["colLotNo"].Visible = false;
                grdWorkerReport.Columns["colQuality"].Visible = false;
                grdWorkerReport.Columns["colCuttingQuantity"].Visible = false;
                
            }
            else if (cbxDepartments.Text == "Splitting")
            {
                grdWorkerReport.Columns["colGalma"].Visible = true;
                grdWorkerReport.Columns["colPuttha"].Visible = true;

                grdWorkerReport.Columns["colSPuttha"].Visible = false;
                grdWorkerReport.Columns["colSGalma"].Visible = false;
                grdWorkerReport.Columns["colDGalma"].Visible = false;
                grdWorkerReport.Columns["colLotNo"].Visible = false;
                grdWorkerReport.Columns["colQuality"].Visible = false;
                grdWorkerReport.Columns["colCuttingQuantity"].Visible = false;
            }
            else if (cbxDepartments.Text == "Retrimming")
            {
                grdWorkerReport.Columns["colGalma"].Visible = true;
                grdWorkerReport.Columns["colPuttha"].Visible = true;

                grdWorkerReport.Columns["colSPuttha"].Visible = false;
                grdWorkerReport.Columns["colSGalma"].Visible = false;
                grdWorkerReport.Columns["colDGalma"].Visible = false;
                grdWorkerReport.Columns["colLotNo"].Visible = false;
                grdWorkerReport.Columns["colQuality"].Visible = false;
                grdWorkerReport.Columns["colCuttingQuantity"].Visible = false;
            }
            else if (cbxDepartments.Text == "Shaving")
            {
                grdWorkerReport.Columns["colGalma"].Visible = true;
                grdWorkerReport.Columns["colPuttha"].Visible = true;
                grdWorkerReport.Columns["colSPuttha"].Visible = true;
                grdWorkerReport.Columns["colSGalma"].Visible = true;
                grdWorkerReport.Columns["colDGalma"].Visible = true;
                grdWorkerReport.Columns["colLotNo"].Visible = false;
                grdWorkerReport.Columns["colQuality"].Visible = false;
                grdWorkerReport.Columns["colCuttingQuantity"].Visible = false;
            }
            else if (cbxDepartments.Text == "Drumming")
            {
                grdWorkerReport.Columns["colGalma"].Visible = true;
                grdWorkerReport.Columns["colPuttha"].Visible = true;
                grdWorkerReport.Columns["colSPuttha"].Visible = true;
                grdWorkerReport.Columns["colSGalma"].Visible = true;

                grdWorkerReport.Columns["colDGalma"].Visible = false;
                grdWorkerReport.Columns["colLotNo"].Visible = true;
                grdWorkerReport.Columns["colQuality"].Visible = true;
                grdWorkerReport.Columns["colCuttingQuantity"].Visible = false;
            }
            else if (cbxDepartments.Text == "Buffing")
            {
                grdWorkerReport.Columns["colGalma"].Visible = true;
                grdWorkerReport.Columns["colPuttha"].Visible = true;
                grdWorkerReport.Columns["colSPuttha"].Visible = true;
                grdWorkerReport.Columns["colSGalma"].Visible = true;
                grdWorkerReport.Columns["colDGalma"].Visible = false;

                grdWorkerReport.Columns["colLotNo"].Visible = true;
                grdWorkerReport.Columns["colQuality"].Visible = true;
                grdWorkerReport.Columns["colCuttingQuantity"].Visible = false;
            }
            else if (cbxDepartments.Text == "Cutting")
            {
                grdWorkerReport.Columns["colGalma"].Visible = false;
                grdWorkerReport.Columns["colPuttha"].Visible = false;
                grdWorkerReport.Columns["colSPuttha"].Visible = false;
                grdWorkerReport.Columns["colSGalma"].Visible = false;

                grdWorkerReport.Columns["colLotNo"].Visible = true;
                grdWorkerReport.Columns["colQuality"].Visible = true;
                grdWorkerReport.Columns["colCuttingQuantity"].Visible = true;

                grdWorkerReport.Columns["colDGalma"].Visible = false;
            }
        }
    }
}
