namespace Accounts.UI
{
    partial class frmStockReceipt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.lblPoNumber = new MetroFramework.Controls.MetroLabel();
            this.txtPoNumber = new MetroFramework.Controls.MetroTextBox();
            this.cbxPurchaser = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.VDate = new MetroFramework.Controls.MetroDateTime();
            this.VEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblDiscription = new MetroFramework.Controls.MetroLabel();
            this.lblBillNo = new MetroFramework.Controls.MetroLabel();
            this.lblVoucherNo = new MetroFramework.Controls.MetroLabel();
            this.lblDate = new MetroFramework.Controls.MetroLabel();
            this.chkPosted = new MetroFramework.Controls.MetroCheckBox();
            this.txtBillNo = new MetroFramework.Controls.MetroTextBox();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.txtContact = new MetroFramework.Controls.MetroTextBox();
            this.grpCreditor = new System.Windows.Forms.GroupBox();
            this.btnViewLedger = new MetroFramework.Controls.MetroButton();
            this.btnViewDetail = new MetroFramework.Controls.MetroButton();
            this.SEditBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtSupplierClosingBalance = new MetroFramework.Controls.MetroTextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.txtTotalCredit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtFreightAmount = new MetroFramework.Controls.MetroTextBox();
            this.lblFreight = new MetroFramework.Controls.MetroLabel();
            this.txtAmountAfterDiscount = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.txtFlatDiscount = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.txtTotalDiscount = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtBillAmount = new MetroFramework.Controls.MetroTextBox();
            this.lblTotal = new MetroFramework.Controls.MetroLabel();
            this.tabTransactions = new System.Windows.Forms.TabPage();
            this.lblVoucherStatus = new MetroFramework.Controls.MetroLabel();
            this.btnPrint = new MetroFramework.Controls.MetroTile();
            this.btnPrevious = new MetroFramework.Controls.MetroTile();
            this.btnNext = new MetroFramework.Controls.MetroTile();
            this.btnNew = new MetroFramework.Controls.MetroTile();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.pnlFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.grpPurchases = new System.Windows.Forms.GroupBox();
            this.rdCash = new MetroFramework.Controls.MetroRadioButton();
            this.rdCredit = new MetroFramework.Controls.MetroRadioButton();
            this.flowPurchasesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCash = new System.Windows.Forms.Panel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnAddCashAccount = new MetroFramework.Controls.MetroButton();
            this.cbxCashAccounts = new MetroFramework.Controls.MetroComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxNaturalAccounts = new MetroFramework.Controls.MetroComboBox();
            this.btnRefresh = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnAddPurchasesAccount = new MetroFramework.Controls.MetroButton();
            this.DgvStockReceipt = new Accounts.UI.TabDataGrid();
            this.colStockReceiptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new Accounts.UI.DataGridViewProductWaterMarkColumn();
            this.colpacking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFlatDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscountAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DgvPurchases = new Accounts.UI.TabDataGrid();
            this.colHeadType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIdDetailVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLinkAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClosingBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpHeader.SuspendLayout();
            this.grpCreditor.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabItems.SuspendLayout();
            this.tabTransactions.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlFlow.SuspendLayout();
            this.grpPurchases.SuspendLayout();
            this.flowPurchasesPanel.SuspendLayout();
            this.pnlCash.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStockReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPurchases)).BeginInit();
            this.SuspendLayout();
            // 
            // grpHeader
            // 
            this.grpHeader.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.grpHeader.Controls.Add(this.lblPoNumber);
            this.grpHeader.Controls.Add(this.txtPoNumber);
            this.grpHeader.Controls.Add(this.cbxPurchaser);
            this.grpHeader.Controls.Add(this.metroLabel7);
            this.grpHeader.Controls.Add(this.VDate);
            this.grpHeader.Controls.Add(this.VEditBox);
            this.grpHeader.Controls.Add(this.lblDiscription);
            this.grpHeader.Controls.Add(this.lblBillNo);
            this.grpHeader.Controls.Add(this.lblVoucherNo);
            this.grpHeader.Controls.Add(this.lblDate);
            this.grpHeader.Controls.Add(this.chkPosted);
            this.grpHeader.Controls.Add(this.txtBillNo);
            this.grpHeader.Controls.Add(this.txtDescription);
            this.grpHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHeader.Location = new System.Drawing.Point(3, 3);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1121, 84);
            this.grpHeader.TabIndex = 2;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Bill Information";
            // 
            // lblPoNumber
            // 
            this.lblPoNumber.AutoSize = true;
            this.lblPoNumber.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblPoNumber.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPoNumber.Location = new System.Drawing.Point(649, 54);
            this.lblPoNumber.Name = "lblPoNumber";
            this.lblPoNumber.Size = new System.Drawing.Size(140, 19);
            this.lblPoNumber.TabIndex = 29;
            this.lblPoNumber.Text = "Customer Po(If Any) :";
            this.lblPoNumber.UseCustomBackColor = true;
            // 
            // txtPoNumber
            // 
            // 
            // 
            // 
            this.txtPoNumber.CustomButton.Image = null;
            this.txtPoNumber.CustomButton.Location = new System.Drawing.Point(140, 1);
            this.txtPoNumber.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtPoNumber.CustomButton.Name = "";
            this.txtPoNumber.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPoNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPoNumber.CustomButton.TabIndex = 1;
            this.txtPoNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPoNumber.CustomButton.UseSelectable = true;
            this.txtPoNumber.Lines = new string[0];
            this.txtPoNumber.Location = new System.Drawing.Point(791, 52);
            this.txtPoNumber.MaxLength = 32767;
            this.txtPoNumber.Name = "txtPoNumber";
            this.txtPoNumber.PasswordChar = '\0';
            this.txtPoNumber.PromptText = "Click Green Button";
            this.txtPoNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPoNumber.SelectedText = "";
            this.txtPoNumber.SelectionLength = 0;
            this.txtPoNumber.SelectionStart = 0;
            this.txtPoNumber.ShortcutsEnabled = true;
            this.txtPoNumber.ShowButton = true;
            this.txtPoNumber.Size = new System.Drawing.Size(162, 23);
            this.txtPoNumber.Style = MetroFramework.MetroColorStyle.Green;
            this.txtPoNumber.TabIndex = 28;
            this.txtPoNumber.UseSelectable = true;
            this.txtPoNumber.WaterMark = "Click Green Button";
            this.txtPoNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPoNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPoNumber.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtPoNumber_ButtonClick);
            // 
            // cbxPurchaser
            // 
            this.cbxPurchaser.FormattingEnabled = true;
            this.cbxPurchaser.ItemHeight = 23;
            this.cbxPurchaser.Items.AddRange(new object[] {
            "",
            "Feroz Sons Gloves",
            "Feroz Sons Garments"});
            this.cbxPurchaser.Location = new System.Drawing.Point(329, 17);
            this.cbxPurchaser.Name = "cbxPurchaser";
            this.cbxPurchaser.Size = new System.Drawing.Size(169, 29);
            this.cbxPurchaser.TabIndex = 27;
            this.cbxPurchaser.UseSelectable = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(249, 23);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(76, 19);
            this.metroLabel7.TabIndex = 26;
            this.metroLabel7.Text = "Purchaser :";
            this.metroLabel7.UseCustomBackColor = true;
            // 
            // VDate
            // 
            this.VDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.VDate.Location = new System.Drawing.Point(555, 16);
            this.VDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.VDate.Name = "VDate";
            this.VDate.Size = new System.Drawing.Size(138, 29);
            this.VDate.TabIndex = 22;
            // 
            // VEditBox
            // 
            // 
            // 
            // 
            this.VEditBox.CustomButton.Image = null;
            this.VEditBox.CustomButton.Location = new System.Drawing.Point(141, 1);
            this.VEditBox.CustomButton.Name = "";
            this.VEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.VEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.VEditBox.CustomButton.TabIndex = 1;
            this.VEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.VEditBox.CustomButton.UseSelectable = true;
            this.VEditBox.Lines = new string[0];
            this.VEditBox.Location = new System.Drawing.Point(82, 21);
            this.VEditBox.MaxLength = 32767;
            this.VEditBox.Name = "VEditBox";
            this.VEditBox.PasswordChar = '\0';
            this.VEditBox.PromptText = "Voucher No";
            this.VEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.VEditBox.SelectedText = "";
            this.VEditBox.SelectionLength = 0;
            this.VEditBox.SelectionStart = 0;
            this.VEditBox.ShortcutsEnabled = true;
            this.VEditBox.ShowButton = true;
            this.VEditBox.Size = new System.Drawing.Size(163, 23);
            this.VEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.VEditBox.TabIndex = 21;
            this.VEditBox.UseSelectable = true;
            this.VEditBox.WaterMark = "Voucher No";
            this.VEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.VEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.VEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.VEditBox_ButtonClick);
            this.VEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VEditBox_KeyPress);
            // 
            // lblDiscription
            // 
            this.lblDiscription.AutoSize = true;
            this.lblDiscription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDiscription.Location = new System.Drawing.Point(1, 54);
            this.lblDiscription.Name = "lblDiscription";
            this.lblDiscription.Size = new System.Drawing.Size(81, 19);
            this.lblDiscription.TabIndex = 19;
            this.lblDiscription.Text = "Discription :";
            this.lblDiscription.UseCustomBackColor = true;
            // 
            // lblBillNo
            // 
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblBillNo.Location = new System.Drawing.Point(702, 20);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(55, 19);
            this.lblBillNo.TabIndex = 19;
            this.lblBillNo.Text = "Bill No :";
            this.lblBillNo.UseCustomBackColor = true;
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblVoucherNo.Location = new System.Drawing.Point(4, 22);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(67, 19);
            this.lblVoucherNo.TabIndex = 19;
            this.lblVoucherNo.Text = "Voucher :";
            this.lblVoucherNo.UseCustomBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDate.Location = new System.Drawing.Point(503, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 19);
            this.lblDate.TabIndex = 19;
            this.lblDate.Text = "Date :";
            this.lblDate.UseCustomBackColor = true;
            // 
            // chkPosted
            // 
            this.chkPosted.AutoSize = true;
            this.chkPosted.Location = new System.Drawing.Point(897, 22);
            this.chkPosted.Name = "chkPosted";
            this.chkPosted.Size = new System.Drawing.Size(59, 15);
            this.chkPosted.TabIndex = 18;
            this.chkPosted.Text = "Posted";
            this.chkPosted.UseCustomBackColor = true;
            this.chkPosted.UseSelectable = true;
            // 
            // txtBillNo
            // 
            // 
            // 
            // 
            this.txtBillNo.CustomButton.Image = null;
            this.txtBillNo.CustomButton.Location = new System.Drawing.Point(107, 1);
            this.txtBillNo.CustomButton.Name = "";
            this.txtBillNo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBillNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBillNo.CustomButton.TabIndex = 1;
            this.txtBillNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBillNo.CustomButton.UseSelectable = true;
            this.txtBillNo.CustomButton.Visible = false;
            this.txtBillNo.Lines = new string[] {
        "0"};
            this.txtBillNo.Location = new System.Drawing.Point(760, 18);
            this.txtBillNo.MaxLength = 32767;
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.PasswordChar = '\0';
            this.txtBillNo.PromptText = "Bill No";
            this.txtBillNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBillNo.SelectedText = "";
            this.txtBillNo.SelectionLength = 0;
            this.txtBillNo.SelectionStart = 0;
            this.txtBillNo.ShortcutsEnabled = true;
            this.txtBillNo.Size = new System.Drawing.Size(129, 23);
            this.txtBillNo.TabIndex = 0;
            this.txtBillNo.Text = "0";
            this.txtBillNo.UseSelectable = true;
            this.txtBillNo.WaterMark = "Bill No";
            this.txtBillNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBillNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtBillNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBillNo_KeyPress);
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(531, 2);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(82, 48);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(561, 32);
            this.txtDescription.TabIndex = 16;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtContact
            // 
            // 
            // 
            // 
            this.txtContact.CustomButton.Image = null;
            this.txtContact.CustomButton.Location = new System.Drawing.Point(102, 1);
            this.txtContact.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtContact.CustomButton.Name = "";
            this.txtContact.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtContact.CustomButton.TabIndex = 1;
            this.txtContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtContact.CustomButton.UseSelectable = true;
            this.txtContact.CustomButton.Visible = false;
            this.txtContact.Lines = new string[0];
            this.txtContact.Location = new System.Drawing.Point(334, 25);
            this.txtContact.MaxLength = 32767;
            this.txtContact.Name = "txtContact";
            this.txtContact.PasswordChar = '\0';
            this.txtContact.PromptText = "Contact";
            this.txtContact.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContact.SelectedText = "";
            this.txtContact.SelectionLength = 0;
            this.txtContact.SelectionStart = 0;
            this.txtContact.ShortcutsEnabled = true;
            this.txtContact.Size = new System.Drawing.Size(124, 23);
            this.txtContact.TabIndex = 21;
            this.txtContact.UseSelectable = true;
            this.txtContact.WaterMark = "Contact";
            this.txtContact.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContact.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // grpCreditor
            // 
            this.grpCreditor.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.grpCreditor.Controls.Add(this.btnViewLedger);
            this.grpCreditor.Controls.Add(this.btnViewDetail);
            this.grpCreditor.Controls.Add(this.SEditBox);
            this.grpCreditor.Controls.Add(this.metroLabel2);
            this.grpCreditor.Controls.Add(this.txtSupplierClosingBalance);
            this.grpCreditor.Controls.Add(this.txtContact);
            this.grpCreditor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCreditor.Location = new System.Drawing.Point(3, 93);
            this.grpCreditor.Name = "grpCreditor";
            this.grpCreditor.Size = new System.Drawing.Size(1121, 56);
            this.grpCreditor.TabIndex = 0;
            this.grpCreditor.TabStop = false;
            this.grpCreditor.Text = "Creditor Information";
            // 
            // btnViewLedger
            // 
            this.btnViewLedger.Location = new System.Drawing.Point(687, 24);
            this.btnViewLedger.Name = "btnViewLedger";
            this.btnViewLedger.Size = new System.Drawing.Size(93, 23);
            this.btnViewLedger.TabIndex = 25;
            this.btnViewLedger.Text = "View Ledger";
            this.btnViewLedger.UseSelectable = true;
            this.btnViewLedger.Click += new System.EventHandler(this.btnViewLedger_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(592, 24);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(93, 23);
            this.btnViewDetail.TabIndex = 25;
            this.btnViewDetail.Text = "View Detail";
            this.btnViewDetail.UseSelectable = true;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // SEditBox
            // 
            // 
            // 
            // 
            this.SEditBox.CustomButton.Image = null;
            this.SEditBox.CustomButton.Location = new System.Drawing.Point(266, 1);
            this.SEditBox.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.SEditBox.CustomButton.Name = "";
            this.SEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SEditBox.CustomButton.TabIndex = 1;
            this.SEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SEditBox.CustomButton.UseSelectable = true;
            this.SEditBox.Lines = new string[0];
            this.SEditBox.Location = new System.Drawing.Point(45, 25);
            this.SEditBox.MaxLength = 32767;
            this.SEditBox.Name = "SEditBox";
            this.SEditBox.PasswordChar = '\0';
            this.SEditBox.PromptText = "Account Name Here";
            this.SEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SEditBox.SelectedText = "";
            this.SEditBox.SelectionLength = 0;
            this.SEditBox.SelectionStart = 0;
            this.SEditBox.ShortcutsEnabled = true;
            this.SEditBox.ShowButton = true;
            this.SEditBox.Size = new System.Drawing.Size(288, 23);
            this.SEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.SEditBox.TabIndex = 0;
            this.SEditBox.UseSelectable = true;
            this.SEditBox.WaterMark = "Account Name Here";
            this.SEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.SEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.SEditBox_ButtonClick);
            this.SEditBox.TextChanged += new System.EventHandler(this.SEditBox_TextChanged);
            this.SEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SEditBox_KeyPress);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(5, 26);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(39, 19);
            this.metroLabel2.TabIndex = 24;
            this.metroLabel2.Text = "A/C :";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // txtSupplierClosingBalance
            // 
            // 
            // 
            // 
            this.txtSupplierClosingBalance.CustomButton.Image = null;
            this.txtSupplierClosingBalance.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.txtSupplierClosingBalance.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtSupplierClosingBalance.CustomButton.Name = "";
            this.txtSupplierClosingBalance.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSupplierClosingBalance.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSupplierClosingBalance.CustomButton.TabIndex = 1;
            this.txtSupplierClosingBalance.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSupplierClosingBalance.CustomButton.UseSelectable = true;
            this.txtSupplierClosingBalance.CustomButton.Visible = false;
            this.txtSupplierClosingBalance.Lines = new string[0];
            this.txtSupplierClosingBalance.Location = new System.Drawing.Point(459, 25);
            this.txtSupplierClosingBalance.MaxLength = 32767;
            this.txtSupplierClosingBalance.Name = "txtSupplierClosingBalance";
            this.txtSupplierClosingBalance.PasswordChar = '\0';
            this.txtSupplierClosingBalance.PromptText = "Closing Balace";
            this.txtSupplierClosingBalance.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSupplierClosingBalance.SelectedText = "";
            this.txtSupplierClosingBalance.SelectionLength = 0;
            this.txtSupplierClosingBalance.SelectionStart = 0;
            this.txtSupplierClosingBalance.ShortcutsEnabled = true;
            this.txtSupplierClosingBalance.Size = new System.Drawing.Size(131, 23);
            this.txtSupplierClosingBalance.TabIndex = 21;
            this.txtSupplierClosingBalance.UseSelectable = true;
            this.txtSupplierClosingBalance.WaterMark = "Closing Balace";
            this.txtSupplierClosingBalance.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSupplierClosingBalance.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabItems);
            this.tabMain.Controls.Add(this.tabTransactions);
            this.tabMain.Location = new System.Drawing.Point(3, 245);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1121, 331);
            this.tabMain.TabIndex = 29;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.txtTotalCredit);
            this.tabItems.Controls.Add(this.metroLabel6);
            this.tabItems.Controls.Add(this.txtFreightAmount);
            this.tabItems.Controls.Add(this.lblFreight);
            this.tabItems.Controls.Add(this.txtAmountAfterDiscount);
            this.tabItems.Controls.Add(this.metroLabel10);
            this.tabItems.Controls.Add(this.txtFlatDiscount);
            this.tabItems.Controls.Add(this.metroLabel9);
            this.tabItems.Controls.Add(this.txtTotalDiscount);
            this.tabItems.Controls.Add(this.metroLabel8);
            this.tabItems.Controls.Add(this.txtBillAmount);
            this.tabItems.Controls.Add(this.lblTotal);
            this.tabItems.Controls.Add(this.DgvStockReceipt);
            this.tabItems.Location = new System.Drawing.Point(4, 25);
            this.tabItems.Name = "tabItems";
            this.tabItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabItems.Size = new System.Drawing.Size(1113, 302);
            this.tabItems.TabIndex = 0;
            this.tabItems.Text = "Line Items";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // txtTotalCredit
            // 
            this.txtTotalCredit.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtTotalCredit.CustomButton.Image = null;
            this.txtTotalCredit.CustomButton.Location = new System.Drawing.Point(138, 1);
            this.txtTotalCredit.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalCredit.CustomButton.Name = "";
            this.txtTotalCredit.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTotalCredit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalCredit.CustomButton.TabIndex = 1;
            this.txtTotalCredit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalCredit.CustomButton.UseSelectable = true;
            this.txtTotalCredit.CustomButton.Visible = false;
            this.txtTotalCredit.Enabled = false;
            this.txtTotalCredit.Lines = new string[0];
            this.txtTotalCredit.Location = new System.Drawing.Point(947, 269);
            this.txtTotalCredit.MaxLength = 32767;
            this.txtTotalCredit.Name = "txtTotalCredit";
            this.txtTotalCredit.PasswordChar = '\0';
            this.txtTotalCredit.PromptText = "Total Credit";
            this.txtTotalCredit.ReadOnly = true;
            this.txtTotalCredit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalCredit.SelectedText = "";
            this.txtTotalCredit.SelectionLength = 0;
            this.txtTotalCredit.SelectionStart = 0;
            this.txtTotalCredit.ShortcutsEnabled = true;
            this.txtTotalCredit.Size = new System.Drawing.Size(160, 23);
            this.txtTotalCredit.TabIndex = 33;
            this.txtTotalCredit.UseCustomBackColor = true;
            this.txtTotalCredit.UseSelectable = true;
            this.txtTotalCredit.WaterMark = "Total Credit";
            this.txtTotalCredit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalCredit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(833, 267);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(87, 19);
            this.metroLabel6.TabIndex = 35;
            this.metroLabel6.Text = "Total Credit :";
            // 
            // txtFreightAmount
            // 
            this.txtFreightAmount.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtFreightAmount.CustomButton.Image = null;
            this.txtFreightAmount.CustomButton.Location = new System.Drawing.Point(138, 1);
            this.txtFreightAmount.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtFreightAmount.CustomButton.Name = "";
            this.txtFreightAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtFreightAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFreightAmount.CustomButton.TabIndex = 1;
            this.txtFreightAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFreightAmount.CustomButton.UseSelectable = true;
            this.txtFreightAmount.CustomButton.Visible = false;
            this.txtFreightAmount.Lines = new string[] {
        "0"};
            this.txtFreightAmount.Location = new System.Drawing.Point(947, 243);
            this.txtFreightAmount.MaxLength = 32767;
            this.txtFreightAmount.Name = "txtFreightAmount";
            this.txtFreightAmount.PasswordChar = '\0';
            this.txtFreightAmount.PromptText = "Total Freigh";
            this.txtFreightAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFreightAmount.SelectedText = "";
            this.txtFreightAmount.SelectionLength = 0;
            this.txtFreightAmount.SelectionStart = 0;
            this.txtFreightAmount.ShortcutsEnabled = true;
            this.txtFreightAmount.Size = new System.Drawing.Size(160, 23);
            this.txtFreightAmount.TabIndex = 31;
            this.txtFreightAmount.Text = "0";
            this.txtFreightAmount.UseCustomBackColor = true;
            this.txtFreightAmount.UseSelectable = true;
            this.txtFreightAmount.WaterMark = "Total Freigh";
            this.txtFreightAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFreightAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtFreightAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFreightAmount_KeyPress);
            this.txtFreightAmount.Leave += new System.EventHandler(this.txtFreightAmount_Leave);
            // 
            // lblFreight
            // 
            this.lblFreight.AutoSize = true;
            this.lblFreight.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblFreight.Location = new System.Drawing.Point(829, 244);
            this.lblFreight.Name = "lblFreight";
            this.lblFreight.Size = new System.Drawing.Size(113, 19);
            this.lblFreight.TabIndex = 36;
            this.lblFreight.Text = "Freight Amount :";
            // 
            // txtAmountAfterDiscount
            // 
            this.txtAmountAfterDiscount.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtAmountAfterDiscount.CustomButton.Image = null;
            this.txtAmountAfterDiscount.CustomButton.Location = new System.Drawing.Point(138, 1);
            this.txtAmountAfterDiscount.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmountAfterDiscount.CustomButton.Name = "";
            this.txtAmountAfterDiscount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAmountAfterDiscount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAmountAfterDiscount.CustomButton.TabIndex = 1;
            this.txtAmountAfterDiscount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAmountAfterDiscount.CustomButton.UseSelectable = true;
            this.txtAmountAfterDiscount.CustomButton.Visible = false;
            this.txtAmountAfterDiscount.Enabled = false;
            this.txtAmountAfterDiscount.Lines = new string[0];
            this.txtAmountAfterDiscount.Location = new System.Drawing.Point(947, 218);
            this.txtAmountAfterDiscount.MaxLength = 32767;
            this.txtAmountAfterDiscount.Name = "txtAmountAfterDiscount";
            this.txtAmountAfterDiscount.PasswordChar = '\0';
            this.txtAmountAfterDiscount.PromptText = "Amount After Discount";
            this.txtAmountAfterDiscount.ReadOnly = true;
            this.txtAmountAfterDiscount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAmountAfterDiscount.SelectedText = "";
            this.txtAmountAfterDiscount.SelectionLength = 0;
            this.txtAmountAfterDiscount.SelectionStart = 0;
            this.txtAmountAfterDiscount.ShortcutsEnabled = true;
            this.txtAmountAfterDiscount.Size = new System.Drawing.Size(160, 23);
            this.txtAmountAfterDiscount.TabIndex = 32;
            this.txtAmountAfterDiscount.UseCustomBackColor = true;
            this.txtAmountAfterDiscount.UseSelectable = true;
            this.txtAmountAfterDiscount.WaterMark = "Amount After Discount";
            this.txtAmountAfterDiscount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAmountAfterDiscount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Location = new System.Drawing.Point(812, 219);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(124, 19);
            this.metroLabel10.TabIndex = 34;
            this.metroLabel10.Text = "Discount Amount :";
            // 
            // txtFlatDiscount
            // 
            this.txtFlatDiscount.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtFlatDiscount.CustomButton.Image = null;
            this.txtFlatDiscount.CustomButton.Location = new System.Drawing.Point(139, 1);
            this.txtFlatDiscount.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtFlatDiscount.CustomButton.Name = "";
            this.txtFlatDiscount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtFlatDiscount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFlatDiscount.CustomButton.TabIndex = 1;
            this.txtFlatDiscount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFlatDiscount.CustomButton.UseSelectable = true;
            this.txtFlatDiscount.CustomButton.Visible = false;
            this.txtFlatDiscount.Enabled = false;
            this.txtFlatDiscount.Lines = new string[0];
            this.txtFlatDiscount.Location = new System.Drawing.Point(115, 268);
            this.txtFlatDiscount.MaxLength = 32767;
            this.txtFlatDiscount.Name = "txtFlatDiscount";
            this.txtFlatDiscount.PasswordChar = '\0';
            this.txtFlatDiscount.PromptText = "Flat Discount";
            this.txtFlatDiscount.ReadOnly = true;
            this.txtFlatDiscount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFlatDiscount.SelectedText = "";
            this.txtFlatDiscount.SelectionLength = 0;
            this.txtFlatDiscount.SelectionStart = 0;
            this.txtFlatDiscount.ShortcutsEnabled = true;
            this.txtFlatDiscount.Size = new System.Drawing.Size(161, 23);
            this.txtFlatDiscount.TabIndex = 27;
            this.txtFlatDiscount.UseCustomBackColor = true;
            this.txtFlatDiscount.UseSelectable = true;
            this.txtFlatDiscount.WaterMark = "Flat Discount";
            this.txtFlatDiscount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFlatDiscount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel9.Location = new System.Drawing.Point(5, 269);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(96, 19);
            this.metroLabel9.TabIndex = 29;
            this.metroLabel9.Text = "Flat Discount :";
            // 
            // txtTotalDiscount
            // 
            this.txtTotalDiscount.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtTotalDiscount.CustomButton.Image = null;
            this.txtTotalDiscount.CustomButton.Location = new System.Drawing.Point(139, 1);
            this.txtTotalDiscount.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalDiscount.CustomButton.Name = "";
            this.txtTotalDiscount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTotalDiscount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalDiscount.CustomButton.TabIndex = 1;
            this.txtTotalDiscount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalDiscount.CustomButton.UseSelectable = true;
            this.txtTotalDiscount.CustomButton.Visible = false;
            this.txtTotalDiscount.Enabled = false;
            this.txtTotalDiscount.Lines = new string[0];
            this.txtTotalDiscount.Location = new System.Drawing.Point(115, 243);
            this.txtTotalDiscount.MaxLength = 32767;
            this.txtTotalDiscount.Name = "txtTotalDiscount";
            this.txtTotalDiscount.PasswordChar = '\0';
            this.txtTotalDiscount.PromptText = "Total Discount";
            this.txtTotalDiscount.ReadOnly = true;
            this.txtTotalDiscount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalDiscount.SelectedText = "";
            this.txtTotalDiscount.SelectionLength = 0;
            this.txtTotalDiscount.SelectionStart = 0;
            this.txtTotalDiscount.ShortcutsEnabled = true;
            this.txtTotalDiscount.Size = new System.Drawing.Size(161, 23);
            this.txtTotalDiscount.TabIndex = 25;
            this.txtTotalDiscount.UseCustomBackColor = true;
            this.txtTotalDiscount.UseSelectable = true;
            this.txtTotalDiscount.WaterMark = "Total Discount";
            this.txtTotalDiscount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalDiscount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(5, 243);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(104, 19);
            this.metroLabel8.TabIndex = 30;
            this.metroLabel8.Text = "Total Discount :";
            // 
            // txtBillAmount
            // 
            this.txtBillAmount.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtBillAmount.CustomButton.Image = null;
            this.txtBillAmount.CustomButton.Location = new System.Drawing.Point(139, 1);
            this.txtBillAmount.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtBillAmount.CustomButton.Name = "";
            this.txtBillAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBillAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBillAmount.CustomButton.TabIndex = 1;
            this.txtBillAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBillAmount.CustomButton.UseSelectable = true;
            this.txtBillAmount.CustomButton.Visible = false;
            this.txtBillAmount.Enabled = false;
            this.txtBillAmount.Lines = new string[0];
            this.txtBillAmount.Location = new System.Drawing.Point(115, 219);
            this.txtBillAmount.MaxLength = 32767;
            this.txtBillAmount.Name = "txtBillAmount";
            this.txtBillAmount.PasswordChar = '\0';
            this.txtBillAmount.PromptText = "Total Bill Amount";
            this.txtBillAmount.ReadOnly = true;
            this.txtBillAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBillAmount.SelectedText = "";
            this.txtBillAmount.SelectionLength = 0;
            this.txtBillAmount.SelectionStart = 0;
            this.txtBillAmount.ShortcutsEnabled = true;
            this.txtBillAmount.Size = new System.Drawing.Size(161, 23);
            this.txtBillAmount.TabIndex = 26;
            this.txtBillAmount.UseCustomBackColor = true;
            this.txtBillAmount.UseSelectable = true;
            this.txtBillAmount.WaterMark = "Total Bill Amount";
            this.txtBillAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBillAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTotal.Location = new System.Drawing.Point(5, 219);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(87, 19);
            this.lblTotal.TabIndex = 28;
            this.lblTotal.Text = "Bill Amount :";
            // 
            // tabTransactions
            // 
            this.tabTransactions.Controls.Add(this.DgvPurchases);
            this.tabTransactions.Location = new System.Drawing.Point(4, 25);
            this.tabTransactions.Name = "tabTransactions";
            this.tabTransactions.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransactions.Size = new System.Drawing.Size(1113, 302);
            this.tabTransactions.TabIndex = 1;
            this.tabTransactions.Text = "Transactions";
            this.tabTransactions.UseVisualStyleBackColor = true;
            // 
            // lblVoucherStatus
            // 
            this.lblVoucherStatus.AutoSize = true;
            this.lblVoucherStatus.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblVoucherStatus.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblVoucherStatus.ForeColor = System.Drawing.Color.Red;
            this.lblVoucherStatus.Location = new System.Drawing.Point(3, 9);
            this.lblVoucherStatus.Name = "lblVoucherStatus";
            this.lblVoucherStatus.Size = new System.Drawing.Size(0, 0);
            this.lblVoucherStatus.TabIndex = 30;
            this.lblVoucherStatus.UseCustomForeColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.ActiveControl = null;
            this.btnPrint.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnPrint.Location = new System.Drawing.Point(916, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(123, 40);
            this.btnPrint.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print Voucher";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.UseCustomBackColor = true;
            this.btnPrint.UseSelectable = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.ActiveControl = null;
            this.btnPrevious.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnPrevious.Location = new System.Drawing.Point(610, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(101, 40);
            this.btnPrevious.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrevious.TabIndex = 7;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrevious.UseCustomBackColor = true;
            this.btnPrevious.UseSelectable = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.ActiveControl = null;
            this.btnNext.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnNext.Location = new System.Drawing.Point(712, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(101, 40);
            this.btnNext.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNext.UseCustomBackColor = true;
            this.btnNext.UseSelectable = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnNew
            // 
            this.btnNew.ActiveControl = null;
            this.btnNew.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnNew.Location = new System.Drawing.Point(814, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(101, 40);
            this.btnNew.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "New Voucher";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNew.UseCustomBackColor = true;
            this.btnNew.UseSelectable = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnClose.Location = new System.Drawing.Point(508, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 40);
            this.btnClose.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseCustomBackColor = true;
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ActiveControl = null;
            this.btnDelete.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnDelete.Location = new System.Drawing.Point(406, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 40);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.UseCustomBackColor = true;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.Location = new System.Drawing.Point(304, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 40);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseCustomBackColor = true;
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.lblVoucherStatus);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnPrint);
            this.pnlButtons.Controls.Add(this.btnPrevious);
            this.pnlButtons.Controls.Add(this.btnNext);
            this.pnlButtons.Controls.Add(this.btnNew);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Location = new System.Drawing.Point(3, 582);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1043, 44);
            this.pnlButtons.TabIndex = 31;
            // 
            // pnlFlow
            // 
            this.pnlFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFlow.Controls.Add(this.grpHeader);
            this.pnlFlow.Controls.Add(this.grpCreditor);
            this.pnlFlow.Controls.Add(this.grpPurchases);
            this.pnlFlow.Controls.Add(this.tabMain);
            this.pnlFlow.Controls.Add(this.pnlButtons);
            this.pnlFlow.Location = new System.Drawing.Point(7, 59);
            this.pnlFlow.Name = "pnlFlow";
            this.pnlFlow.Size = new System.Drawing.Size(1124, 642);
            this.pnlFlow.TabIndex = 32;
            // 
            // grpPurchases
            // 
            this.grpPurchases.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.grpPurchases.Controls.Add(this.rdCash);
            this.grpPurchases.Controls.Add(this.rdCredit);
            this.grpPurchases.Controls.Add(this.flowPurchasesPanel);
            this.grpPurchases.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPurchases.Location = new System.Drawing.Point(3, 155);
            this.grpPurchases.Name = "grpPurchases";
            this.grpPurchases.Size = new System.Drawing.Size(1121, 84);
            this.grpPurchases.TabIndex = 33;
            this.grpPurchases.TabStop = false;
            this.grpPurchases.Text = "Purchases Information";
            // 
            // rdCash
            // 
            this.rdCash.AutoSize = true;
            this.rdCash.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.rdCash.ForeColor = System.Drawing.Color.Black;
            this.rdCash.Location = new System.Drawing.Point(141, 63);
            this.rdCash.Name = "rdCash";
            this.rdCash.Size = new System.Drawing.Size(120, 19);
            this.rdCash.TabIndex = 30;
            this.rdCash.Text = "Cash Purchases";
            this.rdCash.UseCustomBackColor = true;
            this.rdCash.UseCustomForeColor = true;
            this.rdCash.UseSelectable = true;
            this.rdCash.CheckedChanged += new System.EventHandler(this.rdCash_CheckedChanged);
            this.rdCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdCash_KeyPress);
            // 
            // rdCredit
            // 
            this.rdCredit.AutoSize = true;
            this.rdCredit.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.rdCredit.ForeColor = System.Drawing.Color.Black;
            this.rdCredit.Location = new System.Drawing.Point(5, 61);
            this.rdCredit.Name = "rdCredit";
            this.rdCredit.Size = new System.Drawing.Size(127, 19);
            this.rdCredit.TabIndex = 29;
            this.rdCredit.Text = "Credit Purchases";
            this.rdCredit.UseCustomBackColor = true;
            this.rdCredit.UseCustomForeColor = true;
            this.rdCredit.UseSelectable = true;
            this.rdCredit.CheckedChanged += new System.EventHandler(this.rdCredit_CheckedChanged);
            this.rdCredit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdCredit_KeyPress);
            // 
            // flowPurchasesPanel
            // 
            this.flowPurchasesPanel.Controls.Add(this.pnlCash);
            this.flowPurchasesPanel.Controls.Add(this.panel2);
            this.flowPurchasesPanel.Location = new System.Drawing.Point(6, 17);
            this.flowPurchasesPanel.Name = "flowPurchasesPanel";
            this.flowPurchasesPanel.Size = new System.Drawing.Size(1001, 43);
            this.flowPurchasesPanel.TabIndex = 10;
            // 
            // pnlCash
            // 
            this.pnlCash.Controls.Add(this.metroLabel3);
            this.pnlCash.Controls.Add(this.btnAddCashAccount);
            this.pnlCash.Controls.Add(this.cbxCashAccounts);
            this.pnlCash.Location = new System.Drawing.Point(3, 3);
            this.pnlCash.Name = "pnlCash";
            this.pnlCash.Size = new System.Drawing.Size(420, 35);
            this.pnlCash.TabIndex = 10;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(6, 7);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(73, 19);
            this.metroLabel3.TabIndex = 24;
            this.metroLabel3.Text = "Cash A/C :";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // btnAddCashAccount
            // 
            this.btnAddCashAccount.Location = new System.Drawing.Point(301, 4);
            this.btnAddCashAccount.Name = "btnAddCashAccount";
            this.btnAddCashAccount.Size = new System.Drawing.Size(112, 29);
            this.btnAddCashAccount.TabIndex = 17;
            this.btnAddCashAccount.Text = "Add Cash Account";
            this.btnAddCashAccount.UseSelectable = true;
            // 
            // cbxCashAccounts
            // 
            this.cbxCashAccounts.FormattingEnabled = true;
            this.cbxCashAccounts.ItemHeight = 23;
            this.cbxCashAccounts.Location = new System.Drawing.Point(80, 4);
            this.cbxCashAccounts.Name = "cbxCashAccounts";
            this.cbxCashAccounts.Size = new System.Drawing.Size(218, 29);
            this.cbxCashAccounts.TabIndex = 0;
            this.cbxCashAccounts.UseSelectable = true;
            this.cbxCashAccounts.SelectedIndexChanged += new System.EventHandler(this.cbxCashAccounts_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbxNaturalAccounts);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.metroLabel1);
            this.panel2.Controls.Add(this.btnAddPurchasesAccount);
            this.panel2.Location = new System.Drawing.Point(429, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 37);
            this.panel2.TabIndex = 10;
            // 
            // cbxNaturalAccounts
            // 
            this.cbxNaturalAccounts.FormattingEnabled = true;
            this.cbxNaturalAccounts.ItemHeight = 23;
            this.cbxNaturalAccounts.Location = new System.Drawing.Point(83, 5);
            this.cbxNaturalAccounts.Name = "cbxNaturalAccounts";
            this.cbxNaturalAccounts.Size = new System.Drawing.Size(217, 29);
            this.cbxNaturalAccounts.TabIndex = 0;
            this.cbxNaturalAccounts.UseSelectable = true;
            this.cbxNaturalAccounts.SelectedIndexChanged += new System.EventHandler(this.cbxNaturalAccounts_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(449, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 29);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(3, 8);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(76, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Debit A/C :";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // btnAddPurchasesAccount
            // 
            this.btnAddPurchasesAccount.Location = new System.Drawing.Point(304, 4);
            this.btnAddPurchasesAccount.Name = "btnAddPurchasesAccount";
            this.btnAddPurchasesAccount.Size = new System.Drawing.Size(143, 29);
            this.btnAddPurchasesAccount.TabIndex = 17;
            this.btnAddPurchasesAccount.Text = "Add Inventory Account";
            this.btnAddPurchasesAccount.UseSelectable = true;
            // 
            // DgvStockReceipt
            // 
            this.DgvStockReceipt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Beige;
            this.DgvStockReceipt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DgvStockReceipt.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvStockReceipt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvStockReceipt.ColumnHeadersHeight = 25;
            this.DgvStockReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStockReceiptID,
            this.colIdItem,
            this.colItemNo,
            this.colItemName,
            this.colpacking,
            this.colQty,
            this.colBonus,
            this.colUnitPrice,
            this.colAmount,
            this.colDiscount,
            this.colDiscAmount,
            this.colFlatDiscount,
            this.colDiscountAmount,
            this.colDelete});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvStockReceipt.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvStockReceipt.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DgvStockReceipt.EnableHeadersVisualStyles = false;
            this.DgvStockReceipt.Location = new System.Drawing.Point(4, 6);
            this.DgvStockReceipt.MultiSelect = false;
            this.DgvStockReceipt.Name = "DgvStockReceipt";
            this.DgvStockReceipt.RowHeadersVisible = false;
            this.DgvStockReceipt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvStockReceipt.Size = new System.Drawing.Size(1103, 206);
            this.DgvStockReceipt.TabIndex = 3;
            this.DgvStockReceipt.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvStockReceipt_CellBeginEdit);
            this.DgvStockReceipt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvStockReceipt_CellClick);
            this.DgvStockReceipt.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvStockReceipt_CellEndEdit);
            this.DgvStockReceipt.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvStockReceipt_CellEnter);
            this.DgvStockReceipt.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvStockReceipt_CellFormatting);
            this.DgvStockReceipt.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvStockReceipt_CellLeave);
            this.DgvStockReceipt.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvStockReceipt_EditingControlShowing);
            this.DgvStockReceipt.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvStockReceipt_RowValidating);
            this.DgvStockReceipt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvStockReceipt_KeyDown);
            this.DgvStockReceipt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DgvStockReceipt_KeyPress);
            // 
            // colStockReceiptID
            // 
            this.colStockReceiptID.HeaderText = "StockReceiptId";
            this.colStockReceiptID.Name = "colStockReceiptID";
            this.colStockReceiptID.Visible = false;
            // 
            // colIdItem
            // 
            this.colIdItem.HeaderText = "IdItem";
            this.colIdItem.Name = "colIdItem";
            this.colIdItem.Visible = false;
            // 
            // colItemNo
            // 
            this.colItemNo.DataPropertyName = "AccountNo";
            this.colItemNo.HeaderText = "Product Code";
            this.colItemNo.Name = "colItemNo";
            this.colItemNo.Visible = false;
            // 
            // colItemName
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colItemName.DefaultCellStyle = dataGridViewCellStyle10;
            this.colItemName.HeaderText = "Product Discription";
            this.colItemName.Name = "colItemName";
            this.colItemName.WatermarkText = "Type Here For Product Selection";
            this.colItemName.Width = 300;
            // 
            // colpacking
            // 
            this.colpacking.HeaderText = "Uom";
            this.colpacking.Name = "colpacking";
            this.colpacking.ReadOnly = true;
            this.colpacking.Width = 80;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            this.colQty.HeaderText = "Quantity";
            this.colQty.Name = "colQty";
            this.colQty.Width = 80;
            // 
            // colBonus
            // 
            this.colBonus.HeaderText = "Bonus";
            this.colBonus.Name = "colBonus";
            this.colBonus.Width = 80;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "Amount";
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Width = 80;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "qty*amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAmount.Width = 90;
            // 
            // colDiscount
            // 
            this.colDiscount.HeaderText = "Disc(%)";
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.Width = 60;
            // 
            // colDiscAmount
            // 
            this.colDiscAmount.HeaderText = "Discount";
            this.colDiscAmount.Name = "colDiscAmount";
            this.colDiscAmount.Width = 70;
            // 
            // colFlatDiscount
            // 
            this.colFlatDiscount.HeaderText = "Flat Disc";
            this.colFlatDiscount.Name = "colFlatDiscount";
            this.colFlatDiscount.Width = 70;
            // 
            // colDiscountAmount
            // 
            this.colDiscountAmount.HeaderText = "Net Amount";
            this.colDiscountAmount.Name = "colDiscountAmount";
            this.colDiscountAmount.Width = 110;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "...";
            this.colDelete.Name = "colDelete";
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDelete.Width = 60;
            // 
            // DgvPurchases
            // 
            this.DgvPurchases.AllowUserToDeleteRows = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvPurchases.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DgvPurchases.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPurchases.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.DgvPurchases.ColumnHeadersHeight = 25;
            this.DgvPurchases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHeadType,
            this.ColTransaction,
            this.ColIdDetailVoucher,
            this.colIdAccount,
            this.colAccountNo,
            this.colLinkAccount,
            this.colAccountName,
            this.colClosingBalance,
            this.colDescription,
            this.colDebit,
            this.colCredit});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvPurchases.DefaultCellStyle = dataGridViewCellStyle14;
            this.DgvPurchases.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DgvPurchases.EnableHeadersVisualStyles = false;
            this.DgvPurchases.Location = new System.Drawing.Point(3, 6);
            this.DgvPurchases.MultiSelect = false;
            this.DgvPurchases.Name = "DgvPurchases";
            this.DgvPurchases.RowHeadersVisible = false;
            this.DgvPurchases.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvPurchases.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvPurchases.Size = new System.Drawing.Size(957, 254);
            this.DgvPurchases.TabIndex = 25;
            this.DgvPurchases.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPurchases_CellEndEdit);
            this.DgvPurchases.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPurchases_CellLeave);
            this.DgvPurchases.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvPurchases_EditingControlShowing);
            // 
            // colHeadType
            // 
            this.colHeadType.HeaderText = "HeadType";
            this.colHeadType.Name = "colHeadType";
            this.colHeadType.Visible = false;
            // 
            // ColTransaction
            // 
            this.ColTransaction.DataPropertyName = "TransactionID";
            this.ColTransaction.HeaderText = "TransactionId";
            this.ColTransaction.Name = "ColTransaction";
            this.ColTransaction.Visible = false;
            // 
            // ColIdDetailVoucher
            // 
            this.ColIdDetailVoucher.HeaderText = "VoucherDetailId";
            this.ColIdDetailVoucher.Name = "ColIdDetailVoucher";
            this.ColIdDetailVoucher.Visible = false;
            // 
            // colIdAccount
            // 
            this.colIdAccount.HeaderText = "AccountId";
            this.colIdAccount.Name = "colIdAccount";
            this.colIdAccount.Visible = false;
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "AccountNo";
            this.colAccountNo.HeaderText = "Acc. #";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.Visible = false;
            // 
            // colLinkAccount
            // 
            this.colLinkAccount.HeaderText = "Link Acc. #";
            this.colLinkAccount.Name = "colLinkAccount";
            this.colLinkAccount.Visible = false;
            // 
            // colAccountName
            // 
            this.colAccountName.HeaderText = "A/C Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.Width = 240;
            // 
            // colClosingBalance
            // 
            this.colClosingBalance.HeaderText = "Closing Balance";
            this.colClosingBalance.Name = "colClosingBalance";
            this.colClosingBalance.ReadOnly = true;
            this.colClosingBalance.Width = 120;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Narration";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 290;
            // 
            // colDebit
            // 
            this.colDebit.HeaderText = "Debit";
            this.colDebit.Name = "colDebit";
            this.colDebit.Width = 150;
            // 
            // colCredit
            // 
            this.colCredit.HeaderText = "Credit";
            this.colCredit.Name = "colCredit";
            this.colCredit.Width = 150;
            // 
            // frmStockReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1138, 720);
            this.Controls.Add(this.pnlFlow);
            this.DoubleBuffered = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(10, 571);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStockReceipt";
            this.Text = "Stock Receipt Note";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmStockReceipt_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmStockReceipt_KeyPress);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpCreditor.ResumeLayout(false);
            this.grpCreditor.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabItems.ResumeLayout(false);
            this.tabItems.PerformLayout();
            this.tabTransactions.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.pnlFlow.ResumeLayout(false);
            this.grpPurchases.ResumeLayout(false);
            this.grpPurchases.PerformLayout();
            this.flowPurchasesPanel.ResumeLayout(false);
            this.pnlCash.ResumeLayout(false);
            this.pnlCash.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStockReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPurchases)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.DataGridView DgvStockReceipt;
        private System.Windows.Forms.GroupBox grpHeader;
        private MetroFramework.Controls.MetroTextBox txtContact;
        private MetroFramework.Controls.MetroLabel lblDiscription;
        private MetroFramework.Controls.MetroLabel lblBillNo;
        private MetroFramework.Controls.MetroLabel lblVoucherNo;
        private MetroFramework.Controls.MetroLabel lblDate;
        private MetroFramework.Controls.MetroCheckBox chkPosted;
        private MetroFramework.Controls.MetroTextBox txtBillNo;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroTextBox VEditBox;
        private MetroFramework.Controls.MetroDateTime VDate;
        private System.Windows.Forms.GroupBox grpCreditor;
        private MetroFramework.Controls.MetroTextBox SEditBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private TabDataGrid DgvPurchases;
        private MetroFramework.Controls.MetroComboBox cbxPurchaser;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeadType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdDetailVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinkAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClosingBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCredit;
        private TabDataGrid DgvStockReceipt;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.TabPage tabTransactions;
        private MetroFramework.Controls.MetroButton btnViewLedger;
        private MetroFramework.Controls.MetroButton btnViewDetail;
        private MetroFramework.Controls.MetroTextBox txtSupplierClosingBalance;
        private MetroFramework.Controls.MetroLabel lblVoucherStatus;
        private MetroFramework.Controls.MetroTile btnPrint;
        private MetroFramework.Controls.MetroTile btnPrevious;
        private MetroFramework.Controls.MetroTile btnNext;
        private MetroFramework.Controls.MetroTile btnNew;
        private MetroFramework.Controls.MetroTile btnClose;
        private MetroFramework.Controls.MetroTile btnDelete;
        private MetroFramework.Controls.MetroTile btnSave;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.FlowLayoutPanel pnlFlow;
        private System.Windows.Forms.GroupBox grpPurchases;
        private System.Windows.Forms.FlowLayoutPanel flowPurchasesPanel;
        private System.Windows.Forms.Panel pnlCash;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton btnAddCashAccount;
        private MetroFramework.Controls.MetroComboBox cbxCashAccounts;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroComboBox cbxNaturalAccounts;
        private MetroFramework.Controls.MetroButton btnRefresh;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnAddPurchasesAccount;
        private MetroFramework.Controls.MetroLabel lblPoNumber;
        private MetroFramework.Controls.MetroTextBox txtPoNumber;
        private MetroFramework.Controls.MetroTextBox txtTotalCredit;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtFreightAmount;
        private MetroFramework.Controls.MetroLabel lblFreight;
        private MetroFramework.Controls.MetroTextBox txtAmountAfterDiscount;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox txtFlatDiscount;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox txtTotalDiscount;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtBillAmount;
        private MetroFramework.Controls.MetroLabel lblTotal;
        private MetroFramework.Controls.MetroRadioButton rdCash;
        private MetroFramework.Controls.MetroRadioButton rdCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockReceiptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemNo;
        private DataGridViewProductWaterMarkColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpacking;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFlatDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscountAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}