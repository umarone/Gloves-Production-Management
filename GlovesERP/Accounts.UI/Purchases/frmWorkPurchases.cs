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
    public partial class frmWorkPurchases : MetroForm
    {
        public string ProductionType { get; set; }
        public string PurchasesType { get; set; }
        public string ProcessName { get; set; }
        public string EmpAccountNo { get; set; }
        public string EmpAccountName { get; set; }
        public decimal ProcessAmount { get; set; }
        public Int64 VoucherNo { get; set; }
        public Guid SupplierTransactionId { get; set; }
        public Guid PurchasesTransactionId { get; set; }
        public Guid IdEntity { get; set; }
        public bool IsInEditMode { get; set; }
        public Guid IdVoucher { get; set; }        
        public frmWorkPurchases()
        {
            InitializeComponent();
        }

        private void frmWorkPurchases_Load(object sender, EventArgs e)
        {
            if (!IsInEditMode)
            {
                this.Text = PurchasesType;
                IdVoucher = Guid.Empty;
            }
            else
            {
                this.Text = PurchasesType + " " + "Edit Mode" ;
            }
            FillData();
            FillNaturalAccounts("");
            if (!IsInEditMode)
            {
                cbxNaturalAccounts.DroppedDown = true;
                cbxNaturalAccounts.Focus();
            }
            BuildRemarks();
        }
        private void FillData()
        {
            var manager = new VoucherBLL();
            VEditBox.Text = manager.GetMaxVoucherNumber("WorkPurchaseVoucher", Operations.IdCompany);
            txtCreditAmount.Text = ProcessAmount.ToString();
        }
        private void FillNaturalAccounts(string AccountNo)
        {
            var manager = new AccountsBLL();
            List<AccountsEL> list = manager.GetAccountsByType("Cost of Sales", Operations.IdCompany);
            if (AccountNo == "")
            {
                if (list.Count > 0)
                {
                    cbxNaturalAccounts.DataSource = list;
                    list.Insert(0, new AccountsEL() { AccountNo = "0", AccountName = "" });

                    cbxNaturalAccounts.DisplayMember = "AccountName";
                    cbxNaturalAccounts.ValueMember = "AccountNo";
                }
            }
            else
            {
                cbxNaturalAccounts.SelectedValue = AccountNo;
            }
        }
        private void FillVoucher()
        {
            var Manager = new VoucherBLL();
            List<TransactionsEL> listTransactions = Manager.GetTransactions(IdVoucher, "WorkPurchaseVoucher", Operations.IdCompany);
            if (listTransactions.Count > 0)
            {
                TransactionsEL oelPurchaseTransaction = listTransactions.Find(x => x.Debit != 0);
                if (oelPurchaseTransaction != null)
                {
                    FillNaturalAccounts(oelPurchaseTransaction.AccountNo.ToString());
                    txtPurchasesAccountName.Text = oelPurchaseTransaction.AccountNo.ToString();
                    PurchasesTransactionId = oelPurchaseTransaction.TransactionID;
                }
                TransactionsEL oelVendorAccount = listTransactions.Find(x => x.Credit != 0);
                if (oelVendorAccount != null)
                {                  
                    EmpAccountNo = oelPurchaseTransaction.AccountNo;
                    SupplierTransactionId = oelVendorAccount.TransactionID;
                }
            }
        }
        private void BuildRemarks()
        {
            txtDescription.Text = PurchasesType + " from " + EmpAccountName + " At The Rate " + "@" + ProcessAmount;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            List<VoucherDetailEL> oelPurchaseDetailCollection = new List<VoucherDetailEL>();
            #region Voucher Head Entries
            VouchersEL oelVoucher = new VouchersEL();
            if (IdVoucher == Guid.Empty)
            {
                oelVoucher.IdVoucher = Guid.NewGuid();
            }
            else
            {
                oelVoucher.IdVoucher = IdVoucher;
            }
            oelVoucher.IdUser = Operations.UserID;
            oelVoucher.IdCompany = Operations.IdCompany;
            oelVoucher.VoucherNo = Convert.ToInt64(VEditBox.Text);
            oelVoucher.AccountNo = Validation.GetSafeString(EmpAccountNo);
            oelVoucher.Date = VDate.Value;
            oelVoucher.TotalAmount = ProcessAmount;
            oelVoucher.Posted = true;
            #endregion
            #region Add Supplier
            TransactionsEL oelSupplierTransaction = new TransactionsEL();
            VoucherDetailEL oelVoucherPurchaseDetail = new VoucherDetailEL();
            if (SupplierTransactionId != Guid.Empty)
            {
                oelSupplierTransaction.TransactionID = SupplierTransactionId;
                oelVoucherPurchaseDetail.IdVoucherDetail = SupplierTransactionId;
                oelSupplierTransaction.IsNew = false;
            }
            else
            {
                oelSupplierTransaction.TransactionID = Guid.NewGuid();
                oelVoucherPurchaseDetail.IdVoucherDetail = oelSupplierTransaction.TransactionID;
                oelSupplierTransaction.IsNew = true;
            }
            oelSupplierTransaction.IdCompany = Operations.IdCompany;
            oelVoucherPurchaseDetail.IdCompany = Operations.IdCompany;
            oelSupplierTransaction.AccountNo = Validation.GetSafeString(EmpAccountNo);
            oelVoucherPurchaseDetail.AccountNo = Validation.GetSafeString(EmpAccountNo);
            oelSupplierTransaction.LinkAccountNo = "";
            oelVoucherPurchaseDetail.LinkAccountNo = "";
            oelSupplierTransaction.Date = VDate.Value;
            oelSupplierTransaction.VoucherNo = Convert.ToInt32(VEditBox.Text);
            oelVoucherPurchaseDetail.IdVoucher = oelVoucher.IdVoucher;
            oelSupplierTransaction.IdVoucher = oelVoucher.IdVoucher;
            oelSupplierTransaction.VoucherType = "WorkPurchaseVoucher";
            oelSupplierTransaction.Description = txtDescription.Text;
            oelVoucherPurchaseDetail.Description = txtDescription.Text;
            oelVoucherPurchaseDetail.Amount = Validation.GetSafeDecimal(txtCreditAmount.Text);
            oelSupplierTransaction.Credit = Convert.ToDecimal(txtCreditAmount.Text);
            oelSupplierTransaction.Debit = 0;
            oelSupplierTransaction.Posted = true;
            oelTransactionCollection.Add(oelSupplierTransaction);
            oelPurchaseDetailCollection.Add(oelVoucherPurchaseDetail);
            #endregion
            #region Add Purchase Account In Transactions
            /// Add Purchase Account...
            TransactionsEL oelPurchaseTransaction = new TransactionsEL();
            VoucherDetailEL oelVoucherWorkPurchase = new VoucherDetailEL();
            if (PurchasesTransactionId != Guid.Empty)
            {
                oelPurchaseTransaction.TransactionID = PurchasesTransactionId;
                oelVoucherWorkPurchase.IdVoucherDetail = PurchasesTransactionId;
                oelPurchaseTransaction.IsNew = false;
            }
            else
            {
                oelPurchaseTransaction.TransactionID = Guid.NewGuid();
                oelVoucherWorkPurchase.IdVoucherDetail = oelPurchaseTransaction.TransactionID;
                oelPurchaseTransaction.IsNew = true;
            }
            oelPurchaseTransaction.IdCompany = Operations.IdCompany;
            oelPurchaseTransaction.AccountNo = Validation.GetSafeString(txtPurchasesAccountName.Text);
            oelVoucherWorkPurchase.AccountNo = Validation.GetSafeString(txtPurchasesAccountName.Text);
            oelPurchaseTransaction.LinkAccountNo = "";
            oelVoucherWorkPurchase.LinkAccountNo = "";
            oelPurchaseTransaction.SubAccountNo = "0";
            oelPurchaseTransaction.Date = VDate.Value;
            oelPurchaseTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
            oelVoucherWorkPurchase.IdVoucher = oelVoucher.IdVoucher;
            oelPurchaseTransaction.IdVoucher = oelVoucher.IdVoucher;
            oelPurchaseTransaction.VoucherType = "WorkPurchaseVoucher";
            oelVoucherWorkPurchase.Description = txtDescription.Text;
            oelVoucherPurchaseDetail.Description = txtDescription.Text;
            oelPurchaseTransaction.Description = txtDescription.Text;
            oelPurchaseTransaction.Debit = Validation.GetSafeDecimal(txtCreditAmount.Text);

            oelPurchaseTransaction.Credit = 0;
            oelVoucherWorkPurchase.Amount = Validation.GetSafeDecimal(txtCreditAmount.Text);
            oelPurchaseTransaction.Posted = true;

            oelTransactionCollection.Add(oelPurchaseTransaction);
            oelPurchaseDetailCollection.Add(oelVoucherWorkPurchase);
            #endregion region
            #region Saving Code
            if (IdVoucher == Guid.Empty)
            {
                var manager = new PurchaseHeadBLL();
                var PManger = new TanneryProcessesHeadBLL();
                var GManager = new ProductionProcessesHeadBLL();
                EntityoperationInfo infoResult = manager.InsertWorkPurchases(oelVoucher, oelPurchaseDetailCollection, oelTransactionCollection);
                if (infoResult.IsSuccess)
                {
                    if (MessageBox.Show("Entry Posted Successfully....", "Posting", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (ProductionType == "Tannery")
                        {
                            PManger.UpdateProcessEntries(IdEntity, ProcessName, oelVoucher.IdVoucher, true);
                        }
                        else if (ProductionType == "Garments / Gloves")
                        {
                            GManager.UpdateProductionProcessDetailEntries(IdEntity, oelVoucher.IdVoucher, true);
                        }
                        this.Close();
                    }
                }
            }
            else
            {
                var manager = new PurchaseHeadBLL();
                var PManger = new TanneryProcessesHeadBLL();
                var GManager = new ProductionProcessesHeadBLL();
                EntityoperationInfo infoResult = manager.UpdateWorkPurchases(oelVoucher, oelPurchaseDetailCollection, oelTransactionCollection);
                if (infoResult.IsSuccess)
                {
                    if (MessageBox.Show("Entry Posted Successfully....", "Posting", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
                    {
                        //if (ProductionType == "Tannery")
                        //{
                        //    PManger.UpdateProcessEntries(IdEntity, ProcessName, oelVoucher.IdVoucher, true);
                        //}
                        //else if (ProductionType == "Garments / Gloves")
                        //{
                        //    GManager.UpdateProductionProcessDetailEntries(IdEntity, oelVoucher.IdVoucher, true);
                        //}
                        this.Close();
                    }
                }
            }
            #endregion
        }
        private void cbxNaturalAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxNaturalAccounts.SelectedIndex > 0)
            {
                txtPurchasesAccountName.Text = Validation.GetSafeString(cbxNaturalAccounts.SelectedValue);
            }
        }
        private void cbxNaturalAccounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus();
            }
        }
        frmAccounts frmAccounts = null;
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            frmAccounts = new frmAccounts();
            frmAccounts.ShowDialog();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillNaturalAccounts("");
        }
    }
}
