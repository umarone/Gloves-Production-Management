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
using MetroFramework.Controls;

namespace Accounts.UI
{
    public partial class frmLotsFilters : MetroForm
    {
        #region Variables
        string AccountNo = string.Empty;
        Guid IdQuality = Guid.Empty;
        frmFindAccounts frmfindAccount;
        frmStockAccounts frmstockItems;
        frmLotDetail frmlotdetail;
        frmLotsProfitLoss frmlotsprofitloss;
        #endregion
        #region Form Mehotds And Events
        public frmLotsFilters()
        {
            InitializeComponent();
        }
        private void frmLotsFilters_Load(object sender, EventArgs e)
        {
            this.grdLotsByFilter.AutoGenerateColumns = false;
            txtLotNo.Visible = false;
            txtDrumMan.Visible = false;
            txtQuality.Visible = false;
            dtStart.Visible = false;
            dtEnd.Visible = false;
            cbxSearchByPiecesType.Visible = false;
        }
        #endregion
        #region Methods
        private void ClearControls()
        {
            txtLotNo.Text = string.Empty;
            txtDrumMan.Text = string.Empty;
            AccountNo = string.Empty;
            IdQuality = Guid.Empty;
            grdLotsByFilter.DataSource = null;
        }
        #endregion
        #region Controls Events
        private void txtDrumMan_ButtonClick(object sender, EventArgs e)
        {
            frmfindAccount = new frmFindAccounts();
            frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
            frmfindAccount.ShowDialog();
        }
        void frmfindAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            AccountNo = oelAccount.AccountNo;
            txtDrumMan.Text = oelAccount.AccountName;
        }
        private void txtQuality_ButtonClick(object sender, EventArgs e)
        {
            frmstockItems = new frmStockAccounts();
            frmstockItems.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockItems_ExecuteFindStockAccountEvent);
            frmstockItems.ShowDialog();
        }
        void frmstockItems_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            txtQuality.Text = oelItems.ItemName;
            IdQuality = oelItems.IdItem;
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            MetroCheckBox chk = sender as MetroCheckBox;            
            if (chk.Name == "chkLotNo")
            {
                if (chkLotNo.Checked)
                {
                    chkDrumMan.Checked = false;
                    chkQuality.Checked = false;
                    chkByPeriod.Checked = false;
                    chkByPieces.Checked = false;
                }
                txtLotNo.Visible = true;
                txtDrumMan.Visible = false;
                txtQuality.Visible = false;
                dtStart.Visible = false;
                dtEnd.Visible = false;
                cbxSearchByPiecesType.Visible = false;
            }
            else if (chk.Name == "chkDrumMan")
            {
                if (chkDrumMan.Checked)
                {
                    chkLotNo.Checked = false;
                    chkQuality.Checked = false;
                    chkByPeriod.Checked = false;
                    chkByPieces.Checked = false;
                }

                txtDrumMan.Visible = true;
                txtQuality.Visible = false;
                dtStart.Visible = false;
                dtEnd.Visible = false;
                txtLotNo.Visible = false;
                cbxSearchByPiecesType.Visible = false;
            }
            else if (chk.Name == "chkQuality")
            {
                if (chkQuality.Checked)
                {
                    chkLotNo.Checked = false;
                    chkDrumMan.Checked = false;
                    chkByPeriod.Checked = false;
                    chkByPieces.Checked = false;
                }

                txtDrumMan.Visible = false;
                txtQuality.Visible = true;
                dtStart.Visible = false;
                dtEnd.Visible = false;
                txtLotNo.Visible = false;
                cbxSearchByPiecesType.Visible = false;
            }
            else if (chk.Name == "chkByPeriod")
            {
                if (chkByPeriod.Checked)
                {
                    chkLotNo.Checked = false;
                    chkDrumMan.Checked = false;
                    chkQuality.Checked = false;
                    chkByPieces.Checked = false;
                }

                txtDrumMan.Visible = false;
                txtQuality.Visible = false;
                dtStart.Visible = true;
                dtEnd.Visible = true;
                txtLotNo.Visible = false;
                cbxSearchByPiecesType.Visible = false;
            }
            else if (chk.Name == "chkByPieces")
            {
                if (chkByPieces.Checked)
                {
                    chkLotNo.Checked = false;
                    chkDrumMan.Checked = false;
                    chkQuality.Checked = false;
                    chkByPeriod.Checked = false;
                }
                txtDrumMan.Visible = false;
                txtQuality.Visible = false;
                dtStart.Visible = false;
                dtEnd.Visible = false;
                txtLotNo.Visible = false;
                cbxSearchByPiecesType.Visible = true;
            }
            ClearControls();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new TanneryLotBLL();
            List<TanneryLotEL> list = new List<TanneryLotEL>();
            int FilterIndex = 0;
            if (chkLotNo.Checked)
            {
                FilterIndex = 1;
                
            }
            else if(chkDrumMan.Checked)
            {
                FilterIndex = 2;
            }
            else if(chkQuality.Checked)
            {
                FilterIndex = 3;
            }
            else if(chkByPeriod.Checked)
            {
                FilterIndex = 4;
            }
            else if (chkByPieces.Checked)
            {
                FilterIndex = 5;
            }
            list = manager.GetLotsFilterResults(Validation.GetSafeLong(txtLotNo.Text), Validation.GetSafeString(cbxSearchByPiecesType.Text), AccountNo, IdQuality, Convert.ToDateTime(dtStart.Value.ToShortDateString()), Convert.ToDateTime(dtEnd.Value.ToShortDateString()), FilterIndex);
            if (list.Count > 0)
            {
                grdLotsByFilter.DataSource = list;
            }
            else
            {
                grdLotsByFilter.DataSource = null;
            }
        }
        #endregion
        #region Grid Events        
        private void grdLotsByFilter_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                e.Value = "View Detail";
            }
            else if (e.ColumnIndex == 9)
            {
                e.Value = "View P & L";
            }
        }
        private void grdLotsByFilter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                frmlotdetail = new frmLotDetail();
                frmlotdetail.IdLotDetail = Validation.GetSafeGuid(grdLotsByFilter.Rows[e.RowIndex].Cells["colIdLot"].Value);
                frmlotdetail.ShowDialog();
            }
            else if (e.ColumnIndex == 9)
            {
                frmlotsprofitloss = new frmLotsProfitLoss();
                frmlotsprofitloss.IdLot = Validation.GetSafeGuid(grdLotsByFilter.Rows[e.RowIndex].Cells[0].Value);
                frmlotsprofitloss.LotNo = Validation.GetSafeLong(grdLotsByFilter.Rows[e.RowIndex].Cells[1].Value);
                frmlotsprofitloss.ShowDialog();
            }
        }
        #endregion        
    }
}
