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

namespace Accounts.UI
{
    public partial class frmSalesReturn : MetroForm
    {
        frmStockAccounts frmstockAccounts;
        frmFindAccounts frmAccount;
        frmFindVouchers frmfindVouchers;
        frmReports frmReport;
        public decimal OldValue { get; set; }
        public Int64 InvoiceNo { get; set; }
        public Guid IdVoucher = Guid.Empty;
        public Guid CustomerTransactionId { get; set; }
        public Guid SalesReturnTransactionId { get; set; }
        bool IsNewInvoice;
        public string VoucherType { get; set; }
        public bool IsImport { get; set; }
        string CommandType = "";
        string SalesAccountNo = string.Empty;
        public frmSalesReturn()
        {
            InitializeComponent();
        }

        private void frmSalesReturn_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            FillData();
            FillNaturalAccounts(string.Empty);
            CheckModulePermissions();
            if (IsImport)
            {
                this.Text = "Import Sales Return";
                lblVAT.Visible = false;
                txtVAT.Visible = false;
                lblVATAmount.Visible = false;
                txtVATAmount.Visible = false;

            }
            else
            {
                this.Text = "Local Sales Return";
                lblVAT.Visible = true;
                txtVAT.Visible = true;
                lblVATAmount.Visible = false;
                txtVATAmount.Visible = true;
            }
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
                if (PermissionsList[0].Printing == true)
                {
                    btnPrint.Enabled = true;
                }
                else
                {
                    btnPrint.Enabled = false;
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
            InvEditBox.Text = manager.GetMaxVoucherNumber("SalesReturnVoucher", Operations.IdCompany);
        }
        private void FillNaturalAccounts(string SaleAccount)
        {
            if (SaleAccount == "")
            {
                var manager = new AccountsBLL();
                List<AccountsEL> list = manager.GetAccountsByType("Net SALES", Operations.IdCompany);
                if (list.Count > 0)
                {

                    list.Insert(0, new AccountsEL() { AccountNo = "0", AccountName = "Select Sales Account" });

                    cbxNaturalAccounts.DataSource = list;
                    cbxNaturalAccounts.DisplayMember = "AccountName";
                    cbxNaturalAccounts.ValueMember = "AccountNo";

                }
            }
            else
            {
                cbxNaturalAccounts.SelectedValue = SaleAccount;
            }
        }
        private void CustEditBox_ButtonClick(object sender, EventArgs e)
        {
            CommandType = "Persons";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        private void EmpEditCode_ButtonClick(object sender, EventArgs e)
        {
            CommandType = "Employees";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            if (CommandType == "Persons")
            {
                var manager = new PersonsBLL();
                List<PersonsEL> list = manager.VerifyAccount(Operations.IdCompany, "Persons", oelAccount.AccountNo);
                if (list.Count > 0)
                {
                    CustEditBox.Text = oelAccount.AccountNo.ToString();
                    txtCustomerName.Text = list[0].PersonName;
                    txtContact.Text = list[0].Contact;
                    txtNTN.Text = list[0].NTN;
                    txtAddress.Text = list[0].Address;
                    lblStatuMessage.Text = "";
                    lblStatuMessage.Text = "";
                }
                else
                {
                    lblStatuMessage.Text = "Please Select Customer";
                }
            }
            else if (CommandType == "Employees")
            {
                var manager = new PersonsBLL();
                //List<PersonsEL> list = manager.VerifyAccount("Customers/Suppliers", oelChartOfAccount.AccountNo);
                List<PersonsEL> list = manager.VerifyAccount(Operations.IdCompany, "Persons", oelAccount.AccountNo);
                if (list.Count > 0)
                {
                    EmpEditCode.Text = oelAccount.AccountNo.ToString();
                    txtEmployeeName.Text = list[0].PersonName;
                    txtEmployeeContact.Text = list[0].Contact;
                    lblStatuMessage.Text = "";
                }
                else
                {
                    lblStatuMessage.Text = "Please Select Customer";
                }
            }
            else if (CommandType == "Sales")
            {
                SalesEditBox.Text = oelAccount.AccountNo.ToString();
                //txtSalesAccountName.Text = oelAccount.AccountName;
            }
        }
        private void DgvSaleInvoice_KeyDown(object sender, KeyEventArgs e)
        {
        }

        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            var manager = new ItemsBLL();
            if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.AccountNo).Count > 0)
            {
                //for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
                //{
                //    if (DgvSaleInvoice.Rows[i].Cells["colItem"].Value != null)
                //    {
                //        if (oelItems.AccountNo == Validation.GetSafeString(DgvSaleInvoice.Rows[i].Cells["colItem"].Value))
                //        {
                //            lblStatuMessage.Text = "Item Already exists";
                //            return;
                //        }
                //    }
                //}
                lblStatuMessage.Text = "";
                DgvSaleInvoice.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
                DgvSaleInvoice.CurrentRow.Cells["colItem"].Value = oelItems.AccountNo;
                DgvSaleInvoice.CurrentRow.Cells["colProductName"].Value = oelItems.AccountName;
                DgvSaleInvoice.CurrentRow.Cells["colPackingSize"].Value = oelItems.PackingSize;
                //DgvSaleInvoice.CurrentRow.Cells["colBatch"].Value = oelItems.BatchNo;
                //DgvSaleInvoice.CurrentRow.Cells["colRemarks"].Selected = true;
            }
            else
            {
                lblStatuMessage.Text = "Wrong Account For Sale";
            }
        }
        private void ClearControl()
        {
            DgvSaleInvoice.Rows.Clear();
            IdVoucher = Guid.Empty;
            InvEditBox.Enabled = true;
            txtDescription.Text = string.Empty;
            InvoiceNo = 0;
            txtGatePass.Text = string.Empty;
            txtOutWardGatePass.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            txtVAT.Text = string.Empty;
            txtVATAmount.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtNTN.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDescription.Text = string.Empty;
            EmpEditCode.Text = string.Empty;
            txtEmployeeContact.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            cbxReturnType.SelectedIndex = -1;


            //txtCashReceipt.Text = string.Empty;
            CustomerTransactionId = Guid.Empty;
            SalesReturnTransactionId = Guid.Empty;
            SalesAccountNo = string.Empty;
            SalesEditBox.Text = string.Empty;

            IsNewInvoice = true;
            CustEditBox.Text = string.Empty;
            if (chkPosted.Checked)
            {
                chkPosted.Checked = false;
                chkPosted.Enabled = true;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
        private bool ValidateRows()
        {
            bool Status = true;
            if (DgvSaleInvoice.Rows.Count > 1)
            {
                for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
                {
                    if (DgvSaleInvoice.Rows[i].Cells["colItem"].Value == null)
                    {
                        Status = false;
                    }
                    else if (DgvSaleInvoice.Rows[i].Cells["colQty"].Value == null)
                    {
                        Status = false;
                    }
                }
            }
            else if (DgvSaleInvoice.Rows.Count == 1)
            {
                Status = false;
            }
            if (SalesAccountNo == string.Empty)
            {
                Status = false;
                lblStatuMessage.Text = "Select Sales Account :";
            }
            if (CustEditBox.Text == string.Empty)
            {
                Status = false;
                lblStatuMessage.Text = "Select Customer Account :";
            }
            return Status;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Variables
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            List<VoucherDetailEL> oelSaleCollection = new List<VoucherDetailEL>();
            #endregion 
            #region Main
            if (ValidateRows())
            {
                #region Header Voucher Information
                /// Add Voucher...
                VouchersEL oelVoucher = new VouchersEL();
                if (IdVoucher == Guid.Empty)
                {
                    oelVoucher.IdVoucher = Guid.NewGuid();
                }
                else
                {
                    oelVoucher.IdVoucher = IdVoucher;
                }
                oelVoucher.IdCompany = Operations.IdCompany;
                oelVoucher.VoucherNo = Convert.ToInt32(InvEditBox.Text);
                oelVoucher.BookNo = Operations.BookNo;
                oelVoucher.IdUser = Operations.UserID;
                oelVoucher.VDate = VDate.Value;
                oelVoucher.AccountNo = Validation.GetSafeString(CustEditBox.Text);
                oelVoucher.SubAccountNo = Validation.GetSafeString(EmpEditCode.Text);
                oelVoucher.Discription = txtDescription.Text;
                oelVoucher.MemoSaleNo = Convert.ToInt64(txtSaleMemoNo.Text == "" ? "0" : txtSaleMemoNo.Text);
                oelVoucher.InWardGatePassNo = Validation.GetSafeString(txtGatePass.Text);
                oelVoucher.OutWardGatePassNo = Validation.GetSafeString(txtOutWardGatePass.Text);
                oelVoucher.Amount = Convert.ToDecimal(txtTotalAmount.Text == "" ? "0" : txtTotalAmount.Text);
                oelVoucher.VAT = Validation.GetSafeDecimal(txtVAT.Text);
                oelVoucher.VATAmount = Validation.GetSafeDecimal(txtVATAmount.Text);
                oelVoucher.IsImport = IsImport;
                oelVoucher.Posted = chkPosted.Checked;
                if (cbxReturnType.Text == "Sales Return")
                {
                    oelVoucher.ReturnType = 1;
                }
                else if (cbxReturnType.Text == "Claim Return")
                {
                    oelVoucher.ReturnType = 2;
                }
                else if (cbxReturnType.Text == "")
                {
                    MessageBox.Show("Please Select Return Type");
                }
                #endregion
                #region Add Items 
                for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    VoucherDetailEL oelSaleDetail = new VoucherDetailEL();
                    //StockReceiptEL oelStockReciept = new StockReceiptEL();

                    //First Add Returned Sales
                    if (DgvSaleInvoice.Rows[i].Cells["colSale"].Value != null)
                    {
                        oelSaleDetail.IdVoucherDetail = new Guid(DgvSaleInvoice.Rows[i].Cells["colSale"].Value.ToString());
                        oelSaleDetail.IsNew = false;
                    }
                    else
                    {
                        oelSaleDetail.IdVoucherDetail = Guid.NewGuid();
                        oelSaleDetail.IsNew = true;
                    }
                    oelSaleDetail.IdVoucher = oelVoucher.IdVoucher;
                    oelSaleDetail.Seq = i + 1;
                    oelSaleDetail.ItemNo = DgvSaleInvoice.Rows[i].Cells["colItem"].Value.ToString();
                    //oelSaleDetail.BatchNo = Validation.GetSafeString(DgvSaleInvoice.Rows[i].Cells["colBatch"].Value);
                    //oelSaleDetail.Expiry = Validation.GetSafeString(DgvSaleInvoice.Rows[i].Cells["colExpiry"].Value);
                    oelSaleDetail.IdAccount = Validation.GetSafeGuid(DgvSaleInvoice.Rows[i].Cells["colIdItem"].Value);
                    oelSaleDetail.VoucherNo = Convert.ToInt64(InvEditBox.Text);
                    oelSaleDetail.Units = Convert.ToInt32(DgvSaleInvoice.Rows[i].Cells["colQty"].Value);
                    oelSaleDetail.Amount = Convert.ToInt32(DgvSaleInvoice.Rows[i].Cells["colAmount"].Value);
                    oelSaleDetail.UnitPrice = Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colUnitPrice"].Value);
                    oelSaleCollection.Add(oelSaleDetail);

                }
                #endregion
                #region  Add Customer...
                TransactionsEL oeTransaction = new TransactionsEL();
                if (CustomerTransactionId != Guid.Empty)
                {
                    oeTransaction.TransactionID = CustomerTransactionId;
                    oeTransaction.IsNew = false;
                }
                else
                {
                    oeTransaction.TransactionID = Guid.NewGuid();
                    oeTransaction.IsNew = true;
                }
                oeTransaction.IdCompany = Operations.IdCompany;
                oeTransaction.BookNo = Operations.BookNo;
                oeTransaction.AccountNo = Validation.GetSafeString(CustEditBox.Text);
                oeTransaction.VDate = VDate.Value;
                oeTransaction.VoucherNo = Convert.ToInt32(InvEditBox.Text);
                oeTransaction.SubAccountNo = Validation.GetSafeString(EmpEditCode.Text);
                oeTransaction.VoucherType = "SalesReturnVoucher";
                oeTransaction.Discription = txtDescription.Text;
                oeTransaction.Debit = 0;
                if(IsImport)
                    oeTransaction.Credit = Convert.ToDecimal(txtTotalAmount.Text);
                else
                    oeTransaction.Credit = Convert.ToDecimal(txtVATAmount.Text);
                oeTransaction.TransactionType = "Cr";
                oeTransaction.Posted = chkPosted.Checked;
                //if (txtCashReceipt.Text == string.Empty)
                //{
                //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                //}
                //else
                //{
                //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtCashReceipt.Text);
                //}
                oelTransactionCollection.Add(oeTransaction);
                #endregion
                #region Add Sales Account In Transactions
                /// Add Sales Account...
                TransactionsEL oelSaleTransaction = new TransactionsEL();
                if (SalesReturnTransactionId != Guid.Empty)
                {
                    oelSaleTransaction.TransactionID = SalesReturnTransactionId;
                    oelSaleTransaction.IsNew = false;
                }
                else
                {
                    oelSaleTransaction.TransactionID = Guid.NewGuid();
                    oelSaleTransaction.IsNew = true;
                }
                oelSaleTransaction.IdCompany = Operations.IdCompany;
                oelSaleTransaction.BookNo = Operations.BookNo;
                //oelSaleTransaction.AccountNo = Validation.GetSafeLong(SalesEditBox.Text);
                oelSaleTransaction.AccountNo = SalesAccountNo;
                oelSaleTransaction.SubAccountNo = Validation.GetSafeString(EmpEditCode.Text);
                oelSaleTransaction.VDate = VDate.Value;
                oelSaleTransaction.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                oelSaleTransaction.VoucherType = "SalesReturnVoucher";
                oelSaleTransaction.Discription = txtDescription.Text;
                if (IsImport)
                {
                    oelSaleTransaction.Debit = Validation.GetSafeDecimal(txtTotalAmount.Text);
                }
                else
                    oelSaleTransaction.Debit = Validation.GetSafeDecimal(txtVATAmount.Text);
                oelSaleTransaction.Credit = 0;
                oelSaleTransaction.TransactionType = "Dr";
                //if (txtCashReceipt.Text == string.Empty)
                //{
                //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                //}
                //else
                //{
                //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtCashReceipt.Text);
                //}
                oelSaleTransaction.Posted = chkPosted.Checked;
                oelTransactionCollection.Add(oelSaleTransaction);
                #endregion region
                #region Saving Code
                if (IdVoucher == Guid.Empty)
                {
                    var manager = new SalesHeadBLL(); //SalesVoucherBLL();
                    //if (manager.InsertSalesReturn(oelVoucher, oelSaleCollection, oelTransactionCollection, oelStockRecieptCollection) == true)
                    var VManager = new VoucherBLL();
                    if (VManager.CheckVoucherNo(Operations.IdCompany, Validation.GetSafeLong(InvEditBox.Text), "SalesReturnVoucher") == false)
                    {
                        if (manager.InsertSalesReturn(oelVoucher, oelSaleCollection, oelTransactionCollection) == true)
                        {
                            //manager.UpdateStockitems(oelTransactionCollection, "Add");
                            lblStatuMessage.Text = "Sales Returned Successfully...";
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
                    var manager = new SalesHeadBLL(); //SalesVoucherBLL();
                    //if (manager.UpdateSalesReturn(oelVoucher, oelSaleCollection, oelTransactionCollection, oelStockRecieptCollection) == true)
                    if (manager.UpdateSalesReturn(oelVoucher, oelSaleCollection, oelTransactionCollection) == true)
                    {
                        //manager.UpdateStockitems(oelTransactionCollection, "Add");
                        lblStatuMessage.Text = "Sales Returns Updated Successfully...";
                        ClearControl();
                        FillData();
                    }
                }
                #endregion
            }
            else
            {
                lblStatuMessage.Text = "InComplete Entry";
                lblStatuMessage.ForeColor = Color.Red;
            }
            #endregion 
        }
        private void InvEditBox_KeyPress(object sender, KeyPressEventArgs e)
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
        private void InvEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindVouchers = new frmFindVouchers();
            frmfindVouchers.VoucherType = "SalesReturnVoucher";
            frmfindVouchers.ExecuteFindVouchersEvent += new frmFindVouchers.VouchersDelegate(frmfindVouchers_ExecuteFindVouchersEvent);
            frmfindVouchers.ShowDialog(this);
        }

        private void SalesEditBox_ButtonClick(object sender, EventArgs e)
        {
            CommandType = "Sales";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        void frmfindVouchers_ExecuteFindVouchersEvent(VouchersEL oelVoucher)
        {
            var manager = new SalesDetailBLL();
            if (oelVoucher != null)
            {
                InvoiceNo = oelVoucher.VoucherNo;
                InvEditBox.Text = oelVoucher.VoucherNo.ToString();
                IsNewInvoice = false;
                FillVoucher();
            }
        }
        private void FillVoucher()
        {
            var Manager = new VoucherBLL();
            var SalesManager = new SalesDetailBLL();
            VoucherType = "SalesReturnVoucher";
            if (InvEditBox.Text != string.Empty)
            {
                List<VouchersEL> list = Manager.GetVouchersByTypeAndVoucherNumber(Operations.IdCompany, VoucherType, Convert.ToInt64(InvEditBox.Text));
                if (list.Count > 0)
                {
                    IdVoucher = list[0].IdVoucher;
                    VDate.Value = list[0].Date;
                    InvEditBox.Enabled = false;
                    txtGatePass.Text = Validation.GetSafeString(list[0].InWardGatePassNo);
                    txtOutWardGatePass.Text = Validation.GetSafeString(list[0].OutWardGatePassNo);
                    txtVAT.Text = list[0].VAT.ToString();
                    txtVATAmount.Text = list[0].VATAmount.ToString();
                    if (list[0].ReturnType == 0)
                    {
                        cbxReturnType.SelectedIndex = -1;
                    }
                    else if (list[0].ReturnType == 1)
                    {
                        cbxReturnType.SelectedIndex = 0;
                    }
                    else if (list[0].ReturnType == 2)
                    {
                        cbxReturnType.SelectedIndex = 1;
                    }
                    if (list[0].Posted)
                    {
                        if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                        {
                            btnSave.Enabled = false;
                            btnDelete.Enabled = false;
                            chkPosted.Enabled = false;
                        }
                        chkPosted.Checked = list[0].Posted;
                        //chkPosted.Enabled = false;
                        lblStatuMessage.Text = "Posted Voucher ...";
                        lblStatuMessage.ForeColor = Color.Red;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                    }

                    List<TransactionsEL> listTransactions = Manager.GetTransactions(IdVoucher, "SalesReturnVoucher", Operations.IdCompany);

                    if (listTransactions.Count > 0)
                    {
                        TransactionsEL oelSalesTransaction = listTransactions.Find(x => x.Debit != 0);
                        if (oelSalesTransaction != null)
                        {
                            //SalesEditBox.Text = oelSalesTransaction.AccountNo.ToString();
                            FillNaturalAccounts(oelSalesTransaction.AccountNo.ToString());
                            //cbxNaturalAccounts.SelectedValue = oelSalesTransaction.AccountNo;
                            //txtSalesAccountName.Text = oelSalesTransaction.AccountName;
                            SalesAccountNo = oelSalesTransaction.AccountNo.ToString();
                            SalesReturnTransactionId = oelSalesTransaction.TransactionID;
                        }
                    }

                    List<PersonsEL> ListCustomer = Manager.GetSalesReturnCustomer(IdVoucher, list[0].AccountNo, Operations.IdCompany);
                    if (ListCustomer.Count > 0)
                    {
                        CustEditBox.Text = Validation.GetSafeString(ListCustomer[0].AccountNo);
                        txtCustomerName.Text = ListCustomer[0].PersonName;
                        //txtSaleMemoNo.Text = ListCustomer[0].MemoSaleNo.ToString();
                        CustomerTransactionId = ListCustomer[0].PAccountId;
                        txtContact.Text = ListCustomer[0].Contact;
                        txtNTN.Text = ListCustomer[0].NTN;
                        txtAddress.Text = ListCustomer[0].Address;
                    }

                    FillEmployee(ListCustomer[0].SubAccountNo);

                    List<VoucherDetailEL> SalesList = SalesManager.GetSalesReturnWithInvoiceNumber(Validation.GetSafeLong(InvEditBox.Text), Operations.IdCompany);
                    FillSalesTransaction(SalesList, ListCustomer[0].Balance);
                }
                else
                {
                    ClearControl();
                    MessageBox.Show("Voucher Number Not Found ...");
                }
            }


        }
        private void FillEmployee(string EmpCode)
        {
            var manager = new PersonsBLL();
            //List<PersonsEL> list = manager.VerifyAccount("Customers/Suppliers", oelChartOfAccount.AccountNo);
            List<PersonsEL> list = manager.VerifyAccount(Operations.IdCompany, "Persons", EmpCode);
            if (list.Count > 0)
            {
                EmpEditCode.Text = EmpCode.ToString();
                txtEmployeeName.Text = list[0].PersonName;
                txtEmployeeContact.Text = list[0].Contact;
                lblStatuMessage.Text = "";
            }
            else
            {
                lblStatuMessage.Text = "Please Select Customer";
            }
        }
        private void FillSalesTransaction(List<VoucherDetailEL> Salelist, decimal Amount)
        {
            var manager = new ItemsBLL();
            if (DgvSaleInvoice.Rows.Count > 0)
            {
                DgvSaleInvoice.Rows.Clear();
            }
            for (int i = 0; i < Salelist.Count; i++)
            {
                DgvSaleInvoice.Rows.Add();
                DgvSaleInvoice.Rows[i].Cells[0].Value = Salelist[i].IdVoucherDetail;
                DgvSaleInvoice.Rows[i].Cells[1].Value = Salelist[i].IdAccount;
                //DgvSaleInvoice.Rows[i].Cells[2].Value = Salelist[i];
                DgvSaleInvoice.Rows[i].Cells[2].Value = Salelist[i].ItemNo;
                DgvSaleInvoice.Rows[i].Cells[3].Value = Salelist[i].ItemName;
                DgvSaleInvoice.Rows[i].Cells[4].Value = Salelist[i].PackingSize;
                //DgvSaleInvoice.Rows[i].Cells[6].Value = Salelist[i].BatchNo;
                //DgvSaleInvoice.Rows[i].Cells[7].Value = Salelist[i].Description;
                DgvSaleInvoice.Rows[i].Cells[5].Value = Salelist[i].Units;
                DgvSaleInvoice.Rows[i].Cells[6].Value = Salelist[i].UnitPrice;//manager.GetItemPriceByCode(Salelist[0].ItemNo);
                DgvSaleInvoice.Rows[i].Cells[7].Value = Salelist[i].Amount;      //Salelist[i].Units * Convert.ToInt64(DgvSaleInvoice.Rows[i].Cells[3].Value);
                //DgvSaleInvoice.Rows[i].Cells[6].Value = Salelist[i].Discount;
                //if (Salelist[0].Discount > 0)
                //{
                //    DgvSaleInvoice.Rows[i].Cells[7].Value = Convert.ToInt64(DgvSaleInvoice.CurrentRow.Cells["colAmount"].Value) - (Convert.ToInt64(DgvSaleInvoice.CurrentRow.Cells["colAmount"].Value) * Convert.ToInt32(DgvSaleInvoice.Rows[i].Cells[6].Value) / 100);
                //}
                //else
                //{
                //    DgvSaleInvoice.Rows[i].Cells[7].Value = DgvSaleInvoice.Rows[i].Cells[5].Value;
                //}

                //DgvSaleInvoice.Rows[i].Cells[3].Value = List[i].
            }
            txtTotalAmount.Text = Amount.ToString().Trim('.');
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DgvSaleInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                DgvSaleInvoice.CurrentRow.Cells["colAmount"].Value = Convert.ToDecimal(DgvSaleInvoice.CurrentRow.Cells["colUnitPrice"].Value) * Convert.ToInt64(DgvSaleInvoice.CurrentRow.Cells["colQty"].Value);

                DgvSaleInvoice.EndEdit();

                //for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
                //{
                //    OldValue += Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colAmount"].Value);
                //}
                //txtTotalAmount.Text = OldValue.ToString();
                //OldValue = 0;

            }
        }
        private void DgvSaleInvoice_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                DgvSaleInvoice.EndEdit();
                if (DgvSaleInvoice.Columns[e.ColumnIndex].Name == "colAmount")
                {
                    for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
                    {
                        OldValue += Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colAmount"].Value);
                    }
                    txtTotalAmount.Text = OldValue.ToString();
                    OldValue = 0;
                    if (IsImport)
                    {
                        txtVAT.Text = "0";
                        txtVATAmount.Text = "0";
                    }
                    else
                    {
                        txtVAT.Text = ((Validation.GetSafeDecimal(txtTotalAmount.Text) * 5) / 100).ToString();
                        txtVATAmount.Text = (Validation.GetSafeDecimal(txtTotalAmount.Text) + Validation.GetSafeDecimal(txtVAT.Text)).ToString();
                    }
                }
            }
        }
        private void frmSalesReturn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                FillData();
                ClearControl();
                if (DgvSaleInvoice.Rows.Count > 0)
                {
                    DgvSaleInvoice.Rows.Clear();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var manager = new SalesHeadBLL();
            if (MessageBox.Show("Are You Sure To Delete...", "Deleting Sale Return", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (IdVoucher != Guid.Empty)
                {
                    if (manager.DeleteSales(IdVoucher))
                    {
                        lblStatuMessage.Text = "Sales Return Deleted";
                        FillData();
                        ClearControl();
                    }
                    else
                    {
                        lblStatuMessage.Text = "Problem Occured While Deleting Sales Return";
                    }
                }
            }
        }

        private void DgvSaleInvoice_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvSaleInvoice.CurrentCellAddress.X == 3)
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
            if (DgvSaleInvoice.CurrentCellAddress.X == 3)
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
                SalesAccountNo = Validation.GetSafeString(cbxNaturalAccounts.SelectedValue);
            }
        }

        private void btnNewVoucher_Click(object sender, EventArgs e)
        {
            ClearControl();
            FillData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            long NextVoucherNo = Convert.ToInt64(InvEditBox.Text);
            NextVoucherNo += 1;
            InvEditBox.Text = NextVoucherNo.ToString();
            FillVoucher();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            long PreviousVoucherNo = Convert.ToInt64(InvEditBox.Text);
            PreviousVoucherNo -= 1;
            InvEditBox.Text = PreviousVoucherNo.ToString();
            FillVoucher();
        }

        private void EmpEditCode_Click(object sender, EventArgs e)
        {

        }

        private void CustEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetroFramework.Controls.MetroTextBox txt = sender as MetroFramework.Controls.MetroTextBox;
            if (txt != null)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (txt.Name == "CustEditBox")
                    {
                        EmpEditCode.Focus();
                    }
                    else if (txt.Name == "EmpEditCode")
                    {
                        cbxNaturalAccounts.Focus();
                        cbxNaturalAccounts.DroppedDown = true;
                    }
                }
                else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    if (txt.Name == "CustEditBox")
                    {
                        CommandType = "Persons";
                    }
                    else
                        CommandType = "Employees";
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
                cbxReturnType.Focus();
                cbxReturnType.DroppedDown = true;
            }
        }

        private void cbxReturnType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtSaleMemoNo.Focus();
            }
        }

        private void txtSaleMemoNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DgvSaleInvoice.Focus();
            }
        }
    }
}
