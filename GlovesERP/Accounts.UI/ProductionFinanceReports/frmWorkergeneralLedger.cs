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
    public partial class frmWorkergeneralLedger : MetroForm
    {
        TextBox txtOpening = new TextBox();
        TextBox txtDebit = new TextBox();
        TextBox txtCredit = new TextBox();
        TextBox txtBalance = new TextBox();
        TextBox txtBalanceType = new TextBox();
        Label labelDgv1 = new Label();
        Panel pnlAmountSum = new Panel();
        frmFindAccounts frmledgerAccounts;
        frmLedgerreport frmledgerreport;
        string AccountType, AccountNo = "";
        string WorkType = string.Empty;
        public frmWorkergeneralLedger()
        {
            InitializeComponent();

        }
        private void frmgeneralLedger_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
            pnlAmountSum.Width = this.DgvLedger.Columns[6].Width + Xdgv1;
            pnlAmountSum.Location = new Point(0, this.DgvLedger.Height - txtDebit.Height);

            this.DgvLedger.Controls.Add(pnlAmountSum);

            int Xdgvx0 = this.DgvLedger.GetCellDisplayRectangle(2, -1, true).Location.X;


            txtOpening.Width = this.DgvLedger.Columns[2].Width;

            txtOpening.Location = new Point(Xdgvx0, DgvLedger.Height - txtOpening.Height);

            this.DgvLedger.Controls.Add(txtOpening);


            int Xdgvx1 = this.DgvLedger.GetCellDisplayRectangle(3, -1, true).Location.X;


            txtDebit.Width = this.DgvLedger.Columns[3].Width;

            txtDebit.Location = new Point(Xdgvx1, DgvLedger.Height - txtDebit.Height);

            this.DgvLedger.Controls.Add(txtDebit);


            int Xdgvx2 = DgvLedger.GetCellDisplayRectangle(4, -1, true).Location.X;
            txtCredit.Width = this.DgvLedger.Columns[4].Width;
            txtCredit.Location = new Point(Xdgvx2, DgvLedger.Height - txtCredit.Height);
            this.DgvLedger.Controls.Add(txtCredit);

            int Xdgvx3 = DgvLedger.GetCellDisplayRectangle(5, -1, true).Location.X;
            txtBalance.Width = this.DgvLedger.Columns[5].Width;
            txtBalance.Location = new Point(Xdgvx3, DgvLedger.Height - txtBalance.Height);
            DgvLedger.Controls.Add(txtBalance);

            int Xdgvx4 = DgvLedger.GetCellDisplayRectangle(6, -1, true).Location.X;
            txtBalanceType.Width = this.DgvLedger.Columns[6].Width;
            txtBalanceType.Location = new Point(Xdgvx4, DgvLedger.Height - txtBalanceType.Height);
            DgvLedger.Controls.Add(txtBalanceType);

            pnlAmountSum.SendToBack();


        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var Pmanager = new PersonsBLL();
            var TManager = new TransactionBLL();
            List<PersonsEL> oelPerson = Pmanager.GetPersonByAccount(Operations.IdCompany, AccountNo);
            List<TransactionsEL> list = new List<TransactionsEL>();
            if (oelPerson != null && oelPerson.Count > 0)
            {
                if (oelPerson[0].IdDepartment == Guid.Empty)
                {
                    MessageBox.Show("Person Does not have any department....");
                    return;
                }
                else
                {
                    var DManager = new ProcessesBLL();
                    List<ProcessesEL> lstDepart = DManager.GetProcessById(oelPerson[0].IdDepartment);
                    if (lstDepart.Count > 0)
                    {
                        WorkType = lstDepart[0].ProcessName;
                    }
                    else
                    {
                        MessageBox.Show("No Department Found");
                        return;
                    }
                    if (WorkType == "Drumming" || WorkType == "Buffing" || WorkType == "Cutting")
                    {
                        if (chkCompleteLedger.Checked) /// Complete Business Ledger
                        {
                            list = TManager.GetWorkerCompleteLedger(AccountNo, WorkType, lstDepart[0].ProcessType);
                            if (list.Count > 0)
                            {
                                PopulateLedger(list);
                            }
                        }
                        else
                        {
                            list = TManager.GetDateWiseWorkerLedger(AccountNo, WorkType, lstDepart[0].ProcessType, Convert.ToDateTime(StartDate.Value), Convert.ToDateTime(EndDate.Value));
                            if (list.Count > 0)
                            {
                                PopulateLedger(list);
                            }
                        }
                    }
                    else
                    {
                        if (chkCompleteLedger.Checked) /// Complete Business Ledger
                        {
                            list = TManager.GetWorkerCompleteLedger(AccountNo, WorkType, lstDepart[0].ProcessType);
                            if (list.Count > 0)
                            {
                                PopulateLedger(list);
                            }
                        }
                        else
                        {
                            list = TManager.GetDateWiseWorkerLedger(AccountNo, WorkType, lstDepart[0].ProcessType, Convert.ToDateTime(StartDate.Value), Convert.ToDateTime(EndDate.Value));
                            if (list.Count > 0)
                            {
                                PopulateLedger(list);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record Or Department Found...");
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

                    DgvLedger.Rows[i].Cells[0].Value = list[i].Date.ToShortDateString();
                    DgvLedger.Rows[i].Cells[1].Value = list[i].Description;

                    if (chkCompleteLedger.Checked == false)
                    {
                        DgvLedger.Rows[i].Cells[2].Value = Math.Abs(list[i].OpeningBalance);
                    }
                    DgvLedger.Rows[i].Cells[3].Value = list[i].Debit;
                    DgvLedger.Rows[i].Cells[4].Value = Math.Abs(list[i].Credit);

                    debitSum += list[i].Debit;
                    creditSum += Math.Abs(list[i].Credit);

                    if (DgvLedger.Rows[i].Cells[2].Visible)
                    {
                        Opening += list[i].OpeningBalance;
                        if (Opening > 0)
                        {
                            Balance = (Math.Abs(Opening) + creditSum) - debitSum;
                            //DgvLedger.Rows[i].Cells[7].Style.ForeColor = Color.Red;
                            desc = "CR";
                        }
                        else
                        {
                            Balance = (Opening + debitSum) - creditSum;
                            //DgvLedger.Rows[i].Cells[7].Style.ForeColor = Color.Black;
                            desc = "DR";
                        }
                    }
                    else
                    {
                        //if (debitSum > creditSum)
                        //{
                        //    Balance = debitSum - creditSum;
                        //}
                        //else
                        //{
                        //    Balance = creditSum - debitSum;
                        //    //DgvLedger.Rows[i].Cells[5].Style.ForeColor = Color.Red;
                        //}
                        Balance = debitSum - creditSum;                           
                    }
                    DgvLedger.Rows[i].Cells[5].Value = Math.Abs(Balance);

                    if (Math.Abs(Balance) == 0)
                    {
                        DgvLedger.Rows[i].Cells[6].Value = "Equals";
                    }
                    else
                    {
                        if (DgvLedger.Rows[i].Cells[2].Visible)
                        {
                            if (Balance > 0)
                            {
                                DgvLedger.Rows[i].Cells[6].Value = "CR"; //list[i].TransactionType.ToUpper();   
                            }
                            if (Balance < 0)
                            {
                                DgvLedger.Rows[i].Cells[6].Value = "DR"; //list[i].TransactionType.ToUpper();   
                            }
                        }
                        else
                        {
                            //DgvLedger.Rows[i].Cells[6].Value = list[i].TransactionType.ToUpper();
                            if (Balance > 0)
                            {
                                DgvLedger.Rows[i].Cells[6].Value = "DR"; //list[i].TransactionType.ToUpper();   
                            }
                            if (Balance < 0)
                            {
                                DgvLedger.Rows[i].Cells[6].Value = "CR"; //list[i].TransactionType.ToUpper();   
                            }
                        }
                    }
                }
                txtDebit.Text = list.Sum(x => x.Debit).ToString();
                txtCredit.Text = list.Sum(x => Math.Abs(x.Credit)).ToString();
                if (DgvLedger.Columns[2].Visible)
                {
                    txtOpening.Text = list.Sum(x => Math.Abs(x.OpeningBalance)).ToString();
                    if (Opening > 0)
                    {
                        txtBalance.Text = Math.Abs(((Math.Abs(Opening) + creditSum) - debitSum)).ToString();
                        txtBalanceType.Text = "DR";
                    }
                    else if (Opening < 0)
                    {
                        txtBalance.Text = ((Opening + debitSum) - creditSum).ToString();
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
        private void AccEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmledgerAccounts = new frmFindAccounts();
            frmledgerAccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmledgerAccounts_ExecuteFindAccountEvent);
            frmledgerAccounts.ShowDialog();
        }
        void frmledgerAccounts_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            AccEditBox.Text = oelAccount.AccountName;
            AccountNo = oelAccount.AccountNo;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (AccEditBox.Text != string.Empty)
            {

                frmledgerreport = new frmLedgerreport();
                frmledgerreport.AccountNo = AccEditBox.Text;
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
            if (DgvLedger.Rows.Count > 0)
            {
                DgvLedger.Rows.Clear();
            }
            if (chkCompleteLedger.Checked)
            {
                DgvLedger.Columns[2].Visible = false;
                txtOpening.Visible = false;
            }
            else
            {
                DgvLedger.Columns[2].Visible = true;
                txtOpening.Visible = true;
            }
            ClearControls();
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
