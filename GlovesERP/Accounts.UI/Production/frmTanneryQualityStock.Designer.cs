namespace Accounts.UI
{
    partial class frmTanneryQualityStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdTanneryStockReport = new System.Windows.Forms.DataGridView();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClosing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPerUnitAvg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.PEditBox = new MetroFramework.Controls.MetroTextBox();
            this.btnProductReport = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdTanneryStockReport)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTanneryStockReport
            // 
            this.grdTanneryStockReport.AllowUserToAddRows = false;
            this.grdTanneryStockReport.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.grdTanneryStockReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTanneryStockReport.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTanneryStockReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdTanneryStockReport.ColumnHeadersHeight = 26;
            this.grdTanneryStockReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescription,
            this.colType,
            this.colDate,
            this.colAccountName,
            this.colUnits,
            this.colLotNo,
            this.colClosing,
            this.colValue,
            this.colPerUnitAvg,
            this.colStockBalance});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTanneryStockReport.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdTanneryStockReport.EnableHeadersVisualStyles = false;
            this.grdTanneryStockReport.Location = new System.Drawing.Point(23, 113);
            this.grdTanneryStockReport.Name = "grdTanneryStockReport";
            this.grdTanneryStockReport.ReadOnly = true;
            this.grdTanneryStockReport.RowHeadersVisible = false;
            this.grdTanneryStockReport.Size = new System.Drawing.Size(1034, 364);
            this.grdTanneryStockReport.TabIndex = 9;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDescription.HeaderText = "Descriptoin";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 120;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "Type";
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 80;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "StockDate";
            dataGridViewCellStyle4.Format = "d";
            this.colDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 90;
            // 
            // colAccountName
            // 
            this.colAccountName.DataPropertyName = "AccountName";
            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 140;
            // 
            // colUnits
            // 
            this.colUnits.DataPropertyName = "Units";
            this.colUnits.HeaderText = "Qty";
            this.colUnits.Name = "colUnits";
            this.colUnits.ReadOnly = true;
            this.colUnits.Width = 90;
            // 
            // colLotNo
            // 
            this.colLotNo.DataPropertyName = "LotNo";
            this.colLotNo.HeaderText = "Lot No.";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.ReadOnly = true;
            this.colLotNo.Width = 90;
            // 
            // colClosing
            // 
            this.colClosing.DataPropertyName = "Closing";
            this.colClosing.HeaderText = "Stock In Hand";
            this.colClosing.Name = "colClosing";
            this.colClosing.ReadOnly = true;
            this.colClosing.Width = 90;
            // 
            // colValue
            // 
            this.colValue.DataPropertyName = "Value";
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.ReadOnly = true;
            // 
            // colPerUnitAvg
            // 
            this.colPerUnitAvg.HeaderText = "Avg / Unit";
            this.colPerUnitAvg.Name = "colPerUnitAvg";
            this.colPerUnitAvg.ReadOnly = true;
            // 
            // colStockBalance
            // 
            this.colStockBalance.DataPropertyName = "Amount";
            this.colStockBalance.HeaderText = "Remaining AVG";
            this.colStockBalance.Name = "colStockBalance";
            this.colStockBalance.ReadOnly = true;
            this.colStockBalance.Width = 120;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(28, 76);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(110, 19);
            this.metroLabel10.TabIndex = 11;
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
            this.PEditBox.Location = new System.Drawing.Point(144, 76);
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
            this.PEditBox.TabIndex = 10;
            this.PEditBox.UseSelectable = true;
            this.PEditBox.WaterMark = "Product Here";
            this.PEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.PEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.PEditBox_ButtonClick);
            // 
            // btnProductReport
            // 
            this.btnProductReport.BackColor = System.Drawing.Color.AliceBlue;
            this.btnProductReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductReport.ForeColor = System.Drawing.Color.Black;
            this.btnProductReport.Location = new System.Drawing.Point(405, 76);
            this.btnProductReport.Name = "btnProductReport";
            this.btnProductReport.Size = new System.Drawing.Size(101, 25);
            this.btnProductReport.TabIndex = 12;
            this.btnProductReport.Text = "Load Report";
            this.btnProductReport.UseVisualStyleBackColor = false;
            this.btnProductReport.Click += new System.EventHandler(this.btnProductReport_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Description";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "Descriptoin";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Type";
            this.dataGridViewTextBoxColumn2.HeaderText = "Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "StockDate";
            dataGridViewCellStyle7.Format = "d";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "Date";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "AccountName";
            this.dataGridViewTextBoxColumn4.HeaderText = "AccountName";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 170;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Units";
            this.dataGridViewTextBoxColumn5.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Closing";
            this.dataGridViewTextBoxColumn6.HeaderText = "Stock In Hand";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn7.HeaderText = "Value";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn8.HeaderText = "Balance";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 200;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn9.HeaderText = "Total Avg Value";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 140;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Used AVG";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // frmTanneryQualityStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 510);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.PEditBox);
            this.Controls.Add(this.btnProductReport);
            this.Controls.Add(this.grdTanneryStockReport);
            this.Name = "frmTanneryQualityStock";
            this.Text = "Chemical Stock Report";
            this.Load += new System.EventHandler(this.frmTanneryQualityStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTanneryStockReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdTanneryStockReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox PEditBox;
        private System.Windows.Forms.Button btnProductReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClosing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPerUnitAvg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockBalance;
    }
}