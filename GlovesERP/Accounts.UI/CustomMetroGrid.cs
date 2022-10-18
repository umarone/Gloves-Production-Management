using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MetroFramework.Forms;
using MetroFramework.Controls;

namespace Accounts.UI
{
    class CustomMetroGrid : MetroGrid
    {
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                return true;
            return base.ProcessDataGridViewKey(e);
        }
    }
}
