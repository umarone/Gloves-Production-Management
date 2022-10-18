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
    public partial class frmStockReceipt : MetroForm
    {
        #region Variables
        frmFindAccounts frmAccount;
        frmStockAccounts frmstockAccounts;
        frmFindVouchers frmfindVouchers;
        frmPurchaseOrderPrint frmPrint;
        frmgeneralLedger frmledger;
        frmPersons frmpersons;
        frmCustomerPOS frmcustomerpo;
        TextBox txtDebit = new TextBox();
        TextBox txtCredit = new TextBox();
        public decimal OldValue { get; set; }
        public decimal BillingAmount { get; set; }
        public decimal NormalDiscount { get; set; }
        public decimal BulkDiscount { get; set; }
        public decimal ValueAfterDiscount { get; set; }
        public decimal NetAmount { get; set; }
        public Int64 VoucherNo { get; set; }
        Guid IdVoucher, IdOrder = Guid.Empty;
        public Guid SupplierTransactionId { get; set; }
        public Guid PurchasesTransactionId { get; set; }
        public Guid CashTransactionId { get; set; }
        public string VoucherType { get; set; }
        public string PurchaseType { get; set; }
        string EventCommandName;
        int EventTime = 0;
        string LinkAccountNo = "", PurchasesAccountNo = "", SupplierAccountNo = string.Empty, CashAccountNo = string.Empty;
        public bool IsImport { get; set; }
        public bool IsNetTransaction { get; set; }
        int SilentOperation = 0;
        #endregion
        #region Form Events And Methods
        public frmStockReceipt()
        {
            InitializeComponent();
        }
        private void frmStockReceipt_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.DgvStockReceipt.AutoGenerateColumns = false;
            cbxPurchaser.SelectedIndex = 0;
            txtBillNo.Text = "0";
            FillData();
            AdjustControls();
            FillNaturalAccounts(string.Empty);
            FillCashAccounts(string.Empty);
            CheckModulePermissions();
            this.Text = "Inventory Purchases";
            //if (IsNetTransaction)
            //{
            //    this.Text = "Net Inventory Purchases";
            //    btnViewDetail.Enabled = false;
            //    grpCreditor.Text = "Cash Account Information";
            //}
            //else
            //{
            //    this.Text = "Credit Inventory Purchases";
            //}
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
        #endregion
        #region Simple Methods
        private void AdjustControls()
        {
            //if (IsNetTransaction)
            //{
            //    grpCreditor.Visible = false;
            //}
            //else
            //{
                pnlCash.Visible = false;
            //}
        }
        private void CreateAndInitializeFooterRow()
        {
            txtDebit.Enabled = false;
            txtDebit.TextAlign = HorizontalAlignment.Left;
            txtDebit.Font = new System.Drawing.Font("Arial", 9, FontStyle.Bold);

            int hostCellLocation = DgvPurchases.GetCellDisplayRectangle(9, -1, true).X;

            txtDebit.Width = DgvPurchases.Columns[9].Width; //+SystemInformation.VerticalScrollBarWidth;
            txtDebit.Location = new Point(hostCellLocation, DgvPurchases.Height - txtDebit.Height);

            DgvPurchases.Controls.Add(txtDebit);

            txtDebit.BringToFront();

            txtCredit.Enabled = false;
            txtCredit.TextAlign = HorizontalAlignment.Left;
            txtCredit.Font = new System.Drawing.Font("Arial", 9, FontStyle.Bold);

            int hostCreditCellLocation = DgvPurchases.GetCellDisplayRectangle(10, -1, true).X;
            txtCredit.Width = DgvPurchases.Columns[10].Width; //+SystemInformation.VerticalScrollBarWidth;
            txtCredit.Location = new Point(hostCreditCellLocation, DgvPurchases.Height - txtCredit.Height);

            DgvPurchases.Controls.Add(txtCredit);

            txtCredit.BringToFront();
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
            var manager = new PurchaseHeadBLL();
            VEditBox.Text = manager.GetMaxPurchaseNumber(Operations.IdCompany, IsNetTransaction).ToString();
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
                    cbxNaturalAccounts.SelectedIndex = 1;
                }
            }
            else
            {
                cbxNaturalAccounts.SelectedValue = AccountNo;
            }
        }
        private void FillCashAccounts(string AccountNo)
        {
            #region Fill Cash Accounts
            //if (IsNetTransaction)
            //{
                var manager = new AccountsBLL();
                List<AccountsEL> listCash = manager.GetAccountsByType("Cash Balance Head", Operations.IdCompany);
                if (AccountNo == "")
                {
                    if (listCash.Count > 0)
                    {
                        cbxCashAccounts.DataSource = listCash;
                        listCash.Insert(0, new AccountsEL() { AccountNo = "0", AccountName = "" });

                        cbxCashAccounts.DisplayMember = "AccountName";
                        cbxCashAccounts.ValueMember = "AccountNo";

                        cbxCashAccounts.SelectedIndex = 1;
                    }
                }
                else
                {
                    cbxCashAccounts.SelectedValue = AccountNo;
                }
            //}
            #endregion
        }
        private void FillCreditor(string AccountNo)
        {
            var manager = new PersonsBLL();
            List<PersonsEL> list = manager.GetPersonByAccount(Operations.IdCompany, AccountNo);
            if (list.Count > 0)
            {
                //txtCurrentBalance.Text = CommonFunctions.GetClosingBalanceByAccount(Operations.IdProject, Operations.BookNo, AccountNo)[0].TypedClosingBalance;
            }
        }
        private void FillCreditorCredentials(string AccountNo)
        {
            var manager = new PersonsBLL();
            List<PersonsEL> list = manager.GetPersonByAccount(Operations.IdCompany, AccountNo);
            if (list.Count > 0)
            {
                if (list[0].PersonName == string.Empty)
                {
                    SEditBox.Text = list[0].AccountName;
                }
                else
                {
                    SEditBox.Text = list[0].PersonName + "-" + list[0].Address;
                }
            }
            else
            {
                var Amanager = new AccountsBLL();
                List<AccountsEL> Alist = Amanager.GetAccount(AccountNo, Operations.IdCompany);
                if (Alist.Count > 0)
                {
                    SEditBox.Text = Alist[0].AccountName;
                }
            }
        }
        private void ClearControl()
        {
            DgvStockReceipt.Rows.Clear();
            DgvPurchases.Rows.Clear();
            //txtDescription.Text = string.Empty;
            VoucherNo = 0;
            IdVoucher = Guid.Empty;
            VEditBox.Enabled = true;
            txtBillNo.Text = "0";
            txtDescription.Text = string.Empty;
            txtDebit.Text = string.Empty;
            txtCredit.Text = string.Empty;
            cbxPurchaser.SelectedIndex = 0;
            lblVoucherStatus.Text = string.Empty;
            //txtVat.Text = string.Empty;
            //txtVATAmount.Text = string.Empty;
            SupplierTransactionId = Guid.Empty;
            //PurchasesAccountNo = string.Empty;

            PurchasesTransactionId = Guid.Empty;
            CashTransactionId = Guid.Empty;
            //cbxNaturalAccounts.SelectedIndex = 0;
            if(cbxCashAccounts.Visible)
            cbxCashAccounts.SelectedIndex = 0;
            SEditBox.Text = string.Empty;
            //txtBillNo.Text = string.Empty;
            SupplierAccountNo = string.Empty;
            txtContact.Text = string.Empty;
            if (chkPosted.Checked)
            {
                chkPosted.Checked = false;
                chkPosted.Enabled = true;
            }
            IdOrder = Guid.Empty;
            txtPoNumber.Text = string.Empty;
            VDate.Value = DateTime.Now;

            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnNew.Enabled = true;

            txtBillAmount.Text = string.Empty;
            txtTotalDiscount.Text = string.Empty;
            txtFlatDiscount.Text = string.Empty;
            txtAmountAfterDiscount.Text = string.Empty;
            txtFreightAmount.Text = string.Empty;
            txtTotalCredit.Text = string.Empty;
            pnlCash.Visible = false;
            rdCredit.Checked = false;
            rdCash.Checked = false;
        }
        #endregion
        #region Validation Methods
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
            if (!rdCredit.Checked && !rdCash.Checked)
            {
                MessageBox.Show("Please Select Transaction Type :");
                return false;
            }
            if (!IsNetTransaction)
            {
                if (SupplierAccountNo == string.Empty)
                {
                    MessageBox.Show("Supplier Missing...");
                    return false;
                }
            
            }
            else
            {
                if(CashAccountNo == string.Empty)
                {
                    MessageBox.Show("Please Select Cash Account For Cash Transaction...");
                    return false;
                }
            }
            if (txtBillNo.Text == string.Empty)
            {
                MessageBox.Show("Bill Missing...");
                return false;
            }
            else if (PurchasesAccountNo == string.Empty)
            {
                MessageBox.Show("Purchases Account Missing...");
                return false;
            }
            if (IdVoucher != null && IdVoucher != Guid.Empty)
            {
                if (rdCredit.Checked)
                {
                    if (SupplierTransactionId != null && SupplierTransactionId != Guid.Empty)
                    {
                        if (SupplierTransactionId != null && SupplierTransactionId != Guid.Empty)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Customer Is Missing...");
                            return false;
                        }
                    }
                    else if (CashTransactionId != null || CashTransactionId != Guid.Empty)
                    {
                        SupplierTransactionId = CashTransactionId;
                    }
                }
                else if (rdCash.Checked)
                {
                    //if (IsWhatTransactionType)
                    //{
                    if (CashTransactionId != null && CashTransactionId != Guid.Empty)
                    {
                        if (CashTransactionId!= null && CashTransactionId != Guid.Empty)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Cash Account Is Missing...");
                            return false;
                        }
                    }
                    else if (SupplierTransactionId != null || SupplierTransactionId != Guid.Empty)
                    {
                        CashTransactionId = SupplierTransactionId;
                    }

                    //}
                    //else
                    //{ 

                    //}
                }
            }
            return true;
        }
        #endregion
        #region Button Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Variables
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            List<StockReceiptEL> oelStockReceiptCollection = new List<StockReceiptEL>();
            List<VoucherDetailEL> oelPurchaseDetailCollection = new List<VoucherDetailEL>();
            List<VoucherDetailEL> oelCostOfSalesCollection = new List<VoucherDetailEL>();
            List<ItemsEL> oelItemsCollection = new List<ItemsEL>();
            string StatusMsg;
            #endregion
            #region Main
            if (ValidateRows())
            {
                if (ValidateControls())
                {

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
                    oelVoucher.IdOrder = IdOrder;
                    oelVoucher.VoucherNo = Convert.ToInt64(VEditBox.Text);
                    oelVoucher.BookNo = Operations.BookNo;
                    oelVoucher.VehicalNo = "";
                    oelVoucher.VehicalType = 0;
                    oelVoucher.Weight = 0;
                    oelVoucher.AccountNo = SupplierAccountNo;
                    if (!IsNetTransaction)
                    {
                        oelVoucher.TransactionAccountNo = SupplierAccountNo;
                    }
                    else
                    {
                        oelVoucher.TransactionAccountNo = CashAccountNo;
                    }
                    if (!IsNetTransaction)
                    {
                        oelVoucher.IsNetTransaction = false;
                    }
                    else
                    {
                        oelVoucher.IsNetTransaction = true;
                    }
                    oelVoucher.LinkAccountNo = LinkAccountNo;
                    oelVoucher.SubAccountNo = "0";
                    oelVoucher.BillNo = txtBillNo.Text;
                    oelVoucher.VDiscription = Validation.GetSafeString(txtDescription.Text);
                    oelVoucher.VDate = VDate.Value;
                    oelVoucher.BillAmount = Validation.GetSafeDecimal(txtBillAmount.Text);
                    oelVoucher.TotalFreight = Validation.GetSafeDecimal(txtFreightAmount.Text);
                    oelVoucher.TotalDiscount = Validation.GetSafeDecimal(txtTotalDiscount.Text);
                    oelVoucher.ExtraDiscount = Validation.GetSafeDecimal(txtFlatDiscount.Text);
                    oelVoucher.BillAmountAfterDiscount = Validation.GetSafeDecimal(txtAmountAfterDiscount.Text);
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(txtTotalCredit.Text);

                    oelVoucher.PurchaseType = 0;

                    //oelVoucher.VAT = Validation.GetSafeInteger(txtVat.Text);
                    //oelVoucher.VATAmount = Validation.GetSafeDecimal(txtVATAmount.Text);
                    oelVoucher.IsImport = IsImport;
                    if (cbxPurchaser.SelectedIndex == 0 || cbxPurchaser.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please Select Purchaser ....");
                        return;
                    }
                    else
                    {
                        oelVoucher.Purchaser = cbxPurchaser.SelectedIndex;
                    }
                    oelVoucher.Posted = chkPosted.Checked;
                    #endregion
                    #region Stock Entries
                    for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                    {
                        VoucherDetailEL oelPurchaseDetial = new VoucherDetailEL();
                        ItemsEL oelItem = new ItemsEL();
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
                        oelItem.IdItem = Validation.GetSafeGuid(DgvStockReceipt.Rows[i].Cells["colIdItem"].Value);
                        //oelPurchaseDetial.ItemNo = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colItemNo"].Value);
                        //oelPurchaseDetial.ItemName = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colItemName"].Value);
                        oelPurchaseDetial.PackingSize = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colpacking"].Value);
                        //oelPurchaseDetial.BatchNo = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["ColBatch"].Value);
                        //oelPurchaseDetial.Expiry = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colExpiry"].Value);
                        oelPurchaseDetial.Discription = "N/A"; //Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colRemarks"].Value);
                        oelPurchaseDetial.Units = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                        //oelPurchaseDetial.Bonus = Validation.GetSafeInteger(DgvStockReceipt.Rows[i].Cells["colBonus"].Value);
                        oelPurchaseDetial.RemainingUnits = Validation.GetSafeInteger(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                        oelPurchaseDetial.Bonus = Validation.GetSafeLong(DgvStockReceipt.Rows[i].Cells["colBonus"].Value);
                        oelPurchaseDetial.UnitPrice = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value);
                        oelItem.CurrentUnitPrice = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value);
                        oelPurchaseDetial.Discount = 0;//Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDisc"].Value);
                        oelPurchaseDetial.Amount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                        oelPurchaseDetial.Discount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscount"].Value.ToString().Replace('%', ' '));
                        oelPurchaseDetial.DiscountAmount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscAmount"].Value);
                        oelPurchaseDetial.FlatDiscount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colFlatDiscount"].Value);
                        oelPurchaseDetial.NetAmount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscountAmount"].Value);

                        oelItemsCollection.Add(oelItem);
                        oelPurchaseDetailCollection.Add(oelPurchaseDetial);
                    }
                    #endregion
                    #region Add Items In Transactions
                    /// Add Items In Transactions
                    //for (int j = 0; j < DgvStockReceipt.Rows.Count - 1; j++)
                    //{
                    //    TransactionsEL oelTransaction = new TransactionsEL();
                    //    if (DgvStockReceipt.Rows[j].Cells["ColTransaction"].Value != null)
                    //    {
                    //        oelTransaction.TransactionID = new Guid(DgvStockReceipt.Rows[j].Cells["ColTransaction"].Value.ToString());
                    //        oelTransaction.IsNew = false;
                    //    }
                    //    else
                    //    {
                    //        oelTransaction.TransactionID = Guid.NewGuid();
                    //        oelTransaction.IsNew = true;
                    //    }
                    //    oelTransaction.IdCompany = Operations.IdCompany;
                    //    oelTransaction.AccountNo = Validation.GetSafeLong(DgvStockReceipt.Rows[j].Cells["colItemNo"].Value);
                    //    oelTransaction.Date = VDate.Value;
                    //    oelTransaction.VoucherNo = Convert.ToInt32(VEditBox.Text);
                    //    oelTransaction.VoucherType = "StockReceiptVoucher";
                    //    if (DgvStockReceipt.Rows[j].Cells["colRemarks"].Value == null)
                    //    {
                    //        oelTransaction.Description = "N/A";
                    //    }
                    //    else
                    //    {
                    //        oelTransaction.Description = DgvStockReceipt.Rows[j].Cells["colRemarks"].Value.ToString();
                    //    }
                    //    //oelTransaction.Debit = Convert.ToInt64(DgvStockReceipt.Rows[j].Cells["colUnitPrice"].Value);
                    //    oelTransaction.Debit = Convert.ToInt64(DgvStockReceipt.Rows[j].Cells["colAmount"].Value);
                    //    oelTransaction.Credit = 0;
                    //    //oelTransaction.Amount = Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                    //    oelTransaction.Qty = Convert.ToInt32(DgvStockReceipt.Rows[j].Cells["colQty"].Value);
                    //    oelTransaction.Posted = chkPosted.Checked;
                    //    oelTransactionCollection.Add(oelTransaction);
                    //}
                    #endregion
                    #region Add Supplier
                    if (!IsNetTransaction)
                    {
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
                        oelSupplierTransaction.IdCompany = Operations.IdCompany;
                        oelSupplierTransaction.IdUser = Operations.UserID;
                        oelSupplierTransaction.BookNo = Operations.BookNo;
                        oelSupplierTransaction.AccountNo = SupplierAccountNo;
                        oelSupplierTransaction.LinkAccountNo = "";
                        oelSupplierTransaction.SubAccountNo = "0";
                        oelSupplierTransaction.VDate = VDate.Value;
                        oelSupplierTransaction.IdVoucher = oelVoucher.IdVoucher;
                        oelSupplierTransaction.VoucherNo = Convert.ToInt32(VEditBox.Text);
                        oelSupplierTransaction.VoucherType = "StockReceiptVoucher";
                        oelSupplierTransaction.AdjustmentType = -1;
                        oelSupplierTransaction.SettlementType = "Purchases";
                        oelSupplierTransaction.VDiscription = txtDescription.Text;
                        oelSupplierTransaction.Credit = Validation.GetSafeDecimal(txtTotalCredit.Text);
                        oelSupplierTransaction.TransactionType = "Cr";
                        oelSupplierTransaction.Debit = 0;
                        oelSupplierTransaction.Posted = chkPosted.Checked;
                        oelTransactionCollection.Add(oelSupplierTransaction);
                    }
                    #endregion
                    #region Add Cash
                    if (IsNetTransaction)
                    {
                        TransactionsEL oelCashTransaction = new TransactionsEL();
                        if (CashTransactionId != Guid.Empty)
                        {
                            oelCashTransaction.TransactionID = CashTransactionId;
                            oelCashTransaction.IsNew = false;
                        }
                        else
                        {
                            oelCashTransaction.TransactionID = Guid.NewGuid();
                            oelCashTransaction.IsNew = true;
                        }
                        oelCashTransaction.IdCompany = Operations.IdCompany;
                        oelCashTransaction.IdUser = Operations.UserID;
                        oelCashTransaction.BookNo = Operations.BookNo;
                        oelCashTransaction.IdVoucher = oelVoucher.IdVoucher;
                        oelCashTransaction.AccountNo = CashAccountNo;
                        oelCashTransaction.LinkAccountNo = string.Empty;
                        oelCashTransaction.SubAccountNo = "0";
                        oelCashTransaction.VDate = VDate.Value;
                        oelCashTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                        oelCashTransaction.VoucherType = "StockReceiptVoucher";
                        oelCashTransaction.AdjustmentType = -1;
                        oelCashTransaction.TransactionType = "Cr";
                        oelCashTransaction.SettlementType = "Cash Purchases";
                        oelCashTransaction.VDiscription = txtDescription.Text;
                        oelCashTransaction.Credit = Convert.ToDecimal(txtTotalCredit.Text);

                        oelCashTransaction.Debit = 0;
                        oelCashTransaction.Posted = chkPosted.Checked;
                        oelCashTransaction.CreatedDateTime = VDate.Value;

                        oelTransactionCollection.Add(oelCashTransaction);
                    }
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
                    oelPurchaseTransaction.IdCompany = Operations.IdCompany;
                    oelPurchaseTransaction.IdUser = Operations.UserID;
                    oelPurchaseTransaction.BookNo = Operations.BookNo;
                    //oelPurchaseTransaction.AccountNo = Validation.GetSafeLong(PurchasesEditBox.Text);
                    oelPurchaseTransaction.AccountNo = PurchasesAccountNo;
                    oelPurchaseTransaction.LinkAccountNo = LinkAccountNo;
                    oelPurchaseTransaction.SubAccountNo = "0";
                    oelPurchaseTransaction.VDate = VDate.Value;
                    oelPurchaseTransaction.IdVoucher = oelVoucher.IdVoucher;
                    oelPurchaseTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelPurchaseTransaction.VoucherType = "StockReceiptVoucher";
                    oelPurchaseTransaction.AdjustmentType = -1;
                    oelPurchaseTransaction.SettlementType = "Purchases";
                    oelPurchaseTransaction.VDiscription = txtDescription.Text;
                    oelPurchaseTransaction.Debit = Validation.GetSafeDecimal(txtTotalCredit.Text);
                    oelPurchaseTransaction.TransactionType = "Dr";
                    oelPurchaseTransaction.Credit = 0;
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
                    #region Add Cost of Sales Transactions
                    if (DgvPurchases.Rows.Count > 1)
                    {
                        if (IsCashORbankAccountInvolve())
                        {
                            if (!AccountTransactionStatus(out StatusMsg))
                            {
                                MessageBox.Show(StatusMsg);
                                return;
                            }
                            if (IsTransactionalAccountExceeding(out StatusMsg))
                            {
                                MessageBox.Show(StatusMsg);
                                return;
                            }
                        }
                        for (int j = 0; j < DgvPurchases.Rows.Count - 1; j++)
                        {
                            VoucherDetailEL oelVoucherDetail = new VoucherDetailEL();
                            TransactionsEL oelCostofSalesTransaction = new TransactionsEL();
                            oelVoucherDetail.IdVoucher = oelVoucher.IdVoucher;
                            oelCostofSalesTransaction.IdVoucher = oelVoucher.IdVoucher;
                            if (DgvPurchases.Rows[j].Cells["ColIdDetailVoucher"].Value != null)
                            {
                                oelVoucherDetail.IdVoucherDetail = new Guid(DgvPurchases.Rows[j].Cells["ColIdDetailVoucher"].Value.ToString());
                                oelVoucherDetail.IsNew = false;
                                oelCostofSalesTransaction.TransactionID = oelVoucherDetail.IdVoucherDetail.Value; //Validation.GetSafeGuid(DgvPurchases.Rows[i].Cells["ColTransaction"].Value);
                                oelCostofSalesTransaction.IsNew = false;
                            }
                            else
                            {
                                oelVoucherDetail.IdVoucherDetail = Guid.NewGuid();
                                oelVoucherDetail.IsNew = true;
                                oelCostofSalesTransaction.TransactionID = oelVoucherDetail.IdVoucherDetail.Value;
                                oelCostofSalesTransaction.IsNew = true;

                            }
                            oelVoucherDetail.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                            oelCostofSalesTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                            oelCostofSalesTransaction.IdCompany = Operations.IdCompany;
                            oelCostofSalesTransaction.IdUser = Operations.UserID;
                            oelCostofSalesTransaction.BookNo = Operations.BookNo;
                            if (DgvPurchases.Rows[j].Cells["colDescription"].Value == null)
                            {
                                oelVoucherDetail.VDiscription = "N/A";
                            }
                            else
                            {
                                oelVoucherDetail.VDiscription = DgvPurchases.Rows[j].Cells["colDescription"].Value.ToString();
                            }
                            oelVoucherDetail.Seq = j + 1;
                            oelVoucherDetail.Units = 0;
                            oelVoucherDetail.IdAccount = Validation.GetSafeGuid(DgvPurchases.Rows[j].Cells["colIdAccount"].Value);
                            oelVoucherDetail.AccountNo = Validation.GetSafeString(DgvPurchases.Rows[j].Cells["colAccountNo"].Value);
                            if (oelVoucherDetail.Debit != 0)
                            {
                                oelVoucherDetail.LinkAccountNo = Validation.GetSafeString(DgvPurchases.Rows[j].Cells["colLinkAccount"].Value);
                            }
                            oelVoucherDetail.Debit = Validation.GetSafeDecimal(DgvPurchases.Rows[j].Cells["colDebit"].Value);
                            oelVoucherDetail.Credit = Validation.GetSafeDecimal(DgvPurchases.Rows[j].Cells["colCredit"].Value);
                            if (DgvPurchases.Rows[j].Cells["colDebit"].Value != null && Validation.GetSafeLong(DgvPurchases.Rows[j].Cells["colDebit"].Value) > 0)
                            {
                                oelVoucherDetail.TransactionType = "Dr";
                            }
                            if (DgvPurchases.Rows[j].Cells["colCredit"].Value != null && Validation.GetSafeLong(DgvPurchases.Rows[j].Cells["colCredit"].Value) > 0)
                            {
                                oelVoucherDetail.TransactionType = "Cr";
                            }
                            oelCostofSalesTransaction.AccountNo = Validation.GetSafeString(DgvPurchases.Rows[j].Cells["colAccountNo"].Value);
                            oelCostofSalesTransaction.LinkAccountNo = Validation.GetSafeString(DgvPurchases.Rows[j].Cells["colLinkAccount"].Value);
                            oelCostofSalesTransaction.SubAccountNo = "0";
                            oelCostofSalesTransaction.VDate = VDate.Value;
                            oelCostofSalesTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                            oelCostofSalesTransaction.VoucherType = "StockReceiptVoucher/Sub";
                            oelCostofSalesTransaction.Discription = Validation.GetSafeString(DgvPurchases.Rows[j].Cells["colDescription"].Value);
                            oelCostofSalesTransaction.Debit = Validation.GetSafeDecimal(DgvPurchases.Rows[j].Cells["colDebit"].Value);
                            oelCostofSalesTransaction.Credit = Validation.GetSafeDecimal(DgvPurchases.Rows[j].Cells["colCredit"].Value);

                            if (oelCostofSalesTransaction.Debit != 0)
                            {
                                oelCostofSalesTransaction.TransactionType = "Dr";
                            }
                            else if (oelCostofSalesTransaction.Credit != 0)
                            {
                                oelCostofSalesTransaction.TransactionType = "Cr";
                            }

                            oelCostofSalesTransaction.Posted = chkPosted.Checked;
                            oelCostofSalesTransaction.AdjustmentType = -1;
                            oelCostofSalesTransaction.SettlementType = "Purchases";

                            oelCostOfSalesCollection.Add(oelVoucherDetail);
                            oelTransactionCollection.Add(oelCostofSalesTransaction);
                        }
                    }
                    #endregion
                    #region Save Code
                    if (IdVoucher == Guid.Empty)
                    {
                        var manager = new PurchaseHeadBLL();
                        var VManager = new VoucherBLL();
                        var ItemManager = new ItemsBLL();
                        //if (VManager.CheckVoucherNo(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text), "StockReceiptVoucher") == false)
                        //{

                            EntityoperationInfo infoResult = manager.InsertPurchases(oelVoucher, oelPurchaseDetailCollection, oelTransactionCollection, oelCostOfSalesCollection);
                            if (infoResult.IsSuccess)
                            {
                                if (VManager.GetMaxVoucherNumber("StockReceiptVoucher", Operations.IdCompany) == VEditBox.Text)
                                {
                                    ItemManager.UpdateCurrentUnitPrice(oelItemsCollection);
                                }
                                //manager.UpdateStockitems(oelTransactionCollection, "Add");
                                
                                MessageBox.Show("Purchases Done Successfully...");
                                ClearControl();
                                FillData();
                                
                            }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("This Voucher No Already Exists ; Plz Change Voucher No :");
                        //}
                    }
                    else
                    {
                        var manager = new PurchaseHeadBLL();
                        var VManager = new VoucherBLL();
                        var ItemManager = new ItemsBLL();
                        EntityoperationInfo infoResult = manager.UpdatePurchases(oelVoucher, oelPurchaseDetailCollection, oelTransactionCollection, oelCostOfSalesCollection);
                        if (infoResult.IsSuccess)
                        {
                            if (VManager.GetMaxVoucherNumber("StockReceiptVoucher", Operations.IdCompany) == VEditBox.Text)
                            {
                                ItemManager.UpdateCurrentUnitPrice(oelItemsCollection);
                            }
                            //manager.UpdateStockitems(oelTransactionCollection, "Add");
                            if (SilentOperation != 1)
                            {
                                MessageBox.Show("Purchases Updated Successfully...");
                                ClearControl();
                                FillData();
                                SilentOperation = 2;
                            }
                            else
                                SilentOperation = 2;
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<TransactionsEL> oelItemTransactionCollection = new List<TransactionsEL>();
            if (VEditBox.Text != string.Empty)
            {
                var manager = new PurchaseHeadBLL();
                if (IdVoucher != Guid.Empty)
                {
                    if (MessageBox.Show("Are You Sure To Delete ?", "Deleting Voucher", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (manager.DeletePurchases(IdVoucher))
                        {
                            MessageBox.Show("Voucher Deleted Successfully and Transactions Rolled Back");
                            ClearControl();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select Voucher To Delete....");
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnViewLedger_Click(object sender, EventArgs e)
        {
            if (SupplierAccountNo != string.Empty)
            {
                frmledger = new frmgeneralLedger();
                frmledger.AccountNo = SupplierAccountNo;
                frmledger.AccountName = SEditBox.Text;
                frmledger.Show();
            }
            else
            {
                MessageBox.Show("Select Supplier First To View Ledger...");
            }
        }
        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (SupplierAccountNo != string.Empty)
            {
                frmpersons = new frmPersons();
                frmpersons.AccountNo = SupplierAccountNo;
                frmpersons.Show();
            }
            else
                MessageBox.Show("Select Supplier First To View Detail");
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrint = new frmPurchaseOrderPrint();
            frmPrint.IdVoucher = IdVoucher;
            frmPrint.PrintType = "";
            frmPrint.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
            frmPrint.ShowDialog();
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
            FillVoucher("Voucher");
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            long PreviousVoucherNo = Convert.ToInt64(VEditBox.Text);
            PreviousVoucherNo -= 1;
            VEditBox.Text = PreviousVoucherNo.ToString();
            FillVoucher("Voucher");
        }
        #endregion
        #region ComboBox and Text Boxes Events
        private void cbxCashAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCashAccounts.SelectedIndex > 0)
            {
                CashAccountNo = Validation.GetSafeString(cbxCashAccounts.SelectedValue);
            }
            else
            {
                CashAccountNo = string.Empty;
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
        private void txtFreightAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.Handled = true;
            else if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                decimal ActualAmount = Validation.GetSafeDecimal(txtAmountAfterDiscount.Text);
                decimal Resultant = ActualAmount + Validation.GetSafeDecimal(txtFreightAmount.Text);
                txtTotalCredit.Text = Resultant.ToString();
                btnSave.Focus();
            }
        }
        private void txtFreightAmount_Leave(object sender, EventArgs e)
        {
            if (txtFreightAmount.Text != string.Empty)
            {
                decimal ActualAmount = Validation.GetSafeDecimal(txtAmountAfterDiscount.Text);
                decimal Resultant = ActualAmount + Validation.GetSafeDecimal(txtFreightAmount.Text);
                txtTotalCredit.Text = Resultant.ToString();
            }
        }
        private void txtVehicalNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    FillVoucher("Vehicle");
                }
            }
            else
                e.Handled = true;
        }
        #endregion
        #region Stock Grid Events
        private void DgvStockReceipt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                e.Value = "Delete";
            }
        }
        private void DgvStockReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                decimal lineAmount = 0;  //, value = 0;
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["colStockReceiptID"].Value == null)
                {
                    if (DgvStockReceipt.Rows.Count > 1)
                    {
                        DataGridViewRow oRow = DgvStockReceipt.Rows[e.RowIndex];
                        DgvStockReceipt.Rows.Remove(oRow);
                    }
                    //DataGridViewCell oCell = DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"];
                    //for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                    //{
                    //    value += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscountAmount"].Value);
                    //}
                    ////lineAmount = Validation.GetSafeDecimal(oCell.GetEditedFormattedValue(e.RowIndex, DataGridViewDataErrorContexts.Commit));
                    ////txtCreditBalance.Text = (Validation.GetSafeDecimal(txtCreditBalance.Text) - lineAmount).ToString();
                    //txtBillAmount.Text = value.ToString();
                    //txtTotalAmount.Text = Validation.GetSafeString(Validation.GetSafeDecimal(txtBillAmount.Text) + Validation.GetSafeDecimal(txtFreightAmount.Text));
                    if (DgvStockReceipt.Rows.Count - 1 == 0)
                    {
                        txtBillAmount.Text = string.Empty;
                        txtFreightAmount.Text = string.Empty;
                        txtTotalCredit.Text = string.Empty;
                    }
                    for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                    {
                        string CellValue = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colDiscount"].Value);
                        if (CellValue.Contains('%'))
                        {
                            CellValue = CellValue.Substring(0, CellValue.Length - 1);
                        }
                        BillingAmount += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                        //NormalDiscount += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscountAmount"].Value);
                        if (Validation.GetSafeDecimal(CellValue) > 0)
                        {
                            NormalDiscount += ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value) / 100)
                                                                                                  * Validation.GetSafeDecimal(CellValue));
                        }
                        BulkDiscount += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colFlatDiscount"].Value);
                        NetAmount += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscountAmount"].Value);
                    }
                    txtBillAmount.Text = Validation.GetSafeString(BillingAmount);
                    txtTotalDiscount.Text = Validation.GetSafeString(NormalDiscount);
                    txtFlatDiscount.Text = Validation.GetSafeString(BulkDiscount);
                    txtAmountAfterDiscount.Text = Validation.GetSafeString(BillingAmount - (NormalDiscount + BulkDiscount));
                    txtTotalCredit.Text = Validation.GetSafeString(NetAmount + Validation.GetSafeDecimal(txtFreightAmount.Text));
                    OldValue = 0;
                    BillingAmount = 0;
                    NormalDiscount = 0;
                    BulkDiscount = 0;
                    ValueAfterDiscount = 0;
                    NetAmount = 0;
                }
                else
                {
                    if (!chkPosted.Checked)
                    {
                        if (DgvStockReceipt.Rows.Count - 1 == 1)
                        {
                            MessageBox.Show("There Is Only One Record In This Voucher , Please Press Delete Button To Remove This Voucher");
                            return;
                        }
                        var Manager = new VoucherBLL();
                        lineAmount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value);
                        txtBillAmount.Text = (Validation.GetSafeDecimal(txtBillAmount.Text) - lineAmount).ToString();
                        txtTotalCredit.Text = Validation.GetSafeString(Validation.GetSafeDecimal(txtBillAmount.Text) + Validation.GetSafeDecimal(txtFreightAmount.Text));

                        if (Manager.DeleteChildRecords(Validation.GetSafeGuid(DgvStockReceipt.Rows[e.RowIndex].Cells["colStockReceiptID"].Value), "StockReceiptVoucher"))
                        {
                            DataGridViewRow oRow = DgvStockReceipt.Rows[e.RowIndex];
                            DgvStockReceipt.Rows.Remove(oRow);
                            for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                            {
                                string CellValue = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colDiscount"].Value);
                                if (CellValue.Contains('%'))
                                {
                                    CellValue = CellValue.Substring(0, CellValue.Length - 1);
                                }
                                BillingAmount += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                                //NormalDiscount += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscountAmount"].Value);
                                if (Validation.GetSafeDecimal(CellValue) > 0)
                                {
                                    NormalDiscount += ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value) / 100)
                                                                                                          * Validation.GetSafeDecimal(CellValue));
                                }
                                BulkDiscount += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colFlatDiscount"].Value);
                                NetAmount += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscountAmount"].Value);
                            }
                            txtBillAmount.Text = Validation.GetSafeString(BillingAmount);
                            txtTotalDiscount.Text = Validation.GetSafeString(NormalDiscount);
                            txtFlatDiscount.Text = Validation.GetSafeString(BulkDiscount);
                            txtAmountAfterDiscount.Text = Validation.GetSafeString(BillingAmount - (NormalDiscount + BulkDiscount));
                            txtTotalCredit.Text = Validation.GetSafeString(NetAmount + Validation.GetSafeDecimal(txtFreightAmount.Text));
                            OldValue = 0;
                            BillingAmount = 0;
                            NormalDiscount = 0;
                            BulkDiscount = 0;
                            ValueAfterDiscount = 0;
                            NetAmount = 0;
                            SilentOperation = 1;
                            btnSave_Click(sender, e);
                            //MessageBox.Show("This Voucher and Party Ledger Updated Automatically...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Voucher Is Posted...");
                    }

                }                                
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
            var manager = new ItemsBLL();            
            if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colQty")
            {
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["colIdItem"].Value != null)
                {
                    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value == null)
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value = manager.GetItemById(Validation.GetSafeGuid(DgvStockReceipt.Rows[e.RowIndex].Cells["colIdItem"].Value))[0].CurrentUnitPrice;
                    }
                    if (Validation.GetSafeLong(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) > 0)
                    {                       
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value));                        
                    }
                    else
                    {
                        if (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) > 0 && Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) > 0)
                        {
                           DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value));
                        }
                        else
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = 0;
                    }
                    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value != null && Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value.ToString().Replace('%', ' ')) > 0)
                    {
                        string CellValue = Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value);
                        if (CellValue.Contains('%'))
                        {
                            CellValue = CellValue.Substring(0, CellValue.Length - 1);
                        }
                        if (Validation.GetSafeDecimal(CellValue) > 0)
                        {
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscAmount"].Value = ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) / 100)
                                                                                      * Validation.GetSafeDecimal(CellValue));
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscAmount"].Value) + Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colFlatDiscount"].Value));

                        }
                        else
                        {
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscAmount"].Value) + Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colFlatDiscount"].Value));
                        }
                    }
                    else
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value = 0 + "%";
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);
                    }
                }
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colUnitPrice")
            {
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["colIdItem"].Value != null)
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value));
                    
                    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value != null && Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value.ToString().Replace('%', ' ')) > 0)
                    {
                        string CellValue = Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value);
                        if (CellValue.Contains('%'))
                        {
                            CellValue = CellValue.Substring(0, CellValue.Length - 1);
                        }
                        if (Validation.GetSafeDecimal(CellValue) > 0)
                        {
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscAmount"].Value = ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) / 100)
                                                                                      * Validation.GetSafeDecimal(CellValue));
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscAmount"].Value) + Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colFlatDiscount"].Value));

                        }
                        else
                        {
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscAmount"].Value) + Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colFlatDiscount"].Value));
                        }
                    }
                    else
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value = 0 + "%";
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value);
                    }
                }
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colDiscount")
            {
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value != null)
                {
                    string CellValue = Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value);
                    if (CellValue.Contains('%'))
                    {
                        CellValue = CellValue.Substring(0, CellValue.Length - 1);
                    }
                    if (Validation.GetSafeDecimal(CellValue) > 0)
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value = CellValue + "%";
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscAmount"].Value = ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) / 100)
                                                                                      * Validation.GetSafeDecimal(CellValue));
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscAmount"].Value) + Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colFlatDiscount"].Value));

                    }
                    else
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscAmount"].Value = 0;
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscAmount"].Value) + Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colFlatDiscount"].Value));
                    }
                }
                else
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value = 0 + "%";
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscAmount"].Value = 0;
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscAmount"].Value) + Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colFlatDiscount"].Value));
                }
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colFlatDiscount")
            {
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscount"].Value != null)
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiscAmount"].Value) + Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colFlatDiscount"].Value));
                }
            }
            for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
            {
                BillingAmount += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                NormalDiscount += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscAmount"].Value);
                BulkDiscount += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colFlatDiscount"].Value);
                NetAmount += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiscountAmount"].Value);
            }
            txtBillAmount.Text = Validation.GetSafeString(BillingAmount);
            txtTotalDiscount.Text = Validation.GetSafeString(NormalDiscount);
            txtFlatDiscount.Text = Validation.GetSafeString(BulkDiscount);
            txtAmountAfterDiscount.Text = Validation.GetSafeString(BillingAmount - (NormalDiscount + BulkDiscount));
            txtTotalCredit.Text = Validation.GetSafeString(NetAmount + Validation.GetSafeDecimal(txtFreightAmount.Text));
            OldValue = 0;
            BillingAmount = 0;
            NormalDiscount = 0;
            BulkDiscount = 0;
            ValueAfterDiscount = 0;
            NetAmount = 0;

        }
        private void DgvStockReceipt_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colUnitPrice")
            //{
            //    DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value));
            //}
            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
            //    for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
            //    {
            //        OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
            //    }
            //    txtCreditBalance.Text = OldValue.ToString();
            //    OldValue = 0;
            //    //if (IsImport)
            //    //{
            //    //    txtVat.Text = "0";
            //    //    txtVATAmount.Text = "0";
            //    //}
            //    //else
            //    //{
            //    //    txtVat.Text = ((Validation.GetSafeDecimal(txtCreditBalance.Text) * 5) / 100).ToString();
            //    //    txtVATAmount.Text = (Validation.GetSafeDecimal(txtCreditBalance.Text) + Validation.GetSafeDecimal(txtVat.Text)).ToString();
            //    //}
            //}
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
        private void DgvStockReceipt_KeyDown(object sender, KeyEventArgs e)
        {
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
        #endregion
        #region Custom Controls Events And Methods
        private void txtPoNumber_ButtonClick(object sender, EventArgs e)
        {
            frmcustomerpo = new frmCustomerPOS();
            frmcustomerpo.ExecuteFindAccountEvent += new frmCustomerPOS.FindCustomerPoDelegate(frmcustomerpo_ExecuteFindAccountEvent);
            frmcustomerpo.ShowDialog();
        }
        void frmcustomerpo_ExecuteFindAccountEvent(object Sender, OrdersEL oelOrder)
        {
            if(oelOrder != null)
            {
                IdOrder = oelOrder.IdOrder;
                txtPoNumber.Text = oelOrder.CustomerPo;
            }
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
                    EventTime = 1;
                    SupplierAccountNo = oelAccount.AccountNo;
                    SEditBox.Text = oelAccount.AccountName;
                    txtSupplierClosingBalance.Text = GetClosingBalance(oelAccount.AccountNo).ToString();
                    //LinkAccountNo = Validation.GetSafeString(oelAccount.AccountNo);
                    EventTime = 0;
                    //txtSupplierName.Text = list[0].PersonName;
                    //txtContact.Text = list[0].Contact;
                    //txtNTN.Text = list[0].NTN;
                    //txtAddress.Text = list[0].Address;
                    //lblStatuMessage.Text = "";
                }
                //else
                //{
                //lblStatuMessage.Text = "Please Select Supplier";
                //}
            }
            else if (EventCommandName == "DgvPurchases")
            {
                DgvPurchases.CurrentRow.Cells["colHeadType"].Value = oelAccount.AccountType;
                DgvPurchases.CurrentRow.Cells["colAccountNo"].Value = oelAccount.AccountNo;
                DgvPurchases.CurrentRow.Cells["colLinkAccount"].Value = oelAccount.LinkAccountNo;
                DgvPurchases.CurrentRow.Cells["colIdAccount"].Value = oelAccount.IdAccount;
                DgvPurchases.CurrentRow.Cells["colAccountName"].Value = oelAccount.AccountName;
                DgvPurchases.CurrentRow.Cells["colClosingBalance"].Value = GetClosingBalance(oelAccount.AccountNo);
            }           
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            DgvStockReceipt.RefreshEdit();
            DgvPurchases.RefreshEdit();
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
            else
            {
                MessageBox.Show("Wrong Account...");
            }
        }
        private void VEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindVouchers = new frmFindVouchers();
            frmfindVouchers.VoucherType = "StockReceiptVoucher";
            frmfindVouchers.ExecuteFindVouchersEvent += new frmFindVouchers.VouchersDelegate(frmfindVouchers_ExecuteFindVouchersEvent);
            frmfindVouchers.ShowDialog(this);
        }
        void frmfindVouchers_ExecuteFindVouchersEvent(VouchersEL oelVoucher)
        {
            VoucherNo = oelVoucher.VoucherNo;
            IdVoucher = oelVoucher.IdVoucher;
            VEditBox.Text = oelVoucher.VoucherNo.ToString();
            FillVoucher("Voucher");

        }
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    FillVoucher("Voucher");
                }
            }
            else
                e.Handled = true;
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
                    if (EventTime == 0)
                    {
                        EventCommandName = "Persons";
                        e.Handled = true;
                        frmAccount = new frmFindAccounts();
                        frmAccount.SearchText = e.KeyChar.ToString();
                        frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                        frmAccount.ShowDialog();
                    }
                }
                else
                    e.Handled = false;
            }
        }
        private void SEditBox_TextChanged(object sender, EventArgs e)
        {
            //if (EventTime == 0)
            //{

            //    frmAccount = new frmFindAccounts();
            //    frmAccount.SearchText = SEditBox.Text;
            //    frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            //    frmAccount.ShowDialog();
            //}
        }
        #endregion
        #region Purchases Grid Code and Events
        private void DgvPurchases_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvPurchases.Columns[e.ColumnIndex].Name == "colDebit")
            {

                for (int i = 0; i < DgvPurchases.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvPurchases.Rows[i].Cells["colDebit"].Value);
                }
                //txtAmount.Text = OldValue.ToString();
                txtDebit.Text = OldValue.ToString();
                OldValue = 0;

            }
            else if (DgvPurchases.Columns[e.ColumnIndex].Name == "colCredit")
            {
                for (int i = 0; i < DgvPurchases.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvPurchases.Rows[i].Cells["colCredit"].Value);
                }
                //txtAmount.Text = OldValue.ToString();
                txtCredit.Text = OldValue.ToString();
                OldValue = 0;
            }
        }
        private void DgvPurchases_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvPurchases.Columns[e.ColumnIndex].Name == "colDebit")
            {
                if (DgvPurchases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    DgvPurchases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
            else if (DgvPurchases.Columns[e.ColumnIndex].Name == "colCredit")
            {
                if (DgvPurchases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    DgvPurchases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
        }
        private void DgvPurchases_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvPurchases.CurrentCellAddress.X == 6)
            {
                TextBox txtAccountName = e.Control as TextBox;
                if (txtAccountName != null)
                {
                    txtAccountName.KeyPress -= new KeyPressEventHandler(txtAccountName_KeyPress);
                    txtAccountName.KeyPress += new KeyPressEventHandler(txtAccountName_KeyPress);
                }
            }
        }
        void txtAccountName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvPurchases.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmAccount = new frmFindAccounts();
                    EventCommandName = "DgvPurchases";
                    frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                    frmAccount.SearchText = e.KeyChar.ToString();
                    frmAccount.ShowDialog(this);
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
        #endregion
        #region Tab Related Event
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedIndex == 1)
            {
                CreateAndInitializeFooterRow();
            }
        }
        #endregion
        #region Radion Buttons Methods and Events
        private void rdCredit_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCredit.Checked)
            {
                IsNetTransaction = false;
                rdCash.Checked = false;
                pnlCash.Visible = false;
            }
        }
        private void rdCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCash.Checked)
            {
                IsNetTransaction = true;
                rdCredit.Checked = false;
                pnlCash.Visible = true;
                //FillCashAccounts("");
            }
        }
        private void rdCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && rdCredit.Checked)
            {
                DgvStockReceipt.Focus();
            }
            else
            {
                rdCash.Focus();
            }
        }
        private void rdCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && rdCash.Checked)
            {
                DgvStockReceipt.Focus();
            }
        }
        #endregion
        #region Transactional Methods
        private decimal GetClosingBalance(string AccountNo)
        {
            var manager = new TransactionBLL();
            return manager.GetAccountClosingBalance(AccountNo, Operations.IdCompany);
        }
        private bool IsCashORbankAccountInvolve()
        {
            bool HeadStatus = false;
            for (int i = 0; i < DgvPurchases.Rows.Count - 1; i++)
            {
                if (Validation.GetSafeString(DgvPurchases.Rows[i].Cells["colHeadType"].Value) == "Cash Balance Head" ||
                    Validation.GetSafeString(DgvPurchases.Rows[i].Cells["colHeadType"].Value) == "Bank Balance Head")
                {
                    HeadStatus = true;
                    break;
                }
                else
                {
                    HeadStatus = false;
                    break;
                }
            }
            return HeadStatus;
        }
        private bool AccountTransactionStatus(out string Message)
        {
            bool TransactionStatus = true;
            Message = "";
            for (int i = 0; i < DgvPurchases.Rows.Count - 1; i++)
            {
                if (Validation.GetSafeString(DgvPurchases.Rows[i].Cells["colHeadType"].Value) == "Cash Balance Head" ||
                    Validation.GetSafeString(DgvPurchases.Rows[i].Cells["colHeadType"].Value) == "Bank Balance Head")
                {
                    if (Validation.GetSafeDecimal(DgvPurchases.Rows[i].Cells["colCredit"].Value) == 0 || Validation.GetSafeDecimal(DgvPurchases.Rows[i].Cells["colCredit"].Value) < 0)
                    {
                        Message = "Cash OR Bank Account Must Be Credited...";
                        TransactionStatus = false;
                    }
                    break;
                }
            }
            return TransactionStatus;
        }
        private bool IsTransactionalAccountExceeding(out string Message)
        {
            bool status = false;
            Message = string.Empty;
            for (int i = 0; i < DgvPurchases.Rows.Count - 1; i++)
            {
                if (Validation.GetSafeString(DgvPurchases.Rows[i].Cells["colHeadType"].Value) == "Cash Balance Head" ||
                    Validation.GetSafeString(DgvPurchases.Rows[i].Cells["colHeadType"].Value) == "Bank Balance Head")
                {
                    if (Validation.GetSafeDecimal(DgvPurchases.Rows[i].Cells["colCredit"].Value) > Validation.GetSafeDecimal(DgvPurchases.Rows[i].Cells["colClosingBalance"].Value))
                    {
                        Message = "Cash OR Bank Account Is Exceeding Credit Limit With Closing Balance...";
                        status = true;
                        break;
                    }
                }
            }
            return status;
        }
        private void FillVoucher(string LoadType)
        {
            var Manager = new VoucherBLL();
            var PManager = new PurchaseHeadBLL();
            List<VoucherDetailEL> list = null;
            VoucherType = "StockReceiptVoucher";
            lblVoucherStatus.Text = string.Empty;
            if (VEditBox.Text != string.Empty)
            {
                #region VoucherHeadInformation
                if (LoadType == "Voucher")
                {
                    list = PManager.GetPurchasesByVoucher(Validation.GetSafeLong(VEditBox.Text), Operations.IdCompany, IsNetTransaction);
                }
                if (list.Count > 0)
                {
                    IdVoucher = list[0].IdVoucher;
                    IdOrder = list[0].IdOrder;
                    VEditBox.Enabled = false;
                    txtPoNumber.Text = list[0].PoNumber;
                    txtBillNo.Text = list[0].BillNo;
                    VDate.Value = list[0].VDate.Value;
                    txtDescription.Text = list[0].VDiscription;
                    LinkAccountNo = list[0].LinkAccountNo;
                    cbxPurchaser.SelectedIndex = list[0].Purchaser;
                    txtSupplierClosingBalance.Text = list[0].ClosingBalance.ToString();
                    txtBillAmount.Text = list[0].BillAmount.ToString();
                    txtTotalDiscount.Text = list[0].TotalDiscount.ToString();
                    txtFlatDiscount.Text = list[0].ExtraDiscount.ToString();
                    txtAmountAfterDiscount.Text = list[0].BillAmountAfterDiscount.ToString();
                    txtFreightAmount.Text = list[0].TotalFreight.ToString();
                    txtTotalCredit.Text = list[0].TotalAmount.ToString();
                    SupplierAccountNo = list[0].AccountNo;
                    FillCreditorCredentials(list[0].AccountNo);
                    IsNetTransaction = list[0].IsNetTransaction;
                    if (IsNetTransaction)
                    {
                        pnlCash.Visible = true;
                        rdCash.Checked = true;
                        rdCredit.Checked = false;
                    }
                    else
                    {
                        pnlCash.Visible = false;
                        rdCash.Checked = false;
                        rdCredit.Checked = true;
                    }
                    //txtVat.Text = list[0].VAT.ToString();
                    //txtVATAmount.Text = list[0].VATAmount.ToString();
                    HandleVoucher(list);
                    FillTransactions(list);
                    #region PurchaseTransactionInformation
                    List<TransactionsEL> listTransactions = Manager.GetTransactions(IdVoucher, "StockReceiptVoucher", Operations.IdCompany);

                    if (listTransactions.Count > 0)
                    {
                        TransactionsEL oelPurchaseTransaction = listTransactions.Find(x => x.Debit != 0);
                        if (oelPurchaseTransaction != null)
                        {
                            FillNaturalAccounts(oelPurchaseTransaction.AccountNo.ToString());
                            PurchasesAccountNo = oelPurchaseTransaction.AccountNo.ToString();
                            PurchasesTransactionId = oelPurchaseTransaction.TransactionID;
                        }
                        if (!IsNetTransaction)
                        {
                            TransactionsEL oelSupplierTransaction = listTransactions.Find(x => x.Credit != 0);
                            if (oelSupplierTransaction != null)
                            {
                                EventTime = 1;
                                SEditBox.Text = Validation.GetSafeString(oelSupplierTransaction.AccountName);
                                txtContact.Text = list[0].Contact;
                                EventTime = 0;
                                SupplierAccountNo = oelSupplierTransaction.AccountNo;
                                SupplierTransactionId = oelSupplierTransaction.TransactionID;
                            }
                        }
                        else
                        {
                            TransactionsEL oelCashTransaction = listTransactions.Find(x => x.Credit != 0);
                            if (oelCashTransaction != null)
                            {
                                EventTime = 1;
                                FillCashAccounts(oelCashTransaction.AccountNo.ToString());
                                CashAccountNo = oelCashTransaction.AccountNo;
                                CashTransactionId = oelCashTransaction.TransactionID;
                            }
                        }

                    }
                    #endregion
                    #region Purchase Expense Information
                    List<TransactionsEL> listPurchasesExpense = Manager.GetTransactions(IdVoucher, "StockReceiptVoucher/Sub", Operations.IdCompany);
                    if (listPurchasesExpense.Count > 0)
                    {
                        FillPurchasesExpenses(listPurchasesExpense);
                    }
                    else
                    {
                        DgvPurchases.Rows.Clear();
                    }

                    //List<TransactionsEL> List = Manager.GetTransactionsByVoucherAndType(Operations.IdCompany, list[0].IdVoucher, Validation.GetSafeLong(VEditBox.Text), VoucherType);
                    //FillTransactions(List);
                    #endregion
                }
                else
                {
                    if (LoadType == "Voucher")
                    {
                        MessageBox.Show("Voucher Number Not Found ...");
                    }
                    else
                    {
                        MessageBox.Show("Vehicle Number Not Found ...");
                    }
                    ClearControl();
                }
                #endregion
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
            else if (list[0].Posted && list[0].IsDeleted == null)
            {
                chkPosted.Checked = true;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                chkPosted.Enabled = true;
                lblVoucherStatus.Text = "Posted Voucher";
            }
            else if (!list[0].Posted && list[0].IsDeleted == null)
            {
                chkPosted.Checked = false;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                chkPosted.Enabled = true;
                lblVoucherStatus.Text = "UnPosted Voucher";
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
                    DgvStockReceipt.Rows[i].Cells[6].Value = List[i].Bonus;
                    DgvStockReceipt.Rows[i].Cells[7].Value = List[i].UnitPrice;
                    DgvStockReceipt.Rows[i].Cells[8].Value = List[i].Amount;
                    DgvStockReceipt.Rows[i].Cells[9].Value = List[i].Discount;
                    DgvStockReceipt.Rows[i].Cells[10].Value = List[i].DiscountAmount;
                    DgvStockReceipt.Rows[i].Cells[11].Value = List[i].FlatDiscount;
                    DgvStockReceipt.Rows[i].Cells[12].Value = List[i].NetAmount;
                    //if (List[i].Discount == 0)
                    //{
                    //    DgvStockReceipt.Rows[i].Cells[10].Value = "";
                    //}
                    //else
                    //{
                    //    DgvStockReceipt.Rows[i].Cells[10].Value = List[i].Discount;
                    //}
                    //DgvStockReceipt.Rows[i].Cells[11].Value = List[i].TotalAmount; //List[i].Qty * List[i].unitprice;

                    ////txtCreditBalance.Text = List.Sum(x => x.Amount).ToString();
                    //txtTotalCredit.Text = List[0].Amount.ToString("0.00");
                    // DgvStockReceipt.DataSource = List;
                    //
                }
            }
        }
        private void FillPurchasesExpenses(List<TransactionsEL> List)
        {
            if (DgvPurchases.Rows.Count > 0)
            {
                DgvPurchases.Rows.Clear();
            }
            for (int i = 0; i < List.Count; i++)
            {
                DgvPurchases.Rows.Add();
                DgvPurchases.Rows[i].Cells[0].Value = List[i].AccountType;
                DgvPurchases.Rows[i].Cells[1].Value = List[i].TransactionID;
                DgvPurchases.Rows[i].Cells[2].Value = List[i].TransactionID;
                DgvPurchases.Rows[i].Cells[3].Value = List[i].IdAccount;
                DgvPurchases.Rows[i].Cells[4].Value = List[i].AccountNo;
                DgvPurchases.Rows[i].Cells[5].Value = List[i].LinkAccountNo;
                DgvPurchases.Rows[i].Cells[6].Value = List[i].AccountName;
                DgvPurchases.Rows[i].Cells[7].Value = List[i].ClosingBalance;
                DgvPurchases.Rows[i].Cells[8].Value = List[i].Description;
                DgvPurchases.Rows[i].Cells[9].Value = List[i].Debit;
                DgvPurchases.Rows[i].Cells[10].Value = List[i].Credit;
            }
            txtDebit.Text = List.Sum(x => x.Debit).ToString();
            txtCredit.Text = List.Sum(x => x.Credit).ToString();
        }
        #endregion
    }
}
