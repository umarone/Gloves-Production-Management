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

namespace Accounts.UI
{
    public partial class frmLogin :MetroFramework.Forms.MetroForm
    {
        //UsersEL oelUsers = new UsersEL();
        UserRolesEL oelUsers = new UserRolesEL();
        List<UsersEL> oelUserCollection = null;
        //List<UserRolesEL> oelUserCollection = null;
        public frmLogin()
        {
            InitializeComponent();
        }
        private bool isValidData()
        {
            if (string.IsNullOrEmpty(mtxtUserName.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(mtxtPassword.Text))
            {
                return false;
            }
            return true;
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

            FillCompanies();
            this.Opacity = 100;

        }
        private void FillCompanies()
        { 
             var manager = new CompanyBLL();
            List<CompanyEL> list = manager.GetAllCompanies();
            if(list != null && list.Count > 0)
            {
                cbxCompany.DataSource = list;
                
                cbxCompany.DisplayMember = "CompanyName";
                cbxCompany.ValueMember = "IdCompany";
                
                cbxCompany.SelectedIndex = 0;
            }
        }
        private void mbtnLogin_Click(object sender, EventArgs e)
        {
            var manager = new UsersBLL();
            if (isValidData())
            {
                if (mbtnLogin.DialogResult == DialogResult.OK)
                {
                    oelUsers.UserName = mtxtUserName.Text;
                    oelUsers.Password = mtxtPassword.Text;
                    oelUsers.IdCompany = Validation.GetSafeGuid(cbxCompany.SelectedValue);

                    oelUserCollection = manager.verifyUser(oelUsers);
                    if (oelUserCollection != null && oelUserCollection.Count > 0)
                    {
                        if (!oelUserCollection[0].IsActive)
                        {
                            MessageBox.Show("User Is Blocked,Please Contact Administrator");
                            this.DialogResult = System.Windows.Forms.DialogResult.None;
                            mtxtUserName.Focus();
                            return;
                        }
                        Operations.UserID = oelUserCollection[0].UserId;
                        Operations.UserName = oelUserCollection[0].UserName;
                        Operations.IdCompany = Validation.GetSafeGuid(oelUserCollection[0].IdCompany);
                        Operations.IdRole = oelUserCollection[0].IdRole;
                        Operations.CompanyName = cbxCompany.Text;
                        Operations.BookNo = oelUserCollection[0].BookNo;
                        Operations.BookPeriod = oelUserCollection[0].BookPeriod;
                        mtxtUserName.Focus();
                        mtxtUserName.Text = "";
                        mtxtPassword.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Wrong UserName Or Password", "Login Failed", MessageBoxButtons.OKCancel);
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                        mtxtUserName.Focus();
                        mtxtPassword.Text = string.Empty;
                    }

                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                }

            }
            else
            {
                MessageBox.Show("Input UserName OR Password");
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }
        private void mbtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void mtxtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                mtxtPassword.Focus();
            }
        }
        private void mtxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //cbxCompany.Focus();
                //cbxCompany.DroppedDown = true;
                mbtnLogin.Focus();
            }
        }
        private void cbxCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //mbtnLogin.Focus();
            }
        }

        private void mtxtPassword_Click(object sender, EventArgs e)
        {

        }

        private void mtxtUserName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
