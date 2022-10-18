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
using Accounts.EL;

using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmUsersRoles : MetroForm
    {
        public frmUsersRoles()
        {
            InitializeComponent();
        }

        private void frmUsersRoles_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            FillData();
        }
        private void FillData()
        {
            FillUsers();
            FillRoles();
        }
        private void FillUsers()
        {
            var manager = new UsersBLL();
            List<UsersEL> list = manager.GetAllUsers();
            if (list.Count > 0)
            {
                list.Insert(0, new UsersEL() { UserId = Guid.Empty, UserName = "Select User" });

                cbxUsers.DataSource = list;
                cbxUsers.DisplayMember = "UserName";
                cbxUsers.ValueMember = "UserId";
                cbxUsers.SelectedIndex = 0;
            }
        }
        private void FillRoles()
        {
            var manager = new RoleBLL();
            List<RoleEL> list = manager.GetAllRoles();

            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    grdUserRoles.Rows.Add();
                    grdUserRoles.Rows[i].Cells["colIdRole"].Value = list[i].IdRole;
                    grdUserRoles.Rows[i].Cells["colIdUserRole"].Value = Guid.Empty;
                    grdUserRoles.Rows[i].Cells["colRoleName"].Value = list[i].RoleName;
                }
            }    
        }
        private void cbxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var manager = new UserRolesBLL();
            if (cbxUsers.SelectedIndex > 0)
            {
                List<UserRolesEL> list = manager.GetUserRolesById(Validation.GetSafeGuid(cbxUsers.SelectedValue));
                if (list.Count > 0)
                {
                    grdUserRoles.Rows.Clear();
                    for (int i = 0; i < list.Count; i++)
                    {
                        grdUserRoles.Rows.Add();
                        grdUserRoles.Rows[i].Cells["colIdRole"].Value = list[i].IdRole;
                        grdUserRoles.Rows[i].Cells["colIdUserRole"].Value = list[i].IdUserRole;
                        grdUserRoles.Rows[i].Cells["colRoleName"].Value = list[i].RoleName;
                        if (list[i].IdUserRole != Guid.Empty)
                        {
                            grdUserRoles.Rows[i].Cells["colRoleRight"].Value = true;
                        }
                        else
                        {
                            grdUserRoles.Rows[i].Cells["colRoleRight"].Value = false;
                        }
                    }
                }
            }
            else if (grdUserRoles.Rows.Count > 0)
            {
                grdUserRoles.Rows.Clear();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<UserRolesEL> listUserRoles = new List<UserRolesEL>();
            var manager = new UserRolesBLL();
            if (Validation.GetSafeGuid(cbxUsers.SelectedValue) != Guid.Empty)
            {
                for (int i = 0; i < grdUserRoles.Rows.Count; i++)
                {
                    UserRolesEL oelUserRole = new UserRolesEL();
                    oelUserRole.UserId = Validation.GetSafeGuid(cbxUsers.SelectedValue);
                    oelUserRole.IdRole = Validation.GetSafeGuid(grdUserRoles.Rows[i].Cells["colIdRole"].Value);
                    if (Validation.GetSafeGuid(grdUserRoles.Rows[i].Cells["colIdUserRole"].Value) == Guid.Empty)
                    {
                        oelUserRole.IdUserRole = Guid.NewGuid();
                    }
                    else
                    {
                        oelUserRole.IdUserRole = Validation.GetSafeGuid(grdUserRoles.Rows[i].Cells["colIdUserRole"].Value);
                    }
                    if (Validation.GetSafeBooleanNullable(grdUserRoles.Rows[i].Cells["colRoleRight"].Value) == true)
                    {
                        oelUserRole.RoleAction = "Assign";
                    }
                    else
                    {
                        oelUserRole.RoleAction = "Remove";
                    }
                    oelUserRole.CreatedDateTime = DateTime.Now;
                    listUserRoles.Add(oelUserRole);
                }
                if (manager.AssignRoles(listUserRoles).IsSuccess)
                {
                    MessageBox.Show("Roles Assigned For Selected User");
                    cbxUsers_SelectedIndexChanged(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Select User First For Roles Rights");
            }
        }

        private void chkUserRoles_CheckedChanged(object sender, EventArgs e)
        {
            //for (int i = 0; i < grdUserRoles.Rows.Count; i++)
            //{
            //    grdUserRoles.Rows[i].Cells["colRoleRight"].Value = chkUserRoles.Checked;
            //}
        }

        private void grdUserRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdUserRoles.Rows[e.RowIndex].Cells["colRoleRight"].Value !=null)
            {
                for (int i = 0; i < grdUserRoles.Rows.Count; i++)
                {
                    if (e.RowIndex != i)
                    {
                        grdUserRoles.Rows[i].Cells["colRoleRight"].Value = false;
                    }
                }
            }
        }
    }
}
