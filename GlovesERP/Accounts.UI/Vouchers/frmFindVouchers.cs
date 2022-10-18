using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.EL;
using Accounts.BLL;
using Accounts.Common;
using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmFindVouchers : MetroForm
    {
        VouchersEL elVoucher = null;
        public delegate void VouchersDelegate(VouchersEL oelVoucher);
        public event VouchersDelegate ExecuteFindVouchersEvent;
        frmFindAccounts frmAccount;
        public string VoucherType
        {
            get;
            set;
        }
        public frmFindVouchers()
        {
            InitializeComponent();
        }

        private void frmVouchers_Load(object sender, EventArgs e)
        {
            string seperatedName = "";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.DgvVoucher.AutoGenerateColumns = false;
            if (VoucherType == VoucherTypes.BankPaymentVoucher.ToString())
            {
                seperatedName = "Search Bank Payment Vouchers";
            }
            else if (VoucherType == VoucherTypes.BankReceiptVoucher.ToString())
            {
                seperatedName = "Search Bank Receipt Vouchers";
            }
            else if (VoucherType == VoucherTypes.PaymentVoucher.ToString())
            {
                seperatedName = "Search Cash Payment Vouchers";
            }
            else if (VoucherType == VoucherTypes.CashReceiptVoucher.ToString())
            {
                seperatedName = "Search Cash Receipt Vouchers";
            }
            else if (VoucherType == VoucherTypes.SaleInvoiceVoucher.ToString())
            {
                seperatedName = "Search Invoice Vouchers";
            }
            else if (VoucherType == VoucherTypes.SalesReturnVoucher.ToString())
            {
                seperatedName = "Search Return Vouchers";
            }
            else if (VoucherType == VoucherTypes.JournalVoucher.ToString())
            {
                seperatedName = "Search Journal Vouchers";
            }
            this.Text = seperatedName;
            CreateVoucherWiseColumns();
            BindVouchersByDate(Convert.ToDateTime(DateTime.Now.ToShortDateString()));
        }
        private void CreateVoucherWiseColumns()
        {
            DataGridViewTextBoxColumn colIdVoucher = new DataGridViewTextBoxColumn();
            colIdVoucher.HeaderText = "IdVoucher";
            colIdVoucher.Name = "colIdVoucher";
            colIdVoucher.Width = 100;
            colIdVoucher.DataPropertyName = "IdVoucher";
            colIdVoucher.Visible = false;
            this.DgvVoucher.Columns.Add(colIdVoucher);

            DataGridViewTextBoxColumn colVoucherNo = new DataGridViewTextBoxColumn();
            colVoucherNo.HeaderText = "VoucherNo. #";
            colVoucherNo.Name = "colVoucherNo";
            colVoucherNo.Width = 100;
            colVoucherNo.DataPropertyName = "VoucherNo";
            this.DgvVoucher.Columns.Add(colVoucherNo);

            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
            colDate.HeaderText = "Date";
            colDate.Name = "colDate";
            colDate.DataPropertyName = "Date";
            this.DgvVoucher.Columns.Add(colDate);

            DataGridViewTextBoxColumn colVoucherType = new DataGridViewTextBoxColumn();
            colVoucherType.HeaderText = "VoucherType";
            colVoucherType.Name = "colVoucherType";
            colVoucherType.DataPropertyName = "VoucherType";
            this.DgvVoucher.Columns.Add(colVoucherType);

            DataGridViewTextBoxColumn colHead = new DataGridViewTextBoxColumn();
            if (VoucherType == "StockReceiptVoucher")
            {
                //colHead.HeaderText = "Supplier";
                colHead.DataPropertyName = "AccountNo";
            }
            //else if (VoucherType == "PaymentVoucher")
            //{
            //    //colHead.HeaderText = "Account";
            //    colHead.DataPropertyName = "AccountNo";
            //}
            //else if (VoucherType == "CashReceiptVoucher")
            //{
            //    //colHead.HeaderText = "Head";
            //    colHead.DataPropertyName = "AccountNo";
            //}
            else if (VoucherType == "SaleInvoiceVoucher")
            {
                //colHead.HeaderText = "Head";
                colHead.DataPropertyName = "AccountNo";

            }
            else if (VoucherType == "SalesReturnVoucher")
            {
                colHead.HeaderText = "Head";
                colHead.DataPropertyName = "AccountNo";
            }
            //else if (VoucherType == "BankPaymentVoucher")
            //{
            //    colHead.DataPropertyName = "AccountNo";
            //}
            //else if (VoucherType == "BankReceiptVoucher")
            //{
            //    colHead.DataPropertyName = "AccountNo";
            //}
            else if (VoucherType == "PrescriberSampleVoucher")
            {
                colHead.DataPropertyName = "AccountNo";
            }
            colHead.HeaderText = "Head A/C";
            colHead.Name = "HeadAC";
            this.DgvVoucher.Columns.Add(colHead);

            DataGridViewTextBoxColumn colHeadName = new DataGridViewTextBoxColumn();
            colHeadName.DataPropertyName = "AccountName";
            colHeadName.HeaderText = "Head Name";
            colHeadName.Name = "HeadName";
            colHeadName.Width = 200;
            this.DgvVoucher.Columns.Add(colHeadName);


            DataGridViewTextBoxColumn colBill = new DataGridViewTextBoxColumn();
            if (VoucherType == "CashReceiptVoucher")
            {
                colBill.HeaderText = "Bill. #";
            }
            else
            {
                colBill.HeaderText = "Invoce. #";
            }

            colBill.Name = "colBill";
            colBill.Width = 50;
            colBill.DataPropertyName = "BillNo";
            this.DgvVoucher.Columns.Add(colBill);
            if (VoucherType == "PaymentVoucher" || VoucherType == "CashReceiptVoucher" || VoucherType == "SaleInvoiceVoucher" || VoucherType == "BankPaymentVoucher" || VoucherType == "BankReceiptVoucher" || VoucherType == "PrescriberSampleVoucher" || VoucherType == "JournalVoucher")
            {
                colBill.Visible = false;
            }
            else
            {
                colBill.Visible = true;
            }


            DataGridViewTextBoxColumn colAmount = new DataGridViewTextBoxColumn();
            colAmount.HeaderText = "Amount";
            colAmount.Name = "colAmount";
            colAmount.DataPropertyName = "Amount";
            colAmount.Width = 75;
            this.DgvVoucher.Columns.Add(colAmount);

            DataGridViewCheckBoxColumn colPosted = new DataGridViewCheckBoxColumn();
            colPosted.HeaderText = "Posted";
            colPosted.Name = "colPosted";
            colPosted.DataPropertyName = "Posted";
            colPosted.Width = 75;
            this.DgvVoucher.Columns.Add(colPosted);
        }
        private void BindVouchersByDate(DateTime VoucherDate)
        {
            var manager = new VoucherBLL();
            List<VouchersEL> list = manager.GetVouchersByTypeAndDate(Operations.IdCompany, VoucherType, VoucherDate);
            DgvVoucher.DataSource = list;
        }
        private void BindVouchersByVoucherNo()
        {
            var manager = new VoucherBLL();
            if (txtVoucherNo.Text != string.Empty)
            {
                List<VouchersEL> list = manager.GetVouchersByTypeAndVoucherNumber(Operations.IdCompany, VoucherType, Convert.ToInt64(txtVoucherNo.Text));
                DgvVoucher.DataSource = list;
            }
            else
            {
                MessageBox.Show("Voucher Number Is Missing In Field...");
            }
        }
        private void BindVouchersByAccountNo()
        {
            var manager = new VoucherBLL();
            if (AcEditBox.Text != string.Empty)
            {
                List<VouchersEL> list = manager.GetVouchersByTypeAndAccountNo(Operations.IdCompany, VoucherType, AcEditBox.Text);
                DgvVoucher.DataSource = list;
            }
            else
            {
                MessageBox.Show("Account Number Is Missing In Field...");
            }
        }
        private void BindAllVouchersByType()
        {
            var manager = new VoucherBLL();

            List<VouchersEL> list = manager.GetAllVouchersByType(Operations.IdCompany, VoucherType);
            if (list.Count > 0)
            {
                DgvVoucher.DataSource = list;
            }
            else
            {
                MessageBox.Show("Not Record Found...");
            }

        }
        private void DgvVoucher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvVoucher.CurrentRow != null)
            {
                int RowIndex = DgvVoucher.CurrentRow.Index;

                elVoucher = new VouchersEL();

                elVoucher.IdVoucher = Validation.GetSafeGuid(DgvVoucher.Rows[RowIndex].Cells[0].Value);
                elVoucher.VoucherNo = Convert.ToInt64(DgvVoucher.Rows[RowIndex].Cells[1].Value);
                elVoucher.Date = Convert.ToDateTime(DgvVoucher.Rows[RowIndex].Cells[2].Value);
                //elVoucher.PersonName = Row.Cells[2].Value.ToString();
                if (VoucherType != "PaymentVoucher" && VoucherType != "CashReceiptVoucher" && VoucherType != "SaleInvoiceVoucher" && VoucherType != "SalesReturnVoucher" && VoucherType != "BankPaymentVoucher" && VoucherType != "BankReceiptVoucher" && VoucherType != "PrescriberSampleVoucher" && VoucherType != "JournalVoucher")
                {
                    elVoucher.BillNo = DgvVoucher.Rows[RowIndex].Cells[6].Value.ToString();
                    elVoucher.AccountNo = Validation.GetSafeString(DgvVoucher.Rows[RowIndex].Cells[4].Value);
                }
                else
                {
                    DgvVoucher.Columns[6].Visible = false;
                    elVoucher.AccountNo = Validation.GetSafeString(DgvVoucher.Rows[RowIndex].Cells[4].Value);
                }
                elVoucher.Amount = Convert.ToDecimal(DgvVoucher.Rows[RowIndex].Cells[7].Value);
                elVoucher.Posted = Convert.ToBoolean(DgvVoucher.Rows[RowIndex].Cells[8].Value);

                this.Close();
            }
        }
        private void frmVouchers_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (elVoucher != null)
            {
                ExecuteFindVouchersEvent(elVoucher);
            }
        }
        private void DgvVoucher_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            elVoucher = new VouchersEL();

            elVoucher.IdVoucher = Validation.GetSafeGuid(DgvVoucher.Rows[e.RowIndex].Cells[0].Value);
            elVoucher.VoucherNo = Convert.ToInt64(DgvVoucher.Rows[e.RowIndex].Cells[1].Value);
            elVoucher.Date = Convert.ToDateTime(DgvVoucher.Rows[e.RowIndex].Cells[2].Value);
            //elVoucher.PersonName = Row.Cells[2].Value.ToString();
            if (VoucherType != "PaymentVoucher" && VoucherType != "CashReceiptVoucher" && VoucherType != "SaleInvoiceVoucher" && VoucherType != "SalesReturnVoucher" && VoucherType != "BankPaymentVoucher" && VoucherType != "BankReceiptVoucher" && VoucherType != "PrescriberSampleVoucher" && VoucherType != "JournalVoucher")
            {
                elVoucher.BillNo = DgvVoucher.Rows[e.RowIndex].Cells[6].Value.ToString();
                elVoucher.AccountNo = Validation.GetSafeString(DgvVoucher.Rows[e.RowIndex].Cells[4].Value);
            }
            else
            {
                DgvVoucher.Columns[6].Visible = false;
                elVoucher.AccountNo = Validation.GetSafeString(DgvVoucher.Rows[e.RowIndex].Cells[4].Value);
            }
            elVoucher.Amount = Validation.GetSafeDecimal(DgvVoucher.Rows[e.RowIndex].Cells[7].Value);
            elVoucher.Posted = Convert.ToBoolean(DgvVoucher.Rows[e.RowIndex].Cells[8].Value);

            this.Close();

        }

        private void chkVoucher_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk.Name == "chkVByDate")
            {
                if (chk.Checked)
                {
                    chkByVoucherNo.Checked = false;
                    chkVoucherByName.Checked = false;
                    chkAllVouchers.Checked = false;
                }
                else
                {
                    //chkByVoucherNo.Checked = true;
                    //chkVoucherByName.Checked= true;
                }
            }
            else if (chk.Name == "chkByVoucherNo")
            {
                if (chk.Checked)
                {
                    chkVByDate.Checked = false;
                    chkVoucherByName.Checked = false;
                    chkAllVouchers.Checked = false;
                }
                else
                {
                    //chkVByDate.Checked = true;
                    //chkVoucherByName.Checked = true;
                }
            }
            else if (chk.Name == "chkVoucherByName")
            {
                if (chk.Checked)
                {
                    chkByVoucherNo.Checked = false;
                    chkVByDate.Checked = false;
                    chkAllVouchers.Checked = false;
                }
                else
                {
                    //chkByVoucherNo.Checked = true;
                    //chkVByDate.Checked = true;
                }
            }
            else if (chk.Name == "chkAllVouchers")
            {
                if (chk.Checked)
                {
                    chkByVoucherNo.Checked = false;
                    chkVByDate.Checked = false;
                    chkVoucherByName.Checked = false;
                }
                else
                {
                    //chkByVoucherNo.Checked = true;
                    //chkVByDate.Checked = true;
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (chkVByDate.Checked)
            {
                BindVouchersByDate(Convert.ToDateTime(dtVouchers.Value.ToString("yyyy/MM/dd")));
            }
            else if (chkByVoucherNo.Checked)
            {
                BindVouchersByVoucherNo();
            }
            else if (chkVoucherByName.Checked)
            {
                BindVouchersByAccountNo();
            }
            else if (chkAllVouchers.Checked)
            {
                BindAllVouchersByType();
            }

        }
        private void AcEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }

        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            AcEditBox.Text = Validation.GetSafeString(oelAccount.AccountNo);
        }
    }
}
