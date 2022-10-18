namespace Accounts.UI
{
    partial class frmPackingInspection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ProductionTab = new MetroFramework.Controls.MetroTabControl();
            this.mTabInspection = new MetroFramework.Controls.MetroTabPage();
            this.grdInspection = new Accounts.UI.TabDataGrid();
            this.colIdIspection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionIdBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionBrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionUOM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colInspectionSizes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colGlovesInspectionSizes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colInspectionQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionPassQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionRejectedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionBQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionRepair = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectorRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectorAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.mTabPacking = new MetroFramework.Controls.MetroTabPage();
            this.grdPacking = new Accounts.UI.TabDataGrid();
            this.colIdPacking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdPackingBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingBrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingSizes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colGlovesPackingSize = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPackingStyle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPackingUOM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPackingQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingCartons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingRates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ProductionDate = new MetroFramework.Controls.MetroDateTime();
            this.VEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblVoucherNo = new MetroFramework.Controls.MetroLabel();
            this.lblDate = new MetroFramework.Controls.MetroLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SEditBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtAddress = new MetroFramework.Controls.MetroTextBox();
            this.txtContact = new MetroFramework.Controls.MetroTextBox();
            this.lblDiscription = new MetroFramework.Controls.MetroLabel();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.btnNext = new MetroFramework.Controls.MetroTile();
            this.btnPrevious = new MetroFramework.Controls.MetroTile();
            this.btnNew = new MetroFramework.Controls.MetroTile();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.chkPosted = new MetroFramework.Controls.MetroCheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDeletedVoucher = new MetroFramework.Controls.MetroLabel();
            this.ProductionTab.SuspendLayout();
            this.mTabInspection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInspection)).BeginInit();
            this.mTabPacking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPacking)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductionTab
            // 
            this.ProductionTab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.ProductionTab.Controls.Add(this.mTabInspection);
            this.ProductionTab.Controls.Add(this.mTabPacking);
            this.ProductionTab.Location = new System.Drawing.Point(-1, 189);
            this.ProductionTab.Name = "ProductionTab";
            this.ProductionTab.SelectedIndex = 1;
            this.ProductionTab.Size = new System.Drawing.Size(1222, 279);
            this.ProductionTab.Style = MetroFramework.MetroColorStyle.Green;
            this.ProductionTab.TabIndex = 3;
            this.ProductionTab.UseSelectable = true;
            // 
            // mTabInspection
            // 
            this.mTabInspection.Controls.Add(this.grdInspection);
            this.mTabInspection.HorizontalScrollbarBarColor = true;
            this.mTabInspection.HorizontalScrollbarHighlightOnWheel = false;
            this.mTabInspection.HorizontalScrollbarSize = 10;
            this.mTabInspection.Location = new System.Drawing.Point(4, 41);
            this.mTabInspection.Name = "mTabInspection";
            this.mTabInspection.Size = new System.Drawing.Size(1214, 234);
            this.mTabInspection.TabIndex = 5;
            this.mTabInspection.Text = "Checking / Inspection";
            this.mTabInspection.VerticalScrollbarBarColor = true;
            this.mTabInspection.VerticalScrollbarHighlightOnWheel = false;
            this.mTabInspection.VerticalScrollbarSize = 10;
            // 
            // grdInspection
            // 
            this.grdInspection.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInspection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdInspection.ColumnHeadersHeight = 28;
            this.grdInspection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdIspection,
            this.colInspectionIdItem,
            this.colInspectionIdBrand,
            this.colInspectionAccountNo,
            this.colInspectionVendorName,
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
            this.colInspectionAmount,
            this.colInspectorRate,
            this.colInspectorAmount,
            this.colInspectionDelete});
            this.grdInspection.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdInspection.EnableHeadersVisualStyles = false;
            this.grdInspection.Location = new System.Drawing.Point(3, 4);
            this.grdInspection.Name = "grdInspection";
            this.grdInspection.RowHeadersVisible = false;
            this.grdInspection.Size = new System.Drawing.Size(1207, 223);
            this.grdInspection.TabIndex = 4;
            this.grdInspection.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInspection_CellClick);
            this.grdInspection.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInspection_CellEndEdit);
            this.grdInspection.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInspection_CellEnter);
            this.grdInspection.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdInspection_CellFormatting);
            this.grdInspection.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInspection_CellLeave);
            this.grdInspection.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdInspection_EditingControlShowing);
            // 
            // colIdIspection
            // 
            this.colIdIspection.HeaderText = "Id Inspection";
            this.colIdIspection.Name = "colIdIspection";
            this.colIdIspection.Visible = false;
            // 
            // colInspectionIdItem
            // 
            this.colInspectionIdItem.HeaderText = "IdItem";
            this.colInspectionIdItem.Name = "colInspectionIdItem";
            this.colInspectionIdItem.Visible = false;
            // 
            // colInspectionIdBrand
            // 
            this.colInspectionIdBrand.HeaderText = "IdBrand";
            this.colInspectionIdBrand.Name = "colInspectionIdBrand";
            this.colInspectionIdBrand.Visible = false;
            // 
            // colInspectionAccountNo
            // 
            this.colInspectionAccountNo.HeaderText = "AccountNo";
            this.colInspectionAccountNo.Name = "colInspectionAccountNo";
            this.colInspectionAccountNo.Visible = false;
            // 
            // colInspectionVendorName
            // 
            this.colInspectionVendorName.HeaderText = "Stitcher Info";
            this.colInspectionVendorName.Name = "colInspectionVendorName";
            this.colInspectionVendorName.Width = 120;
            // 
            // colInspectionArticleName
            // 
            this.colInspectionArticleName.HeaderText = "Article";
            this.colInspectionArticleName.Name = "colInspectionArticleName";
            this.colInspectionArticleName.Width = 150;
            // 
            // colInspectionBrandName
            // 
            this.colInspectionBrandName.HeaderText = "Brand Name";
            this.colInspectionBrandName.Name = "colInspectionBrandName";
            // 
            // colInspectionUOM
            // 
            this.colInspectionUOM.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colInspectionUOM.HeaderText = "UOM";
            this.colInspectionUOM.Items.AddRange(new object[] {
            "",
            "Dozen",
            "Pairs",
            "Pcs"});
            this.colInspectionUOM.Name = "colInspectionUOM";
            this.colInspectionUOM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInspectionUOM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colInspectionUOM.Width = 80;
            // 
            // colInspectionSizes
            // 
            this.colInspectionSizes.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colInspectionSizes.HeaderText = "Sizes";
            this.colInspectionSizes.Items.AddRange(new object[] {
            "",
            "Small",
            "Medium",
            "Large",
            "X Large",
            "2X Large",
            "3X Large",
            "4X Large",
            "5X Large"});
            this.colInspectionSizes.Name = "colInspectionSizes";
            this.colInspectionSizes.Visible = false;
            this.colInspectionSizes.Width = 80;
            // 
            // colGlovesInspectionSizes
            // 
            this.colGlovesInspectionSizes.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colGlovesInspectionSizes.HeaderText = "Sizes";
            this.colGlovesInspectionSizes.Name = "colGlovesInspectionSizes";
            this.colGlovesInspectionSizes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGlovesInspectionSizes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colGlovesInspectionSizes.Width = 80;
            // 
            // colInspectionQuantity
            // 
            this.colInspectionQuantity.HeaderText = "Quantity";
            this.colInspectionQuantity.Name = "colInspectionQuantity";
            this.colInspectionQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInspectionQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInspectionQuantity.Width = 70;
            // 
            // colInspectionPassQuantity
            // 
            this.colInspectionPassQuantity.HeaderText = "Rass";
            this.colInspectionPassQuantity.Name = "colInspectionPassQuantity";
            this.colInspectionPassQuantity.Width = 50;
            // 
            // colInspectionRejectedQuantity
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colInspectionRejectedQuantity.DefaultCellStyle = dataGridViewCellStyle7;
            this.colInspectionRejectedQuantity.HeaderText = "Reject";
            this.colInspectionRejectedQuantity.Name = "colInspectionRejectedQuantity";
            this.colInspectionRejectedQuantity.Width = 50;
            // 
            // colInspectionBQ
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colInspectionBQ.DefaultCellStyle = dataGridViewCellStyle8;
            this.colInspectionBQ.HeaderText = "B.Q";
            this.colInspectionBQ.Name = "colInspectionBQ";
            this.colInspectionBQ.Width = 50;
            // 
            // colInspectionRepair
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colInspectionRepair.DefaultCellStyle = dataGridViewCellStyle9;
            this.colInspectionRepair.HeaderText = "R.Q";
            this.colInspectionRepair.Name = "colInspectionRepair";
            this.colInspectionRepair.Width = 50;
            // 
            // colInspectionRate
            // 
            this.colInspectionRate.HeaderText = "Rates";
            this.colInspectionRate.Name = "colInspectionRate";
            this.colInspectionRate.Width = 70;
            // 
            // colInspectionAmount
            // 
            this.colInspectionAmount.HeaderText = "Amount";
            this.colInspectionAmount.Name = "colInspectionAmount";
            // 
            // colInspectorRate
            // 
            this.colInspectorRate.HeaderText = "Ins.Rate";
            this.colInspectorRate.Name = "colInspectorRate";
            this.colInspectorRate.Width = 70;
            // 
            // colInspectorAmount
            // 
            this.colInspectorAmount.HeaderText = "Ins.Amount";
            this.colInspectorAmount.Name = "colInspectorAmount";
            this.colInspectorAmount.Width = 70;
            // 
            // colInspectionDelete
            // 
            this.colInspectionDelete.HeaderText = "Delete...";
            this.colInspectionDelete.Name = "colInspectionDelete";
            this.colInspectionDelete.Width = 85;
            // 
            // mTabPacking
            // 
            this.mTabPacking.Controls.Add(this.grdPacking);
            this.mTabPacking.HorizontalScrollbarBarColor = true;
            this.mTabPacking.HorizontalScrollbarHighlightOnWheel = false;
            this.mTabPacking.HorizontalScrollbarSize = 10;
            this.mTabPacking.Location = new System.Drawing.Point(4, 41);
            this.mTabPacking.Name = "mTabPacking";
            this.mTabPacking.Size = new System.Drawing.Size(1214, 234);
            this.mTabPacking.TabIndex = 7;
            this.mTabPacking.Text = "Packing";
            this.mTabPacking.VerticalScrollbarBarColor = true;
            this.mTabPacking.VerticalScrollbarHighlightOnWheel = false;
            this.mTabPacking.VerticalScrollbarSize = 10;
            // 
            // grdPacking
            // 
            this.grdPacking.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPacking.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdPacking.ColumnHeadersHeight = 28;
            this.grdPacking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdPacking,
            this.colPackingIdItem,
            this.colIdPackingBrand,
            this.colPackingArticleName,
            this.colPackingBrandName,
            this.colPackingSizes,
            this.colGlovesPackingSize,
            this.colPackingStyle,
            this.colPackingUOM,
            this.colPackingQuantity,
            this.colPackingCartons,
            this.colPackingRates,
            this.colPackingAmount,
            this.colPackingDelete});
            this.grdPacking.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdPacking.EnableHeadersVisualStyles = false;
            this.grdPacking.Location = new System.Drawing.Point(3, 3);
            this.grdPacking.Name = "grdPacking";
            this.grdPacking.RowHeadersVisible = false;
            this.grdPacking.Size = new System.Drawing.Size(1211, 225);
            this.grdPacking.TabIndex = 0;
            this.grdPacking.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPacking_CellClick);
            this.grdPacking.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPacking_CellEndEdit);
            this.grdPacking.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPacking_CellEnter);
            this.grdPacking.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdPacking_CellFormatting);
            this.grdPacking.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPacking_CellLeave);
            this.grdPacking.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdPacking_EditingControlShowing);
            // 
            // colIdPacking
            // 
            this.colIdPacking.HeaderText = "Id Packing";
            this.colIdPacking.Name = "colIdPacking";
            this.colIdPacking.Visible = false;
            // 
            // colPackingIdItem
            // 
            this.colPackingIdItem.HeaderText = "IdItem";
            this.colPackingIdItem.Name = "colPackingIdItem";
            this.colPackingIdItem.Visible = false;
            // 
            // colIdPackingBrand
            // 
            this.colIdPackingBrand.HeaderText = "IdBrand";
            this.colIdPackingBrand.Name = "colIdPackingBrand";
            this.colIdPackingBrand.Visible = false;
            // 
            // colPackingArticleName
            // 
            this.colPackingArticleName.HeaderText = "Article Name";
            this.colPackingArticleName.Name = "colPackingArticleName";
            this.colPackingArticleName.Width = 250;
            // 
            // colPackingBrandName
            // 
            this.colPackingBrandName.HeaderText = "Brand";
            this.colPackingBrandName.Name = "colPackingBrandName";
            this.colPackingBrandName.Width = 130;
            // 
            // colPackingSizes
            // 
            this.colPackingSizes.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colPackingSizes.HeaderText = "Sizes";
            this.colPackingSizes.Items.AddRange(new object[] {
            "",
            "Small",
            "Medium",
            "Large",
            "X Large",
            "2X Large",
            "3X Large",
            "4X Large",
            "5X Large"});
            this.colPackingSizes.Name = "colPackingSizes";
            this.colPackingSizes.Visible = false;
            // 
            // colGlovesPackingSize
            // 
            this.colGlovesPackingSize.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colGlovesPackingSize.HeaderText = "Sizes";
            this.colGlovesPackingSize.Items.AddRange(new object[] {
            "",
            "Small",
            "Medium",
            "Large"});
            this.colGlovesPackingSize.Name = "colGlovesPackingSize";
            this.colGlovesPackingSize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGlovesPackingSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colPackingStyle
            // 
            this.colPackingStyle.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colPackingStyle.HeaderText = "P.Style";
            this.colPackingStyle.Items.AddRange(new object[] {
            "",
            "",
            "5 Dozens",
            "6 Dozens",
            "10 Dozens",
            "10 Pieces",
            "20 Pieces",
            "120 Pieces"});
            this.colPackingStyle.Name = "colPackingStyle";
            // 
            // colPackingUOM
            // 
            this.colPackingUOM.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colPackingUOM.HeaderText = "UOM";
            this.colPackingUOM.Items.AddRange(new object[] {
            "",
            "Doz",
            "Pair",
            "Pcs"});
            this.colPackingUOM.Name = "colPackingUOM";
            // 
            // colPackingQuantity
            // 
            this.colPackingQuantity.HeaderText = "Ready To Export";
            this.colPackingQuantity.Name = "colPackingQuantity";
            this.colPackingQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPackingQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPackingCartons
            // 
            this.colPackingCartons.HeaderText = "Cartons";
            this.colPackingCartons.Name = "colPackingCartons";
            this.colPackingCartons.ReadOnly = true;
            this.colPackingCartons.Width = 90;
            // 
            // colPackingRates
            // 
            this.colPackingRates.HeaderText = "Rates";
            this.colPackingRates.Name = "colPackingRates";
            this.colPackingRates.Width = 90;
            // 
            // colPackingAmount
            // 
            this.colPackingAmount.HeaderText = "Amount";
            this.colPackingAmount.Name = "colPackingAmount";
            // 
            // colPackingDelete
            // 
            this.colPackingDelete.HeaderText = "Delete...";
            this.colPackingDelete.Name = "colPackingDelete";
            this.colPackingDelete.Width = 90;
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(21, 54);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(1195, 23);
            this.metroLabel1.TabIndex = 29;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "------------------------------------";
            // 
            // ProductionDate
            // 
            this.ProductionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ProductionDate.Location = new System.Drawing.Point(322, 83);
            this.ProductionDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.ProductionDate.Name = "ProductionDate";
            this.ProductionDate.Size = new System.Drawing.Size(146, 29);
            this.ProductionDate.TabIndex = 33;
            // 
            // VEditBox
            // 
            // 
            // 
            // 
            this.VEditBox.CustomButton.Image = null;
            this.VEditBox.CustomButton.Location = new System.Drawing.Point(143, 1);
            this.VEditBox.CustomButton.Name = "";
            this.VEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.VEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.VEditBox.CustomButton.TabIndex = 1;
            this.VEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.VEditBox.CustomButton.UseSelectable = true;
            this.VEditBox.Lines = new string[0];
            this.VEditBox.Location = new System.Drawing.Point(102, 87);
            this.VEditBox.MaxLength = 32767;
            this.VEditBox.Name = "VEditBox";
            this.VEditBox.PasswordChar = '\0';
            this.VEditBox.PromptText = "Voucher No.";
            this.VEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.VEditBox.SelectedText = "";
            this.VEditBox.SelectionLength = 0;
            this.VEditBox.SelectionStart = 0;
            this.VEditBox.ShortcutsEnabled = true;
            this.VEditBox.ShowButton = true;
            this.VEditBox.Size = new System.Drawing.Size(165, 23);
            this.VEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.VEditBox.TabIndex = 9;
            this.VEditBox.UseSelectable = true;
            this.VEditBox.WaterMark = "Voucher No.";
            this.VEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.VEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblVoucherNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblVoucherNo.Location = new System.Drawing.Point(24, 87);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(70, 19);
            this.lblVoucherNo.TabIndex = 30;
            this.lblVoucherNo.Text = "Serial No :";
            this.lblVoucherNo.UseCustomBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDate.Location = new System.Drawing.Point(271, 90);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 19);
            this.lblDate.TabIndex = 10;
            this.lblDate.Text = "Date :";
            this.lblDate.UseCustomBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.groupBox2.Controls.Add(this.SEditBox);
            this.groupBox2.Controls.Add(this.metroLabel2);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.txtContact);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(496, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(720, 107);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Worker Information";
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
            this.SEditBox.Location = new System.Drawing.Point(84, 25);
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
            this.SEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.SEditBox_ButtonClick);
            this.SEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SEditBox_KeyPress);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(6, 26);
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
            this.txtAddress.Location = new System.Drawing.Point(84, 51);
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
            this.txtContact.Location = new System.Drawing.Point(384, 24);
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
            // lblDiscription
            // 
            this.lblDiscription.AutoSize = true;
            this.lblDiscription.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblDiscription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDiscription.Location = new System.Drawing.Point(21, 126);
            this.lblDiscription.Name = "lblDiscription";
            this.lblDiscription.Size = new System.Drawing.Size(81, 19);
            this.lblDiscription.TabIndex = 36;
            this.lblDiscription.Text = "Discription :";
            this.lblDiscription.UseCustomBackColor = true;
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(322, 2);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(41, 41);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(102, 115);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(366, 46);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(604, 462);
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
            this.btnDelete.Location = new System.Drawing.Point(706, 462);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 40);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Red;
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNext
            // 
            this.btnNext.ActiveControl = null;
            this.btnNext.Location = new System.Drawing.Point(1012, 462);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(101, 40);
            this.btnNext.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNext.UseSelectable = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.ActiveControl = null;
            this.btnPrevious.Location = new System.Drawing.Point(910, 462);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(101, 40);
            this.btnPrevious.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnPrevious.TabIndex = 7;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrevious.UseSelectable = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNew
            // 
            this.btnNew.ActiveControl = null;
            this.btnNew.Location = new System.Drawing.Point(1115, 462);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(101, 40);
            this.btnNew.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "New Voucher";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNew.UseSelectable = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.Location = new System.Drawing.Point(808, 462);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 40);
            this.btnClose.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkPosted
            // 
            this.chkPosted.AutoSize = true;
            this.chkPosted.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.chkPosted.Location = new System.Drawing.Point(393, 85);
            this.chkPosted.Name = "chkPosted";
            this.chkPosted.Size = new System.Drawing.Size(59, 15);
            this.chkPosted.TabIndex = 2;
            this.chkPosted.Text = "Posted";
            this.chkPosted.UseCustomBackColor = true;
            this.chkPosted.UseSelectable = true;
            this.chkPosted.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkPosted_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panel1.Controls.Add(this.chkPosted);
            this.panel1.Location = new System.Drawing.Point(20, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 106);
            this.panel1.TabIndex = 37;
            // 
            // lblDeletedVoucher
            // 
            this.lblDeletedVoucher.AutoSize = true;
            this.lblDeletedVoucher.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblDeletedVoucher.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblDeletedVoucher.ForeColor = System.Drawing.Color.Red;
            this.lblDeletedVoucher.Location = new System.Drawing.Point(20, 469);
            this.lblDeletedVoucher.Name = "lblDeletedVoucher";
            this.lblDeletedVoucher.Size = new System.Drawing.Size(169, 25);
            this.lblDeletedVoucher.TabIndex = 38;
            this.lblDeletedVoucher.Text = "Deleted Voucher...";
            this.lblDeletedVoucher.UseCustomForeColor = true;
            // 
            // frmPackingInspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 548);
            this.Controls.Add(this.lblDeletedVoucher);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDiscription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ProductionDate);
            this.Controls.Add(this.VEditBox);
            this.Controls.Add(this.lblVoucherNo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.ProductionTab);
            this.Controls.Add(this.panel1);
            this.Name = "frmPackingInspection";
            this.Text = "Inspection / Packing";
            this.Load += new System.EventHandler(this.frmPackingInspection_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmPackingInspection_KeyPress);
            this.ProductionTab.ResumeLayout(false);
            this.mTabInspection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInspection)).EndInit();
            this.mTabPacking.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPacking)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private MetroFramework.Controls.MetroDateTime ProductionDate;
        private MetroFramework.Controls.MetroTextBox VEditBox;
        private MetroFramework.Controls.MetroLabel lblVoucherNo;
        private MetroFramework.Controls.MetroLabel lblDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroTextBox SEditBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtAddress;
        private MetroFramework.Controls.MetroTextBox txtContact;
        private MetroFramework.Controls.MetroLabel lblDiscription;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroTile btnDelete;
        private MetroFramework.Controls.MetroTile btnNext;
        private MetroFramework.Controls.MetroTile btnPrevious;
        private MetroFramework.Controls.MetroTile btnNew;
        private MetroFramework.Controls.MetroTile btnClose;
        private MetroFramework.Controls.MetroCheckBox chkPosted;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPacking;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPackingBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingArticleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingBrandName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPackingSizes;
        private System.Windows.Forms.DataGridViewComboBoxColumn colGlovesPackingSize;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPackingStyle;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPackingUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingCartons;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingRates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colPackingDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdIspection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionIdBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionVendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionArticleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionBrandName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colInspectionUOM;
        private System.Windows.Forms.DataGridViewComboBoxColumn colInspectionSizes;
        private System.Windows.Forms.DataGridViewComboBoxColumn colGlovesInspectionSizes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionPassQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionRejectedQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionBQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionRepair;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectorRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectorAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colInspectionDelete;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroLabel lblDeletedVoucher;
    }
}