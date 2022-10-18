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
    public partial class frmFindProcess : MetroForm
    {
        ProcessesEL oelProcess = null;
        public delegate void FindProcessDelegate(Object Sender, ProcessesEL oelProcess);
        public event FindProcessDelegate ExecuteFindProcessEvent;
        public frmFindProcess()
        {
            InitializeComponent();
        }

        private void frmFindProcess_Load(object sender, EventArgs e)
        {
            this.grdFindProcesses.AutoGenerateColumns = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PopulateProcesses();
        }
        private void PopulateProcesses()
        {
            var manager = new ProcessesBLL();
            List<ProcessesEL> list = manager.GetAllProcesses();
            if (list.Count > 0)
            {
                grdFindProcesses.DataSource = list;
            }
            else
            {
                grdFindProcesses.DataSource = null;
            }
        }

        private void grdFindProcesses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (grdFindProcesses.CurrentRow != null)
                {
                    int RowIndex = grdFindProcesses.CurrentRow.Index;
                    oelProcess = new ProcessesEL();
                    oelProcess.IdProcess = Validation.GetSafeGuid(grdFindProcesses.Rows[RowIndex].Cells[0].Value);
                    oelProcess.ProcessCode = Validation.GetSafeString(grdFindProcesses.Rows[RowIndex].Cells[1].Value);
                    oelProcess.ProcessName = grdFindProcesses.Rows[RowIndex].Cells[2].Value.ToString();
                    this.Close();
                }
            }
            else
            {
                txtID.Focus();
            }
        }

        private void grdFindProcesses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            oelProcess = new ProcessesEL();
            oelProcess.IdProcess = Validation.GetSafeGuid(grdFindProcesses.Rows[e.RowIndex].Cells[0].Value);
            oelProcess.ProcessCode = Validation.GetSafeString(grdFindProcesses.Rows[e.RowIndex].Cells[1].Value);
            oelProcess.ProcessName = grdFindProcesses.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.Close();
        }

        private void frmFindProcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (oelProcess != null)
            {
                ExecuteFindProcessEvent(sender, oelProcess);
            }
        }
    }
}
