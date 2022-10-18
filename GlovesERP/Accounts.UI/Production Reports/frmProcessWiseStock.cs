using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.EL;
using Accounts.BLL;
using Accounts.Common;
using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmProcessWiseStock : MetroForm
    {
        #region        
        frmProcessWiseItemStock frmItemWiseStock;
        int ProcessIndex = 0;
        public int ProductionType { get; set; }
        DataTable dt;
        #endregion
        public frmProcessWiseStock()
        {
            InitializeComponent();
        }
        private void frmProcessWiseStock_Load(object sender, EventArgs e)
        {
            this.grdProcessStock.AutoGenerateColumns = false;
            if (ProductionType == 1)
            {
                this.Text = "Gloves Process Wise Stock Report";
            }
            else
            { 
                // No Code Here .....
            }
            LoadStepsByType();
        }
        private void LoadStepsByType()
        {
            if (ProductionType == 1)
            {
                cbxProductionType.Items.Add("");
                cbxProductionType.Items.Add("Cuff Cutting");
                cbxProductionType.Items.Add("Cuff Printing");
                cbxProductionType.Items.Add("OverLock");
                cbxProductionType.Items.Add("Magzi/Tape");
            }                  
        }
        private void chkApplyDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApplyDateFilter.Checked)
            {
                pnlDate.Enabled = true;
                btnLoad.Enabled = false;
            }
            else
            {
                pnlDate.Enabled = false;
                btnLoad.Enabled = true;
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {           
            var manager = new ProductionIssuanceHeadBLL();
            if (ProductionType == 1)
            {
                if (cbxProductionType.Text == "Cuff Cutting")
                {
                    ProcessIndex = 1;
                }
                else if (cbxProductionType.Text == "Cuff Printing")
                {
                    ProcessIndex = 3;
                }
                else if (cbxProductionType.Text == "OverLock")
                {
                    ProcessIndex = 4;
                }
                else if (cbxProductionType.Text == "Magzi/Tape")
                {
                    ProcessIndex = 5;
                }
            }            
            List<VoucherDetailEL> list = manager.GetProcessWiseStock(ProcessIndex);
            if (list.Count > 0)
            {
                dt = DataOperations.ToDataTable(list);
                grdProcessStock.DataSource = dt;
            }
        }
        private void btnLoadbyFilter_Click(object sender, EventArgs e)
        {            
            //var manager = new ProductionIssuanceHeadBLL();
            //List<VoucherDetailEL> list = manager.GetDateWiseWorkInProcessReport(IdArticle, ProductionType, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()));
            //if (list.Count > 0)
            //{
            //    SimplifyData(list);
            //}
        }       
        private void SimplifyData(List<VoucherDetailEL> list)
        {
            decimal DebitStock = 0, CreditStock = 0, Balance = 0, Qty = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (Validation.GetSafeDecimal(list[i].StockOut) == 0)
                {
                    CreditStock = Validation.GetSafeLong(list[i].StockIn);
                    Balance += CreditStock;
                    Qty += CreditStock;
                    list[i].Balance = Math.Abs(Qty);
                }
                if (Validation.GetSafeDecimal(list[i].StockIn) == 0)
                {
                    DebitStock = Validation.GetSafeLong(list[i].StockOut);
                    Balance -= DebitStock;
                    Qty -= DebitStock;
                    list[i].Balance = Math.Abs(Qty);
                }
            }
            grdProcessStock.DataSource = list;
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("ItemName LIKE '%{0}%'", txtsearch.Text);
            grdProcessStock.DataSource = DV;
        }
        private void grdProcessStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                e.Value = "View Detail";
            }
        }
        private void grdProcessStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                frmItemWiseStock = new frmProcessWiseItemStock();
                frmItemWiseStock.IdItem = Validation.GetSafeGuid(grdProcessStock.Rows[e.RowIndex].Cells["colItemId"].Value);
                frmItemWiseStock.ItemName = Validation.GetSafeString(grdProcessStock.Rows[e.RowIndex].Cells["colItemName"].Value);
                frmItemWiseStock.ProcessIndex = ProcessIndex;
                frmItemWiseStock.ShowDialog();
            }
        }        
    }
}
