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
    public partial class frmPackingInspection : MetroForm
    {
        #region Variables
        frmFindAccounts frmfindAccount;
        frmStockAccounts frmstockAccounts;
        frmFindBrand frmfindBrand;
        Guid IdVoucher = Guid.Empty;
        string EventFiringName;
        public int ProductionType { get; set; }
        public int WorkType { get; set; }
        string PersonAccountNo = "";
        #endregion
        #region Form Events
        public frmPackingInspection()
        {
            InitializeComponent();
        }
        private void frmPackingInspection_Load(object sender, EventArgs e)
        {           
            FillMaxProductionNo();
            ProductionTab.SelectedIndex = 0;
            ShowHideTabs();
            LabelForm();
                   
        }
        private void ShowHideTabs()
        {
            if (WorkType == 1)
            {
                ProductionTab.TabPages.Remove(mTabPacking);
            }
            else if (WorkType == 2)
            {
                ProductionTab.TabPages.Remove(mTabInspection);
            }    
        }
        private void LabelForm()
        {
            if (ProductionType == 1 && WorkType == 1)
            {
                this.Text = "Gloves Inspection";
            }
            else if (ProductionType == 1 && WorkType == 2)
            {
                this.Text = "Gloves Packing";
            }
            else if (ProductionType == 2 && WorkType == 1)
            {
                this.Text = "Garments Inspection";
            }
            else if (ProductionType == 2 && WorkType == 2)
            {
                this.Text = "Garments Packing";
            }
        }
        private void FillMaxProductionNo()
        {
            var Manager = new ProductionProcessesHeadBLL();
            VEditBox.Text = Validation.GetSafeString(Manager.GetMaxProductionProcessCode(Operations.IdCompany, WorkType, ProductionType));
            VEditBox.Enabled = true;
        }
        #endregion
        #region Inspection Grid Events
        private void grdInspection_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 19)
            {
                e.Value = "Delete";
            }
        }
        private void grdInspection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 19)
            {
                if (Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    var Manager = new ProductionProcessDetailBLL();
                    if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colIdIspection"].Value),IdVoucher))
                    {
                        MessageBox.Show("Record Deleted Successfully....");
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
        }
        private void grdInspection_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdInspection_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 10)
            {
                if (grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value != null && Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value) > 0)
                {
                    var manager = new ProductionProcessesHeadBLL();
                    List<ItemsEL> list =  manager.GetArticleClosingStockForInspectionPacking(Validation.GetSafeGuid(grdInspection.Rows[e.RowIndex].Cells["colInspectionIdItem"].Value), Validation.GetSafeString(grdInspection.Rows[e.RowIndex].Cells["colInspectionAccountNo"].Value), 1, ProductionType);
                    if (list.Count > 0)
                    {
                        if (Validation.GetSafeDecimal(grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value) > list[0].Qty)
                        {
                            MessageBox.Show("Opps ! You have only : " + list[0].Qty);
                            grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value = "";
                            return;
                        }
                    }
                    else if (list.Count == 0)
                    {
                        MessageBox.Show("Opps ! You have only : " + 0 + " For This Stitcher");
                    }
                }
            }
            else if (e.ColumnIndex == 10)
            {
                if (Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionPassQuantity"].Value) > Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value))
                {
                    MessageBox.Show("Pass Quantity Is Greater Than Total Quantity");
                    grdInspection.Rows[e.RowIndex].Cells["colInspectionPassQuantity"].Value = "";
                    return;
                }
            }
            else if (e.ColumnIndex == 15)
            {
                if (ProductionType == 1)
                {
                    grdInspection.Rows[e.RowIndex].Cells["colInspectionAmount"].Value = (Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionPassQuantity"].Value)
                                                                                        + Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionBQ"].Value)
                                                                                        + Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionRejectedQuantity"].Value))
                                                                                        * Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionRate"].Value);
                }
                else
                {
                    grdInspection.Rows[e.RowIndex].Cells["colInspectionAmount"].Value = Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value);
                }
            }
            else if (e.ColumnIndex == 17)
            {
                grdInspection.Rows[e.RowIndex].Cells["colInspectorAmount"].Value = (Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectionQuantity"].Value)
                                                                                    * Validation.GetSafeLong(grdInspection.Rows[e.RowIndex].Cells["colInspectorRate"].Value));
            }
        }
        private void grdInspection_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdInspection_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdInspection.CurrentCellAddress.X == 4)
            {
                TextBox txtInspectionStitcherName = e.Control as TextBox;
                if (txtInspectionStitcherName != null)
                {
                    txtInspectionStitcherName.KeyPress -= new KeyPressEventHandler(txtInspectionStitcherName_KeyPress);
                    txtInspectionStitcherName.KeyPress += new KeyPressEventHandler(txtInspectionStitcherName_KeyPress);
                }
            }
            else if (grdInspection.CurrentCellAddress.X == 5)
            {
                TextBox txtInspectionArticleName = e.Control as TextBox;
                if (txtInspectionArticleName != null)
                {
                    txtInspectionArticleName.KeyPress -= new KeyPressEventHandler(txtInspectionArticleName_KeyPress);
                    txtInspectionArticleName.KeyPress += new KeyPressEventHandler(txtInspectionArticleName_KeyPress);
                }
            }
            else if (grdInspection.CurrentCellAddress.X == 6)
            {
                TextBox txtInspectionBrandName = e.Control as TextBox;
                if (txtInspectionBrandName != null)
                {
                    txtInspectionBrandName.KeyPress -= new KeyPressEventHandler(txtInspectionBrandName_KeyPress);
                    txtInspectionBrandName.KeyPress += new KeyPressEventHandler(txtInspectionBrandName_KeyPress);
                }
            }
        }
        void txtInspectionStitcherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdInspection.CurrentCellAddress.X == 4)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Inspection";
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
            if (grdInspection.CurrentCellAddress.X == 5)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "InspectionArticle";
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
        void txtInspectionBrandName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdInspection.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "InspectionBrand";
                    frmfindBrand = new frmFindBrand();
                    frmfindBrand.SearchBy = "";
                    frmfindBrand.ExecuteFindBrandEvent += new frmFindBrand.FindBrandDelegate(frmfindBrand_ExecuteFindBrandEvent);
                    frmfindBrand.ShowDialog(this);
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
        private void grdPacking_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                e.Value = "Delete";
            }
        }
        private void grdPacking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 12)
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
                        if (Manager.DeleteGarmentsProcessEntry(Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colIdPacking"].Value),
                            Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colInspectionIdVoucher"].Value)))
                        {
                            MessageBox.Show("Record Deleted Successfully....");
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
        }
        private void grdPacking_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 8)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdPacking_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 9)
            {
                if (grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value != null && Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value) > 0)
                {
                    var manager = new ProductionProcessesHeadBLL();
                    List<ItemsEL> list = manager.GetArticleClosingStockForInspectionPacking(Validation.GetSafeGuid(grdPacking.Rows[e.RowIndex].Cells["colPackingIdItem"].Value), "", 2,ProductionType);
                    if (list.Count > 0)
                    {
                        if (Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value) > list[0].Qty)
                        {
                            MessageBox.Show("Opps ! You have only : " + list[0].Qty);
                            grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value = "";
                            return;
                        }
                    }
                    else if(list.Count == 0)
                    {
                        MessageBox.Show("Oops! You Have 0 Quantity");
                        grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value = "";
                        return;
                    }
                    if(Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingStyle"].Value) == "5 Dozens")
                    {
                        grdPacking.Rows[e.RowIndex].Cells["colPackingCartons"].Value = Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value) / 5;
                    }
                    else if(Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingStyle"].Value) == "6 Dozens")
                    {
                        grdPacking.Rows[e.RowIndex].Cells["colPackingCartons"].Value = Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value) / 6;
                    }
                    else if(Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingStyle"].Value) == "10 Dozens")
                    {
                        grdPacking.Rows[e.RowIndex].Cells["colPackingCartons"].Value = Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value) / 10;
                    }
                    else if(Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingStyle"].Value) == "10 Pieces")
                    {
                        grdPacking.Rows[e.RowIndex].Cells["colPackingCartons"].Value = Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value) / 10;
                    }
                    else if(Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingStyle"].Value) == "20 Pieces")
                    {
                        grdPacking.Rows[e.RowIndex].Cells["colPackingCartons"].Value = Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value) / 20;
                    }
                    else if(Validation.GetSafeString(grdPacking.Rows[e.RowIndex].Cells["colPackingStyle"].Value) == "120 Pieces")
                    {
                        grdPacking.Rows[e.RowIndex].Cells["colPackingCartons"].Value = Validation.GetSafeDecimal(grdPacking.Rows[e.RowIndex].Cells["colPackingQuantity"].Value) / 120;
                    }
                }
            }
            if (e.ColumnIndex == 11)
            {
                grdPacking.Rows[e.RowIndex].Cells["colPackingAmount"].Value = Validation.GetSafeLong(grdPacking.Rows[e.RowIndex].Cells["colPackingCartons"].Value)
                                                                              * Validation.GetSafeLong(grdPacking.Rows[e.RowIndex].Cells["colPackingRates"].Value);
            }
        }
        private void grdPacking_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdPacking_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (grdPacking.CurrentCellAddress.X == 7)
            //{
            //    TextBox txtPackingVendorName = e.Control as TextBox;
            //    if (txtPackingVendorName != null)
            //    {
            //        txtPackingVendorName.KeyPress -= new KeyPressEventHandler(txtPackingVendorName_KeyPress);
            //        txtPackingVendorName.KeyPress += new KeyPressEventHandler(txtPackingVendorName_KeyPress);
            //    }
            //}
            if (grdPacking.CurrentCellAddress.X == 3)
            {
                TextBox txtPackingArticleName = e.Control as TextBox;
                if (txtPackingArticleName != null)
                {
                    txtPackingArticleName.KeyPress -= new KeyPressEventHandler(txtPackingArticleName_KeyPress);
                    txtPackingArticleName.KeyPress += new KeyPressEventHandler(txtPackingArticleName_KeyPress);
                }
            }
            else if (grdPacking.CurrentCellAddress.X == 4)
            {
                TextBox txtPackingBrand = e.Control as TextBox;
                if (txtPackingBrand != null)
                {
                    txtPackingBrand.KeyPress -= new KeyPressEventHandler(txtPackingBrand_KeyPress);
                    txtPackingBrand.KeyPress += new KeyPressEventHandler(txtPackingBrand_KeyPress);
                }
            }
        }
        //void txtPackingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (grdPacking.CurrentCellAddress.X == 7)
        //    {
        //        if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
        //        {
        //            EventFiringName = "Gloves Packing";
        //            frmfindAccount = new frmFindAccounts();
        //            frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
        //            frmfindAccount.SearchText = e.KeyChar.ToString();
        //            frmfindAccount.ShowDialog(this);
        //            e.Handled = true;
        //            SendKeys.Send("{TAB}");
        //        }
        //        else if (e.KeyChar == (char)Keys.Back)
        //        {

        //        }
        //        else
        //            e.Handled = true;
        //    }
        //}
        void txtPackingArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPacking.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "PackingArticle";
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
        void txtPackingBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdPacking.CurrentCellAddress.X == 4)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "PackingBrand";
                    frmfindBrand = new frmFindBrand();
                    frmfindBrand.SearchBy = "";
                    frmfindBrand.ExecuteFindBrandEvent += new frmFindBrand.FindBrandDelegate(frmfindBrand_ExecuteFindBrandEvent);
                    frmfindBrand.ShowDialog(this);
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
        #region General Methods
        private void ClearControls()
        {
            #region Clearing Variables
            IdVoucher = Guid.Empty;
            #endregion
            #region Clearing Controls
            SEditBox.Text = string.Empty;
            PersonAccountNo = string.Empty;
            #endregion
            #region Clearing Grids

            if (WorkType == 1)
            {
                grdInspection.Rows.Clear();
            }
            else if (WorkType == 2)
            {
                grdPacking.Rows.Clear();
            }
            #endregion
        }
        private bool ValidateRecords(int GridNumber)
        {
            bool Status = true;
            #region Misc Validations
            if (VEditBox.Text == string.Empty)
            {
                MessageBox.Show("Production Number Is Empty :");
                Status = false;
            }
            else if (PersonAccountNo == string.Empty)
            {
                MessageBox.Show("Please Select Worker Name :");
                Status = false;
            }
            #endregion
            #region Checking / Inspection Grid Validation
            else if (GridNumber == 1)
            {
                for (int i = 0; i < grdInspection.Rows.Count-1; i++)
                {
                    if (grdInspection.Rows[i].Cells["colInspectionVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Stitcher.....");
                        break;
                    }
                    else if (grdInspection.Rows[i].Cells["colInspectionArticleName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Article For Inspection.....");
                        break;
                    }
                    else if (grdInspection.Rows[i].Cells["colInspectionBrandName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Brand For Inspection.....");
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
            else if (GridNumber == 2)
            {
                for (int i = 0; i < grdPacking.Rows.Count-1; i++)
                {
                    if (grdPacking.Rows[i].Cells["colPackingArticleName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Article For Packing.....");
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
        private void LoadItemSizes(Guid IdItem)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemsAttributes(IdItem);
            if (list.Count > 0)
            {
                list.Insert(0, new ItemsEL() { ItemSize = "", IdSize = Guid.Empty });
                DataGridViewComboBoxCell cellO = (DataGridViewComboBoxCell)grdInspection.CurrentRow.Cells["colGlovesInspectionSizes"];

                cellO.DataSource = list;

                cellO.DisplayMember = "ItemSize";
                cellO.ValueMember = "IdSize";
            }
        }
        private void LoadIndexedItemsSizes(Guid IdItem, int RowIndex)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemsAttributes(IdItem);
            if (list.Count > 0)
            {
                list.Insert(0, new ItemsEL() { ItemSize = "", IdSize = Guid.Empty });
                DataGridViewComboBoxCell cellO = (DataGridViewComboBoxCell)grdInspection.Rows[RowIndex].Cells["colGlovesInspectionSizes"];

                cellO.DataSource = list;

                cellO.DisplayMember = "ItemSize";
                cellO.ValueMember = "IdSize";
            }
        }
        private void FillVoucher()
        {
            var Manager = new ProductionProcessDetailBLL();
            if (VEditBox.Text != string.Empty)
            {
                List<ProductionProcessDetailEL> list = Manager.GetProductionProcessDetailByVoucherNoAndProductionType(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text), WorkType, ProductionType);
                if (list.Count > 0)
                {
                    IdVoucher = list[0].IdVoucher;
                    VEditBox.Enabled = false;
                    ProductionDate.Value = list[0].VDate;
                    txtDescription.Text = list[0].VDiscription;
                    SEditBox.Text = list[0].LinkAccountName;
                    PersonAccountNo = list[0].LinkAccountNo;
                    chkPosted.Checked = list[0].Posted;
                    HandleVoucher(list);


                    FillProductionDetail(list);

                }
                else
                {
                    MessageBox.Show("Voucher Number Not Found ...");
                    ClearControls();
                }
            }
        }
        private void HandleVoucher(List<ProductionProcessDetailEL> list)
        {
            if (list[0].Posted && list[0].IsDeleted == true)
            {
                //if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    chkPosted.Enabled = false;
                }
                lblDeletedVoucher.Text = "Deleted Voucher";
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
                lblDeletedVoucher.Text = "Deleted Voucher";
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
        private void FillProductionDetail(List<ProductionProcessDetailEL> List)
        {
            #region Filling Inspection
            if (List[0].WorkType == 1)
            {
                grdInspection.Rows.Clear();
                for (int i = 0; i < List.Count; i++)
                {
                    grdInspection.Rows.Add();
                    grdInspection.Rows[i].Cells["colIdIspection"].Value = List[i].IdProductionProcessDetail;
                    grdInspection.Rows[i].Cells["colInspectionIdItem"].Value = List[i].IdItem;
                    grdInspection.Rows[i].Cells["colInspectionIdBrand"].Value = List[i].IdBrand;
                    grdInspection.Rows[i].Cells["colInspectionAccountNo"].Value = List[i].AccountNo;
                    grdInspection.Rows[i].Cells["colInspectionVendorName"].Value = List[i].AccountName;
                    grdInspection.Rows[i].Cells["colInspectionArticleName"].Value = List[i].ItemName;
                    grdInspection.Rows[i].Cells["colInspectionBrandName"].Value = List[i].BrandName;
                    grdInspection.Rows[i].Cells["colInspectionUOM"].Value = List[i].PackingSize;
                    if (List[i].ItemSize != "")
                    {
                        LoadIndexedItemsSizes(List[i].IdItem, i);
                        grdInspection.Rows[i].Cells["colGlovesInspectionSizes"].Value = List[i].ItemSize;
                    }
                    grdInspection.Rows[i].Cells["colInspectionQuantity"].Value = List[i].Quantity;
                    grdInspection.Rows[i].Cells["colInspectionPassQuantity"].Value = List[i].ReadyUnits;
                    grdInspection.Rows[i].Cells["colInspectionRejectedQuantity"].Value = List[i].Rejection;
                    grdInspection.Rows[i].Cells["colInspectionBQ"].Value = List[i].BQuantity;
                    grdInspection.Rows[i].Cells["colInspectionRepair"].Value = List[i].RepairQuantity;
                    grdInspection.Rows[i].Cells["colInspectionRate"].Value = List[i].Rate;
                    grdInspection.Rows[i].Cells["colInspectionAmount"].Value = List[i].Amount.ToString("0.00");

                    grdInspection.Rows[i].Cells["colInspectorRate"].Value = List[i].InspectorRate;
                    grdInspection.Rows[i].Cells["colInspectorAmount"].Value = List[i].InspectorAmount.ToString("0.00");
                }
            }
            #endregion
            #region Filling Packing
            else if (List[0].WorkType == 2)
            {
                grdInspection.Rows.Clear();
                for (int i = 0; i < List.Count; i++)
                {
                    grdPacking.Rows.Add();
                    grdPacking.Rows[i].Cells["colIdPacking"].Value = List[i].IdProductionProcessDetail;
                    grdPacking.Rows[i].Cells["colPackingIdItem"].Value = List[i].IdItem;
                    grdPacking.Rows[i].Cells["colIdPackingBrand"].Value = List[i].IdBrand;
                    grdPacking.Rows[i].Cells["colPackingArticleName"].Value = List[i].ItemName;
                    grdPacking.Rows[i].Cells["colPackingBrandName"].Value = List[i].BrandName;
                    grdPacking.Rows[i].Cells["colGlovesPackingSize"].Value = List[i].ItemSize;
                    grdPacking.Rows[i].Cells["colPackingStyle"].Value = List[i].PStyle;
                    grdPacking.Rows[i].Cells["colPackingUOM"].Value = List[i].PackingSize;
                    grdPacking.Rows[i].Cells["colPackingQuantity"].Value = List[i].ReadyUnits;
                    grdPacking.Rows[i].Cells["colPackingCartons"].Value = List[i].PackingCartons;
                    grdPacking.Rows[i].Cells["colPackingRates"].Value = List[i].Rate;
                    grdPacking.Rows[i].Cells["colPackingAmount"].Value = List[i].Amount.ToString("0.00");
                }
            }
            #endregion
        }
        private void LoadItemsSizes(Guid IdItem)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemsAttributes(IdItem);
            if (list.Count > 0)
            {
                list.Insert(0, new ItemsEL() { ItemSize = "", IdSize = Guid.Empty });
                DataGridViewComboBoxCell cellO = (DataGridViewComboBoxCell)grdInspection.CurrentRow.Cells["colInspectionSizes"];

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
                DataGridViewComboBoxCell cellO = (DataGridViewComboBoxCell)grdInspection.Rows[RowIndex].Cells["colGlovesInspectionSizes"];

                cellO.DataSource = list;

                cellO.DisplayMember = "ItemSize";
                cellO.ValueMember = "IdSize";
            }
        }
        #endregion
        #region General Events
        void frmfindAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            if (EventFiringName == "Inspection")
            {
                grdInspection.CurrentRow.Cells["colInspectionAccountNo"].Value = oelAccount.AccountNo;
                grdInspection.CurrentRow.Cells["colInspectionVendorName"].Value = oelAccount.AccountName;
            }
            else if(EventFiringName == "")
            {
                PersonAccountNo = oelAccount.AccountNo;
                SEditBox.Text = oelAccount.AccountName;
            }            
        }
        void frmfindBrand_ExecuteFindBrandEvent(object Sender, BrandEL oelBrand)
        {
            grdInspection.RefreshEdit();
            grdPacking.RefreshEdit();
            if (EventFiringName == "InspectionBrand")
            {
                grdInspection.CurrentRow.Cells["colInspectionIdBrand"].Value = oelBrand.IdBrand;
                grdInspection.CurrentRow.Cells["colInspectionBrandName"].Value = oelBrand.BrandName;
            }
            else if (EventFiringName == "PackingBrand")
            {
                grdPacking.CurrentRow.Cells["colIdPackingBrand"].Value = oelBrand.IdBrand;
                grdPacking.CurrentRow.Cells["colPackingBrandName"].Value = oelBrand.BrandName;
            }
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            grdInspection.RefreshEdit();
            if (EventFiringName == "InspectionArticle")
            {
                grdInspection.CurrentRow.Cells["colInspectionIdItem"].Value = oelItems.IdItem;
                grdInspection.CurrentRow.Cells["colInspectionArticleName"].Value = oelItems.ItemName;
                LoadItemsSizes(oelItems.IdItem);
            }
            else if (EventFiringName == "PackingArticle")
            {
                grdPacking.CurrentRow.Cells["colPackingIdItem"].Value = oelItems.IdItem;
                grdPacking.CurrentRow.Cells["colPackingArticleName"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "PackingBrand")
            {
                grdPacking.CurrentRow.Cells["colIdPackingBrand"].Value = oelItems.IdItem;
                grdPacking.CurrentRow.Cells["colPackingBrandName"].Value = oelItems.ItemName;
            }
        }
        #endregion
        #region Form Controls Events
        private void frmPackingInspection_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                ClearControls();
                FillMaxProductionNo();
            }
        }
        private void SEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindAccount = new frmFindAccounts();
            EventFiringName = "";
            frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
            frmfindAccount.ShowDialog();
        }
        private void SEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDescription.Focus();
            }
        }
        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                chkPosted.Focus();
            }
        }
        private void chkPosted_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (WorkType == 1)
                {
                    grdInspection.Focus();
                }
                else if (WorkType == 2)
                {
                    grdPacking.Focus();
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var Manager = new ProductionProcessesHeadBLL();
            ProductionProcessesHeadEL oelProductionHead = new ProductionProcessesHeadEL();
            List<ProductionProcessDetailEL> oelProductionDetailCollection = new List<ProductionProcessDetailEL>();
            #region Header Information
            if (IdVoucher == Guid.Empty)
            {
                oelProductionHead.IdVoucher = Guid.NewGuid();
            }
            else
            {
                oelProductionHead.IdVoucher = IdVoucher;
            }
            oelProductionHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
            oelProductionHead.AccountNo = PersonAccountNo;
            oelProductionHead.IdCompany = Operations.IdCompany;
            oelProductionHead.BookNo = Operations.BookNo;
            oelProductionHead.UserId = Operations.UserID;
            oelProductionHead.VDate = ProductionDate.Value;
            oelProductionHead.VDiscription = txtDescription.Text;
            oelProductionHead.WorkType = WorkType;
            oelProductionHead.Amount = 0;
            oelProductionHead.Posted = chkPosted.Checked;
            oelProductionHead.CloseDate = DateTime.Now;
            oelProductionHead.ProductionType = ProductionType;
            #endregion
            #region Inspection Area
            if (WorkType == 1)
            {
                if (ValidateRecords(1))
                {
                    for (int i = 0; i < grdInspection.Rows.Count-1; i++)
                    {
                        ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                        oelProductionDetail.IdVoucher = oelProductionHead.IdVoucher;
                        if (grdInspection.Rows[i].Cells["colIdIspection"].Value == null)
                        {
                            oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                            oelProductionDetail.IsNew = true;
                        }
                        else
                        {
                            oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdInspection.Rows[i].Cells["colIdIspection"].Value);
                        }
                        oelProductionDetail.IdUser = Operations.UserID;
                        oelProductionDetail.Description = "N/A";
                        oelProductionDetail.IdItem = Validation.GetSafeGuid(grdInspection.Rows[i].Cells["colInspectionIdItem"].Value);
                        oelProductionDetail.IdBrand = Validation.GetSafeGuid(grdInspection.Rows[i].Cells["colInspectionIdBrand"].Value);
                        oelProductionDetail.AccountNo = Validation.GetSafeString(grdInspection.Rows[i].Cells["colInspectionAccountNo"].Value);
                        oelProductionDetail.PackingSize = Validation.GetSafeString(grdInspection.Rows[i].Cells["colInspectionUOM"].Value);
                        //if (grdInspection.Rows[i].Cells["colInspectionSizes"].Value != null)
                        //{
                        //    oelProductionDetail.IdSize = Validation.GetSafeGuid(grdInspection.Rows[i].Cells["colInspectionSizes"].Value);
                        //}                    
                        oelProductionDetail.ItemSize = Validation.GetSafeString(grdInspection.Rows[i].Cells["colGlovesInspectionSizes"].Value);
                        oelProductionDetail.PackingSize = Validation.GetSafeString(grdInspection.Rows[i].Cells["colInspectionUOM"].Value);
                        oelProductionDetail.PStyle = "";
                        oelProductionDetail.GType = 0;

                        oelProductionDetail.GarmentWorkType = 0;
                        oelProductionDetail.Quality = 0;
                        oelProductionDetail.Quantity = Validation.GetSafeLong(grdInspection.Rows[i].Cells["colInspectionQuantity"].Value);
                        oelProductionDetail.ReadyUnits = Validation.GetSafeLong(grdInspection.Rows[i].Cells["colInspectionPassQuantity"].Value);
                        oelProductionDetail.Rejection = Validation.GetSafeLong(grdInspection.Rows[i].Cells["colInspectionRejectedQuantity"].Value);
                        oelProductionDetail.BQuantity = Validation.GetSafeLong(grdInspection.Rows[i].Cells["colInspectionBQ"].Value);
                        oelProductionDetail.RepairQuantity = Validation.GetSafeLong(grdInspection.Rows[i].Cells["colInspectionRepair"].Value);
                        oelProductionDetail.Rejection = Validation.GetSafeLong(grdInspection.Rows[i].Cells["colInspectionRejectedQuantity"].Value);
                        oelProductionDetail.PackingCartons = 0;
                        oelProductionDetail.Rate = Validation.GetSafeLong(grdInspection.Rows[i].Cells["colInspectionRate"].Value);
                        oelProductionDetail.Amount = Validation.GetSafeDecimal(grdInspection.Rows[i].Cells["colInspectionAmount"].Value);
                        oelProductionDetail.InspectorRate = Validation.GetSafeDecimal(grdInspection.Rows[i].Cells["colInspectorRate"].Value);
                        oelProductionDetail.InspectorAmount = Validation.GetSafeDecimal(grdInspection.Rows[i].Cells["colInspectorAmount"].Value);
                        oelProductionHead.TotalAmount += Validation.GetSafeDecimal(grdInspection.Rows[i].Cells["colInspectionAmount"].Value);
                        oelProductionDetailCollection.Add(oelProductionDetail);
                    }
                }
                else
                {
                    return;
                }
            }
            #endregion
            #region Packing Work
            else if (WorkType == 2)
            {
                if (ValidateRecords(2))
                {
                    for (int i = 0; i < grdPacking.Rows.Count - 1; i++)
                    {
                        ProductionProcessDetailEL oelProductionDetail = new ProductionProcessDetailEL();
                        oelProductionDetail.IdVoucher = oelProductionHead.IdVoucher;
                        if (grdPacking.Rows[i].Cells["colIdPacking"].Value == null)
                        {
                            oelProductionDetail.IdProductionProcessDetail = Guid.NewGuid();
                            oelProductionDetail.IsNew = true;
                        }
                        else
                        {
                            oelProductionDetail.IdProductionProcessDetail = Validation.GetSafeGuid(grdPacking.Rows[i].Cells["colIdPacking"].Value);
                        }
                        oelProductionDetail.IdUser = Operations.UserID;
                        oelProductionDetail.Description = "N/A";
                        oelProductionDetail.IdItem = Validation.GetSafeGuid(grdPacking.Rows[i].Cells["colPackingIdItem"].Value);
                        oelProductionDetail.IdBrand = Validation.GetSafeGuid(grdPacking.Rows[i].Cells["colIdPackingBrand"].Value);
                        oelProductionDetail.PStyle = Validation.GetSafeString(grdPacking.Rows[i].Cells["colPackingStyle"].Value);
                        oelProductionDetail.ItemSize = Validation.GetSafeString(grdPacking.Rows[i].Cells["colGlovesPackingSize"].Value);
                        oelProductionDetail.PackingSize = Validation.GetSafeString(grdPacking.Rows[i].Cells["colPackingUOM"].Value);
                        oelProductionDetail.IdSize = Guid.Empty;
                        oelProductionDetail.GType = 0;

                        oelProductionDetail.GarmentWorkType = 0;
                        oelProductionDetail.Quality = 0;
                        oelProductionDetail.Quantity = 0;
                        oelProductionDetail.ReadyUnits = Validation.GetSafeLong(grdPacking.Rows[i].Cells["colPackingQuantity"].Value);
                        oelProductionDetail.Rejection = 0;
                        oelProductionDetail.BQuantity = 0;
                        oelProductionDetail.RepairQuantity = 0;
                        oelProductionDetail.Rejection = 0;
                        oelProductionDetail.PackingCartons = Validation.GetSafeLong(grdPacking.Rows[i].Cells["colPackingCartons"].Value);
                        oelProductionDetail.Rate = Validation.GetSafeLong(grdPacking.Rows[i].Cells["colPackingRates"].Value);
                        oelProductionDetail.Amount = Validation.GetSafeDecimal(grdPacking.Rows[i].Cells["colPackingAmount"].Value);
                        oelProductionHead.TotalAmount += Validation.GetSafeDecimal(grdInspection.Rows[i].Cells["colInspectionAmount"].Value);
                        oelProductionDetailCollection.Add(oelProductionDetail);
                    }
                }
            }
            #endregion
            #region Saving Code
            if (IdVoucher == Guid.Empty)
            {
                if (Manager.CreateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                {
                    MessageBox.Show("Data Inserted Successfully, Click New for Next Voucher");
                    ClearControls();
                    FillVoucher();
                }
            }
            else
            {
                if (Manager.UpdateProductionHead(oelProductionHead, oelProductionDetailCollection).IsSuccess)
                {
                    MessageBox.Show("Data Updated Successfully, Click New for Next Voucher");
                    ClearControls();
                    FillVoucher();
                }
            }
            #endregion
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            /// Yet To Code Here .....
            var manager = new ProductionProcessesHeadBLL();
            if (IdVoucher != Guid.Empty)
            {
                if (manager.DeleteInspectionPackingByVoucher(IdVoucher))
                {
                    MessageBox.Show("Voucher Deleted Successfully....");
                    ClearControls();
                }
            }
            else
            {
                MessageBox.Show("Please Select Voucher To Delete....");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            long NextVoucherNo = Convert.ToInt64(VEditBox.Text);
            NextVoucherNo += 1;
            VEditBox.Text = NextVoucherNo.ToString();
            ClearControls();
            FillVoucher();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            long PreviousVoucherNo = Convert.ToInt64(VEditBox.Text);
            PreviousVoucherNo -= 1;
            VEditBox.Text = PreviousVoucherNo.ToString();
            ClearControls();
            FillVoucher();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            FillMaxProductionNo();
        }
        #endregion              
    }
}

