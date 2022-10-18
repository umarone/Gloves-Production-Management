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
    public partial class frmOrderCosting : MetroForm
    {
        public int ProductionType { get; set; }
        public frmOrderCosting()
        {
            InitializeComponent();
        }

        private void frmOrderCosting_Load(object sender, EventArgs e)
        {
            if (ProductionType == 1)
            {
                this.Text = "Gloves Order Costing";
            }
            else if (ProductionType == 2)
            {
                this.Text = "Garments Order Costing";
            }
            grdOrderCosting.AutoGenerateColumns = false;
        }
        private void btnGetReport_Click(object sender, EventArgs e)
        {
            var manager = new ProductionProcessDetailBLL();
            List<ProductionProcessDetailEL> list = manager.GetOrderCosting(txtCustomerPo.Text, ProductionType);
            if (list.Count > 0)
            {
                grdOrderCosting.DataSource = list;
            }
            else
            {
                grdOrderCosting.DataSource = null;
            }
        }
    }
}
