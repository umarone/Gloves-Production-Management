namespace Accounts.UI
{
    partial class frmTanneryLotsByChemical
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
            this.lblDashes = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.PEditBox = new MetroFramework.Controls.MetroTextBox();
            this.btnChemicalLotsReport = new System.Windows.Forms.Button();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.grdChemicalLots = new Accounts.UI.TabDataGrid();
            this.colLotDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalCrustIssueQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalCrustIssuedValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalDyingIssueQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalDyingIssuedValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalRedyingIssueQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalRedyingIssuedValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalQtyStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalCurrentValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdChemicalLots)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDashes
            // 
            this.lblDashes.AutoSize = true;
            this.lblDashes.Location = new System.Drawing.Point(25, 51);
            this.lblDashes.Name = "lblDashes";
            this.lblDashes.Size = new System.Drawing.Size(1029, 19);
            this.lblDashes.TabIndex = 0;
            this.lblDashes.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "---------";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(25, 73);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(110, 19);
            this.metroLabel10.TabIndex = 14;
            this.metroLabel10.Text = "Chemical Name :";
            // 
            // PEditBox
            // 
            // 
            // 
            // 
            this.PEditBox.CustomButton.Image = null;
            this.PEditBox.CustomButton.Location = new System.Drawing.Point(233, 1);
            this.PEditBox.CustomButton.Name = "";
            this.PEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.PEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PEditBox.CustomButton.TabIndex = 1;
            this.PEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PEditBox.CustomButton.UseSelectable = true;
            this.PEditBox.Lines = new string[0];
            this.PEditBox.Location = new System.Drawing.Point(141, 73);
            this.PEditBox.MaxLength = 32767;
            this.PEditBox.Name = "PEditBox";
            this.PEditBox.PasswordChar = '\0';
            this.PEditBox.PromptText = "Product Here";
            this.PEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PEditBox.SelectedText = "";
            this.PEditBox.SelectionLength = 0;
            this.PEditBox.SelectionStart = 0;
            this.PEditBox.ShortcutsEnabled = true;
            this.PEditBox.ShowButton = true;
            this.PEditBox.Size = new System.Drawing.Size(255, 23);
            this.PEditBox.TabIndex = 13;
            this.PEditBox.UseSelectable = true;
            this.PEditBox.WaterMark = "Product Here";
            this.PEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.PEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.PEditBox_ButtonClick);
            this.PEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PEditBox_KeyPress);
            // 
            // btnChemicalLotsReport
            // 
            this.btnChemicalLotsReport.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnChemicalLotsReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChemicalLotsReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChemicalLotsReport.ForeColor = System.Drawing.Color.Black;
            this.btnChemicalLotsReport.Location = new System.Drawing.Point(402, 73);
            this.btnChemicalLotsReport.Name = "btnChemicalLotsReport";
            this.btnChemicalLotsReport.Size = new System.Drawing.Size(101, 25);
            this.btnChemicalLotsReport.TabIndex = 15;
            this.btnChemicalLotsReport.Text = "Load Report";
            this.btnChemicalLotsReport.UseVisualStyleBackColor = false;
            this.btnChemicalLotsReport.Click += new System.EventHandler(this.btnChemicalLotsReport_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 99);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(1029, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "---------";
            // 
            // grdChemicalLots
            // 
            this.grdChemicalLots.AllowUserToAddRows = false;
            this.grdChemicalLots.AllowUserToDeleteRows = false;
            this.grdChemicalLots.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdChemicalLots.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdChemicalLots.ColumnHeadersHeight = 27;
            this.grdChemicalLots.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLotDate,
            this.colLotNo,
            this.colLotWeight,
            this.colLotType,
            this.colChemicalCrustIssueQuantity,
            this.colChemicalCrustIssuedValue,
            this.colChemicalDyingIssueQuantity,
            this.colChemicalDyingIssuedValue,
            this.colChemicalRedyingIssueQuantity,
            this.colChemicalRedyingIssuedValue,
            this.colChemicalQtyStock,
            this.colChemicalCurrentValue});
            this.grdChemicalLots.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdChemicalLots.EnableHeadersVisualStyles = false;
            this.grdChemicalLots.Location = new System.Drawing.Point(25, 121);
            this.grdChemicalLots.Name = "grdChemicalLots";
            this.grdChemicalLots.RowHeadersVisible = false;
            this.grdChemicalLots.Size = new System.Drawing.Size(1024, 322);
            this.grdChemicalLots.TabIndex = 16;
            // 
            // colLotDate
            // 
            this.colLotDate.DataPropertyName = "LotDate";
            dataGridViewCellStyle2.Format = "d";
            this.colLotDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLotDate.HeaderText = "Date";
            this.colLotDate.Name = "colLotDate";
            this.colLotDate.Width = 80;
            // 
            // colLotNo
            // 
            this.colLotNo.DataPropertyName = "LotNo";
            this.colLotNo.HeaderText = "Lot No";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.Width = 80;
            // 
            // colLotWeight
            // 
            this.colLotWeight.DataPropertyName = "LotWeight";
            this.colLotWeight.HeaderText = "Weight";
            this.colLotWeight.Name = "colLotWeight";
            this.colLotWeight.Width = 80;
            // 
            // colLotType
            // 
            this.colLotType.DataPropertyName = "LotTypeDiscription";
            this.colLotType.HeaderText = "Type";
            this.colLotType.Name = "colLotType";
            this.colLotType.Width = 80;
            // 
            // colChemicalCrustIssueQuantity
            // 
            this.colChemicalCrustIssueQuantity.DataPropertyName = "CrustIssuedQuantity";
            this.colChemicalCrustIssueQuantity.HeaderText = "Crust";
            this.colChemicalCrustIssueQuantity.Name = "colChemicalCrustIssueQuantity";
            this.colChemicalCrustIssueQuantity.Width = 85;
            // 
            // colChemicalCrustIssuedValue
            // 
            this.colChemicalCrustIssuedValue.DataPropertyName = "CrustIssuedValue";
            this.colChemicalCrustIssuedValue.HeaderText = "Issued Value";
            this.colChemicalCrustIssuedValue.Name = "colChemicalCrustIssuedValue";
            this.colChemicalCrustIssuedValue.ReadOnly = true;
            this.colChemicalCrustIssuedValue.Width = 85;
            // 
            // colChemicalDyingIssueQuantity
            // 
            this.colChemicalDyingIssueQuantity.DataPropertyName = "DyingIssuedQuantity";
            this.colChemicalDyingIssueQuantity.HeaderText = "Dying";
            this.colChemicalDyingIssueQuantity.Name = "colChemicalDyingIssueQuantity";
            this.colChemicalDyingIssueQuantity.Width = 85;
            // 
            // colChemicalDyingIssuedValue
            // 
            this.colChemicalDyingIssuedValue.DataPropertyName = "DyingIssuedValue";
            this.colChemicalDyingIssuedValue.HeaderText = "Issued Value";
            this.colChemicalDyingIssuedValue.Name = "colChemicalDyingIssuedValue";
            this.colChemicalDyingIssuedValue.ReadOnly = true;
            this.colChemicalDyingIssuedValue.Width = 85;
            // 
            // colChemicalRedyingIssueQuantity
            // 
            this.colChemicalRedyingIssueQuantity.DataPropertyName = "ReDyingIssuedQuantity";
            this.colChemicalRedyingIssueQuantity.HeaderText = "ReDying";
            this.colChemicalRedyingIssueQuantity.Name = "colChemicalRedyingIssueQuantity";
            this.colChemicalRedyingIssueQuantity.Width = 85;
            // 
            // colChemicalRedyingIssuedValue
            // 
            this.colChemicalRedyingIssuedValue.DataPropertyName = "ReDyingIssuedValue";
            this.colChemicalRedyingIssuedValue.HeaderText = "Issued Value";
            this.colChemicalRedyingIssuedValue.Name = "colChemicalRedyingIssuedValue";
            this.colChemicalRedyingIssuedValue.ReadOnly = true;
            this.colChemicalRedyingIssuedValue.Width = 85;
            // 
            // colChemicalQtyStock
            // 
            this.colChemicalQtyStock.DataPropertyName = "CurrentQuantity";
            this.colChemicalQtyStock.HeaderText = "Total Qty";
            this.colChemicalQtyStock.Name = "colChemicalQtyStock";
            this.colChemicalQtyStock.ReadOnly = true;
            this.colChemicalQtyStock.Width = 85;
            // 
            // colChemicalCurrentValue
            // 
            this.colChemicalCurrentValue.DataPropertyName = "CurrentValue";
            dataGridViewCellStyle3.NullValue = "2.2";
            this.colChemicalCurrentValue.DefaultCellStyle = dataGridViewCellStyle3;
            this.colChemicalCurrentValue.HeaderText = "Total Value";
            this.colChemicalCurrentValue.Name = "colChemicalCurrentValue";
            this.colChemicalCurrentValue.ReadOnly = true;
            this.colChemicalCurrentValue.Width = 85;
            // 
            // frmTanneryLotsByChemical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 466);
            this.Controls.Add(this.grdChemicalLots);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.PEditBox);
            this.Controls.Add(this.btnChemicalLotsReport);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.lblDashes);
            this.MaximizeBox = false;
            this.Name = "frmTanneryLotsByChemical";
            this.Text = "Chemical Lots";
            this.Load += new System.EventHandler(this.frmTanneyLotsByChemical_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdChemicalLots)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblDashes;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox PEditBox;
        private System.Windows.Forms.Button btnChemicalLotsReport;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private TabDataGrid grdChemicalLots;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalCrustIssueQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalCrustIssuedValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalDyingIssueQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalDyingIssuedValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalRedyingIssueQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalRedyingIssuedValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalQtyStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalCurrentValue;
    }
}