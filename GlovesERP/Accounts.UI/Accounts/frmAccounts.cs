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
    public partial class frmAccounts : MetroForm
    {
        #region Variables
        frmHeadsSetup frmheadSetup;
        AccountsEL oelAccount = new AccountsEL();
        AccountsBLL objAccountsBLL = new AccountsBLL();
        PersonsEL oelPerson = new PersonsEL();
        PersonsBLL objPersonBll = new PersonsBLL();
        ItemsBLL objItemBll = new ItemsBLL();
        ItemsEL oelItem = new ItemsEL();
        EntityoperationInfo infoResult = null;
        string MiscAccount = "";
        int AccountType,levelOne,levelTwo,levelThree;
        Guid IdAccount = Guid.Empty;
        #endregion
        public frmAccounts()
        {
            InitializeComponent();
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            grdAccounts.AutoGenerateColumns = false;
            //FillParentAccounts();
            FillHeads(null, 1);
            //FillTradingCo();
        }
        private void FillHeads(Guid? Id, int level)
        {
            var manager = new AccountsBLL();
            List<AccountsEL> list = manager.GetAccountsByParent(Id,Operations.IdCompany,level);
            if (list.Count > 0)
            {
                if (level != 4)
                {
                    list.Insert(0, new AccountsEL() { IdAccount = Guid.Empty, AccountName = "Select Head" });
                }

                //cbxHeadsLevel3.SelectedIndex = -1;
                if (level == 1)
                {
                    CbxHeadsLevel1.DataSource = list;
                    CbxHeadsLevel1.DisplayMember = "AccountName";
                    CbxHeadsLevel1.ValueMember = "IdAccount";
                }
                else if (level == 2)
                {
                    CbxHeadsLevel2.DataSource = list;
                    CbxHeadsLevel2.DisplayMember = "AccountName";
                    CbxHeadsLevel2.ValueMember = "IdAccount";
                }
                else if (level == 3)
                {
                    CbxHeadsLevel3.DataSource = list;
                    CbxHeadsLevel3.DisplayMember = "AccountName";
                    CbxHeadsLevel3.ValueMember = "IdAccount";
                }
                else if (level == 4)
                {
                    grdAccounts.DataSource = list;
                }
            }
            else if (level == 2)
            {
                CbxHeadsLevel2.DataSource = null;
                ClearControls(level);
            }
            else if (level == 3)
            {
                CbxHeadsLevel3.DataSource = null;
                ClearControls(level);
            }
            else if (level == 4)
            {
                grdAccounts.DataSource = null;
                ClearControls(level);
            }
        }
        private void CbxHeads_SelectedIndexChanged(object sender, EventArgs e)
        {
            var manager = new AccountsBLL();
            MetroFramework.Controls.MetroComboBox ctrl = sender as MetroFramework.Controls.MetroComboBox;
            if (ctrl != null)
            {
                if (Validation.GetSafeGuid(ctrl.SelectedValue) != Guid.Empty)
                {
                    if (ctrl.Name == "CbxHeadsLevel1")
                    {
                        if (ctrl.SelectedValue != null && Validation.GetSafeGuid(ctrl.SelectedValue) != Guid.Empty)
                        {
                            FillHeads(Validation.GetSafeGuid(ctrl.SelectedValue), 2);
                            levelOne = Validation.GetSafeInteger(manager.GetAccountsById(Validation.GetSafeGuid(ctrl.SelectedValue))[0].AccountNo);
                        }
                    }
                    else if (ctrl.Name == "CbxHeadsLevel2")
                    {
                        if (ctrl.SelectedValue != null)
                        {
                            FillHeads(Validation.GetSafeGuid(ctrl.SelectedValue), 3);
                            levelTwo = Validation.GetSafeInteger(manager.GetAccountsById(Validation.GetSafeGuid(ctrl.SelectedValue))[0].AccountNo);
                        }
                    }
                    else if (ctrl.Name == "CbxHeadsLevel3")
                    {
                        if (ctrl.SelectedValue != null)
                        {
                            FillHeads(Validation.GetSafeGuid(ctrl.SelectedValue), 4);
                            levelThree = Validation.GetSafeInteger(manager.GetAccountsById(Validation.GetSafeGuid(ctrl.SelectedValue))[0].AccountNo);
                            FillMaxAccountNo(4,Validation.GetSafeGuid(ctrl.SelectedValue));
                        }

                    }
                }
            }
        }
        private void FillMaxAccountNo(int Level,Guid IdParent)
        {
            var manager = new AccountsBLL();
            string MaxAccountNo = manager.GetMaxAccountNo(levelOne, levelTwo, levelThree,4, Operations.IdCompany, IdParent);
            //if (MaxAccountNo.HasValue)
            //{
            txtAccountNo.Text = MaxAccountNo;

            //}
        }
        private void FillTradingCo()
        {
            var manager = new TradingBLL();
            List<TradingEL> listTradingCo = manager.GetAllTradingCo(Operations.IdCompany);

            CbxHeadsLevel2.DataSource = listTradingCo;
            CbxHeadsLevel2.DisplayMember = "TradingName";
            CbxHeadsLevel2.ValueMember = "TradingCode";
        }
        private void ClearControls(int Level)
        {
            txtAccountNo.Text = string.Empty;
            txtPersonalCode.Text = string.Empty;
            txtAccountTitle.Text = string.Empty;
            MiscAccount = string.Empty;
            txtSearchAccounts.Text = string.Empty;
            txtSearchAccounts.WaterMark = "Type And Search Accounts Here";
            txtDiscription.Text = "";
            if (chkActive.Checked)
            {
                chkActive.Checked = false;
            }
            //CbxHeadsLevel1.DataSource = null;
            if (Level == 2)
            {
                CbxHeadsLevel2.DataSource = null;
            }
            else if (Level == 3)
            {
                CbxHeadsLevel3.DataSource = null;
            }
            //else if(Level == 0)
            //{
            //    CbxHeadsLevel1.SelectedIndex = 0;
            //    CbxHeadsLevel1.Focus();
            //}
            IdAccount = Guid.Empty;
            //if (grdAccounts.Rows.Count > 0)
            //{
            //    grdAccounts.DataSource = null;
            //}
            if (grdAccounts.DataSource == null && grdAccounts.Rows.Count > 0)
            {
                grdAccounts.Rows.Clear();
            }
            else if (grdAccounts.DataSource != null)
            {
                grdAccounts.DataSource = null;
            }

        }      
        private bool Validate()
        {
            bool IsValid = true;
            if (txtAccountNo.Text == string.Empty)
            {
                IsValid = false;
            }
            else if (txtAccountTitle.Text == string.Empty)
            {
                IsValid = false;
            }
            return IsValid;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                //oelAccount.IdParent1 = Validation.GetSafeInteger(CbxHeadsLevel1.SelectedValue);
                //oelAccount.IdParent2 = Validation.GetSafeInteger(CbxHeadsLevel3.SelectedValue);
                oelAccount.IdParent = Validation.GetSafeGuid(CbxHeadsLevel3.SelectedValue);
                oelAccount.UserId = Operations.UserID;
                oelAccount.IdCompany = Operations.IdCompany;
                oelAccount.CreatedDateTime = DateTime.Now;
                if (IdAccount != Guid.Empty)
                {
                    oelAccount.IdAccount = IdAccount;
                }
                else
                {
                    oelAccount.IdAccount = Guid.NewGuid();
                }
                oelAccount.AccountNo = Validation.GetSafeString(txtAccountNo.Text);
                oelAccount.LinkAccountNo = Validation.GetSafeString(txtLinkAccountNo.Text);
                oelAccount.PersonalAccountNo = Validation.GetSafeString(txtPersonalCode.Text);
                oelAccount.AccountName = txtAccountTitle.Text;
                oelAccount.AccountType = CbxHeadsLevel3.Text;
                oelAccount.IdLevel = 4;
                if (CbxHeadsLevel1.Text == "Assets")
                {
                    oelAccount.IdHead = 1;
                }
                if (CbxHeadsLevel1.Text == "Libilities")
                {
                    oelAccount.IdHead = 2;
                }
                if (CbxHeadsLevel1.Text == "Equity / Capital")
                {
                    oelAccount.IdHead = 3;
                }
                if (CbxHeadsLevel1.Text == "Revenue")
                {
                    oelAccount.IdHead = 4;
                }
                if (CbxHeadsLevel1.Text == "Expenses")
                {
                    oelAccount.IdHead = 5;
                }
                oelAccount.Discription = txtDiscription.Text;

                if (chkActive.Checked)
                {
                    oelAccount.IsActive = false;
                }
                else
                {
                    oelAccount.IsActive = true;
                }
                if (CbxHeadsLevel3.Text == "Accounts Recieveables" && CbxHeadsLevel1.SelectedIndex == 1)
                {
                    AccountType = (int)AccountTypes.Customers;
                }
                else if (CbxHeadsLevel3.Text == "Accounts Payables" && CbxHeadsLevel1.Text == "Libilities")
                {
                    AccountType = (int)AccountTypes.Suppliers;
                }
                else if (CbxHeadsLevel3.SelectedIndex == 4 && CbxHeadsLevel1.Text == "Expenses")
                {
                    AccountType = (int)AccountTypes.Employees;
                }
                //else if (CbxHeadsLevel3.SelectedIndex == 2 && CbxHeadsLevel1.Text == "Assets")
                //{
                //    AccountType = (int)AccountTypes.Stock;
                //}
                else
                {
                    AccountType = (int)AccountTypes.GLAccount;
                }
                if (MiscAccount == string.Empty)
                {
                    if (!objAccountsBLL.CheckAccount(Validation.GetSafeLong(txtAccountNo.Text), Operations.IdCompany))
                    {
                        infoResult = objAccountsBLL.InsertChartsOfAccounts(oelAccount);
                        if (infoResult.IsSuccess)
                        {
                            MessageBox.Show("Account Created Successfully...");
                            ClearControls(0);
                            FillMaxAccountNo(4, Validation.GetSafeGuid(CbxHeadsLevel3.SelectedValue));
                        }
                        else
                        {
                            MessageBox.Show("Some Problem Occured while Saving Account...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Account Already Exists...");
                    }
                }
                else
                {
                    infoResult = objAccountsBLL.UpdateChartsOfAccounts(oelAccount);
                    if (infoResult.IsSuccess)
                    {
                        MessageBox.Show("Account Updated Successfully...");
                        ClearControls(0);
                        FillMaxAccountNo(4, Validation.GetSafeGuid(CbxHeadsLevel3.SelectedValue));
                    }
                    else
                    {
                        MessageBox.Show("Some Problem Occured while Saving Account...");
                    }
                }
                //if (AccountType == (int)AccountTypes.Customers || AccountType == (int)AccountTypes.Suppliers || AccountType == (int)AccountTypes.Employees)
                //{
                //    oelPerson.IdAccount = oelAccount.IdAccount;
                //    oelPerson.IdCompany = Operations.IdCompany;
                //    oelPerson.AccountNo = Validation.GetSafeString(txtAccountNo.Text);
                //    oelPerson.PersonName = txtAccountTitle.Text;
                //    oelPerson.LastName = "";
                //    oelPerson.IdParent1 = Validation.GetSafeInteger(CbxHeadsLevel1.SelectedValue);
                //    oelPerson.Cnic = string.Empty;

                //    oelPerson.Address = "";
                //    oelPerson.NTN = "";
                //    oelPerson.Contact = "";
                //    oelPerson.Salary = "";
                //    oelPerson.PersonPic = null;
                //    oelPerson.Discription = "";

                //    if (MiscAccount == string.Empty)
                //    {
                //        if (!objAccountsBLL.CheckAccount(Validation.GetSafeLong(txtAccountNo.Text), Validation.GetSafeGuid(Operations.IdCompany)))
                //        {
                //            infoResult = objPersonBll.InsertPersonAccount(oelPerson, oelAccount);
                //            if (infoResult.IsSuccess)
                //            {
                //                MessageBox.Show("Account Created Successfully");
                //                ClearControls(0);
                //                FillMaxAccountNo(4, Validation.GetSafeGuid(CbxHeadsLevel3.SelectedValue));
                //            }
                //            else
                //            {
                //                MessageBox.Show("Some Problem occured while loading Record");
                //            }
                //        }
                //        else
                //        {
                //            MessageBox.Show("Account Already Exists");
                //        }
                //    }
                //    else
                //    {
                //        infoResult = objPersonBll.UpdatePersonAccount(oelAccount, oelPerson);
                //        if (infoResult.IsSuccess)
                //        {
                //            MessageBox.Show("Account Updated Successfully");
                //            ClearControls(0);
                //        }
                //        else
                //        {
                //            MessageBox.Show("Some Problem occured while loading Record");
                //        }
                //    }

                //}
                //else if (AccountType == (int)AccountTypes.Stock)
                //{
                //    oelItem.IdAccount = oelAccount.IdAccount;
                //    oelItem.IdCompany = Operations.IdCompany;
                //    oelItem.ItemNo = txtAccountNo.Text;
                //    oelItem.ItemName = txtAccountTitle.Text;
                //    oelItem.PackingSize = "";
                //    oelItem.Description = "";

                //    if (MiscAccount == string.Empty)
                //    {
                //        if (!objAccountsBLL.CheckAccount(Validation.GetSafeLong(txtAccountNo.Text), Validation.GetSafeGuid(Operations.IdCompany)))
                //        {
                //            infoResult = objItemBll.InsertStockWithAccount(oelAccount, oelItem);
                //            if (infoResult.IsSuccess)
                //            {
                //                MessageBox.Show("Account Created Successfully...");
                //                ClearControls(0);
                //                FillMaxAccountNo(4, Validation.GetSafeGuid(CbxHeadsLevel3.SelectedValue));
                //            }
                //            else
                //            {
                //                MessageBox.Show("Some Problem Occured while Saving Account...");
                //            }
                //        }
                //        else
                //        {
                //            MessageBox.Show("Account Already Exists...");
                //        }
                //    }
                //    else
                //    {
                //        infoResult = objItemBll.UpdateItemsWithAccount(oelAccount, oelItem);
                //        if (infoResult.IsSuccess)
                //        {
                //            MessageBox.Show("Account Updated Successfully...");
                //            ClearControls(0);
                //            FillMaxAccountNo(4, Validation.GetSafeGuid(CbxHeadsLevel3.SelectedValue));
                //        }
                //        else
                //        {
                //            MessageBox.Show("Some Problem Occured while Saving Account...");
                //        }
                //    }
                //}
                //else
                //{
                //    if (MiscAccount == string.Empty)
                //    {
                //        if (!objAccountsBLL.CheckAccount(Validation.GetSafeLong(txtAccountNo.Text), Operations.IdCompany))
                //        {
                //            infoResult = objAccountsBLL.InsertChartsOfAccounts(oelAccount);
                //            if (infoResult.IsSuccess)
                //            {
                //                MessageBox.Show("Account Created Successfully...");
                //                ClearControls(0);
                //                FillMaxAccountNo(4, Validation.GetSafeGuid(CbxHeadsLevel3.SelectedValue));
                //            }
                //            else
                //            {
                //                MessageBox.Show("Some Problem Occured while Saving Account...");
                //            }
                //        }
                //        else
                //        {
                //            MessageBox.Show("Account Already Exists...");
                //        }
                //    }
                //    else
                //    {
                //        infoResult = objAccountsBLL.UpdateChartsOfAccounts(oelAccount);
                //        if (infoResult.IsSuccess)
                //        {
                //            MessageBox.Show("Account Updated Successfully...");
                //            ClearControls(0);
                //            FillMaxAccountNo(4, Validation.GetSafeGuid(CbxHeadsLevel3.SelectedValue));
                //        }
                //        else
                //        {
                //            MessageBox.Show("Some Problem Occured while Saving Account...");
                //        }
                //    }
                //}
                //AddRecord(oelAccount);
                GetAccountsByParent(4);
            }
            else
            {
                MessageBox.Show("Account No Or Account Title Is Empty....");
            }
        }
        private void GetAccountsByParent(int IdLevel)
        {
            var manager = new AccountsBLL();
            List<AccountsEL> list = manager.GetAccountsByParent(Validation.GetSafeGuid(CbxHeadsLevel3.SelectedValue),Operations.IdCompany, IdLevel);
            if (list.Count > 0)
            {
                grdAccounts.DataSource = list;
            }
            else
            {
                grdAccounts.DataSource = null;
            }
        }
        private void AddRecord(AccountsEL oelAccount)
        {
            if (oelAccount != null)
            {
                grdAccounts.Rows.Add();
                grdAccounts.Rows[grdAccounts.Rows.Count - 1].Cells[0].Value = oelAccount.IdAccount;
                grdAccounts.Rows[grdAccounts.Rows.Count - 1].Cells[1].Value = oelAccount.IdParent;
                grdAccounts.Rows[grdAccounts.Rows.Count - 1].Cells[2].Value = oelAccount.AccountNo;
                grdAccounts.Rows[grdAccounts.Rows.Count - 1].Cells[3].Value = oelAccount.AccountName;
                grdAccounts.Rows[grdAccounts.Rows.Count - 1].Cells[4].Value = oelAccount.Discription;
                grdAccounts.Rows[grdAccounts.Rows.Count - 1].Cells[5].Value = oelAccount.AccountType;

            }
        }
        private void txtSearchAccounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                grdAccounts.Focus();
                e.KeyChar = (char)Keys.Tab;
            }
        }
        private void txtSearchAccounts_TextChanged(object sender, EventArgs e)
        {
            var manager = new AccountsBLL();
            List<AccountsEL> list = new List<AccountsEL>();
            string searchString = "";
            if (txtSearchAccounts.Text != string.Empty)
            {
                char[] chars = txtSearchAccounts.Text.ToArray();
                if (chars.Length > 0 && char.IsNumber(chars[0]))
                {
                    //list = manager.SearchAccountByAccountNo(Validation.GetSafeLong(txtSearchAccounts.Text), Operations.IdCompany);
                    //PopulateAccountsBySearch(list);
                    list = manager.SearchAccountByAccountNo(Validation.GetSafeLong(txtSearchAccounts.Text), Operations.IdCompany);
                    if (list.Count > 0)
                        PopulateAccountsBySearch(list);
                    else
                    {
                        searchString = txtSearchAccounts.Text;
                        if (txtSearchAccounts.Text.Contains("\t"))
                            searchString = txtSearchAccounts.Text.Remove(txtSearchAccounts.Text.Count() - 1);
                        list = manager.SearchAccountByAccountName(searchString, Operations.IdCompany);
                        PopulateAccountsBySearch(list);
                    }
                }
                else
                {
                    searchString = txtSearchAccounts.Text;
                    if (txtSearchAccounts.Text.Contains("\t"))
                        searchString = txtSearchAccounts.Text.Remove(txtSearchAccounts.Text.Count() - 1);
                    list = manager.SearchAccountByAccountName(searchString, Operations.IdCompany);
                    PopulateAccountsBySearch(list);
                }
            }
            else if (grdAccounts.Rows.Count > 0)
            {
                grdAccounts.DataSource = null;
            }
        }
        private void PopulateAccountsBySearch(List<AccountsEL> list)
        {
            if (grdAccounts.Rows.Count > 1)
            {
                grdAccounts.DataSource = null;
            }
            grdAccounts.DataSource = list;
        }
        private void frmAccounts_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ClearControls(0);
            }
        }
        private void grdAccounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (grdAccounts.CurrentRow != null)
                {
                    int RowIndex = grdAccounts.CurrentRow.Index;
                    IdAccount = Validation.GetSafeGuid(grdAccounts.Rows[RowIndex].Cells["colAccountId"].Value);
                    MiscAccount = Validation.GetSafeString(grdAccounts.Rows[RowIndex].Cells["colAccountCode"].Value);
                    // CbxHeads.SelectedValue = Validation.GetSafeInteger(grdAccounts.Rows[RowIndex].Cells["colIdParent1"].Value);
                    // CbxHeads_SelectedIndexChanged(sender, e);
                    GetAccount(Validation.GetSafeString(grdAccounts.Rows[RowIndex].Cells["colAccountCode"].Value));
                }
            }
        }
        private void grdAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdAccount = Validation.GetSafeGuid(grdAccounts.Rows[e.RowIndex].Cells["colAccountId"].Value);
            MiscAccount = Validation.GetSafeString(grdAccounts.Rows[e.RowIndex].Cells["colAccountCode"].Value);
            //CbxHeads.SelectedValue = Validation.GetSafeInteger(grdAccounts.Rows[e.RowIndex].Cells["colIdParent1"].Value);
            //CbxHeads_SelectedIndexChanged(sender, e);
            GetAccount(Validation.GetSafeString(grdAccounts.Rows[e.RowIndex].Cells["colAccountCode"].Value));
        }
        private void GetAccount(string AccountNo)
        {
            var manager = new AccountsBLL();
            AccountsEL oelAccounts = new AccountsEL();
            List<AccountsEL> list = manager.GetAccount(AccountNo, Operations.IdCompany);
            if (list.Count > 0)
            {
                CbxHeadsLevel1.SelectedIndex = list[0].IdHead;
                CbxHeadsLevel2.SelectedValue = manager.GetAccountsById(manager.GetAccountsById(manager.GetAccountsById(list[0].IdParent)[0].IdParent)[0].IdAccount)[0].IdAccount;
                CbxHeadsLevel3.SelectedValue = list[0].IdParent; //cbxSubCategory.FindString(list[0].AccountType);
                //CbxHeadsLevel2.SelectedValue = manager.GetAccountsByParent(manager.GetAccountsByParent(list[0].IdParent)[0].IdAccount)[0].IdAccount;//CbxHeadsLevel3.FindString(list[0].AccountType);
                txtAccountNo.Text = list[0].AccountNo.ToString();
                txtPersonalCode.Text = list[0].PersonalAccountNo;
                txtLinkAccountNo.Text = list[0].LinkAccountNo;
                txtAccountTitle.Text = list[0].AccountName;
                txtDiscription.Text = list[0].Discription;
                txtAccountNo.Enabled = false;
            }
        }

        private void CbxTradingCo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CbxHeadsLevel1.Focus();
                CbxHeadsLevel1.DroppedDown = true;
            }
        }
        private void CbxHeads_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetroFramework.Controls.MetroComboBox ctrl = sender as MetroFramework.Controls.MetroComboBox;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (ctrl.Name == "CbxHeadsLevel1")
                {
                    if (CbxHeadsLevel1.SelectedIndex > 0)
                    {
                        CbxHeadsLevel2.Focus();
                        CbxHeadsLevel2.DroppedDown = true;
                    }
                }
                else if (ctrl.Name == "CbxHeadsLevel2")
                {
                    if (CbxHeadsLevel2.SelectedIndex > 0)
                    {
                        CbxHeadsLevel3.Focus();
                        CbxHeadsLevel3.DroppedDown = true;
                    }
                }
                else if (ctrl.Name == "CbxHeadsLevel3")
                {
                    if (CbxHeadsLevel3.SelectedIndex > 0)
                    {
                        //txtAccountTitle.Focus();
                        txtPersonalCode.Focus();
                    }
                }
            }
        }
        private void txtSearchAccounts_Enter(object sender, EventArgs e)
        {
            txtSearchAccounts.WaterMark = string.Empty;
        }
        private void txtAccountTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtAccountTitle.Text == string.Empty)
                    return;
                txtDiscription.Focus();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var manager = new AccountsBLL();
            //if (MessageBox.Show("Do You want to delete Account Physically ?", "Delete Account", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    manager.DeleteChartOfAccount(IdAccount);
            //}
            MessageBox.Show("Please select checkbox then press Save Button To Delete Account");
        }
        private void chkAllAccounts_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllAccounts.Checked)
            {
                LoadAllAccounts(true);
            }
            else
            {
                LoadAllAccounts(false);
            }
        }
        private void LoadAllAccounts(bool status)
        {
            if (status)
            {
                var manager = new AccountsBLL();
                List<AccountsEL> list = manager.GetAllAccounts(Operations.IdCompany);
                if (list.Count > 0)
                {
                    grdAccounts.DataSource = list;
                }
            }
            else
            {
                grdAccounts.DataSource = null;
            }
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnLevel2Heads_Click(object sender, EventArgs e)
        {
            if (CbxHeadsLevel1.Text != "Select Head")
            {
                frmheadSetup = new frmHeadsSetup();
                frmheadSetup.Level = 2;
                frmheadSetup.IdParent = Validation.GetSafeGuid(CbxHeadsLevel1.SelectedValue);
                frmheadSetup.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select Head First");
            }
        }
        private void btnLevel3Heads_Click(object sender, EventArgs e)
        {
            if (CbxHeadsLevel1.Text != "Select Head")
            {
                frmheadSetup = new frmHeadsSetup();
                frmheadSetup.Level = 3;
                frmheadSetup.IdParent = Validation.GetSafeGuid(CbxHeadsLevel1.SelectedValue);
                frmheadSetup.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select Head First");
            }
        }
        frmFindAccounts frmfindAccounts;
        private void btnLinkAccount_Click(object sender, EventArgs e)
        {
            frmfindAccounts = new frmFindAccounts();
            frmfindAccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccounts_ExecuteFindAccountEvent);
            frmfindAccounts.ShowDialog();
        }

        void frmfindAccounts_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            txtLinkAccountNo.Text = oelAccount.AccountNo;
        }

        private void txtPersonalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtAccountTitle.Focus();
            }
        }

        private void txtDiscription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus();
            }
        }

    }
}
