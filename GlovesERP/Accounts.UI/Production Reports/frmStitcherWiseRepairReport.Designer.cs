namespace Accounts.UI
{
    partial class frmStitcherWiseRepairReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdRepairDetail = new System.Windows.Forms.DataGridView();
            this.grdRepairSummary = new System.Windows.Forms.DataGridView();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSummaryReadyForInspection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSummaryInspectedUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSummaryRemaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblAccountNo = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnGetReport = new MetroFramework.Controls.MetroButton();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReadyUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackedUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdRepairDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRepairSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // grdRepairDetail
            // 
            this.grdRepairDetail.AllowUserToAddRows = false;
            this.grdRepairDetail.AllowUserToDeleteRows = false;
            this.grdRepairDetail.AllowUserToResizeColumns = false;
            this.grdRepairDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.grdRepairDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdRepairDetail.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRepairDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdRepairDetail.ColumnHeadersHeight = 26;
            this.grdRepairDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colDetailItemName,
            this.colReadyUnits,
            this.colPackedUnits,
            this.colBalance});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRepairDetail.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdRepairDetail.EnableHeadersVisualStyles = false;
            this.grdRepairDetail.Location = new System.Drawing.Point(23, 118);
            this.grdRepairDetail.MultiSelect = false;
            this.grdRepairDetail.Name = "grdRepairDetail";
            this.grdRepairDetail.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRepairDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdRepairDetail.RowHeadersVisible = false;
            this.grdRepairDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdRepairDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdRepairDetail.Size = new System.Drawing.Size(610, 437);
            this.grdRepairDetail.TabIndex = 14;
            // 
            // grdRepairSummary
            // 
            this.grdRepairSummary.AllowUserToAddRows = false;
            this.grdRepairSummary.AllowUserToDeleteRows = false;
            this.grdRepairSummary.AllowUserToResizeColumns = false;
            this.grdRepairSummary.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Beige;
            this.grdRepairSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.grdRepairSummary.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRepairSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grdRepairSummary.ColumnHeadersHeight = 26;
            this.grdRepairSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductName,
            this.colSummaryReadyForInspection,
            this.colSummaryInspectedUnits,
            this.colSummaryRemaining});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRepairSummary.DefaultCellStyle = dataGridViewCellStyle14;
            this.grdRepairSummary.EnableHeadersVisualStyles = false;
            this.grdRepairSummary.Location = new System.Drawing.Point(642, 118);
            this.grdRepairSummary.MultiSelect = false;
            this.grdRepairSummary.Name = "grdRepairSummary";
            this.grdRepairSummary.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRepairSummary.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.grdRepairSummary.RowHeadersVisible = false;
            this.grdRepairSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdRepairSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdRepairSummary.Size = new System.Drawing.Size(520, 437);
            this.grdRepairSummary.TabIndex = 15;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ItemName";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colProductName.DefaultCellStyle = dataGridViewCellStyle10;
            this.colProductName.HeaderText = "Product Name";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 200;
            // 
            // colSummaryReadyForInspection
            // 
            this.colSummaryReadyForInspection.DataPropertyName = "Units";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSummaryReadyForInspection.DefaultCellStyle = dataGridViewCellStyle11;
            this.colSummaryReadyForInspection.HeaderText = "Repair Stock";
            this.colSummaryReadyForInspection.Name = "colSummaryReadyForInspection";
            this.colSummaryReadyForInspection.ReadOnly = true;
            // 
            // colSummaryInspectedUnits
            // 
            this.colSummaryInspectedUnits.DataPropertyName = "Qty";
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSummaryInspectedUnits.DefaultCellStyle = dataGridViewCellStyle12;
            this.colSummaryInspectedUnits.HeaderText = "Repair Issuance";
            this.colSummaryInspectedUnits.Name = "colSummaryInspectedUnits";
            this.colSummaryInspectedUnits.ReadOnly = true;
            // 
            // colSummaryRemaining
            // 
            this.colSummaryRemaining.DataPropertyName = "RemainingUnits";
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSummaryRemaining.DefaultCellStyle = dataGridViewCellStyle13;
            this.colSummaryRemaining.HeaderText = "Remaining";
            this.colSummaryRemaining.Name = "colSummaryRemaining";
            this.colSummaryRemaining.ReadOnly = true;
            this.colSummaryRemaining.Width = 110;
            // 
            // CustEditBox
            // 
            // 
            // 
            // 
            this.CustEditBox.CustomButton.Image = null;
            this.CustEditBox.CustomButton.Location = new System.Drawing.Point(412, 1);
            this.CustEditBox.CustomButton.Name = "";
            this.CustEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CustEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CustEditBox.CustomButton.TabIndex = 1;
            this.CustEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CustEditBox.CustomButton.UseSelectable = true;
            this.CustEditBox.Lines = new string[0];
            this.CustEditBox.Location = new System.Drawing.Point(72, 79);
            this.CustEditBox.MaxLength = 32767;
            this.CustEditBox.Name = "CustEditBox";
            this.CustEditBox.PasswordChar = '\0';
            this.CustEditBox.PromptText = "Account Name Here";
            this.CustEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CustEditBox.SelectedText = "";
            this.CustEditBox.SelectionLength = 0;
            this.CustEditBox.SelectionStart = 0;
            this.CustEditBox.ShortcutsEnabled = true;
            this.CustEditBox.ShowButton = true;
            this.CustEditBox.Size = new System.Drawing.Size(434, 23);
            this.CustEditBox.Style = MetroFramework.MetroColorStyle.Red;
            this.CustEditBox.TabIndex = 18;
            this.CustEditBox.UseSelectable = true;
            this.CustEditBox.WaterMark = "Account Name Here";
            this.CustEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CustEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.CustEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.CustEditBox_ButtonClick);
            this.CustEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustEditBox_KeyPress);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAccountNo.Location = new System.Drawing.Point(25, 80);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(39, 19);
            this.lblAccountNo.TabIndex = 19;
            this.lblAccountNo.Text = "A/C :";
            this.lblAccountNo.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(25, 53);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(1137, 23);
            this.metroLabel2.TabIndex = 20;
            this.metroLabel2.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "-----------------------------";
            // 
            // btnGetReport
            // 
            this.btnGetReport.Location = new System.Drawing.Point(512, 79);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(82, 23);
            this.btnGetReport.TabIndex = 23;
            this.btnGetReport.Text = "Get Report";
            this.btnGetReport.UseSelectable = true;
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "WorkDate";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDate.HeaderText = "WorkDate";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colDetailItemName
            // 
            this.colDetailItemName.DataPropertyName = "ItemName";
            this.colDetailItemName.HeaderText = "Item Name";
            this.colDetailItemName.Name = "colDetailItemName";
            this.colDetailItemName.ReadOnly = true;
            this.colDetailItemName.Width = 200;
            // 
            // colReadyUnits
            // 
            this.colReadyUnits.DataPropertyName = "Qty";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colReadyUnits.DefaultCellStyle = dataGridViewCellStyle4;
            this.colReadyUnits.HeaderText = "Repair Stock";
            this.colReadyUnits.Name = "colReadyUnits";
            this.colReadyUnits.ReadOnly = true;
            // 
            // colPackedUnits
            // 
            this.colPackedUnits.DataPropertyName = "Units";
            this.colPackedUnits.HeaderText = "Repair Issuance";
            this.colPackedUnits.Name = "colPackedUnits";
            this.colPackedUnits.ReadOnly = true;
            // 
            // colBalance
            // 
            this.colBalance.DataPropertyName = "Balance";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colBalance.DefaultCellStyle = dataGridViewCellStyle5;
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.ReadOnly = true;
            // 
            // frmStitcherWiseRepairReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 578);
            this.Controls.Add(this.btnGetReport);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.CustEditBox);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.grdRepairSummary);
            this.Controls.Add(this.grdRepairDetail);
            this.Name = "frmStitcherWiseRepairReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Maker Wise Repair Stock Report";
            this.Load += new System.EventHandler(this.frmStitcherWiseRepairReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdRepairDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRepairSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdRepairDetail;
        private System.Windows.Forms.DataGridView grdRepairSummary;
        private MetroFramework.Controls.MetroTextBox CustEditBox;
        private MetroFramework.Controls.MetroLabel lblAccountNo;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnGetReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSummaryReadyForInspection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSummaryInspectedUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSummaryRemaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReadyUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackedUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
    }
}