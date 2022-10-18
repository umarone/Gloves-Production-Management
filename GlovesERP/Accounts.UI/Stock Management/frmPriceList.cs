using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounts.BLL;
using Accounts.EL;

using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmPriceList : MetroForm
    {
        frmPriceListReport frmPriceReport;
        public frmPriceList()
        {
            InitializeComponent();
        }

        private void frmPriceList_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.DgvPriceList.AutoGenerateColumns = false;
            this.DgvPriceList.Columns[0].ReadOnly = true;
            this.DgvPriceList.Columns[1].ReadOnly = true; 
            this.DgvPriceList.Columns[2].ReadOnly = true;

            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetPriceWiseItems(Operations.IdCompany);
            DgvPriceList.DataSource = list;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<ItemsEL> oelItemsCollections = new List<ItemsEL>();
            for (int i = 0; i < DgvPriceList.Rows.Count; i++)
            {
                ItemsEL oelItem = new ItemsEL();
                oelItem.ItemNo = DgvPriceList.Rows[i].Cells[0].Value.ToString();
                oelItem.ItemName = DgvPriceList.Rows[i].Cells[1].Value.ToString();
                if (DgvPriceList.Rows[i].Cells[3].Value == null || DgvPriceList.Rows[i].Cells[3].Value.ToString() == string.Empty)
                {
                    oelItem.Description = "N/A";
                }
                else
                {
                    oelItem.Description = DgvPriceList.Rows[i].Cells[3].Value.ToString();
                }
                //if (DgvPriceList.Rows[i].Cells[4].Value == DBNull.Value)
                //{
                //    oelItem.ProductRegNo = "N/A";
                //}
                //else
                //{
                //    oelItem.ProductRegNo = Convert.ToString(DgvPriceList.Rows[i].Cells[4].Value);
                //}
                if (DgvPriceList.Rows[i].Cells[4].Value == DBNull.Value)
                {
                    oelItem.UnitPrice = 0;
                }
                else
                {
                    oelItem.UnitPrice = Convert.ToDecimal(DgvPriceList.Rows[i].Cells[4].Value);
                }
                oelItemsCollections.Add(oelItem);
            }
            var manager = new ItemsBLL();
            if (manager.CreateUpdatePriceList(oelItemsCollections,Operations.IdCompany))
            {
                MessageBox.Show("Price List Updated");            
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPriceReport = new frmPriceListReport();
            frmPriceReport.Show(this);
        }
    }
}
