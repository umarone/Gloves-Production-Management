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
using Accounts.Common;

namespace Accounts.UI
{
    public partial class frmAccountBalance : MetroForm
    {
        frmAccountsBalanceReport frmAccountsBalanceReport;
        string AccountType = "";
        public frmAccountBalance()
        {
            InitializeComponent();
        }

        private void frmAccountBalance_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            DgvAccountBalance.Columns[4].Visible = false;
            StartBalanceDate.Enabled = false;
            EndBalanceDate.Enabled = false;
            CheckModulePermissions();
        }
        private void CheckModulePermissions()
        {
            List<UserModulesPermissionsEL> PermissionsList = UserPermissions.GetUserModulePermissionsByUserAndModuleId(Operations.UserID);
            if (PermissionsList != null && PermissionsList.Count > 0)
            {
                if (PermissionsList[0].Viewing == true)
                {
                    btnLoad.Enabled = true;
                }
                else
                {
                    btnLoad.Enabled = false;
                }
                
                if (PermissionsList[0].Printing == true)
                {
                    btnPrint.Enabled = true;
                }
                else
                {
                    btnPrint.Enabled = false;
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
        private void btnLoad_Click(object sender, EventArgs e)
        {
            List<TransactionsEL> list = null;
            var manager = new TransactionBLL();
            if (rdCustomers.Checked)
            {
                AccountType = "Accounts Recieveables";
            }
            else if (rdSuppliers.Checked)
            {
                AccountType = "Accounts Payables";
            }
            else
            {
                AccountType = "";
            }
            if (AccountType == "Stock")
            {
                var Stockmanager = new StockRecieptBLL();
                List<StockReceiptEL> lstStock = new List<StockReceiptEL>();
                if (!chkIncludeDate.Checked)
                {
                    lstStock = Stockmanager.GetTotalStockReport(Guid.Empty, Operations.IdCompany);
                    PopulateStock(lstStock);
                }
                else
                {
                    lstStock = Stockmanager.GetDateWiseTotalStockReport(Guid.Empty, Operations.IdCompany, Convert.ToDateTime(StartBalanceDate.Value.ToShortDateString()), Convert.ToDateTime(EndBalanceDate.Value.ToShortDateString()));
                    PopulateStock(lstStock);
                }
            }
            else
            {
                if (chkIncludeDate.Checked)
                {
                    list = manager.GetDateWiseAccountsBalance(AccountType, Convert.ToDateTime(StartBalanceDate.Value.ToShortDateString()), Convert.ToDateTime(EndBalanceDate.Value.ToShortDateString()), Operations.IdCompany);
                }
                else
                {
                    list = manager.GetAccountsBalance(AccountType, Operations.IdCompany);
                }
                LoadAccountsBalance(list);
            }
        }
        private void PopulateStock(List<StockReceiptEL> lstStock)
        {
            if (lstStock.Count > 0)
            {
                if (DgvAccountBalance.Rows.Count > 0)
                {
                    DgvAccountBalance.Rows.Clear();
                }
                for (int i = 0; i < lstStock.Count; i++)
                {
                    DgvAccountBalance.Rows.Add();
                    DgvAccountBalance.Rows[i].Cells[0].Value = lstStock[i].ItemNo;
                    DgvAccountBalance.Rows[i].Cells[1].Value = lstStock[i].AccountName;
                    DgvAccountBalance.Rows[i].Cells[2].Value = "Stock";
                    DgvAccountBalance.Rows[i].Cells[3].Value = lstStock[i].Amount;
                    DgvAccountBalance.Rows[i].Cells[4].Value = lstStock[i].Closing; 
                }
            }
        }
        private void LoadAccountsBalance(List<TransactionsEL> list)
        {
            if (list.Count > 0)
            {
                if (DgvAccountBalance.Rows.Count > 0)
                {
                    DgvAccountBalance.Rows.Clear();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    DgvAccountBalance.Rows.Add();
                    DgvAccountBalance.Rows[i].Cells[0].Value = list[i].AccountNo;
                    DgvAccountBalance.Rows[i].Cells[1].Value = list[i].AccountName;
                    if (list[i].AccountType == "Accounts Receivables")
                    {
                        DgvAccountBalance.Rows[i].Cells[2].Value = "Customer";
                    }
                    else if (list[i].AccountType == "Accounts Payables")
                    {
                        DgvAccountBalance.Rows[i].Cells[2].Value = "Supplier";
                    }
                    else
                    {
                        DgvAccountBalance.Rows[i].Cells[2].Value = list[i].AccountType;
                    }
                    if (list[i].Debit > list[i].Credit)
                    {
                        DgvAccountBalance.Rows[i].Cells[3].Value = list[i].Debit - list[i].Credit;
                    }
                    //else
                    //{
                    if (list[i].AccountType == "Accounts Recieveables")
                    {
                        DgvAccountBalance.Rows[i].Cells[3].Value = list[i].Debit - list[i].Credit;
                    }
                    else
                    {
                        DgvAccountBalance.Rows[i].Cells[3].Value = list[i].Credit - list[i].Debit;
                    }
                    //}                    
                    DgvAccountBalance.Rows[i].Cells[4].Value = list[i].Qty;                    
                }
                if (list.Count > 0)
                {
                    decimal amount = 0;
                    for (int i = 0; i < DgvAccountBalance.Rows.Count; i++)
                    {
                        amount += Convert.ToDecimal(DgvAccountBalance.Rows[i].Cells["colBalance"].Value);
                    }
                    lblTotalAmount.Text = amount.ToString();
                    if (rdCustomers.Checked)
                    {
                        lblTotal.Text = "Total Recievables :";
                    }
                    else if (rdSuppliers.Checked)
                    {
                        lblTotal.Text = "Total Payables :";
                    }
                    else
                    {
                        lblTotal.Text = "";
                        lblTotalAmount.Text = "";
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmAccountsBalanceReport = new frmAccountsBalanceReport();
            frmAccountsBalanceReport.StartDate = Convert.ToDateTime(StartBalanceDate.Value.ToShortDateString());
            frmAccountsBalanceReport.EndDate = Convert.ToDateTime(EndBalanceDate.Value.ToShortDateString());
            if (chkIncludeDate.Checked)
            {
                frmAccountsBalanceReport.IsDateWiseBalanceReport = true;
            }
            else
            {
                frmAccountsBalanceReport.IsDateWiseBalanceReport = false;
            }
            if (rdCustomers.Checked)
            {
                frmAccountsBalanceReport.AccountType = "Accounts Recieveables"; 
            }
            else if (rdSuppliers.Checked)
            {
                frmAccountsBalanceReport.AccountType = "Accounts Payables";
            }
            else
            {
                frmAccountsBalanceReport.AccountType = "";
            }
            frmAccountsBalanceReport.Show();
        }

        private void rdStock_CheckedChanged(object sender, EventArgs e)
        {
            lblTotal.Text = "";
            lblTotalAmount.Text = "";
            if (DgvAccountBalance.Rows.Count > 0)
            {
                DgvAccountBalance.Rows.Clear();
            }
            if (((RadioButton)sender).Text == "Stock")
            {
                DgvAccountBalance.Columns[4].Visible = true;
                DgvAccountBalance.Columns[3].Visible = true;
            }
            else
            {
                DgvAccountBalance.Columns[4].Visible = false;
                DgvAccountBalance.Columns[3].Visible = true;
            }
        }

        private void chkIncludeDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIncludeDate.Checked)
            {
                StartBalanceDate.Enabled = true;
                EndBalanceDate.Enabled = true;
            }
            else
            {
                StartBalanceDate.Enabled = false;
                EndBalanceDate.Enabled = false;
            }
        }
    }
}
