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
    public partial class frmCurrentStock : MetroForm
    {
        Guid IdItem;
        DataTable dt;
        public int StockType { get; set; }
        string CatType = "";
        public frmCurrentStock()
        {
            InitializeComponent();
        }
        private void frmCurrentStock_Load(object sender, EventArgs e)
        {
            this.grdCurrentStock.AutoGenerateColumns = false;
            if (StockType == 1)
            {
                CatType = "Gloves Raw Materials";
                this.Text = "Gloves Raw Materials Opening Stock";
            }
            else if (StockType == 2)
            {
                CatType = "Gloves Semi Finished Materials";//"Gloves Semi Finished Materials";
                this.Text = "Gloves Semi Finished Opening Stock";
            }            
            else if (StockType == 3)
            {
                CatType = "Garments Raw Materials";
                this.Text = "Garments Raw Materials Opening Stock";
            }
            else if (StockType == 4)
            {
                CatType = "Gloves Finished Goods";
                this.Text = "Gloves Finished Goods Opening Stock";
            }           
            FillCategories(CatType);
        }
        private void FillCategories(string CategoryType)
        {
            var manager = new CategoryBLL();
            List<CategoryEL> listCategories = manager.GetAllCategoriesByCategoryTypes(Operations.IdCompany, CategoryType);
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
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Qty > 0)
                    {
                        IdItem = list[i].IdItem;
                        break;
                    }
                }
                dt = DataOperations.ToDataTable(list);
                grdCurrentStock.DataSource = dt;
            }
            else
            {
                grdCurrentStock.DataSource = null;
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
                oelCurrentStock.Seq = i + 1;
                oelCurrentStock.BatchNo = "N/A";
                oelCurrentStock.Qty = Validation.GetSafeDecimal(grdCurrentStock.Rows[i].Cells["colUnits"].Value);
                oelCurrentStock.UnitPrice = Validation.GetSafeDecimal(grdCurrentStock.Rows[i].Cells["colUnitPrice"].Value);
                oelCurrentStock.CurrentUnitPrice = Validation.GetSafeDecimal(grdCurrentStock.Rows[i].Cells["colUnitPrice"].Value);
                oelCurrentStock.TotalAmount = Validation.GetSafeDecimal(grdCurrentStock.Rows[i].Cells["colTotalAmount"].Value);
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
                grdCurrentStock.Rows[e.RowIndex].Cells["colTotalAmount"].Value = Validation.GetSafeDecimal(grdCurrentStock.Rows[e.RowIndex].Cells["colUnits"].Value) *
                                                                                 Validation.GetSafeDecimal(grdCurrentStock.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
            }
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("ItemName LIKE '%{0}%'", txtsearch.Text);
            grdCurrentStock.DataSource = DV;
        }
    }
}
