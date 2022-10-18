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
    public partial class frmAllVehiclesProfitLoss : MetroForm
    {
        #region Variables
        TextBox txtDebit = new TextBox();
        TextBox txtCredit = new TextBox();
        TextBox txtBalance = new TextBox();
        #endregion
        public frmAllVehiclesProfitLoss()
        {
            InitializeComponent();
        }

        private void frmAllVehiclesProfitLoss_Load(object sender, EventArgs e)
        {
            this.grdVehicleProfitLoss.AutoGenerateColumns = false;
            CreateAndInitializeFooterRow();
        }
        private void CreateAndInitializeFooterRow()
        {

            txtDebit.Enabled = false;
            txtCredit.Enabled = false;
            txtBalance.Enabled = false;
            txtCredit.TextAlign = HorizontalAlignment.Center;
            txtDebit.TextAlign = HorizontalAlignment.Center;
            txtBalance.TextAlign = HorizontalAlignment.Center;
            
            int Xdgvx1 = this.grdVehicleProfitLoss.GetCellDisplayRectangle(1, -1, true).Location.X;


            txtCredit.Width = this.grdVehicleProfitLoss.Columns[1].Width;

            txtCredit.Location = new Point(Xdgvx1, grdVehicleProfitLoss.Height - txtCredit.Height);

            this.grdVehicleProfitLoss.Controls.Add(txtCredit);


            int Xdgvx2 = grdVehicleProfitLoss.GetCellDisplayRectangle(2, -1, true).Location.X;
            txtDebit.Width = this.grdVehicleProfitLoss.Columns[2].Width;
            txtDebit.Location = new Point(Xdgvx2, grdVehicleProfitLoss.Height - txtDebit.Height);
            this.grdVehicleProfitLoss.Controls.Add(txtDebit);

            int Xdgvx3 = grdVehicleProfitLoss.GetCellDisplayRectangle(3, -1, true).Location.X;
            txtBalance.Width = this.grdVehicleProfitLoss.Columns[3].Width;
            txtBalance.Location = new Point(Xdgvx3, grdVehicleProfitLoss.Height - txtBalance.Height);
            grdVehicleProfitLoss.Controls.Add(txtBalance);

        }
        private void btnLoadVehicles_Click(object sender, EventArgs e)
        {
            var manager = new TanneryProcessesHeadBLL();
            List<TanneryProcessesHeadEL> list = manager.GetAllVehicleProfitAndLoss();
            if (list.Count > 0)
            {
                grdVehicleProfitLoss.DataSource = list;
                txtCredit.Text = list.Sum(x => x.Credit).ToString();
                txtDebit.Text = list.Sum(x => x.Debit).ToString();
                txtBalance.Text = (Validation.GetSafeDecimal(txtCredit.Text) - Validation.GetSafeDecimal(txtDebit.Text)).ToString(); 
            }
            else
            {
                grdVehicleProfitLoss.DataSource = null;
                txtCredit.Text = string.Empty;
                txtDebit.Text = string.Empty;
                txtBalance.Text = string.Empty;
            }
        }
    }
}
