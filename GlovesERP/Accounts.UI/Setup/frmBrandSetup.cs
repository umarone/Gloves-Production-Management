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
    public partial class frmBrandSetup : MetroForm
    {
        Guid IdBrand = Guid.Empty;
        frmFindBrand frmBrand = null;
        frmFindAccounts frmfindaccounts;
        string AccountNo;
        public frmBrandSetup()
        {
            InitializeComponent();
        }
        private void frmBrandSetup_Load(object sender, EventArgs e)
        {
            GetMaxBrandCode();
        }
        private void GetMaxBrandCode()
        {
            var Manager = new BrandBLL();
            txtBrandCode.Text = Validation.GetSafeString(Manager.GetMaxBrandCode(Operations.IdCompany));
        }
        private bool Validate()
        {
            bool isValid = true;
            if (txtBrandName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Brand Code...");
                isValid = false;
            }
            else if (txtAccountNo.Text == string.Empty)
            {
                MessageBox.Show("Please Select Customer...");
                isValid = false;
            }
            return isValid;
        }
        private void ClearControls()
        {
            IdBrand = Guid.Empty;
            txtBrandCode.Text = string.Empty;
            txtBrandName.Text = string.Empty;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            BrandEL oelBrand = new BrandEL();
            var Manager = new BrandBLL();
            if (Validate())
            {
                if (IdBrand == Guid.Empty)
                {
                    oelBrand.IdBrand = Guid.NewGuid();
                }
                else
                {
                    oelBrand.IdBrand = IdBrand;
                }

                oelBrand.IdCompany = Operations.IdCompany;
                oelBrand.BrandCode = txtBrandCode.Text;
                oelBrand.AccountNo = AccountNo;
                oelBrand.BrandName = txtBrandName.Text;
                oelBrand.CreatedDateTime = BrandDate.Value;
                oelBrand.IsActive = chkActive.Checked;
                oelBrand.UserId= Operations.UserID;


                if (IdBrand == Guid.Empty)
                {
                    if (Manager.CreateBrand(oelBrand).IsSuccess)
                    {
                        GetMaxBrandCode();
                        ClearControls();
                    }
                }
                else
                {
                    if (Manager.UpdateBrand(oelBrand).IsSuccess)
                    {
                        GetMaxBrandCode();
                        ClearControls();
                    }
                }
            }
        }        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmBrand = new frmFindBrand();
            frmBrand.SearchBy = string.Empty;
            frmBrand.ExecuteFindBrandEvent += new frmFindBrand.FindBrandDelegate(frmBrand_ExecuteFindBrandEvent);
            frmBrand.ShowDialog();
        }
        void frmBrand_ExecuteFindBrandEvent(object Sender, BrandEL oelBrand)
        {
            IdBrand = oelBrand.IdBrand;
            GetBrand(IdBrand);
        }
        private void GetBrand(Guid Id)
        {
            var manager = new BrandBLL();
            List<BrandEL> list = manager.GetBrandById(Id);
            if (list.Count > 0)
            {
                txtBrandCode.Text = list[0].BrandCode.ToString();
                txtAccountNo.Text = list[0].AccountName;
                AccountNo = list[0].AccountNo;
                txtBrandName.Text = list[0].BrandName;
                chkActive.Checked = Convert.ToBoolean(list[0].IsActive);
                BrandDate.Value = Convert.ToDateTime(list[0].CreatedDateTime);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtAccountNo_ButtonClick(object sender, EventArgs e)
        {
            frmfindaccounts = new frmFindAccounts();
            frmfindaccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindaccounts_ExecuteFindAccountEvent);
            frmfindaccounts.ShowDialog();
        }
        void frmfindaccounts_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            txtAccountNo.Text = oelAccount.AccountName;
            AccountNo = oelAccount.AccountNo;
        }
        private void btnSearch_Click_1(object sender, EventArgs e)
        {

        }
    }
}
