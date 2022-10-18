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
    public partial class frmPurchaseOrder : MetroForm
    {
        #region Variables
        frmStockAccounts frmstockAccounts;
        frmFindVouchers frmfindVouchers;
        frmFindAccounts frmfindAccounts;
        frmPurchaseOrderPrint frmPrint;
        string AccountNo = "";
        public decimal OldValue { get; set; }
        public Int64 VoucherNo { get; set; }
        Guid IdVoucher;
        public string VoucherType { get; set; }
        public string PurchaseType { get; set; }
        public bool IsImport { get; set; }
        frmCustomerPOS frmcustomerpo;
        Guid IdOrder = Guid.Empty;
        #endregion
        #region Form Methods And Variables
        public frmPurchaseOrder()
        {
            InitializeComponent();
        }
        private void frmStockReceipt_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.DgvStockReceipt.AutoGenerateColumns = false;
            FillData();
            CheckModulePermissions();
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
            VEditBox.Text = manager.GetMaxVoucherNumber("PurchaseOrder", Operations.IdCompany);
        }
        private void LoadItemSizes(Guid IdItem)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemsAttributes(IdItem);
            if (list.Count > 0)
            {
                list.Insert(0, new ItemsEL() { ItemSize = "", IdSize = Guid.Empty });
                DataGridViewComboBoxCell cellO = (DataGridViewComboBoxCell)DgvStockReceipt.CurrentRow.Cells["colSizes"];

                cellO.DataSource = list;

                cellO.DisplayMember = "ItemSize";
                cellO.ValueMember = "IdSize";
            }
        }
        private void LoadIndexedItemSizes(Guid IdItem, int RowIndex)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemsAttributes(IdItem);
            if (list.Count > 0)
            {
                list.Insert(0, new ItemsEL() { ItemSize = "", IdSize = Guid.Empty });
                DataGridViewComboBoxCell cellO = (DataGridViewComboBoxCell)DgvStockReceipt.Rows[RowIndex].Cells["colSizes"];

                cellO.DataSource = list;

                cellO.DisplayMember = "ItemSize";
                cellO.ValueMember = "IdSize";
            }
        }
        private void ClearControl()
        {
            DgvStockReceipt.Rows.Clear();
            VoucherNo = 0;
            IdVoucher = Guid.Empty;
            VEditBox.Enabled = true;
            txtDescription.Text = string.Empty;
            cbxPurchaseType.SelectedIndex = 0;
            txtPoNumber.Text = string.Empty;
            txtCustomerBrand.Text = string.Empty;
            lblStatuMessage.Text = string.Empty;
            txtParty.Text = string.Empty;
            txtPaymentTerm.Text = string.Empty;
            txtDeliveryTerms.Text = string.Empty;
            AccountNo = string.Empty;
            if (chkPosted.Checked)
            {
                chkPosted.Checked = false;
                chkPosted.Enabled = true;
            }
        }
        private bool ValidateRows()
        {

            for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
            {
                if (DgvStockReceipt.Rows[i].Cells["colQty"].Value == null)
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidateControls()
        {
            if (AccountNo == string.Empty)
            {
                lblStatuMessage.Text = "Please Select Party :";
                return false;
            }
            return true;
        }
        #endregion
        #region Button Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<StockReceiptEL> oelStockReceiptCollection = new List<StockReceiptEL>();
            List<VoucherDetailEL> oelPurchaseDetailCollection = new List<VoucherDetailEL>();
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
                    oelVoucher.IdOrder = IdOrder;
                    oelVoucher.IdRequisition = Guid.Empty;
                    oelVoucher.IdUser = Operations.UserID;
                    oelVoucher.BookNo = Operations.BookNo;
                    oelVoucher.IdCompany = Operations.IdCompany;
                    oelVoucher.VoucherNo = Convert.ToInt64(VEditBox.Text);
                    oelVoucher.AccountNo = AccountNo;
                    oelVoucher.PaymentTerms = Validation.GetSafeString(txtPaymentTerm.Text);
                    oelVoucher.DeliveryTerms = Validation.GetSafeString(txtDeliveryTerms.Text);
                    oelVoucher.VDiscription = Validation.GetSafeString(txtDescription.Text);
                    oelVoucher.VDate = VDate.Value;
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(txttotalAmount.Text);

                    oelVoucher.PurchaseType = cbxPurchaseType.SelectedIndex;

                    //oelVoucher.VAT = Validation.GetSafeInteger(txtVat.Text);
                    //oelVoucher.VATAmount = Validation.GetSafeDecimal(txtVATAmount.Text);
                    oelVoucher.IsImport = IsImport;
                    oelVoucher.Posted = chkPosted.Checked;
                    #endregion
                    #region Purchase Order Detail Enteries
                    for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                    {
                        VoucherDetailEL oelPurchaseDetial = new VoucherDetailEL();
                        if (DgvStockReceipt.Rows[i].Cells["colDetailId"].Value != null)
                        {
                            //oelPurchaseDetial.TransactionID = new Guid(DgvStockReceipt.Rows[i].Cells["ColTransaction"].Value.ToString());
                            oelPurchaseDetial.IdVoucherDetail = new Guid(DgvStockReceipt.Rows[i].Cells["colDetailId"].Value.ToString());
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
                        oelPurchaseDetial.IdSize = Validation.GetSafeGuid(DgvStockReceipt.Rows[i].Cells["colSizes"].Value);
                        oelPurchaseDetial.PackingSize = Validation.GetSafeString(DgvStockReceipt.Rows[i].Cells["colpacking"].Value);
                        oelPurchaseDetial.Discription = "N/A";
                        oelPurchaseDetial.Units = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colQty"].Value);
                        oelPurchaseDetial.RemainingUnits = 0;
                        oelPurchaseDetial.UnitPrice = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colUnitPrice"].Value);
                        oelPurchaseDetial.Discount = 0;
                        oelPurchaseDetial.Amount = Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value); ;

                        oelPurchaseDetailCollection.Add(oelPurchaseDetial);
                    }
                    #endregion
                    #region Save Code
                    if (IdVoucher == Guid.Empty)
                    {
                        var manager = new PurchaseHeadBLL();
                        EntityoperationInfo infoResult = manager.InsertPurchaseOrder(oelVoucher, oelPurchaseDetailCollection);
                        if (infoResult.IsSuccess)
                        {
                            lblStatuMessage.Text = "Purchase Order Inserted Successfully...";
                            FillVoucher("Voucher");
                        }
                    }
                    else
                    {
                        var manager = new PurchaseHeadBLL();
                        EntityoperationInfo infoResult = manager.UpdatePurchaseOrder(oelVoucher, oelPurchaseDetailCollection);
                        if (infoResult.IsSuccess)
                        {
                            lblStatuMessage.Text = "Purchase Order Updated Successfully...";
                            //ClearControl();
                            FillVoucher("Voucher");
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
                var manager = new PurchaseHeadBLL();
                if (IdVoucher != Guid.Empty)
                {
                    if (MessageBox.Show("Are You Sure To Delete ?", "Deleting Voucher", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (manager.DeletePurchaseOrder(IdVoucher))
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
            frmPrint = new frmPurchaseOrderPrint();
            frmPrint.IdVoucher = IdVoucher;
            frmPrint.PrintType = "PurchaseOrder";
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
        private void txtParty_ButtonClick(object sender, EventArgs e)
        {
            frmfindAccounts = new frmFindAccounts();
            frmfindAccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccounts_ExecuteFindAccountEvent);
            frmfindAccounts.ShowDialog();
        }
        #endregion
        #region Custom Controls Events
        private void VEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindVouchers = new frmFindVouchers();
            frmfindVouchers.VoucherType = "PurchaseOrder";
            frmfindVouchers.ExecuteFindVouchersEvent += new frmFindVouchers.VouchersDelegate(frmfindVouchers_ExecuteFindVouchersEvent);
            frmfindVouchers.ShowDialog(this);
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
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            var manager = new ItemsBLL();

            lblStatuMessage.Text = "";
            DgvStockReceipt.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
            DgvStockReceipt.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
            DgvStockReceipt.CurrentRow.Cells["colpacking"].Value = oelItems.PackingSize;
            LoadItemSizes(oelItems.IdItem);
        }
        void frmcustomerpo_ExecuteFindAccountEvent(object Sender, OrdersEL oelOrder)
        {
            IdOrder = oelOrder.IdOrder;
            txtPoNumber.Text = oelOrder.CustomerPo;
            txtCustomerBrand.Text = oelOrder.BrandName;
        }
        void frmfindAccounts_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            txtParty.Text = oelAccount.AccountName;
            AccountNo = oelAccount.AccountNo;
        }
        void frmfindVouchers_ExecuteFindVouchersEvent(VouchersEL oelVoucher)
        {
            VoucherNo = oelVoucher.VoucherNo;
            IdVoucher = oelVoucher.IdVoucher;
            VEditBox.Text = oelVoucher.VoucherNo.ToString();
            FillVoucher("Voucher");

        }
        #endregion
        #region Grid Events
        private void DgvStockReceipt_KeyDown(object sender, KeyEventArgs e)
        {
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
            if (e.ColumnIndex == 6)
            {
                if (DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value != null && DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value != null)
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colQty"].Value) * Validation.GetSafeDecimal(DgvStockReceipt.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                }
                else
                {
                    DgvStockReceipt.Rows[e.RowIndex].Cells["colAmount"].Value = 0;
                }
            }
        }
        private void DgvStockReceipt_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                for (int i = 0; i < DgvStockReceipt.Rows.Count - 1; i++)
                {
                    OldValue += Validation.GetSafeDecimal(DgvStockReceipt.Rows[i].Cells["colAmount"].Value);
                }
                txttotalAmount.Text = OldValue.ToString();
                OldValue = 0;
            }
        }
        private void DgvStockReceipt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                SendKeys.Send("{F4}");
            }
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
        #endregion
        #region Transactional Methods
        private void FillVoucher(string LoadType)
        {
            #region Variables
            var Manager = new PurchaseHeadBLL();
            var PManager = new PurchaseDetailBLL();
            List<VoucherDetailEL> list = null;
            VoucherType = "PurchaseOrder";
            #endregion
            #region VoucherHeadInformation
            if (VEditBox.Text != string.Empty)
            {

                if (LoadType == "Voucher")
                {
                    list = Manager.GetPurchaseOrderByVoucher(Validation.GetSafeLong(VEditBox.Text), Operations.IdCompany);
                }
                if (list.Count > 0)
                {
                    IdVoucher = list[0].IdVoucher;
                    VEditBox.Enabled = false;
                    VDate.Value = list[0].VDate.Value;
                    txtDescription.Text = list[0].VDiscription;
                    cbxPurchaseType.SelectedIndex = list[0].PurchaseType;
                    cbxPurchaseType.SelectedIndex = cbxPurchaseType.FindString(list[0].TransactionType);
                    HandleVoucher(list);
                    FillPo(list);
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

            }
            #endregion
        }
        //private void HandleVoucher(List<VoucherDetailEL> list)
        //{
        //    if (list[0].Posted && list[0].IsDeleted == null)
        //    {
        //        //if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
        //        {
        //            btnSave.Enabled = true;
        //            btnDelete.Enabled = true;
        //            chkPosted.Enabled = true;
        //            btnPrint.Enabled = true;
        //        }
        //        lblVoucherStatus.Visible = true;
        //        lblVoucherStatus.Text = "Deleted Voucher";
        //        chkPosted.Checked = list[0].Posted;
        //    }
        //    else if (!list[0].Posted && !list[0].IsDeleted == true)
        //    {
        //        {
        //            btnSave.Enabled = false;
        //            btnDelete.Enabled = false;
        //            chkPosted.Enabled = false;
        //        }
        //        lblVoucherStatus.Visible = true;
        //        lblVoucherStatus.Text = "Deleted Voucher";

        //    }
        //    else if (list[0].Posted && !list[0].IsDeleted == true)
        //    {
        //        btnSave.Enabled = false;
        //        btnDelete.Enabled = false;
        //        chkPosted.Enabled = false;
        //        btnPrint.Enabled = true;

        //        lblVoucherStatus.Visible = true;
        //        lblVoucherStatus.Text = "Deleted Voucher";
        //    }
        //    else if (!list[0].Posted && list[0].IsDeleted == null)
        //    {
        //        btnSave.Enabled = false;
        //        btnDelete.Enabled = false;
        //        chkPosted.Enabled = false;
        //        btnPrint.Enabled = false;
        //        lblVoucherStatus.Visible = true;
        //        lblVoucherStatus.Text = "UnPosted Voucher";
        //    }
        //    else if (list[0].Posted && list[0].IsDeleted == null)
        //    {
        //        chkPosted.Checked = true;
        //        btnSave.Enabled = true;
        //        btnDelete.Enabled = true;
        //        chkPosted.Enabled = true;

        //        lblVoucherStatus.Visible = true;
        //        lblVoucherStatus.Text = "Posted Voucher";
        //    }
        //    else
        //    {
        //        btnSave.Enabled = true;
        //        btnDelete.Enabled = true;
        //    }
        //}
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
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                chkPosted.Enabled = true;
                chkPosted.Checked = true;
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
        private void FillPo(List<VoucherDetailEL> List)
        {
            if (DgvStockReceipt.Rows.Count > 0)
            {
                DgvStockReceipt.Rows.Clear();
            }
            if (List != null && List.Count > 0)
            {
                IdOrder = List[0].IdOrder;
                txtPoNumber.Text = List[0].PoNumber;
                txtCustomerBrand.Text = List[0].BrandName;
                AccountNo = List[0].AccountNo;
                txtParty.Text = List[0].AccountName;
                txttotalAmount.Text = List[0].Amount.ToString();
                txtDeliveryTerms.Text = List[0].DeliveryTerms;
                txtPaymentTerm.Text = List[0].PaymentTerms;
                for (int i = 0; i < List.Count; i++)
                {
                    DgvStockReceipt.Rows.Add();
                    DgvStockReceipt.Rows[i].Cells[0].Value = List[i].IdVoucherDetail;
                    DgvStockReceipt.Rows[i].Cells[1].Value = List[i].IdItem;
                    DgvStockReceipt.Rows[i].Cells[2].Value = List[i].ItemName;
                    DgvStockReceipt.Rows[i].Cells[3].Value = List[i].PackingSize;
                    LoadIndexedItemSizes(List[i].IdItem, i);
                    if (List[i].IdSize != Guid.Empty)
                    {
                        DgvStockReceipt.Rows[i].Cells[4].Value = List[i].IdSize;
                    }
                    DgvStockReceipt.Rows[i].Cells[5].Value = List[i].Qty;
                    DgvStockReceipt.Rows[i].Cells[6].Value = List[i].UnitPrice;
                    DgvStockReceipt.Rows[i].Cells[7].Value = List[i].TotalAmount;
                }
            }
        }
        #endregion
        #region TextBoxes Events
        void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvStockReceipt.CurrentCellAddress.X == 2)
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
        private void txtPoNumber_ButtonClick(object sender, EventArgs e)
        {
            frmcustomerpo = new frmCustomerPOS();
            frmcustomerpo.ExecuteFindAccountEvent += new frmCustomerPOS.FindCustomerPoDelegate(frmcustomerpo_ExecuteFindAccountEvent);
            frmcustomerpo.ShowDialog();
        }
        #endregion

    }
}
