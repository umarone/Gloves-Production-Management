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
    public partial class frmClotheProcess : MetroForm
    {
        #region Variables
        frmFindAccounts frmAccount;
        frmStockAccounts frmstockAccounts;
        frmFindVouchers frmfindVouchers;
        frmPrintCloseProcessGatePass frmgatepass;
        public decimal OldValue { get; set; }
        public Int64 VoucherNo { get; set; }
        Guid IdVoucher;
        public Guid SupplierTransactionId { get; set; }
        public Guid PurchasesTransactionId { get; set; }
        string PurchasesAccountNo = "", SupplierAccountNo = "";
        public string VoucherType { get; set; }
        public int IssuanceType { get; set; }
        public bool IsImport { get; set; }
        string EventCommandName;
        string StockCommand;
        #endregion
        #region Forms Events And Methods
        public frmClotheProcess()
        {
            InitializeComponent();
        }
        private void frmStockReceipt_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.DgvStockReceipt.AutoGenerateColumns = false;          
            FillData();
            FillNaturalAccounts(string.Empty);
            CheckModulePermissions();
            ShowHideControls();
        }        
        private void ShowHideControls()
        {
            if (IssuanceType == 1)
            {
                chkClaim.Visible = true;
                chkPlain.Visible = false;
                DgvStockReceipt.Columns["colLinkProduct"].Visible = false;
                DgvStockReceipt.Columns["colUnitPrice"].Visible = true;
                DgvStockReceipt.Columns["colAmount"].Visible = true;
                DgvStockReceipt.Columns["colLinkProduct"].ReadOnly = true;
                //ReSizeColumns(1);

                grpPurchases.Visible = false;
                this.Text = "Rubberizing Outward Gate Pass";
            }
            else
            {
                chkClaim.Visible = false;
                chkPlain.Visible = true;
                grpPurchases.Visible = true;
                DgvStockReceipt.Columns["colMarkeen"].Visible = false;
                DgvStockReceipt.Columns["colLinkProduct"].Visible = true;
                DgvStockReceipt.Columns["colUnitPrice"].Visible = true;
                DgvStockReceipt.Columns["colAmount"].Visible = true;

                DgvStockReceipt.Columns["colSideItem"].Visible = false;
                DgvStockReceipt.Columns["colActualWidth"].Visible = false;
                DgvStockReceipt.Columns["coloutWidth"].Visible = false;
                DgvStockReceipt.Columns["colDiff"].Visible = false;
                DgvStockReceipt.Columns["colSideAmount"].Visible = false;

                ReSizeColumns(2);
                this.Text = "Rubberizing Inward Gate Pass";
                grpPurchases.Visible = true;
            }
        }
        private void ReSizeColumns(int ResizeType)
        {
            if (ResizeType == 1)
            {
                DgvStockReceipt.Columns["colItemName"].Width = 250;
                DgvStockReceipt.Columns["colpacking"].Width = 200;
                DgvStockReceipt.Columns["colQty"].Width = 250;
                DgvStockReceipt.Columns["colYardQty"].Width = 150;

            }
            else
            {

                DgvStockReceipt.Columns["colItemName"].Width = 300;
                DgvStockReceipt.Columns["colLinkProduct"].Width = 250;
                DgvStockReceipt.Columns["colpacking"].Width = 150;
                DgvStockReceipt.Columns["colQty"].Width = 110;
                DgvStockReceipt.Columns["colYardQty"].Width = 150;
                DgvStockReceipt.Columns["colUnitPrice"].Width = 110;
                DgvStockReceipt.Columns["colAmount"].Width = 125;
                this.Text = "Rubberizing Inward Gate Pass";
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
            var manager = new ProcessHeadBLL();
            VEditBox.Text = manager.GetMaxRubberizingVoucherNumber(Operations.IdCompany,IssuanceType).ToString();
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
            SupplierAccountNo = string.Empty;

            PurchasesTransactionId = Guid.Empty;
            PurchasesAccountNo = string.Empty;


            SEditBox.Text = string.Empty;
            txtContact.Text = string.Empty;

            txtAddress.Text = string.Empty;
            lblStatuMessage.Text = string.Empty;

            CbxProcessType.SelectedIndex = 0;
            if(IssuanceType == 1)
            grpPurchases.Visible = false;
            if (chkPosted.Checked)
            {
                chkPosted.Checked = false;
                chkPosted.Enabled = true;
            }
            VDate.Value = DateTime.Now;         
            chkClaim.Checked = false;
            chkPlain.Checked = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
        }
        private bool ValidateRows()
        {

            for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
            {
                if (DgvStockReceipt.Rows[i].Cells["colQty"].Value == null || Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colQty"].Value) == 0)
                {
                    return false;
                }
                //else if (DgvStockReceipt.Rows[i].Cells["colYardQty"].Value == null || Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colYardQty"].Value) == 0)
                //{
                //    return false;
                //}
                if (IssuanceType == 2)
                {
                    if (CbxProcessType.Text != "Razing")
                    {
                        if (DgvStockReceipt.Rows[i].Cells["colIdLinkItem"].Value == null || Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colIdLinkItem"].Value) == string.Empty)
                        {
                            MessageBox.Show("Please Give Link Item....");
                            return false;
                        }
                    }
                }
                //else if (DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value == null)
                //{
                //    return false;
                //}
            }
            return true;
        }
        private bool ValidateControls()
        {
            if (SupplierAccountNo == string.Empty)
            {
                lblStatuMessage.Text = "Party Missing...";
                return false;
            }            
            if (IssuanceType == 2)
            {
                if (PurchasesAccountNo == string.Empty)
                {
                    MessageBox.Show("Please Select Purchase Account");
                    return false;
                }
            }
            return true;
        }
        #endregion
        #region Button Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            List<StockReceiptEL> oelStockReceiptCollection = new List<StockReceiptEL>();
            List<VoucherDetailEL> oelPurchaseDetailCollection = new List<VoucherDetailEL>();
            if (ValidateRows())
            {
                if (ValidateControls())
                {
                    #region Voucher Info
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
                    oelVoucher.VDate = VDate.Value;
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(txtCreditBalance.Text);
                    oelVoucher.Posted = chkPosted.Checked;
                    oelVoucher.WorkType = IssuanceType;
                    oelVoucher.VDiscription = Validation.GetSafeString(txtDescription.Text);
                    if (CbxProcessType.SelectedIndex == 0 || CbxProcessType.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please Select Process Type");
                        return;
                    }
                    else if (CbxProcessType.Text == "Rubberizing")
                    {
                        oelVoucher.ProcessType = 1;
                    }
                    else if (CbxProcessType.Text == "Razing")
                    {
                        oelVoucher.ProcessType = 2;
                    }
                    else if (CbxProcessType.Text == "Back Clothe Cutting")
                    {
                        oelVoucher.ProcessType = 3;
                    }

                    oelVoucher.IsPlain = chkPlain.Checked;
                    oelVoucher.IsClaimed = chkClaim.Checked;
                    #endregion
                    #region Stock Detail
                    for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                    {
                        VoucherDetailEL oelProcessDetail = new VoucherDetailEL();
                        oelProcessDetail.WorkType = IssuanceType;
                        if (DgvStockReceipt.Rows[i].Cells["colStockReceiptID"].Value != null)
                        {
                            //oelPurchaseDetial.TransactionID = new Guid(DgvStockReceipt.Rows[i].Cells["ColTransaction"].Value.ToString());
                            oelProcessDetail.IdVoucherDetail = new Guid(DgvStockReceipt.Rows[i].Cells["colStockReceiptID"].Value.ToString());
                            oelProcessDetail.IsNew = false;
                        }
                        else
                        {
                            oelProcessDetail.IdVoucherDetail = Guid.NewGuid();
                            //  oelPurchaseDetial.TransactionID = Guid.NewGuid();
                            oelProcessDetail.IsNew = true;
                        }
                        oelProcessDetail.Seq = i + 1;
                        oelProcessDetail.IdVoucher = oelVoucher.IdVoucher;
                        oelProcessDetail.VoucherNo = Convert.ToInt64(VEditBox.Text);
                        oelProcessDetail.IdItem = Validation.GetSafeGuid(DgvStockReceipt.Rows[i].Cells["colIdItem"].Value);
                        if (IssuanceType == 2 && DgvStockReceipt.Rows[i].Cells["colIdLinkItem"].Value == null)
                        {
                            if (CbxProcessType.Text != "Razing")
                            {
                                MessageBox.Show("Link Item Is Compulsory");
                                return;
                            }
                        }
                        else
                        {
                            oelProcessDetail.IdLinkItem = Validation.GetSafeGuid(DgvStockReceipt.Rows[i].Cells["colIdLinkItem"].Value);
                        }
                        if (IssuanceType == 1 && DgvStockReceipt.Rows[i].Cells["colIdLinkItem"].Value != null)
                        {
                            oelProcessDetail.IdLinkItem = Guid.Empty;
                            DgvStockReceipt.Rows[i].Cells["colIdLinkItem"].Value = null;
                        }
                        //oelPurchaseDetial.ItemNo = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colItemNo"].Value);
                        //oelPurchaseDetial.ItemName = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colItemName"].Value);
                        oelProcessDetail.PackingSize = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colpacking"].Value);

                        if (DgvStockReceipt.Rows[i].Cells["colMarkeen"].Value == null)
                        {
                            oelProcessDetail.IsMarkeen = false;
                        }
                        else
                        {
                            oelProcessDetail.IsMarkeen = Validation.GetSafeBooleanNullable(DgvStockReceipt.Rows[i].Cells["colMarkeen"].Value);
                        }
                        oelProcessDetail.IdSideItem = Validation.GetSafeGuid(DgvStockReceipt.Rows[i].Cells["colIdSideItem"].Value);
                        oelProcessDetail.ActualWidth = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colActualWidth"].Value);
                        oelProcessDetail.OutWidth = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["coloutWidth"].Value);
                        oelProcessDetail.Diff = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDiff"].Value);
                        oelProcessDetail.SideAmount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colSideAmount"].Value);

                        oelProcessDetail.Discription = "N/A"; //Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colRemarks"].Value);
                        oelProcessDetail.Units = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                        oelProcessDetail.MeterYardQty = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colYardQty"].Value);
                        //oelPurchaseDetial.Bonus = Validation.GetSafeInteger(DgvStockReceipt.Rows[i].Cells["colBonus"].Value);
                        oelProcessDetail.RemainingUnits = Validation.GetSafeInteger(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                        if (IssuanceType == 1 || IssuanceType == 2 || chkClaim.Checked)
                        {
                            oelProcessDetail.UnitPrice = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value);
                            if (IssuanceType == 1)
                            {
                                oelProcessDetail.AvgRate = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value);
                            }
                            else
                            {
                                oelProcessDetail.AvgRate = 0;
                            }
                            oelProcessDetail.AVGSideRate = 0;
                            oelProcessDetail.Discount = 0;//Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDisc"].Value);
                            oelProcessDetail.Amount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                        }
                        //else
                        //{
                        //    oelProcessDetail.UnitPrice = 0;
                        //    oelProcessDetail.Discount = 0;//Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colDisc"].Value);
                        //    oelProcessDetail.Amount = 0;
                        //}
                        oelPurchaseDetailCollection.Add(oelProcessDetail);
                    }
                    #endregion
                    #region Add Supplier
                    if (grpPurchases.Visible)
                    {
                        TransactionsEL oelSupplierTransaction = new TransactionsEL();
                        oelSupplierTransaction.IdVoucher = oelVoucher.IdVoucher;
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
                        oelSupplierTransaction.TransactionType = Validation.GetSafeString(CbxProcessType.Text);
                        oelSupplierTransaction.IdCompany = Operations.IdCompany;
                        oelSupplierTransaction.AccountNo = SupplierAccountNo;
                        oelSupplierTransaction.BookNo = Operations.BookNo;
                        oelSupplierTransaction.LinkAccountNo = "";
                        oelSupplierTransaction.SubAccountNo = "0";
                        oelSupplierTransaction.VDate = VDate.Value;
                        oelSupplierTransaction.VoucherNo = Convert.ToInt32(VEditBox.Text);
                        oelSupplierTransaction.VoucherType = "WorkProcess";
                        oelSupplierTransaction.VDiscription = txtDescription.Text;
                        //oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);
                        if (chkClaim.Checked)
                        {
                            oelSupplierTransaction.Debit = Validation.GetSafeDecimal(txtCreditBalance.Text);
                            oelSupplierTransaction.Credit = 0;
                        }
                        else
                        {
                            oelSupplierTransaction.Credit = Validation.GetSafeDecimal(txtCreditBalance.Text);
                            oelSupplierTransaction.Debit = 0;
                        }
                        oelSupplierTransaction.Posted = chkPosted.Checked;
                        oelTransactionCollection.Add(oelSupplierTransaction);
                    }
                    #endregion
                    #region Add Purchase Account In Transactions
                    /// Add Purchase Account...
                    if (grpPurchases.Visible)
                    {
                        TransactionsEL oelPurchaseTransaction = new TransactionsEL();
                        oelPurchaseTransaction.IdVoucher = oelVoucher.IdVoucher;
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
                        oelPurchaseTransaction.TransactionType = Validation.GetSafeString(CbxProcessType.Text);
                        oelPurchaseTransaction.IdCompany = Operations.IdCompany;
                        oelPurchaseTransaction.BookNo = Operations.BookNo;
                        //oelPurchaseTransaction.AccountNo = Validation.GetSafeLong(PurchasesEditBox.Text);
                        oelPurchaseTransaction.AccountNo = PurchasesAccountNo;
                        oelPurchaseTransaction.SubAccountNo = "0";
                        oelPurchaseTransaction.LinkAccountNo = "";
                        oelPurchaseTransaction.VDate = VDate.Value;
                        oelPurchaseTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                        oelPurchaseTransaction.VoucherType = "WorkProcess";
                        oelPurchaseTransaction.VDiscription = txtDescription.Text;

                        if (chkClaim.Checked)
                        {
                            oelPurchaseTransaction.Credit = Validation.GetSafeDecimal(txtCreditBalance.Text);
                            oelPurchaseTransaction.Debit = 0;
                        }
                        else
                        {
                            oelPurchaseTransaction.Debit = Validation.GetSafeDecimal(txtCreditBalance.Text);
                            oelPurchaseTransaction.Credit = 0;
                        }

                        oelPurchaseTransaction.Posted = chkPosted.Checked;
                        oelTransactionCollection.Add(oelPurchaseTransaction);
                    }
                    #endregion region
                    #region Save Code
                    if (IdVoucher == Guid.Empty)
                    {
                        var manager = new ProcessHeadBLL();
                        //var VManager = new VoucherBLL();
                        //if (VManager.CheckVoucherNo(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text), "WorkProcess") == false)
                        {

                            EntityoperationInfo infoResult = manager.InsertWorkProcess(oelVoucher, oelPurchaseDetailCollection, oelTransactionCollection);
                            if (infoResult.IsSuccess)
                            {
                                //manager.UpdateStockitems(oelTransactionCollection, "Add");
                                lblStatuMessage.Text = "Transaction Successfully Recorded...";
                                ClearControl();
                                FillData();
                            }
                        }
                        //else
                        //{
                        //MessageBox.Show("This Voucher No Already Exists ; Plz Change Voucher No :");
                        //}
                    }
                    else
                    {
                        var manager = new ProcessHeadBLL();
                        EntityoperationInfo infoResult = manager.UpdateWorkProcess(oelVoucher, oelPurchaseDetailCollection, oelTransactionCollection);
                        if (infoResult.IsSuccess)
                        {
                            //manager.UpdateStockitems(oelTransactionCollection, "Add");
                            lblStatuMessage.Text = "Transaction Successfully Recorded...";
                            ClearControl();
                            FillData();
                        }
                    }
                    #endregion
                }
                else
                {
                    lblStatuMessage.Text = "Check Values";
                }
            }
            else
            {
                lblStatuMessage.Text = "Incomplete Entry...";
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (VEditBox.Text != string.Empty)
            {
                var manager = new ProcessHeadBLL(); //PurchaseStockReceiptBLL();
                if (IdVoucher != Guid.Empty)
                {
                    if (MessageBox.Show("Are You Sure To Delete ?", "Deleting Voucher", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {

                        if (manager.DeleteProcessHead(IdVoucher))
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
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmgatepass = new frmPrintCloseProcessGatePass();
            frmgatepass.IssuanceNo = Validation.GetSafeLong(VEditBox.Text);
            frmgatepass.IssuanceType = IssuanceType;
            frmgatepass.ShowDialog();
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
        #endregion
        #region Grid Events 
        private void DgvStockReceipt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == 11)
            //{
            //    e.Value = "View Ledger";
            //}
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
            if (e.ColumnIndex == 11)
            {
                if (IssuanceType == 1)
                {
                    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colActualWidth"].Value != null && DgvStockReceipt.Rows[e.RowIndex].Cells["coloutWidth"].Value != null)
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colDiff"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colActualWidth"].Value) - Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["coloutWidth"].Value);
                    }
                }
            }
            if (e.ColumnIndex == 13)
            {
                List<ItemsEL> obj = null;
                if (IssuanceType == 1)
                {
                    var Manager = new ItemsBLL();
                    obj = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(DgvStockReceipt.Rows[e.RowIndex].Cells["colIdItem"].Value));
                    if (Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colpacking"].Value) == "Yard")
                    {
                        if ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) > obj[0].Qty)
                        {
                            MessageBox.Show("Your Quantity Is Exceeding Than Current Stock Which Is : " + obj[0].Qty.ToString());
                            //DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = "";
                            return;
                        }
                    }
                    else if (Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colpacking"].Value) == "Meter")
                    {
                        if (DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value != null)
                        {
                            if ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) > obj[0].Qty)
                            {
                                MessageBox.Show("Your Quantity Is Exceeding Than Current Stock Which Is : " + obj[0].Qty.ToString());
                                //DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = "";
                                return;
                            }
                        }
                    }
                    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value != null)
                    {
                        if (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colActualWidth"].Value) > 0)
                        {
                            decimal PerInchRate = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) / Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colActualWidth"].Value);
                            decimal ActualAmount = PerInchRate * Validation.GetSafeDecimal(Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["coloutWidth"].Value)) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value);
                            decimal SideAmount = PerInchRate * Validation.GetSafeDecimal(Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiff"].Value)) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value);

                            DgvStockReceipt.Rows[e.RowIndex].Cells["colSideAmount"].Value = SideAmount.ToString("0.000");
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = ActualAmount.ToString("0.000");
                        }
                        if ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) > obj[0].Qty)
                        {
                            MessageBox.Show("Your Quantity Is Exceeding Than Current Stock Which Is : " + obj[0].Qty.ToString());
                            //DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = "";
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value = "";
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = "";

                            return;
                        }
                        else
                        {
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value));
                        }
                    }
                    for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                    {
                        OldValue += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                    }
                    txtCreditBalance.Text = OldValue.ToString();
                    OldValue = 0;
                }
                //if ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Validation.GetSafeDecimal(1.09)) < obj[0].Qty || (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Validation.GetSafeDecimal(1.09)) == obj[0].Qty)
                {
                    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colpacking"] != null && Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colpacking"].Value) == "Yard")
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value;
                    }
                    else if (DgvStockReceipt.Rows[e.RowIndex].Cells["colpacking"] != null && Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colpacking"].Value) == "Meter")
                    {
                        DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Validation.GetSafeDecimal(1.0936)).ToString("0.00");
                    }
                }
            }
            else if (e.ColumnIndex == 15)
            {
                if (IssuanceType == 2)
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value));
                }
            }
        }
        private void DgvStockReceipt_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            List<ItemsEL> obj = null;
            var Manager = new ItemsBLL();
            obj = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(DgvStockReceipt.Rows[e.RowIndex].Cells["colIdItem"].Value));
            if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colYardQty")
            {
                if (IssuanceType == 2)
                {
                    var manager = new ProcessHeadBLL();
                    List<ItemsEL> list = manager.GetRubberingClosingStockToParty(Validation.GetSafeGuid(DgvStockReceipt.Rows[e.RowIndex].Cells["colIdLinkItem"].Value), SupplierAccountNo);                    
                    if (list.Count > 0)
                    {
                        if (IdVoucher == Guid.Empty)
                        {
                            if (Validation.GetSafeLong(DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value) > list[0].Qty)
                            {
                                MessageBox.Show("You Have only " + list[0].Qty + " Yards Remaining from " + SEditBox.Text);
                                DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value = "";
                                DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = "";
                                return;
                            }
                        }
                        else
                        {
                            List<ItemsEL> listlastEntry = manager.GetRubberingClosingStockToPartyLastEntry(IdVoucher, Validation.GetSafeGuid(DgvStockReceipt.Rows[e.RowIndex].Cells["colIdLinkItem"].Value), SupplierAccountNo);
                            if ((listlastEntry[0].Qty + list[0].Qty) >= Validation.GetSafeLong(DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value))
                            {
                                // Take No Action....
                            }
                            else
                            {
                                MessageBox.Show("You Have only " + list[0].Qty + " Yards Remaining from " + SEditBox.Text);
                                DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value = "";
                                DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = "";
                                return;
                            }
                        }
                    }
                }
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colUnitPrice")
            {
                if (IssuanceType == 2)
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value));
                }
            }
            else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            {
                if (IssuanceType == 2)
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                }
                else
                {
                    if (Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colpacking"].Value) == "Yard")
                    {
                        if ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) > obj[0].Qty)
                        {
                            //MessageBox.Show("Your Quantity Is Exceeding Than Current Stock Which Is : " + obj[0].Qty.ToString());
                            //DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = "";
                            return;
                        }
                    }
                    else if (Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colpacking"].Value) == "Meter")
                    {
                        if (DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value != null)
                        {
                            if ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) > obj[0].Qty)
                            {
                                //MessageBox.Show("Your Quantity Is Exceeding Than Current Stock Which Is : " + obj[0].Qty.ToString());
                                //DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = "";
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colActualWidth"].Value) > 0)
                        {
                            decimal PerInchRate = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) / Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colActualWidth"].Value);
                            decimal ActualAmount = PerInchRate * Validation.GetSafeDecimal(Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["coloutWidth"].Value)) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value);
                            decimal SideAmount = PerInchRate * Validation.GetSafeDecimal(Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiff"].Value)) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value);

                            DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = ActualAmount;
                        }
                    }
                }
                for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                {
                    OldValue += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                }
                txtCreditBalance.Text = OldValue.ToString();
                OldValue = 0;
            }
            if (e.ColumnIndex == 13)
            {
                if (IssuanceType == 1)
                {

                    if (Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colpacking"].Value) == "Yard")
                    {
                        if ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) > obj[0].Qty)
                        {
                            //MessageBox.Show("Your Quantity Is Exceeding Than Current Stock Which Is : " + obj[0].Qty.ToString());
                            //DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = "";
                            return;
                        }
                    }
                    else if (Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colpacking"].Value) == "Meter")
                    {
                        if (DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value != null)
                        {
                            if ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) > obj[0].Qty)
                            {
                                //MessageBox.Show("Your Quantity Is Exceeding Than Current Stock Which Is : " + obj[0].Qty.ToString());
                                //DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = "";
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colActualWidth"].Value) > 0)
                        {
                            decimal PerInchRate = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) / Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colActualWidth"].Value);
                            decimal ActualAmount = PerInchRate * Validation.GetSafeDecimal(Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["coloutWidth"].Value)) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value);
                            decimal SideAmount = PerInchRate * Validation.GetSafeDecimal(Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colDiff"].Value)) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value);

                            DgvStockReceipt.Rows[e.RowIndex].Cells["colSideAmount"].Value = SideAmount.ToString("0.000");
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = ActualAmount.ToString("0.000");
                        }
                        else
                        {
                            
                            if ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) > obj[0].Qty)
                            {
                                MessageBox.Show("Your Quantity Is Exceeding Than Current Stock Which Is : " + obj[0].Qty.ToString());
                                //DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = "";
                                DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value = "";
                                DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = "";

                                return;
                            }
                            else 
                            {
                                DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value));
                            }
                        } 
                    }

                }
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
            if (e.ColumnIndex == 6)
            {
                SendKeys.Send("{F4}");
            }
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
            if (DgvStockReceipt.CurrentCellAddress.X == 5)
            {
                TextBox txtItemName = e.Control as TextBox;
                if (txtItemName != null)
                {
                    txtItemName.KeyPress -= new KeyPressEventHandler(txtItemName_KeyPress);
                    txtItemName.KeyPress += new KeyPressEventHandler(txtItemName_KeyPress);
                }
            }
            if (DgvStockReceipt.CurrentCellAddress.X == 6)
            {
                TextBox txtLinkItemName = e.Control as TextBox;
                if (txtLinkItemName != null)
                {
                    txtLinkItemName.KeyPress -= new KeyPressEventHandler(txtLinkItemName_KeyPress);
                    txtLinkItemName.KeyPress += new KeyPressEventHandler(txtLinkItemName_KeyPress);
                }
            }
            if (DgvStockReceipt.CurrentCellAddress.X == 7)
            {
                TextBox txtSideItem = e.Control as TextBox;
                if (txtSideItem != null)
                {
                    txtSideItem.KeyPress -= new KeyPressEventHandler(txtSideItem_KeyPress);
                    txtSideItem.KeyPress += new KeyPressEventHandler(txtSideItem_KeyPress);
                }
            }
        }
        void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvStockReceipt.CurrentCellAddress.X == 5)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    StockCommand = "InWard";
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
        void txtLinkItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvStockReceipt.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    StockCommand = "";
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
        void txtSideItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvStockReceipt.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    StockCommand = "SideItem";
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
        #region ComboBox Events
        private void SEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetroFramework.Controls.MetroTextBox txt = sender as MetroFramework.Controls.MetroTextBox;
            if (txt != null)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (txt.Name == "SEditBox")
                    {
                        if (grpPurchases.Visible)
                        {
                            cbxNaturalAccounts.Focus();
                            cbxNaturalAccounts.DroppedDown = true;
                        }
                        else
                        {
                        }
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

            }
        }
        private void cbxInOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CbxProcessType.Focus();
                CbxProcessType.DroppedDown = true;
            }
        }
        private void CbxProcessType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DgvStockReceipt.Focus();
            }
        }
        private void cbxNaturalAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxNaturalAccounts.SelectedIndex > 0)
            {
                PurchasesAccountNo = Validation.GetSafeString(cbxNaturalAccounts.SelectedValue);
            }
        }
        //private void cbxInOut_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbxInOut.SelectedIndex > 0)
        //    {
        //        if (!chkClaim.Checked)
        //        {
        //            if (cbxInOut.SelectedIndex == 2)
        //            {
        //                DgvStockReceipt.Columns["colUnitPrice"].Visible = false;
        //                DgvStockReceipt.Columns["colAmount"].Visible = false;

        //                DgvStockReceipt.Columns["colItemName"].Width = 500;
        //                DgvStockReceipt.Columns["colpacking"].Width = 250;
        //                DgvStockReceipt.Columns["colQty"].Width = 250;

        //                grpPurchases.Visible = false;
        //            }
        //            else
        //            {
        //                DgvStockReceipt.Columns["colItemName"].Width = 350;
        //                DgvStockReceipt.Columns["colpacking"].Width = 130;
        //                DgvStockReceipt.Columns["colQty"].Width = 130;
        //                DgvStockReceipt.Columns["colUnitPrice"].Visible = true;
        //                DgvStockReceipt.Columns["colAmount"].Visible = true;

        //                grpPurchases.Visible = true;
        //            }
        //        }
        //        else
        //        {
        //            DgvStockReceipt.Columns["colItemName"].Width = 350;
        //            DgvStockReceipt.Columns["colpacking"].Width = 130;
        //            DgvStockReceipt.Columns["colQty"].Width = 130;
        //            DgvStockReceipt.Columns["colUnitPrice"].Visible = true;
        //            DgvStockReceipt.Columns["colAmount"].Visible = true;

        //            grpPurchases.Visible = false;
        //        }
        //    }
        //}
        #endregion
        #region Check Box Events
        private void chkPlain_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPlain.Checked)
            {
                grpPurchases.Visible = false;
            }
            else
            {
                grpPurchases.Visible = true;
            }
        }
        private void chkClaim_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClaim.Checked)
            {
                grpPurchases.Visible = true;
                DgvStockReceipt.Columns["colUnitPrice"].Visible = true;
                DgvStockReceipt.Columns["colAmount"].Visible = true;
                ReSizeColumns(2);
            }
            else
            {
                DgvStockReceipt.Columns["colUnitPrice"].Visible = false;
                DgvStockReceipt.Columns["colAmount"].Visible = false;
                ReSizeColumns(1);
                grpPurchases.Visible = false;
            }
        }
        #endregion
        #region Custom And Other Controls Events
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
                    SEditBox.Text = oelAccount.AccountName;
                }
                //else
                //{
                //lblStatuMessage.Text = "Please Select Supplier";
                //}
            }
        }
        private void DgvStockReceipt_KeyDown(object sender, KeyEventArgs e)
        {
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            DgvStockReceipt.RefreshEdit();
            var manager = new ItemsBLL();
            decimal AverageValue = manager.GetItemsAvgValue(oelItems.IdItem);
            //if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.AccountNo).Count > 0)
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
                if (StockCommand == "InWard")
                {
                    lblStatuMessage.Text = "";
                    DgvStockReceipt.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
                    DgvStockReceipt.CurrentRow.Cells["colItemNo"].Value = oelItems.ItemNo;
                    DgvStockReceipt.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
                    if (IssuanceType == 1)
                    {
                        DgvStockReceipt.CurrentRow.Cells["colUnitPrice"].Value = AverageValue.ToString("0.00");
                    }
                }
                else if (StockCommand == "SideItem")
                {
                    lblStatuMessage.Text = "";
                    DgvStockReceipt.CurrentRow.Cells["colIdSideItem"].Value = oelItems.IdItem;
                    DgvStockReceipt.CurrentRow.Cells["colSideItem"].Value = oelItems.ItemName;
                }
                else
                {
                    DgvStockReceipt.CurrentRow.Cells["colIdLinkItem"].Value = oelItems.IdItem;
                    DgvStockReceipt.CurrentRow.Cells["colLinkProduct"].Value = oelItems.ItemName;
                }
                //DgvStockReceipt.CurrentRow.Cells["ColBatch"].Value = oelItems.BatchNo;
            }
            //else
            //{
            //lblStatuMessage.Text = "Wrong Account...";
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
        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DgvStockReceipt.Focus();
            }
        }
        #endregion
        #region Transactional Methods
        private void FillVoucher()
        {
            var Manager = new VoucherBLL();
            var PMananger = new ProcessDetailBLL();
            VoucherType = "WorkProcess";
            if (VEditBox.Text != string.Empty)
            {
                //List<VouchersEL> list = Manager.GetVouchersByTypeAndVoucherNumber(Operations.IdCompany, VoucherType, Convert.ToInt64(VEditBox.Text));
                List<VoucherDetailEL> list = PMananger.GetRubberizingByIssuanceTypeAndNumber(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text), IssuanceType);
                if (list.Count > 0)
                {
                    IdVoucher = list[0].IdVoucher;
                    VEditBox.Enabled = false;
                    VDate.Value = list[0].VDate.Value;
                    txtDescription.Text = list[0].VDiscription;
                    SupplierAccountNo = list[0].AccountNo;
                    SEditBox.Text = list[0].AccountName;

                    ShowHideControls();
                    CbxProcessType.SelectedIndex = list[0].ProcessType;
                    chkClaim.Checked = list[0].IsClaimed.Value;
                    chkPlain.Checked = list[0].IsPlain.Value;
                    FillTransactions(list);
                    HandleVoucher(list);

                    if (IssuanceType == 2)
                    {
                        List<TransactionsEL> listTransactions = Manager.GetTransactions(IdVoucher, "WorkProcess", Operations.IdCompany);

                        if (listTransactions.Count > 0)
                        {
                            TransactionsEL oelSalesTransaction = listTransactions.Find(x => x.Debit != 0);
                            if (oelSalesTransaction != null)
                            {
                                FillNaturalAccounts(oelSalesTransaction.AccountNo.ToString());
                                PurchasesAccountNo = oelSalesTransaction.AccountNo.ToString();
                                PurchasesTransactionId = oelSalesTransaction.TransactionID;
                            }
                            TransactionsEL oelPurchaseTransaction = listTransactions.Find(x => x.Credit != 0);
                            if (oelPurchaseTransaction != null)
                            {
                                SEditBox.Text = oelPurchaseTransaction.AccountName;
                                SupplierAccountNo = oelPurchaseTransaction.AccountNo;
                                SupplierTransactionId = oelPurchaseTransaction.TransactionID;
                            }

                        }
                    }
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
                    lblVoucherStatus.Visible = true;
                    lblVoucherStatus.Text = "Deleted Voucher...";
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    chkPosted.Enabled = false;
                }

            }
            else if (list[0].Posted && !list[0].IsDeleted == true)
            {
                //btnSave.Enabled = false;
                //btnDelete.Enabled = false;
                lblVoucherStatus.Visible = true;
                lblVoucherStatus.Text = "Deleted Voucher...";
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                chkPosted.Enabled = false;
                chkPosted.Enabled = false;
            }
            else if (!list[0].Posted && list[0].IsDeleted == true)
            {
                //btnSave.Enabled = false;
                //btnDelete.Enabled = false;
                chkPosted.Enabled = false;
                lblVoucherStatus.Visible = true;
                lblVoucherStatus.Text = "Deleted Voucher";
            }
            else if (list[0].Posted && list[0].IsDeleted == null)
            {
                chkPosted.Checked = true;
                //lblVoucherStatus.Visible = false;
                lblVoucherStatus.Text = "Posted Voucher";
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                chkPosted.Enabled = false;
            }
            else if (!list[0].Posted && list[0].IsDeleted == null)
            {
                chkPosted.Checked = false;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                lblVoucherStatus.Visible = true;
                chkPosted.Enabled = false;
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
                VoucherDetailEL oeTransaction = List.Find(x => x.Qty == 0);
                if (oeTransaction != null)
                {
                    SEditBox.Text = Validation.GetSafeString(oeTransaction.AccountNo);
                    txtCreditBalance.Text = oeTransaction.Credit.ToString();
                }


                for (int i = 0; i < List.Count; i++)
                {
                    DgvStockReceipt.Rows.Add();
                    DgvStockReceipt.Rows[i].Cells[0].Value = List[i].IdVoucherDetail;
                    DgvStockReceipt.Rows[i].Cells[1].Value = List[i].IdItem;
                    DgvStockReceipt.Rows[i].Cells[2].Value = List[i].IdLinkItem;
                    DgvStockReceipt.Rows[i].Cells[3].Value = List[i].IdSideItem;
                    DgvStockReceipt.Rows[i].Cells[4].Value = List[i].ItemNo;
                    DgvStockReceipt.Rows[i].Cells[5].Value = List[i].ItemName;
                    DgvStockReceipt.Rows[i].Cells[6].Value = List[i].LinkItemName;
                    DgvStockReceipt.Rows[i].Cells[7].Value = List[i].SideItemName;
                    DgvStockReceipt.Rows[i].Cells[8].Value = List[i].PackingSize;
                    DgvStockReceipt.Rows[i].Cells[9].Value = List[i].IsMarkeen;
                    DgvStockReceipt.Rows[i].Cells[10].Value = List[i].ActualWidth;
                    DgvStockReceipt.Rows[i].Cells[11].Value = List[i].OutWidth;
                    DgvStockReceipt.Rows[i].Cells[12].Value = List[i].Diff;
                    DgvStockReceipt.Rows[i].Cells[13].Value = List[i].Qty;
                    DgvStockReceipt.Rows[i].Cells[14].Value = List[i].MeterYardQty;
                    DgvStockReceipt.Rows[i].Cells[15].Value = List[i].UnitPrice;
                    DgvStockReceipt.Rows[i].Cells[16].Value = List[i].SideAmount;
                    DgvStockReceipt.Rows[i].Cells[17].Value = List[i].Amount;
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
                    txtCreditBalance.Text = List[0].TotalAmount.ToString("0.00");
                    // DgvStockReceipt.DataSource = List;
                    //
                }
            }
        }        
        #endregion
    }
}
