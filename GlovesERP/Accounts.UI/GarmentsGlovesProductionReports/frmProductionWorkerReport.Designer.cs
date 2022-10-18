namespace Accounts.UI
{
    partial class frmProductionWorkerReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.CustEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblAccountNo = new MetroFramework.Controls.MetroLabel();
            this.startDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.endDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.btnGetReport = new MetroFramework.Controls.MetroButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.chkGloves = new MetroFramework.Controls.MetroCheckBox();
            this.chkGarments = new MetroFramework.Controls.MetroCheckBox();
            this.grdWorkerReport = new Accounts.UI.CustomDataGrid();
            this.colWorkingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerReport)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Blue;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.ForeColor = System.Drawing.Color.Blue;
            this.metroLabel2.Location = new System.Drawing.Point(23, 55);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(817, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------";
            // 
            // CustEditBox
            // 
            // 
            // 
            // 
            this.CustEditBox.CustomButton.Image = null;
            this.CustEditBox.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.CustEditBox.CustomButton.Name = "";
            this.CustEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CustEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CustEditBox.CustomButton.TabIndex = 1;
            this.CustEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CustEditBox.CustomButton.UseSelectable = true;
            this.CustEditBox.Lines = new string[0];
            this.CustEditBox.Location = new System.Drawing.Point(70, 91);
            this.CustEditBox.MaxLength = 32767;
            this.CustEditBox.Name = "CustEditBox";
            this.CustEditBox.PasswordChar = '\0';
            this.CustEditBox.PromptText = "Account No Here";
            this.CustEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CustEditBox.SelectedText = "";
            this.CustEditBox.SelectionLength = 0;
            this.CustEditBox.SelectionStart = 0;
            this.CustEditBox.ShortcutsEnabled = true;
            this.CustEditBox.ShowButton = true;
            this.CustEditBox.Size = new System.Drawing.Size(131, 23);
            this.CustEditBox.Style = MetroFramework.MetroColorStyle.Red;
            this.CustEditBox.TabIndex = 16;
            this.CustEditBox.UseSelectable = true;
            this.CustEditBox.WaterMark = "Account No Here";
            this.CustEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CustEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.CustEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.CustEditBox_ButtonClick);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAccountNo.Location = new System.Drawing.Point(23, 92);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(39, 19);
            this.lblAccountNo.TabIndex = 17;
            this.lblAccountNo.Text = "A/C :";
            this.lblAccountNo.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(295, 90);
            this.startDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(192, 29);
            this.startDate.TabIndex = 18;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(214, 94);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(78, 19);
            this.metroLabel1.TabIndex = 17;
            this.metroLabel1.Text = "Start Date :";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(579, 89);
            this.endDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(200, 29);
            this.endDate.TabIndex = 20;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(515, 94);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(64, 19);
            this.metroLabel3.TabIndex = 19;
            this.metroLabel3.Text = "To Date :";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.Blue;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.ForeColor = System.Drawing.Color.Blue;
            this.metroLabel4.Location = new System.Drawing.Point(23, 123);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(817, 25);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel4.TabIndex = 21;
            this.metroLabel4.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------";
            // 
            // btnGetReport
            // 
            this.btnGetReport.Location = new System.Drawing.Point(687, 151);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(82, 28);
            this.btnGetReport.TabIndex = 22;
            this.btnGetReport.Text = "Get Report";
            this.btnGetReport.UseSelectable = true;
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.Color.Blue;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.ForeColor = System.Drawing.Color.Blue;
            this.metroLabel5.Location = new System.Drawing.Point(23, 177);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(817, 25);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel5.TabIndex = 24;
            this.metroLabel5.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------";
            // 
            // chkGloves
            // 
            this.chkGloves.AutoSize = true;
            this.chkGloves.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkGloves.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkGloves.Location = new System.Drawing.Point(76, 156);
            this.chkGloves.Name = "chkGloves";
            this.chkGloves.Size = new System.Drawing.Size(120, 19);
            this.chkGloves.TabIndex = 25;
            this.chkGloves.Text = "Gloves Report";
            this.chkGloves.UseSelectable = true;
            this.chkGloves.CheckedChanged += new System.EventHandler(this.chkProduction_CheckedChanged);
            // 
            // chkGarments
            // 
            this.chkGarments.AutoSize = true;
            this.chkGarments.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkGarments.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkGarments.Location = new System.Drawing.Point(526, 155);
            this.chkGarments.Name = "chkGarments";
            this.chkGarments.Size = new System.Drawing.Size(133, 19);
            this.chkGarments.TabIndex = 25;
            this.chkGarments.Text = "Garment Report";
            this.chkGarments.UseSelectable = true;
            this.chkGarments.CheckedChanged += new System.EventHandler(this.chkProduction_CheckedChanged);
            // 
            // grdWorkerReport
            // 
            this.grdWorkerReport.AllowUserToAddRows = false;
            this.grdWorkerReport.AllowUserToDeleteRows = false;
            this.grdWorkerReport.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdWorkerReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdWorkerReport.ColumnHeadersHeight = 30;
            this.grdWorkerReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWorkingDate,
            this.colAccountName,
            this.colWorkType,
            this.colAmount});
            this.grdWorkerReport.EnableHeadersVisualStyles = false;
            this.grdWorkerReport.Location = new System.Drawing.Point(23, 209);
            this.grdWorkerReport.Name = "grdWorkerReport";
            this.grdWorkerReport.ReadOnly = true;
            this.grdWorkerReport.RowHeadersVisible = false;
            this.grdWorkerReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdWorkerReport.Size = new System.Drawing.Size(810, 478);
            this.grdWorkerReport.TabIndex = 23;
            // 
            // colWorkingDate
            // 
            this.colWorkingDate.DataPropertyName = "WorkDate";
            this.colWorkingDate.HeaderText = "Working Date";
            this.colWorkingDate.Name = "colWorkingDate";
            this.colWorkingDate.ReadOnly = true;
            this.colWorkingDate.Width = 130;
            // 
            // colAccountName
            // 
            this.colAccountName.DataPropertyName = "AccountName";
            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 300;
            // 
            // colWorkType
            // 
            this.colWorkType.DataPropertyName = "ProductionProcessName";
            this.colWorkType.HeaderText = "Work Type";
            this.colWorkType.Name = "colWorkType";
            this.colWorkType.ReadOnly = true;
            this.colWorkType.Width = 130;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 130;
            // 
            // frmProductionWorkerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 722);
            this.Controls.Add(this.chkGarments);
            this.Controls.Add(this.chkGloves);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.grdWorkerReport);
            this.Controls.Add(this.btnGetReport);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.CustEditBox);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.metroLabel2);
            this.Name = "frmProductionWorkerReport";
            this.Text = "Garments Worker Report";
            this.Load += new System.EventHandler(this.frmTanneryWorkerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox CustEditBox;
        private MetroFramework.Controls.MetroLabel lblAccountNo;
        private MetroFramework.Controls.MetroDateTime startDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroDateTime endDate;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton btnGetReport;
        private CustomDataGrid grdWorkerReport;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroCheckBox chkGloves;
        private MetroFramework.Controls.MetroCheckBox chkGarments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}