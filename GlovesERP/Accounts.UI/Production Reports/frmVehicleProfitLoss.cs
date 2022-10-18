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
    public partial class frmVehicleProfitLoss : MetroForm
    {
        public frmVehicleProfitLoss()
        {
            InitializeComponent();
        }
        private void frmVehicleProfitLoss_Load(object sender, EventArgs e)
        {
            FillCompleteVehicles();
            this.grdVehicleProfitLoss.AutoGenerateColumns = false;
        }
        private void FillCompleteVehicles()
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
        private void btnLoadProfitLoss_Click(object sender, EventArgs e)
        {
            var manager = new TanneryProcessesHeadBLL();
            bool isCuttingFound = false;
            if (cbxVehicles.Text != string.Empty)
            {
                List<TanneryProcessesHeadEL> list = manager.GetVehicleProfitAndLoss(cbxVehicles.Text);
                if (list.Count > 0)
                {
                    grdVehicleProfitLoss.DataSource = list;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].AccountName == "Cutting Value")
                        {
                            isCuttingFound = true;
                            break;
                        }
                    }
                    if (isCuttingFound)
                    {
                        lblCuttingValue.Text = list.Find(x => x.AccountName == "Cutting Value").Amount.ToString();
                        lblTotalExpense.Text = list.FindAll(x => x.AccountName != "Cutting Value").Sum(x => x.Amount).ToString();
                        lblProfit.Text = (Validation.GetSafeDecimal(lblCuttingValue.Text) - Validation.GetSafeDecimal(lblTotalExpense.Text)).ToString();
                    }
                    else
                    {
                        lblCuttingValue.Text = "0";
                        lblTotalExpense.Text = list.FindAll(x => x.AccountName != "Cutting Value").Sum(x => x.Amount).ToString();
                        lblProfit.Text = (Validation.GetSafeDecimal(lblCuttingValue.Text) - Validation.GetSafeDecimal(lblTotalExpense.Text)).ToString();
                    }
                }
                else
                {
                    grdVehicleProfitLoss.DataSource = null;
                    lblCuttingValue.Text = string.Empty;
                    lblTotalExpense.Text = string.Empty;
                    lblProfit.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Please Select Vehicle Number");
                grdVehicleProfitLoss.DataSource = null;
            }
        }
    }
}
