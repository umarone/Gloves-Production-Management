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
    public partial class frmGarmentOrders : MetroForm
    {
        #region Variables
        frmFindAccounts frmAccount;
        frmStockAccounts frmstockAccounts;
        frmFindOrders frmfindOrders;
        public Int64 VoucherNo { get; set; }
        public string VoucherType { get; set; }
        Guid IdOrder;
        Guid IdBrand;
        string EventCommandName;
        int EventTime = 0;
        public decimal OldValue { get; set; }
        string StockCommand = "";
        string CustomerAccountNo = "";
        Int64 IdCurrency = 0;
        frmGarmentRequisition frmgarmentrequisition;
        frmFindBrand frmfindbrand;
        #endregion
        #region Form Events And Methods
        public frmGarmentOrders()
        {
            InitializeComponent();
        }
        private void frmGarmentOrders_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.grdOrders.AutoGenerateColumns = false;
            FillMaxOrderNumber();
            CheckModulePermissions();
        }
        private void frmGarmentOrders_KeyPress(object sender, KeyPressEventArgs e)
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
            VEditBox.Text = manager.GetMaxOrderNumber(2, Operations.IdCompany).ToString();
        }
        private void ClearControl()
        {
            grdOrders.Rows.Clear();
            grdOrderBreakup.Rows.Clear();
            txtDescription.Text = string.Empty;
            VoucherNo = 0;
            IdOrder = Guid.Empty;
            IdCurrency = 0;
            txtCurrency.Text = string.Empty;
            VEditBox.Enabled = true;
            txtDescription.Text = string.Empty;

            SEditBox.Text = string.Empty;
            lblStatuMessage.Text = string.Empty;

            txtCustomerPo.Text = "";

        }
        private bool ValidateRows()
        {

            for (int i = 0; i < grdOrders.Rows.Count - 1; i++)
            {
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
                MessageBox.Show("Customer Missing...");
                return false;
            }
            if (IdCurrency == 0)
            {
                MessageBox.Show("Please Allot Currency To Customer ");
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
                    oelOrder.IdUser = Operations.UserID;
                    oelOrder.IdCompany = Operations.IdCompany;
                    oelOrder.IdCurrency = IdCurrency;
                    oelOrder.OrderNo = Convert.ToInt64(VEditBox.Text);
                    oelOrder.BookNo = Operations.BookNo;
                    oelOrder.AccountNo = Validation.GetSafeString(CustomerAccountNo);
                    oelOrder.CustomerPo = Validation.GetSafeString(txtCustomerPo.Text);
                    oelOrder.SubAccountNo = "0";
                    oelOrder.VDiscription = Validation.GetSafeString(txtDescription.Text);
                    oelOrder.OrderType = 2;
                    oelOrder.OrderDate = dtOrder.Value;
                    oelOrder.ProductionDate = dtProduction.Value;
                    oelOrder.DeliveryDate = dtDelivery.Value;
                    oelOrder.TotalAmount = Validation.GetSafeDecimal(txtTotalAmount.Text);
                    oelOrder.Posted = chkPosted.Checked;
                    #endregion
                    #region Stock Entries
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
                        oelOrderDetail.Color = Validation.GetSafeString(grdOrders.Rows[i].Cells["colColors"].Value);
                        oelOrderDetail.IdColor = Validation.GetSafeGuid(grdOrders.Rows[i].Cells["colColors"].Value);
                        oelOrderDetail.IdSize = Guid.Empty;
                        oelOrderDetail.PackingSize = Validation.GetSafeString(grdOrders.Rows[i].Cells["colpacking"].Value);

                        oelOrderDetail.Quantity = Validation.GetSafeLong(grdOrders.Rows[i].Cells["colQty"].Value);
                        oelOrderDetail.UnitPrice = Validation.GetSafeDecimal(grdOrders.Rows[i].Cells["colUnitPrice"].Value);
                        oelOrderDetail.Amount = Validation.GetSafeDecimal(grdOrders.Rows[i].Cells["colAmount"].Value);
                        oelOrderDetail.DeliveredQuantity = Validation.GetSafeLong(grdOrders.Rows[i].Cells["colDeliveredUnits"].Value);
                        oelOrderDetail.DeliveredRemainderQuantity = Validation.GetSafeLong(grdOrders.Rows[i].Cells["colRemaining"].Value);


                        oelOrderCollection.Add(oelOrderDetail);
                    }
                    #endregion
                    #region Order BreeakUP Entries
                    for (int i = 0; i < grdOrderBreakup.Rows.Count - 1; i++)
                    {
                        ItemsAttributesDetailsEL oelBreakupDetail = new ItemsAttributesDetailsEL();
                        ItemsEL oelItem = new ItemsEL();
                        oelBreakupDetail.IdOrder = oelOrder.IdOrder;
                        oelBreakupDetail.VoucherNo = Convert.ToInt64(VEditBox.Text);

                        if (grdOrderBreakup.Rows[i].Cells["colBreakupIdDetail"].Value != null)
                        {
                            oelBreakupDetail.IdOrderDetail = new Guid(grdOrderBreakup.Rows[i].Cells["colBreakupIdDetail"].Value.ToString());
                            oelBreakupDetail.IsNew = false;
                        }
                        else
                        {
                            oelBreakupDetail.IdOrderDetail = Guid.NewGuid();
                            oelBreakupDetail.IsNew = true;
                        }
                        oelBreakupDetail.Seq = i + 1;
                        oelBreakupDetail.IdItem = Validation.GetSafeGuid(grdOrderBreakup.Rows[i].Cells["colBreakupIdItem"].Value);

                        oelBreakupDetail.Small = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakupSmall"].Value);
                        oelBreakupDetail.Medium = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakupMedium"].Value);
                        oelBreakupDetail.Large = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakupLarge"].Value);
                        oelBreakupDetail.XLarge = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakupXL"].Value);
                        oelBreakupDetail.DoubleXLarge = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakup2XLarge"].Value);
                        oelBreakupDetail.TripleXLarge = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakup3XL"].Value);
                        oelBreakupDetail.FourthXLarge = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakup4XL"].Value);
                        oelBreakupDetail.FifthXLarge = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakup5XL"].Value);
                        oelBreakupDetail.TotalBreakup = Validation.GetSafeLong(grdOrderBreakup.Rows[i].Cells["colBreakupTotal"].Value);

                        oelBreakupCollection.Add(oelBreakupDetail);
                    }
                    #endregion
                    #region Saving Entries
                    if (IdOrder == Guid.Empty)
                    {
                        var manager = new OrdersBLL();
                        if (manager.InsertOrders(oelOrder, oelOrderCollection, oelBreakupCollection))
                        {
                            lblStatuMessage.Text = "Garments Sales Order Inserted Successfully...";
                            ClearControl();
                            FillMaxOrderNumber();
                        }
                        else
                        {
                            MessageBox.Show("Some Problem Occured while Saving Order :");
                        }
                    }
                    else
                    {
                        var manager = new OrdersBLL();
                        if (manager.UpdateOrder(oelOrder, oelOrderCollection, oelBreakupCollection))
                        {
                            lblStatuMessage.Text = "Garments Sales Order Updated Successfully...";
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
            frmfindOrders.OrderType = 2;
            frmfindOrders.AccountNo = CustomerAccountNo;
            frmfindOrders.AccountName = SEditBox.Text;
            frmfindOrders.ExecuteFindOrdersEvent += new frmFindOrders.FindOrdersDelegate(frmfindOrders_ExecuteFindOrdersEvent);
            frmfindOrders.ShowDialog();
        }
        private void btnRequisition_Click(object sender, EventArgs e)
        {
            frmgarmentrequisition = new frmGarmentRequisition();
            frmgarmentrequisition.GarmentOrderNo = Validation.GetSafeLong(VEditBox.Text);
            frmgarmentrequisition.ShowDialog();
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
        #region Custom Controls Events And Methods
        private void SEditBox_ButtonClick(object sender, EventArgs e)
        {
            EventCommandName = "Persons";
            frmAccount = new frmFindAccounts();
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog();
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
        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            if (EventCommandName == "Persons")
            {           
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
            grdOrderBreakup.RefreshEdit();
            //var manager = new ItemsBLL();
            //if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.AccountNo).Count > 0)
            {
                lblStatuMessage.Text = "";
                if (StockCommand == "Order")
                {
                    grdOrders.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
                    grdOrders.CurrentRow.Cells["colItemNo"].Value = oelItems.ItemNo;
                    grdOrders.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
                    grdOrders.CurrentRow.Cells["colpacking"].Value = oelItems.PackingSize;
                    LoadItemConfiguration(oelItems.IdItem);
                }
                else
                {
                    grdOrderBreakup.CurrentRow.Cells["colBreakupIdItem"].Value = oelItems.IdItem;
                    grdOrderBreakup.CurrentRow.Cells["colBreakupItemName"].Value = oelItems.ItemName;
                    //grdOrderBreakup.CurrentRow.Cells["colpacking"].Value = oelItems.PackingSize;
                }

                GetItemsColorAttributes(oelItems.IdItem);
            }
            //else
            //{
                //lblStatuMessage.Text = "Wrong Account...";
            //}
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
        private void SEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetroFramework.Controls.MetroTextBox txt = sender as MetroFramework.Controls.MetroTextBox;
            if (txt != null)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
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
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillVoucher();
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
        #endregion
        #region Transactional Methods
        private void LoadItemConfiguration(Guid IdItem)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemById(IdItem);
            if (list.Count > 0)
            {
                grdOrders.CurrentRow.Cells["colConfiguration"].Value = list[0].ItemConfiguration;
            }
        }
        private void GetItemsColorAttributes(Guid Id)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> oelItemsColorAttributes = manager.GetItemsColorAttributes(Id);
            if (oelItemsColorAttributes.Count > 0)
            {
                colColors.DataSource = oelItemsColorAttributes;

                colColors.DisplayMember = "ItemColor";
                colColors.ValueMember = "IdColor";
            }
        }
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
        private void FillVoucher()
        {
            var Manager = new OrderDetailBLL();
            VoucherType = "SalesOrder";
            if (VEditBox.Text != string.Empty)
            {
                List<ItemsAttributesDetailsEL> list = Manager.GetGarmentOrderDetailByOrderNo(Validation.GetSafeLong(VEditBox.Text), Operations.IdCompany);
                List<ItemsAttributesDetailsEL> lstBreakup = Manager.GetGarmentBreakupByOrderNo(Validation.GetSafeLong(VEditBox.Text), Operations.IdCompany);
                if (list.Count > 0)
                {
                    IdOrder = list[0].IdOrder;
                    IdBrand = list[0].IdBrand;
                    IdCurrency = list[0].IdCurrency;
                    txtBrandName.Text = list[0].BrandName;
                    VEditBox.Enabled = false;
                    dtOrder.Value = list[0].OrderDate.Value;
                    dtOrder.Value = list[0].ProductionDate.Value;
                    dtOrder.Value = list[0].DeliveryDate.Value;
                    txtTotalAmount.Text = list[0].TotalAmount.ToString();
                    SEditBox.Text = list[0].AccountName;
                    txtDescription.Text = list[0].VDiscription;
                    CustomerAccountNo = list[0].AccountNo;
                    txtCustomerPo.Text = list[0].CustomerPo;
                    GetPersonCurrency(list[0].AccountNo);
                    HandleVoucher(list);
                    if (list[0].Posted)
                    {
                        if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
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

                    FillTransactions(list);
                    if (lstBreakup.Count > 0)
                    {
                        FillBreakupTransactions(lstBreakup);
                    }

                }
                else
                {
                    MessageBox.Show("Order Number Not Found ...");
                    ClearControl();
                }
            }


        }
        private void HandleVoucher(List<ItemsAttributesDetailsEL> list)
        {
            if (list[0].Posted && list[0].IsDeleted == true)
            {
                //if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    chkPosted.Enabled = false;
                }
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
                lblStatuMessage.Text = "Deleted Voucher";
            }
            else if (list[0].Posted && list[0].IsDeleted == null)
            {
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
        private void FillTransactions(List<ItemsAttributesDetailsEL> List)
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
                    GetItemsColorAttributes(List[i].IdItem);
                    grdOrders.Rows[i].Cells[3].Value = List[i].ItemName;
                    grdOrders.Rows[i].Cells[4].Value = List[i].Configuration;
                    if (List[i].IdColor != Guid.Empty)
                    {
                        grdOrders.Rows[i].Cells[5].Value = List[i].IdColor;
                    }
                    else
                    {
                        grdOrders.Rows[i].Cells[5].Value = null;
                    }
                    grdOrders.Rows[i].Cells[6].Value = List[i].PackingSize;
                    grdOrders.Rows[i].Cells[7].Value = List[i].Quantity;
                    grdOrders.Rows[i].Cells[8].Value = List[i].UnitPrice;
                    grdOrders.Rows[i].Cells[9].Value = List[i].Amount;
                    grdOrders.Rows[i].Cells[10].Value = List[i].DeliveredQuantity;
                    grdOrders.Rows[i].Cells[11].Value = List[i].DeliveredRemainderQuantity;
                }
            }
        }
        private void FillBreakupTransactions(List<ItemsAttributesDetailsEL> List)
        {
            if (grdOrderBreakup.Rows.Count > 0)
            {
                grdOrderBreakup.Rows.Clear();
            }
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].TotalBreakup != 0)
                {
                    grdOrderBreakup.Rows.Add();
                    grdOrderBreakup.Rows[i].Cells[0].Value = List[i].IdOrderDetail;
                    grdOrderBreakup.Rows[i].Cells[1].Value = List[i].IdItem;
                    grdOrderBreakup.Rows[i].Cells[3].Value = List[i].ItemName;
                    grdOrderBreakup.Rows[i].Cells[4].Value = List[i].Small;
                    grdOrderBreakup.Rows[i].Cells[5].Value = List[i].Medium;
                    grdOrderBreakup.Rows[i].Cells[6].Value = List[i].Large;
                    grdOrderBreakup.Rows[i].Cells[7].Value = List[i].XLarge;
                    grdOrderBreakup.Rows[i].Cells[8].Value = List[i].DoubleXLarge;
                    grdOrderBreakup.Rows[i].Cells[9].Value = List[i].TripleXLarge;
                    grdOrderBreakup.Rows[i].Cells[10].Value = List[i].FourthXLarge;
                    grdOrderBreakup.Rows[i].Cells[11].Value = List[i].FifthXLarge;
                    grdOrderBreakup.Rows[i].Cells[12].Value = List[i].TotalBreakup;
                }
            }
        }
        #endregion
        #region Grid Events
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
        }
        private void grdOrderBreakup_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                grdOrderBreakup.Rows[e.RowIndex].Cells["colBreakupTotal"].Value = Validation.GetSafeLong(grdOrderBreakup.Rows[e.RowIndex].Cells["colBreakupSmall"].Value) + Validation.GetSafeLong(grdOrderBreakup.Rows[e.RowIndex].Cells["colBreakupMedium"].Value) +
                                                                                    Validation.GetSafeLong(grdOrderBreakup.Rows[e.RowIndex].Cells["colBreakupLarge"].Value) + Validation.GetSafeLong(grdOrderBreakup.Rows[e.RowIndex].Cells["colBreakupXL"].Value) +
                                                                                    Validation.GetSafeLong(grdOrderBreakup.Rows[e.RowIndex].Cells["colBreakup2XLarge"].Value) + Validation.GetSafeLong(grdOrderBreakup.Rows[e.RowIndex].Cells["colBreakup3XL"].Value) +
                                                                                    Validation.GetSafeLong(grdOrderBreakup.Rows[e.RowIndex].Cells["colBreakup4XL"].Value) + Validation.GetSafeLong(grdOrderBreakup.Rows[e.RowIndex].Cells["colBreakup5XL"].Value);
            }
        }
        private void grdOrderBreakup_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdOrderBreakup.CurrentCellAddress.X == 3)
            {
                TextBox txtBreakupItemName = e.Control as TextBox;
                if (txtBreakupItemName != null)
                {
                    txtBreakupItemName.KeyPress -= new KeyPressEventHandler(txtBreakupItemName_KeyPress);
                    txtBreakupItemName.KeyPress += new KeyPressEventHandler(txtBreakupItemName_KeyPress);
                }
            }
        }
        void txtBreakupItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdOrderBreakup.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    StockCommand = "Breakup";
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
        private void grdOrders_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdOrders.CurrentCellAddress.X == 3)
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
            if (grdOrders.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    StockCommand = "Order";
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
    }
}
