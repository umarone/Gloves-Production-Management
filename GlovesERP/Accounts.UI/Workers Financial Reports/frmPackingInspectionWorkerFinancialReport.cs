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
    public partial class frmPackingInspectionWorkerFinancialReport : MetroForm
    {
        #region Variables
        frmFindAccounts frmfindAccount;
        string EventFiringName;
        public int ProductionType { get; set; }
        public int WorkType { get; set; }
        public string SummaryType { get; set; }
        string AccountNo;
        DataTable dt;
        #endregion
        #region Form Events
        public frmPackingInspectionWorkerFinancialReport()
        {
            InitializeComponent();
        }
        private void frmPackingInspection_Load(object sender, EventArgs e)
        {
            ProductionTab.SelectedIndex = 0;
            this.grdInspection.AutoGenerateColumns = false;
            this.grdPacking.AutoGenerateColumns = false;
            this.grdLoanDetail.AutoGenerateColumns = false;
            this.grdAdvancesDetail.AutoGenerateColumns = false;
            this.grdPaymentDetail.AutoGenerateColumns = false;
            ShowHideTabs();
            LabelForm();

        }
        private void ShowHideTabs()
        {
            if (WorkType == 1)
            {
                ProductionTab.TabPages.Remove(mTabPacking);
            }
            else if (WorkType == 2)
            {
                ProductionTab.TabPages.Remove(mTabInspection);
            }
        }
        private void LabelForm()
        {
            if (ProductionType == 1 && WorkType == 1)
            {
                this.Text = "Gloves Inspection Performance Report";
            }
            else if (ProductionType == 1 && WorkType == 2)
            {
                this.Text = "Gloves Packing Performance Report";
            }
            else if (ProductionType == 2 && WorkType == 1)
            {
                this.Text = "Garments Inspection Performance Report";
            }
            else if (ProductionType == 2 && WorkType == 2)
            {
                this.Text = "Garments Packing Performance Report";
            }

            if (ProductionType == 1 && SummaryType == "Stitcher")
            {
                this.Text = "Stitcher Stock Inspection Performance Report";
                lblAccountName.Text = "Select Stitcher";
            }
            else if (ProductionType == 2 && SummaryType == "Stitcher")
            {
                this.Text = "Stitcher Stock Inspection Performance Report";
                lblAccountName.Text = "Select Stitcher";
            }
        }
        #endregion
        private void btnLoadbyFilter_Click(object sender, EventArgs e)
        {
            var manager = new ProductionProcessDetailBLL();
            List<ProductionProcessDetailEL> listDetail = null;
            if (lblAccountName.Text == "Select Inpector :")
            {
                listDetail = manager.GetWorkerInspectionPackingReportByDate(Operations.IdCompany, AccountNo,Convert.ToDateTime(StartDate.Value.ToShortDateString()),Convert.ToDateTime(EndDate.Value.ToShortDateString()), WorkType, ProductionType);
            }
            else if (lblAccountName.Text == "Select Stitcher")
            {
                listDetail = manager.GetStitcherWorkerInspectionReportByDate(Operations.IdCompany, AccountNo, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()), WorkType, ProductionType);
            }
            if (listDetail != null && listDetail.Count > 0)
            {
                PopulateWorkerSummary(listDetail);
                //FillLoansDetail();
                //FillAdvancesDetail();
                //FillPaymentsDetail();
            }
        }
        private void PopulateWorkerSummary(List<ProductionProcessDetailEL> listDetail)
        {
            dt = new DataTable();
            dt.Columns.Clear();
            dt.Rows.Clear();
            dt.Clear();
            if (ProductionType == 1 && WorkType == 1)
            {
                dt.Columns.Add("VDate");
                dt.Columns.Add("ItemName");
                dt.Columns.Add("BrandName");
                dt.Columns.Add("PackingSize");
                dt.Columns.Add("ItemSize");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("ReadyUnits");
                dt.Columns.Add("Rejection");
                dt.Columns.Add("BQuantity");
                dt.Columns.Add("RepairQuantity");
                dt.Columns.Add("Rate");
                dt.Columns.Add("Amount");

                for (int i = 0; i < listDetail.Count; i++)
                {
                    // Add rows.
                    DataRow dr = dt.NewRow();
                    dr[0] = listDetail[i].VDate;
                    dr[1] = listDetail[i].ItemName;
                    dr[2] = listDetail[i].BrandName;
                    dr[3] = listDetail[i].PackingSize;
                    dr[4] = listDetail[i].ItemSize;
                    dr[5] = listDetail[i].Quantity;
                    dr[6] = listDetail[i].ReadyUnits;
                    dr[7] = listDetail[i].Rejection;
                    dr[8] = listDetail[i].BQuantity;
                    dr[9] = listDetail[i].RepairQuantity;
                    if (lblAccountName.Text == "Select Inpector :")
                    {
                        dr[10] = listDetail[i].Rate;
                        dr[11] = listDetail[i].Amount;
                    }
                    else
                    {
                        dr[10] = listDetail[i].InspectorRate;
                        dr[11] = listDetail[i].InspectorAmount;
                    }
                    dt.Rows.Add(dr);
                }
                if (dt.Rows.Count > 0)
                {
                    grdInspection.DataSource = dt;
                    if (lblAccountName.Text == "Select Inpector :")
                    {
                        txtInspectionTotalAmount.Text = listDetail[0].TotalAmount.ToString("0.00");
                    }
                    else
                    {
                        txtInspectionTotalAmount.Text = listDetail.Sum(x => x.InspectorAmount).ToString("0.00"); //listDetail[0].InspectorAmount.ToString("0.00");
                    }
                }
                else
                {
                    grdInspection.DataSource = null;
                }
            }
            else if (ProductionType == 1 && WorkType == 2)
            {
                dt.Columns.Add("VDate");
                dt.Columns.Add("ItemName");
                dt.Columns.Add("BrandName");
                dt.Columns.Add("ItemSize");
                dt.Columns.Add("PStyle");
                dt.Columns.Add("PackingSize");
                dt.Columns.Add("ReadyUnits");
                dt.Columns.Add("Rate");
                dt.Columns.Add("Amount");

                for (int i = 0; i < listDetail.Count; i++)
                {
                    // Add rows.
                    DataRow dr = dt.NewRow();
                    dr[0] = listDetail[i].VDate;
                    dr[1] = listDetail[i].ItemName;
                    dr[2] = listDetail[i].BrandName;
                    dr[4] = listDetail[i].ItemSize;
                    dr[5] = listDetail[i].PStyle;
                    dr[6] = listDetail[i].PackingSize;
                    dr[6] = listDetail[i].ReadyUnits;
                    dr[7] = listDetail[i].Rate;
                    dr[8] = listDetail[i].Amount;

                    dt.Rows.Add(dr);
                }
                if (dt.Rows.Count > 0)
                {
                    grdPacking.DataSource = dt;
                    txtTotalPackingAmount.Text = listDetail[0].TotalAmount.ToString("0.00");
                }
                else
                {
                    grdPacking.DataSource = null;
                }
            }
        }       
        private void AccEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindAccount = new frmFindAccounts();
            frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
            frmfindAccount.ShowDialog();
        }
        void frmfindAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            AccountNo = oelAccount.AccountNo;
            AccEditBox.Text = oelAccount.AccountName;
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
            List<TransactionsEL> list = null;
            if (WorkType == 1 && SummaryType == "")
            {
                list = manager.GetDateWiseEmployeesPaymentDetail(Operations.IdCompany, AccountNo, "Inspection", Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            }
            else if (WorkType == 2 && SummaryType == "")
            {
                list = manager.GetDateWiseEmployeesPaymentDetail(Operations.IdCompany, AccountNo, "Packing", Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            }
            else if (WorkType == 1 && SummaryType != "")
            {
                list = manager.GetDateWiseEmployeesPaymentDetail(Operations.IdCompany, AccountNo, "Stitching", Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            }
            grdPaymentDetail.DataSource = list;
        }
        frmPrintInspectionPackingWorkerReports frmPrint;
        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            if (ProductionType == 1 && WorkType == 1 && SummaryType == "")
            {
                frmPrint = new frmPrintInspectionPackingWorkerReports();
                frmPrint.AccountNo = AccountNo;
                frmPrint.AccountName = AccEditBox.Text;
                frmPrint.ReportType = "Inspection";
                frmPrint.ProductionType = ProductionType;
                frmPrint.WorkTypeInt = 1;
                frmPrint.WorkType = "Inspection";
                frmPrint.StartDate = Convert.ToDateTime(StartDate.Value.ToShortDateString());
                frmPrint.EndDate = Convert.ToDateTime(EndDate.Value.ToShortDateString());
                frmPrint.Show();
            }
            else if (ProductionType == 1 && WorkType == 2 && SummaryType == "")
            {
                frmPrint = new frmPrintInspectionPackingWorkerReports();
                frmPrint.AccountNo = AccountNo;
                frmPrint.AccountName = AccEditBox.Text;
                frmPrint.ReportType = "Packing";
                frmPrint.ProductionType = ProductionType;
                frmPrint.WorkTypeInt = 2;
                frmPrint.WorkType = "Packing";
                frmPrint.StartDate = Convert.ToDateTime(StartDate.Value.ToShortDateString());
                frmPrint.EndDate = Convert.ToDateTime(EndDate.Value.ToShortDateString());
                frmPrint.Show();
            }
            else if (ProductionType == 1 && WorkType == 1 && SummaryType != "")
            {
                frmPrint = new frmPrintInspectionPackingWorkerReports();
                frmPrint.AccountNo = AccountNo;
                frmPrint.AccountName = AccEditBox.Text;
                frmPrint.ReportType = "Stitching";
                frmPrint.ProductionType = ProductionType;
                frmPrint.WorkTypeInt = 1;
                frmPrint.WorkType = "Stitching";
                frmPrint.StartDate = Convert.ToDateTime(StartDate.Value.ToShortDateString());
                frmPrint.EndDate = Convert.ToDateTime(EndDate.Value.ToShortDateString());
                frmPrint.Show();
            }
        }            
    }
}

