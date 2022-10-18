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
using MetroFramework.Controls;

namespace Accounts.UI
{
    public partial class frmProductLedger : MetroForm
    {
        #region Variables
        frmFindAccounts frmfindAccount;
        frmStockAccounts frmfindstock;
        Guid IdItem = Guid.Empty;
        string AccountNo = string.Empty;
        frmFindOrders frmfindOrders;
        Guid IdOrder = Guid.Empty;
        string CustomerPoNumber = "";
        int eventserial = 0;
        #endregion
        #region Form Methods And Variables
        public frmProductLedger()
        {
            InitializeComponent();
        }
        private void frmProductLedger_Load(object sender, EventArgs e)
        {
            this.grdProductLedger.AutoGenerateColumns = false;
            txtSupplier.Visible = false;
            txtPoNumber.Visible = false;
            txtStitcherName.Visible = false;
            dtStart.Visible = false;
            dtEnd.Visible = false;
        }
        #endregion
        #region Methods
        private void ClearControls()
        {
            txtSupplier.Text = string.Empty;
            txtStitcherName.Text = string.Empty;
            AccountNo = string.Empty;
            txtPoNumber.Text = string.Empty;            
        }
        #endregion
        #region Cutom Controls Events
        private void PEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                e.Handled = true;
                frmfindstock = new frmStockAccounts();
                frmfindstock.SearchText = e.KeyChar.ToString();
                frmfindstock.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmfindstock_ExecuteFindStockAccountEvent);
                frmfindstock.ShowDialog();
            }
        }
        void frmfindstock_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            PEditBox.Text = oelItems.ItemName;
            IdItem = oelItems.IdItem;
        }
        private void PEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindstock = new frmStockAccounts();
            frmfindstock.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmfindstock_ExecuteFindStockAccountEvent);
            frmfindstock.ShowDialog();
        }
        private void txtPoNumber_ButtonClick(object sender, EventArgs e)
        {
            frmfindOrders = new frmFindOrders();
            frmfindOrders.ExecuteFindOrdersEvent += new frmFindOrders.FindOrdersDelegate(frmfindOrders_ExecuteFindOrdersEvent);
            frmfindOrders.ShowDialog();
        }
        private void txtSupplier_ButtonClick(object sender, EventArgs e)
        {
            frmfindAccount = new frmFindAccounts();
            eventserial = 1;
            frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
            frmfindAccount.ShowDialog();
        }
        private void txtStitcherName_ButtonClick(object sender, EventArgs e)
        {
            frmfindAccount = new frmFindAccounts();
            eventserial = 2;
            frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
            frmfindAccount.ShowDialog();
        }
        void frmfindAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            if (eventserial == 1)
            {
                txtSupplier.Text = oelAccount.AccountName;
                AccountNo = oelAccount.AccountNo;
            }
            else
            {
                AccountNo = oelAccount.AccountNo;
                txtStitcherName.Text = oelAccount.AccountName;
            }
        }
        void frmfindOrders_ExecuteFindOrdersEvent(object Sender, OrdersEL oelOrder)
        {
            IdOrder = oelOrder.IdOrder;
            txtPoNumber.Text = oelOrder.CustomerPo;
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            MetroCheckBox chk = sender as MetroCheckBox;
            if (chk.Name == "chkSupplier")
            {
                if (chkSupplier.Checked)
                {
                    chkByPO.Checked = false;
                    chkByStitcher.Checked = false;
                    chkByPeriod.Checked = false;
                }
                else
                {
                    txtSupplier.Visible = false;
                    return;
                }
                txtSupplier.Visible = true;
                txtStitcherName.Visible = false;
                txtPoNumber.Visible = false;
                dtStart.Visible = false;
                dtEnd.Visible = false;                
            }
            else if (chk.Name == "chkByPO")
            {
                if (chkByPO.Checked)
                {
                    chkSupplier.Checked = false;
                    chkByStitcher.Checked = false;
                    chkByPeriod.Checked = false;
                }
                else
                {
                    txtPoNumber.Visible = false;
                    return;
                }
                txtSupplier.Visible = false;
                txtStitcherName.Visible = false;
                txtPoNumber.Visible = true;
                dtStart.Visible = false;
                dtEnd.Visible = false;         
            }
            else if (chk.Name == "chkByStitcher")
            {
                if (chkByStitcher.Checked)
                {
                    chkSupplier.Checked = false;
                    chkByPO.Checked = false;
                    chkByPeriod.Checked = false;
                }
                else
                {
                    txtStitcherName.Visible = false;
                    return;
                }
                txtSupplier.Visible = false;
                txtStitcherName.Visible = true;
                txtPoNumber.Visible = false;
                dtStart.Visible = false;
                dtEnd.Visible = false;   
            }
            else if (chk.Name == "chkByPeriod")
            {
                if (chkByPeriod.Checked)
                {
                    chkSupplier.Checked = false;
                    chkByPO.Checked = false;
                    chkByStitcher.Checked = false;
                }
                else
                {
                    dtStart.Visible = false;
                    dtEnd.Visible = false;
                    return;
                }
                txtSupplier.Visible = false;
                txtStitcherName.Visible = false;
                txtPoNumber.Visible = false;
                dtStart.Visible = true;
                dtEnd.Visible = true;   
            }
            ClearControls();
        }
        #endregion
        #region Button Events
        private void btnProductReport_Click(object sender, EventArgs e)
        {
            decimal DebitStock = 0, CreditStock = 0, Balance = 0, Qty = 0, TotalValue = 0;
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetProductLedger(IdItem);
            if (list.Count > 0)
            {
                list.RemoveAll(x => x.Qty == 0);
                grdProductLedger.DataSource = list;
                for (int i = 0; i < list.Count; i++)
                {
                    if (Validation.GetSafeString(grdProductLedger.Rows[i].Cells["colType"].Value) == "In")
                    {
                        DebitStock = Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colUnits"].Value);
                        Balance += DebitStock;
                        grdProductLedger.Rows[i].Cells["colClosing"].Value = Balance;//.ToString() + " KG";
                        Qty += Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colUnits"].Value);

                    }
                    if (Validation.GetSafeString(grdProductLedger.Rows[i].Cells["colType"].Value) == "Out")
                    {
                        CreditStock = Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colUnits"].Value);
                        Balance -= CreditStock;
                        grdProductLedger.Rows[i].Cells["colClosing"].Value = Balance.ToString();
                        Qty -= Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colUnits"].Value);
                    }

                    //TotalValue += Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colValue"].Value);
                    //if (Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colUnits"].Value) != 0)
                    //{
                    //    grdProductLedger.Rows[i].Cells["colPerUnitAvg"].Value = Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colValue"].Value) / Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colUnits"].Value);
                    //}
                    //if (Qty > 0)
                    //{
                    //    //grdTanneryStockReport.Rows[i].Cells["colPerUnitAvg"].Value = (TotalValue / Qty).ToString("0.00");
                    //    grdProductLedger.Rows[i].Cells["colStockBalance"].Value = (Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colPerUnitAvg"].Value) * Balance).ToString("0.00");
                    //}
                }
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {            
            decimal DebitStock = 0, CreditStock = 0, Balance = 0, Qty = 0, TotalValue = 0;
            var manager = new ItemsBLL();
             List<ItemsEL> list = new List<ItemsEL>();
            if (IdItem == Guid.Empty)
            {
                MessageBox.Show("Please First Select Product...");
                return;
            }
            else
            {
                if (chkSupplier.Checked)
                {
                    list = manager.GetProductLedgerBySupplier(IdItem, AccountNo);
                }
                else if (chkByStitcher.Checked)
                {
                    list = manager.GetProductLedgerByStitcher(IdItem, AccountNo);
                }
                else if (chkByPO.Checked)
                {
                    list = manager.GetProductLedgerByOrder(IdItem, IdOrder);
                }
                else if (chkByPeriod.Checked)
                {
                    list = manager.GetProductLedgerByDate(IdItem, dtStart.Value, dtEnd.Value);
                }
            }
            if (list.Count > 0)
            {
                list.RemoveAll(x => x.Qty == 0);
                grdProductLedger.DataSource = list;
                for (int i = 0; i < list.Count; i++)
                {
                    if (Validation.GetSafeString(grdProductLedger.Rows[i].Cells["colType"].Value) == "In")
                    {
                        DebitStock = Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colUnits"].Value);
                        Balance += DebitStock;
                        grdProductLedger.Rows[i].Cells["colClosing"].Value = Balance;//.ToString() + " KG";
                        Qty += Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colUnits"].Value);

                    }
                    if (Validation.GetSafeString(grdProductLedger.Rows[i].Cells["colType"].Value) == "Out")
                    {
                        CreditStock = Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colUnits"].Value);
                        Balance -= CreditStock;
                        grdProductLedger.Rows[i].Cells["colClosing"].Value = Balance.ToString();
                        Qty -= Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colUnits"].Value);
                    }

                    //TotalValue += Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colValue"].Value);
                    //if (Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colUnits"].Value) != 0)
                    //{
                    //    grdProductLedger.Rows[i].Cells["colPerUnitAvg"].Value = Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colValue"].Value) / Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colUnits"].Value);
                    //}
                    //if (Qty > 0)
                    //{
                    //    //grdTanneryStockReport.Rows[i].Cells["colPerUnitAvg"].Value = (TotalValue / Qty).ToString("0.00");
                    //    grdProductLedger.Rows[i].Cells["colStockBalance"].Value = (Validation.GetSafeDecimal(grdProductLedger.Rows[i].Cells["colPerUnitAvg"].Value) * Balance).ToString("0.00");
                    //}
                }
            }
            else
            {
                MessageBox.Show("No Record Found");
                grdProductLedger.DataSource = null;
            }
        }
        #endregion        
    }
}
