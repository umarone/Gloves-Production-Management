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
using System.IO;


namespace Accounts.UI
{
    public partial class frmPersons : MetroForm
    {
        //UCPersons ucPerson = new UCPersons();
        ImageConverter converter = new ImageConverter();
        frmFindAccounts frmaccounts = null;
        public string PersonsType { get; set; }
        public string AccountNo { get; set; }
        Guid IdPerson = Guid.Empty;
        int ParentId;
        string PersonType;
        public frmPersons()
        {
            //this.Size = ucPerson.Size;
            InitializeComponent();
            if (AccountNo == null)
            {
                AccountNo = string.Empty;
            }
        }

        private void frmPersons_Load(object sender, EventArgs e)
        {
            if (PersonsType == "Persons")
            {
                this.Text = "Customers And Suppliers";
                txtSalary.Visible = false;
                cbxDepartments.Visible = false;
            }
            else if(PersonsType == "Employees")
            {
                this.Text = "Employees";
                txtSalary.Visible = true;
            }

            GetAllCurrencies();
            if (AccountNo != string.Empty)
            {
                GetPersonByAccount(AccountNo);
            }
        }
        private void LoadDepartments(int Index)
        {
            var manager = new ProcessesBLL();
            List<ProcessesEL> list = manager.GetAllDepartmentsByType(Index); //manager.GetAllProcesses();
            if (list.Count > 0)
            {
                list.Insert(0, new ProcessesEL() { IdProcess = Guid.Empty, ProcessName = "Select Department" });
                cbxDepartments.DataSource = list;

                cbxDepartments.ValueMember = "IdProcess";
                cbxDepartments.DisplayMember = "ProcessName";
            }
        }
        private void GetAllCurrencies()
        {
            var manager = new CurrencyBLL();
            List<CurrencyEL> list = manager.GetAllCurrencies();
            if (list.Count > 0)
            {
                list.Insert(0, new CurrencyEL() { IdCurrency = -1, CurrencyName = "Select Currency" });
                cbxCurrencies.DataSource = list;

                cbxCurrencies.DisplayMember = "CurrencyName";
                cbxCurrencies.ValueMember = "IdCurrency";
                cbxCurrencies.SelectedIndex = -1;
            }
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
                    //btnDelete.Enabled = true;
                }
                else
                {
                    //btnDelete.Enabled = false;
                }
            }
            //else
            //{
            //    btnSave.Enabled = false;
            //    btnDelete.Enabled = false;
            //    chkPosted.Checked = true;
            //    chkPosted.Enabled = true;
            //}
        }
        //private void txtSearchPersons_Enter(object sender, EventArgs e)
        //{
        //    txtSearchPersons.WaterMark = "";
        //}
        //private void txtSearchPersons_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        grdPersons.Focus();
        //        e.KeyChar = (char)Keys.Tab;
        //    }
        //}
        //private void txtSearchPersons_TextChanged(object sender, EventArgs e)
        //{
        //    var manager = new PersonsBLL();
        //    List<PersonsEL> list = new List<PersonsEL>();
        //    string searchString = "";
        //    if (txtSearchPersons.Text != string.Empty)
        //    {
        //        char[] chars = txtSearchPersons.Text.ToArray();
        //        if (chars.Length > 0 && char.IsNumber(chars[0]))
        //        {
        //            list = manager.SearchPersonsByAccountNo(Validation.GetSafeLong(txtSearchPersons.Text), Operations.IdCompany);
        //            PopulatePersonsBySearch(list);
        //        }
        //        else
        //        {
        //            searchString = txtSearchPersons.Text;
        //            if (txtSearchPersons.Text.Contains("\t"))
        //                searchString = txtSearchPersons.Text.Remove(txtSearchPersons.Text.Count() - 1);
        //            list = manager.SearchPersonByPersonName(searchString, Operations.IdCompany);
        //            PopulatePersonsBySearch(list);
        //        }
        //    }
        //    else if (grdPersons.Rows.Count > 0)
        //    {
        //        grdPersons.DataSource = null;
        //    }
        //}
        //private void PopulatePersonsBySearch(List<PersonsEL> list)
        //{
        //    if (grdPersons.Rows.Count > 1)
        //    {
        //        grdPersons.DataSource = null;
        //    }
        //    grdPersons.DataSource = list;
        //}

        //private void grdPersons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    IdPerson = Validation.GetSafeGuid(grdPersons.Rows[e.RowIndex].Cells["colAccountId"].Value);
        //    AccountCode = Validation.GetSafeLong(grdPersons.Rows[e.RowIndex].Cells["colAccountCode"].Value);
        //    PersonType = Validation.GetSafeString(grdPersons.Rows[e.RowIndex].Cells["colType"].Value);
        //    //CbxHeads.SelectedValue = Validation.GetSafeInteger(grdAccounts.Rows[e.RowIndex].Cells["colIdParent1"].Value);
        //    //CbxHeads_SelectedIndexChanged(sender, e);
        //    GetPerson(IdPerson);
        //}
        //private void grdPersons_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        if (grdPersons.CurrentRow != null)
        //        {
        //            int RowIndex = grdPersons.CurrentRow.Index;
                    
        //            IdPerson = Validation.GetSafeGuid(grdPersons.Rows[RowIndex].Cells["colAccountId"].Value);
        //            AccountCode = Validation.GetSafeLong(grdPersons.Rows[RowIndex].Cells["colAccountCode"].Value);
        //            PersonType = Validation.GetSafeString(grdPersons.Rows[RowIndex].Cells["colType"].Value);

        //            GetPerson(IdPerson);
        //        }
        //    }
        //}
        private void frmPersons_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                ClearControls();
            }
        }        
        private void btnSave_Click(object sender, EventArgs e)
        {
            var manager = new PersonsBLL();

            PersonsEL oelPerson = new PersonsEL();
            oelPerson.IdAccount = Validation.GetSafeGuid(IdPerson);
            if (PersonsType == "Employees" && cbxDepartments.Text == "Select Department")
            {
                MessageBox.Show("Department Is Must For Factory Employees");
            }
            else
            {
                oelPerson.IdDepartment = Validation.GetSafeGuid(cbxDepartments.SelectedValue);
            }
            oelPerson.IdCompany = Operations.IdCompany;
            oelPerson.AccountNo = Validation.GetSafeString(txtAccountNo.Text);
            oelPerson.PersonName = txtFirstName.Text;
            oelPerson.LastName = txtLastName.Text;
            oelPerson.Cnic = txtNIC.Text;
            oelPerson.IdParent1 = ParentId;
            if (cbxCurrencies.Text == "Select Currency")
            {
                MessageBox.Show("Please Select Currency");
                return;
            }
            oelPerson.IdCurrency = Validation.GetSafeLong(cbxCurrencies.SelectedValue);
            oelPerson.Contact = txtContact.Text;
            oelPerson.Salary = txtSalary.Text;
            oelPerson.PersonPic = (byte[])converter.ConvertTo(PersonPic.Image,typeof(byte[]));
            oelPerson.Address = txtSalary.Text;
            oelPerson.NTN = txtNTN.Text;
            oelPerson.Discription = Validation.GetSafeString(txtDiscription.Text);
            oelPerson.PersonType = PersonType;

            if (btnSave.Text == "Save")
            {
                if (manager.CreatePersons(oelPerson).IsSuccess)
                {
                    MessageBox.Show("Person Information Created Successfully.....");
                    ClearControls();
                }
                else
                {
                    MessageBox.Show("Problem Occured.....");
                }
            }
            else
            {
                if (manager.UpdatePerson(oelPerson).IsSuccess)
                {
                    MessageBox.Show("Person Information Updated Successfully.....");
                    ClearControls();
                }
                else
                {
                    MessageBox.Show("Problem Occured.....");
                }
            }
        }
        private void ClearControls()
        {
            cbxCurrencies.SelectedIndex = -1;
            txtAccountNo.Enabled = true;
            IdPerson = Guid.Empty;
            txtAccountNo.Text = string.Empty;
            txtNIC.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtNTN.Text = string.Empty;
            txtDiscription.Text = string.Empty;
            txtPersonalCode.Text = string.Empty;
            cbxDepartments.SelectedIndex = -1;
            btnSave.Text = "Save";
        }

        private void mtlPic_Click(object sender, EventArgs e)
        {
            if (picDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PersonPic.Image = Image.FromFile(picDialog.FileName);
            }
        }

        private void txtAccountNo_ButtonClick(object sender, EventArgs e)
        {
            frmaccounts = new frmFindAccounts();
            frmaccounts.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmaccounts_ExecuteFindAccountEvent);
            frmaccounts.ShowDialog();
        }

        void frmaccounts_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            GetPerson(oelAccount);
        }
        private void GetPerson(AccountsEL oelAccount)
        {
            var manager = new PersonsBLL();
            PersonsEL oelPerson = new PersonsEL();
            List<PersonsEL> list = manager.GetPersonById(oelAccount.IdAccount);
            if (list.Count > 0)
            {
                IdPerson = list[0].IdAccount;
                txtAccountNo.Text = list[0].AccountNo.ToString();
                txtFirstName.Text = list[0].PersonName;
                txtLastName.Text = list[0].LastName;
                txtNIC.Text = list[0].Cnic;
                txtContact.Text = list[0].Contact;
                txtNTN.Text = list[0].NTN;
                txtSalary.Text = list[0].Salary;
                if (list[0].IdDepartment != null && list[0].IdDepartment != Guid.Empty)
                {
                    List<ProcessesEL> lstDept = GetDepartmentById(list[0].IdDepartment);
                    if (lstDept != null && lstDept.Count > 0)
                    {
                        CbxDepartmentsHead.SelectedIndex = lstDept[0].ProcessType;
                        LoadDepartments(lstDept[0].ProcessType);
                        cbxDepartments.SelectedValue = list[0].IdDepartment;
                    }
                }
                //cbxDepartments.SelectedValue = list[0].IdDepartment;
                if (list[0].PersonPic != null)
                {
                    PersonPic.Image = Image.FromStream(new MemoryStream(list[0].PersonPic));
                }
                txtDiscription.Text = list[0].Discription;
                ParentId = list[0].IdParent1;
                btnSave.Text = "Update";
                PersonType = list[0].PersonType;
                ParentId = list[0].IdParent1;
                cbxCurrencies.SelectedValue = list[0].IdCurrency;
            }
            else
            {
                txtFirstName.Text = oelAccount.AccountName;
                txtAccountNo.Text = oelAccount.AccountNo;
                PersonType = oelAccount.AccountType;
                txtAccountNo.Enabled = false;
                IdPerson = oelAccount.IdAccount;
                ParentId = oelAccount.IdHead;
            }
        }
        private void GetPersonByAccount(string AccountNo)
        {
            var manager = new PersonsBLL();
            List<PersonsEL> list = new List<PersonsEL>();
            list = manager.GetPersonByAccount(Operations.IdCompany, AccountNo);
            if (list.Count > 0)
            {
                IdPerson = list[0].IdAccount;
                txtAccountNo.Text = Validation.GetSafeString(list[0].AccountNo);
                txtFirstName.Text = list[0].PersonName;
                txtLastName.Text = Validation.GetSafeString(list[0].LastName);
                txtNIC.Text = Validation.GetSafeString(list[0].Cnic);
                txtContact.Text = Validation.GetSafeString(list[0].Contact);
                txtNTN.Text = Validation.GetSafeString(list[0].NTN);
                txtSalary.Text = list[0].Salary;
                if (list[0].IdDepartment != null && list[0].IdDepartment != Guid.Empty)
                {
                    List<ProcessesEL> lstDept =  GetDepartmentById(list[0].IdDepartment);
                    if (lstDept != null && lstDept.Count > 0)
                    {
                        CbxDepartmentsHead.SelectedIndex = lstDept[0].ProcessType;
                        LoadDepartments(lstDept[0].ProcessType);
                        cbxDepartments.SelectedValue = list[0].IdDepartment;
                    }
                }
               // cbxDepartments.SelectedValue = list[0].IdDepartment;
                if (list[0].PersonPic != null)
                {
                    PersonPic.Image = Image.FromStream(new MemoryStream(list[0].PersonPic));
                }
                txtDiscription.Text = list[0].Discription;
                ParentId = list[0].IdParent1;
                btnSave.Text = "Update";
                PersonType = list[0].PersonType;
                ParentId = list[0].IdParent1;
                cbxCurrencies.SelectedValue = list[0].IdCurrency;
            }
            else
            {
                MessageBox.Show("Person Not Found...");
            }
        }
        private List<ProcessesEL> GetDepartmentById(Guid IdDept)
        {
            var manager = new ProcessesBLL();
            List<ProcessesEL> lstDept = manager.GetProcessById(IdDept);
            return lstDept;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtAccountNo.Enabled = true;
            ClearControls();
        }

        private void CbxDepartmentsHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxDepartmentsHead.SelectedIndex != -1 && CbxDepartmentsHead.SelectedIndex != 0)
            {
                LoadDepartments(CbxDepartmentsHead.SelectedIndex);
            }
        }
    }
}
