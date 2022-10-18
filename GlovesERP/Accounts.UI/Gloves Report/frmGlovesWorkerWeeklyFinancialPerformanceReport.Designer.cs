namespace Accounts.UI
{
    partial class frmGlovesWorkerWeeklyFinancialPerformanceReport
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
            this.chkInspectionSearchByArticle = new MetroFramework.Controls.MetroCheckBox();
            this.txtInspectionSearch = new MetroFramework.Controls.MetroTextBox();
            this.chkInspectionSearchByBrand = new MetroFramework.Controls.MetroCheckBox();
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
            this.grdWorkerBill = new Accounts.UI.TabDataGrid();
            this.colProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerPo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionBrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalAmount = new MetroFramework.Controls.MetroLabel();
            this.btnExport = new MetroFramework.Controls.MetroButton();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.pnlDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerBill)).BeginInit();
            this.SuspendLayout();
            // 
            // chkInspectionSearchByArticle
            // 
            this.chkInspectionSearchByArticle.AutoSize = true;
            this.chkInspectionSearchByArticle.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkInspectionSearchByArticle.Location = new System.Drawing.Point(21, 192);
            this.chkInspectionSearchByArticle.Name = "chkInspectionSearchByArticle";
            this.chkInspectionSearchByArticle.Size = new System.Drawing.Size(126, 19);
            this.chkInspectionSearchByArticle.TabIndex = 5;
            this.chkInspectionSearchByArticle.Text = "Search By Article";
            this.chkInspectionSearchByArticle.UseSelectable = true;
            this.chkInspectionSearchByArticle.CheckedChanged += new System.EventHandler(this.chkInspectionSearchByArticle_CheckedChanged);
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
            this.txtInspectionSearch.Location = new System.Drawing.Point(285, 192);
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
            this.chkInspectionSearchByBrand.Location = new System.Drawing.Point(154, 193);
            this.chkInspectionSearchByBrand.Name = "chkInspectionSearchByBrand";
            this.chkInspectionSearchByBrand.Size = new System.Drawing.Size(124, 19);
            this.chkInspectionSearchByBrand.TabIndex = 5;
            this.chkInspectionSearchByBrand.Text = "Search By Brand";
            this.chkInspectionSearchByBrand.UseSelectable = true;
            this.chkInspectionSearchByBrand.CheckedChanged += new System.EventHandler(this.chkInspectionSearchByBrand_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(1, 54);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(1141, 23);
            this.metroLabel1.TabIndex = 29;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "---------------------------";
            // 
            // chkApplyDateFilter
            // 
            this.chkApplyDateFilter.AutoSize = true;
            this.chkApplyDateFilter.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkApplyDateFilter.Location = new System.Drawing.Point(449, 85);
            this.chkApplyDateFilter.Name = "chkApplyDateFilter";
            this.chkApplyDateFilter.Size = new System.Drawing.Size(127, 19);
            this.chkApplyDateFilter.TabIndex = 2;
            this.chkApplyDateFilter.Text = "Apply Date Filter";
            this.chkApplyDateFilter.UseSelectable = true;
            this.chkApplyDateFilter.CheckedChanged += new System.EventHandler(this.chkApplyDateFilter_CheckedChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(353, 81);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(87, 23);
            this.btnLoad.TabIndex = 1;
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
            this.AccEditBox.CustomButton.Location = new System.Drawing.Point(196, 1);
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
            this.AccEditBox.Size = new System.Drawing.Size(218, 23);
            this.AccEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.AccEditBox.TabIndex = 0;
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
            this.lblAccountName.Size = new System.Drawing.Size(99, 19);
            this.lblAccountName.TabIndex = 30;
            this.lblAccountName.Text = "Select Worker :";
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
            this.pnlDate.Size = new System.Drawing.Size(1127, 50);
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
            this.btnLoadbyFilter.TabIndex = 0;
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
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "---------------------------";
            // 
            // grdWorkerBill
            // 
            this.grdWorkerBill.AllowUserToAddRows = false;
            this.grdWorkerBill.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdWorkerBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdWorkerBill.ColumnHeadersHeight = 28;
            this.grdWorkerBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProcessName,
            this.colVDate,
            this.colCustomerPo,
            this.colMaterialName,
            this.colInspectionArticleName,
            this.colInspectionBrandName,
            this.colInspectionQuantity,
            this.colInspectionRate,
            this.colInspectionAmount});
            this.grdWorkerBill.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdWorkerBill.EnableHeadersVisualStyles = false;
            this.grdWorkerBill.Location = new System.Drawing.Point(9, 221);
            this.grdWorkerBill.Name = "grdWorkerBill";
            this.grdWorkerBill.ReadOnly = true;
            this.grdWorkerBill.RowHeadersVisible = false;
            this.grdWorkerBill.Size = new System.Drawing.Size(1127, 422);
            this.grdWorkerBill.TabIndex = 4;
            // 
            // colProcessName
            // 
            this.colProcessName.DataPropertyName = "ProductionProcessName";
            this.colProcessName.HeaderText = "Process Name";
            this.colProcessName.Name = "colProcessName";
            this.colProcessName.ReadOnly = true;
            this.colProcessName.Width = 130;
            // 
            // colVDate
            // 
            this.colVDate.DataPropertyName = "WorkDate";
            dataGridViewCellStyle2.Format = "d";
            this.colVDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colVDate.HeaderText = "WorkDate";
            this.colVDate.Name = "colVDate";
            this.colVDate.ReadOnly = true;
            // 
            // colCustomerPo
            // 
            this.colCustomerPo.DataPropertyName = "CustomerPO";
            this.colCustomerPo.HeaderText = "Customer Po #";
            this.colCustomerPo.Name = "colCustomerPo";
            this.colCustomerPo.ReadOnly = true;
            this.colCustomerPo.Width = 130;
            // 
            // colMaterialName
            // 
            this.colMaterialName.DataPropertyName = "ItemName";
            this.colMaterialName.HeaderText = "Material Name";
            this.colMaterialName.Name = "colMaterialName";
            this.colMaterialName.ReadOnly = true;
            this.colMaterialName.Width = 180;
            // 
            // colInspectionArticleName
            // 
            this.colInspectionArticleName.DataPropertyName = "ArticleName";
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
            this.colInspectionBrandName.Width = 130;
            // 
            // colInspectionQuantity
            // 
            this.colInspectionQuantity.DataPropertyName = "Qty";
            this.colInspectionQuantity.HeaderText = "Quantity";
            this.colInspectionQuantity.Name = "colInspectionQuantity";
            this.colInspectionQuantity.ReadOnly = true;
            this.colInspectionQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInspectionQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInspectionQuantity.Width = 70;
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
            // lblTotalAmount
            // 
            this.lblTotalAmount.AccessibleDescription = "lbl";
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTotalAmount.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTotalAmount.Location = new System.Drawing.Point(847, 651);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(118, 25);
            this.lblTotalAmount.TabIndex = 36;
            this.lblTotalAmount.Text = "metroLabel2";
            this.lblTotalAmount.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(706, 192);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(201, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Excel Export";
            this.btnExport.UseSelectable = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(536, 192);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(164, 23);
            this.btnCalculate.TabIndex = 37;
            this.btnCalculate.Text = "Calculate Filter Total";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // frmGlovesWorkerWeeklyFinancialPerformanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 700);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.pnlDate);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.chkApplyDateFilter);
            this.Controls.Add(this.grdWorkerBill);
            this.Controls.Add(this.chkInspectionSearchByArticle);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.AccEditBox);
            this.Controls.Add(this.txtInspectionSearch);
            this.Controls.Add(this.chkInspectionSearchByBrand);
            this.Controls.Add(this.lblAccountName);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frmGlovesWorkerWeeklyFinancialPerformanceReport";
            this.Text = "Workers Weekly Financial Report";
            this.Load += new System.EventHandler(this.frmGlovesWorkerWeeklyFinancialPerformanceReport_Load);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabDataGrid grdWorkerBill;
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
        private MetroFramework.Controls.MetroLabel lblTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerPo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionArticleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionBrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionAmount;
        private MetroFramework.Controls.MetroButton btnExport;
        private System.Windows.Forms.Button btnCalculate;
    }
}