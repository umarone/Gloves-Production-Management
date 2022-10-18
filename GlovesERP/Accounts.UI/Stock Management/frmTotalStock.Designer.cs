namespace Accounts.UI
{
    partial class frmTotalStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlPeriod = new System.Windows.Forms.GroupBox();
            this.btnExcelExport = new MetroFramework.Controls.MetroTile();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnLoad = new MetroFramework.Controls.MetroTile();
            this.chkDate = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.EndDate = new MetroFramework.Controls.MetroDateTime();
            this.StartDate = new MetroFramework.Controls.MetroDateTime();
            this.grdTotalStock = new System.Windows.Forms.DataGridView();
            this.CbxCategories = new MetroFramework.Controls.MetroComboBox();
            this.txtsearch = new MetroFramework.Controls.MetroTextBox();
            this.lblSearch = new MetroFramework.Controls.MetroLabel();
            this.chkByGlovesCategory = new MetroFramework.Controls.MetroCheckBox();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lblSelectCategory = new MetroFramework.Controls.MetroLabel();
            this.pnlCategory = new System.Windows.Forms.Panel();
            this.chkByGarmentsCategory = new MetroFramework.Controls.MetroCheckBox();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchases = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchasesReturn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReturns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStoreOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStoreIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRubberOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRubberingIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDyingUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClosing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAVRBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalStock)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.pnlCategory.SuspendLayout();
            this.flowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.BackColor = System.Drawing.Color.MistyRose;
            this.pnlPeriod.Controls.Add(this.btnExcelExport);
            this.pnlPeriod.Controls.Add(this.metroLabel2);
            this.pnlPeriod.Controls.Add(this.btnLoad);
            this.pnlPeriod.Controls.Add(this.chkDate);
            this.pnlPeriod.Controls.Add(this.metroLabel1);
            this.pnlPeriod.Controls.Add(this.EndDate);
            this.pnlPeriod.Controls.Add(this.StartDate);
            this.pnlPeriod.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPeriod.ForeColor = System.Drawing.SystemColors.Desktop;
            this.pnlPeriod.Location = new System.Drawing.Point(3, 3);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(1187, 66);
            this.pnlPeriod.TabIndex = 7;
            this.pnlPeriod.TabStop = false;
            this.pnlPeriod.Text = "Periodic Stock";
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.ActiveControl = null;
            this.btnExcelExport.BackColor = System.Drawing.Color.RosyBrown;
            this.btnExcelExport.Location = new System.Drawing.Point(912, 20);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(106, 39);
            this.btnExcelExport.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnExcelExport.TabIndex = 9;
            this.btnExcelExport.Text = "Excel Export";
            this.btnExcelExport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcelExport.UseCustomBackColor = true;
            this.btnExcelExport.UseSelectable = true;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(362, 30);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(74, 19);
            this.metroLabel2.TabIndex = 9;
            this.metroLabel2.Text = "To Period :";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.ActiveControl = null;
            this.btnLoad.BackColor = System.Drawing.Color.RosyBrown;
            this.btnLoad.Location = new System.Drawing.Point(804, 20);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(106, 39);
            this.btnLoad.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Load";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoad.UseCustomBackColor = true;
            this.btnLoad.UseSelectable = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Checked = true;
            this.chkDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDate.Location = new System.Drawing.Point(698, 35);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(90, 15);
            this.chkDate.TabIndex = 9;
            this.chkDate.Text = "Exclude Date";
            this.chkDate.UseCustomBackColor = true;
            this.chkDate.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(15, 31);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(90, 19);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "Start Period : ";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // EndDate
            // 
            this.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDate.Location = new System.Drawing.Point(439, 26);
            this.EndDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(241, 29);
            this.EndDate.TabIndex = 10;
            // 
            // StartDate
            // 
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDate.Location = new System.Drawing.Point(110, 26);
            this.StartDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(245, 29);
            this.StartDate.TabIndex = 9;
            // 
            // grdTotalStock
            // 
            this.grdTotalStock.AllowUserToAddRows = false;
            this.grdTotalStock.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.grdTotalStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTotalStock.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTotalStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdTotalStock.ColumnHeadersHeight = 27;
            this.grdTotalStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountName,
            this.colPackingSize,
            this.colOpening,
            this.colPurchases,
            this.colPurchasesReturn,
            this.colSales,
            this.colReturns,
            this.colStoreOut,
            this.colStoreIn,
            this.colRubberOut,
            this.colRubberingIN,
            this.colDyingUnits,
            this.colClosing,
            this.colStockBalance,
            this.colAVRBalance});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTotalStock.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdTotalStock.EnableHeadersVisualStyles = false;
            this.grdTotalStock.Location = new System.Drawing.Point(3, 34);
            this.grdTotalStock.Name = "grdTotalStock";
            this.grdTotalStock.ReadOnly = true;
            this.grdTotalStock.RowHeadersVisible = false;
            this.grdTotalStock.Size = new System.Drawing.Size(1184, 308);
            this.grdTotalStock.TabIndex = 8;
            // 
            // CbxCategories
            // 
            this.CbxCategories.FormattingEnabled = true;
            this.CbxCategories.ItemHeight = 23;
            this.CbxCategories.Location = new System.Drawing.Point(123, 7);
            this.CbxCategories.Name = "CbxCategories";
            this.CbxCategories.Size = new System.Drawing.Size(360, 29);
            this.CbxCategories.TabIndex = 10;
            this.CbxCategories.UseSelectable = true;
            // 
            // txtsearch
            // 
            // 
            // 
            // 
            this.txtsearch.CustomButton.Image = null;
            this.txtsearch.CustomButton.Location = new System.Drawing.Point(377, 1);
            this.txtsearch.CustomButton.Name = "";
            this.txtsearch.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtsearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtsearch.CustomButton.TabIndex = 1;
            this.txtsearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtsearch.CustomButton.UseSelectable = true;
            this.txtsearch.CustomButton.Visible = false;
            this.txtsearch.Lines = new string[0];
            this.txtsearch.Location = new System.Drawing.Point(98, 5);
            this.txtsearch.MaxLength = 32767;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PasswordChar = '\0';
            this.txtsearch.PromptText = "Search Here";
            this.txtsearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtsearch.SelectedText = "";
            this.txtsearch.SelectionLength = 0;
            this.txtsearch.SelectionStart = 0;
            this.txtsearch.ShortcutsEnabled = true;
            this.txtsearch.Size = new System.Drawing.Size(399, 23);
            this.txtsearch.TabIndex = 11;
            this.txtsearch.UseSelectable = true;
            this.txtsearch.WaterMark = "Search Here";
            this.txtsearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtsearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblSearch.Location = new System.Drawing.Point(6, 5);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(90, 19);
            this.lblSearch.TabIndex = 12;
            this.lblSearch.Text = "Search Stock :";
            this.lblSearch.UseCustomBackColor = true;
            // 
            // chkByGlovesCategory
            // 
            this.chkByGlovesCategory.AutoSize = true;
            this.chkByGlovesCategory.Location = new System.Drawing.Point(3, 75);
            this.chkByGlovesCategory.Name = "chkByGlovesCategory";
            this.chkByGlovesCategory.Size = new System.Drawing.Size(196, 15);
            this.chkByGlovesCategory.TabIndex = 13;
            this.chkByGlovesCategory.Text = "By Gloves Raw Material Category";
            this.chkByGlovesCategory.UseSelectable = true;
            this.chkByGlovesCategory.CheckedChanged += new System.EventHandler(this.chkByCategory_CheckedChanged);
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pnlGrid.Controls.Add(this.lblSearch);
            this.pnlGrid.Controls.Add(this.txtsearch);
            this.pnlGrid.Controls.Add(this.grdTotalStock);
            this.pnlGrid.Location = new System.Drawing.Point(3, 164);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1190, 345);
            this.pnlGrid.TabIndex = 14;
            // 
            // lblSelectCategory
            // 
            this.lblSelectCategory.AutoSize = true;
            this.lblSelectCategory.Location = new System.Drawing.Point(7, 11);
            this.lblSelectCategory.Name = "lblSelectCategory";
            this.lblSelectCategory.Size = new System.Drawing.Size(112, 19);
            this.lblSelectCategory.TabIndex = 9;
            this.lblSelectCategory.Text = "Select Category : ";
            this.lblSelectCategory.UseCustomBackColor = true;
            // 
            // pnlCategory
            // 
            this.pnlCategory.BackColor = System.Drawing.Color.RosyBrown;
            this.pnlCategory.Controls.Add(this.lblSelectCategory);
            this.pnlCategory.Controls.Add(this.CbxCategories);
            this.pnlCategory.Location = new System.Drawing.Point(3, 117);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Size = new System.Drawing.Size(1190, 41);
            this.pnlCategory.TabIndex = 15;
            // 
            // chkByGarmentsCategory
            // 
            this.chkByGarmentsCategory.AutoSize = true;
            this.chkByGarmentsCategory.Location = new System.Drawing.Point(3, 96);
            this.chkByGarmentsCategory.Name = "chkByGarmentsCategory";
            this.chkByGarmentsCategory.Size = new System.Drawing.Size(212, 15);
            this.chkByGarmentsCategory.TabIndex = 13;
            this.chkByGarmentsCategory.Text = "By Garments Raw Material Category";
            this.chkByGarmentsCategory.UseSelectable = true;
            this.chkByGarmentsCategory.CheckedChanged += new System.EventHandler(this.chkAllStock_CheckedChanged);
            // 
            // flowPanel
            // 
            this.flowPanel.AutoSize = true;
            this.flowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowPanel.Controls.Add(this.pnlPeriod);
            this.flowPanel.Controls.Add(this.chkByGlovesCategory);
            this.flowPanel.Controls.Add(this.chkByGarmentsCategory);
            this.flowPanel.Controls.Add(this.pnlCategory);
            this.flowPanel.Controls.Add(this.pnlGrid);
            this.flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanel.Location = new System.Drawing.Point(6, 55);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(1196, 512);
            this.flowPanel.TabIndex = 16;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AccountName";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Product Discription";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PackingSize";
            this.dataGridViewTextBoxColumn2.HeaderText = "Packing Size";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Opening";
            this.dataGridViewTextBoxColumn3.HeaderText = "OPening";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Purchases";
            this.dataGridViewTextBoxColumn4.HeaderText = "Purchases";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Sales";
            this.dataGridViewTextBoxColumn5.HeaderText = "Sold";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Returns";
            this.dataGridViewTextBoxColumn6.HeaderText = "Returns";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Closing";
            this.dataGridViewTextBoxColumn7.HeaderText = "Closing Stock";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NVR";
            this.dataGridViewTextBoxColumn8.HeaderText = "NVR Balance";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "AVR";
            this.dataGridViewTextBoxColumn9.HeaderText = "AVR Balance";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "AVR";
            this.dataGridViewTextBoxColumn10.HeaderText = "AVR Balance";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 70;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "SideINRubbering";
            this.dataGridViewTextBoxColumn11.HeaderText = "Side";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "DyingUnits";
            this.dataGridViewTextBoxColumn12.HeaderText = "Dying";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            this.dataGridViewTextBoxColumn12.Width = 70;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Closing";
            this.dataGridViewTextBoxColumn13.HeaderText = "Closing";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "NVR";
            this.dataGridViewTextBoxColumn14.HeaderText = "NVR Balance";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "AVR";
            this.dataGridViewTextBoxColumn15.HeaderText = "AVR Balance";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // colAccountName
            // 
            this.colAccountName.DataPropertyName = "ItemName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAccountName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAccountName.HeaderText = "Product Discription";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 180;
            // 
            // colPackingSize
            // 
            this.colPackingSize.DataPropertyName = "PackingSize";
            this.colPackingSize.HeaderText = "UOM";
            this.colPackingSize.Name = "colPackingSize";
            this.colPackingSize.ReadOnly = true;
            this.colPackingSize.Width = 80;
            // 
            // colOpening
            // 
            this.colOpening.DataPropertyName = "Opening";
            this.colOpening.HeaderText = "OP";
            this.colOpening.Name = "colOpening";
            this.colOpening.ReadOnly = true;
            this.colOpening.Width = 70;
            // 
            // colPurchases
            // 
            this.colPurchases.DataPropertyName = "Purchases";
            this.colPurchases.HeaderText = "P";
            this.colPurchases.Name = "colPurchases";
            this.colPurchases.ReadOnly = true;
            this.colPurchases.Width = 70;
            // 
            // colPurchasesReturn
            // 
            this.colPurchasesReturn.DataPropertyName = "PurchasesReturn";
            this.colPurchasesReturn.HeaderText = "PR";
            this.colPurchasesReturn.Name = "colPurchasesReturn";
            this.colPurchasesReturn.ReadOnly = true;
            this.colPurchasesReturn.Width = 70;
            // 
            // colSales
            // 
            this.colSales.DataPropertyName = "Sales";
            this.colSales.HeaderText = "S";
            this.colSales.Name = "colSales";
            this.colSales.ReadOnly = true;
            this.colSales.Width = 70;
            // 
            // colReturns
            // 
            this.colReturns.DataPropertyName = "SalesReturns";
            this.colReturns.HeaderText = "SR";
            this.colReturns.Name = "colReturns";
            this.colReturns.ReadOnly = true;
            this.colReturns.Width = 70;
            // 
            // colStoreOut
            // 
            this.colStoreOut.DataPropertyName = "ProductionOut";
            this.colStoreOut.HeaderText = "MOut";
            this.colStoreOut.Name = "colStoreOut";
            this.colStoreOut.ReadOnly = true;
            this.colStoreOut.Width = 70;
            // 
            // colStoreIn
            // 
            this.colStoreIn.DataPropertyName = "ProductionIn";
            this.colStoreIn.HeaderText = "MIN";
            this.colStoreIn.Name = "colStoreIn";
            this.colStoreIn.ReadOnly = true;
            this.colStoreIn.Width = 70;
            // 
            // colRubberOut
            // 
            this.colRubberOut.DataPropertyName = "RubberingOut";
            this.colRubberOut.HeaderText = "ROut";
            this.colRubberOut.Name = "colRubberOut";
            this.colRubberOut.ReadOnly = true;
            this.colRubberOut.Width = 70;
            // 
            // colRubberingIN
            // 
            this.colRubberingIN.DataPropertyName = "RubberingIn";
            this.colRubberingIN.HeaderText = "Side";
            this.colRubberingIN.Name = "colRubberingIN";
            this.colRubberingIN.ReadOnly = true;
            this.colRubberingIN.Width = 70;
            // 
            // colDyingUnits
            // 
            this.colDyingUnits.DataPropertyName = "DyingUnits";
            this.colDyingUnits.HeaderText = "Dying";
            this.colDyingUnits.Name = "colDyingUnits";
            this.colDyingUnits.ReadOnly = true;
            this.colDyingUnits.Visible = false;
            this.colDyingUnits.Width = 70;
            // 
            // colClosing
            // 
            this.colClosing.DataPropertyName = "Closing";
            this.colClosing.HeaderText = "Closing";
            this.colClosing.Name = "colClosing";
            this.colClosing.ReadOnly = true;
            // 
            // colStockBalance
            // 
            this.colStockBalance.DataPropertyName = "NVR";
            this.colStockBalance.HeaderText = "NVR Balance";
            this.colStockBalance.Name = "colStockBalance";
            this.colStockBalance.ReadOnly = true;
            // 
            // colAVRBalance
            // 
            this.colAVRBalance.DataPropertyName = "AVR";
            this.colAVRBalance.HeaderText = "AVR Balance";
            this.colAVRBalance.Name = "colAVRBalance";
            this.colAVRBalance.ReadOnly = true;
            // 
            // frmTotalStock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1214, 590);
            this.Controls.Add(this.flowPanel);
            this.Name = "frmTotalStock";
            this.Text = "Raw Material Stock Analysis";
            this.Load += new System.EventHandler(this.frmTotalStock_Load);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalStock)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.pnlCategory.ResumeLayout(false);
            this.pnlCategory.PerformLayout();
            this.flowPanel.ResumeLayout(false);
            this.flowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox pnlPeriod;
        private System.Windows.Forms.DataGridView grdTotalStock;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroCheckBox chkDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroDateTime EndDate;
        private MetroFramework.Controls.MetroDateTime StartDate;
        private MetroFramework.Controls.MetroTile btnExcelExport;
        private MetroFramework.Controls.MetroTile btnLoad;
        private MetroFramework.Controls.MetroComboBox CbxCategories;
        private MetroFramework.Controls.MetroTextBox txtsearch;
        private MetroFramework.Controls.MetroLabel lblSearch;
        private MetroFramework.Controls.MetroCheckBox chkByGlovesCategory;
        private System.Windows.Forms.Panel pnlGrid;
        private MetroFramework.Controls.MetroLabel lblSelectCategory;
        private System.Windows.Forms.Panel pnlCategory;
        private MetroFramework.Controls.MetroCheckBox chkByGarmentsCategory;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpening;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchases;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchasesReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReturns;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStoreOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStoreIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRubberOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRubberingIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDyingUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClosing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAVRBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
    }
}