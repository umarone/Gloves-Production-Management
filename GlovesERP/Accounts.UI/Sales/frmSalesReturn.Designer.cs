namespace Accounts.UI
{
    partial class frmSalesReturn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatuMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalBalance = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VDate = new MetroFramework.Controls.MetroDateTime();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.InvEditBox = new MetroFramework.Controls.MetroTextBox();
            this.txtOutWardGatePass = new MetroFramework.Controls.MetroTextBox();
            this.txtGatePass = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.chkPosted = new System.Windows.Forms.CheckBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtSaleMemoNo = new MetroFramework.Controls.MetroTextBox();
            this.lblInvoiceNo = new MetroFramework.Controls.MetroLabel();
            this.lblDiscription = new MetroFramework.Controls.MetroLabel();
            this.lblDate = new MetroFramework.Controls.MetroLabel();
            this.lblVoucherNo = new MetroFramework.Controls.MetroLabel();
            this.txtContact = new MetroFramework.Controls.MetroTextBox();
            this.txtAddress = new MetroFramework.Controls.MetroTextBox();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.txtNTN = new MetroFramework.Controls.MetroTextBox();
            this.btnPrint = new MetroFramework.Controls.MetroTile();
            this.txtCustomerName = new MetroFramework.Controls.MetroTextBox();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.CustEditBox = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.txtTotalAmount = new MetroFramework.Controls.MetroTextBox();
            this.txtEmployeeContact = new MetroFramework.Controls.MetroTextBox();
            this.txtEmployeeName = new MetroFramework.Controls.MetroTextBox();
            this.EmpEditCode = new MetroFramework.Controls.MetroTextBox();
            this.lblAccountNo = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.txtEmployeeNTN = new MetroFramework.Controls.MetroTextBox();
            this.btnPrevious = new MetroFramework.Controls.MetroTile();
            this.btnNewVoucher = new MetroFramework.Controls.MetroTile();
            this.btnNext = new MetroFramework.Controls.MetroTile();
            this.grpSales = new System.Windows.Forms.GroupBox();
            this.cbxReturnType = new MetroFramework.Controls.MetroComboBox();
            this.cbxNaturalAccounts = new MetroFramework.Controls.MetroComboBox();
            this.lblReturnType = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SalesEditBox = new MetroFramework.Controls.MetroTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.DgvSaleInvoice = new Accounts.UI.TabDataGrid();
            this.colSale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblVAT = new System.Windows.Forms.Label();
            this.txtVAT = new MetroFramework.Controls.MetroTextBox();
            this.lblVATAmount = new System.Windows.Forms.Label();
            this.txtVATAmount = new MetroFramework.Controls.MetroTextBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpSales.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSaleInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatuMessage});
            this.statusStrip1.Location = new System.Drawing.Point(20, 617);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1136, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatuMessage
            // 
            this.lblStatuMessage.Name = "lblStatuMessage";
            this.lblStatuMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // lblTotalBalance
            // 
            this.lblTotalBalance.AutoSize = true;
            this.lblTotalBalance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTotalBalance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBalance.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblTotalBalance.Location = new System.Drawing.Point(918, 483);
            this.lblTotalBalance.Name = "lblTotalBalance";
            this.lblTotalBalance.Size = new System.Drawing.Size(93, 17);
            this.lblTotalBalance.TabIndex = 17;
            this.lblTotalBalance.Text = "Total Amount :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.VDate);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.InvEditBox);
            this.groupBox1.Controls.Add(this.txtOutWardGatePass);
            this.groupBox1.Controls.Add(this.txtGatePass);
            this.groupBox1.Controls.Add(this.metroLabel9);
            this.groupBox1.Controls.Add(this.chkPosted);
            this.groupBox1.Controls.Add(this.metroLabel8);
            this.groupBox1.Controls.Add(this.txtSaleMemoNo);
            this.groupBox1.Controls.Add(this.lblInvoiceNo);
            this.groupBox1.Controls.Add(this.lblDiscription);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblVoucherNo);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 222);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice Information";
            // 
            // VDate
            // 
            this.VDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.VDate.Location = new System.Drawing.Point(94, 52);
            this.VDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.VDate.Name = "VDate";
            this.VDate.Size = new System.Drawing.Size(164, 29);
            this.VDate.TabIndex = 24;
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(299, 2);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(101, 101);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(94, 110);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(403, 106);
            this.txtDescription.TabIndex = 24;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // InvEditBox
            // 
            // 
            // 
            // 
            this.InvEditBox.CustomButton.Image = null;
            this.InvEditBox.CustomButton.Location = new System.Drawing.Point(142, 1);
            this.InvEditBox.CustomButton.Name = "";
            this.InvEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.InvEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.InvEditBox.CustomButton.TabIndex = 1;
            this.InvEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.InvEditBox.CustomButton.UseSelectable = true;
            this.InvEditBox.Lines = new string[0];
            this.InvEditBox.Location = new System.Drawing.Point(94, 27);
            this.InvEditBox.MaxLength = 32767;
            this.InvEditBox.Name = "InvEditBox";
            this.InvEditBox.PasswordChar = '\0';
            this.InvEditBox.PromptText = "Voucher No Here";
            this.InvEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.InvEditBox.SelectedText = "";
            this.InvEditBox.SelectionLength = 0;
            this.InvEditBox.SelectionStart = 0;
            this.InvEditBox.ShortcutsEnabled = true;
            this.InvEditBox.ShowButton = true;
            this.InvEditBox.Size = new System.Drawing.Size(164, 23);
            this.InvEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.InvEditBox.TabIndex = 24;
            this.InvEditBox.UseSelectable = true;
            this.InvEditBox.WaterMark = "Voucher No Here";
            this.InvEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.InvEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.InvEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.InvEditBox_ButtonClick);
            this.InvEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InvEditBox_KeyPress);
            // 
            // txtOutWardGatePass
            // 
            // 
            // 
            // 
            this.txtOutWardGatePass.CustomButton.Image = null;
            this.txtOutWardGatePass.CustomButton.Location = new System.Drawing.Point(148, 1);
            this.txtOutWardGatePass.CustomButton.Name = "";
            this.txtOutWardGatePass.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtOutWardGatePass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOutWardGatePass.CustomButton.TabIndex = 1;
            this.txtOutWardGatePass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOutWardGatePass.CustomButton.UseSelectable = true;
            this.txtOutWardGatePass.CustomButton.Visible = false;
            this.txtOutWardGatePass.Lines = new string[0];
            this.txtOutWardGatePass.Location = new System.Drawing.Point(327, 53);
            this.txtOutWardGatePass.MaxLength = 32767;
            this.txtOutWardGatePass.Name = "txtOutWardGatePass";
            this.txtOutWardGatePass.PasswordChar = '\0';
            this.txtOutWardGatePass.PromptText = "OutWard Gate Pass";
            this.txtOutWardGatePass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOutWardGatePass.SelectedText = "";
            this.txtOutWardGatePass.SelectionLength = 0;
            this.txtOutWardGatePass.SelectionStart = 0;
            this.txtOutWardGatePass.ShortcutsEnabled = true;
            this.txtOutWardGatePass.Size = new System.Drawing.Size(170, 23);
            this.txtOutWardGatePass.TabIndex = 24;
            this.txtOutWardGatePass.UseSelectable = true;
            this.txtOutWardGatePass.WaterMark = "OutWard Gate Pass";
            this.txtOutWardGatePass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOutWardGatePass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtGatePass
            // 
            // 
            // 
            // 
            this.txtGatePass.CustomButton.Image = null;
            this.txtGatePass.CustomButton.Location = new System.Drawing.Point(148, 1);
            this.txtGatePass.CustomButton.Name = "";
            this.txtGatePass.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtGatePass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtGatePass.CustomButton.TabIndex = 1;
            this.txtGatePass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtGatePass.CustomButton.UseSelectable = true;
            this.txtGatePass.CustomButton.Visible = false;
            this.txtGatePass.Lines = new string[0];
            this.txtGatePass.Location = new System.Drawing.Point(327, 26);
            this.txtGatePass.MaxLength = 32767;
            this.txtGatePass.Name = "txtGatePass";
            this.txtGatePass.PasswordChar = '\0';
            this.txtGatePass.PromptText = "Inward Gate Pass";
            this.txtGatePass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtGatePass.SelectedText = "";
            this.txtGatePass.SelectionLength = 0;
            this.txtGatePass.SelectionStart = 0;
            this.txtGatePass.ShortcutsEnabled = true;
            this.txtGatePass.Size = new System.Drawing.Size(170, 23);
            this.txtGatePass.TabIndex = 24;
            this.txtGatePass.UseSelectable = true;
            this.txtGatePass.WaterMark = "Inward Gate Pass";
            this.txtGatePass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtGatePass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(275, 53);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(44, 19);
            this.metroLabel9.TabIndex = 24;
            this.metroLabel9.Text = "OGP :";
            // 
            // chkPosted
            // 
            this.chkPosted.AutoSize = true;
            this.chkPosted.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPosted.ForeColor = System.Drawing.Color.Red;
            this.chkPosted.Location = new System.Drawing.Point(327, 83);
            this.chkPosted.Name = "chkPosted";
            this.chkPosted.Size = new System.Drawing.Size(76, 25);
            this.chkPosted.TabIndex = 15;
            this.chkPosted.Text = "Posted";
            this.chkPosted.UseVisualStyleBackColor = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(283, 27);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(36, 19);
            this.metroLabel8.TabIndex = 24;
            this.metroLabel8.Text = "IGP :";
            // 
            // txtSaleMemoNo
            // 
            // 
            // 
            // 
            this.txtSaleMemoNo.CustomButton.Image = null;
            this.txtSaleMemoNo.CustomButton.Location = new System.Drawing.Point(142, 1);
            this.txtSaleMemoNo.CustomButton.Name = "";
            this.txtSaleMemoNo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSaleMemoNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSaleMemoNo.CustomButton.TabIndex = 1;
            this.txtSaleMemoNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSaleMemoNo.CustomButton.UseSelectable = true;
            this.txtSaleMemoNo.CustomButton.Visible = false;
            this.txtSaleMemoNo.Lines = new string[0];
            this.txtSaleMemoNo.Location = new System.Drawing.Point(94, 83);
            this.txtSaleMemoNo.MaxLength = 32767;
            this.txtSaleMemoNo.Name = "txtSaleMemoNo";
            this.txtSaleMemoNo.PasswordChar = '\0';
            this.txtSaleMemoNo.PromptText = "Invoice No";
            this.txtSaleMemoNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSaleMemoNo.SelectedText = "";
            this.txtSaleMemoNo.SelectionLength = 0;
            this.txtSaleMemoNo.SelectionStart = 0;
            this.txtSaleMemoNo.ShortcutsEnabled = true;
            this.txtSaleMemoNo.Size = new System.Drawing.Size(164, 23);
            this.txtSaleMemoNo.TabIndex = 0;
            this.txtSaleMemoNo.UseSelectable = true;
            this.txtSaleMemoNo.WaterMark = "Invoice No";
            this.txtSaleMemoNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSaleMemoNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSaleMemoNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaleMemoNo_KeyPress);
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(9, 83);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(78, 19);
            this.lblInvoiceNo.TabIndex = 24;
            this.lblInvoiceNo.Text = "Invoice No :";
            // 
            // lblDiscription
            // 
            this.lblDiscription.AutoSize = true;
            this.lblDiscription.Location = new System.Drawing.Point(9, 123);
            this.lblDiscription.Name = "lblDiscription";
            this.lblDiscription.Size = new System.Drawing.Size(81, 19);
            this.lblDiscription.TabIndex = 24;
            this.lblDiscription.Text = "Description :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 53);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(43, 19);
            this.lblDate.TabIndex = 24;
            this.lblDate.Text = "Date :";
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Location = new System.Drawing.Point(9, 26);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(86, 19);
            this.lblVoucherNo.TabIndex = 24;
            this.lblVoucherNo.Text = "Voucher No :";
            // 
            // txtContact
            // 
            // 
            // 
            // 
            this.txtContact.CustomButton.Image = null;
            this.txtContact.CustomButton.Location = new System.Drawing.Point(106, 1);
            this.txtContact.CustomButton.Name = "";
            this.txtContact.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtContact.CustomButton.TabIndex = 1;
            this.txtContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtContact.CustomButton.UseSelectable = true;
            this.txtContact.CustomButton.Visible = false;
            this.txtContact.Lines = new string[0];
            this.txtContact.Location = new System.Drawing.Point(348, 23);
            this.txtContact.MaxLength = 32767;
            this.txtContact.Name = "txtContact";
            this.txtContact.PasswordChar = '\0';
            this.txtContact.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContact.SelectedText = "";
            this.txtContact.SelectionLength = 0;
            this.txtContact.SelectionStart = 0;
            this.txtContact.ShortcutsEnabled = true;
            this.txtContact.Size = new System.Drawing.Size(128, 23);
            this.txtContact.TabIndex = 24;
            this.txtContact.UseSelectable = true;
            this.txtContact.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContact.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtAddress
            // 
            // 
            // 
            // 
            this.txtAddress.CustomButton.Image = null;
            this.txtAddress.CustomButton.Location = new System.Drawing.Point(535, 2);
            this.txtAddress.CustomButton.Name = "";
            this.txtAddress.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAddress.CustomButton.TabIndex = 1;
            this.txtAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAddress.CustomButton.UseSelectable = true;
            this.txtAddress.CustomButton.Visible = false;
            this.txtAddress.Lines = new string[0];
            this.txtAddress.Location = new System.Drawing.Point(74, 52);
            this.txtAddress.MaxLength = 32767;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAddress.SelectedText = "";
            this.txtAddress.SelectionLength = 0;
            this.txtAddress.SelectionStart = 0;
            this.txtAddress.ShortcutsEnabled = true;
            this.txtAddress.Size = new System.Drawing.Size(563, 30);
            this.txtAddress.TabIndex = 24;
            this.txtAddress.UseSelectable = true;
            this.txtAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.Location = new System.Drawing.Point(689, 570);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 35);
            this.btnClose.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtNTN
            // 
            // 
            // 
            // 
            this.txtNTN.CustomButton.Image = null;
            this.txtNTN.CustomButton.Location = new System.Drawing.Point(134, 1);
            this.txtNTN.CustomButton.Name = "";
            this.txtNTN.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNTN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNTN.CustomButton.TabIndex = 1;
            this.txtNTN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNTN.CustomButton.UseSelectable = true;
            this.txtNTN.CustomButton.Visible = false;
            this.txtNTN.Lines = new string[0];
            this.txtNTN.Location = new System.Drawing.Point(482, 23);
            this.txtNTN.MaxLength = 32767;
            this.txtNTN.Name = "txtNTN";
            this.txtNTN.PasswordChar = '\0';
            this.txtNTN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNTN.SelectedText = "";
            this.txtNTN.SelectionLength = 0;
            this.txtNTN.SelectionStart = 0;
            this.txtNTN.ShortcutsEnabled = true;
            this.txtNTN.Size = new System.Drawing.Size(156, 23);
            this.txtNTN.TabIndex = 24;
            this.txtNTN.UseSelectable = true;
            this.txtNTN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNTN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnPrint
            // 
            this.btnPrint.ActiveControl = null;
            this.btnPrint.Location = new System.Drawing.Point(573, 570);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(115, 35);
            this.btnPrint.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.UseSelectable = true;
            // 
            // txtCustomerName
            // 
            // 
            // 
            // 
            this.txtCustomerName.CustomButton.Image = null;
            this.txtCustomerName.CustomButton.Location = new System.Drawing.Point(114, 1);
            this.txtCustomerName.CustomButton.Name = "";
            this.txtCustomerName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCustomerName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCustomerName.CustomButton.TabIndex = 1;
            this.txtCustomerName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCustomerName.CustomButton.UseSelectable = true;
            this.txtCustomerName.CustomButton.Visible = false;
            this.txtCustomerName.Lines = new string[0];
            this.txtCustomerName.Location = new System.Drawing.Point(206, 23);
            this.txtCustomerName.MaxLength = 32767;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PasswordChar = '\0';
            this.txtCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCustomerName.SelectedText = "";
            this.txtCustomerName.SelectionLength = 0;
            this.txtCustomerName.SelectionStart = 0;
            this.txtCustomerName.ShortcutsEnabled = true;
            this.txtCustomerName.Size = new System.Drawing.Size(136, 23);
            this.txtCustomerName.TabIndex = 24;
            this.txtCustomerName.UseSelectable = true;
            this.txtCustomerName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCustomerName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnDelete
            // 
            this.btnDelete.ActiveControl = null;
            this.btnDelete.Location = new System.Drawing.Point(457, 570);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 35);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // CustEditBox
            // 
            // 
            // 
            // 
            this.CustEditBox.CustomButton.Image = null;
            this.CustEditBox.CustomButton.Location = new System.Drawing.Point(104, 1);
            this.CustEditBox.CustomButton.Name = "";
            this.CustEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CustEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CustEditBox.CustomButton.TabIndex = 1;
            this.CustEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CustEditBox.CustomButton.UseSelectable = true;
            this.CustEditBox.Lines = new string[0];
            this.CustEditBox.Location = new System.Drawing.Point(74, 24);
            this.CustEditBox.MaxLength = 32767;
            this.CustEditBox.Name = "CustEditBox";
            this.CustEditBox.PasswordChar = '\0';
            this.CustEditBox.PromptText = "Account No Here";
            this.CustEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CustEditBox.SelectedText = "";
            this.CustEditBox.SelectionLength = 0;
            this.CustEditBox.SelectionStart = 0;
            this.CustEditBox.ShortcutsEnabled = true;
            this.CustEditBox.ShowButton = true;
            this.CustEditBox.Size = new System.Drawing.Size(126, 23);
            this.CustEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.CustEditBox.TabIndex = 0;
            this.CustEditBox.UseSelectable = true;
            this.CustEditBox.WaterMark = "Account No Here";
            this.CustEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CustEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.CustEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.CustEditBox_ButtonClick);
            this.CustEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustEditBox_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(341, 570);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 35);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTotalAmount
            // 
            // 
            // 
            // 
            this.txtTotalAmount.CustomButton.Image = null;
            this.txtTotalAmount.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.txtTotalAmount.CustomButton.Name = "";
            this.txtTotalAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTotalAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalAmount.CustomButton.TabIndex = 1;
            this.txtTotalAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalAmount.CustomButton.UseSelectable = true;
            this.txtTotalAmount.CustomButton.Visible = false;
            this.txtTotalAmount.Lines = new string[0];
            this.txtTotalAmount.Location = new System.Drawing.Point(1014, 481);
            this.txtTotalAmount.MaxLength = 32767;
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.PasswordChar = '\0';
            this.txtTotalAmount.PromptText = "Total Amount";
            this.txtTotalAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalAmount.SelectedText = "";
            this.txtTotalAmount.SelectionLength = 0;
            this.txtTotalAmount.SelectionStart = 0;
            this.txtTotalAmount.ShortcutsEnabled = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(138, 23);
            this.txtTotalAmount.TabIndex = 24;
            this.txtTotalAmount.UseSelectable = true;
            this.txtTotalAmount.WaterMark = "Total Amount";
            this.txtTotalAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtEmployeeContact
            // 
            // 
            // 
            // 
            this.txtEmployeeContact.CustomButton.Image = null;
            this.txtEmployeeContact.CustomButton.Location = new System.Drawing.Point(106, 1);
            this.txtEmployeeContact.CustomButton.Name = "";
            this.txtEmployeeContact.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtEmployeeContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEmployeeContact.CustomButton.TabIndex = 1;
            this.txtEmployeeContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEmployeeContact.CustomButton.UseSelectable = true;
            this.txtEmployeeContact.CustomButton.Visible = false;
            this.txtEmployeeContact.Lines = new string[0];
            this.txtEmployeeContact.Location = new System.Drawing.Point(348, 14);
            this.txtEmployeeContact.MaxLength = 32767;
            this.txtEmployeeContact.Name = "txtEmployeeContact";
            this.txtEmployeeContact.PasswordChar = '\0';
            this.txtEmployeeContact.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmployeeContact.SelectedText = "";
            this.txtEmployeeContact.SelectionLength = 0;
            this.txtEmployeeContact.SelectionStart = 0;
            this.txtEmployeeContact.ShortcutsEnabled = true;
            this.txtEmployeeContact.Size = new System.Drawing.Size(128, 23);
            this.txtEmployeeContact.TabIndex = 2;
            this.txtEmployeeContact.UseSelectable = true;
            this.txtEmployeeContact.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEmployeeContact.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtEmployeeName
            // 
            // 
            // 
            // 
            this.txtEmployeeName.CustomButton.Image = null;
            this.txtEmployeeName.CustomButton.Location = new System.Drawing.Point(113, 1);
            this.txtEmployeeName.CustomButton.Name = "";
            this.txtEmployeeName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtEmployeeName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEmployeeName.CustomButton.TabIndex = 1;
            this.txtEmployeeName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEmployeeName.CustomButton.UseSelectable = true;
            this.txtEmployeeName.CustomButton.Visible = false;
            this.txtEmployeeName.Lines = new string[0];
            this.txtEmployeeName.Location = new System.Drawing.Point(207, 14);
            this.txtEmployeeName.MaxLength = 32767;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.PasswordChar = '\0';
            this.txtEmployeeName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmployeeName.SelectedText = "";
            this.txtEmployeeName.SelectionLength = 0;
            this.txtEmployeeName.SelectionStart = 0;
            this.txtEmployeeName.ShortcutsEnabled = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(135, 23);
            this.txtEmployeeName.TabIndex = 1;
            this.txtEmployeeName.UseSelectable = true;
            this.txtEmployeeName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEmployeeName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // EmpEditCode
            // 
            // 
            // 
            // 
            this.EmpEditCode.CustomButton.Image = null;
            this.EmpEditCode.CustomButton.Location = new System.Drawing.Point(101, 1);
            this.EmpEditCode.CustomButton.Name = "";
            this.EmpEditCode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.EmpEditCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.EmpEditCode.CustomButton.TabIndex = 1;
            this.EmpEditCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.EmpEditCode.CustomButton.UseSelectable = true;
            this.EmpEditCode.Lines = new string[0];
            this.EmpEditCode.Location = new System.Drawing.Point(78, 14);
            this.EmpEditCode.MaxLength = 32767;
            this.EmpEditCode.Name = "EmpEditCode";
            this.EmpEditCode.PasswordChar = '\0';
            this.EmpEditCode.PromptText = "Account No Here";
            this.EmpEditCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.EmpEditCode.SelectedText = "";
            this.EmpEditCode.SelectionLength = 0;
            this.EmpEditCode.SelectionStart = 0;
            this.EmpEditCode.ShortcutsEnabled = true;
            this.EmpEditCode.ShowButton = true;
            this.EmpEditCode.Size = new System.Drawing.Size(123, 23);
            this.EmpEditCode.Style = MetroFramework.MetroColorStyle.Green;
            this.EmpEditCode.TabIndex = 0;
            this.EmpEditCode.UseSelectable = true;
            this.EmpEditCode.WaterMark = "Account No Here";
            this.EmpEditCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.EmpEditCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.EmpEditCode.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.EmpEditCode_ButtonClick);
            this.EmpEditCode.Click += new System.EventHandler(this.EmpEditCode_Click);
            this.EmpEditCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustEditBox_KeyPress);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAccountNo.Location = new System.Drawing.Point(5, 24);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(61, 19);
            this.lblAccountNo.TabIndex = 28;
            this.lblAccountNo.Text = "A/C No :";
            this.lblAccountNo.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroTextBox2
            // 
            // 
            // 
            // 
            this.metroTextBox2.CustomButton.Image = null;
            this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(531, 1);
            this.metroTextBox2.CustomButton.Name = "";
            this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.CustomButton.TabIndex = 1;
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.Lines = new string[0];
            this.metroTextBox2.Location = new System.Drawing.Point(78, 39);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Multiline = true;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.SelectionLength = 0;
            this.metroTextBox2.SelectionStart = 0;
            this.metroTextBox2.ShortcutsEnabled = true;
            this.metroTextBox2.Size = new System.Drawing.Size(559, 29);
            this.metroTextBox2.TabIndex = 32;
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtEmployeeNTN
            // 
            // 
            // 
            // 
            this.txtEmployeeNTN.CustomButton.Image = null;
            this.txtEmployeeNTN.CustomButton.Location = new System.Drawing.Point(133, 1);
            this.txtEmployeeNTN.CustomButton.Name = "";
            this.txtEmployeeNTN.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtEmployeeNTN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEmployeeNTN.CustomButton.TabIndex = 1;
            this.txtEmployeeNTN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEmployeeNTN.CustomButton.UseSelectable = true;
            this.txtEmployeeNTN.CustomButton.Visible = false;
            this.txtEmployeeNTN.Lines = new string[0];
            this.txtEmployeeNTN.Location = new System.Drawing.Point(482, 13);
            this.txtEmployeeNTN.MaxLength = 32767;
            this.txtEmployeeNTN.Name = "txtEmployeeNTN";
            this.txtEmployeeNTN.PasswordChar = '\0';
            this.txtEmployeeNTN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmployeeNTN.SelectedText = "";
            this.txtEmployeeNTN.SelectionLength = 0;
            this.txtEmployeeNTN.SelectionStart = 0;
            this.txtEmployeeNTN.ShortcutsEnabled = true;
            this.txtEmployeeNTN.Size = new System.Drawing.Size(155, 23);
            this.txtEmployeeNTN.TabIndex = 30;
            this.txtEmployeeNTN.UseSelectable = true;
            this.txtEmployeeNTN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEmployeeNTN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnPrevious
            // 
            this.btnPrevious.ActiveControl = null;
            this.btnPrevious.Location = new System.Drawing.Point(805, 570);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(115, 35);
            this.btnPrevious.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrevious.TabIndex = 9;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrevious.UseSelectable = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNewVoucher
            // 
            this.btnNewVoucher.ActiveControl = null;
            this.btnNewVoucher.Location = new System.Drawing.Point(1037, 570);
            this.btnNewVoucher.Name = "btnNewVoucher";
            this.btnNewVoucher.Size = new System.Drawing.Size(115, 35);
            this.btnNewVoucher.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNewVoucher.TabIndex = 11;
            this.btnNewVoucher.Text = "New Voucher";
            this.btnNewVoucher.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNewVoucher.UseSelectable = true;
            this.btnNewVoucher.Click += new System.EventHandler(this.btnNewVoucher_Click);
            // 
            // btnNext
            // 
            this.btnNext.ActiveControl = null;
            this.btnNext.Location = new System.Drawing.Point(921, 570);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(115, 35);
            this.btnNext.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNext.UseSelectable = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // grpSales
            // 
            this.grpSales.Controls.Add(this.cbxReturnType);
            this.grpSales.Controls.Add(this.cbxNaturalAccounts);
            this.grpSales.Controls.Add(this.lblReturnType);
            this.grpSales.Controls.Add(this.metroLabel1);
            this.grpSales.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSales.Location = new System.Drawing.Point(508, 227);
            this.grpSales.Name = "grpSales";
            this.grpSales.Size = new System.Drawing.Size(645, 55);
            this.grpSales.TabIndex = 2;
            this.grpSales.TabStop = false;
            this.grpSales.Text = "Sales Information";
            // 
            // cbxReturnType
            // 
            this.cbxReturnType.FormattingEnabled = true;
            this.cbxReturnType.ItemHeight = 23;
            this.cbxReturnType.Items.AddRange(new object[] {
            "Sales Return",
            "Claim Return"});
            this.cbxReturnType.Location = new System.Drawing.Point(439, 19);
            this.cbxReturnType.Name = "cbxReturnType";
            this.cbxReturnType.Size = new System.Drawing.Size(198, 29);
            this.cbxReturnType.TabIndex = 1;
            this.cbxReturnType.UseSelectable = true;
            this.cbxReturnType.SelectedIndexChanged += new System.EventHandler(this.cbxNaturalAccounts_SelectedIndexChanged);
            this.cbxReturnType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxReturnType_KeyPress);
            // 
            // cbxNaturalAccounts
            // 
            this.cbxNaturalAccounts.FormattingEnabled = true;
            this.cbxNaturalAccounts.ItemHeight = 23;
            this.cbxNaturalAccounts.Location = new System.Drawing.Point(83, 19);
            this.cbxNaturalAccounts.Name = "cbxNaturalAccounts";
            this.cbxNaturalAccounts.Size = new System.Drawing.Size(259, 29);
            this.cbxNaturalAccounts.TabIndex = 0;
            this.cbxNaturalAccounts.UseSelectable = true;
            this.cbxNaturalAccounts.SelectedIndexChanged += new System.EventHandler(this.cbxNaturalAccounts_SelectedIndexChanged);
            this.cbxNaturalAccounts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxNaturalAccounts_KeyPress);
            // 
            // lblReturnType
            // 
            this.lblReturnType.AutoSize = true;
            this.lblReturnType.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblReturnType.Location = new System.Drawing.Point(343, 24);
            this.lblReturnType.Name = "lblReturnType";
            this.lblReturnType.Size = new System.Drawing.Size(90, 19);
            this.lblReturnType.TabIndex = 3;
            this.lblReturnType.Text = "Return Type :";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(4, 21);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(77, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Sales A/ C :";
            // 
            // SalesEditBox
            // 
            // 
            // 
            // 
            this.SalesEditBox.CustomButton.Image = null;
            this.SalesEditBox.CustomButton.Location = new System.Drawing.Point(141, 1);
            this.SalesEditBox.CustomButton.Name = "";
            this.SalesEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SalesEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SalesEditBox.CustomButton.TabIndex = 1;
            this.SalesEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SalesEditBox.CustomButton.UseSelectable = true;
            this.SalesEditBox.Lines = new string[0];
            this.SalesEditBox.Location = new System.Drawing.Point(555, 24);
            this.SalesEditBox.MaxLength = 32767;
            this.SalesEditBox.Name = "SalesEditBox";
            this.SalesEditBox.PasswordChar = '\0';
            this.SalesEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SalesEditBox.SelectedText = "";
            this.SalesEditBox.SelectionLength = 0;
            this.SalesEditBox.SelectionStart = 0;
            this.SalesEditBox.ShortcutsEnabled = true;
            this.SalesEditBox.ShowButton = true;
            this.SalesEditBox.Size = new System.Drawing.Size(163, 23);
            this.SalesEditBox.Style = MetroFramework.MetroColorStyle.Teal;
            this.SalesEditBox.TabIndex = 1;
            this.SalesEditBox.UseSelectable = true;
            this.SalesEditBox.Visible = false;
            this.SalesEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SalesEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.SalesEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.SalesEditBox_ButtonClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CustEditBox);
            this.groupBox2.Controls.Add(this.lblAccountNo);
            this.groupBox2.Controls.Add(this.txtCustomerName);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.txtContact);
            this.groupBox2.Controls.Add(this.txtNTN);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(508, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(645, 90);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.EmpEditCode);
            this.groupBox3.Controls.Add(this.metroLabel2);
            this.groupBox3.Controls.Add(this.txtEmployeeName);
            this.groupBox3.Controls.Add(this.txtEmployeeContact);
            this.groupBox3.Controls.Add(this.metroTextBox2);
            this.groupBox3.Controls.Add(this.txtEmployeeNTN);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(508, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(645, 71);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Employee";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(11, 17);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(61, 19);
            this.metroLabel2.TabIndex = 28;
            this.metroLabel2.Text = "A/C No :";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // DgvSaleInvoice
            // 
            this.DgvSaleInvoice.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Beige;
            this.DgvSaleInvoice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvSaleInvoice.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvSaleInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvSaleInvoice.ColumnHeadersHeight = 25;
            this.DgvSaleInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSale,
            this.colIdItem,
            this.colItem,
            this.colProductName,
            this.colPackingSize,
            this.colQty,
            this.colUnitPrice,
            this.colAmount});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSaleInvoice.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvSaleInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DgvSaleInvoice.EnableHeadersVisualStyles = false;
            this.DgvSaleInvoice.GridColor = System.Drawing.SystemColors.GrayText;
            this.DgvSaleInvoice.Location = new System.Drawing.Point(0, 290);
            this.DgvSaleInvoice.MultiSelect = false;
            this.DgvSaleInvoice.Name = "DgvSaleInvoice";
            this.DgvSaleInvoice.RowHeadersVisible = false;
            this.DgvSaleInvoice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvSaleInvoice.Size = new System.Drawing.Size(1153, 188);
            this.DgvSaleInvoice.TabIndex = 4;
            this.DgvSaleInvoice.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSaleInvoice_CellEndEdit);
            this.DgvSaleInvoice.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSaleInvoice_CellLeave);
            this.DgvSaleInvoice.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvSaleInvoice_EditingControlShowing);
            this.DgvSaleInvoice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvSaleInvoice_KeyDown);
            // 
            // colSale
            // 
            this.colSale.HeaderText = "SaleDetailId";
            this.colSale.Name = "colSale";
            this.colSale.Visible = false;
            // 
            // colIdItem
            // 
            this.colIdItem.HeaderText = "IdItem";
            this.colIdItem.Name = "colIdItem";
            this.colIdItem.Visible = false;
            // 
            // colItem
            // 
            this.colItem.DataPropertyName = "AccountNo";
            this.colItem.HeaderText = "Product Code";
            this.colItem.Name = "colItem";
            this.colItem.Visible = false;
            this.colItem.Width = 104;
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Product Name";
            this.colProductName.Name = "colProductName";
            this.colProductName.Width = 400;
            // 
            // colPackingSize
            // 
            this.colPackingSize.HeaderText = "Packing Size";
            this.colPackingSize.Name = "colPackingSize";
            this.colPackingSize.ReadOnly = true;
            this.colPackingSize.Width = 160;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            this.colQty.HeaderText = "Units";
            this.colQty.Name = "colQty";
            this.colQty.Width = 160;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "Amount";
            this.colUnitPrice.HeaderText = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Width = 160;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 250;
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblVAT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVAT.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblVAT.Location = new System.Drawing.Point(918, 510);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(79, 17);
            this.lblVAT.TabIndex = 17;
            this.lblVAT.Text = "Vat Amount:";
            // 
            // txtVAT
            // 
            // 
            // 
            // 
            this.txtVAT.CustomButton.Image = null;
            this.txtVAT.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.txtVAT.CustomButton.Name = "";
            this.txtVAT.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtVAT.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtVAT.CustomButton.TabIndex = 1;
            this.txtVAT.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtVAT.CustomButton.UseSelectable = true;
            this.txtVAT.CustomButton.Visible = false;
            this.txtVAT.Lines = new string[0];
            this.txtVAT.Location = new System.Drawing.Point(1014, 510);
            this.txtVAT.MaxLength = 32767;
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.PasswordChar = '\0';
            this.txtVAT.PromptText = "VAT";
            this.txtVAT.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtVAT.SelectedText = "";
            this.txtVAT.SelectionLength = 0;
            this.txtVAT.SelectionStart = 0;
            this.txtVAT.ShortcutsEnabled = true;
            this.txtVAT.Size = new System.Drawing.Size(138, 23);
            this.txtVAT.TabIndex = 24;
            this.txtVAT.UseSelectable = true;
            this.txtVAT.WaterMark = "VAT";
            this.txtVAT.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtVAT.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblVATAmount
            // 
            this.lblVATAmount.AutoSize = true;
            this.lblVATAmount.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblVATAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATAmount.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblVATAmount.Location = new System.Drawing.Point(918, 543);
            this.lblVATAmount.Name = "lblVATAmount";
            this.lblVATAmount.Size = new System.Drawing.Size(100, 17);
            this.lblVATAmount.TabIndex = 17;
            this.lblVATAmount.Text = "Total After Tax :";
            // 
            // txtVATAmount
            // 
            // 
            // 
            // 
            this.txtVATAmount.CustomButton.Image = null;
            this.txtVATAmount.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.txtVATAmount.CustomButton.Name = "";
            this.txtVATAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtVATAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtVATAmount.CustomButton.TabIndex = 1;
            this.txtVATAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtVATAmount.CustomButton.UseSelectable = true;
            this.txtVATAmount.CustomButton.Visible = false;
            this.txtVATAmount.Lines = new string[0];
            this.txtVATAmount.Location = new System.Drawing.Point(1014, 541);
            this.txtVATAmount.MaxLength = 32767;
            this.txtVATAmount.Name = "txtVATAmount";
            this.txtVATAmount.PasswordChar = '\0';
            this.txtVATAmount.PromptText = "VAT Amount";
            this.txtVATAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtVATAmount.SelectedText = "";
            this.txtVATAmount.SelectionLength = 0;
            this.txtVATAmount.SelectionStart = 0;
            this.txtVATAmount.ShortcutsEnabled = true;
            this.txtVATAmount.Size = new System.Drawing.Size(138, 23);
            this.txtVATAmount.TabIndex = 24;
            this.txtVATAmount.UseSelectable = true;
            this.txtVATAmount.WaterMark = "VAT Amount";
            this.txtVATAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtVATAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // frmSalesReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 659);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DgvSaleInvoice);
            this.Controls.Add(this.txtVATAmount);
            this.Controls.Add(this.txtVAT);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.grpSales);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblVATAmount);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblVAT);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblTotalBalance);
            this.Controls.Add(this.SalesEditBox);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNewVoucher);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPrint);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmSalesReturn";
            this.Text = "Sales Return";
            this.Load += new System.EventHandler(this.frmSalesReturn_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSalesReturn_KeyPress);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSales.ResumeLayout(false);
            this.grpSales.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSaleInvoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabDataGrid DgvSaleInvoice;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatuMessage;
        private System.Windows.Forms.Label lblTotalBalance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPosted;
        private MetroFramework.Controls.MetroLabel lblInvoiceNo;
        private MetroFramework.Controls.MetroLabel lblDiscription;
        private MetroFramework.Controls.MetroLabel lblDate;
        private MetroFramework.Controls.MetroLabel lblVoucherNo;
        private MetroFramework.Controls.MetroDateTime VDate;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroTextBox txtSaleMemoNo;
        private MetroFramework.Controls.MetroTextBox InvEditBox;
        private MetroFramework.Controls.MetroTextBox CustEditBox;
        private MetroFramework.Controls.MetroTextBox txtCustomerName;
        private MetroFramework.Controls.MetroTextBox txtContact;
        private MetroFramework.Controls.MetroTextBox txtNTN;
        private MetroFramework.Controls.MetroTextBox txtAddress;
        private MetroFramework.Controls.MetroTextBox txtTotalAmount;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroTile btnDelete;
        private MetroFramework.Controls.MetroTile btnPrint;
        private MetroFramework.Controls.MetroTile btnClose;
        private MetroFramework.Controls.MetroTextBox txtEmployeeContact;
        private MetroFramework.Controls.MetroTextBox txtEmployeeName;
        private MetroFramework.Controls.MetroTextBox EmpEditCode;
        private MetroFramework.Controls.MetroLabel lblAccountNo;
        private System.Windows.Forms.GroupBox grpSales;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox SalesEditBox;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroTextBox txtEmployeeNTN;
        private MetroFramework.Controls.MetroComboBox cbxNaturalAccounts;
        private MetroFramework.Controls.MetroTextBox txtGatePass;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtOutWardGatePass;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTile btnNext;
        private MetroFramework.Controls.MetroTile btnPrevious;
        private MetroFramework.Controls.MetroTile btnNewVoucher;
        private MetroFramework.Controls.MetroComboBox cbxReturnType;
        private MetroFramework.Controls.MetroLabel lblReturnType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.Label lblVAT;
        private MetroFramework.Controls.MetroTextBox txtVAT;
        private System.Windows.Forms.Label lblVATAmount;
        private MetroFramework.Controls.MetroTextBox txtVATAmount;
    }
}