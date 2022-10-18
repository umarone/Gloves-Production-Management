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
    public partial class frmGlovesProcessWiseReport : MetroForm
    {
        #region Variables
        frmFindAccounts frmfindAccount;
        string EventFiringName;
        string AccountNo;
        public int ProductionType { get; set; }
        DataTable dt;
        DataTable dtSummary; 
        string MaterialName = "";
        #endregion
        public frmGlovesProcessWiseReport()
        {
            InitializeComponent();
        }
        private void frmGlovesProcessWiseReport_Load(object sender, EventArgs e)
        {
            this.grdMaterialsInput.AutoGenerateColumns = false;
            this.grdOutPut.AutoGenerateColumns = false;
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
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new ProductionIssuanceHeadBLL();
            List<VoucherDetailEL> list = manager.GetProcessWiseWorkerReport(Operations.IdCompany, AccountNo, cbxProductionType.SelectedIndex, ProductionType, cbxProductionType.Text, MaterialName);
            if (list.Count > 0)
            {
                List<VoucherDetailEL> lstOut = list.FindAll(x => x.ProcessType == 1);
                if (lstOut != null && lstOut.Count > 0)
                {
                    PopulateWorkerSummary(lstOut, 2);
                    txtOutPutUnits.Text = lstOut.Sum(x => x.Qty).ToString();
                    txtOutPutAmount.Text = lstOut.Sum(x => x.Amount).ToString();
                }
                List<VoucherDetailEL> lstIn = list.FindAll(x => x.ProcessType == 2);
                if (lstIn != null && lstIn.Count > 0)
                {
                    PopulateWorkerSummary(lstIn, 1);
                    txtMaterialUnits.Text = lstIn.Sum(x => x.Qty).ToString();
                }
            }
            else
            {
                grdMaterialsInput.DataSource = null;
                grdOutPut.DataSource = null;
                txtOutPutUnits.Text = string.Empty;
                txtOutPutAmount.Text = string.Empty;
                txtMaterialUnits.Text = string.Empty;
            }
        }
        private void btnLoadbyFilter_Click(object sender, EventArgs e)
        {
            var manager = new ProductionIssuanceHeadBLL();
            List<VoucherDetailEL> list = manager.GetProcessWiseWorkerReportByDate(Operations.IdCompany, AccountNo,Convert.ToDateTime(StartDate.Value.ToShortDateString()),Convert.ToDateTime(EndDate.Value.ToShortDateString()), cbxProductionType.SelectedIndex, ProductionType, cbxProductionType.Text, MaterialName);
            if (list.Count > 0)
            {
                List<VoucherDetailEL> lstOut = list.FindAll(x => x.ProcessType == 1);
                if (lstOut != null && lstOut.Count > 0)
                {
                    PopulateWorkerSummary(lstOut, 2);
                    txtOutPutUnits.Text = lstOut.Sum(x => x.Qty).ToString();
                    txtOutPutAmount.Text = lstOut.Sum(x => x.Amount).ToString();
                }
                List<VoucherDetailEL> lstIn = list.FindAll(x => x.ProcessType == 2);
                if (lstIn != null && lstIn.Count > 0)
                {
                    PopulateWorkerSummary(lstIn, 1);
                    txtMaterialUnits.Text = lstIn.Sum(x => x.Qty).ToString();
                }
            }
            else
            {
                grdMaterialsInput.DataSource = null;
                grdOutPut.DataSource = null;
                txtOutPutUnits.Text = string.Empty;
                txtOutPutAmount.Text = string.Empty;
                txtMaterialUnits.Text = string.Empty;
            }
        }
        private void PopulateWorkerSummary(List<VoucherDetailEL> listDetail, int GridSeq)
        {
            dt = new DataTable();
            dt.Columns.Clear();
            dt.Rows.Clear();
            dt.Clear();
            if (ProductionType == 1 && GridSeq == 1)
            {
                dt.Columns.Add("WorkDate");
                dt.Columns.Add("ItemName");               
                dt.Columns.Add("Qty");

                for (int i = 0; i < listDetail.Count; i++)
                {
                    // Add rows.
                    DataRow dr = dt.NewRow();
                    dr[0] = listDetail[i].WorkDate;
                    dr[1] = listDetail[i].ItemName;
                    dr[2] = listDetail[i].Qty;                    
                    dt.Rows.Add(dr);
                }
                if (dt.Rows.Count > 0)
                {
                    grdMaterialsInput.DataSource = dt;
                }
                else
                {
                    grdMaterialsInput.DataSource = null;
                }
            }
            else if (ProductionType == 1 && GridSeq == 2)
            {
                dtSummary = new DataTable();
                dtSummary.Columns.Clear();
                dtSummary.Rows.Clear();
                dtSummary.Clear();

                dtSummary.Columns.Add("WorkDate");
                dtSummary.Columns.Add("ItemName");
                dtSummary.Columns.Add("BrandName");
                dtSummary.Columns.Add("Qty");
                dtSummary.Columns.Add("Amount");

                for (int i = 0; i < listDetail.Count; i++)
                {
                    // Add rows.
                    DataRow dr = dtSummary.NewRow();
                    dr[0] = listDetail[i].WorkDate;
                    dr[1] = listDetail[i].ItemName;
                    dr[2] = listDetail[i].BrandName;
                    dr[3] = listDetail[i].Qty;                    
                    dr[4] = listDetail[i].Amount;

                    dtSummary.Rows.Add(dr);
                }
                if (dtSummary.Rows.Count > 0)
                {
                    grdOutPut.DataSource = dtSummary;                    
                }
                else
                {
                    grdOutPut.DataSource = null;
                }
            }
        }
        private void txtSearchIssuedMaterials_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("ItemName LIKE '%{0}%'", txtSearchIssuedMaterials.Text);
            grdMaterialsInput.DataSource = DV;
        }
        private void txtSearchInputWork_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dtSummary);
            DV.RowFilter = string.Format("ItemName LIKE '%{0}%'", txtSearchInputWork.Text);
            grdOutPut.DataSource = DV;
        }
        private void chkApplyDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApplyDateFilter.Checked)
            {
                StartDate.Enabled = true;
                EndDate.Enabled = true;
                btnLoadbyFilter.Enabled = true;
                pnlDate.Enabled = true;
            }
            else
            {
                StartDate.Enabled = false;
                EndDate.Enabled = false;
                btnLoadbyFilter.Enabled = false;
                pnlDate.Enabled = false;
            }
        }
        private void cbxProductionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProductionType.Text == string.Empty)
            {
                MaterialName = "";
            }
            else if (cbxProductionType.Text == "Gloves Cutting")
            {
                MaterialName = "Gloves Cuff Cutting Material Usage";
            }
            else if (cbxProductionType.Text == "Gloves Talli Cutting")
            {
                MaterialName = "Gloves Talli Cutting Material Usage";
            }
            else if (cbxProductionType.Text == "Gloves OverLock")
            {
                MaterialName = "Gloves OverLock Material Usage";
            }
            else if (cbxProductionType.Text == "Gloves Magzi")
            {
                MaterialName = "Gloves Magzi Material Usage";
            }
            else if (cbxProductionType.Text == "Gloves Tape")
            {
                MaterialName = "Gloves Tap Material Usage";
            }
        }
        private void AccEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                frmfindAccount = new frmFindAccounts();
                frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                frmfindAccount.SearchText = e.KeyChar.ToString();
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

        private void btnMaterialTotal_Click(object sender, EventArgs e)
        {
            if (grdMaterialsInput.Rows.Count > 0)
            {
                decimal total = 0;
                for (int i = 0; i < grdMaterialsInput.Rows.Count; i++)
                {
                    total += Validation.GetSafeDecimal(grdMaterialsInput.Rows[i].Cells["colUnits"].Value);
                }
                txtMaterialUnits.Text = total.ToString();
            }
        }

        private void btnOutputTotal_Click(object sender, EventArgs e)
        {
            if (grdOutPut.Rows.Count > 0)
            {
                decimal unittotal = 0,amountTotal = 0;
                for (int i = 0; i < grdOutPut.Rows.Count; i++)
                {
                    unittotal += Validation.GetSafeDecimal(grdOutPut.Rows[i].Cells["colOutPutUnits"].Value);
                    amountTotal += Validation.GetSafeDecimal(grdOutPut.Rows[i].Cells["colOutPutTotalAmount"].Value);
                }
                txtOutPutUnits.Text = unittotal.ToString();
                txtOutPutAmount.Text = amountTotal.ToString();
            }
        }
    }
}
