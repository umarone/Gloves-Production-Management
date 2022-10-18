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

using MetroFramework.Forms;
using Accounts.Common;

namespace Accounts.UI
{
    public partial class frmUsers : MetroForm
    {        
        Guid IdUser;
        public frmUsers()
        {
            InitializeComponent();
        }
        private void frmUsers_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.grdUsers.AutoGenerateColumns = false;
            FillCompanies();
            FillUsers();
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
        private void FillUsers()
        {
            var manager = new UsersBLL();
            List<UsersEL> list = manager.GetAllUsers();
            if(list.Count > 0)
            {
                grdUsers.DataSource = list;
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IsActive)
                {
                    grdUsers.Rows[i].Cells["colUserStatus"].Value = false;
                }
                else if (!list[i].IsActive)
                {
                    grdUsers.Rows[i].Cells["colUserStatus"].Value = true;
                }
            }
        }
        private bool ValidateControls()
        {
            bool Status = true;
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                //lblMsgStatus.Text = "User Name Missing";
                Status = false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                //lblMsgStatus.Text = "Password Missing";
                Status = false;
            }
            return Status;
        }
        private void ClearControls()
        {
            IdUser = Guid.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtNIC.Text = string.Empty;
            txtAddress.Text = string.Empty;
            chkSuspend.Checked = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var manager = new UsersBLL();
            try
            {
                UsersEL oelUser = new UsersEL();
                if (ValidateControls())
                {
                    oelUser.UserId = IdUser;
                    oelUser.IdCompany = Validation.GetSafeGuid(cbxCompany.SelectedValue);
                    oelUser.UserName = txtUserName.Text;
                    oelUser.Password = txtPassword.Text;
                    oelUser.FirstName = txtFirstName.Text;
                    oelUser.LastName = txtLastName.Text;
                    oelUser.Cnic = txtNIC.Text;
                    oelUser.Contact = txtContact.Text;
                    oelUser.Address = txtAddress.Text;
                    if (chkSuspend.Checked)
                    {
                        oelUser.IsActive = false;
                    }
                    else
                    {
                        oelUser.IsActive = true;
                    }
                    oelUser.CreatedDateTime = dtUserCreation.Value;

                    if (IdUser == Guid.Empty)
                    {
                        oelUser.UserId = Guid.Empty;
                        if (manager.CreateUsers(oelUser).IsSuccess)
                        {
                            //lblMsgStatus.Text = "User Saved SuccessFully";
                            MessageBox.Show("User Successfully Created....");
                            ClearControls();
                            FillUsers();
                        }
                    }
                    else
                    {
                        oelUser.UserId = IdUser;
                        if (manager.UpdateUsers(oelUser).IsSuccess)
                        {
                            //lblMsgStatus.Text = "User Updated SuccessFully";
                            MessageBox.Show("User Successfully Updated....");
                            ClearControls();
                            FillUsers();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //lblMsgStatus.Text = "Some Problem Occured While Saving Record";
            }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var manager = new UsersBLL();
            if (MessageBox.Show("Deleting ?", "Delete User", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
            {
                UsersEL oelUser = new UsersEL();
                oelUser.UserId = IdUser;
                manager.DeleteUsers(oelUser);
                ClearControls();
            }
        }

        private void grdPersons_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                e.Value = "Edit";
            }
        }

        private void grdPersons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                IdUser = Validation.GetSafeGuid(grdUsers.Rows[e.RowIndex].Cells["colIdUser"].Value);
                GetUserById(IdUser);
            }
        }

        private void GetUserById(Guid IdUser)
        {
            var manager = new UsersBLL();
            UsersEL oelUser = manager.GetUserById(IdUser)[0];
            if (oelUser != null)
            {
                txtUserName.Text = oelUser.UserName;
                txtPassword.Text = oelUser.Password;
                txtFirstName.Text = oelUser.FirstName;
                txtLastName.Text = oelUser.LastName;
                txtNIC.Text = oelUser.Cnic;
                txtContact.Text = oelUser.Contact;
                txtAddress.Text = oelUser.Address;
                dtUserCreation.Value = Convert.ToDateTime(oelUser.CreatedDateTime);

                if (oelUser.IsActive)
                {
                    chkSuspend.Checked = false;
                }
                else
                {
                    chkSuspend.Checked = true;
                }

                cbxCompany.SelectedValue = oelUser.IdCompany;
            }
        }
    }
}
