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
    public partial class frmFindTradingCo : MetroForm
    {
        TradingEL oelTrading = null;
        public delegate void FindTradingDelegate(Object Sender, TradingEL oelTrading);
        public event FindTradingDelegate ExecuteFindTradingEvent;
        public frmFindTradingCo()
        {
            InitializeComponent();
        }
        private void frmFindTradingCo_Load(object sender, EventArgs e)
        {
            this.grdFindTradingCo.AutoGenerateColumns = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PopulateTradingCo();
        }
        private void PopulateTradingCo()
        {
            var manager = new TradingBLL();
            List<TradingEL> list = manager.GetAllTradingCo(Operations.IdCompany);
            if (list.Count > 0)
            {
                grdFindTradingCo.DataSource = list;
            }
            else
            {
                grdFindTradingCo.DataSource = null;
            }
        }

        private void grdFindTradingCo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (grdFindTradingCo.CurrentRow != null)
                {
                    int RowIndex = grdFindTradingCo.CurrentRow.Index;
                    oelTrading = new TradingEL();
                    oelTrading.IdTrading = Validation.GetSafeGuid(grdFindTradingCo.Rows[RowIndex].Cells[0].Value);
                    oelTrading.TradingCode = Validation.GetSafeString(grdFindTradingCo.Rows[RowIndex].Cells[1].Value);
                    oelTrading.TradingName = grdFindTradingCo.Rows[RowIndex].Cells[2].Value.ToString();
                    this.Close();
                }
            }
            else
            {
                txtID.Focus();
            }
        }

        private void grdFindTradingCo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            oelTrading = new TradingEL();
            oelTrading.IdTrading = Validation.GetSafeGuid(grdFindTradingCo.Rows[e.RowIndex].Cells[0].Value);
            oelTrading.TradingCode = Validation.GetSafeString(grdFindTradingCo.Rows[e.RowIndex].Cells[1].Value);
            oelTrading.TradingName = grdFindTradingCo.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.Close();
        }

        private void frmFindTradingCo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (oelTrading != null)
            {
                ExecuteFindTradingEvent(sender, oelTrading);
            }
        }
    }
}
