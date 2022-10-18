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
    public partial class frmItemsFormula : MetroForm
    {
        public Guid IdCalculatedItem { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public Guid IdCalculation = Guid.Empty;
        bool IsFormulaExists = false;
        public frmItemsFormula()
        {
            InitializeComponent();
        }
        private void frmItemsFormula_Load(object sender, EventArgs e)
        {
            this.Text = ItemName + " " + "Formula";
            LoadFormula();
            AddItemsByCategory();
        }
        private void AddItemsByCategory()
        {
            if (CategoryName == "Gloves Material")
            {
                cbxProductType.Items.Add("");
                cbxProductType.Items.Add("Magzi");
                cbxProductType.Items.Add("Tape");
                cbxProductType.Items.Add("Gloves ELASTIC");
                cbxProductType.Items.Add("Andras");
                cbxProductType.Items.Add("Fabric / Thread");
                cbxProductType.Items.Add("Piping / Tanda");
                cbxProductType.Items.Add("Carbon Tape(Packing)");
                cbxProductType.Items.Add("Strip(Packing)");
                cbxProductType.Items.Add("Carton");
            }
            else
            {
                cbxProductType.Items.Add("");
                cbxProductType.Items.Add("ZIP");
                cbxProductType.Items.Add("ELASTIC");
                cbxProductType.Items.Add("BUTTON");
                cbxProductType.Items.Add("LABEL2 (CARE)");
                cbxProductType.Items.Add("LABEL3 (SIZE)");
                cbxProductType.Items.Add("LABEL4 (POCKET)");
                cbxProductType.Items.Add("LABEL5 (PANTS)");
                cbxProductType.Items.Add("POCKET");
                cbxProductType.Items.Add("POLY BAG");
                cbxProductType.Items.Add("CARTON");
                cbxProductType.Items.Add("SINGER THREAD");
                cbxProductType.Items.Add("SPECIAL THREAD");
            }
        }
        private void LoadFormula()
        {
            var manager = new GarmentsCalculationBLL();
            List<ItemFormulaEL> list = manager.GetFormulaByItem(IdCalculatedItem);
            if (list.Count > 0)
            {
                IsFormulaExists = true;
                btnSave.Text = "Update";
                for (int i = 0; i < list.Count; i++)
                {
                    grdFormulas.Rows.Add();
                    grdFormulas.Rows[i].Cells["colIdCalculation"].Value = list[i].IdCalculation;
                    grdFormulas.Rows[i].Cells["colPerunitQty"].Value = list[i].PerUnitTotal;
                    grdFormulas.Rows[i].Cells["colTotalUnits"].Value = list[i].TotalExactQty;
                    grdFormulas.Rows[i].Cells["colTotal"].Value = list[i].TotalQty;
                }
            }
        }
        private void grdFormulas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                e.Value = "Delete";
            }
        }
        private bool ValidateControl()
        {
            bool status = true;
            if (cbxProductType.SelectedIndex == -1)
            {
                status = false;
            }
            return status;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ItemFormulaEL oelFormula = new ItemFormulaEL();
            oelFormula.IdItem = IdCalculatedItem;
            if (ValidateControl())
            {
                if (!IsFormulaExists && btnSave.Text == "Save")
                {
                    if (IdCalculation == Guid.Empty)
                    {
                        oelFormula.IdCalculation = Guid.NewGuid();
                    }
                    else
                    {
                        oelFormula.IdCalculation = IdCalculation;
                    }
                    oelFormula.MaterialType = cbxProductType.Text;
                    oelFormula.OperationType = cbxOperationType.Text;
                    oelFormula.PerUnitTotal = Validation.GetSafeInteger(txtPerUnitQty.Text);
                    oelFormula.TotalExactQty = Validation.GetSafeInteger(txtTotalUnits.Text);
                    
                    if (cbxOperationType.SelectedIndex == -1 || cbxOperationType.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please Select Operation Type");
                        return;
                    }
                    else if (cbxOperationType.SelectedIndex == 1)
                    {                       
                       oelFormula.TotalQty = Validation.GetSafeInteger(txtTotalUnits.Text) * Validation.GetSafeInteger(txtPerUnitQty.Text);                        
                    }
                    else if (cbxOperationType.SelectedIndex == 2)
                    {
                        oelFormula.TotalQty = Validation.GetSafeDecimal(Validation.GetSafeDecimal(txtPerUnitQty.Text) / Validation.GetSafeInteger(txtTotalUnits.Text));
                    }
                    if (IdCalculation == Guid.Empty)
                    {
                        IdCalculation = oelFormula.IdCalculation;
                        var manager = new GarmentsCalculationBLL();
                        if (manager.CreateGarmentsCalculation(oelFormula))
                        {
                            //ClearControls();
                            IsFormulaExists = true;
                            AddRecord();
                        }
                        else
                        {
                            MessageBox.Show("Some Problem Occured While Saving Formula");
                            IsFormulaExists = false;
                        }
                    }
                    else
                    {
                        var manager = new GarmentsCalculationBLL();
                        if (manager.UpdateGarmentsCalculation(oelFormula))
                        {
                            //ClearControls();
                            AddRecord();
                            IsFormulaExists = true;
                        }
                        else
                        {
                            MessageBox.Show("Some Problem Occured While Saving Formula");
                            IsFormulaExists = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Formula for this item already exists");
                }
            }
            else
            {
                MessageBox.Show("Please Select Material Type");
            }
        }
        private void ClearControls()
        {
            txtPerUnitQty.Text = string.Empty;
            txtTotalUnits.Text = string.Empty;
        }
        private void AddRecord()
        {
            grdFormulas.Rows.Add();
            DataGridViewRow oRow = grdFormulas.Rows[0];
            oRow.Cells["colIdCalculation"].Value = IdCalculation;
            oRow.Cells["colPerunitQty"].Value = txtPerUnitQty.Text;
            oRow.Cells["colTotalUnits"].Value = txtTotalUnits.Text;
            if (cbxOperationType.SelectedIndex == 1)
            {
                oRow.Cells["colTotal"].Value = Validation.GetSafeInteger(txtPerUnitQty.Text) * Validation.GetSafeInteger(txtTotalUnits.Text);
            }
            else if (cbxOperationType.SelectedIndex == 2)
            {
                oRow.Cells["colTotal"].Value = Validation.GetSafeInteger(txtPerUnitQty.Text) / Validation.GetSafeInteger(txtTotalUnits.Text);
            }
            //grdFormulas.Rows.Add(oRow);        
        }

        private void grdFormulas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdFormulas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4)
            {
                txtPerUnitQty.Text = Validation.GetSafeString(grdFormulas.Rows[e.RowIndex].Cells["colPerunitQty"].Value);
                txtTotalUnits.Text = Validation.GetSafeString(grdFormulas.Rows[e.RowIndex].Cells["colTotalUnits"].Value);
            }
        }
    }
}
