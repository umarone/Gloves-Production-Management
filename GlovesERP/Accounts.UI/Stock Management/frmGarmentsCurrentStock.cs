using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MetroFramework.Forms;

using Accounts.BLL;
using Accounts.EL;
using Accounts.Common;

namespace Accounts.UI
{
    public partial class frmGarmentsCurrentStock : MetroForm
    {
        #region Variables
        Guid IdItem;
        DataTable dt;
        frmStockAccounts frmfindStock;
        #endregion
        #region Form Events And Methods
        public frmGarmentsCurrentStock()
        {
            InitializeComponent();
        }
        private void frmGarmentsCurrentStock_Load(object sender, EventArgs e)
        {
            this.grdCurrentStock.AutoGenerateColumns = false;
            FillCategories();
        }
        #endregion
        private void FillCategories()
        {
            var manager = new CategoryBLL();
            List<CategoryEL> listCategories = manager.GetAllCategoriesByCategoryTypes(Operations.IdCompany, "Garments Finished Goods"); //manager.GetAllCategories(Operations.IdCompany);
            listCategories.Insert(0, new CategoryEL() { IdCategory = Guid.Empty, CategoryName = "Please Select Category" });
            CbxCategories.DataSource = listCategories;
            CbxCategories.DisplayMember = "CategoryName";
            CbxCategories.ValueMember = "IdCategory";
        }
        private void CbxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxCategories.SelectedIndex > 0)
            {
                grdCurrentStock.DataSource = null;
                GetItemOpeningStock(Validation.GetSafeGuid(CbxCategories.SelectedValue));
            }
            else
            {
                grdCurrentStock.DataSource = null;
            }
        }
        private void GetItemOpeningStock(Guid Id)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemsCurrentStockByCategory(Id);
            if (list.Count > 0)
            {
                if (grdCurrentStock.Rows.Count > 0)
                {
                    grdCurrentStock.Rows.Clear();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    grdCurrentStock.Rows.Add();
                    grdCurrentStock.Rows[i].Cells[0].Value = list[i].IdCurrentStock;
                    grdCurrentStock.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdCurrentStock.Rows[i].Cells[2].Value = list[i].ItemName;
                    grdCurrentStock.Rows[i].Cells[3].Value = list[i].PackingSize;
                    List<ItemsEL> listColors = GetItemsColorAttributes(list[i].IdItem);
                    if (listColors.Count > 0)
                    {
                        DataGridViewComboBoxCell OCell = (DataGridViewComboBoxCell)grdCurrentStock.Rows[i].Cells[4];
                        if (OCell != null)
                        {
                            OCell.DataSource = listColors;
                            OCell.DisplayMember = "ItemColor";
                            OCell.ValueMember = "IdColor";
                        }
                        if (list[i].IdColor != Guid.Empty)
                            grdCurrentStock.Rows[i].Cells[4].Value = list[i].IdColor;
                        else
                            grdCurrentStock.Rows[i].Cells[4].Value = null;
                    }
                    else
                    {
                        grdCurrentStock.Rows[i].Cells[4].Value = null;
                    }
                    grdCurrentStock.Rows[i].Cells[5].Value = list[i].FreshClotheQuantity;
                    grdCurrentStock.Rows[i].Cells[6].Value = list[i].FreshClotheRate;
                    grdCurrentStock.Rows[i].Cells[7].Value = list[i].GradeAUnits;
                    grdCurrentStock.Rows[i].Cells[8].Value = list[i].GradeAAmount;
                    grdCurrentStock.Rows[i].Cells[9].Value = list[i].GradeBUnits;
                    grdCurrentStock.Rows[i].Cells[10].Value = list[i].GradeBAmount;
                    grdCurrentStock.Rows[i].Cells[11].Value = list[i].CPUnits;
                    //if (list[i].Qty > 0)
                    //{
                    //    IdItem = list[i].IdItem;
                    //    break;
                    //}
                }
                dt = DataOperations.ToDataTable(list);
                //grdCurrentStock.DataSource = dt;
            }
            else
            {
                //grdCurrentStock.DataSource = null;
                grdCurrentStock.Rows.Clear();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ItemsEL oelItem = new ItemsEL();
            var Manager = new ItemsBLL();
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();

            for (int i = 0; i < grdCurrentStock.Rows.Count; i++)
            {
                VoucherDetailEL oelCurrentStock = new VoucherDetailEL();
                if (grdCurrentStock.Rows[i].Cells["colIdCurrentStock"].Value != null && Validation.GetSafeGuid(grdCurrentStock.Rows[i].Cells["colIdCurrentStock"].Value) != Guid.Empty)
                {
                    oelCurrentStock.IdCurrentStock = Validation.GetSafeGuid(grdCurrentStock.Rows[i].Cells["colIdCurrentStock"].Value);
                    oelCurrentStock.IsNew = false;
                }
                else
                {
                    oelCurrentStock.IdCurrentStock = Guid.NewGuid();
                    oelCurrentStock.IsNew = true;
                }
                oelCurrentStock.IdItem = Validation.GetSafeGuid(grdCurrentStock.Rows[i].Cells["colIdItem"].Value);
                oelCurrentStock.PackingSize = Validation.GetSafeString(grdCurrentStock.Rows[i].Cells["colPackingSize"].Value);
                oelCurrentStock.IdColor = Validation.GetSafeGuid(grdCurrentStock.Rows[i].Cells["ColColor"].Value);
                oelCurrentStock.Seq = i + 1;
                oelCurrentStock.BatchNo = "N/A";
                oelCurrentStock.FreshClotheQuantity = Validation.GetSafeDecimal(grdCurrentStock.Rows[i].Cells["colPlainQuantity"].Value);
                oelCurrentStock.FreshClotheRate = Validation.GetSafeDecimal(grdCurrentStock.Rows[i].Cells["colPlainRate"].Value);
                oelCurrentStock.GradeAUnits = Validation.GetSafeDecimal(grdCurrentStock.Rows[i].Cells["colFreshAGradeQuantity"].Value);
                oelCurrentStock.GradeAAmount = Validation.GetSafeDecimal(grdCurrentStock.Rows[i].Cells["colFreshGradeARate"].Value);
                oelCurrentStock.GradeBUnits = Validation.GetSafeDecimal(grdCurrentStock.Rows[i].Cells["colGradeBQuantity"].Value);
                oelCurrentStock.GradeBAmount = Validation.GetSafeDecimal(grdCurrentStock.Rows[i].Cells["colGradeBRate"].Value);
                oelCurrentStock.CPUnits = Validation.GetSafeDecimal(grdCurrentStock.Rows[i].Cells["colGradeBRate"].Value);
                oelCurrentStock.UnitPrice = 0;
                oelCurrentStock.CurrentUnitPrice = 0;
                oelCurrentStock.TotalAmount = 0;
                list.Add(oelCurrentStock);
            }
            if (Manager.InsertUpdateCurrentStock(list))
            {
                MessageBox.Show("Opening Stock Inserted / Updated Successfully....");
                CbxCategories.SelectedIndex = 0;
                //GetMaxProductNo();
                //ClearControls();
            }

        }
        private void grdCurrentStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                //grdCurrentStock.Rows[e.RowIndex].Cells["colTotalAmount"].Value = Validation.GetSafeDecimal(grdCurrentStock.Rows[e.RowIndex].Cells["colUnits"].Value) *
                //Validation.GetSafeDecimal(grdCurrentStock.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
            }
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("ItemName LIKE '%{0}%'", txtsearch.Text);
            grdCurrentStock.DataSource = DV;
            //if (DV.Count > 0)
            //{
            //    for (int i = 0; i < DV.Count; i++)
            //    {
            //        //List<ItemsEL> listColors = GetItemsColorAttributesSearch(Validation.GetSafeGuid(DV.Table.Rows[i].ItemArray[0]));
            //        List<ItemsEL> listColors = GetItemsColorAttributesSearch(Validation.GetSafeGuid(grdCurrentStock.Rows[i].Cells["colIdItem"].Value));
            //        DataGridViewComboBoxCell OCell = (DataGridViewComboBoxCell)grdCurrentStock.Rows[i].Cells[4];
            //        if (OCell != null)
            //        {
            //            OCell.DataSource = listColors;
            //            OCell.DisplayMember = "ItemColor";
            //            OCell.ValueMember = "IdColor";
            //        }
            //        if (Validation.GetSafeGuid(DV.Table.Rows[i].ItemArray[6]) != Guid.Empty)
            //        {
            //            grdCurrentStock.Rows[i].Cells[4].Value = Validation.GetSafeGuid(DV.Table.Rows[i].ItemArray[6]);
            //        }
            //        else
            //        {
            //            grdCurrentStock.Rows[i].Cells[4].Value = null;
            //        }
            //        //if (listColors.Count > 0)
            //        //{
            //        //    if (listColors.Count > i)
            //        //    {
            //        //        if (listColors[i].IdColor != Guid.Empty)
            //        //            grdCurrentStock.Rows[i].Cells[4].Value = listColors[i].IdColor;
            //        //        else
            //        //            grdCurrentStock.Rows[i].Cells[4].Value = null;
            //        //    }
            //        //}
            //    }
            //}
        }
        private void grdCurrentStock_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCurrentStock.CurrentCellAddress.X == 2)
            {
                TextBox txtProductName = e.Control as TextBox;
                if (txtProductName != null)
                {
                    txtProductName.KeyPress -= new KeyPressEventHandler(txtProductName_KeyPress);
                    txtProductName.KeyPress += new KeyPressEventHandler(txtProductName_KeyPress);
                }
            }
        }
        void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCurrentStock.CurrentCellAddress.X == 2)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmfindStock = new frmStockAccounts();
                    frmfindStock.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmfindStock_ExecuteFindStockAccountEvent);
                    frmfindStock.SearchText = e.KeyChar.ToString();
                    frmfindStock.ShowDialog(this);
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
        void frmfindStock_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            grdCurrentStock.RefreshEdit();
            grdCurrentStock.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
            grdCurrentStock.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
            DataGridViewComboBoxCell oColorCell = (DataGridViewComboBoxCell)grdCurrentStock.CurrentRow.Cells["ColColor"];
            if (oColorCell != null)
            {
                oColorCell.DataSource = GetItemsColorAttributes(oelItems.IdItem);
                oColorCell.DisplayMember = "ItemColor";
                oColorCell.ValueMember = "IdColor";
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
        private List<ItemsEL> GetItemsColorAttributesSearch(Guid Id) //, string ProcessName
        {
            var manager = new ItemsBLL();
            List<ItemsEL> oelItemsColorAttributesList = manager.GetItemsColorAttributes(Id);
            return oelItemsColorAttributesList;
        }
        private void grdCurrentStock_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                SendKeys.Send("{F4}");
            }
        }
    }
}
