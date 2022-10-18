namespace Accounts.UI
{
    partial class frmPackingInspectionReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ProductionTab = new MetroFramework.Controls.MetroTabControl();
            this.mTabInspection = new MetroFramework.Controls.MetroTabPage();
            this.btnCalculateInspectionTotal = new System.Windows.Forms.Button();
            this.txtInspectionTotalAmount = new MetroFramework.Controls.MetroTextBox();
            this.chkInspectionSearchByArticle = new MetroFramework.Controls.MetroCheckBox();
            this.grdInspection = new Accounts.UI.TabDataGrid();
            this.colVDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionBrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionSizes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGlovesInspectionSizes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionPassQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionRejectedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionBQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionRepair = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInspectionSearch = new MetroFramework.Controls.MetroTextBox();
            this.chkInspectionSearchByBrand = new MetroFramework.Controls.MetroCheckBox();
            this.mTabPacking = new MetroFramework.Controls.MetroTabPage();
            this.btnCalculatePackingTotal = new System.Windows.Forms.Button();
            this.txtTotalPackingAmount = new MetroFramework.Controls.MetroTextBox();
            this.chkPackingSearchByArticle = new MetroFramework.Controls.MetroCheckBox();
            this.txtPackingSearch = new MetroFramework.Controls.MetroTextBox();
            this.chkPackingSearchByBrand = new MetroFramework.Controls.MetroCheckBox();
            this.grdPacking = new Accounts.UI.TabDataGrid();
            this.colPackingVDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingBrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingSizes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGlovesPackingSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingStyle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingRates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.chkApplyDateFilter = new MetroFramework.Controls.MetroCheckBox();
            this.btnLoad = new MetroFramework.Controls.MetroButton();
            this.AccEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblAccountName = new MetroFramework.Controls.MetroLabel();
            this.pnlDate = new MetroFramework.Controls.MetroPanel();
            this.EndDate = new MetroFramework.Controls.MetroDateTime();
            this.btnLoadbyFilter = new MetroFramework.Controls.MetroButton();
            this.StartDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.ProductionTab.SuspendLayout();
            this.mTabInspection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInspection)).BeginInit();
            this.mTabPacking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPacking)).BeginInit();
            this.pnlDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductionTab
            // 
            this.ProductionTab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.ProductionTab.Controls.Add(this.mTabInspection);
            this.ProductionTab.Controls.Add(this.mTabPacking);
            this.ProductionTab.Location = new System.Drawing.Point(-1, 190);
            this.ProductionTab.Name = "ProductionTab";
            this.ProductionTab.SelectedIndex = 1;
            this.ProductionTab.Size = new System.Drawing.Size(1092, 347);
            this.ProductionTab.Style = MetroFramework.MetroColorStyle.Green;
            this.ProductionTab.TabIndex = 3;
            this.ProductionTab.UseSelectable = true;
            this.ProductionTab.SelectedIndexChanged += new System.EventHandler(this.ProductionTab_SelectedIndexChanged);
            // 
            // mTabInspection
            // 
            this.mTabInspection.Controls.Add(this.btnCalculateInspectionTotal);
            this.mTabInspection.Controls.Add(this.txtInspectionTotalAmount);
            this.mTabInspection.Controls.Add(this.chkInspectionSearchByArticle);
            this.mTabInspection.Controls.Add(this.grdInspection);
            this.mTabInspection.Controls.Add(this.txtInspectionSearch);
            this.mTabInspection.Controls.Add(this.chkInspectionSearchByBrand);
            this.mTabInspection.HorizontalScrollbarBarColor = true;
            this.mTabInspection.HorizontalScrollbarHighlightOnWheel = false;
            this.mTabInspection.HorizontalScrollbarSize = 10;
            this.mTabInspection.Location = new System.Drawing.Point(4, 41);
            this.mTabInspection.Name = "mTabInspection";
            this.mTabInspection.Size = new System.Drawing.Size(1084, 302);
            this.mTabInspection.TabIndex = 5;
            this.mTabInspection.Text = "Checking / Inspection";
            this.mTabInspection.VerticalScrollbarBarColor = true;
            this.mTabInspection.VerticalScrollbarHighlightOnWheel = false;
            this.mTabInspection.VerticalScrollbarSize = 10;
            // 
            // btnCalculateInspectionTotal
            // 
            this.btnCalculateInspectionTotal.Location = new System.Drawing.Point(523, 22);
            this.btnCalculateInspectionTotal.Name = "btnCalculateInspectionTotal";
            this.btnCalculateInspectionTotal.Size = new System.Drawing.Size(177, 23);
            this.btnCalculateInspectionTotal.TabIndex = 8;
            this.btnCalculateInspectionTotal.Text = "Caculate Filter Total";
            this.btnCalculateInspectionTotal.UseVisualStyleBackColor = true;
            this.btnCalculateInspectionTotal.Click += new System.EventHandler(this.btnCalculateInspectionTotal_Click);
            // 
            // txtInspectionTotalAmount
            // 
            // 
            // 
            // 
            this.txtInspectionTotalAmount.CustomButton.Image = null;
            this.txtInspectionTotalAmount.CustomButton.Location = new System.Drawing.Point(68, 1);
            this.txtInspectionTotalAmount.CustomButton.Name = "";
            this.txtInspectionTotalAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtInspectionTotalAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtInspectionTotalAmount.CustomButton.TabIndex = 1;
            this.txtInspectionTotalAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtInspectionTotalAmount.CustomButton.UseSelectable = true;
            this.txtInspectionTotalAmount.CustomButton.Visible = false;
            this.txtInspectionTotalAmount.Lines = new string[0];
            this.txtInspectionTotalAmount.Location = new System.Drawing.Point(986, 271);
            this.txtInspectionTotalAmount.MaxLength = 32767;
            this.txtInspectionTotalAmount.Name = "txtInspectionTotalAmount";
            this.txtInspectionTotalAmount.PasswordChar = '\0';
            this.txtInspectionTotalAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtInspectionTotalAmount.SelectedText = "";
            this.txtInspectionTotalAmount.SelectionLength = 0;
            this.txtInspectionTotalAmount.SelectionStart = 0;
            this.txtInspectionTotalAmount.ShortcutsEnabled = true;
            this.txtInspectionTotalAmount.Size = new System.Drawing.Size(90, 23);
            this.txtInspectionTotalAmount.TabIndex = 7;
            this.txtInspectionTotalAmount.UseSelectable = true;
            this.txtInspectionTotalAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtInspectionTotalAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // chkInspectionSearchByArticle
            // 
            this.chkInspectionSearchByArticle.AutoSize = true;
            this.chkInspectionSearchByArticle.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkInspectionSearchByArticle.Location = new System.Drawing.Point(7, 22);
            this.chkInspectionSearchByArticle.Name = "chkInspectionSearchByArticle";
            this.chkInspectionSearchByArticle.Size = new System.Drawing.Size(126, 19);
            this.chkInspectionSearchByArticle.TabIndex = 5;
            this.chkInspectionSearchByArticle.Text = "Search By Article";
            this.chkInspectionSearchByArticle.UseSelectable = true;
            this.chkInspectionSearchByArticle.CheckedChanged += new System.EventHandler(this.chkInspectionSearchByArticle_CheckedChanged);
            // 
            // grdInspection
            // 
            this.grdInspection.AllowUserToAddRows = false;
            this.grdInspection.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInspection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdInspection.ColumnHeadersHeight = 28;
            this.grdInspection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVDate,
            this.colInspectionArticleName,
            this.colInspectionBrandName,
            this.colInspectionUOM,
            this.colInspectionSizes,
            this.colGlovesInspectionSizes,
            this.colInspectionQuantity,
            this.colInspectionPassQuantity,
            this.colInspectionRejectedQuantity,
            this.colInspectionBQ,
            this.colInspectionRepair,
            this.colInspectionRate,
            this.colInspectionAmount});
            this.grdInspection.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdInspection.EnableHeadersVisualStyles = false;
            this.grdInspection.Location = new System.Drawing.Point(3, 58);
            this.grdInspection.Name = "grdInspection";
            this.grdInspection.ReadOnly = true;
            this.grdInspection.RowHeadersVisible = false;
            this.grdInspection.Size = new System.Drawing.Size(1071, 206);
            this.grdInspection.TabIndex = 4;
            // 
            // colVDate
            // 
            this.colVDate.DataPropertyName = "VDate";
            dataGridViewCellStyle9.Format = "d";
            this.colVDate.DefaultCellStyle = dataGridViewCellStyle9;
            this.colVDate.HeaderText = "Date";
            this.colVDate.Name = "colVDate";
            this.colVDate.ReadOnly = true;
            this.colVDate.Width = 80;
            // 
            // colInspectionArticleName
            // 
            this.colInspectionArticleName.DataPropertyName = "ItemName";
            this.colInspectionArticleName.HeaderText = "Article";
            this.colInspectionArticleName.Name = "colInspectionArticleName";
            this.colInspectionArticleName.ReadOnly = true;
            this.colInspectionArticleName.Width = 180;
            // 
            // colInspectionBrandName
            // 
            this.colInspectionBrandName.DataPropertyName = "BrandName";
            this.colInspectionBrandName.HeaderText = "Brand Name";
            this.colInspectionBrandName.Name = "colInspectionBrandName";
            this.colInspectionBrandName.ReadOnly = true;
            this.colInspectionBrandName.Width = 110;
            // 
            // colInspectionUOM
            // 
            this.colInspectionUOM.DataPropertyName = "PackingSize";
            this.colInspectionUOM.HeaderText = "UOM";
            this.colInspectionUOM.Name = "colInspectionUOM";
            this.colInspectionUOM.ReadOnly = true;
            this.colInspectionUOM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInspectionUOM.Width = 80;
            // 
            // colInspectionSizes
            // 
            this.colInspectionSizes.DataPropertyName = "ItemSize";
            this.colInspectionSizes.HeaderText = "Sizes";
            this.colInspectionSizes.Name = "colInspectionSizes";
            this.colInspectionSizes.ReadOnly = true;
            this.colInspectionSizes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInspectionSizes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInspectionSizes.Visible = false;
            this.colInspectionSizes.Width = 80;
            // 
            // colGlovesInspectionSizes
            // 
            this.colGlovesInspectionSizes.DataPropertyName = "ItemSize";
            this.colGlovesInspectionSizes.HeaderText = "Sizes";
            this.colGlovesInspectionSizes.Name = "colGlovesInspectionSizes";
            this.colGlovesInspectionSizes.ReadOnly = true;
            this.colGlovesInspectionSizes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGlovesInspectionSizes.Width = 80;
            // 
            // colInspectionQuantity
            // 
            this.colInspectionQuantity.DataPropertyName = "Quantity";
            this.colInspectionQuantity.HeaderText = "Quantity";
            this.colInspectionQuantity.Name = "colInspectionQuantity";
            this.colInspectionQuantity.ReadOnly = true;
            this.colInspectionQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInspectionQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInspectionQuantity.Width = 70;
            // 
            // colInspectionPassQuantity
            // 
            this.colInspectionPassQuantity.DataPropertyName = "ReadyUnits";
            this.colInspectionPassQuantity.HeaderText = "Rass";
            this.colInspectionPassQuantity.Name = "colInspectionPassQuantity";
            this.colInspectionPassQuantity.ReadOnly = true;
            this.colInspectionPassQuantity.Width = 70;
            // 
            // colInspectionRejectedQuantity
            // 
            this.colInspectionRejectedQuantity.DataPropertyName = "Rejection";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colInspectionRejectedQuantity.DefaultCellStyle = dataGridViewCellStyle10;
            this.colInspectionRejectedQuantity.HeaderText = "Reject";
            this.colInspectionRejectedQuantity.Name = "colInspectionRejectedQuantity";
            this.colInspectionRejectedQuantity.ReadOnly = true;
            this.colInspectionRejectedQuantity.Width = 70;
            // 
            // colInspectionBQ
            // 
            this.colInspectionBQ.DataPropertyName = "BQuantity";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colInspectionBQ.DefaultCellStyle = dataGridViewCellStyle11;
            this.colInspectionBQ.HeaderText = "B.Q";
            this.colInspectionBQ.Name = "colInspectionBQ";
            this.colInspectionBQ.ReadOnly = true;
            this.colInspectionBQ.Width = 70;
            // 
            // colInspectionRepair
            // 
            this.colInspectionRepair.DataPropertyName = "RepairQuantity";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colInspectionRepair.DefaultCellStyle = dataGridViewCellStyle12;
            this.colInspectionRepair.HeaderText = "R.Q";
            this.colInspectionRepair.Name = "colInspectionRepair";
            this.colInspectionRepair.ReadOnly = true;
            this.colInspectionRepair.Width = 70;
            // 
            // colInspectionRate
            // 
            this.colInspectionRate.DataPropertyName = "Rate";
            this.colInspectionRate.HeaderText = "Rates";
            this.colInspectionRate.Name = "colInspectionRate";
            this.colInspectionRate.ReadOnly = true;
            this.colInspectionRate.Width = 90;
            // 
            // colInspectionAmount
            // 
            this.colInspectionAmount.DataPropertyName = "Amount";
            this.colInspectionAmount.HeaderText = "Amount";
            this.colInspectionAmount.Name = "colInspectionAmount";
            this.colInspectionAmount.ReadOnly = true;
            this.colInspectionAmount.Width = 90;
            // 
            // txtInspectionSearch
            // 
            // 
            // 
            // 
            this.txtInspectionSearch.CustomButton.Image = null;
            this.txtInspectionSearch.CustomButton.Location = new System.Drawing.Point(223, 1);
            this.txtInspectionSearch.CustomButton.Name = "";
            this.txtInspectionSearch.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtInspectionSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtInspectionSearch.CustomButton.TabIndex = 1;
            this.txtInspectionSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtInspectionSearch.CustomButton.UseSelectable = true;
            this.txtInspectionSearch.CustomButton.Visible = false;
            this.txtInspectionSearch.Lines = new string[0];
            this.txtInspectionSearch.Location = new System.Drawing.Point(271, 22);
            this.txtInspectionSearch.MaxLength = 32767;
            this.txtInspectionSearch.Name = "txtInspectionSearch";
            this.txtInspectionSearch.PasswordChar = '\0';
            this.txtInspectionSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtInspectionSearch.SelectedText = "";
            this.txtInspectionSearch.SelectionLength = 0;
            this.txtInspectionSearch.SelectionStart = 0;
            this.txtInspectionSearch.ShortcutsEnabled = true;
            this.txtInspectionSearch.Size = new System.Drawing.Size(245, 23);
            this.txtInspectionSearch.TabIndex = 6;
            this.txtInspectionSearch.UseSelectable = true;
            this.txtInspectionSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtInspectionSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtInspectionSearch.TextChanged += new System.EventHandler(this.txtInspectionSearch_TextChanged);
            // 
            // chkInspectionSearchByBrand
            // 
            this.chkInspectionSearchByBrand.AutoSize = true;
            this.chkInspectionSearchByBrand.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkInspectionSearchByBrand.Location = new System.Drawing.Point(140, 23);
            this.chkInspectionSearchByBrand.Name = "chkInspectionSearchByBrand";
            this.chkInspectionSearchByBrand.Size = new System.Drawing.Size(124, 19);
            this.chkInspectionSearchByBrand.TabIndex = 5;
            this.chkInspectionSearchByBrand.Text = "Search By Brand";
            this.chkInspectionSearchByBrand.UseSelectable = true;
            this.chkInspectionSearchByBrand.CheckedChanged += new System.EventHandler(this.chkInspectionSearchByBrand_CheckedChanged);
            // 
            // mTabPacking
            // 
            this.mTabPacking.Controls.Add(this.btnCalculatePackingTotal);
            this.mTabPacking.Controls.Add(this.txtTotalPackingAmount);
            this.mTabPacking.Controls.Add(this.chkPackingSearchByArticle);
            this.mTabPacking.Controls.Add(this.txtPackingSearch);
            this.mTabPacking.Controls.Add(this.chkPackingSearchByBrand);
            this.mTabPacking.Controls.Add(this.grdPacking);
            this.mTabPacking.HorizontalScrollbarBarColor = true;
            this.mTabPacking.HorizontalScrollbarHighlightOnWheel = false;
            this.mTabPacking.HorizontalScrollbarSize = 10;
            this.mTabPacking.Location = new System.Drawing.Point(4, 41);
            this.mTabPacking.Name = "mTabPacking";
            this.mTabPacking.Size = new System.Drawing.Size(1084, 302);
            this.mTabPacking.TabIndex = 7;
            this.mTabPacking.Text = "Packing";
            this.mTabPacking.VerticalScrollbarBarColor = true;
            this.mTabPacking.VerticalScrollbarHighlightOnWheel = false;
            this.mTabPacking.VerticalScrollbarSize = 10;
            // 
            // btnCalculatePackingTotal
            // 
            this.btnCalculatePackingTotal.Location = new System.Drawing.Point(518, 20);
            this.btnCalculatePackingTotal.Name = "btnCalculatePackingTotal";
            this.btnCalculatePackingTotal.Size = new System.Drawing.Size(177, 23);
            this.btnCalculatePackingTotal.TabIndex = 11;
            this.btnCalculatePackingTotal.Text = "Caculate Filter Total";
            this.btnCalculatePackingTotal.UseVisualStyleBackColor = true;
            this.btnCalculatePackingTotal.Click += new System.EventHandler(this.btnCalculatePackingTotal_Click);
            // 
            // txtTotalPackingAmount
            // 
            // 
            // 
            // 
            this.txtTotalPackingAmount.CustomButton.Image = null;
            this.txtTotalPackingAmount.CustomButton.Location = new System.Drawing.Point(75, 1);
            this.txtTotalPackingAmount.CustomButton.Name = "";
            this.txtTotalPackingAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTotalPackingAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalPackingAmount.CustomButton.TabIndex = 1;
            this.txtTotalPackingAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalPackingAmount.CustomButton.UseSelectable = true;
            this.txtTotalPackingAmount.CustomButton.Visible = false;
            this.txtTotalPackingAmount.Lines = new string[0];
            this.txtTotalPackingAmount.Location = new System.Drawing.Point(956, 263);
            this.txtTotalPackingAmount.MaxLength = 32767;
            this.txtTotalPackingAmount.Name = "txtTotalPackingAmount";
            this.txtTotalPackingAmount.PasswordChar = '\0';
            this.txtTotalPackingAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalPackingAmount.SelectedText = "";
            this.txtTotalPackingAmount.SelectionLength = 0;
            this.txtTotalPackingAmount.SelectionStart = 0;
            this.txtTotalPackingAmount.ShortcutsEnabled = true;
            this.txtTotalPackingAmount.Size = new System.Drawing.Size(97, 23);
            this.txtTotalPackingAmount.TabIndex = 10;
            this.txtTotalPackingAmount.UseSelectable = true;
            this.txtTotalPackingAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalPackingAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // chkPackingSearchByArticle
            // 
            this.chkPackingSearchByArticle.AutoSize = true;
            this.chkPackingSearchByArticle.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkPackingSearchByArticle.Location = new System.Drawing.Point(3, 19);
            this.chkPackingSearchByArticle.Name = "chkPackingSearchByArticle";
            this.chkPackingSearchByArticle.Size = new System.Drawing.Size(126, 19);
            this.chkPackingSearchByArticle.TabIndex = 8;
            this.chkPackingSearchByArticle.Text = "Search By Article";
            this.chkPackingSearchByArticle.UseSelectable = true;
            this.chkPackingSearchByArticle.CheckedChanged += new System.EventHandler(this.chkPackingSearchByArticle_CheckedChanged);
            // 
            // txtPackingSearch
            // 
            // 
            // 
            // 
            this.txtPackingSearch.CustomButton.Image = null;
            this.txtPackingSearch.CustomButton.Location = new System.Drawing.Point(223, 1);
            this.txtPackingSearch.CustomButton.Name = "";
            this.txtPackingSearch.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPackingSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPackingSearch.CustomButton.TabIndex = 1;
            this.txtPackingSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPackingSearch.CustomButton.UseSelectable = true;
            this.txtPackingSearch.CustomButton.Visible = false;
            this.txtPackingSearch.Lines = new string[0];
            this.txtPackingSearch.Location = new System.Drawing.Point(267, 19);
            this.txtPackingSearch.MaxLength = 32767;
            this.txtPackingSearch.Name = "txtPackingSearch";
            this.txtPackingSearch.PasswordChar = '\0';
            this.txtPackingSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPackingSearch.SelectedText = "";
            this.txtPackingSearch.SelectionLength = 0;
            this.txtPackingSearch.SelectionStart = 0;
            this.txtPackingSearch.ShortcutsEnabled = true;
            this.txtPackingSearch.Size = new System.Drawing.Size(245, 23);
            this.txtPackingSearch.TabIndex = 9;
            this.txtPackingSearch.UseSelectable = true;
            this.txtPackingSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPackingSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPackingSearch.TextChanged += new System.EventHandler(this.txtPackingSearch_TextChanged);
            // 
            // chkPackingSearchByBrand
            // 
            this.chkPackingSearchByBrand.AutoSize = true;
            this.chkPackingSearchByBrand.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkPackingSearchByBrand.Location = new System.Drawing.Point(136, 20);
            this.chkPackingSearchByBrand.Name = "chkPackingSearchByBrand";
            this.chkPackingSearchByBrand.Size = new System.Drawing.Size(124, 19);
            this.chkPackingSearchByBrand.TabIndex = 7;
            this.chkPackingSearchByBrand.Text = "Search By Brand";
            this.chkPackingSearchByBrand.UseSelectable = true;
            this.chkPackingSearchByBrand.CheckedChanged += new System.EventHandler(this.chkPackingSearchByBrand_CheckedChanged);
            // 
            // grdPacking
            // 
            this.grdPacking.AllowUserToAddRows = false;
            this.grdPacking.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPacking.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.grdPacking.ColumnHeadersHeight = 28;
            this.grdPacking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPackingVDate,
            this.colPackingArticleName,
            this.colPackingBrandName,
            this.colPackingSizes,
            this.colGlovesPackingSize,
            this.colPackingStyle,
            this.colPackingUOM,
            this.colPackingQuantity,
            this.colPackingRates,
            this.colPackingAmount});
            this.grdPacking.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdPacking.EnableHeadersVisualStyles = false;
            this.grdPacking.Location = new System.Drawing.Point(3, 57);
            this.grdPacking.Name = "grdPacking";
            this.grdPacking.ReadOnly = true;
            this.grdPacking.RowHeadersVisible = false;
            this.grdPacking.Size = new System.Drawing.Size(1050, 199);
            this.grdPacking.TabIndex = 0;
            // 
            // colPackingVDate
            // 
            this.colPackingVDate.DataPropertyName = "VDate";
            dataGridViewCellStyle14.Format = "d";
            this.colPackingVDate.DefaultCellStyle = dataGridViewCellStyle14;
            this.colPackingVDate.HeaderText = "Date";
            this.colPackingVDate.Name = "colPackingVDate";
            this.colPackingVDate.ReadOnly = true;
            // 
            // colPackingArticleName
            // 
            this.colPackingArticleName.DataPropertyName = "ItemName";
            this.colPackingArticleName.HeaderText = "Article Name";
            this.colPackingArticleName.Name = "colPackingArticleName";
            this.colPackingArticleName.ReadOnly = true;
            this.colPackingArticleName.Width = 250;
            // 
            // colPackingBrandName
            // 
            this.colPackingBrandName.DataPropertyName = "BrandName";
            this.colPackingBrandName.HeaderText = "Brand";
            this.colPackingBrandName.Name = "colPackingBrandName";
            this.colPackingBrandName.ReadOnly = true;
            this.colPackingBrandName.Width = 120;
            // 
            // colPackingSizes
            // 
            this.colPackingSizes.DataPropertyName = "ItemSize";
            this.colPackingSizes.HeaderText = "Sizes";
            this.colPackingSizes.Name = "colPackingSizes";
            this.colPackingSizes.ReadOnly = true;
            this.colPackingSizes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPackingSizes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPackingSizes.Visible = false;
            this.colPackingSizes.Width = 90;
            // 
            // colGlovesPackingSize
            // 
            this.colGlovesPackingSize.DataPropertyName = "ItemSize";
            this.colGlovesPackingSize.HeaderText = "Sizes";
            this.colGlovesPackingSize.Name = "colGlovesPackingSize";
            this.colGlovesPackingSize.ReadOnly = true;
            this.colGlovesPackingSize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colPackingStyle
            // 
            this.colPackingStyle.DataPropertyName = "PStyle";
            this.colPackingStyle.HeaderText = "P.Style";
            this.colPackingStyle.Name = "colPackingStyle";
            this.colPackingStyle.ReadOnly = true;
            this.colPackingStyle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPackingStyle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPackingStyle.Width = 90;
            // 
            // colPackingUOM
            // 
            this.colPackingUOM.DataPropertyName = "PackingSize";
            this.colPackingUOM.HeaderText = "UOM";
            this.colPackingUOM.Name = "colPackingUOM";
            this.colPackingUOM.ReadOnly = true;
            this.colPackingUOM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPackingUOM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPackingUOM.Width = 90;
            // 
            // colPackingQuantity
            // 
            this.colPackingQuantity.DataPropertyName = "ReadyUnits";
            this.colPackingQuantity.HeaderText = "Ready To Export";
            this.colPackingQuantity.Name = "colPackingQuantity";
            this.colPackingQuantity.ReadOnly = true;
            this.colPackingQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPackingQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPackingRates
            // 
            this.colPackingRates.DataPropertyName = "Rate";
            this.colPackingRates.HeaderText = "Rates";
            this.colPackingRates.Name = "colPackingRates";
            this.colPackingRates.ReadOnly = true;
            this.colPackingRates.Width = 90;
            // 
            // colPackingAmount
            // 
            this.colPackingAmount.DataPropertyName = "Amount";
            this.colPackingAmount.HeaderText = "Amount";
            this.colPackingAmount.Name = "colPackingAmount";
            this.colPackingAmount.ReadOnly = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(1, 54);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(1135, 23);
            this.metroLabel1.TabIndex = 29;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "--------------------------";
            // 
            // chkApplyDateFilter
            // 
            this.chkApplyDateFilter.AutoSize = true;
            this.chkApplyDateFilter.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkApplyDateFilter.Location = new System.Drawing.Point(576, 84);
            this.chkApplyDateFilter.Name = "chkApplyDateFilter";
            this.chkApplyDateFilter.Size = new System.Drawing.Size(127, 19);
            this.chkApplyDateFilter.TabIndex = 33;
            this.chkApplyDateFilter.Text = "Apply Date Filter";
            this.chkApplyDateFilter.UseSelectable = true;
            this.chkApplyDateFilter.CheckedChanged += new System.EventHandler(this.chkApplyDateFilter_CheckedChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(480, 80);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(87, 23);
            this.btnLoad.TabIndex = 32;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseSelectable = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // AccEditBox
            // 
            // 
            // 
            // 
            this.AccEditBox.CustomButton.Image = null;
            this.AccEditBox.CustomButton.Location = new System.Drawing.Point(323, 1);
            this.AccEditBox.CustomButton.Name = "";
            this.AccEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.AccEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.AccEditBox.CustomButton.TabIndex = 1;
            this.AccEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.AccEditBox.CustomButton.UseSelectable = true;
            this.AccEditBox.Lines = new string[0];
            this.AccEditBox.Location = new System.Drawing.Point(129, 80);
            this.AccEditBox.MaxLength = 32767;
            this.AccEditBox.Name = "AccEditBox";
            this.AccEditBox.PasswordChar = '\0';
            this.AccEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AccEditBox.SelectedText = "";
            this.AccEditBox.SelectionLength = 0;
            this.AccEditBox.SelectionStart = 0;
            this.AccEditBox.ShortcutsEnabled = true;
            this.AccEditBox.ShowButton = true;
            this.AccEditBox.Size = new System.Drawing.Size(345, 23);
            this.AccEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.AccEditBox.TabIndex = 31;
            this.AccEditBox.UseSelectable = true;
            this.AccEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.AccEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.AccEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.AccEditBox_ButtonClick);
            this.AccEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AccEditBox_KeyPress);
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAccountName.Location = new System.Drawing.Point(21, 81);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(106, 19);
            this.lblAccountName.TabIndex = 30;
            this.lblAccountName.Text = "Select Inpector :";
            // 
            // pnlDate
            // 
            this.pnlDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDate.Controls.Add(this.EndDate);
            this.pnlDate.Controls.Add(this.btnLoadbyFilter);
            this.pnlDate.Controls.Add(this.StartDate);
            this.pnlDate.Controls.Add(this.metroLabel4);
            this.pnlDate.Controls.Add(this.metroLabel5);
            this.pnlDate.Enabled = false;
            this.pnlDate.HorizontalScrollbarBarColor = true;
            this.pnlDate.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlDate.HorizontalScrollbarSize = 10;
            this.pnlDate.Location = new System.Drawing.Point(9, 136);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(1082, 50);
            this.pnlDate.TabIndex = 35;
            this.pnlDate.VerticalScrollbarBarColor = true;
            this.pnlDate.VerticalScrollbarHighlightOnWheel = false;
            this.pnlDate.VerticalScrollbarSize = 10;
            // 
            // EndDate
            // 
            this.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDate.Location = new System.Drawing.Point(352, 9);
            this.EndDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(160, 29);
            this.EndDate.TabIndex = 15;
            // 
            // btnLoadbyFilter
            // 
            this.btnLoadbyFilter.Location = new System.Drawing.Point(524, 9);
            this.btnLoadbyFilter.Name = "btnLoadbyFilter";
            this.btnLoadbyFilter.Size = new System.Drawing.Size(137, 27);
            this.btnLoadbyFilter.TabIndex = 10;
            this.btnLoadbyFilter.Text = "Load By Date Filter";
            this.btnLoadbyFilter.UseSelectable = true;
            this.btnLoadbyFilter.Click += new System.EventHandler(this.btnLoadbyFilter_Click);
            // 
            // StartDate
            // 
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDate.Location = new System.Drawing.Point(103, 9);
            this.StartDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(150, 29);
            this.StartDate.TabIndex = 14;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(268, 13);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(72, 19);
            this.metroLabel4.TabIndex = 13;
            this.metroLabel4.Text = "To Period :";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(9, 13);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(87, 19);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "Start Period :";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel3
            // 
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(-1, 110);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(1137, 23);
            this.metroLabel3.TabIndex = 34;
            this.metroLabel3.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "---------------------------";
            // 
            // frmPackingInspectionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 560);
            this.Controls.Add(this.pnlDate);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.chkApplyDateFilter);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.AccEditBox);
            this.Controls.Add(this.lblAccountName);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.ProductionTab);
            this.Name = "frmPackingInspectionReport";
            this.Text = "Inspection / Packing";
            this.Load += new System.EventHandler(this.frmPackingInspection_Load);
            this.ProductionTab.ResumeLayout(false);
            this.mTabInspection.ResumeLayout(false);
            this.mTabInspection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInspection)).EndInit();
            this.mTabPacking.ResumeLayout(false);
            this.mTabPacking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPacking)).EndInit();
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl ProductionTab;
        private MetroFramework.Controls.MetroTabPage mTabInspection;
        private TabDataGrid grdInspection;
        private MetroFramework.Controls.MetroTabPage mTabPacking;
        private TabDataGrid grdPacking;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroCheckBox chkApplyDateFilter;
        private MetroFramework.Controls.MetroButton btnLoad;
        private MetroFramework.Controls.MetroTextBox AccEditBox;
        private MetroFramework.Controls.MetroLabel lblAccountName;
        private MetroFramework.Controls.MetroPanel pnlDate;
        private MetroFramework.Controls.MetroDateTime EndDate;
        private MetroFramework.Controls.MetroButton btnLoadbyFilter;
        private MetroFramework.Controls.MetroDateTime StartDate;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroCheckBox chkInspectionSearchByArticle;
        private MetroFramework.Controls.MetroTextBox txtInspectionSearch;
        private MetroFramework.Controls.MetroCheckBox chkInspectionSearchByBrand;
        private MetroFramework.Controls.MetroCheckBox chkPackingSearchByArticle;
        private MetroFramework.Controls.MetroTextBox txtPackingSearch;
        private MetroFramework.Controls.MetroCheckBox chkPackingSearchByBrand;
        private MetroFramework.Controls.MetroTextBox txtInspectionTotalAmount;
        private MetroFramework.Controls.MetroTextBox txtTotalPackingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionArticleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionBrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionSizes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGlovesInspectionSizes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionPassQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionRejectedQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionBQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionRepair;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingVDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingArticleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingBrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingSizes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGlovesPackingSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingRates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingAmount;
        private System.Windows.Forms.Button btnCalculateInspectionTotal;
        private System.Windows.Forms.Button btnCalculatePackingTotal;
    }
}