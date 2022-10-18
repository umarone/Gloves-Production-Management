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
    public partial class frmCompany : MetroForm
    {
        Guid IdCompany;
        public frmCompany()
        {
            InitializeComponent();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            grdCompanies.AutoGenerateColumns = false;
            FillCompanies();
        }
        private void FillCompanies()
        {
            var manager = new CompanyBLL();
            CompanyEL oelCompany = new CompanyEL();
            List<CompanyEL> list = manager.GetAllCompanies();
            if (list.Count > 0)
            {
                grdCompanies.DataSource = list;
            }
        }
        private void ClearControls()
        {
            txtCompanyName.Text = string.Empty;
            txtDiscription.Text = string.Empty;

            IdCompany = Guid.Empty;
            grdCompanies.DataSource = null;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            CompanyEL oelCompany = new CompanyEL();

            if (IdCompany == Guid.Empty)
            {
                oelCompany.IdCompany = Guid.NewGuid();
            }
            else
            {
                oelCompany.IdCompany = IdCompany;
            }
            oelCompany.CompanyName = txtCompanyName.Text;
            oelCompany.CreatedDateTime = CDate.Value;
            oelCompany.Discription = txtDiscription.Text;
            if (chkSuspend.Checked)
            {
                oelCompany.IsActive = false;
            }
            else
            {
                oelCompany.IsActive = true;
            }
            if (IdCompany == Guid.Empty)
            {
                var manager = new CompanyBLL();
                if (manager.InsertCompany(oelCompany).IsSuccess)
                {
                    MessageBox.Show("New Company Created Successfully");
                    ClearControls();
                    FillCompanies();
                }
            }
            else
            {
                var manager = new CompanyBLL();
                if (manager.UpdateCompany(oelCompany).IsSuccess)
                {
                    MessageBox.Show("Company Updated Successfully");
                    ClearControls();
                    FillCompanies();
                }
            }
        }

        private void grdCompanies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            { 
                IdCompany = Validation.GetSafeGuid(grdCompanies.Rows[e.RowIndex].Cells["colIdCompany"].Value);
                txtCompanyName.Text = Validation.GetSafeString(grdCompanies.Rows[e.RowIndex].Cells["colCompanyName"].Value);
                txtDiscription.Text = Validation.GetSafeString(grdCompanies.Rows[e.RowIndex].Cells["colDiscription"].Value);
                CDate.Value = Convert.ToDateTime(grdCompanies.Rows[e.RowIndex].Cells["ColCreationDate"].Value); 
            }
            else if (e.ColumnIndex == 5)
            {
                var manager = new CompanyBLL();
                if (manager.DeleteCompany(IdCompany).IsSuccess)
                {
                    MessageBox.Show("Company Is InActive Now");
                    ClearControls();
                    FillCompanies();
                }
                //Delete Company Here ....
            }
        }
        private void grdCompanies_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                e.Value = "Edit";
            }
            if (e.ColumnIndex == 5)
            {
                e.Value = "Delete";
            }
        }
    }
}
