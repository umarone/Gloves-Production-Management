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
    public partial class frmPackingInspectionReport : MetroForm
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
        public frmPackingInspectionReport()
        {
            InitializeComponent();
        }
        private void frmPackingInspection_Load(object sender, EventArgs e)
        {
            ProductionTab.SelectedIndex = 0;
            this.grdInspection.AutoGenerateColumns = false;
            this.grdPacking.AutoGenerateColumns = false;
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
        }
        #endregion
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new ProductionProcessDetailBLL();
            List<ProductionProcessDetailEL> listDetail = null;
            if (lblAccountName.Text == "Select Inpector :")
            {
                listDetail = manager.GetWorkerInspectionPackingReport(Operations.IdCompany, AccountNo, WorkType, ProductionType);
            }
            else if (lblAccountName.Text == "Select Stitcher")
            {
                listDetail = manager.GetStitcherWorkerInspectionReport(Operations.IdCompany, AccountNo, WorkType, ProductionType, 2);
            }
            if (listDetail != null && listDetail.Count > 0)
            {
                PopulateWorkerSummary(listDetail);
            }
            else
            {
                if (ProductionType == 1)
                {
                    grdInspection.DataSource = null;
                }
                else
                {
                    grdPacking.DataSource = null;
                }
            }
        }
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
            }
            else
            {
                if (ProductionType == 1)
                {
                    grdInspection.DataSource = null;
                }
                else
                {
                    grdPacking.DataSource = null;
                }
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
                    if (lblAccountName.Text == "Select Stitcher")
                    {
                        dr[10] = listDetail[i].InspectorRate;
                        dr[11] = listDetail[i].InspectorAmount;
                    }
                    else
                    {
                        dr[10] = listDetail[i].Rate;
                        dr[11] = listDetail[i].Amount;
                    }
                    dt.Rows.Add(dr);
                }
                if (dt.Rows.Count > 0)
                {
                    grdInspection.DataSource = dt;
                    if (lblAccountName.Text == "Select Stitcher")
                    {
                        txtInspectionTotalAmount.Text = Validation.GetSafeString(listDetail.Sum(x => x.InspectorAmount)); ///listDetail[0].TotalAmount.ToString("0.00");
                    }
                    else 
                    {
                        txtInspectionTotalAmount.Text = Validation.GetSafeString(listDetail.Sum(x => x.Amount)); //listDetail.Sum(x => x.InspectorAmount).ToString("0.00"); //listDetail[0].InspectorAmount.ToString("0.00");
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
                dt.Columns.Add("ItemSizes");
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
                    dr[3] = listDetail[i].ItemSize;
                    dr[4] = listDetail[i].ItemSize;
                    dr[5] = listDetail[i].PStyle;
                    dr[6] = listDetail[i].PackingSize;
                    dr[7] = listDetail[i].ReadyUnits;
                    dr[8] = listDetail[i].Rate;
                    dr[9] = listDetail[i].Amount;

                    dt.Rows.Add(dr);
                }
                if (dt.Rows.Count > 0)
                {
                    grdPacking.DataSource = dt;
                    txtTotalPackingAmount.Text = Validation.GetSafeString(listDetail.Sum(x => x.Amount));//listDetail[0].Amount.ToString("0.00");
                }
                else
                {
                    grdPacking.DataSource = null;
                }
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
        private void chkPackingSearchByArticle_CheckedChanged(object sender, EventArgs e)
        {
            chkPackingSearchByBrand.Checked = false;
        }
        private void chkPackingSearchByBrand_CheckedChanged(object sender, EventArgs e)
        {
            chkPackingSearchByArticle.Checked = false;
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
                grdInspection.DataSource = DV;
            }
            else if (chkInspectionSearchByBrand.Checked)
            {
                DataView DV = new DataView(dt);
                DV.RowFilter = string.Format("BrandName LIKE '%{0}%'", txtInspectionSearch.Text);
                grdInspection.DataSource = DV;
            }
        }
        private void txtPackingSearch_TextChanged(object sender, EventArgs e)
        {
            if (chkPackingSearchByArticle.Checked)
            {
                DataView DV = new DataView(dt);
                DV.RowFilter = string.Format("ItemName LIKE '%{0}%'", txtPackingSearch.Text);
                grdInspection.DataSource = DV;
            }
            else if (chkPackingSearchByBrand.Checked)
            {
                DataView DV = new DataView(dt);
                DV.RowFilter = string.Format("BrandName LIKE '%{0}%'", txtPackingSearch.Text);
                grdInspection.DataSource = DV;
            }
        }
        private void AccEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindAccount = new frmFindAccounts();
            frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
            frmfindAccount.ShowDialog();
        }
        private void AccEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (AccEditBox.Text == string.Empty)
                {
                    AccEditBox.Focus();
                }
                else
                    btnLoad.Focus();
            }
            else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                frmfindAccount = new frmFindAccounts();
                frmfindAccount.SearchText = e.KeyChar.ToString();
                frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                frmfindAccount.ShowDialog();
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == (char)Keys.Back)
            {

            }
            else
                e.Handled = true;
        }
        void frmfindAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            AccountNo = oelAccount.AccountNo;
            AccEditBox.Text = oelAccount.AccountName;
        }

        private void ProductionTab_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnCalculateInspectionTotal_Click(object sender, EventArgs e)
        {
            if (grdInspection.Rows.Count > 0)
            {
                decimal total = 0;
                for (int i = 0; i < grdInspection.Rows.Count; i++)
                {
                    total += Validation.GetSafeDecimal(grdInspection.Rows[i].Cells["colInspectionAmount"].Value);
                }
                txtInspectionTotalAmount.Text = total.ToString();
            }
        }

        private void btnCalculatePackingTotal_Click(object sender, EventArgs e)
        {
            if (grdPacking.Rows.Count > 0)
            {
                decimal total = 0;
                for (int i = 0; i < grdPacking.Rows.Count; i++)
                {
                    total += Validation.GetSafeDecimal(grdPacking.Rows[i].Cells["colPackingAmount"].Value);
                }
                txtTotalPackingAmount.Text = total.ToString();
            }
        }
    }
}

