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
    public partial class frmProcessWiseCosting : MetroForm
    {
        #region Variables
        frmFindAccounts frmfindAccount;
        string EventFiringName;
        string AccountNo;
        public int ProductionType { get; set; }
        DataTable dt;
        string MaterialName = "";
        #endregion
        public frmProcessWiseCosting()
        {
            InitializeComponent();
        }
        private void frmProcessWiseCosting_Load(object sender, EventArgs e)
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
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new ProductionIssuanceHeadBLL();
            List<VoucherDetailEL> list = manager.GetProcessWiseWorkerReport(Operations.IdCompany, AccountNo, cbxProductionType.SelectedIndex, ProductionType,cbxProductionType.Text,MaterialName);
            if (list.Count > 0)
            {
                List<VoucherDetailEL> lstOut = list.FindAll(x => x.ProcessType == 1);
                if (lstOut != null && lstOut.Count > 0)
                {
                    PopulateWorkerSummary(lstOut, 1);
                }
                List<VoucherDetailEL> lstIn = list.FindAll(x => x.ProcessType == 2);
                if (lstIn != null && lstIn.Count > 0)
                {
                    PopulateWorkerSummary(lstIn, 2);
                }
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
                    PopulateWorkerSummary(lstOut, 1);
                }
                List<VoucherDetailEL> lstIn = list.FindAll(x => x.ProcessType == 2);
                if (lstIn != null && lstIn.Count > 0)
                {
                    PopulateWorkerSummary(lstIn, 2);
                }
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
                dt.Columns.Add("CreatedDateTime");
                dt.Columns.Add("ItemName");               
                dt.Columns.Add("Qty");

                for (int i = 0; i < listDetail.Count; i++)
                {
                    // Add rows.
                    DataRow dr = dt.NewRow();
                    dr[0] = listDetail[i].CreatedDateTime;
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
                dt.Columns.Add("CreatedDateTime");
                dt.Columns.Add("ItemName");
                dt.Columns.Add("BrandName");
                dt.Columns.Add("Qty"); 
                dt.Columns.Add("Amount");

                for (int i = 0; i < listDetail.Count; i++)
                {
                    // Add rows.
                    DataRow dr = dt.NewRow();
                    dr[0] = listDetail[i].CreatedDateTime;
                    dr[1] = listDetail[i].ItemName;
                    dr[2] = listDetail[i].BrandName;
                    dr[3] = listDetail[i].Qty;                    
                    dr[4] = listDetail[i].Amount;

                    dt.Rows.Add(dr);
                }
                if (dt.Rows.Count > 0)
                {
                    grdOutPut.DataSource = dt;                    
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
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("ItemName LIKE '%{0}%'", txtSearchLabour.Text);
            grdOutPut.DataSource = DV;
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
    }
}
