using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Accounts.UI
{
    public partial class frmtest : Form
    {
        public frmtest()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.RemoveAt(0);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Insert(0,tabPage1);
            tabControl1.SelectedIndex = 0;
        }
    }
}
