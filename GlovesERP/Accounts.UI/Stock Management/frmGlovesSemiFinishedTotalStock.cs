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
using SpreadsheetLight;
using System.Diagnostics;

using MetroFramework.Forms;
namespace Accounts.UI
{
    public partial class frmGlovesSemiFinishedTotalStock : MetroForm
    {
        #region Variables
        DataTable dt;
        #endregion
        #region Form Methods And Events
        public frmGlovesSemiFinishedTotalStock()
        {
            InitializeComponent();
        }
        private void frmGlovesSemiFinishedTotalStock_Load(object sender, EventArgs e)
        {
            grdTotalStock.AutoGenerateColumns = false;
            FillCategories("Gloves Semi Finished Materials");
        }
        #endregion
        #region Fill Methods
        private void FillCategories(string CatType)
        {
            var manager = new CategoryBLL();
            List<CategoryEL> listCategories = manager.GetAllCategoriesByCategoryTypes(Operations.IdCompany, CatType);

            CbxCategories.DataSource = listCategories;
            CbxCategories.DisplayMember = "CategoryName";
            CbxCategories.ValueMember = "IdCategory";
        }
        //private void FillTradingCo()
        //{
        //    var manager = new TradingBLL();
        //    List<TradingEL> listTradingCo = manager.GetAllTradingCo();

        //    CbxTrading.DataSource = listTradingCo;
        //    CbxTrading.DisplayMember = "TradingName";
        //    CbxTrading.ValueMember = "IdTrading";
        //}
        #endregion
        #region Button Events
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new StockRecieptBLL();
            List<StockReceiptEL> lstStock = new List<StockReceiptEL>();
            if (chkDate.Checked)
            {
                lstStock = manager.GetGlovesSemiFinishMaterialTotalStock(Validation.GetSafeGuid(CbxCategories.SelectedValue), Operations.IdCompany);
            }
            else
            {
                lstStock = manager.GetDateWiseGlovesSemiFinishMaterialTotalStock(Validation.GetSafeGuid(CbxCategories.SelectedValue), Operations.IdCompany, StartDate.Value, EndDate.Value);
            }
            if (lstStock.Count > 0)
            {
                dt = DataOperations.ToDataTable(lstStock);
                grdTotalStock.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Stock Found For This Category....");
                grdTotalStock.DataSource = null;
            }
        }
        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            if (grdTotalStock.Rows.Count > 0)
            {
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in grdTotalStock.Columns)
                {
                    if (column.Visible)
                    {
                        dt.Columns.Add(column.HeaderText);
                    }
                }

                //Add Header Rows....
                dt.Rows.Add();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Rows[0][i] = dt.Columns[i].ColumnName; //"Account Name"; 
                }

                // Add Empty Row....
                dt.Rows.Add();
                for (int i = 0; i < grdTotalStock.Columns.Count; i++)
                {
                    if (i != dt.Columns.Count)
                    {
                        dt.Rows[1][i] = "";
                    }
                    else
                    {
                        break;
                    }
                }

                foreach (DataGridViewRow row in grdTotalStock.Rows)
                {
                    dt.Rows.Add();
                    int colindex = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //if (cell.Value != null)
                        //{
                        if (cell.Visible)
                        {
                            //dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                            dt.Rows[dt.Rows.Count - 1][colindex] = cell.Value ?? 0.ToString();
                            colindex++;
                        }
                        //}
                    }
                }

                SLDocument slExcelExport = new SLDocument();


                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    slExcelExport.SetColumnWidth(i, 20);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        slExcelExport.SetCellValue(j + 1, i + 1, dt.Rows[j].ItemArray[i].ToString());
                    }
                }
                slExcelExport.Save();

                Process.Start("Book1.xlsx");
            }
        }
        #endregion
        #region TextBox Events
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("ItemName LIKE '%{0}%'", txtsearch.Text);
            grdTotalStock.DataSource = DV;
            //(grdTotalStock.DataSource as DataTable).DefaultView.RowFilter = string.Format("colAccountName='{0}'", txtsearch.Text);
        }
        #endregion
    }
}
