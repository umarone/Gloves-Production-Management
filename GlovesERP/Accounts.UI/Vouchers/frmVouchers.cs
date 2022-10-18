using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounts.BLL;
using Accounts.Common;
using Accounts.EL;
using MetroFramework.Controls;

namespace Accounts.UI
{
    public partial class frmVouchers : MetroFramework.Forms.MetroForm
    {
        #region Variable
        frmFindAccounts frmAccount;
        frmFindVouchers frmfindVoucher;
        public decimal OldValue { get; set; }
        public Guid IdVoucher = Guid.Empty;
        public Guid CashTransactionId { get; set; }
        bool IsNewVoucher;
        public string VoucherType { get; set; }
        TextBox txtDebit = new TextBox();
        TextBox txtCredit = new TextBox();
        string Command = "";
        frmPrintVouchers frmprintVouchers = null;
        #endregion
        #region Form Methods And Events
        public frmVouchers()
        {
            InitializeComponent();
        }
        private void frmCashVoucher_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            if (VoucherType == VoucherTypes.PaymentVoucher.ToString())
            {
                this.Text = "Cash Payment Voucher";
                btnPrint.Visible = true;
                pnlAdjustmentTypes.Visible = true;
            }
            else if (VoucherType == VoucherTypes.CashReceiptVoucher.ToString())
            {
                this.Text = "Cash Receipt Voucher";
                pnlAdjustmentTypes.Visible = true;
            }
            else if (VoucherType == VoucherTypes.BankPaymentVoucher.ToString())
            {
                this.Text = "Bank Payment Voucher";
                btnPrint.Visible = true;
                ShowControls();
            }
            else if (VoucherType == VoucherTypes.BankReceiptVoucher.ToString())
            {
                this.Text = "Bank Receipt Voucher";
                ShowControls();
            }
            FillData();
            CreateAndInitializeFooterRow();
            CheckModulePermissions();
            BuildAdjustmentCollection();
        }
        #endregion
        #region Simple Methods
        private void BuildAdjustmentCollection()
        {
            if (VoucherType == VoucherTypes.PaymentVoucher.ToString())
            {
                cbxAdjustments.Items.Add("");
                cbxAdjustments.Items.Add("Payment To Supplier Against Purchases");
                cbxAdjustments.Items.Add("Advances to Suppliers For Booking Stock");
                cbxAdjustments.Items.Add("Payment Against Company Expenses");
                cbxAdjustments.Items.Add("Payment To Employees Against Work");
                cbxAdjustments.Items.Add("Others");
            }
            else if (VoucherType == VoucherTypes.CashReceiptVoucher.ToString())
            {
                cbxAdjustments.Items.Add("");
                cbxAdjustments.Items.Add("Cash Receipt from Customers");
                cbxAdjustments.Items.Add("Advances Receipt from Customers");
                cbxAdjustments.Items.Add("Others");
            }
        }
        private void CreateAndInitializeFooterRow()
        {
            txtDebit.Enabled = false;
            txtDebit.TextAlign = HorizontalAlignment.Left;
            txtDebit.Font = new System.Drawing.Font("Arial", 9, FontStyle.Bold);

            int hostCellLocation = DgvVoucher.GetCellDisplayRectangle(9, -1, true).X;

            txtDebit.Width = DgvVoucher.Columns[9].Width; //+SystemInformation.VerticalScrollBarWidth;
            txtDebit.Location = new Point(hostCellLocation, DgvVoucher.Height - txtDebit.Height);

            DgvVoucher.Controls.Add(txtDebit);

            txtDebit.BringToFront();

            txtCredit.Enabled = false;
            txtCredit.TextAlign = HorizontalAlignment.Left;
            txtCredit.Font = new System.Drawing.Font("Arial", 9, FontStyle.Bold);

            int hostCreditCellLocation = DgvVoucher.GetCellDisplayRectangle(10, -1, true).X;
            txtCredit.Width = DgvVoucher.Columns[10].Width; //+SystemInformation.VerticalScrollBarWidth;
            txtCredit.Location = new Point(hostCreditCellLocation, DgvVoucher.Height - txtCredit.Height);

            DgvVoucher.Controls.Add(txtCredit);

            txtCredit.BringToFront();
        }
        private void CheckModulePermissions()
        {
            List<UserModulesPermissionsEL> PermissionsList = UserPermissions.GetUserModulePermissionsByUserAndModuleId(Operations.UserID);
            if (PermissionsList != null && PermissionsList.Count > 0)
            {
                if (PermissionsList[0].Saving == true)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
                if (PermissionsList[0].Deleting == true)
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                }
                if (PermissionsList[0].Posting == true)
                {
                    btnSave.Enabled = true;
                    chkPosted.Checked = true;
                    chkPosted.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = false;
                    chkPosted.Checked = false;
                    chkPosted.Enabled = true;
                }
            }
            //else
            //{
            //    btnSave.Enabled = false;
            //    btnDelete.Enabled = false;
            //    chkPosted.Checked = true;
            //    chkPosted.Enabled = true;
            //}

        }
        private void ShowControls()
        {
            lblChequeNo.Visible = true;
            txtChequeNo.Visible = true;
        }
        private void FillData()
        {
            var manager = new VoucherBLL();
            VEditBox.Text = manager.GetMaxVoucherNumber(VoucherType, Operations.IdCompany);
        }
        private bool ValidateRows()
        {
            bool Status = true;
            if (DgvVoucher.Rows.Count > 1)
            {
                for (int i = 0; i < DgvVoucher.Rows.Count - 1; i++)
                {
                    if (DgvVoucher.Rows[i].Cells["colAccountNo"].Value == null)
                    {
                        Status = false;
                    }
                    else if (DgvVoucher.Rows[i].Cells["colDebit"].Value == null)
                    {
                        return false;
                    }
                    else if (DgvVoucher.Rows[i].Cells["colCredit"].Value == null)
                    {
                        return false;
                    }
                }
            }
            else
            {
                Status = false;
            }
            return Status;
        }
        private bool ValidateControls()
        {
            bool status = true;
            if (VoucherType == VoucherTypes.PaymentVoucher.ToString())
            {
                if (cbxAdjustments.SelectedIndex == 0 || cbxAdjustments.SelectedIndex == -1)
                {
                    status = false;
                    MessageBox.Show("Please Select Adjustment Type...");
                }
            }
            else if (VoucherType == VoucherTypes.CashReceiptVoucher.ToString())
            {
                if (cbxAdjustments.SelectedIndex == 0 || cbxAdjustments.SelectedIndex == -1)
                {
                    status = false;
                    MessageBox.Show("Please Select Adjustment Type...");
                }
            }
            return status;
        }
        private void ClearControl()
        {
            DgvVoucher.Rows.Clear();
            VEditBox.Enabled = true;
            txtDescription.Text = string.Empty;
            IdVoucher = Guid.Empty;
            //txtAmount.Text = string.Empty;
            txtDebit.Text = string.Empty;
            txtCredit.Text = string.Empty;
            CashTransactionId = Guid.Empty;
            IsNewVoucher = true;
            lblStatuMessage.Text = string.Empty;
            txtEmployeeContact.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            EmpEditCode.Text = string.Empty;
            txtChequeNo.Text = string.Empty;
            cbxAdjustments.SelectedIndex = -1;
            if (chkPosted.Checked)
            {
                chkPosted.Checked = false;
                chkPosted.Enabled = true;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
            VDate.Value = DateTime.Now;
        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            List<VoucherDetailEL> oelVoucherDetailCollection = new List<VoucherDetailEL>();
            EntityoperationInfo infoResult = new EntityoperationInfo();
            string InvolvementMsg;
            if (ValidateRows())
            {
                if (ValidateControls())
                {

                    if (!IsCashORbankAccountInvolve(out InvolvementMsg))
                    {
                        MessageBox.Show(InvolvementMsg);
                        return;
                    }
                    if (!AccountTransactionStatus(out InvolvementMsg))
                    {
                        MessageBox.Show(InvolvementMsg);
                        return;
                    }
                    if (IsTransactionalAccountExceeding(out InvolvementMsg))
                    {
                        MessageBox.Show(InvolvementMsg);
                        return;
                    }
                    /// Add Voucher...
                    VouchersEL oelVoucher = new VouchersEL();
                    if (IdVoucher == Guid.Empty)
                    {
                        oelVoucher.IdVoucher = Guid.NewGuid();
                    }
                    else
                    {
                        oelVoucher.IdVoucher = IdVoucher;
                    }
                    oelVoucher.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                    oelVoucher.BookNo = Operations.BookNo;
                    oelVoucher.SubAccountNo = Validation.GetSafeString(EmpEditCode.Text);
                    oelVoucher.IdUser = Operations.UserID;
                    oelVoucher.IdCompany = Operations.IdCompany;
                    oelVoucher.VDate = VDate.Value;
                    oelVoucher.VDiscription = txtDescription.Text;
                    oelVoucher.VoucherType = VoucherType;
                    oelVoucher.ChequeNo = txtChequeNo.Text;
                    oelVoucher.AdjustmentType = cbxAdjustments.SelectedIndex;
                    //oelVoucher.Amount = Convert.ToDecimal(txtAmount.Text == "" ? "0" : txtAmount.Text);
                    oelVoucher.TotalAmount = Convert.ToDecimal(txtDebit.Text == "" ? "0" : txtDebit.Text);
                    if (chkPosted.Checked)
                    {
                        oelVoucher.Posted = true;
                    }
                    else
                    {
                        oelVoucher.Posted = false;
                    }

                    // Add Voucher Payments In Detail
                    for (int i = 0; i < DgvVoucher.Rows.Count - 1; i++)
                    {
                        //PaymentDetailEL oelPaymentDetail = new PaymentDetailEL();
                        VoucherDetailEL oelVoucherDetail = new VoucherDetailEL();
                        TransactionsEL oelTransaction = new TransactionsEL();
                        oelVoucherDetail.IdVoucher = oelVoucher.IdVoucher;
                        oelTransaction.IdVoucher = oelVoucher.IdVoucher;
                        //oelTransaction.VDate = VDate.Value; 
                        oelTransaction.VDate = VDate.Value.AddSeconds(i);
                        if (DgvVoucher.Rows[i].Cells["ColIdDetailVoucher"].Value != null)
                        {
                            oelVoucherDetail.IdVoucherDetail = new Guid(DgvVoucher.Rows[i].Cells["ColIdDetailVoucher"].Value.ToString());
                            oelVoucherDetail.IsNew = false;
                            oelTransaction.TransactionID = oelVoucherDetail.IdVoucherDetail.Value;
                            oelTransaction.IsNew = false;
                        }
                        else
                        {
                            oelVoucherDetail.IdVoucherDetail = Guid.NewGuid();
                            oelVoucherDetail.IsNew = true;
                            oelTransaction.TransactionID = oelVoucherDetail.IdVoucherDetail.Value;
                            oelTransaction.IsNew = true;
                        }
                        oelVoucherDetail.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                        if (DgvVoucher.Rows[i].Cells["colDescription"].Value == null)
                        {
                            oelVoucherDetail.Description = "N/A";
                        }
                        else
                        {
                            oelVoucherDetail.Description = DgvVoucher.Rows[i].Cells["colDescription"].Value.ToString();
                        }
                        oelVoucherDetail.Seq = i + 1;
                        oelVoucherDetail.Units = 0;
                        oelVoucherDetail.IdUser = Operations.UserID;
                        oelVoucherDetail.IdAccount = Validation.GetSafeGuid(DgvVoucher.Rows[i].Cells["colIdAccount"].Value);
                        oelVoucherDetail.AccountNo = Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colAccountNo"].Value);
                        oelVoucherDetail.LinkAccountNo = Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colLinkAccountNo"].Value);
                        oelVoucherDetail.ClosingBalance = Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colClosingBalance"].Value);
                        oelVoucherDetail.Debit = Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colDebit"].Value);
                        oelVoucherDetail.Credit = Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colCredit"].Value);
                        if (oelVoucherDetail.Debit != 0)
                        {
                            oelVoucherDetail.TransactionType = "Dr";
                        }
                        else if (oelVoucherDetail.Credit != 0)
                        {
                            oelVoucherDetail.TransactionType = "Cr";
                        }
                        oelVoucherDetailCollection.Add(oelVoucherDetail);

                        oelTransaction.AccountNo = Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colAccountNo"].Value);
                        oelTransaction.SubAccountNo = Validation.GetSafeString(EmpEditCode.Text);
                        oelTransaction.IdCompany = Operations.IdCompany;
                        oelTransaction.IdUser = Operations.UserID;
                        oelTransaction.Seq = i + 1;

                        oelTransaction.AdjustmentType = cbxAdjustments.SelectedIndex;
                        oelTransaction.SettlementType = cbxAdjustments.Text;
                        //oelTransaction.Date = VDate.Value;
                        oelTransaction.VDate = VDate.Value.AddSeconds(i);
                        oelTransaction.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
                        oelTransaction.VoucherType = VoucherType;
                        if (DgvVoucher.Rows[i].Cells["colDescription"].Value == null)
                        {
                            oelTransaction.Discription = "";
                        }
                        else
                        {
                            oelTransaction.Discription = DgvVoucher.Rows[i].Cells["colDescription"].Value.ToString();
                        }
                        oelTransaction.ClosingBalance = Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colClosingBalance"].Value);
                        oelTransaction.Debit = Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colDebit"].Value);
                        oelTransaction.Credit = Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colCredit"].Value);
                        if (oelTransaction.Debit != 0)
                        {
                            oelTransaction.TransactionType = "Dr";
                        }
                        else if (oelTransaction.Credit != 0)
                        {
                            oelTransaction.TransactionType = "Cr";
                        }
                        if (VoucherType == VoucherTypes.PaymentVoucher.ToString())
                        {
                            if (oelTransaction.Debit != 0)
                            {
                                oelTransaction.LinkAccountNo = Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colLinkAccountNo"].Value);
                            }
                            else
                            {
                                oelTransaction.LinkAccountNo = "";
                            }
                        }
                        else
                        {
                            oelTransaction.LinkAccountNo = "";
                        }
                        if (chkPosted.Checked)
                        {
                            oelTransaction.Posted = true;
                        }
                        else
                        {
                            oelTransaction.Posted = false;
                        }
                        oelTransactionCollection.Add(oelTransaction);
                    }
                    #region Comments
                    ///// Add Cash...
                    //TransactionsEL oeTransaction = new TransactionsEL();
                    //if (CashTransactionId != Guid.Empty)
                    //{
                    //    oeTransaction.TransactionID = CashTransactionId;
                    //    oeTransaction.IsNew = false;
                    //}
                    //else
                    //{
                    //    oeTransaction.TransactionID = Guid.NewGuid();
                    //    oeTransaction.IsNew = true;
                    //}
                    //oeTransaction.IdCompany = Operations.IdCompany;
                    //oeTransaction.AccountNo = Validation.GetSafeLong(CEditBox.Text);
                    //oeTransaction.Date = VDate.Value;
                    //oeTransaction.VoucherNo = Convert.ToInt32(VEditBox.Text);
                    //oeTransaction.VoucherType = VoucherType;
                    //oeTransaction.Description = txtDescription.Text;
                    ////oeTransaction.Amount = -Convert.ToDecimal(txtTotalAmount.Text);
                    //if (VoucherType == VoucherTypes.PaymentVoucher.ToString())
                    //{
                    //    //oeTransaction.Credit = Convert.ToDecimal(txtAmount.Text == "" ? "0" : txtAmount.Text);
                    //    oeTransaction.Credit = Convert.ToDecimal(txtBalance.Text == "" ? "0" : txtBalance.Text);
                    //    oeTransaction.Debit = 0;
                    //}
                    //else if (VoucherType == VoucherTypes.CashReceiptVoucher.ToString())
                    //{
                    //    oeTransaction.Debit = Convert.ToDecimal(txtBalance.Text == "" ? "0" : txtBalance.Text);
                    //    oeTransaction.Credit = 0;
                    //}
                    //if (chkPosted.Checked)
                    //{
                    //    oeTransaction.Posted = true;
                    //}
                    //else
                    //{
                    //    oeTransaction.Posted = false;
                    //}
                    //oelTransactionCollection.Add(oeTransaction);
                    //if (CashTransactionId == Guid.Empty)
                    #endregion
                    if (txtDebit.Text == txtCredit.Text)
                    {
                        if (IdVoucher == Guid.Empty)
                        {
                            //var Manager = new CashBLL();
                            var Manager = new VoucherBLL();
                            if (Manager.CheckVoucherNo(Operations.IdCompany, Validation.GetSafeLong(VEditBox.Text), VoucherType) == false)
                            {
                                infoResult = Manager.InsertVouchersHead(oelVoucher, oelVoucherDetailCollection, oelTransactionCollection);
                                if (infoResult.IsSuccess)
                                {
                                    lblStatuMessage.Text = "Successfully Inserted...";
                                    ClearControl();
                                    FillData();
                                }
                            }
                            else
                            {
                                MessageBox.Show("This Voucher No Already Exists ; Plz Change Voucher No :");
                            }
                        }
                        else
                        {
                            var Manager = new VoucherBLL();
                            infoResult = Manager.UpdateVouchersHead(oelVoucher, oelVoucherDetailCollection, oelTransactionCollection);

                            if (infoResult.IsSuccess)
                            {
                                // manager.UpdateStockitems(oelTransactionCollection, "Add");
                                lblStatuMessage.Text = "Successfully Updated...";
                                ClearControl();
                                FillData();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debit & Credit Sides not equal");
                    }
                }

                else
                {
                    lblStatuMessage.Text = "Something Missing Perhaps...";
                }
            }
            else
            {
                lblStatuMessage.Text = "Incomplete Entry...";
                lblStatuMessage.ForeColor = Color.Red;
            }
        }
        private bool IsCashORbankAccountInvolve(out string Message)
        {
            bool HeadStatus = true;
            Message = string.Empty;
            for (int i = 0; i < DgvVoucher.Rows.Count - 1; i++)
            {
                if (VoucherType == VoucherTypes.PaymentVoucher.ToString())
                {
                    if (Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colHeadType"].Value) != "Cash Balance Head")
                    {
                        HeadStatus = false;
                        Message = "Cash Account Is Not Involved In This Transaction";
                    }
                    else
                    {
                        HeadStatus = true;
                        Message = "";
                        break;
                    }
                }
                if (VoucherType == VoucherTypes.CashReceiptVoucher.ToString())
                {
                    if (Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colHeadType"].Value) != "Cash Balance Head")
                    {
                        HeadStatus = false;
                        Message = "Cash Account Is Not Involved In This Transaction";
                    }
                    else
                    {
                        HeadStatus = true;
                        Message = "";
                        break;
                    }
                }
                if (VoucherType == VoucherTypes.BankPaymentVoucher.ToString())
                {
                    if (Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colHeadType"].Value) != "Bank Balance Head")
                    {
                        HeadStatus = false;
                        Message = "Bank Account Is Not Involved In This Transaction";
                    }
                    else
                    {
                        HeadStatus = true;
                        Message = "";
                        break;
                    }
                }
                if (VoucherType == VoucherTypes.BankReceiptVoucher.ToString())
                {
                    if (Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colHeadType"].Value) != "Bank Balance Head")
                    {
                        HeadStatus = false;
                        Message = "Bank Account Is Not Involved In This Transaction";
                    }
                    else
                    {
                        HeadStatus = true;
                        Message = "";
                        break;
                    }
                }
            }
            return HeadStatus;
        }
        private bool AccountTransactionStatus(out string Message)
        {
            bool TransactionStatus = true;
            Message = "";
            for (int i = 0; i < DgvVoucher.Rows.Count - 1; i++)
            {
                if (VoucherType == VoucherTypes.PaymentVoucher.ToString())
                {
                    if (Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colHeadType"].Value) == "Cash Balance Head")
                    {
                        if (Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colCredit"].Value) == 0 || Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colCredit"].Value) < 0)
                        {
                            Message = "Cash Account Must Be Credited...";
                            TransactionStatus = false;
                        }
                        break;
                    }
                }
                if (VoucherType == VoucherTypes.CashReceiptVoucher.ToString())
                {
                    if (Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colHeadType"].Value) == "Cash Balance Head")
                    {
                        if (Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colDebit"].Value) == 0 || Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colDebit"].Value) < 0)
                        {
                            Message = "Cash Account Must Be Debited";
                            TransactionStatus = false;
                            break;
                        }
                    }
                }
                if (VoucherType == VoucherTypes.BankPaymentVoucher.ToString())
                {
                    if (Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colHeadType"].Value) == "Bank Balance Head")
                    {
                        if (Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colCredit"].Value) == 0 || Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colCredit"].Value) < 0)
                        {
                            Message = "Bank Account Must Be Credit";
                            TransactionStatus = false;
                            break;
                        }
                    }
                }
                if (VoucherType == VoucherTypes.BankReceiptVoucher.ToString())
                {
                    if (Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colHeadType"].Value) == "Bank Balance Head")
                    {
                        if (Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colDebit"].Value) == 0 || Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colDebit"].Value) < 0)
                        {
                            Message = "Bank Account Must Be Debited";
                            TransactionStatus = false;
                            break;
                        }
                    }
                }
            }
            return TransactionStatus;
        }
        private bool IsTransactionalAccountExceeding(out string Message)
        {
            bool status = false ;
            Message = string.Empty;
            for (int i = 0; i < DgvVoucher.Rows.Count - 1; i++)
            {
                if (VoucherType == VoucherTypes.PaymentVoucher.ToString())
                {
                    if (Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colHeadType"].Value) == "Cash Balance Head")
                    {
                        if (Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colCredit"].Value) > Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colClosingBalance"].Value) )
                        {
                            Message = "Cash Account Is Exceeding Credit Limit With Closing Balance...";
                            status = true;
                            break;
                        }
                    }
                }
                if (VoucherType == VoucherTypes.BankPaymentVoucher.ToString())
                {
                    if (Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colHeadType"].Value) == "Bank Balance Head")
                    {
                        if (Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colCredit"].Value) > Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colClosingBalance"].Value))
                        {
                            Message = "Back Account Is Exceeding Credit Limit With Closing Balance...";
                            status = true;
                            break;
                        }
                    }
                }
            }
            return status;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (VEditBox.Text != string.Empty)
            {
                var manager = new VoucherBLL();
                if (IdVoucher != Guid.Empty)
                {
                    if (MessageBox.Show("Are You Sure To Delete ?", "Deleting Voucher", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (manager.DeleteVouchers(IdVoucher, Operations.IdCompany))
                        {
                            lblStatuMessage.Text = "Voucher Deleted Successfully";
                            ClearControl();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Voucher To Delete....");
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DgvVoucher.EndEdit();
            DgvVoucher.CurrentCell = null;
            this.Close();
        }
        private void DgvVoucher_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvVoucher.Columns[e.ColumnIndex].Name == "colDebit")
            {

                for (int i = 0; i < DgvVoucher.Rows.Count - 1; i++)
                {
                    OldValue += Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colDebit"].Value);
                }
                //txtAmount.Text = OldValue.ToString();
                txtDebit.Text = OldValue.ToString();
                OldValue = 0;

            }
            else if (DgvVoucher.Columns[e.ColumnIndex].Name == "colCredit")
            {
                for (int i = 0; i < DgvVoucher.Rows.Count - 1; i++)
                {
                    OldValue += Validation.GetSafeDecimal(DgvVoucher.Rows[i].Cells["colCredit"].Value);
                }
                //txtAmount.Text = OldValue.ToString();
                txtCredit.Text = OldValue.ToString();
                OldValue = 0;
            }
        }
        private void DgvVoucher_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvVoucher.Columns[e.ColumnIndex].Name == "colDebit")
            {
                if (DgvVoucher.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    DgvVoucher.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
            else if (DgvVoucher.Columns[e.ColumnIndex].Name == "colCredit")
            {
                if (DgvVoucher.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    DgvVoucher.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
            if (DgvVoucher.Columns[e.ColumnIndex].Name == "colCredit")
            {
                if (Validation.GetSafeDecimal(DgvVoucher.Rows[e.RowIndex].Cells["colDebit"].EditedFormattedValue) == Validation.GetSafeDecimal(DgvVoucher.Rows[e.RowIndex].Cells["colCredit"].EditedFormattedValue))
                {
                    MessageBox.Show("Debit & Credit Values In Single Row Can,t be equal....");
                    DgvVoucher.Rows[e.RowIndex].Cells["colCredit"].Value = 0;
                }
            }
        }
        private void VEditBox_ButtonClick(object sender, EventArgs e)
        {
            frmfindVoucher = new frmFindVouchers();
            frmfindVoucher.VoucherType = VoucherType;
            frmfindVoucher.ExecuteFindVouchersEvent += new frmFindVouchers.VouchersDelegate(frmfindVoucher_ExecuteFindVouchersEvent);
            frmfindVoucher.ShowDialog(this);
        }
        void frmfindVoucher_ExecuteFindVouchersEvent(VouchersEL oelVoucher)
        {
            VEditBox.Text = oelVoucher.VoucherNo.ToString();
            //CEditBox.Text = Validation.GetSafeString(oelVoucher.AccountNo);

            FillVoucher();
        }
        private void VEditBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    FillVoucher();
                }
            }
            else
                e.Handled = true;
        }

        #region Transactional Methods
        private void FillVoucher()
        {
            var Manager = new VoucherBLL();
            if (VEditBox.Text != string.Empty)
            {
                List<VouchersEL> list = Manager.GetVouchersByTypeAndVoucherNumber(Operations.IdCompany, VoucherType, Convert.ToInt64(VEditBox.Text));
                if (list.Count > 0)
                {
                    VDate.Value = list[0].VDate.Value;
                    IdVoucher = list[0].IdVoucher;
                    txtDescription.Text = list[0].VDiscription;
                    txtChequeNo.Text = Validation.GetSafeString(list[0].ChequeNo);
                    VEditBox.Enabled = false;
                    if (VoucherType == VoucherTypes.PaymentVoucher.ToString())
                    {
                        cbxAdjustments.SelectedIndex = list[0].AdjustmentType.Value;
                    }
                    else if (VoucherType == VoucherTypes.CashReceiptVoucher.ToString())
                    {
                        cbxAdjustments.SelectedIndex = list[0].AdjustmentType.Value;
                    }
                    HandleVoucher(list);

                    //var TManager = new TransactionBLL();
                    //CashTransactionId = TManager.GetHeadAccountTransactionId(Validation.GetSafeLong(VEditBox.Text), VoucherType, list[0].AccountNo, Operations.IdCompany)[0].TransactionID;

                    if (VoucherType == VoucherTypes.CashReceiptVoucher.ToString())
                    {
                        FillEmployee(list[0].SubAccountNo);
                    }

                    var manager = new VoucherBLL();
                    List<TransactionsEL> List = manager.GetTransactionsByVoucherAndType(Operations.IdCompany, IdVoucher, Validation.GetSafeLong(VEditBox.Text), VoucherType);
                    if (list.Count > 0)
                    {
                        FillTransactions(List);
                    }
                    else
                    {
                        ClearControl();
                    }

                }
                else
                {
                    MessageBox.Show("Voucher Number Not Found ...");
                    ClearControl();
                }
            }
        }
        private void HandleVoucher(List<VouchersEL> list)
        {
            if (list[0].Posted && list[0].IsDeleted == true)
            {
                //if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                {
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    chkPosted.Enabled = false;
                }
                lblDeletedVoucher.Visible = true;
                lblDeletedVoucher.Text = "Deleted Voucher";
                chkPosted.Checked = list[0].Posted;
            }
            else if (!list[0].Posted && !list[0].IsDeleted == true)
            {
                {
                    btnSave.Enabled = true;
                    btnDelete.Enabled = true;
                    chkPosted.Enabled = true;
                }
                lblDeletedVoucher.Visible = false;
            }
            else if (list[0].Posted && !list[0].IsDeleted == true)
            {
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                chkPosted.Enabled = false;
            }
            else if (!list[0].Posted && list[0].IsDeleted == true)
            {
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                chkPosted.Enabled = false;
                lblDeletedVoucher.Visible = true;
                lblDeletedVoucher.Text = "Deleted Voucher";
            }
            else if (list[0].Posted && list[0].IsDeleted == null)
            {
                chkPosted.Checked = true;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                chkPosted.Enabled = true;
                lblDeletedVoucher.Text = "Posted Voucher";
            }
            else if (!list[0].Posted && list[0].IsDeleted == null)
            {
                chkPosted.Checked = false;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                chkPosted.Enabled = true;
                lblDeletedVoucher.Text = "UnPosted Voucher";
            }
            else
            {
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
        private void FillEmployee(string EmpCode)
        {
            var manager = new PersonsBLL();
            //List<PersonsEL> list = manager.VerifyAccount("Customers/Suppliers", oelChartOfAccount.AccountNo);
            List<PersonsEL> list = manager.VerifyAccount(Operations.IdCompany, "Persons", EmpCode);
            if (list.Count > 0)
            {
                EmpEditCode.Text = EmpCode.ToString();
                txtEmployeeName.Text = list[0].PersonName;
                txtEmployeeContact.Text = list[0].Contact;
                lblStatuMessage.Text = "";
            }
            else
            {
                lblStatuMessage.Text = "Please Select Employee";
            }
        }
        private void FillTransactions(List<TransactionsEL> List)
        {
            if (DgvVoucher.Rows.Count > 0)
            {
                DgvVoucher.Rows.Clear();
            }
            if (List != null && List.Count > 0)
            {
                for (int i = 0; i < List.Count; i++)
                {
                    DgvVoucher.Rows.Add();
                    DgvVoucher.Rows[i].Cells[0].Value = List[i].AccountType;
                    DgvVoucher.Rows[i].Cells[1].Value = List[i].TransactionID;
                    DgvVoucher.Rows[i].Cells[2].Value = List[i].IdDetail;
                    DgvVoucher.Rows[i].Cells[3].Value = List[i].IdAccount;
                    DgvVoucher.Rows[i].Cells[4].Value = List[i].AccountNo;
                    DgvVoucher.Rows[i].Cells[5].Value = List[i].LinkAccountNo;
                    DgvVoucher.Rows[i].Cells[6].Value = List[i].AccountName;
                    DgvVoucher.Rows[i].Cells[7].Value = List[i].ClosingBalance;
                    DgvVoucher.Rows[i].Cells[8].Value = List[i].Discription;
                    DgvVoucher.Rows[i].Cells[9].Value = List[i].Debit;
                    DgvVoucher.Rows[i].Cells[10].Value = List[i].Credit;
                    //if (VoucherType == VoucherTypes.PaymentVoucher.ToString())
                    //{
                    //    DgvCashVoucher.Rows[i].Cells[5].Value = List[i].Debit;
                    //}
                    //else if (VoucherType == VoucherTypes.CashReceiptVoucher.ToString())
                    //{
                    //    DgvCashVoucher.Rows[i].Cells[5].Value = List[i].Credit;
                    //}
                }
                txtDebit.Text = List.Sum(x => x.Debit).ToString();

                txtCredit.Text = List.Sum(x => x.Credit).ToString();

                //txtDescription.Text = List[0].Description;
            }
        }
        #endregion
        private void EmpEditCode_ButtonClick(object sender, EventArgs e)
        {
            frmAccount = new frmFindAccounts();
            Command = "Employees";
            frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
            frmAccount.ShowDialog(this);
        }
        private void DgvVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (DgvVoucher.CurrentCellAddress.X == 2)
                {

                }
            }
        }
        private void frmPaymentVoucher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                FillData();
                ClearControl();
                if (DgvVoucher.Rows.Count > 0)
                {
                    DgvVoucher.Rows.Clear();
                }
            }
        }

        private void DgvVoucher_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvVoucher.CurrentCellAddress.X == 6)
            {
                TextBox txtAccountName = e.Control as TextBox;
                if (txtAccountName != null)
                {
                    txtAccountName.KeyPress -= new KeyPressEventHandler(txtAccountName_KeyPress);
                    txtAccountName.KeyPress += new KeyPressEventHandler(txtAccountName_KeyPress);
                }
            }
        }

        void txtAccountName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvVoucher.CurrentCellAddress.X == 6)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmAccount = new frmFindAccounts();
                    Command = "";
                    frmAccount.ExecuteFindAccountEvent += new frmFindAccounts.FindAccountDelegate(frmAccount_ExecuteFindAccountEvent);
                    frmAccount.SearchText = e.KeyChar.ToString();
                    frmAccount.ShowDialog(this);
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
        void frmAccount_ExecuteFindAccountEvent(object Sender, AccountsEL oelAccount)
        {
            DgvVoucher.RefreshEdit();
            if (Command == "Employees")
            {
                var manager = new PersonsBLL();
                //List<PersonsEL> list = manager.VerifyAccount("Customers/Suppliers", oelChartOfAccount.AccountNo);
                List<PersonsEL> list = manager.VerifyAccount(Operations.IdCompany, "Persons", oelAccount.AccountNo);
                if (list.Count > 0)
                {
                    EmpEditCode.Text = oelAccount.AccountNo.ToString();
                    txtEmployeeName.Text = list[0].PersonName;
                    txtEmployeeContact.Text = list[0].Contact;
                    lblStatuMessage.Text = "";
                }
                else
                {
                    lblStatuMessage.Text = "Please Select Employee";
                }
            }
            else
            {
                var manager = new AccountsBLL();
                List<AccountsEL> list = manager.GetAccount(oelAccount.AccountNo, Validation.GetSafeGuid(oelAccount.IdCompany));
                if (list.Count > 0)
                {
                    for (int i = 0; i < DgvVoucher.Rows.Count - 1; i++)
                    {
                        if (DgvVoucher.Rows[i].Cells["colAccountNo"].Value != null)
                        {
                            if (oelAccount.AccountNo == Validation.GetSafeString(DgvVoucher.Rows[i].Cells["colAccountNo"].Value))
                            {
                                lblStatuMessage.Text = "Account Already exists";
                                return;
                            }
                        }
                    }
                }
                DgvVoucher.CurrentRow.Cells["colHeadType"].Value = oelAccount.AccountType;
                DgvVoucher.CurrentRow.Cells["colIdAccount"].Value = oelAccount.IdAccount;
                DgvVoucher.CurrentRow.Cells["colAccountNo"].Value = oelAccount.AccountNo;
                DgvVoucher.CurrentRow.Cells["colLinkAccountNo"].Value = oelAccount.LinkAccountNo;
                DgvVoucher.CurrentRow.Cells["colAccountName"].Value = oelAccount.AccountName;
                DgvVoucher.CurrentRow.Cells["colClosingBalance"].Value = new TransactionBLL().GetAccountClosingBalance(oelAccount.AccountNo, Operations.IdCompany);
                //DgvCashVoucher.CurrentRow.Cells["colDescription"].Selected = true; 
                DgvVoucher.Focus();
                lblStatuMessage.Text = "";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmprintVouchers = new frmPrintVouchers();
            frmprintVouchers.VoucherNo = Validation.GetSafeLong(VEditBox.Text);
            frmprintVouchers.VType = VoucherType;
            frmprintVouchers.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            long NextVoucherNo = Convert.ToInt64(VEditBox.Text);
            NextVoucherNo += 1;
            VEditBox.Text = NextVoucherNo.ToString();
            FillVoucher();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            long PreviousVoucherNo = Convert.ToInt64(VEditBox.Text);
            PreviousVoucherNo -= 1;
            VEditBox.Text = PreviousVoucherNo.ToString();
            FillVoucher();
        }

        private void btnNewVoucher_Click(object sender, EventArgs e)
        {
            ClearControl();
            FillData();
        }

        private void pnlGrid_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
