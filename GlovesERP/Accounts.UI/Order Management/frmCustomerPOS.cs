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
    public partial class frmCustomerPOS : MetroForm
    {
        OrdersEL oelOrder = null;
        public delegate void FindCustomerPoDelegate(Object Sender, OrdersEL oelOrder);
        public event FindCustomerPoDelegate ExecuteFindAccountEvent;
        public frmCustomerPOS()
        {
            InitializeComponent();
        }

        private void frmCustomerPOS_Load(object sender, EventArgs e)
        {
            this.grdPos.AutoGenerateColumns = false;
        }
        private void chkGloves_CheckedChanged(object sender, EventArgs e)
        {
            var manager = new OrdersBLL();
            List<OrdersEL> list = new List<OrdersEL>();
            MetroFramework.Controls.MetroCheckBox chk = sender as MetroFramework.Controls.MetroCheckBox;
            if (chk != null)
            {
                if (chk.Name == "chkGloves")
                {
                    list = manager.GetOpenCustomerPos(1);                    
                }
                else
                {
                    list = manager.GetOpenCustomerPos(2);
                }
                if (list.Count > 0)
                {
                    grdPos.DataSource = list;
                }
                else
                {
                    grdPos.DataSource = null;
                }
            }
        }
        private void grdPos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            oelOrder = new OrdersEL();
            oelOrder.IdOrder = Validation.GetSafeGuid(grdPos.Rows[e.RowIndex].Cells["colIdOrder"].Value);
            oelOrder.OrderNo = Validation.GetSafeLong(grdPos.Rows[e.RowIndex].Cells["colOrderNumber"].Value);
            oelOrder.AccountName = Validation.GetSafeString(grdPos.Rows[e.RowIndex].Cells["colCustomer"].Value);
            oelOrder.CustomerPo = Validation.GetSafeString(grdPos.Rows[e.RowIndex].Cells["colPoNumber"].Value);
            oelOrder.BrandName = Validation.GetSafeString(grdPos.Rows[e.RowIndex].Cells["colBrand"].Value);
            this.Close();
        }
        private void grdPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            oelOrder = new OrdersEL();
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (grdPos.CurrentRow != null)
                {
                    int RowIndex = grdPos.CurrentRow.Index;
                    oelOrder.IdOrder = Validation.GetSafeGuid(grdPos.Rows[RowIndex].Cells["colIdOrder"].Value);
                    oelOrder.OrderNo = Validation.GetSafeLong(grdPos.Rows[RowIndex].Cells["colOrderNumber"].Value);
                    oelOrder.AccountName = Validation.GetSafeString(grdPos.Rows[RowIndex].Cells["colCustomer"].Value);
                    oelOrder.CustomerPo = Validation.GetSafeString(grdPos.Rows[RowIndex].Cells["colPoNumber"].Value);
                    oelOrder.BrandName = Validation.GetSafeString(grdPos.Rows[RowIndex].Cells["colBrand"].Value);
                    this.Close();
                }
            }
        }
        private void frmCustomerPOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (oelOrder != null)
            {
                ExecuteFindAccountEvent(sender, oelOrder);
            }
        }
    }
}
