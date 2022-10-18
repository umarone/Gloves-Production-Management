namespace Accounts.UI
{
    partial class frmWorkerFinancialAndWorkComparisonReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.grdWorkerReport = new Accounts.UI.CustomDataGrid();
            this.colWorkingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGalma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPuttha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDPuttha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSPuttha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDGalma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdWorkerFinance = new Accounts.UI.CustomDataGrid();
            this.colFinanceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.endDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.startDate = new MetroFramework.Controls.MetroDateTime();
            this.EmpEditBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.lblAccountNo = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.btnGetComparison = new MetroFramework.Controls.MetroButton();
            this.lblFinancialExpense = new MetroFramework.Controls.MetroLabel();
            this.lblWorkerExpenses = new MetroFramework.Controls.MetroLabel();
            this.lblWorkerTotalAmount = new MetroFramework.Controls.MetroLabel();
            this.lblWorkerAmount = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerFinance)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(23, 54);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(1073, 23);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "-----------";
            // 
            // grdWorkerReport
            // 
            this.grdWorkerReport.AllowUserToAddRows = false;
            this.grdWorkerReport.AllowUserToDeleteRows = false;
            this.grdWorkerReport.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdWorkerReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdWorkerReport.ColumnHeadersHeight = 30;
            this.grdWorkerReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWorkingDate,
            this.colGalma,
            this.colPuttha,
            this.colDPuttha,
            this.colSPuttha,
            this.colDGalma,
            this.colCuttingQuantity,
            this.colAmount});
            this.grdWorkerReport.EnableHeadersVisualStyles = false;
            this.grdWorkerReport.Location = new System.Drawing.Point(498, 150);
            this.grdWorkerReport.Name = "grdWorkerReport";
            this.grdWorkerReport.ReadOnly = true;
            this.grdWorkerReport.RowHeadersVisible = false;
            this.grdWorkerReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdWorkerReport.Size = new System.Drawing.Size(703, 295);
            this.grdWorkerReport.TabIndex = 25;
            // 
            // colWorkingDate
            // 
            this.colWorkingDate.DataPropertyName = "WorkingDate";
            dataGridViewCellStyle6.Format = "d";
            this.colWorkingDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.colWorkingDate.HeaderText = "Date";
            this.colWorkingDate.Name = "colWorkingDate";
            this.colWorkingDate.ReadOnly = true;
            this.colWorkingDate.Width = 90;
            // 
            // colGalma
            // 
            this.colGalma.DataPropertyName = "Galma";
            this.colGalma.HeaderText = "Galma";
            this.colGalma.Name = "colGalma";
            this.colGalma.ReadOnly = true;
            this.colGalma.Width = 80;
            // 
            // colPuttha
            // 
            this.colPuttha.DataPropertyName = "Puttha";
            this.colPuttha.HeaderText = "Puttha";
            this.colPuttha.Name = "colPuttha";
            this.colPuttha.ReadOnly = true;
            this.colPuttha.Width = 80;
            // 
            // colDPuttha
            // 
            this.colDPuttha.DataPropertyName = "SGalma";
            this.colDPuttha.HeaderText = "S.Galma";
            this.colDPuttha.Name = "colDPuttha";
            this.colDPuttha.ReadOnly = true;
            this.colDPuttha.Width = 80;
            // 
            // colSPuttha
            // 
            this.colSPuttha.DataPropertyName = "SPuttha";
            this.colSPuttha.HeaderText = "S. Puttha";
            this.colSPuttha.Name = "colSPuttha";
            this.colSPuttha.ReadOnly = true;
            // 
            // colDGalma
            // 
            this.colDGalma.DataPropertyName = "DGalma";
            this.colDGalma.HeaderText = "D.Galma";
            this.colDGalma.Name = "colDGalma";
            this.colDGalma.ReadOnly = true;
            this.colDGalma.Width = 80;
            // 
            // colCuttingQuantity
            // 
            this.colCuttingQuantity.DataPropertyName = "Cutting";
            this.colCuttingQuantity.HeaderText = "Quantity";
            this.colCuttingQuantity.Name = "colCuttingQuantity";
            this.colCuttingQuantity.ReadOnly = true;
            this.colCuttingQuantity.Width = 80;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // grdWorkerFinance
            // 
            this.grdWorkerFinance.AllowUserToAddRows = false;
            this.grdWorkerFinance.AllowUserToDeleteRows = false;
            this.grdWorkerFinance.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdWorkerFinance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdWorkerFinance.ColumnHeadersHeight = 30;
            this.grdWorkerFinance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFinanceDate,
            this.colDescription,
            this.colFinanceAmount});
            this.grdWorkerFinance.EnableHeadersVisualStyles = false;
            this.grdWorkerFinance.Location = new System.Drawing.Point(29, 150);
            this.grdWorkerFinance.Name = "grdWorkerFinance";
            this.grdWorkerFinance.ReadOnly = true;
            this.grdWorkerFinance.RowHeadersVisible = false;
            this.grdWorkerFinance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdWorkerFinance.Size = new System.Drawing.Size(459, 295);
            this.grdWorkerFinance.TabIndex = 25;
            // 
            // colFinanceDate
            // 
            this.colFinanceDate.DataPropertyName = "Date";
            dataGridViewCellStyle8.Format = "d";
            this.colFinanceDate.DefaultCellStyle = dataGridViewCellStyle8;
            this.colFinanceDate.HeaderText = "Date";
            this.colFinanceDate.Name = "colFinanceDate";
            this.colFinanceDate.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "SettlementType";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 250;
            // 
            // colFinanceAmount
            // 
            this.colFinanceAmount.DataPropertyName = "Debit";
            this.colFinanceAmount.HeaderText = "Amount";
            this.colFinanceAmount.Name = "colFinanceAmount";
            this.colFinanceAmount.ReadOnly = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Location = new System.Drawing.Point(23, 107);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(1073, 23);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "-----------";
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(730, 77);
            this.endDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(202, 29);
            this.endDate.TabIndex = 31;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(660, 81);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(64, 19);
            this.metroLabel3.TabIndex = 30;
            this.metroLabel3.Text = "To Date :";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(440, 77);
            this.startDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(198, 29);
            this.startDate.TabIndex = 29;
            // 
            // EmpEditBox
            // 
            // 
            // 
            // 
            this.EmpEditBox.CustomButton.Image = null;
            this.EmpEditBox.CustomButton.Location = new System.Drawing.Point(255, 1);
            this.EmpEditBox.CustomButton.Name = "";
            this.EmpEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.EmpEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.EmpEditBox.CustomButton.TabIndex = 1;
            this.EmpEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.EmpEditBox.CustomButton.UseSelectable = true;
            this.EmpEditBox.Lines = new string[0];
            this.EmpEditBox.Location = new System.Drawing.Point(76, 78);
            this.EmpEditBox.MaxLength = 32767;
            this.EmpEditBox.Name = "EmpEditBox";
            this.EmpEditBox.PasswordChar = '\0';
            this.EmpEditBox.PromptText = "Account No Here";
            this.EmpEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.EmpEditBox.SelectedText = "";
            this.EmpEditBox.SelectionLength = 0;
            this.EmpEditBox.SelectionStart = 0;
            this.EmpEditBox.ShortcutsEnabled = true;
            this.EmpEditBox.ShowButton = true;
            this.EmpEditBox.Size = new System.Drawing.Size(277, 23);
            this.EmpEditBox.Style = MetroFramework.MetroColorStyle.Red;
            this.EmpEditBox.TabIndex = 26;
            this.EmpEditBox.UseSelectable = true;
            this.EmpEditBox.WaterMark = "Account No Here";
            this.EmpEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.EmpEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.EmpEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.EmpEditBox_ButtonClick);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(359, 81);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(78, 19);
            this.metroLabel4.TabIndex = 28;
            this.metroLabel4.Text = "Start Date :";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAccountNo.Location = new System.Drawing.Point(29, 79);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(39, 19);
            this.lblAccountNo.TabIndex = 27;
            this.lblAccountNo.Text = "A/C :";
            this.lblAccountNo.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(27, 127);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(117, 19);
            this.metroLabel5.TabIndex = 27;
            this.metroLabel5.Text = "Financial Report";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(497, 127);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(96, 19);
            this.metroLabel6.TabIndex = 27;
            this.metroLabel6.Text = "Work Report";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // btnGetComparison
            // 
            this.btnGetComparison.Location = new System.Drawing.Point(949, 77);
            this.btnGetComparison.Name = "btnGetComparison";
            this.btnGetComparison.Size = new System.Drawing.Size(114, 28);
            this.btnGetComparison.TabIndex = 32;
            this.btnGetComparison.Text = "Get Comparison";
            this.btnGetComparison.UseSelectable = true;
            this.btnGetComparison.Click += new System.EventHandler(this.btnGetComparison_Click);
            // 
            // lblFinancialExpense
            // 
            this.lblFinancialExpense.AutoSize = true;
            this.lblFinancialExpense.BackColor = System.Drawing.Color.Transparent;
            this.lblFinancialExpense.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblFinancialExpense.Location = new System.Drawing.Point(29, 465);
            this.lblFinancialExpense.Name = "lblFinancialExpense";
            this.lblFinancialExpense.Size = new System.Drawing.Size(108, 19);
            this.lblFinancialExpense.TabIndex = 27;
            this.lblFinancialExpense.Text = "Total Amount :";
            this.lblFinancialExpense.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // lblWorkerExpenses
            // 
            this.lblWorkerExpenses.AutoSize = true;
            this.lblWorkerExpenses.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkerExpenses.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblWorkerExpenses.Location = new System.Drawing.Point(143, 465);
            this.lblWorkerExpenses.Name = "lblWorkerExpenses";
            this.lblWorkerExpenses.Size = new System.Drawing.Size(0, 0);
            this.lblWorkerExpenses.TabIndex = 27;
            this.lblWorkerExpenses.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // lblWorkerTotalAmount
            // 
            this.lblWorkerTotalAmount.AutoSize = true;
            this.lblWorkerTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkerTotalAmount.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblWorkerTotalAmount.Location = new System.Drawing.Point(498, 465);
            this.lblWorkerTotalAmount.Name = "lblWorkerTotalAmount";
            this.lblWorkerTotalAmount.Size = new System.Drawing.Size(108, 19);
            this.lblWorkerTotalAmount.TabIndex = 27;
            this.lblWorkerTotalAmount.Text = "Total Amount :";
            this.lblWorkerTotalAmount.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // lblWorkerAmount
            // 
            this.lblWorkerAmount.AutoSize = true;
            this.lblWorkerAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkerAmount.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblWorkerAmount.Location = new System.Drawing.Point(612, 465);
            this.lblWorkerAmount.Name = "lblWorkerAmount";
            this.lblWorkerAmount.Size = new System.Drawing.Size(0, 0);
            this.lblWorkerAmount.TabIndex = 27;
            this.lblWorkerAmount.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // frmWorkerFinancialAndWorkComparisonReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 504);
            this.Controls.Add(this.btnGetComparison);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.EmpEditBox);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.lblWorkerAmount);
            this.Controls.Add(this.lblWorkerExpenses);
            this.Controls.Add(this.lblWorkerTotalAmount);
            this.Controls.Add(this.lblFinancialExpense);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.grdWorkerFinance);
            this.Controls.Add(this.grdWorkerReport);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frmWorkerFinancialAndWorkComparisonReport";
            this.Text = "Worker Comparison Report";
            this.Load += new System.EventHandler(this.frmWorkerFinancialAndWorkComparisonReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerFinance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private CustomDataGrid grdWorkerReport;
        private CustomDataGrid grdWorkerFinance;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime endDate;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime startDate;
        private MetroFramework.Controls.MetroTextBox EmpEditBox;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel lblAccountNo;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroButton btnGetComparison;
        private MetroFramework.Controls.MetroLabel lblFinancialExpense;
        private MetroFramework.Controls.MetroLabel lblWorkerExpenses;
        private MetroFramework.Controls.MetroLabel lblWorkerTotalAmount;
        private MetroFramework.Controls.MetroLabel lblWorkerAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGalma;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPuttha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDPuttha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSPuttha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDGalma;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinanceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinanceAmount;
    }
}