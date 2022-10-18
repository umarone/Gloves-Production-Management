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
    public partial class frmFindGroups : MetroForm
    {
        AccountsBLL objAccounts = new AccountsBLL();
        GroupsEL oelGroup = null;                
        public delegate void FindGroupDelegate(Object Sender, GroupsEL oelGroup);
        public event FindGroupDelegate ExecuteFindGroupEvent;
        public string SearchBy { get; set; }
        public string AccountNo { get; set; }
        public frmFindGroups()
        {
            InitializeComponent();
        }

        private void frmFindGroups_Load(object sender, EventArgs e)      
        {
            this.grdFindGroups.AutoGenerateColumns = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            if (SearchBy == string.Empty)
            {
                PopulateGroups();
            }
        }
         private void PopulateGroups()
        {
            var manager = new GroupsBLL();
            List<GroupsEL> list = manager.GetAllGroups(Operations.IdCompany);
            if (list.Count > 0)
            {
                grdFindGroups.DataSource = list;
            }
            else
            {
                grdFindGroups.DataSource = null;
            }
        }
         private void grdFindGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (grdFindGroups.CurrentRow != null)
                {
                    int RowIndex = grdFindGroups.CurrentRow.Index;
                    oelGroup= new GroupsEL();
                    oelGroup.IdGroup = Validation.GetSafeGuid(grdFindGroups.Rows[RowIndex].Cells[0].Value);
                    oelGroup.GroupCode = Validation.GetSafeString(grdFindGroups.Rows[RowIndex].Cells[1].Value);
                    oelGroup.GroupName = grdFindGroups.Rows[RowIndex].Cells[2].Value.ToString();                  
                    this.Close();
                }
            }
            else
            {
                txtID.Focus();
            }

        }
         private void grdFindGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            oelGroup = new GroupsEL();
            oelGroup.IdGroup = Validation.GetSafeGuid(grdFindGroups.Rows[e.RowIndex].Cells[0].Value);
            oelGroup.GroupCode = Validation.GetSafeString(grdFindGroups.Rows[e.RowIndex].Cells[1].Value);
            oelGroup.GroupName = Validation.GetSafeString(grdFindGroups.Rows[e.RowIndex].Cells[2].Value);
            this.Close();
        }

        private void frmFindGroups_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (oelGroup != null)
            {
                ExecuteFindGroupEvent(sender, oelGroup);
            }
        }
        private void frmFindGroups_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                grdFindGroups.Focus();
            }
        }
    }
}
