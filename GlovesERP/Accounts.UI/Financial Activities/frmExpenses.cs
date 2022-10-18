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
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace Accounts.UI
{
    public partial class frmExpenses : MetroForm
    {
        frmFindAccounts frmAccount = null;
        public frmExpenses()
        {
            InitializeComponent();
        }
        private void btnLoadExpense_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            var manager = new TransactionBLL();
            List<TransactionsEL> list = manager.ListExpenses(dtStart.Value,dtEnd.Value,Operations.IdCompany);            
            PopulateExpenses(list);
        }
        private void PopulateExpenses(List<TransactionsEL> list)
        {
            if (dgvExpenses.Rows.Count > 0)
            {
                dgvExpenses.Rows.Clear();
                txtExpenseAmount.Text = "";
            }
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    dgvExpenses.Rows.Add();
                    dgvExpenses.Rows[i].Cells[0].Value = list[i].VoucherNo;
                    dgvExpenses.Rows[i].Cells[1].Value = list[i].AccountName;
                    dgvExpenses.Rows[i].Cells[2].Value = list[i].Description;
                    dgvExpenses.Rows[i].Cells[3].Value = list[i].Debit;                                        
                }               
            }
            txtExpenseAmount.Text = list.Sum(x => x.Debit).ToString();
        }

        private void dgvExpenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmExpenses_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        private void CheckModulePermissions()
        {
            List<UserModulesPermissionsEL> PermissionsList = UserPermissions.GetUserModulePermissionsByUserAndModuleId(Operations.UserID);
            if (PermissionsList != null && PermissionsList.Count > 0)
            {
                if (PermissionsList[0].Viewing == true)
                {
                    btnLoadExpense.Enabled = true;
                }
                else
                {
                    btnLoadExpense.Enabled = false;
                }
            }
            //else
            //{
            //    btnSave.Enabled = false;
            //    btnDelete.Enabled = false;
            //    chkPosted.Checked = true;
            //    chkPosted.Enabled = true;
            //}
        }
        //private void AccEditBox_ClickButton(object sender, EventArgs e)
        //{
        //    frmAccount = new frmAccounts();
        //    frmAccount.ExecuteFindAccountEvent += new frmAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
        //    frmAccount.Show();
        //}

       // void frmAccount_ExecuteFindAccountEvent(ChartsOfAccountsEL oelChartOfAccount)
        //{
        //    var manager = new ChartsOfAccountsBLL();
        //    if (oelChartOfAccount != null)
        //    {
        //        List<ChartsOfAccountsEL> list = manager.GetAccount(oelChartOfAccount.AccountNo);
        //        if (list.Count > 0)
        //        {

        //            if (list[0].HeaderAccount == 5)
        //            {
        //                AccEditBox.Text = oelChartOfAccount.AccountNo;
        //            }
        //            else
        //            { 
                        
        //            }
        //        }
        //    }
        //}       
    }
}
