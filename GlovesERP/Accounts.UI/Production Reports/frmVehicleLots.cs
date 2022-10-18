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
    public partial class frmVehicleLots : MetroForm
    {
        frmLotDetail frmlotdetail;
        public frmVehicleLots()
        {
            InitializeComponent();
        }
        private void frmVehicleLots_Load(object sender, EventArgs e)
        {
            this.grdVehicleLots.AutoGenerateColumns = false;
            FillVehicles();
        }        
        private void FillVehicles()
        {
            var manager = new TanneryProcessesHeadBLL();
            List<TanneryProcessesHeadEL> list = manager.GetVehiclesByStatus(2);
            list.Insert(0, new TanneryProcessesHeadEL() { VehicleNo = "" });
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    cbxVehicles.Items.Add(list[i].VehicleNo ?? "");
                }
            }
        }
        private void btnLoadLots_Click(object sender, EventArgs e)
        {
            var manager = new TanneryLotBLL();
            if (cbxVehicles.Text != string.Empty)
            {
                List<TanneryLotEL> list = manager.GetVehicleLots(cbxVehicles.Text);
                if (list.Count > 0)
                {
                    grdVehicleLots.DataSource = list;
                }
                else
                {
                    grdVehicleLots.DataSource = null;
                }
            }
            else
            {
                MessageBox.Show("Please Select Vehicle Number");
                grdVehicleLots.DataSource = null;
            }
        }
        private void grdVehicleLots_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                e.Value = "View Lot Detail";
            }
        }
        private void grdVehicleLots_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6)
            {
                frmlotdetail = new frmLotDetail();
                frmlotdetail.IdLotDetail = Validation.GetSafeGuid(grdVehicleLots.Rows[e.RowIndex].Cells["colIdLot"].Value);
                frmlotdetail.ShowDialog();
            }
        }
    }
}
