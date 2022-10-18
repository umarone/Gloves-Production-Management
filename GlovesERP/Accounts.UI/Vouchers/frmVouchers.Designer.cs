namespace Accounts.UI
{
    partial class frmVouchers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.lblChequeNo = new MetroFramework.Controls.MetroLabel();
            this.chkPosted = new System.Windows.Forms.CheckBox();
            this.lblDate = new MetroFramework.Controls.MetroLabel();
            this.VDate = new MetroFramework.Controls.MetroDateTime();
            this.lblVoucherNo = new MetroFramework.Controls.MetroLabel();
            this.lblDiscription = new MetroFramework.Controls.MetroLabel();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.VEditBox = new MetroFramework.Controls.MetroTextBox();
            this.txtChequeNo = new MetroFramework.Controls.MetroTextBox();
            this.btnPrint = new MetroFramework.Controls.MetroTile();
            this.btnPrevious = new MetroFramework.Controls.MetroTile();
            this.btnNext = new MetroFramework.Controls.MetroTile();
            this.btnNewVoucher = new MetroFramework.Controls.MetroTile();
            this.cbxAdjustments = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.pnlAdjustmentTypes = new System.Windows.Forms.Panel();
            this.grpEmployees = new System.Windows.Forms.GroupBox();
            this.txtEmployeeContact = new MetroFramework.Controls.MetroTextBox();
            this.txtEmployeeName = new MetroFramework.Controls.MetroTextBox();
            this.EmpEditCode = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.grpVoucher = new System.Windows.Forms.GroupBox();
            this.lblDeletedVoucher = new MetroFramework.Controls.MetroLabel();
            this.lblStatuMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlAdjustmentTypes.SuspendLayout();
            this.grpEmployees.SuspendLayout();
            this.grpVoucher.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlHead.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVoucher)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSave.Location = new System.Drawing.Point(626, 237);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 35);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnSave.UseCustomBackColor = true;
            this.btnSave.UseSelectable = true;
            this.btnSave.UseStyleColors = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ActiveControl = null;
            this.btnDelete.BackColor = System.Drawing.Color.DarkCyan;
            this.btnDelete.Location = new System.Drawing.Point(744, 237);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 35);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnDelete.UseCustomBackColor = true;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.UseStyleColors = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.BackColor = System.Drawing.Color.DarkCyan;
            this.btnClose.Location = new System.Drawing.Point(856, 237);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 35);
            this.btnClose.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnClose.UseCustomBackColor = true;
            this.btnClose.UseSelectable = true;
            this.btnClose.UseStyleColors = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblChequeNo
            // 
            this.lblChequeNo.AutoSize = true;
            this.lblChequeNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblChequeNo.Location = new System.Drawing.Point(294, 59);
            this.lblChequeNo.Name = "lblChequeNo";
            this.lblChequeNo.Size = new System.Drawing.Size(85, 19);
            this.lblChequeNo.TabIndex = 14;
            this.lblChequeNo.Text = "Cheque No :";
            this.lblChequeNo.UseCustomBackColor = true;
            this.lblChequeNo.Visible = false;
            // 
            // chkPosted
            // 
            this.chkPosted.AutoSize = true;
            this.chkPosted.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPosted.ForeColor = System.Drawing.Color.Red;
            this.chkPosted.Location = new System.Drawing.Point(337, 32);
            this.chkPosted.Name = "chkPosted";
            this.chkPosted.Size = new System.Drawing.Size(76, 25);
            this.chkPosted.TabIndex = 5;
            this.chkPosted.Text = "Posted";
            this.chkPosted.UseVisualStyleBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDate.Location = new System.Drawing.Point(21, 58);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 19);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "Date :";
            this.lblDate.UseCustomBackColor = true;
            // 
            // VDate
            // 
            this.VDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.VDate.Location = new System.Drawing.Point(105, 55);
            this.VDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.VDate.Name = "VDate";
            this.VDate.Size = new System.Drawing.Size(186, 29);
            this.VDate.TabIndex = 16;
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblVoucherNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVoucherNo.Location = new System.Drawing.Point(16, 31);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(89, 19);
            this.lblVoucherNo.Style = MetroFramework.MetroColorStyle.Black;
            this.lblVoucherNo.TabIndex = 1;
            this.lblVoucherNo.Text = "Voucher No :";
            this.lblVoucherNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVoucherNo.UseCustomBackColor = true;
            // 
            // lblDiscription
            // 
            this.lblDiscription.AutoSize = true;
            this.lblDiscription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDiscription.Location = new System.Drawing.Point(16, 93);
            this.lblDiscription.Name = "lblDiscription";
            this.lblDiscription.Size = new System.Drawing.Size(81, 19);
            this.lblDiscription.TabIndex = 15;
            this.lblDiscription.Text = "Discription :";
            this.lblDiscription.UseCustomBackColor = true;
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(425, 2);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(105, 87);
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
            this.txtDescription.Size = new System.Drawing.Size(463, 40);
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
            this.VEditBox.Location = new System.Drawing.Point(107, 30);
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
            // txtChequeNo
            // 
            // 
            // 
            // 
            this.txtChequeNo.CustomButton.Image = null;
            this.txtChequeNo.CustomButton.Location = new System.Drawing.Point(167, 1);
            this.txtChequeNo.CustomButton.Name = "";
            this.txtChequeNo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtChequeNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtChequeNo.CustomButton.TabIndex = 1;
            this.txtChequeNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtChequeNo.CustomButton.UseSelectable = true;
            this.txtChequeNo.CustomButton.Visible = false;
            this.txtChequeNo.Lines = new string[0];
            this.txtChequeNo.Location = new System.Drawing.Point(380, 58);
            this.txtChequeNo.MaxLength = 32767;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.PasswordChar = '\0';
            this.txtChequeNo.PromptText = "Cheque No here";
            this.txtChequeNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtChequeNo.SelectedText = "";
            this.txtChequeNo.SelectionLength = 0;
            this.txtChequeNo.SelectionStart = 0;
            this.txtChequeNo.ShortcutsEnabled = true;
            this.txtChequeNo.Size = new System.Drawing.Size(189, 23);
            this.txtChequeNo.TabIndex = 17;
            this.txtChequeNo.UseSelectable = true;
            this.txtChequeNo.Visible = false;
            this.txtChequeNo.WaterMark = "Cheque No here";
            this.txtChequeNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtChequeNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnPrint
            // 
            this.btnPrint.ActiveControl = null;
            this.btnPrint.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPrint.Location = new System.Drawing.Point(154, 237);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(117, 35);
            this.btnPrint.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrint.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnPrint.UseCustomBackColor = true;
            this.btnPrint.UseSelectable = true;
            this.btnPrint.UseStyleColors = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.ActiveControl = null;
            this.btnPrevious.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPrevious.Location = new System.Drawing.Point(272, 237);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(117, 35);
            this.btnPrevious.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrevious.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnPrevious.UseCustomBackColor = true;
            this.btnPrevious.UseSelectable = true;
            this.btnPrevious.UseStyleColors = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.ActiveControl = null;
            this.btnNext.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNext.Location = new System.Drawing.Point(390, 237);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(117, 35);
            this.btnNext.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNext.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnNext.UseCustomBackColor = true;
            this.btnNext.UseSelectable = true;
            this.btnNext.UseStyleColors = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnNewVoucher
            // 
            this.btnNewVoucher.ActiveControl = null;
            this.btnNewVoucher.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNewVoucher.Location = new System.Drawing.Point(508, 237);
            this.btnNewVoucher.Name = "btnNewVoucher";
            this.btnNewVoucher.Size = new System.Drawing.Size(117, 35);
            this.btnNewVoucher.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNewVoucher.TabIndex = 1;
            this.btnNewVoucher.Text = "New Voucher";
            this.btnNewVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNewVoucher.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnNewVoucher.UseCustomBackColor = true;
            this.btnNewVoucher.UseSelectable = true;
            this.btnNewVoucher.UseStyleColors = true;
            this.btnNewVoucher.Click += new System.EventHandler(this.btnNewVoucher_Click);
            // 
            // cbxAdjustments
            // 
            this.cbxAdjustments.FormattingEnabled = true;
            this.cbxAdjustments.ItemHeight = 23;
            this.cbxAdjustments.Location = new System.Drawing.Point(125, 8);
            this.cbxAdjustments.Name = "cbxAdjustments";
            this.cbxAdjustments.Size = new System.Drawing.Size(327, 29);
            this.cbxAdjustments.TabIndex = 19;
            this.cbxAdjustments.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(8, 12);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(109, 19);
            this.metroLabel2.TabIndex = 15;
            this.metroLabel2.Text = "Payment Types :";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // pnlAdjustmentTypes
            // 
            this.pnlAdjustmentTypes.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.pnlAdjustmentTypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdjustmentTypes.Controls.Add(this.cbxAdjustments);
            this.pnlAdjustmentTypes.Controls.Add(this.metroLabel2);
            this.pnlAdjustmentTypes.Location = new System.Drawing.Point(3, 177);
            this.pnlAdjustmentTypes.Name = "pnlAdjustmentTypes";
            this.pnlAdjustmentTypes.Size = new System.Drawing.Size(970, 42);
            this.pnlAdjustmentTypes.TabIndex = 20;
            this.pnlAdjustmentTypes.Visible = false;
            // 
            // grpEmployees
            // 
            this.grpEmployees.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.grpEmployees.Controls.Add(this.txtEmployeeContact);
            this.grpEmployees.Controls.Add(this.txtEmployeeName);
            this.grpEmployees.Controls.Add(this.EmpEditCode);
            this.grpEmployees.Controls.Add(this.metroLabel3);
            this.grpEmployees.Controls.Add(this.metroLabel4);
            this.grpEmployees.Controls.Add(this.metroLabel5);
            this.grpEmployees.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEmployees.ForeColor = System.Drawing.Color.Black;
            this.grpEmployees.Location = new System.Drawing.Point(571, 9);
            this.grpEmployees.Name = "grpEmployees";
            this.grpEmployees.Size = new System.Drawing.Size(90, 28);
            this.grpEmployees.TabIndex = 11;
            this.grpEmployees.TabStop = false;
            this.grpEmployees.Text = "Employees Information";
            this.grpEmployees.Visible = false;
            // 
            // txtEmployeeContact
            // 
            // 
            // 
            // 
            this.txtEmployeeContact.CustomButton.Image = null;
            this.txtEmployeeContact.CustomButton.Location = new System.Drawing.Point(183, 1);
            this.txtEmployeeContact.CustomButton.Name = "";
            this.txtEmployeeContact.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtEmployeeContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEmployeeContact.CustomButton.TabIndex = 1;
            this.txtEmployeeContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEmployeeContact.CustomButton.UseSelectable = true;
            this.txtEmployeeContact.CustomButton.Visible = false;
            this.txtEmployeeContact.Lines = new string[0];
            this.txtEmployeeContact.Location = new System.Drawing.Point(95, 94);
            this.txtEmployeeContact.MaxLength = 32767;
            this.txtEmployeeContact.Name = "txtEmployeeContact";
            this.txtEmployeeContact.PasswordChar = '\0';
            this.txtEmployeeContact.PromptText = "Employees Contact";
            this.txtEmployeeContact.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmployeeContact.SelectedText = "";
            this.txtEmployeeContact.SelectionLength = 0;
            this.txtEmployeeContact.SelectionStart = 0;
            this.txtEmployeeContact.ShortcutsEnabled = true;
            this.txtEmployeeContact.Size = new System.Drawing.Size(205, 23);
            this.txtEmployeeContact.TabIndex = 2;
            this.txtEmployeeContact.UseSelectable = true;
            this.txtEmployeeContact.WaterMark = "Employees Contact";
            this.txtEmployeeContact.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEmployeeContact.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtEmployeeName
            // 
            // 
            // 
            // 
            this.txtEmployeeName.CustomButton.Image = null;
            this.txtEmployeeName.CustomButton.Location = new System.Drawing.Point(183, 1);
            this.txtEmployeeName.CustomButton.Name = "";
            this.txtEmployeeName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtEmployeeName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEmployeeName.CustomButton.TabIndex = 1;
            this.txtEmployeeName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEmployeeName.CustomButton.UseSelectable = true;
            this.txtEmployeeName.CustomButton.Visible = false;
            this.txtEmployeeName.Lines = new string[0];
            this.txtEmployeeName.Location = new System.Drawing.Point(95, 61);
            this.txtEmployeeName.MaxLength = 32767;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.PasswordChar = '\0';
            this.txtEmployeeName.PromptText = "Employee Name";
            this.txtEmployeeName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmployeeName.SelectedText = "";
            this.txtEmployeeName.SelectionLength = 0;
            this.txtEmployeeName.SelectionStart = 0;
            this.txtEmployeeName.ShortcutsEnabled = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(205, 23);
            this.txtEmployeeName.TabIndex = 1;
            this.txtEmployeeName.UseSelectable = true;
            this.txtEmployeeName.WaterMark = "Employee Name";
            this.txtEmployeeName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEmployeeName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // EmpEditCode
            // 
            // 
            // 
            // 
            this.EmpEditCode.CustomButton.Image = null;
            this.EmpEditCode.CustomButton.Location = new System.Drawing.Point(183, 1);
            this.EmpEditCode.CustomButton.Name = "";
            this.EmpEditCode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.EmpEditCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.EmpEditCode.CustomButton.TabIndex = 1;
            this.EmpEditCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.EmpEditCode.CustomButton.UseSelectable = true;
            this.EmpEditCode.Lines = new string[0];
            this.EmpEditCode.Location = new System.Drawing.Point(95, 29);
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
            this.EmpEditCode.Size = new System.Drawing.Size(205, 23);
            this.EmpEditCode.Style = MetroFramework.MetroColorStyle.Green;
            this.EmpEditCode.TabIndex = 0;
            this.EmpEditCode.UseSelectable = true;
            this.EmpEditCode.WaterMark = "Account No Here";
            this.EmpEditCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.EmpEditCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.EmpEditCode.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.EmpEditCode_ButtonClick);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(26, 95);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(64, 19);
            this.metroLabel3.TabIndex = 15;
            this.metroLabel3.Text = "Contact :";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(27, 63);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(52, 19);
            this.metroLabel4.TabIndex = 15;
            this.metroLabel4.Text = "Name :";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(21, 26);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(61, 19);
            this.metroLabel5.TabIndex = 15;
            this.metroLabel5.Text = "A/C No :";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // grpVoucher
            // 
            this.grpVoucher.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.grpVoucher.Controls.Add(this.lblDeletedVoucher);
            this.grpVoucher.Controls.Add(this.lblVoucherNo);
            this.grpVoucher.Controls.Add(this.VEditBox);
            this.grpVoucher.Controls.Add(this.chkPosted);
            this.grpVoucher.Controls.Add(this.lblDate);
            this.grpVoucher.Controls.Add(this.VDate);
            this.grpVoucher.Controls.Add(this.lblDiscription);
            this.grpVoucher.Controls.Add(this.txtDescription);
            this.grpVoucher.Controls.Add(this.lblChequeNo);
            this.grpVoucher.Controls.Add(this.txtChequeNo);
            this.grpVoucher.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVoucher.Location = new System.Drawing.Point(3, 10);
            this.grpVoucher.Name = "grpVoucher";
            this.grpVoucher.Size = new System.Drawing.Size(961, 150);
            this.grpVoucher.TabIndex = 18;
            this.grpVoucher.TabStop = false;
            this.grpVoucher.Text = "Voucher Info";
            // 
            // lblDeletedVoucher
            // 
            this.lblDeletedVoucher.AutoSize = true;
            this.lblDeletedVoucher.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblDeletedVoucher.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblDeletedVoucher.ForeColor = System.Drawing.Color.Red;
            this.lblDeletedVoucher.Location = new System.Drawing.Point(783, 14);
            this.lblDeletedVoucher.Name = "lblDeletedVoucher";
            this.lblDeletedVoucher.Size = new System.Drawing.Size(169, 25);
            this.lblDeletedVoucher.TabIndex = 4;
            this.lblDeletedVoucher.Text = "Deleted Voucher...";
            this.lblDeletedVoucher.UseCustomBackColor = true;
            this.lblDeletedVoucher.UseCustomForeColor = true;
            this.lblDeletedVoucher.Visible = false;
            // 
            // lblStatuMessage
            // 
            this.lblStatuMessage.Name = "lblStatuMessage";
            this.lblStatuMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatuMessage});
            this.statusStrip1.Location = new System.Drawing.Point(20, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(992, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pnlHead
            // 
            this.pnlHead.Controls.Add(this.grpVoucher);
            this.pnlHead.Location = new System.Drawing.Point(3, 3);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(967, 168);
            this.pnlHead.TabIndex = 21;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.btnPrint);
            this.pnlGrid.Controls.Add(this.btnSave);
            this.pnlGrid.Controls.Add(this.DgvVoucher);
            this.pnlGrid.Controls.Add(this.btnClose);
            this.pnlGrid.Controls.Add(this.btnNext);
            this.pnlGrid.Controls.Add(this.btnNewVoucher);
            this.pnlGrid.Controls.Add(this.btnDelete);
            this.pnlGrid.Controls.Add(this.btnPrevious);
            this.pnlGrid.Location = new System.Drawing.Point(3, 225);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(970, 288);
            this.pnlGrid.TabIndex = 22;
            this.pnlGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGrid_Paint);
            // 
            // DgvVoucher
            // 
            this.DgvVoucher.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvVoucher.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvVoucher.BackgroundColor = System.Drawing.Color.Cornsilk;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvVoucher.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvVoucher.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DgvVoucher.EnableHeadersVisualStyles = false;
            this.DgvVoucher.Location = new System.Drawing.Point(3, 14);
            this.DgvVoucher.MultiSelect = false;
            this.DgvVoucher.Name = "DgvVoucher";
            this.DgvVoucher.RowHeadersVisible = false;
            this.DgvVoucher.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvVoucher.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvVoucher.Size = new System.Drawing.Size(965, 212);
            this.DgvVoucher.TabIndex = 0;
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
            this.colLinkAccountNo.HeaderText = "Link#";
            this.colLinkAccountNo.Name = "colLinkAccountNo";
            this.colLinkAccountNo.Visible = false;
            // 
            // colAccountName
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colAccountName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAccountName.HeaderText = "A/C Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.Width = 250;
            // 
            // colClosingBalance
            // 
            this.colClosingBalance.HeaderText = "Closing Balance";
            this.colClosingBalance.Name = "colClosingBalance";
            this.colClosingBalance.ReadOnly = true;
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
            this.colDebit.Width = 120;
            // 
            // colCredit
            // 
            this.colCredit.HeaderText = "Credit";
            this.colCredit.Name = "colCredit";
            this.colCredit.Width = 120;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.pnlHead);
            this.flowLayoutPanel1.Controls.Add(this.pnlAdjustmentTypes);
            this.flowLayoutPanel1.Controls.Add(this.pnlGrid);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(992, 552);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // frmVouchers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1032, 632);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpEmployees);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmVouchers";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Payment Voucher";
            this.Load += new System.EventHandler(this.frmCashVoucher_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmPaymentVoucher_KeyPress);
            this.pnlAdjustmentTypes.ResumeLayout(false);
            this.pnlAdjustmentTypes.PerformLayout();
            this.grpEmployees.ResumeLayout(false);
            this.grpEmployees.PerformLayout();
            this.grpVoucher.ResumeLayout(false);
            this.grpVoucher.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlHead.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvVoucher)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroTile btnDelete;
        private MetroFramework.Controls.MetroTile btnClose;
        private TabDataGrid DgvVoucher;
        private MetroFramework.Controls.MetroLabel lblChequeNo;
        private System.Windows.Forms.CheckBox chkPosted;
        private MetroFramework.Controls.MetroLabel lblDate;
        private MetroFramework.Controls.MetroDateTime VDate;
        private MetroFramework.Controls.MetroLabel lblVoucherNo;
        private MetroFramework.Controls.MetroLabel lblDiscription;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroTextBox VEditBox;
        private MetroFramework.Controls.MetroTextBox txtChequeNo;
        private MetroFramework.Controls.MetroTile btnPrint;
        private MetroFramework.Controls.MetroTile btnPrevious;
        private MetroFramework.Controls.MetroTile btnNext;
        private MetroFramework.Controls.MetroTile btnNewVoucher;
        private MetroFramework.Controls.MetroComboBox cbxAdjustments;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.Panel pnlAdjustmentTypes;
        private MetroFramework.Controls.MetroTextBox txtEmployeeContact;
        private MetroFramework.Controls.MetroTextBox txtEmployeeName;
        private MetroFramework.Controls.MetroTextBox EmpEditCode;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.GroupBox grpVoucher;
        private System.Windows.Forms.GroupBox grpEmployees;
        private System.Windows.Forms.ToolStripStatusLabel lblStatuMessage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
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