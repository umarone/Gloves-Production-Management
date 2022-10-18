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
using MetroFramework.Controls;

namespace Accounts.UI
{
    public partial class frmTanneryLotsByChemical : MetroForm
    {
        #region Variables
        frmStockAccounts frmstockAccounts;
        Guid IdItem;
        #endregion
        public frmTanneryLotsByChemical()
        {
            InitializeComponent();
        }

        private void frmTanneyLotsByChemical_Load(object sender, EventArgs e)
        {
            this.grdChemicalLots.AutoGenerateColumns = false;
        }
        private void PEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                frmstockAccounts = new frmStockAccounts();
                frmstockAccounts.ExecuteFindStockAccountEvent +=new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                frmstockAccounts.SearchText = e.KeyChar.ToString();
                frmstockAccounts.ShowDialog(this);
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {

            }
            else
                e.Handled = true;
        }     
        private void PEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmstockAccounts = new frmStockAccounts();
            frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
            frmstockAccounts.ShowDialog();
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, EL.ItemsEL oelItems)
        {
            PEditBox.Text = oelItems.ItemName;
            IdItem = oelItems.IdItem;
        }
        private void btnChemicalLotsReport_Click(object sender, EventArgs e)
        {
            var manager = new TanneryLotBLL();
            List<TanneryChemicalEL> list = manager.GetLotsByChemical(IdItem);
            if (list.Count > 0)
            {
                grdChemicalLots.DataSource = list;
            }
            else
            {
                grdChemicalLots.DataSource = null;
            }
        }
    }
}
