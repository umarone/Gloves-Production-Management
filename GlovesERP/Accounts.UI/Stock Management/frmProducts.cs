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
    public partial class frmProducts : MetroForm
    {
        #region Varibles
        frmStockAccounts frmstockAccounts;
        frmFindCategories frmfindCategory;
        frmFindTradingCo frmfindTradingCo;
        frmLinkItems frmlinkitems;
        frmItemsFormula frmformula;
        frmAritcleRequisitionMaterials frmrequisitoinMaterials;
        Guid IdItem = Guid.Empty;
        Guid IdCategory = Guid.Empty;
        Guid IdTradingCo = Guid.Empty;
        #endregion
        #region Form Methods
        public frmProducts()
        {
            InitializeComponent();
        }
        private void frmProducts_Load(object sender, EventArgs e)
        {
            this.grdItemsAttributes.AutoGenerateColumns = false;
            this.grdItemsColorAttributes.AutoGenerateColumns = false;
            GetMaxProductNo();
        }
        private void frmProducts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                GetMaxProductNo();
                ClearControls();
            }
            else if (e.KeyChar == (char)Keys.F2)
            {
                frmstockAccounts = new frmStockAccounts();
                frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                frmstockAccounts.ShowDialog(this);
            }
        }
        #endregion
        #region Simple Methods
        private void GetMaxProductNo()
        {
            var Manager = new ItemsBLL();
            txtProdcutNo.Text = Validation.GetSafeString(Manager.GetMaxProductNo(Operations.IdCompany));
        }
        private bool ValidateControls()
        {
            bool isValid = true;
            if (txtProductName.Text == string.Empty)
            {
                isValid = false;
                MessageBox.Show("Product name Is Empty");
            }
            if (txtCategoryName.Text == string.Empty)
            {
                MessageBox.Show("Category name Is Empty");
                isValid = false;
            }
            if (txtTradingCo.Text == string.Empty)
            {
                MessageBox.Show("Trading name Is Empty");
                isValid = false;
            }
            if (cbxStockType.SelectedIndex == -1 || cbxStockType.SelectedIndex == 0)
            {
                MessageBox.Show("Stock Type Is Missing...");
                isValid = false;
            }
            return isValid;
        }
        private void ClearControls()
        {
            IdItem = Guid.Empty;
            grdItemsAttributes.Rows.Clear();
            grdItemsColorAttributes.Rows.Clear();
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtConfiguration.Text = string.Empty;
            //txtBatchNo.Text = string.Empty;
            txtBarCode.Text = string.Empty;
            txtMRP.Text = "";
            txtunitPrice.Text = string.Empty;
            txtReorderlevel.Text = string.Empty;
            chkRazing.Checked = false;
            chkMandatory.Checked = false;
            cbxStockType.SelectedIndex = 0;
            btnSave.Text = "Save";
            //txtStockInHand.Text = string.Empty;
        }
        #endregion
        #region Transactional Methods
        private void GetItem(Guid Id)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemById(Id);
            if (list.Count > 0)
            {
                txtProdcutNo.Text = list[0].AccountNo.ToString();
                txtProductCode.Text = list[0].ProductCode;
                txtProductName.Text = list[0].ItemName;
                txtCategoryName.Text = list[0].CategoryName;
                txtTradingCo.Text = list[0].TradingCode;
                txtConfiguration.Text = list[0].ItemConfiguration;
                cbxPackingSize.SelectedIndex = cbxPackingSize.Items.IndexOf(list[0].PackingSize);
                cbxStockType.SelectedIndex = list[0].ItemType;
                chkRazing.Checked = Convert.ToBoolean(list[0].IsRazing);
                chkMandatory.Checked = Convert.ToBoolean(list[0].IsMandatory);
                //txtPackingSize.Text = list[0].PackingSize;
                //txtBatchNo.Text = list[0].BatchNo;
                txtBarCode.Text = list[0].BarCode;
                txtMRP.Text = list[0].MRP.ToString();
                txtunitPrice.Text = Validation.GetSafeString(list[0].UnitPrice);
                txtReorderlevel.Text = Validation.GetSafeString(list[0].ReorderLevel);
                //txtStockInHand.Text = Validation.GetSafeString(list[0].StockOnHand);
                IdCategory = list[0].IdCategory;
                IdTradingCo = list[0].IdTradingCo;

                //StockDate.Value = Convert.ToDateTime(list[0].StockOnHandDate);
            }
        }
        private void GetItemsAttributes(Guid Id)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> oelItemsAttributes = manager.GetItemsAttributes(Id);
            if (oelItemsAttributes.Count > 0)
            {
                for (int i = 0; i < oelItemsAttributes.Count; i++)
                {
                    grdItemsAttributes.Rows.Add();
                    grdItemsAttributes.Rows[i].Cells["colIdSize"].Value = oelItemsAttributes[i].IdSize;
                    grdItemsAttributes.Rows[i].Cells["colSizes"].Value = oelItemsAttributes[i].ItemSize;
                    grdItemsAttributes.Rows[i].Cells["colDescription"].Value = oelItemsAttributes[i].Description;
                }
            }
        }
        private void GetItemsColorAttributes(Guid Id)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> oelItemsColorAttributes = manager.GetItemsColorAttributes(Id);
            if (oelItemsColorAttributes.Count > 0)
            {
                for (int i = 0; i < oelItemsColorAttributes.Count; i++)
                {
                    grdItemsColorAttributes.Rows.Add();
                    grdItemsColorAttributes.Rows[i].Cells["colIdColor"].Value = oelItemsColorAttributes[i].IdColor;
                    grdItemsColorAttributes.Rows[i].Cells["colItemColor"].Value = oelItemsColorAttributes[i].ItemColor;
                    grdItemsColorAttributes.Rows[i].Cells["colItemDescription"].Value = oelItemsColorAttributes[i].Description;
                }
                //grdItemsColorAttributes.DataSource = oelItemsColorAttributes;
            }
        }
        #endregion
        #region Button Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            ItemsEL oelItem = new ItemsEL();
            List<ItemsEL> oelItemsAttributeCollection = new List<ItemsEL>();
            List<ItemsEL> oelItemsColorAttributeCollection = new List<ItemsEL>();
            var Manager = new ItemsBLL();
            List<ItemsEL> list = new List<ItemsEL>();
            if (ValidateControls())
            {
                if (IdItem == Guid.Empty)
                {
                    oelItem.IdItem = Guid.NewGuid();
                }
                else
                {
                    oelItem.IdItem = IdItem;
                }
                oelItem.IdCategory = Validation.GetSafeGuid(IdCategory);
                oelItem.IdTradingCo = IdTradingCo;
                oelItem.IdCompany = Operations.IdCompany;
                oelItem.ItemNo = txtProdcutNo.Text;
                oelItem.ProductCode = txtProductCode.Text;
                oelItem.ItemName = txtProductName.Text.Trim();
                oelItem.ItemConfiguration = txtConfiguration.Text.Trim();
                oelItem.IsRazing = chkRazing.Checked;
                oelItem.IsMandatory = chkMandatory.Checked;
                oelItem.PackingSize = cbxPackingSize.Text;
                oelItem.ItemType = cbxStockType.SelectedIndex;
                //oelItem.BatchNo = txtBatchNo.Text;
                oelItem.BarCode = txtBarCode.Text;
                oelItem.MRP = Validation.GetSafeDecimal(txtMRP.Text);
                //oelItem.UnitPrice = Validation.GetSafeDecimal(txtunitPrice.Text);
                //oelItem.StockOnHandDate = StockDate.Value;
                //oelItem.StockOnHand = Validation.GetSafeInteger(txtStockInHand.Text);
                oelItem.ReorderLevel = Validation.GetSafeInteger(txtReorderlevel.Text);
                oelItem.CuttingRates = 0;
                oelItem.CuttingWages = 0;
                oelItem.IsActive = true;
                //oelItem.PackingSize = "";

                for (int i = 0; i < grdItemsAttributes.Rows.Count-1; i++)
                {
                    ItemsEL oelItemAttribute = new ItemsEL();
                    oelItemAttribute.IdItem = oelItem.IdItem;
                    if (grdItemsAttributes.Rows[i].Cells["colIdSize"].Value == null)
                    {
                        oelItemAttribute.IdSize = Guid.NewGuid();
                        grdItemsAttributes.Rows[i].Cells["colIdSize"].Value = oelItemAttribute.IdSize;
                        oelItemAttribute.IsNew = true;
                    }
                    else
                    {
                        oelItemAttribute.IdSize = Validation.GetSafeGuid(grdItemsAttributes.Rows[i].Cells["colIdSize"].Value);
                        oelItemAttribute.IsNew = false;
                    }

                    oelItemAttribute.ItemSize = Validation.GetSafeString(grdItemsAttributes.Rows[i].Cells["colSizes"].Value);                    
                    oelItemAttribute.Description = Validation.GetSafeString(grdItemsAttributes.Rows[i].Cells["colDescription"].Value);

                    oelItemsAttributeCollection.Add(oelItemAttribute);
                }

                for (int i = 0; i < grdItemsColorAttributes.Rows.Count - 1; i++)
                {
                    ItemsEL oelItemColorAttribute = new ItemsEL();
                    oelItemColorAttribute.IdItem = oelItem.IdItem;
                    if (grdItemsColorAttributes.Rows[i].Cells["colIdColor"].Value == null)
                    {
                        oelItemColorAttribute.IdColor = Guid.NewGuid();
                        grdItemsColorAttributes.Rows[i].Cells["colIdColor"].Value = oelItemColorAttribute.IdSize;
                        oelItemColorAttribute.IsNew = true;
                    }
                    else
                    {
                        oelItemColorAttribute.IdColor = Validation.GetSafeGuid(grdItemsColorAttributes.Rows[i].Cells["colIdColor"].Value);
                        oelItemColorAttribute.IsNew = false;
                    }
                    oelItemColorAttribute.ItemColor = Validation.GetSafeString(grdItemsColorAttributes.Rows[i].Cells["colItemColor"].Value);
                    oelItemColorAttribute.Description = Validation.GetSafeString(grdItemsColorAttributes.Rows[i].Cells["colItemDescription"].Value);

                    oelItemsColorAttributeCollection.Add(oelItemColorAttribute);
                }

                if (IdItem == Guid.Empty)
                {
                    if (Manager.InsertItems(oelItem, oelItemsAttributeCollection, oelItemsColorAttributeCollection))
                    {
                        GetMaxProductNo();
                        ClearControls();
                    }
                }
                else
                {
                    if (Manager.UpdateItems(oelItem, oelItemsAttributeCollection, oelItemsColorAttributeCollection))
                    {
                        GetMaxProductNo();
                        ClearControls();
                    }
                }
            }
            else
            {
               
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IdItem != Guid.Empty)
            {
                var manager = new ItemsBLL();
                if (manager.DeleteItems(IdItem))
                {
                    MessageBox.Show("Item Deleted Successfully....");
                    GetMaxProductNo();
                    ClearControls();                    
                }
            }
            else
            {
                MessageBox.Show("Please Select Product First...");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearControls();
            frmstockAccounts = new frmStockAccounts();
            frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
            frmstockAccounts.ShowDialog(this);
        }
        private void btnLinkItems_Click(object sender, EventArgs e)
        {
            if (IdItem != null && IdItem != Guid.Empty)
            {
                frmlinkitems = new frmLinkItems();
                frmlinkitems.IdItem = IdItem;
                frmlinkitems.ItemName = txtProductName.Text;
                frmlinkitems.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select Item First To Add Childs...");
            }
        }
        private void btnFindCategory_Click(object sender, EventArgs e)
        {
            frmfindCategory = new frmFindCategories();
            frmfindCategory.ExecuteFindCategoryEvent += new frmFindCategories.FindCategoryDelegate(frmfindCategory_ExecuteFindCategoryEvent);
            frmfindCategory.ShowDialog();
        }
        private void btnFindTradingCo_Click(object sender, EventArgs e)
        {
            frmfindTradingCo = new frmFindTradingCo();
            frmfindTradingCo.ExecuteFindTradingEvent += new frmFindTradingCo.FindTradingDelegate(frmfindTradingCo_ExecuteFindTradingEvent);
            frmfindTradingCo.ShowDialog();
        }
        private void btnAddFormula_Click(object sender, EventArgs e)
        {
            //frmformula = new frmItemsFormula();
            //frmformula.ItemName = txtProductName.Text;
            //frmformula.CategoryName = txtCategoryName.Text;
            //frmformula.IdCalculatedItem = IdItem;
            //frmformula.ShowDialog();
            if (IdItem != Guid.Empty)
            {
                frmrequisitoinMaterials = new frmAritcleRequisitionMaterials();
                frmrequisitoinMaterials.IdAritcle = IdItem;
                frmrequisitoinMaterials.ArticleName = txtProductName.Text;
                frmrequisitoinMaterials.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please First Select Item");
            }
        }
        #endregion
        #region Custom Events And Methods
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            IdItem = oelItems.IdItem;
            GetItem(IdItem);
            GetItemsAttributes(IdItem);
            GetItemsColorAttributes(IdItem);
            btnSave.Text = "Update";
            //GetItemOpeningStock(IdItem);
        }
        void frmfindCategory_ExecuteFindCategoryEvent(object Sender, CategoryEL oelCategory)
        {
            IdCategory = oelCategory.IdCategory;
            txtCategoryName.Text = oelCategory.CategoryName;
        }
        void frmfindTradingCo_ExecuteFindTradingEvent(object Sender, TradingEL oelTrading)
        {
            IdTradingCo = oelTrading.IdTrading;
            txtTradingCo.Text = oelTrading.TradingName;
        }
        #endregion
        #region Other Controls Events And Methods
        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MetroFramework.Controls.MetroTextBox txt = sender as MetroFramework.Controls.MetroTextBox;
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion
    }
}
