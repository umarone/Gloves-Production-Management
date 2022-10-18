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
    public partial class frmInventoryIssuance : MetroForm
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
        public Guid SalesTransactionId { get; set; }
        TextBox txtDebit = new TextBox();
        TextBox txtCredit = new TextBox();
        public bool IsImport { get; set; }
        bool IsNewInvoice;
        decimal CostOfGoodsSoldAmount = 0;
        public string VoucherType { get; set; }
        string CommandType = "", StockSearchType;
        string LinkAccountNo, CustomerAccountNo, SalesAccountNo, MakerAccountNo;
        List<PurchaseDetailEL> ListToUpdateStock = null;
        List<PurchaseDetailEL> ListToCheck = null;
        decimal MRP = 0;
        #endregion
        #region Form Constructor And Load Method
        public frmInventoryIssuance()
        {
            InitializeComponent();
        }
        private void frmSales_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            FillData();
            CustEditBox.Focus();
            CheckModulePermissions();
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

        private void FillData()
        {
            var manager = new GeneralStockIssuanceHeadBLL();
            InvEditBox.Text = manager.GetMaxGeneralStockNumber(Operations.IdCompany);
        }

        private void CustEditBox_ButtonClick(object sender, EventArgs e)
        {
            CommandType = "Persons";
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
                    CustomerAccountNo = oelAccount.AccountNo;
                    CustEditBox.Text = oelAccount.AccountName;
                    txtContact.Text = list[0].Contact;
                    txtNTN.Text = list[0].NTN;
                    txtAddress.Text = list[0].Address;
                    lblStatuMessage.Text = "";
                }
                else
                {
                    CustomerAccountNo = oelAccount.AccountNo;
                    CustEditBox.Text = oelAccount.AccountName;
                }
            }
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            List<ItemsEL> ClosingQty = null;
            var manager = new ItemsBLL();
            DgvSaleInvoice.RefreshEdit();
            List<ItemsEL> listpriceAndSize = manager.GetItemPriceAndSizeByCode(Validation.GetSafeLong(oelItems.AccountNo), Operations.IdCompany);
            if (StockSearchType == "Items")
            {
                if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.ItemNo).Count > 0)
                {
                    lblStatuMessage.Text = "";
                    DgvSaleInvoice.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
                    DgvSaleInvoice.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
                    DgvSaleInvoice.CurrentRow.Cells["colPackingSize"].Value = oelItems.PackingSize;


                    DgvSaleInvoice.CurrentRow.Cells["colCurrentStock"].Value = manager.GetItemClosingStock(Operations.IdCompany, oelItems.IdItem)[0].Qty;
                    if (listpriceAndSize.Count > 0)
                    {
                        MRP = listpriceAndSize[0].MRP;
                    }
                }
            }
        }
        private void DgvSaleInvoice_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (DgvSaleInvoice.CurrentRow.Cells["colItemName"].Value != null)
                {
                    if (MRP != 0)
                    {
                        DgvSaleInvoice.CurrentRow.Cells["colUnitPrice"].Value = MRP;
                    }
                    else
                    {
                        //var manager = new ItemsBLL();
                        //List<ItemsEL> listpriceAndSize = manager.GetItemPriceAndSizeByCode(Validation.GetSafeLong(DgvSaleInvoice.CurrentRow.Cells["colItemNo"].Value), Operations.IdCompany);
                        //MRP = listpriceAndSize[0].MRP;
                    }
                }           
            }
           
            else if (e.ColumnIndex == 6)
            {
                DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value) *
                    Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
            }
            else if (e.ColumnIndex == 7)
            {
                for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colAmount"].Value);
                }
                txtTotalAmount.Text = OldValue.ToString();
                //if (IsImport)
                //{
                //    txtVat.Text = "0";
                //    txtVatAmount.Text = "0";                    
                //}
                //else
                //{
                //    txtVat.Text = ((Validation.GetSafeDecimal(txtTotalAmount.Text) * 5) / 100).ToString();
                //    txtVatAmount.Text = (Validation.GetSafeDecimal(txtTotalAmount.Text) + Validation.GetSafeDecimal(txtVat.Text)).ToString();
                //}
                OldValue = 0;
                //if (Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colIdBuild"].Value) == 0)
                //{
                //    txtDescription.AppendText(DgvSaleInvoice.Rows[e.RowIndex].Cells[4].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[3].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[5].Value.ToString() + " " + DgvSaleInvoice.Rows[e.RowIndex].Cells[7].Value.ToString() + " Units" + "@" + DgvSaleInvoice.Rows[e.RowIndex].Cells[9].Value.ToString() + Environment.NewLine);
                //    DgvSaleInvoice.Rows[e.RowIndex].Cells["colIdBuild"].Value = 1;
                //}
            }
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

                if (Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value) >
                    Validation.GetSafeLong(DgvSaleInvoice.Rows[e.RowIndex].Cells["colCurrentStock"].Value))
                {
                    MessageBox.Show("Quantity is Exceeding Than Current Stock");
                    DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value = "";
                    return;
                }                
            }
            else if (e.ColumnIndex == 6)
            {
                DgvSaleInvoice.Rows[e.RowIndex].Cells["colAmount"].Value = Validation.GetSafeInteger(DgvSaleInvoice.Rows[e.RowIndex].Cells["colQty"].Value) *
                    Validation.GetSafeDecimal(DgvSaleInvoice.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
            }
            else if (e.ColumnIndex == 7)
            {
                for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(DgvSaleInvoice.Rows[i].Cells["colAmount"].Value);
                }
                txtTotalAmount.Text = OldValue.ToString();
                OldValue = 0;
            }
        }
        private bool ValidateRows()
        {
            bool Status = true;
            if (DgvSaleInvoice.Rows.Count > 1)
            {
                for (int i = 0; i < DgvSaleInvoice.Rows.Count - 1; i++)
                {
                    if (DgvSaleInvoice.Rows[i].Cells["colIdItem"].Value == null)
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
            return Status;
        }
        private bool ValidateControls()
        {
            if (CustEditBox.Text == string.Empty)
            {
                lblStatuMessage.Text = "Customer Name Missing...";
                return false;
            }
            if (CustomerAccountNo == string.Empty)
            {
                lblStatuMessage.Text = "Customer Account Missing...";
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<VoucherDetailEL> oelIssuanceCollection = new List<VoucherDetailEL>();
            var manager = new GeneralStockIssuanceHeadBLL();
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
                    oelVoucher.IdUser = Operations.UserID;
                    oelVoucher.Date = VDate.Value;
                    oelVoucher.AccountNo = CustomerAccountNo;
                    oelVoucher.Discription = txtDescription.Text;
                    oelVoucher.DemandNo = Validation.GetSafeString(txtSaleMemoNo.Text);
                    oelVoucher.OutWardGatePassNo = Validation.GetSafeString(txtGatePass.Text);
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(txtTotalAmount.Text);
                    oelVoucher.Posted = chkPosted.Checked;
                    #endregion
                    #region Add Items In Sales Detail
                    for (int j = 0; j < DgvSaleInvoice.Rows.Count - 1; j++)
                    {
                        VoucherDetailEL oelIssuanceDetail = new VoucherDetailEL();

                        if (DgvSaleInvoice.Rows[j].Cells["colIssuanceId"].Value != null)
                        {
                            oelIssuanceDetail.IdVoucherDetail = Validation.GetSafeGuid(DgvSaleInvoice.Rows[j].Cells["colIssuanceId"].Value);
                            oelIssuanceDetail.IsNew = false;
                        }
                        else
                        {
                            oelIssuanceDetail.IdVoucherDetail = Guid.NewGuid();
                            oelIssuanceDetail.IsNew = true;
                        }
                        oelIssuanceDetail.Seq = j + 1;

                        oelIssuanceDetail.IdVoucher = oelVoucher.IdVoucher;
                        oelIssuanceDetail.IdItem = Validation.GetSafeGuid(DgvSaleInvoice.Rows[j].Cells["colIdItem"].Value);
                        oelIssuanceDetail.PackingSize = Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colPackingSize"].Value);

                        //oelSaleDetail.BatchNo = Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colBatchNo"].Value);
                        //oelSaleDetail.Expiry = Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colExpiry"].Value);             
                        oelIssuanceDetail.CurrentStock = Validation.GetSafeLong(DgvSaleInvoice.Rows[j].Cells["colCurrentStock"].Value);
                        oelIssuanceDetail.TotalCartons = 0;//Validation.GetSafeLong(DgvSaleInvoice.Rows[j].Cells["colCartons"].Value);
                        oelIssuanceDetail.Discription = "N/A"; //Validation.GetSafeString(DgvSaleInvoice.Rows[j].Cells["colNarration"].Value);                        
                        oelIssuanceDetail.VoucherNo = Validation.GetSafeLong(InvEditBox.Text);

                        oelIssuanceDetail.Units = Validation.GetSafeInteger(DgvSaleInvoice.Rows[j].Cells["colQty"].Value);
                        oelIssuanceDetail.UnitPrice = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[j].Cells["colUnitPrice"].Value);

                        oelIssuanceDetail.Amount = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[j].Cells["colAmount"].Value);
                        oelIssuanceDetail.Discount = 0;
                        oelIssuanceDetail.DiscountAmount = 0;
                        //oelSaleDetail.Amount = Validation.GetSafeDecimal(DgvSaleInvoice.Rows[j].Cells["colDiscountAmount"].Value);


                        oelIssuanceCollection.Add(oelIssuanceDetail);
                    }
                    #endregion
                    #region Saving Code
                    if (IdVoucher == Guid.Empty)
                    {
                        if (manager.CreateGeneralStockIssuance(oelVoucher, oelIssuanceCollection) == true)
                        {
                            lblStatuMessage.Text = "General Stock Issued Successfully...";
                            ClearControl();
                            FillData();
                        }
                    }
                    else
                    {

                        if (manager.UpdateGeneralStockIssuance(oelVoucher, oelIssuanceCollection) == true)
                        {
                            lblStatuMessage.Text = "General Stock Issued Successfully...";
                            ClearControl();
                            FillData();
                        }
                    }
                    #endregion
                }
                else
                {
                    lblStatuMessage.Text = "Customer Missing...";
                    lblStatuMessage.ForeColor = Color.Red;
                }
            }
            else
            {
                lblStatuMessage.Text = "InComplete Entry";
                lblStatuMessage.ForeColor = Color.Red;
            }
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
            IdVoucher = Guid.Empty;
            IdSampleVoucher = Guid.Empty;
            InvEditBox.Enabled = true;
            //txtDescription.Text = string.Empty;
            InvoiceNo = 0;
            SampleNo = 0;
            txtSaleMemoNo.Text = string.Empty;
            lblStatuMessage.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            //txtVat.Text = string.Empty;
            //txtVatAmount.Text = string.Empty;
            //txtDiscount.Text = string.Empty;
            //txtTotalDiscount.Text = string.Empty;
            //txtNetSale.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtNTN.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtGatePass.Text = string.Empty;
            CustEditBox.Text = string.Empty;

            //txtCashReceipt.Text = string.Empty;
            CustomerTransactionId = Guid.Empty;
            SalesTransactionId = Guid.Empty;
            CustomerAccountNo = string.Empty;
            SalesAccountNo = string.Empty;
            MakerAccountNo = string.Empty;


            IsNewInvoice = true;
            CustEditBox.Text = string.Empty;
            ListToUpdateStock = null;
            ListToCheck = null;
            CostOfGoodsSoldAmount = 0;
            if (chkPosted.Checked)
            {                
                chkPosted.Enabled = true;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
            CustEditBox.Focus();
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
            var Manager = new GeneralStockIssuanceHeadBLL();
            if (InvEditBox.Text != string.Empty)
            {
                List<VoucherDetailEL> list = Manager.GetGeneralIssuanceWithIssuanceNumber(Validation.GetSafeLong(InvEditBox.Text),Operations.IdCompany);
                if (list.Count > 0)
                {
                    IdVoucher = list[0].IdVoucher;
                    VDate.Value = list[0].Date;
                    InvEditBox.Enabled = false;
                    txtDescription.Text = list[0].Description;
                    txtSaleMemoNo.Text = list[0].DemandNo;
                    txtGatePass.Text = list[0].OutWardGatePassNo;
                    CustomerAccountNo = list[0].AccountNo;
                    CustEditBox.Text = list[0].AccountName;
                    if (list[0].Posted)
                    {
                        if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                        {
                            btnSave.Enabled = false;
                            btnDelete.Enabled = false;
                            chkPosted.Enabled = false;
                        }
                        chkPosted.Checked = list[0].Posted;
                        lblStatuMessage.Text = "Posted Voucher ...";
                        lblStatuMessage.ForeColor = Color.Red;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    FillIssuanceDetails(list);
                }
                else
                {
                    ClearControl();
                    MessageBox.Show("Issuance Number Not Found ...");
                }
            }


        }
        private void FillEmployee(string EmpCode, string MakerName)
        {
            var manager = new PersonsBLL();
            List<PersonsEL> list = manager.VerifyAccount(Operations.IdCompany, "Persons", EmpCode);
            if (list.Count > 0)
            {
                MakerAccountNo = EmpCode;
            }
            else
            {
                MakerAccountNo = EmpCode;
            }
        }
        private void FillIssuanceDetails(List<VoucherDetailEL> list)
        {
            var manager = new ItemsBLL();

            if (DgvSaleInvoice.Rows.Count > 0)
            {
                DgvSaleInvoice.Rows.Clear();
            }
            for (int i = 0; i < list.Count; i++)
            {
                DgvSaleInvoice.Rows.Add();
                DgvSaleInvoice.Rows[i].Cells[0].Value = list[i].IdVoucherDetail;
                DgvSaleInvoice.Rows[i].Cells[1].Value = list[i].IdItem;;
                DgvSaleInvoice.Rows[i].Cells[2].Value = list[i].ItemName; 
                DgvSaleInvoice.Rows[i].Cells[3].Value = list[i].PackingSize;
                DgvSaleInvoice.Rows[i].Cells[4].Value = list[i].CurrentStock;

                DgvSaleInvoice.Rows[i].Cells[5].Value = list[i].Units;
                DgvSaleInvoice.Rows[i].Cells[6].Value = list[i].UnitPrice;
                DgvSaleInvoice.Rows[i].Cells[7].Value = list[i].Amount;
            }
            txtTotalAmount.Text = list[0].TotalAmount.ToString();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReport = new frmReports();
            frmReport.VoucherNo = Convert.ToInt64(InvEditBox.Text);
            frmReport.ShowDialog();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var manager = new SalesHeadBLL(); //SalesVoucherBLL();
            if (MessageBox.Show("Are You Sure To Delete...", "Deleting Sale", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (manager.CheckSales(Operations.IdCompany, Validation.GetSafeLong(InvEditBox.Text)))
                {
                    //if (manager.DeleteSale(IdVoucher, Validation.GetSafeLong(InvEditBox.Text), "SaleInvoiceVoucher", Operations.IdCompany))
                    {
                        lblStatuMessage.Text = "Sales Deleted And Stock Roll Back";
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
            if (DgvSaleInvoice.CurrentCellAddress.X == 2)
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
            if (DgvSaleInvoice.CurrentCellAddress.X == 2)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    StockSearchType = "Items";
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
        private void CustEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetroFramework.Controls.MetroTextBox txt = sender as MetroFramework.Controls.MetroTextBox;
            if (txt != null)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (txt.Name == "CustEditBox")
                    {
                        DgvSaleInvoice.Focus();
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
    }
}
