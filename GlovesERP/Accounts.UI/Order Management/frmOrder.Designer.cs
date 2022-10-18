namespace Accounts.UI
{
    partial class frmOrder
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
            this.btnTrackOrders = new MetroFramework.Controls.MetroButton();
            this.chkPosted = new MetroFramework.Controls.MetroCheckBox();
            this.SEditBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dtProduction = new MetroFramework.Controls.MetroDateTime();
            this.dtDelivery = new MetroFramework.Controls.MetroDateTime();
            this.dtOrder = new MetroFramework.Controls.MetroDateTime();
            this.txtCurrency = new MetroFramework.Controls.MetroTextBox();
            this.txtBrandName = new MetroFramework.Controls.MetroTextBox();
            this.txtCustomerPo = new MetroFramework.Controls.MetroTextBox();
            this.VEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblDiscription = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblVoucherNo = new MetroFramework.Controls.MetroLabel();
            this.lblDate = new MetroFramework.Controls.MetroLabel();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.btnPrevious = new MetroFramework.Controls.MetroTile();
            this.btnNext = new MetroFramework.Controls.MetroTile();
            this.btnNew = new MetroFramework.Controls.MetroTile();
            this.btnReq = new MetroFramework.Controls.MetroTile();
            this.btnCloseOrder = new MetroFramework.Controls.MetroTile();
            this.grdOrders = new Accounts.UI.TabDataGrid();
            this.colIdOrderDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new Accounts.UI.DataGridViewProductWaterMarkColumn();
            this.colpacking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colconfiguration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveredUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalAmount = new MetroFramework.Controls.MetroTextBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatuMessage});
            this.statusStrip1.Location = new System.Drawing.Point(20, 490);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1062, 22);
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
            this.groupBox1.Controls.Add(this.btnTrackOrders);
            this.groupBox1.Controls.Add(this.chkPosted);
            this.groupBox1.Controls.Add(this.SEditBox);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.dtProduction);
            this.groupBox1.Controls.Add(this.dtDelivery);
            this.groupBox1.Controls.Add(this.dtOrder);
            this.groupBox1.Controls.Add(this.txtCurrency);
            this.groupBox1.Controls.Add(this.txtBrandName);
            this.groupBox1.Controls.Add(this.txtCustomerPo);
            this.groupBox1.Controls.Add(this.VEditBox);
            this.groupBox1.Controls.Add(this.lblDiscription);
            this.groupBox1.Controls.Add(this.metroLabel6);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.lblVoucherNo);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1091, 169);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Information";
            // 
            // btnTrackOrders
            // 
            this.btnTrackOrders.Location = new System.Drawing.Point(336, 35);
            this.btnTrackOrders.Name = "btnTrackOrders";
            this.btnTrackOrders.Size = new System.Drawing.Size(75, 23);
            this.btnTrackOrders.TabIndex = 26;
            this.btnTrackOrders.Text = "Track Orders";
            this.btnTrackOrders.UseCustomBackColor = true;
            this.btnTrackOrders.UseSelectable = true;
            this.btnTrackOrders.Click += new System.EventHandler(this.btnTrackOrders_Click);
            // 
            // chkPosted
            // 
            this.chkPosted.AutoSize = true;
            this.chkPosted.Location = new System.Drawing.Point(243, 90);
            this.chkPosted.Name = "chkPosted";
            this.chkPosted.Size = new System.Drawing.Size(59, 15);
            this.chkPosted.TabIndex = 25;
            this.chkPosted.Text = "Posted";
            this.chkPosted.UseCustomBackColor = true;
            this.chkPosted.UseSelectable = true;
            // 
            // SEditBox
            // 
            // 
            // 
            // 
            this.SEditBox.CustomButton.Image = null;
            this.SEditBox.CustomButton.Location = new System.Drawing.Point(303, 1);
            this.SEditBox.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.SEditBox.CustomButton.Name = "";
            this.SEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SEditBox.CustomButton.TabIndex = 1;
            this.SEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SEditBox.CustomButton.UseSelectable = true;
            this.SEditBox.Lines = new string[0];
            this.SEditBox.Location = new System.Drawing.Point(87, 60);
            this.SEditBox.MaxLength = 32767;
            this.SEditBox.Name = "SEditBox";
            this.SEditBox.PasswordChar = '\0';
            this.SEditBox.PromptText = "Customer Here";
            this.SEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SEditBox.SelectedText = "";
            this.SEditBox.SelectionLength = 0;
            this.SEditBox.SelectionStart = 0;
            this.SEditBox.ShortcutsEnabled = true;
            this.SEditBox.ShowButton = true;
            this.SEditBox.Size = new System.Drawing.Size(325, 23);
            this.SEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.SEditBox.TabIndex = 0;
            this.SEditBox.UseSelectable = true;
            this.SEditBox.WaterMark = "Customer Here";
            this.SEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.SEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.SEditBox_ButtonClick);
            this.SEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SEditBox_KeyPress);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(5, 61);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(76, 19);
            this.metroLabel2.TabIndex = 24;
            this.metroLabel2.Text = "Customer :";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // dtProduction
            // 
            this.dtProduction.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtProduction.Location = new System.Drawing.Point(907, 68);
            this.dtProduction.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtProduction.Name = "dtProduction";
            this.dtProduction.Size = new System.Drawing.Size(146, 29);
            this.dtProduction.TabIndex = 5;
            this.dtProduction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtProduction_KeyPress);
            // 
            // dtDelivery
            // 
            this.dtDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDelivery.Location = new System.Drawing.Point(907, 104);
            this.dtDelivery.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtDelivery.Name = "dtDelivery";
            this.dtDelivery.Size = new System.Drawing.Size(146, 29);
            this.dtDelivery.TabIndex = 6;
            this.dtDelivery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtDelivery_KeyPress);
            // 
            // dtOrder
            // 
            this.dtOrder.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtOrder.Location = new System.Drawing.Point(907, 36);
            this.dtOrder.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtOrder.Name = "dtOrder";
            this.dtOrder.Size = new System.Drawing.Size(146, 29);
            this.dtOrder.TabIndex = 4;
            this.dtOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtOrder_KeyPress);
            // 
            // txtCurrency
            // 
            // 
            // 
            // 
            this.txtCurrency.CustomButton.Image = null;
            this.txtCurrency.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.txtCurrency.CustomButton.Name = "";
            this.txtCurrency.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCurrency.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCurrency.CustomButton.TabIndex = 1;
            this.txtCurrency.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCurrency.CustomButton.UseSelectable = true;
            this.txtCurrency.CustomButton.Visible = false;
            this.txtCurrency.Lines = new string[0];
            this.txtCurrency.Location = new System.Drawing.Point(87, 87);
            this.txtCurrency.MaxLength = 32767;
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.PasswordChar = '\0';
            this.txtCurrency.PromptText = "Currency";
            this.txtCurrency.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrency.SelectedText = "";
            this.txtCurrency.SelectionLength = 0;
            this.txtCurrency.SelectionStart = 0;
            this.txtCurrency.ShortcutsEnabled = true;
            this.txtCurrency.Size = new System.Drawing.Size(151, 23);
            this.txtCurrency.Style = MetroFramework.MetroColorStyle.Green;
            this.txtCurrency.TabIndex = 2;
            this.txtCurrency.UseSelectable = true;
            this.txtCurrency.WaterMark = "Currency";
            this.txtCurrency.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrency.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtCurrency.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtBrandName_ButtonClick);
            this.txtCurrency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBrandName_KeyPress);
            // 
            // txtBrandName
            // 
            // 
            // 
            // 
            this.txtBrandName.CustomButton.Image = null;
            this.txtBrandName.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.txtBrandName.CustomButton.Name = "";
            this.txtBrandName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBrandName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBrandName.CustomButton.TabIndex = 1;
            this.txtBrandName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBrandName.CustomButton.UseSelectable = true;
            this.txtBrandName.Lines = new string[0];
            this.txtBrandName.Location = new System.Drawing.Point(526, 32);
            this.txtBrandName.MaxLength = 32767;
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.PasswordChar = '\0';
            this.txtBrandName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBrandName.SelectedText = "";
            this.txtBrandName.SelectionLength = 0;
            this.txtBrandName.SelectionStart = 0;
            this.txtBrandName.ShortcutsEnabled = true;
            this.txtBrandName.ShowButton = true;
            this.txtBrandName.Size = new System.Drawing.Size(151, 23);
            this.txtBrandName.Style = MetroFramework.MetroColorStyle.Green;
            this.txtBrandName.TabIndex = 2;
            this.txtBrandName.UseSelectable = true;
            this.txtBrandName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBrandName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtBrandName.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtBrandName_ButtonClick);
            this.txtBrandName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBrandName_KeyPress);
            // 
            // txtCustomerPo
            // 
            // 
            // 
            // 
            this.txtCustomerPo.CustomButton.Image = null;
            this.txtCustomerPo.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.txtCustomerPo.CustomButton.Name = "";
            this.txtCustomerPo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCustomerPo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCustomerPo.CustomButton.TabIndex = 1;
            this.txtCustomerPo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCustomerPo.CustomButton.UseSelectable = true;
            this.txtCustomerPo.Lines = new string[0];
            this.txtCustomerPo.Location = new System.Drawing.Point(526, 57);
            this.txtCustomerPo.MaxLength = 32767;
            this.txtCustomerPo.Name = "txtCustomerPo";
            this.txtCustomerPo.PasswordChar = '\0';
            this.txtCustomerPo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCustomerPo.SelectedText = "";
            this.txtCustomerPo.SelectionLength = 0;
            this.txtCustomerPo.SelectionStart = 0;
            this.txtCustomerPo.ShortcutsEnabled = true;
            this.txtCustomerPo.ShowButton = true;
            this.txtCustomerPo.Size = new System.Drawing.Size(151, 23);
            this.txtCustomerPo.Style = MetroFramework.MetroColorStyle.Green;
            this.txtCustomerPo.TabIndex = 1;
            this.txtCustomerPo.UseSelectable = true;
            this.txtCustomerPo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCustomerPo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomerPo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerPo_KeyPress);
            this.txtCustomerPo.Leave += new System.EventHandler(this.txtCustomerPo_Leave);
            // 
            // VEditBox
            // 
            // 
            // 
            // 
            this.VEditBox.CustomButton.Image = null;
            this.VEditBox.CustomButton.Location = new System.Drawing.Point(227, 1);
            this.VEditBox.CustomButton.Name = "";
            this.VEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.VEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.VEditBox.CustomButton.TabIndex = 1;
            this.VEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.VEditBox.CustomButton.UseSelectable = true;
            this.VEditBox.Lines = new string[0];
            this.VEditBox.Location = new System.Drawing.Point(87, 35);
            this.VEditBox.MaxLength = 32767;
            this.VEditBox.Name = "VEditBox";
            this.VEditBox.PasswordChar = '\0';
            this.VEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.VEditBox.SelectedText = "";
            this.VEditBox.SelectionLength = 0;
            this.VEditBox.SelectionStart = 0;
            this.VEditBox.ShortcutsEnabled = true;
            this.VEditBox.ShowButton = true;
            this.VEditBox.Size = new System.Drawing.Size(249, 23);
            this.VEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.VEditBox.TabIndex = 21;
            this.VEditBox.UseSelectable = true;
            this.VEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.VEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.VEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.VEditBox_ButtonClick);
            this.VEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VEditBox_KeyPress);
            // 
            // lblDiscription
            // 
            this.lblDiscription.AutoSize = true;
            this.lblDiscription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDiscription.Location = new System.Drawing.Point(3, 129);
            this.lblDiscription.Name = "lblDiscription";
            this.lblDiscription.Size = new System.Drawing.Size(81, 19);
            this.lblDiscription.TabIndex = 19;
            this.lblDiscription.Text = "Discription :";
            this.lblDiscription.UseCustomBackColor = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(428, 36);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(52, 19);
            this.metroLabel6.TabIndex = 19;
            this.metroLabel6.Text = "Brand :";
            this.metroLabel6.UseCustomBackColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(787, 74);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(116, 19);
            this.metroLabel4.TabIndex = 19;
            this.metroLabel4.Text = "Production Date :";
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(421, 57);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(101, 19);
            this.metroLabel3.TabIndex = 19;
            this.metroLabel3.Text = "Customer Po #";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(810, 109);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(98, 19);
            this.metroLabel1.TabIndex = 19;
            this.metroLabel1.Text = "Delivery Date :";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblVoucherNo.Location = new System.Drawing.Point(6, 36);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(74, 19);
            this.lblVoucherNo.TabIndex = 19;
            this.lblVoucherNo.Text = "Order No :";
            this.lblVoucherNo.UseCustomBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDate.Location = new System.Drawing.Point(819, 41);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(85, 19);
            this.lblDate.TabIndex = 19;
            this.lblDate.Text = "Order Date :";
            this.lblDate.UseCustomBackColor = true;
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(527, 2);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(47, 47);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(87, 112);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(577, 52);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(261, 434);
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
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(363, 434);
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
            this.btnClose.Location = new System.Drawing.Point(465, 434);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 40);
            this.btnClose.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.ActiveControl = null;
            this.btnPrevious.Location = new System.Drawing.Point(567, 434);
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
            this.btnNext.Location = new System.Drawing.Point(669, 434);
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
            this.btnNew.Location = new System.Drawing.Point(771, 434);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(101, 40);
            this.btnNew.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "New Order";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNew.UseSelectable = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnReq
            // 
            this.btnReq.ActiveControl = null;
            this.btnReq.Location = new System.Drawing.Point(873, 434);
            this.btnReq.Name = "btnReq";
            this.btnReq.Size = new System.Drawing.Size(101, 40);
            this.btnReq.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnReq.TabIndex = 10;
            this.btnReq.Text = "Requisition";
            this.btnReq.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReq.UseSelectable = true;
            this.btnReq.Click += new System.EventHandler(this.btnReq_Click);
            // 
            // btnCloseOrder
            // 
            this.btnCloseOrder.ActiveControl = null;
            this.btnCloseOrder.Location = new System.Drawing.Point(975, 434);
            this.btnCloseOrder.Name = "btnCloseOrder";
            this.btnCloseOrder.Size = new System.Drawing.Size(121, 40);
            this.btnCloseOrder.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCloseOrder.TabIndex = 10;
            this.btnCloseOrder.Text = "Complete Order";
            this.btnCloseOrder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCloseOrder.UseSelectable = true;
            this.btnCloseOrder.Click += new System.EventHandler(this.btnCloseOrder_Click);
            // 
            // grdOrders
            // 
            this.grdOrders.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.grdOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdOrders.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdOrders.ColumnHeadersHeight = 25;
            this.grdOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdOrderDetail,
            this.colIdItem,
            this.colItemName,
            this.colpacking,
            this.colconfiguration,
            this.colColor,
            this.colSize,
            this.colQty,
            this.colUnitPrice,
            this.colAmount,
            this.colDeliveredUnits,
            this.colRemaining});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdOrders.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdOrders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdOrders.EnableHeadersVisualStyles = false;
            this.grdOrders.Location = new System.Drawing.Point(8, 238);
            this.grdOrders.MultiSelect = false;
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.RowHeadersVisible = false;
            this.grdOrders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdOrders.Size = new System.Drawing.Size(1088, 190);
            this.grdOrders.TabIndex = 3;
            this.grdOrders.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOrders_CellEndEdit);
            this.grdOrders.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOrders_CellEnter);
            this.grdOrders.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOrders_CellLeave);
            this.grdOrders.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdOrders_EditingControlShowing);
            this.grdOrders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvStockReceipt_KeyDown);
            this.grdOrders.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DgvStockReceipt_KeyPress);
            // 
            // colIdOrderDetail
            // 
            this.colIdOrderDetail.HeaderText = "IdOrderDetail";
            this.colIdOrderDetail.Name = "colIdOrderDetail";
            this.colIdOrderDetail.Visible = false;
            // 
            // colIdItem
            // 
            this.colIdItem.HeaderText = "IdItem";
            this.colIdItem.Name = "colIdItem";
            this.colIdItem.Visible = false;
            // 
            // colItemName
            // 
            this.colItemName.HeaderText = "Article Name";
            this.colItemName.Name = "colItemName";
            this.colItemName.WatermarkText = "Type Here For Product Selection";
            this.colItemName.Width = 220;
            // 
            // colpacking
            // 
            this.colpacking.HeaderText = "UOM";
            this.colpacking.Name = "colpacking";
            this.colpacking.ReadOnly = true;
            this.colpacking.Width = 70;
            // 
            // colconfiguration
            // 
            this.colconfiguration.HeaderText = "Configuration";
            this.colconfiguration.Name = "colconfiguration";
            this.colconfiguration.ReadOnly = true;
            this.colconfiguration.Width = 190;
            // 
            // colColor
            // 
            this.colColor.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colColor.HeaderText = "Color";
            this.colColor.Name = "colColor";
            this.colColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colColor.Width = 85;
            // 
            // colSize
            // 
            this.colSize.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Width = 80;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 90;
            // 
            // colDeliveredUnits
            // 
            this.colDeliveredUnits.HeaderText = "Delivered";
            this.colDeliveredUnits.Name = "colDeliveredUnits";
            this.colDeliveredUnits.ReadOnly = true;
            this.colDeliveredUnits.Width = 80;
            // 
            // colRemaining
            // 
            this.colRemaining.HeaderText = "Remainder";
            this.colRemaining.Name = "colRemaining";
            this.colRemaining.ReadOnly = true;
            this.colRemaining.Width = 80;
            // 
            // txtTotalAmount
            // 
            // 
            // 
            // 
            this.txtTotalAmount.CustomButton.Image = null;
            this.txtTotalAmount.CustomButton.Location = new System.Drawing.Point(147, 1);
            this.txtTotalAmount.CustomButton.Name = "";
            this.txtTotalAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTotalAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalAmount.CustomButton.TabIndex = 1;
            this.txtTotalAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalAmount.CustomButton.UseSelectable = true;
            this.txtTotalAmount.CustomButton.Visible = false;
            this.txtTotalAmount.Lines = new string[0];
            this.txtTotalAmount.Location = new System.Drawing.Point(45, 444);
            this.txtTotalAmount.MaxLength = 32767;
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.PasswordChar = '\0';
            this.txtTotalAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalAmount.SelectedText = "";
            this.txtTotalAmount.SelectionLength = 0;
            this.txtTotalAmount.SelectionStart = 0;
            this.txtTotalAmount.ShortcutsEnabled = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(169, 23);
            this.txtTotalAmount.TabIndex = 11;
            this.txtTotalAmount.UseSelectable = true;
            this.txtTotalAmount.Visible = false;
            this.txtTotalAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1102, 532);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.grdOrders);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCloseOrder);
            this.Controls.Add(this.btnReq);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnNext);
            this.DoubleBuffered = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmOrder";
            this.Text = "Gloves Orders";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmOrder_KeyPress);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.DataGridView DgvStockReceipt;
        private TabDataGrid grdOrders;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatuMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel lblDiscription;
        private MetroFramework.Controls.MetroLabel lblVoucherNo;
        private MetroFramework.Controls.MetroLabel lblDate;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroTextBox VEditBox;
        private MetroFramework.Controls.MetroDateTime dtOrder;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroTile btnDelete;
        private MetroFramework.Controls.MetroTile btnClose;
        private MetroFramework.Controls.MetroTile btnPrevious;
        private MetroFramework.Controls.MetroTile btnNext;
        private MetroFramework.Controls.MetroTile btnNew;
        private MetroFramework.Controls.MetroTextBox SEditBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime dtDelivery;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtCustomerPo;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime dtProduction;
        private MetroFramework.Controls.MetroLabel metroLabel4;       
        private MetroFramework.Controls.MetroTextBox txtBrandName;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTile btnReq;
        private MetroFramework.Controls.MetroTile btnCloseOrder;
        private MetroFramework.Controls.MetroTextBox txtCurrency;
        private MetroFramework.Controls.MetroCheckBox chkPosted;
        private MetroFramework.Controls.MetroTextBox txtTotalAmount;
        private MetroFramework.Controls.MetroButton btnTrackOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdOrderDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdItem;
        private DataGridViewProductWaterMarkColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpacking;
        private System.Windows.Forms.DataGridViewTextBoxColumn colconfiguration;
        private System.Windows.Forms.DataGridViewComboBoxColumn colColor;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveredUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemaining;
    }
}