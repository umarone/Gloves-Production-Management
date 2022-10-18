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
    public partial class frmfindProductionBatches : MetroForm
    {
        public int ProductionType { get; set; }
        int Status = 1;
        ProductionBatchesEL oelBatch = null;
        public delegate void FindBatchesDelegate(Object Sender, ProductionBatchesEL oelProductionBatch);
        public event FindBatchesDelegate ExecuteFindBatchEvent;
        public frmfindProductionBatches()
        {
            InitializeComponent();
        }
        private void frmfindProductionBatches_Load(object sender, EventArgs e)
        {
            this.grdBatches.AutoGenerateColumns = false;
            LoadDefaultbatches();
        }
        private void LoadDefaultbatches()
        {
            var manager = new ProductionBatchesBLL();
            List<ProductionBatchesEL> list = manager.GetAllProductionBatches(Operations.IdCompany, ProductionType, Status);
            if (list.Count > 0)
            {
                grdBatches.DataSource = list;
            }
            else
            {
                grdBatches.DataSource = null;
            }
        }
        private void btnLoadBatches_Click(object sender, EventArgs e)
        {
            if (chkContinueBatches.Checked)
            {
                Status = 1;
            }
            else
            {
                Status = 2;
            }
            LoadDefaultbatches();
        }
        private void chkContinueBatches_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContinueBatches.Checked)
            {
                chkCompletedBatches.Checked = false;
            }
        }
        private void chkCompletedBatches_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCompletedBatches.Checked)
            {
                chkContinueBatches.Checked = false;
            }
        }
        private void grdBatches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            oelBatch = new ProductionBatchesEL();
            oelBatch.IdBatch = Validation.GetSafeGuid(grdBatches.Rows[RowIndex].Cells[0].Value);
            oelBatch.ProductionBatchNo = Validation.GetSafeLong(grdBatches.Rows[RowIndex].Cells[1].Value);
            oelBatch.OutWardStatus = Validation.GetSafeString(grdBatches.Rows[RowIndex].Cells[2].Value);
            oelBatch.OutWardStatus = Validation.GetSafeString(grdBatches.Rows[RowIndex].Cells[2].Value);

            this.Close();    
        }
        private void grdBatches_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (grdBatches.CurrentRow != null)
                {
                    int RowIndex = grdBatches.CurrentRow.Index;
                    oelBatch = new ProductionBatchesEL();
                    oelBatch.IdBatch = Validation.GetSafeGuid(grdBatches.Rows[RowIndex].Cells[0].Value);
                    oelBatch.ProductionBatchNo = Validation.GetSafeLong(grdBatches.Rows[RowIndex].Cells[1].Value);
                    oelBatch.OutWardStatus = Validation.GetSafeString(grdBatches.Rows[RowIndex].Cells[2].Value);
                    oelBatch.OutWardStatus = Validation.GetSafeString(grdBatches.Rows[RowIndex].Cells[2].Value);

                    this.Close();
                }
            }
        }
        private void frmfindProductionBatches_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (oelBatch != null)
            {
                ExecuteFindBatchEvent(sender, oelBatch);
            }
        }
    }
}
