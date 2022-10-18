using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.BLL;
using Accounts.Common;
using Accounts.UI.UserControls;
using Accounts.EL;
using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmFindBrand : MetroForm
    {
        AccountsBLL objAccounts = new AccountsBLL();
        BrandEL oelBrand = null;
        public delegate void FindBrandDelegate(Object Sender, BrandEL oelBrand);
        public event FindBrandDelegate ExecuteFindBrandEvent;
        public string SearchBy { get; set; }
        public string AccountNo { get; set; }
        public frmFindBrand()
        {
            InitializeComponent();
        }

        private void frmFindBrand_Load(object sender, EventArgs e)      
        {
            this.grdFindBrand.AutoGenerateColumns = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            if (SearchBy == string.Empty)
            {
                PopulateBrands();
            }
            else
            {
                PopulateBrandsByCustomers();
            }
        }
         private void PopulateBrands()
        {
            var manager = new BrandBLL();
            List<BrandEL> list = manager.GetAllBrands(Operations.IdCompany);
            if (list.Count > 0)
            {
                grdFindBrand.DataSource = list;
            }
            else
            {
                grdFindBrand.DataSource = null;
            }
        }
         private void PopulateBrandsByCustomers()
         {
             var manager = new BrandBLL();
             List<BrandEL> list = manager.GetAllBrandsByCustomer(Operations.IdCompany,AccountNo);
             if (list.Count > 0)
             {
                 grdFindBrand.DataSource = list;
             }
             else
             {
                 grdFindBrand.DataSource = null;
             }
         }
         private void grdFindBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (grdFindBrand.CurrentRow != null)
                {
                    int RowIndex = grdFindBrand.CurrentRow.Index;
                    oelBrand= new BrandEL();
                    oelBrand.IdBrand = Validation.GetSafeGuid(grdFindBrand.Rows[RowIndex].Cells[0].Value);
                    oelBrand.BrandCode = Validation.GetSafeString(grdFindBrand.Rows[RowIndex].Cells[1].Value);
                    oelBrand.BrandName = grdFindBrand.Rows[RowIndex].Cells[3].Value.ToString();                  
                    this.Close();
                }
            }
            else
            {
                txtID.Focus();
            }

        }
         private void grdFindBrand_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            oelBrand = new BrandEL();
            oelBrand.IdBrand = Validation.GetSafeGuid(grdFindBrand.Rows[e.RowIndex].Cells[0].Value);
            oelBrand.BrandCode = Validation.GetSafeString(grdFindBrand.Rows[e.RowIndex].Cells[1].Value);
            oelBrand.BrandName = Validation.GetSafeString(grdFindBrand.Rows[e.RowIndex].Cells[3].Value);
            this.Close();
        }

        private void frmFindBrand_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (oelBrand != null)
            {
                ExecuteFindBrandEvent(sender, oelBrand);
            }
        }
        private void frmFindBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmFindBrand_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                grdFindBrand.Focus();
            }
        }
    }
}
