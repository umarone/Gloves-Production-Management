using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.BLL;
using Accounts.EL;
using MetroFramework.Forms;
using MetroFramework.Controls;
using Accounts.Common;


namespace Accounts.UI.Production
{
    public partial class frmCuffTalliCalculation : MetroForm
    {
        frmStockAccounts frmstockAccounts;
        public frmCuffTalliCalculation()
        {
            InitializeComponent();
        }

        private void frmCuffTalliCalculation_Load(object sender, EventArgs e)
        {

        }

        private void grdCuffing_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (Validation.GetSafeString(grdCuffing.Rows[e.RowIndex].Cells["colCuffingPacking"].Value) == "Meter")
                {
                    grdCuffing.Rows[e.RowIndex].Cells["colcuffingMeterYard"].Value = Validation.GetSafeDecimal(grdCuffing.Rows[e.RowIndex].Cells["colCuffingQty"].Value) * Validation.GetSafeDecimal(1.09);
                }
                else
                {
                    grdCuffing.Rows[e.RowIndex].Cells["colcuffingMeterYard"].Value = Validation.GetSafeDecimal(grdCuffing.Rows[e.RowIndex].Cells["colCuffingQty"].Value);
                }
            }
            else if (e.ColumnIndex == 7)
            {
                grdCuffing.Rows[e.RowIndex].Cells["colcuffingTotalBari"].Value = (Validation.GetSafeDecimal(grdCuffing.Rows[e.RowIndex].Cells["colcuffingMeterYard"].Value) / Validation.GetSafeDecimal(grdCuffing.Rows[e.RowIndex].Cells["colCuffingBariSize"].Value)).ToString("0.00");
            }
            else if (e.ColumnIndex == 10)
            {
                grdCuffing.Rows[e.RowIndex].Cells["colCuffingCalculatedQty"].Value = (Validation.GetSafeDecimal(grdCuffing.Rows[e.RowIndex].Cells["colcuffingWidth"].Value) / Validation.GetSafeDecimal(grdCuffing.Rows[e.RowIndex].Cells["colcuffTaliBariSize"].Value)).ToString("0.00");
            }
        }

        private void grdCuffing_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                grdCuffing.Rows[e.RowIndex].Cells["colTotalCuffBari"].Value = (Validation.GetSafeDecimal(grdCuffing.Rows[e.RowIndex].Cells["colcuffingTotalBari"].Value) * Validation.GetSafeDecimal(grdCuffing.Rows[e.RowIndex].Cells["colCuffingCalculatedQty"].Value)).ToString("0.00");
                grdCuffing.Rows[e.RowIndex].Cells["colCuffingDozen"].Value = 24;
            }
            else if (e.ColumnIndex == 13)
            {
                grdCuffing.Rows[e.RowIndex].Cells["colcuffingEstimated"].Value = (Validation.GetSafeDecimal(grdCuffing.Rows[e.RowIndex].Cells["colTotalCuffBari"].Value) / 24).ToString("0.00");
            }
        }

        private void grdCuffing_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                SendKeys.Send("{F4}");
            }
        }

        private void grdCuffing_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCuffing.CurrentCellAddress.X == 3)
            {
                TextBox txtProductName = e.Control as TextBox;
                if (txtProductName != null)
                {
                    txtProductName.KeyPress -= new KeyPressEventHandler(txtProductName_KeyPress);
                    txtProductName.KeyPress += new KeyPressEventHandler(txtProductName_KeyPress);
                }
            }
        }
        void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuffing.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            var manager = new ItemsBLL();
            if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.AccountNo).Count > 0)
            {
                //for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                //{
                //    if (DgvStockReceipt.Rows[i].Cells["colItemNo"].Value != null)
                //    {
                //        if (oelItems.AccountNo == Validation.GetSafeLong(DgvStockReceipt.Rows[i].Cells["colItemNo"].Value))
                //        {
                //            lblStatuMessage.Text = "Product Already exists";
                //            return;
                //        }
                //    }
                //}
                    grdCuffing.CurrentRow.Cells["colcuffingIdItem"].Value = oelItems.IdItem;
                    grdCuffing.CurrentRow.Cells["colCuffingProduct"].Value = oelItems.AccountName;
                
            }
        }
    }
}
