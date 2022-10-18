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
    public partial class frmMainTannery : MetroForm
    {
        #region Variables
        frmFindAccounts frmfindAccount;
        frmStockAccounts frmstockAccounts;
        Guid IdVoucher = Guid.Empty;
        Guid IdTrimming;
        Guid IdSplitting;
        Guid IdReTrimming;
        Guid IdShaving;
        Guid IdTanneryDrumming;
        Guid IdTanneryBuffing;
        Guid IdTanneryCutting;
        Guid IdQuality;
        Guid IdEntity;
        string LoadType;
        Guid IdLot;
        string EventFiringName;
        frmWorkPurchases frmworkpurchases;
        string EmpAccountNo = "";
        string EmpAccountName = "";
        decimal postAmount;
        bool EntryAlreadyDone;
        List<WagesEL> list = null;
        #endregion
        #region Form Methods
        public frmMainTannery()
        {
            InitializeComponent();
        }
        private void frmMainTannery_Load(object sender, EventArgs e)
        {
            this.grdTrimming.AutoGenerateColumns = false;
            this.grdSplitting.AutoGenerateColumns = false;
            this.grdRetrimming.AutoGenerateColumns = false;
            this.grdShaving.AutoGenerateColumns = false;
            this.grdDrumming.AutoGenerateColumns = false;
            this.grdBuffing.AutoGenerateColumns = false;
            this.grdCutting.AutoGenerateColumns = false;
            this.grdChemicals.AutoGenerateColumns = false;
            TanneryTab.SelectedIndex = 0;
            FillVehicles();
            FillMaxProductionNo();
            EnableDisableControls(false);
            GetTanneryPurchaseRates();
            this.grdChemicals.Columns[4].ReadOnly = true;
            this.grdChemicals.Columns[6].ReadOnly = true;
            this.grdChemicals.Columns[8].ReadOnly = true;

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
        private void EnableDisableControls(bool Status)
        {
            if (Status)
            {
                this.grdDrumming.Enabled = true;
                this.grdBuffing.Enabled = true;
                this.grdCutting.Enabled = true;
            }
            else
            {
                this.grdDrumming.Enabled = false;
                this.grdBuffing.Enabled = false;
                this.grdCutting.Enabled = false;
            }
        }
        private void FillMaxProductionNo()
        {
            var Manager = new TanneryProcessesHeadBLL();
            VEditBox.Text = Validation.GetSafeString(Manager.GetMaxProductionCode(Operations.IdCompany));
        }
        #endregion
        #region Trimming Grid Events
        private void grdTrimming_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 14)
            {
                e.Value = "Post";
            }
        }
        private void grdTrimming_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (grdTrimming.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdTrimming_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 13)
            {
                var Manager = new TanneryProcessDetailsBLL();
                if (Validation.GetSafeGuid(grdTrimming.Rows[e.RowIndex].Cells["colIdTrimming"].Value) != Guid.Empty)
                {
                    if (grdTrimming.Rows[e.RowIndex].ReadOnly)
                    {
                        if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                        {
                            MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdTrimming.Rows[e.RowIndex].Cells["colIdTrimming"].Value), Validation.GetSafeGuid(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingVoucherNo"].Value), "Trimming"))
                                {
                                    MessageBox.Show("Entry Deleted Successfully....");
                                    TanneryTab_SelectedIndexChanged(sender, e);
                                    FillVehicleClosingWeight();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdTrimming.Rows[e.RowIndex].Cells["colIdTrimming"].Value), Validation.GetSafeGuid(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingVoucherNo"].Value), "Trimming"))
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                TanneryTab_SelectedIndexChanged(sender, e);
                                FillVehicleClosingWeight();
                            }
                        }
                    }
                    /// Delete From Database.....
                }
                else
                {
                    for (int i = 0; i < grdTrimming.Columns.Count; i++)
                    {
                        grdTrimming.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Recored Insertion / Updation
            else if (e.ColumnIndex == 14)
            {
                var Manager = new TanneryProcessesHeadBLL();
                TanneryProcessesHeadEL oelTanneryHead = new TanneryProcessesHeadEL();
                TanneryProcessesEL oelTanneryProcess = new TanneryProcessesEL();
                List<TanneryProcessDetailsEL> oelTanneryProcessesDetailCollection = new List<TanneryProcessDetailsEL>();
                if (ValidateRecords(1))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelTanneryHead.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelTanneryHead.IdVoucher = IdVoucher;
                    }
                    oelTanneryHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelTanneryHead.IdCompany = Operations.IdCompany;
                    oelTanneryHead.UserId = Operations.UserID;
                    oelTanneryHead.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                    oelTanneryHead.VDate = TanneryDate.Value;
                    oelTanneryHead.Description = "N/A";
                    oelTanneryHead.Amount = 0;
                    oelTanneryHead.IsComplete = false;
                    oelTanneryHead.CloseDate = DateTime.Now;

                    if (IdTrimming == Guid.Empty)
                    {
                        oelTanneryProcess.IdProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelTanneryProcess.IdProcess = IdTrimming;
                    }
                    oelTanneryProcess.IdVoucher = oelTanneryHead.IdVoucher;
                    oelTanneryProcess.IdUser = Operations.UserID;
                    oelTanneryProcess.ProcessName = "Trimming";
                    oelTanneryProcess.VDate = DateTime.Now;

                    TanneryProcessDetailsEL oelTanneryDetail = new TanneryProcessDetailsEL();
                    oelTanneryDetail.IdUser = Operations.UserID;
                    if (grdTrimming.Rows[e.RowIndex].Cells["colIdTrimming"].Value == null)
                    {
                        oelTanneryDetail.IdProcessDetail = Guid.NewGuid();
                        grdTrimming.Rows[e.RowIndex].Cells["colIdTrimming"].Value = oelTanneryDetail.IdProcessDetail;
                        oelTanneryDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelTanneryDetail.IdProcessDetail = Validation.GetSafeGuid(grdTrimming.Rows[e.RowIndex].Cells["colIdTrimming"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdTrimming.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelTanneryDetail.IdProcessDetail;
                    oelTanneryDetail.IdProcess = oelTanneryProcess.IdProcess;
                    oelTanneryDetail.AccountNo = Validation.GetSafeString(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingAccountNo"].Value);
                    EmpAccountNo = Validation.GetSafeString(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingVendorName"].Value);
                    //oelTanneryDetail.Description = Validation.GetSafeString(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingDescription"].Value);
                    oelTanneryDetail.IdItem = Validation.GetSafeGuid(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingIdItem"].Value);
                    oelTanneryDetail.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                    oelTanneryDetail.Galma = Validation.GetSafeLong(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingGalma"].Value);
                    oelTanneryDetail.GalmaPieces = 0;
                    oelTanneryDetail.Puttha = Validation.GetSafeLong(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingPuttha"].Value);
                    oelTanneryDetail.PutthaPieces = 0;
                    oelTanneryDetail.DGalma = 0;
                    oelTanneryDetail.DPuttha = 0;
                    oelTanneryDetail.Pieces = 0;
                    oelTanneryDetail.SGalma = 0;
                    oelTanneryDetail.SPuttha = 0;
                    oelTanneryDetail.WorkDate = Convert.ToDateTime(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingDate"].Value);
                    oelTanneryDetail.SSet = 0;
                    oelTanneryDetail.Rate = Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingRate"].Value);
                    oelTanneryDetail.Amount = Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingAmount"].Value);
                    postAmount = oelTanneryDetail.Amount;
                    oelTanneryDetail.Description = BuildRemarks("Trimming Purchases", EmpAccountName, postAmount);
                    if (Validation.GetSafeString(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingAccountType"].Value) == "Employees")
                    {
                        oelTanneryDetail.Posted = true;
                    }
                    else
                    {
                        oelTanneryDetail.Posted = false;
                    }
                    oelTanneryProcessesDetailCollection.Add(oelTanneryDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdTrimming == Guid.Empty)
                        {
                            IdVoucher = oelTanneryHead.IdVoucher;
                            IdTrimming = oelTanneryProcess.IdProcess;
                            if (Manager.CreateProcessHead(oelTanneryHead, oelTanneryProcess, oelTanneryProcessesDetailCollection).IsSuccess)
                            {
                                FillVehicleClosingWeight();
                                //if (Validation.GetSafeString(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingAccountType"].Value) == "Employees")
                                //{
                                //    grdTrimming.Rows[e.RowIndex].ReadOnly = true;
                                //}
                                //if (Validation.GetSafeString(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingAccountType"].Value) != "Employees")
                                //{
                                //    frmworkpurchases = new frmWorkPurchases();
                                //    frmworkpurchases.ProductionType = "Tannery";
                                //    frmworkpurchases.IdEntity = IdEntity;
                                //    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                //    frmworkpurchases.EmpAccountName = EmpAccountName;
                                //    frmworkpurchases.PurchasesType = "Trimming Purchases";
                                //    frmworkpurchases.ProcessName = "Trimming";
                                //    frmworkpurchases.ProcessAmount = postAmount;
                                //    frmworkpurchases.ShowDialog();
                                //}
                                TanneryTab_SelectedIndexChanged(sender, e);
                            }
                        }
                    }
                    else
                    {
                        if (Validation.GetSafeString(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingAccountType"].Value) != "Employees")
                        {
                            //frmworkpurchases = new frmWorkPurchases();
                            //frmworkpurchases.ProductionType = "Tannery";
                            //frmworkpurchases.IdEntity = IdEntity;
                            //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                            //frmworkpurchases.EmpAccountName = EmpAccountName;
                            //frmworkpurchases.PurchasesType = "Trimming Purchases";
                            //frmworkpurchases.ProcessName = "Trimming";
                            //frmworkpurchases.ProcessAmount = postAmount;
                            //frmworkpurchases.ShowDialog();
                        }
                        FillVehicleClosingWeight();
                        TanneryTab_SelectedIndexChanged(sender, e);
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelTanneryProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            }
            #endregion
        }
        private void grdTrimming_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var Manager = new WagesBLL();
            decimal TotalWeight = 0;
            if (e.ColumnIndex == 9)
            {
                if (txtVehicalType.Text == "Puttha")
                {
                    //for (int i = 0; i < grdTrimming.Rows.Count - 1; i++)
                    {
                        //TotalWeight += Validation.GetSafeDecimal(grdTrimming.Rows[i].Cells["colTrimmingPuttha"].Value);
                        TotalWeight = Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingPuttha"].Value);
                        if (TotalWeight > Validation.GetSafeDecimal(txtVehicleClosingWeight.Text))
                        {
                            MessageBox.Show("You Are Exceeding With Vehicle Closing Weight");
                            grdTrimming.Rows[e.RowIndex].Cells["colTrimmingPuttha"].Value = "";
                            return;
                        }
                    }
                }
                else if (txtVehicalType.Text == "Galma/Puttha")
                {
                    //for (int i = 0; i < grdTrimming.Rows.Count - 1; i++)
                    {
                        //TotalWeight += (Validation.GetSafeDecimal(grdTrimming.Rows[i].Cells["colTrimmingPuttha"].Value) + Validation.GetSafeDecimal(grdTrimming.Rows[i].Cells["colTrimmingGalma"].Value));
                        TotalWeight = (Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingPuttha"].Value) + Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingGalma"].Value));
                        if (TotalWeight > Validation.GetSafeDecimal(txtVehicleClosingWeight.Text))
                        {
                            MessageBox.Show("You Are Exceeding With Vehicle Closing Weight");
                            grdTrimming.Rows[e.RowIndex].Cells["colTrimmingPuttha"].Value = "";
                            return;
                        }
                    }
                }
                if (grdTrimming.Rows[e.RowIndex].Cells["colTrimmingPuttha"].Value != null && Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingPuttha"].Value) > 0)
                {
                    list = Manager.GetWagesByProcess("Trimming");
                    if (list.Count > 0)
                    {
                        if (grdTrimming.Rows[e.RowIndex].Cells["colTrimmingPuttha"].Value != null)
                        {
                            grdTrimming.Rows[e.RowIndex].Cells["colTrimmingRate"].Value = list.Find(x => x.WorkType == "Puttha").WorkRate;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Set Wages First");
                    }
                }
            }
            else if (e.ColumnIndex == 10)
            {
                if (txtVehicalType.Text == "Galma")
                {
                    //for (int i = 0; i < grdTrimming.Rows.Count - 1; i++)
                    {
                        //TotalWeight += Validation.GetSafeDecimal(grdTrimming.Rows[i].Cells["colTrimmingGalma"].Value);
                        TotalWeight = Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingGalma"].Value);
                        if (TotalWeight > Validation.GetSafeDecimal(txtVehicleClosingWeight.Text))
                        {
                            MessageBox.Show("You Are Exceeding With Vehicle Closing Weight");
                            grdTrimming.Rows[e.RowIndex].Cells["colTrimmingGalma"].Value = "";
                            return;
                        }
                    }
                }
                else if (txtVehicalType.Text == "Galma/Puttha")
                {
                    //for (int i = 0; i < grdTrimming.Rows.Count - 1; i++)
                    {
                        //TotalWeight += (Validation.GetSafeDecimal(grdTrimming.Rows[i].Cells["colTrimmingPuttha"].Value) + Validation.GetSafeDecimal(grdTrimming.Rows[i].Cells["colTrimmingGalma"].Value));
                        TotalWeight = (Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingPuttha"].Value) + Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingGalma"].Value));
                        if (TotalWeight > Validation.GetSafeDecimal(txtVehicleClosingWeight.Text))
                        {
                            MessageBox.Show("You Are Exceeding With Vehicle Closing Weight");
                            grdTrimming.Rows[e.RowIndex].Cells["colTrimmingGalma"].Value = "";
                            return;
                        }
                    }
                }
                if (Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingGalma"].Value) != null && Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingGalma"].Value) > 0)
                {
                    list = Manager.GetWagesByProcess("Trimming");
                    if (list.Count > 0)
                    {
                        if (grdTrimming.Rows[e.RowIndex].Cells["colTrimmingGalma"].Value != null)
                        {
                            if (grdTrimming.Rows[e.RowIndex].Cells["colTrimmingPuttha"].Value != null)
                            {
                                grdTrimming.Rows[e.RowIndex].Cells["colTrimmingPuttha"].Value = null;
                            }
                        }
                        if (grdTrimming.Rows[e.RowIndex].Cells["colTrimmingGalma"].Value != null)
                        {
                            grdTrimming.Rows[e.RowIndex].Cells["colTrimmingRate"].Value = list.Find(x => x.WorkType == "Galma").WorkRate;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Set Wages First");
                    }
                }
            }
        }
        private void grdTrimming_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {

                if (grdTrimming.Rows[e.RowIndex].Cells["colTrimmingGalma"].Value != null)
                {

                    grdTrimming.Rows[e.RowIndex].Cells["colTrimmingAmount"].Value = Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingGalma"].Value) * Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingRate"].Value);
                }
                else
                {
                    grdTrimming.Rows[e.RowIndex].Cells["colTrimmingAmount"].Value = Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingPuttha"].Value) * Validation.GetSafeDecimal(grdTrimming.Rows[e.RowIndex].Cells["colTrimmingRate"].Value);
                }
            }
        }
        private void grdTrimming_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdTrimming.CurrentCellAddress.X == 7)
            {
                TextBox txtVendorName = e.Control as TextBox;
                if (txtVendorName != null)
                {
                    txtVendorName.KeyPress -= new KeyPressEventHandler(txtVendorName_KeyPress);
                    txtVendorName.KeyPress += new KeyPressEventHandler(txtVendorName_KeyPress);
                }
            }
            else if (grdTrimming.CurrentCellAddress.X == 8)
            {
                TextBox txtTrimmingProduct = e.Control as TextBox;
                if (txtTrimmingProduct != null)
                {
                    txtTrimmingProduct.KeyPress -= new KeyPressEventHandler(txtTrimmingProduct_KeyPress);
                    txtTrimmingProduct.KeyPress += new KeyPressEventHandler(txtTrimmingProduct_KeyPress);
                }
            }
        }
        void txtVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdTrimming.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Trimming";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        void txtTrimmingProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdTrimming.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "TrimmingProduct";
                    frmstockAccounts = new frmStockAccounts();
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Splitting Grid Events
        private void grdSplitting_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 12)
            {
                e.Value = "Posting";
            }

        }
        private void grdSplitting_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (grdSplitting.Rows[e.RowIndex].Cells[5].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdSplitting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 11)
            {
                var Manager = new TanneryProcessDetailsBLL();
                Int64 TotalQuantity = 0;
                if (Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    if (grdSplitting.Rows[e.RowIndex].ReadOnly)
                    {
                        if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                        {
                            MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                            return;
                        }
                        else
                        {
                            Int64 Pieces = 0;
                            if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                TotalQuantity = Manager.GetProcessesCompareStockBeforeDeleting("Splitting", "ReTrimming", "Puttha", "Puttha", 1, cbxVehicles.Text, Guid.Empty);
                                if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value) > 0)
                                {
                                    for (int i = 0; i < grdSplitting.Rows.Count - 1; i++)
                                    {
                                        Pieces += Validation.GetSafeLong(grdSplitting.Rows[i].Cells["colSplittingPutthaPiece"].Value);
                                    }
                                    if (Pieces == TotalQuantity)
                                    {
                                        MessageBox.Show("Splitting Puttha Pieces are equal with ReTrimming Puttha Pieces, Please Delete Puttha Pieces First In Retrimming For Balanced Stock...");
                                        return;
                                    }
                                    else
                                    {
                                        Int64 ResultantPieces = Pieces - TotalQuantity;
                                        //if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value) < ResultantPieces)
                                        if (ResultantPieces > Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value))
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value), Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colSplittingVoucherNo"].Value), "Splitting"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else if (TotalQuantity == 0)
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value), Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colSplittingVoucherNo"].Value), "Splitting"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        //else if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value) > TotalQuantity)
                                        //{
                                        //    if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value), Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colSplittingVoucherNo"].Value), "Splitting"))
                                        //    {
                                        //        MessageBox.Show("Entry Deleted Successfully....");
                                        //        TanneryTab_SelectedIndexChanged(sender, e);
                                        //    }
                                        //}
                                        else
                                        {
                                            MessageBox.Show("Please Delete Puttha Pieces From ReTrimming Puttha First For Balanced Stock");
                                            return;
                                        }
                                    }
                                }
                                else if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value) > 0)
                                {
                                    TotalQuantity = Manager.GetProcessesCompareStockBeforeDeleting("Splitting", "ReTrimming", "Galma", "Galma", 1, cbxVehicles.Text, Guid.Empty);
                                    for (int i = 0; i < grdSplitting.Rows.Count - 1; i++)
                                    {
                                        Pieces += Validation.GetSafeLong(grdSplitting.Rows[i].Cells["colSplittingGalmaPieces"].Value);
                                    }
                                    if (Pieces == TotalQuantity)
                                    {
                                        MessageBox.Show("Splitting Galma Pieces are equal with ReTrimming Galma Pieces, Please Delete Galma Pieces First In Retrimming For Balanced Stock...");
                                        return;
                                    }
                                    else
                                    {
                                        Int64 ResultantPieces = Pieces - TotalQuantity;
                                        //if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value) < ResultantPieces)
                                        if (ResultantPieces > Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value))
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value), Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colSplittingVoucherNo"].Value), "Splitting"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else if (TotalQuantity == 0)
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value), Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colSplittingVoucherNo"].Value), "Splitting"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please Delete Puttha Pieces From ReTrimming Puttha First");
                                            return;
                                        }
                                    }
                                }
                                //else
                                //{
                                //    if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value), Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colSplittingVoucherNo"].Value), "Splitting"))
                                //    {
                                //        MessageBox.Show("Entry Deleted Successfully....");
                                //        TanneryTab_SelectedIndexChanged(sender, e);
                                //    }
                                //}
                            }
                        }
                    }
                    else
                    {
                        //if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        //{
                        //    if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value), Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colSplittingVoucherNo"].Value), "Splitting"))
                        //    {
                        //        MessageBox.Show("Entry Deleted Successfully....");
                        //        TanneryTab_SelectedIndexChanged(sender, e);
                        //    }
                        //}
                        Int64 Pieces = 0;
                        if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            TotalQuantity = Manager.GetProcessesCompareStockBeforeDeleting("Splitting", "ReTrimming", "Puttha", "Puttha", 1, cbxVehicles.Text, Guid.Empty);
                            if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value) > 0)
                            {
                                for (int i = 0; i < grdSplitting.Rows.Count - 1; i++)
                                {
                                    Pieces += Validation.GetSafeLong(grdSplitting.Rows[i].Cells["colSplittingPutthaPiece"].Value);
                                }
                                if (Pieces == TotalQuantity)
                                {
                                    MessageBox.Show("Splitting Puttha Pieces are equal with ReTrimming Puttha Pieces, Please Delete Puttha Pieces First In Retrimming For Balanced Stock...");
                                    return;
                                }
                                else
                                {
                                    Int64 ResultantPieces = Pieces - TotalQuantity;
                                    //if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value) < ResultantPieces)
                                    if (ResultantPieces > Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value))
                                    {
                                        if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value), Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colSplittingVoucherNo"].Value), "Splitting"))
                                        {
                                            MessageBox.Show("Entry Deleted Successfully....");
                                            TanneryTab_SelectedIndexChanged(sender, e);
                                        }
                                    }
                                    else if (TotalQuantity == 0)
                                    {
                                        if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value), Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colSplittingVoucherNo"].Value), "Splitting"))
                                        {
                                            MessageBox.Show("Entry Deleted Successfully....");
                                            TanneryTab_SelectedIndexChanged(sender, e);
                                        }
                                    }
                                    //else if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value) > TotalQuantity)
                                    //{
                                    //    if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value), Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colSplittingVoucherNo"].Value), "Splitting"))
                                    //    {
                                    //        MessageBox.Show("Entry Deleted Successfully....");
                                    //        TanneryTab_SelectedIndexChanged(sender, e);
                                    //    }
                                    //}
                                    else
                                    {
                                        MessageBox.Show("Please Delete Puttha Pieces From ReTrimming Puttha First For Balanced Stock");
                                        return;
                                    }
                                }
                            }
                            else if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value) > 0)
                            {
                                TotalQuantity = Manager.GetProcessesCompareStockBeforeDeleting("Splitting", "ReTrimming", "Galma", "Galma", 1, cbxVehicles.Text, Guid.Empty);
                                for (int i = 0; i < grdSplitting.Rows.Count - 1; i++)
                                {
                                    Pieces += Validation.GetSafeLong(grdSplitting.Rows[i].Cells["colSplittingGalmaPieces"].Value);
                                }
                                if (Pieces == TotalQuantity)
                                {
                                    MessageBox.Show("Splitting Galma Pieces are equal with ReTrimming Galma Pieces, Please Delete Galma Pieces First In Retrimming For Balanced Stock...");
                                    return;
                                }
                                else
                                {
                                    Int64 ResultantPieces = Pieces - TotalQuantity;
                                    //if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value) < ResultantPieces)
                                    if (ResultantPieces > Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value))
                                    {
                                        if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value), Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colSplittingVoucherNo"].Value), "Splitting"))
                                        {
                                            MessageBox.Show("Entry Deleted Successfully....");
                                            TanneryTab_SelectedIndexChanged(sender, e);
                                        }
                                    }
                                    else if (TotalQuantity == 0)
                                    {
                                        if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value), Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colSplittingVoucherNo"].Value), "Splitting"))
                                        {
                                            MessageBox.Show("Entry Deleted Successfully....");
                                            TanneryTab_SelectedIndexChanged(sender, e);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please Delete Puttha Pieces From ReTrimming Puttha First");
                                        return;
                                    }
                                }
                            }
                            //else
                            //{
                            //    if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value), Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colSplittingVoucherNo"].Value), "Splitting"))
                            //    {
                            //        MessageBox.Show("Entry Deleted Successfully....");
                            //        TanneryTab_SelectedIndexChanged(sender, e);
                            //    }
                            //}
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdSplitting.Columns.Count; i++)
                    {
                        grdSplitting.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 12)
            {
                var Manager = new TanneryProcessesHeadBLL();
                TanneryProcessesHeadEL oelTanneryHead = new TanneryProcessesHeadEL();
                TanneryProcessesEL oelTanneryProcess = new TanneryProcessesEL();
                List<TanneryProcessDetailsEL> oelSplittingProcessesDetailCollection = new List<TanneryProcessDetailsEL>();
                if (ValidateRecords(2))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelTanneryHead.IdVoucher = Guid.NewGuid();
                        IdVoucher = oelTanneryHead.IdVoucher;
                    }
                    else
                    {
                        oelTanneryHead.IdVoucher = IdVoucher;
                    }
                    oelTanneryHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelTanneryHead.IdCompany = Operations.IdCompany;
                    oelTanneryHead.UserId = Operations.UserID;
                    oelTanneryHead.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                    oelTanneryHead.VDate = TanneryDate.Value;
                    oelTanneryHead.Description = "N/A";
                    oelTanneryHead.Amount = 0;
                    oelTanneryHead.IsComplete = false;
                    oelTanneryHead.CloseDate = DateTime.Now;

                    if (IdSplitting == Guid.Empty)
                    {
                        oelTanneryProcess.IdProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelTanneryProcess.IdProcess = IdSplitting;
                    }
                    oelTanneryProcess.IdVoucher = oelTanneryHead.IdVoucher;
                    oelTanneryProcess.IdUser = Operations.UserID;
                    oelTanneryProcess.ProcessName = "Splitting";
                    oelTanneryProcess.VDate = DateTime.Now;

                    TanneryProcessDetailsEL oelTanneryDetail = new TanneryProcessDetailsEL();
                    oelTanneryDetail.IdUser = Operations.UserID;
                    if (grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value == null)
                    {
                        oelTanneryDetail.IdProcessDetail = Guid.NewGuid();
                        grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value = oelTanneryDetail.IdProcessDetail;
                        oelTanneryDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelTanneryDetail.IdProcessDetail = Validation.GetSafeGuid(grdSplitting.Rows[e.RowIndex].Cells["colIdSplitting"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdSplitting.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelTanneryDetail.IdProcessDetail;
                    oelTanneryDetail.IdProcess = oelTanneryProcess.IdProcess;
                    oelTanneryDetail.AccountNo = Validation.GetSafeString(grdSplitting.Rows[e.RowIndex].Cells["colSplittingAccountNo"].Value);
                    EmpAccountNo = Validation.GetSafeString(grdSplitting.Rows[e.RowIndex].Cells["colSplittingAccountNo"].Value);
                    EmpAccountName = Validation.GetSafeString(grdSplitting.Rows[e.RowIndex].Cells["colSplittingVendorName"].Value);
                    //oelTanneryDetail.Description = Validation.GetSafeString(grdSplitting.Rows[e.RowIndex].Cells["colSplittingDescription"].Value);
                    oelTanneryDetail.IdItem = Guid.Empty;
                    oelTanneryDetail.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                    oelTanneryDetail.Galma = 0;
                    oelTanneryDetail.Puttha = 0;
                    oelTanneryDetail.PutthaPieces = Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value);
                    oelTanneryDetail.GalmaPieces = Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value);
                    oelTanneryDetail.DGalma = 0;
                    oelTanneryDetail.DPuttha = 0;
                    oelTanneryDetail.Pieces = 0;
                    oelTanneryDetail.SGalma = 0;
                    oelTanneryDetail.SPuttha = 0;
                    oelTanneryDetail.WorkDate = Convert.ToDateTime(grdSplitting.Rows[e.RowIndex].Cells["colSplittingDate"].Value);
                    oelTanneryDetail.SSet = 0;
                    oelTanneryDetail.Rate = Validation.GetSafeDecimal(grdSplitting.Rows[e.RowIndex].Cells["colSplittingRate"].Value);
                    oelTanneryDetail.Amount = Validation.GetSafeDecimal(grdSplitting.Rows[e.RowIndex].Cells["colSplittingAmount"].Value);
                    postAmount = oelTanneryDetail.Amount;
                    oelTanneryDetail.Description = BuildRemarks("Splitting Purchases", EmpAccountName, postAmount);
                    if (Validation.GetSafeString(grdSplitting.Rows[e.RowIndex].Cells["colSplittingAccountType"].Value) == "Employees")
                    {
                        oelTanneryDetail.Posted = true;
                    }
                    else
                    {
                        oelTanneryDetail.Posted = false;
                    }
                    oelSplittingProcessesDetailCollection.Add(oelTanneryDetail);


                    if (!EntryAlreadyDone)
                    {
                        IdSplitting = oelTanneryProcess.IdProcess;
                        if (Manager.CreateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                        {
                            //if (Validation.GetSafeString(grdSplitting.Rows[e.RowIndex].Cells["colSplittingAccountType"].Value) == "Employees")
                            //{
                            //    grdSplitting.Rows[e.RowIndex].ReadOnly = true;
                            //}
                            //if (Validation.GetSafeString(grdSplitting.Rows[e.RowIndex].Cells["colSplittingAccountType"].Value) != "Employees")
                            //{
                            //    frmworkpurchases = new frmWorkPurchases();
                            //    frmworkpurchases.ProductionType = "Tannery";
                            //    frmworkpurchases.IdEntity = IdEntity;
                            //    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                            //    frmworkpurchases.EmpAccountName = EmpAccountName;
                            //    frmworkpurchases.PurchasesType = "Splitting Purchases";
                            //    frmworkpurchases.ProcessName = "Splitting";
                            //    frmworkpurchases.ProcessAmount = postAmount;
                            //    frmworkpurchases.ShowDialog();
                            //}
                            TanneryTab_SelectedIndexChanged(sender, e);
                        }

                    }
                    else
                    {
                        if (Validation.GetSafeString(grdSplitting.Rows[e.RowIndex].Cells["colSplittingAccountType"].Value) != "Employees")
                        {
                            //frmworkpurchases = new frmWorkPurchases();
                            //frmworkpurchases.IdEntity = IdEntity;
                            //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                            //frmworkpurchases.EmpAccountName = EmpAccountName;
                            //frmworkpurchases.PurchasesType = "Splitting Purchases";
                            //frmworkpurchases.ProcessName = "Splitting";
                            //frmworkpurchases.ProcessAmount = postAmount;
                            //frmworkpurchases.ShowDialog();
                        }
                        TanneryTab_SelectedIndexChanged(sender, e);
                    }
                    //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                    //{

                    //}
                }
            #endregion
            }
        }
        private void grdSplitting_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var Manager = new WagesBLL();
            if (e.ColumnIndex == 7)
            {
                list = Manager.GetWagesByProcess("Splitting");
                if (list.Count > 0)
                {
                    if (grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value != null)
                    {
                        grdSplitting.Rows[e.RowIndex].Cells["colSplittingRate"].Value = list.Find(x => x.WorkType == "PutthaPieces").WorkRate;
                    }
                }
                else
                {
                    MessageBox.Show("Please Set Wages First");
                }
            }
            else if (e.ColumnIndex == 8)
            {
                list = Manager.GetWagesByProcess("Splitting");
                if (list.Count > 0)
                {
                    if (grdSplitting.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value != null)
                    {
                        if (grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value != null)
                        {
                            grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value = null;
                        }
                    }
                    if (grdSplitting.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value != null)
                    {
                        grdSplitting.Rows[e.RowIndex].Cells["colSplittingRate"].Value = list.Find(x => x.WorkType == "GalmaPieces").WorkRate;
                    }
                }
                else
                {
                    MessageBox.Show("Please Set Wages First");
                }
            }
        }
        private void grdSplitting_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value != null && Validation.GetSafeDecimal(grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value) != 0)
            {
                grdSplitting.Rows[e.RowIndex].Cells["colSplittingAmount"].Value = Validation.GetSafeDecimal(grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value) * Validation.GetSafeDecimal(grdSplitting.Rows[e.RowIndex].Cells["colSplittingRate"].Value);
            }
            else
            {
                grdSplitting.Rows[e.RowIndex].Cells["colSplittingAmount"].Value = Validation.GetSafeDecimal(grdSplitting.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value) * Validation.GetSafeDecimal(grdSplitting.Rows[e.RowIndex].Cells["colSplittingRate"].Value);
            }
        }
        private void grdSplitting_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdSplitting.CurrentCellAddress.X == 6)
            {
                TextBox txtSplittingVendorName = e.Control as TextBox;
                if (txtSplittingVendorName != null)
                {
                    txtSplittingVendorName.KeyPress -= new KeyPressEventHandler(txtSplittingVendorName_KeyPress);
                    txtSplittingVendorName.KeyPress += new KeyPressEventHandler(txtSplittingVendorName_KeyPress);
                }
            }
        }
        void txtSplittingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdSplitting.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Splitting";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region ReTrimming Grid Events
        private void grdRetrimming_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 13)
            {
                e.Value = "Posting";
            }
        }
        private void grdRetrimming_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (grdRetrimming.Rows[e.RowIndex].Cells[5].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdRetrimming_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 12)
            {
                var Manager = new TanneryProcessDetailsBLL();
                Int64 TotalQuantity = 0;
                if (Validation.GetSafeGuid(grdRetrimming.Rows[e.RowIndex].Cells["colIdReTrimming"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....                   
                    if (grdRetrimming.Rows[e.RowIndex].ReadOnly)
                    {
                        if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                        {
                            MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                            return;
                        }
                        else
                        {
                            Int64 Pieces = 0;
                            if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                TotalQuantity = Manager.GetProcessesCompareStockBeforeDeleting("Retrimming", "Shaving", "Puttha", "Puttha", 1, cbxVehicles.Text, Guid.Empty);
                                if (Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value) > 0)
                                {
                                    for (int i = 0; i < grdRetrimming.Rows.Count - 1; i++)
                                    {
                                        Pieces += Validation.GetSafeLong(grdRetrimming.Rows[i].Cells["colRetrimmingPuttha"].Value);
                                    }
                                    if (Pieces == TotalQuantity)
                                    {
                                        MessageBox.Show("Retrimming Puttha Pieces are equal with Shaving Puttha Pieces, Please Delete Puttha Pieces First In Shaving For Balanced Stock...");
                                        return;
                                    }
                                    else
                                    {
                                        Int64 ResultantPieces = Pieces - TotalQuantity;
                                        //if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value) < ResultantPieces)
                                        if (ResultantPieces > Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value))
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdRetrimming.Rows[e.RowIndex].Cells["colIdReTrimming"].Value), Validation.GetSafeGuid(grdRetrimming.Rows[e.RowIndex].Cells["colReTrimmingVoucherNo"].Value), "Retrimming"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else if (TotalQuantity == 0)
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdRetrimming.Rows[e.RowIndex].Cells["colIdReTrimming"].Value), Validation.GetSafeGuid(grdRetrimming.Rows[e.RowIndex].Cells["colReTrimmingVoucherNo"].Value), "Retrimming"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please Delete Puttha Pieces From Shaving Puttha First For Balanced Stock");
                                            return;
                                        }
                                    }
                                }
                                else if (Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value) > 0)
                                {
                                    TotalQuantity = Manager.GetProcessesCompareStockBeforeDeleting("Retrimming", "Shaving", "Galma", "Galma", 1, cbxVehicles.Text, Guid.Empty);
                                    for (int i = 0; i < grdRetrimming.Rows.Count - 1; i++)
                                    {
                                        Pieces += Validation.GetSafeLong(grdRetrimming.Rows[i].Cells["colRetrimmingGalma"].Value);
                                    }
                                    if (Pieces == TotalQuantity)
                                    {
                                        MessageBox.Show("Retrimming Galma Pieces are equal with Shaving Galma Pieces, Please Delete Galma Pieces First In Shaving For Balanced Stock...");
                                        return;
                                    }
                                    else
                                    {
                                        Int64 ResultantPieces = Pieces - TotalQuantity;
                                        //if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value) < ResultantPieces)
                                        if (ResultantPieces > Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value))
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdRetrimming.Rows[e.RowIndex].Cells["colIdReTrimming"].Value), Validation.GetSafeGuid(grdRetrimming.Rows[e.RowIndex].Cells["colReTrimmingVoucherNo"].Value), "Retrimming"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else if (TotalQuantity == 0)
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdRetrimming.Rows[e.RowIndex].Cells["colIdReTrimming"].Value), Validation.GetSafeGuid(grdRetrimming.Rows[e.RowIndex].Cells["colReTrimmingVoucherNo"].Value), "Retrimming"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please Delete Galma Pieces From Shaving Galma First For Balanced Stock");
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdRetrimming.Rows[e.RowIndex].Cells["colIdReTrimming"].Value), Validation.GetSafeGuid(grdRetrimming.Rows[e.RowIndex].Cells["colReTrimmingVoucherNo"].Value), "ReTrimming"))
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                TanneryTab_SelectedIndexChanged(sender, e);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdRetrimming.Columns.Count; i++)
                    {
                        grdRetrimming.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 13)
            {
                var Manager = new TanneryProcessesHeadBLL();
                TanneryProcessesHeadEL oelTanneryHead = new TanneryProcessesHeadEL();
                TanneryProcessesEL oelTanneryProcess = new TanneryProcessesEL();
                List<TanneryProcessDetailsEL> oelRetrimmingProcessesDetailCollection = new List<TanneryProcessDetailsEL>();
                if (ValidateRecords(3))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelTanneryHead.IdVoucher = Guid.NewGuid();
                        IdVoucher = oelTanneryHead.IdVoucher;
                    }
                    else
                    {
                        oelTanneryHead.IdVoucher = IdVoucher;
                    }
                    oelTanneryHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelTanneryHead.IdCompany = Operations.IdCompany;
                    oelTanneryHead.UserId = Operations.UserID;
                    oelTanneryHead.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                    oelTanneryHead.VDate = TanneryDate.Value;
                    oelTanneryHead.Description = "N/A";
                    oelTanneryHead.Amount = 0;
                    oelTanneryHead.IsComplete = false;
                    oelTanneryHead.CloseDate = DateTime.Now;

                    if (IdReTrimming == Guid.Empty)
                    {
                        oelTanneryProcess.IdProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelTanneryProcess.IdProcess = IdReTrimming;
                    }
                    oelTanneryProcess.IdVoucher = oelTanneryHead.IdVoucher;
                    oelTanneryProcess.IdUser = Operations.UserID;
                    oelTanneryProcess.ProcessName = "ReTrimming";
                    oelTanneryProcess.VDate = DateTime.Now;

                    TanneryProcessDetailsEL oelTanneryDetail = new TanneryProcessDetailsEL();
                    oelTanneryDetail.IdUser = Operations.UserID;
                    if (grdRetrimming.Rows[e.RowIndex].Cells["colIdReTrimming"].Value == null)
                    {
                        oelTanneryDetail.IdProcessDetail = Guid.NewGuid();
                        grdRetrimming.Rows[e.RowIndex].Cells["colIdReTrimming"].Value = oelTanneryDetail.IdProcessDetail;
                        oelTanneryDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelTanneryDetail.IdProcessDetail = Validation.GetSafeGuid(grdRetrimming.Rows[e.RowIndex].Cells["colIdReTrimming"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdRetrimming.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelTanneryDetail.IdProcessDetail;
                    oelTanneryDetail.IdProcess = oelTanneryProcess.IdProcess;
                    oelTanneryDetail.AccountNo = Validation.GetSafeString(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingAccountNo"].Value);
                    EmpAccountNo = oelTanneryDetail.AccountNo;
                    EmpAccountName = Validation.GetSafeString(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingVendor"].Value);
                    //oelTanneryDetail.Description = Validation.GetSafeString(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingDescription"].Value);
                    oelTanneryDetail.IdItem = Guid.Empty;
                    oelTanneryDetail.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                    oelTanneryDetail.Puttha = Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value);
                    oelTanneryDetail.Galma = Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value);
                    oelTanneryDetail.Pieces = Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPieces"].Value);

                    oelTanneryDetail.PutthaPieces = 0;
                    oelTanneryDetail.GalmaPieces = 0;
                    oelTanneryDetail.DGalma = 0;
                    oelTanneryDetail.DPuttha = 0;
                    oelTanneryDetail.SGalma = 0;
                    oelTanneryDetail.SPuttha = 0;
                    oelTanneryDetail.WorkDate = Convert.ToDateTime(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingDate"].Value);
                    oelTanneryDetail.SSet = 0;
                    oelTanneryDetail.Rate = Validation.GetSafeDecimal(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingRate"].Value);
                    oelTanneryDetail.Amount = Validation.GetSafeDecimal(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingAmount"].Value);
                    postAmount = oelTanneryDetail.Amount;
                    oelTanneryDetail.Description = BuildRemarks("Retrimming Purchases", EmpAccountName, postAmount);
                    if (Validation.GetSafeString(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingAccountType"].Value) == "Employees")
                    {
                        oelTanneryDetail.Posted = true;
                    }
                    else
                    {
                        oelTanneryDetail.Posted = false;
                    }
                    oelRetrimmingProcessesDetailCollection.Add(oelTanneryDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdReTrimming == Guid.Empty)
                        {
                            IdReTrimming = oelTanneryProcess.IdProcess;
                            if (Manager.CreateProcessHead(oelTanneryHead, oelTanneryProcess, oelRetrimmingProcessesDetailCollection).IsSuccess)
                            {
                                //if (Validation.GetSafeString(grdSplitting.Rows[e.RowIndex].Cells["colRetrimmingAccountType"].Value) == "Employees")
                                //{
                                //    grdRetrimming.Rows[e.RowIndex].ReadOnly = true;
                                //}
                                //if (Validation.GetSafeString(grdSplitting.Rows[e.RowIndex].Cells["colRetrimmingAccountType"].Value) != "Employees")
                                //{
                                //    frmworkpurchases = new frmWorkPurchases();
                                //    frmworkpurchases.ProductionType = "Tannery";
                                //    frmworkpurchases.IdEntity = IdEntity;
                                //    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                //    frmworkpurchases.EmpAccountName = EmpAccountName;
                                //    frmworkpurchases.PurchasesType = "ReTrimming Purchases";
                                //    frmworkpurchases.ProcessName = "ReTrimming";
                                //    frmworkpurchases.ProcessAmount = postAmount;
                                //    frmworkpurchases.ShowDialog();
                                //}
                                TanneryTab_SelectedIndexChanged(sender, e);
                            }
                        }
                        //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelRetrimmingProcessesDetailCollection).IsSuccess)
                        //{

                        //}
                    }
                    else
                    {
                        //frmworkpurchases = new frmWorkPurchases();
                        //frmworkpurchases.IdEntity = IdEntity;
                        //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        //frmworkpurchases.EmpAccountName = EmpAccountName;
                        //frmworkpurchases.PurchasesType = "ReTrimming Purchases";
                        //frmworkpurchases.ProcessName = "ReTrimming";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    TanneryTab_SelectedIndexChanged(sender, e);
                }
            #endregion
            }
        }
        private void grdRetrimming_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var Manager = new WagesBLL();
            var PManager = new TanneryProcessDetailsBLL();
            Int64 TotalUnits = 0;
            if (e.ColumnIndex == 7)
            {
                if (txtVehicalType.Text == "Puttha")
                {
                    if (Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value) > 0)
                    {
                        TotalUnits = PManager.GetProcessesClosingStock("ReTrimming", "Splitting", "Puttha", "Puttha", 1, cbxVehicles.Text, Guid.Empty);
                        if (TotalUnits == 0)
                        {
                            MessageBox.Show("There Is No Puttha Stock In Splitting Puttha");
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value = "";
                            return;
                        }
                        else if (TotalUnits < Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value))
                        {
                            MessageBox.Show("You Are Exceeding from Splitting Puttha Stock");
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value = "";
                            return;
                        }
                    }
                }
                else if (txtVehicalType.Text == "Galma/Puttha")
                {
                    if (Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value) > 0)
                    {
                        TotalUnits = PManager.GetProcessesClosingStock("ReTrimming", "Splitting", "Puttha", "Puttha", 1, cbxVehicles.Text, Guid.Empty);
                        if (TotalUnits == 0)
                        {
                            MessageBox.Show("There Is No Puttha Stock In Splitting Puttha");
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value = "";
                            return;
                        }
                        else if (TotalUnits < Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value))
                        {
                            MessageBox.Show("You Are Exceeding from Splitting Puttha Stock");
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value = "";
                            return;
                        }
                    }
                    else if (Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value) > 0)
                    {
                        TotalUnits = PManager.GetProcessesClosingStock("ReTrimming", "Splitting", "Galma", "Galma", 1, cbxVehicles.Text, Guid.Empty);
                        if (TotalUnits == 0)
                        {
                            MessageBox.Show("There Is No Puttha Stock In Splitting Puttha");
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value = "";
                            return;
                        }
                        else if (TotalUnits < Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value))
                        {
                            MessageBox.Show("You Are Exceeding from Splitting Galma Stock");
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value = "";
                            return;
                        }
                    }
                }
                if (Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value) > 0)
                {
                    list = Manager.GetWagesByProcess("Retrimming");
                    if (list.Count > 0)
                    {
                        if (grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value != null)
                        {
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingRate"].Value = list.Find(x => x.WorkType == "Puttha").WorkRate;
                        }
                        if (grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPieces"].Value != null)
                        {
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingRate"].Value = list.Find(x => x.WorkType == "PLoading").WorkRate;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Set Rates First");
                    }
                }
            }
            else if (e.ColumnIndex == 8)
            {
                if (txtVehicalType.Text == "Galma")
                {
                    if (Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value) > 0)
                    {
                        TotalUnits = PManager.GetProcessesClosingStock("ReTrimming", "Splitting", "Galma", "Galma", 1, cbxVehicles.Text, Guid.Empty);
                        if (TotalUnits == 0)
                        {
                            MessageBox.Show("There Is No Galma Stock In Splitting Galma");
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value = "";
                            return;
                        }
                        else if (TotalUnits < Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value))
                        {
                            MessageBox.Show("You Are Exceeding from Splitting Galma Stock");
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value = "";
                            return;
                        }
                    }

                }
                else if (txtVehicalType.Text == "Galma/Puttha")
                {
                    if (Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value) > 0)
                    {
                        TotalUnits = PManager.GetProcessesClosingStock("ReTrimming", "Splitting", "Puttha", "Puttha", 1, cbxVehicles.Text, Guid.Empty);
                        if (TotalUnits == 0)
                        {
                            MessageBox.Show("There Is No Puttha Stock In Splitting Puttha");
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value = "";
                            return;
                        }
                        else if (TotalUnits < Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value))
                        {
                            MessageBox.Show("You Are Exceeding from Splitting Puttha Stock");
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value = "";
                            return;
                        }
                    }
                    else if (Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value) > 0)
                    {
                        TotalUnits = PManager.GetProcessesClosingStock("ReTrimming", "Splitting", "Galma", "Galma", 1, cbxVehicles.Text, Guid.Empty);
                        if (TotalUnits == 0)
                        {
                            MessageBox.Show("There Is No Galma Stock In Splitting Galma");
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value = "";
                            return;
                        }
                        else if (TotalUnits < Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value))
                        {
                            MessageBox.Show("You Are Exceeding from Splitting Galma Stock");
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value = "";
                            return;
                        }
                    }
                }
                if (Validation.GetSafeLong(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value) > 0)
                {
                    list = Manager.GetWagesByProcess("Retrimming");
                    if (list.Count > 0)
                    {
                        if (grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value != null)
                        {
                            if (grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value != null)
                            {
                                grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value = null;
                            }
                        }
                        if (grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value != null)
                        {
                            grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingRate"].Value = list.Find(x => x.WorkType == "Galma").WorkRate;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Set Rates First");
                    }
                }
            }
        }
        private void grdRetrimming_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value != null && Validation.GetSafeDecimal(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value) > 0)
            {
                grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingAmount"].Value = Validation.GetSafeDecimal(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value) * Validation.GetSafeDecimal(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingRate"].Value);
            }
            else
            {
                grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingAmount"].Value = Validation.GetSafeDecimal(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value) * Validation.GetSafeDecimal(grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingRate"].Value);
            }
        }
        private void grdRetrimming_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdRetrimming.CurrentCellAddress.X == 6)
            {
                TextBox txtReTrimmingVendorName = e.Control as TextBox;
                if (txtReTrimmingVendorName != null)
                {
                    txtReTrimmingVendorName.KeyPress -= new KeyPressEventHandler(txtReTrimmingVendorName_KeyPress);
                    txtReTrimmingVendorName.KeyPress += new KeyPressEventHandler(txtReTrimmingVendorName_KeyPress);
                }
            }
        }
        void txtReTrimmingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdRetrimming.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "ReTrimming";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Shaving Grid Events
        private void grdShaving_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 17)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 18)
            {
                e.Value = "Posting";
            }
        }
        private void grdShaving_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (grdShaving.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdShaving_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 17)
            {
                var Manager = new TanneryProcessDetailsBLL();
                Int64 TotalQuantity = 0;
                if (Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colIdShaving"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    if (grdShaving.Rows[e.RowIndex].ReadOnly)
                    {
                        if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                        {
                            MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                            return;
                        }
                        else
                        {
                            Int64 Pieces = 0;
                            if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                TotalQuantity = Manager.GetProcessesCompareStockBeforeDeleting("Shaving", "Drumming", "Puttha", "Puttha", 2, cbxVehicles.Text, Guid.Empty);
                                if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value) > 0)
                                {
                                    for (int i = 0; i < grdShaving.Rows.Count - 1; i++)
                                    {
                                        Pieces += Validation.GetSafeLong(grdShaving.Rows[i].Cells["colShavingPuttha"].Value);
                                    }
                                    if (Pieces == TotalQuantity)
                                    {
                                        MessageBox.Show("Shaving Puttha Pieces are equal with Drumming Puttha Pieces, Please Delete Puttha Pieces First In Drumming For Balanced Stock...");
                                        return;
                                    }
                                    else
                                    {
                                        Int64 ResultantPieces = Pieces - TotalQuantity;
                                        //if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value) < ResultantPieces)
                                        if (ResultantPieces > Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value))
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colIdShaving"].Value), Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colShavingVoucherNo"].Value), "Shaving"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else if (TotalQuantity == 0)
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colIdShaving"].Value), Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colShavingVoucherNo"].Value), "Shaving"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please Delete Puttha Pieces From Drumming Puttha First For Balanced Stock");
                                            return;
                                        }
                                    }
                                }
                                else if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value) > 0)
                                {
                                    TotalQuantity = Manager.GetProcessesCompareStockBeforeDeleting("Shaving", "Drumming", "Galma", "Galma", 2, cbxVehicles.Text, Guid.Empty);
                                    for (int i = 0; i < grdShaving.Rows.Count - 1; i++)
                                    {
                                        Pieces += Validation.GetSafeLong(grdShaving.Rows[i].Cells["colShavingGalma"].Value);
                                    }
                                    if (Pieces == TotalQuantity)
                                    {
                                        MessageBox.Show("Shaving Galma Pieces are equal with Drumming Galma Pieces, Please Delete Galma Pieces First In Drumming For Balanced Stock...");
                                        return;
                                    }
                                    else
                                    {
                                        Int64 ResultantPieces = Pieces - TotalQuantity;
                                        //if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value) < ResultantPieces)
                                        if (ResultantPieces > Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value))
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colIdShaving"].Value), Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colShavingVoucherNo"].Value), "Shaving"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else if (TotalQuantity == 0)
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colIdShaving"].Value), Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colShavingVoucherNo"].Value), "Shaving"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please Delete Galma Pieces From Drumming Galma First For Balanced Stock");
                                            return;
                                        }
                                    }
                                }
                                else if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value) > 0)
                                {
                                    TotalQuantity = Manager.GetProcessesCompareStockBeforeDeleting("Shaving", "Drumming", "S. Puttha", "S. Puttha", 2, cbxVehicles.Text, Guid.Empty);
                                    for (int i = 0; i < grdShaving.Rows.Count - 1; i++)
                                    {
                                        Pieces += Validation.GetSafeLong(grdShaving.Rows[i].Cells["colShavingSPuttha"].Value);
                                    }
                                    if (Pieces == TotalQuantity)
                                    {
                                        MessageBox.Show("Shaving Split Puttha Pieces are equal with Drumming Split Puttha Pieces, Please Delete Split Putth Pieces First In Drumming For Balanced Stock...");
                                        return;
                                    }
                                    else
                                    {
                                        Int64 ResultantPieces = Pieces - TotalQuantity;
                                        //if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value) < ResultantPieces)
                                        if (ResultantPieces > Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value))
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colIdShaving"].Value), Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colShavingVoucherNo"].Value), "Shaving"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else if (TotalQuantity == 0)
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colIdShaving"].Value), Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colShavingVoucherNo"].Value), "Shaving"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please Delete Splitt Puttha Pieces From Drumming Splitt Puttha First For Balanced Stock");
                                            return;
                                        }
                                    }
                                }
                                else if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value) > 0)
                                {
                                    TotalQuantity = Manager.GetProcessesCompareStockBeforeDeleting("Shaving", "Drumming", "S. Galma", "S. Galma", 2, cbxVehicles.Text, Guid.Empty);
                                    for (int i = 0; i < grdShaving.Rows.Count - 1; i++)
                                    {
                                        Pieces += Validation.GetSafeLong(grdShaving.Rows[i].Cells["colShavingSGalma"].Value);
                                    }
                                    if (Pieces == TotalQuantity)
                                    {
                                        MessageBox.Show("Shaving Split Galma Pieces are equal with Drumming Split Galma Pieces, Please Delete Split Galma Pieces First In Drumming For Balanced Stock...");
                                        return;
                                    }
                                    else
                                    {
                                        Int64 ResultantPieces = Pieces - TotalQuantity;
                                        //if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingGalmaPieces"].Value) < ResultantPieces)
                                        if (ResultantPieces > Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value))
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colIdShaving"].Value), Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colShavingVoucherNo"].Value), "Shaving"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else if (TotalQuantity == 0)
                                        {
                                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colIdShaving"].Value), Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colShavingVoucherNo"].Value), "Shaving"))
                                            {
                                                MessageBox.Show("Entry Deleted Successfully....");
                                                TanneryTab_SelectedIndexChanged(sender, e);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please Delete Split Galma Pieces From Drumming Split Galma First For Balanced Stock");
                                            return;
                                        }
                                    }
                                }
                            }
                            //if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            //{
                            //    if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colIdShaving"].Value), Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colShavingVoucherNo"].Value), "Shaving"))
                            //    {
                            //        MessageBox.Show("Entry Deleted Successfully....");
                            //        TanneryTab_SelectedIndexChanged(sender, e);
                            //    }
                            //}
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colIdShaving"].Value), Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colShavingVoucherNo"].Value), "Shaving"))
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                TanneryTab_SelectedIndexChanged(sender, e);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdShaving.Columns.Count; i++)
                    {
                        grdShaving.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 18)
            {
                var Manager = new TanneryProcessesHeadBLL();
                TanneryProcessesHeadEL oelTanneryHead = new TanneryProcessesHeadEL();
                TanneryProcessesEL oelTanneryProcess = new TanneryProcessesEL();
                List<TanneryProcessDetailsEL> oelShavingProcessesDetailCollection = new List<TanneryProcessDetailsEL>();
                if (ValidateRecords(4))
                {
                    if (IdVoucher == Guid.Empty)
                    {
                        oelTanneryHead.IdVoucher = Guid.NewGuid();
                        IdVoucher = oelTanneryHead.IdVoucher;
                    }
                    else
                    {
                        oelTanneryHead.IdVoucher = IdVoucher;
                    }
                    oelTanneryHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelTanneryHead.IdCompany = Operations.IdCompany;
                    oelTanneryHead.UserId = Operations.UserID;
                    oelTanneryHead.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                    oelTanneryHead.VDate = TanneryDate.Value;
                    oelTanneryHead.Description = "N/A";
                    oelTanneryHead.Amount = 0;
                    oelTanneryHead.IsComplete = false;
                    oelTanneryHead.CloseDate = DateTime.Now;

                    if (IdShaving == Guid.Empty)
                    {
                        oelTanneryProcess.IdProcess = Guid.NewGuid();
                    }
                    else
                    {
                        oelTanneryProcess.IdProcess = IdShaving;
                    }
                    oelTanneryProcess.IdVoucher = oelTanneryHead.IdVoucher;
                    oelTanneryProcess.IdUser = Operations.UserID;
                    oelTanneryProcess.ProcessName = "Shaving";
                    oelTanneryProcess.VDate = DateTime.Now;


                    TanneryProcessDetailsEL oelTanneryDetail = new TanneryProcessDetailsEL();
                    oelTanneryDetail.IdUser = Operations.UserID;
                    if (grdShaving.Rows[e.RowIndex].Cells["colIdShaving"].Value == null)
                    {
                        oelTanneryDetail.IdProcessDetail = Guid.NewGuid();
                        grdShaving.Rows[e.RowIndex].Cells["colIdShaving"].Value = oelTanneryDetail.IdProcessDetail;
                        oelTanneryDetail.IsNew = true;
                        EntryAlreadyDone = false;
                    }
                    else
                    {
                        oelTanneryDetail.IdProcessDetail = Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colIdShaving"].Value);
                        EntryAlreadyDone = true;
                    }
                    if (grdShaving.Rows[e.RowIndex].ReadOnly)
                    {
                        MessageBox.Show("This Entry Is Posted Please");
                        return;
                    }
                    IdEntity = oelTanneryDetail.IdProcessDetail;
                    oelTanneryDetail.IdProcess = oelTanneryProcess.IdProcess;
                    oelTanneryDetail.AccountNo = Validation.GetSafeString(grdShaving.Rows[e.RowIndex].Cells["colShavingAccountNo"].Value);
                    EmpAccountNo = oelTanneryDetail.AccountNo;
                    EmpAccountName = Validation.GetSafeString(grdShaving.Rows[e.RowIndex].Cells["colShavingVendorName"].Value);
                    //oelTanneryDetail.Description = "N/A";
                    oelTanneryDetail.IdItem = Validation.GetSafeGuid(grdShaving.Rows[e.RowIndex].Cells["colShavingIdItem"].Value);
                    oelTanneryDetail.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);

                    oelTanneryDetail.Galma = Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value);
                    oelTanneryDetail.Puttha = Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value);
                    oelTanneryDetail.SGalma = Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value);
                    oelTanneryDetail.SPuttha = Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value);
                    oelTanneryDetail.DGalma = Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingDGalma"].Value);
                    oelTanneryDetail.DPuttha = Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingDPuttha"].Value);
                    oelTanneryDetail.SSet = Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSet"].Value);

                    oelTanneryDetail.PutthaPieces = 0;
                    oelTanneryDetail.GalmaPieces = 0;
                    oelTanneryDetail.WorkDate = Convert.ToDateTime(grdShaving.Rows[e.RowIndex].Cells["colShavingDate"].Value);
                    oelTanneryDetail.Rate = 0;
                    oelTanneryDetail.Amount = Validation.GetSafeDecimal(grdShaving.Rows[e.RowIndex].Cells["colShavingRates"].Value);
                    postAmount = oelTanneryDetail.Amount;
                    oelTanneryDetail.Description = BuildRemarks("Shaving Purchases", EmpAccountName, postAmount);
                    if (Validation.GetSafeString(grdShaving.Rows[e.RowIndex].Cells["colShavingAccountType"].Value) == "Employees")
                    {
                        oelTanneryDetail.Posted = true;
                    }
                    else
                    {
                        oelTanneryDetail.Posted = false;
                    }
                    oelShavingProcessesDetailCollection.Add(oelTanneryDetail);

                    if (!EntryAlreadyDone)
                    {
                        //if (IdShaving == Guid.Empty)
                        {
                            IdShaving = oelTanneryProcess.IdProcess;
                            if (Manager.CreateProcessHead(oelTanneryHead, oelTanneryProcess, oelShavingProcessesDetailCollection).IsSuccess)
                            {
                                //if (Validation.GetSafeString(grdShaving.Rows[e.RowIndex].Cells["colShavingAccountType"].Value) == "Employees")
                                //{
                                //    grdShaving.Rows[e.RowIndex].ReadOnly = true;
                                //}
                                //if (Validation.GetSafeString(grdShaving.Rows[e.RowIndex].Cells["colShavingAccountType"].Value) != "Employees")
                                //{
                                //    frmworkpurchases = new frmWorkPurchases();
                                //    frmworkpurchases.ProductionType = "Tannery";
                                //    frmworkpurchases.IdEntity = IdEntity;
                                //    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                //    frmworkpurchases.EmpAccountName = EmpAccountName;
                                //    frmworkpurchases.PurchasesType = "Shaving Purchases";
                                //    frmworkpurchases.ProcessName = "Shaving";
                                //    frmworkpurchases.ProcessAmount = postAmount;
                                //    frmworkpurchases.ShowDialog();
                                //}
                                TanneryTab_SelectedIndexChanged(sender, e);
                            }
                        }
                        //else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelShavingProcessesDetailCollection).IsSuccess)
                        //{

                        //}
                    }
                    else
                    {
                        //frmworkpurchases = new frmWorkPurchases();
                        //frmworkpurchases.IdEntity = IdEntity;
                        //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        //frmworkpurchases.EmpAccountName = EmpAccountName;
                        //frmworkpurchases.PurchasesType = "Shaving Purchases";
                        //frmworkpurchases.ProcessName = "Shaving";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                        TanneryTab_SelectedIndexChanged(sender, e);
                    }
                }
            }
            #endregion
        }
        private void grdShaving_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            Int64 TotalUnits = 0;
            var PManager = new TanneryProcessDetailsBLL();
            //if (e.ColumnIndex == 9)
            //{
            //    if (txtVehicalType.Text == "Galma")
            //    {
            //        if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value) > 0)
            //        {
            //            TotalUnits = PManager.GetProcessesClosingStock("Shaving", "ReTrimming", "Galma", 1, cbxVehicles.Text);
            //            if (TotalUnits == 0)
            //            {
            //                MessageBox.Show("There Is No Galma Stock In Retrimming Galma");
            //                grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value = "";
            //                return;
            //            }
            //            else if (TotalUnits < Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value))
            //            {
            //                MessageBox.Show("You Are Exceeding from Retrimming Galma Stock");
            //                grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value = "";
            //                return;
            //            }
            //        }
            //    }
            //    else if (txtVehicalType.Text == "Galma/Puttha")
            //    {
            //        if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value) > 0)
            //        {
            //            TotalUnits = PManager.GetProcessesClosingStock("Shaving", "ReTrimming", "Galma", 1, cbxVehicles.Text);
            //            if (TotalUnits == 0)
            //            {
            //                MessageBox.Show("There Is No Galma Stock In Retrimming Galma");
            //                grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value = "";
            //                return;
            //            }
            //            else if (TotalUnits < Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value))
            //            {
            //                MessageBox.Show("You Are Exceeding from Retrimming Galma Stock");
            //                grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value = "";
            //                return;
            //            }
            //        }
            //        if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value) > 0)
            //        {
            //            TotalUnits = PManager.GetProcessesClosingStock("Shaving", "ReTrimming", "Puttha", 1, cbxVehicles.Text);
            //            if (TotalUnits == 0)
            //            {
            //                MessageBox.Show("There Is No Puttha Stock In Retrimming Puttha");
            //                grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value = "";
            //                return;
            //            }
            //            else if (TotalUnits < Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value))
            //            {
            //                MessageBox.Show("You Are Exceeding from ReTrimming Puttha Stock");
            //                grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value = "";
            //                return;
            //            }
            //        }
            //    }
            //}
            //else if (e.ColumnIndex == 10)
            //{
            //    if (txtVehicalType.Text == "Puttha")
            //    {
            //        if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value) > 0)
            //        {
            //            TotalUnits = PManager.GetProcessesClosingStock("Shaving", "ReTrimming", "Puttha", 1, cbxVehicles.Text);
            //            if (TotalUnits == 0)
            //            {
            //                MessageBox.Show("There Is No Puttha Stock In Retrimming Puttha");
            //                grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value = "";
            //                return;
            //            }
            //            else if (TotalUnits < Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value))
            //            {
            //                MessageBox.Show("You Are Exceeding from ReTrimming Puttha Stock");
            //                grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value = "";
            //                return;
            //            }
            //        }
            //    }
            //    else if (txtVehicalType.Text == "Galma/Puttha")
            //    {
            //        if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value) > 0)
            //        {
            //            TotalUnits = PManager.GetProcessesClosingStock("Shaving", "ReTrimming", "Galma", 1, cbxVehicles.Text);
            //            if (TotalUnits == 0)
            //            {
            //                MessageBox.Show("There Is No Galma Stock In Retrimming Galma");
            //                grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value = "";
            //                return;
            //            }
            //            else if (TotalUnits < Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value))
            //            {
            //                MessageBox.Show("You Are Exceeding from Retrimming Galma Stock");
            //                grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value = "";
            //                return;
            //            }
            //        }
            //        if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value) > 0)
            //        {
            //            TotalUnits = PManager.GetProcessesClosingStock("Shaving", "ReTrimming", "Puttha", 1, cbxVehicles.Text);
            //            if (TotalUnits == 0)
            //            {
            //                MessageBox.Show("There Is No Puttha Stock In Retrimming Puttha");
            //                grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value = "";
            //                return;
            //            }
            //            else if (TotalUnits < Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value))
            //            {
            //                MessageBox.Show("You Are Exceeding from ReTrimming Puttha Stock");
            //                grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value = "";
            //                return;
            //            }
            //        }
            //    }
            //}
            //else if (e.ColumnIndex == 11)
            if (e.ColumnIndex == 11)
            {
                if (txtVehicalType.Text == "Galma")
                {
                    if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value) > 0)
                    {
                        //TotalUnits = PManager.GetProcessesClosingStock("Shaving", "Splitting", "SGalma", 1, cbxVehicles.Text);
                        TotalUnits = PManager.GetProcessesClosingStock("Shaving", "ReTrimming", "Galma", "SGalma", 1, cbxVehicles.Text, Guid.Empty);
                        if (TotalUnits == 0)
                        {
                            MessageBox.Show("There Is No Split Galma Stock In Retrimming Galma");
                            grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value = "";
                            return;
                        }
                        else if (TotalUnits < Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value))
                        {
                            MessageBox.Show("You are Exceeding from Retrimming Galma Stock");
                            grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value = "";
                            return;
                        }
                    }
                }
                else if (txtVehicalType.Text == "Galma/Puttha")
                {
                    if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value) > 0)
                    {
                        //TotalUnits = PManager.GetProcessesClosingStock("Shaving", "Splitting", "SGalma", 1, cbxVehicles.Text);
                        TotalUnits = PManager.GetProcessesClosingStock("Shaving", "ReTrimming", "Galma", "SGalma", 1, cbxVehicles.Text,Guid.Empty);
                        if (TotalUnits == 0)
                        {
                            MessageBox.Show("There Is No Split Galma Stock In Retrimming Galma");
                            grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value = "";
                            return;
                        }
                        else if (TotalUnits < Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value))
                        {
                            MessageBox.Show("You are Exceeding from Retrimming Galma Stock");
                            grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value = "";
                            return;
                        }
                    }
                    if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value) > 0)
                    {
                        //TotalUnits = PManager.GetProcessesClosingStock("Shaving", "Splitting", "SPuttha", 1, cbxVehicles.Text);
                        TotalUnits = PManager.GetProcessesClosingStock("Shaving", "ReTrimming", "Puttha", "SPuttha", 1, cbxVehicles.Text, Guid.Empty);
                        if (TotalUnits == 0)
                        {
                            MessageBox.Show("There Is No Splitt Puttha Stock In Retrimming Puttha");
                            grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value = "";
                            return;
                        }
                        else if (TotalUnits < Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value))
                        {
                            MessageBox.Show("You Are Exceeding from Retrimming Puttha Stock");
                            grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value = "";
                            return;
                        }
                    }
                }
            }
            else if (e.ColumnIndex == 12)
            {
                if (txtVehicalType.Text == "Puttha")
                {
                    if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value) > 0)
                    {
                        //TotalUnits = PManager.GetProcessesClosingStock("Shaving", "Splitting", "SPuttha", 1, cbxVehicles.Text);
                        TotalUnits = PManager.GetProcessesClosingStock("Shaving", "Retrimming", "Puttha", "SPuttha", 1, cbxVehicles.Text, Guid.Empty);
                        if (TotalUnits == 0)
                        {
                            MessageBox.Show("There Is No Split Puttha Stock In Retrimming Puttha");
                            grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value = "";
                            return;
                        }
                        else if (TotalUnits < Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value))
                        {
                            MessageBox.Show("You are Exceeding from Retrimming Puttha Stock");
                            grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value = "";
                            return;
                        }
                    }
                }
                else if (txtVehicalType.Text == "Galma/Puttha")
                {
                    if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value) > 0)
                    {
                        //TotalUnits = PManager.GetProcessesClosingStock("Shaving", "Splitting", "SPuttha", 1, cbxVehicles.Text);
                        TotalUnits = PManager.GetProcessesClosingStock("Shaving", "Retrimming", "Puttha", "SPuttha", 1, cbxVehicles.Text, Guid.Empty);
                        if (TotalUnits == 0)
                        {
                            MessageBox.Show("There Is No Splitt Puttha Stock In Retrimming Puttha");
                            grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value = "";
                            return;
                        }
                        else if (TotalUnits < Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value))
                        {
                            MessageBox.Show("You are Exceeding from Retrimming Puttha Stock");
                            grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value = "";
                            return;
                        }
                    }
                    if (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value) > 0)
                    {
                        //TotalUnits = PManager.GetProcessesClosingStock("Shaving", "Splitting", "SGalma", 1, cbxVehicles.Text);
                        TotalUnits = PManager.GetProcessesClosingStock("Shaving", "ReTrimming", "Galma", "SGalma", 1, cbxVehicles.Text, Guid.Empty);
                        if (TotalUnits == 0)
                        {
                            MessageBox.Show("There Is No Splitt Galma Stock In Retrimming Galma");
                            grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value = "";
                            return;
                        }
                        else if (TotalUnits < Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value))
                        {
                            MessageBox.Show("You are Exceeding from Retrimming Galma Stock");
                            grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value = "";
                            return;
                        }
                    }
                }
            }
            var Manager = new WagesBLL();
            if (e.ColumnIndex == 15)
            {
                list = Manager.GetWagesByProcess("Shaving");

                if (grdShaving.Rows[e.RowIndex].Cells["colShavingSet"].Value != null && Validation.GetSafeDecimal(grdShaving.Rows[e.RowIndex].Cells["colShavingSet"].Value) > 0)
                {

                    grdShaving.Rows[e.RowIndex].Cells["colShavingRates"].Value = (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value) * list.Find(x => x.WorkType == "Galma").WorkRate) +
                                                                                 (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingDGalma"].Value) * list.Find(x => x.WorkType == "D.Galam").WorkRate) +
                                                                                 (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value) * list.Find(x => x.WorkType == "Puttha").WorkRate) +
                        //(Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingDPuttha"].Value) * list.Find(x => x.WorkType == "D.Puttha").WorkRate) +
                                                                                (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "SGalma").WorkRate)) +
                                                                                 (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "SPuttha").WorkRate)) +
                                                                                 (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSet"].Value) * list.Find(x => x.WorkType == "S.Set").WorkRate);

                }
                else if (grdShaving.Rows[e.RowIndex].Cells["colShavingSet"].Value == null)
                {
                    grdShaving.Rows[e.RowIndex].Cells["colShavingRates"].Value = (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "Galma").WorkRate)) +
                                                                                 (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingDGalma"].Value) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "D.Galam").WorkRate)) +
                                                                                 (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "Puttha").WorkRate)) + //+
                        //(Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingDPuttha"].Value) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "D.Puttha").WorkRate));
                                                                                 (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "SGalma").WorkRate)) +
                                                                                 (Validation.GetSafeLong(grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "SPuttha").WorkRate));

                }
            }
        }
        private void grdShaving_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                if (grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].EditedFormattedValue != null && Validation.GetSafeString(grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].EditedFormattedValue) != "")
                {
                    grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value = null;
                    grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value = null;
                    grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value = null;
                }
            }
            else if (e.ColumnIndex == 10)
            {
                if (grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].EditedFormattedValue != null && Validation.GetSafeString(grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].EditedFormattedValue) != "")
                {
                    grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value = null;
                    grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value = null;
                    grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value = null;
                }
            }
            if (e.ColumnIndex == 11)
            {
                if (grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].EditedFormattedValue != null && Validation.GetSafeString(grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].EditedFormattedValue) != "")
                {
                    grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value = null;
                    grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value = null;
                    grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].Value = null;
                }
            }
            if (e.ColumnIndex == 12)
            {
                if (grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].EditedFormattedValue != null && Validation.GetSafeString(grdShaving.Rows[e.RowIndex].Cells["colShavingSPuttha"].EditedFormattedValue) != "")
                {
                    grdShaving.Rows[e.RowIndex].Cells["colShavingPuttha"].Value = null;
                    grdShaving.Rows[e.RowIndex].Cells["colShavingSGalma"].Value = null;
                    grdShaving.Rows[e.RowIndex].Cells["colShavingGalma"].Value = null;
                }
            }
            //if (grdRetrimming.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value != null)
            //{
            //    grdShaving.Rows[e.RowIndex].Cells["colRetrimmingAmount"].Value = Validation.GetSafeDecimal(grdShaving.Rows[e.RowIndex].Cells["colRetrimmingPuttha"].Value) * Validation.GetSafeDecimal(grdShaving.Rows[e.RowIndex].Cells["colRetrimmingRate"].Value);
            //}
            //else
            //{
            //    grdShaving.Rows[e.RowIndex].Cells["colRetrimmingAmount"].Value = Validation.GetSafeDecimal(grdShaving.Rows[e.RowIndex].Cells["colRetrimmingGalma"].Value) * Validation.GetSafeDecimal(grdShaving.Rows[e.RowIndex].Cells["colRetrimmingRate"].Value);
            //}
        }
        private void grdShaving_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdShaving.CurrentCellAddress.X == 7)
            {
                TextBox txtShavingVendorName = e.Control as TextBox;
                if (txtShavingVendorName != null)
                {
                    txtShavingVendorName.KeyPress -= new KeyPressEventHandler(txtShavingVendorName_KeyPress);
                    txtShavingVendorName.KeyPress += new KeyPressEventHandler(txtShavingVendorName_KeyPress);
                }
            }
            else if (grdShaving.CurrentCellAddress.X == 8)
            {
                TextBox txtShavingQuality = e.Control as TextBox;
                if (txtShavingQuality != null)
                {
                    txtShavingQuality.KeyPress -= new KeyPressEventHandler(txtShavingQuality_KeyPress);
                    txtShavingQuality.KeyPress += new KeyPressEventHandler(txtShavingQuality_KeyPress);
                }
            }
        }
        void txtShavingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdShaving.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Shaving";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        void txtShavingQuality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdShaving.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "ShavingQuality";
                    frmstockAccounts = new frmStockAccounts();
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Drumming Grid Events
        private void grdDrumming_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 13)
            {
                e.Value = "Post";
            }
        }
        private void grdDrumming_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (grdDrumming.Rows[e.RowIndex].Cells[5].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdDrumming_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 12)
            {
                var Manager = new TanneryProcessDetailsBLL();
                Int64 TotalQuantity = 0;
                if (Validation.GetSafeGuid(grdDrumming.Rows[e.RowIndex].Cells["colIdDrumming"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    if (grdDrumming.Rows[e.RowIndex].ReadOnly)
                    {
                        if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                        {
                            MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                            return;
                        }
                        else
                        {
                            Int64 Pieces = 0;
                            string UOM = Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value);
                            if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                TotalQuantity = Manager.GetProcessesCompareStockBeforeDeleting("Drumming", "Buffing", UOM, UOM, 3, cbxVehicles.Text, IdLot);
                                for (int i = 0; i < grdDrumming.Rows.Count - 1; i++)
                                {
                                    if (Validation.GetSafeString(grdDrumming.Rows[i].Cells["colDrummingPiecesType"].Value) == UOM)
                                    {
                                        Pieces += Validation.GetSafeLong(grdDrumming.Rows[i].Cells["colDrummingPieces"].Value);
                                    }
                                }
                                if (Pieces == TotalQuantity)
                                {
                                    MessageBox.Show("Drumming " + UOM + " Pieces are equal with Buffing " + UOM + " Pieces, Please Delete " + UOM + " Pieces First In Buffing For Balanced Stock...");
                                    return;
                                }
                                else
                                {
                                    Int64 ResultantPieces = Pieces - TotalQuantity;
                                    //if (Validation.GetSafeLong(grdSplitting.Rows[e.RowIndex].Cells["colSplittingPutthaPiece"].Value) < ResultantPieces)
                                    if (ResultantPieces > Validation.GetSafeLong(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPieces"].Value))
                                    {
                                        if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdDrumming.Rows[e.RowIndex].Cells["colIdDrumming"].Value), Validation.GetSafeGuid(grdDrumming.Rows[e.RowIndex].Cells["colDrummingVoucherNo"].Value), "Drumming"))
                                        {
                                            MessageBox.Show("Entry Deleted Successfully....");
                                            FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "Drumming");
                                            //TanneryTab_SelectedIndexChanged(sender, e);
                                        }
                                    }
                                    else if (TotalQuantity == 0)
                                    {
                                        if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdDrumming.Rows[e.RowIndex].Cells["colIdDrumming"].Value), Validation.GetSafeGuid(grdDrumming.Rows[e.RowIndex].Cells["colDrummingVoucherNo"].Value), "Drumming"))
                                        {
                                            MessageBox.Show("Entry Deleted Successfully....");
                                            FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "Drumming");
                                            //TanneryTab_SelectedIndexChanged(sender, e);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please Delete " + UOM + " Pieces From Buffing " + UOM + " First For Balanced Stock");
                                        return;
                                    }
                                }

                            }
                            //if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            //{
                            //    if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdDrumming.Rows[e.RowIndex].Cells["colIdDrumming"].Value), Validation.GetSafeGuid(grdDrumming.Rows[e.RowIndex].Cells["colDrummingVoucherNo"].Value), "Drumming"))
                            //    {
                            //        MessageBox.Show("Entry Deleted Successfully....");
                            //        FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "Drumming");
                            //    }
                            //}
                        }

                    }
                    else
                    {
                        if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdDrumming.Rows[e.RowIndex].Cells["colIdDrumming"].Value), Validation.GetSafeGuid(grdDrumming.Rows[e.RowIndex].Cells["colDrummingVoucherNo"].Value), "Drumming"))
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "Drumming");
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdDrumming.Columns.Count; i++)
                    {
                        grdDrumming.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 13)
            {
                var manager = new TanneryLotBLL();
                TanneryLotEL oelLot = new TanneryLotEL();
                List<TanneryLotDetailEL> listDetail = new List<TanneryLotDetailEL>();
                List<TanneryProcessesEL> listProcesses = new List<TanneryProcessesEL>();
                #region Main Lot Process
                if (IdLot != Guid.Empty)
                {
                    oelLot.IdLot = IdLot;
                }
                else
                {
                    oelLot.IdLot = Guid.NewGuid();
                }
                oelLot.IdVoucher = IdVoucher;
                oelLot.IdUser = Operations.UserID;
                oelLot.LotNo = Validation.GetSafeLong(txtLotNo.Text);
                oelLot.LotDate = DtLot.Value;
                oelLot.IdQuality = IdQuality;
                oelLot.LotWeight = Validation.GetSafeDecimal(txtLotWeight.Text);
                oelLot.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                oelLot.LotType = cbxLotType.SelectedIndex;
                oelLot.CloseDate = DateTime.Now;
                #endregion
                #region Drumming Process Entries
                if (ValidateRecords(5))
                {
                    if (grdDrumming.Rows.Count > 1)
                    {
                        oelLot.Status = "Open";
                        TanneryProcessesEL oelTanneryDrummingProcess = new TanneryProcessesEL();
                        if (IdTanneryDrumming == Guid.Empty)
                        {
                            oelTanneryDrummingProcess.IdProcess = Guid.NewGuid();
                        }
                        else
                        {
                            oelTanneryDrummingProcess.IdProcess = IdTanneryDrumming;
                        }
                        oelTanneryDrummingProcess.IdVoucher = IdVoucher;
                        oelTanneryDrummingProcess.IdUser = Operations.UserID;
                        oelTanneryDrummingProcess.ProcessName = "Drumming";
                        oelTanneryDrummingProcess.VDate = DateTime.Now;

                        listProcesses.Add(oelTanneryDrummingProcess);
                        
                        TanneryLotDetailEL lotDetail = new TanneryLotDetailEL();
                        lotDetail.IdUser = Operations.UserID;
                        if (grdDrumming.Rows[e.RowIndex].Cells["colIdDrumming"].Value == null)
                        {
                            lotDetail.IdLotDetail = Guid.NewGuid();
                            lotDetail.IsNew = true;
                            EntryAlreadyDone = false;
                        }
                        else
                        {
                            lotDetail.IdLotDetail = Validation.GetSafeGuid(grdDrumming.Rows[e.RowIndex].Cells["colIdDrumming"].Value);
                            EntryAlreadyDone = true;
                        }
                        if (grdDrumming.Rows[e.RowIndex].ReadOnly)
                        {
                            MessageBox.Show("Entry is already posted please...");
                            return;
                        }
                        IdEntity = lotDetail.IdLotDetail;
                        lotDetail.IdLot = IdLot;
                        lotDetail.IdProcess = oelTanneryDrummingProcess.IdProcess;
                        lotDetail.AccountNo = Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingAccountNo"].Value);
                        EmpAccountNo = lotDetail.AccountNo;
                        EmpAccountName = Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingVendorName"].Value);
                        lotDetail.WorkingDate = Convert.ToDateTime(grdDrumming.Rows[e.RowIndex].Cells["colDrummingDate"].Value);
                        lotDetail.Weight = Validation.GetSafeDecimal(grdDrumming.Rows[e.RowIndex].Cells["colDrummingWeight"].Value);
                        if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Crust")
                        {
                            lotDetail.ProcessType = 0;
                            oelLot.ProcessName = "Crust";
                        }
                        else if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Dying")
                        {
                            lotDetail.ProcessType = 1;
                            oelLot.ProcessName = "Dying";
                        }
                        else if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Re Dying")
                        {
                            lotDetail.ProcessType = 2;
                            oelLot.ProcessName = "Re Dying";
                        }
                        lotDetail.SeqNo = e.RowIndex;
                        lotDetail.Uom = Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value);
                        lotDetail.Pieces = Validation.GetSafeInteger(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPieces"].Value);
                        lotDetail.GalmaPieces = 0;
                        lotDetail.PutthaPieces = 0;
                        lotDetail.DGalma = 0;
                        lotDetail.Cutting = 0;
                        lotDetail.CuttingStock = 0;
                        lotDetail.CuttingStockValue = 0;
                        lotDetail.CuttingRateValue = 0;
                        lotDetail.Amount = Validation.GetSafeDecimal(grdDrumming.Rows[e.RowIndex].Cells["colDrummingAmount"].Value);
                        postAmount = lotDetail.Amount;
                        lotDetail.Description = BuildRemarks("Drumming" + "/" + oelLot.ProcessName + " Purchases", EmpAccountName, postAmount);
                        if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingAccountType"].Value) == "Employees")
                        {
                            lotDetail.Posted = true;
                        }
                        else
                        {
                            lotDetail.Posted = false;
                        }
                        listDetail.Add(lotDetail);

                    }
                }
                else
                {
                    return;
                }

                #endregion
                #region Save Process
                if (!EntryAlreadyDone)
                {
                    //if (IdLot == Guid.Empty)
                    {
                        IdLot = oelLot.IdLot;
                        if (manager.CreatePostingLot(oelLot, listProcesses, listDetail))
                        {
                            if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingAccountType"].Value) != "Employees")
                            {
                                //frmworkpurchases = new frmWorkPurchases();
                                //frmworkpurchases.ProductionType = "Tannery";
                                //frmworkpurchases.IdEntity = IdEntity;
                                //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                                //frmworkpurchases.EmpAccountName = EmpAccountName;
                                //frmworkpurchases.PurchasesType = "Drumming Purchases";
                                //frmworkpurchases.ProcessName = "Drumming";
                                //frmworkpurchases.ProcessAmount = postAmount;
                                //frmworkpurchases.ShowDialog();
                            }
                            FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "Drumming");
                        }
                    }
                }
                else
                {
                    if (manager.UpdatePostingLot(oelLot, listProcesses, listDetail))
                    {
                        if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingAccountType"].Value) != "Employees")
                        {
                            //frmworkpurchases = new frmWorkPurchases();
                            //frmworkpurchases.IdEntity = IdEntity;
                            //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                            //frmworkpurchases.EmpAccountName = EmpAccountName;
                            //frmworkpurchases.PurchasesType = "Drumming Purchases";
                            //frmworkpurchases.ProcessName = "Drumming";
                            //frmworkpurchases.ProcessAmount = postAmount;
                            //frmworkpurchases.ShowDialog();
                        }
                        FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "Drumming");
                    }
                }
                #endregion
            }
            #endregion
        }
        private void grdDrumming_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var Manager = new WagesBLL();
            if (e.ColumnIndex == 9)
            {
                //list = Manager.GetWagesByProcess("Crust");
                list = Manager.GetWagesByProcess(Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value));
                if (list.Count > 0)
                {
                    if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Crust" && Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value) == "Galma")
                    {
                        grdDrumming.Rows[e.RowIndex].Cells["colDrummingAmount"].Value = ((list.Find(x => x.WorkType == "Galma").WorkRate / 350) * Validation.GetSafeDecimal(grdDrumming.Rows[e.RowIndex].Cells["colDrummingWeight"].Value)).ToString("0.00");
                    }
                    else if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Crust" && Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value) == "Puttha")
                    {
                        grdDrumming.Rows[e.RowIndex].Cells["colDrummingAmount"].Value = ((list.Find(x => x.WorkType == "Puttha").WorkRate / 400) * Validation.GetSafeDecimal(grdDrumming.Rows[e.RowIndex].Cells["colDrummingWeight"].Value)).ToString("0.00");
                    }
                    else if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Dying" && Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value) == "Galma")
                    {
                        grdDrumming.Rows[e.RowIndex].Cells["colDrummingAmount"].Value = ((list.Find(x => x.WorkType == "Galma").WorkRate / 350) * Validation.GetSafeDecimal(grdDrumming.Rows[e.RowIndex].Cells["colDrummingWeight"].Value)).ToString("0.00");
                    }
                    else if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Dying" && Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value) == "Puttha")
                    {
                        grdDrumming.Rows[e.RowIndex].Cells["colDrummingAmount"].Value = ((list.Find(x => x.WorkType == "Puttha").WorkRate / 400) * Validation.GetSafeDecimal(grdDrumming.Rows[e.RowIndex].Cells["colDrummingWeight"].Value)).ToString("0.00");
                    }
                    else if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Re Dying" && Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value) == "Galma")
                    {
                        grdDrumming.Rows[e.RowIndex].Cells["colDrummingAmount"].Value = ((list.Find(x => x.WorkType == "Galma").WorkRate / 350) * Validation.GetSafeDecimal(grdDrumming.Rows[e.RowIndex].Cells["colDrummingWeight"].Value)).ToString("0.00");
                    }
                    else if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Re Dying" && Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value) == "Puttha")
                    {
                        grdDrumming.Rows[e.RowIndex].Cells["colDrummingAmount"].Value = ((list.Find(x => x.WorkType == "Puttha").WorkRate / 400) * Validation.GetSafeDecimal(grdDrumming.Rows[e.RowIndex].Cells["colDrummingWeight"].Value)).ToString("0.00");
                    }
                    //
                    //
                    //
                    else if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Crust" && Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value) == "S. Galma")
                    {
                        grdDrumming.Rows[e.RowIndex].Cells["colDrummingAmount"].Value = ((list.Find(x => x.WorkType == "S.CGalma").WorkRate / 350) * Validation.GetSafeDecimal(grdDrumming.Rows[e.RowIndex].Cells["colDrummingWeight"].Value)).ToString("0.00");
                    }
                    else if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Crust" && Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value) == "S. Puttha")
                    {
                        grdDrumming.Rows[e.RowIndex].Cells["colDrummingAmount"].Value = ((list.Find(x => x.WorkType == "S.CPuttha").WorkRate / 400) * Validation.GetSafeDecimal(grdDrumming.Rows[e.RowIndex].Cells["colDrummingWeight"].Value)).ToString("0.00");
                    }
                    else if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Dying" && Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value) == "S. Galma")
                    {
                        grdDrumming.Rows[e.RowIndex].Cells["colDrummingAmount"].Value = ((list.Find(x => x.WorkType == "SDGalma").WorkRate / 350) * Validation.GetSafeDecimal(grdDrumming.Rows[e.RowIndex].Cells["colDrummingWeight"].Value)).ToString("0.00");
                    }
                    else if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Dying" && Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value) == "S. Puttha")
                    {
                        grdDrumming.Rows[e.RowIndex].Cells["colDrummingAmount"].Value = ((list.Find(x => x.WorkType == "SDPuttha").WorkRate / 400) * Validation.GetSafeDecimal(grdDrumming.Rows[e.RowIndex].Cells["colDrummingWeight"].Value)).ToString("0.00");
                    }
                    else if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Re Dying" && Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value) == "S. Galma")
                    {
                        grdDrumming.Rows[e.RowIndex].Cells["colDrummingAmount"].Value = ((list.Find(x => x.WorkType == "RESGalma").WorkRate / 350) * Validation.GetSafeDecimal(grdDrumming.Rows[e.RowIndex].Cells["colDrummingWeight"].Value)).ToString("0.00");
                    }
                    else if (Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingProcessType"].Value) == "Re Dying" && Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value) == "S. Puttha")
                    {
                        grdDrumming.Rows[e.RowIndex].Cells["colDrummingAmount"].Value = ((list.Find(x => x.WorkType == "RESPuttha").WorkRate / 400) * Validation.GetSafeDecimal(grdDrumming.Rows[e.RowIndex].Cells["colDrummingWeight"].Value)).ToString("0.00");
                    }
                }
                else
                {
                    MessageBox.Show("Please Set Rates First");
                }
            }
            else if (e.ColumnIndex == 10)
            {
                if (Validation.GetSafeLong(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPieces"].Value) > 0)
                {
                    Int64 TotalUnits = 0;
                    var PManager = new TanneryProcessDetailsBLL();
                    string PiecesType = Validation.GetSafeString(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPiecesType"].Value);
                    if (PiecesType != string.Empty)
                    {
                        TotalUnits = PManager.GetProcessesClosingStock("Drumming", "Shaving", PiecesType, PiecesType, 2, cbxVehicles.Text, IdLot);
                        if (TotalUnits == 0)
                        {
                            MessageBox.Show("There Is No '" + PiecesType + "' Stock In Shaving '" + PiecesType + "'");
                            grdDrumming.Rows[e.RowIndex].Cells["colDrummingPieces"].Value = "";
                            return;
                        }
                        else if (TotalUnits < Validation.GetSafeLong(grdDrumming.Rows[e.RowIndex].Cells["colDrummingPieces"].Value))
                        {
                            MessageBox.Show("You Are Exceeding from Shaving '" + PiecesType + "' Stock");
                            grdDrumming.Rows[e.RowIndex].Cells["colDrummingPieces"].Value = "";
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Pieces Type...");
                        grdDrumming.Rows[e.RowIndex].Cells["colDrummingPieces"].Value = "";
                    }
                }
            }
        }
        private void grdDrumming_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdDrumming_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 9)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdDrumming_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdDrumming.CurrentCellAddress.X == 6)
            {
                TextBox txtDrummingVendorName = e.Control as TextBox;
                if (txtDrummingVendorName != null)
                {
                    txtDrummingVendorName.KeyPress -= new KeyPressEventHandler(txtDrummingVendorName_KeyPress);
                    txtDrummingVendorName.KeyPress += new KeyPressEventHandler(txtDrummingVendorName_KeyPress);
                }
            }
        }
        void txtDrummingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdDrumming.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Drumming";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Buffing Grid Events
        private void grdBuffing_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 13)
            {
                e.Value = "Post";
            }
        }
        private void grdBuffing_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (grdBuffing.Rows[e.RowIndex].Cells[5].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdBuffing_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 12)
            {
                var Manager = new TanneryProcessDetailsBLL();
                if (Validation.GetSafeGuid(grdBuffing.Rows[e.RowIndex].Cells["colIdBuffing"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....                    
                    if (grdBuffing.Rows[e.RowIndex].ReadOnly)
                    {
                        if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                        {
                            MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdBuffing.Rows[e.RowIndex].Cells["colIdBuffing"].Value), Validation.GetSafeGuid(grdBuffing.Rows[e.RowIndex].Cells["colBuffingVoucherNo"].Value), "Buffing"))
                                {
                                    MessageBox.Show("Entry Deleted Successfully....");
                                    FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "Buffing");
                                    //TanneryTab_SelectedIndexChanged(sender, e);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdBuffing.Rows[e.RowIndex].Cells["colIdBuffing"].Value), Validation.GetSafeGuid(grdBuffing.Rows[e.RowIndex].Cells["colBuffingVoucherNo"].Value), "Buffing"))
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "Buffing");
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdBuffing.Columns.Count; i++)
                    {
                        grdBuffing.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 13)
            {
                var manager = new TanneryLotBLL();
                TanneryLotEL oelLot = new TanneryLotEL();
                List<TanneryLotDetailEL> listDetail = new List<TanneryLotDetailEL>();
                List<TanneryProcessesEL> listProcesses = new List<TanneryProcessesEL>();
                #region Main Lot Process
                if (IdLot != Guid.Empty)
                {
                    oelLot.IdLot = IdLot;
                }
                else
                {
                    oelLot.IdLot = Guid.NewGuid();
                }
                oelLot.IdVoucher = IdVoucher;
                oelLot.IdUser = Operations.UserID;
                oelLot.LotNo = Validation.GetSafeLong(txtLotNo.Text);
                oelLot.LotDate = DtLot.Value;
                oelLot.IdQuality = IdQuality;
                oelLot.LotWeight = Validation.GetSafeDecimal(txtLotWeight.Text);
                oelLot.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                oelLot.LotType = cbxLotType.SelectedIndex;
                oelLot.CloseDate = DateTime.Now;
                #endregion
                #region Buffing Process Entries
                if (ValidateRecords(6))
                {
                    if (grdBuffing.Rows.Count > 1)
                    {
                        oelLot.Status = "Open";
                        TanneryProcessesEL oelTanneryBuffingProcess = new TanneryProcessesEL();
                        if (IdTanneryBuffing == Guid.Empty)
                        {
                            oelTanneryBuffingProcess.IdProcess = Guid.NewGuid();
                        }
                        else
                        {
                            oelTanneryBuffingProcess.IdProcess = IdTanneryBuffing;
                        }
                        oelTanneryBuffingProcess.IdVoucher = IdVoucher;
                        oelTanneryBuffingProcess.IdUser = Operations.UserID;
                        oelTanneryBuffingProcess.ProcessName = "Buffing";
                        oelTanneryBuffingProcess.VDate = DateTime.Now;

                        listProcesses.Add(oelTanneryBuffingProcess);


                        TanneryLotDetailEL BuffinglotDetail = new TanneryLotDetailEL();
                        BuffinglotDetail.IdUser = Operations.UserID;
                        if (grdBuffing.Rows[e.RowIndex].Cells["colIdBuffing"].Value == null)
                        {
                            BuffinglotDetail.IdLotDetail = Guid.NewGuid();
                            BuffinglotDetail.IsNew = true;
                            grdBuffing.Rows[e.RowIndex].Cells["colIdBuffing"].Value = BuffinglotDetail.IdLotDetail;
                            EntryAlreadyDone = false;
                        }
                        else
                        {
                            BuffinglotDetail.IdLotDetail = Validation.GetSafeGuid(grdBuffing.Rows[e.RowIndex].Cells["colIdBuffing"].Value);
                            EntryAlreadyDone = true;
                        }
                        if (grdBuffing.Rows[e.RowIndex].ReadOnly)
                        {
                            MessageBox.Show("Entry Already Posted Please....");
                            return;
                        }

                        IdEntity = BuffinglotDetail.IdLotDetail;
                        BuffinglotDetail.IdLot = IdLot;
                        BuffinglotDetail.IdProcess = oelTanneryBuffingProcess.IdProcess;
                        BuffinglotDetail.AccountNo = Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingAccountNo"].Value);
                        EmpAccountNo = BuffinglotDetail.AccountNo;
                        EmpAccountName = Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingVendorName"].Value);
                        BuffinglotDetail.WorkingDate = Convert.ToDateTime(grdBuffing.Rows[e.RowIndex].Cells["colBuffingDate"].Value);
                        if (Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingProcessType"].Value) == "Buffing")
                        {
                            BuffinglotDetail.ProcessType = 3;
                            oelLot.ProcessName = "Buffing";
                        }
                        else if (Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingProcessType"].Value) == "Re Buffing")
                        {
                            BuffinglotDetail.ProcessType = 4;
                            oelLot.ProcessName = "Re Buffing";
                        }
                        BuffinglotDetail.SeqNo = e.RowIndex;
                        BuffinglotDetail.Uom = "";
                        //BuffinglotDetail.Pieces = 0;
                        BuffinglotDetail.GalmaPieces = 0;//Validation.GetSafeInteger(grdBuffing.Rows[e.RowIndex].Cells["colBuffingGalmaPieces"].Value);
                        BuffinglotDetail.PutthaPieces = 0; //Validation.GetSafeInteger(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPutthaPeices"].Value); ;
                        BuffinglotDetail.DGalma = Validation.GetSafeInteger(grdBuffing.Rows[e.RowIndex].Cells["colBuffingDGalmaPieces"].Value);
                        BuffinglotDetail.Uom = Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPiecesType"].Value);
                        BuffinglotDetail.Pieces = Validation.GetSafeInteger(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value);
                        BuffinglotDetail.Cutting = 0;
                        BuffinglotDetail.CuttingStock = 0;
                        BuffinglotDetail.CuttingStockValue = 0;
                        BuffinglotDetail.CuttingRateValue = 0;
                        BuffinglotDetail.Amount = Validation.GetSafeDecimal(grdBuffing.Rows[e.RowIndex].Cells["colBuffingAmount"].Value);
                        postAmount = BuffinglotDetail.Amount;
                        BuffinglotDetail.Description = BuildRemarks("Buffing" + "/" + oelLot.ProcessName + " Purchases", EmpAccountName, postAmount);
                        if (Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingAccountType"].Value) == "Employees")
                        {
                            BuffinglotDetail.Posted = true;
                        }
                        else
                        {
                            BuffinglotDetail.Posted = false;
                        }
                        listDetail.Add(BuffinglotDetail);

                    }
                }
                else
                {
                    return;
                }
                #endregion
                #region Save Process
                if (!EntryAlreadyDone)
                {
                    //if (IdLot == Guid.Empty)
                    {
                        IdLot = oelLot.IdLot;
                        if (manager.CreatePostingLot(oelLot, listProcesses, listDetail))
                        {
                            //if (Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingAccountType"].Value) != "Employees")
                            //{
                            //    frmworkpurchases = new frmWorkPurchases();
                            //    frmworkpurchases.ProductionType = "Tannery";
                            //    frmworkpurchases.IdEntity = IdEntity;
                            //    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                            //    frmworkpurchases.EmpAccountName = EmpAccountName;
                            //    frmworkpurchases.PurchasesType = "Buffing Purchases";
                            //    frmworkpurchases.ProcessName = "Buffing";
                            //    frmworkpurchases.ProcessAmount = postAmount;
                            //    frmworkpurchases.ShowDialog();
                            //}
                            FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "Buffing");
                        }
                    }
                }
                else
                {
                    if (manager.UpdatePostingLot(oelLot, listProcesses, listDetail))
                    {
                        //frmworkpurchases = new frmWorkPurchases();
                        //frmworkpurchases.IdEntity = IdEntity;
                        //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                        //frmworkpurchases.EmpAccountName = EmpAccountName;
                        //frmworkpurchases.PurchasesType = "Buffing Purchases";
                        //frmworkpurchases.ProcessName = "Buffing";
                        //frmworkpurchases.ProcessAmount = postAmount;
                        //frmworkpurchases.ShowDialog();
                    }
                    FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "Buffing");
                }
                #endregion
            }
            #endregion
        }
        private void grdBuffing_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            //if (grdDrumming.Rows.Count > 0)
            //{
            //    if (Validation.GetSafeString(grdDrumming.Rows[0].Cells["colDrummingPiecesType"].Value) == "Galma")
            //    {
            //        grdBuffing.Rows[e.RowIndex].Cells["colBuffingGalmaPieces"].Value = grdDrumming.Rows[0].Cells["colDrummingPieces"].Value;
            //    }
            //    else if (Validation.GetSafeString(grdDrumming.Rows[0].Cells["colDrummingPiecesType"].Value) == "Puttha")
            //    {
            //        grdBuffing.Rows[e.RowIndex].Cells["colBuffingPutthaPeices"].Value = grdDrumming.Rows[0].Cells["colDrummingPieces"].Value;
            //    }
            //}

            if (e.ColumnIndex == 7)
            {
                SendKeys.Send("{F4}");
            }
            else if (e.ColumnIndex == 8)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdBuffing_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var Manager = new WagesBLL();
            if (e.ColumnIndex == 8)
            {
                //list = Manager.GetWagesByProcess("Buffing / ReBuffing");
                //if (list.Count > 0)
                //{
                //    grdBuffing.Rows[e.RowIndex].Cells["colBuffingAmount"].Value = (Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value ?? 0) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "Galma").WorkRate)) +
                //                                                                  (Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingDGalmaPieces"].Value ?? 0) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "D.Galma").WorkRate)) +
                //                                                                  (Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value ?? 0) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "Puttha").WorkRate)) +
                //                                                                  (Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value ?? 0) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "S.Galma").WorkRate)) +
                //                                                                  (Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value ?? 0) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "S.Puttha").WorkRate));
                //}
                //else
                //{
                //    MessageBox.Show("Please Set Rates First");
                //}
            }
            else if (e.ColumnIndex == 9)
            {
                if (Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value) > 0)
                {
                    Int64 TotalUnits = 0;
                    var PManager = new TanneryProcessDetailsBLL();
                    string PiecesType = Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPiecesType"].Value);
                    string ProcessType = Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingProcessType"].Value);
                    if (PiecesType != string.Empty)
                    {
                        if (ProcessType != "Re Buffing")
                        {
                            TotalUnits = PManager.GetProcessesClosingStock("Buffing", "Drumming", PiecesType, PiecesType, 3, cbxVehicles.Text, IdLot);
                            if (TotalUnits == 0)
                            {
                                MessageBox.Show("There Is No '" + PiecesType + "' Stock In Drumming '" + PiecesType + "' For Lot No : '"+ txtLotNo.Text +"'");
                                grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value = "";
                                return;
                            }
                            else if (TotalUnits < Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value))
                            {
                                MessageBox.Show("You Are Exceeding from Drumming '" + PiecesType + "' Stock for Lot No : '" + txtLotNo.Text + "'");
                                grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value = "";
                                return;
                            }
                            else
                            {
                                list = Manager.GetWagesByProcess("Buffing / ReBuffing");
                                if (list.Count > 0)
                                {
                                    if (Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPiecesType"].Value) == "Galma")
                                    {
                                        grdBuffing.Rows[e.RowIndex].Cells["colBuffingAmount"].Value = (Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value ?? 0) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "Galma").WorkRate));
                                    }
                                    else if (Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPiecesType"].Value) == "Puttha")
                                    {
                                        grdBuffing.Rows[e.RowIndex].Cells["colBuffingAmount"].Value = (Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value ?? 0) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "Puttha").WorkRate));
                                    }
                                    else if (Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPiecesType"].Value) == "S. Galma")
                                    {
                                        grdBuffing.Rows[e.RowIndex].Cells["colBuffingAmount"].Value = (Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value ?? 0) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "S.Galma").WorkRate));
                                    }
                                    else if (Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPiecesType"].Value) == "S. Puttha")
                                    {
                                        grdBuffing.Rows[e.RowIndex].Cells["colBuffingAmount"].Value = Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value ?? 0) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "S.Puttha").WorkRate);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please Set Rates First");
                                }
                            }
                        }
                        else
                        {
                            list = Manager.GetWagesByProcess("Buffing / ReBuffing");
                            if (list.Count > 0)
                            {
                                if (Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPiecesType"].Value) == "Galma")
                                {
                                    grdBuffing.Rows[e.RowIndex].Cells["colBuffingAmount"].Value = (Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value ?? 0) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "Galma").WorkRate));
                                }
                                else if (Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPiecesType"].Value) == "Puttha")
                                {
                                    grdBuffing.Rows[e.RowIndex].Cells["colBuffingAmount"].Value = (Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value ?? 0) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "Puttha").WorkRate));
                                }
                                else if (Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPiecesType"].Value) == "S. Galma")
                                {
                                    grdBuffing.Rows[e.RowIndex].Cells["colBuffingAmount"].Value = (Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value ?? 0) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "S.Galma").WorkRate));
                                }
                                else if (Validation.GetSafeString(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPiecesType"].Value) == "S. Puttha")
                                {
                                    grdBuffing.Rows[e.RowIndex].Cells["colBuffingAmount"].Value = Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingPieces"].Value ?? 0) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "S.Puttha").WorkRate);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please Set Rates First");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Pieces Type...");
                        grdBuffing.Rows[e.RowIndex].Cells["colBuffingPiecesType"].Value = "";
                    }
                }
            }
            else if (e.ColumnIndex == 10)
            {
                decimal DGalmaWagesCalculator = 0;
                if (Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingDGalmaPieces"].Value) > 0)
                {
                    DGalmaWagesCalculator = (Validation.GetSafeLong(grdBuffing.Rows[e.RowIndex].Cells["colBuffingDGalmaPieces"].Value ?? 0) * Validation.GetSafeDecimal(list.Find(x => x.WorkType == "D.Galma").WorkRate));
                }
                grdBuffing.Rows[e.RowIndex].Cells["colBuffingAmount"].Value = Validation.GetSafeDecimal(grdBuffing.Rows[e.RowIndex].Cells["colBuffingAmount"].Value) + DGalmaWagesCalculator;
            }
        }
        private void grdBuffing_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdBuffing_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdBuffing.CurrentCellAddress.X == 6)
            {
                TextBox txtBuffingVendorName = e.Control as TextBox;
                if (txtBuffingVendorName != null)
                {
                    txtBuffingVendorName.KeyPress -= new KeyPressEventHandler(txtBuffingVendorName_KeyPress);
                    txtBuffingVendorName.KeyPress += new KeyPressEventHandler(txtBuffingVendorName_KeyPress);
                }
            }
        }
        void txtBuffingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdBuffing.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Buffing";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Cutting Grid Events
        private void grdCutting_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                e.Value = "Delete";
            }
            else if (e.ColumnIndex == 15)
            {
                e.Value = "post";
            }
        }
        private void grdCutting_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (grdCutting.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    //MessageBox.Show(grdTrimming.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
        }
        private void grdCutting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Record Deletion
            if (e.ColumnIndex == 14)
            {
                var Manager = new TanneryProcessDetailsBLL();
                if (Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value) != Guid.Empty)
                {
                    /// Delete From Database.....
                    if (grdCutting.Rows[e.RowIndex].ReadOnly)
                    {
                        if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                        {
                            MessageBox.Show("This Entry Is Posted and Can not be Deleted....");
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value), Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingVoucherNo"].Value), "Cutting"))
                                {
                                    MessageBox.Show("Entry Deleted Successfully....");
                                    FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "Cutting");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Do You Want To Delete Entry ?", "Deletion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (Manager.DeleteProcessEntry(Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value), Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingVoucherNo"].Value), "Cutting"))
                            {
                                MessageBox.Show("Entry Deleted Successfully....");
                                FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "Cutting");
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdCutting.Columns.Count; i++)
                    {
                        grdCutting.Rows[e.RowIndex].Cells[i].Value = "";
                    }
                }
            }
            #endregion
            #region Record Insertion / Updation
            else if (e.ColumnIndex == 15)
            {
                var manager = new TanneryLotBLL();
                TanneryLotEL oelLot = new TanneryLotEL();
                List<TanneryLotDetailEL> listDetail = new List<TanneryLotDetailEL>();
                List<TanneryProcessesEL> listProcesses = new List<TanneryProcessesEL>();
                #region Main Lot Process
                if (IdLot != Guid.Empty)
                {
                    oelLot.IdLot = IdLot;
                }
                else
                {
                    oelLot.IdLot = Guid.NewGuid();
                }
                oelLot.IdVoucher = IdVoucher;
                oelLot.IdUser = Operations.UserID;
                oelLot.LotNo = Validation.GetSafeLong(txtLotNo.Text);
                oelLot.LotDate = DtLot.Value;
                if (grdCutting.Rows.Count > 0)
                {
                    oelLot.IdQuality = Validation.GetSafeGuid(grdCutting.Rows[0].Cells["colCuttingIdQuality"].Value);
                }
                else
                {
                    oelLot.IdQuality = IdQuality;
                }
                oelLot.LotWeight = Validation.GetSafeDecimal(txtLotWeight.Text);
                oelLot.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                oelLot.LotType = cbxLotType.SelectedIndex;
                oelLot.CloseDate = DateTime.Now;
                #endregion
                #region Cutting Process Entries
                if (ValidateRecords(7))
                {
                    if (grdCutting.Rows.Count > 1)
                    {
                        oelLot.Status = "Open";
                        oelLot.ProcessName = "Cutting";
                        TanneryProcessesEL oelTanneryCuttingProcess = new TanneryProcessesEL();
                        if (IdTanneryCutting == Guid.Empty)
                        {
                            oelTanneryCuttingProcess.IdProcess = Guid.NewGuid();
                        }
                        else
                        {
                            oelTanneryCuttingProcess.IdProcess = IdTanneryCutting;
                        }
                        oelTanneryCuttingProcess.IdVoucher = IdVoucher;
                        oelTanneryCuttingProcess.IdUser = Operations.UserID;
                        oelTanneryCuttingProcess.ProcessName = "Cutting";
                        oelTanneryCuttingProcess.VDate = DateTime.Now;

                        listProcesses.Add(oelTanneryCuttingProcess);
                        
                        /// Cutting Detail Starts here.....
                        TanneryLotDetailEL CuttinglotDetail = new TanneryLotDetailEL();
                        CuttinglotDetail.IdUser = Operations.UserID;
                        if (grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value == null)
                        {
                            CuttinglotDetail.IdLotDetail = Guid.NewGuid();
                            CuttinglotDetail.IsNew = true;
                            grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value = CuttinglotDetail.IdLotDetail;
                            EntryAlreadyDone = false;
                        }
                        else
                        {
                            CuttinglotDetail.IdLotDetail = Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colIdCutting"].Value);
                            EntryAlreadyDone = true;
                        }
                        if (grdCutting.Rows[e.RowIndex].ReadOnly)
                        {
                            MessageBox.Show("Entry Already Saved Please....");
                            return;
                        }
                        IdEntity = CuttinglotDetail.IdLotDetail;
                        CuttinglotDetail.IdLot = IdLot;
                        CuttinglotDetail.IdProcess = oelTanneryCuttingProcess.IdProcess;
                        CuttinglotDetail.AccountNo = Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountNo"].Value);
                        EmpAccountNo = CuttinglotDetail.AccountNo;
                        EmpAccountName = Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingVendorName"].Value);

                        CuttinglotDetail.WorkingDate = Convert.ToDateTime(grdCutting.Rows[e.RowIndex].Cells["colCuttingDate"].Value);
                        CuttinglotDetail.ProcessType = -1;
                        CuttinglotDetail.Uom = Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingUOM"].Value);
                        CuttinglotDetail.SeqNo = e.RowIndex;
                        CuttinglotDetail.Pieces = 0;
                        CuttinglotDetail.GalmaPieces = 0;
                        CuttinglotDetail.PutthaPieces = 0;
                        CuttinglotDetail.DGalma = 0;
                        if (grdCutting.Rows[e.RowIndex].Cells["colCuttingIdQuality"].Value != null)
                        {
                            CuttinglotDetail.IdQuality = Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingIdQuality"].Value);
                        }
                        else
                        {
                            CuttinglotDetail.IdQuality = IdQuality;
                        }
                        CuttinglotDetail.Cutting = Validation.GetSafeInteger(grdCutting.Rows[e.RowIndex].Cells["colCuttingQty"].Value);
                        CuttinglotDetail.CuttingRateValue = Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colCuttingValue"].Value);
                        CuttinglotDetail.CuttingStock = Validation.GetSafeInteger(grdCutting.Rows[e.RowIndex].Cells["colCuttingStock"].Value);
                        CuttinglotDetail.CuttingStockValue = CuttinglotDetail.Cutting * Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colCuttingValue"].Value);
                        CuttinglotDetail.Amount = Validation.GetSafeDecimal(grdCutting.Rows[e.RowIndex].Cells["colCuttingWages"].Value);
                        postAmount = CuttinglotDetail.Amount;
                        CuttinglotDetail.Description = BuildRemarks("Cutting Purchases", EmpAccountName, postAmount);
                        if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountType"].Value) == "Employees")
                        {
                            CuttinglotDetail.Posted = true;
                        }
                        else
                        {
                            CuttinglotDetail.Posted = false;
                        }
                        listDetail.Add(CuttinglotDetail);

                    }
                }
                else
                {
                    return;
                }
                #endregion
                #region Save Process
                if (!EntryAlreadyDone)
                {
                    //if (IdLot == Guid.Empty)
                    {
                        IdLot = oelLot.IdLot;
                        if (manager.CreatePostingLot(oelLot, listProcesses, listDetail))
                        {
                            //if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountType"].Value) != "Employees")
                            //{
                            //    frmworkpurchases = new frmWorkPurchases();
                            //    frmworkpurchases.ProductionType = "Tannery";
                            //    frmworkpurchases.IdEntity = IdEntity;
                            //    frmworkpurchases.EmpAccountNo = EmpAccountNo;
                            //    frmworkpurchases.EmpAccountName = EmpAccountName;
                            //    frmworkpurchases.PurchasesType = "Cutting Purchases";
                            //    frmworkpurchases.ProcessName = "Cutting";
                            //    frmworkpurchases.ProcessAmount = postAmount;
                            //    frmworkpurchases.ShowDialog();
                            //}
                            FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "Cutting");
                        }
                    }
                }
                else
                {
                    if (manager.UpdatePostingLot(oelLot, listProcesses, listDetail))
                    {
                        if (Validation.GetSafeString(grdCutting.Rows[e.RowIndex].Cells["colCuttingAccountType"].Value) != "Employees")
                        {
                            //frmworkpurchases = new frmWorkPurchases();
                            //frmworkpurchases.IdEntity = IdEntity;
                            //frmworkpurchases.EmpAccountNo = EmpAccountNo;
                            //frmworkpurchases.EmpAccountName = EmpAccountName;
                            //frmworkpurchases.PurchasesType = "Cutting Purchases";
                            //frmworkpurchases.ProcessName = "Cutting";
                            //frmworkpurchases.ProcessAmount = postAmount;
                            //frmworkpurchases.ShowDialog();
                        }
                    }
                    FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "Cutting");
                }
                #endregion
            }
            #endregion
        }
        private void grdCutting_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                //grdCutting.Rows[e.RowIndex].Cells["colCuttingIdQuality"].Value = IdQuality;
                //grdCutting.Rows[e.RowIndex].Cells["colCuttingQuality"].Value = txtQuality.Text;

            }
            else if (e.ColumnIndex == 11)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdCutting_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = null;
            if (e.ColumnIndex == 9)
            {
                list = manager.GetItemById(Validation.GetSafeGuid(grdCutting.Rows[e.RowIndex].Cells["colCuttingIdQuality"].Value));
                if (list.Count > 0)
                {
                    if (list[0].CuttingRates > 0 && list[0].CuttingWages > 0)
                    {
                        grdCutting.Rows[e.RowIndex].Cells["colCuttingValue"].Value = Validation.GetSafeInteger(grdCutting.Rows[e.RowIndex].Cells["colCuttingQty"].Value) * list[0].CuttingRates;
                        grdCutting.Rows[e.RowIndex].Cells["colCuttingWages"].Value = Validation.GetSafeInteger(grdCutting.Rows[e.RowIndex].Cells["colCuttingQty"].Value) * list[0].CuttingWages;
                    }
                    else
                    {
                        MessageBox.Show("Please Set Rates First");
                    }
                }
                else
                {
                    MessageBox.Show("Please Set Rates First");
                }
            }
        }
        private void grdCutting_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //var Manager = new WagesBLL();
            //if (e.ColumnIndex == 9)
            //{
            //    list = Manager.GetWagesByProcess("Cutting");
            //    grdCutting.Rows[e.RowIndex].Cells["colCuttingQuality"].Value = list.Find(x => x.WorkType == "").CuttingRate;
            //}
            //if (e.ColumnIndex == 10)
            //{
            //    list = Manager.GetWagesByProcess("Cutting");
            //    grdCutting.Rows[e.RowIndex].Cells["colCuttingQuality"].Value = Validation.GetSafeLong(grdCutting.Rows[e.RowIndex].Cells["colCuttingQty"].Value) * list.Find(x => x.WorkType == "").WorkRate;
            //}
        }
        private void grdCutting_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdCutting.CurrentCellAddress.X == 7)
            {
                TextBox txtCuttingVendorName = e.Control as TextBox;
                if (txtCuttingVendorName != null)
                {
                    txtCuttingVendorName.KeyPress -= new KeyPressEventHandler(txtCuttingVendorName_KeyPress);
                    txtCuttingVendorName.KeyPress += new KeyPressEventHandler(txtCuttingVendorName_KeyPress);
                }
            }
            if (grdCutting.CurrentCellAddress.X == 8)
            {
                TextBox txtCuttingQuality = e.Control as TextBox;
                if (txtCuttingQuality != null)
                {
                    txtCuttingQuality.KeyPress -= new KeyPressEventHandler(txtCuttingQuality_KeyPress);
                    txtCuttingQuality.KeyPress += new KeyPressEventHandler(txtCuttingQuality_KeyPress);
                }
            }
        }
        void txtCuttingVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCutting.CurrentCellAddress.X == 7)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    EventFiringName = "Cutting";
                    frmfindAccount = new frmFindAccounts();
                    frmfindAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmfindAccount_ExecuteFindAccountEvent);
                    frmfindAccount.SearchText = e.KeyChar.ToString();
                    frmfindAccount.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        void txtCuttingQuality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdCutting.CurrentCellAddress.X == 8)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                {
                    EventFiringName = "CuttingQuality";
                    frmstockAccounts = new frmStockAccounts();
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    //SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Enter)
                {
                    grdDrumming.Focus();
                }
                else
                    e.Handled = true;
            }
        }
        #endregion
        #region Lots Grid Events
        private void grdLots_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                e.Value = "Delete";
            }
        }
        private void grdLots_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdLot = Validation.GetSafeGuid(grdLots.Rows[e.RowIndex].Cells["colIdLot"].Value);
            txtLotNo.Text = Validation.GetSafeString(grdLots.Rows[e.RowIndex].Cells["colLotNo"].Value);
            FillLotDetails(Validation.GetSafeLong(txtLotNo.Text), "All");
            FillLotChemicals(IdLot);
            if (Validation.GetSafeString(grdLots.Rows[e.RowIndex].Cells["colLotStatus"].Value) == "Closed")
            {
                grdChemicals.Enabled = false;
            }
            else
            {
                grdChemicals.Enabled = true;
            }
        }
        private void grdLots_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var manager = new TanneryLotBLL();
            if (e.ColumnIndex == 4)
            {
                if (Validation.GetSafeString(grdLots.Rows[e.RowIndex].Cells["colLotStatus"].Value) == "Closed")
                {
                    MessageBox.Show("Lot Is Closed And Can not be Deleted...");
                    return;
                }
                else
                {
                    if (MessageBox.Show("Are You Sure To Delete This Lot", "Deleting Lot", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Guid IdLot = Validation.GetSafeGuid(grdLots.Rows[e.RowIndex].Cells["colIdLot"].Value);
                        if (manager.DeleteTanneryLot(IdLot).IsSuccess)
                        {
                            MessageBox.Show("Lot Deleted Successfully...");
                            txtQuality.Text = string.Empty;
                            IdQuality = Guid.Empty;
                            grdLots.Rows.Remove(grdLots.Rows[e.RowIndex]);
                            grdDrumming.Rows.Clear();
                            grdBuffing.Rows.Clear();
                            grdCutting.Rows.Clear();
                            grdChemicals.DataSource = null;
                        }
                    }
                }
            }
        }
        #endregion
        #region Triming Events
        private void btnTrimmingSave_Click(object sender, EventArgs e)
        {
            var Manager = new TanneryProcessesHeadBLL();
            TanneryProcessesHeadEL oelTanneryHead = new TanneryProcessesHeadEL();
            TanneryProcessesEL oelTanneryProcess = new TanneryProcessesEL();
            List<TanneryProcessDetailsEL> oelTanneryProcessesDetailCollection = new List<TanneryProcessDetailsEL>();
            if (IdVoucher == Guid.Empty)
            {
                oelTanneryHead.IdVoucher = Guid.NewGuid();
            }
            else
            {
                oelTanneryHead.IdVoucher = IdVoucher;
            }
            oelTanneryHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
            oelTanneryHead.IdCompany = Operations.IdCompany;
            oelTanneryHead.UserId = Operations.UserID;
            oelTanneryHead.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
            oelTanneryHead.VDate = TanneryDate.Value;
            oelTanneryHead.Description = "N/A";
            oelTanneryHead.Amount = 0;
            oelTanneryHead.CloseDate = DateTime.Now;

            if (IdTrimming == Guid.Empty)
            {
                oelTanneryProcess.IdProcess = Guid.NewGuid();
            }
            else
            {
                oelTanneryProcess.IdProcess = IdTrimming;
            }
            oelTanneryProcess.IdVoucher = oelTanneryHead.IdVoucher;
            oelTanneryProcess.ProcessName = "Trimming";
            oelTanneryProcess.VDate = DateTime.Now;

            for (int i = 0; i < grdTrimming.Rows.Count - 1; i++)
            {
                TanneryProcessDetailsEL oelTanneryDetail = new TanneryProcessDetailsEL();
                if (grdTrimming.Rows[i].Cells["colIdTrimming"].Value == null)
                {
                    oelTanneryDetail.IdProcessDetail = Guid.NewGuid();
                    grdTrimming.Rows[i].Cells["colIdTrimming"].Value = oelTanneryDetail.IdProcessDetail;
                    oelTanneryDetail.IsNew = true;
                }
                else
                {
                    oelTanneryDetail.IdProcessDetail = Validation.GetSafeGuid(grdTrimming.Rows[i].Cells["colIdTrimming"].Value);
                }
                oelTanneryDetail.IdProcess = oelTanneryProcess.IdProcess;
                oelTanneryDetail.AccountNo = Validation.GetSafeString(grdTrimming.Rows[i].Cells["colTrimmingAccountNo"].Value);
                oelTanneryDetail.Description = Validation.GetSafeString(grdTrimming.Rows[i].Cells["colTrimmingDescription"].Value);
                oelTanneryDetail.IdItem = Guid.Empty;
                oelTanneryDetail.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                oelTanneryDetail.Galma = Validation.GetSafeInteger(grdTrimming.Rows[i].Cells["colTrimmingGalma"].Value);
                oelTanneryDetail.GalmaPieces = 0;
                oelTanneryDetail.Puttha = Validation.GetSafeInteger(grdTrimming.Rows[i].Cells["colTrimmingPuttha"].Value);
                oelTanneryDetail.PutthaPieces = 0;
                oelTanneryDetail.DGalma = 0;
                oelTanneryDetail.DPuttha = 0;
                oelTanneryDetail.Pieces = 0;
                oelTanneryDetail.WorkDate = Convert.ToDateTime(grdTrimming.Rows[i].Cells["colTrimmingDate"].Value);
                oelTanneryDetail.SSet = 0;
                oelTanneryDetail.Rate = Validation.GetSafeLong(grdTrimming.Rows[i].Cells["colTrimmingRate"].Value);
                oelTanneryDetail.Amount = Validation.GetSafeDecimal(grdTrimming.Rows[i].Cells["colTrimmingAmount"].Value);

                oelTanneryProcessesDetailCollection.Add(oelTanneryDetail);

            }
            if (IdTrimming == Guid.Empty)
            {
                IdVoucher = oelTanneryHead.IdVoucher;
                IdTrimming = oelTanneryProcess.IdProcess;
                if (Manager.CreateProcessHead(oelTanneryHead, oelTanneryProcess, oelTanneryProcessesDetailCollection).IsSuccess)
                {

                }
            }
            else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelTanneryProcessesDetailCollection).IsSuccess)
            {

            }
        }
        #endregion
        #region Splitting Events
        private void btnSplittingSave_Click(object sender, EventArgs e)
        {
            var Manager = new TanneryProcessesHeadBLL();
            TanneryProcessesHeadEL oelTanneryHead = new TanneryProcessesHeadEL();
            TanneryProcessesEL oelTanneryProcess = new TanneryProcessesEL();
            List<TanneryProcessDetailsEL> oelSplittingProcessesDetailCollection = new List<TanneryProcessDetailsEL>();
            if (IdVoucher == Guid.Empty)
            {
                oelTanneryHead.IdVoucher = Guid.NewGuid();
                IdVoucher = oelTanneryHead.IdVoucher;
            }
            else
            {
                oelTanneryHead.IdVoucher = IdVoucher;
            }
            oelTanneryHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
            oelTanneryHead.IdCompany = Operations.IdCompany;
            oelTanneryHead.UserId = Operations.UserID;
            oelTanneryHead.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
            oelTanneryHead.VDate = TanneryDate.Value;
            oelTanneryHead.Description = "N/A";
            oelTanneryHead.Amount = 0;
            oelTanneryHead.CloseDate = DateTime.Now;

            if (IdSplitting == Guid.Empty)
            {
                oelTanneryProcess.IdProcess = Guid.NewGuid();
            }
            else
            {
                oelTanneryProcess.IdProcess = IdSplitting;
            }
            oelTanneryProcess.IdVoucher = oelTanneryHead.IdVoucher;
            oelTanneryProcess.ProcessName = "Splitting";
            oelTanneryProcess.VDate = DateTime.Now;

            for (int i = 0; i < grdSplitting.Rows.Count - 1; i++)
            {
                TanneryProcessDetailsEL oelTanneryDetail = new TanneryProcessDetailsEL();
                if (grdSplitting.Rows[i].Cells["colIdSplitting"].Value == null)
                {
                    oelTanneryDetail.IdProcessDetail = Guid.NewGuid();
                    grdSplitting.Rows[i].Cells["colIdSplitting"].Value = oelTanneryDetail.IdProcessDetail;
                    oelTanneryDetail.IsNew = true;
                }
                else
                {
                    oelTanneryDetail.IdProcessDetail = Validation.GetSafeGuid(grdSplitting.Rows[i].Cells["colIdSplitting"].Value);
                }
                oelTanneryDetail.IdProcess = oelTanneryProcess.IdProcess;
                oelTanneryDetail.AccountNo = Validation.GetSafeString(grdSplitting.Rows[i].Cells["colSplittingAccountNo"].Value);
                oelTanneryDetail.Description = Validation.GetSafeString(grdSplitting.Rows[i].Cells["colSplittingDescription"].Value);
                oelTanneryDetail.IdItem = Guid.Empty;
                oelTanneryDetail.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                oelTanneryDetail.Galma = 0;
                oelTanneryDetail.Puttha = 0;
                oelTanneryDetail.PutthaPieces = Validation.GetSafeInteger(grdSplitting.Rows[i].Cells["colSplittingPutthaPiece"].Value);
                oelTanneryDetail.GalmaPieces = Validation.GetSafeInteger(grdSplitting.Rows[i].Cells["colSplittingGalmaPieces"].Value);
                oelTanneryDetail.DGalma = 0;
                oelTanneryDetail.DPuttha = 0;
                oelTanneryDetail.Pieces = 0;
                oelTanneryDetail.WorkDate = Convert.ToDateTime(grdSplitting.Rows[i].Cells["colSplittingDate"].Value);
                oelTanneryDetail.SSet = 0;
                oelTanneryDetail.Rate = Validation.GetSafeLong(grdSplitting.Rows[i].Cells["colSplittingRate"].Value);
                oelTanneryDetail.Amount = Validation.GetSafeDecimal(grdSplitting.Rows[i].Cells["colSplittingAmount"].Value);

                oelSplittingProcessesDetailCollection.Add(oelTanneryDetail);

            }
            if (IdSplitting == Guid.Empty)
            {
                IdSplitting = oelTanneryProcess.IdProcess;
                if (Manager.CreateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
                {

                }
            }
            else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelSplittingProcessesDetailCollection).IsSuccess)
            {

            }
        }
        #endregion
        #region ReTrimming Events
        private void btnRetrimmingSave_Click(object sender, EventArgs e)
        {
            var Manager = new TanneryProcessesHeadBLL();
            TanneryProcessesHeadEL oelTanneryHead = new TanneryProcessesHeadEL();
            TanneryProcessesEL oelTanneryProcess = new TanneryProcessesEL();
            List<TanneryProcessDetailsEL> oelRetrimmingProcessesDetailCollection = new List<TanneryProcessDetailsEL>();
            if (IdVoucher == Guid.Empty)
            {
                oelTanneryHead.IdVoucher = Guid.NewGuid();
                IdVoucher = oelTanneryHead.IdVoucher;
            }
            else
            {
                oelTanneryHead.IdVoucher = IdVoucher;
            }
            oelTanneryHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
            oelTanneryHead.IdCompany = Operations.IdCompany;
            oelTanneryHead.UserId = Operations.UserID;
            oelTanneryHead.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
            oelTanneryHead.VDate = TanneryDate.Value;
            oelTanneryHead.Description = "N/A";
            oelTanneryHead.Amount = 0;
            oelTanneryHead.CloseDate = DateTime.Now;

            if (IdReTrimming == Guid.Empty)
            {
                oelTanneryProcess.IdProcess = Guid.NewGuid();
            }
            else
            {
                oelTanneryProcess.IdProcess = IdReTrimming;
            }
            oelTanneryProcess.IdVoucher = oelTanneryHead.IdVoucher;
            oelTanneryProcess.ProcessName = "ReTrimming";
            oelTanneryProcess.VDate = DateTime.Now;

            for (int i = 0; i < grdRetrimming.Rows.Count - 1; i++)
            {
                TanneryProcessDetailsEL oelTanneryDetail = new TanneryProcessDetailsEL();
                if (grdRetrimming.Rows[i].Cells["colReTrimmingId"].Value == null)
                {
                    oelTanneryDetail.IdProcessDetail = Guid.NewGuid();
                    grdRetrimming.Rows[i].Cells["colReTrimmingId"].Value = oelTanneryDetail.IdProcessDetail;
                    oelTanneryDetail.IsNew = true;
                }
                else
                {
                    oelTanneryDetail.IdProcessDetail = Validation.GetSafeGuid(grdRetrimming.Rows[i].Cells["colReTrimmingId"].Value);
                }
                oelTanneryDetail.IdProcess = oelTanneryProcess.IdProcess;
                oelTanneryDetail.AccountNo = Validation.GetSafeString(grdRetrimming.Rows[i].Cells["colRetrimmingAccountNo"].Value);
                oelTanneryDetail.Description = Validation.GetSafeString(grdRetrimming.Rows[i].Cells["colRetrimmingDescription"].Value);
                oelTanneryDetail.IdItem = Guid.Empty;
                oelTanneryDetail.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                oelTanneryDetail.Puttha = Validation.GetSafeInteger(grdRetrimming.Rows[i].Cells["colRetrimmingPuttha"].Value);
                oelTanneryDetail.Galma = Validation.GetSafeInteger(grdRetrimming.Rows[i].Cells["colRetrimmingGalma"].Value);
                oelTanneryDetail.Pieces = Validation.GetSafeInteger(grdRetrimming.Rows[i].Cells["colRetrimmingPieces"].Value);

                oelTanneryDetail.PutthaPieces = 0;
                oelTanneryDetail.GalmaPieces = 0;
                oelTanneryDetail.DGalma = 0;
                oelTanneryDetail.DPuttha = 0;
                oelTanneryDetail.WorkDate = Convert.ToDateTime(grdRetrimming.Rows[i].Cells["colRetrimmingDate"].Value);
                oelTanneryDetail.SSet = 0;
                oelTanneryDetail.Rate = Validation.GetSafeLong(grdRetrimming.Rows[i].Cells["colRetrimmingRate"].Value);
                oelTanneryDetail.Amount = Validation.GetSafeDecimal(grdRetrimming.Rows[i].Cells["colRetrimmingAmount"].Value);

                oelRetrimmingProcessesDetailCollection.Add(oelTanneryDetail);

            }
            if (IdReTrimming == Guid.Empty)
            {
                IdReTrimming = oelTanneryProcess.IdProcess;
                if (Manager.CreateProcessHead(oelTanneryHead, oelTanneryProcess, oelRetrimmingProcessesDetailCollection).IsSuccess)
                {

                }
            }
            else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelRetrimmingProcessesDetailCollection).IsSuccess)
            {

            }
        }
        #endregion
        #region Shaving Events
        private void btnShavingSave_Click(object sender, EventArgs e)
        {
            var Manager = new TanneryProcessesHeadBLL();
            TanneryProcessesHeadEL oelTanneryHead = new TanneryProcessesHeadEL();
            TanneryProcessesEL oelTanneryProcess = new TanneryProcessesEL();
            List<TanneryProcessDetailsEL> oelShavingProcessesDetailCollection = new List<TanneryProcessDetailsEL>();
            if (IdVoucher == Guid.Empty)
            {
                oelTanneryHead.IdVoucher = Guid.NewGuid();
                IdVoucher = oelTanneryHead.IdVoucher;
            }
            else
            {
                oelTanneryHead.IdVoucher = IdVoucher;
            }
            oelTanneryHead.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
            oelTanneryHead.IdCompany = Operations.IdCompany;
            oelTanneryHead.UserId = Operations.UserID;
            oelTanneryHead.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
            oelTanneryHead.VDate = TanneryDate.Value;
            oelTanneryHead.Description = "N/A";
            oelTanneryHead.Amount = 0;
            oelTanneryHead.CloseDate = DateTime.Now;

            if (IdShaving == Guid.Empty)
            {
                oelTanneryProcess.IdProcess = Guid.NewGuid();
            }
            else
            {
                oelTanneryProcess.IdProcess = IdShaving;
            }
            oelTanneryProcess.IdVoucher = oelTanneryHead.IdVoucher;
            oelTanneryProcess.ProcessName = "Shaving";
            oelTanneryProcess.VDate = DateTime.Now;

            for (int i = 0; i < grdShaving.Rows.Count - 1; i++)
            {
                TanneryProcessDetailsEL oelTanneryDetail = new TanneryProcessDetailsEL();
                if (grdShaving.Rows[i].Cells["colIdShaving"].Value == null)
                {
                    oelTanneryDetail.IdProcessDetail = Guid.NewGuid();
                    grdShaving.Rows[i].Cells["colIdShaving"].Value = oelTanneryDetail.IdProcessDetail;
                    oelTanneryDetail.IsNew = true;
                }
                else
                {
                    oelTanneryDetail.IdProcessDetail = Validation.GetSafeGuid(grdShaving.Rows[i].Cells["colIdShaving"].Value);
                }
                oelTanneryDetail.IdProcess = oelTanneryProcess.IdProcess;
                oelTanneryDetail.AccountNo = Validation.GetSafeString(grdShaving.Rows[i].Cells["colShavingAccountNo"].Value);
                oelTanneryDetail.Description = "N/A";
                oelTanneryDetail.IdItem = Validation.GetSafeGuid(grdShaving.Rows[i].Cells["colShavingIdItem"].Value);
                oelTanneryDetail.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);

                oelTanneryDetail.Puttha = Validation.GetSafeInteger(grdShaving.Rows[i].Cells["colShavingPuttha"].Value);
                oelTanneryDetail.Galma = Validation.GetSafeInteger(grdShaving.Rows[i].Cells["colShavingGalma"].Value);
                oelTanneryDetail.DGalma = Validation.GetSafeInteger(grdShaving.Rows[i].Cells["colShavingDGalma"].Value);
                oelTanneryDetail.DPuttha = Validation.GetSafeInteger(grdShaving.Rows[i].Cells["colShavingDPuttha"].Value);
                oelTanneryDetail.SSet = Validation.GetSafeInteger(grdShaving.Rows[i].Cells["colShavingSet"].Value);

                oelTanneryDetail.PutthaPieces = 0;
                oelTanneryDetail.GalmaPieces = 0;
                oelTanneryDetail.WorkDate = Convert.ToDateTime(grdShaving.Rows[i].Cells["colShavingDate"].Value);
                oelTanneryDetail.Rate = 0;
                oelTanneryDetail.Amount = Validation.GetSafeLong(grdShaving.Rows[i].Cells["colShavingRates"].Value);

                oelShavingProcessesDetailCollection.Add(oelTanneryDetail);

            }
            if (IdShaving == Guid.Empty)
            {
                IdShaving = oelTanneryProcess.IdProcess;
                if (Manager.CreateProcessHead(oelTanneryHead, oelTanneryProcess, oelShavingProcessesDetailCollection).IsSuccess)
                {

                }
            }
            else if (Manager.UpdateProcessHead(oelTanneryHead, oelTanneryProcess, oelShavingProcessesDetailCollection).IsSuccess)
            {

            }
        }
        #endregion
        #region Lot Events
        private void btnSaveLot_Click(object sender, EventArgs e)
        {
            //var manager = new TanneryLotBLL();
            var manager = new TanneryChemicalBLL();
            TanneryLotEL oelLot = new TanneryLotEL();
            //List<TanneryLotDetailEL> listDetail = new List<TanneryLotDetailEL>();
            //List<TanneryProcessesEL> listProcesses = new List<TanneryProcessesEL>();
            List<TanneryChemicalEL> listChemicals = new List<TanneryChemicalEL>();
            #region Main Lot Process
            //if (IdLot != Guid.Empty)
            //{
            //    oelLot.IdLot = IdLot;
            //}
            //else
            //{
            //    oelLot.IdLot = Guid.NewGuid();
            //}
            //oelLot.IdVoucher = IdVoucher;
            //oelLot.LotNo = Validation.GetSafeLong(txtLotNo.Text);
            //oelLot.LotDate = DtLot.Value;
            //oelLot.IdQuality = IdQuality;
            //oelLot.VehicleNo = Validation.GetSafeString(txtVehicleNumber.Text);
            //oelLot.CloseDate = DateTime.Now;
            //#endregion
            //#region Drumming Process Entries
            //if (grdDrumming.Rows.Count > 1)
            //{
            //    oelLot.Status = "Open";
            //    TanneryProcessesEL oelTanneryDrummingProcess = new TanneryProcessesEL();
            //    if (IdTanneryDrumming == Guid.Empty)
            //    {
            //        oelTanneryDrummingProcess.IdProcess = Guid.NewGuid();
            //    }
            //    else
            //    {
            //        oelTanneryDrummingProcess.IdProcess = IdTanneryDrumming;
            //    }
            //    oelTanneryDrummingProcess.IdVoucher = IdVoucher;
            //    oelTanneryDrummingProcess.ProcessName = "Drumming";
            //    oelTanneryDrummingProcess.VDate = DateTime.Now;

            //    listProcesses.Add(oelTanneryDrummingProcess);

            //    for (int i = 0; i < grdDrumming.Rows.Count - 1; i++)
            //    {
            //        TanneryLotDetailEL lotDetail = new TanneryLotDetailEL();
            //        if (grdDrumming.Rows[i].Cells["colIdDrumming"].Value == null)
            //        {
            //            lotDetail.IdLotDetail = Guid.NewGuid();
            //            lotDetail.IsNew = true;
            //        }
            //        else
            //        {
            //            lotDetail.IdLotDetail = Validation.GetSafeGuid(grdDrumming.Rows[i].Cells["colIdDrumming"].Value);
            //        }
            //        lotDetail.IdLot = oelLot.IdLot;
            //        lotDetail.IdProcess = oelTanneryDrummingProcess.IdProcess;
            //        lotDetail.AccountNo = Validation.GetSafeString(grdDrumming.Rows[i].Cells["colDrummingAccountNo"].Value);
            //        lotDetail.WorkingDate = Validation.GetSafeDateTime(grdDrumming.Rows[i].Cells["colDrummingDate"].Value);
            //        if (Validation.GetSafeString(grdDrumming.Rows[i].Cells["colDrummingProcessType"].Value) == "Crust")
            //        {
            //            lotDetail.ProcessType = 0;
            //            oelLot.ProcessName = "Crust";
            //        }
            //        else if (Validation.GetSafeString(grdDrumming.Rows[i].Cells["colDrummingProcessType"].Value) == "Dying")
            //        {
            //            lotDetail.ProcessType = 1;
            //            oelLot.ProcessName = "Dying";
            //        }
            //        else if (Validation.GetSafeString(grdDrumming.Rows[i].Cells["colDrummingProcessType"].Value) == "Re Dying")
            //        {
            //            lotDetail.ProcessType = 2;
            //            oelLot.ProcessName = "Re Dying";
            //        }
            //        lotDetail.SeqNo = i;
            //        lotDetail.Uom = Validation.GetSafeString(grdDrumming.Rows[i].Cells["colDrummingPiecesType"].Value);
            //        lotDetail.Pieces = Validation.GetSafeInteger(grdDrumming.Rows[i].Cells["colDrummingPieces"].Value);
            //        lotDetail.GalmaPieces = 0;
            //        lotDetail.PutthaPieces = 0;
            //        lotDetail.DGalma = 0;
            //        lotDetail.Cutting = 0;
            //        lotDetail.CuttingStock = 0;
            //        lotDetail.Amount = Validation.GetSafeDecimal(grdDrumming.Rows[i].Cells["colDrummingAmount"].Value);

            //        listDetail.Add(lotDetail);
            //    }
            //}

            #endregion
            #region Buffing Process Entries
            //if (grdBuffing.Rows.Count > 1)
            //{
            //    oelLot.Status = "Open";
            //    TanneryProcessesEL oelTanneryBuffingProcess = new TanneryProcessesEL();
            //    if (IdTanneryBuffing == Guid.Empty)
            //    {
            //        oelTanneryBuffingProcess.IdProcess = Guid.NewGuid();
            //    }
            //    else
            //    {
            //        oelTanneryBuffingProcess.IdProcess = IdTanneryBuffing;
            //    }
            //    oelTanneryBuffingProcess.IdVoucher = IdVoucher;
            //    oelTanneryBuffingProcess.ProcessName = "Buffing";
            //    oelTanneryBuffingProcess.VDate = DateTime.Now;

            //    listProcesses.Add(oelTanneryBuffingProcess);

            //    for (int i = 0; i < grdBuffing.Rows.Count - 1; i++)
            //    {
            //        TanneryLotDetailEL BuffinglotDetail = new TanneryLotDetailEL();
            //        if (grdBuffing.Rows[i].Cells["colIdBuffing"].Value == null)
            //        {
            //            BuffinglotDetail.IdLotDetail = Guid.NewGuid();
            //            BuffinglotDetail.IsNew = true;
            //            grdBuffing.Rows[i].Cells["colIdBuffing"].Value = BuffinglotDetail.IdLotDetail;
            //        }
            //        else
            //        {
            //            BuffinglotDetail.IdLotDetail = Validation.GetSafeGuid(grdBuffing.Rows[i].Cells["colIdBuffing"].Value);
            //        }
            //        BuffinglotDetail.IdLot = oelLot.IdLot;
            //        BuffinglotDetail.IdProcess = oelTanneryBuffingProcess.IdProcess;
            //        BuffinglotDetail.AccountNo = Validation.GetSafeString(grdBuffing.Rows[i].Cells["colBuffingAccountNo"].Value);
            //        BuffinglotDetail.WorkingDate = Validation.GetSafeDateTime(grdBuffing.Rows[i].Cells["colBuffingDate"].Value);
            //        if (Validation.GetSafeString(grdBuffing.Rows[i].Cells["colBuffingProcessType"].Value) == "Buffing")
            //        {
            //            BuffinglotDetail.ProcessType = 3;
            //            oelLot.ProcessName = "Buffing";
            //        }
            //        else if (Validation.GetSafeString(grdBuffing.Rows[i].Cells["colBuffingProcessType"].Value) == "Re Buffing")
            //        {
            //            BuffinglotDetail.ProcessType = 4;
            //            oelLot.ProcessName = "Re Buffing";
            //        }
            //        BuffinglotDetail.SeqNo = i;
            //        BuffinglotDetail.Uom = "";
            //        BuffinglotDetail.Pieces = 0;
            //        BuffinglotDetail.GalmaPieces = Validation.GetSafeInteger(grdBuffing.Rows[i].Cells["colBuffingGalmaPieces"].Value);
            //        BuffinglotDetail.PutthaPieces = Validation.GetSafeInteger(grdBuffing.Rows[i].Cells["colBuffingPutthaPeices"].Value); ;
            //        BuffinglotDetail.DGalma = Validation.GetSafeInteger(grdBuffing.Rows[i].Cells["colBuffingDGalmaPieces"].Value);
            //        BuffinglotDetail.Cutting = 0;
            //        BuffinglotDetail.CuttingStock = 0;
            //        BuffinglotDetail.Amount = Validation.GetSafeDecimal(grdBuffing.Rows[i].Cells["colBuffingAmount"].Value);

            //        listDetail.Add(BuffinglotDetail);
            //    }
            //}
            #endregion
            #region Cutting Process Entries
            //if (grdCutting.Rows.Count > 1)
            //{
            //    oelLot.Status = "Open";
            //    oelLot.ProcessName = "Cutting";
            //    TanneryProcessesEL oelTanneryCuttingProcess = new TanneryProcessesEL();
            //    if (IdTanneryCutting == Guid.Empty)
            //    {
            //        oelTanneryCuttingProcess.IdProcess = Guid.NewGuid();
            //    }
            //    else
            //    {
            //        oelTanneryCuttingProcess.IdProcess = IdTanneryCutting;
            //    }
            //    oelTanneryCuttingProcess.IdVoucher = IdVoucher;
            //    oelTanneryCuttingProcess.ProcessName = "Cutting";
            //    oelTanneryCuttingProcess.VDate = DateTime.Now;

            //    listProcesses.Add(oelTanneryCuttingProcess);

            //    for (int i = 0; i < grdCutting.Rows.Count - 1; i++)
            //    {
            //        TanneryLotDetailEL CuttinglotDetail = new TanneryLotDetailEL();
            //        if (grdCutting.Rows[i].Cells["colIdCutting"].Value == null)
            //        {
            //            CuttinglotDetail.IdLotDetail = Guid.NewGuid();
            //            CuttinglotDetail.IsNew = true;
            //            grdCutting.Rows[i].Cells["colIdCutting"].Value = CuttinglotDetail.IdLotDetail;
            //        }
            //        else
            //        {
            //            CuttinglotDetail.IdLotDetail = Validation.GetSafeGuid(grdCutting.Rows[i].Cells["colIdCutting"].Value);
            //        }
            //        CuttinglotDetail.IdLot = oelLot.IdLot;
            //        CuttinglotDetail.IdProcess = oelTanneryCuttingProcess.IdProcess;
            //        CuttinglotDetail.AccountNo = Validation.GetSafeString(grdCutting.Rows[i].Cells["colCuttingAccountNo"].Value);
            //        CuttinglotDetail.WorkingDate = Validation.GetSafeDateTime(grdCutting.Rows[i].Cells["colCuttingDate"].Value);
            //        CuttinglotDetail.ProcessType = -1;
            //        CuttinglotDetail.Uom = Validation.GetSafeString(grdCutting.Rows[i].Cells["colCuttingUOM"].Value);
            //        CuttinglotDetail.SeqNo = i;
            //        CuttinglotDetail.Pieces = 0;
            //        CuttinglotDetail.GalmaPieces = 0;
            //        CuttinglotDetail.PutthaPieces = 0;
            //        CuttinglotDetail.DGalma = 0;
            //        CuttinglotDetail.IdQuality = Validation.GetSafeGuid(grdCutting.Rows[i].Cells["colCuttingIdQuality"].Value);
            //        CuttinglotDetail.Cutting = Validation.GetSafeInteger(grdCutting.Rows[i].Cells["colCuttingQty"].Value);
            //        CuttinglotDetail.CuttingStock = Validation.GetSafeInteger(grdCutting.Rows[i].Cells["colCuttingStock"].Value); ;
            //        CuttinglotDetail.Amount = Validation.GetSafeDecimal(grdCutting.Rows[i].Cells["colCuttingWages"].Value);

            //        listDetail.Add(CuttinglotDetail);
            //    }
            //}

            #endregion
            #region Chemical Entries
            for (int i = 0; i < grdChemicals.Rows.Count; i++)
            {
                TanneryChemicalEL oelTanneryChemicals = new TanneryChemicalEL();
                if (grdChemicals.Rows[i].Cells["colIdChemical"].Value == null || Validation.GetSafeGuid(grdChemicals.Rows[i].Cells["colIdChemical"].Value) == Guid.Empty)
                {
                    oelTanneryChemicals.IdChemical = Guid.NewGuid();
                    oelTanneryChemicals.IsNew = true;
                    grdChemicals.Rows[i].Cells["colIdChemical"].Value = oelTanneryChemicals.IdChemical;
                }
                else
                {
                    oelTanneryChemicals.IdChemical = Validation.GetSafeGuid(grdChemicals.Rows[i].Cells["colIdChemical"].Value);
                    oelTanneryChemicals.IsNew = false;
                }
                oelTanneryChemicals.IdLot = IdLot;
                oelTanneryChemicals.IdItem = Validation.GetSafeGuid(grdChemicals.Rows[i].Cells["colChemicalIdItem"].Value);
                oelTanneryChemicals.CrustIssuedQuantity = Validation.GetSafeInteger(grdChemicals.Rows[i].Cells["colChemicalCrustIssueQuantity"].Value);
                oelTanneryChemicals.CrustIssuedValue = Validation.GetSafeDecimal(grdChemicals.Rows[i].Cells["colChemicalCrustIssuedValue"].Value);
                oelTanneryChemicals.DyingIssuedQuantity = Validation.GetSafeInteger(grdChemicals.Rows[i].Cells["colChemicalDyingIssueQuantity"].Value);
                oelTanneryChemicals.DyingIssuedValue = Validation.GetSafeDecimal(grdChemicals.Rows[i].Cells["colChemicalDyingIssuedValue"].Value);
                oelTanneryChemicals.ReDyingIssuedQuantity = Validation.GetSafeDecimal(grdChemicals.Rows[i].Cells["colChemicalRedyingIssueQuantity"].Value);
                oelTanneryChemicals.ReDyingIssuedValue = Validation.GetSafeDecimal(grdChemicals.Rows[i].Cells["colChemicalRedyingIssuedValue"].Value);
                //oelTanneryChemicals.CurrentQuantity = Validation.GetSafeDecimal(grdChemicals.Rows[i].Cells["colChemicalQtyStock"].Value); //oelTanneryChemicals.CrustIssuedQuantity + oelTanneryChemicals.DyingIssuedQuantity + oelTanneryChemicals.ReDyingIssuedQuantity;   
                if (!grdChemicals.Rows[i].Cells["colChemicalCrustIssueQuantity"].ReadOnly && !grdChemicals.Rows[i].Cells["colChemicalDyingIssueQuantity"].ReadOnly && !grdChemicals.Rows[i].Cells["colChemicalRedyingIssuedValue"].ReadOnly)
                {
                    oelTanneryChemicals.CurrentQuantity = Validation.GetSafeDecimal(grdChemicals.Rows[i].Cells["colChemicalQtyStock"].Value) - (oelTanneryChemicals.CrustIssuedQuantity + oelTanneryChemicals.DyingIssuedQuantity + oelTanneryChemicals.ReDyingIssuedQuantity);
                }
                else if (grdChemicals.Rows[i].Cells["colChemicalCrustIssueQuantity"].ReadOnly && !grdChemicals.Rows[i].Cells["colChemicalDyingIssueQuantity"].ReadOnly && !grdChemicals.Rows[i].Cells["colChemicalRedyingIssuedValue"].ReadOnly)
                {
                    oelTanneryChemicals.CurrentQuantity = Validation.GetSafeDecimal(grdChemicals.Rows[i].Cells["colChemicalQtyStock"].Value) - (oelTanneryChemicals.DyingIssuedQuantity + oelTanneryChemicals.ReDyingIssuedQuantity);
                }
                else if (grdChemicals.Rows[i].Cells["colChemicalCrustIssueQuantity"].ReadOnly && grdChemicals.Rows[i].Cells["colChemicalDyingIssueQuantity"].ReadOnly && !grdChemicals.Rows[i].Cells["colChemicalRedyingIssuedValue"].ReadOnly)
                {
                    oelTanneryChemicals.CurrentQuantity = Validation.GetSafeDecimal(grdChemicals.Rows[i].Cells["colChemicalQtyStock"].Value) - (oelTanneryChemicals.ReDyingIssuedQuantity);
                }
                oelTanneryChemicals.CurrentValue = Validation.GetSafeDecimal(grdChemicals.Rows[i].Cells["colChemicalCurrentValue"].Value);

                listChemicals.Add(oelTanneryChemicals);
            }
            #endregion
            #region Saving Process
            if (IdLot == Guid.Empty)
            {
                IdLot = oelLot.IdLot;
                if (manager.CreateChemical(listChemicals))
                {
                    MessageBox.Show("Success");
                    FillLotChemicals(IdLot);
                }
            }
            else
            {
                if (manager.UpdateChemical(listChemicals))
                {
                    MessageBox.Show("Success");
                    FillLotChemicals(IdLot);
                }
            }
            #endregion
        }
        #endregion
        #region Chemical Grid Events
        private void grdChemicals_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal ResultantQty, ActualQty, ClosingStock = 0;
            var Manager = new TanneryChemicalBLL();
            if (e.ColumnIndex == 3)
            {
                if (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalQtyStock"].Value) > 0)
                {
                    ActualQty = Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalQtyStock"].Value);
                    ClosingStock = Manager.GetChemicalClosingStock(Validation.GetSafeGuid(grdChemicals.Rows[e.RowIndex].Cells["colChemicalIdItem"].Value));
                    if (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalCrustIssueQuantity"].Value) > ClosingStock)
                    {
                        MessageBox.Show("Sorry You Can Not Issue Chemicals for Crust more than Actual Quantity");
                        grdChemicals.Rows[e.RowIndex].Cells["colChemicalCrustIssueQuantity"].Value = Validation.GetSafeDecimal(0.00);
                        return;
                    }
                    else
                    {
                        ResultantQty = ActualQty - Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalCrustIssueQuantity"].Value);
                        //grdChemicals.Rows[e.RowIndex].Cells["colChemicalQtyStock"].Value = ResultantQty;

                    }
                    List<TanneryChemicalEL> list = Manager.GetItemAverageRate(Validation.GetSafeGuid(grdChemicals.Rows[e.RowIndex].Cells["colChemicalIdItem"].Value));
                    if (list.Count > 0)
                    {
                        if (Validation.GetSafeLong(grdChemicals.Rows[e.RowIndex].Cells["colChemicalCrustIssueQuantity"].Value) >= 0)
                        {
                            grdChemicals.Rows[e.RowIndex].Cells["colChemicalCrustIssuedValue"].Value = (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalCrustIssueQuantity"].Value) * list[0].Amount).ToString("0.00");
                        }
                    }
                }
                else
                {
                    if (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > 0)
                    {
                        MessageBox.Show("No Quantity To Issue....");
                        grdChemicals.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Validation.GetSafeDecimal(0.00);
                    }
                }
            }
            else if (e.ColumnIndex == 5)
            {
                if (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalQtyStock"].Value) > 0)
                {
                    ActualQty = Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalQtyStock"].Value);
                    ClosingStock = Manager.GetChemicalClosingStock(Validation.GetSafeGuid(grdChemicals.Rows[e.RowIndex].Cells["colChemicalIdItem"].Value));
                    if (!grdChemicals.Columns[0].ReadOnly)
                    {
                        if (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalDyingIssueQuantity"].Value) > (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalQtyStock"].Value) - Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalCrustIssueQuantity"].Value)))
                        {
                            MessageBox.Show("Sorry You Can Not Issue Chemicals for Dying more than Actual Quantity");
                            grdChemicals.Rows[e.RowIndex].Cells["colChemicalDyingIssueQuantity"].Value = Validation.GetSafeDecimal(0.00);
                            return;
                        }
                    }
                    else
                    {
                        if (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalDyingIssueQuantity"].Value) > ClosingStock)
                        {
                            MessageBox.Show("Sorry You Can Not Issue Chemicals for Dying more than Actual Quantity");
                            grdChemicals.Rows[e.RowIndex].Cells["colChemicalDyingIssueQuantity"].Value = Validation.GetSafeDecimal(0.00);
                            return;
                        }
                    }

                    List<TanneryChemicalEL> list = Manager.GetItemAverageRate(Validation.GetSafeGuid(grdChemicals.Rows[e.RowIndex].Cells["colChemicalIdItem"].Value));
                    if (list.Count > 0)
                    {
                        if (Validation.GetSafeLong(grdChemicals.Rows[e.RowIndex].Cells["colChemicalDyingIssueQuantity"].Value) >= 0)
                        {
                            grdChemicals.Rows[e.RowIndex].Cells["colChemicalDyingIssuedValue"].Value = (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalDyingIssueQuantity"].Value) * list[0].Amount).ToString("0.00");
                        }
                    }
                }
                else
                {
                    if (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > 0)
                    {
                        MessageBox.Show("No Quantity To Issue....");
                        grdChemicals.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Validation.GetSafeDecimal(0.00);
                    }
                }
            }
            else if (e.ColumnIndex == 7)
            {
                if (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalQtyStock"].Value) > 0)
                {
                    ActualQty = Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalQtyStock"].Value);
                    ClosingStock = Manager.GetChemicalClosingStock(Validation.GetSafeGuid(grdChemicals.Rows[e.RowIndex].Cells["colChemicalIdItem"].Value));
                    if (!grdChemicals.Columns[3].ReadOnly && !grdChemicals.Columns[5].ReadOnly)
                    {
                        if (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalRedyingIssueQuantity"].Value) > (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalQtyStock"].Value) - (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalCrustIssueQuantity"].Value) + Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalDyingIssueQuantity"].Value))))
                        {
                            MessageBox.Show("Sorry You Can Not Issue Chemicals for Redying more than Actual Quantity");
                            grdChemicals.Rows[e.RowIndex].Cells["colChemicalRedyingIssueQuantity"].Value = Validation.GetSafeDecimal(0.00);
                            return;
                        }
                    }
                    else
                    {
                        if (grdChemicals.Columns[3].ReadOnly && !grdChemicals.Columns[5].ReadOnly)
                        {
                            if (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalRedyingIssueQuantity"].Value) > (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalQtyStock"].Value) - (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalDyingIssueQuantity"].Value))))
                            {
                                MessageBox.Show("Sorry You Can Not Issue Chemicals for Redying more than Actual Quantity");
                                grdChemicals.Rows[e.RowIndex].Cells["colChemicalRedyingIssueQuantity"].Value = Validation.GetSafeDecimal(0.00);
                                return;
                            }
                        }
                        else if (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalRedyingIssueQuantity"].Value) > ClosingStock)
                        {
                            MessageBox.Show("Sorry You Can Not Issue Chemicals for Redying more than Actual Quantity");
                            grdChemicals.Rows[e.RowIndex].Cells["colChemicalRedyingIssueQuantity"].Value = Validation.GetSafeDecimal(0.00);
                            return;
                        }
                    }
                    List<TanneryChemicalEL> list = Manager.GetItemAverageRate(Validation.GetSafeGuid(grdChemicals.Rows[e.RowIndex].Cells["colChemicalIdItem"].Value));
                    if (list.Count > 0)
                    {
                        if (Validation.GetSafeLong(grdChemicals.Rows[e.RowIndex].Cells["colChemicalRedyingIssueQuantity"].Value) >= 0)
                        {
                            grdChemicals.Rows[e.RowIndex].Cells["colChemicalRedyingIssuedValue"].Value = (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells["colChemicalRedyingIssueQuantity"].Value) * list[0].Amount).ToString("0.00");
                        }
                    }
                }
                else
                {
                    if (Validation.GetSafeDecimal(grdChemicals.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > 0)
                    {
                        MessageBox.Show("No Quantity To Issue....");
                        grdChemicals.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Validation.GetSafeDecimal(0.00);
                    }
                }
            }
        }
        private void grdChemicals_MouseClick(object sender, MouseEventArgs e)
        {
            if (grdChemicals.Enabled == false)
            {
                MessageBox.Show("This Lot Is Closed, You can not issue Chemicals");
            }
        }
        #endregion
        #region Common Events
        void frmfindAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            if (EventFiringName == "Trimming")
            {
                if (oelAccount.AccountType == "Employees")
                {
                    grdTrimming.CurrentRow.Cells["colTrimmingAccountNo"].Value = oelAccount.AccountNo;
                    grdTrimming.CurrentRow.Cells["colTrimmingVendorName"].Value = oelAccount.AccountName;
                    grdTrimming.CurrentRow.Cells["colTrimmingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Splitting")
            {
                if (oelAccount.AccountType == "Employees")
                {
                    grdSplitting.CurrentRow.Cells["colSplittingAccountNo"].Value = oelAccount.AccountNo;
                    grdSplitting.CurrentRow.Cells["colSplittingVendorName"].Value = oelAccount.AccountName;
                    grdSplitting.CurrentRow.Cells["colSplittingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "ReTrimming")
            {
                if (oelAccount.AccountType == "Employees")
                {
                    grdRetrimming.CurrentRow.Cells["colRetrimmingAccountNo"].Value = oelAccount.AccountNo;
                    grdRetrimming.CurrentRow.Cells["colRetrimmingVendor"].Value = oelAccount.AccountName;
                    grdRetrimming.CurrentRow.Cells["colRetrimmingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Shaving")
            {
                if (oelAccount.AccountType == "Employees")
                {
                    grdShaving.CurrentRow.Cells["colShavingAccountNo"].Value = oelAccount.AccountNo;
                    grdShaving.CurrentRow.Cells["colShavingVendorName"].Value = oelAccount.AccountName;
                    grdShaving.CurrentRow.Cells["colShavingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Drumming")
            {
                if (oelAccount.AccountType == "Employees")
                {
                    grdDrumming.CurrentRow.Cells["colDrummingAccountNo"].Value = oelAccount.AccountNo;
                    grdDrumming.CurrentRow.Cells["colDrummingVendorName"].Value = oelAccount.AccountName;
                    grdDrumming.CurrentRow.Cells["colDrummingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Buffing")
            {
                if (oelAccount.AccountType == "Employees")
                {
                    grdBuffing.CurrentRow.Cells["colBuffingAccountNo"].Value = oelAccount.AccountNo;
                    grdBuffing.CurrentRow.Cells["colBuffingVendorName"].Value = oelAccount.AccountName;
                    grdBuffing.CurrentRow.Cells["colBuffingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }
            else if (EventFiringName == "Cutting")
            {
                if (oelAccount.AccountType == "Employees")
                {
                    grdCutting.CurrentRow.Cells["colCuttingAccountNo"].Value = oelAccount.AccountNo;
                    grdCutting.CurrentRow.Cells["colCuttingVendorName"].Value = oelAccount.AccountName;
                    grdCutting.CurrentRow.Cells["colCuttingAccountType"].Value = oelAccount.AccountType;
                }
                else
                {
                    MessageBox.Show("Please Select Employees Or Vendor");
                }
            }

        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            if (EventFiringName == "ShavingQuality")
            {
                grdShaving.CurrentRow.Cells["colShavingIdItem"].Value = oelItems.IdItem;
                grdShaving.CurrentRow.Cells["colShavingQuality"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "CuttingQuality")
            {
                grdCutting.CurrentRow.Cells["colCuttingIdQuality"].Value = oelItems.IdItem;
                grdCutting.CurrentRow.Cells["colCuttingQuality"].Value = oelItems.ItemName;
            }
            else if (EventFiringName == "TrimmingProduct")
            {
                grdTrimming.CurrentRow.Cells["colTrimmingIdItem"].Value = oelItems.IdItem;
                grdTrimming.CurrentRow.Cells["colTrimmingProduct"].Value = oelItems.ItemName;
            }
            else
            {
                txtQuality.Text = oelItems.ItemName;
                IdQuality = oelItems.IdItem;
            }
        }
        private void cbxVehicles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxVehicles.SelectedIndex > 0)
            {
                LoadType = "Vehicle";
                TanneryTab.SelectedIndex = 0;
                txtLotNo.Text = string.Empty;
                IdQuality = Guid.Empty;
                txtQuality.Text = string.Empty;
                cbxLotType.SelectedIndex = 0;
                txtLotWeight.Text = string.Empty;
                GetVoucherInfoByVehicleNo(cbxVehicles.Text);
                TanneryTab_SelectedIndexChanged(sender, e);
                FillVehicalDetail();
                FillVehicleClosingWeight();
            }
            else
            {
                ClearControls();
            }
        }
        private void cbxVehicles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillVehicalDetail();
            }
        }
        private void GetVoucherInfoByVehicleNo(string VehicleNo)
        {
            var Manager = new TanneryProcessesHeadBLL();
            List<TanneryProcessesHeadEL> list = Manager.GetVoucherInfoByVehicleNo(VehicleNo);
            if (list.Count > 0)
            {
                IdVoucher = list[0].IdVoucher;
                VEditBox.Text = list[0].VoucherNo.ToString();
            }
            else
            {
                IdVoucher = Guid.Empty;
            }
        }
        private void FillVehicalDetail()
        {
            var manager = new PurchaseHeadBLL();
            List<VoucherDetailEL> list = manager.GetVehicalDetail(cbxVehicles.Text, Operations.IdCompany);
            if (list.Count > 0)
            {
                txtSupplier.Text = list[0].AccountName;
                txtVehicalType.Text = list[0].VoucherType;
                txtVehicalDate.Text = list[0].CreatedDateTime.Value.ToShortDateString();
                txtVehicalWeight.Text = list[0].Weight.ToString("0.00");
                EnableDisableColumns(txtVehicalType.Text);
            }
            else
            {
                MessageBox.Show("No Vehical Found Against This Number");
            }
        }
        private void FillVehicleClosingWeight()
        {
            var manager = new TanneryProcessDetailsBLL();
            txtVehicleClosingWeight.Text = manager.GetVehicleClosingWeight(cbxVehicles.Text).ToString();
        }
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadType = "Voucher";
                TanneryTab.SelectedIndex = 0;
                GetVoucherInfoByVoucherNo();
            }
        }
        private void GetVoucherInfoByVoucherNo()
        {
            var Manager = new TanneryProcessesHeadBLL();
            List<TanneryProcessesHeadEL> list = Manager.GetVoucherInfoByVoucherNo(Validation.GetSafeLong(VEditBox.Text));
            if (list.Count > 0)
            {
                IdVoucher = list[0].IdVoucher;
                cbxVehicles.SelectedIndex = cbxVehicles.FindString(list[0].VehicleNo);
            }
            else
            {
                IdVoucher = Guid.Empty;
            }
        }
        private void EnableDisableColumns(string VehicleType)
        {
            // First Disable Trimming Grid Columns
            if (VehicleType == "Galma")
            {
                grdTrimming.Columns["colTrimmingPuttha"].ReadOnly = true;
                grdTrimming.Columns["colTrimmingGalma"].ReadOnly = false;
            }
            else if (VehicleType == "Puttha")
            {
                grdTrimming.Columns["colTrimmingGalma"].ReadOnly = true;
                grdTrimming.Columns["colTrimmingPuttha"].ReadOnly = false;
            }
            else
            {
                grdTrimming.Columns["colTrimmingGalma"].ReadOnly = false;
                grdTrimming.Columns["colTrimmingPuttha"].ReadOnly = false;
            }

            // First Disable ReTrimming Grid Columns
            if (VehicleType == "Galma")
            {
                grdRetrimming.Columns["colRetrimmingPuttha"].ReadOnly = true;
                grdRetrimming.Columns["colRetrimmingGalma"].ReadOnly = false;
            }
            else if (VehicleType == "Puttha")
            {
                grdRetrimming.Columns["colRetrimmingGalma"].ReadOnly = true;
                grdRetrimming.Columns["colRetrimmingPuttha"].ReadOnly = false;
            }
            else
            {
                grdRetrimming.Columns["colRetrimmingGalma"].ReadOnly = false;
                grdRetrimming.Columns["colRetrimmingPuttha"].ReadOnly = false;
            }

            // First Disable Shaving Grid Columns
            if (VehicleType == "Galma")
            {
                grdShaving.Columns["colShavingPuttha"].ReadOnly = true;
                grdShaving.Columns["colShavingSPuttha"].ReadOnly = true;

                grdShaving.Columns["colShavingGalma"].ReadOnly = false;
                grdShaving.Columns["colShavingSGalma"].ReadOnly = false;
            }
            else if (VehicleType == "Puttha")
            {
                grdShaving.Columns["colShavingGalma"].ReadOnly = true;
                grdShaving.Columns["colShavingSGalma"].ReadOnly = true;


                grdShaving.Columns["colShavingPuttha"].ReadOnly = false;
                grdShaving.Columns["colShavingSPuttha"].ReadOnly = false;
            }
            else
            {
                grdShaving.Columns["colShavingGalma"].ReadOnly = false;
                grdShaving.Columns["colShavingSGalma"].ReadOnly = false;


                grdShaving.Columns["colShavingPuttha"].ReadOnly = false;
                grdShaving.Columns["colShavingSPuttha"].ReadOnly = false;
            }
        }
        private void btnFinishVehicle_Click(object sender, EventArgs e)
        {
            var manager = new TanneryProcessesHeadBLL();
            if (manager.CompleteVehicle(IdVoucher).IsSuccess)
            {
                MessageBox.Show("Vehicle Is Completed");
            }
        }
        private void btnSaveCutting_Click(object sender, EventArgs e)
        {
            var manager = new TanneryProcessesHeadBLL();
            if (manager.CreateTanneryCuttingRate(Validation.GetSafeDecimal(txtCuttingRate.Text)).IsSuccess)
            {
                MessageBox.Show("Tannery Rate Saved Successfully.....");
            }
        }
        #endregion
        #region Methods
        private void GetTanneryPurchaseRates()
        {
            var manager = new TanneryProcessesHeadBLL();
            List<TanneryProcessesHeadEL> list = manager.GetCuttingPurchaseRate();
            if (list.Count > 0)
            {
                txtCuttingRate.Text = list[0].Amount.ToString();
            }
        }
        private bool ValidateRecords(int GridNumber)
        {
            bool Status = true;
            #region Misc Validations
            if (cbxVehicles.Text == string.Empty)
            {
                MessageBox.Show("Please Select Vehicle Number :");
                Status = false;
            }
            else if (VEditBox.Text == string.Empty)
            {
                MessageBox.Show("Production Number Is Empty :");
                Status = false;
            }
            #endregion
            #region Trimming Grid Validation
            else if (GridNumber == 1)
            {
                for (int i = 0; i < grdTrimming.Rows.Count - 1; i++)
                {
                    if (grdTrimming.Rows[i].Cells["colTrimmingVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdTrimming.Rows[i].Cells["colTrimmingAmount"].Value == null || Validation.GetSafeDecimal(grdTrimming.Rows[i].Cells["colTrimmingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                    else if (grdTrimming.Rows[i].Cells["colTrimmingProduct"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Trimming Product.....");
                        break;
                    }
                    else if (grdTrimming.Rows[i].Cells["colTrimmingIdItem"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Trimming Product.....");
                        break;
                    }
                }
            }
            #endregion
            #region Splitting Grid Validation
            else if (GridNumber == 2)
            {
                for (int i = 0; i < grdSplitting.Rows.Count - 1; i++)
                {
                    if (grdSplitting.Rows[i].Cells["colSplittingVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdSplitting.Rows[i].Cells["colSplittingAmount"].Value == null || Validation.GetSafeDecimal(grdSplitting.Rows[i].Cells["colSplittingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Retrimming Grid Validation
            else if (GridNumber == 3)
            {
                for (int i = 0; i < grdRetrimming.Rows.Count - 1; i++)
                {
                    if (grdRetrimming.Rows[i].Cells["colRetrimmingVendor"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdRetrimming.Rows[i].Cells["colRetrimmingAmount"].Value == null || Validation.GetSafeDecimal(grdRetrimming.Rows[i].Cells["colRetrimmingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Shaving Grid Validation
            else if (GridNumber == 4)
            {
                for (int i = 0; i < grdShaving.Rows.Count - 1; i++)
                {
                    if (grdShaving.Rows[i].Cells["colShavingVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (Validation.GetSafeDecimal(grdShaving.Rows[i].Cells["colShavingRates"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Drumming Grid Validation
            else if (GridNumber == 5)
            {
                for (int i = 0; i < grdDrumming.Rows.Count - 1; i++)
                {
                    if (grdDrumming.Rows[i].Cells["colDrummingVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdDrumming.Rows[i].Cells["colDrummingAmount"].Value == null || Validation.GetSafeDecimal(grdDrumming.Rows[i].Cells["colDrummingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Buffing Grid Validation
            else if (GridNumber == 6)
            {
                for (int i = 0; i < grdBuffing.Rows.Count - 1; i++)
                {
                    if (grdBuffing.Rows[i].Cells["colBuffingVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdBuffing.Rows[i].Cells["colBuffingAmount"].Value == null || Validation.GetSafeDecimal(grdBuffing.Rows[i].Cells["colBuffingAmount"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                }
            }
            #endregion
            #region Cutting Grid Validation
            else if (GridNumber == 7)
            {
                for (int i = 0; i < grdCutting.Rows.Count - 1; i++)
                {
                    if (grdCutting.Rows[i].Cells["colCuttingVendorName"].Value == null)
                    {
                        Status = false;
                        MessageBox.Show("Please Select Vendor.....");
                        break;
                    }
                    else if (grdCutting.Rows[i].Cells["colCuttingWages"].Value == null || Validation.GetSafeDecimal(grdCutting.Rows[i].Cells["colCuttingWages"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Amount Must Be Greater Than Zero.....");
                        break;
                    }
                    else if (grdCutting.Rows[i].Cells["colCuttingValue"].Value == null || Validation.GetSafeDecimal(grdCutting.Rows[i].Cells["colCuttingValue"].Value) == 0)
                    {
                        Status = false;
                        MessageBox.Show("Cutting Rate Value Must Be Given...");
                        break;
                    }
                }
                if (txtCuttingRate.Text == string.Empty || Validation.GetSafeDecimal(txtCuttingRate.Text) == 0)
                {
                    Status = false;
                    MessageBox.Show("Please Settle Cutting Rates .....");
                }
            }
            #endregion
            return Status;
        }
        private void ClearControls()
        {
            #region Clearing Variables
            IdVoucher = Guid.Empty;
            IdTrimming = Guid.Empty;
            IdSplitting = Guid.Empty;
            IdReTrimming = Guid.Empty;
            IdShaving = Guid.Empty;
            IdTanneryDrumming = Guid.Empty; ;
            IdTanneryBuffing = Guid.Empty;
            IdTanneryCutting = Guid.Empty;
            #endregion
            #region Clearing Grids
            grdTrimming.Rows.Clear();

            grdSplitting.Rows.Clear();

            grdRetrimming.Rows.Clear();

            grdShaving.Rows.Clear();

            grdDrumming.Rows.Clear();

            grdBuffing.Rows.Clear();

            grdCutting.Rows.Clear();

            grdLots.Rows.Clear();

            grdChemicals.DataSource = null;
            #endregion
        }
        private string BuildRemarks(string PurchasesType, string EmpAccountName, decimal ProcessAmount)
        {
            return PurchasesType + " from " + EmpAccountName + " At The Rate " + "@" + ProcessAmount;
        }
        #endregion
        #region Tab Related Methods And Events
        private void TanneryTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Manager = new TanneryProcessDetailsBLL();
            List<TanneryProcessDetailsEL> list = null;
            List<TanneryProcessesEL> listProcess = null;
            string ProcessName = "";
            #region Trimming Area
            if (TanneryTab.SelectedIndex == 0)
            {
                ProcessName = "Trimming";
                if (grdTrimming.Rows.Count > 0)
                {
                    grdTrimming.Rows.Clear();
                }
                if (LoadType == "Vehicle")
                {
                    list = Manager.GetProcessesDetailByVehicleAndProcess(Operations.IdCompany, ProcessName, cbxVehicles.Text);
                }
                else
                {
                    list = Manager.GetProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, VEditBox.Text);
                }
                if (list.Count > 0)
                {
                    VEditBox.Text = list[0].VoucherNo.ToString();
                    //if (grdTrimming.Rows.Count > 0)
                    //{
                    //    grdTrimming.Rows.Clear();
                    //}
                    IdTrimming = list[0].IdProcess;
                    FillProcessDetails(list, ProcessName);
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName, IdVoucher);
                    if (listProcess.Count > 0)
                    {
                        IdTrimming = listProcess[0].IdProcess;
                    }
                    else
                    {
                        IdTrimming = Guid.Empty;
                    }
                }
            }
            #endregion
            #region Splitting Area
            else if (TanneryTab.SelectedIndex == 1)
            {
                ProcessName = "Splitting";
                if (grdSplitting.Rows.Count > 0)
                {
                    grdSplitting.Rows.Clear();
                }
                if (LoadType == "Vehicle")
                {
                    list = Manager.GetProcessesDetailByVehicleAndProcess(Operations.IdCompany, ProcessName, cbxVehicles.Text);
                }
                else
                {
                    list = Manager.GetProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, VEditBox.Text);
                }
                if (list.Count > 0)
                {
                    VEditBox.Text = list[0].VoucherNo.ToString();
                    //if (grdSplitting.Rows.Count > 0)
                    //{
                    //    grdSplitting.Rows.Clear();
                    //}
                    IdSplitting = list[0].IdProcess;
                    FillProcessDetails(list, ProcessName);
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName, IdVoucher);
                    if (listProcess.Count > 0)
                    {
                        IdSplitting = listProcess[0].IdProcess;
                    }
                    else
                    {
                        IdSplitting = Guid.Empty;
                    }
                }
            }
            #endregion
            #region Retrimming Area
            else if (TanneryTab.SelectedIndex == 2)
            {
                ProcessName = "ReTrimming";
                if (grdRetrimming.Rows.Count > 0)
                {
                    grdRetrimming.Rows.Clear();
                }
                if (LoadType == "Vehicle")
                {
                    list = Manager.GetProcessesDetailByVehicleAndProcess(Operations.IdCompany, ProcessName, cbxVehicles.Text);
                }
                else
                {
                    list = Manager.GetProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, VEditBox.Text);
                }
                if (list.Count > 0)
                {
                    VEditBox.Text = list[0].VoucherNo.ToString();
                    //if (grdRetrimming.Rows.Count > 0)
                    //{
                    //    grdRetrimming.Rows.Clear();
                    //}
                    IdReTrimming = list[0].IdProcess;
                    FillProcessDetails(list, ProcessName);
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName, IdVoucher);
                    if (listProcess.Count > 0)
                    {
                        IdReTrimming = listProcess[0].IdProcess;
                    }
                    else
                    {
                        IdReTrimming = Guid.Empty;
                    }
                }
            }
            #endregion
            #region Shaving Area
            else if (TanneryTab.SelectedIndex == 3)
            {
                ProcessName = "Shaving";
                if (grdShaving.Rows.Count > 0)
                {
                    grdShaving.Rows.Clear();
                }
                if (LoadType == "Vehicle")
                {
                    list = Manager.GetProcessesDetailByVehicleAndProcess(Operations.IdCompany, ProcessName, cbxVehicles.Text);
                }
                else
                {
                    list = Manager.GetProcessesDetailByVoucherNoAndProcess(Operations.IdCompany, ProcessName, VEditBox.Text);
                }
                if (list.Count > 0)
                {
                    VEditBox.Text = list[0].VoucherNo.ToString();
                    //if (grdShaving.Rows.Count > 0)
                    //{
                    //    grdShaving.Rows.Clear();
                    //}
                    IdShaving = list[0].IdProcess;
                    FillProcessDetails(list, ProcessName);
                }
                else
                {
                    listProcess = Manager.GetProcessDetailByName(ProcessName, IdVoucher);
                    if (listProcess.Count > 0)
                    {
                        IdShaving = listProcess[0].IdProcess;
                    }
                    else
                    {
                        IdShaving = Guid.Empty;
                    }
                }

            }
            #endregion
            #region Lots Area
            else if (TanneryTab.SelectedIndex == 4)
            {
                var manager = new TanneryLotBLL();
                List<TanneryLotEL> lstLots = manager.GetLotsByProcessHead(IdVoucher);
                if (lstLots.Count > 0)
                {
                    grdLots.Rows.Clear();
                    //txtQuality.Text = string.Empty;
                    //IdQuality = Guid.Empty;
                    if (grdDrumming.Rows.Count > 0)
                    {
                        grdDrumming.Rows.Clear();
                    }
                    if (grdBuffing.Rows.Count > 0)
                    {
                        grdBuffing.Rows.Clear();
                    }
                    if (grdCutting.Rows.Count > 0)
                    {
                        grdCutting.Rows.Clear();
                    }
                    for (int i = 0; i < lstLots.Count; i++)
                    {
                        grdLots.Rows.Add();
                        grdLots.Rows[i].Cells["colIdLot"].Value = lstLots[i].IdLot;
                        grdLots.Rows[i].Cells["colLotNo"].Value = lstLots[i].LotNo;
                        grdLots.Rows[i].Cells["colLotProcess"].Value = lstLots[i].ProcessName;
                        grdLots.Rows[i].Cells["colLotStatus"].Value = lstLots[i].Status;

                        if (lstLots[i].Status == "Closed")
                        {
                            grdLots.Rows[i].Cells["colLotStatus"].Style.BackColor = Color.LightGray;
                            grdLots.Rows[i].Cells["colLotProcess"].Style.BackColor = Color.LightGray;
                            grdLots.Rows[i].Cells["colLotNo"].Style.BackColor = Color.LightGray;
                        }
                    }
                }
                else
                {
                    grdLots.Rows.Clear();
                    grdDrumming.Rows.Clear();
                    grdBuffing.Rows.Clear();
                    grdCutting.Rows.Clear();
                    grdChemicals.DataSource = null;
                }
            }
            #endregion
        }
        private void FillProcessDetails(List<TanneryProcessDetailsEL> list, string ProcessName)
        {
            IdVoucher = list[0].IdVoucher;
            for (int i = 0; i < list.Count; i++)
            {
                #region Trimming Area
                if (ProcessName == "Trimming")
                {
                    grdTrimming.Rows.Add();
                    grdTrimming.Rows[i].Cells[0].Value = list[i].IdProcessDetail;
                    grdTrimming.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdTrimming.Rows[i].Cells[2].Value = list[i].Posted;
                    grdTrimming.Rows[i].Cells[3].Value = list[i].IdPosting;
                    grdTrimming.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdTrimming.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdTrimming.Rows[i].Cells[6].Value = list[i].WorkDate;
                    grdTrimming.Rows[i].Cells[7].Value = list[i].AccountName;
                    grdTrimming.Rows[i].Cells[8].Value = list[i].ItemName;
                    grdTrimming.Rows[i].Cells[9].Value = list[i].Puttha;
                    grdTrimming.Rows[i].Cells[10].Value = list[i].Galma;
                    grdTrimming.Rows[i].Cells[11].Value = list[i].Rate;
                    grdTrimming.Rows[i].Cells[12].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdTrimming.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdTrimming.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdTrimming.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdTrimming.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdTrimming.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdTrimming.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdTrimming.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdTrimming.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdTrimming.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdTrimming.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdTrimming.Rows[i].Cells[13].ReadOnly = true;
                        grdTrimming.Rows[i].Cells[14].ReadOnly = true;
                        grdTrimming.Rows[i].ReadOnly = true;
                    }

                }
                #endregion
                #region Splitting Area
                else if (ProcessName == "Splitting")
                {
                    grdSplitting.Rows.Add();
                    grdSplitting.Rows[i].Cells[0].Value = list[i].IdProcessDetail;
                    grdSplitting.Rows[i].Cells[1].Value = list[i].Posted;
                    //grdSplitting.Rows[i].Cells[2].Value = list[i].PostingNo;
                    grdSplitting.Rows[i].Cells[2].Value = list[i].IdPosting;
                    grdSplitting.Rows[i].Cells[3].Value = list[i].AccountNo;
                    grdSplitting.Rows[i].Cells[4].Value = list[i].AccountType;
                    grdSplitting.Rows[i].Cells[5].Value = list[i].WorkDate;
                    grdSplitting.Rows[i].Cells[6].Value = list[i].AccountName;
                    grdSplitting.Rows[i].Cells[7].Value = list[i].PutthaPieces;
                    grdSplitting.Rows[i].Cells[8].Value = list[i].GalmaPieces;
                    grdSplitting.Rows[i].Cells[9].Value = list[i].Rate;
                    grdSplitting.Rows[i].Cells[10].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdSplitting.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdSplitting.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdSplitting.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdSplitting.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdSplitting.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdSplitting.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdSplitting.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdSplitting.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdSplitting.Rows[i].Cells[11].ReadOnly = true;
                        //grdSplitting.Rows[i].Cells[13].ReadOnly = true;
                        grdSplitting.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Retrimming Area
                else if (ProcessName == "ReTrimming")
                {
                    grdRetrimming.Rows.Add();
                    grdRetrimming.Rows[i].Cells[0].Value = list[i].IdProcessDetail;
                    grdRetrimming.Rows[i].Cells[1].Value = list[i].Posted;
                    grdRetrimming.Rows[i].Cells[2].Value = list[i].IdPosting;
                    grdRetrimming.Rows[i].Cells[3].Value = list[i].AccountNo;
                    grdRetrimming.Rows[i].Cells[4].Value = list[i].AccountType;
                    grdRetrimming.Rows[i].Cells[5].Value = list[i].WorkDate;
                    grdRetrimming.Rows[i].Cells[6].Value = list[i].AccountName;
                    grdRetrimming.Rows[i].Cells[7].Value = list[i].Puttha;
                    grdRetrimming.Rows[i].Cells[8].Value = list[i].Galma;
                    grdRetrimming.Rows[i].Cells[9].Value = list[i].GalmaPieces;
                    grdRetrimming.Rows[i].Cells[10].Value = list[i].Rate;
                    grdRetrimming.Rows[i].Cells[11].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdRetrimming.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                        grdRetrimming.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdRetrimming.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdRetrimming.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdRetrimming.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdRetrimming.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdRetrimming.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdRetrimming.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdRetrimming.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;

                        grdRetrimming.Rows[i].Cells[12].ReadOnly = true;
                        grdRetrimming.Rows[i].Cells[13].ReadOnly = true;
                        grdRetrimming.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
                #region Shaving Area
                else if (ProcessName == "Shaving")
                {
                    grdShaving.Rows.Add();
                    grdShaving.Rows[i].Cells[0].Value = list[i].IdProcessDetail;
                    grdShaving.Rows[i].Cells[1].Value = list[i].IdItem;
                    grdShaving.Rows[i].Cells[2].Value = list[i].Posted;
                    grdShaving.Rows[i].Cells[3].Value = list[i].IdPosting;
                    grdShaving.Rows[i].Cells[4].Value = list[i].AccountNo;
                    grdShaving.Rows[i].Cells[5].Value = list[i].AccountType;
                    grdShaving.Rows[i].Cells[6].Value = list[i].WorkDate;
                    grdShaving.Rows[i].Cells[7].Value = list[i].AccountName;
                    if (list[0].IdItem != Guid.Empty)
                    {
                        grdShaving.Rows[i].Cells[8].Value = list[i].ItemName; //new ItemsBLL().GetItemById(list[i].IdItem)[0].ItemName;
                    }
                    else
                    {
                        grdShaving.Rows[i].Cells[8].Value = "";
                    }
                    grdShaving.Rows[i].Cells[9].Value = list[i].Galma;
                    grdShaving.Rows[i].Cells[10].Value = list[i].Puttha;
                    grdShaving.Rows[i].Cells[11].Value = list[i].SGalma;
                    grdShaving.Rows[i].Cells[12].Value = list[i].SPuttha;
                    grdShaving.Rows[i].Cells[13].Value = list[i].DGalma;
                    grdShaving.Rows[i].Cells[14].Value = list[i].DPuttha;
                    grdShaving.Rows[i].Cells[15].Value = list[i].SSet;
                    grdShaving.Rows[i].Cells[16].Value = list[i].Amount;


                    if (list[i].Posted)
                    {
                        grdShaving.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                        grdShaving.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        grdShaving.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                        grdShaving.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                        grdShaving.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                        grdShaving.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                        grdShaving.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                        grdShaving.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                        grdShaving.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        grdShaving.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                        grdShaving.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;
                        grdShaving.Rows[i].Cells[15].Style.BackColor = Color.LightGreen;
                        grdShaving.Rows[i].Cells[16].Style.BackColor = Color.LightGreen;
                        grdShaving.Rows[i].Cells[17].ReadOnly = true;
                        grdShaving.Rows[i].Cells[18].ReadOnly = true;
                        grdShaving.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
            }
        }
        #endregion
        //private void FillLotsDetail()
        //{
        //    for (int i = 0; i < grdLots.Rows.Count - 1; i++)
        //    {
        //        if (Validation.GetSafeGuid(grdLots.Rows[i].Cells["colIdLot"].Value) == Guid.Empty)
        //        {
        //            MessageBox.Show("A lot Is Already Generated,Please Save the Lot First Then Generate Next Lot");
        //            return;
        //        }
        //    }
        //    grdLots.Rows.Add();
        //    grdLots.Rows[grdLots.Rows.Count - 2].Cells["colIdLot"].Value = Guid.Empty;
        //    grdLots.Rows[grdLots.Rows.Count - 2].Cells["colLotNo"].Value = txtLotNo.Text;
        //    grdLots.Rows[grdLots.Rows.Count - 2].Cells["colLotProcess"].Value = "New";
        //    grdLots.Rows[grdLots.Rows.Count - 2].Cells["colLotStatus"].Value = "Open";

        //}
        #region Lot Related Methods And Events
        private void FillLotDetails(Int64 LotNo, string LoadType)
        {
            var manager = new TanneryLotDetailBLL();
            var LManager = new TanneryLotBLL();
            var TManager = new TanneryProcessDetailsBLL();
            List<TanneryLotDetailEL> list = manager.GetLotDetailByLotNoWithProcessHead(IdVoucher, LotNo);
            List<TanneryProcessesEL> listProcess = null;
            if (list.Count > 0)
            {
                IdQuality = list[0].IdQuality;
                txtQuality.Text = list[0].QualityName;
                txtLotWeight.Text = list[0].LotWeight.ToString();
                cbxLotType.SelectedIndex = list[0].LotType;
                if (LoadType == "Drumming")
                {
                    List<TanneryLotDetailEL> lstDrumming = list.FindAll(x => x.ProcessName == "Drumming");
                    if (lstDrumming != null && lstDrumming.Count > 0)
                    {
                        IdTanneryDrumming = lstDrumming[0].IdProcess;
                        FillProcessesGrid(lstDrumming, 1);
                    }
                    else
                    {
                        grdDrumming.Rows.Clear();
                        listProcess = TManager.GetProcessDetailByName("Drumming", IdVoucher);
                        if (listProcess.Count > 0)
                        {
                            IdTanneryDrumming = listProcess[0].IdProcess;
                        }
                        else 
                        {
                            IdTanneryDrumming = Guid.Empty;
                        }
                    }
                }
                else if (LoadType == "Buffing")
                {
                    List<TanneryLotDetailEL> lstBuffing = list.FindAll(x => x.ProcessName == "Buffing");
                    if (lstBuffing != null && lstBuffing.Count > 0)
                    {
                        IdTanneryBuffing = lstBuffing[0].IdProcess;
                        FillProcessesGrid(lstBuffing, 2);
                    }
                    else
                    {
                        grdBuffing.Rows.Clear();
                        listProcess = TManager.GetProcessDetailByName("Buffing", IdVoucher);
                        if (listProcess.Count > 0)
                        {
                            IdTanneryBuffing = listProcess[0].IdProcess;
                        }
                        else
                        {
                            IdTanneryBuffing = Guid.Empty;
                        }
                    }
                }
                else if (LoadType == "Cutting")
                {
                    List<TanneryLotDetailEL> lstCutting = list.FindAll(x => x.ProcessName == "Cutting");
                    if (lstCutting != null && lstCutting.Count > 0)
                    {
                        IdTanneryCutting = lstCutting[0].IdProcess;
                        FillProcessesGrid(lstCutting, 3);
                    }
                    else
                    {
                        grdCutting.Rows.Clear();
                        listProcess = TManager.GetProcessDetailByName("Cutting", IdVoucher);
                        if (listProcess.Count > 0)
                        {
                            IdTanneryCutting = listProcess[0].IdProcess;
                        }
                        else
                        {
                            IdTanneryCutting = Guid.Empty;
                        }
                    }
                }
                else if (LoadType == "All")
                {
                    List<TanneryLotDetailEL> lstDrumming = list.FindAll(x => x.ProcessName == "Drumming");
                    if (lstDrumming != null && lstDrumming.Count > 0)
                    {
                        IdTanneryDrumming = lstDrumming[0].IdProcess;
                        FillProcessesGrid(lstDrumming, 1);
                    }
                    else
                    {
                        listProcess = TManager.GetProcessDetailByName("Drumming", IdVoucher);
                        if (grdDrumming.Rows.Count > 0)
                        {
                            grdDrumming.Rows.Clear();
                        }
                        if (listProcess.Count > 0)
                        {
                            IdTanneryDrumming = listProcess[0].IdProcess;
                        }
                        else
                        {
                            IdTanneryDrumming = Guid.Empty;
                        }
                    }
                    List<TanneryLotDetailEL> lstBuffing = list.FindAll(x => x.ProcessName == "Buffing");
                    if (lstBuffing != null && lstBuffing.Count > 0)
                    {
                        IdTanneryBuffing = lstBuffing[0].IdProcess;
                        FillProcessesGrid(lstBuffing, 2);
                    }
                    else
                    {
                        listProcess = TManager.GetProcessDetailByName("Buffing", IdVoucher);
                        if (grdBuffing.Rows.Count > 0)
                        {
                            grdBuffing.Rows.Clear();
                        }
                        if (listProcess.Count > 0)
                        {
                            IdTanneryBuffing = listProcess[0].IdProcess;
                        }
                        else
                        {
                            IdTanneryBuffing = Guid.Empty;
                        }
                    }
                    List<TanneryLotDetailEL> lstCutting = list.FindAll(x => x.ProcessName == "Cutting");
                    if (lstCutting != null && lstCutting.Count > 0)
                    {
                        IdTanneryCutting = lstCutting[0].IdProcess;
                        FillProcessesGrid(lstCutting, 3);
                    }
                    else
                    {
                        listProcess = TManager.GetProcessDetailByName("Cutting", IdVoucher);
                        if (grdCutting.Rows.Count > 0)
                        {
                            grdCutting.Rows.Clear();
                        }
                        if (listProcess.Count > 0)
                        {
                            IdTanneryCutting = listProcess[0].IdProcess;
                        }
                        else
                        {
                            IdTanneryCutting = Guid.Empty;
                        }
                    }
                    if (LManager.GetLotById(IdLot)[0].Status == "Closed")
                    {
                        MessageBox.Show("You Can Not Work on this lot because this is Closed");
                        EnableDisableControls(false);
                    }
                    else
                    {
                        EnableDisableControls(true);
                    }
                }
            }
            else if (IdVoucher != Guid.Empty)
            {
                List<TanneryLotEL> Llist = LManager.GetLotById(IdLot);
                if (Llist[0].Status == "Closed")
                {
                    MessageBox.Show("You Can Not Work on this lot because this is Closed");
                    EnableDisableControls(false);
                }
                else
                {
                    EnableDisableControls(true);
                    IdQuality = Validation.GetSafeGuid(Llist[0].IdQuality);
                    txtQuality.Text = Validation.GetSafeString(Llist[0].QualityName);
                }
                grdDrumming.Rows.Clear();
                grdBuffing.Rows.Clear();
                grdCutting.Rows.Clear();
                //EnableDisableControls(true);
            }
            else
            {
                EnableDisableControls(false);
            }

            RunMiscProcessesQueue();
        }
        private void RunMiscProcessesQueue()
        {
            var TManager = new TanneryProcessDetailsBLL();
            List<TanneryProcessesEL> listProcess = null;
            #region Misc Processes
            if (IdTanneryDrumming == Guid.Empty)
            {
                listProcess = TManager.GetProcessDetailByName("Drumming", IdVoucher);
                if (listProcess.Count > 0)
                {
                    IdTanneryDrumming = listProcess[0].IdProcess;
                }
                else
                {
                    IdTanneryDrumming = Guid.Empty;
                }
            }
            if (IdTanneryBuffing == Guid.Empty)
            {
                listProcess = TManager.GetProcessDetailByName("Buffing", IdVoucher);
                if (listProcess.Count > 0)
                {
                    IdTanneryBuffing = listProcess[0].IdProcess;
                }
                else
                {
                    IdTanneryBuffing = Guid.Empty;
                }
            }
            if (IdTanneryCutting == Guid.Empty)
            {
                listProcess = TManager.GetProcessDetailByName("Cutting", IdVoucher);
                if (listProcess.Count > 0)
                {
                    IdTanneryCutting = listProcess[0].IdProcess;
                }
                else
                {
                    IdTanneryCutting = Guid.Empty;
                }
            }
            #endregion
        }
        private void FillProcessesGrid(List<TanneryLotDetailEL> list, int GridNumber)
        {
            if (GridNumber == 1)
            {
                //Fill Drumming Grid
                #region Drumming Grid Filling
                grdDrumming.Rows.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    grdDrumming.Rows.Add();
                    grdDrumming.Rows[i].Cells["colIdDrumming"].Value = list[i].IdLotDetail;
                    grdDrumming.Rows[i].Cells["colIsDrummingPosting"].Value = list[i].Posted;
                    grdDrumming.Rows[i].Cells["colDrummingVoucherNo"].Value = list[i].IdPosting;
                    grdDrumming.Rows[i].Cells["colDrummingAccountNo"].Value = list[i].AccountNo;
                    grdDrumming.Rows[i].Cells["colDrummingAccountType"].Value = list[i].AccountType;
                    grdDrumming.Rows[i].Cells["colDrummingDate"].Value = list[i].WorkingDate.Value;
                    grdDrumming.Rows[i].Cells["colDrummingVendorName"].Value = list[i].AccountName;
                    grdDrumming.Rows[i].Cells["colDrummingWeight"].Value = list[i].Weight;
                    if (list[i].ProcessType == 0)
                    {
                        grdDrumming.Rows[i].Cells["colDrummingProcessType"].Value = "Crust";
                    }
                    else if (list[i].ProcessType == 1)
                    {
                        grdDrumming.Rows[i].Cells["colDrummingProcessType"].Value = "Dying";
                    }
                    else if (list[i].ProcessType == 2)
                    {
                        grdDrumming.Rows[i].Cells["colDrummingProcessType"].Value = "Re Dying";
                    }

                    //grdDrumming.Rows[i].Cells["colDrummingProcessType"].Value = list[i].ProcessType;

                    grdDrumming.Rows[i].Cells["colDrummingPiecesType"].Value = list[i].Uom;
                    grdDrumming.Rows[i].Cells["colDrummingPieces"].Value = list[i].Pieces;
                    grdDrumming.Rows[i].Cells["colDrummingAmount"].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdDrumming.Rows[i].Cells["colDrummingDate"].Style.BackColor = Color.LightGreen;
                        grdDrumming.Rows[i].Cells["colDrummingVendorName"].Style.BackColor = Color.LightGreen;
                        grdDrumming.Rows[i].Cells["colDrummingWeight"].Style.BackColor = Color.LightGreen;
                        grdDrumming.Rows[i].Cells["colDrummingProcessType"].Style.ForeColor = Color.LightGreen;
                        grdDrumming.Rows[i].Cells["colDrummingPiecesType"].Style.ForeColor = Color.LightGreen;
                        grdDrumming.Rows[i].Cells["colDrummingPieces"].Style.BackColor = Color.LightGreen;
                        grdDrumming.Rows[i].Cells["colDrummingAmount"].Style.BackColor = Color.LightGreen;

                        grdDrumming.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
            }
            else if (GridNumber == 2)
            {
                // Fill Buffing Grid
                #region Buffing Grid Filling
                grdBuffing.Rows.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    grdBuffing.Rows.Add();
                    grdBuffing.Rows[i].Cells["colIdBuffing"].Value = list[i].IdLotDetail;
                    grdBuffing.Rows[i].Cells["colIsBuffingPosting"].Value = list[i].Posted;
                    grdBuffing.Rows[i].Cells["colBuffingVoucherNo"].Value = list[i].IdPosting;
                    grdBuffing.Rows[i].Cells["colBuffingAccountNo"].Value = list[i].AccountNo;
                    grdBuffing.Rows[i].Cells["colBuffingAccountType"].Value = list[i].AccountType;
                    grdBuffing.Rows[i].Cells["colBuffingDate"].Value = list[i].WorkingDate.Value;
                    grdBuffing.Rows[i].Cells["colBuffingVendorName"].Value = list[i].AccountName;
                    if (list[i].ProcessType == 3)
                    {
                        grdBuffing.Rows[i].Cells["colBuffingProcessType"].Value = "Buffing";
                    }
                    else
                    {
                        grdBuffing.Rows[i].Cells["colBuffingProcessType"].Value = "Re Buffing";
                    }
                    //grdBuffing.Rows[i].Cells["colBuffingProcessType"].Value = list[i].ProcessType;
                    grdBuffing.Rows[i].Cells["colBuffingPiecesType"].Value = list[i].Uom;
                    grdBuffing.Rows[i].Cells["colBuffingPieces"].Value = list[i].Pieces;

                    //grdBuffing.Rows[i].Cells["colBuffingGalmaPieces"].Value = list[i].GalmaPieces;

                    //grdBuffing.Rows[i].Cells["colBuffingPutthaPeices"].Value = list[i].PutthaPieces;

                    grdBuffing.Rows[i].Cells["colBuffingDGalmaPieces"].Value = list[i].DGalma;
                    grdBuffing.Rows[i].Cells["colBuffingAmount"].Value = list[i].Amount;

                    if (list[i].Posted)
                    {
                        grdBuffing.Rows[i].Cells["colBuffingDate"].Style.BackColor = Color.LightGreen;
                        grdBuffing.Rows[i].Cells["colBuffingVendorName"].Style.BackColor = Color.LightGreen;
                        grdBuffing.Rows[i].Cells["colBuffingProcessType"].Style.BackColor = Color.LightGreen;
                        grdBuffing.Rows[i].Cells["colBuffingPiecesType"].Style.BackColor = Color.LightGreen;
                        grdBuffing.Rows[i].Cells["colBuffingPieces"].Style.BackColor = Color.LightGreen;
                        //grdBuffing.Rows[i].Cells["colBuffingGalmaPieces"].Style.BackColor = Color.LightGreen;

                        //grdBuffing.Rows[i].Cells["colBuffingPutthaPeices"].Style.BackColor = Color.LightGreen;

                        grdBuffing.Rows[i].Cells["colBuffingDGalmaPieces"].Style.BackColor = Color.LightGreen;
                        grdBuffing.Rows[i].Cells["colBuffingAmount"].Style.BackColor = Color.LightGreen;

                        grdBuffing.Rows[i].ReadOnly = true;
                    }
                }
                #endregion
            }
            else if (GridNumber == 3)
            {
                // Fill Cutting Grid
                #region Cutting Grid Filling
                grdCutting.Rows.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    grdCutting.Rows.Add();
                    grdCutting.Rows[i].Cells["colIdCutting"].Value = list[i].IdLotDetail;
                    grdCutting.Rows[i].Cells["colIsCuttingPosting"].Value = list[i].Posted;
                    grdCutting.Rows[i].Cells["colCuttingVoucherNo"].Value = list[i].IdPosting;
                    grdCutting.Rows[i].Cells["colCuttingIdQuality"].Value = list[i].IdAccount;
                    grdCutting.Rows[i].Cells["colCuttingValue"].Value = list[i].CuttingRateValue;
                    grdCutting.Rows[i].Cells["colCuttingAccountNo"].Value = list[i].AccountNo;
                    grdCutting.Rows[i].Cells["colCuttingAccountType"].Value = list[i].AccountType;
                    grdCutting.Rows[i].Cells["colCuttingDate"].Value = list[i].WorkingDate.Value;
                    grdCutting.Rows[i].Cells["colCuttingVendorName"].Value = list[i].AccountName;
                    grdCutting.Rows[i].Cells["colCuttingQuality"].Value = list[i].ItemName;
                    grdCutting.Rows[i].Cells["colCuttingQty"].Value = list[i].Cutting;
                    grdCutting.Rows[i].Cells["colCuttingValue"].Value = list[i].CuttingRateValue;
                    grdCutting.Rows[i].Cells["colCuttingUOM"].Value = list[i].Uom;

                    grdCutting.Rows[i].Cells["colCuttingWages"].Value = list[i].Amount;
                    grdCutting.Rows[i].Cells["colCuttingStock"].Value = list[i].CuttingStock;

                    if (list[i].Posted)
                    {
                        grdCutting.Rows[i].Cells["colCuttingDate"].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells["colCuttingVendorName"].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells["colCuttingQuality"].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells["colCuttingQty"].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells["colCuttingUOM"].Style.BackColor = Color.LightGreen;

                        grdCutting.Rows[i].Cells["colCuttingWages"].Style.BackColor = Color.LightGreen;
                        grdCutting.Rows[i].Cells["colCuttingStock"].Style.BackColor = Color.LightGreen;

                        grdCutting.Rows[i].ReadOnly = true;
                    }

                }
                #endregion

            }
        }
        private void FillLotChemicals(Guid IdLot)
        {
            var manager = new TanneryChemicalBLL();
            List<TanneryChemicalEL> list = manager.GetChemicalDetailsByLot(IdLot);
            if (list.Count > 0)
            {
                grdChemicals.DataSource = list;
                if (list.Find(x => x.CrustIssuedQuantity > 0) != null)
                {
                    grdChemicals.Columns[3].ReadOnly = true;
                    grdChemicals.Columns[4].ReadOnly = true;
                }
                else
                {
                    grdChemicals.Columns[3].ReadOnly = false;
                    grdChemicals.Columns[4].ReadOnly = false;
                }
                if (list.Find(x => x.DyingIssuedQuantity > 0) != null)
                {
                    grdChemicals.Columns[5].ReadOnly = true;
                    grdChemicals.Columns[6].ReadOnly = true;
                }
                else
                {
                    grdChemicals.Columns[5].ReadOnly = false;
                    grdChemicals.Columns[6].ReadOnly = false;
                }
                if (list.Find(x => x.ReDyingIssuedQuantity > 0) != null)
                {
                    grdChemicals.Columns[7].ReadOnly = true;
                    grdChemicals.Columns[8].ReadOnly = true;
                }
                else
                {
                    grdChemicals.Columns[7].ReadOnly = false;
                    grdChemicals.Columns[8].ReadOnly = false;
                }

            }
        }
        private void txtQuality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
            {
                EventFiringName = "";
                frmstockAccounts = new frmStockAccounts();
                frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                frmstockAccounts.SearchText = e.KeyChar.ToString();
                frmstockAccounts.ShowDialog(this);
                e.Handled = true;
                //SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                grdDrumming.Focus();
            }
            else
                e.Handled = true;

        }
        private void txtQuality_ButtonClick(object sender, EventArgs e)
        {
            EventFiringName = "";
            frmstockAccounts = new frmStockAccounts();
            frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
            frmstockAccounts.ShowDialog(this);
        }
        private void btnDrummingGenerateLot_Click(object sender, EventArgs e)
        {
            if (IdVoucher != Guid.Empty)
            {
                var manager = new TanneryLotBLL();
                TanneryLotEL oelLot = new TanneryLotEL();
                oelLot.IdLot = Guid.NewGuid();
                IdLot = oelLot.IdLot;
                oelLot.IdVoucher = IdVoucher;
                oelLot.IdUser = Operations.UserID;
                oelLot.LotNo = manager.GetMaxLotNo(IdVoucher);
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
                oelLot.LotWeight = Validation.GetSafeDecimal(txtLotWeight.Text);
                oelLot.Status = "Open/New";
                oelLot.ProcessName = "Nothing";
                oelLot.VehicleNo = Validation.GetSafeString(cbxVehicles.Text);
                oelLot.CloseDate = DateTime.Now;
                if (manager.CreateLot(oelLot))
                {
                    txtLotNo.Text = oelLot.LotNo.ToString();
                    TanneryTab.SelectedIndex = 4;
                    TanneryTab_SelectedIndexChanged(sender, e);
                    FillLotDetails(oelLot.LotNo, "All");
                    EnableDisableControls(true);
                    grdDrumming.Rows.Clear();
                    grdBuffing.Rows.Clear();
                    grdCutting.Rows.Clear();
                    RunMiscProcessesQueue();
                }
                //FillLotsDetail();
                FillLotChemicals(IdLot);
            }
            else
            {
                MessageBox.Show("Please First Fill Other Entries");
            }
        }
        private void btnCloseLot_Click(object sender, EventArgs e)
        {
            if (IdLot != Guid.Empty)
            {
                var manager = new TanneryLotBLL();
                if (btnCloseLot.Text == "Close Lot")
                {
                    lblDate.Visible = true;
                    dtLotClose.Visible = true;
                    btnCloseLot.Text = "Now Close";
                }
                else
                {
                    TanneryLotEL oelLot = new TanneryLotEL();

                    oelLot.IdLot = IdLot;
                    oelLot.CloseDate = dtLotClose.Value;
                    oelLot.Amount = 0;

                    if (manager.CloseLot(oelLot))
                    {
                        lblDate.Visible = false;
                        dtLotClose.Visible = false;
                        btnCloseLot.Text = "Close Lot";

                        EnableDisableControls(false);

                        grdLots.CurrentRow.Cells["colLotStatus"].Value = "Closed";
                        grdLots.CurrentRow.Cells["colLotStatus"].Style.BackColor = Color.LightGray;
                        grdLots.CurrentRow.Cells["colLotProcess"].Style.BackColor = Color.LightGray;
                        grdLots.CurrentRow.Cells["colLotNo"].Style.BackColor = Color.LightGray;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Lot First to Close");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}



