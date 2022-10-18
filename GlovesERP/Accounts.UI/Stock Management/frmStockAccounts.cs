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
    public partial class frmStockAccounts : MetroForm
    {
        public string SearchText { get; set; }
        public string SearchType { get; set; }
        public int? Boss { get; set; }
        public int SaleType { get; set; }
        AccountsBLL objAccounts = new AccountsBLL();
        ItemsEL Items = null;
        public delegate void FindStockAccountDelegate(Object Sender,ItemsEL oelItems);
        public event FindStockAccountDelegate ExecuteFindStockAccountEvent;
        frmFindProductByBatchAndExpiry frmFind = null;
        public frmStockAccounts()
        {
            InitializeComponent();
        }
        private void PopulateCategories()
        {
            var manager = new CategoryBLL();
            List<CategoryEL> list = manager.GetAllCategories(Operations.IdCompany);
            list.Insert(0, new CategoryEL { IdCategory = Guid.Empty, CategoryName = "Select Category" });

            cbxCategories.DataSource = list;
            cbxCategories.DisplayMember = "CategoryName";
            cbxCategories.ValueMember = "IdCategory";

            cbxCategories.SelectedIndex = 0;

        }
        private void frmStockAccounts_Load(object sender, EventArgs e)
        {
            grdFindAccount.AutoGenerateColumns = false;
            txtName.Text = SearchText;
            txtName.SelectionStart = 1;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //PopulateAccountsHeader();
            PopulateCategories();
        }
        private void PopulateAccountsByCategory(int Id)
        {
            //List<ChartsOfAccountsEL> list = objChartOfAccount.GetAccountsByCategory(Id);
            //List<ChartsOfAccountsEL> list = objAccounts.GetAccountsByCategory(Id);
            //grdFindAccount.DataSource = list;
        }
        private void PopulateAccountsByAccountNo(List<ItemsEL> list)
        {
            if (grdFindAccount.Rows.Count > 1)
            {
                grdFindAccount.DataSource = null;
            }
            grdFindAccount.DataSource = list;
        }
        private void cbxSubCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCategories.SelectedIndex != -1 && cbxCategories.SelectedIndex > 0)
            {
                PopulateAccountsByCategory(Convert.ToInt32(cbxCategories.SelectedValue));
            }
        }              
        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            //var manager = new ChartsOfAccountsBLL();
            //var manager = new AccountsBLL();
            var manager = new ItemsBLL();
            if (txtID.Text != string.Empty)
            {
                List<ItemsEL> list = manager.SearchStockByProductNo(Validation.GetSafeLong(txtID.Text),Operations.IdCompany);
                PopulateAccountsByAccountNo(list);
            }
            else
            {
                grdFindAccount.DataSource = null;
            }
        }
        private void grdFindAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (grdFindAccount.CurrentRow != null)
                {
                    int RowIndex = grdFindAccount.CurrentRow.Index;
                    Items = new ItemsEL();
                    Items.IdItem = Validation.GetSafeGuid(grdFindAccount.Rows[RowIndex].Cells[0].Value);
                    Items.ItemNo = Validation.GetSafeString(grdFindAccount.Rows[RowIndex].Cells[1].Value);
                    Items.ProductCode = Validation.GetSafeString(grdFindAccount.Rows[RowIndex].Cells[2].Value);
                    Items.PackingSize = Validation.GetSafeString(grdFindAccount.Rows[RowIndex].Cells[3].Value);
                    Items.ItemName = grdFindAccount.Rows[RowIndex].Cells[4].Value.ToString();                    
                    Items.BatchNo = Validation.GetSafeString(grdFindAccount.Rows[RowIndex].Cells[5].Value);
                    //Items.PackingSize = Validation.GetSafeString(grdFindAccount.Rows[RowIndex].Cells[5].Value);                   
                    Items.SubCategoryName = cbxCategories.Text;
                    //if (SearchType == "SaleInvoiceVoucher" && SaleType != 3 && SaleType != 4)
                    //{
                    //    frmFind = new frmFindProductByBatchAndExpiry();
                    //    frmFind.IdItem = Validation.GetSafeGuid(grdFindAccount.Rows[RowIndex].Cells[0].Value);
                    //    frmFind.Boss = Boss;
                    //    frmFind.ProductName = grdFindAccount.Rows[RowIndex].Cells[4].Value.ToString();
                    //    frmFind.ExecuteFindStockEvent += new frmFindProductByBatchAndExpiry.FindStockDelegate(frmFind_ExecuteFindStockEvent);
                    //    frmFind.ShowDialog();
                    //}
                    this.Close();
                }
            }
            else
            {
                txtID.Focus();
            }
        }
        private void grdFindAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Items = new ItemsEL();
            Items.IdItem = Validation.GetSafeGuid(grdFindAccount.Rows[e.RowIndex].Cells[0].Value);
            Items.ItemNo = Validation.GetSafeString(grdFindAccount.Rows[e.RowIndex].Cells[1].Value);
            Items.ProductCode = Validation.GetSafeString(grdFindAccount.Rows[e.RowIndex].Cells[2].Value);
            Items.PackingSize = Validation.GetSafeString(grdFindAccount.Rows[e.RowIndex].Cells[3].Value);
            Items.ItemName = grdFindAccount.Rows[e.RowIndex].Cells[4].Value.ToString();
            Items.BatchNo = Validation.GetSafeString(grdFindAccount.Rows[e.RowIndex].Cells[5].Value);
            //Items.PackingSize = Validation.GetSafeString(grdFindAccount.Rows[e.RowIndex].Cells[5].Value);            
            Items.SubCategoryName = cbxCategories.Text;
            //if (SearchType == "SaleInvoiceVoucher")
            //{
            //    frmFind = new frmFindProductByBatchAndExpiry();
            //    frmFind.IdItem = Validation.GetSafeGuid(grdFindAccount.Rows[e.RowIndex].Cells[0].Value);
            //    frmFind.ProductName = grdFindAccount.Rows[e.RowIndex].Cells[4].Value.ToString();
            //    frmFind.ExecuteFindStockEvent += new frmFindProductByBatchAndExpiry.FindStockDelegate(frmFind_ExecuteFindStockEvent);
            //    frmFind.ShowDialog();
            //}
            this.Close();
        }
        void frmFind_ExecuteFindStockEvent(object Sender, ItemsEL oelItems)
        {
            Items.Qty = oelItems.Qty;
        }
        private void frmAccounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Items != null)
            {
                ExecuteFindStockAccountEvent(sender,Items);
            }
        }
        private void cbxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCategories.SelectedIndex > 0)
            {
                var manager = new ItemsBLL();
                List<ItemsEL> list = manager.GetItemsByCategory(Validation.GetSafeGuid(cbxCategories.SelectedValue));
                if (list.Count > 0)
                {
                    grdFindAccount.DataSource = list;
                }
                else
                {
                    grdFindAccount.DataSource = null;
                }
            }
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            var manager = new ItemsBLL();
            if (txtName.Text != string.Empty)
            {
                List<ItemsEL> list = manager.SearchStockByProductName(txtName.Text, Operations.IdCompany);
                PopulateAccountsByAccountNo(list);
            }
            else
            {
                grdFindAccount.DataSource = null;
            }
        }
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                grdFindAccount.Focus();
            }
        }
    }
}
