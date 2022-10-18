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
using Accounts.Common;
using SpreadsheetLight;
using System.Diagnostics;

namespace Accounts.UI
{
    public partial class frmgeneralLedger : MetroForm
    {
        #region Variables
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        TextBox txtOpening = new TextBox();
        TextBox txtDebit = new TextBox();
        TextBox txtCredit = new TextBox();
        TextBox txtBalance = new TextBox();
        TextBox txtBalanceType = new TextBox();
        Label labelDgv1 = new Label();
        Panel pnlAmountSum = new Panel();
        frmFindAccounts frmledgerAccounts;
        frmLedgerreport frmledgerreport;
        string AccountType = "";
        #endregion
        public frmgeneralLedger()
        {
            InitializeComponent();
       
        }
        private void frmgeneralLedger_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.DgvLedger.AutoGenerateColumns = false;
            CreateAndInitializeFooterRow();
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
        private void CreateAndInitializeFooterRow()
        {
            txtOpening.Enabled = false;
            txtDebit.Enabled = false;
            txtCredit.Enabled = false;
            txtBalance.Enabled = false;
            txtBalanceType.Enabled = false;
            txtCredit.TextAlign = HorizontalAlignment.Center;
            txtDebit.TextAlign = HorizontalAlignment.Center;
            txtBalance.TextAlign = HorizontalAlignment.Center;
            txtOpening.TextAlign = HorizontalAlignment.Center;
            txtBalanceType.TextAlign = HorizontalAlignment.Center;

            int Xdgv1 = this.DgvLedger.GetCellDisplayRectangle(6, -1, true).Location.X;

            labelDgv1.Text = "Total";

            labelDgv1.Height = 21;
            pnlAmountSum.Height = 21;
            pnlAmountSum.BackColor = Color.Wheat;
            pnlAmountSum.AutoSize = false;
            pnlAmountSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlAmountSum.Width = this.DgvLedger.Columns[7].Width + Xdgv1;
            pnlAmountSum.Location = new Point(0, this.DgvLedger.Height - txtDebit.Height);

            this.DgvLedger.Controls.Add(pnlAmountSum);

            int Xdgvx0 = this.DgvLedger.GetCellDisplayRectangle(4, -1, true).Location.X;


            txtOpening.Width = this.DgvLedger.Columns[4].Width;

            txtOpening.Location = new Point(Xdgvx0, DgvLedger.Height - txtOpening.Height);

            this.DgvLedger.Controls.Add(txtOpening);

            
            int Xdgvx1 = this.DgvLedger.GetCellDisplayRectangle(5, -1, true).Location.X;


            txtDebit.Width = this.DgvLedger.Columns[5].Width;

            txtDebit.Location = new Point(Xdgvx1, DgvLedger.Height - txtDebit.Height);

            this.DgvLedger.Controls.Add(txtDebit);


            int Xdgvx2 = DgvLedger.GetCellDisplayRectangle(6, -1, true).Location.X;
            txtCredit.Width = this.DgvLedger.Columns[6].Width;
            txtCredit.Location = new Point(Xdgvx2, DgvLedger.Height - txtCredit.Height);
            this.DgvLedger.Controls.Add(txtCredit);

            int Xdgvx3 = DgvLedger.GetCellDisplayRectangle(7, -1, true).Location.X;
            txtBalance.Width = this.DgvLedger.Columns[7].Width;
            txtBalance.Location = new Point(Xdgvx3, DgvLedger.Height - txtBalance.Height);
            DgvLedger.Controls.Add(txtBalance);

            int Xdgvx4 = DgvLedger.GetCellDisplayRectangle(8, -1, true).Location.X;
            txtBalanceType.Width = this.DgvLedger.Columns[8].Width;
            txtBalanceType.Location = new Point(Xdgvx4, DgvLedger.Height - txtBalanceType.Height);
            DgvLedger.Controls.Add(txtBalanceType);

            pnlAmountSum.SendToBack();
            
                   
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new TransactionBLL();
            List<TransactionsEL> list = null;
            DataTable dt = null;
            if (chkCompleteLedger.Checked) /// Complete Business Ledger
            {
                dt = manager.GetAccountLedger(AccountNo, Operations.IdCompany);
                //if (list.Count == 0)
                //{
                //    list = manager.GetControlAccountLedger(AccountNo, Operations.IdCompany); 
                //}
            }
            else   /// Periodic Business Ledger 
            {
                dt = manager.GetAccountsDateWiseLedger(AccountNo, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()), Operations.IdCompany);
                //if (list.Count == 0)
                //{
                //    list = manager.GetControlAccountsDateWiseLedger(AccountNo, Convert.ToDateTime(StartDate.Value.ToShortDateString()), Convert.ToDateTime(EndDate.Value.ToShortDateString()), Operations.IdCompany);
                //}
            }
            //PopulateLedger(list);
            if (dt != null && dt.Rows.Count > 0)
            {
                DgvLedger.DataSource = dt; //list;

                if (!chkCompleteLedger.Checked)
                {
                    txtOpening.Text = dt.AsEnumerable().Sum(x => x.Field<decimal>("Opening")).ToString(); //Validation.GetSafeString(dr[0]);
                }
                //txtOpening.Text =     list.Sum(x => x.OpeningBalance).ToString();
                txtDebit.Text = dt.AsEnumerable().Sum(x => x.Field<decimal>("Debit")).ToString();
                txtCredit.Text = dt.AsEnumerable().Sum(x => x.Field<decimal>("Credit")).ToString(); //list.Sum(x => x.Credit).ToString();
                txtBalance.Text = Validation.GetSafeString(dt.Rows[0]["ClosingBalance"]); //list[0].ClosingBalance.ToString();
                txtBalanceType.Text = Validation.GetSafeString(dt.Rows[0]["FinalBalanceType"]);
            }
            else
            {
                MessageBox.Show("No Data Found...");
                ClearControls();
            }
        }
        private void PopulateLedger(List<TransactionsEL> list)
        {
            decimal debitSum = 0, creditSum = 0, Balance = 0, Opening = 0;
            string desc = string.Empty;
            if (DgvLedger.Rows.Count > 0)
            {
                DgvLedger.Rows.Clear();
                txtDebit.Text = string.Empty;
                txtCredit.Text = string.Empty;
                txtBalance.Text = string.Empty;
                txtOpening.Text = string.Empty;
                txtBalanceType.Text = string.Empty;
            }
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    DgvLedger.Rows.Add();
                    DgvLedger.Rows[i].Cells[0].Value = list[i].VoucherNo;
                    if (list[i].VoucherType == "OpeningBalance")
                    {
                        DgvLedger.Rows[i].Cells[1].Value = "OB";
                    }
                    else if (list[i].VoucherType == "CashReceiptVoucher")
                    {
                        DgvLedger.Rows[i].Cells[1].Value = "CRV";
                    }
                    else if (list[i].VoucherType == "SaleInvoiceVoucher")
                    {
                        DgvLedger.Rows[i].Cells[1].Value = "Invoice";
                    }
                    else if (list[i].VoucherType == "PaymentVoucher")
                    {
                        DgvLedger.Rows[i].Cells[1].Value = "CPV";
                    }
                    else if (list[i].VoucherType == "StockReceiptVoucher")
                    {
                        DgvLedger.Rows[i].Cells[1].Value = "STV";
                    }
                    else if (list[i].VoucherType == "StockReceiptVoucher/Sub")
                    {
                        DgvLedger.Rows[i].Cells[1].Value = "STV";
                    }
                    else if (list[i].VoucherType == "SalesReturnVoucher")
                    {
                        DgvLedger.Rows[i].Cells[1].Value = "SRV";
                    }
                    else if (list[i].VoucherType == "PrescriberSampleVoucher")
                    {
                        DgvLedger.Rows[i].Cells[1].Value = "PSV";
                    }
                    else if (list[i].VoucherType == "BankReceiptVoucher")
                    {
                        DgvLedger.Rows[i].Cells[1].Value = "BRV";
                    }
                    else if (list[i].VoucherType == "BankPaymentVoucher")
                    {
                        DgvLedger.Rows[i].Cells[1].Value = "BPV";
                    }
                    else if (list[i].VoucherType == "JournalVoucher")
                    {
                        DgvLedger.Rows[i].Cells[1].Value = "JV";
                    }
                    else if (list[i].VoucherType == "WorkPurchaseVoucher")
                    {
                        DgvLedger.Rows[i].Cells[1].Value = "WP";
                    }
                    DgvLedger.Rows[i].Cells[2].Value = list[i].Date.ToShortDateString();
                    if (list[i].VoucherType == "")
                    {
                        DgvLedger.Rows[i].Cells[3].Value = ReBuildRemarks(list[i].Description); //list[i].Description;
                    }
                    else
                    {
                        DgvLedger.Rows[i].Cells[3].Value = list[i].Description;
                    }
                    if (chkCompleteLedger.Checked == false)
                    {
                        DgvLedger.Rows[i].Cells[4].Value = list[i].OpeningBalance;
                    }
                    DgvLedger.Rows[i].Cells[5].Value = list[i].Debit;
                    DgvLedger.Rows[i].Cells[6].Value = Math.Abs(list[i].Credit);
                    
                    debitSum += list[i].Debit;
                    creditSum += Math.Abs(list[i].Credit);

                    if (DgvLedger.Rows[i].Cells[4].Visible)
                    {
                        Opening += list[i].OpeningBalance;
                        if (list[i].IdHead == 1)
                        {
                            if (Opening < 0)
                            {
                                Balance = (Math.Abs(Opening) + creditSum) - debitSum;
                                DgvLedger.Rows[i].Cells[7].Style.ForeColor = Color.Red;
                                desc = "CR";
                            }
                            else
                            {
                                Balance = (Opening - creditSum) + debitSum;
                                DgvLedger.Rows[i].Cells[7].Style.ForeColor = Color.Black;
                                desc = "DR";
                            }
                        }
                        else if (list[i].IdHead == 2)
                        {
                            if (Opening < 0)
                            {
                                Balance = (Opening + debitSum) - creditSum;
                                DgvLedger.Rows[i].Cells[7].Style.ForeColor = Color.Red;
                                if (debitSum > 0)
                                {
                                    DgvLedger.Rows[i].Cells[7].Style.ForeColor = Color.Black;
                                }
                            }
                            else if (Opening == 0)
                            {
                                Balance = (Opening + debitSum) - creditSum;
                                DgvLedger.Rows[i].Cells[7].Style.ForeColor = Color.Red;
                                if (debitSum > 0)
                                {
                                    DgvLedger.Rows[i].Cells[7].Style.ForeColor = Color.Black;
                                }
                            }
                            else
                            {
                                Balance = (Opening - debitSum) + creditSum;
                                if (Balance < 0)
                                {
                                    DgvLedger.Rows[i].Cells[7].Style.ForeColor = Color.Black;
                                }
                                else
                                {
                                    DgvLedger.Rows[i].Cells[7].Style.ForeColor = Color.Red;
                                }

                            }
                            //DgvLedger.Rows[i].Cells[7].Style.ForeColor = Color.Red;
                        }
                        else if (list[i].IdHead == 3)
                        {
                            Balance = (Opening + debitSum) - creditSum;
                        }
                        else if (list[i].IdHead == 4)
                        {
                            Balance = (Opening + creditSum) - debitSum;
                        }
                        else if (list[i].IdHead == 5)
                        {
                            Balance = (Opening + debitSum) - creditSum;
                        }
                    }
                    else
                    {
                        if (debitSum > creditSum)
                        {
                            Balance = debitSum - creditSum;
                        }
                        else
                        {
                            Balance = creditSum - debitSum;
                            DgvLedger.Rows[i].Cells[7].Style.ForeColor = Color.Red;
                        }
                    }
                    DgvLedger.Rows[i].Cells[7].Value = Balance;

                    if (Math.Abs(Balance) == 0)
                    {
                        DgvLedger.Rows[i].Cells[8].Value = "Equals";
                    }
                    else
                    {
                        if (list[i].IdHead == 1)
                        {
                            if (Balance > 0)
                            {
                                DgvLedger.Rows[i].Cells[8].Value = "DR"; //list[i].TransactionType.ToUpper();   
                            }
                            if (Balance < 0)
                            {
                                DgvLedger.Rows[i].Cells[8].Value = "CR"; //list[i].TransactionType.ToUpper();   
                            }
                        }
                        else if (list[i].IdHead == 2)
                        {
                            if (Balance > 0)
                            {
                                DgvLedger.Rows[i].Cells[8].Value = "CR"; //list[i].TransactionType.ToUpper();   
                            }
                            if (Balance < 0)
                            {
                                DgvLedger.Rows[i].Cells[8].Value = "DR"; //list[i].TransactionType.ToUpper();   
                            }
                        }
                        else if (list[i].IdHead == 3)
                        {
                            if (Balance > 0)
                            {
                                DgvLedger.Rows[i].Cells[8].Value = "DR"; //list[i].TransactionType.ToUpper();   
                            }
                            if (Balance < 0)
                            {
                                DgvLedger.Rows[i].Cells[8].Value = "CR"; //list[i].TransactionType.ToUpper();   
                            }
                        }
                        else if (list[i].IdHead == 4)
                        {
                            if (Balance > 0)
                            {
                                DgvLedger.Rows[i].Cells[8].Value = "CR"; //list[i].TransactionType.ToUpper();   
                            }
                            if (Balance < 0)
                            {
                                DgvLedger.Rows[i].Cells[8].Value = "DR"; //list[i].TransactionType.ToUpper();   
                            }
                        }
                        else if (list[i].IdHead == 5)
                        {
                            if (Balance > 0)
                            {
                                DgvLedger.Rows[i].Cells[8].Value = "DR"; //list[i].TransactionType.ToUpper();   
                            }
                            if (Balance < 0)
                            {
                                DgvLedger.Rows[i].Cells[8].Value = "CR"; //list[i].TransactionType.ToUpper();   
                            }
                        }
                       
                    }
                }
                txtDebit.Text = list.Sum(x => x.Debit).ToString();
                txtCredit.Text = list.Sum(x => Math.Abs(x.Credit)).ToString();
                if (DgvLedger.Columns[4].Visible)
                {
                    txtOpening.Text = list.Sum(x => Math.Abs(x.OpeningBalance)).ToString();
                    if (list[0].IdHead == 1)
                    {
                        if (Opening > 0)
                        {
                            txtBalance.Text = ((Opening + debitSum) - creditSum).ToString();
                            txtBalanceType.Text = "DR";
                        }
                        else if (Opening < 0)
                        {
                            txtBalance.Text = ((Math.Abs(Opening) + creditSum) - debitSum).ToString();
                            txtBalanceType.Text = "CR";
                        }
                        else if (Opening == 0)
                        {
                            if (debitSum > creditSum)
                            {
                                txtBalance.Text = ((Opening + debitSum) - creditSum).ToString();
                                txtBalanceType.Text = "DR";
                            }
                            else
                            {
                                txtBalance.Text = ((Math.Abs(Opening) + creditSum) - debitSum).ToString();
                                txtBalanceType.Text = "CR";
                            }
                        }
                    }
                    else if (list[0].IdHead == 2)
                    {
                        if (Opening > 0)
                        {
                            txtBalance.Text = ((Opening + creditSum) - debitSum).ToString();
                            txtBalanceType.Text = "CR";
                        }
                        else if (Opening < 0)
                        {
                            txtBalance.Text = ((Math.Abs(Opening) + creditSum) - debitSum).ToString();
                            txtBalanceType.Text = "DR";
                        }
                        else if (Opening == 0)
                        {
                            if (creditSum > debitSum)
                            {
                                txtBalance.Text = ((Opening + creditSum) - debitSum).ToString();
                                txtBalanceType.Text = "CR";
                            }
                            else
                            {
                                txtBalance.Text = ((Math.Abs(Opening) + debitSum) - creditSum).ToString();
                                txtBalanceType.Text = "DR";
                            }
                        }
                    }
                    else if (list[0].IdHead == 3)
                    {
                        txtBalance.Text = ((Math.Abs(Opening) + debitSum) - creditSum).ToString();
                        txtBalanceType.Text = "DR";
                    }
                    else if (list[0].IdHead == 4)
                    {
                        txtBalance.Text = ((Math.Abs(Opening) + creditSum) - debitSum).ToString();
                        txtBalanceType.Text = "CR";
                    }
                    else if (list[0].IdHead == 5)
                    {
                        txtBalance.Text = ((Math.Abs(Opening) + debitSum) - creditSum).ToString();
                        txtBalanceType.Text = "DR";
                    }
                }
                else
                {
                    if (Convert.ToDecimal(txtDebit.Text) > Convert.ToDecimal(txtCredit.Text))
                    {
                        txtBalance.Text = (Convert.ToDecimal(txtDebit.Text) - Convert.ToDecimal(txtCredit.Text)).ToString();
                        txtBalanceType.Text = "DR";
                    }
                    else if (Convert.ToDecimal(txtCredit.Text) > Convert.ToDecimal(txtDebit.Text))
                    {
                        txtBalance.Text = (Convert.ToDecimal(txtCredit.Text) - Convert.ToDecimal(txtDebit.Text)).ToString();
                        txtBalanceType.Text = "CR";
                    }
                    else if (Convert.ToDecimal(txtCredit.Text) == Convert.ToDecimal(txtDebit.Text))
                    {
                        txtBalance.Text = "0.00";
                        txtBalanceType.Text = "Equals";
                    }
                }
            }
        }
        private string ReBuildRemarks(string Description)
        {
            string[] SplitedRemarks = Description.Split('*');
            string FinalRemarks = "";
            for (int i = 0; i < SplitedRemarks.Length; i++)
            {
                FinalRemarks += SplitedRemarks[i] + Environment.NewLine;
            }
            return FinalRemarks;
        }
        #region Custom Controls Events And Methods
        private void AccEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (AccEditBox.Text != string.Empty)
                {
                    StartDate.Focus();
                }
            }
            else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                e.Handled = true;
                ClearControls();
                frmledgerAccounts = new frmFindAccounts();
                frmledgerAccounts.SearchText = e.KeyChar.ToString();
                frmledgerAccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmledgerAccounts_ExecuteFindAccountEvent);
                frmledgerAccounts.ShowDialog();

            }
            else
                e.Handled = false;
        }
        void frmledgerAccounts_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            AccountNo = oelAccount.AccountNo;
            AccEditBox.Text = oelAccount.AccountName;
        }
        #endregion
        private void AccEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmledgerAccounts = new frmFindAccounts();
            frmledgerAccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmledgerAccounts_ExecuteFindAccountEvent);
            frmledgerAccounts.ShowDialog();
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (AccEditBox.Text != string.Empty)
            {

                frmledgerreport = new frmLedgerreport();
                frmledgerreport.AccountNo = AccountNo;
                if (chkCompleteLedger.Checked)
                {
                    frmledgerreport.ReportType = "LederReport";
                }
                else
                {
                    frmledgerreport.ReportType = "DateWiseLederReport";
                    frmledgerreport.StartDate = Convert.ToDateTime(StartDate.Value.ToShortDateString());
                    frmledgerreport.EndDate = Convert.ToDateTime(EndDate.Value.ToShortDateString());
                }
                //if (AccountType == "Accounts Receivables")
                //{
                //    /// Send Customers Here....
                //    frmledgerreport.ReportType = "Persons";
                //}
                //else if (AccountType == "Accounts Payables")
                //{
                //    /// Send Suppliers Here....
                //    frmledgerreport.ReportType = "Persons";
                //}
                //else if (AccountType == "Cash & Bank Balances")
                //{
                //    /// Send Cash Here....
                //    frmledgerreport.ReportType = "Cash";
                //}
                frmledgerreport.Show();
            }
            else
            {
                MessageBox.Show("Select Suppliers, Customers OR Cash For Ledger");
            }
        }
        private void chkCompleteLedger_CheckedChanged(object sender, EventArgs e)
        {
            ClearControls();
            if (chkCompleteLedger.Checked)
            {
                DgvLedger.Columns[4].Visible = false;
                txtOpening.Visible = false;
            }
            else
            {
                DgvLedger.Columns[4].Visible = true;
                txtOpening.Visible = true;
            }
            CreateAndInitializeFooterRow();
        }
        private void ClearControls()
        {
            txtOpening.Clear();
            txtDebit.Clear();
            txtCredit.Clear();
            txtBalance.Clear();
            txtBalanceType.Clear();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (DgvLedger.Rows.Count > 0)
            {
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in DgvLedger.Columns)
                {
                    if (column.Visible)
                    {
                        dt.Columns.Add(column.HeaderText);
                    }
                }

                //Add Header Rows....
                dt.Rows.Add();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Rows[0][i] = dt.Columns[i].ColumnName; //"Account Name"; 
                }

                // Add Empty Row....
                dt.Rows.Add();
                for (int i = 0; i < DgvLedger.Columns.Count; i++)
                {
                    if (i != dt.Columns.Count)
                    {
                        dt.Rows[1][i] = "";
                    }
                    else
                    {
                        break;
                    }
                }

                foreach (DataGridViewRow row in DgvLedger.Rows)
                {
                    dt.Rows.Add();
                    int colindex = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Visible)
                            {
                                //dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                                dt.Rows[dt.Rows.Count - 1][colindex] = cell.Value.ToString();
                                colindex++;
                            }
                        }
                    }
                }

                SLDocument slExcelExport = new SLDocument();


                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    slExcelExport.SetColumnWidth(i, 20);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        slExcelExport.SetCellValue(j + 1, i + 1, dt.Rows[j].ItemArray[i].ToString());
                    }
                }
                slExcelExport.Save();

                Process.Start("Book1.xlsx");
            }
        }
    }
}
