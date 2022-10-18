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
using MetroFramework.Forms;
using MetroFramework.Controls;
using Accounts.Common;
namespace Accounts.UI
{
    public partial class frmHeadsSetup : MetroForm
    {
        public int Level { get; set; }
        public Guid IdParent { get; set; }
        AccountsEL oelAccount = new AccountsEL();
        AccountsBLL objAccountsBLL = new AccountsBLL();
        int AccountType, levelOne, levelTwo, levelThree;
        Guid IdAccount = Guid.Empty;
        Guid IdAccountLevel2 = Guid.Empty;
        Guid IdAccountLevel3 = Guid.Empty;
        string MiscAccount = "";
        EntityoperationInfo infoResult = null;
        public frmHeadsSetup()
        {
            InitializeComponent();
        }

        private void frmHeadsSetup_Load(object sender, EventArgs e)
        {
            grdHeadsLevel2.AutoGenerateColumns = false;
            grdHeadsLevel3.AutoGenerateColumns = false;
            FillHeads(null, 1);
            FillByLevel(1);


        }
        private void FillHeads(Guid? Id, int level)
        {
            var manager = new AccountsBLL();
            List<AccountsEL> list = manager.GetAccountsByParent(Id,Operations.IdCompany,level);
            if (list.Count > 0)
            {
                list.Insert(0, new AccountsEL() { IdAccount = Guid.Empty, AccountName = "Select Head" });

                //cbxHeadsLevel3.SelectedIndex = -1;

                cbxHeadsLevel3.DataSource = list;
                cbxHeadsLevel3.DisplayMember = "AccountName";
                cbxHeadsLevel3.ValueMember = "IdAccount";

            }
        }
        private void FillChilds(Guid? IdParent, int level)
        {
            var manager = new AccountsBLL();
            List<AccountsEL> list = manager.GetAccountsByParent(IdParent,Operations.IdCompany,level);
            if (list.Count > 0)
            {
                list.Insert(0, new AccountsEL() { IdAccount = Guid.Empty, AccountName = "Select Head" });
                if (level == 3)
                {
                    cbxSubHeadsLevel3.DataSource = list;
                    cbxSubHeadsLevel3.DisplayMember = "AccountName";
                    cbxSubHeadsLevel3.ValueMember = "IdAccount";
                }
                else if (level == 3)
                {
                    //grdHeadsLevel2.DataSource = list;
                }
            }
            else
            { 
                //Nothing
            }
        }
        private void FillByLevel(int level)
        {
            var manager = new AccountsBLL();
            List<AccountsEL> list = manager.GetAccountByLevel(level);
            if (list.Count > 0)
            {
                list.Insert(0, new AccountsEL() { IdAccount = Guid.Empty, AccountName = "Select Head" });

                //cbxHeadsLevel3.SelectedIndex = -1;

                cbxHeadsLevel2.DataSource = list;
                cbxHeadsLevel2.DisplayMember = "AccountName";
                cbxHeadsLevel2.ValueMember = "IdAccount";
            }
        }

        private void FillGrid(int level, Guid IdParent)
        {
            var manager = new AccountsBLL();
            List<AccountsEL> list = manager.GetAccountsByParent(IdParent,Operations.IdCompany, level);
            if (level == 2)
            {
                if (list.Count > 0)
                {
                    grdHeadsLevel2.DataSource = list;
                }
                else
                {
                    grdHeadsLevel2.DataSource = null;
                }
            }
            else
            {
                if (list.Count > 0)
                {
                    grdHeadsLevel3.DataSource = list;
                }
                else
                {
                    grdHeadsLevel3.DataSource = null;
                }
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
                    if (ctrl.Name == "cbxHeadsLevel2")
                    {
                        if (Validation.GetSafeGuid(ctrl.SelectedValue) != Guid.Empty)
                        {
                            //FillHeads(Validation.GetSafeGuid(ctrl.SelectedValue), 2);
                            FillGrid(2, Validation.GetSafeGuid(ctrl.SelectedValue));
                            levelOne = Validation.GetSafeInteger(manager.GetAccountsById(Validation.GetSafeGuid(ctrl.SelectedValue))[0].AccountNo);
                            FillMaxAccountNo(2, Validation.GetSafeGuid(ctrl.SelectedValue));
                        }
                    }
                    else if (ctrl.Name == "cbxHeadsLevel3")
                    {
                        if (ctrl.SelectedValue != null)
                        {
                            FillChilds(Validation.GetSafeGuid(ctrl.SelectedValue), 3);
                            //levelTwo = Validation.GetSafeInteger(manager.GetAccountsById(Validation.GetSafeGuid(ctrl.SelectedValue))[0].AccountNo);
                            //FillMaxAccountNo(Level, Validation.GetSafeGuid(ctrl.SelectedValue));
                        }
                    }
                    else if (ctrl.Name == "cbxSubHeadsLevel3")
                    {
                        if (ctrl.SelectedValue != null)
                        {
                            //FillHeads(Validation.GetSafeGuid(ctrl.SelectedValue), 3);
                            FillGrid(3, Validation.GetSafeGuid(ctrl.SelectedValue));
                            levelTwo = Validation.GetSafeInteger(manager.GetAccountsById(Validation.GetSafeGuid(ctrl.SelectedValue))[0].AccountNo);
                            FillMaxAccountNo(3, Validation.GetSafeGuid(ctrl.SelectedValue));
                        }
                    }
                }
            }
        }

        private void grdHeadsLevel2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdAccountLevel2 = Validation.GetSafeGuid(grdHeadsLevel2.Rows[e.RowIndex].Cells[0].Value);
            txtAccountNumberLevel2.Text = Validation.GetSafeString(grdHeadsLevel2.Rows[e.RowIndex].Cells[2].Value);
            txtAccountNameLevel2.Text = Validation.GetSafeString(grdHeadsLevel2.Rows[e.RowIndex].Cells[3].Value);
            MiscAccount = "1";
        }

        private void grdHeadsLevel3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdAccountLevel3 = Validation.GetSafeGuid(grdHeadsLevel3.Rows[e.RowIndex].Cells[0].Value);
            txtAccountNumberLevel3.Text = Validation.GetSafeString(grdHeadsLevel3.Rows[e.RowIndex].Cells[2].Value);
            txtAccountNameLevel3.Text = Validation.GetSafeString(grdHeadsLevel3.Rows[e.RowIndex].Cells[3].Value);
            MiscAccount = "2";
        }

        private void FillMaxAccountNo(int Level, Guid IdParent)
        {
            var manager = new AccountsBLL();
            string MaxAccountNo = manager.GetMaxAccountNo(levelOne, levelTwo, levelThree, Level, Operations.IdCompany, IdParent);
            //if (MaxAccountNo.HasValue)
            //{
            if (Level == 2)
            {
                txtAccountNumberLevel2.Text = MaxAccountNo;
            }
            else
            {
                txtAccountNumberLevel3.Text = MaxAccountNo;
            }

            //}
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            MetroTile ctrl = sender as MetroTile;
            if (ctrl != null)
            {
                if (ctrl.Name == "btnSaveLevel2")
                {
                    oelAccount.IdParent = Validation.GetSafeGuid(cbxHeadsLevel2.SelectedValue);
                }
                else
                {
                    oelAccount.IdParent = Validation.GetSafeGuid(cbxSubHeadsLevel3.SelectedValue);
                }
                oelAccount.UserId = Operations.UserID;
                oelAccount.IdCompany = null; //Operations.IdCompany;
                oelAccount.CreatedDateTime = DateTime.Now;
                if (IdAccount != Guid.Empty)
                {
                    oelAccount.IdAccount = IdAccount;
                }
                else
                {
                    oelAccount.IdAccount = Guid.NewGuid();
                }
                if (ctrl.Name == "btnSaveLevel2")
                {
                    oelAccount.AccountNo = Validation.GetSafeString(txtAccountNumberLevel2.Text);
                    oelAccount.LinkAccountNo = "";
                    oelAccount.PersonalAccountNo = "";
                    oelAccount.AccountName = txtAccountNameLevel2.Text;
                }
                else if (ctrl.Name == "btnSaveLevel3")
                {
                    oelAccount.AccountNo = Validation.GetSafeString(txtAccountNumberLevel3.Text);
                    oelAccount.LinkAccountNo = "";
                    oelAccount.PersonalAccountNo = "";
                    oelAccount.AccountName = txtAccountNameLevel3.Text;
                }
                if (ctrl.Name == "btnSaveLevel2")
                {
                    if (chkLevel2InActive.Checked == false)
                        oelAccount.IsActive = true;
                    else
                        oelAccount.IsActive = false;
                }
                else if (ctrl.Name == "btnSaveLevel3")
                {
                    if (chkLevel3InActive.Checked == false)
                        oelAccount.IsActive = true;
                    else
                        oelAccount.IsActive = false;
                }
                    if (ctrl.Name == "btnSaveLevel2")
                {
                    oelAccount.AccountType = cbxHeadsLevel2.Text;
                }
                else if (ctrl.Name == "btnSaveLevel3")
                {
                    oelAccount.AccountType = cbxSubHeadsLevel3.Text;
                }
                if (ctrl.Name == "btnSaveLevel2")
                {
                    oelAccount.IdLevel = 2;
                }
                else if (ctrl.Name == "btnSaveLevel3")
                {
                    oelAccount.IdLevel = 3;
                }
                
                oelAccount.Discription = "";

                if (MiscAccount == string.Empty)
                {
                    //if (!objAccountsBLL.CheckAccount(Validation.GetSafeLong(txtAccountNumber.Text), Operations.IdCompany))
                    {
                        infoResult = objAccountsBLL.InsertChartsOfAccounts(oelAccount);
                        if (infoResult.IsSuccess)
                        {
                            MessageBox.Show("Account Created Successfully...");
                            if (ctrl.Name == "btnSaveLevel2")
                            {
                                FillMaxAccountNo(2, Validation.GetSafeGuid(cbxHeadsLevel2.SelectedValue));
                            }
                            else if (ctrl.Name == "btnSaveLevel3")
                            {
                                FillMaxAccountNo(3, Validation.GetSafeGuid(cbxSubHeadsLevel3.SelectedValue));
                            }
                            //CbxHeads_SelectedIndexChanged(sender, e);
                            ClearControls();
                        }
                        else
                        {
                            MessageBox.Show("Some Problem Occured while Saving Account...");
                        }
                    }
                    //else
                    {
                        // MessageBox.Show("Account Already Exists...");
                    }
                }
                else
                {
                    if (ctrl.Name == "btnSaveLevel2")
                    {
                        oelAccount.IdAccount = IdAccountLevel2;
                    }
                    else if (ctrl.Name == "btnSaveLevel3")
                    {
                        oelAccount.IdAccount = IdAccountLevel3;
                    }
                    infoResult = objAccountsBLL.UpdateChartsOfAccounts(oelAccount);

                    if (infoResult.IsSuccess)
                    {
                        MessageBox.Show("Account Updated Successfully...");
                        if (ctrl.Name == "btnSaveLevel2")
                        {
                            FillMaxAccountNo(2, Validation.GetSafeGuid(cbxHeadsLevel2.SelectedValue));
                        }
                        else if (ctrl.Name == "btnSaveLevel3")
                        {
                            FillMaxAccountNo(3, Validation.GetSafeGuid(cbxSubHeadsLevel3.SelectedValue));
                        }                        
                        ClearControls();
                    }
                    else
                    {
                        MessageBox.Show("Some Problem Occured while Saving Account...");
                    }
                }
            }
        }
        private void ClearControls()
        {
            txtAccountNameLevel2.Text = string.Empty;
            txtAccountNameLevel3.Text = string.Empty;
            MiscAccount = string.Empty;
            chkLevel2InActive.Checked = false;
            chkLevel3InActive.Checked = false;
            //txtHeadDiscription.Text = string.Empty;
            IdAccount = Guid.Empty;
        }
    }
}
