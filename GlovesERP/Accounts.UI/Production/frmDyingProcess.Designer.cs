namespace Accounts.UI
{
    partial class frmDyingProcess
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatuMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VDate = new MetroFramework.Controls.MetroDateTime();
            this.VEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblDiscription = new MetroFramework.Controls.MetroLabel();
            this.lblVoucherNo = new MetroFramework.Controls.MetroLabel();
            this.lblDate = new MetroFramework.Controls.MetroLabel();
            this.chkPosted = new MetroFramework.Controls.MetroCheckBox();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.txtCreditBalance = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalCredit = new MetroFramework.Controls.MetroLabel();
            this.btnPrevious = new MetroFramework.Controls.MetroTile();
            this.btnNext = new MetroFramework.Controls.MetroTile();
            this.btnNew = new MetroFramework.Controls.MetroTile();
            this.grpPurchases = new System.Windows.Forms.GroupBox();
            this.cbxNaturalAccounts = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SEditBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtAddress = new MetroFramework.Controls.MetroTextBox();
            this.txtContact = new MetroFramework.Controls.MetroTextBox();
            this.btnPrint = new MetroFramework.Controls.MetroTile();
            this.DgvStockReceipt = new Accounts.UI.TabDataGrid();
            this.lblVoucherStatus = new MetroFramework.Controls.MetroLabel();
            this.colIdVoucherDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpacking = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colColors = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colGradeAQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGradeAAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGradeBQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGradeBAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCPQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpPurchases.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStockReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatuMessage});
            this.statusStrip1.Location = new System.Drawing.Point(20, 534);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1194, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatuMessage
            // 
            this.lblStatuMessage.Name = "lblStatuMessage";
            this.lblStatuMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.groupBox1.Controls.Add(this.VDate);
            this.groupBox1.Controls.Add(this.VEditBox);
            this.groupBox1.Controls.Add(this.lblDiscription);
            this.groupBox1.Controls.Add(this.lblVoucherNo);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.chkPosted);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 148);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process Information";
            // 
            // VDate
            // 
            this.VDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.VDate.Location = new System.Drawing.Point(387, 18);
            this.VDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.VDate.Name = "VDate";
            this.VDate.Size = new System.Drawing.Size(162, 29);
            this.VDate.TabIndex = 22;
            // 
            // VEditBox
            // 
            // 
            // 
            // 
            this.VEditBox.CustomButton.Image = null;
            this.VEditBox.CustomButton.Location = new System.Drawing.Point(218, 1);
            this.VEditBox.CustomButton.Name = "";
            this.VEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.VEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.VEditBox.CustomButton.TabIndex = 1;
            this.VEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.VEditBox.CustomButton.UseSelectable = true;
            this.VEditBox.Lines = new string[0];
            this.VEditBox.Location = new System.Drawing.Point(90, 23);
            this.VEditBox.MaxLength = 32767;
            this.VEditBox.Name = "VEditBox";
            this.VEditBox.PasswordChar = '\0';
            this.VEditBox.PromptText = "Auto Dying No";
            this.VEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.VEditBox.SelectedText = "";
            this.VEditBox.SelectionLength = 0;
            this.VEditBox.SelectionStart = 0;
            this.VEditBox.ShortcutsEnabled = true;
            this.VEditBox.ShowButton = true;
            this.VEditBox.Size = new System.Drawing.Size(240, 23);
            this.VEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.VEditBox.TabIndex = 21;
            this.VEditBox.UseSelectable = true;
            this.VEditBox.WaterMark = "Auto Dying No";
            this.VEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.VEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.VEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.VEditBox_ButtonClick);
            this.VEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VEditBox_KeyPress);
            // 
            // lblDiscription
            // 
            this.lblDiscription.AutoSize = true;
            this.lblDiscription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDiscription.Location = new System.Drawing.Point(7, 96);
            this.lblDiscription.Name = "lblDiscription";
            this.lblDiscription.Size = new System.Drawing.Size(81, 19);
            this.lblDiscription.TabIndex = 19;
            this.lblDiscription.Text = "Discription :";
            this.lblDiscription.UseCustomBackColor = true;
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblVoucherNo.Location = new System.Drawing.Point(11, 23);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(74, 19);
            this.lblVoucherNo.TabIndex = 19;
            this.lblVoucherNo.Text = "Dying No :";
            this.lblVoucherNo.UseCustomBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDate.Location = new System.Drawing.Point(336, 24);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 19);
            this.lblDate.TabIndex = 19;
            this.lblDate.Text = "Date :";
            this.lblDate.UseCustomBackColor = true;
            // 
            // chkPosted
            // 
            this.chkPosted.AutoSize = true;
            this.chkPosted.Location = new System.Drawing.Point(554, 26);
            this.chkPosted.Name = "chkPosted";
            this.chkPosted.Size = new System.Drawing.Size(59, 15);
            this.chkPosted.TabIndex = 18;
            this.chkPosted.Text = "Posted";
            this.chkPosted.UseCustomBackColor = true;
            this.chkPosted.UseSelectable = true;
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(447, 2);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(73, 73);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(90, 54);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(523, 78);
            this.txtDescription.TabIndex = 16;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(599, 473);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 40);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ActiveControl = null;
            this.btnDelete.Location = new System.Drawing.Point(701, 473);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 40);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Red;
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.Location = new System.Drawing.Point(803, 473);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 40);
            this.btnClose.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCreditBalance
            // 
            // 
            // 
            // 
            this.txtCreditBalance.CustomButton.Image = null;
            this.txtCreditBalance.CustomButton.Location = new System.Drawing.Point(135, 1);
            this.txtCreditBalance.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtCreditBalance.CustomButton.Name = "";
            this.txtCreditBalance.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCreditBalance.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCreditBalance.CustomButton.TabIndex = 1;
            this.txtCreditBalance.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCreditBalance.CustomButton.UseSelectable = true;
            this.txtCreditBalance.CustomButton.Visible = false;
            this.txtCreditBalance.Lines = new string[0];
            this.txtCreditBalance.Location = new System.Drawing.Point(1054, 441);
            this.txtCreditBalance.MaxLength = 32767;
            this.txtCreditBalance.Name = "txtCreditBalance";
            this.txtCreditBalance.PasswordChar = '\0';
            this.txtCreditBalance.PromptText = "Ledger Amount";
            this.txtCreditBalance.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCreditBalance.SelectedText = "";
            this.txtCreditBalance.SelectionLength = 0;
            this.txtCreditBalance.SelectionStart = 0;
            this.txtCreditBalance.ShortcutsEnabled = true;
            this.txtCreditBalance.Size = new System.Drawing.Size(157, 23);
            this.txtCreditBalance.TabIndex = 22;
            this.txtCreditBalance.UseSelectable = true;
            this.txtCreditBalance.WaterMark = "Ledger Amount";
            this.txtCreditBalance.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCreditBalance.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(500, 690);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Credit Total :";
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.AutoSize = true;
            this.lblTotalCredit.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblTotalCredit.Location = new System.Drawing.Point(950, 443);
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Size = new System.Drawing.Size(100, 19);
            this.lblTotalCredit.TabIndex = 24;
            this.lblTotalCredit.Text = "Total Amount :";
            // 
            // btnPrevious
            // 
            this.btnPrevious.ActiveControl = null;
            this.btnPrevious.Location = new System.Drawing.Point(905, 473);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(101, 40);
            this.btnPrevious.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrevious.TabIndex = 7;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrevious.UseSelectable = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.ActiveControl = null;
            this.btnNext.Location = new System.Drawing.Point(1007, 473);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(101, 40);
            this.btnNext.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNext.UseSelectable = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnNew
            // 
            this.btnNew.ActiveControl = null;
            this.btnNew.Location = new System.Drawing.Point(1110, 473);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(101, 40);
            this.btnNew.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "New Voucher";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNew.UseSelectable = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // grpPurchases
            // 
            this.grpPurchases.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.grpPurchases.Controls.Add(this.cbxNaturalAccounts);
            this.grpPurchases.Controls.Add(this.metroLabel1);
            this.grpPurchases.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPurchases.Location = new System.Drawing.Point(682, 147);
            this.grpPurchases.Name = "grpPurchases";
            this.grpPurchases.Size = new System.Drawing.Size(532, 64);
            this.grpPurchases.TabIndex = 1;
            this.grpPurchases.TabStop = false;
            this.grpPurchases.Text = "Purchases Information";
            this.grpPurchases.Visible = false;
            // 
            // cbxNaturalAccounts
            // 
            this.cbxNaturalAccounts.FormattingEnabled = true;
            this.cbxNaturalAccounts.ItemHeight = 23;
            this.cbxNaturalAccounts.Location = new System.Drawing.Point(115, 24);
            this.cbxNaturalAccounts.Name = "cbxNaturalAccounts";
            this.cbxNaturalAccounts.Size = new System.Drawing.Size(410, 29);
            this.cbxNaturalAccounts.TabIndex = 0;
            this.cbxNaturalAccounts.UseSelectable = true;
            this.cbxNaturalAccounts.SelectedIndexChanged += new System.EventHandler(this.cbxNaturalAccounts_SelectedIndexChanged);
            this.cbxNaturalAccounts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxNaturalAccounts_KeyPress);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(5, 29);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(104, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Purchases A/C :";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.groupBox2.Controls.Add(this.SEditBox);
            this.groupBox2.Controls.Add(this.metroLabel2);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.txtContact);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(682, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(532, 85);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vendor Information";
            // 
            // SEditBox
            // 
            // 
            // 
            // 
            this.SEditBox.CustomButton.Image = null;
            this.SEditBox.CustomButton.Location = new System.Drawing.Point(272, 1);
            this.SEditBox.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.SEditBox.CustomButton.Name = "";
            this.SEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SEditBox.CustomButton.TabIndex = 1;
            this.SEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SEditBox.CustomButton.UseSelectable = true;
            this.SEditBox.Lines = new string[0];
            this.SEditBox.Location = new System.Drawing.Point(93, 25);
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
            this.SEditBox.Size = new System.Drawing.Size(294, 23);
            this.SEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.SEditBox.TabIndex = 0;
            this.SEditBox.UseSelectable = true;
            this.SEditBox.WaterMark = "Account Name Here";
            this.SEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.SEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SEditBox_KeyPress);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(7, 26);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(75, 19);
            this.metroLabel2.TabIndex = 24;
            this.metroLabel2.Text = "Party A/C :";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // txtAddress
            // 
            // 
            // 
            // 
            this.txtAddress.CustomButton.Image = null;
            this.txtAddress.CustomButton.Location = new System.Drawing.Point(407, 1);
            this.txtAddress.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.CustomButton.Name = "";
            this.txtAddress.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAddress.CustomButton.TabIndex = 1;
            this.txtAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAddress.CustomButton.UseSelectable = true;
            this.txtAddress.CustomButton.Visible = false;
            this.txtAddress.Lines = new string[0];
            this.txtAddress.Location = new System.Drawing.Point(93, 51);
            this.txtAddress.MaxLength = 32767;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.PromptText = "Address";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAddress.SelectedText = "";
            this.txtAddress.SelectionLength = 0;
            this.txtAddress.SelectionStart = 0;
            this.txtAddress.ShortcutsEnabled = true;
            this.txtAddress.Size = new System.Drawing.Size(433, 27);
            this.txtAddress.TabIndex = 22;
            this.txtAddress.UseSelectable = true;
            this.txtAddress.WaterMark = "Address";
            this.txtAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtContact
            // 
            // 
            // 
            // 
            this.txtContact.CustomButton.Image = null;
            this.txtContact.CustomButton.Location = new System.Drawing.Point(111, 1);
            this.txtContact.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtContact.CustomButton.Name = "";
            this.txtContact.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtContact.CustomButton.TabIndex = 1;
            this.txtContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtContact.CustomButton.UseSelectable = true;
            this.txtContact.CustomButton.Visible = false;
            this.txtContact.Lines = new string[0];
            this.txtContact.Location = new System.Drawing.Point(393, 24);
            this.txtContact.MaxLength = 32767;
            this.txtContact.Name = "txtContact";
            this.txtContact.PasswordChar = '\0';
            this.txtContact.PromptText = "Contact";
            this.txtContact.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContact.SelectedText = "";
            this.txtContact.SelectionLength = 0;
            this.txtContact.SelectionStart = 0;
            this.txtContact.ShortcutsEnabled = true;
            this.txtContact.Size = new System.Drawing.Size(133, 23);
            this.txtContact.TabIndex = 21;
            this.txtContact.UseSelectable = true;
            this.txtContact.WaterMark = "Contact";
            this.txtContact.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContact.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnPrint
            // 
            this.btnPrint.ActiveControl = null;
            this.btnPrint.Location = new System.Drawing.Point(497, 473);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(101, 40);
            this.btnPrint.Style = MetroFramework.MetroColorStyle.Green;
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.UseSelectable = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // DgvStockReceipt
            // 
            this.DgvStockReceipt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.DgvStockReceipt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvStockReceipt.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvStockReceipt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvStockReceipt.ColumnHeadersHeight = 25;
            this.DgvStockReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdVoucherDetail,
            this.colIdItem,
            this.colItemName,
            this.colpacking,
            this.colColors,
            this.colGradeAQuantity,
            this.colGradeAAmount,
            this.colGradeBQuantity,
            this.colGradeBAmount,
            this.colCPQuantity,
            this.colQty,
            this.colUnitPrice,
            this.colAmount});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvStockReceipt.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvStockReceipt.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DgvStockReceipt.EnableHeadersVisualStyles = false;
            this.DgvStockReceipt.Location = new System.Drawing.Point(5, 232);
            this.DgvStockReceipt.MultiSelect = false;
            this.DgvStockReceipt.Name = "DgvStockReceipt";
            this.DgvStockReceipt.RowHeadersVisible = false;
            this.DgvStockReceipt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvStockReceipt.Size = new System.Drawing.Size(1206, 203);
            this.DgvStockReceipt.TabIndex = 3;
            this.DgvStockReceipt.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvStockReceipt_CellBeginEdit);
            this.DgvStockReceipt.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvStockReceipt_CellEndEdit);
            this.DgvStockReceipt.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvStockReceipt_CellEnter);
            this.DgvStockReceipt.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvStockReceipt_CellFormatting);
            this.DgvStockReceipt.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvStockReceipt_CellLeave);
            this.DgvStockReceipt.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvStockReceipt_EditingControlShowing);
            this.DgvStockReceipt.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvStockReceipt_RowValidating);
            this.DgvStockReceipt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DgvStockReceipt_KeyPress);
            // 
            // lblVoucherStatus
            // 
            this.lblVoucherStatus.AutoSize = true;
            this.lblVoucherStatus.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblVoucherStatus.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblVoucherStatus.ForeColor = System.Drawing.Color.Red;
            this.lblVoucherStatus.Location = new System.Drawing.Point(12, 473);
            this.lblVoucherStatus.Name = "lblVoucherStatus";
            this.lblVoucherStatus.Size = new System.Drawing.Size(154, 25);
            this.lblVoucherStatus.TabIndex = 31;
            this.lblVoucherStatus.Text = "Deleted Voucher";
            this.lblVoucherStatus.UseCustomForeColor = true;
            this.lblVoucherStatus.Visible = false;
            // 
            // colIdVoucherDetail
            // 
            this.colIdVoucherDetail.HeaderText = "StockReceiptId";
            this.colIdVoucherDetail.Name = "colIdVoucherDetail";
            this.colIdVoucherDetail.Visible = false;
            // 
            // colIdItem
            // 
            this.colIdItem.HeaderText = "IdItem";
            this.colIdItem.Name = "colIdItem";
            this.colIdItem.Visible = false;
            // 
            // colItemName
            // 
            this.colItemName.HeaderText = "Product Discription";
            this.colItemName.Name = "colItemName";
            this.colItemName.Width = 240;
            // 
            // colpacking
            // 
            this.colpacking.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colpacking.HeaderText = "UOM";
            this.colpacking.Items.AddRange(new object[] {
            "",
            "Meter",
            "Yard",
            "Dozen"});
            this.colpacking.Name = "colpacking";
            this.colpacking.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colpacking.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colColors
            // 
            this.colColors.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colColors.HeaderText = "Color";
            this.colColors.Name = "colColors";
            // 
            // colGradeAQuantity
            // 
            this.colGradeAQuantity.HeaderText = "Grade A Qty";
            this.colGradeAQuantity.Name = "colGradeAQuantity";
            // 
            // colGradeAAmount
            // 
            this.colGradeAAmount.HeaderText = "Grade A Amount";
            this.colGradeAAmount.Name = "colGradeAAmount";
            this.colGradeAAmount.Width = 150;
            // 
            // colGradeBQuantity
            // 
            this.colGradeBQuantity.HeaderText = "Grade B Qty";
            this.colGradeBQuantity.Name = "colGradeBQuantity";
            // 
            // colGradeBAmount
            // 
            this.colGradeBAmount.HeaderText = "Grade B Amount";
            this.colGradeBAmount.Name = "colGradeBAmount";
            this.colGradeBAmount.Width = 150;
            // 
            // colCPQuantity
            // 
            this.colCPQuantity.HeaderText = "CP Qty";
            this.colCPQuantity.Name = "colCPQuantity";
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            this.colQty.HeaderText = "Quantity";
            this.colQty.Name = "colQty";
            this.colQty.Width = 80;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "Amount";
            this.colUnitPrice.HeaderText = "Rate";
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
            // 
            // frmDyingProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 576);
            this.Controls.Add(this.lblVoucherStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpPurchases);
            this.Controls.Add(this.lblTotalCredit);
            this.Controls.Add(this.txtCreditBalance);
            this.Controls.Add(this.DgvStockReceipt);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDyingProcess";
            this.Text = "Dying OutSourcing";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmDyingProcess_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmDyingProcess_KeyPress);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpPurchases.ResumeLayout(false);
            this.grpPurchases.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStockReceipt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.DataGridView DgvStockReceipt;
        private TabDataGrid DgvStockReceipt;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatuMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel lblDiscription;
        private MetroFramework.Controls.MetroLabel lblVoucherNo;
        private MetroFramework.Controls.MetroLabel lblDate;
        private MetroFramework.Controls.MetroCheckBox chkPosted;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroTextBox VEditBox;
        private MetroFramework.Controls.MetroDateTime VDate;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroTile btnDelete;
        private MetroFramework.Controls.MetroTile btnClose;
        private MetroFramework.Controls.MetroTextBox txtCreditBalance;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroLabel lblTotalCredit;
        private System.Windows.Forms.GroupBox grpPurchases;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cbxNaturalAccounts;
        private MetroFramework.Controls.MetroTile btnPrevious;
        private MetroFramework.Controls.MetroTile btnNext;
        private MetroFramework.Controls.MetroTile btnNew;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroTextBox SEditBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtAddress;
        private MetroFramework.Controls.MetroTextBox txtContact;
        private MetroFramework.Controls.MetroTile btnPrint;
        private MetroFramework.Controls.MetroLabel lblVoucherStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdVoucherDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colpacking;
        private System.Windows.Forms.DataGridViewComboBoxColumn colColors;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGradeAQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGradeAAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGradeBQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGradeBAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCPQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}