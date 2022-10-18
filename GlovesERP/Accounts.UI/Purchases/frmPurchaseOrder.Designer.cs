namespace Accounts.UI
{
    partial class frmPurchaseOrder
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
            this.txtCustomerBrand = new MetroFramework.Controls.MetroTextBox();
            this.cbxPurchaseType = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.VDate = new MetroFramework.Controls.MetroDateTime();
            this.txtDeliveryTerms = new MetroFramework.Controls.MetroTextBox();
            this.txtPaymentTerm = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.VEditBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblDiscription = new MetroFramework.Controls.MetroLabel();
            this.lblVoucherNo = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.lblDate = new MetroFramework.Controls.MetroLabel();
            this.chkPosted = new MetroFramework.Controls.MetroCheckBox();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.txtPoNumber = new MetroFramework.Controls.MetroTextBox();
            this.lblPoNumber = new MetroFramework.Controls.MetroLabel();
            this.txtNTN = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.btnPrevious = new MetroFramework.Controls.MetroTile();
            this.btnNext = new MetroFramework.Controls.MetroTile();
            this.btnNew = new MetroFramework.Controls.MetroTile();
            this.PurchasesEditBox = new MetroFramework.Controls.MetroTextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnPrint = new MetroFramework.Controls.MetroTile();
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.txttotalAmount = new MetroFramework.Controls.MetroTextBox();
            this.lblParty = new MetroFramework.Controls.MetroLabel();
            this.txtParty = new MetroFramework.Controls.MetroTextBox();
            this.DgvStockReceipt = new Accounts.UI.TabDataGrid();
            this.colDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new DataGridViewProductWaterMarkColumn(); //new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpacking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSizes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblVoucherStatus = new MetroFramework.Controls.MetroLabel();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStockReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatuMessage});
            this.statusStrip1.Location = new System.Drawing.Point(20, 584);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(946, 22);
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
            this.groupBox1.Controls.Add(this.txtCustomerBrand);
            this.groupBox1.Controls.Add(this.cbxPurchaseType);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.VDate);
            this.groupBox1.Controls.Add(this.txtDeliveryTerms);
            this.groupBox1.Controls.Add(this.txtPaymentTerm);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.VEditBox);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.lblDiscription);
            this.groupBox1.Controls.Add(this.lblVoucherNo);
            this.groupBox1.Controls.Add(this.metroLabel6);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.chkPosted);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(957, 180);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PO Information";
            // 
            // txtCustomerBrand
            // 
            // 
            // 
            // 
            this.txtCustomerBrand.CustomButton.Image = null;
            this.txtCustomerBrand.CustomButton.Location = new System.Drawing.Point(205, 1);
            this.txtCustomerBrand.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomerBrand.CustomButton.Name = "";
            this.txtCustomerBrand.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCustomerBrand.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCustomerBrand.CustomButton.TabIndex = 1;
            this.txtCustomerBrand.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCustomerBrand.CustomButton.UseSelectable = true;
            this.txtCustomerBrand.CustomButton.Visible = false;
            this.txtCustomerBrand.Lines = new string[0];
            this.txtCustomerBrand.Location = new System.Drawing.Point(697, 81);
            this.txtCustomerBrand.MaxLength = 32767;
            this.txtCustomerBrand.Name = "txtCustomerBrand";
            this.txtCustomerBrand.PasswordChar = '\0';
            this.txtCustomerBrand.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCustomerBrand.SelectedText = "";
            this.txtCustomerBrand.SelectionLength = 0;
            this.txtCustomerBrand.SelectionStart = 0;
            this.txtCustomerBrand.ShortcutsEnabled = true;
            this.txtCustomerBrand.Size = new System.Drawing.Size(227, 23);
            this.txtCustomerBrand.Style = MetroFramework.MetroColorStyle.Green;
            this.txtCustomerBrand.TabIndex = 26;
            this.txtCustomerBrand.UseSelectable = true;
            this.txtCustomerBrand.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCustomerBrand.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cbxPurchaseType
            // 
            this.cbxPurchaseType.FormattingEnabled = true;
            this.cbxPurchaseType.ItemHeight = 23;
            this.cbxPurchaseType.Items.AddRange(new object[] {
            "",
            "Gloves Purchase Order",
            "Garments Purchase Order",
            "Misc Purchases"});
            this.cbxPurchaseType.Location = new System.Drawing.Point(90, 53);
            this.cbxPurchaseType.Name = "cbxPurchaseType";
            this.cbxPurchaseType.Size = new System.Drawing.Size(199, 29);
            this.cbxPurchaseType.TabIndex = 23;
            this.cbxPurchaseType.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(599, 82);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(96, 19);
            this.metroLabel4.TabIndex = 28;
            this.metroLabel4.Text = "Brand(If Any) :";
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // VDate
            // 
            this.VDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.VDate.Location = new System.Drawing.Point(359, 22);
            this.VDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.VDate.Name = "VDate";
            this.VDate.Size = new System.Drawing.Size(168, 29);
            this.VDate.TabIndex = 22;
            // 
            // txtDeliveryTerms
            // 
            // 
            // 
            // 
            this.txtDeliveryTerms.CustomButton.Image = null;
            this.txtDeliveryTerms.CustomButton.Location = new System.Drawing.Point(146, 1);
            this.txtDeliveryTerms.CustomButton.Name = "";
            this.txtDeliveryTerms.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtDeliveryTerms.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDeliveryTerms.CustomButton.TabIndex = 1;
            this.txtDeliveryTerms.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDeliveryTerms.CustomButton.UseSelectable = true;
            this.txtDeliveryTerms.CustomButton.Visible = false;
            this.txtDeliveryTerms.Lines = new string[0];
            this.txtDeliveryTerms.Location = new System.Drawing.Point(368, 88);
            this.txtDeliveryTerms.MaxLength = 32767;
            this.txtDeliveryTerms.Name = "txtDeliveryTerms";
            this.txtDeliveryTerms.PasswordChar = '\0';
            this.txtDeliveryTerms.PromptText = "Payment Term";
            this.txtDeliveryTerms.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDeliveryTerms.SelectedText = "";
            this.txtDeliveryTerms.SelectionLength = 0;
            this.txtDeliveryTerms.SelectionStart = 0;
            this.txtDeliveryTerms.ShortcutsEnabled = true;
            this.txtDeliveryTerms.Size = new System.Drawing.Size(168, 23);
            this.txtDeliveryTerms.Style = MetroFramework.MetroColorStyle.Green;
            this.txtDeliveryTerms.TabIndex = 21;
            this.txtDeliveryTerms.UseSelectable = true;
            this.txtDeliveryTerms.WaterMark = "Payment Term";
            this.txtDeliveryTerms.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDeliveryTerms.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtDeliveryTerms.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.VEditBox_ButtonClick);
            // 
            // txtPaymentTerm
            // 
            // 
            // 
            // 
            this.txtPaymentTerm.CustomButton.Image = null;
            this.txtPaymentTerm.CustomButton.Location = new System.Drawing.Point(146, 1);
            this.txtPaymentTerm.CustomButton.Name = "";
            this.txtPaymentTerm.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPaymentTerm.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPaymentTerm.CustomButton.TabIndex = 1;
            this.txtPaymentTerm.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPaymentTerm.CustomButton.UseSelectable = true;
            this.txtPaymentTerm.CustomButton.Visible = false;
            this.txtPaymentTerm.Lines = new string[0];
            this.txtPaymentTerm.Location = new System.Drawing.Point(90, 86);
            this.txtPaymentTerm.MaxLength = 32767;
            this.txtPaymentTerm.Name = "txtPaymentTerm";
            this.txtPaymentTerm.PasswordChar = '\0';
            this.txtPaymentTerm.PromptText = "Payment Term";
            this.txtPaymentTerm.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPaymentTerm.SelectedText = "";
            this.txtPaymentTerm.SelectionLength = 0;
            this.txtPaymentTerm.SelectionStart = 0;
            this.txtPaymentTerm.ShortcutsEnabled = true;
            this.txtPaymentTerm.Size = new System.Drawing.Size(168, 23);
            this.txtPaymentTerm.Style = MetroFramework.MetroColorStyle.Green;
            this.txtPaymentTerm.TabIndex = 21;
            this.txtPaymentTerm.UseSelectable = true;
            this.txtPaymentTerm.WaterMark = "Payment Term";
            this.txtPaymentTerm.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPaymentTerm.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPaymentTerm.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.VEditBox_ButtonClick);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(263, 88);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(99, 19);
            this.metroLabel2.TabIndex = 19;
            this.metroLabel2.Text = "Delivery Terms";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // VEditBox
            // 
            // 
            // 
            // 
            this.VEditBox.CustomButton.Image = null;
            this.VEditBox.CustomButton.Location = new System.Drawing.Point(178, 1);
            this.VEditBox.CustomButton.Name = "";
            this.VEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.VEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.VEditBox.CustomButton.TabIndex = 1;
            this.VEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.VEditBox.CustomButton.UseSelectable = true;
            this.VEditBox.Lines = new string[0];
            this.VEditBox.Location = new System.Drawing.Point(90, 27);
            this.VEditBox.MaxLength = 32767;
            this.VEditBox.Name = "VEditBox";
            this.VEditBox.PasswordChar = '\0';
            this.VEditBox.PromptText = "Po No";
            this.VEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.VEditBox.SelectedText = "";
            this.VEditBox.SelectionLength = 0;
            this.VEditBox.SelectionStart = 0;
            this.VEditBox.ShortcutsEnabled = true;
            this.VEditBox.ShowButton = true;
            this.VEditBox.Size = new System.Drawing.Size(200, 23);
            this.VEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.VEditBox.TabIndex = 21;
            this.VEditBox.UseSelectable = true;
            this.VEditBox.WaterMark = "Po No";
            this.VEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.VEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.VEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.VEditBox_ButtonClick);
            this.VEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VEditBox_KeyPress);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(5, 88);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 19;
            this.metroLabel1.Text = "Pay Term";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // lblDiscription
            // 
            this.lblDiscription.AutoSize = true;
            this.lblDiscription.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblDiscription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDiscription.Location = new System.Drawing.Point(3, 127);
            this.lblDiscription.Name = "lblDiscription";
            this.lblDiscription.Size = new System.Drawing.Size(81, 19);
            this.lblDiscription.TabIndex = 19;
            this.lblDiscription.Text = "Discription :";
            this.lblDiscription.UseCustomBackColor = true;
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblVoucherNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblVoucherNo.Location = new System.Drawing.Point(7, 28);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(47, 19);
            this.lblVoucherNo.TabIndex = 19;
            this.lblVoucherNo.Text = "PO # :";
            this.lblVoucherNo.UseCustomBackColor = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(6, 55);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(65, 19);
            this.metroLabel6.TabIndex = 19;
            this.metroLabel6.Text = "Po Type :";
            this.metroLabel6.UseCustomBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDate.Location = new System.Drawing.Point(297, 25);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 19);
            this.lblDate.TabIndex = 19;
            this.lblDate.Text = "Date :";
            this.lblDate.UseCustomBackColor = true;
            // 
            // chkPosted
            // 
            this.chkPosted.AutoSize = true;
            this.chkPosted.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.chkPosted.Location = new System.Drawing.Point(295, 61);
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
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(780, 1);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(53, 53);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(90, 114);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(834, 55);
            this.txtDescription.TabIndex = 16;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPoNumber
            // 
            // 
            // 
            // 
            this.txtPoNumber.CustomButton.Image = null;
            this.txtPoNumber.CustomButton.Location = new System.Drawing.Point(205, 1);
            this.txtPoNumber.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtPoNumber.CustomButton.Name = "";
            this.txtPoNumber.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPoNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPoNumber.CustomButton.TabIndex = 1;
            this.txtPoNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPoNumber.CustomButton.UseSelectable = true;
            this.txtPoNumber.Lines = new string[0];
            this.txtPoNumber.Location = new System.Drawing.Point(702, 117);
            this.txtPoNumber.MaxLength = 32767;
            this.txtPoNumber.Name = "txtPoNumber";
            this.txtPoNumber.PasswordChar = '\0';
            this.txtPoNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPoNumber.SelectedText = "";
            this.txtPoNumber.SelectionLength = 0;
            this.txtPoNumber.SelectionStart = 0;
            this.txtPoNumber.ShortcutsEnabled = true;
            this.txtPoNumber.ShowButton = true;
            this.txtPoNumber.Size = new System.Drawing.Size(227, 23);
            this.txtPoNumber.Style = MetroFramework.MetroColorStyle.Green;
            this.txtPoNumber.TabIndex = 25;
            this.txtPoNumber.UseSelectable = true;
            this.txtPoNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPoNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPoNumber.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtPoNumber_ButtonClick);
            // 
            // lblPoNumber
            // 
            this.lblPoNumber.AutoSize = true;
            this.lblPoNumber.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblPoNumber.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPoNumber.Location = new System.Drawing.Point(560, 119);
            this.lblPoNumber.Name = "lblPoNumber";
            this.lblPoNumber.Size = new System.Drawing.Size(140, 19);
            this.lblPoNumber.TabIndex = 27;
            this.lblPoNumber.Text = "Customer Po(If Any) :";
            this.lblPoNumber.UseCustomBackColor = true;
            // 
            // txtNTN
            // 
            // 
            // 
            // 
            this.txtNTN.CustomButton.Image = null;
            this.txtNTN.CustomButton.Location = new System.Drawing.Point(76, 1);
            this.txtNTN.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtNTN.CustomButton.Name = "";
            this.txtNTN.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNTN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNTN.CustomButton.TabIndex = 1;
            this.txtNTN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNTN.CustomButton.UseSelectable = true;
            this.txtNTN.CustomButton.Visible = false;
            this.txtNTN.Lines = new string[0];
            this.txtNTN.Location = new System.Drawing.Point(264, 14);
            this.txtNTN.MaxLength = 32767;
            this.txtNTN.Name = "txtNTN";
            this.txtNTN.PasswordChar = '\0';
            this.txtNTN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNTN.SelectedText = "";
            this.txtNTN.SelectionLength = 0;
            this.txtNTN.SelectionStart = 0;
            this.txtNTN.ShortcutsEnabled = true;
            this.txtNTN.Size = new System.Drawing.Size(98, 23);
            this.txtNTN.TabIndex = 19;
            this.txtNTN.UseSelectable = true;
            this.txtNTN.Visible = false;
            this.txtNTN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNTN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSave.Location = new System.Drawing.Point(190, 6);
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
            // btnDelete
            // 
            this.btnDelete.ActiveControl = null;
            this.btnDelete.BackColor = System.Drawing.Color.DarkCyan;
            this.btnDelete.Location = new System.Drawing.Point(292, 6);
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
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.BackColor = System.Drawing.Color.DarkCyan;
            this.btnClose.Location = new System.Drawing.Point(394, 6);
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
            // btnPrevious
            // 
            this.btnPrevious.ActiveControl = null;
            this.btnPrevious.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPrevious.Location = new System.Drawing.Point(497, 6);
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
            this.btnNext.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNext.Location = new System.Drawing.Point(599, 6);
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
            this.btnNew.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNew.Location = new System.Drawing.Point(701, 6);
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
            // PurchasesEditBox
            // 
            // 
            // 
            // 
            this.PurchasesEditBox.CustomButton.Image = null;
            this.PurchasesEditBox.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.PurchasesEditBox.CustomButton.Name = "";
            this.PurchasesEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.PurchasesEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PurchasesEditBox.CustomButton.TabIndex = 1;
            this.PurchasesEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PurchasesEditBox.CustomButton.UseSelectable = true;
            this.PurchasesEditBox.Lines = new string[0];
            this.PurchasesEditBox.Location = new System.Drawing.Point(367, 13);
            this.PurchasesEditBox.MaxLength = 32767;
            this.PurchasesEditBox.Name = "PurchasesEditBox";
            this.PurchasesEditBox.PasswordChar = '\0';
            this.PurchasesEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PurchasesEditBox.SelectedText = "";
            this.PurchasesEditBox.SelectionLength = 0;
            this.PurchasesEditBox.SelectionStart = 0;
            this.PurchasesEditBox.ShortcutsEnabled = true;
            this.PurchasesEditBox.ShowButton = true;
            this.PurchasesEditBox.Size = new System.Drawing.Size(75, 23);
            this.PurchasesEditBox.Style = MetroFramework.MetroColorStyle.Teal;
            this.PurchasesEditBox.TabIndex = 1;
            this.PurchasesEditBox.UseSelectable = true;
            this.PurchasesEditBox.Visible = false;
            this.PurchasesEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PurchasesEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnNext);
            this.pnlButtons.Controls.Add(this.btnPrint);
            this.pnlButtons.Controls.Add(this.btnNew);
            this.pnlButtons.Controls.Add(this.btnPrevious);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Location = new System.Drawing.Point(4, 506);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(960, 54);
            this.pnlButtons.TabIndex = 28;
            // 
            // btnPrint
            // 
            this.btnPrint.ActiveControl = null;
            this.btnPrint.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPrint.Location = new System.Drawing.Point(805, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(149, 40);
            this.btnPrint.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print Purchase Order";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.UseCustomBackColor = true;
            this.btnPrint.UseSelectable = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pnlProducts
            // 
            this.pnlProducts.Controls.Add(this.lblVoucherStatus);
            this.pnlProducts.Controls.Add(this.txttotalAmount);
            this.pnlProducts.Location = new System.Drawing.Point(8, 246);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Size = new System.Drawing.Size(956, 253);
            this.pnlProducts.TabIndex = 27;
            // 
            // txttotalAmount
            // 
            // 
            // 
            // 
            this.txttotalAmount.CustomButton.Image = null;
            this.txttotalAmount.CustomButton.Location = new System.Drawing.Point(144, 1);
            this.txttotalAmount.CustomButton.Name = "";
            this.txttotalAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txttotalAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txttotalAmount.CustomButton.TabIndex = 1;
            this.txttotalAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txttotalAmount.CustomButton.UseSelectable = true;
            this.txttotalAmount.CustomButton.Visible = false;
            this.txttotalAmount.Lines = new string[0];
            this.txttotalAmount.Location = new System.Drawing.Point(787, 221);
            this.txttotalAmount.MaxLength = 32767;
            this.txttotalAmount.Name = "txttotalAmount";
            this.txttotalAmount.PasswordChar = '\0';
            this.txttotalAmount.PromptText = "Total Amount";
            this.txttotalAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txttotalAmount.SelectedText = "";
            this.txttotalAmount.SelectionLength = 0;
            this.txttotalAmount.SelectionStart = 0;
            this.txttotalAmount.ShortcutsEnabled = true;
            this.txttotalAmount.Size = new System.Drawing.Size(166, 23);
            this.txttotalAmount.Style = MetroFramework.MetroColorStyle.Green;
            this.txttotalAmount.TabIndex = 21;
            this.txttotalAmount.UseSelectable = true;
            this.txttotalAmount.WaterMark = "Total Amount";
            this.txttotalAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txttotalAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txttotalAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VEditBox_KeyPress);
            // 
            // lblParty
            // 
            this.lblParty.AutoSize = true;
            this.lblParty.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblParty.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblParty.Location = new System.Drawing.Point(605, 92);
            this.lblParty.Name = "lblParty";
            this.lblParty.Size = new System.Drawing.Size(60, 19);
            this.lblParty.TabIndex = 27;
            this.lblParty.Text = "To Party";
            this.lblParty.UseCustomBackColor = true;
            // 
            // txtParty
            // 
            // 
            // 
            // 
            this.txtParty.CustomButton.Image = null;
            this.txtParty.CustomButton.Location = new System.Drawing.Point(205, 1);
            this.txtParty.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtParty.CustomButton.Name = "";
            this.txtParty.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtParty.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtParty.CustomButton.TabIndex = 1;
            this.txtParty.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtParty.CustomButton.UseSelectable = true;
            this.txtParty.Lines = new string[0];
            this.txtParty.Location = new System.Drawing.Point(702, 91);
            this.txtParty.MaxLength = 32767;
            this.txtParty.Name = "txtParty";
            this.txtParty.PasswordChar = '\0';
            this.txtParty.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtParty.SelectedText = "";
            this.txtParty.SelectionLength = 0;
            this.txtParty.SelectionStart = 0;
            this.txtParty.ShortcutsEnabled = true;
            this.txtParty.ShowButton = true;
            this.txtParty.Size = new System.Drawing.Size(227, 23);
            this.txtParty.Style = MetroFramework.MetroColorStyle.Green;
            this.txtParty.TabIndex = 25;
            this.txtParty.UseSelectable = true;
            this.txtParty.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtParty.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtParty.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtParty_ButtonClick);
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
            this.DgvStockReceipt.ColumnHeadersHeight = 27;
            this.DgvStockReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetailId,
            this.colIdItem,
            this.colItemName,
            this.colpacking,
            this.colSizes,
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
            this.DgvStockReceipt.Location = new System.Drawing.Point(8, 246);
            this.DgvStockReceipt.MultiSelect = false;
            this.DgvStockReceipt.Name = "DgvStockReceipt";
            this.DgvStockReceipt.RowHeadersVisible = false;
            this.DgvStockReceipt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvStockReceipt.Size = new System.Drawing.Size(954, 216);
            this.DgvStockReceipt.TabIndex = 3;
            this.DgvStockReceipt.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvStockReceipt_CellBeginEdit);
            this.DgvStockReceipt.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvStockReceipt_CellEndEdit);
            this.DgvStockReceipt.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvStockReceipt_CellEnter);
            this.DgvStockReceipt.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvStockReceipt_CellLeave);
            this.DgvStockReceipt.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvStockReceipt_EditingControlShowing);
            this.DgvStockReceipt.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvStockReceipt_RowValidating);
            this.DgvStockReceipt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvStockReceipt_KeyDown);
            this.DgvStockReceipt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DgvStockReceipt_KeyPress);
            // 
            // colDetailId
            // 
            this.colDetailId.HeaderText = "StockReceiptId";
            this.colDetailId.Name = "colDetailId";
            this.colDetailId.Visible = false;
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
            this.colpacking.HeaderText = "Uom";
            this.colpacking.Name = "colpacking";
            this.colpacking.ReadOnly = true;
            this.colpacking.Width = 138;
            // 
            // colSizes
            // 
            this.colSizes.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colSizes.HeaderText = "Size";
            this.colSizes.Name = "colSizes";
            this.colSizes.Width = 200;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            this.colQty.HeaderText = "Quantity";
            this.colQty.Name = "colQty";
            this.colQty.Width = 150;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 120;
            // 
            // lblVoucherStatus
            // 
            this.lblVoucherStatus.AutoSize = true;
            this.lblVoucherStatus.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblVoucherStatus.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblVoucherStatus.ForeColor = System.Drawing.Color.Red;
            this.lblVoucherStatus.Location = new System.Drawing.Point(4, 222);
            this.lblVoucherStatus.Name = "lblVoucherStatus";
            this.lblVoucherStatus.Size = new System.Drawing.Size(154, 25);
            this.lblVoucherStatus.TabIndex = 31;
            this.lblVoucherStatus.Text = "Deleted Voucher";
            this.lblVoucherStatus.UseCustomForeColor = true;
            this.lblVoucherStatus.Visible = false;
            // 
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(986, 626);
            this.Controls.Add(this.DgvStockReceipt);
            this.Controls.Add(this.txtNTN);
            this.Controls.Add(this.txtParty);
            this.Controls.Add(this.lblParty);
            this.Controls.Add(this.txtPoNumber);
            this.Controls.Add(this.lblPoNumber);
            this.Controls.Add(this.PurchasesEditBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlProducts);
            this.Controls.Add(this.pnlButtons);
            this.DoubleBuffered = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPurchaseOrder";
            this.Text = "Purchase Order";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmStockReceipt_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmStockReceipt_KeyPress);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlProducts.ResumeLayout(false);
            this.pnlProducts.PerformLayout();
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
        private MetroFramework.Controls.MetroTextBox txtNTN;
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
        private MetroFramework.Controls.MetroTextBox PurchasesEditBox;
        private MetroFramework.Controls.MetroTile btnPrevious;
        private MetroFramework.Controls.MetroTile btnNext;
        private MetroFramework.Controls.MetroTile btnNew;
        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.Panel pnlButtons;
        private MetroFramework.Controls.MetroComboBox cbxPurchaseType;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtCustomerBrand;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtPoNumber;
        private MetroFramework.Controls.MetroLabel lblPoNumber;
        private MetroFramework.Controls.MetroTextBox txtPaymentTerm;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpacking;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSizes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private MetroFramework.Controls.MetroTextBox txttotalAmount;
        private MetroFramework.Controls.MetroLabel lblParty;
        private MetroFramework.Controls.MetroTextBox txtParty;
        private MetroFramework.Controls.MetroTile btnPrint;
        private MetroFramework.Controls.MetroTextBox txtDeliveryTerms;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblVoucherStatus;
    }
}