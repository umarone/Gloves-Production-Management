namespace Accounts.UI
{
    partial class frmJournalVoucher
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
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.VEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblDiscription = new MetroFramework.Controls.MetroLabel();
            this.lblVoucherNo = new MetroFramework.Controls.MetroLabel();
            this.VDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.lblStatuMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.cbxAdjustments = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.chkPosted = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.DgvVoucher = new Accounts.UI.TabDataGrid();
            this.colHeadType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIdDetailVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLinkAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClosingBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNewVoucher = new MetroFramework.Controls.MetroTile();
            this.btnNext = new MetroFramework.Controls.MetroTile();
            this.btnPrevious = new MetroFramework.Controls.MetroTile();
            this.btnPrint = new MetroFramework.Controls.MetroTile();
            this.lblDeletedVoucher = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVoucher)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(570, 2);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(108, 78);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.ShowClearButton = true;
            this.txtDescription.Size = new System.Drawing.Size(608, 40);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // VEditBox
            // 
            // 
            // 
            // 
            this.VEditBox.CustomButton.Image = null;
            this.VEditBox.CustomButton.Location = new System.Drawing.Point(164, 1);
            this.VEditBox.CustomButton.Name = "";
            this.VEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.VEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.VEditBox.CustomButton.TabIndex = 1;
            this.VEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.VEditBox.CustomButton.UseSelectable = true;
            this.VEditBox.Lines = new string[0];
            this.VEditBox.Location = new System.Drawing.Point(108, 11);
            this.VEditBox.MaxLength = 32767;
            this.VEditBox.Name = "VEditBox";
            this.VEditBox.PasswordChar = '\0';
            this.VEditBox.PromptText = "Voucher No Here";
            this.VEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.VEditBox.SelectedText = "";
            this.VEditBox.SelectionLength = 0;
            this.VEditBox.SelectionStart = 0;
            this.VEditBox.ShortcutsEnabled = true;
            this.VEditBox.ShowButton = true;
            this.VEditBox.Size = new System.Drawing.Size(186, 23);
            this.VEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.VEditBox.TabIndex = 1;
            this.VEditBox.UseSelectable = true;
            this.VEditBox.UseStyleColors = true;
            this.VEditBox.WaterMark = "Voucher No Here";
            this.VEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.VEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.VEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.VEditBox_ButtonClick);
            this.VEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VEditBox_KeyPress);
            // 
            // lblDiscription
            // 
            this.lblDiscription.AutoSize = true;
            this.lblDiscription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDiscription.Location = new System.Drawing.Point(18, 87);
            this.lblDiscription.Name = "lblDiscription";
            this.lblDiscription.Size = new System.Drawing.Size(81, 19);
            this.lblDiscription.TabIndex = 15;
            this.lblDiscription.Text = "Discription :";
            this.lblDiscription.UseCustomBackColor = true;
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblVoucherNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVoucherNo.Location = new System.Drawing.Point(17, 11);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(89, 19);
            this.lblVoucherNo.Style = MetroFramework.MetroColorStyle.Black;
            this.lblVoucherNo.TabIndex = 1;
            this.lblVoucherNo.Text = "Voucher No :";
            this.lblVoucherNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVoucherNo.UseCustomBackColor = true;
            // 
            // VDate
            // 
            this.VDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.VDate.Location = new System.Drawing.Point(108, 43);
            this.VDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.VDate.Name = "VDate";
            this.VDate.Size = new System.Drawing.Size(186, 29);
            this.VDate.TabIndex = 16;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(27, 45);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(45, 19);
            this.metroLabel1.TabIndex = 14;
            this.metroLabel1.Text = "Date :";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.BackColor = System.Drawing.Color.DarkCyan;
            this.btnClose.Location = new System.Drawing.Point(866, 465);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 35);
            this.btnClose.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnClose.UseCustomBackColor = true;
            this.btnClose.UseSelectable = true;
            this.btnClose.UseStyleColors = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblStatuMessage
            // 
            this.lblStatuMessage.Name = "lblStatuMessage";
            this.lblStatuMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // btnDelete
            // 
            this.btnDelete.ActiveControl = null;
            this.btnDelete.BackColor = System.Drawing.Color.DarkCyan;
            this.btnDelete.Location = new System.Drawing.Point(754, 465);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 35);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnDelete.UseCustomBackColor = true;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.UseStyleColors = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSave.Location = new System.Drawing.Point(636, 465);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 35);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnSave.UseCustomBackColor = true;
            this.btnSave.UseSelectable = true;
            this.btnSave.UseStyleColors = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.metroPanel1.Controls.Add(this.lblDeletedVoucher);
            this.metroPanel1.Controls.Add(this.cbxAdjustments);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.VEditBox);
            this.metroPanel1.Controls.Add(this.txtDescription);
            this.metroPanel1.Controls.Add(this.lblDiscription);
            this.metroPanel1.Controls.Add(this.lblVoucherNo);
            this.metroPanel1.Controls.Add(this.VDate);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.chkPosted);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(1, 58);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(976, 132);
            this.metroPanel1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroPanel1.TabIndex = 15;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // cbxAdjustments
            // 
            this.cbxAdjustments.FormattingEnabled = true;
            this.cbxAdjustments.ItemHeight = 23;
            this.cbxAdjustments.Location = new System.Drawing.Point(439, 43);
            this.cbxAdjustments.Name = "cbxAdjustments";
            this.cbxAdjustments.Size = new System.Drawing.Size(277, 29);
            this.cbxAdjustments.TabIndex = 22;
            this.cbxAdjustments.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(308, 47);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(126, 19);
            this.metroLabel2.TabIndex = 21;
            this.metroLabel2.Text = "Adjustment Types :";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // chkPosted
            // 
            this.chkPosted.AutoSize = true;
            this.chkPosted.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPosted.ForeColor = System.Drawing.Color.Red;
            this.chkPosted.Location = new System.Drawing.Point(310, 10);
            this.chkPosted.Name = "chkPosted";
            this.chkPosted.Size = new System.Drawing.Size(76, 25);
            this.chkPosted.TabIndex = 5;
            this.chkPosted.Text = "Posted";
            this.chkPosted.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatuMessage});
            this.statusStrip1.Location = new System.Drawing.Point(20, 508);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(960, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // DgvVoucher
            // 
            this.DgvVoucher.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvVoucher.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvVoucher.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvVoucher.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvVoucher.ColumnHeadersHeight = 25;
            this.DgvVoucher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHeadType,
            this.ColTransaction,
            this.ColIdDetailVoucher,
            this.colIdAccount,
            this.colAccountNo,
            this.colLinkAccountNo,
            this.colAccountName,
            this.colClosingBalance,
            this.colDescription,
            this.colDebit,
            this.colCredit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvVoucher.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvVoucher.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DgvVoucher.EnableHeadersVisualStyles = false;
            this.DgvVoucher.Location = new System.Drawing.Point(1, 197);
            this.DgvVoucher.MultiSelect = false;
            this.DgvVoucher.Name = "DgvVoucher";
            this.DgvVoucher.RowHeadersVisible = false;
            this.DgvVoucher.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvVoucher.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvVoucher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DgvVoucher.Size = new System.Drawing.Size(976, 262);
            this.DgvVoucher.TabIndex = 11;
            this.DgvVoucher.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvVoucher_CellEndEdit);
            this.DgvVoucher.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvVoucher_CellLeave);
            this.DgvVoucher.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvVoucher_EditingControlShowing);
            this.DgvVoucher.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvVoucher_KeyDown);
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
            // colLinkAccountNo
            // 
            this.colLinkAccountNo.HeaderText = "Link Acc#";
            this.colLinkAccountNo.Name = "colLinkAccountNo";
            this.colLinkAccountNo.Visible = false;
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
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Narration";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 370;
            // 
            // colDebit
            // 
            this.colDebit.HeaderText = "Debit";
            this.colDebit.Name = "colDebit";
            this.colDebit.Width = 130;
            // 
            // colCredit
            // 
            this.colCredit.HeaderText = "Credit";
            this.colCredit.Name = "colCredit";
            this.colCredit.Width = 130;
            // 
            // btnNewVoucher
            // 
            this.btnNewVoucher.ActiveControl = null;
            this.btnNewVoucher.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNewVoucher.Location = new System.Drawing.Point(518, 465);
            this.btnNewVoucher.Name = "btnNewVoucher";
            this.btnNewVoucher.Size = new System.Drawing.Size(117, 35);
            this.btnNewVoucher.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNewVoucher.TabIndex = 19;
            this.btnNewVoucher.Text = "New Voucher";
            this.btnNewVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNewVoucher.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnNewVoucher.UseCustomBackColor = true;
            this.btnNewVoucher.UseSelectable = true;
            this.btnNewVoucher.UseStyleColors = true;
            this.btnNewVoucher.Click += new System.EventHandler(this.btnNewVoucher_Click);
            // 
            // btnNext
            // 
            this.btnNext.ActiveControl = null;
            this.btnNext.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNext.Location = new System.Drawing.Point(400, 465);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(117, 35);
            this.btnNext.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNext.TabIndex = 20;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNext.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnNext.UseCustomBackColor = true;
            this.btnNext.UseSelectable = true;
            this.btnNext.UseStyleColors = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.ActiveControl = null;
            this.btnPrevious.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPrevious.Location = new System.Drawing.Point(282, 465);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(117, 35);
            this.btnPrevious.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrevious.TabIndex = 17;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrevious.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnPrevious.UseCustomBackColor = true;
            this.btnPrevious.UseSelectable = true;
            this.btnPrevious.UseStyleColors = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ActiveControl = null;
            this.btnPrint.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPrint.Location = new System.Drawing.Point(164, 465);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(117, 35);
            this.btnPrint.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrint.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnPrint.UseCustomBackColor = true;
            this.btnPrint.UseSelectable = true;
            this.btnPrint.UseStyleColors = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblDeletedVoucher
            // 
            this.lblDeletedVoucher.AutoSize = true;
            this.lblDeletedVoucher.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblDeletedVoucher.ForeColor = System.Drawing.Color.Red;
            this.lblDeletedVoucher.Location = new System.Drawing.Point(781, 47);
            this.lblDeletedVoucher.Name = "lblDeletedVoucher";
            this.lblDeletedVoucher.Size = new System.Drawing.Size(132, 19);
            this.lblDeletedVoucher.TabIndex = 21;
            this.lblDeletedVoucher.Text = "Deleted Voucher...";
            this.lblDeletedVoucher.UseCustomBackColor = true;
            this.lblDeletedVoucher.UseCustomForeColor = true;
            this.lblDeletedVoucher.Visible = false;
            // 
            // frmJournalVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.btnNewVoucher);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.DgvVoucher);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmJournalVoucher";
            this.Text = "Journal Voucher";
            this.Load += new System.EventHandler(this.frmJournalVoucher_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmJournalVoucher_KeyPress);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVoucher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroTextBox VEditBox;
        private MetroFramework.Controls.MetroLabel lblDiscription;
        private MetroFramework.Controls.MetroLabel lblVoucherNo;
        private MetroFramework.Controls.MetroDateTime VDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private TabDataGrid DgvVoucher;
        private MetroFramework.Controls.MetroTile btnClose;
        private System.Windows.Forms.ToolStripStatusLabel lblStatuMessage;
        private MetroFramework.Controls.MetroTile btnDelete;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.CheckBox chkPosted;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private MetroFramework.Controls.MetroTile btnNewVoucher;
        private MetroFramework.Controls.MetroTile btnNext;
        private MetroFramework.Controls.MetroTile btnPrevious;
        private MetroFramework.Controls.MetroTile btnPrint;
        private MetroFramework.Controls.MetroComboBox cbxAdjustments;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeadType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdDetailVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinkAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClosingBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCredit;
        private MetroFramework.Controls.MetroLabel lblDeletedVoucher;

    }
}