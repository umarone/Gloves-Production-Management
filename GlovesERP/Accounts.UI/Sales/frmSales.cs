using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.EL;
using Accounts.Common;
using Accounts.BLL;
using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmSales : MetroForm
    {
        #region Variables
        frmFindAccounts frmAccount;
        frmStockAccounts frmstockAccounts;
        frmFindVouchers frmfindVouchers;
        frmReports frmReport;
        frmCustomerDiscount frmcustomerdiscounts;
        public decimal OldValue { get; set; }
        public Int64 InvoiceNo { get; set; }
        public Int64 SampleNo { get; set; }
        public bool IsSampleSale { get; set; }
        public Guid IdVoucher = Guid.Empty;
        public Guid IdSampleVoucher = Guid.Empty;
        public Guid CustomerTransactionId { get; set; }
        public Guid CashTransactionId { get; set; }
        public Guid SalesTransactionId { get; set; }
        TextBox txtDebit = new TextBox();
        TextBox txtCredit = new TextBox();
        public bool IsImport { get; set; }
        bool IsNewInvoice;
        decimal CostOfGoodsSoldAmount = 0;
        public string VoucherType { get; set; }
        string CommandType = "";
        int EventTime = 0;
        string LinkAccountNo, SalesAccountNo, CustomerAccountNo = string.Empty, CashAccountNo = string.Empty;
        List<PurchaseDetailEL> ListToUpdateStock = null;
        List<PurchaseDetailEL> ListToCheck = null;
        decimal MRP = 0;
        public int InvoiceType { get; set; }
        #endregion
        #region Form Constructor And Load Method
        public frmSales()
        {
            InitializeComponent();
        }
        private void frmSales_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.metrolSalesTab.SelectedIndex = 0;
            FillData();
            FillNaturalAccounts(string.Empty);
            FillNaturalCashAccounts(string.Empty);
            CheckModulePermissions();
            if (IsSampleSale)
            {
                FillSampleVoucher();
            }
            ResizeColumns(0);
            HideData();
            //if (IsImport)
            //{
            //    this.Text = "Import Sales";

            //    lblVAT.Visible = false;
            //    txtVat.Visible = false;
            //    lblVATAmount.Visible = false;
            //    txtVatAmount.Visible = false;
            //}
            //else
            //{
            //    this.Text = "Local Sales";

            //    lblVAT.Visible = true;
            //    txtVat.Visible = true;
            //    lblVATAmount.Visible = true;
            //    txtVatAmount.Visible = true;
            //}
        }
        #endregion
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
        private void CreateAndInitializeFooterRow()
        {
            txtDebit.Enabled = false;
            txtDebit.TextAlign = HorizontalAlignment.Left;
            txtDebit.Font = new System.Drawing.Font("Arial", 9, FontStyle.Bold);

            int hostCellLocation = DgvSalesAccounts.GetCellDisplayRectangle(7, -1, true).X;

            txtDebit.Width = DgvSalesAccounts.Columns[6].Width; //+SystemInformation.VerticalScrollBarWidth;
            txtDebit.Location = new Point(hostCellLocation, DgvSalesAccounts.Height - txtDebit.Height);

            DgvSalesAccounts.Controls.Add(txtDebit);

            txtDebit.BringToFront();

            txtCredit.Enabled = false;
            txtCredit.TextAlign = HorizontalAlignment.Left;
            txtCredit.Font = new System.Drawing.Font("Arial", 9, FontStyle.Bold);

            int hostCreditCellLocation = DgvSalesAccounts.GetCellDisplayRectangle(8, -1, true).X;
            txtCredit.Width = DgvSalesAccounts.Columns[7].Width; //+SystemInformation.VerticalScrollBarWidth;
            txtCredit.Location = new Point(hostCreditCellLocation, DgvSalesAccounts.Height - txtCredit.Height);

            DgvSalesAccounts.Controls.Add(txtCredit);

            txtCredit.BringToFront();
        }
        private void FillData()
        {
            var manager = new SalesHeadBLL();
            //InvEditBox.Text = manager.GetMaxVoucherNumber("SaleInvoiceVoucher",Operations.IdCompany);
            InvEditBox.Text = manager.GetMaxSaleInvoiceNumberBySaleType(1, Operations.IdCompany).ToString();
        }
        private void HideData()
        {
            lblCashAccount.Visible = false;
            cbxCashAccounts.Visible = false;
            if (rdCashSale.Checked)
            {
                lblCashAccount.Visible = true;
                cbxCashAccounts.Visible = true;
            }
        }
        private void FillSampleVoucher()
        {
            var Manager = new VoucherBLL();
            var SalesManager = new SalesDetailBLL();
            var SamplesManager = new SampleDetailBLL();
            VoucherType = "SampleVoucher";
            List<VouchersEL> list = Manager.GetVouchersByTypeAndVoucherNumber(Operations.IdCompany, VoucherType, SampleNo);
            if (list.Count > 0)
            {
                //IdVoucher = list[0].IdVoucher;
                VDate.Value = list[0].Date;
                txtDescription.Text = list[0].Description;
                txtSaleMemoNo.Text = Validation.GetSafeString(list[0].DemandNo);
                txtGatePass.Text = Validation.GetSafeString(list[0].OutWardGatePassNo);
                if (list[0].Posted)
                {
                    if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                    {
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        chkPosted.Enabled = false;
                    }
                    chkPosted.Checked = list[0].Posted;
                }
                else
                {
                    btnSave.Enabled = true;
                    btnDelete.Enabled = true;
                }

                //List<TransactionsEL> listTransactions = Manager.GetTransactions(Validation.GetSafeLong(InvSampleBox.Text), "SaleInvoiceVoucher", Operations.IdCompany);

                //if (listTransactions.Count > 0)
                //{
                //    TransactionsEL oelSalesTransaction = listTransactions.Find(x => x.Credit != 0);
                //    if (oelSalesTransaction != null)
                //    {
                //        //SalesEditBox.Text = oelSalesTransaction.AccountNo.ToString();
                //        cbxEmployees.SelectedValue = oelSalesTransaction.AccountNo;
                //        EmpEditCode.Text = oelSalesTransaction.AccountNo.ToString();
                //        SalesTransactionId = oelSalesTransaction.TransactionID;
                //    }
                //}


                //FillEmployee(ListCustomer[0].SubAccountNo);

                List<VoucherDetailEL> CustomerSamplesList = SamplesManager.GetSampleWithSampleNumber(SampleNo, Operations.IdCompany);
                if (CustomerSamplesList.Count > 0)
                {
                    FillEmployee(CustomerSamplesList[0].SubAccountNo);

                    List<PersonsEL> ListCustomer = Manager.GetSampleCustomer(SampleNo, list[0].AccountNo.ToString(), "SampleVoucher", Operations.IdCompany);
                    if (ListCustomer.Count > 0)
                    {
                        CustEditBox.Text = Validation.GetSafeString(ListCustomer[0].AccountNo);

                        //txtSaleMemoNo.Text = ListCustomer[0].MemoSaleNo.ToString();                            
                        txtContact.Text = ListCustomer[0].Contact;
                        txtNTN.Text = ListCustomer[0].NTN;

                    }

                    FillSamplesTransaction(CustomerSamplesList, ListCustomer[0].Balance);
                }
            }
            else
            {
                ClearControl();
                MessageBox.Show("Voucher Number Not Found ...");
            }



        }
        private void FillSamplesTransaction(List<VoucherDetailEL> CustomerSamplesList, decimal Amount)
        {
            var manager = new ItemsBLL();

            if (DgvSaleInvoice.Rows.Count > 0)
            {
                DgvSaleInvoice.Rows.Clear();
            }
            for (int i = 0; i < CustomerSamplesList.Count; i++)
            {
                DgvSaleInvoice.Rows.Add();
                DgvSaleInvoice.Rows[i].Cells[0].Value = CustomerSamplesList[i].IdVoucherDetail;
                DgvSaleInvoice.Rows[i].Cells[1].Value = CustomerSamplesList[i].IdAccount;
                DgvSaleInvoice.Rows[i].Cells[2].Value = CustomerSamplesList[i].ItemNo;
                DgvSaleInvoice.Rows[i].Cells[3].Value = CustomerSamplesList[i].ItemName; //manager.GetItemByAccount(Validation.GetSafeLong(Salelist[i].ItemNo), Operations.IdCompany).ItemName;
                DgvSaleInvoice.Rows[i].Cells[4].Value = CustomerSamplesList[i].PackingSize;
                DgvSaleInvoice.Rows[i].Cells[5].Value = CustomerSamplesList[i].BatchNo;
                DgvSaleInvoice.Rows[i].Cells[6].Value = CustomerSamplesList[i].Discription;
                DgvSaleInvoice.Rows[i].Cells[7].Value = CustomerSamplesList[i].UnitPrice;
                DgvSaleInvoice.Rows[i].Cells[8].Value = CustomerSamplesList[i].Units;
                DgvSaleInvoice.Rows[i].Cells[9].Value = CustomerSamplesList[i].Units * Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells[7].Value);
                DgvSaleInvoice.Rows[i].Cells[10].Value = DgvSaleInvoice.Rows[i].Cells[9].Value;  //CustomerSamplesList[i].Discount;
            }
            txtTotalAmount.Text = Amount.ToString();
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
        private void FillNaturalCashAccounts(string SaleAccount)
        {
            if (SaleAccount == "")
            {
                var manager = new AccountsBLL();
                List<AccountsEL> list = manager.GetAccountsByType("Cash Balance Head", Operations.IdCompany);
                if (list.Count > 0)
                {

                    list.Insert(0, new AccountsEL() { AccountNo = "0", AccountName = "Select Cash Account" });

                    cbxCashAccounts.DataSource = list;
                    cbxCashAccounts.DisplayMember = "AccountName";
                    cbxCashAccounts.ValueMember = "AccountNo";

                }
            }
            else
            {
                cbxCashAccounts.SelectedValue = SaleAccount;
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
                //List<PersonsEL> list = manager.VerifyAccount("Customers/Suppliers", oelChartOfAccount.AccountNo);
                List<PersonsEL> list = manager.VerifyAccount(Operations.IdCompany, "Persons", oelAccount.AccountNo);
                if (list.Count > 0)
                {
                    EventTime = 1;
                    CustomerAccountNo = oelAccount.AccountNo;
                    CustEditBox.Text = oelAccount.AccountName;
                    txtClosingBalance.Text = GetClosingBalance(oelAccount.AccountNo).ToString();
                    //LinkAccountNo = oelAccount.LinkAccountNo;
                    EventTime = 0;
                }
                else
                {
                }
            }
            else if (CommandType == "DgvSales")
            {
                DgvSalesAccounts.CurrentRow.Cells["colAccountNo"].Value = oelAccount.AccountNo;
                DgvSalesAccounts.CurrentRow.Cells["colLinkAccount"].Value = oelAccount.LinkAccountNo;
                DgvSalesAccounts.CurrentRow.Cells["colIdAccount"].Value = oelAccount.IdAccount;
                DgvSalesAccounts.CurrentRow.Cells["colAccountName"].Value = oelAccount.AccountName;
                DgvSalesAccounts.CurrentRow.Cells["colClosingBalance"].Value = GetClosingBalance(oelAccount.AccountNo);
            }
        }
        private decimal GetClosingBalance(string AccountNo)
        {
            var manager = new TransactionBLL();
            return manager.GetAccountClosingBalance(AccountNo, Operations.IdCompany);
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            DgvSaleInvoice.RefreshEdit();
            DgvSalesAccounts.RefreshEdit();
            var manager = new ItemsBLL();
            List<ItemsEL> listpriceAndSize = manager.GetItemPriceAndSizeByCode(Validation.GetSafeLong(oelItems.AccountNo), Operations.IdCompany);
            //if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.AccountNo).Count > 0)
            {
                //for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
                //{
                //    if (DgvSaleInvoice.Rows[i].Cells["colItemNo"].Value != null)
                //    {
                //        if (oelItems.AccountNo == Validation.GetSafeLong(DgvSaleInvoice.Rows[i].Cells["colItemNo"].Value))
                //        {
                //            lblStatuMessage.Text = "Item Already exists";
                //            return;
                //        }
                //    }
                //}
                DgvSaleInvoice.CurrentRow.Cells["colItemNo"].Value = oelItems.AccountNo;
                DgvSaleInvoice.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
                DgvSaleInvoice.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
                DgvSaleInvoice.CurrentRow.Cells["colPackingSize"].Value = oelItems.PackingSize;
                //DgvSaleInvoice.CurrentRow.Cells["colBatchNo"].Value = oelItems.BatchNo;
                //DgvSaleInvoice.CurrentRow.Cells["colExpiry"].Value = oelItems.Expiry;
                    if (cbxSaleType.SelectedIndex != 3 && cbxSaleType.SelectedIndex != 4)
                {
                    DgvSaleInvoice.CurrentRow.Cells["colCurrentStock"].Value = oelItems.Qty; //manager.GetItemCurrentTotalQuantity(oelItems.IdItem, oelItems.PackingSize, oelItems.BatchNo, Operations.IdCompany);
                    //DgvSaleInvoice.CurrentRow.Cells["colItemPackingSize"].Value = listpriceAndSize[0].PackingSize; ///oelItems.PackingSize;
                    if (listpriceAndSize.Count > 0)
                        MRP = listpriceAndSize[0].MRP;
                    else
                        MRP = 0;
                }
                else
                {
                    var GManager = new ProductionProcessDetailBLL();
                    List<VoucherDetailEL> list = null;
                        if (cbxSaleType.SelectedIndex == 4)
                    {
                        list = GManager.GetGlovesGarmentsRejectionClosingStock(oelItems.IdItem, 1, 3);
                    }
                    else if (cbxSaleType.SelectedIndex == 5)
                    {
                        list = GManager.GetGlovesGarmentsRejectionClosingStock(oelItems.IdItem, 2, 4);
                    }
                    if (list.Count > 0)
                    {
                        DgvSaleInvoice.CurrentRow.Cells["colCurrentStock"].Value = list[0].ClosingUnits;
                    }
                    else
                    {
                        MessageBox.Show("Oops ! You Have No Rejection Stock");
                        DgvSaleInvoice.CurrentRow.Cells["colCurrentStock"].Value = 0;
                    }
                }
                //DgvSaleInvoice.CurrentRow.Cells["colUnitPrice"].Value = listpriceAndSize[0].UnitPrice; //manager.GetItemPriceByCode(oelItems.AccountNo, Operations.IdCompany).ToString();
                //DgvSaleInvoice.CurrentRow.Cells["colQty"].Selected = true;
                //SendKeys.Send("{TAB}");
            }
            //else
            //{
            //}
        }
        private void DgvSaleInvoice_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 5)
            //{
            //    if (MRP != 0)
            //    {
            //        DgvSaleInvoice.CurrentRow.Cells["colUnitPrice"].Value = MRP;
            //    }
            //    else
            //    {
            //        var manager = new ItemsBLL();
            //        List<ItemsEL> listpriceAndSize = manager.GetItemPriceAndSizeByCode(Validation.GetSafeLong(DgvSaleInvoice.CurrentRow.Cells["colItemNo"].Value), Operations.IdCompany);
            //        MRP = listpriceAndSize[0].MRP;
            //    }
            //    //DgvSaleInvoice.Rows[e.RowIndex].Cells["colDisAmount"].Value = Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value);  
            //}
            //else if (e.ColumnIndex == 11)
            //{
            //    //DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value;
            //    DgvSaleInvoice.EndEdit();
            //    DgvSaleInvoice.Rows[e.RowIndex].Cells["colDisAmount"].Value = (Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value) * (Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colUnitPrice"].Value))) * (Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDisc"].Value)) / 100;
            //    //if (DgvSaleInvoice.Columns[e.ColumnIndex].Name == "colDiscountAmount")
            //    //{
            //    //    for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
            //    //    {
            //    //        OldValue += Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colDiscountAmount"].Value);
            //    //    }
            //    //    txtTotalAmount.Text = OldValue.ToString();                    
            //    //    OldValue = 0;
            //    //}
            //    //for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
            //    //{
            //    //    OldValue += Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colAmount"].Value);
            //    //}
            //    //txtTotalAmount.Text = OldValue.ToString();
            //    //OldValue = 0;

            //    //DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDisAmount"].Value) * Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value);  
            //}
            //else if (e.ColumnIndex == 12)
            //{
            //    DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value) * (Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colUnitPrice"].Value))) - Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDisAmount"].Value); 
            //}
            //else if (e.ColumnIndex == 8)
            //{
            //    DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value) *
            //        Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
            //}
            //else if (e.ColumnIndex == 9)
            //{
            //    for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
            //    {
            //        OldValue += Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colAmount"].Value);
            //    }
            //    txtTotalAmount.Text = OldValue.ToString();
            //    //if (IsImport)
            //    //{
            //    //    txtVat.Text = "0";
            //    //    txtVatAmount.Text = "0";                    
            //    //}
            //    //else
            //    //{
            //    //    txtVat.Text = ((Validation.GetSafeDecimal(txtTotalAmount.Text) * 5) / 100).ToString();
            //    //    txtVatAmount.Text = (Validation.GetSafeDecimal(txtTotalAmount.Text) + Validation.GetSafeDecimal(txtVat.Text)).ToString();
            //    //}
            //    OldValue = 0;
            //    //if (Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colIdBuild"].Value) == 0)
            //    //{
            //    //    txtDescription.AppendText(DgvSaleInvoice.Rows[e.RowIndex].Cells[4].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[3].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[5].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[7].Value.ToString() + " Units" + "@" + DgvSaleInvoice.Rows[e.RowIndex].Cells[9].Value.ToString() + Environment.NewLine);
            //    //    DgvSaleInvoice.Rows[e.RowIndex].Cells["colIdBuild"].Value = 1;
            //    //}
            //}
            //txtDescription.Lines.FirstOrDefault().Remove(0);
            //else if (e.ColumnIndex == 8)
            //{
            //    for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
            //    {
            //        OldValue += Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colDisAmount"].Value);
            //    }
            //    txtTotalAmount.Text = OldValue.ToString();
            //    OldValue = 0;
            //}
        }
        private void DgvSaleInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                //var manager = new ItemsBLL();
                //DgvSaleInvoice.Rows[e.RowIndex].Cells["colCurrentStock"].Value = manager.GetItemCurrentTotalQuantity(Validation.GetSafeGuid(DgvSaleInvoice.Rows[e.RowIndex].Cells["colIdItem"].Value)
                //    , Validation.GetSafeString(DgvSaleInvoice.Rows[e.RowIndex].Cells["colPackingSize"].Value), 
                //    Validation.GetSafeString(DgvSaleInvoice.Rows[e.RowIndex].Cells["colBatchNo"].Value), Operations.IdCompany); 
            }
            else if (e.ColumnIndex == 6)
            {
                var GManager = new ProductionProcessDetailBLL();
                List<VoucherDetailEL> list = null;
                if (cbxSaleType.SelectedIndex == 2 || cbxSaleType.SelectedIndex == 3)
                {
                    list = GManager.GetGlovesGarmentsTotalCartonsClosingStock(Validation.GetSafeGuid(DgvSaleInvoice.Rows[e.RowIndex].Cells["colIdItem"].Value), 1, 3);
                }
                if (Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells["colCartons"].Value) > 0)
                {
                    if (Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells["colCartons"].Value) >
                        list[0].ClosingUnits)
                    {
                        MessageBox.Show("Total Cartons Exceedings Than Current Stock");
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colCartons"].Value = "";
                        return;
                    }
                }
            }
            else if (e.ColumnIndex == 7)
            {
                if (Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value) >
                    Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells["colCurrentStock"].Value))
                {
                    MessageBox.Show("Quantity is Exceeding Than Current Stock");
                    DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value = "";
                    return;
                }
                if (Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value) > 0)
                {
                    DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value);
                }
                else
                {
                    DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value = 0;
                }
                if (DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscPercentage"].Value != null && Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscPercentage"].Value.ToString().Replace('%', ' ')) > 0)
                {
                    string CellValue = Validation.GetSafeString(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscPercentage"].Value);
                    if (CellValue.Contains('%'))
                    {
                        CellValue = CellValue.Substring(0, CellValue.Length - 1);
                    }
                    if (Validation.GetSafeDecimal(CellValue) > 0)
                    {
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscPercentage"].Value = CellValue + "%";
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = ((Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value) / 100)
                                                                                      * Validation.GetSafeDecimal(CellValue));
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colNetAmount"].Value = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value));

                    }
                    else
                    {
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colNetAmount"].Value = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value));

                    }
                }
                else
                {
                    DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscPercentage"].Value = 0 + "%";
                    DgvSaleInvoice.Rows[e.RowIndex].Cells["colNetAmount"].Value = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value));
                }
            }
            else if (e.ColumnIndex == 8)
            {
                DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value) *
                    Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colUnitPrice"].Value);

                if (Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value) > 0)
                {
                    DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value);
                }
                else
                {
                    DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value = 0;
                }
                if (DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscPercentage"].Value != null && Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscPercentage"].Value.ToString().Replace('%', ' ')) > 0)
                {
                    string CellValue = Validation.GetSafeString(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscPercentage"].Value);
                    if (CellValue.Contains('%'))
                    {
                        CellValue = CellValue.Substring(0, CellValue.Length - 1);
                    }
                    if (Validation.GetSafeDecimal(CellValue) > 0)
                    {
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscPercentage"].Value = CellValue + "%";
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = ((Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value) / 100)
                                                                                      * Validation.GetSafeDecimal(CellValue));
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colNetAmount"].Value = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value));

                    }
                    else
                    {
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colNetAmount"].Value = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value));

                    }
                }
                else
                {
                    DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscPercentage"].Value = 0 + "%";
                    DgvSaleInvoice.Rows[e.RowIndex].Cells["colNetAmount"].Value = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value));

                }
            }
            else if (e.ColumnIndex == 10)
            {

                if (DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscPercentage"].Value != null)
                {
                    string CellValue = Validation.GetSafeString(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscPercentage"].Value);
                    if (CellValue.Contains('%'))
                    {
                        CellValue = CellValue.Substring(0, CellValue.Length - 1);
                    }
                    if (Validation.GetSafeDecimal(CellValue) > 0)
                    {
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscPercentage"].Value = CellValue + "%";
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = ((Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value) / 100)
                                                                                          * Validation.GetSafeDecimal(CellValue));
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colNetAmount"].Value = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value));

                    }
                    else
                    {
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = 0;
                        DgvSaleInvoice.Rows[e.RowIndex].Cells["colNetAmount"].Value = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value) - (Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value));
                    }
                }
                else
                {
                    DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscPercentage"].Value = 0 + "%";
                    DgvSaleInvoice.Rows[e.RowIndex].Cells["colDiscountAmount"].Value = 0;
                    DgvSaleInvoice.Rows[e.RowIndex].Cells["colNetAmount"].Value = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value);
                }

            }
            for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
            {
                OldValue += Validation.GetSafeDecimal(DgvSaleInvoice.Rows[i].Cells["colNetAmount"].Value);
                
            }
            txtTotalAmount.Text = OldValue.ToString();
            OldValue = 0;
        }

        #region Validation Method
        private bool ValidateRows()
        {
            bool Status = true;
            if (DgvSaleInvoice.Rows.Count > 1)
            {
                for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
                {
                    //if (DgvSaleInvoice.Rows[i].Cells["colItemNo"].Value == null)
                    //{
                    //    Status = false;
                    //}
                    //else
                    if (DgvSaleInvoice.Rows[i].Cells["colQty"].Value == null)
                    {
                        Status = false;
                    }
                }
            }
            else if (DgvSaleInvoice.Rows.Count == 1)
            {
                Status = false;
            }
            return Status;
        }
        private bool ValidateControls()
        {
            if (CustomerAccountNo == string.Empty)
            {
                MessageBox.Show("Customer Missing...");
                return false;
            }
            if (SalesAccountNo == string.Empty)
            {
                MessageBox.Show("Sales Account Missing...");
                return false;
            }

            if (rdCreditSale.Checked == false && rdCashSale.Checked == false)
            {
                MessageBox.Show("Please Select Transaction Type...");
                return false;
            }
            if (IdVoucher != Guid.Empty)
            {
                if (rdCreditSale.Checked)
                {
                    if (CustomerTransactionId != Guid.Empty)
                    {
                        if (CustomerTransactionId != Guid.Empty)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Customer Is Missing...");
                            return false;
                        }
                    }
                    else if (CashTransactionId != Guid.Empty)
                    {
                        CustomerTransactionId = CashTransactionId;
                    }
                }
                else if (rdCashSale.Checked)
                {
                    //if (IsWhatTransactionType)
                    //{
                    if (CashTransactionId != Guid.Empty)
                    {
                        if (CashTransactionId != Guid.Empty)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Cash Account Is Missing...");
                            return false;
                        }
                    }
                    else if (CustomerTransactionId != Guid.Empty)
                    {
                        CashTransactionId = CustomerTransactionId;
                    }

                    //}
                    //else
                    //{ 

                    //}
                }
            }
            if (cbxSeller.SelectedIndex == 0 || cbxSeller.SelectedIndex == -1)
            {
                MessageBox.Show("Seller Not Selected...");
                return false;
            }
            return true;
        }

        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Variables
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            List<VoucherDetailEL> oelSaleCollection = new List<VoucherDetailEL>();
            //List<StockReceiptEL> oelStockReceiptCollection = new List<StockReceiptEL>();
            List<VoucherDetailEL> oelCostOfSalesCollection = new List<VoucherDetailEL>();
            ListToUpdateStock = new List<PurchaseDetailEL>();
            ListToCheck = new List<PurchaseDetailEL>();
            #endregion
            #region Main 
            if (ValidateRows())
            {
                if (ValidateControls())
                {
                    #region Voucher Entry
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
                    oelVoucher.SampleNo = 0;
                    oelVoucher.IdUser = Operations.UserID;
                    oelVoucher.VDate = VDate.Value;
                    oelVoucher.AccountNo = CustomerAccountNo;
                    if (rdCreditSale.Checked)
                    {
                        oelVoucher.TransactionAccountNo = CustomerAccountNo;
                    }
                    else
                        oelVoucher.TransactionAccountNo = CashAccountNo;
                    oelVoucher.LinkAccountNo = LinkAccountNo;
                    oelVoucher.SubAccountNo = "";
                    oelVoucher.VDiscription = txtDescription.Text;
                    oelVoucher.MemoSaleNo = Validation.GetSafeLong(txtSaleMemoNo.Text == "" ? "0" : txtSaleMemoNo.Text);
                    oelVoucher.OutWardGatePassNo = Validation.GetSafeString(txtGatePass.Text);
                    oelVoucher.Amount = Validation.GetSafeDecimal(txtTotalAmount.Text);
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(txtTotalAmount.Text);
                    oelVoucher.BillNo = string.Empty;
                    if (cbxSeller.SelectedIndex == 0 || cbxSeller.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please Select Seller ....");
                        return;
                    }
                    else
                    {
                        oelVoucher.Seller = cbxSeller.SelectedIndex;
                    }
                    if (cbxSaleType.SelectedIndex == 0 || cbxSaleType.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please Select Sale Type ....");
                        return;
                    }
                    else
                    {
                        oelVoucher.SaleType = cbxSaleType.SelectedIndex;
                    }
                    // oelVoucher.VAT = Validation.GetSafeDecimal(txtVat.Text);
                    //oelVoucher.VATAmount = Validation.GetSafeDecimal(txtVatAmount.Text);
                    oelVoucher.Transactiondays = Validation.GetSafeLong(txtCreditDays.Text);
                    oelVoucher.IsImport = IsImport;
                    oelVoucher.IsRecieved = false;
                    oelVoucher.InvoiceType = 1;
                    //oelVoucher.Discount = Validation.GetSafeDecimal(txtDiscount.Text  == "" ? "0" : txtDiscount.Text);
                    //oelVoucher.TotalDiscount = Validation.GetSafeDecimal(txtTotalDiscount.Text == "" ? "0" : txtTotalDiscount.Text);
                    //oelVoucher.NetSaleAmount = Validation.GetSafeDecimal(txtNetSale.Text);
                    oelVoucher.IsNetTransaction = rdCashSale.Checked;
                    oelVoucher.Posted = chkPosted.Checked;
                    #endregion                  
                    #region Add Items In Sales Detail                    
                    for (int j = 0; j < DgvSaleInvoice.Rows.Count - 1; j++)
                    {
                        //SaleDetailEL oelSaleDetail = new SaleDetailEL();
                        VoucherDetailEL oelSaleDetail = new VoucherDetailEL();

                        if (DgvSaleInvoice.Rows[j].Cells["colSale"].Value != null)
                        {
                            oelSaleDetail.IdVoucherDetail = Validation.GetSafeGuid(DgvSaleInvoice.Rows[j].Cells["colSale"].Value);
                            oelSaleDetail.IsNew = false;
                        }
                        else
                        {
                            oelSaleDetail.IdVoucherDetail = Guid.NewGuid();
                            oelSaleDetail.IsNew = true;
                        }
                        oelSaleDetail.Seq = j + 1;

                        oelSaleDetail.IdVoucher = oelVoucher.IdVoucher;
                        oelSaleDetail.IdItem = Validation.GetSafeGuid(DgvSaleInvoice.Rows[j].Cells["colIdItem"].Value);
                        oelSaleDetail.PackingSize = Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colPackingSize"].Value);
                        //oelSaleDetail.BatchNo = Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colBatchNo"].Value);
                        //oelSaleDetail.Expiry = Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colExpiry"].Value);             
                        oelSaleDetail.CurrentStock = Validation.GetSafeLong(DgvSaleInvoice.Rows[j].Cells["colCurrentStock"].Value);
                        oelSaleDetail.TotalCartons = Validation.GetSafeLong(DgvSaleInvoice.Rows[j].Cells["colCartons"].Value);
                        oelSaleDetail.Discription = "N/A"; //Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colNarration"].Value);
                        oelSaleDetail.ItemNo = Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colItemNo"].Value);
                        oelSaleDetail.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                        //if (DgvSaleInvoice.Rows[i].Cells["colRemarks"].Value == null)
                        //{
                        //    oelTransaction.Description = "";
                        //}
                        //else
                        //{
                        //    oelTransaction.Description = DgvSaleInvoice.Rows[i].Cells["colRemarks"].Value.ToString();
                        //}

                        oelSaleDetail.Units = Validation.GetSafeInteger(DgvSaleInvoice.Rows[j].Cells["colQty"].Value);
                        // oelTransaction.Credit = Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colDiscountAmount"].Value);
                        //oelTransaction.Credit = CalculateCost(oelTransaction.AccountNo, DgvSaleInvoice.Rows[i]);
                        //oelSaleDetail.Amount = Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colDiscountAmount"].Value);
                        oelSaleDetail.Amount = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[j].Cells["colAmount"].Value);
                        oelSaleDetail.Discount = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[j].Cells["colDiscPercentage"].Value.ToString().Replace('%', ' '));
                        oelSaleDetail.DiscountAmount = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[j].Cells["colDiscountAmount"].Value);
                        oelSaleDetail.NetAmount = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[j].Cells["colNetAmount"].Value);
                        //oelSaleDetail.Amount = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[j].Cells["colDiscountAmount"].Value);

                        oelSaleDetail.UnitPrice = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[j].Cells["colUnitPrice"].Value);
                        oelSaleCollection.Add(oelSaleDetail);
                    }
                    #endregion
                    #region Add Customer In Transactions
                    if (rdCreditSale.Checked)
                    {
                        TransactionsEL oelCustomerTransaction = new TransactionsEL();
                        //if (IdVoucher != Guid.Empty && CashTransactionId != Guid.Empty && CustomerTransactionId == Guid.Empty)
                        //{
                        //    oelCustomerTransaction.TransactionID = CashTransactionId;
                        //    oelCustomerTransaction.IsNew = false;
                        //}
                        //else
                        //{
                            if (CustomerTransactionId != Guid.Empty)
                            {
                                oelCustomerTransaction.TransactionID = CustomerTransactionId;
                                oelCustomerTransaction.IsNew = false;
                            }
                            else
                            {
                                oelCustomerTransaction.TransactionID = Guid.NewGuid();
                                oelCustomerTransaction.IsNew = true;
                            }
                        //}
                        oelCustomerTransaction.IdCompany = Operations.IdCompany;
                        oelCustomerTransaction.AccountNo = CustomerAccountNo;
                        oelCustomerTransaction.LinkAccountNo = "";
                        oelCustomerTransaction.SubAccountNo = "";
                        oelCustomerTransaction.VDate = VDate.Value;
                        oelCustomerTransaction.IdVoucher = oelVoucher.IdVoucher;
                        oelCustomerTransaction.BookNo = Operations.BookNo;
                        oelCustomerTransaction.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                        oelCustomerTransaction.VoucherType = "SaleInvoiceVoucher";
                        oelCustomerTransaction.AdjustmentType = -1;
                        oelCustomerTransaction.SettlementType = "Sale To Customer";
                        oelCustomerTransaction.TransactionType = "Sales";
                        oelCustomerTransaction.VDiscription = BuildRemarks(); //txtDescription.Text;
                                                                              //if (IsImport)
                        {
                            oelCustomerTransaction.Debit = Validation.GetSafeDecimal(txtTotalAmount.Text);
                        }
                        ///else
                        {
                            //oelCustomerTransaction.Debit = Validation.GetSafeDecimal(txtVatAmount.Text);
                        }
                        oelCustomerTransaction.Credit = 0;
                        //if (txtCashReceipt.Text == string.Empty)
                        //{
                        //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                        //}
                        //else
                        //{
                        //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtCashReceipt.Text);
                        //}
                        oelCustomerTransaction.Posted = chkPosted.Checked;
                        oelTransactionCollection.Add(oelCustomerTransaction);
                    }
                    #endregion
                    #region Add Cash In Transactions
                    if (rdCashSale.Checked)
                    {
                        TransactionsEL oelCashTransaction = new TransactionsEL();
                        //if (IdVoucher != Guid.Empty && CustomerTransactionId != Guid.Empty && CashTransactionId == Guid.Empty)
                        //{
                        //    oelCashTransaction.TransactionID = CustomerTransactionId;
                        //    oelCashTransaction.IsNew = false;
                        //}
                        //else
                        //{
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
                        //}
                        oelCashTransaction.IdCompany = Operations.IdCompany;
                        oelCashTransaction.AccountNo = CashAccountNo;
                        oelCashTransaction.LinkAccountNo = "";
                        oelCashTransaction.SubAccountNo = "";
                        oelCashTransaction.VDate = VDate.Value;
                        oelCashTransaction.IdVoucher = oelVoucher.IdVoucher;
                        oelCashTransaction.BookNo = Operations.BookNo;
                        oelCashTransaction.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                        oelCashTransaction.VoucherType = "SaleInvoiceVoucher";
                        oelCashTransaction.AdjustmentType = -1;
                        oelCashTransaction.SettlementType = "Cash Sale To Customer";
                        oelCashTransaction.TransactionType = "Sales";
                        oelCashTransaction.VDiscription = BuildRemarks(); //txtDescription.Text;
                                                                          //if (IsImport)
                        {
                            oelCashTransaction.Debit = Validation.GetSafeDecimal(txtTotalAmount.Text);
                        }
                        ///else
                        {
                            //oelCustomerTransaction.Debit = Validation.GetSafeDecimal(txtVatAmount.Text);
                        }
                        oelCashTransaction.Credit = 0;
                        //if (txtCashReceipt.Text == string.Empty)
                        //{
                        //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                        //}
                        //else
                        //{
                        //    oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtCashReceipt.Text);
                        //}
                        oelCashTransaction.Posted = chkPosted.Checked;
                        oelTransactionCollection.Add(oelCashTransaction);
                    }
                    #endregion
                    #region Add Sales Account In Transactions
                    /// Add Sales Account...
                    TransactionsEL oelSaleTransaction = new TransactionsEL();
                    if (SalesTransactionId != Guid.Empty)
                    {
                        oelSaleTransaction.TransactionID = SalesTransactionId;
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
                    oelSaleTransaction.LinkAccountNo = LinkAccountNo;
                    oelSaleTransaction.SubAccountNo = "";
                    oelSaleTransaction.VDate = VDate.Value;
                    oelSaleTransaction.IdVoucher = oelVoucher.IdVoucher;
                    oelSaleTransaction.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                    oelSaleTransaction.VoucherType = "SaleInvoiceVoucher";
                    oelSaleTransaction.AdjustmentType = -1;
                    oelSaleTransaction.SettlementType = "Sale To Customer";
                    oelSaleTransaction.TransactionType = "Sales";
                    oelSaleTransaction.VDiscription = ""; //txtDescription.Text;
                    oelSaleTransaction.Debit = 0;
                    //if (IsImport)
                    {
                        oelSaleTransaction.Credit = Validation.GetSafeDecimal(txtTotalAmount.Text); ;
                    }
                    //else
                    {
                        //oelSaleTransaction.Credit = Validation.GetSafeDecimal(txtVatAmount.Text);
                    }
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
                    #region Add Cost of Sales Transactions
                    for (int j = 0; j < DgvSalesAccounts.Rows.Count - 1; j++)
                    {
                        VoucherDetailEL oelVoucherDetail = new VoucherDetailEL();
                        TransactionsEL oelCostofSalesTransaction = new TransactionsEL();
                        oelVoucherDetail.IdVoucher = oelVoucher.IdVoucher;
                        oelCostofSalesTransaction.IdVoucher = oelVoucher.IdVoucher;
                        if (DgvSalesAccounts.Rows[j].Cells["ColIdDetailVoucher"].Value != null)
                        {
                            oelVoucherDetail.IdVoucherDetail = new Guid(DgvSalesAccounts.Rows[j].Cells["ColIdDetailVoucher"].Value.ToString());
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
                        oelVoucherDetail.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                        oelCostofSalesTransaction.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                        oelCostofSalesTransaction.IdCompany = Operations.IdCompany;
                        if (DgvSalesAccounts.Rows[j].Cells["colDescription"].Value == null)
                        {
                            oelVoucherDetail.Description = "N/A";
                        }
                        else
                        {
                            oelVoucherDetail.Description = DgvSalesAccounts.Rows[j].Cells["colDescription"].Value.ToString();
                        }
                        oelVoucherDetail.Seq = j + 1;
                        oelVoucherDetail.Units = 0;
                        oelVoucherDetail.IdAccount = Validation.GetSafeGuid(DgvSalesAccounts.Rows[j].Cells["colIdAccount"].Value);
                        oelVoucherDetail.AccountNo = Validation.GetSafeString(DgvSalesAccounts.Rows[j].Cells["colAccountNo"].Value);
                        oelVoucherDetail.LinkAccountNo = "";
                        if (oelVoucherDetail.Debit != 0)
                        {
                            oelVoucherDetail.LinkAccountNo = Validation.GetSafeString(DgvSalesAccounts.Rows[j].Cells["colLinkAccount"].Value);
                        }
                        oelVoucherDetail.Debit = Validation.GetSafeDecimal(DgvSalesAccounts.Rows[j].Cells["colDebit"].Value);
                        oelVoucherDetail.Credit = Validation.GetSafeDecimal(DgvSalesAccounts.Rows[j].Cells["colCredit"].Value);
                        oelCostofSalesTransaction.AccountNo = Validation.GetSafeString(DgvSalesAccounts.Rows[j].Cells["colAccountNo"].Value);
                        oelCostofSalesTransaction.LinkAccountNo = Validation.GetSafeString(DgvSalesAccounts.Rows[j].Cells["colLinkAccount"].Value);
                        oelCostofSalesTransaction.SubAccountNo = "0";
                        oelCostofSalesTransaction.Date = VDate.Value;
                        oelCostofSalesTransaction.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);
                        oelCostofSalesTransaction.VoucherType = "SaleInvoiceVoucher/Sub";
                        oelCostofSalesTransaction.VDiscription = Validation.GetSafeString(DgvSalesAccounts.Rows[j].Cells["colDescription"].Value);
                        oelCostofSalesTransaction.Debit = Validation.GetSafeDecimal(DgvSalesAccounts.Rows[j].Cells["colDebit"].Value);
                        oelCostofSalesTransaction.Credit = Validation.GetSafeDecimal(DgvSalesAccounts.Rows[j].Cells["colCredit"].Value);
                        oelCostofSalesTransaction.Posted = chkPosted.Checked;
                        oelCostofSalesTransaction.TransactionType = "Sales";
                        oelCostOfSalesCollection.Add(oelVoucherDetail);
                        oelTransactionCollection.Add(oelCostofSalesTransaction);

                    }
                    #endregion
                    #region Comments
                    //    if (CashEditBox.Text == string.Empty)
                    //    {
                    //        lblStatuMessage.Text = "Choose Cash Account :";
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        TransactionsEL oeCashTransaction = new TransactionsEL();
                    //        oeCashTransaction.TransactionID = Guid.NewGuid();
                    //        oeCashTransaction.AccountNo = CashEditBox.Text;
                    //        oeCashTransaction.Date = VDate.Value;
                    //        oeCashTransaction.VoucherNo = Convert.ToInt32(InvEditBox.Text);
                    //        oeCashTransaction.VoucherType = "SaleInvoiceVoucher";
                    //        oeCashTransaction.Description = txtDescription.Text;
                    //        oeCashTransaction.Amount = Convert.ToDecimal(txtCashReceipt.Text);
                    //        oelTransactionCollection.Add(oeCashTransaction);            
                    //    }
                    //}
                    // Add Sales
                    //if (SalesEditBox.Text == string.Empty)
                    //{
                    //    lblStatuMessage.Text = "Choose Sales Account";
                    //    return;
                    //}
                    //else
                    //{
                    //    TransactionsEL oeSalesTransaction = new TransactionsEL();
                    //    oeSalesTransaction.AccountNo = SalesEditBox.Text;
                    //    oeSalesTransaction.TransactionID = Guid.NewGuid();
                    //    oeSalesTransaction.Date = VDate.Value;
                    //    oeSalesTransaction.VoucherNo = Convert.ToInt32(InvEditBox.Text);
                    //    oeSalesTransaction.VoucherType = "SaleInvoiceVoucher";
                    //    oeSalesTransaction.Description = txtDescription.Text;
                    //    oeSalesTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                    //    oelTransactionCollection.Add(oeSalesTransaction);
                    //}
                    // Add Cost Of Goods Sold
                    //if (CostOfGoodSoldEditBox.Text == string.Empty)
                    //{
                    //    lblStatuMessage.Text = "Choose Cost Of Goods Sold Accounts";
                    //    return;
                    //}
                    //else
                    //{
                    //    TransactionsEL CostofGoodsTransaction = new TransactionsEL();
                    //    CostofGoodsTransaction.TransactionID = Guid.NewGuid();
                    //    CostofGoodsTransaction.AccountNo = CostOfGoodSoldEditBox.Text;
                    //    CostofGoodsTransaction.Date = VDate.Value;
                    //    CostofGoodsTransaction.VoucherNo = Convert.ToInt32(InvEditBox.Text);
                    //    CostofGoodsTransaction.VoucherType = "SaleInvoiceVoucher";
                    //    CostofGoodsTransaction.Description = txtDescription.Text;
                    //    CostofGoodsTransaction.Amount = CostOfGoodsSoldAmount;
                    //    oelTransactionCollection.Add(CostofGoodsTransaction);

                    //}            
                    #endregion
                    #region Saving Code
                    if (IdVoucher == Guid.Empty)
                    {
                        var manager = new SalesHeadBLL(); // SalesVoucherBLL();
                        //if (manager.InsertSales(oelVoucher, oelSaleCollection, oelTransactionCollection, oelStockReceiptCollection) == true)
                        var VManager = new VoucherBLL();
                        if (VManager.CheckVoucherNo(Operations.IdCompany, Validation.GetSafeLong(InvEditBox.Text), "SaleInvoiceVoucher") == false)
                        {
                            if (manager.InsertSales(oelVoucher, oelSaleCollection, oelCostOfSalesCollection, oelTransactionCollection) == true)
                            {

                                MessageBox.Show("Sales Transaction Recorded Successfully...");
                                if (IsSampleSale)
                                {
                                    manager.UpdateSamplesHeadForSales(IdSampleVoucher, true);
                                }
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
                        var manager = new SalesHeadBLL();
                        if (manager.UpdateSales(oelVoucher, oelSaleCollection, oelCostOfSalesCollection, oelTransactionCollection) == true)
                        {

                            MessageBox.Show("Recored Sales Transaction Updated Successfully...");
                            if (IsSampleSale)
                            {
                                manager.UpdateSamplesHeadForSales(IdSampleVoucher, true);
                            }
                            ClearControl();
                            FillData();
                        }
                    }
                    #endregion
                }
            }
            else
            {
                MessageBox.Show("InComplete Entry");
            }
            #endregion
        }
        private string BuildRemarks()
        {
            string Remarks = "";
            string First = txtDescription.Text + "*";
            for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
            {
                Remarks += DgvSaleInvoice.Rows[i].Cells[3].Value.ToString() + " "
                    + DgvSaleInvoice.Rows[i].Cells[4].Value.ToString() + DgvSaleInvoice.Rows[i].Cells[7].Value.ToString() +
                     " @" + DgvSaleInvoice.Rows[i].Cells[8].Value.ToString() + "*";
            }
            First += Remarks;
            return First;
        }
        private void ClearControl()
        {
            DgvSaleInvoice.Rows.Clear();
            cbxSeller.SelectedIndex = 0;
            cbxSaleType.SelectedIndex = 0;
            IdVoucher = Guid.Empty;
            IdSampleVoucher = Guid.Empty;
            InvEditBox.Enabled = true;
            if (IsSampleSale)
            {
                IsSampleSale = false;
            }
            //txtDescription.Text = string.Empty;
            InvoiceNo = 0;
            SampleNo = 0;
            txtSaleMemoNo.Text = string.Empty;

            txtDescription.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            //txtVat.Text = string.Empty;
            //txtVatAmount.Text = string.Empty;
            txtCreditDays.Text = string.Empty;
            //txtDiscount.Text = string.Empty;
            //txtTotalDiscount.Text = string.Empty;
            //txtNetSale.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtNTN.Text = string.Empty;
            txtGatePass.Text = string.Empty;

            //txtCashReceipt.Text = string.Empty;
            CustomerTransactionId = Guid.Empty;
            CashTransactionId = Guid.Empty;
            SalesTransactionId = Guid.Empty;
            cbxNaturalAccounts.SelectedIndex = 0;
            cbxCashAccounts.SelectedIndex = 0;
            SalesAccountNo = string.Empty;
            CustomerAccountNo = string.Empty;
            rdCreditSale.Checked = false;
            rdCashSale.Checked = false;
            HideData();
            IsNewInvoice = true;
            CustEditBox.Text = string.Empty;
            ListToUpdateStock = null;
            ListToCheck = null;
            CostOfGoodsSoldAmount = 0;
            if (chkPosted.Checked)
            {
                chkPosted.Checked = false;
                chkPosted.Enabled = true;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
        private decimal CalculateCost(string ItemNo, DataGridViewRow Row)
        {
            Int64 qty = 0;
            Int64 remaining = 0;
            decimal Amount = 0;
            var manager = new ItemsBLL();
            // List<StockReceiptEL> list = manager.GetStockByItemNo(Row.Cells["colItem"].Value.ToString());
            List<PurchaseDetailEL> list = manager.GetStockByItemNo(Row.Cells["colItemNo"].Value.ToString());
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    PurchaseDetailEL oelPurchaseDetail = new PurchaseDetailEL();
                    PurchaseDetailEL oelPurchaseCheck = new PurchaseDetailEL();

                    qty = item.RemainingUnits;
                    //if (Convert.ToInt64(Row.Cells["colQty"].Value) == item.Units)
                    if (Convert.ToInt64(Row.Cells["colQty"].Value) == item.RemainingUnits)
                    {
                        if (remaining > 0)
                        {
                            remaining += qty;
                            oelPurchaseDetail.IdPurchaseDetail = item.IdPurchaseDetail;
                            if (qty > remaining)
                            {
                                oelPurchaseDetail.RemainingUnits = qty - remaining;
                            }
                            else
                            {
                                oelPurchaseDetail.RemainingUnits = remaining - qty;
                                Amount = Amount + (qty - oelPurchaseDetail.RemainingUnits) * (item.Amount / oelPurchaseDetail.RemainingUnits);
                            }
                            oelPurchaseDetail.Amount = item.Amount;
                            //Amount = Amount + (item.RemainingUnits - oelPurchaseDetail.Units) * (item.Amount / item.RemainingUnits);
                            //Amount = Amount + (qty - oelPurchaseDetail.RemainingUnits) * (item.Units / oelPurchaseDetail.RemainingUnits);
                            ListToUpdateStock.Add(oelPurchaseDetail);
                            remaining = 0;
                            break;
                        }
                        else
                        {
                            oelPurchaseDetail.IdPurchaseDetail = item.IdPurchaseDetail;
                            //oelPurchaseDetail.RemainingUnits = qty - Convert.ToInt64(Row.Cells["colQty"].Value);
                            oelPurchaseDetail.RemainingUnits = qty - Convert.ToInt64(Row.Cells["colQty"].Value);
                            oelPurchaseCheck.RemainingUnits = item.RemainingUnits;
                            oelPurchaseDetail.Amount = item.Amount;
                            //Amount = Amount + (oelPurchaseDetail.RemainingUnits) * (item.Amount / item.RemainingUnits);
                            Amount = Amount + (qty * item.UnitPrice);
                            oelPurchaseCheck.Amount = Amount;
                            ListToCheck.Add(oelPurchaseCheck);
                            ListToUpdateStock.Add(oelPurchaseDetail);

                            break;
                        }
                    }
                    else if (item.RemainingUnits > Convert.ToInt64(Row.Cells["colQty"].Value))
                    {
                        if (remaining > 0)
                        {
                            remaining += qty;
                            oelPurchaseDetail.RemainingUnits = remaining - Convert.ToInt64(Row.Cells["colQty"].Value);
                            oelPurchaseDetail.IdPurchaseDetail = item.IdPurchaseDetail;
                            oelPurchaseDetail.Amount = item.Amount;
                            oelPurchaseCheck.RemainingUnits = item.RemainingUnits - oelPurchaseDetail.RemainingUnits;
                            Amount = Amount + (item.RemainingUnits - oelPurchaseDetail.RemainingUnits) * (item.Amount / item.Units);
                            oelPurchaseCheck.Amount = Amount;
                            ListToCheck.Add(oelPurchaseCheck);
                            ListToUpdateStock.Add(oelPurchaseDetail);
                            remaining = 0;
                            break;
                        }
                        else
                        {
                            oelPurchaseDetail.IdPurchaseDetail = item.IdPurchaseDetail;
                            //oelPurchaseDetail.RemainingUnits = qty - Convert.ToInt64(Row.Cells["colQty"].Value);
                            oelPurchaseDetail.RemainingUnits = qty - Convert.ToInt64(Row.Cells["colQty"].Value);
                            oelPurchaseDetail.Amount = item.Amount;
                            oelPurchaseCheck.RemainingUnits = item.RemainingUnits;
                            // Amount = Amount + (oelPurchaseDetail.RemainingUnits) * (item.Amount / item.RemainingUnits);
                            Amount = Amount + (Convert.ToInt64(Row.Cells["colQty"].Value)) * (item.Amount / item.Units);
                            oelPurchaseCheck.Amount = Amount;
                            ListToCheck.Add(oelPurchaseCheck);
                            ListToUpdateStock.Add(oelPurchaseDetail);
                            break;
                        }
                    }
                    else if (item.RemainingUnits < Convert.ToInt64(Row.Cells["colQty"].Value))
                    {
                        remaining += qty;
                        if (remaining < Convert.ToInt64(Row.Cells["colQty"].Value))
                        {
                            oelPurchaseDetail.RemainingUnits = item.RemainingUnits - qty;
                            Amount = Amount + (remaining) * (item.Amount / item.RemainingUnits);
                        }
                        else if (remaining == Convert.ToInt64(Row.Cells["colQty"].Value))
                        {
                            oelPurchaseDetail.RemainingUnits = item.RemainingUnits - qty;
                            //Amount = Amount + (Convert.ToInt64(Row.Cells["colQty"].Value)) * (item.Amount / item.RemainingUnits);
                            Amount = Amount + (qty * item.UnitPrice);
                        }
                        else if (remaining > Convert.ToInt64(Row.Cells["colQty"].Value))
                        {
                            oelPurchaseDetail.RemainingUnits = remaining - Convert.ToInt64(Row.Cells["colQty"].Value);
                            Amount = Amount + (Convert.ToInt64(Row.Cells["colQty"].Value) - qty) * (item.Amount / item.RemainingUnits);
                        }
                        oelPurchaseDetail.IdPurchaseDetail = item.IdPurchaseDetail;
                        oelPurchaseCheck.RemainingUnits = item.RemainingUnits;
                        oelPurchaseDetail.Amount = item.Amount;
                        // Amount = Amount + (oelPurchaseDetail.RemainingUnits) * (item.Amount / item.RemainingUnits);
                        //Amount = Amount +  (item.Amount / item.RemainingUnits);
                        oelPurchaseCheck.Amount = Amount;
                        ListToUpdateStock.Add(oelPurchaseDetail);
                        ListToCheck.Add(oelPurchaseCheck);
                        if (ListToCheck.Sum(x => x.RemainingUnits) == Convert.ToInt64(Row.Cells["colQty"].Value))
                        {
                            remaining = 0;
                            break;
                        }
                    }
                }
            }
            return Amount;
        }
        private void CashEditBox_ClickButton(object sender, EventArgs e)
        {
            CommandType = "Cash";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        private void SalesEditBox_ButtonClick(object sender, EventArgs e)
        {
            CommandType = "Sales";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        private void CostOfGoodSoldEditBox_ClickButton(object sender, EventArgs e)
        {
            CommandType = "CostOfGoodsSold";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void InvEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindVouchers = new frmFindVouchers();
            frmfindVouchers.VoucherType = "SaleInvoiceVoucher";
            frmfindVouchers.ExecuteFindVouchersEvent += new frmFindVouchers.VouchersDelegate(frmfindVouchers_ExecuteFindVouchersEvent);
            frmfindVouchers.ShowDialog(this);
        }
        void frmfindVouchers_ExecuteFindVouchersEvent(VouchersEL oelVoucher)
        {
            var manager = new SalesDetailBLL();
            if (oelVoucher != null)
            {
                InvoiceNo = oelVoucher.VoucherNo;
                InvEditBox.Text = oelVoucher.VoucherNo.ToString();
                IdVoucher = oelVoucher.IdVoucher;

                IsNewInvoice = false;

                FillVoucher();
            }
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
        private void FillVoucher()
        {
            var Manager = new VoucherBLL();
            var SManager = new SalesHeadBLL();
            VoucherType = "SaleInvoiceVoucher";
            if (InvEditBox.Text != string.Empty)
            {
                //List<VouchersEL> list = Manager.GetVouchersByTypeAndVoucherNumber(Operations.IdCompany, VoucherType, Convert.ToInt64(InvEditBox.Text));
                List<VoucherDetailEL> list = SManager.GetSalesByVoucher(Validation.GetSafeLong(InvEditBox.Text), Operations.IdCompany, 1);
                if (list.Count > 0)
                {
                    IdVoucher = list[0].IdVoucher;
                    VDate.Value = list[0].VDate.Value;
                    InvEditBox.Enabled = false;
                    txtDescription.Text = list[0].Description;
                    txtSaleMemoNo.Text = list[0].MemoSaleNo.ToString();
                    txtGatePass.Text = list[0].OutWardGatePassNo;
                    txtCreditDays.Text = list[0].Transactiondays.ToString();
                    cbxSeller.SelectedIndex = list[0].Seller;
                    cbxSaleType.SelectedIndex = list[0].SaleType;
                    ResizeColumns(cbxSaleType.SelectedIndex);
                    txtTotalAmount.Text = list[0].TotalAmount.ToString();
                    txtClosingBalance.Text = list[0].ClosingBalance.ToString();
                    CustEditBox.Text = list[0].FirstName;
                    CustomerAccountNo = list[0].AccountNo;
                    if (list[0].IsNetTransaction)
                    {
                        rdCashSale.Checked = true;
                        HideData();
                    }
                    else
                        rdCreditSale.Checked = true;
                    FillSalesTransaction(list);
                    //txtVat.Text = list[0].VAT.ToString();
                    //txtVatAmount.Text = list[0].VATAmount.ToString();
                    HandleVoucher(list);

                    List<TransactionsEL> listTransactions = Manager.GetTransactions(IdVoucher, "SaleInvoiceVoucher", Operations.IdCompany);

                    if (listTransactions.Count > 0)
                    {
                        TransactionsEL oelSalesTransaction = listTransactions.Find(x => x.Credit != 0);
                        if (oelSalesTransaction != null)
                        {
                            //SalesEditBox.Text = oelSalesTransaction.AccountNo.ToString();
                            FillNaturalAccounts(oelSalesTransaction.AccountNo.ToString());
                            //cbxNaturalAccounts.SelectedValue = oelSalesTransaction.AccountNo;
                            SalesAccountNo = oelSalesTransaction.AccountNo.ToString();
                            SalesTransactionId = oelSalesTransaction.TransactionID;
                        }
                        else
                        {
                            SalesAccountNo = "";
                        }
                        if (!list[0].IsNetTransaction)
                        {
                            TransactionsEL oelCustomerTransaction = listTransactions.Find(x => x.Debit != 0);
                            if (oelCustomerTransaction != null)
                            {
                                CustomerAccountNo = oelCustomerTransaction.AccountNo;
                                CustomerTransactionId = oelCustomerTransaction.TransactionID;
                            }
                            else
                            {
                                CustomerAccountNo = string.Empty;
                                CustomerTransactionId = Guid.Empty;
                            }
                        }
                        else
                        {
                            TransactionsEL oelCashTransaction = listTransactions.Find(x => x.Debit != 0);
                            if (oelCashTransaction != null)
                            {
                                FillNaturalCashAccounts(oelCashTransaction.AccountNo);
                                CashAccountNo = oelCashTransaction.AccountNo;
                                CashTransactionId = oelCashTransaction.TransactionID;
                            }
                            else
                            {
                                CashAccountNo = string.Empty;
                                CashTransactionId = Guid.Empty;
                            }
                        }
                    }
                    List<TransactionsEL> listSalesExpense = Manager.GetTransactions(IdVoucher, "SaleInvoiceVoucher/Sub", Operations.IdCompany);
                    if (listSalesExpense.Count > 0)
                    {
                        FillSalesExpenses(listSalesExpense);
                    }
                    else
                    {
                        DgvSalesAccounts.Rows.Clear();
                    }
                    //FillEmployee(ListCustomer[0].SubAccountNo);

                    //List<VoucherDetailEL> SalesList = SalesManager.GetSaleWithInvoiceNumber(Validation.GetSafeLong(InvEditBox.Text), Operations.IdCompany);                    
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
                EventTime = 1;
            }
            else
            {
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
        private void FillSalesTransaction(List<VoucherDetailEL> Salelist)
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
                DgvSaleInvoice.Rows[i].Cells[1].Value = Salelist[i].IdItem;
                DgvSaleInvoice.Rows[i].Cells[2].Value = Salelist[i].ItemNo;
                DgvSaleInvoice.Rows[i].Cells[3].Value = Salelist[i].ItemName; //manager.GetItemByAccount(Validation.GetSafeLong(Salelist[i].ItemNo), Operations.IdCompany).ItemName;
                DgvSaleInvoice.Rows[i].Cells[4].Value = Salelist[i].PackingSize;
                DgvSaleInvoice.Rows[i].Cells[5].Value = Salelist[i].CurrentStock;

                DgvSaleInvoice.Rows[i].Cells[6].Value = Salelist[i].TotalCartons;
                DgvSaleInvoice.Rows[i].Cells[7].Value = Salelist[i].Units;
                DgvSaleInvoice.Rows[i].Cells[8].Value = Salelist[i].UnitPrice;
                DgvSaleInvoice.Rows[i].Cells[9].Value = Salelist[i].Amount;
                DgvSaleInvoice.Rows[i].Cells[10].Value = Salelist[i].Discount + "%";
                DgvSaleInvoice.Rows[i].Cells[11].Value = Salelist[i].DiscountAmount;
                DgvSaleInvoice.Rows[i].Cells[12].Value = Salelist[i].NetAmount;
                //if (Salelist[i].Discount > 0)
                //{
                //    DgvSaleInvoice.Rows[i].Cells[9].Value = Salelist[i].Discount;
                //    DgvSaleInvoice.Rows[i].Cells[10].Value = Convert.ToDecimal(Salelist[i].Units * Salelist[i].UnitPrice) - (Convert.ToDecimal(Salelist[i].Units * Salelist[i].UnitPrice) * Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells[9].Value) / 100);

                //}
                //else
                //{
                //    DgvSaleInvoice.Rows[i].Cells[9].Value = Salelist[i].Discount;
                //    DgvSaleInvoice.Rows[i].Cells[10].Value = DgvSaleInvoice.Rows[i].Cells[8].Value;
                //}
                //DgvSaleInvoice.Rows[i].Cells[9].Value = Salelist[i].Description;
                ////DgvSaleInvoice.Rows[i].Cells[3].Value = List[i].
            }
        }
        private void FillSalesExpenses(List<TransactionsEL> List)
        {
            if (DgvSalesAccounts.Rows.Count > 0)
            {
                DgvSalesAccounts.Rows.Clear();
            }
            for (int i = 0; i < List.Count; i++)
            {
                DgvSalesAccounts.Rows.Add();
                DgvSalesAccounts.Rows[i].Cells[0].Value = List[i].TransactionID;
                DgvSalesAccounts.Rows[i].Cells[1].Value = List[i].TransactionID;
                DgvSalesAccounts.Rows[i].Cells[2].Value = List[i].IdAccount;
                DgvSalesAccounts.Rows[i].Cells[3].Value = List[i].AccountNo;
                DgvSalesAccounts.Rows[i].Cells[4].Value = List[i].LinkAccountNo;
                DgvSalesAccounts.Rows[i].Cells[5].Value = List[i].AccountName;
                DgvSalesAccounts.Rows[i].Cells[6].Value = List[i].Description;
                DgvSalesAccounts.Rows[i].Cells[7].Value = List[i].Debit;
                DgvSalesAccounts.Rows[i].Cells[8].Value = List[i].Credit;
            }
            txtDebit.Text = List.Sum(x => x.Debit).ToString();
            txtCredit.Text = List.Sum(x => x.Credit).ToString();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReport = new frmReports();
            frmReport.VoucherNo = Convert.ToInt64(InvEditBox.Text);
            //frmReport.MdiParent = this;
            frmReport.ShowDialog();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var manager = new SalesHeadBLL();
            if (MessageBox.Show("Are You Sure To Delete...", "Deleting Sale", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (manager.CheckSales(Operations.IdCompany, Validation.GetSafeLong(InvEditBox.Text)))
                {
                    if (manager.DeleteSales(IdVoucher))
                    {
                        MessageBox.Show("Sales Deleted And Stock Roll Back");
                        FillData();
                        ClearControl();
                    }
                }
                else
                {
                    MessageBox.Show("Delete With Out Sales ?");
                }
            }
        }
        //private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        if (txtTotalAmount.Text != string.Empty)
        //        {
        //            if (txtDiscount.Text != string.Empty)
        //            {
        //                if (txtDiscount.Text != "0" || txtDiscount.Text != string.Empty)
        //                {
        //                    //txtTotalDiscount.Text = (Convert.ToDecimal(txtTotalAmount.Text) * (Convert.ToDecimal(txtDiscount.Text) / 100)).ToString();
        //                    txtTotalDiscount.Text = (Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtDiscount.Text)).ToString();
        //                    //txtNetSale.Text = (Convert.ToDecimal(txtTotalAmount.Text) - ((Convert.ToDecimal(txtTotalAmount.Text)) * (Convert.ToDecimal(txtDiscount.Text)) / 100)).ToString();
        //                    txtNetSale.Text = (Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtDiscount.Text)).ToString();
        //                }
        //                else
        //                {
        //                    txtNetSale.Text = txtTotalAmount.Text;
        //                }
        //            }
        //            else
        //            {
        //                txtNetSale.Text = txtTotalAmount.Text;
        //            }
        //        }
        //        e.Handled = true;
        //        ProcessTabKey(true);

        //    }
        //    else
        //    {

        //    }
        //}
        private void txtTotalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //txtNetSale.Text = txtTotalAmount.Text;
                e.Handled = true;
                ProcessTabKey(true);
            }

        }
        private void frmSales_KeyPress(object sender, KeyPressEventArgs e)
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
            else if (DgvSaleInvoice.CurrentCellAddress.X == 11)
            {
                TextBox txtDiscount = e.Control as TextBox;
                if (txtDiscount != null)
                {
                    txtDiscount.KeyPress -= new KeyPressEventHandler(txtDiscount_KeyPress);
                    txtDiscount.KeyPress += new KeyPressEventHandler(txtDiscount_KeyPress);
                }
            }
        }
        void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvSaleInvoice.CurrentCellAddress.X == 11)
            {
                if (e.KeyChar == (char)Keys.D)
                {
                    e.Handled = true;
                    frmcustomerdiscounts = new frmCustomerDiscount();
                    frmcustomerdiscounts.AccountNo = CustEditBox.Text;
                    frmcustomerdiscounts.IdItem = Validation.GetSafeGuid(DgvSaleInvoice.CurrentRow.Cells["colIdItem"].Value);
                    frmcustomerdiscounts.ShowDialog();
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
                    frmstockAccounts.SearchType = "SaleInvoiceVoucher";                    
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.Boss = cbxSeller.SelectedIndex;
                    frmstockAccounts.SaleType = cbxSaleType.SelectedIndex;
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
                SalesAccountNo = Validation.GetSafeString(cbxNaturalAccounts.SelectedValue);
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
                DgvSaleInvoice.Focus();
            }
        }
        private void cbxCashAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCashAccounts.SelectedIndex > 0)
            {
                var manager = new AccountsBLL();
                CashAccountNo = Validation.GetSafeString(cbxCashAccounts.SelectedValue);
                List<AccountsEL> list = manager.GetAccount(Validation.GetSafeString(cbxCashAccounts.SelectedValue), Operations.IdCompany);
                if (list.Count > 0)
                {
                    LinkAccountNo = list[0].LinkAccountNo;
                }
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
        private void DgvSaleInvoice_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //txtDescription.Text = DgvSaleInvoice.Rows[e.RowIndex].Cells[4].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[3].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[5].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[7].Value.ToString() + " Units " + " @" + DgvSaleInvoice.Rows[e.RowIndex].Cells[9].Value.ToString() + Environment.NewLine;
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
                        cbxNaturalAccounts.Focus();
                        cbxNaturalAccounts.DroppedDown = true;
                    }
                }
                else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    if (EventTime == 0)
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
                }
                else
                    e.Handled = false;
            }
        }
        private void CustEditBox_TextChanged(object sender, EventArgs e)
        {
            //if (EventTime == 0)
            //{                               
            //    CommandType = "Persons";
            //    frmAccount = new frmFindAccounts();
            //    frmAccount.SearchText = CustEditBox.Text;
            //    frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            //    frmAccount.ShowDialog();
            //}
        }
        private void EmpEditCode_TextChanged(object sender, EventArgs e)
        {
            if (EventTime == 0)
            {
                CommandType = "Employees";
                frmAccount = new frmFindAccounts();
                frmAccount.SearchText = CustEditBox.Text;
                frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                frmAccount.ShowDialog();
            }
        }
        #region Purchases Grid Code and Events
        private void DgvSalesAccounts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvSalesAccounts.Columns[e.ColumnIndex].Name == "colDebit")
            {

                for (int i = 0; i < DgvSalesAccounts.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvSalesAccounts.Rows[i].Cells["colDebit"].Value);
                }
                //txtAmount.Text = OldValue.ToString();
                txtDebit.Text = OldValue.ToString();
                OldValue = 0;

            }
            else if (DgvSalesAccounts.Columns[e.ColumnIndex].Name == "colCredit")
            {
                for (int i = 0; i < DgvSalesAccounts.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvSalesAccounts.Rows[i].Cells["colCredit"].Value);
                }
                //txtAmount.Text = OldValue.ToString();
                txtCredit.Text = OldValue.ToString();
                OldValue = 0;
            }
        }
        private void DgvSalesAccounts_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvSalesAccounts.Columns[e.ColumnIndex].Name == "colDebit")
            {
                if (DgvSalesAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    DgvSalesAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
            else if (DgvSalesAccounts.Columns[e.ColumnIndex].Name == "colCredit")
            {
                if (DgvSalesAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    DgvSalesAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
        }
        private void DgvSalesAccounts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvSalesAccounts.CurrentCellAddress.X == 5)
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
            if (DgvSalesAccounts.CurrentCellAddress.X == 5)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmAccount = new frmFindAccounts();
                    CommandType = "DgvSales";
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
        private void cbxSaleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSaleType.Text == "Gloves Export Sales" || cbxSaleType.Text == "Garments Export Sales")
            {
                DgvSaleInvoice.Columns[6].Visible = true;
                ResizeColumns(cbxSaleType.SelectedIndex);
            }
            else
            {
                DgvSaleInvoice.Columns[6].Visible = false;
                ResizeColumns(cbxSaleType.SelectedIndex);
            }
        }
        private void ResizeColumns(int SaleType)
        {
            //if (SaleType == 2 || SaleType == 3)
            //{
            //    DgvSaleInvoice.Columns["colCurrentStock"].Width = 125;
            //    DgvSaleInvoice.Columns["colQty"].Width = 125;
            //}
            //else
            //{
            //    DgvSaleInvoice.Columns["colCurrentStock"].Width = 165;
            //    DgvSaleInvoice.Columns["colQty"].Width = 165;
            //}
        }
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedIndex == 1)
            {
                CreateAndInitializeFooterRow();
            }
        }
        frmgeneralLedger frmledger;

        private void rdCreditSale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCreditSale.Checked)
            {
                lblCashAccount.Visible = false;
                cbxCashAccounts.Visible = false;
            }
        }

        private void rdCashSale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCashSale.Checked)
            {
                lblCashAccount.Visible = true;
                cbxCashAccounts.Visible = true;
            }
        }

        private void btnViewLedger_Click(object sender, EventArgs e)
        {
            if (CustomerAccountNo != string.Empty)
            {
                frmledger = new frmgeneralLedger();
                frmledger.AccountNo = CustomerAccountNo;
                frmledger.AccountName = CustEditBox.Text;
                frmledger.Show();
            }
            else
            {
                MessageBox.Show("Select Customer First To View Ledger...");
            }
        }
        frmPersons frmpersons;
        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (CustomerAccountNo != string.Empty)
            {
                frmpersons = new frmPersons();
                frmpersons.AccountNo = CustomerAccountNo;
                frmpersons.Show();
            }
            else
            {
                MessageBox.Show("Select Customer First To View Detail...");
            }
        }
    }
}
