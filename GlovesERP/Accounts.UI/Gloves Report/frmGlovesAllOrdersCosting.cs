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
using SpreadsheetLight;
using System.Diagnostics;

namespace Accounts.UI
{
    public partial class frmGlovesAllOrdersCosting : MetroForm
    {
        #region Variables
        frmFindAccounts frmfindAccount;
        frmGlovesAllOrdersCostingDetail frmallorderscostingdetails;
        string EventFiringName;
        public int ProductionType { get; set; }
        public int WorkType { get; set; }
        public string SummaryType { get; set; }
        string AccountNo;
        DataTable dt;
        #endregion
        #region Form Events
        public frmGlovesAllOrdersCosting()
        {
            InitializeComponent();
        }
        private void frmGlovesAllOrdersCosting_Load(object sender, EventArgs e)
        {
            this.grdOrders.AutoGenerateColumns = false;
            if (ProductionType == 1)
            {
                this.Text = "Gloves Order Costing";
            }
            else
                this.Text = "Garments Order Costing";
        }
        #endregion
        #region Buttons Region
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new ProductionProcessDetailBLL();
            List<ProductionProcessDetailEL> listOrders = manager.GetAllOrdersCosting(ProductionType);
            if (listOrders.Count > 0)
            {
                dt = DataOperations.ToDataTable(listOrders);
                grdOrders.DataSource = listOrders;
            }
            else
                grdOrders.DataSource = null;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (grdOrders.Rows.Count > 0)
            {
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in grdOrders.Columns)
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
                for (int i = 0; i < grdOrders.Columns.Count; i++)
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

                foreach (DataGridViewRow row in grdOrders.Rows)
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
        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("AccountName LIKE '%{0}%'", txtCustomerName.Text);
            grdOrders.DataSource = DV;
        }
        #endregion
        #region Grid Events
        private void grdOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                e.Value = "View Detail";
            }
        }
        private void grdOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                frmallorderscostingdetails = new frmGlovesAllOrdersCostingDetail();
                Guid IdVoucher = Validation.GetSafeGuid(grdOrders.Rows[e.RowIndex].Cells[0].Value);
                frmallorderscostingdetails.IdOrder = IdVoucher;
                frmallorderscostingdetails.ShowDialog();
            }
        }
        #endregion
    }
}

