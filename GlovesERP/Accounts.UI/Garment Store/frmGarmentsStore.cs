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
    public partial class frmGarmentsStore : MetroForm
    {
        #region Variables
        frmFindAccounts frmAccount;
        frmStockAccounts frmstockAccounts;
        frmFindBrand frmfindBrand;
        frmPrintMaterialsIssuance frmissuance;
        frmfindProductionBatches frmfindBatches;
        frmFindOrders frmfindOrders;
        string EventCommandName;
        string EventStockName;
        int EventTime = 0;
        public Int64 VoucherNo { get; set; }
        public Int32 GPType { get; set; }
        public bool IsNewBatch { get; set; }
        public bool IsOut { get; set; }
        public string ProductionType { get; set; }
        public int OperationType { get; set; }
        Guid IdVoucher;
        Guid IdArticle = Guid.Empty;
        Guid IdBatch = Guid.Empty;
        string PersonAccountNo = "";
        frmAuthentication frmAuthenticate;
        Int64 ProductionBatchNo = 0;
        string BatchCompletionStatus = string.Empty;
        List<ItemsEL> listItemCalculation = null;
        Guid IdOrder = Guid.Empty;
        #endregion
        #region Forms Methods
        public frmGarmentsStore()
        {
            InitializeComponent();
        }
        private void frmStockIssuance_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.grdProducts.AutoGenerateColumns = false;
            FillData();
            //FormLabel();
            LoadGatePassTypes();
            //ShowHideColumnsOnLoad();
            if (GPType == 1)
            {

            }
            if (GPType == 1)
            {
                //ShowHideColumns();
            }

        }
        private void frmStockIssuance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                ClearControl();
                FillData();
            }
        }
        #endregion
        #region Common Methods
        private void ShowHideColumnsOnLoad()
        {
            if (IsOut && GPType == 1)
            {
                grdProducts.Columns[11].Visible = true;
            }
            else
            {
                grdProducts.Columns[11].Visible = false;
            }
            if (IsOut && GPType == 2)
            {
                lblArticle.Visible = true;
                txtArticle.Visible = true;
                grdProducts.Columns[6].Visible = false;
                grdProducts.Columns[7].Visible = true;
                grdProducts.Columns[8].Visible = false;
            }
            else if (!IsOut && GPType == 2)
            {
                lblArticle.Visible = false;
                txtArticle.Visible = false;
                grdProducts.Columns[6].Visible = true;
                grdProducts.Columns[7].Visible = false;
                grdProducts.Columns[8].Visible = true;
            }
        }
        private void FillData()
        {
            var manager = new ProductionIssuanceHeadBLL();
            int value = 0;
            if (IsOut)
                value = 1;
            else
                value = 2;
            VEditBox.Text = manager.GetMaxVoucherNumber(Operations.IdCompany, value, OperationType, GPType).ToString();
        }
        private void FormLabel()
        {
            if (GPType == 1 && IsOut)
            {
                this.Text = "Gloves " + ProductionType + " Outward GatePass";
                lblVoucherNo.Text = "OutPass No";
            }
            else if (GPType == 1 && !IsOut)
            {
                this.Text = "Gloves " + ProductionType + " InWard GatePass";
                lblVoucherNo.Text = "InPass No";
            }
            else if (GPType == 2 && IsOut)
            {
                this.Text = "Garments " + ProductionType + " Outward Pass";
            }
            else if (GPType == 2 && !IsOut)
            {
                this.Text = "Garments " + ProductionType + " Inward Pass";
            }
        }
        private void LoadGatePassTypes()
        {
            if (GPType == 1 && IsOut)
            {
                cbxGatePassType.Items.Add("");
                cbxGatePassType.Items.Add("Gloves Maker");
                cbxGatePassType.Items.Add("Rubber Cuff");
                cbxGatePassType.Items.Add("Material Issuance");
                cbxGatePassType.Items.Add("Container OutPass");
                cbxGatePassType.Items.Add("Gloves Repair");
                cbxGatePassType.Items.Add("Repairing and Maintainance");
                cbxGatePassType.Items.Add("General Sales");
            }
            else if (GPType == 1 && !IsOut)
            {
                cbxGatePassType.Items.Add("");
                cbxGatePassType.Items.Add("Gloves Maker");
                cbxGatePassType.Items.Add("Production Materials");
                cbxGatePassType.Items.Add("Material Return");
                cbxGatePassType.Items.Add("Gloves Repair");
            }
            else if (GPType == 2 && IsOut)
            {
                cbxGatePassType.Items.Add("");
                cbxGatePassType.Items.Add("Garments Maker");
            }
            else if (GPType == 2 && !IsOut)
            {
                cbxGatePassType.Items.Add("");
                cbxGatePassType.Items.Add("Garments Maker");
            }
        }
        private void LoadItemSizes(Guid IdItem)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemsAttributes(IdItem);
            if (list.Count > 0)
            {
                list.Insert(0, new ItemsEL() { ItemSize = "", IdSize = Guid.Empty });
                DataGridViewComboBoxCell cellO = (DataGridViewComboBoxCell)grdProducts.CurrentRow.Cells["colSizes"];

                cellO.DataSource = list;

                cellO.DisplayMember = "ItemSize";
                cellO.ValueMember = "IdSize";

                if (GPType == 1)
                {
                    if (list[1].ItemSize != "")
                        cellO.Value = list[1].IdSize;
                }
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
        private void ShowHideColumns()
        {
            if (IsOut && GPType == 1)
            {
                lblArticle.Visible = false;
                txtArticle.Visible = false;
                if (ProductionType == "Cuff Cutting")
                {
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[8].Visible = false;
                }
                else if (ProductionType == "Talli Cutting")
                {
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[8].Visible = false;
                }
                else if (ProductionType == "Cuff Printing")
                {
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[8].Visible = true;
                }
                else if (ProductionType == "Cuff OverLock")
                {
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[8].Visible = true;
                }
                else if (ProductionType == "Cuff Magzi")
                {
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[8].Visible = true;
                }
                else if (ProductionType == "Cuff Tape")
                {
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[8].Visible = true;
                }
                else if (ProductionType == "Stitching" && cbxGatePassType.Text == "Gloves Repair")
                {
                    grdProducts.Columns[6].Visible = true;
                    grdProducts.Columns[7].Visible = false;
                    grdProducts.Columns[8].Visible = false;
                    lblArticle.Visible = false;
                    txtArticle.Visible = false;
                }
                else if (ProductionType == "Stitching")
                {
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[7].Visible = true;
                    grdProducts.Columns[8].Visible = true;
                    lblArticle.Visible = true;
                    txtArticle.Visible = true;
                }
            }
            else if (!IsOut && GPType == 1)
            {
                if (ProductionType == "Cuff Cutting")
                {
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[7].Visible = true;
                    grdProducts.Columns[8].Visible = false;
                }
                else if (ProductionType == "Talli Cutting")
                {
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[7].Visible = true;
                    grdProducts.Columns[8].Visible = false;
                }
                else if (ProductionType == "Cuff Printing")
                {
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[8].Visible = true;
                }
                else if (ProductionType == "Cuff OverLock")
                {
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[8].Visible = true;
                }
                else if (ProductionType == "Cuff Magzi")
                {
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[8].Visible = true;
                }
                else if (ProductionType == "Cuff Tape")
                {
                    grdProducts.Columns[6].Visible = false;
                    grdProducts.Columns[8].Visible = true;
                }
                else if (ProductionType == "Stitching")
                {
                    grdProducts.Columns[6].Visible = true;
                    grdProducts.Columns[7].Visible = false;
                    grdProducts.Columns[8].Visible = true;
                }
                //else if (cbxProductionType.Text == "Checking / Inspection")
                //{
                //    grdProducts.Columns[5].Visible = true;
                //    grdProducts.Columns[7].Visible = true;
                //}
                //else if (cbxProductionType.Text == "Packing")
                //{
                //    grdProducts.Columns[5].Visible = true;
                //    grdProducts.Columns[7].Visible = true;
                //}
            }
        }
        private bool CheckMandatoryItemQuantity()
        {
            var Manager = new ItemsBLL();
            bool? IsMandatoryExists = false, Status = true;
            List<ItemsEL> list = null;
            decimal MandatoryQty = 0;
            Guid IdItem = Guid.Empty;
            for (int i = 0; i < grdProducts.Rows.Count - 1; i++)
            {
                list = Manager.GetItemById(Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colIdItem"].Value));
                if (list.Count > 0)
                {
                    IsMandatoryExists = Validation.GetSafeBooleanNullable(list[0].IsMandatory);
                    if (IsMandatoryExists.HasValue)
                    {
                        IdItem = Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colIdItem"].Value);
                        MandatoryQty = Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colQty"].Value);
                        break;
                    }
                }
            }
            if (IsMandatoryExists.HasValue)
            {
                for (int j = 0; j < grdProducts.Rows.Count - 1; j++)
                {
                    if (IdItem != Validation.GetSafeGuid(grdProducts.Rows[j].Cells["colIdItem"].Value))
                    {
                        if (Validation.GetSafeDecimal(grdProducts.Rows[j].Cells["colQty"].Value) > MandatoryQty)
                        {
                            Status = false;
                            break;
                        }
                    }
                }
            }
            return Status.Value;
        }
        //private void FillDepartments()
        //{
        //    var manager = new ProcessesBLL();
        //    List<ProcessesEL> list = manager.GetAllProcesses();
        //    list.Insert(0, new ProcessesEL() { ProcessName = "", IdProcess = Guid.Empty });

        //    cbxProductionType.DataSource = list;
        //    cbxProductionType.DisplayMember = "ProcessName";
        //    cbxProductionType.ValueMember = "IdProcess";
        //}       
        private bool ValidateRows()
        {

            for (int i = 0; i < grdProducts.Rows.Count - 1; i++)
            {
                if (grdProducts.Rows[i].Cells["colQty"].Value == null || Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colQty"].Value) == 0 || Validation.GetSafeString(grdProducts.Rows[i].Cells["colQty"].Value) == string.Empty)
                {
                    return false;
                }
                //if (ProductionType != "Stitching")
                //{
                //    if (Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colRate"].Value) == 0 && Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colAmount"].Value) == 0)
                //    {
                //        MessageBox.Show("Please Enter Rate For Costing...");
                //        return false;
                //    }
                //}
            }
            return true;
        }
        private bool ValidateControls()
        {
            if (PersonAccountNo == string.Empty)
            {
                MessageBox.Show("Department Person Is Missing....");
                return false;
            }
            else if (cbxGatePassType.Text == "")
            {
                MessageBox.Show("Please Select Gate Pass Type :");
                return false;
            }
            if (ProductionType == "Stitching")
            {
                if (GPType == 1)
                {
                    if (IdArticle == Guid.Empty)
                    {
                        MessageBox.Show("Please Select Article...");
                    }
                }
            }
            if (IdOrder == Guid.Empty)
            {
                MessageBox.Show("Please Select Order...");
                return false;
            }
            //if (GPType == 1)
            //{
            //    if (IsOut && ProductionType != "Stitching")
            //    {
            //        if (!IsNewBatch)
            //        {
            //            if (ProductionBatchNo == 0)
            //            {
            //                MessageBox.Show("Please Select Production Batch No");
            //                return false;
            //            }
            //            else if (BatchCompletionStatus == "Complete")
            //            {
            //                MessageBox.Show("Sorry You Can Not Work Because Batch Is Completed");
            //            }
            //        }
            //    }
            //    else if (!IsOut && ProductionType != "Stitching")
            //    {
            //        if (ProductionBatchNo == 0)
            //        {
            //            MessageBox.Show("Please Select Production Batch No");
            //            return false;
            //        }
            //        else if (BatchCompletionStatus == "Complete")
            //        {
            //            MessageBox.Show("Sorry You Can Not Work Because Batch Is Completed");
            //        }
            //    }
            //}

            return true;
        }
        //private void btnSaveCuttingTalli_Click(object sender, EventArgs e)
        //{
        //    List<VoucherDetailEL> oelProductionIssuanceDetailCollection = new List<VoucherDetailEL>();
        //    /// Add Voucher...
        //    #region Voucher Head Entries
        //    VouchersEL oelVoucher = new VouchersEL();
        //    if (IdVoucher == Guid.Empty)
        //    {
        //        oelVoucher.IdVoucher = Guid.NewGuid();
        //    }
        //    else
        //    {
        //        oelVoucher.IdVoucher = IdVoucher;
        //    }
        //    oelVoucher.IdUser = Operations.UserID;
        //    oelVoucher.IdCompany = Operations.IdCompany;
        //    oelVoucher.IdDepartment = Validation.GetSafeGuid(cbxProductionType.SelectedValue);
        //    oelVoucher.VoucherNo = Convert.ToInt64(VEditBox.Text);
        //    oelVoucher.AccountNo = Validation.GetSafeString(SEditBox.Text);
        //    oelVoucher.WorkType = false;
        //    oelVoucher.Description = "N/A";
        //    oelVoucher.CreatedDateTime = VDate.Value;
        //    #endregion
        //    ///Add Stock Detail 
        //    #region Stock Entries
        //    for (int i = 0; i < grdCuffing.Rows.Count - 1; i++)
        //    {
        //        VoucherDetailEL oelProductionIssuance = new VoucherDetailEL();
        //        ItemsEL oelItem = new ItemsEL();
        //        if (grdCuffing.Rows[i].Cells["colCuffingId"].Value != null)
        //        {
        //            //oelPurchaseDetial.TransactionID = new Guid(DgvStockReceipt.Rows[i].Cells["ColTransaction"].Value.ToString());
        //            oelProductionIssuance.IdVoucherDetail = new Guid(grdCuffing.Rows[i].Cells["colCuffingId"].Value.ToString());
        //            oelProductionIssuance.IsNew = false;
        //        }
        //        else
        //        {
        //            oelProductionIssuance.IdVoucherDetail = Guid.NewGuid();
        //            //  oelPurchaseDetial.TransactionID = Guid.NewGuid();
        //            oelProductionIssuance.IsNew = true;
        //        }
        //        oelProductionIssuance.Seq = i + 1;
        //        oelProductionIssuance.IdVoucher = oelVoucher.IdVoucher;
        //        oelProductionIssuance.VoucherNo = Convert.ToInt64(VEditBox.Text);
        //        oelProductionIssuance.IdItem = Validation.GetSafeGuid(grdCuffing.Rows[i].Cells["colcuffingIdItem"].Value);
        //        oelProductionIssuance.PackingSize = Validation.GetSafeString(grdCuffing.Rows[i].Cells["colCuffingPacking"].Value);

        //        oelProductionIssuance.Qty = Validation.GetSafeInteger(grdCuffing.Rows[i].Cells["colCuffingQty"].Value);
        //        oelProductionIssuance.MeterYardQty = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colcuffingMeterYard"].Value);
        //        oelProductionIssuance.BariSize = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colCuffingBariSize"].Value);
        //        oelProductionIssuance.TotalBari = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colcuffingTotalBari"].Value);
        //        oelProductionIssuance.TalliBariWidth = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colcuffingWidth"].Value);
        //        oelProductionIssuance.TalliBariSize = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colcuffTaliBariSize"].Value);
        //        oelProductionIssuance.CalculatedQty = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colCuffingCalculatedQty"].Value);
        //        oelProductionIssuance.TotalCuffs = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colTotalCuffBari"].Value);
        //        oelProductionIssuance.Dozen = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colCuffingDozen"].Value);
        //        oelProductionIssuance.EstimatedQty = Validation.GetSafeDecimal(grdCuffing.Rows[i].Cells["colcuffingEstimated"].Value);
        //        oelProductionIssuanceDetailCollection.Add(oelProductionIssuance);
        //    }
        //    #endregion
        //    #region Insert Values
        //    if (IdVoucher == Guid.Empty)
        //    {
        //        var manager = new ProductionIssuanceHeadBLL();
        //        var VManager = new VoucherBLL();

        //        EntityoperationInfo infoResult = manager.InsertProductionIssuance(oelVoucher, oelProductionIssuanceDetailCollection, false);
        //        if (infoResult.IsSuccess)
        //        {
        //            MessageBox.Show("Inventory Issued Successfully...");
        //            ClearControl();
        //            FillData();
        //        }                
        //        else
        //        {
        //            MessageBox.Show("Problem Occured While Issuance Production Stock :");
        //        }
        //    }
        //    else
        //    {
        //        var manager = new ProductionIssuanceHeadBLL();
        //        var VManager = new VoucherBLL();
        //        var ItemManager = new ItemsBLL();
        //        EntityoperationInfo infoResult = manager.UpdateProductionIssuance(oelVoucher, oelProductionIssuanceDetailCollection, false);
        //        if (infoResult.IsSuccess)
        //        {
        //            MessageBox.Show("Inventory Issuance Updated Successfully...");
        //            ClearControl();
        //            FillData();
        //        }
        //    }
        //    #endregion
        //}
        private void ClearControl()
        {
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            lblVoucherStatus.Visible = false;
            grdProducts.Rows.Clear();
            VoucherNo = 0;
            IdVoucher = Guid.Empty;
            cbxGatePassType.SelectedIndex = 0;
            SEditBox.Text = string.Empty;
            PersonAccountNo = string.Empty;
            txtArticle.Text = string.Empty;
            IdArticle = Guid.Empty;
            grdProducts.Rows.Clear();

            if (IsNewBatch)
            {
                grdProducts.Enabled = true;
                VEditBox.Enabled = false;
            }
            else
            {
                grdProducts.Enabled = false;
                VEditBox.Enabled = true;
            }
            ProductionBatchNo = 0;
            txtOrderNo.Text = string.Empty;
            txtOrderType.Text = string.Empty;
            txtOrderStatus.Text = string.Empty;
            txtOrderedCustomer.Text = string.Empty;
        }
        private void GetOrderById()
        {
            var manager = new OrderDetailBLL();
            List<OrdersDetailEL> listOrders = manager.GetOrderDetailById(IdOrder);
            if (listOrders.Count > 0)
            {
                txtOrderNo.Text = listOrders[0].OrderNo.ToString();
                txtOrderedCustomer.Text = listOrders[0].AccountName;
                if (listOrders[0].OrderType == 1)
                {
                    txtOrderType.Text = "Gloves Order";
                }
                else
                {
                    txtOrderType.Text = "Garments Order";
                }
                if (listOrders[0].OrderStatus == 0)
                {
                    txtOrderStatus.Text = "Opened";
                }
                else
                {
                    txtOrderStatus.Text = "Closed";
                }
            }
        }
        #endregion
        #region Button Events
        private void txtArticle_ButtonClick(object sender, EventArgs e)
        {
            frmstockAccounts = new frmStockAccounts();
            EventStockName = "";
            frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
            frmstockAccounts.ShowDialog();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<VoucherDetailEL> oelProductionIssuanceDetailCollection = new List<VoucherDetailEL>();
            List<ProductionBatchesEL> listBatch = new List<ProductionBatchesEL>();
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
                oelVoucher.IdArticle = IdArticle;
                oelVoucher.IdOrder = IdOrder;
                oelVoucher.IdCompany = Operations.IdCompany;
                oelVoucher.IdDepartment = Guid.Empty; //Validation.GetSafeGuid(cbxProductionType.SelectedValue);
                oelVoucher.VoucherNo = Convert.ToInt64(VEditBox.Text);
                oelVoucher.BookNo = Operations.BookNo;
                oelVoucher.ProductionBatchNo = ProductionBatchNo;
                oelVoucher.AccountNo = PersonAccountNo;
                oelVoucher.GatePassType = Validation.GetSafeString(cbxGatePassType.Text);
                oelVoucher.ProcessType = IsOut ? 1 : 2;
                oelVoucher.GPType = GPType;
                oelVoucher.OperationType = OperationType;
                oelVoucher.SettlementType = ProductionType;
                oelVoucher.VDiscription = "N/A";
                oelVoucher.VDate = VDate.Value;
                oelVoucher.Posted = chkPosted.Checked;
                oelVoucher.NewCost = 0;
                #endregion
                #region Stock Entries
                if (ValidateRows())
                {
                    //if (GPType == 1 && IsOut && !CheckMandatoryItemQuantity() && txtArticle.Visible == true)
                    //{
                    //    frmAuthenticate = new frmAuthentication();
                    //    frmAuthenticate.ShowDialog();
                    //    if (!Operations.IsAuthenticate)
                    //    {
                    //        MessageBox.Show("You Are Not Authenticated, Please Authenticate");
                    //        return;
                    //    }
                    //}
                    for (int i = 0; i < grdProducts.Rows.Count - 1; i++)
                    {
                        VoucherDetailEL oelProductionIssuance = new VoucherDetailEL();
                        ItemsEL oelItem = new ItemsEL();
                        if (grdProducts.Rows[i].Cells["colIdDetail"].Value != null)
                        {
                            //oelPurchaseDetial.TransactionID = new Guid(DgvStockReceipt.Rows[i].Cells["ColTransaction"].Value.ToString());
                            oelProductionIssuance.IdVoucherDetail = new Guid(grdProducts.Rows[i].Cells["colIdDetail"].Value.ToString());
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
                        oelProductionIssuance.IdItem = Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colIdItem"].Value);
                        oelProductionIssuance.IdArticle = Guid.Empty; //Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colIdArticle"].Value);
                        oelProductionIssuance.IdBrand = Guid.Empty; //Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colIdbrand"].Value);
                        oelProductionIssuance.PackingSize = Validation.GetSafeString(grdProducts.Rows[i].Cells["colpacking"].Value);
                        oelProductionIssuance.IdSize = Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colSizes"].Value);
                        oelProductionIssuance.IdColor = Validation.GetSafeGuid(grdProducts.Rows[i].Cells["colColors"].Value);
                        oelProductionIssuance.IssuanceWidth = Validation.GetSafeString(grdProducts.Rows[i].Cells["colWidth"].Value);
                        //if (GPType == 1)
                        {

                            if (Validation.GetSafeString(grdProducts.Rows[i].Cells["colIssuanceDept"].Value) == "Cutting")
                            {
                                oelProductionIssuance.IssuanceDept = 1;
                            }
                            else if (Validation.GetSafeString(grdProducts.Rows[i].Cells["colIssuanceDept"].Value) == "Stitching")
                            {
                                oelProductionIssuance.IssuanceDept = 2;
                            }
                            else if (Validation.GetSafeString(grdProducts.Rows[i].Cells["colIssuanceDept"].Value) == "Bartake")
                            {
                                oelProductionIssuance.IssuanceDept = 3;
                            }
                            else if (Validation.GetSafeString(grdProducts.Rows[i].Cells["colIssuanceDept"].Value) == "Threading")
                            {
                                oelProductionIssuance.IssuanceDept = 4;
                            }
                            else if (Validation.GetSafeString(grdProducts.Rows[i].Cells["colIssuanceDept"].Value) == "Inspection")
                            {
                                oelProductionIssuance.IssuanceDept = 5;
                            }
                            else if (Validation.GetSafeString(grdProducts.Rows[i].Cells["colIssuanceDept"].Value) == "Press")
                            {
                                oelProductionIssuance.IssuanceDept = 6;
                            }
                            else if (Validation.GetSafeString(grdProducts.Rows[i].Cells["colIssuanceDept"].Value) == "Packing")
                            {
                                oelProductionIssuance.IssuanceDept = 7;
                            }
                            else
                            {
                                oelProductionIssuance.IssuanceDept = -1;
                            }
                        }
                        //else
                        //{
                        //    oelProductionIssuance.IssuanceDept = -2;
                        //}
                        oelProductionIssuance.ExtraAvailableQuantity = 0;//Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colOpeningUnits"].Value);
                        oelProductionIssuance.IssuedExtraQuantity = 0; //Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colIssueOpening"].Value);
                        oelProductionIssuance.Units = Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colQty"].Value);
                        //+ Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colIssueOpening"].Value);
                        oelProductionIssuance.UnitPrice = Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colRate"].Value);
                        oelProductionIssuance.Amount = Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colAmount"].Value);

                        if (!IsOut)
                        {
                            for (int j = 0; j < grdProducts.Rows.Count - 1; j++)
                            {
                                oelVoucher.TotalUnits += Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colQty"].Value);
                                oelVoucher.TotalRate += Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colRate"].Value);
                                oelVoucher.TotalAmount += Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colAmount"].Value);
                            }
                        }
                        else
                        {
                            oelProductionIssuance.TotalUnits = 0;
                            oelProductionIssuance.TotalRate = 0;
                            oelProductionIssuance.TotalAmount = 0;
                        }
                        oelProductionIssuanceDetailCollection.Add(oelProductionIssuance);
                    }
                }
                else
                {
                    MessageBox.Show("Incomplete Entry...");
                    return;
                }
                #endregion
                #region Cost Evaluation
                //if (GPType == 1 && IsOut)
                //{
                //    for (int i = 0; i < grdProducts.Rows.Count - 1; i++)
                //    {
                //        if (ProductionType == "Cuff Cutting" || ProductionType == "Talli Cutting" || ProductionType == "Cuff Printing" || ProductionType == "Cuff OverLock" || ProductionType == "Cuff Magzi" || ProductionType == "Cuff Tape")
                //        {
                //            if (listBatch.Count > 0)
                //            {
                //                oelVoucher.NewCost = Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colAmount"].Value);
                //            }
                //            else if (Validation.GetSafeInteger(grdProducts.Rows[i].Cells["colItemType"].Value) == 1)
                //            {
                //                oelVoucher.NewCost += Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colAmount"].Value);
                //            }
                //        }
                //        else if (ProductionType == "Stitching")
                //        {
                //            // oelVoucher.NewCost += Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colAmount"].Value);
                //            oelVoucher.NewCost = 0;
                //        }
                //        else
                //        {
                //            oelVoucher.NewCost = 0;
                //        }
                //    }
                //}
                //else if (GPType == 1 && !IsOut)
                //{
                //    for (int i = 0; i < grdProducts.Rows.Count - 1; i++)
                //    {
                //        if (ProductionType == "Cuff Cutting" || ProductionType == "Talli Cutting" || ProductionType == "Cuff Printing" || ProductionType == "Cuff OverLock" || ProductionType == "Cuff Magzi" || ProductionType == "Cuff Tape")//|| cbxProductionType.Text == "Stitching")
                //        {
                //            oelVoucher.NewCost += Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colAmount"].Value);
                //        }
                //        else if (ProductionType == "Stitching")
                //        {
                //            oelVoucher.NewCost += Validation.GetSafeDecimal(grdProducts.Rows[i].Cells["colAmount"].Value);
                //        }
                //        else
                //        {
                //            oelVoucher.NewCost = 0;
                //        }
                //    }
                //}
                #endregion
                #region Insert Values
                if (IdVoucher == Guid.Empty)
                {
                    var manager = new ProductionIssuanceHeadBLL();
                    var VManager = new VoucherBLL();

                    EntityoperationInfo infoResult = manager.InsertProductionIssuance(oelVoucher, oelProductionIssuanceDetailCollection, listBatch, false);
                    if (infoResult.IsSuccess)
                    {
                        if (IsOut)
                        {
                            MessageBox.Show("Material Issued Successfully...");
                        }
                        else
                        {
                            MessageBox.Show("Material Recieved Successfully");
                        }
                        ClearControl();
                        FillData();
                    }
                    else
                    {
                        MessageBox.Show("Problem Occured While Issuance Production Stock :");
                    }
                }
                else
                {
                    var manager = new ProductionIssuanceHeadBLL();
                    var VManager = new VoucherBLL();
                    var ItemManager = new ItemsBLL();
                    EntityoperationInfo infoResult = manager.UpdateProductionIssuance(oelVoucher, oelProductionIssuanceDetailCollection, false);
                    if (infoResult.IsSuccess)
                    {
                        if (IsOut)
                        {
                            MessageBox.Show("Material Issued Updated Successfully...");
                        }
                        else
                        {
                            MessageBox.Show("Material Recieved Updated Successfully");
                        }
                        ClearControl();
                        FillData();
                    }
                }
                #endregion
            }
        }
        private void btnSelectOrder_Click(object sender, EventArgs e)
        {
            frmfindOrders = new frmFindOrders();
            frmfindOrders.ExecuteFindOrdersEvent += new frmFindOrders.FindOrdersDelegate(frmfindOrders_ExecuteFindOrdersEvent);
            frmfindOrders.ShowDialog();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var manager = new ProductionIssuanceHeadBLL(); //PurchaseStockReceiptBLL();
            if (IdVoucher != Guid.Empty)
            {
                if (MessageBox.Show("Are You Sure To Delete ?", "Deleting Gate Pass", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {

                    if (manager.DeleteGatePass(IdVoucher, GPType))
                    {
                        MessageBox.Show("Voucher Deleted Successfully and Transactions Rolled Back");
                        ClearControl();
                        FillData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select Voucher To Delete....");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmissuance = new frmPrintMaterialsIssuance();
            frmissuance.IssuanceNo = Validation.GetSafeLong(VEditBox.Text);
            if (IsOut)
            {
                frmissuance.IssuanceType = 1;
            }
            else
            {
                frmissuance.IssuanceType = 2;
            }
            frmissuance.ProductionType = GPType;
            frmissuance.ShowDialog();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            FillData();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            long PreviousVoucherNo = Convert.ToInt64(VEditBox.Text);
            PreviousVoucherNo -= 1;
            VEditBox.Text = PreviousVoucherNo.ToString();
            FillVoucher();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            long NextVoucherNo = Convert.ToInt64(VEditBox.Text);
            NextVoucherNo += 1;
            VEditBox.Text = NextVoucherNo.ToString();
            FillVoucher();
        }
        #endregion
        #region  Production Grid Events
        private void grdProducts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                SendKeys.Send("{F4}");
            }
            if (GPType == 1)
            {
                if (e.ColumnIndex == 12)
                {
                    SendKeys.Send("{F4}");
                }
            }
        }
        private void grdProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var Manager = new ItemsBLL();
            if (e.ColumnIndex == 8)
            {
                var manager = new ProductionIssuanceHeadBLL();
                //decimal AvgProcessValue = 0;
                decimal ProcessQuantity = 0;
                if (GPType == 1 && IsOut)
                {

                    ProcessQuantity = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdProducts.Rows[e.RowIndex].Cells["colIdItem"].Value))[0].Qty;
                    if (grdProducts.Rows[e.RowIndex].Cells["colQty"].Value != null && ProcessQuantity > 0)
                    {
                        if (Validation.GetSafeDecimal(grdProducts.Rows[e.RowIndex].Cells["colQty"].Value) > ProcessQuantity)
                        {
                            MessageBox.Show("Available Quantity For " + grdProducts.Rows[e.RowIndex].Cells["colItemName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                            grdProducts.Rows[e.RowIndex].Cells["colQty"].Value = "";
                            //if (grdProducts.Rows[e.RowIndex].Cells["colRate"].Value == null && Validation.GetSafeDecimal(grdProducts.Rows[e.RowIndex].Cells["colRate"].Value) == 0)
                            //{
                            //    grdProducts.Rows[e.RowIndex].Cells["colRate"].Value = "";
                            //    grdProducts.Rows[e.RowIndex].Cells["colAmount"].Value = "";
                            //}
                        }

                        //else
                        //{
                        //    if (grdProducts.Rows[e.RowIndex].Cells["colQty"].Value != null)
                        //    {
                        //        MessageBox.Show("Quantity Not Available For " + ProductionType + " In This Batch...");
                        //        grdProducts.Rows[e.RowIndex].Cells["colQty"].Value = "";
                        //    }
                        //}
                    }
                }

                //if (grdProducts.Rows[e.RowIndex].Cells["colRate"].Value != null)
                //{
                //    if (listItemCalculation != null && listItemCalculation.Count > 0)
                //    {
                //        grdProducts.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(grdProducts.Rows[e.RowIndex].Cells["colRate"].Value) * (Validation.GetSafeDecimal(grdProducts.Rows[e.RowIndex].Cells["colQty"].Value) + Validation.GetSafeDecimal(grdProducts.Rows[e.RowIndex].Cells["colIssueOpening"].Value))).ToString("0.00");
                //    }
                //    else
                //        grdProducts.Rows[e.RowIndex].Cells["colAmount"].Value = (Validation.GetSafeDecimal(grdProducts.Rows[e.RowIndex].Cells["colRate"].Value) * Validation.GetSafeDecimal(grdProducts.Rows[e.RowIndex].Cells["colQty"].Value)).ToString("0.00");
                //}
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
            //if (grdProducts.CurrentCellAddress.X == 8)
            //{
            //    TextBox txtBrand = e.Control as TextBox;
            //    if (txtBrand != null)
            //    {
            //        txtBrand.KeyPress -= new KeyPressEventHandler(txtBrand_KeyPress);
            //        txtBrand.KeyPress += new KeyPressEventHandler(txtBrand_KeyPress);
            //    }
            //}
        }
        void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdProducts.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventStockName = "MaterialEvent";
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
        void txtBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdProducts.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmfindBrand = new frmFindBrand();
                    frmfindBrand.SearchBy = "";
                    frmfindBrand.ExecuteFindBrandEvent += new frmFindBrand.FindBrandDelegate(frmfindBrand_ExecuteFindBrandEvent);
                    frmfindBrand.ShowDialog();
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
        private void cbxGatePassType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxGatePassType.Text == "Gloves Repair")
            {
                ShowHideColumns();
            }
        }
        #endregion
        #region Other Controls Events And methods
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
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillVoucher();
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
                    PersonAccountNo = oelAccount.AccountNo;
                    SEditBox.Text = oelAccount.AccountName;
                    EventTime = 0;
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
        void frmfindBrand_ExecuteFindBrandEvent(object Sender, BrandEL oelBrand)
        {
            grdProducts.CurrentRow.Cells["colIdbrand"].Value = oelBrand.IdBrand;
            grdProducts.CurrentRow.Cells["colBrandName"].Value = oelBrand.BrandName;
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            grdProducts.RefreshEdit();
            var manager = new ItemsBLL();
            List<ItemsEL> listItem = manager.GetItemById(oelItems.IdItem);
            {
                if (EventStockName == "MaterialEvent")
                {
                    if (listItem[0].ItemType == 0)
                    {
                        MessageBox.Show("Please Define Item Type");
                        return;
                    }
                    else
                    {
                        grdProducts.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
                        grdProducts.CurrentRow.Cells["colItemType"].Value = listItem[0].ItemType;
                        grdProducts.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
                        grdProducts.CurrentRow.Cells["colpacking"].Value = oelItems.PackingSize;
                        LoadItemSizes(oelItems.IdItem);
                        DataGridViewComboBoxCell cbxGarmentsColors = grdProducts.CurrentRow.Cells["colColors"] as DataGridViewComboBoxCell;
                        if (cbxGarmentsColors != null)
                        {
                            cbxGarmentsColors.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                            cbxGarmentsColors.DisplayMember = "ItemColor";
                            cbxGarmentsColors.ValueMember = "IdColor";
                        }
                    }
                }
                else if (EventStockName == "ArticleEvent")
                {

                    if (listItem[0].ItemType == 0)
                    {
                        MessageBox.Show("Please Define Item Type");
                        return;
                    }
                    else
                    {
                        grdProducts.CurrentRow.Cells["colIdArticle"].Value = oelItems.IdItem;
                        grdProducts.CurrentRow.Cells["colItemType"].Value = listItem[0].ItemType;
                        grdProducts.CurrentRow.Cells["colArticleName"].Value = oelItems.ItemName;
                        grdProducts.CurrentRow.Cells["colpacking"].Value = oelItems.PackingSize;
                        LoadItemSizes(oelItems.IdItem);
                    }
                }
                else
                {
                    IdArticle = oelItems.IdItem;
                    txtArticle.Text = oelItems.ItemName;
                }
            }

            /// Now Auto Load Brand
            var ProductionManager = new ProductionIssuanceHeadBLL();
            List<BrandEL> listBrands = ProductionManager.GetBrandByBatch(ProductionBatchNo, GPType);
            if (listBrands.Count > 0)
            {
                grdProducts.CurrentRow.Cells["colIdbrand"].Value = listBrands[0].IdBrand;
                grdProducts.CurrentRow.Cells["colBrandName"].Value = listBrands[0].BrandName;
            }

            if (IsOut && ProductionType == "Cuff Printing")
            {
                /// Now Check If Extra Units Available 
                decimal ExtraUnitsAvailability = ProductionManager.GetProductionOpeningPurchasedExtraUnitsByItem(oelItems.IdItem);
                if (ExtraUnitsAvailability > 0)
                {
                    grdProducts.CurrentRow.Cells["colOpeningUnits"].Value = ExtraUnitsAvailability;
                    grdProducts.Columns["colOpeningUnits"].Visible = true;
                    grdProducts.Columns["colIssueOpening"].Visible = true;
                }
            }
        }
        void frmfindOrders_ExecuteFindOrdersEvent(object Sender, OrdersEL oelOrder)
        {
            IdOrder = oelOrder.IdOrder;
            GetOrderById();
        }
        #endregion
        #region Transactional Methods
        private void FillVoucher()
        {
            var manager = new ProductionIssuanceHeadBLL();
            int value = 0;
            if (IsOut)
                value = 1;
            else
                value = 2;
            List<VouchersEL> lstVoucher = manager.GetProductionIssuanceVoucherByNo(Validation.GetSafeLong(VEditBox.Text), Operations.IdCompany, value, OperationType, GPType);
            if (lstVoucher.Count > 0)
            {
                IdVoucher = lstVoucher[0].IdVoucher;
                cbxGatePassType.Text = lstVoucher[0].GatePassType;
                txtArticle.Text = lstVoucher[0].PoNumber;
                IdArticle = lstVoucher[0].IdArticle;
                txtArticle.Text = lstVoucher[0].ArticleName;
                HandleVoucher(lstVoucher);
                if (lstVoucher[0].IdOrder != Guid.Empty)
                {
                    IdOrder = lstVoucher[0].IdOrder;
                    GetOrderById();
                }
                //cbxInOut.SelectedIndex = lstVoucher[0].ProcessType;
                //if (lstVoucher[0].WorkType == false)
                //{
                //    List<VoucherDetailEL> list = manager.GetProductionStockIssuanceDetailForTalliBariByNo(Validation.GetSafeLong(VEditBox.Text), Operations.IdCompany);
                //    VDate.Value = list[0].CreatedDateTime.Value;
                //    cbxProductionType.SelectedValue = list[0].IdDepartment;
                //    //cbxInOut.SelectedIndex = list[0].ProcessType;
                //    SEditBox.Text = list[0].AccountNo;
                //    txtSupplierName.Text = list[0].AccountName;
                //    FillIssuanceDetail(list, true);
                //    tabMain.SelectedIndex = 0;
                //}
                //else
                //{
                List<VoucherDetailEL> list = manager.GetProductionStockIssuanceByNo(Validation.GetSafeLong(VEditBox.Text), Operations.IdCompany, value, GPType, IdVoucher);
                if (list.Count > 0)
                {
                    VDate.Value = list[0].VDate.Value;
                    //cbxProductionType.SelectedValue = list[0].OperationType;
                    PersonAccountNo = list[0].AccountNo;
                    SEditBox.Text = list[0].AccountName;
                    FillIssuanceDetail(list, true);
                    ShowHideColumns();
                }
                else
                {
                    grdProducts.Rows.Clear();
                }
                //}
            }
            else
            {
                MessageBox.Show("Voucher Not Found In Record...");
                ClearControl();
            }

        }
        private void HandleVoucher(List<VouchersEL> list)
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
                //btnSave.Enabled = false;
                btnDelete.Enabled = false;
                //chkPosted.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
        private void FillIssuanceDetail(List<VoucherDetailEL> list, bool WorkType)
        {
            if (WorkType)
            {
                grdProducts.Enabled = true;
                grdProducts.Rows.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    grdProducts.Rows.Add();
                    grdProducts.Rows[i].Cells["colIdDetail"].Value = list[i].IdVoucherDetail;
                    grdProducts.Rows[i].Cells["colIdItem"].Value = list[i].IdItem;
                    grdProducts.Rows[i].Cells["colItemType"].Value = list[i].ItemType;
                    //grdProducts.Rows[i].Cells["colIdArticle"].Value = list[i].IdSubArticle;
                    //grdProducts.Rows[i].Cells["colArticleName"].Value = list[i].SubArticle;
                    //grdProducts.Rows[i].Cells["colIdbrand"].Value = list[i].IdBrand;
                    //grdProducts.Rows[i].Cells["colBrandName"].Value = list[i].BrandName;
                    grdProducts.Rows[i].Cells["colItemName"].Value = list[i].ItemName;
                    grdProducts.Rows[i].Cells["colpacking"].Value = list[i].PackingSize;
                    LoadItemSizes(list[i].IdItem);
                    if (grdProducts.Rows[i].Cells["colSizes"].Value != null)
                    {
                        if (list[i].IdSize != Guid.Empty)
                        {
                            grdProducts.Rows[i].Cells["colSizes"].Value = list[i].IdSize;
                        }
                        else
                        {
                            grdProducts.Rows[i].Cells["colSizes"].Value = null;
                        }
                    }
                    DataGridViewComboBoxCell cbxGarmentsCuttingColors = grdProducts.Rows[i].Cells["colColors"] as DataGridViewComboBoxCell;
                    if (cbxGarmentsCuttingColors != null)
                    {
                        cbxGarmentsCuttingColors.DataSource = GetItemsColorAttributes(list[i].IdItem);
                        cbxGarmentsCuttingColors.DisplayMember = "ItemColor";
                        cbxGarmentsCuttingColors.ValueMember = "IdColor";
                        grdProducts.Rows[i].Cells["colColors"].Value = list[i].IdColor;
                    }
                    else
                        grdProducts.Rows[i].Cells["colColors"].Value = null;

                    grdProducts.Rows[i].Cells["colWidth"].Value = list[i].IssuanceWidth;
                    if (GPType == 1)
                    {
                        if (list[i].IssuanceDept == 1)
                        {
                            grdProducts.Rows[i].Cells["colIssuanceDept"].Value = "Cuff Cutting";
                        }
                        else if (list[i].IssuanceDept == 2)
                        {
                            grdProducts.Rows[i].Cells["colIssuanceDept"].Value = "Cuff Printing";
                        }
                        else if (list[i].IssuanceDept == 3)
                        {
                            grdProducts.Rows[i].Cells["colIssuanceDept"].Value = "OverLock";
                        }
                        else if (list[i].IssuanceDept == 4)
                        {
                            grdProducts.Rows[i].Cells["colIssuanceDept"].Value = "Magzi/Tape";
                        }
                    }
                    //grdProducts.Rows[i].Cells["colOpeningUnits"].Value = list[i].ExtraAvailableQuantity;
                    //grdProducts.Rows[i].Cells["colIssueOpening"].Value = list[i].IssuedExtraQuantity;
                    //grdProducts.Rows[i].Cells["colQty"].Value = list[i].IssuedExtraQuantity;
                    grdProducts.Rows[i].Cells["colQty"].Value = list[i].Qty;
                    grdProducts.Rows[i].Cells["colRate"].Value = list[i].UnitPrice;
                    grdProducts.Rows[i].Cells["colAmount"].Value = list[i].Amount.ToString("0.00");
                }
            }
        }
        #endregion
    }
}
