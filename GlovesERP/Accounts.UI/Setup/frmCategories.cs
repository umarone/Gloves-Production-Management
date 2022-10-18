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
    public partial class frmCategories : MetroForm
    {
        Guid IdCategory = Guid.Empty;
        frmFindCategories frmCategory = null;
        public frmCategories()
        {
            InitializeComponent();
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            GetMaxCategoryCode();
        }
        private void GetMaxCategoryCode()
        {
            var Manager = new CategoryBLL();
            txtCategoryCode.Text = Validation.GetSafeString(Manager.GetMaxCategoryCode(Operations.IdCompany));
        }
        private bool ValidateControls()
        {
            bool isValid = true;
            if (chkGloves.Checked == false && chkGarments.Checked == false)
            {
                MessageBox.Show("Please Select Boss Category :");
                isValid = false;
            }
            return isValid;
        }
        private void ClearControls()
        {
            IdCategory = Guid.Empty;
            //txtCategoryCode.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
            chkGarments.Checked = false;
            chkGloves.Checked = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            CategoryEL oelCategory = new CategoryEL();
            var Manager = new CategoryBLL();
            if (ValidateControls())
            {
                if (IdCategory == Guid.Empty)
                {
                    oelCategory.IdCategory = Guid.NewGuid();
                }
                else
                {
                    oelCategory.IdCategory = IdCategory;
                }

                oelCategory.IdCompany = Operations.IdCompany;
                oelCategory.CategoryCode = txtCategoryCode.Text;                
                oelCategory.CategoryName = txtCategoryName.Text;
                oelCategory.SubCategoryName = cbxCategoryTye.Text;
                oelCategory.CreatedDateTime = CategoryDate.Value;
                if (chkGloves.Checked)
                {
                    oelCategory.BossCategory = 1;
                }
                else if (chkGarments.Checked)
                {
                    oelCategory.BossCategory = 2;
                }
                oelCategory.IsActive = chkActive.Checked;
                oelCategory.UserId= Operations.UserID;


                if (IdCategory == Guid.Empty)
                {
                    if (Manager.CreateCategory(oelCategory).IsSuccess)
                    {
                        GetMaxCategoryCode();
                        ClearControls();
                    }
                }
                else
                {
                    if (Manager.UpdateCategory(oelCategory).IsSuccess)
                    {
                        GetMaxCategoryCode();
                        ClearControls();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var manager = new CategoryBLL();
            if (manager.DeleteCategory(IdCategory).IsSuccess)
            {
                GetMaxCategoryCode();
                ClearControls();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearControls();
            frmCategory = new frmFindCategories();
            frmCategory.ExecuteFindCategoryEvent += new frmFindCategories.FindCategoryDelegate(frmCategory_ExecuteFindCategoryEvent);
            frmCategory.ShowDialog();
        }

        void frmCategory_ExecuteFindCategoryEvent(object Sender, CategoryEL oelCategory)
        {
            IdCategory = oelCategory.IdCategory;
            GetCategory(IdCategory);
        }
        private void GetCategory(Guid Id)
        {
            var manager = new CategoryBLL();
            List<CategoryEL> list = manager.GetCategoryById(Id);
            if (list.Count > 0)
            {
                txtCategoryCode.Text = list[0].CategoryCode.ToString();
                txtCategoryName.Text = list[0].CategoryName;
                cbxCategoryTye.SelectedIndex = cbxCategoryTye.FindString(list[0].SubCategoryName);
                if (list[0].BossCategory == 1)
                {
                    chkGloves.Checked = true;
                }
                else if (list[0].BossCategory == 2)
                {
                    chkGarments.Checked = true;
                }
                chkActive.Checked = Convert.ToBoolean(list[0].IsActive);
                CategoryDate.Value =  Convert.ToDateTime(list[0].CreatedDateTime);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkTannery_CheckedChanged(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroCheckBox chk = sender as MetroFramework.Controls.MetroCheckBox;
            if (chk != null)
            {
                 if (chk.Name == "chkGloves")
                {
                    chkGarments.Checked = false;
                }
                else if (chk.Name == "chkGarments")
                {
                    chkGloves.Checked = false;
                }
            }
        }

        private void cbxCategoryTye_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
