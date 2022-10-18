namespace Accounts.UI
{
    partial class frmBasicGlovesGarmentsWorkerFinancialReport
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
            this.cbxProductionType = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.AccEditBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.pnlDate = new MetroFramework.Controls.MetroPanel();
            this.StartDate = new MetroFramework.Controls.MetroDateTime();
            this.EndDate = new MetroFramework.Controls.MetroDateTime();
            this.btnLoadbyFilter = new MetroFramework.Controls.MetroButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.btnPrint = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.grdPaymentDetail = new Accounts.UI.CustomDataGrid();
            this.colPaymentDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaymentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdAdvancesDetail = new Accounts.UI.CustomDataGrid();
            this.colAdvancesDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdvancesDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdvancesAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdLoanDetail = new Accounts.UI.CustomDataGrid();
            this.colloanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoanDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoanAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdWork = new Accounts.UI.TabDataGrid();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpacking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSizes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdvancesDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoanDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWork)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxProductionType
            // 
            this.cbxProductionType.FormattingEnabled = true;
            this.cbxProductionType.ItemHeight = 23;
            this.cbxProductionType.Location = new System.Drawing.Point(665, 28);
            this.cbxProductionType.Name = "cbxProductionType";
            this.cbxProductionType.Size = new System.Drawing.Size(167, 29);
            this.cbxProductionType.TabIndex = 29;
            this.cbxProductionType.UseSelectable = true;
            this.cbxProductionType.Visible = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(867, 23);
            this.metroLabel1.TabIndex = 37;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(553, 28);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(110, 25);
            this.metroLabel2.TabIndex = 38;
            this.metroLabel2.Text = "Select Head :";
            this.metroLabel2.Visible = false;
            // 
            // AccEditBox
            // 
            // 
            // 
            // 
            this.AccEditBox.CustomButton.Image = null;
            this.AccEditBox.CustomButton.Location = new System.Drawing.Point(333, 1);
            this.AccEditBox.CustomButton.Name = "";
            this.AccEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.AccEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.AccEditBox.CustomButton.TabIndex = 1;
            this.AccEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.AccEditBox.CustomButton.UseSelectable = true;
            this.AccEditBox.Lines = new string[0];
            this.AccEditBox.Location = new System.Drawing.Point(141, 89);
            this.AccEditBox.MaxLength = 32767;
            this.AccEditBox.Name = "AccEditBox";
            this.AccEditBox.PasswordChar = '\0';
            this.AccEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AccEditBox.SelectedText = "";
            this.AccEditBox.SelectionLength = 0;
            this.AccEditBox.SelectionStart = 0;
            this.AccEditBox.ShortcutsEnabled = true;
            this.AccEditBox.ShowButton = true;
            this.AccEditBox.Size = new System.Drawing.Size(355, 23);
            this.AccEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.AccEditBox.TabIndex = 39;
            this.AccEditBox.UseSelectable = true;
            this.AccEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.AccEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.AccEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.AccEditBox_ButtonClick);
            this.AccEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AccEditBox_KeyPress);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(25, 86);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(117, 25);
            this.metroLabel3.TabIndex = 38;
            this.metroLabel3.Text = "Select Maker :";
            // 
            // pnlDate
            // 
            this.pnlDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDate.Controls.Add(this.StartDate);
            this.pnlDate.Controls.Add(this.EndDate);
            this.pnlDate.Controls.Add(this.btnLoadbyFilter);
            this.pnlDate.Controls.Add(this.metroLabel5);
            this.pnlDate.Controls.Add(this.btnPrint);
            this.pnlDate.Controls.Add(this.metroLabel4);
            this.pnlDate.HorizontalScrollbarBarColor = true;
            this.pnlDate.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlDate.HorizontalScrollbarSize = 10;
            this.pnlDate.Location = new System.Drawing.Point(23, 131);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(867, 50);
            this.pnlDate.TabIndex = 44;
            this.pnlDate.VerticalScrollbarBarColor = true;
            this.pnlDate.VerticalScrollbarHighlightOnWheel = false;
            this.pnlDate.VerticalScrollbarSize = 10;
            // 
            // StartDate
            // 
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDate.Location = new System.Drawing.Point(103, 9);
            this.StartDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(175, 29);
            this.StartDate.TabIndex = 14;
            // 
            // EndDate
            // 
            this.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDate.Location = new System.Drawing.Point(402, 9);
            this.EndDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(160, 29);
            this.EndDate.TabIndex = 15;
            // 
            // btnLoadbyFilter
            // 
            this.btnLoadbyFilter.Location = new System.Drawing.Point(574, 9);
            this.btnLoadbyFilter.Name = "btnLoadbyFilter";
            this.btnLoadbyFilter.Size = new System.Drawing.Size(137, 27);
            this.btnLoadbyFilter.TabIndex = 10;
            this.btnLoadbyFilter.Text = "Load By Date Filter";
            this.btnLoadbyFilter.UseSelectable = true;
            this.btnLoadbyFilter.Click += new System.EventHandler(this.btnLoadbyFilter_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(9, 13);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(88, 19);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "Start Period :";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(717, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(137, 27);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print Report";
            this.btnPrint.UseSelectable = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(304, 13);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(74, 19);
            this.metroLabel4.TabIndex = 13;
            this.metroLabel4.Text = "To Period :";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel6
            // 
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(22, 115);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(869, 23);
            this.metroLabel6.TabIndex = 43;
            this.metroLabel6.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------";
            // 
            // grdPaymentDetail
            // 
            this.grdPaymentDetail.AllowUserToAddRows = false;
            this.grdPaymentDetail.AllowUserToDeleteRows = false;
            this.grdPaymentDetail.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPaymentDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPaymentDetail.ColumnHeadersHeight = 30;
            this.grdPaymentDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPaymentDesc,
            this.colPaymentAmount});
            this.grdPaymentDetail.EnableHeadersVisualStyles = false;
            this.grdPaymentDetail.Location = new System.Drawing.Point(646, 397);
            this.grdPaymentDetail.Name = "grdPaymentDetail";
            this.grdPaymentDetail.ReadOnly = true;
            this.grdPaymentDetail.RowHeadersVisible = false;
            this.grdPaymentDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPaymentDetail.Size = new System.Drawing.Size(244, 219);
            this.grdPaymentDetail.TabIndex = 48;
            // 
            // colPaymentDesc
            // 
            this.colPaymentDesc.DataPropertyName = "Description";
            this.colPaymentDesc.HeaderText = "Desc";
            this.colPaymentDesc.Name = "colPaymentDesc";
            this.colPaymentDesc.ReadOnly = true;
            this.colPaymentDesc.Width = 110;
            // 
            // colPaymentAmount
            // 
            this.colPaymentAmount.DataPropertyName = "Balance";
            this.colPaymentAmount.HeaderText = "Amount";
            this.colPaymentAmount.Name = "colPaymentAmount";
            this.colPaymentAmount.ReadOnly = true;
            this.colPaymentAmount.Width = 120;
            // 
            // grdAdvancesDetail
            // 
            this.grdAdvancesDetail.AllowUserToAddRows = false;
            this.grdAdvancesDetail.AllowUserToDeleteRows = false;
            this.grdAdvancesDetail.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAdvancesDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdAdvancesDetail.ColumnHeadersHeight = 30;
            this.grdAdvancesDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAdvancesDate,
            this.colAdvancesDetail,
            this.colAdvancesAmount});
            this.grdAdvancesDetail.EnableHeadersVisualStyles = false;
            this.grdAdvancesDetail.Location = new System.Drawing.Point(325, 397);
            this.grdAdvancesDetail.Name = "grdAdvancesDetail";
            this.grdAdvancesDetail.ReadOnly = true;
            this.grdAdvancesDetail.RowHeadersVisible = false;
            this.grdAdvancesDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAdvancesDetail.Size = new System.Drawing.Size(312, 219);
            this.grdAdvancesDetail.TabIndex = 47;
            // 
            // colAdvancesDate
            // 
            this.colAdvancesDate.DataPropertyName = "Date";
            dataGridViewCellStyle3.Format = "d";
            this.colAdvancesDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAdvancesDate.HeaderText = "Advances Date";
            this.colAdvancesDate.Name = "colAdvancesDate";
            this.colAdvancesDate.ReadOnly = true;
            // 
            // colAdvancesDetail
            // 
            this.colAdvancesDetail.DataPropertyName = "Description";
            dataGridViewCellStyle4.Format = "d";
            this.colAdvancesDetail.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAdvancesDetail.HeaderText = "Desc";
            this.colAdvancesDetail.Name = "colAdvancesDetail";
            this.colAdvancesDetail.ReadOnly = true;
            // 
            // colAdvancesAmount
            // 
            this.colAdvancesAmount.DataPropertyName = "Balance";
            this.colAdvancesAmount.HeaderText = "Amount";
            this.colAdvancesAmount.Name = "colAdvancesAmount";
            this.colAdvancesAmount.ReadOnly = true;
            // 
            // grdLoanDetail
            // 
            this.grdLoanDetail.AllowUserToAddRows = false;
            this.grdLoanDetail.AllowUserToDeleteRows = false;
            this.grdLoanDetail.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLoanDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdLoanDetail.ColumnHeadersHeight = 30;
            this.grdLoanDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colloanDate,
            this.colLoanDescription,
            this.colLoanAmount});
            this.grdLoanDetail.EnableHeadersVisualStyles = false;
            this.grdLoanDetail.Location = new System.Drawing.Point(20, 397);
            this.grdLoanDetail.Name = "grdLoanDetail";
            this.grdLoanDetail.ReadOnly = true;
            this.grdLoanDetail.RowHeadersVisible = false;
            this.grdLoanDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLoanDetail.Size = new System.Drawing.Size(299, 219);
            this.grdLoanDetail.TabIndex = 46;
            // 
            // colloanDate
            // 
            this.colloanDate.DataPropertyName = "Date";
            dataGridViewCellStyle6.Format = "d";
            this.colloanDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.colloanDate.HeaderText = "Loan Date";
            this.colloanDate.Name = "colloanDate";
            this.colloanDate.ReadOnly = true;
            this.colloanDate.Width = 90;
            // 
            // colLoanDescription
            // 
            this.colLoanDescription.DataPropertyName = "Description";
            this.colLoanDescription.HeaderText = "Desc";
            this.colLoanDescription.Name = "colLoanDescription";
            this.colLoanDescription.ReadOnly = true;
            // 
            // colLoanAmount
            // 
            this.colLoanAmount.DataPropertyName = "Balance";
            this.colLoanAmount.HeaderText = "Amount";
            this.colLoanAmount.Name = "colLoanAmount";
            this.colLoanAmount.ReadOnly = true;
            // 
            // grdWork
            // 
            this.grdWork.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Beige;
            this.grdWork.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdWork.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdWork.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdWork.ColumnHeadersHeight = 25;
            this.grdWork.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colArticleName,
            this.colItemName,
            this.colBrandName,
            this.colpacking,
            this.colSizes,
            this.colWidth,
            this.colQty,
            this.colRate,
            this.colAmount});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdWork.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdWork.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdWork.EnableHeadersVisualStyles = false;
            this.grdWork.Location = new System.Drawing.Point(23, 187);
            this.grdWork.MultiSelect = false;
            this.grdWork.Name = "grdWork";
            this.grdWork.RowHeadersVisible = false;
            this.grdWork.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdWork.Size = new System.Drawing.Size(867, 204);
            this.grdWork.TabIndex = 45;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "CreatedDateTime";
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            // 
            // colArticleName
            // 
            this.colArticleName.DataPropertyName = "ArticleName";
            this.colArticleName.HeaderText = "Article Name";
            this.colArticleName.Name = "colArticleName";
            this.colArticleName.Visible = false;
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "ItemName";
            this.colItemName.HeaderText = "Product / Material Discription";
            this.colItemName.Name = "colItemName";
            this.colItemName.Width = 200;
            // 
            // colBrandName
            // 
            this.colBrandName.DataPropertyName = "BrandName";
            this.colBrandName.HeaderText = "Brand Name";
            this.colBrandName.Name = "colBrandName";
            // 
            // colpacking
            // 
            this.colpacking.DataPropertyName = "PackingSize";
            this.colpacking.HeaderText = "UOM";
            this.colpacking.Name = "colpacking";
            this.colpacking.ReadOnly = true;
            this.colpacking.Width = 80;
            // 
            // colSizes
            // 
            this.colSizes.DataPropertyName = "ItemSize";
            this.colSizes.HeaderText = "Size";
            this.colSizes.Name = "colSizes";
            this.colSizes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSizes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colWidth
            // 
            this.colWidth.DataPropertyName = "IssuanceWidth";
            this.colWidth.HeaderText = "Width";
            this.colWidth.Name = "colWidth";
            this.colWidth.Visible = false;
            this.colWidth.Width = 90;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            this.colQty.HeaderText = "Quantity";
            this.colQty.Name = "colQty";
            this.colQty.Width = 90;
            // 
            // colRate
            // 
            this.colRate.DataPropertyName = "UnitPrice";
            this.colRate.HeaderText = "Rate";
            this.colRate.Name = "colRate";
            this.colRate.Width = 90;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            // 
            // frmBasicGlovesGarmentsWorkerFinancialReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 654);
            this.Controls.Add(this.grdPaymentDetail);
            this.Controls.Add(this.grdAdvancesDetail);
            this.Controls.Add(this.grdLoanDetail);
            this.Controls.Add(this.grdWork);
            this.Controls.Add(this.pnlDate);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.AccEditBox);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cbxProductionType);
            this.Name = "frmBasicGlovesGarmentsWorkerFinancialReport";
            this.Text = "frmBasicGlovesGarmentsWorkerFinancialReport";
            this.Load += new System.EventHandler(this.frmBasicGlovesGarmentsWorkerFinancialReport_Load);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdvancesDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoanDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWork)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cbxProductionType;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox AccEditBox;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroPanel pnlDate;
        private MetroFramework.Controls.MetroDateTime EndDate;
        private MetroFramework.Controls.MetroButton btnLoadbyFilter;
        private MetroFramework.Controls.MetroDateTime StartDate;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private TabDataGrid grdWork;
        private CustomDataGrid grdPaymentDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentAmount;
        private CustomDataGrid grdAdvancesDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdvancesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdvancesDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdvancesAmount;
        private CustomDataGrid grdLoanDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colloanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoanDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoanAmount;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroButton btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpacking;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSizes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}