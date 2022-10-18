namespace Accounts.UI
{
    partial class frmTanneryWorkerReport
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
            this.chkLots = new MetroFramework.Controls.MetroCheckBox();
            this.chkOthers = new MetroFramework.Controls.MetroCheckBox();
            this.grdWorkerReport = new Accounts.UI.CustomDataGrid();
            this.colWorkingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVehicleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViewDetail = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.metroLabel2.Size = new System.Drawing.Size(901, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------------------";
            // 
            // CustEditBox
            // 
            // 
            // 
            // 
            this.CustEditBox.CustomButton.Image = null;
            this.CustEditBox.CustomButton.Location = new System.Drawing.Point(235, 1);
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
            this.CustEditBox.Size = new System.Drawing.Size(257, 23);
            this.CustEditBox.Style = MetroFramework.MetroColorStyle.Red;
            this.CustEditBox.TabIndex = 16;
            this.CustEditBox.UseSelectable = true;
            this.CustEditBox.WaterMark = "Account No Here";
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
            this.lblAccountNo.Location = new System.Drawing.Point(23, 92);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(39, 19);
            this.lblAccountNo.TabIndex = 17;
            this.lblAccountNo.Text = "A/C :";
            this.lblAccountNo.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(414, 90);
            this.startDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(198, 29);
            this.startDate.TabIndex = 18;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(333, 94);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(78, 19);
            this.metroLabel1.TabIndex = 17;
            this.metroLabel1.Text = "Start Date :";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(698, 89);
            this.endDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(202, 29);
            this.endDate.TabIndex = 20;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(634, 94);
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
            this.metroLabel4.Size = new System.Drawing.Size(901, 25);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel4.TabIndex = 21;
            this.metroLabel4.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------------------";
            // 
            // btnGetReport
            // 
            this.btnGetReport.Location = new System.Drawing.Point(687, 151);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(84, 24);
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
            this.metroLabel5.Size = new System.Drawing.Size(901, 25);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel5.TabIndex = 24;
            this.metroLabel5.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------------------";
            // 
            // chkLots
            // 
            this.chkLots.AutoSize = true;
            this.chkLots.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkLots.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkLots.Location = new System.Drawing.Point(76, 156);
            this.chkLots.Name = "chkLots";
            this.chkLots.Size = new System.Drawing.Size(102, 19);
            this.chkLots.TabIndex = 25;
            this.chkLots.Text = "Lots Report";
            this.chkLots.UseSelectable = true;
            this.chkLots.CheckedChanged += new System.EventHandler(this.chkLots_CheckedChanged);
            // 
            // chkOthers
            // 
            this.chkOthers.AutoSize = true;
            this.chkOthers.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkOthers.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkOthers.Location = new System.Drawing.Point(536, 155);
            this.chkOthers.Name = "chkOthers";
            this.chkOthers.Size = new System.Drawing.Size(69, 19);
            this.chkOthers.TabIndex = 25;
            this.chkOthers.Text = "Others";
            this.chkOthers.UseSelectable = true;
            this.chkOthers.CheckedChanged += new System.EventHandler(this.chkLots_CheckedChanged);
            // 
            // grdWorkerReport
            // 
            this.grdWorkerReport.AllowUserToAddRows = false;
            this.grdWorkerReport.AllowUserToDeleteRows = false;
            this.grdWorkerReport.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdWorkerReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdWorkerReport.ColumnHeadersHeight = 30;
            this.grdWorkerReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWorkingDate,
            this.colAccountName,
            this.colWorkType,
            this.colVehicleNo,
            this.colAmount,
            this.colViewDetail});
            this.grdWorkerReport.EnableHeadersVisualStyles = false;
            this.grdWorkerReport.Location = new System.Drawing.Point(23, 209);
            this.grdWorkerReport.Name = "grdWorkerReport";
            this.grdWorkerReport.ReadOnly = true;
            this.grdWorkerReport.RowHeadersVisible = false;
            this.grdWorkerReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdWorkerReport.Size = new System.Drawing.Size(898, 478);
            this.grdWorkerReport.TabIndex = 23;
            this.grdWorkerReport.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdWorkerReport_CellClick);
            this.grdWorkerReport.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdWorkerReport_CellFormatting);
            // 
            // colWorkingDate
            // 
            this.colWorkingDate.DataPropertyName = "WorkDate";
            dataGridViewCellStyle2.Format = "d";
            this.colWorkingDate.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.colAccountName.Width = 250;
            // 
            // colWorkType
            // 
            this.colWorkType.DataPropertyName = "ProcessName";
            this.colWorkType.HeaderText = "Work Type";
            this.colWorkType.Name = "colWorkType";
            this.colWorkType.ReadOnly = true;
            this.colWorkType.Width = 130;
            // 
            // colVehicleNo
            // 
            this.colVehicleNo.DataPropertyName = "VehicleNo";
            this.colVehicleNo.HeaderText = "Vehicle No";
            this.colVehicleNo.Name = "colVehicleNo";
            this.colVehicleNo.ReadOnly = true;
            this.colVehicleNo.Width = 130;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 130;
            // 
            // colViewDetail
            // 
            this.colViewDetail.HeaderText = "...";
            this.colViewDetail.Name = "colViewDetail";
            this.colViewDetail.ReadOnly = true;
            this.colViewDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colViewDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmTanneryWorkerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 722);
            this.Controls.Add(this.chkOthers);
            this.Controls.Add(this.chkLots);
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
            this.Name = "frmTanneryWorkerReport";
            this.Text = "Tannery Worker Report";
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
        private MetroFramework.Controls.MetroCheckBox chkLots;
        private MetroFramework.Controls.MetroCheckBox chkOthers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVehicleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colViewDetail;
    }
}