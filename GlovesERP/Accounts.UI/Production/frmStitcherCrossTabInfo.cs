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
    public partial class frmStitcherCrossTabInfo : MetroForm
    {
        #region Variables
        frmFindAccounts frmfindAccount;
        frmStockAccounts frmfindProducts;
        string AccountNo = "";
        DataTable dt;
        Guid IdItem = Guid.Empty;
        #endregion
        public frmStitcherCrossTabInfo()
        {
            InitializeComponent();
        }

        private void frmStitcherCrossTabInfo_Load(object sender, EventArgs e)
        {

        }
        private void AccEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (AccEditBox.Text == string.Empty)
                {
                    AccEditBox.Focus();
                }
                else
                    btnLoad.Focus();
            }
            else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                e.Handled = true;
                frmfindAccount = new frmFindAccounts();
                frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                frmfindAccount.ShowDialog();

            }
            else
                e.Handled = false;
        }
        private void AccEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindAccount = new frmFindAccounts();
            frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
            frmfindAccount.ShowDialog();
        }
        void frmfindAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            AccountNo = oelAccount.AccountNo;
            AccEditBox.Text = oelAccount.AccountName;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var manager = new ProductionProcessDetailBLL();
            var IManager = new ItemsBLL();
            bool IsMandatory = false;
            List<ItemsEL> listItems = null;
            long BalanceKhata = 0;
            decimal DebitStock = 0, CreditStock = 0, Balance = 0, Qty = 0;
            Button btnSender = sender as Button;
            if (btnSender.Name == "btnLoad")
            {
                dt = manager.GetStitcherArticleWiseCrossTabInfo(AccountNo);
            }
            else
            {
                if (IdItem == Guid.Empty)
                    MessageBox.Show("Please Select Article First");
                else
                    dt = manager.GetStitcherArticleWiseCrossTabInfoByArticle(AccountNo, IdItem);
            }                
            if (dt.Rows.Count > 0)
            {
                grdStitcherArticlesInfo.DataSource = dt;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {                    
                        if (grdStitcherArticlesInfo.Columns[i].Name == "LEATHER CUTTING ")
                        {
                            CreditStock = Validation.GetSafeLong(dt.Rows[j]["LEATHER CUTTING "]);//(dt.Rows[j].ItemArray[9]);
                            Balance += CreditStock;
                            Qty += CreditStock;
                            dt.Rows[j]["Balance"] = Math.Abs(Qty);
                        }
                        if (dt.Columns[i].ColumnName == "ArticleIn")
                        {
                            DebitStock = Validation.GetSafeLong(dt.Rows[j]["ArticleIn"]); //(dt.Rows[j].ItemArray[10]);
                            Balance -= DebitStock;
                            Qty -= DebitStock;
                            dt.Rows[j]["Balance"] = Math.Abs(Qty);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                //for (int i = 0; i < dt.Columns.Count; i++)
                //{
                //    for (int j = 0; j < dt.Rows.Count; j++)
                //    {
                //        listItems = IManager.GetItemByName(dt.Columns[i].ColumnName);
                //        if (listItems.Count > 0)
                //        {
                //            if (listItems[0].IsMandatory != null)
                //            {
                //                IsMandatory = listItems[0].IsMandatory.Value;
                //                if (IsMandatory)
                //                {
                //                    BalanceKhata += Validation.GetSafeLong(dt.Rows[j][dt.Columns[i].ColumnName]); 
                //                    dt.Rows[j]["Balance"] = Validation.GetSafeLong(BalanceKhata) - Validation.GetSafeLong(dt.Rows[j]["ArticleIn"]);
                                    
                //                }
                //                else
                //                {
                //                    //dt.Rows[j]["Balance"] = 0;
                //                }
                //            }
                //        }   
                //    }                    
                //}
                grdStitcherArticlesInfo.DataSource = dt;
            }
        }

        private void txtPackingSearch_TextChanged(object sender, EventArgs e)
        {
            //DataView DV = new DataView(dt);
            //DV.RowFilter = string.Format("ArticleName LIKE '%{0}%'", txtPackingSearch.Text);
            //grdStitcherArticlesInfo.DataSource = DV;
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            if (grdStitcherArticlesInfo.Rows.Count > 0)
            {
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in grdStitcherArticlesInfo.Columns)
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
                for (int i = 0; i < grdStitcherArticlesInfo.Columns.Count; i++)
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

                foreach (DataGridViewRow row in grdStitcherArticlesInfo.Rows)
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

        private void txtPackingSearch_ButtonClick(object sender, EventArgs e)
        {
            frmfindProducts = new frmStockAccounts();
            frmfindProducts.ExecuteFindStockAccountEvent += FrmfindProducts_ExecuteFindStockAccountEvent;
            frmfindProducts.ShowDialog();
        }

        private void txtPackingSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtPackingSearch.Text == string.Empty)
                {
                    txtPackingSearch.Focus();
                }
                else
                    BtnFilter.Focus();
            }
            else if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
            {
                frmfindProducts = new frmStockAccounts();
                frmfindProducts.SearchText = e.KeyChar.ToString();
                frmfindProducts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(FrmfindProducts_ExecuteFindStockAccountEvent);
                frmfindProducts.ShowDialog();
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == (char)Keys.Back)
            {

            }
            else
                e.Handled = true;
        }

        private void FrmfindProducts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            IdItem = oelItems.IdItem;
            txtPackingSearch.Text = oelItems.ItemName;
        }
    }
}
