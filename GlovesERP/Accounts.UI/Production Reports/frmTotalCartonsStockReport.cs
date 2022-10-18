using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.EL;
using Accounts.BLL;
using Accounts.Common;

using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmTotalCartonsStockReport : MetroForm
    {
        Guid IdItem;
        public int ProductionType { get; set; }
        frmStockAccounts frmstockaccounts;
        DataTable dtDetail;
        public frmTotalCartonsStockReport()
        {
            InitializeComponent();
        }
        private void frmTotalCartonsStockReport_Load(object sender, EventArgs e)
        {
            this.grdTotalCartons.AutoGenerateColumns = false;
            if (ProductionType == 1)
            {
                this.Text = "Gloves Total Cartons Stock Report";
            }
            else if (ProductionType == 2)
            {
                this.Text = "Garments Total Cartons Stock Report";
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new ProductionProcessDetailBLL();
            List<VoucherDetailEL> listDetail = null;
            if (ProductionType == 1)
            {
                listDetail = manager.GetGlovesGarmentsTotalCartonsStockByArticle(IdItem, ProductionType);
            }
            else if (ProductionType == 2)
            {
                listDetail = manager.GetGlovesGarmentsTotalCartonsStockByArticle(IdItem, ProductionType);
            }
            if (listDetail.Count > 0)
            {
                PopulateRejectionDetailStock(listDetail);
            }

        }
        private void PopulateRejectionDetailStock(List<VoucherDetailEL> lstStock)
        {
            dtDetail = new DataTable();
            decimal DebitStock = 0, CreditStock = 0, Balance = 0, Qty = 0;
            ////if (lstStock.Count > 0)
            ////{s
            ////    grdTotalStock.DataSource = lstStock;                
            ////}
            dtDetail.Columns.Clear();
            dtDetail.Rows.Clear();
            dtDetail.Clear();
            dtDetail.Columns.Add("WorkDate");
            dtDetail.Columns.Add("Units");
            dtDetail.Columns.Add("Qty");
            dtDetail.Columns.Add("Balance");

            for (int i = 0; i < lstStock.Count; i++)
            {
                // Add rows.
                DataRow dr = dtDetail.NewRow();
                dr[0] = lstStock[i].WorkDate;
                dr[1] = lstStock[i].Units;
                dr[2] = lstStock[i].Qty;
                if (Validation.GetSafeString(lstStock[i].GatePassType) == "In")
                {
                    CreditStock = Validation.GetSafeLong(lstStock[i].Units);
                    Balance -= CreditStock;
                    Qty -= CreditStock;
                    dr[3] = Math.Abs(Qty);
                }
                if (Validation.GetSafeString(lstStock[i].GatePassType) == "Out")
                {
                    DebitStock = Validation.GetSafeLong(lstStock[i].Qty);
                    Balance += DebitStock;
                    Qty += DebitStock;
                    dr[3] = Math.Abs(Qty);
                }
                dtDetail.Rows.Add(dr);
            }
            if (dtDetail.Rows.Count > 0)
            {
                grdTotalCartons.DataSource = dtDetail;
            }
            else
            {
                grdTotalCartons.DataSource = null;
            }
        }
        //private void PopulateSummaryStock(List<VoucherDetailEL> lstStock, int i)
        //{
        //    dtSummary = new DataTable();
        //    ////if (lstStock.Count > 0)
        //    ////{
        //    ////    grdTotalStock.DataSource = lstStock;                
        //    ////}
        //    dtSummary.Columns.Clear();
        //    dtSummary.Rows.Clear();
        //    dtSummary.Clear();
        //    dtSummary.Columns.Add("ItemName");
        //    dtSummary.Columns.Add("StockOut");
        //    dtSummary.Columns.Add("StockIn");
        //    dtSummary.Columns.Add("RemainingStock");

        //    for (int i = 0; i < lstStock.Count; i++)
        //    {
        //        // Add rows.
        //        DataRow dr = dtSummary.NewRow();
        //        dr[0] = lstStock[i].AccountName;
        //        dr[1] = lstStock[i].ItemName;
        //        dr[2] = lstStock[i].StockOut;
        //        dr[3] = lstStock[i].StockIn;
        //        dr[4] = lstStock[i].RemainingStock;
        //        dtSummary.Rows.Add(dr);
        //    }
        //    if (dtSummary.Rows.Count > 0)
        //    {
        //        grdInspectionSummary.DataSource = dtSummary;
        //    }
        //    else
        //    {
        //        grdInspectionSummary.DataSource = null;
        //    }
        //}
        private void txtProduct_ButtonClick(object sender, EventArgs e)
        {
            frmstockaccounts = new frmStockAccounts();
            frmstockaccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockaccounts_ExecuteFindStockAccountEvent);
            frmstockaccounts.ShowDialog();
        }
        void frmstockaccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            IdItem = oelItems.IdItem;
            txtProduct.Text = oelItems.ItemName;
        }
    }
}
