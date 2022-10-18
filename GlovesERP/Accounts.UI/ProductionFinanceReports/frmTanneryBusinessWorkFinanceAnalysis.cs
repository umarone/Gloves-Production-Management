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
    public partial class frmTanneryBusinessWorkFinanceAnalysis : MetroForm
    {
        public frmTanneryBusinessWorkFinanceAnalysis()
        {
            InitializeComponent();
        }

        private void frmTanneryBusinessWorkFinanceAnalysis_Load(object sender, EventArgs e)
        {
            this.grdWorkFinance.AutoGenerateColumns = false;
        }

        private void btnGetAnalysis_Click(object sender, EventArgs e)
        {
            var manager = new TransactionBLL();
            List<TransactionsEL> list = manager.GetTanneryBusinessWorkFinanceAnalysis(Convert.ToDateTime(startDate.Value.ToShortDateString()), Convert.ToDateTime(endDate.Value.ToShortDateString()));
            if (list.Count > 0)
            {
                grdWorkFinance.DataSource = list;
                lblAmount.Text = list.Sum(x => x.Amount).ToString();
            }
            else
            {
                grdWorkFinance.DataSource = null;
            }
        }
    }
}
