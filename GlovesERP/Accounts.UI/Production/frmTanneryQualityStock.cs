using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MetroFramework.Forms;
using Accounts.EL;
using Accounts.BLL;
using Accounts.Common;

namespace Accounts.UI
{
    public partial class frmTanneryQualityStock : MetroForm
    {
        frmStockAccounts frmstockAccounts;
        Guid IdItem;
        public frmTanneryQualityStock()
        {
            InitializeComponent();
        }
        private void frmTanneryQualityStock_Load(object sender, EventArgs e)
        {
            this.grdTanneryStockReport.AutoGenerateColumns = false;
        }
        private void PEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmstockAccounts = new frmStockAccounts();
            frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
            frmstockAccounts.ShowDialog();
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, EL.ItemsEL oelItems)
        {
            PEditBox.Text = oelItems.ItemName;
            IdItem = oelItems.IdItem;
        }
        private void btnProductReport_Click(object sender, EventArgs e)
        {
            decimal DebitStock = 0, CreditStock = 0, Balance = 0,Qty = 0, TotalValue = 0;
            var manager = new TanneryStockBLL();
            var CManager = new TanneryChemicalBLL();
            List<TanneryStockEL> list = manager.GetTanneryStock(IdItem);
            if (list.Count > 0)
            {
                list.RemoveAll(x => x.Units == 0);
                grdTanneryStockReport.DataSource = list;
                for (int i = 0; i < list.Count; i++)
                {
                    if (Validation.GetSafeString(grdTanneryStockReport.Rows[i].Cells["colType"].Value) == "In")
                    {
                        DebitStock = Validation.GetSafeLong(grdTanneryStockReport.Rows[i].Cells["colUnits"].Value);
                        Balance += DebitStock;
                        grdTanneryStockReport.Rows[i].Cells["colClosing"].Value = Balance.ToString() + " KG";
                        Qty += Validation.GetSafeDecimal(grdTanneryStockReport.Rows[i].Cells["colUnits"].Value);

                    }
                    if (Validation.GetSafeString(grdTanneryStockReport.Rows[i].Cells["colType"].Value) == "Out")
                    {
                        CreditStock = Validation.GetSafeLong(grdTanneryStockReport.Rows[i].Cells["colUnits"].Value);
                        Balance -= CreditStock;
                        grdTanneryStockReport.Rows[i].Cells["colClosing"].Value = Balance.ToString();
                        Qty -= Validation.GetSafeDecimal(grdTanneryStockReport.Rows[i].Cells["colUnits"].Value);
                    }
                   
                    TotalValue += Validation.GetSafeDecimal(grdTanneryStockReport.Rows[i].Cells["colValue"].Value);
                    if (Validation.GetSafeDecimal(grdTanneryStockReport.Rows[i].Cells["colUnits"].Value) != 0)
                    {
                        grdTanneryStockReport.Rows[i].Cells["colPerUnitAvg"].Value = Validation.GetSafeDecimal(grdTanneryStockReport.Rows[i].Cells["colValue"].Value) / Validation.GetSafeDecimal(grdTanneryStockReport.Rows[i].Cells["colUnits"].Value);
                    }
                    if (Qty > 0)
                    {
                        //grdTanneryStockReport.Rows[i].Cells["colPerUnitAvg"].Value = (TotalValue / Qty).ToString("0.00");
                        grdTanneryStockReport.Rows[i].Cells["colStockBalance"].Value = (Validation.GetSafeDecimal(grdTanneryStockReport.Rows[i].Cells["colPerUnitAvg"].Value) * Balance).ToString("0.00");
                    }
                }
            }
        }       
    }
}
