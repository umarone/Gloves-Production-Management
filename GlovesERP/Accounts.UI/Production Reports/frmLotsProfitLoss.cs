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
    public partial class frmLotsProfitLoss : MetroForm
    {
        #region
        public Guid IdLot { get; set; }
        public Int64 LotNo { get; set; }
        #endregion
        public frmLotsProfitLoss()
        {
            InitializeComponent();
        }

        private void frmLotsProfitLoss_Load(object sender, EventArgs e)
        {
            this.grdLotsProfitLoss.AutoGenerateColumns = false;
            lblLotNo.Text = LotNo.ToString();
            LoadLotProfitLoss();
        }
        private void LoadLotProfitLoss()
        {
            var manager = new TanneryProcessesHeadBLL();
            bool isCuttingFound = false;
            List<TanneryProcessesHeadEL> list = manager.GetLotProfitAndLoss(IdLot);
            if (list.Count > 0)
            {
                grdLotsProfitLoss.DataSource = list;
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
                grdLotsProfitLoss.DataSource = null;
                lblCuttingValue.Text = string.Empty;
                lblTotalExpense.Text = string.Empty;
                lblProfit.Text = string.Empty;
            }

        }
    }
}
