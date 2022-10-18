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

namespace Accounts.UI
{
    public partial class frmStockProductionOutPut : MetroForm
    {
        frmFindAccounts frmAccount;
        frmStockAccounts frmstockAccounts;
        frmFindVouchers frmfindVouchers;
        string EventCommandName;
        string EventStockName;
        int EventTime = 0;
        public Int64 VoucherNo { get; set; }
        public Guid SupplierTransactionId { get; set; }
        public Guid PurchasesTransactionId { get; set; }
        Guid IdVoucher;
        public frmStockProductionOutPut()
        {
            InitializeComponent();
        }

        private void frmStockIssuance_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.grdProducts.AutoGenerateColumns = false;
            FillData();
            FillDepartments();
            FillBrands();
            FillNaturalAccounts("");
        }
        private void FillData()
        {
            var manager = new VoucherBLL();
            VEditBox.Text = manager.GetMaxVoucherNumber("ProductionOutPutVoucher", Operations.IdCompany);
        }
        private void FillDepartments()
        {
            var manager = new ProcessesBLL();
            List<ProcessesEL> list = manager.GetAllProcesses();

            cbxDepartments.DataSource = list;
            cbxDepartments.DisplayMember = "ProcessName";
            cbxDepartments.ValueMember = "IdProcess";
        }
        private void FillBrands()
        {
            var manager = new BrandBLL();
            List<BrandEL> list = manager.GetAllBrands(Operations.IdCompany);
            if (list.Count > 0)
            {
                colProductBrand.DataSource = list;

                colProductBrand.DisplayMember = "BrandName";
                colProductBrand.ValueMember = "IdBrand";
            }

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
        private void cbxNaturalAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxNaturalAccounts.SelectedIndex > 0)
            {
                txtPurchasesAccountName.Text = Validation.GetSafeString(cbxNaturalAccounts.SelectedValue);
            }
        }
        private bool ValidateRows()
        {

            for (int i = 0; i < grdProducts.Rows.Count - 1; i++)
            {
                if (grdProducts.Rows[i].Cells["colProductQty"].Value == null)
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidateControls()
        {
            if (SEditBox.Text == string.Empty)
            {
                MessageBox.Show("Account No Is Missing....");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<VoucherDetailEL> oelProductionReceiptDetailCollection = new List<VoucherDetailEL>();
            List<VoucherDetailEL> oelWastageCollection = new List<VoucherDetailEL>();
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            if (ValidateRows())
            {
                if (ValidateControls())
                {
                    /// Add Voucher...
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
                    oelVoucher.IdDepartment = Validation.GetSafeGuid(cbxDepartments.SelectedValue);
                    oelVoucher.VoucherNo = Convert.ToInt64(VEditBox.Text);
                    oelVoucher.AccountNo = Validation.GetSafeString(SEditBox.Text);
                    oelVoucher.Description = Validation.GetSafeString(txtDescription.Text);
                    oelVoucher.CreatedDateTime = VDate.Value;
                    #endregion
                    ///Add Stock Detail 
                    #region Cuff / Talli Stock Entries
                    if (TabOutPutModules.SelectedIndex == 0)
                    {
                        for (int i = 0; i < grdCuffTalliOutput.Rows.Count - 1; i++)
                        {
                            VoucherDetailEL oelProductionReceipt = new VoucherDetailEL();
                            ItemsEL oelItem = new ItemsEL();
                            if (grdCuffTalliOutput.Rows[i].Cells["colCuffTalliId"].Value != null)
                            {
                                //oelPurchaseDetial.TransactionID = new Guid(DgvStockReceipt.Rows[i].Cells["ColTransaction"].Value.ToString());
                                oelProductionReceipt.IdVoucherDetail = new Guid(grdCuffTalliOutput.Rows[i].Cells["colCuffTalliId"].Value.ToString());
                                oelProductionReceipt.IsNew = false;
                            }
                            else
                            {
                                oelProductionReceipt.IdVoucherDetail = Guid.NewGuid();
                                //  oelPurchaseDetial.TransactionID = Guid.NewGuid();
                                oelProductionReceipt.IsNew = true;
                            }
                            oelProductionReceipt.Seq = i + 1;
                            oelProductionReceipt.IdVoucher = oelVoucher.IdVoucher;
                            oelProductionReceipt.VoucherNo = Convert.ToInt64(VEditBox.Text);
                            oelProductionReceipt.IdItem = Validation.GetSafeGuid(grdCuffTalliOutput.Rows[i].Cells["colCuffTalliIdItem"].Value);
                            oelProductionReceipt.IdBrand = Guid.Empty;
                            oelProductionReceipt.PackingSize = Validation.GetSafeString(grdCuffTalliOutput.Rows[i].Cells["colCuffTalliUOM"].Value);
                            oelProductionReceipt.Description = "N/A";
                            oelProductionReceipt.Qty = Validation.GetSafeInteger(grdCuffTalliOutput.Rows[i].Cells["colCuffTalliQty"].Value);
                            oelProductionReceipt.UnitPrice = Validation.GetSafeInteger(grdCuffTalliOutput.Rows[i].Cells["colCuffTalliRate"].Value);
                            oelProductionReceipt.Amount = Validation.GetSafeInteger(grdCuffTalliOutput.Rows[i].Cells["colCuffTalliAmount"].Value);

                            oelProductionReceiptDetailCollection.Add(oelProductionReceipt);
                        }
                        for (int i = 0; i < grdCuffTaliWastage.Rows.Count - 1; i++)
                        {
                            VoucherDetailEL oelWastage = new VoucherDetailEL();
                            ItemsEL oelItem = new ItemsEL();
                            if (grdCuffTalliOutput.Rows[i].Cells["colIdDetail"].Value != null)
                            {
                                //oelPurchaseDetial.TransactionID = new Guid(DgvStockReceipt.Rows[i].Cells["ColTransaction"].Value.ToString());
                                oelWastage.IdVoucherDetail = new Guid(grdCuffTaliWastage.Rows[i].Cells["colCuffTalliWastageId"].Value.ToString());
                                oelWastage.IsNew = false;
                            }
                            else
                            {
                                oelWastage.IdVoucherDetail = Guid.NewGuid();
                                //  oelPurchaseDetial.TransactionID = Guid.NewGuid();
                                oelWastage.IsNew = true;
                            }
                            oelWastage.Seq = i + 1;
                            oelWastage.IdVoucher = oelVoucher.IdVoucher;
                            oelWastage.VoucherNo = Convert.ToInt64(VEditBox.Text);
                            oelWastage.IdItem = Validation.GetSafeGuid(grdCuffTaliWastage.Rows[i].Cells["colCuffTalliWastageIdItem"].Value);
                            oelWastage.PackingSize = Validation.GetSafeString(grdCuffTaliWastage.Rows[i].Cells["colCuffTalliWastageUOM"].Value);
                            oelWastage.Description = "N/A";
                            oelWastage.Qty = Validation.GetSafeInteger(grdCuffTaliWastage.Rows[i].Cells["colCuffTalliWastageQty"].Value);
                            oelWastage.UnitPrice = Validation.GetSafeInteger(grdCuffTaliWastage.Rows[i].Cells["colCuffTalliWastageUnitPrice"].Value);
                            oelWastage.Amount = Validation.GetSafeInteger(grdCuffTaliWastage.Rows[i].Cells["colCuffTalliWastageAmount"].Value);

                            oelWastageCollection.Add(oelWastage);
                        }
                    }
                    #endregion
                    #region Departments Stock Entries
                    if (TabOutPutModules.SelectedIndex == 1)
                    {
                        for (int i = 0; i < grdProducts.Rows.Count - 1; i++)
                        {
                            VoucherDetailEL oelProductionIssuance = new VoucherDetailEL();
                            ItemsEL oelItem = new ItemsEL();
                            if (grdProducts.Rows[i].Cells["colProductIdDetail"].Value != null)
                            {
                                //oelPurchaseDetial.TransactionID = new Guid(DgvStockReceipt.Rows[i].Cells["ColTransaction"].Value.ToString());
                                oelProductionIssuance.IdVoucherDetail = new Guid(grdProducts.Rows[i].Cells["colProductIdDetail"].Value.ToString());
                                oelProductionIssuance.IsNew = false;
                            }
                            else
                            {
                                oelProductionIssuance.IdVoucherDetail = Guid.NewGuid();
                                //  oelPurchaseDetial.TransactionID = Guid.NewGuid();
                                oelProductionIssuance.IsNew = true;
                            }
                            oelProductionIssuance.Seq = i + 1;
                            oelProductionIssuance.IdVoucher = oelVoucher.IdVoucher;
                            oelProductionIssuance.VoucherNo = Convert.ToInt64(VEditBox.Text);
                            oelProductionIssuance.IdItem = Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colProductIdItem"].Value);
                            oelProductionIssuance.IdBrand = Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colProductBrand"].Value);
                            oelProductionIssuance.PackingSize = Validation.GetSafeString(grdProducts.Rows[i].Cells["colProductUOM"].Value);
                            oelProductionIssuance.Description = "N/A";
                            oelProductionIssuance.Qty = Validation.GetSafeInteger(grdProducts.Rows[i].Cells["colProductQty"].Value);
                            oelProductionIssuance.UnitPrice = Validation.GetSafeInteger(grdProducts.Rows[i].Cells["colProductRate"].Value);
                            oelProductionIssuance.Amount = Validation.GetSafeInteger(grdProducts.Rows[i].Cells["colProductAmount"].Value);

                            oelProductionReceiptDetailCollection.Add(oelProductionIssuance);
                        }
                        for (int i = 0; i < grdWastage.Rows.Count - 1; i++)
                        {
                            VoucherDetailEL oelWastage = new VoucherDetailEL();
                            ItemsEL oelItem = new ItemsEL();
                            if (grdCuffTalliOutput.Rows[i].Cells["colWastageDetailId"].Value != null)
                            {
                                //oelPurchaseDetial.TransactionID = new Guid(DgvStockReceipt.Rows[i].Cells["ColTransaction"].Value.ToString());
                                oelWastage.IdVoucherDetail = new Guid(grdWastage.Rows[i].Cells["colWastageDetailId"].Value.ToString());
                                oelWastage.IsNew = false;
                            }
                            else
                            {
                                oelWastage.IdVoucherDetail = Guid.NewGuid();
                                //  oelPurchaseDetial.TransactionID = Guid.NewGuid();
                                oelWastage.IsNew = true;
                            }
                            oelWastage.Seq = i + 1;
                            oelWastage.IdVoucher = oelVoucher.IdVoucher;
                            oelWastage.VoucherNo = Convert.ToInt64(VEditBox.Text);
                            oelWastage.IdItem = Validation.GetSafeGuid(grdWastage.Rows[i].Cells["colWastageIdItem"].Value);
                            oelWastage.PackingSize = Validation.GetSafeString(grdWastage.Rows[i].Cells["colWastageUOM"].Value);
                            oelWastage.Description = "N/A";
                            oelWastage.Qty = Validation.GetSafeInteger(grdWastage.Rows[i].Cells["colWastageqty"].Value);
                            oelWastage.UnitPrice = Validation.GetSafeInteger(grdWastage.Rows[i].Cells["colWastageUnitPrice"].Value);
                            oelWastage.Amount = Validation.GetSafeInteger(grdWastage.Rows[i].Cells["colWastageAmount"].Value);

                            oelWastageCollection.Add(oelWastage);
                        }
                    }
                    #endregion
                    #region Now Add Transactional Accounts
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
                    oelSupplierTransaction.IdCompany = Operations.IdCompany;
                    oelSupplierTransaction.AccountNo = Validation.GetSafeString(SEditBox.Text);
                    oelSupplierTransaction.LinkAccountNo = "";
                    oelSupplierTransaction.SubAccountNo = "0";
                    oelSupplierTransaction.Date = VDate.Value;
                    oelSupplierTransaction.VoucherNo = Convert.ToInt32(VEditBox.Text);
                    oelSupplierTransaction.VoucherType = "ProductionOutPutVoucher";
                    oelSupplierTransaction.Description = txtDescription.Text;
                    oelSupplierTransaction.Credit = 0; //Convert.ToDecimal(txtCreditBalance.Text);
                    oelSupplierTransaction.Debit = 0;
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
                    oelPurchaseTransaction.IdCompany = Operations.IdCompany;
                    //oelPurchaseTransaction.AccountNo = Validation.GetSafeLong(PurchasesEditBox.Text);
                    oelPurchaseTransaction.AccountNo = Validation.GetSafeString(txtPurchasesAccountName.Text);
                    oelPurchaseTransaction.LinkAccountNo = "";
                    oelPurchaseTransaction.SubAccountNo = "0";
                    oelPurchaseTransaction.Date = VDate.Value;
                    oelPurchaseTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelPurchaseTransaction.VoucherType = "ProductionOutPutVoucher";
                    oelPurchaseTransaction.Description = txtDescription.Text;
                    oelPurchaseTransaction.Debit = 0;//Validation.GetSafeDecimal(txtCreditBalance.Text);

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
                    #endregion
                    if (IdVoucher == Guid.Empty)
                    {
                        var manager = new ProductionReceiptHeadBLL();
                        EntityoperationInfo infoResult = manager.InsertProductionReceipt(oelVoucher, oelProductionReceiptDetailCollection,oelWastageCollection,oelTransactionCollection, true);
                        if (infoResult.IsSuccess)
                        {
                            MessageBox.Show("Inventory Issued Successfully...");
                            ClearControl();
                            FillData();
                        }

                        else
                        {
                            MessageBox.Show("This Voucher No Already Exists ; Plz Change Voucher No :");
                        }
                    }
                    else
                    {
                        var manager = new ProductionReceiptHeadBLL();
                        EntityoperationInfo infoResult = manager.UpdateProductionReceipt(oelVoucher, oelProductionReceiptDetailCollection, oelWastageCollection, oelTransactionCollection, true);
                        if (infoResult.IsSuccess)
                        {
                            MessageBox.Show("Inventory Issuance Updated Successfully...");
                            ClearControl();
                            FillData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Check Values");
                }
            }
            else
            {
                MessageBox.Show("Incomplete Entry...");
            }
        }
        private void ClearControl()
        {
            grdProducts.Rows.Clear();
            VoucherNo = 0;
            IdVoucher = Guid.Empty;
            VEditBox.Enabled = true;
            txtDescription.Text = string.Empty;


            SEditBox.Text = string.Empty;
            txtSupplierName.Text = string.Empty;
        }
        private void SEditBox_Click(object sender, EventArgs e)
        {

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
                        cbxDepartments.Focus();
                        cbxDepartments.DroppedDown = true;
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
        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            if (EventCommandName == "Persons")
            {
                //var manager = new PersonsBLL();
                // List<PersonsEL> list = manager.VerifyAccount(Operations.IdCompany, "Persons", oelAccount.AccountNo);
                //if (list.Count > 0)
                {
                    EventTime = 1;
                    SEditBox.Text = Validation.GetSafeString(oelAccount.AccountNo);
                    EventTime = 0;
                    txtSupplierName.Text = oelAccount.AccountName;
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
                grdProducts.CurrentRow.Cells["colAccountNo"].Value = oelAccount.AccountNo;
                grdProducts.CurrentRow.Cells["colLinkAccount"].Value = oelAccount.LinkAccountNo;
                grdProducts.CurrentRow.Cells["colIdAccount"].Value = oelAccount.IdAccount;
                grdProducts.CurrentRow.Cells["colAccountName"].Value = oelAccount.AccountName;
            }
        }     
        private void FillVoucher()
        {
            //var manager = new ProductionIssuanceHeadBLL();
            //List<VoucherDetailEL> list = manager.GetProductionStockIssuanceByNo(Validation.GetSafeLong(VEditBox.Text), Operations.IdCompany);
            //if (list.Count > 0)
            //{
            //    VDate.Value = list[0].CreatedDateTime.Value;
            //    cbxDepartments.SelectedValue = list[0].IdDepartment;
            //    // cbxInOut.SelectedIndex = list[0].ProcessType;
            //    SEditBox.Text = list[0].AccountNo;
            //    txtSupplierName.Text = list[0].AccountName;
            //    txtDescription.Text = list[0].Description;
            //    FillIssuanceDetail(list);
            //}
        }
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillVoucher();
            }
        }
        private void FillIssuanceDetail(List<VoucherDetailEL> list)
        {
            grdProducts.Rows.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                grdProducts.Rows.Add();
                grdProducts.Rows[i].Cells["colIdDetail"].Value = list[i].IdVoucherDetail;
                grdProducts.Rows[i].Cells["colIdItem"].Value = list[i].IdItem;
                grdProducts.Rows[i].Cells["colItemName"].Value = list[i].ItemName;
                grdProducts.Rows[i].Cells["colRemarks"].Value = list[i].Narration;
                grdProducts.Rows[i].Cells["colpacking"].Value = list[i].PackingSize;
                grdProducts.Rows[i].Cells["colQty"].Value = list[i].Qty;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region  Departments OutPutWork
        private void grdProducts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdProducts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdProducts.CurrentCellAddress.X == 3)
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
            if (grdProducts.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {                    
                    frmstockAccounts = new frmStockAccounts();
                    EventStockName = "ProductGrid";
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
        private void grdWastage_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdWastage.CurrentCellAddress.X == 3)
            {
                TextBox txtWastageItemName = e.Control as TextBox;
                if (txtWastageItemName != null)
                {
                    txtWastageItemName.KeyPress -= new KeyPressEventHandler(txtWastageItemName_KeyPress);
                    txtWastageItemName.KeyPress += new KeyPressEventHandler(txtWastageItemName_KeyPress);
                }
            }
        }
        void txtWastageItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdWastage.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventStockName = "WastageGrid";
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
        #region CuffTalliGridsWork
        private void grdCuffTalliOutput_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCuffTalliOutput.CurrentCellAddress.X == 3)
            {
                TextBox txtCuffTalliItemName = e.Control as TextBox;
                if (txtCuffTalliItemName != null)
                {
                    txtCuffTalliItemName.KeyPress -= new KeyPressEventHandler(txtCuffTalliItemName_KeyPress);
                    txtCuffTalliItemName.KeyPress += new KeyPressEventHandler(txtCuffTalliItemName_KeyPress);
                }
            }
        }
        void txtCuffTalliItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuffTalliOutput.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventStockName = "CuffTalliGrid";
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
        private void grdCuffTaliWastage_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCuffTaliWastage.CurrentCellAddress.X == 3)
            {
                TextBox txtCuffTalliWastageName = e.Control as TextBox;
                if (txtCuffTalliWastageName != null)
                {
                    txtCuffTalliWastageName.KeyPress -= new KeyPressEventHandler(txtCuffTalliWastageName_KeyPress);
                    txtCuffTalliWastageName.KeyPress += new KeyPressEventHandler(txtCuffTalliWastageName_KeyPress);
                }
            }
        }
        void txtCuffTalliWastageName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuffTaliWastage.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventStockName = "CuffTalliWastage";
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
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            var manager = new ItemsBLL();
            if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.AccountNo).Count > 0)
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
                if (EventStockName == "ProductGrid")
                {
                    grdProducts.CurrentRow.Cells["colProductIdItem"].Value = oelItems.IdItem;
                    grdProducts.CurrentRow.Cells["colProductItemName"].Value = oelItems.AccountName;
                    grdProducts.CurrentRow.Cells["colProductUOM"].Value = oelItems.PackingSize;
                }
                else if (EventStockName == "WastageGrid")
                {
                    grdWastage.CurrentRow.Cells["colWastageIdItem"].Value = oelItems.IdItem;
                    grdWastage.CurrentRow.Cells["colWastageItemName"].Value = oelItems.AccountName;
                    grdWastage.CurrentRow.Cells["colWastageUOM"].Value = oelItems.PackingSize;
                }
                else if (EventStockName == "CuffTalliGrid")
                {
                    grdCuffTalliOutput.CurrentRow.Cells["colCuffTalliIdItem"].Value = oelItems.IdItem;
                    grdCuffTalliOutput.CurrentRow.Cells["colCuffTalliItemName"].Value = oelItems.AccountName;
                    grdCuffTalliOutput.CurrentRow.Cells["colCuffTalliUOM"].Value = oelItems.PackingSize;
                }
                else if (EventStockName == "CuffTalliWastage")
                {
                    grdCuffTaliWastage.CurrentRow.Cells["colCuffTalliWastageIdItem"].Value = oelItems.IdItem;
                    grdCuffTaliWastage.CurrentRow.Cells["colCuffTalliWasgeItemName"].Value = oelItems.AccountName;
                    grdCuffTaliWastage.CurrentRow.Cells["colCuffTalliWasgeItemName"].Value = oelItems.PackingSize;
                }
            }
        }
    }
}
