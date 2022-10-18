using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MetroFramework.Forms;
using MetroFramework.Controls;

using Accounts.EL;
using Accounts.Common;
using Accounts.BLL;

namespace Accounts.UI
{
    public partial class frmFindOrders : MetroForm
    {
        #region Variables
        OrdersEL oelOrder;
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public int OrderType { get; set; }
        public bool IsSalesHead { get; set; }
        frmFindAccounts frmfindAccounts;
        public delegate void FindOrdersDelegate(Object Sender, OrdersEL oelOrder);
        public event FindOrdersDelegate ExecuteFindOrdersEvent;
        #endregion
        #region Form Methods And Variables
        public frmFindOrders()
        {
            InitializeComponent();
            if (AccountNo == null)
            {
                AccountNo = string.Empty;
            }
        }
        private void frmFindOrders_Load(object sender, EventArgs e)
        {
            this.grdFindOrders.AutoGenerateColumns = false;
            if (AccountNo != string.Empty)
            {
                if(!IsSalesHead)
                LoadCustomerOrders(AccountNo);
            }
            if (IsSalesHead)
            {
                txtFindByCustomer.Enabled = false;
            }
            if (OrderType == 1)
            {
                this.Text = "Track Gloves Orders";
            }
            else if (OrderType == 2)
            {
                this.Text = "Track Garments Orders";
            }
            else
            {
                this.Text = "Track Customer Orders";
            }
        }
        private void frmFindOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (oelOrder != null)
            {
                this.ExecuteFindOrdersEvent(sender, oelOrder);
            }
        }
        #endregion
        #region Methods
        private void LoadCustomerOrders(string AccountNo)
        {
            var manager = new OrdersBLL();
            List<OrdersEL> list = manager.GetCustomerOrdersByType(Operations.IdCompany, AccountNo, OrderType);
            if (list.Count > 0)
            {
                grdFindOrders.DataSource = list;
            }
            else
            {
                grdFindOrders.DataSource = null;
            }
            if (AccountName != null && AccountName != string.Empty)
            {
                txtFindByCustomer.Text = AccountName;
            }
        }
        #endregion
        #region Button Events
        private void btnLoadOrders_Click(object sender, EventArgs e)
        {
            if (chkGloves.Checked || chkGarments.Checked)
            {
                LoadCustomerOrders(AccountNo);
            }
            else
            {
                MessageBox.Show("Please Select Order Type");
            }
        }
        #endregion
        #region Grid Events
        private void grdFindOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            oelOrder = new OrdersEL();
            oelOrder.IdOrder = Validation.GetSafeGuid(grdFindOrders.Rows[e.RowIndex].Cells[0].Value);
            oelOrder.IdCurrency = Validation.GetSafeLong(grdFindOrders.Rows[e.RowIndex].Cells[1].Value);
            oelOrder.OrderNo = Validation.GetSafeLong(grdFindOrders.Rows[e.RowIndex].Cells[3].Value);
            oelOrder.CustomerPo = Validation.GetSafeString(grdFindOrders.Rows[e.RowIndex].Cells[6].Value);
            oelOrder.OrderStatus = Validation.GetSafeInteger(grdFindOrders.Rows[e.RowIndex].Cells[7].Value);
            this.Close();
        }
        private void grdFindOrders_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (grdFindOrders.CurrentRow != null)
                {
                    int RowIndex = grdFindOrders.CurrentRow.Index;
                    oelOrder = new OrdersEL();
                    oelOrder.IdOrder = Validation.GetSafeGuid(grdFindOrders.Rows[RowIndex].Cells[0].Value);
                    oelOrder.IdCurrency = Validation.GetSafeLong(grdFindOrders.Rows[RowIndex].Cells[1].Value);
                    oelOrder.OrderNo = Validation.GetSafeLong(grdFindOrders.Rows[RowIndex].Cells[3].Value);
                    oelOrder.CustomerPo = Validation.GetSafeString(grdFindOrders.Rows[RowIndex].Cells[6].Value);
                    oelOrder.OrderStatus = Validation.GetSafeInteger(grdFindOrders.Rows[RowIndex].Cells[7].Value);
                    this.Close();
                }
            }
        }             
        #endregion
        #region Other Controls Events And Methods
        private void txtFindByCustomer_ButtonClick(object sender, EventArgs e)
        {
            frmfindAccounts = new frmFindAccounts();
            frmfindAccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccounts_ExecuteFindAccountEvent);
            frmfindAccounts.ShowDialog();
        }
        void frmfindAccounts_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            AccountNo = oelAccount.AccountNo;
            txtFindByCustomer.Text = oelAccount.AccountName;
            LoadCustomerOrders(AccountNo);
        }
        #endregion
        #region CheckBox Events
        private void chkGloves_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGloves.Checked)
            {
                chkGarments.Checked = false;
                OrderType = 1;
            }
        }
        private void chkGarments_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGarments.Checked)
            {
                chkGloves.Checked = false;
                OrderType = 2;
            }
        }
        #endregion
    }
}
