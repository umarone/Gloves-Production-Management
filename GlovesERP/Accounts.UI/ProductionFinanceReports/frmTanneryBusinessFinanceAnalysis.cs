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
    public partial class frmTanneryBusinessFinanceAnalysis : MetroForm
    {
        public frmTanneryBusinessFinanceAnalysis()
        {
            InitializeComponent();
        }

        private void frmTanneryBusinessFinanceAnalysis_Load(object sender, EventArgs e)
        {
            this.grdFinance.AutoGenerateColumns = false;
        }

        private void btnGetAnalysis_Click(object sender, EventArgs e)
        {
            var manager = new TransactionBLL();
            List<TransactionsEL> list = manager.GetTanneryBusinessFinanceAnalysis(Convert.ToDateTime(startDate.Value.ToShortDateString()),Convert.ToDateTime(endDate.Value.ToShortDateString()));
            if (list.Count > 0)
            {
                grdFinance.DataSource = list;
            }
            else
            {
                grdFinance.DataSource = null;
            }
        }
    }
}
