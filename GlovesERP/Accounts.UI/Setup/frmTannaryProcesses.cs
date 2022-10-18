using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.EL;
using Accounts.Common;
using Accounts.BLL;
using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmTannaryProcesses : MetroForm
    {
        #region Variables
        Guid IdProcess;
        frmFindProcess frmfindProcess;
        #endregion
        #region Form Methods And Events
        public frmTannaryProcesses()
        {
            InitializeComponent();
        }
        private void frmTannaryProcesses_Load(object sender, EventArgs e)
        {
            GetMaxProcessCode();
        }
        #endregion
        #region Simpel Methods
        private void GetMaxProcessCode()
        {
            var Manager = new ProcessesBLL();
            txtProcessCode.Text = Validation.GetSafeString(Manager.GetMaxProcessCode());
        }
        private void ClearControls()
        {
            IdProcess = Guid.Empty;
            //txtTradingCode.Text = string.Empty;
            txtProcessName.Text = string.Empty;
            cbxDepartmentType.SelectedIndex = 0;
            txtDeptRates.Text = string.Empty;
            txtProcessDescription.Text = string.Empty;
        }

        #endregion
        #region Validation Methods
        private bool ValidateControl()
        {
            bool IsValidate = true;
            if (txtProcessCode.Text == string.Empty)
            {
                IsValidate = false;
            }
            if (txtProcessName.Text == string.Empty)
            {
                IsValidate = false;
            }
            if (cbxDepartmentType.SelectedIndex == -1 || cbxDepartmentType.SelectedIndex == 0)
            {
                IsValidate = false;
            }
            return IsValidate;
        }
        #endregion
        #region Button Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessesEL oelProcess = new ProcessesEL();
            var Manager = new ProcessesBLL();
            if (ValidateControl())
            {
                if (IdProcess == Guid.Empty)
                {
                    oelProcess.IdProcess = Guid.NewGuid();
                }
                else
                {
                    oelProcess.IdProcess = IdProcess;
                }
                oelProcess.ProcessCode = txtProcessCode.Text;
                oelProcess.ProcessName = txtProcessName.Text;
                oelProcess.ProcessType = cbxDepartmentType.SelectedIndex;
                oelProcess.ProcessRate = Validation.GetSafeDecimal(txtDeptRates.Text);
                oelProcess.Discription = Validation.GetSafeString(txtProcessDescription.Text);
                oelProcess.CreatedDateTime = dtCreationTime.Value;

                if (IdProcess == Guid.Empty)
                {
                    if (Manager.InsertProcesses(oelProcess).IsSuccess)
                    {
                        GetMaxProcessCode();
                        ClearControls();
                    }
                }
                else
                {
                    if (Manager.UpdateProcesses(oelProcess).IsSuccess)
                    {
                        GetMaxProcessCode();
                        ClearControls();
                    }
                }
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var Manager = new ProcessesBLL();
            if(MessageBox.Show("Are You Sure To Delete Department ?","Deleteing Department", MessageBoxButtons.YesNo) == DialogResult.Yes)
            if (Manager.DeleteProcesses(IdProcess).IsSuccess)
            {
                GetMaxProcessCode();
                ClearControls();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmfindProcess = new frmFindProcess();
            frmfindProcess.ExecuteFindProcessEvent += new frmFindProcess.FindProcessDelegate(frmfindProcess_ExecuteFindProcessEvent);
            frmfindProcess.ShowDialog();
        }
        #endregion
        #region Cutom and Controls Events
        void frmfindProcess_ExecuteFindProcessEvent(object Sender, ProcessesEL oelProcess)
        {
            IdProcess = oelProcess.IdProcess;
            GetProcess(IdProcess);
        }
        private void txtProcessCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                ClearControls();
            }
        }
        #endregion
        #region Transactional Methods
        private void GetProcess(Guid Id)
        {
            var manager = new ProcessesBLL();
            List<ProcessesEL> list = manager.GetProcessById(Id);
            if (list.Count > 0)
            {
                txtProcessCode.Text = list[0].ProcessCode;
                txtProcessName.Text = list[0].ProcessName;
                cbxDepartmentType.SelectedIndex = list[0].ProcessType;
                txtDeptRates.Text = list[0].ProcessRate.ToString();
                txtProcessDescription.Text = list[0].Discription;
                dtCreationTime.Value = Convert.ToDateTime(list[0].CreatedDateTime);
            }
        }
        #endregion
    }
}
