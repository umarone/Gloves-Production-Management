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
    public partial class frmFindCategories : MetroForm
    {
        AccountsBLL objAccounts = new AccountsBLL();
        CategoryEL oelCategory = null;
        public delegate void FindCategoryDelegate(Object Sender, CategoryEL oelCategory);
        public event FindCategoryDelegate ExecuteFindCategoryEvent;
        public frmFindCategories()
        {
            InitializeComponent();
        }

        private void frmFindCategories_Load(object sender, EventArgs e)
        {
            this.grdFindCategories.AutoGenerateColumns = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PopulateCategories();
        }
        private void PopulateCategories()
        {
            var manager = new CategoryBLL();
            List<CategoryEL> list = manager.GetAllCategories(Operations.IdCompany);
            if (list.Count > 0)
            {
                grdFindCategories.DataSource = list;
            }
            else
            {
                grdFindCategories.DataSource = null;
            }
        }

        private void grdFindCategories_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (grdFindCategories.CurrentRow != null)
                {
                    int RowIndex = grdFindCategories.CurrentRow.Index;
                    oelCategory = new CategoryEL();
                    oelCategory.IdCategory = Validation.GetSafeGuid(grdFindCategories.Rows[RowIndex].Cells[0].Value);
                    oelCategory.CategoryCode = Validation.GetSafeString(grdFindCategories.Rows[RowIndex].Cells[1].Value);
                    oelCategory.CategoryName = grdFindCategories.Rows[RowIndex].Cells[2].Value.ToString();                  
                    this.Close();
                }
            }
            else
            {
                txtID.Focus();
            }
        }
        private void grdFindCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            oelCategory = new CategoryEL();
            oelCategory.IdCategory = Validation.GetSafeGuid(grdFindCategories.Rows[e.RowIndex].Cells[0].Value);
            oelCategory.CategoryCode = Validation.GetSafeString(grdFindCategories.Rows[e.RowIndex].Cells[1].Value);
            oelCategory.CategoryName = grdFindCategories.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.Close();
        }

        private void frmFindCategories_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (oelCategory != null)
            {
                ExecuteFindCategoryEvent(sender, oelCategory);
            }
        }

        private void frmFindCategories_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            var manager = new CategoryBLL();
            if (txtID.Text != string.Empty)
            {
                List<CategoryEL> list = manager.SearchCategoriesByCategoryName(txtID.Text, Operations.IdCompany);
                PopulateCategoriesBySearch(list);
            }
            else
            {
                grdFindCategories.DataSource = null;
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                grdFindCategories.Focus();
            }
        }
        private void PopulateCategoriesBySearch(List<CategoryEL> list)
        {
            if (grdFindCategories.Rows.Count > 1)
            {
                grdFindCategories.DataSource = null;
            }
            grdFindCategories.DataSource = list;
        }
    }
}
