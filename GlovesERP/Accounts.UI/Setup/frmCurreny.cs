using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.Common;
using Accounts.EL;
using Accounts.BLL;
using MetroFramework.Forms;

namespace Accounts.UI
{    
    public partial class frmCurreny : MetroForm
    {
        Int64? IdCurrency;
        DataTable dt;
        public frmCurreny()
        {
            InitializeComponent();
        }
        private void frmCurreny_Load(object sender, EventArgs e)
        {
            this.grdCurrencies.AutoGenerateColumns = false;
            GetAllCurrencies();
        }
        private void frmCurreny_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                ClearControls();
            }
        }
        private void GetAllCurrencies()
        {
            var manager = new CurrencyBLL();
            List<CurrencyEL> list = manager.GetAllCurrencies();
            if (list.Count > 0)
            {
                dt = DataOperations.ToDataTable(list);
                grdCurrencies.DataSource = dt;
            }
            else
            {
                grdCurrencies.DataSource = null;
            }
        }
        private void ClearControls()
        {
            IdCurrency = null;
            txtCurrencyName.Text = string.Empty;
            txtCurrencySymbol.Text = string.Empty;
            txtDiscription.Text = string.Empty;
        }
        private bool ValidateControls()
        {
            bool status = true;
            if (txtCurrencyName.Text == string.Empty)
            {
                status = false;
                MessageBox.Show("Please Enter Currency Name");
            }
            return status;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var Manager = new CurrencyBLL();
            CurrencyEL oelCurrency = new CurrencyEL();
            if (ValidateControls())
            {
                oelCurrency.UserId = Operations.UserID;
                oelCurrency.CurrencyName = Validation.GetSafeString(txtCurrencyName.Text);
                oelCurrency.CurrencySymbol = Validation.GetSafeString(txtCurrencySymbol.Text);
                oelCurrency.Discription = Validation.GetSafeString(txtDiscription.Text);
                oelCurrency.CreatedDateTime = dtCurrency.Value;
                if (!IdCurrency.HasValue)
                {
                    if (Manager.CreateCurrency(oelCurrency).IsSuccess)
                    {
                        MessageBox.Show("Currency Created Successfully...");
                        ClearControls();
                        GetAllCurrencies();
                    }
                }
                else
                {
                    if (Manager.UpdateCurrency(oelCurrency).IsSuccess)
                    {
                        MessageBox.Show("Currency Updated Successfully...");
                        ClearControls();
                        GetAllCurrencies();
                    }
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grdCurrencies_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                e.Value = "Edit";
            }
        }
        private void grdCurrencies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                IdCurrency = Validation.GetSafeLong(grdCurrencies.Rows[e.RowIndex].Cells["colIdCurrency"].Value);
                GetCurrency();
            }
        }
        private void GetCurrency()
        {
            if (IdCurrency.HasValue && IdCurrency.Value > 0)
            {
                var manager = new CurrencyBLL();
                List<CurrencyEL> list = manager.GetCurrencyById(IdCurrency.Value);
                if (list.Count > 0)
                {
                    txtCurrencyName.Text = list[0].CurrencyName;
                    txtCurrencySymbol.Text = list[0].CurrencySymbol;
                    txtDiscription.Text = list[0].Discription;
                }
            }
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("CurrencyName LIKE '%{0}%'", txtsearch.Text);
            grdCurrencies.DataSource = DV;
        }
    }
}
