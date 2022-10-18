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
    public partial class frmDyingProcess : MetroForm
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
        public frmDyingProcess()
        {
            InitializeComponent();
        }
        private void frmDyingProcess_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.DgvStockReceipt.AutoGenerateColumns = false;
            FillData();
            FillNaturalAccounts(string.Empty);
            CheckModulePermissions();
            ShowHideControls();
        }
        private void frmDyingProcess_KeyPress(object sender, KeyPressEventArgs e)
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
        private void ShowHideControls()
        {
            if (IssuanceType == 1)
            {
                DgvStockReceipt.Columns["colColors"].Visible = false;
                DgvStockReceipt.Columns["colGradeAQuantity"].Visible = false;
                DgvStockReceipt.Columns["colGradeAAmount"].Visible = false;
                DgvStockReceipt.Columns["colGradeBQuantity"].Visible = false;
                DgvStockReceipt.Columns["colGradeBAmount"].Visible = false;
                DgvStockReceipt.Columns["colCPQuantity"].Visible = false;
                DgvStockReceipt.Columns["colUnitPrice"].Visible = true;
                DgvStockReceipt.Columns["colAmount"].Visible = true;
                ReSizeColumns(1);

                grpPurchases.Visible = false;
                this.Text = "Dying Outward Gate Pass";
            }
            else
            {
                DgvStockReceipt.Columns["colColors"].Visible = true;
                DgvStockReceipt.Columns["colGradeAQuantity"].Visible = true;
                DgvStockReceipt.Columns["colGradeAAmount"].Visible = true;
                DgvStockReceipt.Columns["colGradeBQuantity"].Visible = true;
                DgvStockReceipt.Columns["colGradeBAmount"].Visible = true;
                DgvStockReceipt.Columns["colCPQuantity"].Visible = true;
                DgvStockReceipt.Columns["colQty"].Visible = false;
                DgvStockReceipt.Columns["colUnitPrice"].Visible = false;
                DgvStockReceipt.Columns["colAmount"].Visible = true;

                ReSizeColumns(2);
                this.Text = "Dying Inward Gate Pass";
                grpPurchases.Visible = true;
            }
        }
        private void ReSizeColumns(int ResizeType)
        {
            if (ResizeType == 1)
            {
                DgvStockReceipt.Columns["colItemName"].Width = 500;
                DgvStockReceipt.Columns["colpacking"].Width = 200;
                DgvStockReceipt.Columns["colQty"].Width = 100;
            }
            else
            {
                DgvStockReceipt.Columns["colItemName"].Width = 250;
                DgvStockReceipt.Columns["colpacking"].Width = 100;
                DgvStockReceipt.Columns["colAmount"].Width = 100;
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
            var manager = new DyingHeadBLL();
            VEditBox.Text = manager.GetMaxDyingVoucherNumber(Operations.IdCompany, IssuanceType).ToString();
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

            if (IssuanceType == 1)
                grpPurchases.Visible = false;
            if (chkPosted.Checked)
            {
                chkPosted.Checked = false;
                chkPosted.Enabled = true;
            }
        }
        private List<ItemsEL> GetItemsColorAttributes(Guid Id)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> oelItemsColorAttributesList = manager.GetItemsColorAttributes(Id);
            if (oelItemsColorAttributesList.Count > 0)
            {
                oelItemsColorAttributesList.Insert(0, new ItemsEL() { IdColor = Guid.Empty, ItemColor = "" });
            }
            return oelItemsColorAttributesList;
        }
        private bool ValidateRows()
        {
            for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
            {
                if (IssuanceType == 1)
                {
                    if (DgvStockReceipt.Rows[i].Cells["colQty"].Value == null || Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colQty"].Value) == 0)
                    {
                        return false;
                    }
                }
                if (DgvStockReceipt.Rows[i].Cells["colIdItem"].Value == null || Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colIdItem"].Value) == string.Empty)
                {
                    MessageBox.Show("Please Give Item....");
                    return false;
                }
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
            List<VoucherDetailEL> oelDyingCollection = new List<VoucherDetailEL>();
            var manager = new DyingHeadBLL();
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
                    oelVoucher.VDiscription = Validation.GetSafeString(txtDescription.Text);
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(txtCreditBalance.Text);
                    oelVoucher.Posted = chkPosted.Checked;
                    oelVoucher.WorkType = IssuanceType;
                    #endregion
                    #region Stock Detail
                    for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                    {
                        VoucherDetailEL oelProcessDetail = new VoucherDetailEL();
                        oelProcessDetail.WorkType = IssuanceType;
                        if (DgvStockReceipt.Rows[i].Cells["colIdVoucherDetail"].Value != null)
                        {
                            oelProcessDetail.IdVoucherDetail = new Guid(DgvStockReceipt.Rows[i].Cells["colIdVoucherDetail"].Value.ToString());
                            oelProcessDetail.IsNew = false;
                        }
                        else
                        {
                            oelProcessDetail.IdVoucherDetail = Guid.NewGuid();
                            oelProcessDetail.IsNew = true;
                        }
                        oelProcessDetail.Seq = i + 1;
                        oelProcessDetail.IdVoucher = oelVoucher.IdVoucher;
                        oelProcessDetail.IdItem = Validation.GetSafeGuid(DgvStockReceipt.Rows[i].Cells["colIdItem"].Value);
                        oelProcessDetail.PackingSize = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colpacking"].Value);

                        oelProcessDetail.Discription = "N/A";
                        if (DgvStockReceipt.Columns["colColors"].Visible)
                        {
                            if (DgvStockReceipt.Rows[i].Cells["colColors"].Value != null || Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colColors"].Value) != string.Empty)
                            {
                                oelProcessDetail.IdColor = Validation.GetSafeGuid(DgvStockReceipt.Rows[i].Cells["colColors"].Value);
                            }
                            else
                            {
                                MessageBox.Show("Please Select Color");
                                return;
                            }
                        }
                        else
                            oelProcessDetail.IdColor = Guid.Empty;
                        oelProcessDetail.GradeAUnits = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colGradeAQuantity"].Value);
                        oelProcessDetail.GradeAAmount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colGradeAAmount"].Value);
                        oelProcessDetail.GradeBUnits = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colGradeBQuantity"].Value);
                        oelProcessDetail.GradeBAmount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colGradeBAmount"].Value);
                        oelProcessDetail.CPUnits = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colCPQuantity"].Value);
                        oelProcessDetail.Units = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                        oelProcessDetail.UnitPrice = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value);
                        oelProcessDetail.Amount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);

                        oelDyingCollection.Add(oelProcessDetail);
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
                        oelSupplierTransaction.TransactionType = "Dying...";
                        oelSupplierTransaction.IdCompany = Operations.IdCompany;
                        oelSupplierTransaction.AccountNo = SupplierAccountNo;
                        oelSupplierTransaction.BookNo = Operations.BookNo;
                        oelSupplierTransaction.LinkAccountNo = "";
                        oelSupplierTransaction.SubAccountNo = "0";
                        oelSupplierTransaction.VDate = VDate.Value;
                        oelSupplierTransaction.VoucherNo = Convert.ToInt32(VEditBox.Text);
                        oelSupplierTransaction.VoucherType = "DyingProcess";
                        oelSupplierTransaction.VDiscription = txtDescription.Text;
                        //oeTransaction.Amount = Convert.ToDecimal(txtTotalAmount.Text);

                        oelSupplierTransaction.Credit = Validation.GetSafeDecimal(txtCreditBalance.Text);
                        oelSupplierTransaction.Debit = 0;

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
                        oelPurchaseTransaction.TransactionType = "Dying";
                        oelPurchaseTransaction.IdCompany = Operations.IdCompany;
                        oelPurchaseTransaction.BookNo = Operations.BookNo;
                        //oelPurchaseTransaction.AccountNo = Validation.GetSafeLong(PurchasesEditBox.Text);
                        oelPurchaseTransaction.AccountNo = PurchasesAccountNo;
                        oelPurchaseTransaction.SubAccountNo = "0";
                        oelPurchaseTransaction.LinkAccountNo = "";
                        oelPurchaseTransaction.VDate = VDate.Value;
                        oelPurchaseTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                        oelPurchaseTransaction.VoucherType = "DyingProcess";
                        oelPurchaseTransaction.VDiscription = txtDescription.Text;


                        oelPurchaseTransaction.Debit = Validation.GetSafeDecimal(txtCreditBalance.Text);
                        oelPurchaseTransaction.Credit = 0;


                        oelPurchaseTransaction.Posted = chkPosted.Checked;
                        oelTransactionCollection.Add(oelPurchaseTransaction);
                    }
                    #endregion region
                    #region Save Code
                    if (IdVoucher == Guid.Empty)
                    {
                        EntityoperationInfo infoResult = manager.InsertDyingHead(oelVoucher, oelDyingCollection, oelTransactionCollection);
                        if (infoResult.IsSuccess)
                        {
                            //manager.UpdateStockitems(oelTransactionCollection, "Add");
                            lblStatuMessage.Text = "Transaction Successfully Recorded...";
                            ClearControl();
                            FillData();
                        }
                    }
                    else
                    {
                        EntityoperationInfo infoResult = manager.UpdateDyingHead(oelVoucher, oelDyingCollection, oelTransactionCollection);
                        if (infoResult.IsSuccess)
                        {
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
                var manager = new DyingHeadBLL(); //PurchaseStockReceiptBLL();
                if (IdVoucher != Guid.Empty)
                {
                    if (MessageBox.Show("Are You Sure To Delete ?", "Deleting Voucher", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {

                        if (manager.DeleteDyingHead(IdVoucher))
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
            var Manager = new ItemsBLL();
            List<ItemsEL> obj = null;
            if (e.ColumnIndex == 9)
            {
                DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colGradeAAmount"].Value) + Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colGradeBAmount"].Value);
                for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                }
                txtCreditBalance.Text = OldValue.ToString();
                OldValue = 0;
            }
            else if (e.ColumnIndex == 11)
            {
                if (IssuanceType == 1)
                {
                    if (DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value != null)
                    {
                        obj = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(DgvStockReceipt.Rows[e.RowIndex].Cells["colIdItem"].Value));
                        if ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) > obj[0].Qty)
                        {
                            MessageBox.Show("Your Quantity Is Exceeding Than Current Stock Which Is : " + obj[0].Qty.ToString());
                            return;
                        }
                        else
                            DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                    }
                }
            }
            //if (e.ColumnIndex == 12)
            //{
                
            //    if (IssuanceType == 1)
            //    {
                    
                    
            //        if (Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colpacking"].Value) == "Meter")
            //        {
            //            if (DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value != null)
            //            {
            //                if ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) > obj[0].Qty)
            //                {
            //                    MessageBox.Show("Your Quantity Is Exceeding Than Current Stock Which Is : " + obj[0].Qty.ToString());
            //                    //DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = "";
            //                    return;
            //                }
            //            }
            //        }
   
            //        for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
            //        {
            //            OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
            //        }
            //        txtCreditBalance.Text = OldValue.ToString();
            //        OldValue = 0;
            //    }               
            //}
        }
        private void DgvStockReceipt_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //List<ItemsEL> obj = null;
            //var Manager = new ItemsBLL();
            //obj = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(DgvStockReceipt.Rows[e.RowIndex].Cells["colIdItem"].Value));
            //if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colYardQty")
            //{
            //    if (IssuanceType == 2)
            //    {
            //        var manager = new ProcessHeadBLL();
            //        List<ItemsEL> list = manager.GetRubberingClosingStockToParty(Validation.GetSafeGuid(DgvStockReceipt.Rows[e.RowIndex].Cells["colIdLinkItem"].Value), SupplierAccountNo);
            //        if (list.Count > 0)
            //        {
            //            if (Validation.GetSafeLong(DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value) > list[0].Qty)
            //            {
            //                MessageBox.Show("You Have only " + list[0].Qty + " Yards Remaining from " + SEditBox.Text);
            //                DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value = "";
            //                DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = "";
            //                return;
            //            }
            //        }
            //    }
            //}
            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colUnitPrice")
            //{
            //    if (IssuanceType == 2)
            //    {
            //        DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value));
            //    }
            //}
            //else if (DgvStockReceipt.Columns[e.ColumnIndex].Name == "colAmount")
            //{
            //    if (IssuanceType == 2)
            //    {
            //        DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value) * Convert.ToDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
            //    }
            //    else
            //    {
            //        if (Validation.GetSafeString(DgvStockReceipt.Rows[e.RowIndex].Cells["colpacking"].Value) == "Yard")
            //        {
            //            if ((Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value)) > obj[0].Qty)
            //            {
            //                //MessageBox.Show("Your Quantity Is Exceeding Than Current Stock Which Is : " + obj[0].Qty.ToString());
            //                //DgvStockReceipt.Rows[e.RowIndex].Cells["colYardQty"].Value = "";
            //                return;
            //            }
            //        }                  
            //    }
            //    for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
            //    {
            //        OldValue += Convert.ToDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
            //    }
            //    txtCreditBalance.Text = OldValue.ToString();
            //    OldValue = 0;
            //}
           
        }
        private void DgvStockReceipt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (IssuanceType == 2)
                {
                    SendKeys.Send("{F4}");
                }
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
            if (DgvStockReceipt.CurrentCellAddress.X == 2)
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
            if (DgvStockReceipt.CurrentCellAddress.X == 2)
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
        private void cbxNaturalAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxNaturalAccounts.SelectedIndex > 0)
            {
                PurchasesAccountNo = Validation.GetSafeString(cbxNaturalAccounts.SelectedValue);
            }
        }
        #endregion
        #region Check Box Events
        //private void chkPlain_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkPlain.Checked)
        //    {
        //        grpPurchases.Visible = false;
        //    }
        //    else
        //    {
        //        grpPurchases.Visible = true;
        //    }
        //}
        //private void chkClaim_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkClaim.Checked)
        //    {
        //        grpPurchases.Visible = true;
        //        DgvStockReceipt.Columns["colUnitPrice"].Visible = true;
        //        DgvStockReceipt.Columns["colAmount"].Visible = true;
        //        ReSizeColumns(2);
        //    }
        //    else
        //    {
        //        DgvStockReceipt.Columns["colUnitPrice"].Visible = false;
        //        DgvStockReceipt.Columns["colAmount"].Visible = false;
        //        ReSizeColumns(1);
        //        grpPurchases.Visible = false;
        //    }
        //}
        #endregion
        #region Custom And Other Controls Events
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
            }
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            DgvStockReceipt.RefreshEdit();
            var manager = new ItemsBLL();
            decimal AverageValue = manager.GetItemsAvgValue(oelItems.IdItem);
            //if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.AccountNo).Count > 0)
            {

                lblStatuMessage.Text = "";
                DgvStockReceipt.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
                DgvStockReceipt.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
                if (IssuanceType == 1)
                {
                    DgvStockReceipt.CurrentRow.Cells["colUnitPrice"].Value = AverageValue.ToString("0.00");
                }
                if (IssuanceType == 2)
                {
                    DataGridViewComboBoxCell oCell = DgvStockReceipt.CurrentRow.Cells["colColors"] as DataGridViewComboBoxCell;
                    if (oCell != null)
                    { 
                        oCell.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                        oCell.DisplayMember = "ItemColor";
                        oCell.ValueMember = "IdColor";
                    }
                }
            }
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
            var PMananger = new DyingHeadBLL();
            VoucherType = "DyingProcess";
            if (VEditBox.Text != string.Empty)
            {
                List<VoucherDetailEL> list = PMananger.GetDyingByIssuanceTypeAndNumber(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text), IssuanceType);
                if (list.Count > 0)
                {
                    IdVoucher = list[0].IdVoucher;
                    VEditBox.Enabled = false;
                    VDate.Value = list[0].VDate.Value;
                    txtDescription.Text = list[0].VDiscription;
                    SupplierAccountNo = list[0].AccountNo;
                    SEditBox.Text = list[0].AccountName;

                    ShowHideControls();
                    FillTransactions(list);
                    HandleVoucher(list);

                    if (IssuanceType == 2)
                    {
                        List<TransactionsEL> listTransactions = Manager.GetTransactions(IdVoucher, "DyingProcess", Operations.IdCompany);

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
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                chkPosted.Enabled = false;
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
                //VoucherDetailEL oeTransaction = List.Find(x => x.Qty == 0);
                //if (oeTransaction != null)
                //{
                //    SEditBox.Text = Validation.GetSafeString(oeTransaction.AccountNo);
                //    txtCreditBalance.Text = oeTransaction.Credit.ToString();
                //}
                for (int i = 0; i < List.Count; i++)
                {
                    DgvStockReceipt.Rows.Add();
                    DgvStockReceipt.Rows[i].Cells[0].Value = List[i].IdVoucherDetail;
                    DgvStockReceipt.Rows[i].Cells[1].Value = List[i].IdItem;
                    DgvStockReceipt.Rows[i].Cells[2].Value = List[i].ItemName;
                    DgvStockReceipt.Rows[i].Cells[3].Value = List[i].PackingSize;
                    List<ItemsEL> listColors = GetItemsColorAttributes(List[i].IdItem);
                    DataGridViewComboBoxCell oCell = DgvStockReceipt.Rows[i].Cells[4] as DataGridViewComboBoxCell;
                    if (oCell != null)
                    {
                        if (listColors.Count > 0)
                        {
                            oCell.DataSource = listColors;
                            oCell.DisplayMember = "ItemColor";
                            oCell.ValueMember = "IdColor";

                            DgvStockReceipt.Rows[i].Cells[4].Value = List[i].IdColor;
                        }
                        else
                            oCell.DataSource = null;
                    }
                    DgvStockReceipt.Rows[i].Cells[5].Value = List[i].GradeAUnits;
                    DgvStockReceipt.Rows[i].Cells[6].Value = List[i].GradeAAmount;
                    DgvStockReceipt.Rows[i].Cells[7].Value = List[i].GradeBUnits;
                    DgvStockReceipt.Rows[i].Cells[8].Value = List[i].GradeBAmount;
                    DgvStockReceipt.Rows[i].Cells[9].Value = List[i].CPUnits;
                    DgvStockReceipt.Rows[i].Cells[10].Value = List[i].Units;
                    DgvStockReceipt.Rows[i].Cells[11].Value = List[i].UnitPrice;
                    DgvStockReceipt.Rows[i].Cells[12].Value = List[i].Amount;
                    txtCreditBalance.Text = List[0].Amount.ToString("0.00");
                }
            }
        }
        #endregion
    }
}
