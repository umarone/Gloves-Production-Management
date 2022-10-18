using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.BLL;
using Accounts.EL;
using Accounts.Common;

using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmOpeningBalance : MetroForm
    {
        frmFindAccounts frmAccount;
        public Guid TransactionId { get; set; }
        public Guid StockReceiptId { get; set; }
        int HeaderAccount;
        public frmOpeningBalance()
        {
            InitializeComponent();
        }
        private void frmOpeningBalance_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //DgvOpeningBalance.Columns[5].Visible = false;

            CheckModulePermissions();
            //DgvOpeningBalance.Enabled = false;
            FillEmployees();
        }
        private void FillEmployees()
        {
            var manager = new AccountsBLL();
            List<AccountsEL> listAccounts = manager.GetEmployeesAccounts(Operations.IdCompany);

            cbxEmployees.DataSource = listAccounts;
            cbxEmployees.DisplayMember = "AccountName";
            cbxEmployees.ValueMember = "AccountNo";
        }
        private void CheckModulePermissions()
        {
            List<UserModulesPermissionsEL> PermissionsList = UserPermissions.GetUserModulePermissionsByUserAndModuleId(Operations.UserID);
            if (PermissionsList != null && PermissionsList.Count > 0)
            {
                if (PermissionsList[0].Saving == true)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
                if (PermissionsList[0].Deleting == true)
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                }
            }
            //else if(Operations.IdRole == Validation.GetSafeGuid(EnRoles.Operators))
            //{
            //    btnSave.Enabled = false;
            //    btnDelete.Enabled = false;
            //}
        }
        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            var manager = new OpeningBalanceBLL();
            List<OpeningBalanceEL> list = null;
            list = manager.GetOpeningBalance(oelAccount.AccountNo, "", Operations.IdCompany);
            if (list.Count > 0)
            {
                FillOpeningBalance(list);
            }
            else
            {
                DgvOpeningBalance.CurrentRow.Cells["colAccount"].Value = oelAccount.AccountNo;
                DgvOpeningBalance.CurrentRow.Cells["colLinkAccount"].Value = oelAccount.LinkAccountNo;
                DgvOpeningBalance.CurrentRow.Cells["colAccountName"].Value = oelAccount.AccountName;
                DgvOpeningBalance.CurrentRow.Cells["colHeadId"].Value = oelAccount.IdHead;
            }
            DgvOpeningBalance.CurrentRow.Cells["colAccountName"].Selected = true;
        }
        private void FillOpeningBalance(List<OpeningBalanceEL> OpeningBalancelist)
        {
            if (DgvOpeningBalance.Rows.Count > 0)
            {
                DgvOpeningBalance.Rows.Clear();
            }
            for (int i = 0; i < OpeningBalancelist.Count; i++)
            {
                DgvOpeningBalance.Rows.Add();
                DgvOpeningBalance.Rows[i].Cells["ColTransaction"].Value = OpeningBalancelist[i].IdTransaction;
                DgvOpeningBalance.Rows[i].Cells["colHeadId"].Value = OpeningBalancelist[i].IdHead;
                TransactionId = OpeningBalancelist[0].IdTransaction;
                DgvOpeningBalance.Rows[i].Cells["colAccount"].Value = OpeningBalancelist[i].AccountNo;
                DgvOpeningBalance.Rows[i].Cells["colLinkAccount"].Value = OpeningBalancelist[i].LinkAccountNo;
                DgvOpeningBalance.Rows[i].Cells["colAccountName"].Value = OpeningBalancelist[i].AccountName;
                DgvOpeningBalance.Rows[i].Cells["colAdjustmentTypes"].Value = OpeningBalancelist[i].SettlementType;
                DgvOpeningBalance.Rows[i].Cells["colDiscription"].Value = OpeningBalancelist[i].Description;
                DgvOpeningBalance.Rows[i].Cells["colAmount"].Value = OpeningBalancelist[i].Amount;   
            }
        }
        private bool ValidateRows()
        {

            for (int i = 0; i < DgvOpeningBalance.Rows.Count - 1; i++)
            {
                if (DgvOpeningBalance.Rows[i].Cells["colAccount"].Value == null)
                {
                    return false;
                }
                else if (DgvOpeningBalance.Rows[i].Cells["colAmount"].Value == null)
                {
                    return false;
                }
            }
            return true;
        }
        private void ClearControl()
        {
            DgvOpeningBalance.Rows.Clear();
            TransactionId = Guid.Empty;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var manager = new OpeningBalanceBLL();
            try
            {
                if (DgvOpeningBalance.Rows.Count > 0)
                {
                    for (int i = 0; i < DgvOpeningBalance.Rows.Count; i++)
                    {
                        if (manager.DeleteOpeningBalance(Validation.GetSafeLong(DgvOpeningBalance.Rows[i].Cells["colAccount"].Value), new Guid(DgvOpeningBalance.Rows[i].Cells["ColTransaction"].Value.ToString()), Operations.IdCompany).IsSuccess == true)
                        {
                            lblStatuMessage.Text = "Opening Balance Is Deleted Successfully...";
                            ClearControl();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatuMessage.Text = "Problem Occured While Deleting OpeningBalance...";
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            List<OpeningBalanceEL> oelOpeningBalanceCollections = new List<OpeningBalanceEL>();
            //List<StockReceiptEL> oelOpeningStockCollection = new List<StockReceiptEL>();
            if (ValidateRows())
            {

                /// Add Opening Balance And Transaction ...
                for (int i = 0; i < DgvOpeningBalance.Rows.Count - 1; i++)
                {
                    OpeningBalanceEL oelOpeningBalance = new OpeningBalanceEL();
                    //StockReceiptEL oelStockReceipt = new StockReceiptEL();
                   
                    oelOpeningBalance.IdCompany = Operations.IdCompany;
                    oelOpeningBalance.AccountNo = Validation.GetSafeString(DgvOpeningBalance.Rows[i].Cells["colAccount"].Value);
                    oelOpeningBalance.AccountName = DgvOpeningBalance.Rows[i].Cells["colAccountName"].Value.ToString();
                    oelOpeningBalance.EmpCode = Validation.GetSafeString(cbxEmployees.SelectedValue);
                    oelOpeningBalance.UserId = Operations.UserID;                    
                    oelOpeningBalance.Units = 0;
                    
                    if (DgvOpeningBalance.Rows[i].Cells["colHeadId"].Value != null)
                    {
                        HeaderAccount = Validation.GetSafeInteger(DgvOpeningBalance.Rows[i].Cells["colHeadId"].Value);
                    }
                    oelOpeningBalance.Amount = Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value);
                    oelOpeningBalance.Discription = Validation.GetSafeString(DgvOpeningBalance.Rows[i].Cells["colDiscription"].Value);
                    oelOpeningBalance.OpeningBalanceDate = dtOpeningBalance.Value; // DateTime.Now;


                    TransactionsEL oelTransaction = new TransactionsEL();
                    if (DgvOpeningBalance.Rows[i].Cells["ColTransaction"].Value != null)
                    {
                        oelTransaction.TransactionID = new Guid(DgvOpeningBalance.Rows[i].Cells["ColTransaction"].Value.ToString());
                        oelTransaction.IsNew = false;
                        oelOpeningBalance.IsNew = false;
                        // oelStockReceipt.ActionType = "Update";
                    }
                    else
                    {
                        oelTransaction.TransactionID = Guid.NewGuid();
                        oelTransaction.IsNew = true;
                        oelOpeningBalance.IsNew = true;
                        // oelStockReceipt.ActionType = "Add";
                    }
                    oelOpeningBalance.IdOpeningBalance = oelTransaction.TransactionID;
                    oelTransaction.IdVoucher = oelTransaction.TransactionID;
                    oelTransaction.AccountNo = Validation.GetSafeString(DgvOpeningBalance.Rows[i].Cells["colAccount"].Value);
                    oelTransaction.SubAccountNo = "";
                    oelTransaction.LinkAccountNo = Validation.GetSafeString(DgvOpeningBalance.Rows[i].Cells["colLinkAccount"].Value);
                    oelTransaction.IdCompany = Operations.IdCompany;
                    oelTransaction.VDate = dtOpeningBalance.Value; // DateTime.Now;
                    oelTransaction.VoucherNo = 0;
                    oelTransaction.VoucherType = "OpeningBalance";
                    oelTransaction.SettlementType = Validation.GetSafeString(DgvOpeningBalance.Rows[i].Cells["colAdjustmentTypes"].Value);
                    oelTransaction.VDiscription = Validation.GetSafeString(DgvOpeningBalance.Rows[i].Cells["colDiscription"].Value);
                    oelTransaction.Posted = true;

                    //oelTransaction.AdjustmentType = cbxAdjustments.SelectedIndex;
                    //oelTransaction.SettlementType = cbxAdjustments.Text;

                    if (HeaderAccount == Validation.GetSafeInteger(HeaderAccounts.Assets))
                    {
                        if (Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value) < 0)
                        {
                            oelTransaction.Credit = Math.Abs(Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value));
                            oelTransaction.Debit = 0;
                            oelTransaction.TransactionType = "Cr";
                        }
                        else
                        {
                            oelTransaction.Debit = Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value);
                            oelTransaction.Credit = 0;
                            oelTransaction.TransactionType = "Dr";
                        }
                    }
                    else if (HeaderAccount == Validation.GetSafeInteger(HeaderAccounts.Libilities))
                    {
                        if (Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value) < 0)
                        {
                            oelTransaction.Debit = Math.Abs(Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value));
                            oelTransaction.Credit = 0;
                            oelTransaction.TransactionType = "Dr";
                        }
                        else
                        {
                            oelTransaction.Credit = Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value);
                            oelTransaction.Debit = 0;
                            oelTransaction.TransactionType = "Cr";
                        }
                    }
                    else if (HeaderAccount == Validation.GetSafeInteger(HeaderAccounts.Expense))
                    {
                        if (Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value) < 0)
                        {
                            oelTransaction.Credit = Math.Abs(Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value));
                            oelTransaction.Debit = 0;
                            oelTransaction.TransactionType = "Cr";
                        }
                        else
                        {
                            oelTransaction.Debit = Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value);
                            oelTransaction.Credit = 0;
                            oelTransaction.TransactionType = "Dr";
                        }
                    }
                    else if (HeaderAccount == Validation.GetSafeInteger(HeaderAccounts.Income))
                    {
                        if (Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value) < 0)
                        {
                            oelTransaction.Debit = Math.Abs(Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value));
                            oelTransaction.Credit = 0;
                            oelTransaction.TransactionType = "Dr";
                        }
                        else
                        {
                            oelTransaction.Credit = Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value);
                            oelTransaction.Debit = 0;
                            oelTransaction.TransactionType = "Cr";
                        }
                    }
                    else if (HeaderAccount == Validation.GetSafeInteger(HeaderAccounts.Equity))
                    {
                        if (Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value) < 0)
                        {
                            oelTransaction.Debit = Math.Abs(Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value));
                            oelTransaction.Credit = 0;
                            oelTransaction.TransactionType = "Dr";
                        }
                        else
                        {
                            oelTransaction.Credit = Convert.ToDecimal(DgvOpeningBalance.Rows[i].Cells["colAmount"].Value);
                            oelTransaction.Debit = 0;
                            oelTransaction.TransactionType = "Cr";
                        }
                    }

                    oelTransactionCollection.Add(oelTransaction);
                    oelOpeningBalanceCollections.Add(oelOpeningBalance);
                }
                if (TransactionId == Guid.Empty)
                {
                    var manager = new OpeningBalanceBLL();
                    EntityoperationInfo infoResult = manager.InsertOpeningBalance(oelOpeningBalanceCollections, oelTransactionCollection);
                    if (infoResult.IsSuccess)
                    {
                        //var managerStock = new PurchaseHeadBLL(); // PurchaseStockReceiptBLL();
                        //managerStock.UpdateStockitems(oelTransactionCollection, "Add");
                        lblStatuMessage.Text = "Opening Balance Transaction Successfull ...";
                        ClearControl();
                        //var managerStockReciept = new StockRecieptBLL();
                        //managerStockReciept.InsertUpdateStock(oelOpeningStockCollection);
                    }
                }
                else
                {
                    var manager = new OpeningBalanceBLL();
                    EntityoperationInfo infoResult = manager.UpdateOpeningBalance(oelOpeningBalanceCollections, oelTransactionCollection);
                    if (infoResult.IsSuccess)
                    {
                        //manager.UpdateStockitems(oelTransactionCollection, "Add");
                        //var managerStockReciept = new StockRecieptBLL();
                        //managerStockReciept.InsertUpdateStock(oelOpeningStockCollection);
                        lblStatuMessage.Text = "Opening Balance Transaction Successfull ...";
                        ClearControl();
                    }
                }
            }
            else
            {
                lblStatuMessage.Text = "Incomplete Entry...";
            }
        }
        private void chkStock_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStock.Checked)
            {
                DgvOpeningBalance.Columns[5].Visible = true;
            }
            else
            {
                DgvOpeningBalance.Columns[5].Visible = false;
            }
        }
        private void DgvOpeningBalance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvOpeningBalance.CurrentCellAddress.X == 4)
            {
                TextBox txtAccountName = e.Control as TextBox;
                if (txtAccountName != null)
                {
                    txtAccountName.KeyPress -= new KeyPressEventHandler(txtAccountName_KeyPress);
                    txtAccountName.KeyPress += new KeyPressEventHandler(txtAccountName_KeyPress);
                }
            }
        }
        void txtAccountName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvOpeningBalance.CurrentCellAddress.X == 4)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmAccount = new frmFindAccounts();
                    frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                    frmAccount.SearchText = e.KeyChar.ToString();
                    frmAccount.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        private void DgvOpeningBalance_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                SendKeys.Send("{F4}");
            }
        }
    }
}
