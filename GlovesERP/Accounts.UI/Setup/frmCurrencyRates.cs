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
    public partial class frmCurrencyRates : MetroForm
    {
        Int64? IdCurrency, IdCurrencyRates;
        DataTable dt;
        public frmCurrencyRates()
        {
            InitializeComponent();
        }
        private void frmCurrencyRates_Load(object sender, EventArgs e)
        {
            this.grdCurrencyRates.AutoGenerateColumns = false;
            GetAllCurrencies();
        }
        private void frmCurrencyRates_KeyPress(object sender, KeyPressEventArgs e)
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
                list.Insert(0, new CurrencyEL() { IdCurrency = -1, CurrencyName = "Select Currency"});
                cbxCurrencies.DataSource = list;

                cbxCurrencies.DisplayMember = "CurrencyName";
                cbxCurrencies.ValueMember = "IdCurrency";
                cbxCurrencies.SelectedIndex = -1;
            }
        }
        private void GetAllCurrencyRatesById()
        {
            var manager = new CurrencyRatesBLL();
            List<CurrencyRatesEL> list = manager.GetCurrentCurrencyRate(IdCurrency.Value);
            if (list.Count > 0)
            {
                dt = DataOperations.ToDataTable(list);
                grdCurrencyRates.DataSource = dt;
            }
            else
            {
                grdCurrencyRates.DataSource = null;
            }
        }
        private void ClearControls()
        {
            //IdCurrency = null;
            IdCurrencyRates = null;
            txtCurrencyRates.Text = string.Empty;
            txtDiscription.Text = string.Empty;
        }
        private bool ValidateControls()
        {
            bool status = true;
            if (cbxCurrencies.Text == "Select Currency")
            {
                status = false;
                MessageBox.Show("Please Select Currency");
                return status;
            }
            if (txtCurrencyRates.Text == string.Empty)
            {
                status = false;
                MessageBox.Show("Please Enter Currency Rate");
                return status;
            }
            return status;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var Manager = new CurrencyRatesBLL();
            CurrencyRatesEL oelCurrencyRate = new CurrencyRatesEL();
            if (ValidateControls())
            {
                oelCurrencyRate.UserId = Operations.UserID;
                oelCurrencyRate.IdCurrency = Validation.GetSafeLong(cbxCurrencies.SelectedValue);
                oelCurrencyRate.CurrencyRates = Validation.GetSafeDecimal(txtCurrencyRates.Text);
                oelCurrencyRate.Discription = Validation.GetSafeString(txtDiscription.Text);
                oelCurrencyRate.CreatedDateTime = dtCurrency.Value;
                oelCurrencyRate.IsCurrent = true;
                if (!IdCurrencyRates.HasValue)
                {
                    if (Manager.CreateCurrencyRates(oelCurrencyRate).IsSuccess)
                    {
                        MessageBox.Show("Currency Rates Created Successfully...");
                        ClearControls();
                        GetAllCurrencyRatesById();
                    }
                }
                else
                {
                    if (Manager.UpdateCurrencyRates(oelCurrencyRate).IsSuccess)
                    {
                        MessageBox.Show("Currency Rates Updated Successfully...");
                        ClearControls();
                        GetAllCurrencyRatesById();
                    }
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grdCurrencyRates_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                e.Value = "Edit";
            }
        }
        private void grdCurrencyRates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                IdCurrencyRates = Validation.GetSafeLong(grdCurrencyRates.Rows[e.RowIndex].Cells["colIdCurrencyRates"].Value);
                GetCurrencyById();
            }
        }
        private void cbxCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCurrencies.Text != "Select Currency")
            {
                IdCurrency = Validation.GetSafeLong(cbxCurrencies.SelectedValue);
                GetAllCurrencyRatesById();
            }
        }
        private void GetCurrencyById()
        {
            var manager = new CurrencyRatesBLL();
            List<CurrencyRatesEL> list = manager.GetCurrencyRateById(IdCurrencyRates.Value);
            if (list.Count > 0)
            {
                txtCurrencyRates.Text = Validation.GetSafeString(list[0].CurrencyRates);
                txtDiscription.Text = list[0].Discription;
                dtCurrency.Value = list[0].CreatedDateTime.Value;
            }
        }
    }
}
