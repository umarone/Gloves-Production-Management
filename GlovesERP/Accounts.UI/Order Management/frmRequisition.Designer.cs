namespace Accounts.UI
{
    partial class frmRequisition
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
            this.grdFormulaRequisition = new Accounts.UI.TabDataGrid();
            this.colClotheIdDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheItemName = new Accounts.UI.DataGridViewProductWaterMarkColumn();
            this.colClotheColor = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colClotheBariSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheCuffTalliSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheCalculatedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClotheRequiredQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEditBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtCustomerPo = new MetroFramework.Controls.MetroTextBox();
            this.VEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblVoucherNo = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtBrand = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.reqDate = new MetroFramework.Controls.MetroDateTime();
            this.lblDate = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.grdMaterials = new Accounts.UI.TabDataGrid();
            this.colMaterialIdDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialCalculatedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialRequiedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialAvgRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialTotalAvgAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.btnPrevious = new MetroFramework.Controls.MetroTile();
            this.btnNext = new MetroFramework.Controls.MetroTile();
            this.grdOrderdArticles = new Accounts.UI.TabDataGrid();
            this.colOrderedIdDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderdArticleIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderdArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderedArticleQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatuMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdFormulaRequisition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderdArticles)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdFormulaRequisition
            // 
            this.grdFormulaRequisition.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.grdFormulaRequisition.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFormulaRequisition.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFormulaRequisition.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdFormulaRequisition.ColumnHeadersHeight = 25;
            this.grdFormulaRequisition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClotheIdDetail,
            this.colClotheIdItem,
            this.colClotheItemNo,
            this.colClotheItemName,
            this.colClotheColor,
            this.colClotheBariSize,
            this.colClotheWidth,
            this.colClotheCuffTalliSize,
            this.colClotheCalculatedQty,
            this.colClotheCurrentStock,
            this.colClotheRequiredQty});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdFormulaRequisition.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdFormulaRequisition.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdFormulaRequisition.EnableHeadersVisualStyles = false;
            this.grdFormulaRequisition.Location = new System.Drawing.Point(3, 130);
            this.grdFormulaRequisition.MultiSelect = false;
            this.grdFormulaRequisition.Name = "grdFormulaRequisition";
            this.grdFormulaRequisition.RowHeadersVisible = false;
            this.grdFormulaRequisition.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdFormulaRequisition.Size = new System.Drawing.Size(829, 124);
            this.grdFormulaRequisition.TabIndex = 4;
            this.grdFormulaRequisition.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFormulaRequisition_CellEndEdit);
            this.grdFormulaRequisition.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFormulaRequisition_CellEnter);
            this.grdFormulaRequisition.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFormulaRequisition_CellLeave);
            this.grdFormulaRequisition.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdFormulaRequisition_EditingControlShowing);
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
            // colClotheItemNo
            // 
            this.colClotheItemNo.DataPropertyName = "AccountNo";
            this.colClotheItemNo.HeaderText = "Product Code";
            this.colClotheItemNo.Name = "colClotheItemNo";
            this.colClotheItemNo.Visible = false;
            // 
            // colClotheItemName
            // 
            this.colClotheItemName.HeaderText = "Item Name";
            this.colClotheItemName.Name = "colClotheItemName";
            this.colClotheItemName.WatermarkText = "Type Here For Product Selection";
            this.colClotheItemName.Width = 150;
            // 
            // colClotheColor
            // 
            this.colClotheColor.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colClotheColor.HeaderText = "Color";
            this.colClotheColor.Name = "colClotheColor";
            this.colClotheColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colClotheColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colClotheColor.Width = 90;
            // 
            // colClotheBariSize
            // 
            this.colClotheBariSize.HeaderText = "Talli / Bari Size";
            this.colClotheBariSize.Name = "colClotheBariSize";
            this.colClotheBariSize.Width = 110;
            // 
            // colClotheWidth
            // 
            this.colClotheWidth.HeaderText = "Width";
            this.colClotheWidth.Name = "colClotheWidth";
            this.colClotheWidth.Width = 80;
            // 
            // colClotheCuffTalliSize
            // 
            this.colClotheCuffTalliSize.HeaderText = "Cuff / Talli Size";
            this.colClotheCuffTalliSize.Name = "colClotheCuffTalliSize";
            this.colClotheCuffTalliSize.Width = 120;
            // 
            // colClotheCalculatedQty
            // 
            this.colClotheCalculatedQty.DataPropertyName = "Qty";
            this.colClotheCalculatedQty.HeaderText = "Calculated Qty";
            this.colClotheCalculatedQty.Name = "colClotheCalculatedQty";
            this.colClotheCalculatedQty.ReadOnly = true;
            this.colClotheCalculatedQty.Width = 110;
            // 
            // colClotheCurrentStock
            // 
            this.colClotheCurrentStock.HeaderText = "Stock(Av)";
            this.colClotheCurrentStock.Name = "colClotheCurrentStock";
            this.colClotheCurrentStock.ReadOnly = true;
            this.colClotheCurrentStock.Width = 80;
            // 
            // colClotheRequiredQty
            // 
            this.colClotheRequiredQty.HeaderText = "Required";
            this.colClotheRequiredQty.Name = "colClotheRequiredQty";
            this.colClotheRequiredQty.Width = 80;
            // 
            // SEditBox
            // 
            // 
            // 
            // 
            this.SEditBox.CustomButton.Image = null;
            this.SEditBox.CustomButton.Location = new System.Drawing.Point(245, 1);
            this.SEditBox.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.SEditBox.CustomButton.Name = "";
            this.SEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SEditBox.CustomButton.TabIndex = 1;
            this.SEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SEditBox.CustomButton.UseSelectable = true;
            this.SEditBox.Lines = new string[0];
            this.SEditBox.Location = new System.Drawing.Point(91, 90);
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
            this.SEditBox.Size = new System.Drawing.Size(267, 23);
            this.SEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.SEditBox.TabIndex = 25;
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
            this.metroLabel2.Location = new System.Drawing.Point(9, 90);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(76, 19);
            this.metroLabel2.TabIndex = 29;
            this.metroLabel2.Text = "Customer :";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // txtCustomerPo
            // 
            // 
            // 
            // 
            this.txtCustomerPo.CustomButton.Image = null;
            this.txtCustomerPo.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.txtCustomerPo.CustomButton.Name = "";
            this.txtCustomerPo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCustomerPo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCustomerPo.CustomButton.TabIndex = 1;
            this.txtCustomerPo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCustomerPo.CustomButton.UseSelectable = true;
            this.txtCustomerPo.Lines = new string[0];
            this.txtCustomerPo.Location = new System.Drawing.Point(454, 9);
            this.txtCustomerPo.MaxLength = 32767;
            this.txtCustomerPo.Name = "txtCustomerPo";
            this.txtCustomerPo.PasswordChar = '\0';
            this.txtCustomerPo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCustomerPo.SelectedText = "";
            this.txtCustomerPo.SelectionLength = 0;
            this.txtCustomerPo.SelectionStart = 0;
            this.txtCustomerPo.ShortcutsEnabled = true;
            this.txtCustomerPo.ShowButton = true;
            this.txtCustomerPo.Size = new System.Drawing.Size(131, 23);
            this.txtCustomerPo.Style = MetroFramework.MetroColorStyle.Green;
            this.txtCustomerPo.TabIndex = 27;
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
            this.VEditBox.CustomButton.Location = new System.Drawing.Point(143, 1);
            this.VEditBox.CustomButton.Name = "";
            this.VEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.VEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.VEditBox.CustomButton.TabIndex = 1;
            this.VEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.VEditBox.CustomButton.UseSelectable = true;
            this.VEditBox.Lines = new string[0];
            this.VEditBox.Location = new System.Drawing.Point(91, 63);
            this.VEditBox.MaxLength = 32767;
            this.VEditBox.Name = "VEditBox";
            this.VEditBox.PasswordChar = '\0';
            this.VEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.VEditBox.SelectedText = "";
            this.VEditBox.SelectionLength = 0;
            this.VEditBox.SelectionStart = 0;
            this.VEditBox.ShortcutsEnabled = true;
            this.VEditBox.ShowButton = true;
            this.VEditBox.Size = new System.Drawing.Size(165, 23);
            this.VEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.VEditBox.TabIndex = 28;
            this.VEditBox.UseSelectable = true;
            this.VEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.VEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblVoucherNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblVoucherNo.Location = new System.Drawing.Point(13, 64);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(61, 19);
            this.lblVoucherNo.TabIndex = 26;
            this.lblVoucherNo.Text = "Req No :";
            this.lblVoucherNo.UseCustomBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(354, 66);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(101, 19);
            this.metroLabel3.TabIndex = 30;
            this.metroLabel3.Text = "Customer Po #";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // txtBrand
            // 
            // 
            // 
            // 
            this.txtBrand.CustomButton.Image = null;
            this.txtBrand.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.txtBrand.CustomButton.Name = "";
            this.txtBrand.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBrand.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBrand.CustomButton.TabIndex = 1;
            this.txtBrand.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBrand.CustomButton.UseSelectable = true;
            this.txtBrand.Lines = new string[0];
            this.txtBrand.Location = new System.Drawing.Point(454, 36);
            this.txtBrand.MaxLength = 32767;
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.PasswordChar = '\0';
            this.txtBrand.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBrand.SelectedText = "";
            this.txtBrand.SelectionLength = 0;
            this.txtBrand.SelectionStart = 0;
            this.txtBrand.ShortcutsEnabled = true;
            this.txtBrand.ShowButton = true;
            this.txtBrand.Size = new System.Drawing.Size(131, 23);
            this.txtBrand.Style = MetroFramework.MetroColorStyle.Green;
            this.txtBrand.TabIndex = 32;
            this.txtBrand.UseSelectable = true;
            this.txtBrand.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBrand.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(356, 91);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(52, 19);
            this.metroLabel6.TabIndex = 31;
            this.metroLabel6.Text = "Brand :";
            this.metroLabel6.UseCustomBackColor = true;
            // 
            // reqDate
            // 
            this.reqDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.reqDate.Location = new System.Drawing.Point(675, 86);
            this.reqDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.reqDate.Name = "reqDate";
            this.reqDate.Size = new System.Drawing.Size(146, 29);
            this.reqDate.TabIndex = 34;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDate.Location = new System.Drawing.Point(597, 91);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(72, 19);
            this.lblDate.TabIndex = 33;
            this.lblDate.Text = "Req Date :";
            this.lblDate.UseCustomBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(591, 61);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(79, 19);
            this.metroLabel1.TabIndex = 31;
            this.metroLabel1.Text = "Order Size :";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(124, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(675, 60);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(146, 23);
            this.metroTextBox1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTextBox1.TabIndex = 32;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // grdMaterials
            // 
            this.grdMaterials.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Beige;
            this.grdMaterials.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdMaterials.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdMaterials.ColumnHeadersHeight = 25;
            this.grdMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaterialIdDetail,
            this.colMaterialIdItem,
            this.colMaterialProductCode,
            this.colMaterialItemName,
            this.colMaterialColor,
            this.colMaterialCalculatedQty,
            this.colMaterialCurrentStock,
            this.colMaterialRequiedQty,
            this.colMaterialAvgRate,
            this.colMaterialTotalAvgAmount});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMaterials.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdMaterials.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdMaterials.EnableHeadersVisualStyles = false;
            this.grdMaterials.Location = new System.Drawing.Point(4, 258);
            this.grdMaterials.MultiSelect = false;
            this.grdMaterials.Name = "grdMaterials";
            this.grdMaterials.RowHeadersVisible = false;
            this.grdMaterials.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdMaterials.Size = new System.Drawing.Size(828, 254);
            this.grdMaterials.TabIndex = 4;
            this.grdMaterials.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdMaterials_EditingControlShowing);
            // 
            // colMaterialIdDetail
            // 
            this.colMaterialIdDetail.HeaderText = "IdMaterial";
            this.colMaterialIdDetail.Name = "colMaterialIdDetail";
            this.colMaterialIdDetail.Visible = false;
            // 
            // colMaterialIdItem
            // 
            this.colMaterialIdItem.HeaderText = "IdItem";
            this.colMaterialIdItem.Name = "colMaterialIdItem";
            this.colMaterialIdItem.Visible = false;
            // 
            // colMaterialProductCode
            // 
            this.colMaterialProductCode.DataPropertyName = "AccountNo";
            this.colMaterialProductCode.HeaderText = "Product Code";
            this.colMaterialProductCode.Name = "colMaterialProductCode";
            this.colMaterialProductCode.Visible = false;
            // 
            // colMaterialItemName
            // 
            this.colMaterialItemName.HeaderText = "Item Name";
            this.colMaterialItemName.Name = "colMaterialItemName";
            this.colMaterialItemName.Width = 200;
            // 
            // colMaterialColor
            // 
            this.colMaterialColor.HeaderText = "Operation";
            this.colMaterialColor.Name = "colMaterialColor";
            this.colMaterialColor.Width = 85;
            // 
            // colMaterialCalculatedQty
            // 
            this.colMaterialCalculatedQty.HeaderText = "Calculated Qty";
            this.colMaterialCalculatedQty.Name = "colMaterialCalculatedQty";
            this.colMaterialCalculatedQty.Width = 115;
            // 
            // colMaterialCurrentStock
            // 
            this.colMaterialCurrentStock.HeaderText = "Current Stock";
            this.colMaterialCurrentStock.Name = "colMaterialCurrentStock";
            // 
            // colMaterialRequiedQty
            // 
            this.colMaterialRequiedQty.DataPropertyName = "Qty";
            this.colMaterialRequiedQty.HeaderText = "Req Qty";
            this.colMaterialRequiedQty.Name = "colMaterialRequiedQty";
            // 
            // colMaterialAvgRate
            // 
            this.colMaterialAvgRate.HeaderText = "Avg Rate";
            this.colMaterialAvgRate.Name = "colMaterialAvgRate";
            // 
            // colMaterialTotalAvgAmount
            // 
            this.colMaterialTotalAvgAmount.HeaderText = "Total Avg Amount";
            this.colMaterialTotalAvgAmount.Name = "colMaterialTotalAvgAmount";
            this.colMaterialTotalAvgAmount.Width = 120;
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(323, 518);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 40);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ActiveControl = null;
            this.btnDelete.Location = new System.Drawing.Point(425, 518);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 40);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Red;
            this.btnDelete.TabIndex = 36;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.UseSelectable = true;
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.Location = new System.Drawing.Point(527, 518);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 40);
            this.btnClose.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseSelectable = true;
            // 
            // btnPrevious
            // 
            this.btnPrevious.ActiveControl = null;
            this.btnPrevious.Location = new System.Drawing.Point(630, 518);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(101, 40);
            this.btnPrevious.Style = MetroFramework.MetroColorStyle.Brown;
            this.btnPrevious.TabIndex = 38;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrevious.UseSelectable = true;
            // 
            // btnNext
            // 
            this.btnNext.ActiveControl = null;
            this.btnNext.Location = new System.Drawing.Point(732, 518);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(101, 40);
            this.btnNext.Style = MetroFramework.MetroColorStyle.Brown;
            this.btnNext.TabIndex = 39;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNext.UseSelectable = true;
            // 
            // grdOrderdArticles
            // 
            this.grdOrderdArticles.AllowUserToAddRows = false;
            this.grdOrderdArticles.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Beige;
            this.grdOrderdArticles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdOrderdArticles.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOrderdArticles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdOrderdArticles.ColumnHeadersHeight = 25;
            this.grdOrderdArticles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderedIdDetail,
            this.colOrderdArticleIdItem,
            this.colOrderNo,
            this.colOrderdArticleName,
            this.colOrderedArticleQty});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdOrderdArticles.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdOrderdArticles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdOrderdArticles.EnableHeadersVisualStyles = false;
            this.grdOrderdArticles.Location = new System.Drawing.Point(838, 130);
            this.grdOrderdArticles.MultiSelect = false;
            this.grdOrderdArticles.Name = "grdOrderdArticles";
            this.grdOrderdArticles.ReadOnly = true;
            this.grdOrderdArticles.RowHeadersVisible = false;
            this.grdOrderdArticles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdOrderdArticles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdOrderdArticles.Size = new System.Drawing.Size(320, 428);
            this.grdOrderdArticles.TabIndex = 41;
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
            // colOrderNo
            // 
            this.colOrderNo.HeaderText = "Seq No #";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.ReadOnly = true;
            this.colOrderNo.Width = 70;
            // 
            // colOrderdArticleName
            // 
            this.colOrderdArticleName.DataPropertyName = "ItemName";
            this.colOrderdArticleName.HeaderText = "Article Names";
            this.colOrderdArticleName.Name = "colOrderdArticleName";
            this.colOrderdArticleName.ReadOnly = true;
            this.colOrderdArticleName.Width = 150;
            // 
            // colOrderedArticleQty
            // 
            this.colOrderedArticleQty.HeaderText = "Qty";
            this.colOrderedArticleQty.Name = "colOrderedArticleQty";
            this.colOrderedArticleQty.ReadOnly = true;
            this.colOrderedArticleQty.Width = 80;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatuMessage});
            this.statusStrip1.Location = new System.Drawing.Point(20, 574);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1138, 22);
            this.statusStrip1.TabIndex = 56;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatuMessage
            // 
            this.lblStatuMessage.Name = "lblStatuMessage";
            this.lblStatuMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Red;
            this.lblStatus.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblStatus.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(826, 88);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(323, 25);
            this.lblStatus.TabIndex = 57;
            this.lblStatus.Text = "Requisition Prepared For This Article";
            this.lblStatus.UseCustomBackColor = true;
            this.lblStatus.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panel1.Controls.Add(this.txtCustomerPo);
            this.panel1.Controls.Add(this.txtBrand);
            this.panel1.Location = new System.Drawing.Point(7, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1150, 69);
            this.panel1.TabIndex = 58;
            // 
            // frmRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 616);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grdOrderdArticles);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.reqDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.SEditBox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.VEditBox);
            this.Controls.Add(this.lblVoucherNo);
            this.Controls.Add(this.grdMaterials);
            this.Controls.Add(this.grdFormulaRequisition);
            this.Controls.Add(this.panel1);
            this.Name = "frmRequisition";
            this.Text = "Gloves Requisition";
            this.Load += new System.EventHandler(this.frmRequisition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdFormulaRequisition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderdArticles)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabDataGrid grdFormulaRequisition;
        private MetroFramework.Controls.MetroTextBox SEditBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtCustomerPo;
        private MetroFramework.Controls.MetroTextBox VEditBox;
        private MetroFramework.Controls.MetroLabel lblVoucherNo;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtBrand;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroDateTime reqDate;
        private MetroFramework.Controls.MetroLabel lblDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private TabDataGrid grdMaterials;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroTile btnDelete;
        private MetroFramework.Controls.MetroTile btnClose;
        private MetroFramework.Controls.MetroTile btnPrevious;
        private MetroFramework.Controls.MetroTile btnNext;
        private TabDataGrid grdOrderdArticles;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatuMessage;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheIdDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheItemNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn colClotheColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheBariSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheCuffTalliSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheCalculatedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClotheRequiredQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderedIdDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderdArticleIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderdArticleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderedArticleQty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialIdDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialCalculatedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialRequiedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialAvgRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialTotalAvgAmount;
        private DataGridViewProductWaterMarkColumn colClotheItemName;
    }
}