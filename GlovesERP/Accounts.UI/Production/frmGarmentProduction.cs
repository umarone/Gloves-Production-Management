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
    public partial class frmGarmentProduction : MetroForm
    {
        #region Variables
        frmFindAccounts frmfindAccount;
        frmStockAccounts frmstockAccounts;
        frmWorkPurchases frmworkpurchases;
        Guid IdVoucher = Guid.Empty;
        Guid IdBrand = Guid.Empty;
        Guid IdCutting;
        Guid IdStitching;
        Guid IdFeedo;
        Guid IdBartake;
        Guid IdThreading;
        Guid IdInspection;
        Guid IdPress;
        Guid IdPacking;
        Guid IdQuality;
        Guid IdEntity;
        Guid IdOrder = Guid.Empty;
        string LoadType;
        string EventFiringName;
        string EmpAccountNo = "";
        string EmpAccountName = "";
        decimal postAmount;
        decimal AvgProcessValue = 0;
        decimal ProcessQuantity = 0;
        bool EntryAlreadyDone;
        #endregion
        #region Windows Form Events And Methods
        public frmGarmentProduction()
        {
            InitializeComponent();
        }
        private void frmGarmentProduction_Load(object sender, EventArgs e)
        {
            this.grdCutting.AutoGenerateColumns = false;
            this.grdStitching.AutoGenerateColumns = false;
            this.grdFeedoSaftey.AutoGenerateColumns = false;
            this.grdFeedoSaftey.AutoGenerateColumns = false;
            this.grdBartakeMaterials.AutoGenerateColumns = false;
            this.grdThreading.AutoGenerateColumns = false;
            this.grdInspection.AutoGenerateColumns = false;
            this.grdPress.AutoGenerateColumns = false;
            this.grdPacking.AutoGenerateColumns = false;
            ProductionTab.SelectedIndex = 0;
            FillMaxProductionNo();
            FillCustomerPos();
        }
        private void FillMaxProductionNo()
        {
            var Manager = new ProductionProcessesHeadBLL();
            VEditBox.Text = Validation.GetSafeString(Manager.GetMaxProductionProcessCode(Operations.IdCompany, 1, 2));
        }
        #endregion
        #region Cutting Grid Events
        private void grdCutting_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (grdCutting.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdCutting_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 19)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 20)
            {
                e.Value = "Post";
            }
        }
        private void grdCutting_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 10)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdCutting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Recored Deletion
            if (e.ColumnIndex == 19)
            {
                var Manager = new ProductionProcessDetailBLL();
                if (Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value) != Guid.Empty)
                {
                    if (grdCutting.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value), Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdCutting.Columns.Count; i++)
                    {
                        grdCutting.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 20)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(1))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.AccountNo = "0";
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 2;

                    if (IdCutting == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdCutting;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Cutting";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = oelProductionHead.IdVoucher;
                    if (grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdCutting.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountNo"].Value);
                    oelProductionDetail.StitcherAccountNo = "0";
                    EmpAccountNo = Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.ProductionProcessName = "Garments Cutting";
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingIdItem"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingSizes"].Value);
                    if (Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingColors"].Value) == Guid.Empty)
                    {
                        MessageBox.Show("Please Select Color...");
                        return;
                    }
                    oelProductionDetail.IdColor = Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingColors"].Value);
                    if (Validation.GetSafeInteger(grdCutting.Rows[e.RowIndex].Cells["colCuttingType"].Value) == 1)
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else
                    {
                        oelProductionDetail.GType = 2;
                    }
                    if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingClotheQuality"].Value) == "Fresh")
                    {
                        oelProductionDetail.Quality = 1;
                    }
                    else if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingClotheQuality"].Value) == "Cut Pieces")
                    {
                        oelProductionDetail.Quality = 2;
                    }
                    else if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingClotheQuality"].Value) == "B Grade")
                    {
                        oelProductionDetail.Quality = 3;
                    }
                    oelProductionDetail.BundleNo = Validation.GetSafeLong(grdCutting.Rows[e.RowIndex].Cells["colCuttingBundleNumber"].Value);
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdCutting.Rows[e.RowIndex].Cells["colCuttingQty"].Value);
                    oelProductionDetail.Average = Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colCuttingAverage"].Value);
                    oelProductionDetail.Meters = Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colCuttingMeters"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.PStyle = "";
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdCutting.Rows[e.RowIndex].Cells["colCuttingDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colCuttingRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colCuttingAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }
                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdCutting = oelProductionProcess.IdProductionProcess;
                            //if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountType"].Value) == "Employees")
                                {
                                    grdCutting.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted....");
                                }
                                if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountType"].Value) != "Employees")
                                {
                                    //frmworkpurchases = new frmWorkPurchases();
                                    //frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //frmworkpurchases.IdEntity = IdEntity;
                                    //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //frmworkpurchases.PurchasesType = "Garments Cutting Purchases";
                                    //frmworkpurchases.ProcessName = "Garments Cutting";
                                    //frmworkpurchases.ProcessAmount = postAmount;
                                    //frmworkpurchases.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        //frmworkpurchases = new frmWorkPurchases();
                        //frmworkpurchases.ProductionType = "Garments / Gloves";
                        //frmworkpurchases.IdEntity = IdEntity;
                        //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        //frmworkpurchases.EmpAccountName = EmpAccountName;
                        //frmworkpurchases.PurchasesType = "Garments Cutting Purchases";
                        //frmworkpurchases.ProcessName = "Garments Cutting";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelTanneryProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdCutting_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            { 
                /// Generate New Bundle Number Here Automatically....
                var Manager = new ProductionProcessDetailBLL();
                Int64 MaxBundleNumber = Manager.GetMaxBundleNoByArticleAndColor(Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingIdItem"].Value),Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingColors"].Value));
                if(MaxBundleNumber > 0)
                {
                    grdCutting.Rows[e.RowIndex].Cells["colCuttingBundleNumber"].Value = MaxBundleNumber;
                }
            }
            if (e.ColumnIndex == 17)
            {
                grdCutting.Rows[e.RowIndex].Cells["colCuttingAmount"].Value = Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colCuttingQty"].Value) * Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colCuttingRate"].Value);
            }
        }
        private void grdCutting_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCutting.CurrentCellAddress.X == 7)
            {
                TextBox txtVendorName = e.Control as TextBox;
                if (txtVendorName != null)
                {
                    txtVendorName.KeyPress -= new KeyPressEventHandler(txtVendorName_KeyPress);
                    txtVendorName.KeyPress += new KeyPressEventHandler(txtVendorName_KeyPress);
                }
            }
            else if (grdCutting.CurrentCellAddress.X == 8)
            {
                TextBox txtCuttingClotheType = e.Control as TextBox;
                if (txtCuttingClotheType != null)
                {
                    txtCuttingClotheType.KeyPress -= new KeyPressEventHandler(txtCuttingClotheType_KeyPress);
                    txtCuttingClotheType.KeyPress += new KeyPressEventHandler(txtCuttingClotheType_KeyPress);
                }
            }
        }
        void txtVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCutting.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Cutting";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        void txtCuttingClotheType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCutting.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garments Cutting Article";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Cutting Grid Material Events
        private void grdCuttingMaterialUsed_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdCuttingMaterialUsed_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                var Manager = new ItemsBLL();
                int IssuanceType = 0;
                if (Validation.GetSafeString(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialCuttingType"].Value) == "Fresh A Grade")
                {
                    IssuanceType = 1;
                }
                else if (Validation.GetSafeString(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialCuttingType"].Value) == "B Grade")
                {
                    IssuanceType = 2;
                }
                else if (Validation.GetSafeString(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialCuttingType"].Value) == "Cutt Pieces")
                {
                    IssuanceType = 3;
                }
                List<ItemsEL> list = Manager.GetGarmentItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialIdItem"].Value), Validation.GetSafeGuid(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialColors"].Value), IssuanceType);
                if (list.Count > 0)
                {
                    ProcessQuantity = list[0].Qty;
                    if (Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialUsedQty"].Value) > ProcessQuantity)
                    {
                        MessageBox.Show("Available Quantity For " + grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                        grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialUsedQty"].Value = "";
                        if (grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialRate"].Value == null && Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialRate"].Value) == 0)
                        {
                            grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialRate"].Value = "";
                            grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialAmount"].Value = "";
                        }
                    }
                    else
                    {
                        if (grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialUsedQty"].Value != null && Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialUsedQty"].Value) > 0)
                        {
                            grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialRate"].Value = list[0].AvgRate.ToString("0.00");
                            grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialAmount"].Value = (Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialRate"].Value) *
                                                                                                              Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialUsedQty"].Value)).ToString("0.00");
                        }
                    }
                }
            }
        }
        private void grdCuttingMaterialUsed_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCuttingMaterialUsed.CurrentCellAddress.X == 5)
            {
                TextBox txtCuttingMaterialName = e.Control as TextBox;
                if (txtCuttingMaterialName != null)
                {
                    txtCuttingMaterialName.KeyPress -= new KeyPressEventHandler(txtCuttingMaterialName_KeyPress);
                    txtCuttingMaterialName.KeyPress += new KeyPressEventHandler(txtCuttingMaterialName_KeyPress);
                }
            }
            else if (grdCuttingMaterialUsed.CurrentCellAddress.X == 7)
            {
                TextBox txtCuttingMaterialWorkerName = e.Control as TextBox;
                if (txtCuttingMaterialWorkerName != null)
                {
                    txtCuttingMaterialWorkerName.KeyPress -= new KeyPressEventHandler(txtCuttingMaterialWorkerName_KeyPress);
                    txtCuttingMaterialWorkerName.KeyPress += new KeyPressEventHandler(txtCuttingMaterialWorkerName_KeyPress);
                }
            }
        }
        void txtCuttingMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuttingMaterialUsed.CurrentCellAddress.X == 5)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garment Cutting Materials";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        void txtCuttingMaterialWorkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuttingMaterialUsed.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Cutting Material Worker";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        #region Cutting Grid Wastage
        private void grdCuttingWastage_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCuttingWastage.CurrentCellAddress.X == 3)
            {
                TextBox txtCuttingWastageMaterialName = e.Control as TextBox;
                if (txtCuttingWastageMaterialName != null)
                {
                    txtCuttingWastageMaterialName.KeyPress -= new KeyPressEventHandler(txtCuttingWastageMaterialName_KeyPress);
                    txtCuttingWastageMaterialName.KeyPress += new KeyPressEventHandler(txtCuttingWastageMaterialName_KeyPress);
                }
            }
        }
        void txtCuttingWastageMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuttingWastage.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garment Cutting Wastage";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Stitching Grid Events
        private void grdStitching_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (grdStitching.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdStitching_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 16)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 17)
            {
                e.Value = "Posting";
            }

        }
        private void grdStitching_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 10)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdStitching_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 16)
            {
                if (Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colIdStitching"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdStitching.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colIdStitching"].Value), Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colStitchingIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdStitching.Columns.Count; i++)
                    {
                        grdStitching.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 17)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(2))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.AccountNo = "0";
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 2;

                    if (IdStitching == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdStitching;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Stitching";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = oelProductionHead.IdVoucher;
                    if (grdStitching.Rows[e.RowIndex].Cells["colIdStitching"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdStitching.Rows[e.RowIndex].Cells["colIdStitching"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colIdStitching"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdStitching.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingAccountNo"].Value);
                    oelProductionDetail.StitcherAccountNo = "0";
                    EmpAccountNo = Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.ProductionProcessName = "Garments Stitching";
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colStitchingIdItem"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingSizes"].Value);
                    if (Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colStitchingColors"].Value) == Guid.Empty)
                    {
                        MessageBox.Show("Please Select Color...");
                        return;
                    }
                    oelProductionDetail.IdColor = Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingColors"].Value);

                    if (Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingType"].Value) == "Cover All")
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else if (Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingType"].Value) == "Pant & Shirt")
                    {
                        oelProductionDetail.GType = 2;
                    }
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdStitching.Rows[e.RowIndex].Cells["colStitchingQuantity"].Value);
                    oelProductionDetail.BundleNo = Validation.GetSafeLong(grdStitching.Rows[e.RowIndex].Cells["colStitchingBundleNumber"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.Meters = 0;
                    oelProductionDetail.PStyle = string.Empty;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdStitching.Rows[e.RowIndex].Cells["colStitchingDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdStitching.Rows[e.RowIndex].Cells["colStitchingRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdStitching.Rows[e.RowIndex].Cells["colStitchingAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }

                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdStitching = oelProductionProcess.IdProductionProcess;
                            //if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingAccountType"].Value) == "Employees")
                                {
                                    grdStitching.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted....");
                                }
                                else if (Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingAccountType"].Value) != "Employees")
                                {
                                    //frmworkpurchases = new frmWorkPurchases();
                                    //frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //frmworkpurchases.IdEntity = IdEntity;
                                    //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //frmworkpurchases.PurchasesType = "Garments Stitching Purchases";
                                    //frmworkpurchases.ProcessName = "Garments Stitching";
                                    //frmworkpurchases.ProcessAmount = postAmount;
                                    //frmworkpurchases.ShowDialog();
                                }

                            }
                        }
                    }
                    else
                    {
                        //frmworkpurchases = new frmWorkPurchases();
                        //frmworkpurchases.ProductionType = "Garments / Gloves";
                        //frmworkpurchases.IdEntity = IdEntity;
                        //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        //frmworkpurchases.EmpAccountName = EmpAccountName;
                        //frmworkpurchases.PurchasesType = "Garments Stitching Purchases";
                        //frmworkpurchases.ProcessName = "Garments Stitching";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
        }
        private void grdStitching_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                grdStitching.Rows[e.RowIndex].Cells["colStitchingAmount"].Value = Validation.GetSafeDecimal(grdStitching.Rows[e.RowIndex].Cells["colStitchingQuantity"].Value) * Validation.GetSafeDecimal(grdStitching.Rows[e.RowIndex].Cells["colStitchingRate"].Value);
            }
        }
        private void grdStitching_EditingConrolShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdStitching.CurrentCellAddress.X == 7)
            {
                TextBox txtStitchingVendorName = e.Control as TextBox;
                if (txtStitchingVendorName != null)
                {
                    txtStitchingVendorName.KeyPress -= new KeyPressEventHandler(txtStitchingVendorName_KeyPress);
                    txtStitchingVendorName.KeyPress += new KeyPressEventHandler(txtStitchingVendorName_KeyPress);
                }
            }
            else if (grdStitching.CurrentCellAddress.X == 8)
            {
                TextBox txtStitchingArticleName = e.Control as TextBox;
                if (txtStitchingArticleName != null)
                {
                    txtStitchingArticleName.KeyPress -= new KeyPressEventHandler(txtStitchingArticleName_KeyPress);
                    txtStitchingArticleName.KeyPress += new KeyPressEventHandler(txtStitchingArticleName_KeyPress);
                }
            }
        }
        void txtStitchingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdStitching.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Stitching";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        void txtStitchingArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdStitching.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garments Stitching Article";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Stitching Material Grid Events
        private void grdStitchingMaterials_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            #region Variables
            var Manager = new ItemsBLL();
            string ProcessName = "Garments Cutting";
            #endregion
            #region Closing Stock And Average Calculating Region
            if (e.ColumnIndex == 10)
            {

                if (Validation.GetSafeLong(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialItemType"].Value) == 1)
                {
                    ProcessQuantity = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialIdItem"].Value))[0].Qty;
                }
                else if (Validation.GetSafeGuid(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialColors"].Value) != Guid.Empty)
                {
                    ProcessQuantity = GetGarmentsProductionClosingStockByCustomerPO(Validation.GetSafeGuid(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialIdItem"].Value), Validation.GetSafeGuid(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialColors"].Value), Validation.GetSafeLong(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialBundleNo"].Value), ProcessName, "Garments Stitching Material Usage");
                }
                else
                {
                    MessageBox.Show("Please Select Article Color....");
                    return;
                }
                if (Validation.GetSafeDecimal(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialQuantity"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                    grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialQuantity"].Value = "";
                    grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialRate"].Value = "";
                    grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialAmount"].Value = "";

                }
                else
                {
                    /// Calculating Average Value Here....
                    if (Validation.GetSafeLong(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialItemType"].Value) == 1)
                    {
                        grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialRate"].Value = Manager.GetItemsAvgValue(Validation.GetSafeGuid(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialIdItem"].Value)).ToString("0.00");
                        grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialAmount"].Value = (Validation.GetSafeDecimal(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialQuantity"].Value)
                                                                                                               * Validation.GetSafeDecimal(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialRate"].Value)).ToString("0.00");
                    }
                    else
                    {
                        if (grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialQuantity"].Value != null && Validation.GetSafeDecimal(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialQuantity"].Value) > 0)
                        {

                            grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialRate"].Value = GetGarmentsAvgCostingByCustomerPO(Validation.GetSafeGuid(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialIdItem"].Value), Validation.GetSafeGuid(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialColors"].Value), ProcessName, "Garments Cutting material Usage").ToString("0.00");
                            grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialAmount"].Value = (Validation.GetSafeDecimal(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialQuantity"].Value)
                                                                                                                    * Validation.GetSafeDecimal(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialRate"].Value)).ToString("0.00");
                        }
                        else
                        {
                            grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialRate"].Value = "";
                            grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialAmount"].Value = "";
                        }
                    }
                }
            }
            #endregion
        }
        private void grdStitchingMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdStitchingMaterials.CurrentCellAddress.X == 5)
            {
                TextBox txtStitchingMaterialName = e.Control as TextBox;
                txtStitchingMaterialName.KeyPress -= new KeyPressEventHandler(txtStitchingMaterialName_KeyPress);
                txtStitchingMaterialName.KeyPress += new KeyPressEventHandler(txtStitchingMaterialName_KeyPress);
            }
            else if (grdStitchingMaterials.CurrentCellAddress.X == 7)
            {
                TextBox txtStitchingMaterialWorkerName = e.Control as TextBox;
                txtStitchingMaterialWorkerName.KeyPress -= new KeyPressEventHandler(txtStitchingMaterialWorkerName_KeyPress);
                txtStitchingMaterialWorkerName.KeyPress += new KeyPressEventHandler(txtStitchingMaterialWorkerName_KeyPress);
            }
        }
        void txtStitchingMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdStitchingMaterials.CurrentCellAddress.X == 5)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garment Stitching Material";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        void txtStitchingMaterialWorkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdStitchingMaterials.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Stitching Material Worker";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        #region Feedo/Saftey Grid Events
        private void grdFeedoSaftey_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (grdFeedoSaftey.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdFeedoSaftey_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 17)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 18)
            {
                e.Value = "Posting";
            }
        }
        private void grdFeedoSaftey_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 10)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 12)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdFeedoSaftey_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 17)
            {
                if (Validation.GetSafeGuid(grdFeedoSaftey.Rows[e.RowIndex].Cells["colIdFeedo"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdFeedoSaftey.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdFeedoSaftey.Rows[e.RowIndex].Cells["colIdFeedo"].Value), Validation.GetSafeGuid(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdFeedoSaftey.Columns.Count; i++)
                    {
                        grdFeedoSaftey.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 18)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(3))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.AccountNo = "0";
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 2;

                    if (IdFeedo == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdFeedo;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Feedo/Saftey";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = oelProductionHead.IdVoucher;
                    if (grdFeedoSaftey.Rows[e.RowIndex].Cells["colIdFeedo"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdFeedoSaftey.Rows[e.RowIndex].Cells["colIdFeedo"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdFeedoSaftey.Rows[e.RowIndex].Cells["colIdFeedo"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdFeedoSaftey.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoAccountNo"].Value);
                    oelProductionDetail.StitcherAccountNo = "0";
                    EmpAccountNo = Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoVendorName"].Value);
                    oelProductionDetail.ProductionProcessName = "Garments Feedo/Saftey";
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoIdItem"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoSizes"].Value);
                    if (Validation.GetSafeGuid(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoColors"].Value) == Guid.Empty)
                    {
                        MessageBox.Show("Please Select Color...");
                        return;
                    }
                    oelProductionDetail.IdColor = Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingColors"].Value);

                    if (Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoBrandType"].Value) == "Cover All")
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else if (Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoBrandType"].Value) == "Pant & Shirt")
                    {
                        oelProductionDetail.GType = 2;
                    }
                    if (Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoWorkType"].Value) == "Feedo")
                    {
                        oelProductionDetail.GarmentWorkType = 1;
                    }
                    else if (Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoWorkType"].Value) == "Saftey")
                    {
                        oelProductionDetail.GarmentWorkType = 2;
                    }
                    oelProductionDetail.Meters = 0;
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoQuantity"].Value);
                    oelProductionDetail.BundleNo = Validation.GetSafeLong(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoBundleNumber"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.PStyle = "";
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }
                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdFeedo = oelProductionProcess.IdProductionProcess;
                            //if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoAccountType"].Value) == "Employees")
                                {
                                    grdFeedoSaftey.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted.....");
                                }
                                else
                                {
                                    //frmworkpurchases = new frmWorkPurchases();
                                    //frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //frmworkpurchases.IdEntity = IdEntity;
                                    //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //frmworkpurchases.PurchasesType = "Garments Feedo/Saftey Purchases";
                                    //frmworkpurchases.ProcessName = "Garments Feedo/Saftey";
                                    //frmworkpurchases.ProcessAmount = postAmount;
                                    //frmworkpurchases.ShowDialog();
                                }

                            }
                        }
                    }
                    else
                    {
                        //    frmworkpurchases = new frmWorkPurchases();
                        //    frmworkpurchases.ProductionType = "Garments / Gloves";
                        //    frmworkpurchases.IdEntity = IdEntity;
                        //    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        //    frmworkpurchases.EmpAccountName = EmpAccountName;
                        //    frmworkpurchases.PurchasesType = "Garments Feedo/Saftey Purchases";
                        //    frmworkpurchases.ProcessName = "Garments Feedo/Saftey";
                        //    frmworkpurchases.ProcessAmount = postAmount;
                        //    frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}

                }
            }
            #endregion
        }
        private void grdFeedoSaftey_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 15)
            {
                grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoAmount"].Value = Validation.GetSafeDecimal(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoQuantity"].Value) * Validation.GetSafeDecimal(grdFeedoSaftey.Rows[e.RowIndex].Cells["colFeedoRate"].Value);
            }
        }
        private void grdFeedoSaftey_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdFeedoSaftey_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdFeedoSaftey.CurrentCellAddress.X == 7)
            {
                TextBox txtFeedoSafteyVendorName = e.Control as TextBox;
                if (txtFeedoSafteyVendorName != null)
                {
                    txtFeedoSafteyVendorName.KeyPress -= new KeyPressEventHandler(txtFeedoSafteyVendorName_KeyPress);
                    txtFeedoSafteyVendorName.KeyPress += new KeyPressEventHandler(txtFeedoSafteyVendorName_KeyPress);
                }
            }
            else if (grdFeedoSaftey.CurrentCellAddress.X == 8)
            {
                TextBox txtFeedoSafetyArticleName = e.Control as TextBox;
                if (txtFeedoSafetyArticleName != null)
                {
                    txtFeedoSafetyArticleName.KeyPress -= new KeyPressEventHandler(txtFeedoSafetyArticleName_KeyPress);
                    txtFeedoSafetyArticleName.KeyPress += new KeyPressEventHandler(txtFeedoSafetyArticleName_KeyPress);
                }
            }
        }
        void txtFeedoSafteyVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdFeedoSaftey.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Feedo";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        void txtFeedoSafetyArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdFeedoSaftey.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garments Feedo Article";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Feedo / Saftey Material Grid Events
        private void grdFeedoMaterials_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdFeedoMaterials_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            #region Variables
            var Manager = new ItemsBLL();
            string ProcessName = "Garments Stitching";
            #endregion
            #region Closing Stock And Average Calculating Region
            if (e.ColumnIndex == 10)
            {

                if (Validation.GetSafeLong(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialItemType"].Value) == 1)
                {
                    ProcessQuantity = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialIdItem"].Value))[0].Qty;
                }
                else if (Validation.GetSafeGuid(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialColors"].Value) != Guid.Empty)
                {
                    ProcessQuantity = GetGarmentsProductionClosingStockByCustomerPO(Validation.GetSafeGuid(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialIdItem"].Value), Validation.GetSafeGuid(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialColors"].Value), Validation.GetSafeLong(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialBundleNo"].Value), ProcessName, "Garments Feedo Material Usage");
                }
                else
                {
                    MessageBox.Show("Please Select Article Color....");
                    return;
                }
                if (Validation.GetSafeDecimal(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialUsedQuantity"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                    grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialUsedQuantity"].Value = "";
                    grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialRate"].Value = "";
                    grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialAmount"].Value = "";

                }
                else
                {
                    /// Calculating Average Value Here....
                    if (Validation.GetSafeLong(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialItemType"].Value) == 1)
                    {
                        grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialRate"].Value = Manager.GetItemsAvgValue(Validation.GetSafeGuid(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialIdItem"].Value)).ToString("0.00");
                        grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialAmount"].Value = (Validation.GetSafeDecimal(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialUsedQuantity"].Value)
                                                                                                               * Validation.GetSafeDecimal(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialRate"].Value)).ToString("0.00");
                    }
                    else
                    {
                        if (grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialUsedQuantity"].Value != null && Validation.GetSafeDecimal(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialUsedQuantity"].Value) > 0)
                        {

                            grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialRate"].Value = GetGarmentsAvgCostingByCustomerPO(Validation.GetSafeGuid(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialIdItem"].Value), Validation.GetSafeGuid(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialColors"].Value), ProcessName, "Garments Stitching material Usage").ToString("0.00");
                            grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialAmount"].Value = (Validation.GetSafeDecimal(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialUsedQuantity"].Value)
                                                                                                                    * Validation.GetSafeDecimal(grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialRate"].Value)).ToString("0.00");
                        }
                        else
                        {
                            grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialRate"].Value = "";
                            grdFeedoMaterials.Rows[e.RowIndex].Cells["colFeedoMaterialAmount"].Value = "";
                        }
                    }
                }
            }
            #endregion
        }
        private void grdFeedoMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdFeedoMaterials.CurrentCellAddress.X == 5)
            {
                TextBox txtFeedoSafteyMaterialName = e.Control as TextBox;
                txtFeedoSafteyMaterialName.KeyPress -= new KeyPressEventHandler(txtFeedoSafteyMaterialName_KeyPress);
                txtFeedoSafteyMaterialName.KeyPress += new KeyPressEventHandler(txtFeedoSafteyMaterialName_KeyPress);
            }
            else if (grdFeedoMaterials.CurrentCellAddress.X == 7)
            {
                TextBox txtFeedoSafteyWorkerName = e.Control as TextBox;
                txtFeedoSafteyWorkerName.KeyPress -= new KeyPressEventHandler(txtFeedoSafteyWorkerName_KeyPress);
                txtFeedoSafteyWorkerName.KeyPress += new KeyPressEventHandler(txtFeedoSafteyWorkerName_KeyPress);
            }
        }
        void txtFeedoSafteyMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdFeedoMaterials.CurrentCellAddress.X == 5)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garment Feedo/Saftey Material";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        void txtFeedoSafteyWorkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdFeedoMaterials.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garment Feedo/Saftey Worker";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        #region Bartake/Kage/Buttons Grid Events
        private void grdBartake_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (grdBartake.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdBartake_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 17)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 18)
            {
                e.Value = "Posting";
            }
        }
        private void grdBartake_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 10)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 12)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdBartake_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 17)
            {
                if (Validation.GetSafeGuid(grdBartake.Rows[e.RowIndex].Cells["colIdBartake"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdBartake.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdBartake.Rows[e.RowIndex].Cells["colIdBartake"].Value), Validation.GetSafeGuid(grdBartake.Rows[e.RowIndex].Cells["colBartakeIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdBartake.Columns.Count; i++)
                    {
                        grdBartakeMaterials.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 18)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(4))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.AccountNo = "0";
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 2;

                    if (IdBartake == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdBartake;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Bartake/Kaaj/Buttons";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = oelProductionHead.IdVoucher;
                    if (grdBartake.Rows[e.RowIndex].Cells["colIdBartake"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdBartake.Rows[e.RowIndex].Cells["colIdBartake"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdBartake.Rows[e.RowIndex].Cells["colIdBartake"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdBartake.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeAccountNo"].Value);
                    oelProductionDetail.StitcherAccountNo = "0";
                    EmpAccountNo = Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeVendorName"].Value);
                    oelProductionDetail.ProductionProcessName = "Garments Bartake/Kaaj/Buttons";
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdBartake.Rows[e.RowIndex].Cells["colBartakeIdItem"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeSizes"].Value);
                    if (Validation.GetSafeGuid(grdBartake.Rows[e.RowIndex].Cells["colBartakeColors"].Value) == Guid.Empty)
                    {
                        MessageBox.Show("Please Select Color...");
                        return;
                    }
                    oelProductionDetail.IdColor = Validation.GetSafeGuid(grdBartake.Rows[e.RowIndex].Cells["colBartakeColors"].Value);

                    if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeOrderType"].Value) == "Cover All")
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeOrderType"].Value) == "Pant & Shirt")
                    {
                        oelProductionDetail.GType = 2;
                    }
                    if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeWorkType"].Value) == "Bartake")
                    {
                        oelProductionDetail.GarmentWorkType = 1;
                    }
                    else if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeWorkType"].Value) == "Kaaj")
                    {
                        oelProductionDetail.GarmentWorkType = 2;
                    }
                    else if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeWorkType"].Value) == "Buttons")
                    {
                        oelProductionDetail.GarmentWorkType = 3;
                    }
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdBartake.Rows[e.RowIndex].Cells["colBartakeQuantity"].Value);
                    oelProductionDetail.BundleNo = Validation.GetSafeLong(grdBartake.Rows[e.RowIndex].Cells["colBartakeBundleNumber"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.Meters = 0;
                    oelProductionDetail.PStyle = "";
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdBartake.Rows[e.RowIndex].Cells["colBartakeDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdBartake.Rows[e.RowIndex].Cells["colBartakeRates"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdBartake.Rows[e.RowIndex].Cells["colBartakeAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }
                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdBartake = oelProductionProcess.IdProductionProcess;
                            //if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeAccountType"].Value) == "Employees")
                                {
                                    grdBartake.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted.....");
                                }
                                else if (Validation.GetSafeString(grdBartake.Rows[e.RowIndex].Cells["colBartakeAccountType"].Value) != "Employees")
                                {
                                    //frmworkpurchases = new frmWorkPurchases();
                                    //frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //frmworkpurchases.IdEntity = IdEntity;
                                    //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //frmworkpurchases.PurchasesType = "Garments Bartake / Button / Kaaj Purchases";
                                    //frmworkpurchases.ProcessName = "Garments Bartake/Buttons/Kaaj";
                                    //frmworkpurchases.ProcessAmount = postAmount;
                                    //frmworkpurchases.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        //frmworkpurchases = new frmWorkPurchases();
                        //frmworkpurchases.ProductionType = "Garments / Gloves";
                        //frmworkpurchases.IdEntity = IdEntity;
                        //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        //frmworkpurchases.EmpAccountName = EmpAccountName;
                        //frmworkpurchases.PurchasesType = "Garment Bartake / Button / Kaaj Purchases";
                        //frmworkpurchases.ProcessName = "Garment Feedo/Button/Kaaj";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
        }
        private void grdBartake_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 15)
            {
                grdBartake.Rows[e.RowIndex].Cells["colBartakeAmount"].Value = Validation.GetSafeDecimal(grdBartake.Rows[e.RowIndex].Cells["colBartakeQuantity"].Value) * Validation.GetSafeDecimal(grdBartake.Rows[e.RowIndex].Cells["colBartakeRates"].Value);
            }
        }
        private void grdBartake_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdBartake_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdBartake.CurrentCellAddress.X == 7)
            {
                TextBox txtBartakeVendorName = e.Control as TextBox;
                if (txtBartakeVendorName != null)
                {
                    txtBartakeVendorName.KeyPress -= new KeyPressEventHandler(txtBartakeVendorName_KeyPress);
                    txtBartakeVendorName.KeyPress += new KeyPressEventHandler(txtBartakeVendorName_KeyPress);
                }
            }
            else if (grdBartake.CurrentCellAddress.X == 8)
            {
                TextBox txtFinishedProduct = e.Control as TextBox;
                if (txtFinishedProduct != null)
                {
                    txtFinishedProduct.KeyPress -= new KeyPressEventHandler(txtFinishedProduct_KeyPress);
                    txtFinishedProduct.KeyPress += new KeyPressEventHandler(txtFinishedProduct_KeyPress);
                }
            }
        }
        void txtBartakeVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdBartake.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Bartake";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        void txtFinishedProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdBartake.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Bartake Article";
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
        #endregion
        #region Bartake/kaaj/Button Material Grid Events
        private void grdBartakeMaterials_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdBartakeMaterials_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            #region Variables
            var Manager = new ItemsBLL();
            string ProcessName = "Garments Feedo/Saftey";
            #endregion
            #region Closing Stock And Average Calculating Region
            if (e.ColumnIndex == 10)
            {

                if (Validation.GetSafeLong(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialItemType"].Value) == 1)
                {
                    ProcessQuantity = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialIdItem"].Value))[0].Qty;
                }
                else if (Validation.GetSafeGuid(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialColors"].Value) != Guid.Empty)
                {
                    ProcessQuantity = GetGarmentsProductionClosingStockByCustomerPO(Validation.GetSafeGuid(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialIdItem"].Value), Validation.GetSafeGuid(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialColors"].Value), Validation.GetSafeLong(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialBundleNo"].Value), ProcessName, "Garments Bartake/Kaaj/Buttons Material Usage");
                }
                else
                {
                    MessageBox.Show("Please Select Article Color....");
                    return;
                }
                if (Validation.GetSafeDecimal(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialQuantity"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity in this Bundle Number" + Validation.GetSafeString(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialBundleNo"].Value));
                    grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialQuantity"].Value = "";
                    grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialRate"].Value = "";
                    grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialAmount"].Value = "";

                }
                else
                {
                    /// Calculating Average Value Here....
                    if (Validation.GetSafeLong(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialItemType"].Value) == 1)
                    {
                        grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialRate"].Value = Manager.GetItemsAvgValue(Validation.GetSafeGuid(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialIdItem"].Value)).ToString("0.00");
                        grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialAmount"].Value = (Validation.GetSafeDecimal(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialQuantity"].Value)
                                                                                                               * Validation.GetSafeDecimal(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialRate"].Value)).ToString("0.00");
                    }
                    else
                    {
                        if (grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialQuantity"].Value != null && Validation.GetSafeDecimal(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialQuantity"].Value) > 0)
                        {

                            grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialRate"].Value = GetGarmentsAvgCostingByCustomerPO(Validation.GetSafeGuid(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialIdItem"].Value), Validation.GetSafeGuid(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialColors"].Value), ProcessName, "Garments Feedo material Usage").ToString("0.00");
                            grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialAmount"].Value = (Validation.GetSafeDecimal(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialQuantity"].Value)
                                                                                                                    * Validation.GetSafeDecimal(grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialRate"].Value)).ToString("0.00");
                        }
                        else
                        {
                            grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialRate"].Value = "";
                            grdBartakeMaterials.Rows[e.RowIndex].Cells["colBartakeMaterialAmount"].Value = "";
                        }
                    }
                }
            }
            #endregion
        }
        private void grdBartakeMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdBartakeMaterials.CurrentCellAddress.X == 5)
            {
                TextBox txtBartakeMaterialName = e.Control as TextBox;
                txtBartakeMaterialName.KeyPress -= new KeyPressEventHandler(txtBartakeMaterialName_KeyPress);
                txtBartakeMaterialName.KeyPress += new KeyPressEventHandler(txtBartakeMaterialName_KeyPress);
            }
            else if (grdBartakeMaterials.CurrentCellAddress.X == 7)
            {
                TextBox txtBartakeMaterialWorkerName = e.Control as TextBox;
                txtBartakeMaterialWorkerName.KeyPress -= new KeyPressEventHandler(txtBartakeMaterialWorkerName_KeyPress);
                txtBartakeMaterialWorkerName.KeyPress += new KeyPressEventHandler(txtBartakeMaterialWorkerName_KeyPress);
            }
        }
        void txtBartakeMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdBartakeMaterials.CurrentCellAddress.X == 5)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garment Bartake Material";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        void txtBartakeMaterialWorkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdBartakeMaterials.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garment Bartake Material Worker";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        #region Threading Grid Events
        private void grdThreading_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (grdThreading.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdThreading_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 10)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 12)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdThreading_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 16)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 17)
            {
                e.Value = "Post";
            }
        }
        private void grdThreading_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 16)
            {
                if (Validation.GetSafeGuid(grdThreading.Rows[e.RowIndex].Cells["colIdThreading"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdThreading.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdThreading.Rows[e.RowIndex].Cells["colIdThreading"].Value), Validation.GetSafeGuid(grdThreading.Rows[e.RowIndex].Cells["colThreadingIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdThreading.Columns.Count; i++)
                    {
                        grdThreading.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 17)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(5))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.AccountNo = "0";
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 2;

                    if (IdThreading == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdThreading;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Threading";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = oelProductionHead.IdVoucher;
                    if (grdThreading.Rows[e.RowIndex].Cells["colIdThreading"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdThreading.Rows[e.RowIndex].Cells["colIdThreading"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdThreading.Rows[e.RowIndex].Cells["colIdThreading"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdThreading.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingAccountNo"].Value);
                    oelProductionDetail.StitcherAccountNo = "";
                    EmpAccountNo = Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.ProductionProcessName = "Garments Threading";
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdThreading.Rows[e.RowIndex].Cells["colThreadingIdItem"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingSizes"].Value);
                    if (Validation.GetSafeGuid(grdThreading.Rows[e.RowIndex].Cells["colThreadingColors"].Value) == Guid.Empty)
                    {
                        MessageBox.Show("Please Select Color...");
                        return;
                    }
                    oelProductionDetail.IdColor = Validation.GetSafeGuid(grdThreading.Rows[e.RowIndex].Cells["colThreadingColors"].Value);

                    if (Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingOrderType"].Value) == "Cover All")
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else if (Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingOrderType"].Value) == "Pant & Shirt")
                    {
                        oelProductionDetail.GType = 2;
                    }
                    oelProductionDetail.GarmentWorkType = 0;
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdThreading.Rows[e.RowIndex].Cells["colThreadingQuantity"].Value);
                    oelProductionDetail.BundleNo = Validation.GetSafeLong(grdThreading.Rows[e.RowIndex].Cells["colThreadingBundleNumber"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.Meters = 0;
                    oelProductionDetail.PStyle = "";
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdThreading.Rows[e.RowIndex].Cells["colThreadingWorkDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdThreading.Rows[e.RowIndex].Cells["colThreadingRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdThreading.Rows[e.RowIndex].Cells["colThreadingAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }
                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdThreading = oelProductionProcess.IdProductionProcess;
                            //if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingAccountType"].Value) == "Employees")
                                {
                                    grdThreading.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted.....");
                                }
                                else if (Validation.GetSafeString(grdThreading.Rows[e.RowIndex].Cells["colThreadingAccountType"].Value) != "Employees")
                                {
                                    //frmworkpurchases = new frmWorkPurchases();
                                    //frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //frmworkpurchases.IdEntity = IdEntity;
                                    //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //frmworkpurchases.PurchasesType = "Garments Threading Purchases";
                                    //frmworkpurchases.ProcessName = "Garments Threading";
                                    //frmworkpurchases.ProcessAmount = postAmount;
                                    //frmworkpurchases.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        //frmworkpurchases = new frmWorkPurchases();
                        //frmworkpurchases.ProductionType = "Garments / Gloves";
                        //frmworkpurchases.IdEntity = IdEntity;
                        //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        //frmworkpurchases.EmpAccountName = EmpAccountName;
                        //frmworkpurchases.PurchasesType = "Garments Threading Purchases";
                        //frmworkpurchases.ProcessName = "Garments Threading";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
        }
        private void grdThreading_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                #region Variables
                var Manager = new ItemsBLL();
                string ProcessName = "Garments Bartake/Kaaj/Buttons";
                #endregion
                #region Closing Stock Check Region
                
                if (Validation.GetSafeGuid(grdThreading.Rows[e.RowIndex].Cells["colThreadingColors"].Value) != Guid.Empty)
                {
                    ProcessQuantity = GetGarmentsProductionClosingStockByCustomerPO(Validation.GetSafeGuid(grdThreading.Rows[e.RowIndex].Cells["colThreadingIdItem"].Value), Validation.GetSafeGuid(grdThreading.Rows[e.RowIndex].Cells["colThreadingColors"].Value), Validation.GetSafeLong(grdThreading.Rows[e.RowIndex].Cells["colThreadingBundleNumber"].Value), ProcessName, "Garments Threading");
                }
                else
                {
                    MessageBox.Show("Please Select Article Color....");
                    return;
                }
                if (Validation.GetSafeDecimal(grdThreading.Rows[e.RowIndex].Cells["colThreadingQuantity"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdThreading.Rows[e.RowIndex].Cells["colThreadingArticleName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                    grdThreading.Rows[e.RowIndex].Cells["colThreadingQuantity"].Value = "";
                    grdThreading.Rows[e.RowIndex].Cells["colThreadingRate"].Value = "";
                    grdThreading.Rows[e.RowIndex].Cells["colThreadingAmount"].Value = "";

                }

                #endregion
            }
            else if (e.ColumnIndex == 14)
            {
                grdThreading.Rows[e.RowIndex].Cells["colThreadingAmount"].Value = Validation.GetSafeDecimal(grdThreading.Rows[e.RowIndex].Cells["colThreadingQuantity"].Value) * Validation.GetSafeDecimal(grdThreading.Rows[e.RowIndex].Cells["colThreadingRate"].Value);
            }
        }
        private void grdThreading_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdThreading_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdThreading.CurrentCellAddress.X == 7)
            {
                TextBox txtThreadingVendorName = e.Control as TextBox;
                if (txtThreadingVendorName != null)
                {
                    txtThreadingVendorName.KeyPress -= new KeyPressEventHandler(txtThreadingVendorName_KeyPress);
                    txtThreadingVendorName.KeyPress += new KeyPressEventHandler(txtThreadingVendorName_KeyPress);
                }
            }
            else if (grdThreading.CurrentCellAddress.X == 8)
            {
                TextBox txtThreadingArticleName = e.Control as TextBox;
                if (txtThreadingArticleName != null)
                {
                    txtThreadingArticleName.KeyPress -= new KeyPressEventHandler(txtThreadingArticleName_KeyPress);
                    txtThreadingArticleName.KeyPress += new KeyPressEventHandler(txtThreadingArticleName_KeyPress);
                }
            }
        }
        void txtThreadingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdThreading.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Threading";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        void txtThreadingArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdThreading.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garments Threading Article";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Inspection Grid Events
        private void grdInspection_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (grdInspection.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdInspection_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 18)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 19)
            {
                e.Value = "Posting";
            }
        }
        private void grdInspection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 18)
            {
                if (Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdInspection.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value), Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdInspection.Columns.Count; i++)
                    {
                        grdInspection.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 19)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(6))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.AccountNo = "0";
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 2;

                    if (IdInspection == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdInspection;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Inspection";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = oelProductionHead.IdVoucher;
                    if (grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdInspection.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionAccountNo"].Value);
                    oelProductionDetail.StitcherAccountNo = "0";
                    EmpAccountNo = Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.ProductionProcessName = "Garments Inspection";
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionIdItem"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionSizes"].Value);
                    if (Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionColors"].Value) == Guid.Empty)
                    {
                        MessageBox.Show("Please Select Color...");
                        return;
                    }
                    oelProductionDetail.IdColor = Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionColors"].Value);
                    if (Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionOrderType"].Value) == "Cover All")
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else if (Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionOrderType"].Value) == "Pant & Shirt")
                    {
                        oelProductionDetail.GType = 2;
                    }
                    oelProductionDetail.GarmentWorkType = 0;
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Meters = 0;
                    oelProductionDetail.PStyle = "";
                    oelProductionDetail.BundleNo = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionBundleNumber"].Value);
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value);
                    oelProductionDetail.ReadyUnits = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionPassQuantity"].Value);
                    oelProductionDetail.Rejection = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionRejectedQuantity"].Value); ;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdInspection.Rows[e.RowIndex].Cells["colInspectionWorkingDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }
                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdInspection = oelProductionProcess.IdProductionProcess;
                            //if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionAccountType"].Value) == "Employees")
                                {
                                    grdInspection.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted.....");
                                }
                                else if (Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionAccountType"].Value) != "Employees")
                                {
                                    //frmworkpurchases = new frmWorkPurchases();
                                    //frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //frmworkpurchases.IdEntity = IdEntity;
                                    //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //frmworkpurchases.PurchasesType = "Garments Inspection Purchases";
                                    //frmworkpurchases.ProcessName = "Garments Inspection";
                                    //frmworkpurchases.ProcessAmount = postAmount;
                                    //frmworkpurchases.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        //frmworkpurchases = new frmWorkPurchases();
                        //frmworkpurchases.ProductionType = "Garments / Gloves";
                        //frmworkpurchases.IdEntity = IdEntity;
                        //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        //frmworkpurchases.EmpAccountName = EmpAccountName;
                        //frmworkpurchases.PurchasesType = "Garments Inspection Purchases";
                        //frmworkpurchases.ProcessName = "Inspection";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
        }
        private void grdInspection_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 10)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdInspection_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                #region Variables
                var Manager = new ItemsBLL();
                string ProcessName = "Garments Threading";
                #endregion
                #region Closing Stock Check Region
                
                if (Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionColors"].Value) != Guid.Empty)
                {
                    ProcessQuantity = GetGarmentsProductionClosingStockByCustomerPO(Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionIdItem"].Value), Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionColors"].Value), Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionBundleNumber"].Value), ProcessName, "Garments Inspection");
                }
                else
                {
                    MessageBox.Show("Please Select Article Color....");
                    return;
                }
                if (Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdInspection.Rows[e.RowIndex].Cells["colInspectionArticleName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                    grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value = "";
                    grdInspection.Rows[e.RowIndex].Cells["colInspectionRate"].Value = "";
                    grdInspection.Rows[e.RowIndex].Cells["colInspectionAmount"].Value = "";

                }

                #endregion
            }
            else if (e.ColumnIndex == 16)
            {
                grdInspection.Rows[e.RowIndex].Cells["colInspectionAmount"].Value = Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value) * Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionRate"].Value);
            }
        }
        private void grdInspection_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdInspection_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdInspection.CurrentCellAddress.X == 7)
            {
                TextBox txtInspectionVendorName = e.Control as TextBox;
                if (txtInspectionVendorName != null)
                {
                    txtInspectionVendorName.KeyPress -= new KeyPressEventHandler(txtInspectionVendorName_KeyPress);
                    txtInspectionVendorName.KeyPress += new KeyPressEventHandler(txtInspectionVendorName_KeyPress);
                }
            }
            else if (grdInspection.CurrentCellAddress.X == 8)
            {
                TextBox txtInspectionArticleName = e.Control as TextBox;
                if (txtInspectionArticleName != null)
                {
                    txtInspectionArticleName.KeyPress -= new KeyPressEventHandler(txtInspectionArticleName_KeyPress);
                    txtInspectionArticleName.KeyPress += new KeyPressEventHandler(txtInspectionArticleName_KeyPress);
                }
            }
        }
        void txtInspectionVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdInspection.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Inspection";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        void txtInspectionArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdInspection.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garments Inspection Article";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Press Grid Events
        private void grdPress_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (grdPress.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdPress_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 18)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 19)
            {
                e.Value = "Post";
            }
        }
        private void grdPress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 18)
            {
                if (Validation.GetSafeGuid(grdPress.Rows[e.RowIndex].Cells["colIdPress"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdPress.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdPress.Rows[e.RowIndex].Cells["colIdPress"].Value), Validation.GetSafeGuid(grdPress.Rows[e.RowIndex].Cells["colPressIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdPress.Columns.Count; i++)
                    {
                        grdPress.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 19)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(7))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.AccountNo = "0";
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 2;

                    if (IdPress == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdPress;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Press";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = oelProductionHead.IdVoucher;
                    if (grdPress.Rows[e.RowIndex].Cells["colIdPress"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdPress.Rows[e.RowIndex].Cells["colIdPress"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdPress.Rows[e.RowIndex].Cells["colIdPress"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdPress.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressAccountNo"].Value);
                    oelProductionDetail.StitcherAccountNo = "0";
                    EmpAccountNo = Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.ProductionProcessName = "Garments Press";
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdPress.Rows[e.RowIndex].Cells["colPressIdItem"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressSizes"].Value);
                    if (Validation.GetSafeGuid(grdPress.Rows[e.RowIndex].Cells["colpressColors"].Value) == Guid.Empty)
                    {
                        MessageBox.Show("Please Select Color...");
                        return;
                    }
                    oelProductionDetail.IdColor = Validation.GetSafeGuid(grdPress.Rows[e.RowIndex].Cells["colpressColors"].Value);
                    if (Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressOrderType"].Value) == "Cover All")
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else if (Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressOrderType"].Value) == "Pant & Shirt")
                    {
                        oelProductionDetail.GType = 2;
                    }
                    oelProductionDetail.GarmentWorkType = 0;
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Meters = 0;
                    oelProductionDetail.BundleNo = Validation.GetSafeLong(grdPress.Rows[e.RowIndex].Cells["colPressBundleNumber"].Value);
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdPress.Rows[e.RowIndex].Cells["colPressQuantity"].Value);
                    oelProductionDetail.ReadyUnits = Validation.GetSafeLong(grdPress.Rows[e.RowIndex].Cells["colPressReadyUnits"].Value);
                    oelProductionDetail.Rejection = Validation.GetSafeLong(grdPress.Rows[e.RowIndex].Cells["colPressRejection"].Value);
                    oelProductionDetail.PStyle = string.Empty;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdPress.Rows[e.RowIndex].Cells["colPressWorkDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdPress.Rows[e.RowIndex].Cells["colPressRates"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdPress.Rows[e.RowIndex].Cells["colPressAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }
                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdPress = oelProductionProcess.IdProductionProcess;
                            //if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressAccountType"].Value) == "Employees")
                                {
                                    grdPress.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted.....");
                                }
                                else if (Validation.GetSafeString(grdPress.Rows[e.RowIndex].Cells["colPressAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Garments Press Purchases";
                                    frmworkpurchases.ProcessName = "Garments Press";
                                    frmworkpurchases.ProcessAmount = postAmount;
                                    frmworkpurchases.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        frmworkpurchases = new frmWorkPurchases();
                        frmworkpurchases.ProductionType = "Garments / Gloves";
                        frmworkpurchases.IdEntity = IdEntity;
                        frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        frmworkpurchases.EmpAccountName = EmpAccountName;
                        frmworkpurchases.PurchasesType = "Garments Press Purchases";
                        frmworkpurchases.ProcessName = "Garment Press";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
        }
        private void grdPress_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 10)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdPress_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                #region Variables
                var Manager = new ItemsBLL();
                string ProcessName = "Garments Inspection";
                #endregion
                #region Closing Stock Check Region

                if (Validation.GetSafeGuid(grdPress.Rows[e.RowIndex].Cells["colpressColors"].Value) != Guid.Empty)
                {
                    ProcessQuantity = GetGarmentsProductionClosingStockByCustomerPO(Validation.GetSafeGuid(grdPress.Rows[e.RowIndex].Cells["colPressIdItem"].Value), Validation.GetSafeGuid(grdPress.Rows[e.RowIndex].Cells["colpressColors"].Value), Validation.GetSafeLong(grdPress.Rows[e.RowIndex].Cells["colPressBundleNumber"].Value), ProcessName, "Garments Press");
                }
                else
                {
                    MessageBox.Show("Please Select Article Color....");
                    return;
                }
                if (Validation.GetSafeDecimal(grdPress.Rows[e.RowIndex].Cells["colPressQuantity"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdPress.Rows[e.RowIndex].Cells["colPressArticleName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                    grdPress.Rows[e.RowIndex].Cells["colPressQuantity"].Value = "";
                    grdPress.Rows[e.RowIndex].Cells["colPressRates"].Value = "";
                    grdPress.Rows[e.RowIndex].Cells["colPressAmount"].Value = "";

                }

                #endregion
            }
            else if (e.ColumnIndex == 16)
            {
                grdPress.Rows[e.RowIndex].Cells["colPressAmount"].Value = Validation.GetSafeDecimal(grdPress.Rows[e.RowIndex].Cells["colPressQuantity"].Value) * Validation.GetSafeDecimal(grdPress.Rows[e.RowIndex].Cells["colPressRates"].Value);
            }
        }
        private void grdPress_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdPress_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdPress.CurrentCellAddress.X == 7)
            {
                TextBox txtPressVendorName = e.Control as TextBox;
                if (txtPressVendorName != null)
                {
                    txtPressVendorName.KeyPress -= new KeyPressEventHandler(txtPressVendorName_KeyPress);
                    txtPressVendorName.KeyPress += new KeyPressEventHandler(txtPressVendorName_KeyPress);
                }
            }
            else if (grdPress.CurrentCellAddress.X == 8)
            {
                TextBox txtPressArticleName = e.Control as TextBox;
                if (txtPressArticleName != null)
                {
                    txtPressArticleName.KeyPress -= new KeyPressEventHandler(txtPressArticleName_KeyPress);
                    txtPressArticleName.KeyPress += new KeyPressEventHandler(txtPressArticleName_KeyPress);
                }
            }
        }
        void txtPressVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPress.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Pressing";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        void txtPressArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPress.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garments Press Article";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Packing Grid Events
        private void grdPacking_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (grdPacking.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdPacking_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 17)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 18)
            {
                e.Value = "Post";
            }
        }
        private void grdPacking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 17)
            {
                if (Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (grdPacking.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    else
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value), Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colPackingIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdPacking.Columns.Count; i++)
                    {
                        grdPacking.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insetion / Updation
            else if (e.ColumnIndex == 18)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(8))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelProductionHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionHead.IdVoucher = IdVoucher;
                    }
                    oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelProductionHead.AccountNo = "0";
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 2;

                    if (IdPacking == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdPacking;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Garments Packing";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = oelProductionHead.IdVoucher;
                    if (grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdPacking.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingAccountNo"].Value);
                    oelProductionDetail.StitcherAccountNo = "0";
                    EmpAccountNo = Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.ProductionProcessName = "Garments Packing";
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colPackingIdItem"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingSizes"].Value);
                    if (Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colPackingColors"].Value) == Guid.Empty)
                    {
                        MessageBox.Show("Please Select Color...");
                        return;
                    }
                    oelProductionDetail.IdColor = Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colPackingColors"].Value);
                    if (Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingOrderType"].Value) == "Cover All")
                    {
                        oelProductionDetail.GType = 1;
                    }
                    else if (Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingOrderType"].Value) == "Pant & Shirt")
                    {
                        oelProductionDetail.GType = 2;
                    }
                    oelProductionDetail.GarmentWorkType = 0;
                    oelProductionDetail.Quality = 0;

                    oelProductionDetail.BundleNo = Validation.GetSafeLong(grdPacking.Rows[e.RowIndex].Cells["colPackingBundleNumber"].Value);
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value);
                    oelProductionDetail.ReadyUnits = Validation.GetSafeLong(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value);
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.Meters = 0;
                    oelProductionDetail.PStyle = Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingStyle"].Value);
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdPacking.Rows[e.RowIndex].Cells["colPackingWorkDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingRates"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingAccountType"].Value) == "Employees")
                    {
                        oelProductionDetail.Posted = true;
                    }
                    else
                    {
                        oelProductionDetail.Posted = false;
                    }
                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdPacking = oelProductionProcess.IdProductionProcess;
                            //if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingAccountType"].Value) == "Employees")
                                {
                                    grdPacking.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted.....");
                                }
                                else if (Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingAccountType"].Value) != "Employees")
                                {
                                    frmworkpurchases = new frmWorkPurchases();
                                    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    frmworkpurchases.IdEntity = IdEntity;
                                    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    frmworkpurchases.PurchasesType = "Garments Packing Purchases";
                                    frmworkpurchases.ProcessName = "Garments Packing";
                                    frmworkpurchases.ProcessAmount = postAmount;
                                    frmworkpurchases.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        frmworkpurchases = new frmWorkPurchases();
                        frmworkpurchases.ProductionType = "Garments / Gloves";
                        frmworkpurchases.IdEntity = IdEntity;
                        frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        frmworkpurchases.EmpAccountName = EmpAccountName;
                        frmworkpurchases.PurchasesType = "Garments Packing Purchases";
                        frmworkpurchases.ProcessName = "Garments Packing";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
        }
        private void grdPacking_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 10)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 12)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdPacking_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 15)
            {
                grdPacking.Rows[e.RowIndex].Cells["colPackingAmount"].Value = Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value) * Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingRates"].Value);
            }
        }
        private void grdPacking_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdPacking_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdPacking.CurrentCellAddress.X == 7)
            {
                TextBox txtPackingVendorName = e.Control as TextBox;
                if (txtPackingVendorName != null)
                {
                    txtPackingVendorName.KeyPress -= new KeyPressEventHandler(txtPackingVendorName_KeyPress);
                    txtPackingVendorName.KeyPress += new KeyPressEventHandler(txtPackingVendorName_KeyPress);
                }
            }
            if (grdPacking.CurrentCellAddress.X == 8)
            {
                TextBox txtPackingArticleName = e.Control as TextBox;
                if (txtPackingArticleName != null)
                {
                    txtPackingArticleName.KeyPress -= new KeyPressEventHandler(txtPackingArticleName_KeyPress);
                    txtPackingArticleName.KeyPress += new KeyPressEventHandler(txtPackingArticleName_KeyPress);
                }
            }
        }
        void txtPackingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPacking.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garments Packing";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        void txtPackingArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPacking.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garments Packing Article";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Packing Material Grid Events
        private void grdPackingMaterials_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            #region Variables
            var Manager = new ItemsBLL();
            string ProcessName = "Garments Press";
            #endregion
            #region Closing Stock And Average Calculating Region
            if (e.ColumnIndex == 10)
            {

                if (Validation.GetSafeLong(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialItemType"].Value) == 1)
                {
                    ProcessQuantity = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialIdItem"].Value))[0].Qty;
                }
                else if (Validation.GetSafeGuid(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialColors"].Value) != Guid.Empty)
                {
                    ProcessQuantity = GetGarmentsProductionClosingStockByCustomerPO(Validation.GetSafeGuid(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialIdItem"].Value), Validation.GetSafeGuid(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialColors"].Value), Validation.GetSafeLong(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialBundleNo"].Value), ProcessName, "Garments Packing Material Usage");
                }
                else
                {
                    MessageBox.Show("Please Select Article Color....");
                    return;
                }
                if (Validation.GetSafeDecimal(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialQuantity"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                    grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialQuantity"].Value = "";
                    grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialRate"].Value = "";
                    grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialAmount"].Value = "";

                }
                else
                {
                    /// Calculating Average Value Here....
                    if (Validation.GetSafeLong(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialItemType"].Value) == 1)
                    {
                        grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialRate"].Value = Manager.GetItemsAvgValue(Validation.GetSafeGuid(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialIdItem"].Value)).ToString("0.00");
                        grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialAmount"].Value = (Validation.GetSafeDecimal(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialQuantity"].Value)
                                                                                                               * Validation.GetSafeDecimal(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialRate"].Value)).ToString("0.00");
                    }
                    else
                    {
                        if (grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialQuantity"].Value != null && Validation.GetSafeDecimal(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialQuantity"].Value) > 0)
                        {

                            grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialRate"].Value = GetGarmentsAvgCostingByCustomerPO(Validation.GetSafeGuid(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialIdItem"].Value), Validation.GetSafeGuid(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialColors"].Value), "Garments Packing", "Garments Packing").ToString("0.00");
                            grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialAmount"].Value = (Validation.GetSafeDecimal(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialQuantity"].Value)
                                                                                                                    * Validation.GetSafeDecimal(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialRate"].Value)).ToString("0.00");
                        }
                        else
                        {
                            grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialRate"].Value = "";
                            grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialAmount"].Value = "";
                        }
                    }
                }
            }
            #endregion
        }
        private void grdPackingMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdPackingMaterials.CurrentCellAddress.X == 5)
            {
                TextBox txtPackingMaterialName = e.Control as TextBox;
                txtPackingMaterialName.KeyPress -= new KeyPressEventHandler(txtPackingMaterialName_KeyPress);
                txtPackingMaterialName.KeyPress += new KeyPressEventHandler(txtPackingMaterialName_KeyPress);
            }
            else if (grdPackingMaterials.CurrentCellAddress.X == 7)
            {
                TextBox txtPackingMaterialWorkerName = e.Control as TextBox;
                txtPackingMaterialWorkerName.KeyPress -= new KeyPressEventHandler(txtPackingMaterialWorkerName_KeyPress);
                txtPackingMaterialWorkerName.KeyPress += new KeyPressEventHandler(txtPackingMaterialWorkerName_KeyPress);
            }
        }
        void txtPackingMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPackingMaterials.CurrentCellAddress.X == 5)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garment Packing Material";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        void txtPackingMaterialWorkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPackingMaterials.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Garment Packing Material Worker";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        #region OverHeads Grid Events
        private void grdMiscCost_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (grdMiscCost.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdMiscCost_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                e.Value = "Delete";
            }
        }
        private void grdMiscCost_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdMiscCost.CurrentCellAddress.X == 3)
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
            if (grdMiscCost.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "OverHeads";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
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
        #region Common Events
        void frmfindAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            #region OutPut Workers Grids
            if (EventFiringName == "Garments Cutting")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdCutting.CurrentRow.Cells["colCuttingAccountNo"].Value = oelAccount.AccountNo;
                    grdCutting.CurrentRow.Cells["colCuttingVendorName"].Value = oelAccount.AccountName;
                    grdCutting.CurrentRow.Cells["colCuttingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Garments Stitching")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdStitching.CurrentRow.Cells["colStitchingAccountNo"].Value = oelAccount.AccountNo;
                    grdStitching.CurrentRow.Cells["colStitchingVendorName"].Value = oelAccount.AccountName;
                    grdStitching.CurrentRow.Cells["colStitchingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Garments Feedo")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdFeedoSaftey.CurrentRow.Cells["colFeedoAccountNo"].Value = oelAccount.AccountNo;
                    grdFeedoSaftey.CurrentRow.Cells["colFeedoVendorName"].Value = oelAccount.AccountName;
                    grdFeedoSaftey.CurrentRow.Cells["colFeedoAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Garments Bartake")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdBartake.CurrentRow.Cells["colBartakeAccountNo"].Value = oelAccount.AccountNo;
                    grdBartake.CurrentRow.Cells["colBartakeVendorName"].Value = oelAccount.AccountName;
                    grdBartake.CurrentRow.Cells["colBartakeAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Garments Threading")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdThreading.CurrentRow.Cells["colThreadingAccountNo"].Value = oelAccount.AccountNo;
                    grdThreading.CurrentRow.Cells["colThreadingVendorName"].Value = oelAccount.AccountName;
                    grdThreading.CurrentRow.Cells["colThreadingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Garments Inspection")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdInspection.CurrentRow.Cells["colInspectionAccountNo"].Value = oelAccount.AccountNo;
                    grdInspection.CurrentRow.Cells["colInspectionVendorName"].Value = oelAccount.AccountName;
                    grdInspection.CurrentRow.Cells["colInspectionAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Garments Pressing")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdPress.CurrentRow.Cells["colPressAccountNo"].Value = oelAccount.AccountNo;
                    grdPress.CurrentRow.Cells["colPressVendorName"].Value = oelAccount.AccountName;
                    grdPress.CurrentRow.Cells["colPressAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Garments Packing")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdPacking.CurrentRow.Cells["colPackingAccountNo"].Value = oelAccount.AccountNo;
                    grdPacking.CurrentRow.Cells["colPackingVendorName"].Value = oelAccount.AccountName;
                    grdPacking.CurrentRow.Cells["colPackingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            #endregion
            #region Materials Workers Grids
            else if (EventFiringName == "Garments Cutting Material Worker")
            {
                grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialAccountNo"].Value = oelAccount.AccountNo;
                grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialWorkerName"].Value = oelAccount.AccountName;
            }
            else if (EventFiringName == "Garments Stitching Material Worker")
            {
                grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialAccountNo"].Value = oelAccount.AccountNo;
                grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialWorkerName"].Value = oelAccount.AccountName;
            }
            else if (EventFiringName == "Garment Feedo/Saftey Worker")
            {
                grdFeedoMaterials.CurrentRow.Cells["colFeedoMaterialAccountNo"].Value = oelAccount.AccountNo;
                grdFeedoMaterials.CurrentRow.Cells["colFeedoMaterialWorkerName"].Value = oelAccount.AccountName;
            }
            else if (EventFiringName == "Garment Bartake Material Worker")
            {
                grdBartakeMaterials.CurrentRow.Cells["colBartakeMaterialAccountNo"].Value = oelAccount.AccountNo;
                grdBartakeMaterials.CurrentRow.Cells["colBartakeMaterialWorkerName"].Value = oelAccount.AccountName;
            }
            else if (EventFiringName == "Garment Packing Material Worker")
            {
                grdPackingMaterials.CurrentRow.Cells["colPackingMaterialAccountNo"].Value = oelAccount.AccountNo;
                grdPackingMaterials.CurrentRow.Cells["colPackingMaterialWorkerName"].Value = oelAccount.AccountName;
            }
            #endregion
            #region OverHead Grids
            else if (EventFiringName == "OverHeads")
            {
                grdMiscCost.CurrentRow.Cells["colAccountNo"].Value = oelAccount.AccountNo;
                grdMiscCost.CurrentRow.Cells["colAccountName"].Value = oelAccount.AccountName;
            }
            #endregion
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            #region Output Article Grids Events
            if (EventFiringName == "Garments Cutting Article")
            {
                grdCutting.CurrentRow.Cells["colCuttingIdItem"].Value = oelItems.IdItem;
                grdCutting.CurrentRow.Cells["colCuttingClotheName"].Value = oelItems.ItemName;

                DataGridViewComboBoxCell cbxGarmentsCuttingColors = grdCutting.CurrentRow.Cells["colCuttingColors"] as DataGridViewComboBoxCell;
                if (cbxGarmentsCuttingColors != null)
                {
                    cbxGarmentsCuttingColors.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                    cbxGarmentsCuttingColors.DisplayMember = "ItemColor";
                    cbxGarmentsCuttingColors.ValueMember = "IdColor";
                }
            }
            else if (EventFiringName == "Garments Stitching Article")
            {
                grdStitching.CurrentRow.Cells["colStitchingIdItem"].Value = oelItems.IdItem;
                grdStitching.CurrentRow.Cells["colStitchingArticleName"].Value = oelItems.ItemName;
                DataGridViewComboBoxCell cbxGarmentsStitchingColors = grdStitching.CurrentRow.Cells["colStitchingColors"] as DataGridViewComboBoxCell;
                if (cbxGarmentsStitchingColors != null)
                {
                    cbxGarmentsStitchingColors.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                    cbxGarmentsStitchingColors.DisplayMember = "ItemColor";
                    cbxGarmentsStitchingColors.ValueMember = "IdColor";
                }
            }
            else if (EventFiringName == "Garments Bartake Article")
            {
                grdBartake.CurrentRow.Cells["colBartakeIdItem"].Value = oelItems.IdItem;
                grdBartake.CurrentRow.Cells["colBartakeFinishedGoods"].Value = oelItems.ItemName;
                DataGridViewComboBoxCell cbxGarmentsBartakeColors = grdBartake.CurrentRow.Cells["colBartakeColors"] as DataGridViewComboBoxCell;
                if (cbxGarmentsBartakeColors != null)
                {
                    cbxGarmentsBartakeColors.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                    cbxGarmentsBartakeColors.DisplayMember = "ItemColor";
                    cbxGarmentsBartakeColors.ValueMember = "IdColor";
                }
            }
            else if (EventFiringName == "Garments Feedo Article")
            {
                grdFeedoSaftey.CurrentRow.Cells["colFeedoIdItem"].Value = oelItems.IdItem;
                grdFeedoSaftey.CurrentRow.Cells["colFeedoArticleName"].Value = oelItems.ItemName;
                DataGridViewComboBoxCell cbxGarmentsFeedoColors = grdFeedoSaftey.CurrentRow.Cells["colFeedoColors"] as DataGridViewComboBoxCell;
                if (cbxGarmentsFeedoColors != null)
                {
                    cbxGarmentsFeedoColors.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                    cbxGarmentsFeedoColors.DisplayMember = "ItemColor";
                    cbxGarmentsFeedoColors.ValueMember = "IdColor";
                }
            }
            else if (EventFiringName == "Garments Threading Article")
            {
                grdThreading.CurrentRow.Cells["colThreadingIdItem"].Value = oelItems.IdItem;
                grdThreading.CurrentRow.Cells["colThreadingArticleName"].Value = oelItems.ItemName;
                DataGridViewComboBoxCell cbxGarmentsThreadingColors = grdThreading.CurrentRow.Cells["colThreadingColors"] as DataGridViewComboBoxCell;
                if (cbxGarmentsThreadingColors != null)
                {
                    cbxGarmentsThreadingColors.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                    cbxGarmentsThreadingColors.DisplayMember = "ItemColor";
                    cbxGarmentsThreadingColors.ValueMember = "IdColor";
                }
            }
            else if (EventFiringName == "Garments Press Article")
            {
                grdPress.CurrentRow.Cells["colPressIdItem"].Value = oelItems.IdItem;
                grdPress.CurrentRow.Cells["colPressArticleName"].Value = oelItems.ItemName;
                DataGridViewComboBoxCell cbxGarmentsPressColors = grdPress.CurrentRow.Cells["colpressColors"] as DataGridViewComboBoxCell;
                if (cbxGarmentsPressColors != null)
                {
                    cbxGarmentsPressColors.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                    cbxGarmentsPressColors.DisplayMember = "ItemColor";
                    cbxGarmentsPressColors.ValueMember = "IdColor";
                }
            }
            else if (EventFiringName == "Garments Inspection Article")
            {
                grdInspection.CurrentRow.Cells["colInspectionIdItem"].Value = oelItems.IdItem;
                grdInspection.CurrentRow.Cells["colInspectionArticleName"].Value = oelItems.ItemName;
                DataGridViewComboBoxCell cbxGarmentsInspectionColors = grdInspection.CurrentRow.Cells["colInspectionColors"] as DataGridViewComboBoxCell;
                if (cbxGarmentsInspectionColors != null)
                {
                    cbxGarmentsInspectionColors.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                    cbxGarmentsInspectionColors.DisplayMember = "ItemColor";
                    cbxGarmentsInspectionColors.ValueMember = "IdColor";
                }
            }
            //else if (EventFiringName == "Garments Packing")
            else if (EventFiringName == "Garments Packing Article")
            {
                grdPacking.CurrentRow.Cells["colPackingIdItem"].Value = oelItems.IdItem;
                grdPacking.CurrentRow.Cells["colPackingArticleName"].Value = oelItems.ItemName;
                DataGridViewComboBoxCell cbxGarmentsPackingColors = grdPacking.CurrentRow.Cells["colPackingColors"] as DataGridViewComboBoxCell;
                if (cbxGarmentsPackingColors != null)
                {
                    cbxGarmentsPackingColors.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                    cbxGarmentsPackingColors.DisplayMember = "ItemColor";
                    cbxGarmentsPackingColors.ValueMember = "IdColor";
                }
            }
            #endregion
            #region Material Grids Events
            else if (EventFiringName == "Garment Cutting Materials")
            {
                grdCuttingMaterialUsed.Refresh();
                grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialIdItem"].Value = oelItems.IdItem;
                grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialName"].Value = oelItems.ItemName;
                grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialItemType"].Value = GetItemType(oelItems.IdItem);
                if (Validation.GetSafeString(grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialItemType"].Value) == "1")
                {
                    DataGridViewComboBoxCell cbxGarmentsCuttingMaterialColor = grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialColors"] as DataGridViewComboBoxCell;
                    if (cbxGarmentsCuttingMaterialColor != null)
                    {
                        cbxGarmentsCuttingMaterialColor.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                        cbxGarmentsCuttingMaterialColor.DisplayMember = "ItemColor";
                        cbxGarmentsCuttingMaterialColor.ValueMember = "IdColor";
                    }
                }
                else
                {
                    //colCuttingMaterialColors.DataSource = null;
                }
            }
            else if (EventFiringName == "Garment Cutting Wastage")
            {
                grdCuttingWastage.CurrentRow.Cells["colCuttingWastageIdItem"].Value = oelItems.IdItem;
                grdCuttingWastage.CurrentRow.Cells["colCuttingWastageName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Garment Stitching Material")
            {
                grdStitchingMaterials.RefreshEdit();
                grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialIdItem"].Value = oelItems.IdItem;
                grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialName"].Value = oelItems.ItemName;
                grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialItemType"].Value = GetItemType(oelItems.IdItem);
                if (Validation.GetSafeString(grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialItemType"].Value) != "1")
                {
                    DataGridViewComboBoxCell cbxGarmentsStitchingMaterialColor = grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialColors"] as DataGridViewComboBoxCell;
                    if (cbxGarmentsStitchingMaterialColor != null)
                    {
                        cbxGarmentsStitchingMaterialColor.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                        cbxGarmentsStitchingMaterialColor.DisplayMember = "ItemColor";
                        cbxGarmentsStitchingMaterialColor.ValueMember = "IdColor";
                    }
                }
                else
                {
                    //colStitchingMaterialColors.DataSource = null;
                }
            }
            else if (EventFiringName == "Garment Feedo/Saftey Material")
            {
                grdFeedoMaterials.RefreshEdit();
                grdFeedoMaterials.CurrentRow.Cells["colFeedoMaterialIdItem"].Value = oelItems.IdItem;
                grdFeedoMaterials.CurrentRow.Cells["colFeedoMaterialName"].Value = oelItems.ItemName;
                grdFeedoMaterials.CurrentRow.Cells["colFeedoMaterialItemType"].Value = GetItemType(oelItems.IdItem);
                if (Validation.GetSafeString(grdFeedoMaterials.CurrentRow.Cells["colFeedoMaterialItemType"].Value) != "1")
                {

                    DataGridViewComboBoxCell cbxGarmentsFeedoMaterialColor = grdFeedoMaterials.CurrentRow.Cells["colFeedoMaterialColors"] as DataGridViewComboBoxCell;
                    if (cbxGarmentsFeedoMaterialColor != null)
                    {
                        cbxGarmentsFeedoMaterialColor.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                        cbxGarmentsFeedoMaterialColor.DisplayMember = "ItemColor";
                        cbxGarmentsFeedoMaterialColor.ValueMember = "IdColor";
                    }
                }
                else
                {
                    //colFeedoMaterialColors.DataSource = null;
                }
            }
            else if (EventFiringName == "Garment Bartake Material")
            {
                grdBartakeMaterials.RefreshEdit();
                grdBartakeMaterials.CurrentRow.Cells["colBartakeMaterialIdItem"].Value = oelItems.IdItem;
                grdBartakeMaterials.CurrentRow.Cells["colBartakeMaterialName"].Value = oelItems.ItemName;
                grdBartakeMaterials.CurrentRow.Cells["colBartakeMaterialItemType"].Value = GetItemType(oelItems.IdItem);
                if (Validation.GetSafeString(grdBartakeMaterials.CurrentRow.Cells["colBartakeMaterialItemType"].Value) != "1")
                {

                    DataGridViewComboBoxCell cbxGarmentsBartakeMaterialColor = grdBartakeMaterials.CurrentRow.Cells["colBartakeMaterialColors"] as DataGridViewComboBoxCell;
                    if (cbxGarmentsBartakeMaterialColor != null)
                    {
                        cbxGarmentsBartakeMaterialColor.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                        cbxGarmentsBartakeMaterialColor.DisplayMember = "ItemColor";
                        cbxGarmentsBartakeMaterialColor.ValueMember = "IdColor";
                    }
                }
                else
                {
                    //colBartakeMaterialColors.DataSource = null;
                }
            }
            else if (EventFiringName == "Garment Packing Material")
            {
                grdPackingMaterials.RefreshEdit();
                grdPackingMaterials.CurrentRow.Cells["colPackingMaterialIdItem"].Value = oelItems.IdItem;
                grdPackingMaterials.CurrentRow.Cells["colPackingMaterialName"].Value = oelItems.ItemName;
                grdPackingMaterials.CurrentRow.Cells["colPackingMaterialItemType"].Value = GetItemType(oelItems.IdItem);
                if (Validation.GetSafeString(grdPackingMaterials.CurrentRow.Cells["colPackingMaterialItemType"].Value) != "1")
                {
                    DataGridViewComboBoxCell cbxGarmentsPackingMaterialColor = grdPackingMaterials.CurrentRow.Cells["colPackingMaterialColors"] as DataGridViewComboBoxCell;
                    if (cbxGarmentsPackingMaterialColor != null)
                    {
                        cbxGarmentsPackingMaterialColor.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                        cbxGarmentsPackingMaterialColor.DisplayMember = "ItemColor";
                        cbxGarmentsPackingMaterialColor.ValueMember = "IdColor";
                    }
                }
                else
                {
                    //colPackingMaterialColors.DataSource = null;
                }
            }
            #endregion
            #region Order Opening Stock
            else if (EventFiringName == "Garments Opening Stock")
            {
                grdOpeningStock.CurrentRow.Cells["colOrderOpeningStockIdItem"].Value = oelItems.IdItem;
                grdOpeningStock.CurrentRow.Cells["colOrderOpeningStockItemName"].Value = oelItems.ItemName;
                DataGridViewComboBoxCell txtOpeningColors = grdOpeningStock.CurrentRow.Cells["colOpeningOrderColors"] as DataGridViewComboBoxCell;
                if (txtOpeningColors != null)
                {
                    txtOpeningColors.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                    txtOpeningColors.DisplayMember = "ItemColor";
                    txtOpeningColors.ValueMember = "IdColor";
                }
            }
            #endregion
            #region Else Case
            else
            {
                //txtQuality.Text = oelItems.AccountName;
                IdQuality = oelItems.IdItem;
            }
            #endregion
        }
        private void cbxCustomerPOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCustomerPOS.SelectedIndex > 0)
            {
                GetVoucherInfoByCustomerPONo(cbxCustomerPOS.Text);
                LoadType = "CustomerPo";
                ProductionTab.SelectedIndex = 0;
                ProductionTab_SelectedIndexChanged(sender, e);
                FillCustomerPoDetail();
            }
        }
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadType = "Voucher";
                GetProductionVoucher();
                ProductionTab_SelectedIndexChanged(sender, e);
            }
        }
        #endregion
        #region Tab Related Events and Methods
        private void ProductionTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Variables
            var Manager = new ProductionProcessDetailBLL();
            var MManager = new ProductionMaterialsBLL();
            List<ProductionProcessDetailEL> list = null;
            List<ProductionProcessesEL> listProcess = null;
            string ProcessName = "";
            #endregion
            #region Garments Opening Stock
            if (ProductionTab.SelectedIndex == 0)
            {
                ProcessName = "Garments Opening Stock";
                
                list = Manager.GetProductionOpeningStockByOrder(IdVoucher, 2);
                
                if (list.Count > 0)
                {
                    if (grdOpeningStock.Rows.Count > 0)
                    {
                        grdOpeningStock.Rows.Clear();
                    }
                    FillProcessDetails(list, ProcessName);
                }
                else
                {
                    grdOpeningStock.Rows.Clear();
                }
            }
            #endregion
            #region Garments Cutting
            if (ProductionTab.SelectedIndex == 1)
            {
                ProcessName = "Garments Cutting";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    if (grdCutting.Rows.Count > 0)
                    {
                        grdCutting.Rows.Clear();
                    }
                    IdCutting = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 2, "Garments Cutting Material Usage");
                    if (grdCuttingMaterialUsed.Rows.Count > 0)
                    {
                        grdCuttingMaterialUsed.Rows.Clear();
                    }
                    FillMaterials(listMaterials, ProcessName);
                    List<ProductionMaterialUsedEL> listWastage = MManager.GetProductionWastageByVoucher(IdVoucher, 2, ProcessName);
                    FillWastage(listWastage, ProcessName);
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdCutting = listProcess[0].IdProductionProcess;
                    }
                    FillCuttingMaterialGridByCustomerPO();
                }
            }
            #endregion
            #region Garments Stitching
            else if (ProductionTab.SelectedIndex == 2)
            {
                ProcessName = "Garments Stitching";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 2, "Garments Stitching Material Usage");
                    if (grdStitching.Rows.Count > 0)
                    {
                        grdStitching.Rows.Clear();
                    }
                    IdStitching = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdStitchingMaterials.Rows.Count > 0)
                        {
                            grdStitchingMaterials.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdStitching = listProcess[0].IdProductionProcess;
                    }
                    FillStitchingMaterialGridByCustomerPO();
                }
            }
            #endregion
            #region Garments Feedo/Saftey
            else if (ProductionTab.SelectedIndex == 3)
            {
                ProcessName = "Garments Feedo/Saftey";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 2, "Garments Feedo Material Usage");
                    if (grdFeedoSaftey.Rows.Count > 0)
                    {
                        grdFeedoSaftey.Rows.Clear();
                    }
                    IdFeedo = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdFeedoMaterials.Rows.Count > 0)
                        {
                            grdFeedoMaterials.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdFeedo = listProcess[0].IdProductionProcess;
                    }
                    FillFeedoMaterialGridByCustomerPO();
                }
            }
            #endregion
            #region Garments Bartake/Buttons/Kaaj
            else if (ProductionTab.SelectedIndex == 4)
            {
                ProcessName = "Garments Bartake/Kaaj/Buttons";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 2, "Garments Bartake/Kaaj/Buttons Material Usage");
                    if (grdBartake.Rows.Count > 0)
                    {
                        grdBartake.Rows.Clear();
                    }
                    IdBartake = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdBartakeMaterials.Rows.Count > 0)
                        {
                            grdBartakeMaterials.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdBartake = listProcess[0].IdProductionProcess;
                    }
                    FillBartakeMaterialGridByCustomerPO();
                }
            }
            #endregion
            #region Garments Threading
            else if (ProductionTab.SelectedIndex == 5)
            {
                ProcessName = "Garments Threading";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    if (grdThreading.Rows.Count > 0)
                    {
                        grdThreading.Rows.Clear();
                    }
                    IdThreading = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdThreading = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion
            #region Garments Inspection
            else if (ProductionTab.SelectedIndex == 6)
            {
                ProcessName = "Garments Inspection";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    if (grdInspection.Rows.Count > 0)
                    {
                        grdInspection.Rows.Clear();
                    }
                    IdInspection = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdInspection = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion
            #region Garments Press
            else if (ProductionTab.SelectedIndex == 7)
            {
                ProcessName = "Garments Press";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    if (grdPress.Rows.Count > 0)
                    {
                        grdPress.Rows.Clear();
                    }
                    IdPress = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdPress = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion
            #region Garments Packing
            else if (ProductionTab.SelectedIndex == 8)
            {
                ProcessName = "Garments Packing";
                if (LoadType == "CustomerPo")
                {
                    list = Manager.GetGarmentProcessesDetailByCustomerPoNoAndProcess(Operations.IdCompany, ProcessName, cbxCustomerPOS.Text);
                }
                else
                {
                    list = Manager.GetGarmentProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, Validation.GetSafeLong(VEditBox.Text));
                }
                if (list.Count > 0)
                {
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 2, "Garments Packing Material Usage");
                    if (grdPacking.Rows.Count > 0)
                    {
                        grdPacking.Rows.Clear();
                    }
                    IdPacking = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (grdPackingMaterials.Rows.Count > 0)
                    {
                        grdPackingMaterials.Rows.Clear();
                    }
                    FillMaterials(listMaterials, ProcessName);
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdPacking = listProcess[0].IdProductionProcess;
                    }
                    FillPackingMaterialGridByCustomerPO();
                }
            }
            #endregion
            #region Garments OverHeads
            else if (ProductionTab.SelectedIndex == 9)
            {
                var OverHeadManager = new ProductionOverHeadsBLL();
                List<ProductionOverHeadEL> listCost = OverHeadManager.GetProductionOverHeadsByVoucher(IdVoucher, 2);
                if (listCost.Count > 0)
                {
                    FillProductionCost(listCost);
                }
            }
            #endregion
        }
        private void FillProcessDetails(List<ProductionProcessDetailEL> list, string ProcessName)
        {
            IdVoucher = list[0].IdVoucher;
            for (int i = 0; i < list.Count; i++)
            {
                #region Garments Opening Stock
                if (ProcessName == "Garments Opening Stock")
                {
                    grdOpeningStock.Rows.Add();
                    grdOpeningStock.Rows[i].Cells["colIdOrderOpeningStock"].Value = list[i].IdProductionProcessDetail;
                    grdOpeningStock.Rows[i].Cells["colOrderOpeningStockIdItem"].Value = list[i].IdItem;
                    grdOpeningStock.Rows[i].Cells["colOrderOpeningStockItemName"].Value = list[i].ItemName;
                    if (list[i].IdProductionDepartment == 1)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Garments Cutting";
                    }
                    else if (list[i].IdProductionDepartment == 2)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Garments Stitching";
                    }
                    else if (list[i].IdProductionDepartment == 3)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Garments Feedo / Saftey";
                    }
                    else if (list[i].IdProductionDepartment == 4)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Garments Bartake / Kaaj / Buttons";
                    }
                    else if (list[i].IdProductionDepartment == 5)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Garments Threading";
                    }
                    else if (list[i].IdProductionDepartment == 6)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Garments Checking / Inspection";
                    }
                    else if (list[i].IdProductionDepartment == 7)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Garments Press";
                    }
                    else if (list[i].IdProductionDepartment == 8)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Garments Packing";
                    }
                    if (list[i].GType == 1)
                    {
                        grdOpeningStock.Rows[i].Cells["colOpeningOrderType"].Value = "Cover All";
                    }
                    else
                    {
                        grdOpeningStock.Rows[i].Cells["colOpeningOrderType"].Value = "Pant & Shirt";
                    }
                    grdOpeningStock.Rows[i].Cells["colOpeningOrderSizes"].Value = list[i].ItemSize;

                    if (list[i].IdProductionDepartment == 3)
                    {
                        if (list[i].GarmentWorkType == 1)
                        {
                            grdOpeningStock.Rows[i].Cells["colOrderOpeningWorkType"].Value = "Feedo";
                        }
                        else if (list[i].GarmentWorkType == 2)
                        {
                            grdOpeningStock.Rows[i].Cells["colOrderOpeningWorkType"].Value = "Safety";
                        }
                    }
                    else if (list[i].IdProductionDepartment == 4)
                    {
                        if (list[i].GarmentWorkType == 1)
                        {
                            grdOpeningStock.Rows[i].Cells["colOrderOpeningWorkType"].Value = "Bartake";
                        }
                        else if (list[i].GarmentWorkType == 2)
                        {
                            grdOpeningStock.Rows[i].Cells["colOrderOpeningWorkType"].Value = "Kaaj";
                        }
                        else if (list[i].GarmentWorkType == 3)
                        {
                            grdOpeningStock.Rows[i].Cells["colOrderOpeningWorkType"].Value = "Buttons";
                        }
                    }
                    else
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningWorkType"].Value = "";
                    }
                    
                    
                    List<ItemsEL> listColors = GetItemsColorAttributes(list[i].IdItem);
                    if (listColors.Count > 0)
                    {
                        DataGridViewComboBoxCell OCell = (DataGridViewComboBoxCell)grdOpeningStock.Rows[i].Cells[7];
                        if (OCell != null)
                        {
                            OCell.DataSource = listColors;
                            OCell.DisplayMember = "ItemColor";
                            OCell.ValueMember = "IdColor";
                        }
                        grdOpeningStock.Rows[i].Cells[7].Value = list[i].IdColor;
                    }
                    else
                    {
                        grdOpeningStock.Rows[i].Cells[7].Value = null;
                    }
                    grdOpeningStock.Rows[i].Cells["colOrderOpeningStockQuantity"].Value = CommonFunctions.RemoveTrailingZeros(list[i].Qty);
                    grdOpeningStock.Rows[i].Cells["colOrderOpeningStockRates"].Value = list[i].Rate;
                    grdOpeningStock.Rows[i].Cells["colOrderOpeningStockAmount"].Value = list[i].Amount;
                }
                #endregion
                #region Garment Cutting Entries
                if (ProcessName == "Garments Cutting")
                {
                    grdCutting.Rows.Add();
                    grdCutting.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdCutting.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdCutting.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdCutting.Rows[i].Cells[3].Value = list[i].Posted;
                    grdCutting.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdCutting.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdCutting.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdCutting.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdCutting.Rows[i].Cells[8].Value = list[i].ItemName;
                    List<ItemsEL> listColors = GetItemsColorAttributes(list[i].IdItem);
                    if (listColors.Count > 0)
                    {
                        DataGridViewComboBoxCell OCell = (DataGridViewComboBoxCell)grdCutting.Rows[i].Cells[9];
                        if (OCell != null)
                        {
                            OCell.DataSource = listColors;
                            OCell.DisplayMember = "ItemColor";
                            OCell.ValueMember = "IdColor";
                        }
                        grdCutting.Rows[i].Cells[9].Value = list[i].IdColor;
                    }
                    else
                    {
                        grdCutting.Rows[i].Cells[9].Value = null;
                    }
                    grdCutting.Rows[i].Cells[10].Value = list[i].ItemSize;
                    if (list[i].GType == 1)
                    {
                        grdCutting.Rows[i].Cells[11].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdCutting.Rows[i].Cells[11].Value = "Pant & Shirt";
                    }
                    if (list[i].Quality == 1)
                    {
                        grdCutting.Rows[i].Cells[12].Value = "Fresh";
                    }
                    else if (list[i].Quality == 2)
                    {
                        grdCutting.Rows[i].Cells[12].Value = "Cut Pieces";
                    }
                    else if (list[i].Quality == 3)
                    {
                        grdCutting.Rows[i].Cells[12].Value = "B Grade";
                    }
                    grdCutting.Rows[i].Cells[13].Value = list[i].BundleNo;
                    grdCutting.Rows[i].Cells[14].Value = list[i].Quantity;
                    grdCutting.Rows[i].Cells[15].Value = list[i].Average;
                    grdCutting.Rows[i].Cells[16].Value = list[i].Meters;


                    grdCutting.Rows[i].Cells[17].Value = list[i].Rate.ToString("0.00");
                    grdCutting.Rows[i].Cells[18].Value = list[i].Amount.ToString("0.00");

                    if (list[i].Posted)
                    {
                        grdCutting.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[15].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[16].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[17].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[18].Style.BackColor = Color.LightGreen;

                        grdCutting.Rows[i].Cells[14].ReadOnly = true;
                        grdCutting.Rows[i].Cells[15].ReadOnly = true;
                        grdCutting.Rows[i].ReadOnly = true;
                    }

                }
                #endregion
                #region Stitching Entries
                else if (ProcessName == "Garments Stitching")
                {

                    grdStitching.Rows.Add();
                    grdStitching.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdStitching.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdStitching.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdStitching.Rows[i].Cells[3].Value = list[i].Posted;
                    grdStitching.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdStitching.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdStitching.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdStitching.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdStitching.Rows[i].Cells[8].Value = list[i].ItemName;
                    List<ItemsEL> listColors = GetItemsColorAttributes(list[i].IdItem);
                    if (listColors.Count > 0)
                    {
                        DataGridViewComboBoxCell OCell = (DataGridViewComboBoxCell)grdStitching.Rows[i].Cells[9];
                        if (OCell != null)
                        {
                            OCell.DataSource = listColors;
                            OCell.DisplayMember = "ItemColor";
                            OCell.ValueMember = "IdColor";
                        }
                        grdStitching.Rows[i].Cells[9].Value = list[i].IdColor;
                    }
                    else
                    {
                        grdStitching.Rows[i].Cells[9].Value = null;
                    }
                    grdStitching.Rows[i].Cells[10].Value = list[i].ItemSize;
                    if (list[i].GType == 1)
                    {
                        grdStitching.Rows[i].Cells[11].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdStitching.Rows[i].Cells[11].Value = "Pant & Shirt";
                    }
                    grdStitching.Rows[i].Cells[12].Value = list[i].BundleNo;
                    grdStitching.Rows[i].Cells[13].Value = list[i].Quantity;



                    grdStitching.Rows[i].Cells[14].Value = list[i].Rate;
                    grdStitching.Rows[i].Cells[15].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdStitching.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].Cells[15].Style.BackColor = Color.LightGreen;
                        grdStitching.Rows[i].ReadOnly = true;
                    }

                }
                #endregion
                #region Feedo / Saftey Entries
                else if (ProcessName == "Garments Feedo/Saftey")
                {
                    grdFeedoSaftey.Rows.Add();
                    grdFeedoSaftey.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdFeedoSaftey.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdFeedoSaftey.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdFeedoSaftey.Rows[i].Cells[3].Value = list[i].Posted;
                    grdFeedoSaftey.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdFeedoSaftey.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdFeedoSaftey.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdFeedoSaftey.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdFeedoSaftey.Rows[i].Cells[8].Value = list[i].ItemName;
                    List<ItemsEL> listColors = GetItemsColorAttributes(list[i].IdItem);
                    if (listColors.Count > 0)
                    {
                        DataGridViewComboBoxCell OCell = (DataGridViewComboBoxCell)grdFeedoSaftey.Rows[i].Cells[9];
                        if (OCell != null)
                        {
                            OCell.DataSource = listColors;
                            OCell.DisplayMember = "ItemColor";
                            OCell.ValueMember = "IdColor";
                        }
                        grdFeedoSaftey.Rows[i].Cells[9].Value = list[i].IdColor;
                    }
                    else
                    {
                        grdFeedoSaftey.Rows[i].Cells[9].Value = null;
                    }
                    if (list[i].GarmentWorkType == 1)
                    {
                        grdFeedoSaftey.Rows[i].Cells[10].Value = "Feedo";
                    }
                    else if (list[i].GarmentWorkType == 2)
                    {
                        grdFeedoSaftey.Rows[i].Cells[10].Value = "Saftey";
                    }
                    if (list[i].GType == 1)
                    {
                        grdFeedoSaftey.Rows[i].Cells[11].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdFeedoSaftey.Rows[i].Cells[11].Value = "Pant & Shirt";
                    }
                    grdFeedoSaftey.Rows[i].Cells[12].Value = list[i].ItemSize;
                    grdFeedoSaftey.Rows[i].Cells[13].Value = list[i].BundleNo;
                    grdFeedoSaftey.Rows[i].Cells[14].Value = list[i].Quantity;



                    grdFeedoSaftey.Rows[i].Cells[15].Value = list[i].Rate;
                    grdFeedoSaftey.Rows[i].Cells[16].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdFeedoSaftey.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[15].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].Cells[16].Style.BackColor = Color.LightGreen;
                        grdFeedoSaftey.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Bartake / Kaaj / Buttons Entries
                else if (ProcessName == "Garments Bartake/Kaaj/Buttons")
                {
                    grdBartake.Rows.Add();
                    grdBartake.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdBartake.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdBartake.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdBartake.Rows[i].Cells[3].Value = list[i].Posted;
                    grdBartake.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdBartake.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdBartake.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdBartake.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdBartake.Rows[i].Cells[8].Value = list[i].ItemName;
                    List<ItemsEL> listColors = GetItemsColorAttributes(list[i].IdItem);
                    if (listColors.Count > 0)
                    {
                        DataGridViewComboBoxCell OCell = (DataGridViewComboBoxCell)grdBartake.Rows[i].Cells[9];
                        if (OCell != null)
                        {
                            OCell.DataSource = listColors;
                            OCell.DisplayMember = "ItemColor";
                            OCell.ValueMember = "IdColor";
                        }
                        grdBartake.Rows[i].Cells[9].Value = list[i].IdColor;
                    }
                    else
                    {
                        grdBartake.Rows[i].Cells[9].Value = null;
                    }
                    if (list[i].GarmentWorkType == 1)
                    {
                        grdBartake.Rows[i].Cells[10].Value = "Bartake";
                    }
                    else if (list[i].GarmentWorkType == 2)
                    {
                        grdBartake.Rows[i].Cells[10].Value = "Kaaj";
                    }
                    else if (list[i].GarmentWorkType == 2)
                    {
                        grdBartake.Rows[i].Cells[10].Value = "Buttons";
                    }
                    if (list[i].GType == 1)
                    {
                        grdBartake.Rows[i].Cells[11].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdBartake.Rows[i].Cells[11].Value = "Pant & Shirt";
                    }
                    grdBartake.Rows[i].Cells[12].Value = list[i].ItemSize;
                    grdBartake.Rows[i].Cells[13].Value = list[i].BundleNo;
                    grdBartake.Rows[i].Cells[14].Value = list[i].Quantity;



                    grdBartake.Rows[i].Cells[15].Value = list[i].Rate;
                    grdBartake.Rows[i].Cells[16].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdBartake.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[15].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].Cells[16].Style.BackColor = Color.LightGreen;
                        grdBartake.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Threading Entries
                else if (ProcessName == "Garments Threading")
                {
                    grdThreading.Rows.Add();
                    grdThreading.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdThreading.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdThreading.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdThreading.Rows[i].Cells[3].Value = list[i].Posted;
                    grdThreading.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdThreading.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdThreading.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdThreading.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdThreading.Rows[i].Cells[8].Value = list[i].ItemName;
                    List<ItemsEL> listColors = GetItemsColorAttributes(list[i].IdItem);
                    if (listColors.Count > 0)
                    {
                        DataGridViewComboBoxCell OCell = (DataGridViewComboBoxCell)grdThreading.Rows[i].Cells[9];
                        if (OCell != null)
                        {
                            OCell.DataSource = listColors;
                            OCell.DisplayMember = "ItemColor";
                            OCell.ValueMember = "IdColor";
                        }
                        grdThreading.Rows[i].Cells[9].Value = list[i].IdColor;
                    }
                    else
                    {
                        grdThreading.Rows[i].Cells[9].Value = null;
                    }
                    if (list[i].GType == 1)
                    {
                        grdThreading.Rows[i].Cells[10].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdThreading.Rows[i].Cells[10].Value = "Pant & Shirt";
                    }
                    grdThreading.Rows[i].Cells[11].Value = list[i].ItemSize;
                    grdThreading.Rows[i].Cells[12].Value = list[i].BundleNo;
                    grdThreading.Rows[i].Cells[13].Value = list[i].Quantity;

                    grdThreading.Rows[i].Cells[14].Value = list[i].Rate;
                    grdThreading.Rows[i].Cells[15].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdThreading.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdThreading.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;

                        grdThreading.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Checking / Inspection Entries
                else if (ProcessName == "Garments Inspection")
                {
                    grdInspection.Rows.Add();
                    grdInspection.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdInspection.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdInspection.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdInspection.Rows[i].Cells[3].Value = list[i].Posted;
                    grdInspection.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdInspection.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdInspection.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdInspection.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdInspection.Rows[i].Cells[8].Value = list[i].ItemName;
                    List<ItemsEL> listColors = GetItemsColorAttributes(list[i].IdItem);
                    if (listColors.Count > 0)
                    {
                        DataGridViewComboBoxCell OCell = (DataGridViewComboBoxCell)grdInspection.Rows[i].Cells[9];
                        if (OCell != null)
                        {
                            OCell.DataSource = listColors;
                            OCell.DisplayMember = "ItemColor";
                            OCell.ValueMember = "IdColor";
                        }
                        grdInspection.Rows[i].Cells[9].Value = list[i].IdColor;
                    }
                    else
                    {
                        grdInspection.Rows[i].Cells[9].Value = null;
                    }
                    if (list[i].GType == 1)
                    {
                        grdInspection.Rows[i].Cells[10].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdInspection.Rows[i].Cells[10].Value = "Pant & Shirt";
                    }
                    grdInspection.Rows[i].Cells[11].Value = list[i].ItemSize;
                    grdInspection.Rows[i].Cells[12].Value = list[i].BundleNo;
                    grdInspection.Rows[i].Cells[13].Value = list[i].Quantity;
                    grdInspection.Rows[i].Cells[14].Value = list[i].ReadyUnits;
                    grdInspection.Rows[i].Cells[15].Value = list[i].Rejection;


                    grdInspection.Rows[i].Cells[16].Value = list[i].Rate.ToString("0.00");
                    grdInspection.Rows[i].Cells[17].Value = list[i].Amount.ToString("0.00");

                    if (list[i].Posted)
                    {
                        grdInspection.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;

                        grdInspection.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Press Entries
                else if (ProcessName == "Garments Press")
                {
                    grdPress.Rows.Add();
                    grdPress.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdPress.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdPress.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdPress.Rows[i].Cells[3].Value = list[i].Posted;
                    grdPress.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdPress.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdPress.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdPress.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdPress.Rows[i].Cells[8].Value = list[i].ItemName;
                    List<ItemsEL> listColors = GetItemsColorAttributes(list[i].IdItem);
                    if (listColors.Count > 0)
                    {
                        DataGridViewComboBoxCell OCell = (DataGridViewComboBoxCell)grdPress.Rows[i].Cells[9];
                        if (OCell != null)
                        {
                            OCell.DataSource = listColors;
                            OCell.DisplayMember = "ItemColor";
                            OCell.ValueMember = "IdColor";
                        }
                        grdPress.Rows[i].Cells[9].Value = list[i].IdColor;
                    }
                    else
                    {
                        grdPress.Rows[i].Cells[9].Value = null;
                    }
                    if (list[i].GType == 1)
                    {
                        grdPress.Rows[i].Cells[10].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdPress.Rows[i].Cells[10].Value = "Pant & Shirt";
                    }
                    grdPress.Rows[i].Cells[11].Value = list[i].ItemSize;
                    grdPress.Rows[i].Cells[12].Value = list[i].BundleNo;
                    grdPress.Rows[i].Cells[13].Value = list[i].Quantity;
                    grdPress.Rows[i].Cells[14].Value = list[i].ReadyUnits;
                    grdPress.Rows[i].Cells[15].Value = list[i].Rejection;


                    grdPress.Rows[i].Cells[16].Value = list[i].Rate.ToString("0.00");
                    grdPress.Rows[i].Cells[17].Value = list[i].Amount.ToString("0.00");

                    if (list[i].Posted)
                    {
                        grdPress.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[15].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[16].Style.BackColor = Color.LightGreen;
                        grdPress.Rows[i].Cells[17].Style.BackColor = Color.LightGreen;

                        grdPress.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Packing Entries
                else if (ProcessName == "Garments Packing")
                {
                    grdPacking.Rows.Add();
                    grdPacking.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdPacking.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdPacking.Rows[i].Cells[2].Value = list[i].IdVoucher;
                    grdPacking.Rows[i].Cells[3].Value = list[i].Posted;
                    grdPacking.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdPacking.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdPacking.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdPacking.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdPacking.Rows[i].Cells[8].Value = list[i].ItemName;
                    List<ItemsEL> listColors = GetItemsColorAttributes(list[i].IdItem);
                    if (listColors.Count > 0)
                    {
                        DataGridViewComboBoxCell OCell = (DataGridViewComboBoxCell)grdPacking.Rows[i].Cells[9];
                        if (OCell != null)
                        {
                            OCell.DataSource = listColors;
                            OCell.DisplayMember = "ItemColor";
                            OCell.ValueMember = "IdColor";
                        }
                        grdPacking.Rows[i].Cells[9].Value = list[i].IdColor;
                    }
                    else
                    {
                        grdPacking.Rows[i].Cells[9].Value = null;
                    }
                    if (list[i].GType == 1)
                    {
                        grdPacking.Rows[i].Cells[10].Value = "Cover All";
                    }
                    else if (list[i].GType == 2)
                    {
                        grdPacking.Rows[i].Cells[10].Value = "Pant & Shirt";
                    }
                    grdPacking.Rows[i].Cells[11].Value = list[i].ItemSize;
                    grdPacking.Rows[i].Cells[12].Value = list[i].PStyle;
                    grdPacking.Rows[i].Cells[13].Value = list[i].BundleNo;
                    grdPacking.Rows[i].Cells[14].Value = list[i].Quantity;

                    grdPacking.Rows[i].Cells[15].Value = list[i].Rate;
                    grdPacking.Rows[i].Cells[16].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdPacking.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[15].Style.BackColor = Color.LightGreen;
                        grdPacking.Rows[i].Cells[16].Style.BackColor = Color.LightGreen;

                        grdPacking.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
            }
        }
        private void FillMaterials(List<ProductionMaterialUsedEL> list, string ProcessName)
        {
            for (int i = 0; i < list.Count; i++)
            {
                #region Cutting Materials Entries
                if (ProcessName == "Garments Cutting")
                {
                    grdCuttingMaterialUsed.Rows.Add();
                    List<ItemsEL> Colorlist = GetItemsColorAttributes(list[i].IdItem);
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialIdItem"].Value = list[i].IdItem;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialItemType"].Value = list[i].ItemType;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialAccountNo"].Value = list[i].AccountNo;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialDate"].Value = list[i].VDate;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialName"].Value = list[i].ItemName;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUOM"].Value = list[i].PackingSize;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialWorkerName"].Value = list[i].AccountName;
                    if (list[i].GarmentsStockType == -1)
                    {
                        grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialCuttingType"].Value = "";
                    }
                    else if (list[i].GarmentsStockType == 1)
                    {
                        grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialCuttingType"].Value = "Fresh A Grade";
                    }
                    else if (list[i].GarmentsStockType == 2)
                    {
                        grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialCuttingType"].Value = "B Grade";
                    }
                    else if (list[i].GarmentsStockType == 3)
                    {
                        grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialCuttingType"].Value = "Cutt Pieces";
                    }
                    if (Colorlist.Count > 0)
                    {
                        DataGridViewComboBoxCell oCell = (DataGridViewComboBoxCell)grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialColors"];
                        if (oCell != null)
                        {

                            oCell.DataSource = Colorlist;
                            oCell.DisplayMember = "ItemColor";
                            oCell.ValueMember = "IdColor";

                        }
                        grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialColors"].Value = list[i].IdColor;
                    }
                    else
                    {
                        grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialColors"].Value = null;
                    }
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUsedQty"].Value = list[i].UsedQuantity;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialRate"].Value = list[i].Rate;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialAmount"].Value = list[i].Amount;
                }
                #endregion
                #region Stitching Materials Entries
                if (ProcessName == "Garments Stitching")
                {
                    grdStitchingMaterials.Rows.Add();
                    List<ItemsEL> Colorlist = GetItemsColorAttributes(list[i].IdItem);
                    grdStitchingMaterials.Rows[i].Cells["colStitchingIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialIdItem"].Value = list[i].IdItem;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialItemType"].Value = list[i].ItemType;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialAccountNo"].Value = list[i].AccountNo;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDate"].Value = list[i].VDate;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialName"].Value = list[i].ItemName;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialUOM"].Value = list[i].PackingSize;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialWorkerName"].Value = list[i].AccountName;
                    if (Colorlist.Count > 0)
                    {
                        DataGridViewComboBoxCell oCell = (DataGridViewComboBoxCell)grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialColors"];
                        if (oCell != null)
                        {

                            oCell.DataSource = Colorlist;
                            oCell.DisplayMember = "ItemColor";
                            oCell.ValueMember = "IdColor";

                        }
                        grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialColors"].Value = list[i].IdColor;
                    }
                    else
                    {
                        grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialColors"].Value = null;
                    }
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialBundleNo"].Value = list[i].BundleNo;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialQuantity"].Value = list[i].UsedQuantity;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialRate"].Value = list[i].Rate;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialAmount"].Value = list[i].Amount;
                }
                #endregion
                #region Feedo / Safety Materials Entries
                if (ProcessName == "Garments Feedo/Saftey")
                {
                    grdFeedoMaterials.Rows.Add();
                    List<ItemsEL> Colorlist = GetItemsColorAttributes(list[i].IdItem);
                    grdFeedoMaterials.Rows[i].Cells["colFeedoIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialIdItem"].Value = list[i].IdItem;
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialItemType"].Value = list[i].ItemType;
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialAccountNo"].Value = list[i].AccountNo;
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialDate"].Value = list[i].VDate;
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialName"].Value = list[i].ItemName;
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialUOM"].Value = list[i].PackingSize;
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialWorkerName"].Value = list[i].AccountName;
                    if (Colorlist.Count > 0)
                    {
                        DataGridViewComboBoxCell oCell = (DataGridViewComboBoxCell)grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialColors"];
                        if (oCell != null)
                        {

                            oCell.DataSource = Colorlist;
                            oCell.DisplayMember = "ItemColor";
                            oCell.ValueMember = "IdColor";

                        }
                        grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialColors"].Value = list[i].IdColor;
                    }
                    else
                    {
                        grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialColors"].Value = null;
                    }
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialBundleNo"].Value = list[i].BundleNo;
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialUsedQuantity"].Value = list[i].UsedQuantity;
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialRate"].Value = list[i].Rate;
                    grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialAmount"].Value = list[i].Amount;
                }
                #endregion
                #region Bartake / Kaaj / Buttons Materials Entries
                if (ProcessName == "Garments Bartake/Kaaj/Buttons")
                {
                    grdBartakeMaterials.Rows.Add();
                    List<ItemsEL> Colorlist = GetItemsColorAttributes(list[i].IdItem);
                    grdBartakeMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialIdItem"].Value = list[i].IdItem;
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialItemType"].Value = list[i].ItemType;
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialAccountNo"].Value = list[i].AccountNo;
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialDate"].Value = list[i].VDate;
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialName"].Value = list[i].ItemName;
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialUOM"].Value = list[i].PackingSize;
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialWorkerName"].Value = list[i].AccountName;
                    if (Colorlist.Count > 0)
                    {
                        DataGridViewComboBoxCell oCell = (DataGridViewComboBoxCell)grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialColors"];
                        if (oCell != null)
                        {

                            oCell.DataSource = Colorlist;
                            oCell.DisplayMember = "ItemColor";
                            oCell.ValueMember = "IdColor";

                        }
                        grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialColors"].Value = list[i].IdColor;
                    }
                    else
                    {
                        grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialColors"].Value = null;
                    }
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialBundleNo"].Value = list[i].BundleNo;
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialQuantity"].Value = list[i].UsedQuantity;
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialRate"].Value = list[i].Rate;
                    grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialAmount"].Value = list[i].Amount;
                }
                #endregion
                #region Packing Materials Entries
                if (ProcessName == "Garments Packing")
                {
                    grdPackingMaterials.Rows.Add();
                    List<ItemsEL> Colorlist = GetItemsColorAttributes(list[i].IdItem);
                    grdPackingMaterials.Rows[i].Cells["colPackingIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialIdItem"].Value = list[i].IdItem;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialItemType"].Value = list[i].ItemType;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialAccountNo"].Value = list[i].AccountNo;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialDate"].Value = list[i].VDate;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialName"].Value = list[i].ItemName;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialWorkerName"].Value = list[i].AccountName;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialUOM"].Value = list[i].PackingSize;
                    if (Colorlist.Count > 0)
                    {
                        DataGridViewComboBoxCell oCell = (DataGridViewComboBoxCell)grdPackingMaterials.Rows[i].Cells["colPackingMaterialColors"];
                        if (oCell != null)
                        {

                            oCell.DataSource = Colorlist;
                            oCell.DisplayMember = "ItemColor";
                            oCell.ValueMember = "IdColor";

                        }
                        grdPackingMaterials.Rows[i].Cells["colPackingMaterialColors"].Value = list[i].IdColor;
                    }
                    else
                    {
                        grdPackingMaterials.Rows[i].Cells["colPackingMaterialColors"].Value = null;
                    }
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialBundleNo"].Value = list[i].BundleNo;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialQuantity"].Value = list[i].UsedQuantity;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialRate"].Value = list[i].Rate;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialAmount"].Value = list[i].Amount;
                }
                #endregion
            }
        }
        private void FillWastage(List<ProductionMaterialUsedEL> list, string ProcessName)
        {
            for (int i = 0; i < list.Count; i++)
            {
                #region Cutting Wastage Entries
                if (ProcessName == "Garments Cutting")
                {
                    grdCuttingWastage.Rows.Add();
                    grdCuttingWastage.Rows[i].Cells["colCuttingIdWastage"].Value = list[i].IdMaterialUsed;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageIdItem"].Value = list[i].IdItem;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageName"].Value = list[i].ItemName;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageUOM"].Value = list[i].PackingSize;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageQuantity"].Value = list[i].UsedQuantity;
                }
                #endregion
            }
        }
        private void FillProductionCost(List<ProductionOverHeadEL> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                grdMiscCost.Rows.Add();
                grdMiscCost.Rows[i].Cells["colIdDetailCost"].Value = list[0].IdProductionOverHead;
                grdMiscCost.Rows[i].Cells["colCostDate"].Value = list[0].OverHeadDate;
                grdMiscCost.Rows[i].Cells["colAccountNo"].Value = list[0].IdProductionOverHead;
                grdMiscCost.Rows[i].Cells["colAccountName"].Value = list[0].AccountName;
                grdMiscCost.Rows[i].Cells["colCostDescription"].Value = list[0].Description;
                grdMiscCost.Rows[i].Cells["colCost"].Value = list[0].OverHeadCost;
            }
        }
        #endregion
        #region Methods
        private void GetProductionVoucher()
        {
            var manager = new ProductionProcessesHeadBLL();
            List<ProductionProcessesHeadEL> list = manager.GetProductionByNumberAndType(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text), 2);
            if (list.Count > 0)
            {
                IdVoucher = list[0].IdVoucher;
            }
            else
            {
                ClearControls();
            }
        }
        private int GetItemType(Guid IdItem)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemById(IdItem);
            return list[0].ItemType;
        }
        private List<ItemsEL> GetItemsColorAttributes(Guid Id) //, string ProcessName
        {
            var manager = new ItemsBLL();
            List<ItemsEL> oelItemsColorAttributesList = manager.GetItemsColorAttributes(Id);
            if (oelItemsColorAttributesList.Count > 0)
            {
                oelItemsColorAttributesList.Insert(0, new ItemsEL() { IdColor = Guid.Empty, ItemColor = "" });
            }
            //if (oelItemsColorAttributes.Count > 0)
            //{
            //    if (ProcessName == "Garments Cutting")
            //    {
            //        oelItemsColorAttributes.Insert(0, new ItemsEL() { IdColor = Guid.Empty, ItemColor = "" });

            //        colCuttingColors.DataSource = oelItemsColorAttributes;
            //        colCuttingColors.DisplayMember = "ItemColor";
            //        colCuttingColors.ValueMember = "IdColor";
            //    }
            //}
            //else
            //{
            //    colCuttingColors.DataSource = null;
            //}
            return oelItemsColorAttributesList;
        }
        private bool ValidateRecords(int GridNumber)
        {
            bool Status = true;
            #region Misc Validations
            if (cbxCustomerPOS.Text == string.Empty)
            {
                MessageBox.Show("Please Select Customer Order Number :");
                Status = false;
            }
            else if (VEditBox.Text == string.Empty)
            {
                MessageBox.Show("Production Number Is Empty :");
                Status = false;
            }
            #endregion
            #region Garments Cutting Grid Validation
            else if (GridNumber == 1)
            {
                for (int i = 0; i < grdCutting.Rows.Count - 1; i++)
                {
                    if (grdCutting.Rows[i].Cells["colCuttingAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdCutting.Rows[i].Cells["colCuttingIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Article.....");
                        break;
                    }
                    else if (grdCutting.Rows[i].Cells["colCuttingColors"].Value == null || Validation.GetSafeString(grdCutting.Rows[i].Cells["colCuttingColors"].Value) == string.Empty)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Color.....");
                        break;
                    }
                    else if (grdCutting.Rows[i].Cells["colCuttingAmount"].Value == null || Validation.GetSafeDecimal(grdCutting.Rows[i].Cells["colCuttingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Garments Stitching Grid Validation
            else if (GridNumber == 2)
            {
                for (int i = 0; i < grdStitching.Rows.Count - 1; i++)
                {
                    if (grdStitching.Rows[i].Cells["colStitchingAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    if (grdStitching.Rows[i].Cells["colStitchingIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Article.....");
                        break;
                    }
                    else if (grdStitching.Rows[i].Cells["colStitchingColors"].Value == null || Validation.GetSafeString(grdStitching.Rows[i].Cells["colStitchingColors"].Value) == string.Empty)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Color.....");
                        break;
                    }
                    else if (grdStitching.Rows[i].Cells["colStitchingAmount"].Value == null || Validation.GetSafeDecimal(grdStitching.Rows[i].Cells["colStitchingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Garments Feed/Saftey Grid Validation
            else if (GridNumber == 3)
            {
                for (int i = 0; i < grdFeedoSaftey.Rows.Count - 1; i++)
                {
                    if (grdFeedoSaftey.Rows[i].Cells["colFeedoAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdFeedoSaftey.Rows[i].Cells["colFeedoIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Article.....");
                        break;
                    }
                    else if (grdFeedoSaftey.Rows[i].Cells["colFeedoColors"].Value == null || Validation.GetSafeString(grdFeedoSaftey.Rows[i].Cells["colFeedoColors"].Value) == string.Empty)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Color.....");
                        break;
                    }
                    else if (grdFeedoSaftey.Rows[i].Cells["colFeedoAmount"].Value == null || Validation.GetSafeDecimal(grdFeedoSaftey.Rows[i].Cells["colFeedoAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Garments Bartake / Kaaj / Buttons Grid Validation
            else if (GridNumber == 4)
            {
                for (int i = 0; i < grdBartake.Rows.Count - 1; i++)
                {
                    if (grdBartake.Rows[i].Cells["colBartakeAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdBartake.Rows[i].Cells["colBartakeIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Article.....");
                        break;
                    }
                    else if (grdBartake.Rows[i].Cells["colBartakeColors"].Value == null || Validation.GetSafeString(grdBartake.Rows[i].Cells["colBartakeColors"].Value) == string.Empty)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Color.....");
                        break;
                    }
                    else if (grdBartake.Rows[i].Cells["colBartakeAmount"].Value == null || Validation.GetSafeDecimal(grdBartake.Rows[i].Cells["colBartakeAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Garments Threading Grid Validation
            else if (GridNumber == 5)
            {
                for (int i = 0; i < grdThreading.Rows.Count - 1; i++)
                {
                    if (grdThreading.Rows[i].Cells["colThreadingAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdThreading.Rows[i].Cells["colThreadingIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Article.....");
                        break;
                    }
                    else if (grdThreading.Rows[i].Cells["colThreadingColors"].Value == null || Validation.GetSafeString(grdThreading.Rows[i].Cells["colThreadingColors"].Value) == string.Empty)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Color.....");
                        break;
                    }
                    else if (grdThreading.Rows[i].Cells["colThreadingAmount"].Value == null || Validation.GetSafeDecimal(grdThreading.Rows[i].Cells["colThreadingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Garments Checking / Inspection Grid Validation
            else if (GridNumber == 6)
            {
                for (int i = 0; i < grdInspection.Rows.Count - 1; i++)
                {
                    if (grdInspection.Rows[i].Cells["colInspectionAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdInspection.Rows[i].Cells["colInspectionIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Article.....");
                        break;
                    }
                    else if (grdInspection.Rows[i].Cells["colInspectionColors"].Value == null || Validation.GetSafeString(grdInspection.Rows[i].Cells["colInspectionColors"].Value) == string.Empty)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Color.....");
                        break;
                    }
                    else if (grdInspection.Rows[i].Cells["colInspectionAmount"].Value == null || Validation.GetSafeDecimal(grdInspection.Rows[i].Cells["colInspectionAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Garments Press Grid Validation
            else if (GridNumber == 7)
            {
                for (int i = 0; i < grdPress.Rows.Count - 1; i++)
                {
                    if (grdPress.Rows[i].Cells["colPressAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdPress.Rows[i].Cells["colPressIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Article.....");
                        break;
                    }
                    else if (grdPress.Rows[i].Cells["colpressColors"].Value == null || Validation.GetSafeString(grdPress.Rows[i].Cells["colpressColors"].Value) == string.Empty)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Color.....");
                        break;
                    }
                    else if (grdPress.Rows[i].Cells["colPressAmount"].Value == null || Validation.GetSafeDecimal(grdPress.Rows[i].Cells["colPressAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Garments Packing Grid Validation
            else if (GridNumber == 8)
            {
                for (int i = 0; i < grdPacking.Rows.Count - 1; i++)
                {
                    if (grdPacking.Rows[i].Cells["colPackingAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdPacking.Rows[i].Cells["colPackingIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Article.....");
                        break;
                    }
                    else if (grdPacking.Rows[i].Cells["colPackingColors"].Value == null || Validation.GetSafeString(grdPacking.Rows[i].Cells["colPackingColors"].Value) == string.Empty)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Color.....");
                        break;
                    }
                    else if (grdPacking.Rows[i].Cells["colPackingAmount"].Value == null || Validation.GetSafeDecimal(grdPacking.Rows[i].Cells["colPackingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            return Status;
        }
        private bool ValidateMaterialRecords(int GridNumber)
        {
            bool Status = true;
            #region Misc Validations
            if (cbxCustomerPOS.Text == string.Empty)
            {
                MessageBox.Show("Please Select Customer Order Number :");
                Status = false;
            }
            else if (VEditBox.Text == string.Empty)
            {
                MessageBox.Show("Production Number Is Empty :");
                Status = false;
            }
            #endregion
            #region Garments Cutting Material Grid Validation
            else if (GridNumber == 1)
            {
                for (int i = 0; i < grdCuttingMaterialUsed.Rows.Count - 1; i++)
                {
                    if (grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Worker.....");
                        break;
                    }
                    else if (grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Product.....");
                        break;
                    }
                    else if (grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialAmount"].Value == null || Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Stitching Material Grid Validation
            else if (GridNumber == 2)
            {
                for (int i = 0; i < grdStitchingMaterials.Rows.Count - 1; i++)
                {
                    if (grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Worker.....");
                        break;
                    }
                    else if (grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Product.....");
                        break;
                    }
                    else if (grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialAmount"].Value == null || Validation.GetSafeDecimal(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Feedo Mateial Grid Validation
            else if (GridNumber == 3)
            {
                for (int i = 0; i < grdFeedoMaterials.Rows.Count - 1; i++)
                {
                    if (grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Worker.....");
                        break;
                    }
                    else if (grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Product.....");
                        break;
                    }
                    else if (grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialAmount"].Value == null || Validation.GetSafeDecimal(grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Bartake Mateial Grid Validation
            else if (GridNumber == 4)
            {
                for (int i = 0; i < grdBartakeMaterials.Rows.Count - 1; i++)
                {
                    if (grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Worker.....");
                        break;
                    }
                    else if (grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Product.....");
                        break;
                    }
                    else if (grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialAmount"].Value == null || Validation.GetSafeDecimal(grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Packing Grid Validation
            else if (GridNumber == 5)
            {
                for (int i = 0; i < grdPackingMaterials.Rows.Count - 1; i++)
                {
                    if (grdPackingMaterials.Rows[i].Cells["colPackingMaterialAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Worker.....");
                        break;
                    }
                    else if (grdPackingMaterials.Rows[i].Cells["colPackingMaterialIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Product / Article.....");
                        break;
                    }
                    else if (grdPackingMaterials.Rows[i].Cells["colPackingMaterialAmount"].Value == null || Validation.GetSafeDecimal(grdPackingMaterials.Rows[i].Cells["colPackingMaterialAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            return Status;
        }
        private void FillCustomerPos()
        {
            var manager = new ProductionProcessesHeadBLL();
            List<ProductionProcessesHeadEL> list = manager.GetCustomerPOSByStatusAndType(2);
            list.Insert(0, new ProductionProcessesHeadEL() { CustomerPO = "" });
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    cbxCustomerPOS.Items.Add(list[i].CustomerPO ?? "");
                }
            }
        }
        private void FillCustomerPoDetail()
        {
            if (cbxCustomerPOS.Text != string.Empty)
            {
                var OrderManager = new OrdersBLL();
                List<OrdersEL> list = OrderManager.GetOrderDetailByCustomerPo(Operations.IdCompany, cbxCustomerPOS.Text, 2);
                if (list.Count > 0)
                {
                    txtBrandName.Text = list[0].BrandName;
                    txtCustomerName.Text = list[0].AccountName;
                    txtCurrency.Text = list[0].CurrencyName;
                    dtDelivery.Value = list[0].DeliveryDate.Value;
                    IdOrder = list[0].IdOrder;
                    IdBrand = list[0].IdBrand;
                }
                else
                {
                    txtBrandName.Text = string.Empty;
                    txtCustomerName.Text = string.Empty;
                    txtCurrency.Text = string.Empty;
                    IdOrder = Guid.Empty;
                    IdBrand = Guid.Empty;
                    dtDelivery.Value = DateTime.Now;
                }
            }
            else
            {
                txtBrandName.Text = string.Empty;
                txtCustomerName.Text = string.Empty;
                txtCurrency.Text = string.Empty;
                IdOrder = Guid.Empty;
                dtDelivery.Value = DateTime.Now;
            }
        }
        private void GetVoucherInfoByCustomerPONo(string CustomerPo)
        {
            var Manager = new ProductionProcessesHeadBLL();
            List<TanneryProcessesHeadEL> list = Manager.GetVoucherInfoByCustomerPo(CustomerPo, 2);
            if (list.Count > 0)
            {
                IdVoucher = list[0].IdVoucher;
                VEditBox.Text = list[0].VoucherNo.ToString();
            }
            else
            {
                ClearControls();
            }
        }
        private void ClearControls()
        {
            #region Clearing Variables
            IdVoucher = Guid.Empty;
            IdCutting = Guid.Empty;
            IdStitching = Guid.Empty;
            IdFeedo = Guid.Empty;
            IdBartake = Guid.Empty;
            IdThreading = Guid.Empty;
            IdInspection = Guid.Empty;
            IdPress = Guid.Empty;
            IdPacking = Guid.Empty;
            #endregion
            #region Clearing Grids
            grdCutting.Rows.Clear();
            grdCuttingMaterialUsed.Rows.Clear();
            grdCuttingWastage.Rows.Clear();

            grdStitching.Rows.Clear();
            grdStitchingMaterials.Rows.Clear();

            grdFeedoSaftey.Rows.Clear();
            grdFeedoMaterials.Rows.Clear();

            grdBartake.Rows.Clear();
            grdBartakeMaterials.Rows.Clear();

            grdThreading.Rows.Clear();

            grdInspection.Rows.Clear();

            grdPress.Rows.Clear();

            grdPacking.Rows.Clear();
            grdPackingMaterials.Rows.Clear();

            grdMiscCost.Rows.Clear();
            #endregion
        }
        #endregion
        #region Garments Stock Quantitative and Qualitative Related Methods
        private decimal GetGarmentsProductionClosingStockByCustomerPO(Guid IdItem, Guid IdColor, Int64 BundleNo, string ProcessName, string SubProcessName)
        {
            var Manager = new ProductionProcessDetailBLL();
            return Manager.GetGarmentProductionClosingStockByCustomerPO(IdItem, IdColor, BundleNo, ProcessName, SubProcessName, cbxCustomerPOS.Text);
        }
        private decimal GetGarmentsAvgCostingByCustomerPO(Guid IdItem, Guid IdColor, string ProcessName, string SubProcessName)
        {
            var Manager = new ProductionProcessDetailBLL();
            return Manager.GetGarmentAvgCostingByCustomerPO(IdItem, IdColor, ProcessName, SubProcessName, cbxCustomerPOS.Text);
        }
        #endregion
        #region Buttons Related Events and Methods
        private void btnSaveOpeningStock_Click(object sender, EventArgs e)
        {
            #region Variables
            var Manager = new ProductionProcessesHeadBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionProcessDetailEL> list = new List<ProductionProcessDetailEL>();
            #endregion
            #region Creating Voucher Section If Voucher Empty
            if (IdVoucher == Guid.Empty)
            {
                oelProductionHead.IdVoucher = Guid.NewGuid();
                IdVoucher = oelProductionHead.IdVoucher;
                oelProductionHead.IsNew = true;
                oelProductionHead.AccountNo = "";
                oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                oelProductionHead.IdCompany = Operations.IdCompany;
                oelProductionHead.UserId = Operations.UserID;
                oelProductionHead.IdOrder = IdOrder;
                if (Validation.GetSafeString(cbxCustomerPOS.Text) == string.Empty)
                {
                    MessageBox.Show("Please Select Customer PO...");
                    return;
                }
                oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                oelProductionHead.VDate = ProductionDate.Value;
                oelProductionHead.VDiscription = "N/A";
                oelProductionHead.Amount = 0;
                oelProductionHead.CloseDate = DateTime.Now;
                oelProductionHead.ProductionType = 2;
            }
            #endregion
            #region Order Opening Stock Data
            for (int i = 0; i < grdOpeningStock.Rows.Count - 1; i++)
            {
                ProductionProcessDetailEL oelCurrentStock = new ProductionProcessDetailEL();
                if (grdOpeningStock.Rows[i].Cells["colIdOrderOpeningStock"].Value != null && Validation.GetSafeGuid(grdOpeningStock.Rows[i].Cells["colIdOrderOpeningStock"].Value) != Guid.Empty)
                {
                    oelCurrentStock.IdProductionProcessDetail = Validation.GetSafeGuid(grdOpeningStock.Rows[i].Cells["colIdOrderOpeningStock"].Value);
                    oelCurrentStock.IsNew = false;
                }
                else
                {
                    oelCurrentStock.IdProductionProcessDetail = Guid.NewGuid();
                    oelCurrentStock.IsNew = true;
                }
                oelCurrentStock.IdVoucher = IdVoucher;
                oelCurrentStock.PoNumber = cbxCustomerPOS.Text;
                oelCurrentStock.IdItem = Validation.GetSafeGuid(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockIdItem"].Value);
                oelCurrentStock.ProductionProcessName = Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value);
                oelCurrentStock.ProductionType = 2;
                if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Garments Cutting")
                {
                    oelCurrentStock.IdProductionDepartment = 1;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Garments Stitching")
                {
                    oelCurrentStock.IdProductionDepartment = 2;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Garments Feedo / Saftey")
                {
                    oelCurrentStock.IdProductionDepartment = 3;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Garments Bartake / Kaaj / Buttons")
                {
                    oelCurrentStock.IdProductionDepartment = 4;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Garments Threading")
                {
                    oelCurrentStock.IdProductionDepartment = 5;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Garments Checking / Inspection")
                {
                    oelCurrentStock.IdProductionDepartment = 6;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Garments Press")
                {
                    oelCurrentStock.IdProductionDepartment = 7;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Garments Packing")
                {
                    oelCurrentStock.IdProductionDepartment = 8;
                }
               
                oelCurrentStock.ItemSize = Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOpeningOrderSizes"].Value);
                if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOpeningOrderType"].Value) == "Cover All")
                {
                    oelCurrentStock.GType = 1;
                }
                else
                {
                    oelCurrentStock.GType = 2;
                }
                if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningWorkType"].Value) == "Feedo")
                {
                    oelCurrentStock.GarmentWorkType = 1;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningWorkType"].Value) == "Saftey")
                {
                    oelCurrentStock.GarmentWorkType = 2;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningWorkType"].Value) == "Bartake")
                {
                    oelCurrentStock.GarmentWorkType = 1;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningWorkType"].Value) == "Kaaj")
                {
                    oelCurrentStock.GarmentWorkType = 2;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningWorkType"].Value) == "Buttons")
                {
                    oelCurrentStock.GarmentWorkType = 3;
                }
                else
                    oelCurrentStock.GarmentsStockType = -1;   
 
                oelCurrentStock.Seq = i + 1;
                oelCurrentStock.BatchNo = "N/A";
                oelCurrentStock.ItemSize = Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOpeningOrderSizes"].Value);
                oelCurrentStock.IdColor = Validation.GetSafeGuid(grdOpeningStock.Rows[i].Cells["colOpeningOrderColors"].Value);
                oelCurrentStock.Qty = Validation.GetSafeDecimal(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockQuantity"].Value);
                oelCurrentStock.UnitPrice = Validation.GetSafeDecimal(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockRates"].Value);
                oelCurrentStock.Amount = Validation.GetSafeDecimal(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockAmount"].Value);
                list.Add(oelCurrentStock);
            }
            #endregion
            #region Saving Code Area
            if (Manager.CreateUpdateGlovesProductionOpeningStock(oelProductionHead, list).IsSuccess)
            {
                MessageBox.Show("Opening Stock Saved Successfully...");
                ProductionTab_SelectedIndexChanged(sender, e);
            }
            #endregion
        }
        private void btnCuttingSave_Click(object sender, EventArgs e)
        {
            #region Variables
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelCuttingMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelCuttingWastageCollection = new List<ProductionMaterialUsedEL>();
            #endregion
            #region Creating Voucher Section If Voucher Empty
            if (IdVoucher == Guid.Empty)
            {
                oelProductionHead.IdVoucher = Guid.NewGuid();
                IdVoucher = oelProductionHead.IdVoucher;
                oelProductionHead.IsNew = true;
                oelProductionHead.AccountNo = "";
                oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                oelProductionHead.IdCompany = Operations.IdCompany;
                oelProductionHead.UserId = Operations.UserID;
                oelProductionHead.IdOrder = IdOrder;
                if (Validation.GetSafeString(cbxCustomerPOS.Text) == string.Empty)
                {
                    MessageBox.Show("Please Select Customer PO...");
                    return;
                }
                oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                oelProductionHead.VDate = ProductionDate.Value;
                oelProductionHead.VDiscription = "N/A";
                oelProductionHead.Amount = 0;
                oelProductionHead.CloseDate = DateTime.Now;
                oelProductionHead.ProductionType = 2;
            }
            #endregion
            #region Creating Material Section
            if (grdCuttingMaterialUsed.Rows.Count > 0)
            {
                if (ValidateMaterialRecords(1))
                {
                    for (int i = 0; i < grdCuttingMaterialUsed.Rows.Count - 1; i++)
                    {
                        ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                        if (grdCuttingMaterialUsed.Rows[i].Cells["colCuttingIdMaterial"].Value == null || Validation.GetSafeGuid(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingIdMaterial"].Value) == Guid.Empty)
                        {
                            oelMaterialDetail.IdMaterialUsed = Guid.NewGuid();
                            oelMaterialDetail.IsNew = true;
                            grdCuttingMaterialUsed.Rows[i].Cells["colCuttingIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                        }
                        else
                        {
                            oelMaterialDetail.IdMaterialUsed = Validation.GetSafeGuid(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingIdMaterial"].Value);
                            oelMaterialDetail.IsNew = false;
                        }
                        if (IdVoucher != Guid.Empty)
                        {
                            oelMaterialDetail.IdVoucher = IdVoucher;
                        }
                        else
                        {
                            oelMaterialDetail.IdVoucher = oelProductionHead.IdVoucher;
                        }
                        oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialIdItem"].Value);
                        oelMaterialDetail.AccountNo = Validation.GetSafeString(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialAccountNo"].Value);
                        if (grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialColors"].Value != null)
                        {
                            if (Validation.GetSafeGuid(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialColors"].Value) != Guid.Empty)
                            {
                                oelMaterialDetail.IdColor = Validation.GetSafeGuid(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialColors"].Value);
                            }
                            else
                            {
                                MessageBox.Show("Please Select Color...");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Color Is Defined For This Article");
                        }
                        if (Validation.GetSafeString(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialCuttingType"].Value) == "")
                        {
                            oelMaterialDetail.GarmentsStockType = -1;
                        }
                        else if (Validation.GetSafeString(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialCuttingType"].Value) == "Fresh A Grade")
                        {
                            oelMaterialDetail.GarmentsStockType = 1;
                        }
                        else if (Validation.GetSafeString(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialCuttingType"].Value) == "B Grade")
                        {
                            oelMaterialDetail.GarmentsStockType = 2;
                        }
                        else if (Validation.GetSafeString(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialCuttingType"].Value) == "Cutt Pieces")
                        {
                            oelMaterialDetail.GarmentsStockType = 3;
                        }
                        oelMaterialDetail.UsedQuantity = Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUsedQty"].Value);
                        oelMaterialDetail.ProcessType = 2;
                        oelMaterialDetail.ProductionProcessName = "Garments Cutting Material Usage";
                        oelMaterialDetail.VDate = Convert.ToDateTime(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialDate"].Value);
                        oelMaterialDetail.Rate = Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialRate"].Value);
                        oelMaterialDetail.Amount = Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialAmount"].Value);

                        oelCuttingMaterialCollection.Add(oelMaterialDetail);
                    }
                }
                else
                {
                    return;
                }
            }
            #endregion
            #region Creating Wastage Section
            if (grdCuttingWastage.Rows.Count > 0)
            {
                for (int i = 0; i < grdCuttingWastage.Rows.Count - 1; i++)
                {
                    ProductionMaterialUsedEL oelCuttingWastage = new ProductionMaterialUsedEL();
                    if (grdCuttingWastage.Rows[i].Cells["colCuttingIdWastage"].Value == null || Validation.GetSafeGuid(grdCuttingWastage.Rows[i].Cells["colCuttingIdWastage"].Value) == Guid.Empty)
                    {
                        oelCuttingWastage.IdVoucherDetail = Guid.NewGuid();
                        oelCuttingWastage.IsNew = true;
                        grdCuttingWastage.Rows[i].Cells["colCuttingIdWastage"].Value = oelCuttingWastage.IdVoucherDetail;
                    }
                    else
                    {
                        oelCuttingWastage.IdVoucherDetail = Validation.GetSafeGuid(grdCuttingWastage.Rows[i].Cells["colCuttingIdWastage"].Value);
                        oelCuttingWastage.IsNew = false;
                    }
                    oelCuttingWastage.IdVoucher = IdVoucher;
                    oelCuttingWastage.IdItem = Validation.GetSafeGuid(grdCuttingWastage.Rows[i].Cells["colCuttingWastageIdItem"].Value);
                    oelCuttingWastage.Qty = Validation.GetSafeLong(grdCuttingWastage.Rows[i].Cells["colCuttingWastageQuantity"].Value);
                    oelCuttingWastage.ProcessType = 2;
                    oelCuttingWastage.ProductionProcessName = "Garments Cutting Material Wastage";
                    oelCuttingWastage.VDate = Convert.ToDateTime(grdCuttingWastage.Rows[i].Cells["colCuttingWastageDate"].Value);
                    oelCuttingWastageCollection.Add(oelCuttingWastage);
                }
            }
            #endregion
            #region Saving Section
            if (Manager.CreateMaterialsUsed(oelProductionHead, oelCuttingMaterialCollection, oelCuttingWastageCollection))
            {
                MessageBox.Show("Entry Saved / Updated Successfully...");
                if (oelProductionHead.IsNew)
                {
                    FillCuttingMaterialGrid(oelProductionHead.IdVoucher);
                    IdVoucher = oelProductionHead.IdVoucher;
                }
                else
                    FillCuttingMaterialGridByCustomerPO();
            }
            #endregion
        }
        private void btnStitchingSave_Click(object sender, EventArgs e)
        {
            #region Variables
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelCuttingMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelCuttingWastageCollection = new List<ProductionMaterialUsedEL>();
            #endregion
            #region Creating Voucher Section If Voucher Empty
            if (IdVoucher == Guid.Empty)
            {
                oelProductionHead.IdVoucher = Guid.NewGuid();
                IdVoucher = oelProductionHead.IdVoucher;
                oelProductionHead.IsNew = true;
                oelProductionHead.AccountNo = "";
                oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                oelProductionHead.IdCompany = Operations.IdCompany;
                oelProductionHead.UserId = Operations.UserID;
                oelProductionHead.IdOrder = IdOrder;
                if (Validation.GetSafeString(cbxCustomerPOS.Text) == string.Empty)
                {
                    MessageBox.Show("Please Select Customer PO...");
                    return;
                }
                oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                oelProductionHead.VDate = ProductionDate.Value;
                oelProductionHead.VDiscription = "N/A";
                oelProductionHead.Amount = 0;
                oelProductionHead.CloseDate = DateTime.Now;
                oelProductionHead.ProductionType = 2;
            }
            #endregion
            #region Creating Material Section
            if (grdStitching.Rows.Count > 0)
            {
                if (ValidateMaterialRecords(2))
                {
                    for (int i = 0; i < grdStitchingMaterials.Rows.Count - 1; i++)
                    {
                        ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                        if (grdStitchingMaterials.Rows[i].Cells["colStitchingIdMaterial"].Value == null || Validation.GetSafeGuid(grdStitchingMaterials.Rows[i].Cells["colStitchingIdMaterial"].Value) == Guid.Empty)
                        {
                            oelMaterialDetail.IdMaterialUsed = Guid.NewGuid();
                            oelMaterialDetail.IsNew = true;
                            grdStitchingMaterials.Rows[i].Cells["colStitchingIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                        }
                        else
                        {
                            oelMaterialDetail.IdMaterialUsed = Validation.GetSafeGuid(grdStitchingMaterials.Rows[i].Cells["colStitchingIdMaterial"].Value);
                            oelMaterialDetail.IsNew = false;
                        }
                        if (IdVoucher != Guid.Empty)
                        {
                            oelMaterialDetail.IdVoucher = IdVoucher;
                        }
                        else
                        {
                            oelMaterialDetail.IdVoucher = oelProductionHead.IdVoucher;
                        }
                        oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialIdItem"].Value);
                        oelMaterialDetail.AccountNo = Validation.GetSafeString(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialAccountNo"].Value);
                        if (grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialColors"].Value != null)
                        {
                            if (Validation.GetSafeGuid(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialColors"].Value) != Guid.Empty)
                            {
                                oelMaterialDetail.IdColor = Validation.GetSafeGuid(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialColors"].Value);
                            }
                            else
                            {
                                MessageBox.Show("Please Select Color...");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Color Is Defined For This Article");
                        }
                        oelMaterialDetail.BundleNo = Validation.GetSafeLong(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialBundleNo"].Value);
                        oelMaterialDetail.UsedQuantity = Validation.GetSafeDecimal(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialQuantity"].Value);
                        oelMaterialDetail.ProcessType = 2;
                        oelMaterialDetail.ProductionProcessName = "Garments Stitching Material Usage";
                        oelMaterialDetail.VDate = Convert.ToDateTime(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDate"].Value);
                        oelMaterialDetail.Rate = Validation.GetSafeDecimal(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialRate"].Value);
                        oelMaterialDetail.Amount = Validation.GetSafeDecimal(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialAmount"].Value);

                        oelCuttingMaterialCollection.Add(oelMaterialDetail);
                    }
                }
                else
                {
                    return;
                }
            }
            #endregion
            #region Saving Section
            if (Manager.CreateMaterialsUsed(oelProductionHead, oelCuttingMaterialCollection, oelCuttingWastageCollection))
            {
                MessageBox.Show("Entry Saved / Updated Successfully...");
                if (oelProductionHead.IsNew)
                {
                    FillStitchingMaterialGrid(oelProductionHead.IdVoucher);
                    IdVoucher = oelProductionHead.IdVoucher;
                }
                else
                    FillStitchingMaterialGridByCustomerPO();
            }
            #endregion
        }
        private void btnFeedoSave_Click(object sender, EventArgs e)
        {
            #region Variables
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelCuttingMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelCuttingWastageCollection = new List<ProductionMaterialUsedEL>();
            #endregion
            #region Creating Voucher Section If Voucher Empty
            if (IdVoucher == Guid.Empty)
            {
                oelProductionHead.IdVoucher = Guid.NewGuid();
                IdVoucher = oelProductionHead.IdVoucher;
                oelProductionHead.IsNew = true;
                oelProductionHead.AccountNo = "";
                oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                oelProductionHead.IdCompany = Operations.IdCompany;
                oelProductionHead.UserId = Operations.UserID;
                oelProductionHead.IdOrder = IdOrder;
                if (Validation.GetSafeString(cbxCustomerPOS.Text) == string.Empty)
                {
                    MessageBox.Show("Please Select Customer PO...");
                    return;
                }
                oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                oelProductionHead.VDate = ProductionDate.Value;
                oelProductionHead.VDiscription = "N/A";
                oelProductionHead.Amount = 0;
                oelProductionHead.CloseDate = DateTime.Now;
                oelProductionHead.ProductionType = 2;
            }
            #endregion
            #region Creating Material Section
            if (grdFeedoMaterials.Rows.Count > 0)
            {
                if (ValidateMaterialRecords(3))
                {
                    for (int i = 0; i < grdFeedoMaterials.Rows.Count - 1; i++)
                    {
                        ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                        if (grdFeedoMaterials.Rows[i].Cells["colFeedoIdMaterial"].Value == null || Validation.GetSafeGuid(grdFeedoMaterials.Rows[i].Cells["colFeedoIdMaterial"].Value) == Guid.Empty)
                        {
                            oelMaterialDetail.IdMaterialUsed = Guid.NewGuid();
                            oelMaterialDetail.IsNew = true;
                            grdFeedoMaterials.Rows[i].Cells["colFeedoIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                        }
                        else
                        {
                            oelMaterialDetail.IdMaterialUsed = Validation.GetSafeGuid(grdFeedoMaterials.Rows[i].Cells["colFeedoIdMaterial"].Value);
                            oelMaterialDetail.IsNew = false;
                        }
                        if (IdVoucher != Guid.Empty)
                        {
                            oelMaterialDetail.IdVoucher = IdVoucher;
                        }
                        else
                        {
                            oelMaterialDetail.IdVoucher = oelProductionHead.IdVoucher;
                        }
                        oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialIdItem"].Value);
                        oelMaterialDetail.AccountNo = Validation.GetSafeString(grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialAccountNo"].Value);
                        if (grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialColors"].Value != null)
                        {
                            if (Validation.GetSafeGuid(grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialColors"].Value) != Guid.Empty)
                            {
                                oelMaterialDetail.IdColor = Validation.GetSafeGuid(grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialColors"].Value);
                            }
                            else
                            {
                                MessageBox.Show("Please Select Color...");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Color Is Defined For This Article");
                        }
                        oelMaterialDetail.BundleNo = Validation.GetSafeLong(grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialBundleNo"].Value);
                        oelMaterialDetail.UsedQuantity = Validation.GetSafeDecimal(grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialUsedQuantity"].Value);
                        oelMaterialDetail.ProcessType = 2;
                        oelMaterialDetail.ProductionProcessName = "Garments Feedo Material Usage";
                        oelMaterialDetail.VDate = Convert.ToDateTime(grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialDate"].Value);
                        oelMaterialDetail.Rate = Validation.GetSafeDecimal(grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialRate"].Value);
                        oelMaterialDetail.Amount = Validation.GetSafeDecimal(grdFeedoMaterials.Rows[i].Cells["colFeedoMaterialAmount"].Value);

                        oelCuttingMaterialCollection.Add(oelMaterialDetail);
                    }
                }
                else
                {
                    return;
                }
            }
            #endregion
            #region Saving Section
            if (Manager.CreateMaterialsUsed(oelProductionHead, oelCuttingMaterialCollection, oelCuttingWastageCollection))
            {
                MessageBox.Show("Entry Saved / Updated Successfully...");
                if (oelProductionHead.IsNew)
                {
                    FillFeedoMaterialGrid(oelProductionHead.IdVoucher);
                    IdVoucher = oelProductionHead.IdVoucher;
                }
                else
                    FillFeedoMaterialGridByCustomerPO();
            }
            #endregion
        }
        private void btnBartakeSave_Click(object sender, EventArgs e)
        {
            #region Variables
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelCuttingMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelCuttingWastageCollection = new List<ProductionMaterialUsedEL>();
            #endregion
            #region Creating Voucher Section If Voucher Empty
            if (IdVoucher == Guid.Empty)
            {
                oelProductionHead.IdVoucher = Guid.NewGuid();
                IdVoucher = oelProductionHead.IdVoucher;
                oelProductionHead.IsNew = true;
                oelProductionHead.AccountNo = "";
                oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                oelProductionHead.IdCompany = Operations.IdCompany;
                oelProductionHead.UserId = Operations.UserID;
                oelProductionHead.IdOrder = IdOrder;
                if (Validation.GetSafeString(cbxCustomerPOS.Text) == string.Empty)
                {
                    MessageBox.Show("Please Select Customer PO...");
                    return;
                }
                oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                oelProductionHead.VDate = ProductionDate.Value;
                oelProductionHead.VDiscription = "N/A";
                oelProductionHead.Amount = 0;
                oelProductionHead.CloseDate = DateTime.Now;
                oelProductionHead.ProductionType = 2;
            }
            #endregion
            #region Creating Material Section
            if (grdBartakeMaterials.Rows.Count > 0)
            {
                if (ValidateMaterialRecords(4))
                {
                    for (int i = 0; i < grdBartakeMaterials.Rows.Count - 1; i++)
                    {
                        ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                        if (grdBartakeMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value == null || Validation.GetSafeGuid(grdBartakeMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value) == Guid.Empty)
                        {
                            oelMaterialDetail.IdMaterialUsed = Guid.NewGuid();
                            oelMaterialDetail.IsNew = true;
                            grdBartakeMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                        }
                        else
                        {
                            oelMaterialDetail.IdMaterialUsed = Validation.GetSafeGuid(grdBartakeMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value);
                            oelMaterialDetail.IsNew = false;
                        }
                        if (IdVoucher != Guid.Empty)
                        {
                            oelMaterialDetail.IdVoucher = IdVoucher;
                        }
                        else
                        {
                            oelMaterialDetail.IdVoucher = oelProductionHead.IdVoucher;
                        }
                        oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialIdItem"].Value);
                        oelMaterialDetail.AccountNo = Validation.GetSafeString(grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialAccountNo"].Value);
                        if (grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialColors"].Value != null)
                        {
                            if (Validation.GetSafeGuid(grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialColors"].Value) != Guid.Empty)
                            {
                                oelMaterialDetail.IdColor = Validation.GetSafeGuid(grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialColors"].Value);
                            }
                            else
                            {
                                MessageBox.Show("Please Select Color...");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Color Is Defined For This Article");
                        }
                        oelMaterialDetail.BundleNo = Validation.GetSafeLong(grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialBundleNo"].Value);
                        oelMaterialDetail.UsedQuantity = Validation.GetSafeDecimal(grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialQuantity"].Value);
                        oelMaterialDetail.ProcessType = 2;
                        oelMaterialDetail.ProductionProcessName = "Garments Bartake/Kaaj/Buttons Material Usage";
                        oelMaterialDetail.VDate = Convert.ToDateTime(grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialDate"].Value);
                        oelMaterialDetail.Rate = Validation.GetSafeDecimal(grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialRate"].Value);
                        oelMaterialDetail.Amount = Validation.GetSafeDecimal(grdBartakeMaterials.Rows[i].Cells["colBartakeMaterialAmount"].Value);

                        oelCuttingMaterialCollection.Add(oelMaterialDetail);
                    }
                }
                else
                {
                    return;
                }
            }
            #endregion
            #region Saving Section
            if (Manager.CreateMaterialsUsed(oelProductionHead, oelCuttingMaterialCollection, oelCuttingWastageCollection))
            {
                MessageBox.Show("Entry Saved / Updated Successfully...");
                if (oelProductionHead.IsNew)
                {
                    FillBartakeMaterialGrid(oelProductionHead.IdVoucher);
                    IdVoucher = oelProductionHead.IdVoucher;
                }
                else
                    FillBartakeMaterialGridByCustomerPO();
            }
            #endregion
        }
        private void btnPackingSave_Click(object sender, EventArgs e)
        {
            #region Variables
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelPackingMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelPackingWastageCollection = new List<ProductionMaterialUsedEL>();
            #endregion
            #region Creating Voucher Section If Voucher Empty
            if (IdVoucher == Guid.Empty)
            {
                oelProductionHead.IdVoucher = Guid.NewGuid();
                IdVoucher = oelProductionHead.IdVoucher;
                oelProductionHead.IsNew = true;
                oelProductionHead.AccountNo = "";
                oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                oelProductionHead.IdCompany = Operations.IdCompany;
                oelProductionHead.UserId = Operations.UserID;
                oelProductionHead.IdOrder = IdOrder;
                if (Validation.GetSafeString(cbxCustomerPOS.Text) == string.Empty)
                {
                    MessageBox.Show("Please Select Customer PO...");
                    return;
                }
                oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                oelProductionHead.VDate = ProductionDate.Value;
                oelProductionHead.VDiscription = "N/A";
                oelProductionHead.Amount = 0;
                oelProductionHead.CloseDate = DateTime.Now;
                oelProductionHead.ProductionType = 2;
            }
            #endregion
            #region Creating Material Section
            if (grdPackingMaterials.Rows.Count > 0)
            {
                if (ValidateMaterialRecords(5))
                {
                    for (int i = 0; i < grdPackingMaterials.Rows.Count - 1; i++)
                    {
                        ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                        if (grdPackingMaterials.Rows[i].Cells["colPackingIdMaterial"].Value == null || Validation.GetSafeGuid(grdPackingMaterials.Rows[i].Cells["colPackingIdMaterial"].Value) == Guid.Empty)
                        {
                            oelMaterialDetail.IdMaterialUsed = Guid.NewGuid();
                            oelMaterialDetail.IsNew = true;
                            grdPackingMaterials.Rows[i].Cells["colPackingIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                        }
                        else
                        {
                            oelMaterialDetail.IdMaterialUsed = Validation.GetSafeGuid(grdPackingMaterials.Rows[i].Cells["colBartakeIdMaterial"].Value);
                            oelMaterialDetail.IsNew = false;
                        }
                        if (IdVoucher != Guid.Empty)
                        {
                            oelMaterialDetail.IdVoucher = IdVoucher;
                        }
                        else
                        {
                            oelMaterialDetail.IdVoucher = oelProductionHead.IdVoucher;
                        }
                        oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdPackingMaterials.Rows[i].Cells["colPackingMaterialIdItem"].Value);
                        oelMaterialDetail.AccountNo = Validation.GetSafeString(grdPackingMaterials.Rows[i].Cells["colPackingMaterialAccountNo"].Value);
                        if (grdPackingMaterials.Rows[i].Cells["colPackingMaterialColors"].Value != null)
                        {
                            if (Validation.GetSafeGuid(grdPackingMaterials.Rows[i].Cells["colPackingMaterialColors"].Value) != Guid.Empty)
                            {
                                oelMaterialDetail.IdColor = Validation.GetSafeGuid(grdPackingMaterials.Rows[i].Cells["colPackingMaterialColors"].Value);
                            }
                            else
                            {
                                MessageBox.Show("Please Select Color...");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Color Is Defined For This Article");
                        }
                        oelMaterialDetail.BundleNo = Validation.GetSafeLong(grdPackingMaterials.Rows[i].Cells["colPackingMaterialBundleNo"].Value);
                        oelMaterialDetail.UsedQuantity = Validation.GetSafeLong(grdPackingMaterials.Rows[i].Cells["colPackingMaterialQuantity"].Value);
                        oelMaterialDetail.ProcessType = 2;
                        oelMaterialDetail.ProductionProcessName = "Garments Packing Material Usage";
                        oelMaterialDetail.VDate = Convert.ToDateTime(grdPackingMaterials.Rows[i].Cells["colPackingMaterialDate"].Value);
                        oelMaterialDetail.Rate = Validation.GetSafeDecimal(grdPackingMaterials.Rows[i].Cells["colPackingMaterialRate"].Value);
                        oelMaterialDetail.Amount = Validation.GetSafeDecimal(grdPackingMaterials.Rows[i].Cells["colPackingMaterialAmount"].Value);

                        oelPackingMaterialCollection.Add(oelMaterialDetail);
                    }
                }
                else
                {
                    return;
                }
            }
            #endregion
            #region Saving Section
            if (Manager.CreateMaterialsUsed(oelProductionHead, oelPackingMaterialCollection, oelPackingWastageCollection))
            {
                MessageBox.Show("Entry Saved / Updated Successfully...");
                if (oelProductionHead.IsNew)
                {
                    FillPackingMaterialGrid(oelProductionHead.IdVoucher);
                    IdVoucher = oelProductionHead.IdVoucher;
                }
                else
                    FillPackingMaterialGridByCustomerPO();
            }
            #endregion
        }
        private void btnOverHeadsSave_Click(object sender, EventArgs e)
        {
            #region Variables
            var Manager = new ProductionOverHeadsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionOverHeadEL> oelProductionOverHeadCollection = new List<ProductionOverHeadEL>();
            #endregion
            #region Creating Voucher Section If Voucher Empty
            if (IdVoucher == Guid.Empty)
            {
                oelProductionHead.IdVoucher = Guid.NewGuid();
                IdVoucher = oelProductionHead.IdVoucher;
                oelProductionHead.IsNew = true;
                oelProductionHead.AccountNo = "";
                oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                oelProductionHead.IdCompany = Operations.IdCompany;
                oelProductionHead.UserId = Operations.UserID;
                oelProductionHead.IdOrder = IdOrder;
                if (Validation.GetSafeString(cbxCustomerPOS.Text) == string.Empty)
                {
                    MessageBox.Show("Please Select Customer PO...");
                    return;
                }
                oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                oelProductionHead.VDate = ProductionDate.Value;
                oelProductionHead.VDiscription = "N/A";
                oelProductionHead.Amount = 0;
                oelProductionHead.CloseDate = DateTime.Now;
                oelProductionHead.ProductionType = 2;
            }
            #endregion
            #region Creating Head Section
            if (grdMiscCost.Rows.Count > 0)
            {
                for (int i = 0; i < grdMiscCost.Rows.Count - 1; i++)
                {
                    ProductionOverHeadEL oelProductionOverhead = new ProductionOverHeadEL();
                    if (grdMiscCost.Rows[i].Cells["colIdDetailCost"].Value == null || Validation.GetSafeGuid(grdMiscCost.Rows[i].Cells["colIdDetailCost"].Value) == Guid.Empty)
                    {
                        oelProductionOverhead.IdProductionOverHead = Guid.NewGuid();
                        oelProductionOverhead.IsNew = true;
                        grdMiscCost.Rows[i].Cells["colIdDetailCost"].Value = oelProductionOverhead.IdProductionOverHead;
                    }
                    else
                    {
                        oelProductionOverhead.IdProductionOverHead = Validation.GetSafeGuid(grdMiscCost.Rows[i].Cells["colIdDetailCost"].Value);
                        oelProductionOverhead.IsNew = false;
                    }
                    if (IdVoucher != Guid.Empty)
                    {
                        oelProductionOverhead.IdVoucher = IdVoucher;
                    }
                    else
                    {
                        oelProductionOverhead.IdVoucher = oelProductionHead.IdVoucher;
                    }
                    oelProductionOverhead.AccountNo = Validation.GetSafeString(grdMiscCost.Rows[i].Cells["colAccountNo"].Value);
                    oelProductionOverhead.Description = Validation.GetSafeString(grdMiscCost.Rows[i].Cells["colCostDescription"].Value);
                    oelProductionOverhead.ProcessType = 2;
                    oelProductionOverhead.OverHeadCost = Validation.GetSafeDecimal(grdMiscCost.Rows[i].Cells["colCost"].Value);
                    oelProductionOverhead.OverHeadDate = Convert.ToDateTime(grdMiscCost.Rows[i].Cells["colCostDate"].Value);

                    oelProductionOverHeadCollection.Add(oelProductionOverhead);
                }
            }
            #endregion
            #region Saving Section
            if (Manager.CreateUpdateProductionOverHeads(oelProductionOverHeadCollection))
            {
                MessageBox.Show("Over Head Entry Saved / Updated....");
            }
            else
            {
                MessageBox.Show("Some Problem Occured Duing Saving / Updating Over Head Process");
            }
            #endregion
        }
        #endregion
        #region Materials Grids Fill Methods
        private void FillCuttingMaterialGrid(Guid IdVoucher)
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByVoucher(IdVoucher, 2, "Garments Cutting Material Usage");
            if (listMaterials.Count > 0)
            {
                if (listMaterials.Count > 0)
                {
                    grdCuttingMaterialUsed.Rows.Clear();
                    FillMaterials(listMaterials, "Garments Cutting");
                }
            }
        }
        private void FillCuttingMaterialGridByCustomerPO()
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 2, "Garments Cutting Material Usage");
            if (listMaterials.Count > 0)
            {
                grdCuttingMaterialUsed.Rows.Clear();
                FillMaterials(listMaterials, "Garments Cutting");
            }
        }
        private void FillStitchingMaterialGrid(Guid IdVoucher)
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByVoucher(IdVoucher, 2, "Garments Stitching Material Usage");
            if (listMaterials.Count > 0)
            {
                if (listMaterials.Count > 0)
                {
                    grdStitchingMaterials.Rows.Clear();
                    FillMaterials(listMaterials, "Garments Stitching");
                }
            }
        }
        private void FillStitchingMaterialGridByCustomerPO()
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 2, "Garments Stitching Material Usage");
            if (listMaterials.Count > 0)
            {
                grdStitchingMaterials.Rows.Clear();
                FillMaterials(listMaterials, "Garments Stitching");
            }
        }
        private void FillFeedoMaterialGrid(Guid IdVoucher)
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByVoucher(IdVoucher, 2, "Garments Feedo Material Usage");
            if (listMaterials.Count > 0)
            {
                if (listMaterials.Count > 0)
                {
                    grdFeedoMaterials.Rows.Clear();
                    FillMaterials(listMaterials, "Garments Feedo/Saftey");
                }
            }
        }
        private void FillFeedoMaterialGridByCustomerPO()
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 2, "Garments Feedo Material Usage");
            if (listMaterials.Count > 0)
            {
                grdFeedoMaterials.Rows.Clear();
                FillMaterials(listMaterials, "Garments Feedo/Saftey");
            }
        }
        private void FillBartakeMaterialGrid(Guid IdVoucher)
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByVoucher(IdVoucher, 2, "Garments Bartake/Kaaj/Buttons Material Usage");
            if (listMaterials.Count > 0)
            {
                if (listMaterials.Count > 0)
                {
                    grdBartakeMaterials.Rows.Clear();
                    FillMaterials(listMaterials, "Garments Bartake/Kaaj/Buttons");
                }
            }
        }
        private void FillBartakeMaterialGridByCustomerPO()
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 2, "Garments Bartake/Kaaj/Buttons Material Usage");
            if (listMaterials.Count > 0)
            {
                grdBartakeMaterials.Rows.Clear();
                FillMaterials(listMaterials, "Garments Bartake/Kaaj/Buttons");
            }
        }
        private void FillPackingMaterialGrid(Guid IdVoucher)
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByVoucher(IdVoucher, 2, "Garments Packing Material Usage");
            if (listMaterials.Count > 0)
            {
                if (listMaterials.Count > 0)
                {
                    grdPackingMaterials.Rows.Clear();
                    FillMaterials(listMaterials, "Garments Packing");
                }
            }
        }
        private void FillPackingMaterialGridByCustomerPO()
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 2, "Garments Packing Material Usage");
            if (listMaterials.Count > 0)
            {
                grdPackingMaterials.Rows.Clear();
                FillMaterials(listMaterials, "Garments Packing");
            }
        }

        #endregion
        #region Gloves Opening Stock Grid Events
        private void grdOpeningStock_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 4)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 5)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 6)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdOpeningStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                grdOpeningStock.Rows[e.RowIndex].Cells["colOrderOpeningStockAmount"].Value = Validation.GetSafeDecimal(grdOpeningStock.Rows[e.RowIndex].Cells["colOrderOpeningStockQuantity"].Value) * Validation.GetSafeDecimal(grdOpeningStock.Rows[e.RowIndex].Cells["colOrderOpeningStockRates"].Value);
            }
        }
        private void grdOpeningStock_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdOpeningStock.CurrentCellAddress.X == 2)
            {
                TextBox txtOpeningStockItemName = e.Control as TextBox;
                if (txtOpeningStockItemName != null)
                {
                    txtOpeningStockItemName.KeyPress -= new KeyPressEventHandler(txtOpeningStockItemName_KeyPress);
                    txtOpeningStockItemName.KeyPress += new KeyPressEventHandler(txtOpeningStockItemName_KeyPress);
                }
            }
        }
        void txtOpeningStockItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdOpeningStock.CurrentCellAddress.X == 2)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Garments Opening Stock";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
    }
}