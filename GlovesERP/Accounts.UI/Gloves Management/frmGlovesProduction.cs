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
    public partial class frmGlovesProduction : MetroForm
    {
        #region Variables
        frmFindAccounts frmfindAccount;
        frmStockAccounts frmstockAccounts;
        frmWorkPurchases frmworkpurchases;
        Guid IdVoucher = Guid.Empty;
        Guid IdOrder = Guid.Empty;
        Guid IdBrand = Guid.Empty;
        Guid IdCutting;
        Guid IdStitching;
        Guid IdPrinting;
        Guid IdOverLock;
        Guid IdMagzi;
        Guid IdInspection;
        Guid IdPacking;
        Guid IdQuality;
        Guid IdEntity;
        string LoadType;
        string EventFiringName;
        string EmpAccountNo = "";
        string EmpAccountName = "";
        decimal postAmount;
        bool EntryAlreadyDone;
        decimal AvgProcessValue = 0;
        decimal ProcessQuantity = 0;
        int IdDepartment = 0;
        #endregion
        #region Windows Form Events
        public frmGlovesProduction()
        {
            InitializeComponent();
        }
        private void frmGarmentProduction_Load(object sender, EventArgs e)
        {
            this.grdCutting.AutoGenerateColumns = false;
            this.grdStitching.AutoGenerateColumns = false;
            this.grdCuffPrinting.AutoGenerateColumns = false;
            this.grdCuffPrinting.AutoGenerateColumns = false;
            this.grdOverlockMaterials.AutoGenerateColumns = false;
            this.grdMagzi.AutoGenerateColumns = false;
            this.grdInspection.AutoGenerateColumns = false;
            this.grdPacking.AutoGenerateColumns = false;
            ProductionTab.SelectedIndex = 0;
            FillMaxProductionNo();
            FillCustomerPos();
        }
        private void FillMaxProductionNo()
        {
            var Manager = new ProductionProcessesHeadBLL();
            VEditBox.Text = Validation.GetSafeString(Manager.GetMaxProductionProcessCode(Operations.IdCompany, 1, 1));
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
            if (e.ColumnIndex == 13)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 14)
            {
                e.Value = "Post";
            }
        }
        private void grdCutting_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdCutting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 13)
            {
                if (Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value), Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            grdCutting.Rows.RemoveAt(e.RowIndex);
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                    else if (grdCutting.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
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
            else if (e.ColumnIndex == 14)
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
                    oelProductionHead.AccountNo = string.Empty;
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdCutting == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdCutting;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Cutting";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = IdVoucher;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
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
                    oelProductionDetail.ProductionProcessName = "Gloves Cutting";
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingIdItem"].Value);
                    oelProductionDetail.IdArticle = Guid.Empty;
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty; //Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingColors"].Value);
                    oelProductionDetail.IdBrand = Guid.Empty;
                    oelProductionDetail.GType = 0;
                    oelProductionDetail.WorkType = 0;
                    oelProductionDetail.PStyle = "";
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdCutting.Rows[e.RowIndex].Cells["colCuttingQty"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.Meters = 0;
                    oelProductionDetail.BQuantity = 0;
                    oelProductionDetail.RepairQuantity = 0;
                    oelProductionDetail.PackingCartons = 0;
                    oelProductionDetail.InspectorRate = 0;
                    oelProductionDetail.InspectorAmount = 0;
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
                                else if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountType"].Value) != "Employees")
                                {
                                    //frmworkpurchases = new frmWorkPurchases();
                                    //frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //frmworkpurchases.IdEntity = IdEntity;
                                    //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //frmworkpurchases.PurchasesType = "Gloves Cutting Purchases";
                                    //frmworkpurchases.ProcessName = "Gloves Cutting";
                                    //frmworkpurchases.ProcessAmount = postAmount;
                                    //frmworkpurchases.ShowDialog();
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
                        frmworkpurchases.PurchasesType = "Gloves Cutting Purchases";
                        frmworkpurchases.ProcessName = "Gloves Cutting";
                        frmworkpurchases.ProcessAmount = postAmount;
                        frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelTanneryProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
        }
        private void grdCutting_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                grdCutting.Rows[e.RowIndex].Cells["colCuttingAmount"].Value = Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colCuttingQty"].Value) * Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colCuttingRate"].Value);
            }
        }
        private void grdCutting_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCutting.CurrentCellAddress.X == 7)
            {
                TextBox txtCuttingVendorName = e.Control as TextBox;
                if (txtCuttingVendorName != null)
                {
                    txtCuttingVendorName.KeyPress -= new KeyPressEventHandler(txtCuttingVendorName_KeyPress);
                    txtCuttingVendorName.KeyPress += new KeyPressEventHandler(txtCuttingVendorName_KeyPress);
                }
            }
            else if (grdCutting.CurrentCellAddress.X == 8)
            {
                TextBox txtCuttingRecievedItemName = e.Control as TextBox;
                if (txtCuttingRecievedItemName != null)
                {
                    txtCuttingRecievedItemName.KeyPress -= new KeyPressEventHandler(txtCuttingRecievedItemName_KeyPress);
                    txtCuttingRecievedItemName.KeyPress += new KeyPressEventHandler(txtCuttingRecievedItemName_KeyPress);
                }
            }
        }
        void txtCuttingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCutting.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Cuff Cutting";
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
        void txtCuttingRecievedItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCutting.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Cutting";
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
        #region Cutting Grid Material Events
        private void grdCuttingMaterialUsed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                e.Value = "Delete";
            }
        }
        private void grdCuttingMaterialUsed_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                var Manager = new ItemsBLL();
                //ProcessQuantity = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialIdItem"].Value))[0].Qty;
                ProcessQuantity = Manager.GetRawItemClosingStockByEmployee(Operations.IdCompany, Validation.GetSafeGuid(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialIdItem"].Value), Validation.GetSafeString(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMateriaAccountNo"].Value))[0].Qty;
                if (Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialUsedQty"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                    grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialUsedQty"].Value = "";
                    if (grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialRate"].Value == null && Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialRate"].Value) == 0)
                    {
                        grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialRate"].Value = "";
                        grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialAmount"].Value = "";
                    }
                    //grdProducts.Rows[e.RowIndex].Cells["colRate"].Value = Manager.GetItemAverageRate(Validation.GetSafeGuid(grdProducts.Rows[e.RowIndex].Cells["colIdItem"].Value))[0].TotalAmount;
                }
                else
                {
                    grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialRate"].Value = Manager.GetRubberizingItemsAvgValue(Validation.GetSafeGuid(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialIdItem"].Value)).ToString("0.00");
                    grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialAmount"].Value = (Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialRate"].Value) *
                                                                                                      Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingMaterialUsedQty"].Value)).ToString("0.00");
                }
            }
        }
        private void grdCuttingMaterialUsed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                var manager = new ProductionMaterialsBLL();
                Guid Id = Validation.GetSafeGuid(grdCuttingMaterialUsed.Rows[e.RowIndex].Cells["colCuttingIdMaterial"].Value);
                if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    if (Id != Guid.Empty)
                    {
                        if (MessageBox.Show("Are You Sure To Delete...", "Deleting Material", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (manager.DeleteMaterialEntry(Id).IsSuccess)
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                grdCuttingMaterialUsed.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                    }
                    else
                    {
                        grdCuttingMaterialUsed.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    MessageBox.Show("You have no administrator rights");
                }
            }
        }
        private void grdCuttingMaterialUsed_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCuttingMaterialUsed.CurrentCellAddress.X == 4)
            {
                TextBox txtCuttingMaterialName = e.Control as TextBox;
                if (txtCuttingMaterialName != null)
                {
                    txtCuttingMaterialName.KeyPress -= new KeyPressEventHandler(txtCuttingMaterialName_KeyPress);
                    txtCuttingMaterialName.KeyPress += new KeyPressEventHandler(txtCuttingMaterialName_KeyPress);
                }
            }
            else if (grdCuttingMaterialUsed.CurrentCellAddress.X == 6)
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
            if (grdCuttingMaterialUsed.CurrentCellAddress.X == 4)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Cutting Materials";
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
            if (grdCuttingMaterialUsed.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Cutting Material Worker Account";
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
                    EventFiringName = "Gloves Cutting Wastage";
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
        #region Talli Cutting Grid Events
        private void grdTalliCutting_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (grdTalliCutting.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdTalliCutting_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 14)
            {
                e.Value = "Post";
            }
        }
        private void grdTalliCutting_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdTalliCutting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 13)
            {
                if (Validation.GetSafeGuid(grdTalliCutting.Rows[e.RowIndex].Cells["colIdTalliCutting"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdTalliCutting.Rows[e.RowIndex].Cells["colIdTalliCutting"].Value), Validation.GetSafeGuid(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            grdTalliCutting.Rows.RemoveAt(e.RowIndex);
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                    else if (grdTalliCutting.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    //else
                    //{
                    //    if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdTalliCutting.Rows[e.RowIndex].Cells["colIdTalliCutting"].Value), Validation.GetSafeGuid(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingIdVoucher"].Value)))
                    //    {
                    //        MessageBox.Show("Record Deleted Successfully....");
                    //        ProductionTab_SelectedIndexChanged(sender, e);
                    //    }
                    //}
                }
                else
                {
                    for (int i = 0; i < grdTalliCutting.Columns.Count; i++)
                    {
                        grdTalliCutting.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 14)
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
                    oelProductionHead.AccountNo = string.Empty;
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdCutting == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdCutting;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Talli Cutting";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = IdVoucher;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    if (grdTalliCutting.Rows[e.RowIndex].Cells["colIdTalliCutting"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdTalliCutting.Rows[e.RowIndex].Cells["colIdTalliCutting"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdTalliCutting.Rows[e.RowIndex].Cells["colIdTalliCutting"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdTalliCutting.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingAccountNo"].Value);
                    oelProductionDetail.StitcherAccountNo = "0";
                    EmpAccountNo = Validation.GetSafeString(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.ProductionProcessName = "Gloves Talli Cutting";
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingIdItem"].Value);
                    oelProductionDetail.IdArticle = Guid.Empty;
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty; //Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingColors"].Value);
                    oelProductionDetail.IdBrand = Guid.Empty;
                    oelProductionDetail.GType = 0;
                    oelProductionDetail.WorkType = 0;
                    oelProductionDetail.PStyle = "";
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingQty"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.Meters = 0;
                    oelProductionDetail.BQuantity = 0;
                    oelProductionDetail.RepairQuantity = 0;
                    oelProductionDetail.PackingCartons = 0;
                    oelProductionDetail.InspectorRate = 0;
                    oelProductionDetail.InspectorAmount = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingAccountType"].Value) == "Employees")
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
                                if (Validation.GetSafeString(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingAccountType"].Value) == "Employees")
                                {
                                    grdTalliCutting.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted....");
                                }
                                else if (Validation.GetSafeString(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingAccountType"].Value) != "Employees")
                                {
                                    //frmworkpurchases = new frmWorkPurchases();
                                    //frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //frmworkpurchases.IdEntity = IdEntity;
                                    //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //frmworkpurchases.PurchasesType = "Gloves Cutting Purchases";
                                    //frmworkpurchases.ProcessName = "Gloves Cutting";
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
                        //frmworkpurchases.PurchasesType = "Gloves Talli Cutting Purchases";
                        //frmworkpurchases.ProcessName = "Gloves Talli Cutting";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelTanneryProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
        }
        private void grdTalliCutting_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingAmount"].Value = Validation.GetSafeDecimal(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingQty"].Value) * Validation.GetSafeDecimal(grdTalliCutting.Rows[e.RowIndex].Cells["colTalliCuttingRate"].Value);
            }
        }
        private void grdTalliCutting_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdTalliCutting.CurrentCellAddress.X == 7)
            {
                TextBox txtTalliCuttingVendorName = e.Control as TextBox;
                if (txtTalliCuttingVendorName != null)
                {
                    txtTalliCuttingVendorName.KeyPress -= new KeyPressEventHandler(txtTalliCuttingVendorName_KeyPress);
                    txtTalliCuttingVendorName.KeyPress += new KeyPressEventHandler(txtTalliCuttingVendorName_KeyPress);
                }
            }
            else if (grdTalliCutting.CurrentCellAddress.X == 8)
            {
                TextBox txtTalliCuttingRecievedItemName = e.Control as TextBox;
                if (txtTalliCuttingRecievedItemName != null)
                {
                    txtTalliCuttingRecievedItemName.KeyPress -= new KeyPressEventHandler(txtTalliCuttingRecievedItemName_KeyPress);
                    txtTalliCuttingRecievedItemName.KeyPress += new KeyPressEventHandler(txtTalliCuttingRecievedItemName_KeyPress);
                }
            }
        }
        void txtTalliCuttingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdTalliCutting.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Talli Cutting";
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
        void txtTalliCuttingRecievedItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdTalliCutting.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Talli Cutting";
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
        #region Talli Cutting Grid Material Events
        private void grdTalliCuttingMaterialUsed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                e.Value = "Delete";
            }
        }
        private void grdTalliCuttingMaterialUsed_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                var Manager = new ItemsBLL();
                //ProcessQuantity = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialIdItem"].Value))[0].Qty;
                ProcessQuantity = Manager.GetRawItemClosingStockByEmployee(Operations.IdCompany, Validation.GetSafeGuid(grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialIdItem"].Value), Validation.GetSafeString(grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialAccountNo"].Value))[0].Qty;
                if (Validation.GetSafeDecimal(grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialUsedQty"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                    grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialUsedQty"].Value = "";
                    if (grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialRate"].Value == null && Validation.GetSafeDecimal(grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialRate"].Value) == 0)
                    {
                        grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialRate"].Value = "";
                        grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialAmount"].Value = "";
                    }
                    //grdProducts.Rows[e.RowIndex].Cells["colRate"].Value = Manager.GetItemAverageRate(Validation.GetSafeGuid(grdProducts.Rows[e.RowIndex].Cells["colIdItem"].Value))[0].TotalAmount;
                }
                else
                {
                    grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialRate"].Value = Manager.GetItemsAvgValue(Validation.GetSafeGuid(grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialIdItem"].Value)).ToString("0.00");
                    grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialAmount"].Value = (Validation.GetSafeDecimal(grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialRate"].Value) *
                                                                                                      Validation.GetSafeDecimal(grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingMaterialUsedQty"].Value)).ToString("0.00");
                }
            }
        }
        private void grdTalliCuttingMaterialUsed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                var manager = new ProductionMaterialsBLL();
                Guid Id = Validation.GetSafeGuid(grdTalliCuttingMaterialUsed.Rows[e.RowIndex].Cells["colTalliCuttingIdMaterial"].Value);
                if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    if (Id != Guid.Empty)
                    {
                        if (MessageBox.Show("Are You Sure To Delete...", "Deleting Material", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (manager.DeleteMaterialEntry(Id).IsSuccess)
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                grdTalliCuttingMaterialUsed.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                    }
                    else
                    {
                        grdTalliCuttingMaterialUsed.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    MessageBox.Show("You have no administrator rights");
                }
            }
        }
        private void grdTalliCuttingMaterialUsed_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdTalliCuttingMaterialUsed.CurrentCellAddress.X == 4)
            {
                TextBox txtTalliCuttingMaterialName = e.Control as TextBox;
                if (txtTalliCuttingMaterialName != null)
                {
                    txtTalliCuttingMaterialName.KeyPress -= new KeyPressEventHandler(txtTalliCuttingMaterialName_KeyPress);
                    txtTalliCuttingMaterialName.KeyPress += new KeyPressEventHandler(txtTalliCuttingMaterialName_KeyPress);
                }
            }
            else if (grdTalliCuttingMaterialUsed.CurrentCellAddress.X == 6)
            {
                TextBox txtTalliCuttingMaterialWorkerName = e.Control as TextBox;
                if (txtTalliCuttingMaterialWorkerName != null)
                {
                    txtTalliCuttingMaterialWorkerName.KeyPress -= new KeyPressEventHandler(txtTalliCuttingMaterialWorkerName_KeyPress);
                    txtTalliCuttingMaterialWorkerName.KeyPress += new KeyPressEventHandler(txtTalliCuttingMaterialWorkerName_KeyPress);
                }
            }
        }
        void txtTalliCuttingMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdTalliCuttingMaterialUsed.CurrentCellAddress.X == 4)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Talli Cutting Materials";
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
        void txtTalliCuttingMaterialWorkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdTalliCuttingMaterialUsed.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Talli Cutting Material Worker Account";
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
        #region Talli Cutting Grid Wastage
        private void grdTalliCuttingWastage_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdTalliCuttingWastage.CurrentCellAddress.X == 3)
            {
                TextBox txtTalliCuttingWastageMaterialName = e.Control as TextBox;
                if (txtTalliCuttingWastageMaterialName != null)
                {
                    txtTalliCuttingWastageMaterialName.KeyPress -= new KeyPressEventHandler(txtTalliCuttingWastageMaterialName_KeyPress);
                    txtTalliCuttingWastageMaterialName.KeyPress += new KeyPressEventHandler(txtTalliCuttingWastageMaterialName_KeyPress);
                }
            }
        }
        void txtTalliCuttingWastageMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdTalliCuttingWastage.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Talli Cutting Wastage";
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
        #region Cuff Printing Grid Events
        private void grdCuffPrinting_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (grdCuffPrinting.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdCuffPrinting_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 15)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 16)
            {
                e.Value = "Posting";
            }
        }
        private void grdCuffPrinting_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdCuffPrinting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 15)
            {
                if (Validation.GetSafeGuid(grdCuffPrinting.Rows[e.RowIndex].Cells["colIdCuffPrinting"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdCuffPrinting.Rows[e.RowIndex].Cells["colIdCuffPrinting"].Value),
                            Validation.GetSafeGuid(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            grdCuffPrinting.Rows.RemoveAt(e.RowIndex);
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                    else if (grdCuffPrinting.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    //else
                    //{
                    //    if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdCuffPrinting.Rows[e.RowIndex].Cells["colIdCuffPrinting"].Value),
                    //        Validation.GetSafeGuid(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingVoucher"].Value)))
                    //    {
                    //        MessageBox.Show("Record Deleted Successfully....");
                    //        ProductionTab_SelectedIndexChanged(sender, e);
                    //    }
                    //}
                }
                else
                {
                    for (int i = 0; i < grdCuffPrinting.Columns.Count; i++)
                    {
                        grdCuffPrinting.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 16)
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
                    oelProductionHead.AccountNo = string.Empty;
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdPrinting == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdPrinting;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Printing";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = IdVoucher;
                    if (grdCuffPrinting.Rows[e.RowIndex].Cells["colIdCuffPrinting"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdCuffPrinting.Rows[e.RowIndex].Cells["colIdCuffPrinting"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdCuffPrinting.Rows[e.RowIndex].Cells["colIdCuffPrinting"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdCuffPrinting.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingAccountNo"].Value);
                    oelProductionDetail.StitcherAccountNo = "0";
                    EmpAccountNo = Validation.GetSafeString(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingVendorName"].Value);
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingIdItem"].Value);
                    oelProductionDetail.IdArticle = Validation.GetSafeGuid(grdCuffPrinting.Rows[e.RowIndex].Cells["colcuffprintingIdArticle"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.ProductionProcessName = "Gloves Cuff Printing";
                    oelProductionDetail.GType = 0;
                    oelProductionDetail.GarmentWorkType = 0;
                    oelProductionDetail.PStyle = "";

                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingQuantity"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingAccountType"].Value) == "Employees")
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
                            IdPrinting = oelProductionProcess.IdProductionProcess;
                            //if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingAccountType"].Value) == "Employees")
                                {
                                    grdCuffPrinting.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted....");
                                }
                                else if (Validation.GetSafeString(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingAccountType"].Value) != "Employees")
                                {
                                    //    frmworkpurchases = new frmWorkPurchases();
                                    //    frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //    frmworkpurchases.IdEntity = IdEntity;
                                    //    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //    frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //    frmworkpurchases.PurchasesType = "Gloves Printing Purchases";
                                    //    frmworkpurchases.ProcessName = "Gloves Printing";
                                    //    frmworkpurchases.ProcessAmount = postAmount;
                                    //    frmworkpurchases.ShowDialog();
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
                        //frmworkpurchases.PurchasesType = "Gloves Printing Purchases";
                        //frmworkpurchases.ProcessName = "Gloves Printing";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdCuffPrinting_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingAmount"].Value = Validation.GetSafeDecimal(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingQuantity"].Value) * Validation.GetSafeDecimal(grdCuffPrinting.Rows[e.RowIndex].Cells["colCuffPrintingRate"].Value);
            }
        }
        private void grdCuffPrinting_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdCuffPrinting_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCuffPrinting.CurrentCellAddress.X == 8)
            {
                TextBox txtPrintingVendorName = e.Control as TextBox;
                if (txtPrintingVendorName != null)
                {
                    txtPrintingVendorName.KeyPress -= new KeyPressEventHandler(txtPrintingVendorName_KeyPress);
                    txtPrintingVendorName.KeyPress += new KeyPressEventHandler(txtPrintingVendorName_KeyPress);
                }
            }
            else if (grdCuffPrinting.CurrentCellAddress.X == 9)
            {
                TextBox txtPrintingBrand = e.Control as TextBox;
                if (txtPrintingBrand != null)
                {
                    txtPrintingBrand.KeyPress -= new KeyPressEventHandler(txtPrintingBrand_KeyPress);
                    txtPrintingBrand.KeyPress += new KeyPressEventHandler(txtPrintingBrand_KeyPress);
                }
            }
            else if (grdCuffPrinting.CurrentCellAddress.X == 10)
            {
                TextBox txtCuffPrintingArticle = e.Control as TextBox;
                if (txtCuffPrintingArticle != null)
                {
                    txtCuffPrintingArticle.KeyPress -= new KeyPressEventHandler(txtCuffPrintingArticle_KeyPress);
                    txtCuffPrintingArticle.KeyPress += new KeyPressEventHandler(txtCuffPrintingArticle_KeyPress);
                }
            }
        }        
        void txtPrintingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuffPrinting.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Printing";
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
        void txtPrintingBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuffPrinting.CurrentCellAddress.X == 9)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "PrintingBrand";
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
        void txtCuffPrintingArticle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuffPrinting.CurrentCellAddress.X == 10)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "CuffPrintingArticle";
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
        #region Gloves Printing Grid Material Events
        private void grdCuffPrintingMaterial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                e.Value = "Delete";
            }
        }
        private void grdCuffPrintingMaterial_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdCuffPrintingMaterial_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            #region Variables
            var Manager = new ItemsBLL();
            string ProcessName = string.Empty;
            #endregion
            #region Closing Stock Region
            if (e.ColumnIndex == 8)
            {
                if (Validation.GetSafeString(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colPrintingMaterialDepartment"].Value) == "Cuff Cutting")
                {
                    IdDepartment = 1;
                    ProcessName = "Gloves Cutting";
                }
                else if (Validation.GetSafeString(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colPrintingMaterialDepartment"].Value) == "Cuff OverLock")
                {
                    IdDepartment = 3;
                    ProcessName = "Gloves OverLock";
                }
                else if (Validation.GetSafeString(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colPrintingMaterialDepartment"].Value) == "Cuff Magzi")
                {
                    IdDepartment = 4;
                    ProcessName = "Gloves Magzi";
                }
                else if (Validation.GetSafeString(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colPrintingMaterialDepartment"].Value) == "Cuff Tape")
                {
                    IdDepartment = 5;
                    ProcessName = "Gloves Tape";
                }
                else
                {
                    IdDepartment = -1;
                }
                if (IdDepartment == -1)
                {
                    //ProcessQuantity = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialIdItem"].Value))[0].Qty;
                    ProcessQuantity = Manager.GetRawItemClosingStockByEmployee(Operations.IdCompany, Validation.GetSafeGuid(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialIdItem"].Value), Validation.GetSafeString(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialAccountNo"].Value))[0].Qty;
                }
                else
                {
                    ProcessQuantity = GetGlovesProductionClosingStockByCustomerPO(Validation.GetSafeGuid(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialIdItem"].Value), IdDepartment, ProcessName);
                }
                if (Validation.GetSafeDecimal(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialUsedQuantity"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                    grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialUsedQuantity"].Value = "";
                    grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialRate"].Value = "";
                    grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialAmount"].Value = "";

                }
                else
                {
                    /// Calculating Average Value Here....
                    if (IdDepartment == -1)
                    {
                        grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialRate"].Value = Manager.GetRawMaterialItemsAvgValue(Validation.GetSafeGuid(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialIdItem"].Value)).ToString("0.00");
                        grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialAmount"].Value = (Validation.GetSafeDecimal(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialUsedQuantity"].Value)
                                                                                                                * Validation.GetSafeDecimal(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialRate"].Value)).ToString("0.00");
                    }
                    else
                    {
                        grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialRate"].Value = GetGlovesAvgCostingByCustomerPO(Validation.GetSafeGuid(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialIdItem"].Value), IdDepartment, ProcessName, "").ToString("0.00");
                        grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialAmount"].Value = (Validation.GetSafeDecimal(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialUsedQuantity"].Value)
                                                                                                                * Validation.GetSafeDecimal(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingMaterialRate"].Value)).ToString("0.00");

                    }
                }
            }
            #endregion
        }
        private void grdCuffPrintingMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                var manager = new ProductionMaterialsBLL();
                Guid Id = Validation.GetSafeGuid(grdCuffPrintingMaterial.Rows[e.RowIndex].Cells["colCuffPrintingIdMaterial"].Value);
                if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    if (Id != Guid.Empty)
                    {
                        if (MessageBox.Show("Are You Sure To Delete...", "Deleting Material", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (manager.DeleteMaterialEntry(Id).IsSuccess)
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                grdCuffPrintingMaterial.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                    }
                    else
                    {
                        grdCuffPrintingMaterial.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    MessageBox.Show("You have no administrator rights");
                }
            }
        }

        private void grdCuffPrintingMaterial_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCuffPrintingMaterial.CurrentCellAddress.X == 4)
            {
                TextBox txtCuffPrintingMaterialName = e.Control as TextBox;
                if (txtCuffPrintingMaterialName != null)
                {
                    txtCuffPrintingMaterialName.KeyPress -= new KeyPressEventHandler(txtCuffPrintingMaterialName_KeyPress);
                    txtCuffPrintingMaterialName.KeyPress += new KeyPressEventHandler(txtCuffPrintingMaterialName_KeyPress);
                }
            }
            else if (grdCuffPrintingMaterial.CurrentCellAddress.X == 6)
            {
                TextBox txtPrintingMaterialWorkerName = e.Control as TextBox;
                if (txtPrintingMaterialWorkerName != null)
                {
                    txtPrintingMaterialWorkerName.KeyPress -= new KeyPressEventHandler(txtPrintingMaterialWorkerName_KeyPress);
                    txtPrintingMaterialWorkerName.KeyPress += new KeyPressEventHandler(txtPrintingMaterialWorkerName_KeyPress);
                }
            }
        }
        void txtCuffPrintingMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuffPrintingMaterial.CurrentCellAddress.X == 4)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Printing Materials";
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
        void txtPrintingMaterialWorkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuffPrintingMaterial.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Printing Material Worker Account";
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
        #region Gloves Printing Grid Wastage
        private void grdCuffPrintingWastage_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (grdCuffPrintingWastage.CurrentCellAddress.X == 3)
            {
                TextBox txtCuffPrintingWastageMaterialName = e.Control as TextBox;
                if (txtCuffPrintingWastageMaterialName != null)
                {
                    txtCuffPrintingWastageMaterialName.KeyPress -= new KeyPressEventHandler(txtCuffPrintingWastageMaterialName_KeyPress);
                    txtCuffPrintingWastageMaterialName.KeyPress += new KeyPressEventHandler(txtCuffPrintingWastageMaterialName_KeyPress);
                }
            }
        }
        void txtCuffPrintingWastageMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCuffPrintingWastage.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Printing Wastage";
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
        #region OverLock Grid Events
        private void grdOverLock_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (grdOverLock.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdOverLock_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdOverLock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 15)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 16)
            {
                e.Value = "Posting";
            }
        }
        private void grdOverLock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 15)
            {
                if (Validation.GetSafeGuid(grdOverLock.Rows[e.RowIndex].Cells["colIdOverLock"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdOverLock.Rows[e.RowIndex].Cells["colIdOverLock"].Value),
                            Validation.GetSafeGuid(grdOverLock.Rows[e.RowIndex].Cells["colOverLockIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            grdOverLock.Rows.RemoveAt(e.RowIndex);
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                    else if (grdOverLock.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    //else
                    //{
                    //    if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdOverLock.Rows[e.RowIndex].Cells["colIdOverLock"].Value),
                    //        Validation.GetSafeGuid(grdOverLock.Rows[e.RowIndex].Cells["colOverLockIdVoucher"].Value)))
                    //    {
                    //        MessageBox.Show("Record Deleted Successfully....");
                    //        ProductionTab_SelectedIndexChanged(sender, e);
                    //    }
                    //}
                }
                else
                {
                    for (int i = 0; i < grdOverLock.Columns.Count; i++)
                    {
                        grdOverLock.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 16)
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
                    oelProductionHead.AccountNo = string.Empty;
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdOverLock == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdOverLock;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves OverLock";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = IdVoucher;
                    if (grdOverLock.Rows[e.RowIndex].Cells["colIdOverLock"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdOverLock.Rows[e.RowIndex].Cells["colIdOverLock"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdOverLock.Rows[e.RowIndex].Cells["colIdOverLock"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdOverLock.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdOverLock.Rows[e.RowIndex].Cells["colOverLockAccountNo"].Value);
                    oelProductionDetail.StitcherAccountNo = "0";
                    EmpAccountNo = Validation.GetSafeString(grdOverLock.Rows[e.RowIndex].Cells["colOverLockAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdOverLock.Rows[e.RowIndex].Cells["colOverLockVendorName"].Value);
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdOverLock.Rows[e.RowIndex].Cells["colOverLockIdItem"].Value);
                    oelProductionDetail.IdArticle = Validation.GetSafeGuid(grdOverLock.Rows[e.RowIndex].Cells["colOverLockIdArticle"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdOverLock.Rows[e.RowIndex].Cells["colOverLockSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.ProductionProcessName = "Gloves OverLock";
                    oelProductionDetail.GType = 0;
                    oelProductionDetail.GarmentWorkType = 0;
                    oelProductionDetail.PStyle = "";

                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdOverLock.Rows[e.RowIndex].Cells["colOverLockQuantity"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdOverLock.Rows[e.RowIndex].Cells["colOverLockDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdOverLock.Rows[e.RowIndex].Cells["colOverLockRates"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdOverLock.Rows[e.RowIndex].Cells["colOverLockAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdOverLock.Rows[e.RowIndex].Cells["colOverLockAccountType"].Value) == "Employees")
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
                            IdOverLock = oelProductionProcess.IdProductionProcess;
                            //if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdOverLock.Rows[e.RowIndex].Cells["colOverLockAccountType"].Value) == "Employees")
                                {
                                    grdOverLock.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted.....");
                                }
                                else if (Validation.GetSafeString(grdOverLock.Rows[e.RowIndex].Cells["colOverLockAccountType"].Value) != "Employees")
                                {
                                    //frmworkpurchases = new frmWorkPurchases();
                                    //frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //frmworkpurchases.IdEntity = IdEntity;
                                    //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //frmworkpurchases.PurchasesType = "Gloves OverLock Purchases";
                                    //frmworkpurchases.ProcessName = "Gloves OverLock";
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
                        //frmworkpurchases.PurchasesType = "Gloves OverLock Purchases";
                        //frmworkpurchases.ProcessName = "Gloves OverLock";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdOverLock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                grdOverLock.Rows[e.RowIndex].Cells["colOverLockAmount"].Value = Validation.GetSafeDecimal(grdOverLock.Rows[e.RowIndex].Cells["colOverLockQuantity"].Value) * Validation.GetSafeDecimal(grdOverLock.Rows[e.RowIndex].Cells["colOverLockRates"].Value);
            }
        }
        private void grdOverLock_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdOverLock_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdOverLock.CurrentCellAddress.X == 8)
            {
                TextBox txtOverLockVendorName = e.Control as TextBox;
                if (txtOverLockVendorName != null)
                {
                    txtOverLockVendorName.KeyPress -= new KeyPressEventHandler(txtOverLockVendorName_KeyPress);
                    txtOverLockVendorName.KeyPress += new KeyPressEventHandler(txtOverLockVendorName_KeyPress);
                }
            }
            else if (grdOverLock.CurrentCellAddress.X == 9)
            {
                TextBox txtOverLockRecievedItemName = e.Control as TextBox;
                if (txtOverLockRecievedItemName != null)
                {
                    txtOverLockRecievedItemName.KeyPress -= new KeyPressEventHandler(txtOverLockRecievedItemName_KeyPress);
                    txtOverLockRecievedItemName.KeyPress += new KeyPressEventHandler(txtOverLockRecievedItemName_KeyPress);
                }
            }
            else if (grdOverLock.CurrentCellAddress.X == 10)
            {
                TextBox txtOverLockArticleName = e.Control as TextBox;
                if (txtOverLockArticleName != null)
                {
                    txtOverLockArticleName.KeyPress -= new KeyPressEventHandler(txtOverLockArticleName_KeyPress);
                    txtOverLockArticleName.KeyPress += new KeyPressEventHandler(txtOverLockArticleName_KeyPress);
                }
            }
        }
        void txtOverLockVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdOverLock.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves OverLock";
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
        void txtOverLockRecievedItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdOverLock.CurrentCellAddress.X == 9)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves OverLock RecievedItemName";
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
        void txtOverLockArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdOverLock.CurrentCellAddress.X == 10)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves OverLock RecievedArticleName";
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
        #region Over Lock Materials Events
        private void grdOverlockMaterials_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                e.Value = "Delete";
            }
        }
        private void grdOverlockMaterials_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdOverlockMaterials_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            #region Variables
            var Manager = new ItemsBLL();
            string ProcessName = string.Empty;
            #endregion
            #region Closing Stock Region
            if (e.ColumnIndex == 8)
            {
                if (Validation.GetSafeString(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialDepartment"].Value) == "Cuff Cutting")
                {
                    IdDepartment = 1;
                    ProcessName = "Gloves Cutting";
                }
                else if (Validation.GetSafeString(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialDepartment"].Value) == "Cuff Printing")
                {
                    IdDepartment = 2;
                    ProcessName = "Gloves Cuff Printing";
                }
                else if (Validation.GetSafeString(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialDepartment"].Value) == "Cuff Magzi")
                {
                    IdDepartment = 4;
                    ProcessName = "Gloves Magzi";
                }
                else if (Validation.GetSafeString(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialDepartment"].Value) == "Cuff Tape")
                {
                    IdDepartment = 5;
                    ProcessName = "Gloves Tape";
                }
                else
                {
                    IdDepartment = -1;
                }
                if (IdDepartment == -1)
                {
                    //ProcessQuantity = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialIdItem"].Value))[0].Qty;
                    ProcessQuantity = Manager.GetRawItemClosingStockByEmployee(Operations.IdCompany, Validation.GetSafeGuid(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialIdItem"].Value), Validation.GetSafeString(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialAccountNo"].Value))[0].Qty;
                }
                else
                {
                    ProcessQuantity = GetGlovesProductionClosingStockByCustomerPO(Validation.GetSafeGuid(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialIdItem"].Value), IdDepartment, ProcessName);
                }
                if (Validation.GetSafeDecimal(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialQuantity"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                    grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialQuantity"].Value = "";
                    grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialRate"].Value = "";
                    grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialAmount"].Value = "";

                }
                else
                {
                    /// Calculating Average Value Here....
                    if (IdDepartment == -1)
                    {
                        grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialRate"].Value = Manager.GetRawMaterialItemsAvgValue(Validation.GetSafeGuid(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialIdItem"].Value)).ToString("0.00");
                        grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialAmount"].Value = (Validation.GetSafeDecimal(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialQuantity"].Value)
                                                                                                               * Validation.GetSafeDecimal(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialRate"].Value)).ToString("0.00");
                    }
                    else
                    {
                        if (grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialQuantity"].Value != null && Validation.GetSafeDecimal(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialQuantity"].Value) > 0)
                        {
                            grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialRate"].Value = GetGlovesAvgCostingByCustomerPO(Validation.GetSafeGuid(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialIdItem"].Value), IdDepartment, ProcessName, "").ToString("0.00");
                            grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialAmount"].Value = (Validation.GetSafeDecimal(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialQuantity"].Value)
                                                                                                                    * Validation.GetSafeDecimal(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialRate"].Value)).ToString("0.00");
                        }
                        else
                        {
                            grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialRate"].Value = "";
                            grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockMaterialAmount"].Value = "";
                        }
                    }
                }
            }
            #endregion
        }
        private void grdOverlockMaterials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                var manager = new ProductionMaterialsBLL();
                Guid Id = Validation.GetSafeGuid(grdOverlockMaterials.Rows[e.RowIndex].Cells["colOverLockIdMaterial"].Value);
                if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    if (Id != Guid.Empty)
                    {
                        if (MessageBox.Show("Are You Sure To Delete...", "Deleting Material", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (manager.DeleteMaterialEntry(Id).IsSuccess)
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                grdOverlockMaterials.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                    }
                    else
                    {
                        grdOverlockMaterials.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    MessageBox.Show("You have no administrator rights");
                }
            }
        }
        private void grdOverlockMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdOverlockMaterials.CurrentCellAddress.X == 4)
            {
                TextBox txtOverLockMaterialName = e.Control as TextBox;
                if (txtOverLockMaterialName != null)
                {
                    txtOverLockMaterialName.KeyPress -= new KeyPressEventHandler(txtOverLockMaterialName_KeyPress);
                    txtOverLockMaterialName.KeyPress += new KeyPressEventHandler(txtOverLockMaterialName_KeyPress);
                }
            }
            else if (grdOverlockMaterials.CurrentCellAddress.X == 6)
            {
                TextBox txtOverLockMaterialWorkerName = e.Control as TextBox;
                if (txtOverLockMaterialWorkerName != null)
                {
                    txtOverLockMaterialWorkerName.KeyPress -= new KeyPressEventHandler(txtOverLockMaterialWorkerName_KeyPress);
                    txtOverLockMaterialWorkerName.KeyPress += new KeyPressEventHandler(txtOverLockMaterialWorkerName_KeyPress);
                }
            }
        }
        void txtOverLockMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdOverlockMaterials.CurrentCellAddress.X == 4)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves OverLock Materials";
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
        void txtOverLockMaterialWorkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdOverlockMaterials.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "OverLock Material Worker Account";
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
        #region Magzi Grid Events
        private void grdMagzi_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (grdMagzi.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdMagzi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 15)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 16)
            {
                e.Value = "Post";
            }
        }
        private void grdMagzi_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdMagzi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Recored Deletion
            if (e.ColumnIndex == 15)
            {
                if (Validation.GetSafeGuid(grdMagzi.Rows[e.RowIndex].Cells["colIdMagzi"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdMagzi.Rows[e.RowIndex].Cells["colIdMagzi"].Value),
                            Validation.GetSafeGuid(grdMagzi.Rows[e.RowIndex].Cells["colMagziIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            grdMagzi.Rows.RemoveAt(e.RowIndex);
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                    else if (grdMagzi.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    //else
                    //{
                    //    if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdMagzi.Rows[e.RowIndex].Cells["colIdMagzi"].Value),
                    //        Validation.GetSafeGuid(grdMagzi.Rows[e.RowIndex].Cells["colMagziIdVoucher"].Value)))
                    //    {
                    //        MessageBox.Show("Record Deleted Successfully....");
                    //        ProductionTab_SelectedIndexChanged(sender, e);
                    //    }
                    //}
                }
                else
                {
                    for (int i = 0; i < grdMagzi.Columns.Count; i++)
                    {
                        grdMagzi.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 16)
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
                    oelProductionHead.AccountNo = string.Empty;
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdMagzi == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdMagzi;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Magzi";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = IdVoucher;
                    if (grdMagzi.Rows[e.RowIndex].Cells["colIdMagzi"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdMagzi.Rows[e.RowIndex].Cells["colIdMagzi"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdMagzi.Rows[e.RowIndex].Cells["colIdMagzi"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdMagzi.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziAccountNo"].Value);
                    oelProductionDetail.StitcherAccountNo = "0";
                    EmpAccountNo = Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziVendorName"].Value);
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdMagzi.Rows[e.RowIndex].Cells["colMagziIdItem"].Value);
                    oelProductionDetail.IdArticle = Validation.GetSafeGuid(grdMagzi.Rows[e.RowIndex].Cells["colMagziIdArticle"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.ProductionProcessName = "Gloves Magzi";

                    oelProductionDetail.GType = 0;
                    oelProductionDetail.GarmentWorkType = 1;
                    oelProductionDetail.PStyle = "";
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdMagzi.Rows[e.RowIndex].Cells["colMagziQuantity"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdMagzi.Rows[e.RowIndex].Cells["colMagziWorkDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdMagzi.Rows[e.RowIndex].Cells["colMagziRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdMagzi.Rows[e.RowIndex].Cells["colMagziAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziAccountType"].Value) == "Employees")
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
                            IdMagzi = oelProductionProcess.IdProductionProcess;
                            //if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziAccountType"].Value) == "Employees")
                                {
                                    grdMagzi.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted....");
                                }
                                else if (Validation.GetSafeString(grdMagzi.Rows[e.RowIndex].Cells["colMagziAccountType"].Value) != "Employees")
                                {
                                    //frmworkpurchases = new frmWorkPurchases();
                                    //frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //frmworkpurchases.IdEntity = IdEntity;
                                    //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //frmworkpurchases.PurchasesType = "Gloves Magzi/Tape Purchases";
                                    //frmworkpurchases.ProcessName = "Gloves Magzi/Tape";
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
                        //frmworkpurchases.PurchasesType = "Gloves Magzi/Tape Purchases";
                        //frmworkpurchases.ProcessName = "Gloves Magzi/Tape";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdMagzi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                grdMagzi.Rows[e.RowIndex].Cells["colMagziAmount"].Value = Validation.GetSafeDecimal(grdMagzi.Rows[e.RowIndex].Cells["colMagziQuantity"].Value) * Validation.GetSafeDecimal(grdMagzi.Rows[e.RowIndex].Cells["colMagziRate"].Value);
            }
        }
        private void grdMagzi_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdMagzi_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdMagzi.CurrentCellAddress.X == 8)
            {
                TextBox txtMagziVendorName = e.Control as TextBox;
                if (txtMagziVendorName != null)
                {
                    txtMagziVendorName.KeyPress -= new KeyPressEventHandler(txtMagziVendorName_KeyPress);
                    txtMagziVendorName.KeyPress += new KeyPressEventHandler(txtMagziVendorName_KeyPress);
                }
            }
            else if (grdMagzi.CurrentCellAddress.X == 9)
            {
                TextBox txtMagziRecievedItemName = e.Control as TextBox;
                if (txtMagziRecievedItemName != null)
                {
                    txtMagziRecievedItemName.KeyPress -= new KeyPressEventHandler(txtMagziRecievedItemName_KeyPress);
                    txtMagziRecievedItemName.KeyPress += new KeyPressEventHandler(txtMagziRecievedItemName_KeyPress);
                }
            }
            else if (grdMagzi.CurrentCellAddress.X == 10)
            {
                TextBox txtMagziRecievedArticleName = e.Control as TextBox;
                if (txtMagziRecievedArticleName != null)
                {
                    txtMagziRecievedArticleName.KeyPress -= new KeyPressEventHandler(txtMagziRecievedArticleName_KeyPress);
                    txtMagziRecievedArticleName.KeyPress += new KeyPressEventHandler(txtMagziRecievedArticleName_KeyPress);
                }
            }
        }
        void txtMagziVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdMagzi.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Magzi";
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
        void txtMagziRecievedItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdMagzi.CurrentCellAddress.X == 9)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Magzi RecievedItemName";
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
        void txtMagziRecievedArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdMagzi.CurrentCellAddress.X == 10)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Magzi RecievedArticleName";
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
        #region Magzi Materials Grid Events
        private void grdMagziMaterial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                e.Value = "Delete";
            }
        }
        private void grdMagziMaterial_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdMagziMaterial_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            #region Variables
            var Manager = new ItemsBLL();
            string ProcessName = string.Empty;
            #endregion
            #region Closing Stock Region
            if (e.ColumnIndex == 8)
            {
                if (Validation.GetSafeString(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialDepartment"].Value) == "Cuff Cutting")
                {
                    IdDepartment = 1;
                    ProcessName = "Gloves Cutting";
                }
                else if (Validation.GetSafeString(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialDepartment"].Value) == "Cuff Printing")
                {
                    IdDepartment = 2;
                    ProcessName = "Gloves Cuff Printing";
                }
                else if (Validation.GetSafeString(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialDepartment"].Value) == "Cuff OverLock")
                {
                    IdDepartment = 3;
                    ProcessName = "Gloves OverLock";
                }
                else if (Validation.GetSafeString(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialDepartment"].Value) == "Cuff Tape")
                {
                    IdDepartment = 5;
                    ProcessName = "Gloves Tape";
                }
                else
                {
                    IdDepartment = -1;
                }
                if (IdDepartment == -1)
                {
                    //ProcessQuantity = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialIdItem"].Value))[0].Qty;
                    ProcessQuantity = Manager.GetRawItemClosingStockByEmployee(Operations.IdCompany, Validation.GetSafeGuid(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialIdItem"].Value), Validation.GetSafeString(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialAccountNo"].Value))[0].Qty;
                }
                else
                {
                    ProcessQuantity = GetGlovesProductionClosingStockByCustomerPO(Validation.GetSafeGuid(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialIdItem"].Value), IdDepartment, ProcessName);
                }
                if (Validation.GetSafeDecimal(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialUsedQuantity"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                    grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialUsedQuantity"].Value = "";
                    grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialRate"].Value = "";
                    grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialAmount"].Value = "";

                }
                else
                {
                    /// Calculating Average Value Here....
                    if (IdDepartment == -1)
                    {
                        grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialRate"].Value = Manager.GetRawMaterialItemsAvgValue(Validation.GetSafeGuid(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialIdItem"].Value)).ToString("0.00");
                        grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialAmount"].Value = (Validation.GetSafeDecimal(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialUsedQuantity"].Value)
                                                                                                               * Validation.GetSafeDecimal(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialRate"].Value)).ToString("0.00");
                    }
                    else
                    {
                        if (grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialUsedQuantity"].Value != null && Validation.GetSafeDecimal(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialUsedQuantity"].Value) > 0)
                        {
                            grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialRate"].Value = GetGlovesAvgCostingByCustomerPO(Validation.GetSafeGuid(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialIdItem"].Value), IdDepartment, ProcessName, "").ToString("0.00");
                            grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialAmount"].Value = (Validation.GetSafeDecimal(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialUsedQuantity"].Value)
                                                                                                                    * Validation.GetSafeDecimal(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialRate"].Value)).ToString("0.00");
                        }
                        else
                        {
                            grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialRate"].Value = "";
                            grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziMaterialAmount"].Value = "";
                        }
                    }
                }
            }
            #endregion
        }
        private void grdMagziMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                var manager = new ProductionMaterialsBLL();
                Guid Id = Validation.GetSafeGuid(grdMagziMaterial.Rows[e.RowIndex].Cells["colMagziIdMaterial"].Value);
                if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    if (Id != Guid.Empty)
                    {
                        if (MessageBox.Show("Are You Sure To Delete...", "Deleting Material", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (manager.DeleteMaterialEntry(Id).IsSuccess)
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                grdMagziMaterial.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                    }
                    else
                    {
                        grdMagziMaterial.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    MessageBox.Show("You have no administrator rights");
                }
            }
        }
        private void grdMagziMaterial_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdMagziMaterial.CurrentCellAddress.X == 4)
            {
                TextBox txtMagziTapMaterialName = e.Control as TextBox;
                if (txtMagziTapMaterialName != null)
                {
                    txtMagziTapMaterialName.KeyPress -= new KeyPressEventHandler(txtMagziTapMaterialName_KeyPress);
                    txtMagziTapMaterialName.KeyPress += new KeyPressEventHandler(txtMagziTapMaterialName_KeyPress);
                }
            }
            else if (grdMagziMaterial.CurrentCellAddress.X == 6)
            {
                TextBox txtMagziTapMaterialWorkerName = e.Control as TextBox;
                if (txtMagziTapMaterialWorkerName != null)
                {
                    txtMagziTapMaterialWorkerName.KeyPress -= new KeyPressEventHandler(txtMagziTapMaterialWorkerName_KeyPress);
                    txtMagziTapMaterialWorkerName.KeyPress += new KeyPressEventHandler(txtMagziTapMaterialWorkerName_KeyPress);
                }
            }
        }
        void txtMagziTapMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdMagziMaterial.CurrentCellAddress.X == 4)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Magzi Materials";
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
        void txtMagziTapMaterialWorkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdMagziMaterial.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Magzi Material Worker Account";
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
        #region Tap Grid Events
        private void grdTap_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (grdTap.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdTap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 15)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 16)
            {
                e.Value = "Post";
            }
        }
        private void grdTap_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdTap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Recored Deletion
            if (e.ColumnIndex == 15)
            {
                if (Validation.GetSafeGuid(grdTap.Rows[e.RowIndex].Cells["colIdTap"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdTap.Rows[e.RowIndex].Cells["colIdTap"].Value),
                            Validation.GetSafeGuid(grdTap.Rows[e.RowIndex].Cells["colTapIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            grdTap.Rows.RemoveAt(e.RowIndex);
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                    else if (grdTap.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    //else
                    //{
                    //    if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdTap.Rows[e.RowIndex].Cells["colIdTap"].Value),
                    //        Validation.GetSafeGuid(grdTap.Rows[e.RowIndex].Cells["colTapIdVoucher"].Value)))
                    //    {
                    //        MessageBox.Show("Record Deleted Successfully....");
                    //        ProductionTab_SelectedIndexChanged(sender, e);
                    //    }
                    //}
                }
                else
                {
                    for (int i = 0; i < grdTap.Columns.Count; i++)
                    {
                        grdTap.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 16)
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
                    oelProductionHead.AccountNo = string.Empty;
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdMagzi == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdMagzi;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Tape";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = IdVoucher;
                    if (grdTap.Rows[e.RowIndex].Cells["colIdTap"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdTap.Rows[e.RowIndex].Cells["colIdTap"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdTap.Rows[e.RowIndex].Cells["colIdTap"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdTap.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdTap.Rows[e.RowIndex].Cells["colTapAccountNo"].Value);
                    oelProductionDetail.StitcherAccountNo = "0";
                    EmpAccountNo = Validation.GetSafeString(grdTap.Rows[e.RowIndex].Cells["colTapAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdTap.Rows[e.RowIndex].Cells["colTapVendorName"].Value);
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdTap.Rows[e.RowIndex].Cells["colTapIdItem"].Value);
                    oelProductionDetail.IdArticle = Validation.GetSafeGuid(grdTap.Rows[e.RowIndex].Cells["colTapIdArticle"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdTap.Rows[e.RowIndex].Cells["colTapSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.ProductionProcessName = "Gloves Tape";

                    oelProductionDetail.GType = 0;

                    oelProductionDetail.GarmentWorkType = 2;

                    oelProductionDetail.PStyle = "";
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdTap.Rows[e.RowIndex].Cells["colTapQuantity"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdTap.Rows[e.RowIndex].Cells["colTapWorkDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdTap.Rows[e.RowIndex].Cells["colTapRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdTap.Rows[e.RowIndex].Cells["colTapAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    if (Validation.GetSafeString(grdTap.Rows[e.RowIndex].Cells["colTapAccountType"].Value) == "Employees")
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
                            IdMagzi = oelProductionProcess.IdProductionProcess;
                            //if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                            {
                                if (Validation.GetSafeString(grdTap.Rows[e.RowIndex].Cells["colTapAccountType"].Value) == "Employees")
                                {
                                    grdTap.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted....");
                                }
                                else if (Validation.GetSafeString(grdTap.Rows[e.RowIndex].Cells["colTapAccountType"].Value) != "Employees")
                                {
                                    //frmworkpurchases = new frmWorkPurchases();
                                    //frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //frmworkpurchases.IdEntity = IdEntity;
                                    //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //frmworkpurchases.PurchasesType = "Gloves Magzi/Tape Purchases";
                                    //frmworkpurchases.ProcessName = "Gloves Magzi/Tape";
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
                        //frmworkpurchases.PurchasesType = "Gloves Magzi/Tape Purchases";
                        //frmworkpurchases.ProcessName = "Gloves Magzi/Tape";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdTap_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                grdTap.Rows[e.RowIndex].Cells["colTapAmount"].Value = Validation.GetSafeDecimal(grdTap.Rows[e.RowIndex].Cells["colTapQuantity"].Value) * Validation.GetSafeDecimal(grdTap.Rows[e.RowIndex].Cells["colTapRate"].Value);
            }
        }
        private void grdTap_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdTap_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdTap.CurrentCellAddress.X == 8)
            {
                TextBox txtTapVendorName = e.Control as TextBox;
                if (txtTapVendorName != null)
                {
                    txtTapVendorName.KeyPress -= new KeyPressEventHandler(txtTapVendorName_KeyPress);
                    txtTapVendorName.KeyPress += new KeyPressEventHandler(txtTapVendorName_KeyPress);
                }
            }
            else if (grdTap.CurrentCellAddress.X == 9)
            {
                TextBox txtTapRecievedItemName = e.Control as TextBox;
                if (txtTapRecievedItemName != null)
                {
                    txtTapRecievedItemName.KeyPress -= new KeyPressEventHandler(txtTapRecievedItemName_KeyPress);
                    txtTapRecievedItemName.KeyPress += new KeyPressEventHandler(txtTapRecievedItemName_KeyPress);
                }
            }
            else if (grdTap.CurrentCellAddress.X == 10)
            {
                TextBox txtTapRecievedArticleName = e.Control as TextBox;
                if (txtTapRecievedArticleName != null)
                {
                    txtTapRecievedArticleName.KeyPress -= new KeyPressEventHandler(txtTapRecievedArticleName_KeyPress);
                    txtTapRecievedArticleName.KeyPress +=new KeyPressEventHandler(txtTapRecievedArticleName_KeyPress);
                }
            }
        }    
        void txtTapVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdTap.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Tap";
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
        void txtTapRecievedItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdTap.CurrentCellAddress.X == 9)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Tap RecievedItemName";
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
        void txtTapRecievedArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdTap.CurrentCellAddress.X == 10)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Tap RecievedArticleName";
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
        #region Tap Materials Grid Events
        private void grdTapMaterial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                e.Value = "Delete";
            }
        }
        private void grdTapMaterial_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdTapMaterial_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            #region Variables
            var Manager = new ItemsBLL();
            string ProcessName = string.Empty;
            #endregion
            #region Closing Stock Region
            if (e.ColumnIndex == 8)
            {
                if (Validation.GetSafeString(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialDepartment"].Value) == "Cuff Cutting")
                {
                    IdDepartment = 1;
                    ProcessName = "Gloves Cutting";
                }
                else if (Validation.GetSafeString(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialDepartment"].Value) == "Cuff Printing")
                {
                    IdDepartment = 2;
                    ProcessName = "Gloves Cuff Printing";
                }
                else if (Validation.GetSafeString(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialDepartment"].Value) == "Cuff OverLock")
                {
                    IdDepartment = 3;
                    ProcessName = "Gloves OverLock";
                }
                else if (Validation.GetSafeString(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialDepartment"].Value) == "Cuff Magzi")
                {
                    IdDepartment = 4;
                    ProcessName = "Gloves Magzi";
                }
                else
                {
                    IdDepartment = -1;
                }
                if (IdDepartment == -1)
                {
                    //ProcessQuantity = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialIdItem"].Value))[0].Qty;
                    ProcessQuantity = Manager.GetRawItemClosingStockByEmployee(Operations.IdCompany, Validation.GetSafeGuid(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialIdItem"].Value), Validation.GetSafeString(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialAccountNo"].Value))[0].Qty;
                }
                else
                {
                    ProcessQuantity = GetGlovesProductionClosingStockByCustomerPO(Validation.GetSafeGuid(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialIdItem"].Value), IdDepartment, ProcessName);
                }
                if (Validation.GetSafeDecimal(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialUsedQuantity"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                    grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialUsedQuantity"].Value = "";
                    grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialRate"].Value = "";
                    grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialAmount"].Value = "";

                }
                else
                {
                    /// Calculating Average Value Here....
                    if (IdDepartment == -1)
                    {
                        grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialRate"].Value = Manager.GetRawMaterialItemsAvgValue(Validation.GetSafeGuid(grdMagziMaterial.Rows[e.RowIndex].Cells["colTapMaterialIdItem"].Value)).ToString("0.00");
                        grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialAmount"].Value = (Validation.GetSafeDecimal(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialUsedQuantity"].Value)
                                                                                                               * Validation.GetSafeDecimal(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialRate"].Value)).ToString("0.00");
                    }
                    else
                    {
                        if (grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialUsedQuantity"].Value != null && Validation.GetSafeDecimal(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialUsedQuantity"].Value) > 0)
                        {
                            grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialRate"].Value = GetGlovesAvgCostingByCustomerPO(Validation.GetSafeGuid(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialIdItem"].Value), IdDepartment, ProcessName, "").ToString("0.00");
                            grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialAmount"].Value = (Validation.GetSafeDecimal(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialUsedQuantity"].Value)
                                                                                                                    * Validation.GetSafeDecimal(grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialRate"].Value)).ToString("0.00");
                        }
                        else
                        {
                            grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialRate"].Value = "";
                            grdTapMaterial.Rows[e.RowIndex].Cells["colTapMaterialAmount"].Value = "";
                        }
                    }
                }
            }
            #endregion
        }
        private void grdTapMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                var manager = new ProductionMaterialsBLL();
                Guid Id = Validation.GetSafeGuid(grdTapMaterial.Rows[e.RowIndex].Cells["colTapIdMaterial"].Value);
                if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    if (Id != Guid.Empty)
                    {
                        if (MessageBox.Show("Are You Sure To Delete...", "Deleting Material", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (manager.DeleteMaterialEntry(Id).IsSuccess)
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                grdTapMaterial.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                    }
                    else
                    {
                        grdTapMaterial.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    MessageBox.Show("You have no administrator rights");
                }
            }
        }
        private void grdTapMaterial_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdTapMaterial.CurrentCellAddress.X == 4)
            {
                TextBox txtTapMaterialName = e.Control as TextBox;
                if (txtTapMaterialName != null)
                {
                    txtTapMaterialName.KeyPress -= new KeyPressEventHandler(txtTapMaterialName_KeyPress);
                    txtTapMaterialName.KeyPress += new KeyPressEventHandler(txtTapMaterialName_KeyPress);
                }
            }
            else if (grdTapMaterial.CurrentCellAddress.X == 6)
            {
                TextBox txtTapMaterialWorkerName = e.Control as TextBox;
                if (txtTapMaterialWorkerName != null)
                {
                    txtTapMaterialWorkerName.KeyPress -= new KeyPressEventHandler(txtTapMaterialWorkerName_KeyPress);
                    txtTapMaterialWorkerName.KeyPress += new KeyPressEventHandler(txtTapMaterialWorkerName_KeyPress);
                }
            }
        }
        void txtTapMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdTapMaterial.CurrentCellAddress.X == 4)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Tap Materials";
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
        void txtTapMaterialWorkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdTapMaterial.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Tap Material Worker Account";
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
            if (e.ColumnIndex == 13)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 14)
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
        }
        private void grdStitching_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 13)
            {
                if (Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colIdStitching"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colIdStitching"].Value),
                            Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colStitchingIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            grdStitching.Rows.RemoveAt(e.RowIndex);
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                    else if (grdStitching.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    //else
                    //{
                    //    if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colIdStitching"].Value),
                    //        Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colStitchingIdVoucher"].Value)))
                    //    {
                    //        MessageBox.Show("Record Deleted Successfully....");
                    //        ProductionTab_SelectedIndexChanged(sender, e);
                    //    }
                    //}
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
            else if (e.ColumnIndex == 14)
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
                    oelProductionHead.AccountNo = string.Empty;
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdStitching == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdStitching;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Stitching";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = IdVoucher;
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
                    oelProductionDetail.ProductionProcessName = "Gloves Stitching";

                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colStitchingIdItem"].Value);
                    oelProductionDetail.IdArticle = Validation.GetSafeGuid(grdStitching.Rows[e.RowIndex].Cells["colStitchingIdItem"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdStitching.Rows[e.RowIndex].Cells["colStitchingSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;

                    oelProductionDetail.GType = 0;
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdStitching.Rows[e.RowIndex].Cells["colStitchingQuantity"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.GarmentWorkType = 0;
                    oelProductionDetail.PStyle = "";

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
                                    //frmworkpurchases.PurchasesType = "Gloves Stitching Purchases";
                                    //frmworkpurchases.ProcessName = "Gloves Stitching";
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
                        //frmworkpurchases.PurchasesType = "Gloves Stitching Purchases";
                        //frmworkpurchases.ProcessName = "Gloves Stitching";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdStitching_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            grdStitching.Rows[e.RowIndex].Cells["colStitchingAmount"].Value = Validation.GetSafeDecimal(grdStitching.Rows[e.RowIndex].Cells["colStitchingQuantity"].Value) * Validation.GetSafeDecimal(grdStitching.Rows[e.RowIndex].Cells["colStitchingRate"].Value);
        }
        private void grdStitching_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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
                TextBox txtStitchingRecievedItemName = e.Control as TextBox;
                if (txtStitchingRecievedItemName != null)
                {
                    txtStitchingRecievedItemName.KeyPress -= new KeyPressEventHandler(txtStitchingRecievedItemName_KeyPress);
                    txtStitchingRecievedItemName.KeyPress += new KeyPressEventHandler(txtStitchingRecievedItemName_KeyPress);
                }
            }
        }
        void txtStitchingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdStitching.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Stitching";
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
        void txtStitchingRecievedItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdStitching.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Stitching RecievedItemName";
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
        #region Stitching Material Grid Events
        private void grdStitchingMaterials_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                e.Value = "Delete";
            }
        }
        private void grdStitchingMaterials_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdStitchingMaterials_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            #region Variables
            var Manager = new ItemsBLL();
            string ProcessName = string.Empty;
            #endregion
            #region Closing Stock Region
            if (e.ColumnIndex == 11)
            {
                if (Validation.GetSafeString(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialDepartment"].Value) == "Cuff Cutting")
                {
                    IdDepartment = 1;
                    ProcessName = "Gloves Cutting";
                }
                else if (Validation.GetSafeString(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialDepartment"].Value) == "Cuff Printing")
                {
                    IdDepartment = 2;
                    ProcessName = "Gloves Cuff Printing";
                }
                else if (Validation.GetSafeString(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialDepartment"].Value) == "Cuff OverLock")
                {
                    IdDepartment = 3;
                    ProcessName = "Gloves OverLock";
                }
                else if (Validation.GetSafeString(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialDepartment"].Value) == "Cuff Magzi")
                {
                    IdDepartment = 4;
                    ProcessName = "Gloves Magzi";
                }
                else if (Validation.GetSafeString(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialDepartment"].Value) == "Cuff Tape")
                {
                    IdDepartment = 5;
                    ProcessName = "Gloves Tape";
                }
                else if (Validation.GetSafeString(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialDepartment"].Value) == "Cuff Talli")
                {
                    IdDepartment = 15;
                    ProcessName = "Gloves Talli Cutting";
                }
                else if (Validation.GetSafeString(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialDepartment"].Value) == "Cuff General Stock")
                {
                    if (Validation.GetSafeString(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialItemType"].Value) == "1")
                    {
                        if (IdDepartment != -1)
                        {
                            MessageBox.Show("Please Dont Select Any Department Because It Is a Raw Material");
                            grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialDepartment"].Value = "";
                            grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialQuantity"].Value = "";
                            return;
                        }
                        else
                        {
                            IdDepartment = -1;
                        }
                    }
                    else
                    {
                        IdDepartment = -1;
                    }
                }
                else
                {
                    IdDepartment = -1;
                }
                if (IdDepartment == -1)
                {
                    //ProcessQuantity = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialIdItem"].Value))[0].Qty;
                    ProcessQuantity = Manager.GetRawItemClosingStockByEmployee(Operations.IdCompany, Validation.GetSafeGuid(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialIdItem"].Value), Validation.GetSafeString(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialAccountNo"].Value))[0].Qty;
                }
                else
                {
                    ProcessQuantity = GetGlovesProductionClosingStockByCustomerPO(Validation.GetSafeGuid(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialIdItem"].Value), IdDepartment, ProcessName);
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
                    if (IdDepartment == -1)
                    {
                        grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialRate"].Value = Manager.GetRawMaterialItemsAvgValue(Validation.GetSafeGuid(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialIdItem"].Value)).ToString("0.00");
                        grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialAmount"].Value = (Validation.GetSafeDecimal(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialQuantity"].Value)
                                                                                                               * Validation.GetSafeDecimal(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialRate"].Value)).ToString("0.00");
                    }
                    else
                    {
                        if (grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialQuantity"].Value != null && Validation.GetSafeDecimal(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialQuantity"].Value) > 0)
                        {
                            if (Validation.GetSafeString(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialDepartment"].Value) == "Cuff Talli")
                            {
                                grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialRate"].Value = GetGlovesAvgCostingByCustomerPO(Validation.GetSafeGuid(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialIdItem"].Value), IdDepartment, ProcessName, "Gloves Talli Cutting").ToString("0.00");
                                grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialAmount"].Value = (Validation.GetSafeDecimal(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialQuantity"].Value)
                                                                                                                        * Validation.GetSafeDecimal(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialRate"].Value)).ToString("0.00");
                            }
                            else
                            {
                                grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialRate"].Value = GetGlovesAvgCostingByCustomerPO(Validation.GetSafeGuid(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialIdItem"].Value), IdDepartment, ProcessName, "").ToString("0.00");
                                grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialAmount"].Value = (Validation.GetSafeDecimal(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialQuantity"].Value)
                                                                                                                        * Validation.GetSafeDecimal(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingMaterialRate"].Value)).ToString("0.00");
                            }
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
        private void grdStitchingMaterials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                var manager = new ProductionMaterialsBLL();
                Guid Id = Validation.GetSafeGuid(grdStitchingMaterials.Rows[e.RowIndex].Cells["colStitchingIdMaterial"].Value);
                if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    if (Id != Guid.Empty)
                    {
                        if (MessageBox.Show("Are You Sure To Delete...", "Deleting Material", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (manager.DeleteMaterialEntry(Id).IsSuccess)
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                grdStitchingMaterials.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                    }
                    else
                    {
                        grdStitchingMaterials.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    MessageBox.Show("You have no administrator rights");
                }
            }
        }
        private void grdStitchingMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdStitchingMaterials.CurrentCellAddress.X == 6)
            {
                TextBox txtStitchingMaterialName = e.Control as TextBox;
                txtStitchingMaterialName.KeyPress -= new KeyPressEventHandler(txtStitchingMaterialName_KeyPress);
                txtStitchingMaterialName.KeyPress += new KeyPressEventHandler(txtStitchingMaterialName_KeyPress);
            }
            else if (grdStitchingMaterials.CurrentCellAddress.X == 8)
            {
                TextBox txtStitchingMaterialArticleName = e.Control as TextBox;
                txtStitchingMaterialArticleName.KeyPress -= new KeyPressEventHandler(txtStitchingMaterialArticleName_KeyPress);
                txtStitchingMaterialArticleName.KeyPress += new KeyPressEventHandler(txtStitchingMaterialArticleName_KeyPress);
            }
            else if (grdStitchingMaterials.CurrentCellAddress.X == 9)
            {
                TextBox txtStitchingMaterialWorkerName = e.Control as TextBox;
                txtStitchingMaterialWorkerName.KeyPress -= new KeyPressEventHandler(txtStitchingMaterialWorkerName_KeyPress);
                txtStitchingMaterialWorkerName.KeyPress += new KeyPressEventHandler(txtStitchingMaterialWorkerName_KeyPress);
            }
        }
        void txtStitchingMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdStitchingMaterials.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Stitching Materials";
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
        void txtStitchingMaterialArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdStitchingMaterials.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Stitching Material Article";
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
            if (grdStitchingMaterials.CurrentCellAddress.X == 9)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Stitching Material Worker Account";
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
        #region Inspection Grid Events
        private void grdInspection_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (grdInspection.Rows[e.RowIndex].Cells[7].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdInspection_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 22)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 23)
            {
                e.Value = "Posting";
            }
        }
        private void grdInspection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 22)
            {
                if (Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value),
                            Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            grdInspection.Rows.RemoveAt(e.RowIndex);
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                    else if (grdInspection.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    //else
                    //{
                    //    if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value),
                    //        Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionIdVoucher"].Value)))
                    //    {
                    //        MessageBox.Show("Record Deleted Successfully....");
                    //        ProductionTab_SelectedIndexChanged(sender, e);
                    //    }
                    //}
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
            else if (e.ColumnIndex == 23)
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
                    oelProductionHead.AccountNo = string.Empty;
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdInspection == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdInspection;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Inspection";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = IdVoucher;
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
                    oelProductionDetail.StitcherAccountNo = Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionStitcherAccountNo"].Value);
                    EmpAccountNo = Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionVendorName"].Value);
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.ProductionProcessName = "Gloves Inspection";

                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionIdItem"].Value);
                    oelProductionDetail.IdArticle = Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionIdItem"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;

                    oelProductionDetail.GType = 0;
                    if (grdInspection.Rows[e.RowIndex].Cells["colInspectionDepartment"].Value != null)
                    {
                        if (Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionDepartment"].Value) == "Stitching")
                        {
                            oelProductionDetail.GarmentWorkType = 1;
                        }
                        else
                        {
                            oelProductionDetail.GarmentWorkType = 2;
                        }
                    }
                    else
                    {
                        oelProductionDetail.GarmentWorkType = 0;
                    }
                    oelProductionDetail.PStyle = "";
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value);
                    oelProductionDetail.ReadyUnits = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionPassQuantity"].Value);
                    oelProductionDetail.Rejection = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionRejectedQuantity"].Value);
                    oelProductionDetail.BQuantity = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionBQ"].Value);
                    oelProductionDetail.RepairQuantity = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionRepair"].Value);
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdInspection.Rows[e.RowIndex].Cells["colInspectionWorkingDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionAmount"].Value);
                    oelProductionDetail.InspectorRate = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionWorkRate"].Value);
                    oelProductionDetail.InspectorAmount = Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionWorkAmount"].Value);
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
                                    MessageBox.Show("Work Is Posted....");
                                }
                                else if (Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionAccountType"].Value) != "Employees")
                                {
                                    //frmworkpurchases = new frmWorkPurchases();
                                    //frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //frmworkpurchases.IdEntity = IdEntity;
                                    //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //frmworkpurchases.PurchasesType = "Gloves Inspection Purchases";
                                    //frmworkpurchases.ProcessName = "Gloves Inspection";
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
                        //frmworkpurchases.PurchasesType = "Gloves Inspection Purchases";
                        //frmworkpurchases.ProcessName = "Gloves Inspection";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdInspection_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 12)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdInspection_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                int Department = 0;
                decimal ClosingStock = 0;
                var manager = new ProductionProcessDetailBLL();
                if (grdInspection.Rows[e.RowIndex].Cells["colInspectionDepartment"].Value == null)
                {
                    MessageBox.Show("Please Select Department From Previous Cell Option");
                    grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value = "";
                    return;
                }
                else
                { 
                    string StitcherAccountNo = Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionStitcherAccountNo"].Value);
                    Guid IdInspectionArticleId = Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionIdItem"].Value);
                    decimal InspectionQuantity = Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value);
                    if (Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionDepartment"].Value) == "Stitching")
                    {
                        Department = 1;
                    }
                    else
                        Department = 2;
                    ClosingStock = manager.GetGlovesDepartmentClosingStockInInspection(IdInspectionArticleId, StitcherAccountNo, Department, cbxCustomerPOS.Text);
                    if (ClosingStock >= InspectionQuantity)
                    {
                        /// Allow Entry Here....
                    }
                    else
                    {
                        MessageBox.Show("Only ''" + ClosingStock + "'' Is Available To Process...");
                        grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value = "";
                    }

                }
            }
            else if (e.ColumnIndex == 18)
            {
                //grdInspection.Rows[e.RowIndex].Cells["colInspectionWorkAmount"].Value = Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value) * Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionWorkRate"].Value);
                grdInspection.Rows[e.RowIndex].Cells["colInspectionWorkAmount"].Value = (Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionPassQuantity"].Value) + Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionRejectedQuantity"].Value) + +Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionBQ"].Value)) * Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionWorkRate"].Value);
            }
            else if (e.ColumnIndex == 20)
            {
                grdInspection.Rows[e.RowIndex].Cells["colInspectionAmount"].Value = Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value) * Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionRate"].Value);
            }
        }
        private void grdInspection_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdInspection_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdInspection.CurrentCellAddress.X == 8)
            {
                TextBox txtInspectionVendorName = e.Control as TextBox;
                if (txtInspectionVendorName != null)
                {
                    txtInspectionVendorName.KeyPress -= new KeyPressEventHandler(txtInspectionVendorName_KeyPress);
                    txtInspectionVendorName.KeyPress += new KeyPressEventHandler(txtInspectionVendorName_KeyPress);
                }
            }
            else if (grdInspection.CurrentCellAddress.X == 9)
            {
                TextBox txtInspectionBrandName = e.Control as TextBox;
                if (txtInspectionBrandName != null)
                {
                    txtInspectionBrandName.KeyPress -= new KeyPressEventHandler(txtInspectionBrandName_KeyPress);
                    txtInspectionBrandName.KeyPress += new KeyPressEventHandler(txtInspectionBrandName_KeyPress);
                }
            }
            else if (grdInspection.CurrentCellAddress.X == 10)
            {
                TextBox txtInspectorName = e.Control as TextBox;
                if (txtInspectorName != null)
                {
                    txtInspectorName.KeyPress -= new KeyPressEventHandler(txtInspectorName_KeyPress);
                    txtInspectorName.KeyPress += new KeyPressEventHandler(txtInspectorName_KeyPress);
                }
            }
        }
        void txtInspectionVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdInspection.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Inspection";
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
        void txtInspectionBrandName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdInspection.CurrentCellAddress.X == 9)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "InspectionBrand";
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
        void txtInspectorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdInspection.CurrentCellAddress.X == 10)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Inspector";
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
        #region Gloves Repair Grid Events
        private void grdGlovesRepair_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (grdGlovesRepair.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdGlovesRepair_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 14)
            {
                e.Value = "Post";
            }
        }
        private void grdGlovesRepair_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdGlovesRepair_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Recored Deletion
            if (e.ColumnIndex == 13)
            {
                if (Validation.GetSafeGuid(grdGlovesRepair.Rows[e.RowIndex].Cells["colIdGlovesRepair"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdGlovesRepair.Rows[e.RowIndex].Cells["colIdGlovesRepair"].Value),
                            Validation.GetSafeGuid(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            grdGlovesRepair.Rows.RemoveAt(e.RowIndex);
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                    else if (grdGlovesRepair.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    //else
                    //{
                    //    if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdGlovesRepair.Rows[e.RowIndex].Cells["colIdGlovesRepair"].Value),
                    //        Validation.GetSafeGuid(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairIdVoucher"].Value)))
                    //    {
                    //        MessageBox.Show("Record Deleted Successfully....");
                    //        ProductionTab_SelectedIndexChanged(sender, e);
                    //    }
                    //}
                }
                else
                {
                    for (int i = 0; i < grdGlovesRepair.Columns.Count; i++)
                    {
                        grdGlovesRepair.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 14)
            {
                var Manager = new ProductionProcessesHeadBLL();
                ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
                ProductionProcessesEL oelProductionProcess = new ProductionProcessesEL();
                if (ValidateRecords(9))
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
                    oelProductionHead.AccountNo = string.Empty;
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdMagzi == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdMagzi;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Repair";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = IdVoucher;
                    if (grdGlovesRepair.Rows[e.RowIndex].Cells["colIdGlovesRepair"].Value == null)
                    {
                        oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                        grdGlovesRepair.Rows[e.RowIndex].Cells["colIdGlovesRepair"].Value = oelProductionDetail.IdProductionProcessDetail;
                        oelProductionDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdGlovesRepair.Rows[e.RowIndex].Cells["colIdGlovesRepair"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdGlovesRepair.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelProductionDetail.IdProductionProcessDetail;
                    oelProductionDetail.IdProductionProcess = oelProductionProcess.IdProductionProcess;
                    oelProductionDetail.IdUser = Operations.UserID;
                    oelProductionDetail.AccountNo = Validation.GetSafeString(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairAccountNo"].Value);
                    oelProductionDetail.StitcherAccountNo = "0";
                    EmpAccountNo = Validation.GetSafeString(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairVendorName"].Value);
                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairIdItem"].Value);
                    oelProductionDetail.IdArticle = Validation.GetSafeGuid(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairIdItem"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;
                    oelProductionDetail.Description = "N/A";
                    oelProductionDetail.ProductionProcessName = "Gloves Repair";

                    oelProductionDetail.GType = 0;

                    oelProductionDetail.GarmentWorkType = 0;

                    oelProductionDetail.PStyle = "";
                    oelProductionDetail.Quality = 0;
                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairQuantity"].Value);
                    oelProductionDetail.ReadyUnits = 0;
                    oelProductionDetail.Rejection = 0;
                    oelProductionDetail.WorkDate = Convert.ToDateTime(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairWorkDate"].Value);
                    oelProductionDetail.Rate = Validation.GetSafeDecimal(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairRate"].Value);
                    oelProductionDetail.Amount = Validation.GetSafeDecimal(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairAmount"].Value);
                    postAmount = oelProductionDetail.Amount;
                    //if (Validation.GetSafeString(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairAccountType"].Value) == "Employees")
                    //{
                    //    oelProductionDetail.Posted = true;
                    //}
                    //else
                    //{
                    //    oelProductionDetail.Posted = false;
                    //}
                    oelProductionDetail.Posted = true;
                    oelProductionDetailCollection.Add(oelProductionDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelProductionHead.IdVoucher;
                            IdMagzi = oelProductionProcess.IdProductionProcess;
                            //if (Manager.CreateProductionHead(oelProductionHead, oelProductionProcess, oelProductionDetailCollection).IsSuccess)
                            if (Manager.CreateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                            {
                                //if (Validation.GetSafeString(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairAccountType"].Value) == "Employees")
                                {
                                    grdGlovesRepair.Rows[e.RowIndex].ReadOnly = true;
                                    MessageBox.Show("Work Is Posted....");
                                }
                                //else if (Validation.GetSafeString(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairAccountType"].Value) != "Employees")
                                {
                                    //frmworkpurchases = new frmWorkPurchases();
                                    //frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //frmworkpurchases.IdEntity = IdEntity;
                                    //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //frmworkpurchases.PurchasesType = "Gloves Magzi/Tape Purchases";
                                    //frmworkpurchases.ProcessName = "Gloves Magzi/Tape";
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
                        //frmworkpurchases.PurchasesType = "Gloves Magzi/Tape Purchases";
                        //frmworkpurchases.ProcessName = "Gloves Magzi/Tape";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdGlovesRepair_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairAmount"].Value = Validation.GetSafeDecimal(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairQuantity"].Value) * Validation.GetSafeDecimal(grdGlovesRepair.Rows[e.RowIndex].Cells["colGlovesRepairRate"].Value);
            }
        }
        private void grdGlovesRepair_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdGlovesRepair_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdGlovesRepair.CurrentCellAddress.X == 7)
            {
                TextBox txtGlovesRepairVendorName = e.Control as TextBox;
                if (txtGlovesRepairVendorName != null)
                {
                    txtGlovesRepairVendorName.KeyPress -= new KeyPressEventHandler(txtGlovesRepairVendorName_KeyPress);
                    txtGlovesRepairVendorName.KeyPress += new KeyPressEventHandler(txtGlovesRepairVendorName_KeyPress);
                }
            }
            else if (grdGlovesRepair.CurrentCellAddress.X == 8)
            {
                TextBox txtGlovesRepairRecievedItemName = e.Control as TextBox;
                if (txtGlovesRepairRecievedItemName != null)
                {
                    txtGlovesRepairRecievedItemName.KeyPress -= new KeyPressEventHandler(txtGlovesRepairRecievedItemName_KeyPress);
                    txtGlovesRepairRecievedItemName.KeyPress += new KeyPressEventHandler(txtGlovesRepairRecievedItemName_KeyPress);
                }
            }
        }
        void txtGlovesRepairVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdGlovesRepair.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Repair";
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
        void txtGlovesRepairRecievedItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdGlovesRepair.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Repair RecievedItemName";
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
        #region Gloves Repair Materials Grid Events
        private void grdGlovesRepairMaterial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                e.Value = "Delete";
            }
        }
        private void grdGlovesRepairMaterial_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            #region Variables
            var Manager = new ItemsBLL();
            string ProcessName = string.Empty;
            #endregion
            #region Closing Stock Region
            if (e.ColumnIndex == 7)
            {
                ProcessQuantity = GetGlovesRepairAndPackingProductionClosingStockByCustomerPO(Validation.GetSafeGuid(grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialIdItem"].Value), IdDepartment, "Gloves Repair");
                if (Validation.GetSafeDecimal(grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialUsedQuantity"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                    grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialUsedQuantity"].Value = "";
                    grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialRate"].Value = "";
                    grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialAmount"].Value = "";

                }
                else
                {
                    /// Calculating Average Value Here....
                    if (grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialUsedQuantity"].Value != null && Validation.GetSafeDecimal(grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialUsedQuantity"].Value) > 0)
                    {
                        grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialRate"].Value = GetGlovesAvgCostingByCustomerPO(Validation.GetSafeGuid(grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialIdItem"].Value), IdDepartment, "Gloves Repair", "Gloves Repair").ToString("0.00");
                        grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialAmount"].Value = (Validation.GetSafeDecimal(grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialUsedQuantity"].Value)
                                                                                                                * Validation.GetSafeDecimal(grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialRate"].Value)).ToString("0.00");
                    }
                    else
                    {
                        grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialRate"].Value = "";
                        grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairMaterialAmount"].Value = "";
                    }

                }
            }
            #endregion
        }
        private void grdGlovesRepairMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                var manager = new ProductionMaterialsBLL();
                Guid Id = Validation.GetSafeGuid(grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colGlovesRepairIdMaterial"].Value);
                if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    if (Id != Guid.Empty)
                    {
                        if (MessageBox.Show("Are You Sure To Delete...", "Deleting Material", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (manager.DeleteMaterialEntry(Id).IsSuccess)
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                grdGlovesRepairMaterial.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                    }
                    else
                    {
                        grdGlovesRepairMaterial.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    MessageBox.Show("You have no administrator rights");
                }
            }
        }

        private void grdGlovesRepairMaterial_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdGlovesRepairMaterial.CurrentCellAddress.X == 4)
            {
                TextBox txtGlovesRepairMaterialName = e.Control as TextBox;
                if (txtGlovesRepairMaterialName != null)
                {
                    txtGlovesRepairMaterialName.KeyPress -= new KeyPressEventHandler(txtGlovesRepairMaterialName_KeyPress);
                    txtGlovesRepairMaterialName.KeyPress += new KeyPressEventHandler(txtGlovesRepairMaterialName_KeyPress);
                }
            }
            else if (grdGlovesRepairMaterial.CurrentCellAddress.X == 6)
            {
                TextBox txtGlovesRepairMaterialWorkerName = e.Control as TextBox;
                if (txtGlovesRepairMaterialWorkerName != null)
                {
                    txtGlovesRepairMaterialWorkerName.KeyPress -= new KeyPressEventHandler(txtGlovesRepairMaterialWorkerName_KeyPress);
                    txtGlovesRepairMaterialWorkerName.KeyPress += new KeyPressEventHandler(txtGlovesRepairMaterialWorkerName_KeyPress);
                }
            }
        }
        void txtGlovesRepairMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdGlovesRepairMaterial.CurrentCellAddress.X == 4)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Repair Materials";
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
        void txtGlovesRepairMaterialWorkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdGlovesRepairMaterial.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Gloves Repair Material Worker Account";
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
            if (e.ColumnIndex == 16)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 17)
            {
                e.Value = "Post";
            }
        }
        private void grdPacking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 16)
            {
                if (Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                    {
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value),
                            Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colPackingIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
                            grdPacking.Rows.RemoveAt(e.RowIndex);
                            ProductionTab_SelectedIndexChanged(sender, e);
                        }
                    }
                    else if (grdPacking.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                        return;
                    }
                    //else
                    //{
                    //    if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value),
                    //        Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colInspectionIdVoucher"].Value)))
                    //    {
                    //        MessageBox.Show("Record Deleted Successfully....");
                    //        ProductionTab_SelectedIndexChanged(sender, e);
                    //    }
                    //}
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
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 17)
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
                    oelProductionHead.AccountNo = string.Empty;
                    oelProductionHead.IdCompany = Operations.IdCompany;
                    oelProductionHead.UserId = Operations.UserID;
                    oelProductionHead.CustomerPO = Validation.GetSafeString(cbxCustomerPOS.Text);
                    oelProductionHead.VDate = ProductionDate.Value;
                    oelProductionHead.VDiscription = "N/A";
                    oelProductionHead.Amount = 0;
                    oelProductionHead.CloseDate = DateTime.Now;
                    oelProductionHead.ProductionType = 1;

                    if (IdPacking == Guid.Empty)
                    {
                        oelProductionProcess.IdProductionProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelProductionProcess.IdProductionProcess = IdPacking;
                    }
                    oelProductionProcess.IdVoucher = oelProductionHead.IdVoucher;
                    oelProductionProcess.ProductionProcessName = "Gloves Packing";
                    oelProductionProcess.VDate = DateTime.Now;

                    ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                    List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
                    oelProductionDetail.IdVoucher = IdVoucher;
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
                    oelProductionDetail.ProductionProcessName = "Gloves Packing";

                    oelProductionDetail.IdItem = Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colPackingIdItem"].Value);
                    oelProductionDetail.IdArticle = Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colPackingIdItem"].Value);
                    oelProductionDetail.IdBrand = IdBrand;
                    oelProductionDetail.ItemSize = Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingSizes"].Value);
                    oelProductionDetail.IdColor = Guid.Empty;

                    oelProductionDetail.GType = 0;
                    oelProductionDetail.GarmentWorkType = 0;
                    oelProductionDetail.PStyle = Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingPStyle"].Value);
                    oelProductionDetail.Quality = 0;

                    oelProductionDetail.Quantity = Validation.GetSafeLong(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value);
                    oelProductionDetail.ReadyUnits = Validation.GetSafeLong(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value);
                    oelProductionDetail.PackingCartons = Validation.GetSafeLong(grdPacking.Rows[e.RowIndex].Cells["colPackingCartons"].Value);
                    oelProductionDetail.Rejection = 0;
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
                                    MessageBox.Show("Work Is Posted....");
                                }
                                else if (Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingAccountType"].Value) != "Employees")
                                {
                                    //frmworkpurchases = new frmWorkPurchases();
                                    //frmworkpurchases.ProductionType = "Garments / Gloves";
                                    //frmworkpurchases.IdEntity = IdEntity;
                                    //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                    //frmworkpurchases.EmpAccountName = EmpAccountName;
                                    //frmworkpurchases.PurchasesType = "Gloves Packing Purchases";
                                    //frmworkpurchases.ProcessName = "Gloves Packing";
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
                        //frmworkpurchases.PurchasesType = "Gloves Packing Purchases";
                        //frmworkpurchases.ProcessName = "Gloves Packing";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
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
        }
        private void grdPacking_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //grdPacking.Rows[e.RowIndex].Cells["colPackingAmount"].Value = Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value) * Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingRates"].Value);
            grdPacking.Rows[e.RowIndex].Cells["colPackingAmount"].Value = Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingCartons"].Value) * Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingRates"].Value);            
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
            else if (grdPacking.CurrentCellAddress.X == 8)
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
                    EventFiringName = "Gloves Packing";
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
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "PackingBrand";
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
        #region Packing Material Grid Events
        private void grdPackingMaterials_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                e.Value = "Delete";
            }
        }
        private void grdPackingMaterials_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            #region Variables
            var Manager = new ItemsBLL();
            string ProcessName = string.Empty;
            #endregion
            if (e.ColumnIndex == 8)
            { 

                if(Validation.GetSafeInteger(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialItemType"].Value) == 1)
                {
                    //ProcessQuantity = Manager.GetItemClosingStock(Operations.IdCompany, Validation.GetSafeGuid(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialIdItem"].Value))[0].Qty;
                    ProcessQuantity = Manager.GetRawItemClosingStockByEmployee(Operations.IdCompany, Validation.GetSafeGuid(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialIdItem"].Value), Validation.GetSafeString(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialAccountNo"].Value))[0].Qty;
                }
                else if (Validation.GetSafeInteger(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialItemType"].Value) == 3)
                {
                    ProcessQuantity = GetGlovesRepairAndPackingProductionClosingStockByCustomerPO(Validation.GetSafeGuid(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialIdItem"].Value), IdDepartment, "Gloves Packing");
                }
                if (Validation.GetSafeDecimal(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialQuantity"].Value) > ProcessQuantity)
                {
                    MessageBox.Show("Available Quantity For " + grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialName"].Value.ToString() + " Is : " + ProcessQuantity.ToString() + " Which is Greater Than Required Quantity");
                    grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialQuantity"].Value = "";
                    grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialRates"].Value = "";
                    grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialAmount"].Value = "";
                    return;
                }

                if (Validation.GetSafeInteger(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialItemType"].Value) == 1)
                {
                    if (grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialQuantity"].Value != null && Validation.GetSafeDecimal(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialQuantity"].Value) > 0)
                    {
                        grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialRates"].Value = Manager.GetRawMaterialItemsAvgValue(Validation.GetSafeGuid(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialIdItem"].Value)).ToString("0.00");
                        grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialAmount"].Value = (Validation.GetSafeDecimal(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialQuantity"].Value)
                                                                                                               * Validation.GetSafeDecimal(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialRates"].Value)).ToString("0.00");
                    }
                    else
                    {
                        grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialRates"].Value = "";
                        grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialAmount"].Value = "";
                    }
                }
                else if (Validation.GetSafeInteger(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialItemType"].Value) == 3)
                {
                    if (grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialQuantity"].Value != null && Validation.GetSafeDecimal(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialQuantity"].Value) > 0)
                    {
                        grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialRates"].Value = GetGlovesAvgCostingByCustomerPO(Validation.GetSafeGuid(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialIdItem"].Value), IdDepartment, "Gloves Packing", "Gloves Packing").ToString("0.00");
                        grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialAmount"].Value = (Validation.GetSafeDecimal(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialQuantity"].Value)
                                                                                                                * Validation.GetSafeDecimal(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingMaterialRates"].Value)).ToString("0.00");
                    }
                    else
                    {
                        grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colPackingMaterialRates"].Value = "";
                        grdGlovesRepairMaterial.Rows[e.RowIndex].Cells["colPackingMaterialAmount"].Value = "";
                    }
                }
            }
        }
        private void grdPackingMaterials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                var manager = new ProductionMaterialsBLL();
                Guid Id = Validation.GetSafeGuid(grdPackingMaterials.Rows[e.RowIndex].Cells["colPackingIdMaterial"].Value);
                if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    if (Id != Guid.Empty)
                    {
                        if (MessageBox.Show("Are You Sure To Delete...", "Deleting Material", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (manager.DeleteMaterialEntry(Id).IsSuccess)
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                grdPackingMaterials.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                    }
                    else
                    {
                        grdPackingMaterials.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    MessageBox.Show("You have no administrator rights");
                }
            }
        }
        private void grdPackingMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdPackingMaterials.CurrentCellAddress.X == 5)
            {
                TextBox txtPackingMaterialName = e.Control as TextBox;
                if (txtPackingMaterialName != null)
                {
                    txtPackingMaterialName.KeyPress -= new KeyPressEventHandler(txtPackingMaterialName_KeyPress);
                    txtPackingMaterialName.KeyPress += new KeyPressEventHandler(txtPackingMaterialName_KeyPress);
                }
            }
            else if (grdPackingMaterials.CurrentCellAddress.X == 7)
            {
                TextBox txtPackingMaterialWorkerName = e.Control as TextBox;
                if (txtPackingMaterialWorkerName != null)
                {
                    txtPackingMaterialWorkerName.KeyPress -= new KeyPressEventHandler(txtPackingMaterialWorkerName_KeyPress);
                    txtPackingMaterialWorkerName.KeyPress += new KeyPressEventHandler(txtPackingMaterialWorkerName_KeyPress);
                }
            }
        }
        void txtPackingMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPackingMaterials.CurrentCellAddress.X == 5)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    frmstockAccounts = new frmStockAccounts();
                    EventFiringName = "Gloves Packing Materials";
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
                    EventFiringName = "Packing Material Worker Account";
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
        private void grdMiscCost_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                e.Value = "Delete";
            }
        }
        private void grdMiscCost_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            if (e.ColumnIndex == 6)
            {
                var manager = new ProductionOverHeadsBLL();
                Guid Id = Validation.GetSafeGuid(grdMiscCost.Rows[e.RowIndex].Cells["colIdDetailCost"].Value);
                if (Operations.IdRole == Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    if (Id != Guid.Empty)
                    {
                        if (MessageBox.Show("Are You Sure To Delete...", "Deleting OverHead", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (manager.DeleteFOHEntry(Id).IsSuccess)
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                grdMiscCost.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                    }
                    else
                    {
                        grdMiscCost.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    MessageBox.Show("You have no administrator rights");
                }
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
            #region Workers OutPut Events
            if (EventFiringName == "Gloves Cuff Cutting")
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
            else if (EventFiringName == "Gloves Talli Cutting")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdTalliCutting.CurrentRow.Cells["colTalliCuttingAccountNo"].Value = oelAccount.AccountNo;
                    grdTalliCutting.CurrentRow.Cells["colTalliCuttingVendorName"].Value = oelAccount.AccountName;
                    grdTalliCutting.CurrentRow.Cells["colTalliCuttingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Gloves Printing")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdCuffPrinting.CurrentRow.Cells["colCuffPrintingAccountNo"].Value = oelAccount.AccountNo;
                    grdCuffPrinting.CurrentRow.Cells["colCuffPrintingVendorName"].Value = oelAccount.AccountName;
                    grdCuffPrinting.CurrentRow.Cells["colCuffPrintingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Gloves OverLock")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdOverLock.CurrentRow.Cells["colOverLockAccountNo"].Value = oelAccount.AccountNo;
                    grdOverLock.CurrentRow.Cells["colOverLockVendorName"].Value = oelAccount.AccountName;
                    grdOverLock.CurrentRow.Cells["colOverLockAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Gloves Magzi")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdMagzi.CurrentRow.Cells["colMagziAccountNo"].Value = oelAccount.AccountNo;
                    grdMagzi.CurrentRow.Cells["colMagziVendorName"].Value = oelAccount.AccountName;
                    grdMagzi.CurrentRow.Cells["colMagziAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Gloves Tap")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdTap.CurrentRow.Cells["colTapAccountNo"].Value = oelAccount.AccountNo;
                    grdTap.CurrentRow.Cells["colTapVendorName"].Value = oelAccount.AccountName;
                    grdTap.CurrentRow.Cells["colTapAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Gloves Stitching")
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
            else if (EventFiringName == "Gloves Inspection")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdInspection.CurrentRow.Cells["colInspectionStitcherAccountNo"].Value = oelAccount.AccountNo;
                    grdInspection.CurrentRow.Cells["colInspectionStitcherName"].Value = oelAccount.AccountName;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Gloves Inspector")
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
            else if (EventFiringName == "Gloves Repair")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdGlovesRepair.CurrentRow.Cells["colGlovesRepairAccountNo"].Value = oelAccount.AccountNo;
                    grdGlovesRepair.CurrentRow.Cells["colGlovesRepairVendorName"].Value = oelAccount.AccountName;
                    grdGlovesRepair.CurrentRow.Cells["colGlovesRepairAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Gloves Packing")
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
            #region Materials Workers Events
            else if (EventFiringName == "Cutting Material Worker Account")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMateriaAccountNo"].Value = oelAccount.AccountNo;
                    grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialWorkerName"].Value = oelAccount.AccountName;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Talli Cutting Material Worker Account")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdTalliCuttingMaterialUsed.CurrentRow.Cells["colTalliCuttingMaterialAccountNo"].Value = oelAccount.AccountNo;
                    grdTalliCuttingMaterialUsed.CurrentRow.Cells["colTalliCuttingMaterialWorkerName"].Value = oelAccount.AccountName;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Printing Material Worker Account")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdCuffPrintingMaterial.CurrentRow.Cells["colCuffPrintingMaterialAccountNo"].Value = oelAccount.AccountNo;
                    grdCuffPrintingMaterial.CurrentRow.Cells["colCuffPrintingMaterialWorkerName"].Value = oelAccount.AccountName;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "OverLock Material Worker Account")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdOverlockMaterials.CurrentRow.Cells["colOverLockMaterialAccountNo"].Value = oelAccount.AccountNo;
                    grdOverlockMaterials.CurrentRow.Cells["colOverLockMaterialWorkerName"].Value = oelAccount.AccountName;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Magzi Material Worker Account")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdMagziMaterial.CurrentRow.Cells["colMagziMaterialAccountNo"].Value = oelAccount.AccountNo;
                    grdMagziMaterial.CurrentRow.Cells["colMagziMaterialWorkerName"].Value = oelAccount.AccountName;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Tap Material Worker Account")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdTapMaterial.CurrentRow.Cells["colTapMaterialAccountNo"].Value = oelAccount.AccountNo;
                    grdTapMaterial.CurrentRow.Cells["colTapMaterialWorkerName"].Value = oelAccount.AccountName;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Stitching Material Worker Account")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialAccountNo"].Value = oelAccount.AccountNo;
                    grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialWorkerName"].Value = oelAccount.AccountName;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Gloves Repair Material Worker Account")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdGlovesRepairMaterial.CurrentRow.Cells["colGlovesRepairMaterialAccountNo"].Value = oelAccount.AccountNo;
                    grdGlovesRepairMaterial.CurrentRow.Cells["colGlovesRepairMaterialWorkerName"].Value = oelAccount.AccountName;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Packing Material Worker Account")
            {
                if (oelAccount.AccountType == "Employees" || oelAccount.AccountType == "Accounts Payables")
                {
                    grdPackingMaterials.CurrentRow.Cells["colPackingMaterialAccountNo"].Value = oelAccount.AccountNo;
                    grdPackingMaterials.CurrentRow.Cells["colPackingMaterialWorkerName"].Value = oelAccount.AccountName;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            #endregion
            #region OverHeads Events
            else if (EventFiringName == "OverHeads")
            {
                grdMiscCost.CurrentRow.Cells["colAccountNo"].Value = oelAccount.AccountNo;
                grdMiscCost.CurrentRow.Cells["colAccountName"].Value = oelAccount.AccountName;
            }
            #endregion
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            if (EventFiringName == "PrintingBrand")
            {
                grdCuffPrinting.CurrentRow.Cells["colCuffPrintingIdItem"].Value = oelItems.IdItem;
                grdCuffPrinting.CurrentRow.Cells["colCuffPrintingBrand"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "CuffPrintingArticle")
            {
                grdCuffPrinting.CurrentRow.Cells["colcuffprintingIdArticle"].Value = oelItems.IdItem;
                grdCuffPrinting.CurrentRow.Cells["colCuffPrintingArticleName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "InspectionBrand")
            {
                grdInspection.CurrentRow.Cells["colInspectionIdItem"].Value = oelItems.IdItem;
                grdInspection.CurrentRow.Cells["colInspectionArticleName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "PackingBrand")
            {
                grdPacking.CurrentRow.Cells["colPackingIdItem"].Value = oelItems.IdItem;
                grdPacking.CurrentRow.Cells["colPackingArticleName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Cutting")
            {
                grdCutting.CurrentRow.Cells["colCuttingIdItem"].Value = oelItems.IdItem;
                grdCutting.CurrentRow.Cells["colCuttingItemName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Talli Cutting")
            {
                grdTalliCutting.CurrentRow.Cells["colTalliCuttingIdItem"].Value = oelItems.IdItem;
                grdTalliCutting.CurrentRow.Cells["colTalliCuttingItemName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Cutting Materials")
            {
                grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialIdItem"].Value = oelItems.IdItem;
                grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialName"].Value = oelItems.ItemName;
                grdCuttingMaterialUsed.CurrentRow.Cells["colCuttingMaterialUOM"].Value = oelItems.PackingSize;
            }
            else if (EventFiringName == "Gloves Talli Cutting Materials")
            {
                grdTalliCuttingMaterialUsed.CurrentRow.Cells["colTalliCuttingMaterialIdItem"].Value = oelItems.IdItem;
                grdTalliCuttingMaterialUsed.CurrentRow.Cells["colTalliCuttingMaterialName"].Value = oelItems.ItemName;
                grdTalliCuttingMaterialUsed.CurrentRow.Cells["colTalliCuttingMaterialUOM"].Value = oelItems.PackingSize;
            }
            else if (EventFiringName == "Gloves Cutting Wastage")
            {
                grdCuttingWastage.CurrentRow.Cells["colCuttingWastageIdItem"].Value = oelItems.IdItem;
                grdCuttingWastage.CurrentRow.Cells["colCuttingWastageName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Talli Cutting Wastage")
            {
                grdTalliCuttingWastage.CurrentRow.Cells["colTalliCuttingWastageIdItem"].Value = oelItems.IdItem;
                grdTalliCuttingWastage.CurrentRow.Cells["colTalliCuttingWastageName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Printing Materials")
            {
                grdCuffPrintingMaterial.CurrentRow.Cells["colCuffPrintingMaterialIdItem"].Value = oelItems.IdItem;
                grdCuffPrintingMaterial.CurrentRow.Cells["colCuffPrintingMaterialName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Printing Wastage")
            {
                grdCuffPrintingMaterial.CurrentRow.Cells["colCuffPrintingWastageIdItem"].Value = oelItems.IdItem;
                grdCuffPrintingMaterial.CurrentRow.Cells["colCuffPrintingWastageName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves OverLock Materials")
            {
                grdOverlockMaterials.CurrentRow.Cells["colOverLockMaterialIdItem"].Value = oelItems.IdItem;
                grdOverlockMaterials.CurrentRow.Cells["colOverLockMaterialName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves OverLock RecievedItemName")
            {
                grdOverLock.CurrentRow.Cells["colOverLockIdItem"].Value = oelItems.IdItem;
                grdOverLock.CurrentRow.Cells["colOverLockItemName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves OverLock RecievedArticleName")
            {
                grdOverLock.CurrentRow.Cells["colOverLockIdArticle"].Value = oelItems.IdItem;
                grdOverLock.CurrentRow.Cells["colOverLockArticleName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Magzi Materials")
            {
                grdMagziMaterial.CurrentRow.Cells["colMagziMaterialIdItem"].Value = oelItems.IdItem;
                grdMagziMaterial.CurrentRow.Cells["colMagziMaterialName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Magzi RecievedItemName")
            {
                grdMagzi.CurrentRow.Cells["colMagziIdItem"].Value = oelItems.IdItem;
                grdMagzi.CurrentRow.Cells["colMagziItemName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Magzi RecievedArticleName")
            {
                grdMagzi.CurrentRow.Cells["colMagziIdArticle"].Value = oelItems.IdItem;
                grdMagzi.CurrentRow.Cells["colMagziArticleName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Tap Materials")
            {
                grdTapMaterial.CurrentRow.Cells["colTapMaterialIdItem"].Value = oelItems.IdItem;
                grdTapMaterial.CurrentRow.Cells["colTapMaterialName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Tap RecievedItemName")
            {
                grdTap.CurrentRow.Cells["colTapIdItem"].Value = oelItems.IdItem;
                grdTap.CurrentRow.Cells["colTapItemName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Tap RecievedArticleName")
            {
                grdTap.CurrentRow.Cells["colTapIdArticle"].Value = oelItems.IdItem;
                grdTap.CurrentRow.Cells["colTapArticleName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Stitching Materials")
            {
                if (GetItemType(oelItems.IdItem) == 0)
                {
                    MessageBox.Show("No Item Type Is Defined Here...");
                    return;
                }
                else
                {
                    grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialIdItem"].Value = oelItems.IdItem;
                    grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialName"].Value = oelItems.ItemName;
                    grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialItemType"].Value = GetItemType(oelItems.IdItem);
                    grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialUOM"].Value = oelItems.PackingSize;
                }
            }
            else if (EventFiringName == "Gloves Stitching Material Article")
            {
                grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialIdArticle"].Value = oelItems.IdItem;
                grdStitchingMaterials.CurrentRow.Cells["colStitchingMaterialArticleName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Stitching RecievedItemName")
            {
                grdStitching.CurrentRow.Cells["colStitchingIdItem"].Value = oelItems.IdItem;
                grdStitching.CurrentRow.Cells["colStitchingItemName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Repair Materials")
            {
                grdGlovesRepairMaterial.CurrentRow.Cells["colGlovesRepairMaterialIdItem"].Value = oelItems.IdItem;
                grdGlovesRepairMaterial.CurrentRow.Cells["colGlovesRepairMaterialName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Repair RecievedItemName")
            {
                grdGlovesRepair.CurrentRow.Cells["colGlovesRepairIdItem"].Value = oelItems.IdItem;
                grdGlovesRepair.CurrentRow.Cells["colGlovesRepairItemName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "Gloves Packing Materials")
            {
                if (GetItemType(oelItems.IdItem) == 0)
                {
                    MessageBox.Show("No Item Type Is Defined Here...");
                    return;
                }
                else if (GetItemType(oelItems.IdItem) == 2)
                {
                    MessageBox.Show("No Semi Finised Item Type Is Allowed Here...");
                    return;
                }
                else
                {
                    grdPackingMaterials.CurrentRow.Cells["colPackingMaterialIdItem"].Value = oelItems.IdItem;
                    grdPackingMaterials.CurrentRow.Cells["colPackingMaterialItemType"].Value = GetItemType(oelItems.IdItem);
                    grdPackingMaterials.CurrentRow.Cells["colPackingMaterialName"].Value = oelItems.ItemName;
                    grdPackingMaterials.CurrentRow.Cells["colPackingMaterialUOM"].Value = oelItems.PackingSize;
                }
            }
            else if (EventFiringName == "Gloves Opening Stock")
            {
                grdOpeningStock.CurrentRow.Cells["colOrderOpeningStockIdItem"].Value = oelItems.IdItem;
                grdOpeningStock.CurrentRow.Cells["colOrderOpeningStockItemName"].Value = oelItems.ItemName;
            }
            else
            {
                //txtQuality.Text = oelItems.AccountName;
                IdQuality = oelItems.IdItem;
            }

        }
        private void cbxCustomerPOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCustomerPOS.SelectedIndex > 0)
            {
                GetVoucherInfoByCustomerPONo(cbxCustomerPOS.Text);
                FillCustomerPoDetail();
                LoadType = "CustomerPo";
                ProductionTab_SelectedIndexChanged(sender, e);
                //ProductionTab_SelectedIndexChanged(sender, e);   
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
        private void GetProductionVoucher()
        {
            var manager = new ProductionProcessesHeadBLL();
            List<ProductionProcessesHeadEL> list = manager.GetProductionByNumberAndType(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text), 1);
            if (list.Count > 0)
            {
                IdVoucher = list[0].IdVoucher;
            }
            else
            {
                IdVoucher = Guid.Empty;
            }
        }
        #endregion
        #region Tabs Related Events And Methods
        private void ProductionTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Variables
            var Manager = new ProductionProcessDetailBLL();
            var MManager = new ProductionMaterialsBLL();
            List<ProductionProcessDetailEL> list = null;
            List<ProductionProcessesEL> listProcess = null;
            string ProcessName = "";
            #endregion
            #region Gloves Opening Stock Process
            if (ProductionTab.SelectedIndex == 0)
            {
               ProcessName = "Gloves Opening Stock";
               list = Manager.GetProductionOpeningStockByOrder(IdVoucher, 1);
               if (list.Count > 0)
                {
                    //VEditBox.Text = list[0].VoucherNo.ToString();
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
            #region Gloves Cutting Process
            if (ProductionTab.SelectedIndex == 1)
            {
                ProcessName = "Gloves Cutting";
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
                    //VEditBox.Text = list[0].VoucherNo.ToString();
                    if (grdCutting.Rows.Count > 0)
                    {
                        grdCutting.Rows.Clear();
                    }
                    IdCutting = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Cuff Cutting Material Usage");
                    if (grdCuttingMaterialUsed.Rows.Count > 0)
                    {
                        grdCuttingMaterialUsed.Rows.Clear();
                    }
                    FillMaterials(listMaterials, ProcessName);
                    List<ProductionMaterialUsedEL> listWastage = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, ProcessName);
                    FillWastage(listWastage, ProcessName);
                }
                else
                {
                    if (grdCutting.Rows.Count > 0)
                    {
                        grdCutting.Rows.Clear();
                    }
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdCutting = listProcess[0].IdProductionProcess;
                    }
                    FillCuttingMaterialGridByCustomerPO();
                }
            }
            #endregion
            #region Gloves Talli Cutting Process
            else if (ProductionTab.SelectedIndex == 2)
            {
                ProcessName = "Gloves Talli Cutting";
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
                    //VEditBox.Text = list[0].VoucherNo.ToString();
                    if (grdTalliCutting.Rows.Count > 0)
                    {
                        grdTalliCutting.Rows.Clear();
                    }
                    IdCutting = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Talli Cutting Material Usage");
                    if (grdTalliCuttingMaterialUsed.Rows.Count > 0)
                    {
                        grdTalliCuttingMaterialUsed.Rows.Clear();
                    }
                    FillMaterials(listMaterials, ProcessName);
                    List<ProductionMaterialUsedEL> listWastage = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, ProcessName);
                    FillWastage(listWastage, ProcessName);
                }
                else
                {
                    if (grdTalliCutting.Rows.Count > 0)
                    {
                        grdTalliCutting.Rows.Clear();
                    }
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdCutting = listProcess[0].IdProductionProcess;
                    }
                    FillTalliCuttingMaterialGridByCustomerPO();
                }
            }
            #endregion
            #region Gloves Printing Process
            else if (ProductionTab.SelectedIndex == 3)
            {
                ProcessName = "Gloves Cuff Printing";
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
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Cuff Printing Material Usage");
                    if (grdCuffPrinting.Rows.Count > 0)
                    {
                        grdCuffPrinting.Rows.Clear();
                    }
                    IdPrinting = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdCuffPrintingMaterial.Rows.Count > 0)
                        {
                            grdCuffPrintingMaterial.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                    List<ProductionMaterialUsedEL> listWastage = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, ProcessName);
                    if (listWastage.Count > 0)
                    {
                        if (grdCuffPrintingMaterial.Rows.Count > 0)
                        {
                            grdCuffPrintingMaterial.Rows.Clear();
                            FillWastage(listWastage, ProcessName);
                        }
                    }
                }
                else
                {
                    if (grdCuffPrinting.Rows.Count > 0)
                    {
                        grdCuffPrinting.Rows.Clear();
                    }
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdPrinting = listProcess[0].IdProductionProcess;
                    }
                    FillPrintingMaterialGridByCustomerPO();
                }
            }
            #endregion
            #region Overlock Process
            else if (ProductionTab.SelectedIndex == 4)
            {
                ProcessName = "Gloves OverLock";
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
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves OverLock Material Usage");
                    if (grdOverLock.Rows.Count > 0)
                    {
                        grdOverLock.Rows.Clear();
                    }
                    IdOverLock = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdOverlockMaterials.Rows.Count > 0)
                        {
                            grdOverlockMaterials.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                }
                else
                {
                    if (grdOverLock.Rows.Count > 0)
                    {
                        grdOverLock.Rows.Clear();
                    }
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdOverLock = listProcess[0].IdProductionProcess;
                    }
                    FillOverLockMaterialGridByCustomerPO();
                }
            }
            #endregion
            #region Magzi Process
            else if (ProductionTab.SelectedIndex == 5)
            {
                ProcessName = "Gloves Magzi";
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
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Magzi Material Usage");
                    if (grdMagzi.Rows.Count > 0)
                    {
                        grdMagzi.Rows.Clear();
                    }
                    IdMagzi = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdMagziMaterial.Rows.Count > 0)
                        {
                            grdMagziMaterial.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                }
                else
                {
                    if (grdMagzi.Rows.Count > 0)
                    {
                        grdMagzi.Rows.Clear();
                    }
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdMagzi = listProcess[0].IdProductionProcess;
                    }
                    FillMagziMaterialGridByCustomerPO();
                }
            }
            #endregion
            #region Tap Process
            else if (ProductionTab.SelectedIndex == 6)
            {
                ProcessName = "Gloves Tape";
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
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Tap Material Usage");
                    if (grdTap.Rows.Count > 0)
                    {
                        grdTap.Rows.Clear();
                    }
                    IdMagzi = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdTapMaterial.Rows.Count > 0)
                        {
                            grdTapMaterial.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                }
                else
                {
                    if (grdTap.Rows.Count > 0)
                    {
                        grdTap.Rows.Clear();
                    }
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdMagzi = listProcess[0].IdProductionProcess;
                    }
                    FillTapeMaterialGridByCustomerPO();
                }
            }
            #endregion
            #region Gloves Stitching Process
            else if (ProductionTab.SelectedIndex == 7)
            {
                ProcessName = "Gloves Stitching";
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
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Stitching Material Usage");
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
                    if (grdStitching.Rows.Count > 0)
                    {
                        grdStitching.Rows.Clear();
                    }
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdStitching = listProcess[0].IdProductionProcess;
                    }
                    FillStitchingMaterialGridByCustomerPO();
                }
            }
            #endregion
            #region Gloves Repair Process
            else if (ProductionTab.SelectedIndex == 8)
            {
                ProcessName = "Gloves Repair";
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
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Repair Material Usage");
                    if (grdGlovesRepair.Rows.Count > 0)
                    {
                        grdGlovesRepair.Rows.Clear();
                    }
                    IdInspection = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdGlovesRepairMaterial.Rows.Count > 0)
                        {
                            grdGlovesRepairMaterial.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                }
                else
                {
                    if (grdGlovesRepair.Rows.Count > 0)
                    {
                        grdGlovesRepair.Rows.Clear();
                    }
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdInspection = listProcess[0].IdProductionProcess;
                    }
                    FillGlovesRepairMaterialGridByCustomerPO();
                }
            }
            #endregion
            #region Gloves Inspection Process
            else if (ProductionTab.SelectedIndex == 9)
            {
                ProcessName = "Gloves Inspection";
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
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, ProcessName);
                    if (grdInspection.Rows.Count > 0)
                    {
                        grdInspection.Rows.Clear();
                    }
                    IdInspection = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                }
                else
                {
                    if (grdInspection.Rows.Count > 0)
                    {
                        grdInspection.Rows.Clear();
                    }
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdInspection = listProcess[0].IdProductionProcess;
                    }
                }
            }
            #endregion            
            #region Gloves Packing Process
            else if (ProductionTab.SelectedIndex == 10)
            {
                ProcessName = "Gloves Packing";
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
                    List<ProductionMaterialUsedEL> listMaterials = MManager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Packing Material Usage");
                    if (grdPacking.Rows.Count > 0)
                    {
                        grdPacking.Rows.Clear();
                    }
                    IdPacking = list[0].IdProductionProcess;
                    FillProcessDetails(list, ProcessName);
                    if (listMaterials.Count > 0)
                    {
                        if (grdPackingMaterials.Rows.Count > 0)
                        {
                            grdPackingMaterials.Rows.Clear();
                        }
                        FillMaterials(listMaterials, ProcessName);
                    }
                }
                else
                {
                    if (grdPacking.Rows.Count > 0)
                    {
                        grdPacking.Rows.Clear();
                    }                    
                    listProcess = Manager.GetProcessDetailByName(ProcessName);
                    if (listProcess.Count > 0)
                    {
                        IdPacking = listProcess[0].IdProductionProcess;
                    }
                    FillGlovesPackingMaterialGridByCustomerPO();
                }
            }
            #endregion
            #region Factory OverHeads
            else if (ProductionTab.SelectedIndex == 11)
            {
                var OverHeadManager = new ProductionOverHeadsBLL();
                List<ProductionOverHeadEL> listCost = OverHeadManager.GetProductionOverHeadsByVoucher(IdVoucher, 1);
                if (listCost.Count > 0)
                {
                    if (grdMiscCost.Rows.Count > 0)
                    {
                        grdMiscCost.Rows.Clear();
                    }
                    FillProductionCost(listCost);
                }
                else 
                {
                    if (grdMiscCost.Rows.Count > 0)
                    {
                        grdMiscCost.Rows.Clear();
                    }
                }
            }
            #endregion
        }
        private void FillProcessDetails(List<ProductionProcessDetailEL> list, string ProcessName)
        {
            IdVoucher = list[0].IdVoucher;
            for (int i = 0; i < list.Count; i++)
            {
                #region Gloves Opening Stock
                if (ProcessName == "Gloves Opening Stock")
                {
                    grdOpeningStock.Rows.Add();
                    grdOpeningStock.Rows[i].Cells["colIdOrderOpeningStock"].Value = list[i].IdProductionProcessDetail;
                    grdOpeningStock.Rows[i].Cells["colOrderOpeningStockIdItem"].Value = list[i].IdItem;
                    grdOpeningStock.Rows[i].Cells["colOrderOpeningStockItemName"].Value = list[i].ItemName;
                    if (list[i].IdProductionDepartment == 1)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Gloves Cuff Cutting";
                    }
                    else if (list[i].IdProductionDepartment == 2)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Gloves Talli Cutting";
                    }
                    else if (list[i].IdProductionDepartment == 3)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Gloves Cuff Printing";
                    }
                    else if (list[i].IdProductionDepartment == 4)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Gloves Cuff OverLock";
                    }
                    else if (list[i].IdProductionDepartment == 5)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Gloves Cuff Magzi";
                    }
                    else if (list[i].IdProductionDepartment == 6)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Gloves Cuff Tape";
                    }
                    else if (list[i].IdProductionDepartment == 7)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Gloves Cuff Stitching";
                    }
                    else if (list[i].IdProductionDepartment == 8)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Gloves Cuff Repair";
                    }
                    else if (list[i].IdProductionDepartment == 9)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Gloves Checking / Inspection";
                    }
                    else if (list[i].IdProductionDepartment == 10)
                    {
                        grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value = "Gloves Packing";
                    }
                    grdOpeningStock.Rows[i].Cells["colOrderOpeningStockQuantity"].Value = CommonFunctions.RemoveTrailingZeros(list[i].Qty);
                    grdOpeningStock.Rows[i].Cells["colOrderOpeningStockRates"].Value = list[i].Rate;
                    grdOpeningStock.Rows[i].Cells["colOrderOpeningStockAmount"].Value = list[i].Amount;
                }
                #endregion
                #region Gloves Cutting Entries
                if (ProcessName == "Gloves Cutting")
                {
                    grdCutting.Rows.Add();
                    grdCutting.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdCutting.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdCutting.Rows[i].Cells[2].Value = list[i].Posted;
                    grdCutting.Rows[i].Cells[3].Value = list[i].IdVoucher;
                    grdCutting.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdCutting.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdCutting.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdCutting.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdCutting.Rows[i].Cells[8].Value = list[i].ItemName;
                    grdCutting.Rows[i].Cells[9].Value = list[i].ItemSize;
                    grdCutting.Rows[i].Cells[10].Value = list[i].Quantity;

                    grdCutting.Rows[i].Cells[11].Value = list[i].Rate;
                    grdCutting.Rows[i].Cells[12].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdCutting.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells[10].ReadOnly = true;
                        grdCutting.Rows[i].Cells[11].ReadOnly = true;
                        grdCutting.Rows[i].ReadOnly = true;
                    }

                }
                #endregion
                #region Gloves Talli Cutting Entries
                if (ProcessName == "Gloves Talli Cutting")
                {
                    grdTalliCutting.Rows.Add();
                    grdTalliCutting.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdTalliCutting.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdTalliCutting.Rows[i].Cells[2].Value = list[i].Posted;
                    grdTalliCutting.Rows[i].Cells[3].Value = list[i].IdVoucher;
                    grdTalliCutting.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdTalliCutting.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdTalliCutting.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdTalliCutting.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdTalliCutting.Rows[i].Cells[8].Value = list[i].ItemName;
                    grdTalliCutting.Rows[i].Cells[9].Value = list[i].ItemSize;
                    grdTalliCutting.Rows[i].Cells[10].Value = list[i].Quantity;

                    grdTalliCutting.Rows[i].Cells[11].Value = list[i].Rate;
                    grdTalliCutting.Rows[i].Cells[12].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdTalliCutting.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdTalliCutting.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdTalliCutting.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdTalliCutting.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdTalliCutting.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdTalliCutting.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdTalliCutting.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdTalliCutting.Rows[i].Cells[10].ReadOnly = true;
                        grdTalliCutting.Rows[i].Cells[11].ReadOnly = true;
                        grdTalliCutting.Rows[i].ReadOnly = true;
                    }

                }
                #endregion
                #region Gloves Printing Entries
                else if (ProcessName == "Gloves Cuff Printing")
                {
                    grdCuffPrinting.Rows.Add();
                    grdCuffPrinting.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdCuffPrinting.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdCuffPrinting.Rows[i].Cells[2].Value = list[i].IdArticle;
                    grdCuffPrinting.Rows[i].Cells[3].Value = list[i].Posted;
                    grdCuffPrinting.Rows[i].Cells[4].Value = list[i].IdVoucher;
                    grdCuffPrinting.Rows[i].Cells[5].Value = list[i].AccountNo;
                    grdCuffPrinting.Rows[i].Cells[6].Value = list[i].AccountType;
                    grdCuffPrinting.Rows[i].Cells[7].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdCuffPrinting.Rows[i].Cells[8].Value = list[i].AccountName;
                    grdCuffPrinting.Rows[i].Cells[9].Value = list[i].ItemName;
                    grdCuffPrinting.Rows[i].Cells[10].Value = list[i].ArticleName;

                    grdCuffPrinting.Rows[i].Cells[11].Value = list[i].ItemSize;
                    grdCuffPrinting.Rows[i].Cells[12].Value = list[i].Quantity;



                    grdCuffPrinting.Rows[i].Cells[13].Value = list[i].Rate;
                    grdCuffPrinting.Rows[i].Cells[14].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdCuffPrinting.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdCuffPrinting.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;

                        grdCuffPrinting.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region OverLock Entries
                else if (ProcessName == "Gloves OverLock")
                {
                    grdOverLock.Rows.Add();
                    grdOverLock.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdOverLock.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdOverLock.Rows[i].Cells[2].Value = list[i].IdArticle;
                    grdOverLock.Rows[i].Cells[3].Value = list[i].Posted;
                    grdOverLock.Rows[i].Cells[4].Value = list[i].IdVoucher;
                    grdOverLock.Rows[i].Cells[5].Value = list[i].AccountNo;
                    grdOverLock.Rows[i].Cells[6].Value = list[i].AccountType;
                    grdOverLock.Rows[i].Cells[7].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdOverLock.Rows[i].Cells[8].Value = list[i].AccountName;
                    grdOverLock.Rows[i].Cells[9].Value = list[i].ItemName;
                    grdOverLock.Rows[i].Cells[10].Value = list[i].ArticleName;

                    grdOverLock.Rows[i].Cells[11].Value = list[i].ItemSize;
                    grdOverLock.Rows[i].Cells[12].Value = list[i].Quantity;

                    grdOverLock.Rows[i].Cells[13].Value = list[i].Rate;
                    grdOverLock.Rows[i].Cells[14].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdOverLock.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdOverLock.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;

                        grdOverLock.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Magzi Entriese
                else if (ProcessName == "Gloves Magzi")
                {
                    grdMagzi.Rows.Add();
                    grdMagzi.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdMagzi.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdMagzi.Rows[i].Cells[2].Value = list[i].IdArticle;
                    grdMagzi.Rows[i].Cells[3].Value = list[i].Posted;
                    grdMagzi.Rows[i].Cells[4].Value = list[i].IdVoucher;
                    grdMagzi.Rows[i].Cells[5].Value = list[i].AccountNo;
                    grdMagzi.Rows[i].Cells[6].Value = list[i].AccountType;
                    grdMagzi.Rows[i].Cells[7].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdMagzi.Rows[i].Cells[8].Value = list[i].AccountName;
                    grdMagzi.Rows[i].Cells[9].Value = list[i].ItemName;
                    grdMagzi.Rows[i].Cells[10].Value = list[i].ArticleName;

                    grdMagzi.Rows[i].Cells[11].Value = list[i].ItemSize;
                    grdMagzi.Rows[i].Cells[12].Value = list[i].Quantity;

                    grdMagzi.Rows[i].Cells[13].Value = list[i].Rate;
                    grdMagzi.Rows[i].Cells[14].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdMagzi.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdMagzi.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;

                        grdMagzi.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Tap Entriese
                else if (ProcessName == "Gloves Tape")
                {
                    grdTap.Rows.Add();
                    grdTap.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdTap.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdTap.Rows[i].Cells[2].Value = list[i].IdArticle;
                    grdTap.Rows[i].Cells[3].Value = list[i].Posted;
                    grdTap.Rows[i].Cells[4].Value = list[i].IdVoucher;
                    grdTap.Rows[i].Cells[5].Value = list[i].AccountNo;
                    grdTap.Rows[i].Cells[6].Value = list[i].AccountType;
                    grdTap.Rows[i].Cells[7].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdTap.Rows[i].Cells[8].Value = list[i].AccountName;
                    grdTap.Rows[i].Cells[9].Value = list[i].ItemName;
                    grdTap.Rows[i].Cells[10].Value = list[i].ArticleName;

                    grdTap.Rows[i].Cells[11].Value = list[i].ItemSize;
                    grdTap.Rows[i].Cells[12].Value = list[i].Quantity;

                    grdTap.Rows[i].Cells[13].Value = list[i].Rate;
                    grdTap.Rows[i].Cells[14].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdTap.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdTap.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdTap.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdTap.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdTap.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdTap.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdTap.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdTap.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdTap.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdTap.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdTap.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdTap.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;

                        grdTap.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Stitching Entries
                else if (ProcessName == "Gloves Stitching")
                {

                    grdStitching.Rows.Add();
                    grdStitching.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdStitching.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdStitching.Rows[i].Cells[2].Value = list[i].Posted;
                    grdStitching.Rows[i].Cells[3].Value = list[i].IdVoucher;
                    grdStitching.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdStitching.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdStitching.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdStitching.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdStitching.Rows[i].Cells[8].Value = list[i].ItemName;

                    grdStitching.Rows[i].Cells[9].Value = list[i].ItemSize;

                    grdStitching.Rows[i].Cells[10].Value = list[i].Quantity;
                    grdStitching.Rows[i].Cells[11].Value = list[i].Rate;
                    grdStitching.Rows[i].Cells[12].Value = list[i].Amount;

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

                        grdStitching.Rows[i].ReadOnly = true;
                    }

                }
                #endregion
                #region Checking / Inspection Entries
                else if (ProcessName == "Gloves Inspection")
                {
                    grdInspection.Rows.Add();
                    grdInspection.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdInspection.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdInspection.Rows[i].Cells[2].Value = list[i].Posted;
                    grdInspection.Rows[i].Cells[3].Value = list[i].IdVoucher;
                    grdInspection.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdInspection.Rows[i].Cells[5].Value = list[i].StitcherAccountNo;
                    grdInspection.Rows[i].Cells[6].Value = list[i].AccountType;
                    grdInspection.Rows[i].Cells[7].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdInspection.Rows[i].Cells[8].Value = list[i].LinkAccountName;
                    grdInspection.Rows[i].Cells[9].Value = list[i].ItemName;
                    grdInspection.Rows[i].Cells[10].Value = list[i].AccountName;

                    grdInspection.Rows[i].Cells[11].Value = list[i].ItemSize;
                    if (list[i].GarmentWorkType == 0)
                    {
                        grdInspection.Rows[i].Cells[12].Value = "";    
                    }
                    else if (list[i].GarmentWorkType == 1)
                    {
                        grdInspection.Rows[i].Cells[12].Value = "Stitching";
                    }
                    if (list[i].GarmentWorkType == 2)
                    {
                        grdInspection.Rows[i].Cells[12].Value = "Repair";
                    }
                    grdInspection.Rows[i].Cells[13].Value = list[i].Quantity;
                    grdInspection.Rows[i].Cells[14].Value = list[i].ReadyUnits;
                    grdInspection.Rows[i].Cells[15].Value = list[i].Rejection;
                    grdInspection.Rows[i].Cells[16].Value = list[i].BQuantity;
                    grdInspection.Rows[i].Cells[17].Value = list[i].RepairQuantity;

                    grdInspection.Rows[i].Cells[18].Value = list[i].InspectorRate;
                    grdInspection.Rows[i].Cells[19].Value = list[i].InspectorAmount;
                    grdInspection.Rows[i].Cells[20].Value = list[i].Rate;
                    grdInspection.Rows[i].Cells[21].Value = list[i].Amount;

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
                        grdInspection.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;
                        grdInspection.Rows[i].Cells[15].Style.BackColor = Color.LightGreen;

                        grdInspection.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Gloves Repair Entries
                else if (ProcessName == "Gloves Repair")
                {

                    grdGlovesRepair.Rows.Add();
                    grdGlovesRepair.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdGlovesRepair.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdGlovesRepair.Rows[i].Cells[2].Value = list[i].Posted;
                    grdGlovesRepair.Rows[i].Cells[3].Value = list[i].IdVoucher;
                    grdGlovesRepair.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdGlovesRepair.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdGlovesRepair.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdGlovesRepair.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdGlovesRepair.Rows[i].Cells[8].Value = list[i].ItemName;

                    grdGlovesRepair.Rows[i].Cells[9].Value = list[i].ItemSize;

                    grdGlovesRepair.Rows[i].Cells[10].Value = list[i].Quantity;
                    grdGlovesRepair.Rows[i].Cells[11].Value = list[i].Rate;
                    grdGlovesRepair.Rows[i].Cells[12].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdGlovesRepair.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdGlovesRepair.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdGlovesRepair.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdGlovesRepair.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdGlovesRepair.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdGlovesRepair.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdGlovesRepair.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdGlovesRepair.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdGlovesRepair.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdGlovesRepair.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;

                        grdGlovesRepair.Rows[i].ReadOnly = true;
                    }

                }
                #endregion
                #region Packing Entries
                else if (ProcessName == "Gloves Packing")
                {
                    grdPacking.Rows.Add();
                    grdPacking.Rows[i].Cells[0].Value = list[i].IdProductionProcessDetail;
                    grdPacking.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdPacking.Rows[i].Cells[2].Value = list[i].Posted;
                    grdPacking.Rows[i].Cells[3].Value = list[i].IdVoucher;
                    grdPacking.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdPacking.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdPacking.Rows[i].Cells[6].Value = Convert.ToDateTime(list[i].WorkDate).ToShortDateString();
                    grdPacking.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdPacking.Rows[i].Cells[8].Value = list[i].ItemName;

                    grdPacking.Rows[i].Cells[9].Value = list[i].ItemSize;
                    grdPacking.Rows[i].Cells[10].Value = list[i].PStyle;
                    grdPacking.Rows[i].Cells[11].Value = list[i].PackingSize;
                    grdPacking.Rows[i].Cells[12].Value = list[i].ReadyUnits;

                    grdPacking.Rows[i].Cells[13].Value = list[i].PackingCartons;
                    grdPacking.Rows[i].Cells[14].Value = list[i].Rate;
                    grdPacking.Rows[i].Cells[15].Value = list[i].Amount;

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
                if (ProcessName == "Gloves Cutting")
                {
                    grdCuttingMaterialUsed.Rows.Add();
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialIdItem"].Value = list[i].IdItem;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMateriaAccountNo"].Value = list[i].AccountNo;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialDate"].Value = list[i].VDate;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialName"].Value = list[i].ItemName;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUOM"].Value = list[i].PackingSize;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialWorkerName"].Value = list[i].AccountName;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUsedQty"].Value = list[i].UsedQuantity;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialRate"].Value = list[i].Rate;
                    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialAmount"].Value = list[i].Amount;
                }
                #endregion
                #region Talli Cutting Materials Entries
                else if (ProcessName == "Gloves Talli Cutting")
                {
                    grdTalliCuttingMaterialUsed.Rows.Add();
                    grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialIdItem"].Value = list[i].IdItem;
                    grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialAccountNo"].Value = list[i].AccountNo;
                    grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialDate"].Value = list[i].VDate;
                    grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialName"].Value = list[i].ItemName;
                    grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialUOM"].Value = list[i].PackingSize;
                    grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialWorkerName"].Value = list[i].AccountName;
                    grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialUsedQty"].Value = list[i].UsedQuantity;
                    grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialRate"].Value = list[i].Rate;
                    grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialAmount"].Value = list[i].Amount;
                }
                #endregion
                #region Gloves Cuff Printing Materials Entries
                if (ProcessName == "Gloves Cuff Printing")
                {
                    grdCuffPrintingMaterial.Rows.Add();
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialIdItem"].Value = list[i].IdItem;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialAccountNo"].Value = list[i].AccountNo;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialDate"].Value = list[i].VDate;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialName"].Value = list[i].ItemName;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialUOM"].Value = list[i].PackingSize;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialWorkerName"].Value = list[i].AccountName;
                    if (list[i].IdProductionDepartment == 0)
                    {
                        grdCuffPrintingMaterial.Rows[i].Cells["colPrintingMaterialDepartment"].Value = "Cuff General Stock";
                    }
                    else if (list[i].IdProductionDepartment == 1)
                    {
                        grdCuffPrintingMaterial.Rows[i].Cells["colPrintingMaterialDepartment"].Value = "Cuff Cutting";
                    }
                    else if (list[i].IdProductionDepartment == 3)
                    {
                        grdCuffPrintingMaterial.Rows[i].Cells["colPrintingMaterialDepartment"].Value = "Cuff OverLock";
                    }
                    else if (list[i].IdProductionDepartment == 4)
                    {
                        grdCuffPrintingMaterial.Rows[i].Cells["colPrintingMaterialDepartment"].Value = "Cuff Magzi";
                    }
                    else if (list[i].IdProductionDepartment == 5)
                    {
                        grdCuffPrintingMaterial.Rows[i].Cells["colPrintingMaterialDepartment"].Value = "Cuff Tape";
                    }
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialUsedQuantity"].Value = list[i].UsedQuantity;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialRate"].Value = list[i].Rate;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialAmount"].Value = list[i].Amount;
                }
                #endregion
                #region Gloves OverLock Materials Entries
                if (ProcessName == "Gloves OverLock")
                {
                    grdOverlockMaterials.Rows.Add();
                    grdOverlockMaterials.Rows[i].Cells["colOverLockIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialIdItem"].Value = list[i].IdItem;
                    grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialAccountNo"].Value = list[i].AccountNo;
                    grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialDate"].Value = list[i].VDate;
                    grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialName"].Value = list[i].ItemName;
                    grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialUOM"].Value = list[i].PackingSize;
                    grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialWorkerName"].Value = list[i].AccountName;
                    if (list[i].IdProductionDepartment == 0)
                    {
                        grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialDepartment"].Value = "Cuff General Stock";
                    }
                    else if (list[i].IdProductionDepartment == 1)
                    {
                        grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialDepartment"].Value = "Cuff Cutting";
                    }
                    else if (list[i].IdProductionDepartment == 2)
                    {
                        grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialDepartment"].Value = "Cuff Printing";
                    }
                    else if (list[i].IdProductionDepartment == 4)
                    {
                        grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialDepartment"].Value = "Cuff Magzi";
                    }
                    else if (list[i].IdProductionDepartment == 5)
                    {
                        grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialDepartment"].Value = "Cuff Tape";
                    }
                    grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialQuantity"].Value = list[i].UsedQuantity;
                    grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialRate"].Value = list[i].Rate;
                    grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialAmount"].Value = list[i].Amount;
                }
                #endregion
                #region Gloves Magzi Materials Entries
                if (ProcessName == "Gloves Magzi")
                {
                    grdMagziMaterial.Rows.Add();
                    grdMagziMaterial.Rows[i].Cells["colMagziIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdMagziMaterial.Rows[i].Cells["colMagziMaterialIdItem"].Value = list[i].IdItem;
                    grdMagziMaterial.Rows[i].Cells["colMagziMaterialAccountNo"].Value = list[i].AccountNo;
                    grdMagziMaterial.Rows[i].Cells["colMagziMaterialDate"].Value = list[i].VDate;
                    grdMagziMaterial.Rows[i].Cells["colMagziMaterialName"].Value = list[i].ItemName;
                    grdMagziMaterial.Rows[i].Cells["colMagziMaterialUOM"].Value = list[i].PackingSize;
                    grdMagziMaterial.Rows[i].Cells["colMagziMaterialWorkerName"].Value = list[i].AccountName;
                    if (list[i].IdProductionDepartment == 0)
                    {
                        grdMagziMaterial.Rows[i].Cells["colMagziMaterialDepartment"].Value = "Cuff General Stock";
                    }
                    else if (list[i].IdProductionDepartment == 1)
                    {
                        grdMagziMaterial.Rows[i].Cells["colMagziMaterialDepartment"].Value = "Cuff Cutting";
                    }
                    else if (list[i].IdProductionDepartment == 2)
                    {
                        grdMagziMaterial.Rows[i].Cells["colMagziMaterialDepartment"].Value = "Cuff Printing";
                    }
                    else if (list[i].IdProductionDepartment == 3)
                    {
                        grdMagziMaterial.Rows[i].Cells["colMagziMaterialDepartment"].Value = "Cuff OverLock";
                    }
                    else if (list[i].IdProductionDepartment == 5)
                    {
                        grdMagziMaterial.Rows[i].Cells["colPrintingMaterialDepartment"].Value = "Cuff Tape";
                    }
                    grdMagziMaterial.Rows[i].Cells["colMagziMaterialUsedQuantity"].Value = list[i].UsedQuantity;
                    grdMagziMaterial.Rows[i].Cells["colMagziMaterialRate"].Value = list[i].Rate;
                    grdMagziMaterial.Rows[i].Cells["colMagziMaterialAmount"].Value = list[i].Amount;
                }
                #endregion
                #region Gloves Tape Materials Entries
                if (ProcessName == "Gloves Tape")
                {
                    grdTapMaterial.Rows.Add();
                    grdTapMaterial.Rows[i].Cells["colTapIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdTapMaterial.Rows[i].Cells["colTapMaterialIdItem"].Value = list[i].IdItem;
                    grdTapMaterial.Rows[i].Cells["colTapMaterialAccountNo"].Value = list[i].AccountNo;
                    grdTapMaterial.Rows[i].Cells["colTapMaterialDate"].Value = list[i].VDate;
                    grdTapMaterial.Rows[i].Cells["colTapMaterialName"].Value = list[i].ItemName;
                    grdTapMaterial.Rows[i].Cells["colTapMaterialUOM"].Value = list[i].PackingSize;
                    grdTapMaterial.Rows[i].Cells["colTapMaterialWorkerName"].Value = list[i].AccountName;
                    if (list[i].IdProductionDepartment == 0)
                    {
                        grdTapMaterial.Rows[i].Cells["colTapMaterialDepartment"].Value = "Cuff General Stock";
                    }
                    else if (list[i].IdProductionDepartment == 1)
                    {
                        grdTapMaterial.Rows[i].Cells["colTapMaterialDepartment"].Value = "Cuff Cutting";
                    }
                    else if (list[i].IdProductionDepartment == 2)
                    {
                        grdTapMaterial.Rows[i].Cells["colTapMaterialDepartment"].Value = "Cuff Printing";
                    }
                    else if (list[i].IdProductionDepartment == 3)
                    {
                        grdTapMaterial.Rows[i].Cells["colTapMaterialDepartment"].Value = "Cuff OverLock";
                    }
                    else if (list[i].IdProductionDepartment == 4)
                    {
                        grdTapMaterial.Rows[i].Cells["colTapMaterialDepartment"].Value = "Cuff Magzi";
                    }
                    grdTapMaterial.Rows[i].Cells["colTapMaterialUsedQuantity"].Value = list[i].UsedQuantity;
                    grdTapMaterial.Rows[i].Cells["colTapMaterialRate"].Value = list[i].Rate;
                    grdTapMaterial.Rows[i].Cells["colTapMaterialAmount"].Value = list[i].Amount;
                }
                #endregion
                #region Stitching Materials Entries
                if (ProcessName == "Gloves Stitching")
                {
                    grdStitchingMaterials.Rows.Add();
                    grdStitchingMaterials.Rows[i].Cells["colStitchingIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialIdItem"].Value = list[i].IdItem;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialIdArticle"].Value = list[i].IdArticle;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialAccountNo"].Value = list[i].AccountNo;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialItemType"].Value = list[i].ItemType;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDate"].Value = list[i].VDate;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialName"].Value = list[i].ItemName;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialArticleName"].Value = list[i].ArticleName;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialUOM"].Value = list[i].PackingSize;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialWorkerName"].Value = list[i].AccountName;
                    if (list[i].IdProductionDepartment == 0)
                    {
                        grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value = "Cuff General Stock";
                    }
                    else if (list[i].IdProductionDepartment == 1)
                    {
                        grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value = "Cuff Cutting";
                    }
                    else if (list[i].IdProductionDepartment == 2)
                    {
                        grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value = "Cuff Printing";
                    }
                    else if (list[i].IdProductionDepartment == 3)
                    {
                        grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value = "Cuff OverLock";
                    }
                    else if (list[i].IdProductionDepartment == 4)
                    {
                        grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value = "Cuff Magzi";
                    }
                    else if (list[i].IdProductionDepartment == 5)
                    {
                        grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value = "Cuff Tape";
                    }
                    else if (list[i].IdProductionDepartment == 15)
                    {
                        grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value = "Cuff Talli";
                    }
                    else
                    {
                        grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value = "";
                    }
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialQuantity"].Value = list[i].UsedQuantity;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialRate"].Value = list[i].Rate;
                    grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialAmount"].Value = list[i].Amount;
                }
                #endregion
                #region Gloves Repair Materials Entries
                if (ProcessName == "Gloves Repair")
                {
                    grdGlovesRepairMaterial.Rows.Add();
                    grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialIdItem"].Value = list[i].IdItem;
                    grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialAccountNo"].Value = list[i].AccountNo;
                    grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialDate"].Value = list[i].VDate;
                    grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialName"].Value = list[i].ItemName;
                    grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialUOM"].Value = list[i].PackingSize;
                    grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialWorkerName"].Value = list[i].AccountName;
                    grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialUsedQuantity"].Value = list[i].UsedQuantity;
                    grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialRate"].Value = list[i].Rate;
                    grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialAmount"].Value = list[i].Amount;
                }
                #endregion
                #region Packing Materials Entries
                if (ProcessName == "Gloves Packing")
                {
                    grdPackingMaterials.Rows.Add();
                    grdPackingMaterials.Rows[i].Cells["colPackingIdMaterial"].Value = list[i].IdMaterialUsed;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialIdItem"].Value = list[i].IdItem;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialAccountNo"].Value = list[i].AccountNo;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialItemType"].Value = list[i].ItemType;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialDate"].Value = list[i].VDate;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialName"].Value = list[i].ItemName;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialUOM"].Value = list[i].PackingSize;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialWorkerName"].Value = list[i].AccountName;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialQuantity"].Value = list[i].UsedQuantity;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialRates"].Value = list[i].Rate;
                    grdPackingMaterials.Rows[i].Cells["colPackingMaterialAmount"].Value = list[i].Amount;
                }
                #endregion
            }
        }
        private void FillWastage(List<ProductionMaterialUsedEL> list, string ProcessName)
        {
            for (int i = 0; i < list.Count; i++)
            {
                #region Gloves Cutting Wastage Entries
                if (ProcessName == "Gloves Cutting")
                {
                    grdCuttingWastage.Rows.Add();
                    grdCuttingWastage.Rows[i].Cells["colCuttingIdWastage"].Value = list[i].IdMaterialUsed;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageIdItem"].Value = list[i].IdItem;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageName"].Value = list[i].ItemName;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageUOM"].Value = list[i].PackingSize;
                    grdCuttingWastage.Rows[i].Cells["colCuttingWastageQuantity"].Value = list[i].UsedQuantity;
                }
                #endregion
                #region Gloves Prinint Wastage Entries
                if (ProcessName == "Gloves Printing")
                {
                    grdCuffPrintingMaterial.Rows.Add();
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingIdWastage"].Value = list[i].IdMaterialUsed;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingWastageIdItem"].Value = list[i].IdItem;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingWastageName"].Value = list[i].ItemName;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingWastageUOM"].Value = list[i].PackingSize;
                    grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingWastageQuantity"].Value = list[i].UsedQuantity;
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
            //else if (IdVoucher == Guid.Empty)
            //{
            //    MessageBox.Show("Production Voucher May Not be selected :");
            //    Status = false;
            //}
            #endregion
            #region Cuff Cutting Grid Validation
            else if (GridNumber == 2)
            {
                for (int i = 0; i < grdCutting.Rows.Count - 1; i++)
                {
                    if (grdCutting.Rows[i].Cells["colCuttingVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
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
            #region Cuff Printing Grid Validation
            else if (GridNumber == 3)
            {
                for (int i = 0; i < grdCuffPrinting.Rows.Count - 1; i++)
                {
                    if (grdCuffPrinting.Rows[i].Cells["colCuffPrintingVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdCuffPrinting.Rows[i].Cells["colCuffPrintingAmount"].Value == null || Validation.GetSafeDecimal(grdCuffPrinting.Rows[i].Cells["colCuffPrintingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region OverLock Grid Validation
            else if (GridNumber == 4)
            {
                for (int i = 0; i < grdOverLock.Rows.Count - 1; i++)
                {
                    if (grdOverLock.Rows[i].Cells["colOverLockVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdOverLock.Rows[i].Cells["colOverLockAmount"].Value == null || Validation.GetSafeDecimal(grdOverLock.Rows[i].Cells["colOverLockAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Magzi Grid Validation
            else if (GridNumber == 5)
            {
                for (int i = 0; i < grdMagzi.Rows.Count - 1; i++)
                {
                    if (grdMagzi.Rows[i].Cells["colMagziVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdMagzi.Rows[i].Cells["colMagziAmount"].Value == null || Validation.GetSafeDecimal(grdMagzi.Rows[i].Cells["colMagziAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Tap Grid Validation
            else if (GridNumber == 6)
            {
                for (int i = 0; i < grdTap.Rows.Count - 1; i++)
                {
                    if (grdTap.Rows[i].Cells["colTapVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdTap.Rows[i].Cells["colTapAmount"].Value == null || Validation.GetSafeDecimal(grdTap.Rows[i].Cells["colTapAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Stitching Grid Validation
            else if (GridNumber == 7)
            {
                for (int i = 0; i < grdStitching.Rows.Count - 1; i++)
                {
                    if (grdStitching.Rows[i].Cells["colStitchingVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
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
            #region Checking Grid Validation
            else if (GridNumber == 8)
            {
                for (int i = 0; i < grdInspection.Rows.Count - 1; i++)
                {
                    if (grdInspection.Rows[i].Cells["colInspectionVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
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
            #region Packing Grid Validation
            else if (GridNumber == 10)
            {
                for (int i = 0; i < grdPacking.Rows.Count - 1; i++)
                {
                    if (grdPacking.Rows[i].Cells["colPackingVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
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
            //else if (IdVoucher == Guid.Empty)
            //{
            //    MessageBox.Show("Production Voucher May Not be selected :");
            //    Status = false;
            //}
            #endregion
            #region Cuff Cutting Material Grid Validation
            else if (GridNumber == 1)
            {
                for (int i = 0; i < grdCuttingMaterialUsed.Rows.Count - 1; i++)
                {
                    if (grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMateriaAccountNo"].Value == null)
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
            #region Cuff Talli Cutting Material Grid Validation
            else if (GridNumber == 2)
            {
                for (int i = 0; i < grdTalliCuttingMaterialUsed.Rows.Count - 1; i++)
                {
                    if (grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Worker.....");
                        break;
                    }
                    else if (grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Product.....");
                        break;
                    }
                    else if (grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialAmount"].Value == null || Validation.GetSafeDecimal(grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Cuff Printing Material Grid Validation
            else if (GridNumber == 3)
            {
                for (int i = 0; i < grdCuffPrintingMaterial.Rows.Count - 1; i++)
                {
                    if (grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Worker.....");
                        break;
                    }
                    else if (grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Product.....");
                        break;
                    }
                    else if (grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialAmount"].Value == null || Validation.GetSafeDecimal(grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region OverLock Material Grid Validation
            else if (GridNumber == 4)
            {
                for (int i = 0; i < grdOverlockMaterials.Rows.Count - 1; i++)
                {
                    if (grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Worker.....");
                        break;
                    }
                    else if (grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Product.....");
                        break;
                    }
                    else if (grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialAmount"].Value == null || Validation.GetSafeDecimal(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Magzi Material Grid Validation
            else if (GridNumber == 5)
            {
                for (int i = 0; i < grdMagziMaterial.Rows.Count - 1; i++)
                {
                    if (grdMagziMaterial.Rows[i].Cells["colMagziMaterialAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Worker.....");
                        break;
                    }
                    else if (grdMagziMaterial.Rows[i].Cells["colMagziMaterialIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Product.....");
                        break;
                    }
                    else if (grdMagziMaterial.Rows[i].Cells["colMagziMaterialAmount"].Value == null || Validation.GetSafeDecimal(grdMagziMaterial.Rows[i].Cells["colMagziMaterialAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Tap Material Grid Validation
            else if (GridNumber == 6)
            {
                for (int i = 0; i < grdTapMaterial.Rows.Count - 1; i++)
                {
                    if (grdTapMaterial.Rows[i].Cells["colTapMaterialAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Worker.....");
                        break;
                    }
                    else if (grdTapMaterial.Rows[i].Cells["colTapMaterialIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Product.....");
                        break;
                    }
                    else if (grdTapMaterial.Rows[i].Cells["colTapMaterialAmount"].Value == null || Validation.GetSafeDecimal(grdTapMaterial.Rows[i].Cells["colTapMaterialAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Stitching Grid Validation
            else if (GridNumber == 7)
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
                    else if (grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialIdArticle"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Article.....");
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
            #region Gloves Repair Grid Validation
            else if (GridNumber == 8)
            {
                for (int i = 0; i < grdGlovesRepairMaterial.Rows.Count - 1; i++)
                {
                    if (grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialAccountNo"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Worker.....");
                        break;
                    }
                    else if (grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Article.....");
                        break;
                    }
                    else if (grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialAmount"].Value == null || Validation.GetSafeDecimal(grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Packing Grid Validation
            else if (GridNumber == 9)
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
            List<ProductionProcessesHeadEL> list = manager.GetCustomerPOSByStatusAndType(1);
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
                List<OrdersEL> list = OrderManager.GetOrderDetailByCustomerPo(Operations.IdCompany, cbxCustomerPOS.Text, 1);
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
            List<TanneryProcessesHeadEL> list = Manager.GetVoucherInfoByCustomerPo(CustomerPo, 1);
            if (list.Count > 0)
            {
                IdVoucher = list[0].IdVoucher;
                VEditBox.Text = list[0].VoucherNo.ToString();
            }
            else
            {
                IdVoucher = Guid.Empty;
                ClearControls();
            }
        }
        private void ClearControls()
        {
            #region Clearing Variables
            IdVoucher = Guid.Empty;
            IdCutting = Guid.Empty;
            IdStitching = Guid.Empty;
            IdPrinting = Guid.Empty;
            IdOverLock = Guid.Empty;
            IdMagzi = Guid.Empty;
            IdInspection = Guid.Empty;
            IdPacking = Guid.Empty;
            #endregion
            #region Clearing Grids

            grdCutting.Rows.Clear();
            grdCuttingMaterialUsed.Rows.Clear();
            grdCuttingWastage.Rows.Clear();

            grdTalliCutting.Rows.Clear();
            grdTalliCuttingMaterialUsed.Rows.Clear();
            grdTalliCuttingWastage.Rows.Clear();

            grdCuffPrinting.Rows.Clear();
            grdCuffPrintingMaterial.Rows.Clear();
            grdCuffPrintingWastage.Rows.Clear();

            grdOverLock.Rows.Clear();
            grdOverlockMaterials.Rows.Clear();

            grdMagzi.Rows.Clear();
            grdMagziMaterial.Rows.Clear();

            grdStitching.Rows.Clear();
            grdStitchingMaterials.Rows.Clear();


            grdInspection.Rows.Clear();

            grdPacking.Rows.Clear();
            grdPackingMaterials.Rows.Clear();

            grdMiscCost.Rows.Clear();

            #endregion
        }
        private int GetItemType(Guid IdItem)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemById(IdItem);
            return list[0].ItemType;
        }
        #endregion
        #region Gloves Stock Quantitative and Qualitative Related Methods
        private decimal GetGlovesProductionClosingStockByCustomerPO(Guid IdItem, int IdDepartment, string ProcessName)
        {
            var Manager = new ProductionProcessDetailBLL();
            return Manager.GetGlovesProductionClosingStockByCustomerPO(IdItem, IdDepartment, ProcessName, cbxCustomerPOS.Text);
        }
        private decimal GetGlovesRepairAndPackingProductionClosingStockByCustomerPO(Guid IdItem, int IdDepartment, string ProcessName)
        {
            var Manager = new ProductionProcessDetailBLL();
            return Manager.GetGlovesRepairProductionClosingStockByCustomerPO(IdItem, IdDepartment, ProcessName, cbxCustomerPOS.Text);
        }
        private decimal GetGlovesAvgCostingByCustomerPO(Guid IdItem, int IdDepartment, string ProcessName, string CaseType)
        {
            var Manager = new ProductionProcessDetailBLL();
            return Manager.GetGlovesAvgCostingByCustomerPO(IdItem, IdDepartment, ProcessName, cbxCustomerPOS.Text, CaseType);
        }
        #endregion
        #region Buttons Events
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
                oelProductionHead.ProductionType = 1;
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
                oelCurrentStock.ProductionType = 1;
                if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Gloves Cuff Cutting")
                {
                    oelCurrentStock.IdProductionDepartment = 1;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Gloves Talli Cutting")
                {
                    oelCurrentStock.IdProductionDepartment = 2;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Gloves Cuff Printing")
                {
                    oelCurrentStock.IdProductionDepartment = 3;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Gloves Cuff OverLock")
                {
                    oelCurrentStock.IdProductionDepartment = 4;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Gloves Cuff Magzi")
                {
                    oelCurrentStock.IdProductionDepartment = 5;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Gloves Cuff Tape")
                {
                    oelCurrentStock.IdProductionDepartment = 6;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Gloves Cuff Stitching")
                {
                    oelCurrentStock.IdProductionDepartment = 7;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Gloves Cuff Repair")
                {
                    oelCurrentStock.IdProductionDepartment = 8;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Gloves Checking / Inspection")
                {
                    oelCurrentStock.IdProductionDepartment = 9;
                }
                else if (Validation.GetSafeString(grdOpeningStock.Rows[i].Cells["colOrderOpeningStockProcessName"].Value) == "Gloves Packing")
                {
                    oelCurrentStock.IdProductionDepartment = 10;
                }
                oelCurrentStock.Seq = i + 1;
                oelCurrentStock.BatchNo = "N/A";
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
                oelProductionHead.ProductionType = 1;
            }
            #endregion
            #region Creating Material Section
            if (ValidateMaterialRecords(1))
            {
                if (grdCuttingMaterialUsed.Rows.Count > 0)
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
                        oelMaterialDetail.AccountNo = Validation.GetSafeString(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMateriaAccountNo"].Value);
                        oelMaterialDetail.UsedQuantity = Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUsedQty"].Value);
                        oelMaterialDetail.ProcessType = 1;
                        oelMaterialDetail.IdHeadDepartment = 1;
                        oelMaterialDetail.IdProductionDepartment = 0;
                        oelMaterialDetail.ProductionProcessName = "Gloves Cuff Cutting Material Usage";
                        oelMaterialDetail.VDate = Convert.ToDateTime(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialDate"].Value);
                        oelMaterialDetail.Rate = Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialRate"].Value);
                        oelMaterialDetail.Amount = Validation.GetSafeDecimal(grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialAmount"].Value);

                        oelCuttingMaterialCollection.Add(oelMaterialDetail);
                    }
                }
            }
            else
            {
                return;
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
                        oelCuttingWastage.IdMaterialUsed = Guid.NewGuid();
                        oelCuttingWastage.IsNew = true;
                        grdCuttingWastage.Rows[i].Cells["colCuttingIdWastage"].Value = oelCuttingWastage.IdVoucherDetail;
                    }
                    else
                    {
                        oelCuttingWastage.IdMaterialUsed = Validation.GetSafeGuid(grdCuttingWastage.Rows[i].Cells["colCuttingIdWastage"].Value);
                        oelCuttingWastage.IsNew = false;
                    }
                    oelCuttingWastage.IdVoucher = IdVoucher;
                    oelCuttingWastage.IdItem = Validation.GetSafeGuid(grdCuttingWastage.Rows[i].Cells["colCuttingWastageIdItem"].Value);
                    oelCuttingWastage.Qty = Validation.GetSafeLong(grdCuttingWastage.Rows[i].Cells["colCuttingWastageQuantity"].Value);
                    oelCuttingWastage.ProcessType = 1;
                    oelCuttingWastage.ProductionProcessName = "Cuff Cutting Wastage";
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
                    FillCuttingMaterialGrid(IdVoucher);
            }
            else
            {
                MessageBox.Show("Some Exception Occured In System...");
            }
            #endregion
        }
        private void btnTalliCuttingSave_Click(object sender, EventArgs e)
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
                oelProductionHead.ProductionType = 1;
            }
            #endregion
            #region Creating Material Section
            if (ValidateMaterialRecords(2))
            {
                if (grdTalliCuttingMaterialUsed.Rows.Count > 0)
                {
                    for (int i = 0; i < grdTalliCuttingMaterialUsed.Rows.Count - 1; i++)
                    {
                        ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                        if (grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingIdMaterial"].Value == null || Validation.GetSafeGuid(grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingIdMaterial"].Value) == Guid.Empty)
                        {
                            oelMaterialDetail.IdMaterialUsed = Guid.NewGuid();
                            oelMaterialDetail.IsNew = true;
                            grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                        }
                        else
                        {
                            oelMaterialDetail.IdMaterialUsed = Validation.GetSafeGuid(grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingIdMaterial"].Value);
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
                        oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialIdItem"].Value);
                        oelMaterialDetail.AccountNo = Validation.GetSafeString(grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialAccountNo"].Value);
                        oelMaterialDetail.UsedQuantity = Validation.GetSafeDecimal(grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialUsedQty"].Value);
                        oelMaterialDetail.ProcessType = 1;
                        oelMaterialDetail.IdHeadDepartment = 2;
                        oelMaterialDetail.IdProductionDepartment = 0;
                        oelMaterialDetail.ProductionProcessName = "Gloves Talli Cutting Material Usage";
                        oelMaterialDetail.VDate = Convert.ToDateTime(grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialDate"].Value);
                        oelMaterialDetail.Rate = Validation.GetSafeDecimal(grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialRate"].Value);
                        oelMaterialDetail.Amount = Validation.GetSafeDecimal(grdTalliCuttingMaterialUsed.Rows[i].Cells["colTalliCuttingMaterialAmount"].Value);

                        oelCuttingMaterialCollection.Add(oelMaterialDetail);
                    }
                }
            }
            else
            {
                return;
            }
            #endregion
            #region Creating Wastage Section
            if (grdTalliCuttingWastage.Rows.Count > 0)
            {
                for (int i = 0; i < grdTalliCuttingWastage.Rows.Count - 1; i++)
                {
                    ProductionMaterialUsedEL oelCuttingWastage = new ProductionMaterialUsedEL();
                    if (grdTalliCuttingWastage.Rows[i].Cells["colTalliCuttingIdWastage"].Value == null || Validation.GetSafeGuid(grdTalliCuttingWastage.Rows[i].Cells["colTalliCuttingIdWastage"].Value) == Guid.Empty)
                    {
                        oelCuttingWastage.IdMaterialUsed = Guid.NewGuid();
                        oelCuttingWastage.IsNew = true;
                        grdTalliCuttingWastage.Rows[i].Cells["colTalliCuttingIdWastage"].Value = oelCuttingWastage.IdVoucherDetail;
                    }
                    else
                    {
                        oelCuttingWastage.IdMaterialUsed = Validation.GetSafeGuid(grdTalliCuttingWastage.Rows[i].Cells["colTalliCuttingIdWastage"].Value);
                        oelCuttingWastage.IsNew = false;
                    }
                    oelCuttingWastage.IdVoucher = IdVoucher;
                    oelCuttingWastage.IdItem = Validation.GetSafeGuid(grdTalliCuttingWastage.Rows[i].Cells["colTalliCuttingWastageIdItem"].Value);
                    oelCuttingWastage.Qty = Validation.GetSafeLong(grdTalliCuttingWastage.Rows[i].Cells["colTalliCuttingWastageQuantity"].Value);
                    oelCuttingWastage.ProcessType = 1;
                    oelCuttingWastage.ProductionProcessName = "Cuff Talli Cutting Wastage";
                    oelCuttingWastage.VDate = Convert.ToDateTime(grdTalliCuttingWastage.Rows[i].Cells["colTalliCuttingWastageDate"].Value);
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
                    FillTalliCuttingMaterialGrid(oelProductionHead.IdVoucher);
                    IdVoucher = oelProductionHead.IdVoucher;
                }
                else
                    FillTalliCuttingMaterialGrid(IdVoucher);
            }
            else
            {
                MessageBox.Show("Some Exception Occured In System...");
            }
            #endregion
        }
        private void btnCuffPrintingSave_Click(object sender, EventArgs e)
        {
            #region Variables
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelPrintingMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelPrintingWastageCollection = new List<ProductionMaterialUsedEL>();
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
                oelProductionHead.ProductionType = 1;
            }
            #endregion
            #region Creating Material Section
            if (grdCuffPrintingMaterial.Rows.Count > 0)
            {
                if (ValidateMaterialRecords(3))
                {
                    for (int i = 0; i < grdCuffPrintingMaterial.Rows.Count - 1; i++)
                    {
                        ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                        if (grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingIdMaterial"].Value == null || Validation.GetSafeGuid(grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingIdMaterial"].Value) == Guid.Empty)
                        {
                            oelMaterialDetail.IdMaterialUsed = Guid.NewGuid();
                            oelMaterialDetail.IsNew = true;
                            grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                        }
                        else
                        {
                            oelMaterialDetail.IdMaterialUsed = Validation.GetSafeGuid(grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingIdMaterial"].Value);
                            oelMaterialDetail.IsNew = false;
                        }
                        oelMaterialDetail.IdVoucher = IdVoucher;
                        oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialIdItem"].Value);
                        oelMaterialDetail.AccountNo = Validation.GetSafeString(grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialAccountNo"].Value);
                        oelMaterialDetail.UsedQuantity = Validation.GetSafeDecimal(grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialUsedQuantity"].Value);
                        oelMaterialDetail.ProcessType = 1;
                        oelMaterialDetail.IdHeadDepartment = 3;
                        if (grdCuffPrintingMaterial.Rows[i].Cells["colPrintingMaterialDepartment"].Value != null)
                        {
                            if (Validation.GetSafeString(grdCuffPrintingMaterial.Rows[i].Cells["colPrintingMaterialDepartment"].Value) == "Cuff General Stock")
                            {
                                oelMaterialDetail.IdProductionDepartment = 0;
                            }
                            else if (Validation.GetSafeString(grdCuffPrintingMaterial.Rows[i].Cells["colPrintingMaterialDepartment"].Value) == "Cuff Cutting")
                            {
                                oelMaterialDetail.IdProductionDepartment = 1;
                            }
                            else if (Validation.GetSafeString(grdCuffPrintingMaterial.Rows[i].Cells["colPrintingMaterialDepartment"].Value) == "Cuff OverLock")
                            {
                                oelMaterialDetail.IdProductionDepartment = 3;
                            }
                            else if (Validation.GetSafeString(grdCuffPrintingMaterial.Rows[i].Cells["colPrintingMaterialDepartment"].Value) == "Cuff Magzi")
                            {
                                oelMaterialDetail.IdProductionDepartment = 4;
                            }
                            else if (Validation.GetSafeString(grdCuffPrintingMaterial.Rows[i].Cells["colPrintingMaterialDepartment"].Value) == "Cuff Tape")
                            {
                                oelMaterialDetail.IdProductionDepartment = 5;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Department...");
                        }
                        oelMaterialDetail.ProductionProcessName = "Gloves Cuff Printing Material Usage";
                        oelMaterialDetail.VDate = Convert.ToDateTime(grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialDate"].Value);
                        oelMaterialDetail.Rate = Validation.GetSafeDecimal(grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialRate"].Value);
                        oelMaterialDetail.Amount = Validation.GetSafeDecimal(grdCuffPrintingMaterial.Rows[i].Cells["colCuffPrintingMaterialAmount"].Value);

                        oelPrintingMaterialCollection.Add(oelMaterialDetail);
                    }
                }
                else
                {
                    return;
                }
            }
            #endregion
            #region Creating Wastage Section
            if (grdCuffPrintingWastage.Rows.Count > 0)
            {
                for (int i = 0; i < grdCuttingWastage.Rows.Count - 1; i++)
                {
                    ProductionMaterialUsedEL oelPrintingWastage = new ProductionMaterialUsedEL();
                    if (grdCuffPrintingWastage.Rows[i].Cells["colCuffPrintingIdWastage"].Value == null || Validation.GetSafeGuid(grdCuffPrintingWastage.Rows[i].Cells["colCuffPrintingIdWastage"].Value) == Guid.Empty)
                    {
                        oelPrintingWastage.IdVoucherDetail = Guid.NewGuid();
                        oelPrintingWastage.IsNew = true;
                        grdCuttingWastage.Rows[i].Cells["colCuffPrintingIdWastage"].Value = oelPrintingWastage.IdVoucherDetail;
                    }
                    else
                    {
                        oelPrintingWastage.IdVoucherDetail = Validation.GetSafeGuid(grdCuffPrintingWastage.Rows[i].Cells["colCuffPrintingIdWastage"].Value);
                        oelPrintingWastage.IsNew = false;
                    }
                    oelPrintingWastage.IdVoucher = IdVoucher;
                    oelPrintingWastage.IdItem = Validation.GetSafeGuid(grdCuffPrintingWastage.Rows[i].Cells["colCuffPrintingWastageIdItem"].Value);
                    oelPrintingWastage.Qty = Validation.GetSafeLong(grdCuffPrintingWastage.Rows[i].Cells["colCuffPrintingWastageQuantity"].Value);
                    oelPrintingWastage.ProcessType = 1;
                    oelPrintingWastage.ProductionProcessName = "Cuff Printing Wastage";
                    oelPrintingWastage.VDate = Convert.ToDateTime(grdCuffPrintingWastage.Rows[i].Cells["colCuttingWastageDate"].Value);
                    oelPrintingWastageCollection.Add(oelPrintingWastage);
                }
            }
            #endregion
            #region Saving Section
            if (Manager.CreateMaterialsUsed(oelProductionHead, oelPrintingMaterialCollection, oelPrintingWastageCollection))
            {
                MessageBox.Show("Entry Saved / Updated Successfully...");
                if (oelProductionHead.IsNew)
                {
                    FillPrintingMaterialGrid(oelProductionHead.IdVoucher);
                    IdVoucher = oelProductionHead.IdVoucher;
                }
                else
                    FillPrintingMaterialGrid(IdVoucher);
            }
            else
            {
                MessageBox.Show("Some Exception Occured In System...");
            }
            #endregion
        }
        private void btnOverLockSave_Click(object sender, EventArgs e)
        {
            #region Variables
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelOverLockMaterialCollection = new List<ProductionMaterialUsedEL>();
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
                oelProductionHead.ProductionType = 1;
            }
            #endregion
            #region Creating Material Section           
            if (grdOverlockMaterials.Rows.Count > 0)
            {
                if (ValidateMaterialRecords(4))
                {
                    for (int i = 0; i < grdOverlockMaterials.Rows.Count - 1; i++)
                    {
                        ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                        if (grdOverlockMaterials.Rows[i].Cells["colOverLockIdMaterial"].Value == null || Validation.GetSafeGuid(grdOverlockMaterials.Rows[i].Cells["colOverLockIdMaterial"].Value) == Guid.Empty)
                        {
                            oelMaterialDetail.IdMaterialUsed = Guid.NewGuid();
                            oelMaterialDetail.IsNew = true;
                            grdOverlockMaterials.Rows[i].Cells["colOverLockIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                        }
                        else
                        {
                            oelMaterialDetail.IdMaterialUsed = Validation.GetSafeGuid(grdOverlockMaterials.Rows[i].Cells["colOverLockIdMaterial"].Value);
                            oelMaterialDetail.IsNew = false;
                        }
                        oelMaterialDetail.IdVoucher = IdVoucher;
                        oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialIdItem"].Value);
                        oelMaterialDetail.AccountNo = Validation.GetSafeString(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialAccountNo"].Value);
                        oelMaterialDetail.UsedQuantity = Validation.GetSafeLong(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialQuantity"].Value);
                        oelMaterialDetail.ProcessType = 1;
                        oelMaterialDetail.IdHeadDepartment = 4;
                        if (grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialDepartment"].Value != null)
                        {
                            if (Validation.GetSafeString(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialDepartment"].Value) == "Cuff General Stock")
                            {
                                oelMaterialDetail.IdProductionDepartment = 0;
                            }
                            else if (Validation.GetSafeString(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialDepartment"].Value) == "Cuff Cutting")
                            {
                                oelMaterialDetail.IdProductionDepartment = 1;
                            }
                            else if (Validation.GetSafeString(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialDepartment"].Value) == "Cuff Printing")
                            {
                                oelMaterialDetail.IdProductionDepartment = 2;
                            }
                            else if (Validation.GetSafeString(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialDepartment"].Value) == "Cuff Magzi")
                            {
                                oelMaterialDetail.IdProductionDepartment = 4;
                            }
                            else if (Validation.GetSafeString(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialDepartment"].Value) == "Cuff Tape")
                            {
                                oelMaterialDetail.IdProductionDepartment = 5;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Department...");
                        }
                        oelMaterialDetail.ProductionProcessName = "Gloves OverLock Material Usage";
                        oelMaterialDetail.VDate = Convert.ToDateTime(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialDate"].Value);
                        oelMaterialDetail.Rate = Validation.GetSafeDecimal(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialRate"].Value);
                        oelMaterialDetail.Amount = Validation.GetSafeDecimal(grdOverlockMaterials.Rows[i].Cells["colOverLockMaterialAmount"].Value);

                        oelOverLockMaterialCollection.Add(oelMaterialDetail);
                    }
                }
                else
                {
                    return;
                }
            }
            #endregion
            #region Saving Section
            if (Manager.CreateMaterialsUsed(oelProductionHead, oelOverLockMaterialCollection, oelCuttingWastageCollection))
            {
                MessageBox.Show("Entry Saved / Updated Successfully...");
                if (oelProductionHead.IsNew)
                {
                    FillOverLockMaterialGrid(oelProductionHead.IdVoucher);
                    IdVoucher = oelProductionHead.IdVoucher;
                }
                else
                    FillOverLockMaterialGrid(IdVoucher);
            }
            else
            {
                MessageBox.Show("Some Exception Occured In System...");
            }
            #endregion
        }
        private void btnMagziSave_Click(object sender, EventArgs e)
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
                oelProductionHead.ProductionType = 1;
            }
            #endregion
            #region Creating Material Section
            if (grdMagziMaterial.Rows.Count > 0)
            {
                if (ValidateMaterialRecords(5))
                {
                    for (int i = 0; i < grdMagziMaterial.Rows.Count - 1; i++)
                    {
                        ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                        if (grdMagziMaterial.Rows[i].Cells["colMagziIdMaterial"].Value == null || Validation.GetSafeGuid(grdMagziMaterial.Rows[i].Cells["colMagziIdMaterial"].Value) == Guid.Empty)
                        {
                            oelMaterialDetail.IdMaterialUsed = Guid.NewGuid();
                            oelMaterialDetail.IsNew = true;
                            grdMagziMaterial.Rows[i].Cells["colMagziIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                        }
                        else
                        {
                            oelMaterialDetail.IdMaterialUsed = Validation.GetSafeGuid(grdMagziMaterial.Rows[i].Cells["colMagziIdMaterial"].Value);
                            oelMaterialDetail.IsNew = false;
                        }
                        oelMaterialDetail.IdVoucher = IdVoucher;
                        oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdMagziMaterial.Rows[i].Cells["colMagziMaterialIdItem"].Value);
                        oelMaterialDetail.AccountNo = Validation.GetSafeString(grdMagziMaterial.Rows[i].Cells["colMagziMaterialAccountNo"].Value);
                        oelMaterialDetail.UsedQuantity = Validation.GetSafeLong(grdMagziMaterial.Rows[i].Cells["colMagziMaterialUsedQuantity"].Value);
                        oelMaterialDetail.ProcessType = 1;
                        oelMaterialDetail.IdHeadDepartment = 5;
                        if (grdMagziMaterial.Rows[i].Cells["colMagziMaterialDepartment"].Value != null)
                        {
                            if (Validation.GetSafeString(grdMagziMaterial.Rows[i].Cells["colMagziMaterialDepartment"].Value) == "Cuff General Stock")
                            {
                                oelMaterialDetail.IdProductionDepartment = 0;
                            }
                            else if (Validation.GetSafeString(grdMagziMaterial.Rows[i].Cells["colMagziMaterialDepartment"].Value) == "Cuff Cutting")
                            {
                                oelMaterialDetail.IdProductionDepartment = 1;
                            }
                            else if (Validation.GetSafeString(grdMagziMaterial.Rows[i].Cells["colMagziMaterialDepartment"].Value) == "Cuff Printing")
                            {
                                oelMaterialDetail.IdProductionDepartment = 2;
                            }
                            else if (Validation.GetSafeString(grdMagziMaterial.Rows[i].Cells["colMagziMaterialDepartment"].Value) == "Cuff OverLock")
                            {
                                oelMaterialDetail.IdProductionDepartment = 3;
                            }
                            else if (Validation.GetSafeString(grdMagziMaterial.Rows[i].Cells["colMagziMaterialDepartment"].Value) == "Cuff Tap")
                            {
                                oelMaterialDetail.IdProductionDepartment = 5;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Department...");
                        }
                        oelMaterialDetail.ProductionProcessName = "Gloves Magzi Material Usage";
                        oelMaterialDetail.VDate = Convert.ToDateTime(grdMagziMaterial.Rows[i].Cells["colMagziMaterialDate"].Value);
                        oelMaterialDetail.Rate = Validation.GetSafeDecimal(grdMagziMaterial.Rows[i].Cells["colMagziMaterialRate"].Value);
                        oelMaterialDetail.Amount = Validation.GetSafeDecimal(grdMagziMaterial.Rows[i].Cells["colMagziMaterialAmount"].Value);

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
                    FillMagziMaterialGrid(oelProductionHead.IdVoucher);
                    IdVoucher = oelProductionHead.IdVoucher;
                }
                else
                    FillMagziMaterialGrid(IdVoucher);
            }
            else
            {
                MessageBox.Show("Some Exception Occured In System...");
            }
            #endregion
        }
        private void BtnTapSave_Click(object sender, EventArgs e)
        {
            #region Variables
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelTapMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelTapWastageCollection = new List<ProductionMaterialUsedEL>();
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
                oelProductionHead.ProductionType = 1;
            }
            #endregion
            #region Creating Material Section
            if (grdTapMaterial.Rows.Count > 0)
            {
                if (ValidateMaterialRecords(6))
                {
                    for (int i = 0; i < grdTapMaterial.Rows.Count - 1; i++)
                    {
                        ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                        if (grdTapMaterial.Rows[i].Cells["colTapIdMaterial"].Value == null || Validation.GetSafeGuid(grdTapMaterial.Rows[i].Cells["colTapIdMaterial"].Value) == Guid.Empty)
                        {
                            oelMaterialDetail.IdMaterialUsed = Guid.NewGuid();
                            oelMaterialDetail.IsNew = true;
                            grdTapMaterial.Rows[i].Cells["colTapIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                        }
                        else
                        {
                            oelMaterialDetail.IdMaterialUsed = Validation.GetSafeGuid(grdTapMaterial.Rows[i].Cells["colTapIdMaterial"].Value);
                            oelMaterialDetail.IsNew = false;
                        }
                        oelMaterialDetail.IdVoucher = IdVoucher;
                        oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdTapMaterial.Rows[i].Cells["colTapMaterialIdItem"].Value);
                        oelMaterialDetail.AccountNo = Validation.GetSafeString(grdTapMaterial.Rows[i].Cells["colTapMaterialAccountNo"].Value);
                        oelMaterialDetail.UsedQuantity = Validation.GetSafeLong(grdTapMaterial.Rows[i].Cells["colTapMaterialUsedQuantity"].Value);
                        oelMaterialDetail.ProcessType = 1;
                        oelMaterialDetail.IdHeadDepartment = 6;
                        if (grdTapMaterial.Rows[i].Cells["colTapMaterialDepartment"].Value != null)
                        {
                            if (Validation.GetSafeString(grdTapMaterial.Rows[i].Cells["colTapMaterialDepartment"].Value) == "Cuff General Stock")
                            {
                                oelMaterialDetail.IdProductionDepartment = 0;
                            }
                            else if (Validation.GetSafeString(grdTapMaterial.Rows[i].Cells["colTapMaterialDepartment"].Value) == "Cuff Cutting")
                            {
                                oelMaterialDetail.IdProductionDepartment = 1;
                            }
                            else if (Validation.GetSafeString(grdTapMaterial.Rows[i].Cells["colTapMaterialDepartment"].Value) == "Cuff Printing")
                            {
                                oelMaterialDetail.IdProductionDepartment = 2;
                            }
                            else if (Validation.GetSafeString(grdTapMaterial.Rows[i].Cells["colTapMaterialDepartment"].Value) == "Cuff OverLock")
                            {
                                oelMaterialDetail.IdProductionDepartment = 3;
                            }
                            else if (Validation.GetSafeString(grdTapMaterial.Rows[i].Cells["colTapMaterialDepartment"].Value) == "Cuff Magzi")
                            {
                                oelMaterialDetail.IdProductionDepartment = 4;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Department...");
                        }
                        oelMaterialDetail.ProductionProcessName = "Gloves Tap Material Usage";
                        oelMaterialDetail.VDate = Convert.ToDateTime(grdTapMaterial.Rows[i].Cells["colTapMaterialDate"].Value);
                        oelMaterialDetail.Rate = Validation.GetSafeDecimal(grdTapMaterial.Rows[i].Cells["colTapMaterialRate"].Value);
                        oelMaterialDetail.Amount = Validation.GetSafeDecimal(grdTapMaterial.Rows[i].Cells["colTapMaterialAmount"].Value);

                        oelTapMaterialCollection.Add(oelMaterialDetail);
                    }
                }
                else
                {
                    return;
                }
            }
            #endregion
            #region Saving Section
            if (Manager.CreateMaterialsUsed(oelProductionHead, oelTapMaterialCollection, oelTapWastageCollection))
            {
                MessageBox.Show("Entry Saved / Updated Successfully...");
                if (oelProductionHead.IsNew)
                {
                    FillTapeMaterialGrid(oelProductionHead.IdVoucher);
                    IdVoucher = oelProductionHead.IdVoucher;
                }
                else
                    FillTapeMaterialGridByCustomerPO();
            }
            else
            {
                MessageBox.Show("Some Exception Occured In System...");
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
                oelProductionHead.ProductionType = 1;
            }
            #endregion
            #region Creating Material Section
            if (grdStitchingMaterials.Rows.Count > 0)
            {
                if (ValidateMaterialRecords(7))
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
                        oelMaterialDetail.IdVoucher = IdVoucher;
                        oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialIdItem"].Value);
                        oelMaterialDetail.IdArticle = Validation.GetSafeGuid(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialIdArticle"].Value);
                        oelMaterialDetail.AccountNo = Validation.GetSafeString(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialAccountNo"].Value);
                        oelMaterialDetail.UsedQuantity = Validation.GetSafeLong(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialQuantity"].Value);
                        if (grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value != null)
                        {
                            if (Validation.GetSafeString(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value) == "Cuff General Stock")
                            {
                                oelMaterialDetail.IdProductionDepartment = 0;
                            }
                            else if (Validation.GetSafeString(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value) == "Cuff Cutting")
                            {
                                oelMaterialDetail.IdProductionDepartment = 1;
                            }
                            else if (Validation.GetSafeString(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value) == "Cuff Printing")
                            {
                                oelMaterialDetail.IdProductionDepartment = 2;
                            }
                            else if (Validation.GetSafeString(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value) == "Cuff OverLock")
                            {
                                oelMaterialDetail.IdProductionDepartment = 3;
                            }
                            else if (Validation.GetSafeString(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value) == "Cuff Magzi")
                            {
                                oelMaterialDetail.IdProductionDepartment = 4;
                            }
                            else if (Validation.GetSafeString(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value) == "Cuff Tape")
                            {
                                oelMaterialDetail.IdProductionDepartment = 5;
                            }
                            else if (Validation.GetSafeString(grdStitchingMaterials.Rows[i].Cells["colStitchingMaterialDepartment"].Value) == "Cuff Talli")
                            {
                                oelMaterialDetail.IdProductionDepartment = 15; // Just For Talli Cutting....
                            }
                            else
                            {
                                oelMaterialDetail.IdProductionDepartment = -1;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Department...");
                        }
                        oelMaterialDetail.ProcessType = 1;
                        oelMaterialDetail.IdHeadDepartment = 7;
                        oelMaterialDetail.ProductionProcessName = "Gloves Stitching Material Usage";
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
                if (oelProductionHead.IsNew)
                {
                    FillStitchingMaterialGrid(oelProductionHead.IdVoucher);
                    IdVoucher = oelProductionHead.IdVoucher;
                }
                else
                    FillStitchingMaterialGridByCustomerPO();
                MessageBox.Show("Entry Saved / Updated Successfully...");
            }
            else
            {
                MessageBox.Show("Some Exception Occured In System...");
            }
            #endregion
        }
        private void BtnGlovesRepairSave_Click(object sender, EventArgs e)
        {
            #region Variables
            var Manager = new ProductionMaterialsBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionMaterialUsedEL> oelGlovesMaterialCollection = new List<ProductionMaterialUsedEL>();
            List<ProductionMaterialUsedEL> oelTapWastageCollection = new List<ProductionMaterialUsedEL>();
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
                oelProductionHead.ProductionType = 1;
            }
            #endregion
            #region Creating Material Section
            if (grdGlovesRepairMaterial.Rows.Count > 0)
            {
                if (ValidateMaterialRecords(8))
                {
                    for (int i = 0; i < grdGlovesRepairMaterial.Rows.Count - 1; i++)
                    {
                        ProductionMaterialUsedEL oelMaterialDetail = new ProductionMaterialUsedEL();
                        if (grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairIdMaterial"].Value == null || Validation.GetSafeGuid(grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairIdMaterial"].Value) == Guid.Empty)
                        {
                            oelMaterialDetail.IdMaterialUsed = Guid.NewGuid();
                            oelMaterialDetail.IsNew = true;
                            grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairIdMaterial"].Value = oelMaterialDetail.IdVoucherDetail;
                        }
                        else
                        {
                            oelMaterialDetail.IdMaterialUsed = Validation.GetSafeGuid(grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairIdMaterial"].Value);
                            oelMaterialDetail.IsNew = false;
                        }
                        oelMaterialDetail.IdVoucher = IdVoucher;
                        oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialIdItem"].Value);
                        oelMaterialDetail.AccountNo = Validation.GetSafeString(grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialAccountNo"].Value);
                        oelMaterialDetail.UsedQuantity = Validation.GetSafeLong(grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialUsedQuantity"].Value);
                        oelMaterialDetail.ProcessType = 1;
                        oelMaterialDetail.IdHeadDepartment = 8;
                        //if (grdMagziMaterial.Rows[i].Cells["colGlovesRepairMaterialDepartment"].Value != null)
                        //{
                        //    if (Validation.GetSafeString(grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialDepartment"].Value) == "Cuff General Stock")
                        //    {
                        //        oelMaterialDetail.IdProductionDepartment = 0;
                        //    }
                        //    else if (Validation.GetSafeString(grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialDepartment"].Value) == "Cuff Cutting")
                        //    {
                        //        oelMaterialDetail.IdProductionDepartment = 1;
                        //    }
                        //    else if (Validation.GetSafeString(grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialDepartment"].Value) == "Cuff Printing")
                        //    {
                        //        oelMaterialDetail.IdProductionDepartment = 2;
                        //    }
                        //    else if (Validation.GetSafeString(grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialDepartment"].Value) == "Cuff OverLock")
                        //    {
                        //        oelMaterialDetail.IdProductionDepartment = 3;
                        //    }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Please Select Department...");
                        //}
                        oelMaterialDetail.IdProductionDepartment = -1;
                        oelMaterialDetail.ProductionProcessName = "Gloves Repair Material Usage";
                        oelMaterialDetail.VDate = Convert.ToDateTime(grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialDate"].Value);
                        oelMaterialDetail.Rate = Validation.GetSafeDecimal(grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialRate"].Value);
                        oelMaterialDetail.Amount = Validation.GetSafeDecimal(grdGlovesRepairMaterial.Rows[i].Cells["colGlovesRepairMaterialAmount"].Value);

                        oelGlovesMaterialCollection.Add(oelMaterialDetail);
                    }
                }
                else
                {
                    return;
                }
            }
            #endregion
            #region Saving Section
            if (Manager.CreateMaterialsUsed(oelProductionHead, oelGlovesMaterialCollection, oelTapWastageCollection))
            {
                MessageBox.Show("Entry Saved / Updated Successfully...");
                if (oelProductionHead.IsNew)
                {
                    FillGlovesRepairMaterialGrid(oelProductionHead.IdVoucher);
                    IdVoucher = oelProductionHead.IdVoucher;
                }
                else
                    FillGlovesRepairMaterialGridByCustomerPO();
            }
            else
            {
                MessageBox.Show("Some Exception Occured In System...");
            }
            #endregion
        }
        private void btnPackingSave_Click(object sender, EventArgs e)
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
                oelProductionHead.ProductionType = 1;
            }
            #endregion
            #region Creating Material Section
            if (grdPackingMaterials.Rows.Count > 0)
            {
                if (ValidateMaterialRecords(9))
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
                            oelMaterialDetail.IdMaterialUsed = Validation.GetSafeGuid(grdPackingMaterials.Rows[i].Cells["colPackingIdMaterial"].Value);
                            oelMaterialDetail.IsNew = false;
                        }
                        oelMaterialDetail.IdVoucher = IdVoucher;
                        oelMaterialDetail.IdItem = Validation.GetSafeGuid(grdPackingMaterials.Rows[i].Cells["colPackingMaterialIdItem"].Value);
                        oelMaterialDetail.AccountNo = Validation.GetSafeString(grdPackingMaterials.Rows[i].Cells["colPackingMaterialAccountNo"].Value);
                        oelMaterialDetail.UsedQuantity = Validation.GetSafeLong(grdPackingMaterials.Rows[i].Cells["colPackingMaterialQuantity"].Value);
                        oelMaterialDetail.ProcessType = 1;
                        oelMaterialDetail.IdHeadDepartment = 9;
                        oelMaterialDetail.ProductionProcessName = "Gloves Packing Material Usage";
                        oelMaterialDetail.VDate = Convert.ToDateTime(grdPackingMaterials.Rows[i].Cells["colPackingMaterialDate"].Value);
                        oelMaterialDetail.Rate = Validation.GetSafeDecimal(grdPackingMaterials.Rows[i].Cells["colPackingMaterialRates"].Value);
                        oelMaterialDetail.Amount = Validation.GetSafeDecimal(grdPackingMaterials.Rows[i].Cells["colPackingMaterialAmount"].Value);

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
                if (oelProductionHead.IsNew)
                {
                    FillGlovesPackingMaterialGrid(oelProductionHead.IdVoucher);
                    IdVoucher = oelProductionHead.IdVoucher;
                }
                else
                    FillGlovesPackingMaterialGridByCustomerPO();
                MessageBox.Show("Entry Saved / Updated Successfully...");
            }
            else
            {
                MessageBox.Show("Some Exception Occured In System...");
            }
            #endregion
        }
        private void btnOverHeadsSave_Click(object sender, EventArgs e)
        {
            #region Varibles
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
                oelProductionHead.ProductionType = 1;
            }
            #endregion
            #region Creating Over Heads Section
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
                    oelProductionOverhead.IdVoucher = IdVoucher;
                    oelProductionOverhead.AccountNo = Validation.GetSafeString(grdMiscCost.Rows[i].Cells["colAccountNo"].Value);
                    oelProductionOverhead.Description = Validation.GetSafeString(grdMiscCost.Rows[i].Cells["colCostDescription"].Value);
                    oelProductionOverhead.ProcessType = 1;
                    oelProductionOverhead.OverHeadCost = Validation.GetSafeDecimal(grdMiscCost.Rows[i].Cells["colCost"].Value);
                    oelProductionOverhead.OverHeadDate = Convert.ToDateTime(grdMiscCost.Rows[i].Cells["colCostDate"].Value);

                    oelProductionOverHeadCollection.Add(oelProductionOverhead);
                }
            }
            #endregion
            #region Saving Section
            if (Manager.CreateUpdateProductionOverHeads(oelProductionOverHeadCollection))
            {
                MessageBox.Show("Entry Saved / Updated Successfully....");
            }
            else
            {
                MessageBox.Show("Some Problem Occured....");
            }
            #endregion
        }
        #endregion
        #region Materials Grids Fill Methods
        private void FillCuttingMaterialGrid(Guid IdVoucher)
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Cuff Cutting Material Usage");
            if (listMaterials.Count > 0)
            {
                grdCuttingMaterialUsed.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Cutting");
            }
            else
            {
                grdCuttingMaterialUsed.Rows.Clear();
            }
            //for (int i = 0; i < listMaterials.Count; i++)
            //{
            //    grdCuttingMaterialUsed.Rows.Add();
            //    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingIdMaterial"].Value = listMaterials[i].IdMaterialUsed;
            //    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialIdItem"].Value = listMaterials[i].IdItem;
            //    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialName"].Value = listMaterials[i].ItemName;
            //    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUOM"].Value = listMaterials[i].PackingSize;
            //    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUsedQty"].Value = listMaterials[i].UsedQuantity;
            //    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialRate"].Value = listMaterials[i].Rate;
            //    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialAmount"].Value = listMaterials[i].Amount;

            //}
            
   
        }
        private void FillCuttingMaterialGridByCustomerPO()
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 1, "Gloves Cuff Cutting Material Usage");
            if (listMaterials.Count > 0)
            {
                grdCuttingMaterialUsed.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Cutting");
            }
            else
            {
                grdCuttingMaterialUsed.Rows.Clear();
            }
        }
        private void FillTalliCuttingMaterialGrid(Guid IdVoucher)
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 1, "Gloves Talli Cutting Material Usage");
            if (listMaterials.Count > 0)
            {
                grdTalliCuttingMaterialUsed.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Talli Cutting");
            }
            else
            {
                grdTalliCuttingMaterialUsed.Rows.Clear();
            }
        }
        private void FillTalliCuttingMaterialGridByCustomerPO()
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 1, "Gloves Talli Cutting Material Usage");
            if (listMaterials.Count > 0)
            {
                grdTalliCuttingMaterialUsed.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Talli Cutting");
            }
            else
            {
                grdTalliCuttingMaterialUsed.Rows.Clear();
            }
        }
        private void FillPrintingMaterialGrid(Guid IdVoucher)
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Cuff Printing Material Usage");
            if (listMaterials.Count > 0)
            {
                if (listMaterials.Count > 0)
                {
                    grdCuffPrintingMaterial.Rows.Clear();
                    FillMaterials(listMaterials, "Gloves Cuff Printing");
                }
                else
                {
                    grdCuffPrintingMaterial.Rows.Clear();
                }
                //for (int i = 0; i < listMaterials.Count; i++)
                //{
                //    grdCuttingMaterialUsed.Rows.Add();
                //    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingIdMaterial"].Value = listMaterials[i].IdMaterialUsed;
                //    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialIdItem"].Value = listMaterials[i].IdItem;
                //    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialName"].Value = listMaterials[i].ItemName;
                //    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUOM"].Value = listMaterials[i].PackingSize;
                //    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialUsedQty"].Value = listMaterials[i].UsedQuantity;
                //    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialRate"].Value = listMaterials[i].Rate;
                //    grdCuttingMaterialUsed.Rows[i].Cells["colCuttingMaterialAmount"].Value = listMaterials[i].Amount;

                //}
            }
        }
        private void FillPrintingMaterialGridByCustomerPO()
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 1, "Gloves Cuff Printing Material Usage");
            if (listMaterials.Count > 0)
            {
                grdCuffPrintingMaterial.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Cuff Printing");
            }
            else
            {
                grdCuffPrintingMaterial.Rows.Clear();
            }
        }
        private void FillOverLockMaterialGrid(Guid IdVoucher)
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves OverLock Material Usage");
            if (listMaterials.Count > 0)
            {
                grdOverlockMaterials.Rows.Clear();
                FillMaterials(listMaterials, "Gloves OverLock");
            }
            else
            {
                grdOverlockMaterials.Rows.Clear();
            }
        }
        private void FillOverLockMaterialGridByCustomerPO()
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 1, "Gloves OverLock Material Usage");
            if (listMaterials.Count > 0)
            {
                grdOverlockMaterials.Rows.Clear();
                FillMaterials(listMaterials, "Gloves OverLock");
            }
            else
            {
                grdOverlockMaterials.Rows.Clear();
            }
        }
        private void FillMagziMaterialGrid(Guid IdVoucher)
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Magzi Material Usage");
            if (listMaterials.Count > 0)
            {
                grdMagziMaterial.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Magzi");
            }
            else
            {
                grdMagziMaterial.Rows.Clear();
            }
            
        }
        private void FillMagziMaterialGridByCustomerPO()
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 1, "Gloves Magzi Material Usage");
            if (listMaterials.Count > 0)
            {
                grdMagziMaterial.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Magzi");
            }
            else
            {
                grdMagziMaterial.Rows.Clear();
            }
        }
        private void FillTapeMaterialGrid(Guid IdVoucher)
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Tap Material Usage");
            if (listMaterials.Count > 0)
            {
                grdTapMaterial.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Tape");
            }
            else
            {
                grdTapMaterial.Rows.Clear();
            }
            
        }
        private void FillTapeMaterialGridByCustomerPO()
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 1, "Gloves Tap Material Usage");
            if (listMaterials.Count > 0)
            {
                grdTapMaterial.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Tape");
            }
            else
            {
                grdTapMaterial.Rows.Clear();
            }
        }
        private void FillStitchingMaterialGrid(Guid IdVoucher)
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Stitching Material Usage");
            if (listMaterials.Count > 0)
            {
                grdStitchingMaterials.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Stitching");
            }
            else
            {
                grdStitchingMaterials.Rows.Clear();
            }                            
        }
        private void FillStitchingMaterialGridByCustomerPO()
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 1, "Gloves Stitching Material Usage");
            if (listMaterials.Count > 0)
            {
                grdStitchingMaterials.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Stitching");
            }
            else
            {
                grdStitchingMaterials.Rows.Clear();
            }
        }
        private void FillGlovesRepairMaterialGrid(Guid IdVoucher)
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Repair Material Usage");
            if (listMaterials.Count > 0)
            {
                grdGlovesRepairMaterial.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Repair");
            }
            else
            {
                grdGlovesRepairMaterial.Rows.Clear();
            }
        }
        private void FillGlovesRepairMaterialGridByCustomerPO()
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 1, "Gloves Repair Material Usage");
            if (listMaterials.Count > 0)
            {
                grdGlovesRepairMaterial.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Repair");
            }
            else
            {
                grdGlovesRepairMaterial.Rows.Clear();
            }
        }
        private void FillGlovesPackingMaterialGrid(Guid IdVoucher)
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByVoucher(IdVoucher, 1, "Gloves Packing Material Usage");
            if (listMaterials.Count > 0)
            {
                grdPackingMaterials.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Packing");
            }
            else
            {
                grdPackingMaterials.Rows.Clear();
            }            
        }
        private void FillGlovesPackingMaterialGridByCustomerPO()
        {
            var Manager = new ProductionMaterialsBLL();
            List<ProductionMaterialUsedEL> listMaterials = Manager.GetProductionMaterialByCustomerPO(cbxCustomerPOS.Text, 1, "Gloves Packing Material Usage");
            if (listMaterials.Count > 0)
            {
                grdPackingMaterials.Rows.Clear();
                FillMaterials(listMaterials, "Gloves Packing");
            }
            else
            {
                grdPackingMaterials.Rows.Clear();
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
        }
        private void grdOpeningStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
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
                    EventFiringName = "Gloves Opening Stock";
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