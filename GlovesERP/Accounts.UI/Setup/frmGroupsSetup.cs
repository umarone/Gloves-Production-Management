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
    public partial class frmGroupsSetup : MetroForm
    {
        Guid IdGroup = Guid.Empty;
        frmStockAccounts frmstockaccounts;
        frmFindGroups frmfindgroups;
        ItemsEL oelItem;
        public frmGroupsSetup()
        {
            InitializeComponent();
        }
        private void frmGroupsSetup_Load(object sender, EventArgs e)
        {
            GetMaxGroupCode();
        }
        private void GetMaxGroupCode()
        {
            var Manager = new GroupsBLL();
            txtGroupCode.Text = Validation.GetSafeString(Manager.GetMaxGroupCode(Operations.IdCompany));
        }
        private bool ValidateControls()
        {
            bool isValid = true;
            if (txtGroupName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Group Name...");
                isValid = false;
            }
            return isValid;
        }
        private void ClearControls()
        {
            IdGroup = Guid.Empty;
            txtGroupCode.Text = string.Empty;
            txtGroupName.Text = string.Empty;
            chkMandatory.Checked = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            GroupsEL oelGroup = new GroupsEL();
            var Manager = new GroupsBLL();
            if (ValidateControls())
            {
                if (IdGroup == Guid.Empty)
                {
                    oelGroup.IdGroup = Guid.NewGuid();
                }
                else
                {
                    oelGroup.IdGroup = IdGroup;
                }

                oelGroup.IdCompany = Operations.IdCompany;
                oelGroup.GroupCode = txtGroupCode.Text;
                oelGroup.GroupName = txtGroupName.Text;
                oelGroup.CreatedDateTime = BrandDate.Value;
                oelGroup.IsMandatory = chkMandatory.Checked;
                oelGroup.IsActive = chkActive.Checked;
                oelGroup.UserId = Operations.UserID;


                if (IdGroup == Guid.Empty)
                {
                    if (Manager.CreateGroup(oelGroup).IsSuccess)
                    {
                        ClearControls();
                        GetMaxGroupCode();
                    }
                }
                else
                {
                    if (Manager.UpdateGroup(oelGroup).IsSuccess)
                    {
                        ClearControls();
                        GetMaxGroupCode();
                    }
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtSearchStock_ButtonClick(object sender, EventArgs e)
        {
            frmstockaccounts = new frmStockAccounts();
            frmstockaccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockaccounts_ExecuteFindStockAccountEvent);
            frmstockaccounts.ShowDialog();
        }
        void frmstockaccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            if (oelItems != null)
            {
                oelItem = new ItemsEL();
                oelItem.IdItem = oelItems.IdItem;
                oelItem.ItemNo = oelItems.ItemNo;
                txtSearchStock.Text = oelItems.ItemName;
                oelItem.ItemName = oelItems.ItemName;
                oelItem.PackingSize = oelItems.PackingSize;
            }
        }
        private void btnAddItems_Click(object sender, EventArgs e)
        {
            if (oelItem != null)
            {
                grdGroupItems.Rows.Add();
                grdGroupItems.Rows[grdGroupItems.Rows.Count - 1].Cells["colIdItem"].Value = oelItem.IdItem;
                grdGroupItems.Rows[grdGroupItems.Rows.Count - 1].Cells["colItemCode"].Value = oelItem.ItemNo;
                grdGroupItems.Rows[grdGroupItems.Rows.Count - 1].Cells["colPackingSize"].Value = oelItem.PackingSize;
                grdGroupItems.Rows[grdGroupItems.Rows.Count - 1].Cells["colName"].Value = oelItem.ItemName;
                txtSearchStock.Text = string.Empty;
            }
        }
        private void grdGroupItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                e.Value = "Delete";
            }
        }
        private void btnSaveGroupItems_Click(object sender, EventArgs e)
        {
            if (grdGroupItems.Rows.Count > 0 && IdGroup != Guid.Empty)
            {
                var manager = new GroupsBLL();
                /// Create Items List Here....
                List<ItemsEL> list = new List<ItemsEL>();
                for (int i = 0; i < grdGroupItems.Rows.Count; i++)
                {
                    ItemsEL oelCreateItems = new ItemsEL();
                    oelCreateItems.IdItem = Validation.GetSafeGuid(grdGroupItems.Rows[i].Cells["colIdItem"].Value);
                    list.Add(oelCreateItems);
                }
                if (manager.UpdateItemsByGroup(IdGroup, list))
                {
                    MessageBox.Show("All Items Updated....");
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmfindgroups = new frmFindGroups();
            frmfindgroups.SearchBy = "";
            frmfindgroups.ExecuteFindGroupEvent += new frmFindGroups.FindGroupDelegate(frmfindgroups_ExecuteFindGroupEvent);
            frmfindgroups.ShowDialog();
        }
        void frmfindgroups_ExecuteFindGroupEvent(object Sender, GroupsEL oelGroup)
        {
            if (oelGroup != null)
            {
                IdGroup = oelGroup.IdGroup;
                GetGroupById();
                GetItemsByGroup();
            }
        }
        private void GetGroupById()
        {
            var manager = new GroupsBLL();
            List<GroupsEL> list = manager.GetGroupById(IdGroup);
            if (list.Count > 0)
            {
                chkMandatory.Checked = list[0].IsMandatory.Value;
                txtGroupCode.Text = list[0].GroupCode;
                txtGroupName.Text = list[0].GroupName;
            }
        }
        private void GetItemsByGroup()
        {
            var manager = new GroupsBLL();
            List<ItemsEL> list = manager.GetItemsByGroup(IdGroup);
            if (list.Count > 0)
            {
                grdGroupItems.Rows.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    grdGroupItems.Rows.Add();
                    grdGroupItems.Rows[i].Cells["colIdItem"].Value = list[i].IdItem;
                    grdGroupItems.Rows[i].Cells["colItemCode"].Value = list[i].ItemNo;
                    grdGroupItems.Rows[i].Cells["colPackingSize"].Value = list[i].PackingSize;
                    grdGroupItems.Rows[i].Cells["colName"].Value = list[i].ItemName;
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            grdGroupItems.Rows.Clear();
        }
        private void grdGroupItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var manager = new GroupsBLL();
                /// Create Items List Here....
                List<ItemsEL> list = new List<ItemsEL>();
                ItemsEL oelCreateItems = new ItemsEL();
                oelCreateItems.IdItem = Validation.GetSafeGuid(grdGroupItems.Rows[e.RowIndex].Cells["colIdItem"].Value);
                list.Add(oelCreateItems);

                if (manager.UpdateItemsByGroup(null, list))
                {
                    MessageBox.Show("Item Is DeAttached With this Group....");
                    grdGroupItems.Rows.RemoveAt(e.RowIndex);
                }

            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var manager = new GroupsBLL();
            if (manager.DeleteGroups(IdGroup))
            {
                MessageBox.Show("Group Deleted Successfully....");
                ClearControls();
                GetMaxGroupCode();
            }
        }
    }
}
