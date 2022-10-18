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
using MetroFramework.Controls;

namespace Accounts.UI
{
    public partial class frmDayBook : MetroForm
    {
        public frmDayBook()
        {
            InitializeComponent();
        }

        private void frmDayBook_Load(object sender, EventArgs e)
        {
            this.grdDayBook.AutoGenerateColumns = false;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var Manager = new TransactionBLL();
            List<TransactionsEL> list = Manager.GetDayBookDetail(Operations.IdCompany,Convert.ToDateTime(dtStart.Value.ToShortDateString()));
            if(list.Count > 0)
            {
                this.pnlDetail.Visible = true;
                if (list[0].IsAuthorized)
                {
                    chkAuthorized.Checked = true;
                    chkAuthorized.Visible = true;
                    btnAuthorize.Enabled = false;
                }
                else
                {
                    chkAuthorized.Checked = false;
                    chkAuthorized.Visible = false;
                    btnAuthorize.Enabled = true;
                }
                grdDayBook.DataSource = list;
                lblTotalExpense.Text = list.Where(x=> x.DayBook == "Expense").Sum(x => x.Debit).ToString();
                lblTotalReceipts.Text = list.Where(x => x.DayBook == "Cash Reciept").Sum(x => x.Debit).ToString();

                lblRemainingCashInHand.Text = (Validation.GetSafeDecimal(lblTotalReceipts.Text) - Validation.GetSafeDecimal(lblTotalExpense.Text)).ToString();
            }
            else
            {
                grdDayBook.DataSource = null;
                this.pnlDetail.Visible = false;
            }
        }

        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            var manager = new TransactionBLL();
            List<TransactionsEL> list = new List<TransactionsEL>();
            for (int i = 0; i < grdDayBook.Rows.Count; i++)
            {
                TransactionsEL obj = new TransactionsEL();
                obj.TransactionID = Validation.GetSafeGuid(grdDayBook.Rows[i].Cells["colTransactionId"].Value);
                list.Add(obj);
            }
            if (MessageBox.Show("Do You Want To Authoriz...", "Authorize", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (manager.AuthorizeDayBook(list))
                {
                    MessageBox.Show("Day Book Authorized.....");
                }
                else
                { 
                
                }
            }
        }
    }
}
