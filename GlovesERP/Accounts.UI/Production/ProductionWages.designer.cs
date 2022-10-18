namespace Accounts.UI
{
    partial class frmProductionWages
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
            this.cbxProductionType = new MetroFramework.Controls.MetroComboBox();
            this.cbxProcessType = new MetroFramework.Controls.MetroComboBox();
            this.lblVoucherNo = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cachedrptStockAccountsBalances1 = new Accounts.UI.Reports.CachedrptStockAccountsBalances();
            this.btnWagesSave = new MetroFramework.Controls.MetroTile();
            this.grdProductionWages = new Accounts.UI.TabDataGrid();
            this.colIdWorkType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductionWages)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxProductionType
            // 
            this.cbxProductionType.FormattingEnabled = true;
            this.cbxProductionType.ItemHeight = 23;
            this.cbxProductionType.Items.AddRange(new object[] {
            "Select Production",
            "Tannery"});
            this.cbxProductionType.Location = new System.Drawing.Point(234, 76);
            this.cbxProductionType.Name = "cbxProductionType";
            this.cbxProductionType.Size = new System.Drawing.Size(152, 29);
            this.cbxProductionType.TabIndex = 1;
            this.cbxProductionType.UseSelectable = true;
            this.cbxProductionType.SelectedIndexChanged += new System.EventHandler(this.cbxProductionType_SelectedIndexChanged);
            // 
            // cbxProcessType
            // 
            this.cbxProcessType.FormattingEnabled = true;
            this.cbxProcessType.ItemHeight = 23;
            this.cbxProcessType.Location = new System.Drawing.Point(503, 76);
            this.cbxProcessType.Name = "cbxProcessType";
            this.cbxProcessType.Size = new System.Drawing.Size(151, 29);
            this.cbxProcessType.TabIndex = 2;
            this.cbxProcessType.UseSelectable = true;
            this.cbxProcessType.SelectedIndexChanged += new System.EventHandler(this.cbxProcessType_SelectedIndexChanged);
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblVoucherNo.Location = new System.Drawing.Point(401, 80);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(95, 19);
            this.lblVoucherNo.TabIndex = 20;
            this.lblVoucherNo.Text = "Process Type :";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(113, 80);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(116, 19);
            this.metroLabel1.TabIndex = 21;
            this.metroLabel1.Text = "Production Type :";
            // 
            // btnWagesSave
            // 
            this.btnWagesSave.ActiveControl = null;
            this.btnWagesSave.Location = new System.Drawing.Point(534, 407);
            this.btnWagesSave.Name = "btnWagesSave";
            this.btnWagesSave.Size = new System.Drawing.Size(120, 46);
            this.btnWagesSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnWagesSave.TabIndex = 23;
            this.btnWagesSave.Text = "Save";
            this.btnWagesSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnWagesSave.UseSelectable = true;
            this.btnWagesSave.Click += new System.EventHandler(this.btnWagesSave_Click);
            // 
            // grdProductionWages
            // 
            this.grdProductionWages.AllowUserToAddRows = false;
            this.grdProductionWages.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.grdProductionWages.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdProductionWages.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdProductionWages.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdProductionWages.ColumnHeadersHeight = 25;
            this.grdProductionWages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdWorkType,
            this.colWorkType,
            this.colWorkRate,
            this.colCuttingRate});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdProductionWages.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdProductionWages.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdProductionWages.EnableHeadersVisualStyles = false;
            this.grdProductionWages.Location = new System.Drawing.Point(113, 113);
            this.grdProductionWages.MultiSelect = false;
            this.grdProductionWages.Name = "grdProductionWages";
            this.grdProductionWages.RowHeadersVisible = false;
            this.grdProductionWages.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdProductionWages.Size = new System.Drawing.Size(541, 290);
            this.grdProductionWages.TabIndex = 22;
            // 
            // colIdWorkType
            // 
            this.colIdWorkType.DataPropertyName = "SerialNo";
            this.colIdWorkType.HeaderText = "Serial No";
            this.colIdWorkType.Name = "colIdWorkType";
            this.colIdWorkType.Visible = false;
            this.colIdWorkType.Width = 150;
            // 
            // colWorkType
            // 
            this.colWorkType.DataPropertyName = "WorkType";
            this.colWorkType.HeaderText = "Work Type";
            this.colWorkType.Name = "colWorkType";
            this.colWorkType.ReadOnly = true;
            this.colWorkType.Width = 200;
            // 
            // colWorkRate
            // 
            this.colWorkRate.DataPropertyName = "WorkRate";
            this.colWorkRate.HeaderText = "Wadges";
            this.colWorkRate.Name = "colWorkRate";
            this.colWorkRate.Width = 170;
            // 
            // colCuttingRate
            // 
            this.colCuttingRate.HeaderText = "Cutting Rates";
            this.colCuttingRate.Name = "colCuttingRate";
            this.colCuttingRate.Width = 150;
            // 
            // frmProductionWages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 495);
            this.Controls.Add(this.btnWagesSave);
            this.Controls.Add(this.grdProductionWages);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.lblVoucherNo);
            this.Controls.Add(this.cbxProcessType);
            this.Controls.Add(this.cbxProductionType);
            this.Name = "frmProductionWages";
            this.Text = "Production Wages";
            this.Load += new System.EventHandler(this.ProductionWages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdProductionWages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cbxProductionType;
        private MetroFramework.Controls.MetroComboBox cbxProcessType;
        private MetroFramework.Controls.MetroLabel lblVoucherNo;
        private TabDataGrid grdProductionWages;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private Reports.CachedrptStockAccountsBalances cachedrptStockAccountsBalances1;
        private MetroFramework.Controls.MetroTile btnWagesSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdWorkType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingRate;
    }
}