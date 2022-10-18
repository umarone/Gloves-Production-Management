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
    public partial class frmOrder : MetroForm
    {
        #region Variables
        frmFindAccounts frmAccount;
        frmStockAccounts frmstockAccounts;
        frmFindOrders frmfindOrders;
        frmFindVouchers frmfindVouchers;
        frmFindBrand frmfindbrand;
        TextBox txtDebit = new TextBox();
        TextBox txtCredit = new TextBox();
        public decimal OldValue { get; set; }
        public Int64 VoucherNo { get; set; }
        Guid IdOrder;
        Guid IdBrand;
        Int64 IdCurrency = 0;
        public Guid SupplierTransactionId { get; set; }
        public Guid PurchasesTransactionId { get; set; }
        public string VoucherType { get; set; }
        public string PurchaseType { get; set; }
        string EventCommandName;
        string StockEventCommandName;
        int EventTime = 0;
        string Command = "";
        string CustomerAccountNo = "";
        #endregion
        #region Form Methods And Events
        public frmOrder()
        {
            InitializeComponent();
        }
        private void frmOrder_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.grdOrders.AutoGenerateColumns = false;
            FillMaxOrderNumber();
            CheckModulePermissions();         
        }
        private void frmOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                FillMaxOrderNumber();
                ClearControl();
                if (grdOrders.Rows.Count > 0)
                {
                    grdOrders.Rows.Clear();
                }
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
                }
                else
                {
                    btnSave.Enabled = false;
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
        private void FillMaxOrderNumber()
        {
            var manager = new OrdersBLL();
            VEditBox.Text = manager.GetMaxOrderNumber(1, Operations.IdCompany).ToString();
        }
        private void ClearControl()
        {
            grdOrders.Rows.Clear();
            txtDescription.Text = string.Empty;
            VoucherNo = 0;
            IdOrder = Guid.Empty;
            IdBrand = Guid.Empty;
            IdCurrency = 0;
            txtBrandName.Text = string.Empty;
            txtCurrency.Text = string.Empty;
            VEditBox.Enabled = true;
            txtDescription.Text = string.Empty;
            
            SEditBox.Text = string.Empty;
            CustomerAccountNo = string.Empty;
            lblStatuMessage.Text = string.Empty;

            txtCustomerPo.Text = "";

        }
        private bool ValidateRows()
        {

            for (int i = 0; i < grdOrders.Rows.Count - 1; i++)
            {
                if (grdOrders.Rows[i].Cells["colIdItem"].Value == null)
                {
                    return false;
                }
                if (grdOrders.Rows[i].Cells["colQty"].Value == null)
                {
                    return false;
                }               
            }
            return true;
        }
        private bool ValidateControls()
        {
            if (CustomerAccountNo == string.Empty)
            {
                lblStatuMessage.Text = "Customer Missing...";
                return false;
            }
            if (IdCurrency == 0)
            {
                lblStatuMessage.Text = "Customer Currency Missing...";
                return false;
            }
            if (txtCustomerPo.Text == string.Empty)
            {
                lblStatuMessage.Text = "Customer PO Missing...";
                return false;
            }
            return true;
        }
        #endregion
        #region Button Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<OrdersDetailEL> oelOrderCollection = new List<OrdersDetailEL>();
            List<ItemsAttributesDetailsEL> oelBreakupCollection = new List<ItemsAttributesDetailsEL>();
            if (ValidateRows())
            {
                if (ValidateControls())
                {
                    #region Voucher Head Entries
                    OrdersEL oelOrder = new OrdersEL();
                    if (IdOrder == Guid.Empty)
                    {
                        oelOrder.IdOrder = Guid.NewGuid();
                    }
                    else
                    {
                        oelOrder.IdOrder = IdOrder;
                    }
                    oelOrder.IdBrand = IdBrand;
                    oelOrder.IdCurrency = IdCurrency;
                    oelOrder.IdUser = Operations.UserID;
                    oelOrder.IdCompany = Operations.IdCompany;
                    oelOrder.OrderNo = Convert.ToInt64(VEditBox.Text);
                    oelOrder.BookNo = Operations.BookNo;
                    oelOrder.AccountNo = Validation.GetSafeString(CustomerAccountNo);
                    oelOrder.CustomerPo = Validation.GetSafeString(txtCustomerPo.Text);
                    oelOrder.SubAccountNo = "0";
                    oelOrder.VDiscription = Validation.GetSafeString(txtDescription.Text);
                    oelOrder.OrderType = 1;
                    oelOrder.OrderStatus = 0;
                    oelOrder.TotalAmount = Validation.GetSafeDecimal(txtTotalAmount.Text);
                    oelOrder.OrderDate = dtOrder.Value;
                    oelOrder.ProductionDate = dtProduction.Value;
                    oelOrder.DeliveryDate = dtDelivery.Value;
                    oelOrder.Posted = chkPosted.Checked;
                    #endregion
                    #region Order Entries
                    for (int i = 0; i < grdOrders.Rows.Count - 1; i++)
                    {
                        OrdersDetailEL oelOrderDetail = new OrdersDetailEL();
                        ItemsEL oelItem = new ItemsEL();
                        oelOrderDetail.IdOrder = oelOrder.IdOrder;
                        oelOrderDetail.VoucherNo = Convert.ToInt64(VEditBox.Text);

                        if (grdOrders.Rows[i].Cells["colIdOrderDetail"].Value != null)
                        {
                            oelOrderDetail.IdOrderDetail = new Guid(grdOrders.Rows[i].Cells["colIdOrderDetail"].Value.ToString());
                            oelOrderDetail.IsNew = false;
                        }
                        else
                        {
                            oelOrderDetail.IdOrderDetail = Guid.NewGuid();
                            oelOrderDetail.IsNew = true;
                        }
                        oelOrderDetail.Seq = i + 1;
                        oelOrderDetail.IdAccount = Validation.GetSafeGuid(grdOrders.Rows[i].Cells["colIdItem"].Value);

                        oelOrderDetail.Configuration = Validation.GetSafeString(grdOrders.Rows[i].Cells["colConfiguration"].Value);
                        oelOrderDetail.IdColor = Validation.GetSafeGuid(grdOrders.Rows[i].Cells["colColor"].Value);
                        oelOrderDetail.IdSize = Validation.GetSafeGuid(grdOrders.Rows[i].Cells["colSize"].Value);
                        oelOrderDetail.PackingSize = Validation.GetSafeString(grdOrders.Rows[i].Cells["colpacking"].Value);
                        oelOrderDetail.Color = "";

                        oelOrderDetail.Quantity = Validation.GetSafeLong(grdOrders.Rows[i].Cells["colQty"].Value);
                        oelOrderDetail.UnitPrice = Validation.GetSafeDecimal(grdOrders.Rows[i].Cells["colunitprice"].Value);
                        oelOrderDetail.Amount = Validation.GetSafeLong(grdOrders.Rows[i].Cells["colAmount"].Value);
                        oelOrderDetail.DeliveredQuantity = Validation.GetSafeLong(grdOrders.Rows[i].Cells["colDeliveredUnits"].Value);
                        oelOrderDetail.DeliveredRemainderQuantity = Validation.GetSafeLong(grdOrders.Rows[i].Cells["colRemaining"].Value);


                        oelOrderCollection.Add(oelOrderDetail);
                    }
                    #endregion
                    #region Saving Entries
                    if (IdOrder == Guid.Empty)
                    {
                        var manager = new OrdersBLL();
                        var VManager = new VoucherBLL();
                        if (VManager.CheckVoucherNo(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text), "SalesOrder") == false)
                        {
                            if (manager.InsertOrders(oelOrder, oelOrderCollection, oelBreakupCollection))
                            {
                                MessageBox.Show("Sales Order Inserted Successfully...");
                                ClearControl();
                                FillMaxOrderNumber();
                            }
                        }
                        else
                        {
                            MessageBox.Show("This Order No Already Exists ; Plz Change Order No :");
                        }
                    }
                    else
                    {
                        var manager = new OrdersBLL();
                        var VManager = new VoucherBLL();
                        if (manager.UpdateOrder(oelOrder, oelOrderCollection, oelBreakupCollection))
                        {
                            MessageBox.Show("Recored Sales Order Updated Successfully...");
                            ClearControl();
                            FillMaxOrderNumber();
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
            if (IdOrder == Guid.Empty)
            {
                if (MessageBox.Show("Are You Sure To Delete Order", "Deleting Orders", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    var manager = new OrdersBLL();
                    if (manager.DeleteOrders(IdOrder))
                    {
                        MessageBox.Show("Order Deleted Successfully...");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Order First....");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnTrackOrders_Click(object sender, EventArgs e)
        {
            frmfindOrders = new frmFindOrders();
            frmfindOrders.OrderType = 1;
            frmfindOrders.AccountNo = CustomerAccountNo;
            frmfindOrders.AccountName = SEditBox.Text;
            frmfindOrders.ExecuteFindOrdersEvent += new frmFindOrders.FindOrdersDelegate(frmfindOrders_ExecuteFindOrdersEvent);
            frmfindOrders.ShowDialog();
        }
        private void btnReq_Click(object sender, EventArgs e)
        {
            if (IdOrder != Guid.Empty)
            {
                frmRequisition frmreq = new frmRequisition();
                frmreq.GlovesOrderNo = Validation.GetSafeLong(VEditBox.Text);
                frmreq.Show();
            }
            else
            {
                MessageBox.Show("No Order Found For Requisition");
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            FillMaxOrderNumber();
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
        private void btnCloseOrder_Click(object sender, EventArgs e)
        {
            if (IdOrder != Guid.Empty)
            {
                var manager = new OrdersBLL();
                if (MessageBox.Show("Do You Want To Complete OR Finish Order...", "Completing Order", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (manager.CompleteOrder(IdOrder))
                    {
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Order To Complete OR Finish");
            }
        }        
        #endregion
        #region Custom Events
        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {

            if (EventCommandName == "Persons")
            {
                //var manager = new PersonsBLL();
                // List<PersonsEL> list = manager.VerifyAccount(Operations.IdCompany, "Persons", oelAccount.AccountNo);
                //if (list.Count > 0)
                {
                    EventTime = 1;
                    GetPersonCurrency(oelAccount.AccountNo);
                    if (IdCurrency > 0)
                    {
                        SEditBox.Text = Validation.GetSafeString(oelAccount.AccountName);
                        CustomerAccountNo = Validation.GetSafeString(oelAccount.AccountNo);
                    }
                    else
                    {

                        SEditBox.Text = string.Empty;
                        CustomerAccountNo = string.Empty;
                        MessageBox.Show("Customer Currency Is Missing....");
                    }
                }
            }
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            grdOrders.RefreshEdit();
            if (StockEventCommandName == "")
            {
                var manager = new ItemsBLL();
                //if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.ItemNo).Count > 0)
                {
                    lblStatuMessage.Text = "";
                    grdOrders.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
                    grdOrders.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
                    grdOrders.CurrentRow.Cells["colpacking"].Value = oelItems.PackingSize;

                    LoadItemSizes(oelItems.IdItem);
                    LoadItemConfiguration(oelItems.IdItem);
                    DataGridViewComboBoxCell oCell = grdOrders.CurrentRow.Cells["colColor"] as DataGridViewComboBoxCell;
                    if (oCell != null)
                    {
                        oCell.DataSource =  GetItemsColorAttributes(oelItems.IdItem);
                        oCell.DisplayMember = "ItemColor";
                        oCell.ValueMember = "IdColor";
                    }
                }
                //else
                //{
                //lblStatuMessage.Text = "Wrong Account...";
                //}
            }
        }
        void frmfindVouchers_ExecuteFindVouchersEvent(VouchersEL oelVoucher)
        {
            VoucherNo = oelVoucher.VoucherNo;
            IdOrder = oelVoucher.IdVoucher;
            VEditBox.Text = oelVoucher.VoucherNo.ToString();
            FillVoucher();

        }
        void frmfindOrders_ExecuteFindOrdersEvent(object Sender, OrdersEL oelOrder)
        {
            VEditBox.Text = oelOrder.OrderNo.ToString();
            FillVoucher();
        }
        void frmfindbrand_ExecuteFindBrandEvent(object Sender, BrandEL oelBrand)
        {
            IdBrand = oelBrand.IdBrand;
            txtBrandName.Text = oelBrand.BrandName;
        }
        #endregion
        #region Other Control's Events
        private void SEditBox_ButtonClick(object sender, EventArgs e)
        {
            EventCommandName = "Persons";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
        }
        private void VEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindVouchers = new frmFindVouchers();
            frmfindVouchers.VoucherType = "";
            frmfindVouchers.ExecuteFindVouchersEvent += new frmFindVouchers.VouchersDelegate(frmfindVouchers_ExecuteFindVouchersEvent);
            frmfindVouchers.ShowDialog(this);
        }
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillVoucher();
            }
            else if (!char.IsLetter(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    FillVoucher();
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
                if (e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
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
                else if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = false;
                    txtCustomerPo.Focus();
                }
                else
                    e.Handled = false;
            }
        }
        private void txtBrandName_ButtonClick(object sender, EventArgs e)
        {
            frmfindbrand = new frmFindBrand();
            frmfindbrand.SearchBy = "Customers";
            frmfindbrand.AccountNo = CustomerAccountNo;
            frmfindbrand.ExecuteFindBrandEvent += new frmFindBrand.FindBrandDelegate(frmfindbrand_ExecuteFindBrandEvent);
            frmfindbrand.ShowDialog();
        }
        private void txtBrandName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                frmfindbrand = new frmFindBrand();
                frmfindbrand.SearchBy = "Customers";
                frmfindbrand.AccountNo = CustomerAccountNo;
                frmfindbrand.ExecuteFindBrandEvent += new frmFindBrand.FindBrandDelegate(frmfindbrand_ExecuteFindBrandEvent);
                frmfindbrand.ShowDialog();
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = false;
                txtDescription.Focus();
            }
        }
        private void txtCustomerPo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBrandName.Focus();
            }
        }
        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dtOrder.Focus();
            }
        }
        private void dtOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dtProduction.Focus();
            }
        }
        private void dtProduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dtDelivery.Focus();
            }
        }
        private void dtDelivery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                grdOrders.Focus();
            }
        }
        private void txtCustomerPo_Leave(object sender, EventArgs e)
        {
            var manager = new OrdersBLL();
            if (txtCustomerPo.Text != string.Empty)
            {
                if (manager.CheckPoNumber(txtCustomerPo.Text, 1))
                {
                    MessageBox.Show("This Customer Po Number Already Exists");
                    txtCustomerPo.Text = string.Empty;
                }
            }
        }
        #endregion
        #region Grid Events
        private void DgvStockReceipt_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void grdOrders_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (grdOrders.Columns[e.ColumnIndex].Name == "colUnitPrice")
            {
                grdOrders.Rows[e.RowIndex].Cells["colAmount"].Value = Convert.ToInt64(grdOrders.Rows[e.RowIndex].Cells["colQty"].Value) *
                                                                            Convert.ToDecimal(grdOrders.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                for (int i = 0; i < grdOrders.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(grdOrders.Rows[i].Cells["colAmount"].Value);
                }
                txtTotalAmount.Text = OldValue.ToString();
                OldValue = 0;
            }
        }
        private void grdOrders_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (grdOrders.Columns[e.ColumnIndex].Name == "colUnitPrice")
            {
                grdOrders.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(grdOrders.Rows[e.RowIndex].Cells["colUnitPrice"].Value) * Validation.GetSafeDecimal(grdOrders.Rows[e.RowIndex].Cells["colQty"].Value));
            }
            else if (grdOrders.Columns[e.ColumnIndex].Name == "colAmount")
            {
                grdOrders.Rows[e.RowIndex].Cells["colAmount"].Value = Convert.ToInt64(grdOrders.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDecimal(grdOrders.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                for (int i = 0; i < grdOrders.Rows.Count - 1; i++)
                {
                    OldValue += Convert.ToDecimal(grdOrders.Rows[i].Cells["colAmount"].Value);
                }
                txtTotalAmount.Text = OldValue.ToString();
                OldValue = 0;

            }

        }
        private void grdOrders_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 6)
            {
                SendKeys.Send("{F4}");
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
        private void grdOrders_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdOrders.CurrentCellAddress.X == 2)
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
            if (grdOrders.CurrentCellAddress.X == 2)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    StockEventCommandName = "";
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
        #region Transactional Methods
        private void GetPersonCurrency(string AccountNo)
        {
            var manager = new PersonsBLL();
            List<PersonsEL> list = manager.GetPersonCurrencyDetailByAccount(Operations.IdCompany, AccountNo);
            if (list.Count > 0)
            {
                IdCurrency = list[0].IdCurrency;
                txtCurrency.Text = list[0].CurrencyName;
            }
        }
        private void LoadItemSizes(Guid IdItem)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemsAttributes(IdItem);
            if (list.Count > 0)
            {
                list.Insert(0, new ItemsEL() { ItemSize = "", IdSize = Guid.Empty });
                DataGridViewComboBoxCell cellO = (DataGridViewComboBoxCell)grdOrders.CurrentRow.Cells["colSize"];
                
                cellO.DataSource = list;

                cellO.DisplayMember = "ItemSize";
                cellO.ValueMember = "IdSize";
            }
        }
        private void LoadItemConfiguration(Guid IdItem)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemById(IdItem);
            if (list.Count > 0)
            {
                grdOrders.CurrentRow.Cells["colconfiguration"].Value = list[0].ItemConfiguration;
            }
        }
        private void LoadIndexedItemSizes(Guid IdItem,int RowIndex)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemsAttributes(IdItem);
            if (list.Count > 0)
            {
                list.Insert(0, new ItemsEL() { ItemSize = "", IdSize = Guid.Empty });
                DataGridViewComboBoxCell cellO = (DataGridViewComboBoxCell)grdOrders.Rows[RowIndex].Cells["colSize"];

                cellO.DataSource = list;

                cellO.DisplayMember = "ItemSize";
                cellO.ValueMember = "IdSize";
            }
        }
        private List<ItemsEL> GetItemsColorAttributes(Guid Id) //, string ProcessName
        {
            var manager = new ItemsBLL();
            List<ItemsEL> oelItemsColorAttributesList = manager.GetItemsColorAttributes(Id);
            if (oelItemsColorAttributesList.Count > 0)
            {
                oelItemsColorAttributesList.Insert(0, new ItemsEL() { IdColor = Guid.Empty, ItemColor = "" });
            }
            return oelItemsColorAttributesList;
        }
        private void FillVoucher()
        {
            var Manager = new OrderDetailBLL();
            VoucherType = "SalesOrder";
            if (VEditBox.Text != string.Empty)
            {
                List<OrdersDetailEL> list = Manager.GetOrderDetailByOrderNo(Validation.GetSafeLong(VEditBox.Text),1,Operations.IdCompany);
                if (list.Count > 0)
                {
                    IdOrder = list[0].IdOrder;
                    IdBrand = list[0].IdBrand;
                    IdCurrency = list[0].IdCurrency;
                    txtBrandName.Text = list[0].BrandName;
                    GetPersonCurrency(list[0].AccountNo);
                    VEditBox.Enabled = false;
                    dtOrder.Value = list[0].OrderDate.Value;
                    dtOrder.Value = list[0].ProductionDate.Value;
                    dtOrder.Value = list[0].DeliveryDate.Value;
                    SEditBox.Text = list[0].AccountName;
                    txtDescription.Text = list[0].VDiscription;
                    CustomerAccountNo = list[0].AccountNo;
                    //cbxOrderType.SelectedIndex = list[0].OrderType;
                    txtCustomerPo.Text = list[0].CustomerPo;
                    txtTotalAmount.Text = list[0].TotalAmount.ToString();
                    if (list[0].OrderStatus == 1)
                    {
                        //if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                        {
                            btnSave.Enabled = false;
                            btnDelete.Enabled = false;
                        }                                               
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    HandleVoucher(list);
                    FillTransactions(list);

                }
                else
                {
                    MessageBox.Show("Order Number Not Found ...");
                    ClearControl();
                }
            }


        }
        private void HandleVoucher(List<OrdersDetailEL> list)
        {
            if (list[0].Posted && list[0].IsDeleted == true)
            {
                //if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    chkPosted.Enabled = false;
                }
                lblStatuMessage.Visible = true;
                lblStatuMessage.Text = "Deleted Voucher";
                chkPosted.Checked = list[0].Posted;
            }
            else if (!list[0].Posted && !list[0].IsDeleted == true)
            {
                {
                    btnSave.Enabled = true;
                    btnDelete.Enabled = true;
                    chkPosted.Enabled = true;
                }
                lblStatuMessage.Visible = false;
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
                lblStatuMessage.Visible = true;
                lblStatuMessage.Text = "Deleted Voucher";
            }
            else if (list[0].Posted && list[0].IsDeleted == null)
            {
                chkPosted.Checked = true;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                chkPosted.Enabled = true;
                lblStatuMessage.Text = "Posted Voucher";
            }
            else if (!list[0].Posted && list[0].IsDeleted == null)
            {
                chkPosted.Checked = false;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                chkPosted.Enabled = true;
                lblStatuMessage.Text = "UnPosted Voucher";
            }
            else
            {
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
        private void FillTransactions(List<OrdersDetailEL> List)
        {
            if (grdOrders.Rows.Count > 0)
            {
                grdOrders.Rows.Clear();
            }
            if (List != null && List.Count > 0)
            {                
                for (int i = 0; i < List.Count; i++)
                {
                    grdOrders.Rows.Add();
                    grdOrders.Rows[i].Cells[0].Value = List[i].IdOrderDetail;
                    grdOrders.Rows[i].Cells[1].Value = List[i].IdItem;
                    LoadIndexedItemSizes(List[i].IdItem,i);
                    grdOrders.Rows[i].Cells[2].Value = List[i].ItemName;
                    grdOrders.Rows[i].Cells[3].Value = List[i].PackingSize;
                    grdOrders.Rows[i].Cells[4].Value = List[i].Configuration;
                    DataGridViewComboBoxCell oColorCell = grdOrders.Rows[i].Cells["colColor"] as DataGridViewComboBoxCell;
                    if (oColorCell != null)
                    {
                        oColorCell.DataSource = GetItemsColorAttributes(List[i].IdItem);
                        oColorCell.DisplayMember = "ItemColor";
                        oColorCell.ValueMember = "IdColor";
                        if (List[i].IdColor != Guid.Empty)
                        {
                            grdOrders.Rows[i].Cells[5].Value = List[i].IdColor;
                        }
                        else
                        {
                            grdOrders.Rows[i].Cells[5].Value = null;
                        }
                    }
                    if (List[i].IdSize != Guid.Empty)
                    {
                        grdOrders.Rows[i].Cells[6].Value = List[i].IdSize;
                    }
                    else
                    {
                        grdOrders.Rows[i].Cells[6].Value = null;
                    }
                    grdOrders.Rows[i].Cells[7].Value = List[i].Quantity;
                    grdOrders.Rows[i].Cells[8].Value = List[i].UnitPrice;
                    grdOrders.Rows[i].Cells[9].Value = List[i].Amount;
                    grdOrders.Rows[i].Cells[10].Value = List[i].DeliveredQuantity;
                    grdOrders.Rows[i].Cells[11].Value = List[i].DeliveredRemainderQuantity;
                }
            }
        }
        #endregion
    }
}
