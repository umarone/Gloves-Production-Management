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
using SpreadsheetLight;
using System.Diagnostics;

namespace Accounts.UI
{
    public partial class frmGlovesWorkerWeeklyFinancialPerformanceReport : MetroForm
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
        public frmGlovesWorkerWeeklyFinancialPerformanceReport()
        {
            InitializeComponent();
        }
        private void frmGlovesWorkerWeeklyFinancialPerformanceReport_Load(object sender, EventArgs e)
        {
            this.grdWorkerBill.AutoGenerateColumns = false;            
        }
        #endregion
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new ProductionProcessDetailBLL();
            List<ProductionProcessDetailEL> listDetail = manager.GetWorkerWeeklyFinancialPerformanceBill(ProductionType, AccountNo);
            if (listDetail.Count > 0)
            {
                dt = DataOperations.ToDataTable(listDetail);
                grdWorkerBill.DataSource = listDetail;
                lblTotalAmount.Text = "Total Amount Is :" + listDetail.Sum(x=> x.Amount).ToString();
                lblTotalAmount.Visible = true;
            }
            else
            {
                lblTotalAmount.Text = "";
                lblTotalAmount.Visible = false;
                grdWorkerBill.DataSource = null;
            }
        }
        private void btnLoadbyFilter_Click(object sender, EventArgs e)
        {
            var manager = new ProductionProcessDetailBLL();
            List<ProductionProcessDetailEL> listDetail = manager.GetWorkerWeeklyFinancialPerformanceBillByDate(ProductionType, AccountNo, StartDate.Value, EndDate.Value);
            if (listDetail.Count > 0)
            {
                dt = DataOperations.ToDataTable(listDetail);
                grdWorkerBill.DataSource = listDetail;
                lblTotalAmount.Text = "Total Amount Is :" + listDetail.Sum(x => x.Amount).ToString();
                lblTotalAmount.Visible = true;
            }
            else
            {
                grdWorkerBill.DataSource = null;
                lblTotalAmount.Text = "Total Amount Is :" + listDetail.Sum(x => x.Amount).ToString();
                lblTotalAmount.Visible = true;
            }
            
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (grdWorkerBill.Rows.Count > 0)
            {
                decimal total = 0;
                for (int i = 0; i < grdWorkerBill.Rows.Count; i++)
                {
                    total += Validation.GetSafeDecimal(grdWorkerBill.Rows[i].Cells["colInspectionAmount"].Value);
                }
                lblTotalAmount.Text = "Total Amount Is :" + total;
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (grdWorkerBill.Rows.Count > 0)
            {
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in grdWorkerBill.Columns)
                {
                    if (column.Visible)
                    {
                        dt.Columns.Add(column.HeaderText);
                    }
                }

                //Add Header Rows....
                dt.Rows.Add();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Rows[0][i] = dt.Columns[i].ColumnName; //"Account Name"; 
                }

                // Add Empty Row....
                dt.Rows.Add();
                for (int i = 0; i < grdWorkerBill.Columns.Count; i++)
                {
                    if (i != dt.Columns.Count)
                    {
                        dt.Rows[1][i] = "";
                    }
                    else
                    {
                        break;
                    }
                }

                foreach (DataGridViewRow row in grdWorkerBill.Rows)
                {
                    dt.Rows.Add();
                    int colindex = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //if (cell.Value != null)
                        //{
                        if (cell.Visible)
                        {
                            //dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                            dt.Rows[dt.Rows.Count - 1][colindex] = cell.Value ?? 0.ToString();
                            colindex++;
                        }
                        //}
                    }
                }

                SLDocument slExcelExport = new SLDocument();


                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    slExcelExport.SetColumnWidth(i, 20);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        slExcelExport.SetCellValue(j + 1, i + 1, dt.Rows[j].ItemArray[i].ToString());
                    }
                }
                slExcelExport.Save();

                Process.Start("Book1.xlsx");
            }
        }
        private void chkApplyDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApplyDateFilter.Checked)
            {
                pnlDate.Enabled = true;
            }
            else
            {
                pnlDate.Enabled = false;
            }
        }
        private void chkInspectionSearchByArticle_CheckedChanged(object sender, EventArgs e)
        {
            chkInspectionSearchByBrand.Checked = false;
        }
        private void chkInspectionSearchByBrand_CheckedChanged(object sender, EventArgs e)
        {
            chkInspectionSearchByArticle.Checked = false;
        }
        private void txtInspectionSearch_TextChanged(object sender, EventArgs e)
        {
            if (chkInspectionSearchByArticle.Checked)
            {
                DataView DV = new DataView(dt);
                DV.RowFilter = string.Format("ItemName LIKE '%{0}%'", txtInspectionSearch.Text);
                grdWorkerBill.DataSource = DV;
            }
            else if (chkInspectionSearchByBrand.Checked)
            {
                DataView DV = new DataView(dt);
                DV.RowFilter = string.Format("BrandName LIKE '%{0}%'", txtInspectionSearch.Text);
                grdWorkerBill.DataSource = DV;
            }
        }
        private void AccEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
            {
                frmfindAccount = new frmFindAccounts();
                frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                frmfindAccount.SearchText = e.KeyChar.ToString();
                frmfindAccount.ShowDialog(this);
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                if (AccEditBox.Text != string.Empty)
                {
                    btnLoad.Focus();
                }
            }
            else if (e.KeyChar == (char)Keys.Back)
            {

            }
            else
                e.Handled = true;
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
    }
}

