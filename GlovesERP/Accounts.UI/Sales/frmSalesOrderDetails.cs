using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MetroFramework.Forms;
using Accounts.EL;
using Accounts.BLL;

namespace Accounts.UI
{
    public partial class frmSalesOrderDetails : MetroForm
    {
        public List<VoucherDetailEL> OrderList { get; set; }
        public frmSalesOrderDetails()
        {
            InitializeComponent();
        }
        private void frmSalesOrderDetails_Load(object sender, EventArgs e)
        {
            this.DgvSaleInvoice.AutoGenerateColumns = false;
            if (OrderList.Count > 0)
            {
                DgvSaleInvoice.DataSource = OrderList;
            }
            else
            {
                DgvSaleInvoice.DataSource = null;
            }
        }
    }
}
