using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MetroFramework.Forms;

using Accounts.BLL;
using Accounts.EL;
using Accounts.Common;

namespace Accounts.UI
{
    public partial class frmLinkItems : MetroForm
    {
        #region Variables
        frmStockAccounts frmfindStock;
        public Guid IdItem { get; set; }
        public string ItemName { get; set; }
        #endregion
        public frmLinkItems()
        {
            InitializeComponent();
        }
        private void frmLinkItems_Load(object sender, EventArgs e)
        {
            this.Text = "Please Add Child Items For (" + ItemName + ")";
            this.grdLinkItems.AutoGenerateColumns = false;
            this.LoadLinkedItems();
        }
        private void LoadLinkedItems()
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetLinkedItemById(IdItem);
            if (list.Count > 0)
            {
                grdLinkItems.DataSource = list;
            }
        }
        private void btnAddItems_Click(object sender, EventArgs e)
        {
            frmfindStock = new frmStockAccounts();
            frmfindStock.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmfindStock_ExecuteFindStockAccountEvent);
            frmfindStock.ShowDialog();
        }
        void frmfindStock_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            grdLinkItems.Rows.Add();
            grdLinkItems.Rows[grdLinkItems.Rows.Count - 1].Cells["colIdItem"].Value = oelItems.IdItem;
            grdLinkItems.Rows[grdLinkItems.Rows.Count - 1].Cells["colItemCode"].Value = oelItems.ItemNo;
            grdLinkItems.Rows[grdLinkItems.Rows.Count - 1].Cells["colPackingSize"].Value = oelItems.PackingSize;
            grdLinkItems.Rows[grdLinkItems.Rows.Count - 1].Cells["colName"].Value = oelItems.ItemName;
            txtSearchStock.Text = string.Empty;
        }
        private void btnSaveLinkItems_Click(object sender, EventArgs e)
        {
            if (grdLinkItems.Rows.Count > 0 && IdItem != Guid.Empty)
            {
                var manager = new ItemsBLL();
                /// Create Items List Here....
                List<ItemsEL> list = new List<ItemsEL>();
                for (int i = 0; i < grdLinkItems.Rows.Count; i++)
                {
                    ItemsEL oelCreateItems = new ItemsEL();
                    oelCreateItems.IdLinkItem = Validation.GetSafeGuid(grdLinkItems.Rows[i].Cells["colIdItem"].Value);
                    oelCreateItems.IdItem = IdItem;
                    list.Add(oelCreateItems);
                }
                if (manager.UpdateLinkedItems(list))
                {
                    MessageBox.Show("All Items Updated....");
                }
            }
        }
        private void grdLinkItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                e.Value = "Delete";
            }
        }
        private void grdLinkItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("", "Deleting Items", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                var manager = new ItemsBLL();
                /// Create Items List Here....
                List<ItemsEL> list = new List<ItemsEL>();
                ItemsEL oelCreateItems = new ItemsEL();

                oelCreateItems.IdLinkItem = Guid.Empty;
                oelCreateItems.IdItem = Validation.GetSafeGuid(grdLinkItems.Rows[e.RowIndex].Cells["colIdItem"].Value);
                list.Add(oelCreateItems);

                if (manager.UpdateLinkedItems(list))
                {
                    MessageBox.Show("Item Is Deleted....");
                }
                else
                {
                    MessageBox.Show("Some Problem Occured....");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            grdLinkItems.DataSource = null;
        }
    }
}
