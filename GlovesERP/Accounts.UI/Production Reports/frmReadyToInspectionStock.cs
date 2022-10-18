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
    public partial class frmReadyToInspectionStock : MetroForm
    {
        Guid IdItem;
        public int ProductionType { get; set; }
        public int TabType { get; set; }
        frmStockAccounts frmstockaccounts;
        DataTable dtDetail;
        DataTable dtSummary;
        public frmReadyToInspectionStock()
        {
            InitializeComponent();
        }
        private void frmReadyToInspectionStock_Load(object sender, EventArgs e)
        {
            this.grdInspectionSummary.AutoGenerateColumns = false;
            this.grdInspectionDetail.AutoGenerateColumns = false;
            this.grdPackingSummary.AutoGenerateColumns = false;
            this.grdPackingDetail.AutoGenerateColumns = false;

            if (TabType == 1 && ProductionType == 1)
            {
                tabPackingInspection.TabPages.Remove(tabPacking);
                this.Text = "Gloves Ready For Inspection Stock";
            }
            else if (TabType == 1 && ProductionType == 2)
            {
                tabPackingInspection.TabPages.Remove(tabPacking);
                this.Text = "Garments Ready For Inspection Stock";
            }
            else if (TabType == 2 && ProductionType == 1)
            {
                tabPackingInspection.TabPages.Remove(tabInspection);
                this.Text = "Gloves Ready For Packing Stock";
            }
            else if (TabType == 2 && ProductionType == 2)
            {
                tabPackingInspection.TabPages.Remove(tabInspection);
                this.Text = "Garments Ready For Packing Stock";
            }
        }
              
        private void btnLoad_Click(object sender, EventArgs e)
        {
                var manager = new ProductionProcessDetailBLL();
                List<VoucherDetailEL> listDetail = null;
                List<VoucherDetailEL> listSummary = null;
                if (TabType == 1)
                {
                    listDetail = manager.GetReadyToInspectionStockByArticle(IdItem, ProductionType);
                    listSummary = manager.GetReadyToInspectionStockForAllArticles(ProductionType);
                    if (listDetail.Count > 0)
                    {
                        PopulateDetailStock(listDetail,1);
                    }
                    if (listSummary.Count > 0)
                    {
                        grdInspectionSummary.DataSource = listSummary;
                    }    
                }
                else
                {
                    listDetail = manager.GetReadyToPackingStockByArticle(IdItem, ProductionType);
                    listSummary = manager.GetReadyToPackingStockForAllArticles(ProductionType);
                    if (listDetail.Count > 0)
                    {
                        PopulateDetailStock(listDetail,2);
                    }
                    if (listSummary.Count > 0)
                    {
                        grdPackingSummary.DataSource = listSummary;
                    }    
                }                           
                        
        }
        private void PopulateDetailStock(List<VoucherDetailEL> lstStock, int j)
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
            if (j == 1)
            {
                if (dtDetail.Rows.Count > 0)
                {
                    grdInspectionDetail.DataSource = dtDetail;
                }
                else
                {
                    grdInspectionDetail.DataSource = null;
                }
            }
            else
            {
                if (dtDetail.Rows.Count > 0)
                {
                    grdPackingDetail.DataSource = dtDetail;
                }
                else
                {
                    grdPackingDetail.DataSource = null;
                }
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
        private void txtProduct_KeyPress(object sender, KeyPressEventArgs e)
        {   
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtProduct.Text == string.Empty)
                {
                    txtProduct.Focus();
                }
                else
                    btnLoad.Focus();
            }
            else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                frmstockaccounts = new frmStockAccounts();
                frmstockaccounts.SearchText = e.KeyChar.ToString();
                frmstockaccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockaccounts_ExecuteFindStockAccountEvent);
                frmstockaccounts.ShowDialog();
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == (char)Keys.Back)
            {

            }
            else
                e.Handled = true;
        }
        void frmstockaccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            IdItem = oelItems.IdItem;
            txtProduct.Text = oelItems.ItemName;
        }
    }
}
