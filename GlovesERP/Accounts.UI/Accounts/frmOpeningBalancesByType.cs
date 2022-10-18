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
using Accounts.Common;

using MetroFramework.Forms;


namespace Accounts.UI
{
    public partial class frmOpeningBalancesByType : MetroForm
    {
        public frmOpeningBalancesByType()
        {
            InitializeComponent();
        }

        private void frmOpeningBalancesByType_Load(object sender, EventArgs e)
        {
            this.grdOpeningBalances.AutoGenerateColumns = false;
            cbxCategory.SelectedIndex = 0;
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCategory.SelectedIndex > 0)
            {
                var manager = new OpeningBalanceBLL();
                List<OpeningBalanceEL> list = manager.GetOpeningBalancesByType(cbxCategory.Text, Operations.IdCompany);
                if (list.Count > 0)
                {
                    grdOpeningBalances.DataSource = list;
                }
                else
                {
                    grdOpeningBalances.DataSource = null;
                }
            }
        }
    }
}
