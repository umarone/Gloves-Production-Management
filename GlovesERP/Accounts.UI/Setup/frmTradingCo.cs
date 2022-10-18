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
    public partial class frmTradingCo : MetroForm
    {
        Guid IdTrading;
        frmFindTradingCo frmfindTradingCo = null;
        public frmTradingCo()
        {
            InitializeComponent();
        }

        private void frmTradingCo_Load(object sender, EventArgs e)
        {
            GetMaxTradingCode();
        }
        private void GetMaxTradingCode()
        {
            var Manager = new TradingBLL();
            txtTradingCode.Text = Validation.GetSafeString(Manager.GetMaxTradingCode(Operations.IdCompany));
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TradingEL oelTrading = new TradingEL();
            var Manager = new TradingBLL();
            if (Validate())
            {
                if (IdTrading == Guid.Empty)
                {
                    oelTrading.IdTrading = Guid.NewGuid();
                }
                else
                {
                    oelTrading.IdTrading = IdTrading;
                }                
                oelTrading.IdCompany = Operations.IdCompany;
                oelTrading.TradingCode = txtTradingCode.Text;
                oelTrading.TradingName = txtTradingName.Text;
                oelTrading.TradingDiscription = Validation.GetSafeString(txtTradingDescription.Text);

                if (IdTrading == Guid.Empty)
                {
                    if (Manager.InsertTradingCo(oelTrading).IsSuccess)
                    {
                        GetMaxTradingCode();
                        ClearControls();
                    }
                }
                else
                {
                    if (Manager.UpdateTradingCo(oelTrading).IsSuccess)
                    {
                        GetMaxTradingCode();
                        ClearControls();
                    }
                }
            }
        }
        private void ClearControls()
        {
            IdTrading = Guid.Empty;
            //txtTradingCode.Text = string.Empty;
            txtTradingName.Text = string.Empty;
            txtTradingDescription.Text = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var manager = new TradingBLL();
            if (manager.DeleteTradingCo(IdTrading).IsSuccess)
            {
                GetMaxTradingCode();
                ClearControls();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmfindTradingCo = new frmFindTradingCo();
            frmfindTradingCo.ExecuteFindTradingEvent += new frmFindTradingCo.FindTradingDelegate(frmfindTradingCo_ExecuteFindTradingEvent);
            frmfindTradingCo.ShowDialog();
        }

        void frmfindTradingCo_ExecuteFindTradingEvent(object Sender, TradingEL oelTrading)
        {
            IdTrading = oelTrading.IdTrading;
            GetTrading(IdTrading);
        }
        private void GetTrading(Guid Id)
        {
            var manager = new TradingBLL();
            List<TradingEL> list = manager.GetTradingCoById(Id);
            if (list.Count > 0)
            {
                txtTradingCode.Text = list[0].TradingCode;
                txtTradingName.Text = list[0].TradingName;
                txtTradingDescription.Text = list[0].TradingDiscription;                
            }
        }

        private void frmTradingCo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                ClearControls();
            }
        }
    }
}
