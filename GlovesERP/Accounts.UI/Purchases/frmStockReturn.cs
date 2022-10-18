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
    public partial class frmStockReturn : MetroForm
    {
        #region Variables
        frmFindAccounts frmAccount;
        frmStockAccounts frmstockAccounts;
        frmFindVouchers frmfindVouchers;
        public decimal OldValue { get; set; }
        public Int64 VoucherNo { get; set; }
        string LinkAccountNo = "", PurchasesAccountNo = "", SupplierAccountNo = "";
        Guid IdVoucher;
        public Guid SupplierTransactionId { get; set; }
        public Guid PurchasesTransactionId { get; set; }
        public string VoucherType { get; set; }
        public bool IsImport { get; set; }
        string EventCommandName;
        #endregion
        public frmStockReturn()
        {
            InitializeComponent();
        }
        private void frmStockReceipt_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.DgvStockReceipt.AutoGenerateColumns = false;
            txtBillNo.Text = "0";
            FillData();
            FillNaturalAccounts(string.Empty);
            CheckModulePermissions();            
        }
        private void CheckModulePermissions()
        {
            List<UserModulesPermissionsEL> PermissionsList = UserPermissions.GetUserModulePermissionsByUserAndModuleId(Operations.UserID);
            if (PermissionsList != null && PermissionsList.Count > 0)
            {
                if (PermissionsList[0].Saving == true)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
                if (PermissionsList[0].Deleting == true)
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                }
                if (PermissionsList[0].Posting == true)
                {
                    btnSave.Enabled = true;
                    chkPosted.Checked = true;
                    chkPosted.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = false;
                    chkPosted.Checked = false;
                    chkPosted.Enabled = true;
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
        private void FillData()
        {
            var manager = new VoucherBLL();
            VEditBox.Text = manager.GetMaxVoucherNumber("PurchaseReturnVoucher", Operations.IdCompany);
        }
        private void FillNaturalAccounts(string AccountNo)
        {
            var manager = new AccountsBLL();
            List<AccountsEL> list = manager.GetAccountsByType("Inventory Head", Operations.IdCompany);
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
        private void ClearControl()
        {
            DgvStockReceipt.Rows.Clear();
            //txtDescription.Text = string.Empty;
            VoucherNo = 0;
            IdVoucher = Guid.Empty;
            VEditBox.Enabled = true;
            txtDescription.Text = string.Empty;
            txtCreditBalance.Text = string.Empty;          
            SupplierTransactionId = Guid.Empty;


            PurchasesTransactionId = Guid.Empty;
            SupplierAccountNo = string.Empty;
            PurchasesAccountNo = string.Empty;
            cbxNaturalAccounts.SelectedIndex = 0;

            SEditBox.Text = string.Empty;
            txtBillNo.Text = string.Empty;

            txtContact.Text = string.Empty;
            if (chkPosted.Checked)
            {
                chkPosted.Checked = false;
                chkPosted.Enabled = true;
            }
            VDate.Value = DateTime.Now;
        }
        private bool ValidateRows()
        {

            for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
            {
                if (DgvStockReceipt.Rows[i].Cells["colItemNo"].Value == null)
                {
                    return false;
                }
                else if (DgvStockReceipt.Rows[i].Cells["colQty"].Value == null)
                {
                    return false;
                }
                else if (DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value == null)
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidateControls()
        {
            if (SupplierAccountNo == string.Empty)
            {
                MessageBox.Show("Supplier Missing...");
                return false;
            }
            else if (PurchasesAccountNo == string.Empty)
            {
                MessageBox.Show("Purchases Account Missing...");
                return false;
            }
            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PurchasesEditBox_ButtonClick(object sender, EventArgs e)
        {
            EventCommandName = "Sales";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        private void SEditBox_ButtonClick(object sender, EventArgs e)
        {
            EventCommandName = "Persons";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            if (EventCommandName == "Persons")
            {
                //var manager = new PersonsBLL();
                // List<PersonsEL> list = manager.VerifyAccount(Operations.IdCompany, "Persons", oelAccount.AccountNo);
                //if (list.Count > 0)
                {
                    SupplierAccountNo = oelAccount.AccountNo;
                    SEditBox.Text = Validation.GetSafeString(oelAccount.AccountName);
                    txtSupplierClosingBalance.Text = GetClosingBalance(oelAccount.AccountNo).ToString();
                    
                }
                //else
                //{
                //lblStatuMessage.Text = "Please Select Supplier";
                //}
            }
        }
        private decimal GetClosingBalance(string AccountNo)
        {
            var manager = new TransactionBLL();
            return manager.GetAccountClosingBalance(AccountNo, Operations.IdCompany);
        }
        private void DgvStockReceipt_KeyDown(object sender, KeyEventArgs e)
        {
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            DgvStockReceipt.RefreshEdit();
            var manager = new ItemsBLL();
            if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.ItemNo).Count > 0)
            {
                //for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                //{
                //    if (DgvStockReceipt.Rows[i].Cells["colItemNo"].Value != null)
                //    {
                //        if (oelItems.AccountNo == Validation.GetSafeLong(DgvStockReceipt.Rows[i].Cells["colItemNo"].Value))
                //        {
                //            lblStatuMessage.Text = "Product Already exists";
                //            return;
                //        }
                //    }
                //}

                DgvStockReceipt.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
                DgvStockReceipt.CurrentRow.Cells["colItemNo"].Value = oelItems.ItemNo;
                DgvStockReceipt.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
                DgvStockReceipt.CurrentRow.Cells["colpacking"].Value = oelItems.PackingSize;
                //DgvStockReceipt.CurrentRow.Cells["ColBatch"].Value = oelItems.BatchNo;
            }
        }
        private void DgvStockReceipt_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    OldValue = Convert.ToInt32(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);
            //}
        }
        private void DgvStockReceipt_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colUnitPrice")
            {
                DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                }
                txtCreditBalance.Text = OldValue.ToString();
                OldValue = 0;
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colDisc")
            {
                if (Validation.GetSafeInteger(DgvStockReceipt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) != 0)
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) * (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDisc"].Value)) / 100;
                }
                else
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colDisc"].Value = "";
                }
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colExpiry")
            {
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value != null)
                {
                    bool Value = DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value.ToString().Contains('/');
                    if (Value == false)
                    {
                        MessageBox.Show("Wrong Expiry Date");
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
                    }
                    else
                    {
                        string[] splitString = DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value.ToString().Split('/');
                        if (splitString.Length == 3)
                        {
                            MessageBox.Show("Wrong Expiry Date");
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
                        }
                        else if (splitString.Length == 2)
                        {
                            int Year = Validation.GetSafeInteger(splitString[1]);
                            int currentyear = Validation.GetSafeInteger(DateTime.Now.Year.ToString().Substring(2));
                            if (Year < currentyear)
                            {
                                MessageBox.Show("Wrong Expiry Date.. Expiry Year is smaller then current year");
                                DgvStockReceipt.Rows[e.RowIndex].Cells["colExpiry"].Value = "";
                            }
                        }
                    }
                }
            }
            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    decimal value = 0;
            //    if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //    {
            //        if (OldValue > Convert.ToInt32(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value))
            //        {
            //            value = OldValue;
            //            txtTotalAmount.Text = (((Convert.ToInt64(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text) + Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (value))).ToString());
            //        }
            //        else if (OldValue < Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value))
            //        {
            //            value = Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - OldValue;
            //            txtTotalAmount.Text = (Convert.ToDecimal(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text) + (value)).ToString();
            //        }
            //        DgvStockReceipt.Text = (DgvStockReceipt.Rows.Count - 1).ToString();
            //    }
            //}
        }
        private void DgvStockReceipt_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colUnitPrice")
            {
                DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value));
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            {
                DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                }
                txtCreditBalance.Text = OldValue.ToString();               
                OldValue = 0;
            }
            //DgvStockReceipt.EndEdit();
            //if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colUnitPrice")
            //{
            //    DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);

            //}

            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //    {
            //        for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
            //        {
            //            OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
            //        }
            //        txtTotalAmount.Text = OldValue.ToString();
            //        OldValue = 0;
            //    }
            //}
            //{
            //    Int64 value = 0;
            //    if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //    {
            //        if (OldValue > Convert.ToInt32(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value))
            //        {
            //            value = OldValue;
            //            txtTotalAmount.Text = (((Convert.ToInt64(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text) + Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (value))).ToString());
            //        }
            //        else if (OldValue < Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value))
            //        {
            //            value = Convert.ToInt64(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - OldValue;
            //            txtTotalAmount.Text = (Convert.ToDecimal(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text) + (value)).ToString();
            //        }
            //        else
            //        {
            //            txtTotalAmount.Text = OldValue.ToString();
            //        }
            //        OldValue = 0;
            //        DgvStockReceipt.Text = (DgvStockReceipt.Rows.Count - 1).ToString();
            //    }
            //}
        }
        private void DgvStockReceipt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    for(int i=0; i<DgvStockReceipt.Rows.Count-1; i++)
            //    {
            //        OldValue += Convert.ToInt32(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
            //    }
            //}
        }
        //private void DgvStockReceipt_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        ////    if (DgvStockReceipt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        ////    {
        ////        if (DgvStockReceipt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == string.Empty)
        ////        {
        ////            e.Cancel = true;
        ////        }
        ////        else
        ////        {
        ////            e.Cancel = false;
        ////        }
        ////    }
        //}
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Variables
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            List<StockReceiptEL> oelStockReceiptCollection = new List<StockReceiptEL>();
            List<VoucherDetailEL> oelPurchaseDetailCollection = new List<VoucherDetailEL>();
            #endregion
            #region Main
            if (ValidateRows())
            {
                if (ValidateControls())
                {
                    #region Voucher Header Information
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
                    oelVoucher.BookNo = Operations.BookNo;
                    oelVoucher.AccountNo = SupplierAccountNo;
                    oelVoucher.LinkAccountNo = LinkAccountNo;
                    oelVoucher.SubAccountNo = "0";
                    oelVoucher.BillNo = txtBillNo.Text;
                    oelVoucher.VDate = VDate.Value;
                    oelVoucher.TotalAmount = Convert.ToDecimal(txtCreditBalance.Text);
                    oelVoucher.IsImport = IsImport;
                    oelVoucher.VDiscription = Validation.GetSafeString(txtDescription.Text);
                    oelVoucher.Posted = chkPosted.Checked;
                    #endregion
                    #region Add Stock
                    for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                    {
                        VoucherDetailEL oelPurchaseDetial = new VoucherDetailEL();
                        if (DgvStockReceipt.Rows[i].Cells["colStockReceiptID"].Value != null)
                        {
                            //oelPurchaseDetial.TransactionID = new Guid(DgvStockReceipt.Rows[i].Cells["ColTransaction"].Value.ToString());
                            oelPurchaseDetial.IdVoucherDetail = new Guid(DgvStockReceipt.Rows[i].Cells["colStockReceiptID"].Value.ToString());
                            oelPurchaseDetial.IsNew = false;
                        }
                        else
                        {
                            oelPurchaseDetial.IdVoucherDetail = Guid.NewGuid();
                            //  oelPurchaseDetial.TransactionID = Guid.NewGuid();
                            oelPurchaseDetial.IsNew = true;
                        }
                        oelPurchaseDetial.Seq = i + 1;
                        oelPurchaseDetial.IdVoucher = oelVoucher.IdVoucher;
                        oelPurchaseDetial.VoucherNo = Convert.ToInt64(VEditBox.Text);
                        oelPurchaseDetial.IdItem = Validation.GetSafeGuid(DgvStockReceipt.Rows[i].Cells["colIdItem"].Value);
                        //oelPurchaseDetial.ItemNo = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colItemNo"].Value);
                        //oelPurchaseDetial.ItemName = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colItemName"].Value);
                        oelPurchaseDetial.PackingSize = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colpacking"].Value);
                        //oelPurchaseDetial.BatchNo = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["ColBatch"].Value);
                        //oelPurchaseDetial.Expiry = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colExpiry"].Value);
                        oelPurchaseDetial.Discription = "N/A"; //Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colRemarks"].Value);
                        oelPurchaseDetial.Units = Validation.GetSafeInteger(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                        //oelPurchaseDetial.Bonus = Validation.GetSafeInteger(DgvStockReceipt.Rows[i].Cells["colBonus"].Value);
                        oelPurchaseDetial.RemainingUnits = Validation.GetSafeInteger(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                        oelPurchaseDetial.UnitPrice = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value);
                        oelPurchaseDetial.Discount = 0;//Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDisc"].Value);
                        oelPurchaseDetial.Amount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                        oelPurchaseDetailCollection.Add(oelPurchaseDetial);
                    }
                    #endregion                 
                    #region Add Supplier
                    TransactionsEL oelSupplierTransaction = new TransactionsEL();
                    if (SupplierTransactionId != Guid.Empty)
                    {
                        oelSupplierTransaction.TransactionID = SupplierTransactionId;
                        oelSupplierTransaction.IsNew = false;
                    }
                    else
                    {
                        oelSupplierTransaction.TransactionID = Guid.NewGuid();
                        oelSupplierTransaction.IsNew = true;
                    }
                    oelSupplierTransaction.IdVoucher = oelVoucher.IdVoucher;
                    oelSupplierTransaction.BookNo = Operations.BookNo;
                    oelSupplierTransaction.IdCompany = Operations.IdCompany;
                    oelSupplierTransaction.AccountNo = SupplierAccountNo;
                    oelSupplierTransaction.LinkAccountNo = "";
                    oelSupplierTransaction.SubAccountNo = "0";
                    oelSupplierTransaction.VDate = VDate.Value;
                    oelSupplierTransaction.VoucherNo = Convert.ToInt32(VEditBox.Text);
                    oelSupplierTransaction.VoucherType = "PurchaseReturnVoucher";
                    oelSupplierTransaction.Discription = txtDescription.Text;
                    //oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                    oelSupplierTransaction.Credit = 0;
                    oelSupplierTransaction.Debit = Validation.GetSafeDecimal(txtCreditBalance.Text);
                    oelSupplierTransaction.TransactionType = "Dr";
                    
                   
                    oelSupplierTransaction.Posted = chkPosted.Checked;
                    oelTransactionCollection.Add(oelSupplierTransaction);
                    #endregion
                    #region Add Purchase Account In Transactions
                    /// Add Purchase Account...
                    TransactionsEL oelPurchaseTransaction = new TransactionsEL();
                    if (PurchasesTransactionId != Guid.Empty)
                    {
                        oelPurchaseTransaction.TransactionID = PurchasesTransactionId;
                        oelPurchaseTransaction.IsNew = false;
                    }
                    else
                    {
                        oelPurchaseTransaction.TransactionID = Guid.NewGuid();
                        oelPurchaseTransaction.IsNew = true;
                    }
                    oelPurchaseTransaction.IdVoucher = oelVoucher.IdVoucher;
                    oelPurchaseTransaction.BookNo = Operations.BookNo;
                    oelPurchaseTransaction.IdCompany = Operations.IdCompany;
                    //oelPurchaseTransaction.AccountNo = Validation.GetSafeLong(PurchasesEditBox.Text);
                    oelPurchaseTransaction.AccountNo = PurchasesAccountNo;
                    oelPurchaseTransaction.LinkAccountNo = LinkAccountNo;
                    oelPurchaseTransaction.SubAccountNo = "0";
                    oelPurchaseTransaction.VDate = VDate.Value;
                    oelPurchaseTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelPurchaseTransaction.VoucherType = "PurchaseReturnVoucher";
                    oelPurchaseTransaction.Discription = txtDescription.Text;
                    oelPurchaseTransaction.Debit = 0;
                    
                    oelPurchaseTransaction.Credit = Validation.GetSafeDecimal(txtCreditBalance.Text);
                    oelPurchaseTransaction.TransactionType = "Cr";
                    //if (txtCashReceipt.Text == string.Empty)
                    //{
                    //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                    //}
                    //else
                    //{
                    //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtCashReceipt.Text);
                    //}
                    oelPurchaseTransaction.Posted = chkPosted.Checked;
                    oelTransactionCollection.Add(oelPurchaseTransaction);
                    #endregion region
                    #region Saving Code Region
                    if (IdVoucher == Guid.Empty)
                    {
                        var manager = new PurchaseHeadBLL();
                        var VManager = new VoucherBLL();
                        if (VManager.CheckVoucherNo(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text), "PurchaseReturnVoucher") == false)
                        {

                            EntityoperationInfo infoResult = manager.InsertPurchasesReturn(oelVoucher, oelPurchaseDetailCollection, oelTransactionCollection);
                            if (infoResult.IsSuccess)
                            {
                                MessageBox.Show("Purchases Returned Successfully...");
                                ClearControl();
                                FillData();
                            }
                        }
                        else
                        {
                            MessageBox.Show("This Voucher No Already Exists ; Plz Change Voucher No :");
                        }
                    }
                    else
                    {
                        var manager = new PurchaseHeadBLL();
                        EntityoperationInfo infoResult = manager.UpdatePurchasesReturn(oelVoucher, oelPurchaseDetailCollection, oelTransactionCollection);
                        if (infoResult.IsSuccess)
                        {
                            MessageBox.Show("Recored Purchased Return Updated Successfully...");
                            ClearControl();
                            FillData();
                        }
                    }
                    #endregion
                }
            }
            else
            {
                MessageBox.Show("Incomplete Entry...");
            }
            #endregion
        }
        private void DgvStockReceipt_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DgvStockReceipt.EndEdit();
            //if (!DgvStockReceipt.IsCurrentRowDirty)
            //{
            //    e.Cancel = false;
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }
        private void VEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindVouchers = new frmFindVouchers();
            frmfindVouchers.VoucherType = "PurchaseReturnVoucher";
            frmfindVouchers.ExecuteFindVouchersEvent += new frmFindVouchers.VouchersDelegate(frmfindVouchers_ExecuteFindVouchersEvent);
            frmfindVouchers.ShowDialog(this);
        }
        void frmfindVouchers_ExecuteFindVouchersEvent(VouchersEL oelVoucher)
        {
            VoucherNo = oelVoucher.VoucherNo;
            IdVoucher = oelVoucher.IdVoucher;
            VEditBox.Text = oelVoucher.VoucherNo.ToString();
            FillVoucher();

        }
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    FillVoucher();
                }
            }
            else
                e.Handled = true;
        }
        private void FillVoucher()
        {
            var Manager = new VoucherBLL();
            var PManager = new PurchaseHeadBLL();
            VoucherType = "PurchaseReturnVoucher";
            if (VEditBox.Text != string.Empty)
            {
                List<VoucherDetailEL> list = PManager.GetPurchasesReturnByVoucher(Validation.GetSafeLong(VEditBox.Text), Operations.IdCompany);
                if (list.Count > 0)
                {
                    IdVoucher = list[0].IdVoucher;
                    VEditBox.Enabled = false;
                    txtBillNo.Text = list[0].BillNo;
                    VDate.Value = list[0].VDate.Value;
                    txtDescription.Text = list[0].VDiscription;
                    LinkAccountNo = list[0].LinkAccountNo;
                    txtCreditBalance.Text = list[0].TotalAmount.ToString();
                    FillTransactions(list);
                    HandleVoucher(list);

                    List<TransactionsEL> listTransactions = Manager.GetTransactions(IdVoucher, "PurchaseReturnVoucher", Operations.IdCompany);

                    if (listTransactions.Count > 0)
                    {
                        TransactionsEL oelSalesTransaction = listTransactions.Find(x => x.Credit != 0);
                        if (oelSalesTransaction != null)
                        {
                            //PurchasesEditBox.Text = oelSalesTransaction.AccountNo.ToString();
                            //cbxNaturalAccounts.SelectedValue = oelSalesTransaction.AccountNo;
                            FillNaturalAccounts(oelSalesTransaction.AccountNo.ToString());
                            PurchasesAccountNo = oelSalesTransaction.AccountNo.ToString();
                            //txtPurchasesAccountName.Text = oelSalesTransaction.AccountName;
                            PurchasesTransactionId = oelSalesTransaction.TransactionID;
                        }
                        TransactionsEL oelPurchaseTransaction = listTransactions.Find(x => x.Debit != 0);
                        if (oelPurchaseTransaction != null)
                        {
                            SupplierAccountNo = oelPurchaseTransaction.AccountNo;
                            SEditBox.Text = Validation.GetSafeString(oelPurchaseTransaction.AccountName);                            
                            SupplierTransactionId = oelPurchaseTransaction.TransactionID;
                        }

                    }

                    //List<TransactionsEL> List = Manager.GetTransactionsByVoucherAndType(Operations.IdCompany, list[0].IdVoucher, Validation.GetSafeLong(VEditBox.Text), VoucherType);
                    
                }
                else
                {
                    MessageBox.Show("Voucher Number Not Found ...");
                    ClearControl();
                }
            }


        }
        private void HandleVoucher(List<VoucherDetailEL> list)
        {
            if (list[0].Posted && list[0].IsDeleted == true)
            {
                //if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    chkPosted.Enabled = false;
                }
                lblVoucherStatus.Visible = true;
                lblVoucherStatus.Text = "Deleted Voucher";
                chkPosted.Checked = list[0].Posted;
            }
            else if (!list[0].Posted && !list[0].IsDeleted == true)
            {
                {
                    btnSave.Enabled = true;
                    btnDelete.Enabled = true;
                    chkPosted.Enabled = true;
                }
                lblVoucherStatus.Visible = false;
            }
            else if (list[0].Posted && !list[0].IsDeleted == true)
            {
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                chkPosted.Enabled = false;
            }
            else if (!list[0].Posted && list[0].IsDeleted == true)
            {
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                chkPosted.Enabled = false;
                lblVoucherStatus.Visible = true;
                lblVoucherStatus.Text = "Deleted Voucher";
            }
            else
            {
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
        private void FillTransactions(List<VoucherDetailEL> List)
        {
            if (DgvStockReceipt.Rows.Count > 0)
            {
                DgvStockReceipt.Rows.Clear();
            }
            if (List != null && List.Count > 0)
            {

                for (int i = 0; i < List.Count; i++)
                {
                    DgvStockReceipt.Rows.Add();

                    DgvStockReceipt.Rows[i].Cells[0].Value = List[i].IdVoucherDetail;
                    DgvStockReceipt.Rows[i].Cells[1].Value = List[i].IdItem;
                    DgvStockReceipt.Rows[i].Cells[2].Value = List[i].ItemNo;
                    DgvStockReceipt.Rows[i].Cells[3].Value = List[i].ItemName;
                    DgvStockReceipt.Rows[i].Cells[4].Value = List[i].PackingSize;
                    DgvStockReceipt.Rows[i].Cells[5].Value = List[i].Units;
                    //DgvStockReceipt.Rows[i].Cells[4].Value = List[i].Qty * List[i].Debit;
                    DgvStockReceipt.Rows[i].Cells[6].Value = List[i].UnitPrice;
                    DgvStockReceipt.Rows[i].Cells[7].Value = List[i].TotalAmount;
                    //if (List[i].Discount == 0)
                    //{
                    //    DgvStockReceipt.Rows[i].Cells[10].Value = "";
                    //}
                    //else
                    //{
                    //    DgvStockReceipt.Rows[i].Cells[10].Value = List[i].Discount;
                    //}
                    //DgvStockReceipt.Rows[i].Cells[11].Value = List[i].TotalAmount; //List[i].Qty * List[i].unitprice;

                    //txtCreditBalance.Text = List.Sum(x => x.Amount).ToString();
                    txtCreditBalance.Text = List[0].Amount.ToString("0.00");
                    // DgvStockReceipt.DataSource = List;
                    //
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<TransactionsEL> oelItemTransactionCollection = new List<TransactionsEL>();
            if (VEditBox.Text != string.Empty)
            {
                var manager = new PurchaseHeadBLL(); //PurchaseStockReceiptBLL();
                if (IdVoucher != Guid.Empty)
                {
                    if (MessageBox.Show("Are You Sure To Delete ?", "Deleting Voucher", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (manager.DeletePurchasesReturn(IdVoucher))
                        {
                            MessageBox.Show("Voucher Deleted Successfully and Transactions Rolled Back");
                            ClearControl();
                            //for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                            //{
                            //    TransactionsEL oelTransaction = new TransactionsEL();
                            //    oelTransaction.AccountNo = Validation.GetSafeLong(DgvStockReceipt.Rows[i].Cells["colItemNo"].Value);
                            //    oelTransaction.Qty = Convert.ToInt32(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                            //    oelItemTransactionCollection.Add(oelTransaction);
                            //}
                            //if (manager.UpdateStockitems(oelItemTransactionCollection, "Subtract"))
                            //{
                            //    lblStatuMessage.Text = "Voucher Deleted Successfully";
                            //    ClearControl();
                            //}
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select Voucher To Delete....");
                }
            }
        }
        private void frmStockReceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                FillData();
                ClearControl();
                if (DgvStockReceipt.Rows.Count > 0)
                {
                    DgvStockReceipt.Rows.Clear();
                }
            }
        }
        private void DgvStockReceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.F2)
            //{
            //    if (DgvStockReceipt.CurrentCellAddress.X == 2)
            //    {
            //        checkSender = true;
            //        frmstockAccounts = new frmStockAccounts();
            //        frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
            //        frmstockAccounts.ShowDialog(this);
            //    }
            //}
        }
        private void DgvStockReceipt_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvStockReceipt.CurrentCellAddress.X == 3)
            {
                TextBox txtItemName = e.Control as TextBox;
                if (txtItemName != null)
                {
                    txtItemName.KeyPress -= new KeyPressEventHandler(txtItemName_KeyPress);
                    txtItemName.KeyPress += new KeyPressEventHandler(txtItemName_KeyPress);
                }
            }
        }
        void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvStockReceipt.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        private void cbxNaturalAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxNaturalAccounts.SelectedIndex > 0)
            {
                var manager = new AccountsBLL();
                PurchasesAccountNo = Validation.GetSafeString(cbxNaturalAccounts.SelectedValue);
                List<AccountsEL> list = manager.GetAccount(Validation.GetSafeString(cbxNaturalAccounts.SelectedValue), Operations.IdCompany);
                if (list.Count > 0)
                {
                    LinkAccountNo = list[0].LinkAccountNo;
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            FillData();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            long NextVoucherNo = Convert.ToInt64(VEditBox.Text);
            NextVoucherNo += 1;
            VEditBox.Text = NextVoucherNo.ToString();
            FillVoucher();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            long PreviousVoucherNo = Convert.ToInt64(VEditBox.Text);
            PreviousVoucherNo -= 1;
            VEditBox.Text = PreviousVoucherNo.ToString();
            FillVoucher();
        }

        private void SEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetroFramework.Controls.MetroTextBox txt = sender as MetroFramework.Controls.MetroTextBox;
            if (txt != null)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (txt.Name == "SEditBox")
                    {
                        cbxNaturalAccounts.Focus();
                        cbxNaturalAccounts.DroppedDown = true;
                    }
                }
                else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    if (txt.Name == "SEditBox")
                    {
                        EventCommandName = "Persons";
                    }
                    e.Handled = true;
                    frmAccount = new frmFindAccounts();
                    frmAccount.SearchText = e.KeyChar.ToString();
                    frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                    frmAccount.ShowDialog();

                }
                else
                    e.Handled = false;
            }
        }

        private void cbxNaturalAccounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBillNo.Focus();
            }
        }

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DgvStockReceipt.Focus();
            }
        }
        frmgeneralLedger frmledger;
        private void btnViewLedger_Click(object sender, EventArgs e)
        {
            if (SupplierAccountNo != string.Empty)
            {
                frmledger = new frmgeneralLedger();
                frmledger.AccountNo = SupplierAccountNo;
                frmledger.AccountName = SEditBox.Text;
                frmledger.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select Supplier First To View Ledger...");
            }
        }
        frmPersons frmperson;
        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (SupplierAccountNo != string.Empty)
            {
                frmperson = new frmPersons();
                frmperson.AccountNo = SupplierAccountNo;
                frmperson.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select Supplier First To View Detail...");
            }
        }
    }
}
