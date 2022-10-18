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
    public partial class frmAritcleRequisitionMaterials : MetroForm
    {
        #region Variables
        frmStockAccounts frmstockAccounts;
        public Guid IdAritcle { get; set; }
        public string ArticleName { get; set; }
        #endregion
        public frmAritcleRequisitionMaterials()
        {
            InitializeComponent();
        }
        private void frmAritcleRequisitionMaterials_Load(object sender, EventArgs e)
        {
            this.Text = ArticleName + " ---> " + "Requisition Materials";
            FillRequisitionMaterials();
            grdRequisitionMaterials.Columns["colPerunitQty"].ReadOnly = true;
        }
        private void FillRequisitionMaterials()
        {
            var manager = new RequisitionItemsBLL();
            List<ItemFormulaEL> list = manager.GetItemsByAritcle(IdAritcle);
            if (list.Count > 0)
            {
                grdRequisitionMaterials.Rows.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    grdRequisitionMaterials.Rows.Add();
                    grdRequisitionMaterials.Rows[i].Cells["colIdItem"].Value = list[i].IdItem;
                    grdRequisitionMaterials.Rows[i].Cells["colIsNew"].Value = false;
                    grdRequisitionMaterials.Rows[i].Cells["colItemName"].Value = list[i].ItemName;
                    grdRequisitionMaterials.Rows[i].Cells["colUOM"].Value = list[i].PackingSize;
                    grdRequisitionMaterials.Rows[i].Cells["colOperationType"].Value = list[i].OperationType;
                    grdRequisitionMaterials.Rows[i].Cells["colcuff"].Value = list[i].IsCuffItem;
                    grdRequisitionMaterials.Rows[i].Cells["colTalli"].Value = list[i].IsTalliItem;
                    grdRequisitionMaterials.Rows[i].Cells["colPerunitQty"].Value = 1;
                    grdRequisitionMaterials.Rows[i].Cells["colRequiredPerUnit"].Value = list[i].TotalQty;
                    grdRequisitionMaterials.Rows[i].Cells["colGrandTotal"].Value = list[i].TotalExactQty;
                }
            }
        }
        private void grdRequisitionMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdRequisitionMaterials.CurrentCellAddress.X == 2)
            {
                TextBox txtMaterialName = e.Control as TextBox;
                if (txtMaterialName != null)
                {
                    txtMaterialName.KeyPress -= new KeyPressEventHandler(txtMaterialName_KeyPress);
                    txtMaterialName.KeyPress += new KeyPressEventHandler(txtMaterialName_KeyPress);
                }
            }
        }
        void txtMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdRequisitionMaterials.CurrentCellAddress.X == 2)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
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
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            grdRequisitionMaterials.CurrentRow.Cells["colIdItem"].Value = oelItems.IdItem;
            grdRequisitionMaterials.CurrentRow.Cells["colItemName"].Value = oelItems.ItemName;
        }
        private void grdRequisitionMaterials_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                grdRequisitionMaterials.Rows[e.RowIndex].Cells["colPerunitQty"].Value = 1;
            }
        }
        private void grdRequisitionMaterials_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                if (Validation.GetSafeString(grdRequisitionMaterials.Rows[e.RowIndex].Cells["colTalli"].Value) != null)
                {
                    grdRequisitionMaterials.Rows[e.RowIndex].Cells["colcuff"].Value = false;
                }
                else
                { 
                    
                }
            }
            else if (e.ColumnIndex == 5)
            {
                if (Validation.GetSafeString(grdRequisitionMaterials.Rows[e.RowIndex].Cells["colcuff"].Value) != null)
                {
                    grdRequisitionMaterials.Rows[e.RowIndex].Cells["colTalli"].Value = false;
                }
                else
                {

                }
            }
            else if (e.ColumnIndex == 8)
            {
                if (Validation.GetSafeString(grdRequisitionMaterials.Rows[e.RowIndex].Cells["colOperationType"].Value) == "Multiply")
                {
                    if (grdRequisitionMaterials.Rows[e.RowIndex].Cells["colRequiredPerUnit"].Value != null)
                    {
                        grdRequisitionMaterials.Rows[e.RowIndex].Cells["colGrandTotal"].Value = 1 * Validation.GetSafeDecimal(grdRequisitionMaterials.Rows[e.RowIndex].Cells["colRequiredPerUnit"].Value);
                    }
                }
                else if (Validation.GetSafeString(grdRequisitionMaterials.Rows[e.RowIndex].Cells["colOperationType"].Value) == "Divide")
                {
                    if (grdRequisitionMaterials.Rows[e.RowIndex].Cells["colRequiredPerUnit"].Value != null)
                    {
                        grdRequisitionMaterials.Rows[e.RowIndex].Cells["colGrandTotal"].Value = 1 / Validation.GetSafeDecimal(grdRequisitionMaterials.Rows[e.RowIndex].Cells["colRequiredPerUnit"].Value);
                    }
                }
            }
        }
        private void grdRequisitionMaterials_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                e.Value = "Delete";
            }
        }
        private void grdRequisitionMaterials_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<ItemFormulaEL> list = new List<ItemFormulaEL>();
            for (int i = 0; i < grdRequisitionMaterials.Rows.Count - 1; i++)
            {
                ItemFormulaEL oelFormula = new ItemFormulaEL();
                oelFormula.IdItem = Validation.GetSafeGuid(grdRequisitionMaterials.Rows[i].Cells["colIdItem"].Value);
                oelFormula.IdArticle = IdAritcle;
                if (grdRequisitionMaterials.Rows[i].Cells["colOperationType"].Value == null)
                {
                    MessageBox.Show("Please Select Operation Type");
                    return;
                }
                else
                {
                    oelFormula.OperationType = Validation.GetSafeString(grdRequisitionMaterials.Rows[i].Cells["colOperationType"].Value);
                }
                if (grdRequisitionMaterials.Rows[i].Cells["colUOM"].Value == null)
                {
                    MessageBox.Show("Please Select UOM Type");
                    return;
                }
                else
                {
                    oelFormula.PackingSize = Validation.GetSafeString(grdRequisitionMaterials.Rows[i].Cells["colUOM"].Value);
                }
                if (grdRequisitionMaterials.Rows[i].Cells["colIsNew"].Value == null)
                {
                    oelFormula.IsNew = true;
                }
                else
                {
                    oelFormula.IsNew = false;
                }
                if (grdRequisitionMaterials.Rows[i].Cells["colcuff"].Value != null && Validation.GetSafeBooleanNullable(grdRequisitionMaterials.Rows[i].Cells["colcuff"].Value) == true)
                {
                    oelFormula.IsCuffItem = true;
                }
                else
                {
                    oelFormula.IsCuffItem = false;
                }
                if (grdRequisitionMaterials.Rows[i].Cells["colTalli"].Value != null && Validation.GetSafeBooleanNullable(grdRequisitionMaterials.Rows[i].Cells["colTalli"].Value) == true)
                {
                    oelFormula.IsTalliItem= true;
                }
                else
                {
                    oelFormula.IsTalliItem = false;
                }
                oelFormula.PerUnitTotal = Validation.GetSafeInteger(grdRequisitionMaterials.Rows[i].Cells["colPerunitQty"].Value);
                oelFormula.TotalQty = Validation.GetSafeDecimal(grdRequisitionMaterials.Rows[i].Cells["colRequiredPerUnit"].Value);
                oelFormula.TotalExactQty = Validation.GetSafeDecimal(grdRequisitionMaterials.Rows[i].Cells["colGrandTotal"].Value);
                oelFormula.IsActive = true;

                list.Add(oelFormula);
            }
            var manager = new RequisitionItemsBLL();
            if (manager.InsertRequisitionItems(list))
            {
                MessageBox.Show("Requisition Is Updated Successfully...");
                FillRequisitionMaterials();
            }
            else
            {
                MessageBox.Show("Some Problem Occured While Saving Formula");
            }

        }
        private void grdRequisitionMaterials_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5)
            {
                if (Validation.GetSafeString(grdRequisitionMaterials.Rows[e.RowIndex].Cells["colTalli"].Value) != null)
                {
                    grdRequisitionMaterials.Rows[e.RowIndex].Cells["colTalli"].Value = false;
                }
                else
                {

                }
            }
            else if (e.ColumnIndex == 6)
            {
                if (Validation.GetSafeString(grdRequisitionMaterials.Rows[e.RowIndex].Cells["colcuff"].Value) != null)
                {
                    grdRequisitionMaterials.Rows[e.RowIndex].Cells["colcuff"].Value = false;
                }
                else
                {

                }
            }
            else if (e.ColumnIndex == 10)
            {
                var manager = new RequisitionItemsBLL();
                manager.DeleteItemsByArticle(IdAritcle, Validation.GetSafeGuid(grdRequisitionMaterials.Rows[e.RowIndex].Cells["colIdItem"].Value));
                FillRequisitionMaterials();

            }
        }
    }
}
