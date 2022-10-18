namespace Accounts.UI
{
    partial class frmProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProducts));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblMRP = new MetroFramework.Controls.MetroLabel();
            this.txtunitPrice = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.btnSearch = new MetroFramework.Controls.MetroTile();
            this.txtMRP = new MetroFramework.Controls.MetroTextBox();
            this.btnFindCategory = new MetroFramework.Controls.MetroButton();
            this.txtBarCode = new MetroFramework.Controls.MetroTextBox();
            this.txtTradingCo = new MetroFramework.Controls.MetroTextBox();
            this.btnFindTradingCo = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtReorderlevel = new MetroFramework.Controls.MetroTextBox();
            this.txtCategoryName = new MetroFramework.Controls.MetroTextBox();
            this.txtProductName = new MetroFramework.Controls.MetroTextBox();
            this.txtProdcutNo = new MetroFramework.Controls.MetroTextBox();
            this.txtProductCode = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.lblBarCode = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.lblProductNo = new MetroFramework.Controls.MetroLabel();
            this.lblProductDiscription = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbxPackingSize = new MetroFramework.Controls.MetroComboBox();
            this.btnAddFormula = new MetroFramework.Controls.MetroTile();
            this.chkMandatory = new MetroFramework.Controls.MetroCheckBox();
            this.grdItemsColorAttributes = new Accounts.UI.TabDataGrid();
            this.colIdColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdItemsAttributes = new Accounts.UI.TabDataGrid();
            this.colIdSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSizes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkRazing = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cbxStockType = new MetroFramework.Controls.MetroComboBox();
            this.btnLinkItems = new MetroFramework.Controls.MetroTile();
            this.lblConfiguration = new MetroFramework.Controls.MetroLabel();
            this.txtConfiguration = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsColorAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsAttributes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMRP
            // 
            this.lblMRP.AutoSize = true;
            this.lblMRP.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMRP.Location = new System.Drawing.Point(444, 34);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(93, 19);
            this.lblMRP.TabIndex = 1;
            this.lblMRP.Text = "Per Unit Cost:";
            this.lblMRP.Visible = false;
            // 
            // txtunitPrice
            // 
            // 
            // 
            // 
            this.txtunitPrice.CustomButton.Image = null;
            this.txtunitPrice.CustomButton.Location = new System.Drawing.Point(211, 1);
            this.txtunitPrice.CustomButton.Name = "";
            this.txtunitPrice.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtunitPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtunitPrice.CustomButton.TabIndex = 1;
            this.txtunitPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtunitPrice.CustomButton.UseSelectable = true;
            this.txtunitPrice.CustomButton.Visible = false;
            this.txtunitPrice.Lines = new string[0];
            this.txtunitPrice.Location = new System.Drawing.Point(549, 34);
            this.txtunitPrice.MaxLength = 32767;
            this.txtunitPrice.Name = "txtunitPrice";
            this.txtunitPrice.PasswordChar = '\0';
            this.txtunitPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtunitPrice.SelectedText = "";
            this.txtunitPrice.SelectionLength = 0;
            this.txtunitPrice.SelectionStart = 0;
            this.txtunitPrice.ShortcutsEnabled = true;
            this.txtunitPrice.Size = new System.Drawing.Size(233, 23);
            this.txtunitPrice.TabIndex = 8;
            this.txtunitPrice.UseSelectable = true;
            this.txtunitPrice.Visible = false;
            this.txtunitPrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtunitPrice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(443, 392);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 75);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSave.TileImage")));
            this.btnSave.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseSelectable = true;
            this.btnSave.UseTileImage = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ActiveControl = null;
            this.btnDelete.Location = new System.Drawing.Point(525, 393);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 74);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.TileImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.TileImage")));
            this.btnDelete.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.UseTileImage = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.Location = new System.Drawing.Point(693, 393);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 74);
            this.btnClose.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.TileImage = ((System.Drawing.Image)(resources.GetObject("btnClose.TileImage")));
            this.btnClose.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseSelectable = true;
            this.btnClose.UseTileImage = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ActiveControl = null;
            this.btnSearch.Location = new System.Drawing.Point(611, 393);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 74);
            this.btnSearch.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.TileImage")));
            this.btnSearch.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.UseSelectable = true;
            this.btnSearch.UseTileImage = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtMRP
            // 
            // 
            // 
            // 
            this.txtMRP.CustomButton.Image = null;
            this.txtMRP.CustomButton.Location = new System.Drawing.Point(211, 1);
            this.txtMRP.CustomButton.Name = "";
            this.txtMRP.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtMRP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMRP.CustomButton.TabIndex = 1;
            this.txtMRP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMRP.CustomButton.UseSelectable = true;
            this.txtMRP.CustomButton.Visible = false;
            this.txtMRP.Lines = new string[0];
            this.txtMRP.Location = new System.Drawing.Point(128, 409);
            this.txtMRP.MaxLength = 32767;
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.PasswordChar = '\0';
            this.txtMRP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMRP.SelectedText = "";
            this.txtMRP.SelectionLength = 0;
            this.txtMRP.SelectionStart = 0;
            this.txtMRP.ShortcutsEnabled = true;
            this.txtMRP.Size = new System.Drawing.Size(233, 23);
            this.txtMRP.TabIndex = 10;
            this.txtMRP.UseSelectable = true;
            this.txtMRP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMRP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnFindCategory
            // 
            this.btnFindCategory.Location = new System.Drawing.Point(362, 186);
            this.btnFindCategory.Name = "btnFindCategory";
            this.btnFindCategory.Size = new System.Drawing.Size(49, 23);
            this.btnFindCategory.TabIndex = 5;
            this.btnFindCategory.Text = "+";
            this.btnFindCategory.UseSelectable = true;
            this.btnFindCategory.Click += new System.EventHandler(this.btnFindCategory_Click);
            // 
            // txtBarCode
            // 
            // 
            // 
            // 
            this.txtBarCode.CustomButton.Image = null;
            this.txtBarCode.CustomButton.Location = new System.Drawing.Point(191, 1);
            this.txtBarCode.CustomButton.Name = "";
            this.txtBarCode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBarCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBarCode.CustomButton.TabIndex = 1;
            this.txtBarCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBarCode.CustomButton.UseSelectable = true;
            this.txtBarCode.CustomButton.Visible = false;
            this.txtBarCode.Lines = new string[0];
            this.txtBarCode.Location = new System.Drawing.Point(129, 126);
            this.txtBarCode.MaxLength = 32767;
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.PasswordChar = '\0';
            this.txtBarCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBarCode.SelectedText = "";
            this.txtBarCode.SelectionLength = 0;
            this.txtBarCode.SelectionStart = 0;
            this.txtBarCode.ShortcutsEnabled = true;
            this.txtBarCode.Size = new System.Drawing.Size(213, 23);
            this.txtBarCode.TabIndex = 2;
            this.txtBarCode.UseSelectable = true;
            this.txtBarCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBarCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtTradingCo
            // 
            // 
            // 
            // 
            this.txtTradingCo.CustomButton.Image = null;
            this.txtTradingCo.CustomButton.Location = new System.Drawing.Point(211, 1);
            this.txtTradingCo.CustomButton.Name = "";
            this.txtTradingCo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTradingCo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTradingCo.CustomButton.TabIndex = 1;
            this.txtTradingCo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTradingCo.CustomButton.UseSelectable = true;
            this.txtTradingCo.CustomButton.Visible = false;
            this.txtTradingCo.Enabled = false;
            this.txtTradingCo.Lines = new string[0];
            this.txtTradingCo.Location = new System.Drawing.Point(128, 216);
            this.txtTradingCo.MaxLength = 32767;
            this.txtTradingCo.Name = "txtTradingCo";
            this.txtTradingCo.PasswordChar = '\0';
            this.txtTradingCo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTradingCo.SelectedText = "";
            this.txtTradingCo.SelectionLength = 0;
            this.txtTradingCo.SelectionStart = 0;
            this.txtTradingCo.ShortcutsEnabled = true;
            this.txtTradingCo.Size = new System.Drawing.Size(233, 23);
            this.txtTradingCo.TabIndex = 6;
            this.txtTradingCo.UseSelectable = true;
            this.txtTradingCo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTradingCo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnFindTradingCo
            // 
            this.btnFindTradingCo.Location = new System.Drawing.Point(362, 216);
            this.btnFindTradingCo.Name = "btnFindTradingCo";
            this.btnFindTradingCo.Size = new System.Drawing.Size(49, 23);
            this.btnFindTradingCo.TabIndex = 7;
            this.btnFindTradingCo.Text = "+";
            this.btnFindTradingCo.UseSelectable = true;
            this.btnFindTradingCo.Click += new System.EventHandler(this.btnFindTradingCo_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(20, 411);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(105, 19);
            this.metroLabel3.TabIndex = 26;
            this.metroLabel3.Text = "Trade Price(TP) :";
            // 
            // txtReorderlevel
            // 
            // 
            // 
            // 
            this.txtReorderlevel.CustomButton.Image = null;
            this.txtReorderlevel.CustomButton.Location = new System.Drawing.Point(211, 1);
            this.txtReorderlevel.CustomButton.Name = "";
            this.txtReorderlevel.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtReorderlevel.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtReorderlevel.CustomButton.TabIndex = 1;
            this.txtReorderlevel.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtReorderlevel.CustomButton.UseSelectable = true;
            this.txtReorderlevel.CustomButton.Visible = false;
            this.txtReorderlevel.Lines = new string[0];
            this.txtReorderlevel.Location = new System.Drawing.Point(126, 379);
            this.txtReorderlevel.MaxLength = 32767;
            this.txtReorderlevel.Name = "txtReorderlevel";
            this.txtReorderlevel.PasswordChar = '\0';
            this.txtReorderlevel.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtReorderlevel.SelectedText = "";
            this.txtReorderlevel.SelectionLength = 0;
            this.txtReorderlevel.SelectionStart = 0;
            this.txtReorderlevel.ShortcutsEnabled = true;
            this.txtReorderlevel.Size = new System.Drawing.Size(233, 23);
            this.txtReorderlevel.TabIndex = 9;
            this.txtReorderlevel.UseSelectable = true;
            this.txtReorderlevel.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtReorderlevel.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtCategoryName
            // 
            // 
            // 
            // 
            this.txtCategoryName.CustomButton.Image = null;
            this.txtCategoryName.CustomButton.Location = new System.Drawing.Point(211, 1);
            this.txtCategoryName.CustomButton.Name = "";
            this.txtCategoryName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCategoryName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCategoryName.CustomButton.TabIndex = 1;
            this.txtCategoryName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCategoryName.CustomButton.UseSelectable = true;
            this.txtCategoryName.CustomButton.Visible = false;
            this.txtCategoryName.Enabled = false;
            this.txtCategoryName.Lines = new string[0];
            this.txtCategoryName.Location = new System.Drawing.Point(128, 186);
            this.txtCategoryName.MaxLength = 32767;
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.PasswordChar = '\0';
            this.txtCategoryName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCategoryName.SelectedText = "";
            this.txtCategoryName.SelectionLength = 0;
            this.txtCategoryName.SelectionStart = 0;
            this.txtCategoryName.ShortcutsEnabled = true;
            this.txtCategoryName.Size = new System.Drawing.Size(233, 23);
            this.txtCategoryName.TabIndex = 4;
            this.txtCategoryName.UseSelectable = true;
            this.txtCategoryName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCategoryName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtProductName
            // 
            // 
            // 
            // 
            this.txtProductName.CustomButton.Image = null;
            this.txtProductName.CustomButton.Location = new System.Drawing.Point(211, 1);
            this.txtProductName.CustomButton.Name = "";
            this.txtProductName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtProductName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtProductName.CustomButton.TabIndex = 1;
            this.txtProductName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtProductName.CustomButton.UseSelectable = true;
            this.txtProductName.CustomButton.Visible = false;
            this.txtProductName.Lines = new string[0];
            this.txtProductName.Location = new System.Drawing.Point(128, 156);
            this.txtProductName.MaxLength = 32767;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.PasswordChar = '\0';
            this.txtProductName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProductName.SelectedText = "";
            this.txtProductName.SelectionLength = 0;
            this.txtProductName.SelectionStart = 0;
            this.txtProductName.ShortcutsEnabled = true;
            this.txtProductName.Size = new System.Drawing.Size(233, 23);
            this.txtProductName.TabIndex = 3;
            this.txtProductName.UseSelectable = true;
            this.txtProductName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtProductName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtProdcutNo
            // 
            // 
            // 
            // 
            this.txtProdcutNo.CustomButton.Image = null;
            this.txtProdcutNo.CustomButton.Location = new System.Drawing.Point(147, 1);
            this.txtProdcutNo.CustomButton.Name = "";
            this.txtProdcutNo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtProdcutNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtProdcutNo.CustomButton.TabIndex = 1;
            this.txtProdcutNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtProdcutNo.CustomButton.UseSelectable = true;
            this.txtProdcutNo.CustomButton.Visible = false;
            this.txtProdcutNo.Enabled = false;
            this.txtProdcutNo.Lines = new string[0];
            this.txtProdcutNo.Location = new System.Drawing.Point(130, 68);
            this.txtProdcutNo.MaxLength = 32767;
            this.txtProdcutNo.Name = "txtProdcutNo";
            this.txtProdcutNo.PasswordChar = '\0';
            this.txtProdcutNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProdcutNo.SelectedText = "";
            this.txtProdcutNo.SelectionLength = 0;
            this.txtProdcutNo.SelectionStart = 0;
            this.txtProdcutNo.ShortcutsEnabled = true;
            this.txtProdcutNo.Size = new System.Drawing.Size(169, 23);
            this.txtProdcutNo.TabIndex = 0;
            this.txtProdcutNo.UseSelectable = true;
            this.txtProdcutNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtProdcutNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtProductCode
            // 
            // 
            // 
            // 
            this.txtProductCode.CustomButton.Image = null;
            this.txtProductCode.CustomButton.Location = new System.Drawing.Point(191, 1);
            this.txtProductCode.CustomButton.Name = "";
            this.txtProductCode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtProductCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtProductCode.CustomButton.TabIndex = 1;
            this.txtProductCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtProductCode.CustomButton.UseSelectable = true;
            this.txtProductCode.CustomButton.Visible = false;
            this.txtProductCode.Lines = new string[0];
            this.txtProductCode.Location = new System.Drawing.Point(129, 96);
            this.txtProductCode.MaxLength = 32767;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.PasswordChar = '\0';
            this.txtProductCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProductCode.SelectedText = "";
            this.txtProductCode.SelectionLength = 0;
            this.txtProductCode.SelectionStart = 0;
            this.txtProductCode.ShortcutsEnabled = true;
            this.txtProductCode.Size = new System.Drawing.Size(213, 23);
            this.txtProductCode.TabIndex = 1;
            this.txtProductCode.UseSelectable = true;
            this.txtProductCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtProductCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(21, 379);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(99, 19);
            this.metroLabel2.TabIndex = 20;
            this.metroLabel2.Text = "Reorder Level :";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(22, 216);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(52, 19);
            this.metroLabel7.TabIndex = 18;
            this.metroLabel7.Text = "Brand :";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(22, 185);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(72, 19);
            this.metroLabel6.TabIndex = 19;
            this.metroLabel6.Text = "Category :";
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblBarCode.Location = new System.Drawing.Point(23, 121);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(72, 19);
            this.lblBarCode.TabIndex = 27;
            this.lblBarCode.Text = "Bar Code :";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(22, 245);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(84, 19);
            this.metroLabel4.TabIndex = 25;
            this.metroLabel4.Text = "Unit(UOM) :";
            // 
            // lblProductNo
            // 
            this.lblProductNo.AutoSize = true;
            this.lblProductNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblProductNo.Location = new System.Drawing.Point(23, 68);
            this.lblProductNo.Name = "lblProductNo";
            this.lblProductNo.Size = new System.Drawing.Size(89, 19);
            this.lblProductNo.TabIndex = 23;
            this.lblProductNo.Text = "Product No. :";
            // 
            // lblProductDiscription
            // 
            this.lblProductDiscription.AutoSize = true;
            this.lblProductDiscription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblProductDiscription.Location = new System.Drawing.Point(22, 156);
            this.lblProductDiscription.Name = "lblProductDiscription";
            this.lblProductDiscription.Size = new System.Drawing.Size(104, 19);
            this.lblProductDiscription.TabIndex = 24;
            this.lblProductDiscription.Text = "Product Name :";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(23, 95);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(100, 19);
            this.metroLabel1.TabIndex = 21;
            this.metroLabel1.Text = "Product Code :";
            // 
            // cbxPackingSize
            // 
            this.cbxPackingSize.FormattingEnabled = true;
            this.cbxPackingSize.ItemHeight = 23;
            this.cbxPackingSize.Items.AddRange(new object[] {
            "Dozens",
            "Pairs",
            "Pcs",
            "KG",
            "Meter",
            "Yard",
            "Monds"});
            this.cbxPackingSize.Location = new System.Drawing.Point(128, 245);
            this.cbxPackingSize.Name = "cbxPackingSize";
            this.cbxPackingSize.Size = new System.Drawing.Size(233, 29);
            this.cbxPackingSize.TabIndex = 8;
            this.cbxPackingSize.UseSelectable = true;
            // 
            // btnAddFormula
            // 
            this.btnAddFormula.ActiveControl = null;
            this.btnAddFormula.Location = new System.Drawing.Point(855, 393);
            this.btnAddFormula.Name = "btnAddFormula";
            this.btnAddFormula.Size = new System.Drawing.Size(168, 74);
            this.btnAddFormula.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnAddFormula.TabIndex = 15;
            this.btnAddFormula.Text = "Add Requisition Materials";
            this.btnAddFormula.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddFormula.TileImage = ((System.Drawing.Image)(resources.GetObject("btnAddFormula.TileImage")));
            this.btnAddFormula.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddFormula.UseSelectable = true;
            this.btnAddFormula.UseTileImage = true;
            this.btnAddFormula.Click += new System.EventHandler(this.btnAddFormula_Click);
            // 
            // chkMandatory
            // 
            this.chkMandatory.AutoSize = true;
            this.chkMandatory.Location = new System.Drawing.Point(224, 444);
            this.chkMandatory.Name = "chkMandatory";
            this.chkMandatory.Size = new System.Drawing.Size(108, 15);
            this.chkMandatory.TabIndex = 21;
            this.chkMandatory.Text = "Mandatory Item";
            this.chkMandatory.UseSelectable = true;
            // 
            // grdItemsColorAttributes
            // 
            this.grdItemsColorAttributes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Beige;
            this.grdItemsColorAttributes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdItemsColorAttributes.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdItemsColorAttributes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdItemsColorAttributes.ColumnHeadersHeight = 25;
            this.grdItemsColorAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdColor,
            this.colItemColor,
            this.colItemDescription});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItemsColorAttributes.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdItemsColorAttributes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdItemsColorAttributes.EnableHeadersVisualStyles = false;
            this.grdItemsColorAttributes.Location = new System.Drawing.Point(443, 226);
            this.grdItemsColorAttributes.MultiSelect = false;
            this.grdItemsColorAttributes.Name = "grdItemsColorAttributes";
            this.grdItemsColorAttributes.RowHeadersVisible = false;
            this.grdItemsColorAttributes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdItemsColorAttributes.Size = new System.Drawing.Size(605, 160);
            this.grdItemsColorAttributes.TabIndex = 13;
            // 
            // colIdColor
            // 
            this.colIdColor.DataPropertyName = "IdColor";
            this.colIdColor.HeaderText = "IdColor";
            this.colIdColor.Name = "colIdColor";
            this.colIdColor.Visible = false;
            // 
            // colItemColor
            // 
            this.colItemColor.DataPropertyName = "ItemColor";
            this.colItemColor.HeaderText = "Colors";
            this.colItemColor.Name = "colItemColor";
            this.colItemColor.Width = 150;
            // 
            // colItemDescription
            // 
            this.colItemDescription.DataPropertyName = "Description";
            this.colItemDescription.HeaderText = "Description";
            this.colItemDescription.Name = "colItemDescription";
            this.colItemDescription.Width = 450;
            // 
            // grdItemsAttributes
            // 
            this.grdItemsAttributes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Beige;
            this.grdItemsAttributes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.grdItemsAttributes.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdItemsAttributes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.grdItemsAttributes.ColumnHeadersHeight = 25;
            this.grdItemsAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdSize,
            this.colSizes,
            this.colDescription});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItemsAttributes.DefaultCellStyle = dataGridViewCellStyle12;
            this.grdItemsAttributes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdItemsAttributes.EnableHeadersVisualStyles = false;
            this.grdItemsAttributes.Location = new System.Drawing.Point(443, 63);
            this.grdItemsAttributes.MultiSelect = false;
            this.grdItemsAttributes.Name = "grdItemsAttributes";
            this.grdItemsAttributes.RowHeadersVisible = false;
            this.grdItemsAttributes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdItemsAttributes.Size = new System.Drawing.Size(605, 157);
            this.grdItemsAttributes.TabIndex = 12;
            // 
            // colIdSize
            // 
            this.colIdSize.HeaderText = "IdSize";
            this.colIdSize.Name = "colIdSize";
            this.colIdSize.Visible = false;
            // 
            // colSizes
            // 
            this.colSizes.HeaderText = "Sizes";
            this.colSizes.Name = "colSizes";
            this.colSizes.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 450;
            // 
            // chkRazing
            // 
            this.chkRazing.AutoSize = true;
            this.chkRazing.Location = new System.Drawing.Point(130, 442);
            this.chkRazing.Name = "chkRazing";
            this.chkRazing.Size = new System.Drawing.Size(88, 15);
            this.chkRazing.TabIndex = 28;
            this.chkRazing.Text = "Razing Item ";
            this.chkRazing.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(20, 281);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(81, 19);
            this.metroLabel5.TabIndex = 25;
            this.metroLabel5.Text = "Stock Type :";
            // 
            // cbxStockType
            // 
            this.cbxStockType.FormattingEnabled = true;
            this.cbxStockType.ItemHeight = 23;
            this.cbxStockType.Items.AddRange(new object[] {
            "",
            "Raw Material",
            "Semi Finished Material",
            "Finished Good"});
            this.cbxStockType.Location = new System.Drawing.Point(126, 281);
            this.cbxStockType.Name = "cbxStockType";
            this.cbxStockType.Size = new System.Drawing.Size(233, 29);
            this.cbxStockType.TabIndex = 8;
            this.cbxStockType.UseSelectable = true;
            // 
            // btnLinkItems
            // 
            this.btnLinkItems.ActiveControl = null;
            this.btnLinkItems.Location = new System.Drawing.Point(773, 393);
            this.btnLinkItems.Name = "btnLinkItems";
            this.btnLinkItems.Size = new System.Drawing.Size(81, 74);
            this.btnLinkItems.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnLinkItems.TabIndex = 17;
            this.btnLinkItems.Text = "Link Items";
            this.btnLinkItems.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLinkItems.TileImage = ((System.Drawing.Image)(resources.GetObject("btnLinkItems.TileImage")));
            this.btnLinkItems.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLinkItems.UseSelectable = true;
            this.btnLinkItems.UseTileImage = true;
            this.btnLinkItems.Click += new System.EventHandler(this.btnLinkItems_Click);
            // 
            // lblConfiguration
            // 
            this.lblConfiguration.AutoSize = true;
            this.lblConfiguration.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblConfiguration.Location = new System.Drawing.Point(13, 329);
            this.lblConfiguration.Name = "lblConfiguration";
            this.lblConfiguration.Size = new System.Drawing.Size(100, 19);
            this.lblConfiguration.TabIndex = 25;
            this.lblConfiguration.Text = "Configuration :";
            // 
            // txtConfiguration
            // 
            // 
            // 
            // 
            this.txtConfiguration.CustomButton.Image = null;
            this.txtConfiguration.CustomButton.Location = new System.Drawing.Point(177, 1);
            this.txtConfiguration.CustomButton.Name = "";
            this.txtConfiguration.CustomButton.Size = new System.Drawing.Size(55, 55);
            this.txtConfiguration.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtConfiguration.CustomButton.TabIndex = 1;
            this.txtConfiguration.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtConfiguration.CustomButton.UseSelectable = true;
            this.txtConfiguration.CustomButton.Visible = false;
            this.txtConfiguration.Lines = new string[0];
            this.txtConfiguration.Location = new System.Drawing.Point(126, 316);
            this.txtConfiguration.MaxLength = 32767;
            this.txtConfiguration.Multiline = true;
            this.txtConfiguration.Name = "txtConfiguration";
            this.txtConfiguration.PasswordChar = '\0';
            this.txtConfiguration.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtConfiguration.SelectedText = "";
            this.txtConfiguration.SelectionLength = 0;
            this.txtConfiguration.SelectionStart = 0;
            this.txtConfiguration.ShortcutsEnabled = true;
            this.txtConfiguration.Size = new System.Drawing.Size(233, 57);
            this.txtConfiguration.TabIndex = 9;
            this.txtConfiguration.UseSelectable = true;
            this.txtConfiguration.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtConfiguration.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 490);
            this.Controls.Add(this.chkMandatory);
            this.Controls.Add(this.chkRazing);
            this.Controls.Add(this.grdItemsColorAttributes);
            this.Controls.Add(this.grdItemsAttributes);
            this.Controls.Add(this.cbxStockType);
            this.Controls.Add(this.cbxPackingSize);
            this.Controls.Add(this.txtMRP);
            this.Controls.Add(this.btnFindCategory);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.txtTradingCo);
            this.Controls.Add(this.btnFindTradingCo);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtConfiguration);
            this.Controls.Add(this.txtReorderlevel);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProdcutNo);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.lblBarCode);
            this.Controls.Add(this.lblConfiguration);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.lblProductNo);
            this.Controls.Add(this.lblProductDiscription);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.lblMRP);
            this.Controls.Add(this.btnAddFormula);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtunitPrice);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnLinkItems);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.Name = "frmProducts";
            this.Text = "Products Registeration";
            this.Load += new System.EventHandler(this.frmProducts_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmProducts_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsColorAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsAttributes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblMRP;
        private MetroFramework.Controls.MetroTextBox txtunitPrice;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroTile btnDelete;
        private MetroFramework.Controls.MetroTile btnClose;
        private MetroFramework.Controls.MetroTile btnSearch;
        private MetroFramework.Controls.MetroTextBox txtMRP;
        private MetroFramework.Controls.MetroButton btnFindCategory;
        private MetroFramework.Controls.MetroTextBox txtBarCode;
        private MetroFramework.Controls.MetroTextBox txtTradingCo;
        private MetroFramework.Controls.MetroButton btnFindTradingCo;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtReorderlevel;
        private MetroFramework.Controls.MetroTextBox txtCategoryName;
        private MetroFramework.Controls.MetroTextBox txtProductName;
        private MetroFramework.Controls.MetroTextBox txtProdcutNo;
        private MetroFramework.Controls.MetroTextBox txtProductCode;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel lblBarCode;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel lblProductNo;
        private MetroFramework.Controls.MetroLabel lblProductDiscription;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cbxPackingSize;
        private TabDataGrid grdItemsAttributes;
        private TabDataGrid grdItemsColorAttributes;
        private MetroFramework.Controls.MetroTile btnAddFormula;
        private MetroFramework.Controls.MetroCheckBox chkRazing;
        private MetroFramework.Controls.MetroCheckBox chkMandatory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSizes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cbxStockType;
        private MetroFramework.Controls.MetroTile btnLinkItems;
        private MetroFramework.Controls.MetroLabel lblConfiguration;
        private MetroFramework.Controls.MetroTextBox txtConfiguration;
    }
}