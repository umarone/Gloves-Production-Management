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
    public partial class frmTanneryWorkerDetailReport : MetroForm
    {
        #region Variables
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string WorkType{ get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        frmPrintWorkerReports frmprintworkerreports;
        #endregion
        public frmTanneryWorkerDetailReport()
        {
            InitializeComponent();
        }
        private void frmTanneryWorkerDetailReport_Load(object sender, EventArgs e)
        {
            this.grdWorkerReport.AutoGenerateColumns = false;
            this.grdLoanDetail.AutoGenerateColumns = false;
            this.grdAdvancesDetail.AutoGenerateColumns = false;
            this.grdPaymentDetail.AutoGenerateColumns = false;
            this.Text = AccountName + " " + "Work Report" +"( From " + startDate.ToShortDateString() + " To " + endDate.ToShortDateString() + " )";
            LoadWorkerDetailReport();
            ChangeColumnsDataProperty();
            ShowHideColumns();
            FillLoansDetail();
            FillAdvancesDetail();
            FillPaymentsDetail();
        }
        private void ShowHideColumns()
        { 
            if(WorkType == "Cutting")
            {
                grdWorkerReport.Columns["colGalma"].Visible = false;
                grdWorkerReport.Columns["colPuttha"].Visible = false;
                grdWorkerReport.Columns["colDGalma"].Visible = false;
                grdWorkerReport.Columns["colDPuttha"].Visible = false;
                grdWorkerReport.Columns["colSGalma"].Visible = false;
                grdWorkerReport.Columns["colSPuttha"].Visible = false;
            }
            else if (WorkType == "Drumming")
            {
                grdWorkerReport.Columns["colCuttingQuantity"].Visible = false;
                grdWorkerReport.Columns["colDGalma"].Visible = false;
                grdWorkerReport.Columns["colDPuttha"].Visible = false;
            }
            else if (WorkType == "Buffing")
            {
                grdWorkerReport.Columns["colCuttingQuantity"].Visible = false;
                grdWorkerReport.Columns["colDPuttha"].Visible = false;
            }
            else if (WorkType == "Trimming")
            {
                grdWorkerReport.Columns["colCuttingQuantity"].Visible = false;
                grdWorkerReport.Columns["colDGalma"].Visible = false;
                grdWorkerReport.Columns["colQuality"].Visible = false;
                grdWorkerReport.Columns["colLotNo"].Visible = false;
                grdWorkerReport.Columns["colDPuttha"].Visible = false;
                grdWorkerReport.Columns["colSGalma"].Visible = false;
                grdWorkerReport.Columns["colSPuttha"].Visible = false;
            }
            else if (WorkType == "Splitting")
            {
                grdWorkerReport.Columns["colCuttingQuantity"].Visible = false;
                grdWorkerReport.Columns["colDGalma"].Visible = false;
                grdWorkerReport.Columns["colQuality"].Visible = false;
                grdWorkerReport.Columns["colLotNo"].Visible = false;
                grdWorkerReport.Columns["colDPuttha"].Visible = false;
            }
            else if (WorkType == "ReTrimming")
            {
                grdWorkerReport.Columns["colCuttingQuantity"].Visible = false;
                grdWorkerReport.Columns["colDGalma"].Visible = false;
                grdWorkerReport.Columns["colQuality"].Visible = false;
                grdWorkerReport.Columns["colLotNo"].Visible = false;
                grdWorkerReport.Columns["colDPuttha"].Visible = false;
            }
            else if (WorkType == "Shaving")
            {
                grdWorkerReport.Columns["colLotNo"].Visible = false;
                grdWorkerReport.Columns["colCuttingQuantity"].Visible = false;
            }
        }
        private void ChangeColumnsDataProperty()
        {
            if (WorkType == "Cutting")
            {
                grdWorkerReport.Columns["colQuality"].DataPropertyName = "ItemName";
            }
            else if (WorkType == "Buffing")
            {
                grdWorkerReport.Columns["colGalma"].DataPropertyName = "Pieces";
                grdWorkerReport.Columns["colPuttha"].DataPropertyName = "PPieces";
                grdWorkerReport.Columns["colSGalma"].DataPropertyName = "SGalma";
                grdWorkerReport.Columns["colSPuttha"].DataPropertyName = "SPuttha";
                grdWorkerReport.Columns["colDGalma"].DataPropertyName = "DGalma";
            }
            else if (WorkType == "Trimming")
            {
                grdWorkerReport.Columns["colGalma"].DataPropertyName = "Galma";
                grdWorkerReport.Columns["colPuttha"].DataPropertyName = "Puttha";
            }
            else if (WorkType == "Splitting")
            {
                grdWorkerReport.Columns["colSGalma"].DataPropertyName = "GalmaPieces";
                grdWorkerReport.Columns["colSPuttha"].DataPropertyName = "PutthaPieces";
            }
            else if (WorkType == "ReTrimming")
            {
                grdWorkerReport.Columns["colSGalma"].DataPropertyName = "Galma";
                grdWorkerReport.Columns["colSPuttha"].DataPropertyName = "Puttha";
            }
            else if (WorkType == "Shaving")
            {
                grdWorkerReport.Columns["colQuality"].DataPropertyName = "Quality";
                grdWorkerReport.Columns["colGalma"].DataPropertyName = "Galma";
                grdWorkerReport.Columns["colPuttha"].DataPropertyName = "Puttha";
                grdWorkerReport.Columns["colDGalma"].DataPropertyName = "Puttha";
                grdWorkerReport.Columns["colDPuttha"].DataPropertyName = "Puttha";
            }
        }
        private void LoadWorkerDetailReport()
        {
            var Lotmanager = new TanneryLotDetailBLL();
            var ProcessManager = new TanneryProcessDetailsBLL();
            if (WorkType == "Drumming" || WorkType == "Buffing" || WorkType == "Cutting")
            {
                List<TanneryLotDetailEL> list = Lotmanager.GetLotWorkersDetailReport(AccountNo, WorkType, startDate, endDate);
                if (list.Count > 0)
                {
                    grdWorkerReport.DataSource = list;
                }
                else
                {
                    grdWorkerReport.DataSource = null;
                }
            }
            else
            {
                List<TanneryProcessDetailsEL> list = ProcessManager.GetProcessesWorkersDetailReport(AccountNo, WorkType, startDate, endDate);
                if (list.Count > 0)
                {
                    grdWorkerReport.DataSource = list;
                }
                else
                {
                    grdWorkerReport.DataSource = null;
                }
            }
        }
        private void FillLoansDetail()
        {
            var manager = new TransactionBLL();
            List<TransactionsEL> list = manager.GetDateWiseEmployeesLoans(Operations.IdCompany, AccountNo, startDate, endDate);            
            grdLoanDetail.DataSource = list;
        }
        private void FillAdvancesDetail()
        {
            var manager = new TransactionBLL();
            List<TransactionsEL> list = manager.GetDateWiseEmployeesAdvances(Operations.IdCompany, AccountNo, startDate, endDate);
            grdAdvancesDetail.DataSource = list;
        }
        private void FillPaymentsDetail()
        {
            var manager = new TransactionBLL();
            List<TransactionsEL> list = manager.GetDateWiseEmployeesPaymentDetail(Operations.IdCompany, AccountNo, WorkType, startDate, endDate);
            grdPaymentDetail.DataSource = list;
        }
        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            frmprintworkerreports = new frmPrintWorkerReports();
            frmprintworkerreports.AccountNo = AccountNo;
            frmprintworkerreports.AccountName = AccountName;
            frmprintworkerreports.WorkType = WorkType;
            frmprintworkerreports.startDate = startDate;
            frmprintworkerreports.endDate = endDate;
            frmprintworkerreports.ShowDialog();
        }
    }
}
