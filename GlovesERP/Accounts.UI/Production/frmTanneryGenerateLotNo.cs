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
    public partial class frmTanneryGenerateLotNo : MetroForm
    {
        #region Variables
        Guid IdVoucher = Guid.Empty;
        Guid IdQuality;
        Guid IdLot;
        string LoadType;
        frmStockAccounts frmstockAccounts;
        #endregion
        public frmTanneryGenerateLotNo()
        {
            InitializeComponent();
        }        
        private void frmTanneyGenerateLotNo_Load(object sender, EventArgs e)
        {
            FillVehicles();     
        }
        private void btnDrummingGenerateLot_Click(object sender, EventArgs e)
        {
            if (IdVoucher != Guid.Empty)
            {
                var manager = new TanneryLotBLL();
                TanneryLotEL oelLot = new TanneryLotEL();
                List<TanneryLotEL> list = manager.GetLotByLotNo(Validation.GetSafeLong(txtLotNo.Text));
                if (list.Count > 0)
                {
                    MessageBox.Show("This Lot Already Exists in Vehicle No :" + list[0].VehicleNo);
                    return;
                }
                else
                {
                    oelLot.IdLot = Guid.NewGuid();
                    IdLot = oelLot.IdLot;
                    oelLot.IdVoucher = IdVoucher;
                    oelLot.LotNo = Validation.GetSafeLong(txtLotNo.Text);
                    oelLot.LotWeight = Validation.GetSafeDecimal(txtLotWeight.Text);
                    oelLot.LotDate = DtLot.Value;
                    if (IdQuality == Guid.Empty)
                    {
                        MessageBox.Show("Please Select Lot Quality Before Lot Creation");
                        return;
                    }
                    else if (cbxLotType.SelectedIndex == 0 || cbxLotType.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please Select Lot Type Before Lot Creation");
                        return;
                    }
                    oelLot.LotType = cbxLotType.SelectedIndex;
                    oelLot.IdQuality = IdQuality;
                    oelLot.Status = "Open/New";
                    oelLot.ProcessName = "Nothing";
                    oelLot.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                    oelLot.CloseDate = DateTime.Now;
                    if (manager.CreateLot(oelLot))
                    {
                        MessageBox.Show("Lot Created Successfully...");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Vehicle First To Generate");
            }
        }
        private void txtQuality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
            {
                frmstockAccounts = new frmStockAccounts();
                frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                frmstockAccounts.SearchText = e.KeyChar.ToString();
                frmstockAccounts.ShowDialog(this);
                e.Handled = true;
                //SendKeys.Send("{TAB}");
            }
            else
                e.Handled = true;

        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            txtQuality.Text = oelItems.ItemName;
            IdQuality = oelItems.IdItem;            
        }
        private void cbxVehicles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxVehicles.SelectedIndex > 0)
            {
                LoadType = "Vehicle";                
                txtLotNo.Text = string.Empty;
                GetVoucherInfoByVehicleNo(cbxVehicles.Text);                
            }
        }
        private void GetVoucherInfoByVehicleNo(string VehicleNo)
        {
            var Manager = new TanneryProcessesHeadBLL();
            List<TanneryProcessesHeadEL> list = Manager.GetVoucherInfoByVehicleNo(VehicleNo);
            if (list.Count > 0)
            {
                IdVoucher = list[0].IdVoucher;
            }
            else
            {
                IdVoucher = Guid.Empty;
            }
        }
        private void FillVehicles()
        {
            var manager = new TanneryProcessesHeadBLL();
            List<TanneryProcessesHeadEL> list = manager.GetVehiclesByStatus(2);
            if (list.Count > 0)
            {
                list.RemoveAll(x => x.IsComplete == true);
            }
            list.Insert(0, new TanneryProcessesHeadEL() { VehicleNo = "" });
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    cbxVehicles.Items.Add(list[i].VehicleNo ?? "");
                }
            }
        }
    }
 }
