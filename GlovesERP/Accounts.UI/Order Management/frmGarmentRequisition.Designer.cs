namespace Accounts.UI
{
    partial class frmGarmentRequisition
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.reqDate = new MetroFramework.Controls.MetroDateTime();
            this.lblDate = new MetroFramework.Controls.MetroLabel();
            this.txtBrand = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.SEditBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtCustomerPo = new MetroFramework.Controls.MetroTextBox();
            this.VEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblVoucherNo = new MetroFramework.Controls.MetroLabel();
            this.grpFabric = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.btnPrevious = new MetroFramework.Controls.MetroTile();
            this.btnNext = new MetroFramework.Controls.MetroTile();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatuMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.grdOrderdArticles = new Accounts.UI.TabDataGrid();
            this.colOrderedIdDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderdArticleIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderdArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdOrderdClothe = new Accounts.UI.TabDataGrid();
            this.colClotheIdDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheSmall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheMedium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheLarge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheXL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClothe2XL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClothe3XL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClothe4XL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClothe5XL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheDying = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdOrderBreakup = new Accounts.UI.TabDataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.colBreakupIdDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakupIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakupItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakupSmall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakupMedium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakupLarge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakupXL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakup2XLarge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakup3XL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakup4XL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakup5XL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakupTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakUpAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakupRequired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakupRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBreakupAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderdArticles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderdClothe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderBreakup)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reqDate
            // 
            this.reqDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.reqDate.Location = new System.Drawing.Point(862, 4);
            this.reqDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.reqDate.Name = "reqDate";
            this.reqDate.Size = new System.Drawing.Size(146, 29);
            this.reqDate.TabIndex = 46;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDate.Location = new System.Drawing.Point(765, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(72, 19);
            this.lblDate.TabIndex = 45;
            this.lblDate.Text = "Req Date :";
            this.lblDate.UseCustomBackColor = true;
            // 
            // txtBrand
            // 
            // 
            // 
            // 
            this.txtBrand.CustomButton.Image = null;
            this.txtBrand.CustomButton.Location = new System.Drawing.Point(235, 1);
            this.txtBrand.CustomButton.Name = "";
            this.txtBrand.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBrand.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBrand.CustomButton.TabIndex = 1;
            this.txtBrand.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBrand.CustomButton.UseSelectable = true;
            this.txtBrand.Lines = new string[0];
            this.txtBrand.Location = new System.Drawing.Point(515, 87);
            this.txtBrand.MaxLength = 32767;
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.PasswordChar = '\0';
            this.txtBrand.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBrand.SelectedText = "";
            this.txtBrand.SelectionLength = 0;
            this.txtBrand.SelectionStart = 0;
            this.txtBrand.ShortcutsEnabled = true;
            this.txtBrand.ShowButton = true;
            this.txtBrand.Size = new System.Drawing.Size(257, 23);
            this.txtBrand.Style = MetroFramework.MetroColorStyle.Green;
            this.txtBrand.TabIndex = 44;
            this.txtBrand.UseSelectable = true;
            this.txtBrand.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBrand.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(420, 87);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(52, 19);
            this.metroLabel6.TabIndex = 42;
            this.metroLabel6.Text = "Brand :";
            this.metroLabel6.UseCustomBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(408, 68);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(101, 19);
            this.metroLabel3.TabIndex = 40;
            this.metroLabel3.Text = "Customer Po #";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // SEditBox
            // 
            // 
            // 
            // 
            this.SEditBox.CustomButton.Image = null;
            this.SEditBox.CustomButton.Location = new System.Drawing.Point(281, 1);
            this.SEditBox.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.SEditBox.CustomButton.Name = "";
            this.SEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SEditBox.CustomButton.TabIndex = 1;
            this.SEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SEditBox.CustomButton.UseSelectable = true;
            this.SEditBox.Lines = new string[0];
            this.SEditBox.Location = new System.Drawing.Point(111, 89);
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
            this.SEditBox.Size = new System.Drawing.Size(303, 23);
            this.SEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.SEditBox.TabIndex = 35;
            this.SEditBox.UseSelectable = true;
            this.SEditBox.WaterMark = "Customer Here";
            this.SEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(29, 89);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(76, 19);
            this.metroLabel2.TabIndex = 39;
            this.metroLabel2.Text = "Customer :";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // txtCustomerPo
            // 
            // 
            // 
            // 
            this.txtCustomerPo.CustomButton.Image = null;
            this.txtCustomerPo.CustomButton.Location = new System.Drawing.Point(235, 1);
            this.txtCustomerPo.CustomButton.Name = "";
            this.txtCustomerPo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCustomerPo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCustomerPo.CustomButton.TabIndex = 1;
            this.txtCustomerPo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCustomerPo.CustomButton.UseSelectable = true;
            this.txtCustomerPo.Lines = new string[0];
            this.txtCustomerPo.Location = new System.Drawing.Point(501, 8);
            this.txtCustomerPo.MaxLength = 32767;
            this.txtCustomerPo.Name = "txtCustomerPo";
            this.txtCustomerPo.PasswordChar = '\0';
            this.txtCustomerPo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCustomerPo.SelectedText = "";
            this.txtCustomerPo.SelectionLength = 0;
            this.txtCustomerPo.SelectionStart = 0;
            this.txtCustomerPo.ShortcutsEnabled = true;
            this.txtCustomerPo.ShowButton = true;
            this.txtCustomerPo.Size = new System.Drawing.Size(257, 23);
            this.txtCustomerPo.Style = MetroFramework.MetroColorStyle.Green;
            this.txtCustomerPo.TabIndex = 37;
            this.txtCustomerPo.UseSelectable = true;
            this.txtCustomerPo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCustomerPo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // VEditBox
            // 
            // 
            // 
            // 
            this.VEditBox.CustomButton.Image = null;
            this.VEditBox.CustomButton.Location = new System.Drawing.Point(157, 1);
            this.VEditBox.CustomButton.Name = "";
            this.VEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.VEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.VEditBox.CustomButton.TabIndex = 1;
            this.VEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.VEditBox.CustomButton.UseSelectable = true;
            this.VEditBox.Lines = new string[] {
        "1"};
            this.VEditBox.Location = new System.Drawing.Point(111, 65);
            this.VEditBox.MaxLength = 32767;
            this.VEditBox.Name = "VEditBox";
            this.VEditBox.PasswordChar = '\0';
            this.VEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.VEditBox.SelectedText = "";
            this.VEditBox.SelectionLength = 0;
            this.VEditBox.SelectionStart = 0;
            this.VEditBox.ShortcutsEnabled = true;
            this.VEditBox.ShowButton = true;
            this.VEditBox.Size = new System.Drawing.Size(179, 23);
            this.VEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.VEditBox.TabIndex = 38;
            this.VEditBox.Text = "1";
            this.VEditBox.UseSelectable = true;
            this.VEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.VEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.VEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VEditBox_KeyPress);
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblVoucherNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblVoucherNo.Location = new System.Drawing.Point(33, 66);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(61, 19);
            this.lblVoucherNo.TabIndex = 36;
            this.lblVoucherNo.Text = "Req No :";
            this.lblVoucherNo.UseCustomBackColor = true;
            // 
            // grpFabric
            // 
            this.grpFabric.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFabric.Location = new System.Drawing.Point(13, 127);
            this.grpFabric.Name = "grpFabric";
            this.grpFabric.Size = new System.Drawing.Size(986, 196);
            this.grpFabric.TabIndex = 47;
            this.grpFabric.TabStop = false;
            this.grpFabric.Text = "Fabric Items";
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 325);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(986, 222);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Garments Materials";
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(490, 552);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 40);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ActiveControl = null;
            this.btnDelete.Location = new System.Drawing.Point(592, 552);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 40);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Red;
            this.btnDelete.TabIndex = 50;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.UseSelectable = true;
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.Location = new System.Drawing.Point(694, 552);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 40);
            this.btnClose.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseSelectable = true;
            // 
            // btnPrevious
            // 
            this.btnPrevious.ActiveControl = null;
            this.btnPrevious.Location = new System.Drawing.Point(797, 552);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(101, 40);
            this.btnPrevious.Style = MetroFramework.MetroColorStyle.Brown;
            this.btnPrevious.TabIndex = 52;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrevious.UseSelectable = true;
            // 
            // btnNext
            // 
            this.btnNext.ActiveControl = null;
            this.btnNext.Location = new System.Drawing.Point(899, 552);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(101, 40);
            this.btnNext.Style = MetroFramework.MetroColorStyle.Brown;
            this.btnNext.TabIndex = 53;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNext.UseSelectable = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatuMessage});
            this.statusStrip1.Location = new System.Drawing.Point(20, 605);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1196, 22);
            this.statusStrip1.TabIndex = 55;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatuMessage
            // 
            this.lblStatuMessage.Name = "lblStatuMessage";
            this.lblStatuMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // grdOrderdArticles
            // 
            this.grdOrderdArticles.AllowUserToAddRows = false;
            this.grdOrderdArticles.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.grdOrderdArticles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdOrderdArticles.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOrderdArticles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdOrderdArticles.ColumnHeadersHeight = 25;
            this.grdOrderdArticles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderedIdDetail,
            this.colOrderdArticleIdItem,
            this.colOrderdArticleName});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdOrderdArticles.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdOrderdArticles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdOrderdArticles.EnableHeadersVisualStyles = false;
            this.grdOrderdArticles.Location = new System.Drawing.Point(1004, 137);
            this.grdOrderdArticles.MultiSelect = false;
            this.grdOrderdArticles.Name = "grdOrderdArticles";
            this.grdOrderdArticles.ReadOnly = true;
            this.grdOrderdArticles.RowHeadersVisible = false;
            this.grdOrderdArticles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdOrderdArticles.Size = new System.Drawing.Size(208, 460);
            this.grdOrderdArticles.TabIndex = 5;
            this.grdOrderdArticles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOrderdArticles_CellDoubleClick);
            // 
            // colOrderedIdDetail
            // 
            this.colOrderedIdDetail.HeaderText = "IdOrderDetail";
            this.colOrderedIdDetail.Name = "colOrderedIdDetail";
            this.colOrderedIdDetail.ReadOnly = true;
            this.colOrderedIdDetail.Visible = false;
            // 
            // colOrderdArticleIdItem
            // 
            this.colOrderdArticleIdItem.DataPropertyName = "IdItem";
            this.colOrderdArticleIdItem.HeaderText = "IdItem";
            this.colOrderdArticleIdItem.Name = "colOrderdArticleIdItem";
            this.colOrderdArticleIdItem.ReadOnly = true;
            this.colOrderdArticleIdItem.Visible = false;
            // 
            // colOrderdArticleName
            // 
            this.colOrderdArticleName.DataPropertyName = "ItemName";
            this.colOrderdArticleName.HeaderText = "Article Names";
            this.colOrderdArticleName.Name = "colOrderdArticleName";
            this.colOrderdArticleName.ReadOnly = true;
            this.colOrderdArticleName.Width = 200;
            // 
            // grdOrderdClothe
            // 
            this.grdOrderdClothe.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Beige;
            this.grdOrderdClothe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdOrderdClothe.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOrderdClothe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdOrderdClothe.ColumnHeadersHeight = 25;
            this.grdOrderdClothe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClotheIdDetail,
            this.colClotheIdItem,
            this.colClotheProductCode,
            this.colClotheItemName,
            this.colClotheSmall,
            this.colClotheMedium,
            this.colClotheLarge,
            this.colClotheXL,
            this.colClothe2XL,
            this.colClothe3XL,
            this.colClothe4XL,
            this.colClothe5XL,
            this.colClotheDying,
            this.colClotheTotal});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdOrderdClothe.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdOrderdClothe.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdOrderdClothe.EnableHeadersVisualStyles = false;
            this.grdOrderdClothe.Location = new System.Drawing.Point(23, 156);
            this.grdOrderdClothe.MultiSelect = false;
            this.grdOrderdClothe.Name = "grdOrderdClothe";
            this.grdOrderdClothe.RowHeadersVisible = false;
            this.grdOrderdClothe.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdOrderdClothe.Size = new System.Drawing.Size(970, 154);
            this.grdOrderdClothe.TabIndex = 5;
            this.grdOrderdClothe.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdOrderdClothe_EditingControlShowing);
            // 
            // colClotheIdDetail
            // 
            this.colClotheIdDetail.HeaderText = "IdOrderDetail";
            this.colClotheIdDetail.Name = "colClotheIdDetail";
            this.colClotheIdDetail.Visible = false;
            // 
            // colClotheIdItem
            // 
            this.colClotheIdItem.HeaderText = "IdItem";
            this.colClotheIdItem.Name = "colClotheIdItem";
            this.colClotheIdItem.Visible = false;
            // 
            // colClotheProductCode
            // 
            this.colClotheProductCode.DataPropertyName = "AccountNo";
            this.colClotheProductCode.HeaderText = "Product Code";
            this.colClotheProductCode.Name = "colClotheProductCode";
            this.colClotheProductCode.Visible = false;
            // 
            // colClotheItemName
            // 
            this.colClotheItemName.HeaderText = "Item Name";
            this.colClotheItemName.Name = "colClotheItemName";
            this.colClotheItemName.Width = 160;
            // 
            // colClotheSmall
            // 
            this.colClotheSmall.HeaderText = "Small";
            this.colClotheSmall.Name = "colClotheSmall";
            this.colClotheSmall.Width = 80;
            // 
            // colClotheMedium
            // 
            this.colClotheMedium.HeaderText = "Medium";
            this.colClotheMedium.Name = "colClotheMedium";
            this.colClotheMedium.Width = 80;
            // 
            // colClotheLarge
            // 
            this.colClotheLarge.HeaderText = "Large";
            this.colClotheLarge.Name = "colClotheLarge";
            this.colClotheLarge.Width = 80;
            // 
            // colClotheXL
            // 
            this.colClotheXL.HeaderText = "X Large";
            this.colClotheXL.Name = "colClotheXL";
            this.colClotheXL.Width = 80;
            // 
            // colClothe2XL
            // 
            this.colClothe2XL.HeaderText = "2X Large";
            this.colClothe2XL.Name = "colClothe2XL";
            this.colClothe2XL.Width = 80;
            // 
            // colClothe3XL
            // 
            this.colClothe3XL.HeaderText = "3X Large";
            this.colClothe3XL.Name = "colClothe3XL";
            this.colClothe3XL.Width = 80;
            // 
            // colClothe4XL
            // 
            this.colClothe4XL.HeaderText = "4X Large";
            this.colClothe4XL.Name = "colClothe4XL";
            this.colClothe4XL.Width = 80;
            // 
            // colClothe5XL
            // 
            this.colClothe5XL.HeaderText = "5X Large";
            this.colClothe5XL.Name = "colClothe5XL";
            this.colClothe5XL.Width = 80;
            // 
            // colClotheDying
            // 
            this.colClotheDying.HeaderText = "Dying";
            this.colClotheDying.Name = "colClotheDying";
            this.colClotheDying.Width = 80;
            // 
            // colClotheTotal
            // 
            this.colClotheTotal.HeaderText = "Total";
            this.colClotheTotal.Name = "colClotheTotal";
            this.colClotheTotal.Width = 80;
            // 
            // grdOrderBreakup
            // 
            this.grdOrderBreakup.AllowUserToAddRows = false;
            this.grdOrderBreakup.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Beige;
            this.grdOrderBreakup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdOrderBreakup.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOrderBreakup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdOrderBreakup.ColumnHeadersHeight = 28;
            this.grdOrderBreakup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBreakupIdDetail,
            this.colBreakupIdItem,
            this.dataGridViewTextBoxColumn3,
            this.colBreakupItemName,
            this.colBreakupSmall,
            this.colBreakupMedium,
            this.colBreakupLarge,
            this.colBreakupXL,
            this.colBreakup2XLarge,
            this.colBreakup3XL,
            this.colBreakup4XL,
            this.colBreakup5XL,
            this.colBreakupTotal,
            this.colBreakUpAvailable,
            this.colBreakupRequired,
            this.colBreakupRate,
            this.colBreakupAmount});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdOrderBreakup.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdOrderBreakup.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdOrderBreakup.EnableHeadersVisualStyles = false;
            this.grdOrderBreakup.Location = new System.Drawing.Point(24, 355);
            this.grdOrderBreakup.MultiSelect = false;
            this.grdOrderBreakup.Name = "grdOrderBreakup";
            this.grdOrderBreakup.ReadOnly = true;
            this.grdOrderBreakup.RowHeadersVisible = false;
            this.grdOrderBreakup.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdOrderBreakup.Size = new System.Drawing.Size(969, 184);
            this.grdOrderBreakup.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.reqDate);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.txtCustomerPo);
            this.panel1.Location = new System.Drawing.Point(14, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1187, 69);
            this.panel1.TabIndex = 56;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Red;
            this.lblStatus.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblStatus.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(770, 35);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(323, 25);
            this.lblStatus.TabIndex = 58;
            this.lblStatus.Text = "Requisition Prepared For This Article";
            this.lblStatus.UseCustomBackColor = true;
            this.lblStatus.Visible = false;
            // 
            // colBreakupIdDetail
            // 
            this.colBreakupIdDetail.HeaderText = "IdOrderDetail";
            this.colBreakupIdDetail.Name = "colBreakupIdDetail";
            this.colBreakupIdDetail.ReadOnly = true;
            this.colBreakupIdDetail.Visible = false;
            // 
            // colBreakupIdItem
            // 
            this.colBreakupIdItem.HeaderText = "IdItem";
            this.colBreakupIdItem.Name = "colBreakupIdItem";
            this.colBreakupIdItem.ReadOnly = true;
            this.colBreakupIdItem.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "AccountNo";
            this.dataGridViewTextBoxColumn3.HeaderText = "Product Code";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // colBreakupItemName
            // 
            this.colBreakupItemName.HeaderText = "Item Name";
            this.colBreakupItemName.Name = "colBreakupItemName";
            this.colBreakupItemName.ReadOnly = true;
            this.colBreakupItemName.Width = 200;
            // 
            // colBreakupSmall
            // 
            this.colBreakupSmall.HeaderText = "S";
            this.colBreakupSmall.Name = "colBreakupSmall";
            this.colBreakupSmall.ReadOnly = true;
            this.colBreakupSmall.Width = 50;
            // 
            // colBreakupMedium
            // 
            this.colBreakupMedium.HeaderText = "M";
            this.colBreakupMedium.Name = "colBreakupMedium";
            this.colBreakupMedium.ReadOnly = true;
            this.colBreakupMedium.Width = 50;
            // 
            // colBreakupLarge
            // 
            this.colBreakupLarge.HeaderText = "L";
            this.colBreakupLarge.Name = "colBreakupLarge";
            this.colBreakupLarge.ReadOnly = true;
            this.colBreakupLarge.Width = 50;
            // 
            // colBreakupXL
            // 
            this.colBreakupXL.HeaderText = "XL";
            this.colBreakupXL.Name = "colBreakupXL";
            this.colBreakupXL.ReadOnly = true;
            this.colBreakupXL.Width = 50;
            // 
            // colBreakup2XLarge
            // 
            this.colBreakup2XLarge.HeaderText = "2XL";
            this.colBreakup2XLarge.Name = "colBreakup2XLarge";
            this.colBreakup2XLarge.ReadOnly = true;
            this.colBreakup2XLarge.Width = 50;
            // 
            // colBreakup3XL
            // 
            this.colBreakup3XL.HeaderText = "3XL";
            this.colBreakup3XL.Name = "colBreakup3XL";
            this.colBreakup3XL.ReadOnly = true;
            this.colBreakup3XL.Width = 50;
            // 
            // colBreakup4XL
            // 
            this.colBreakup4XL.HeaderText = "4XL";
            this.colBreakup4XL.Name = "colBreakup4XL";
            this.colBreakup4XL.ReadOnly = true;
            this.colBreakup4XL.Width = 50;
            // 
            // colBreakup5XL
            // 
            this.colBreakup5XL.HeaderText = "5XL";
            this.colBreakup5XL.Name = "colBreakup5XL";
            this.colBreakup5XL.ReadOnly = true;
            this.colBreakup5XL.Width = 50;
            // 
            // colBreakupTotal
            // 
            this.colBreakupTotal.HeaderText = "Total";
            this.colBreakupTotal.Name = "colBreakupTotal";
            this.colBreakupTotal.ReadOnly = true;
            this.colBreakupTotal.Width = 60;
            // 
            // colBreakUpAvailable
            // 
            this.colBreakUpAvailable.HeaderText = "Available";
            this.colBreakUpAvailable.Name = "colBreakUpAvailable";
            this.colBreakUpAvailable.ReadOnly = true;
            this.colBreakUpAvailable.Width = 70;
            // 
            // colBreakupRequired
            // 
            this.colBreakupRequired.HeaderText = "Required";
            this.colBreakupRequired.Name = "colBreakupRequired";
            this.colBreakupRequired.ReadOnly = true;
            this.colBreakupRequired.Width = 70;
            // 
            // colBreakupRate
            // 
            this.colBreakupRate.HeaderText = "Rate";
            this.colBreakupRate.Name = "colBreakupRate";
            this.colBreakupRate.ReadOnly = true;
            this.colBreakupRate.Width = 70;
            // 
            // colBreakupAmount
            // 
            this.colBreakupAmount.HeaderText = "Amount";
            this.colBreakupAmount.Name = "colBreakupAmount";
            this.colBreakupAmount.ReadOnly = true;
            this.colBreakupAmount.Width = 78;
            // 
            // frmGarmentRequisition
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1236, 647);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.SEditBox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.VEditBox);
            this.Controls.Add(this.lblVoucherNo);
            this.Controls.Add(this.grdOrderdArticles);
            this.Controls.Add(this.grdOrderdClothe);
            this.Controls.Add(this.grdOrderBreakup);
            this.Controls.Add(this.grpFabric);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmGarmentRequisition";
            this.Text = "Garment Requisition";
            this.Load += new System.EventHandler(this.frmGarmentRequisition_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderdArticles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderdClothe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderBreakup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabDataGrid grdOrderBreakup;
        private MetroFramework.Controls.MetroDateTime reqDate;
        private MetroFramework.Controls.MetroLabel lblDate;
        private MetroFramework.Controls.MetroTextBox txtBrand;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox SEditBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtCustomerPo;
        private MetroFramework.Controls.MetroTextBox VEditBox;
        private MetroFramework.Controls.MetroLabel lblVoucherNo;
        private TabDataGrid grdOrderdClothe;
        private System.Windows.Forms.GroupBox grpFabric;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroTile btnDelete;
        private MetroFramework.Controls.MetroTile btnClose;
        private MetroFramework.Controls.MetroTile btnPrevious;
        private MetroFramework.Controls.MetroTile btnNext;
        private TabDataGrid grdOrderdArticles;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatuMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheIdDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheSmall;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheMedium;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheLarge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheXL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClothe2XL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClothe3XL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClothe4XL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClothe5XL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheDying;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderedIdDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderdArticleIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderdArticleName;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakupIdDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakupIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakupItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakupSmall;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakupMedium;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakupLarge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakupXL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakup2XLarge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakup3XL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakup4XL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakup5XL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakupTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakUpAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakupRequired;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakupRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBreakupAmount;
    }
}