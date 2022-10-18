namespace Accounts.UI
{
    partial class frmDepartmentFinancialAndWorkComparisonReport
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnGetComparison = new MetroFramework.Controls.MetroButton();
            this.endDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.startDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.lblAccountNo = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.cbxDepartments = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.lblWorkerAmount = new MetroFramework.Controls.MetroLabel();
            this.lblWorkerExpenses = new MetroFramework.Controls.MetroLabel();
            this.lblWorkerTotalAmount = new MetroFramework.Controls.MetroLabel();
            this.lblFinancialExpense = new MetroFramework.Controls.MetroLabel();
            this.grdWorkerFinance = new Accounts.UI.CustomDataGrid();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdWorkerReport = new Accounts.UI.CustomDataGrid();
            this.colWorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGalma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPuttha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSGalma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSPuttha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDGalma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerFinance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerReport)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(20, 51);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(1167, 17);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "----------------------------";
            // 
            // btnGetComparison
            // 
            this.btnGetComparison.Location = new System.Drawing.Point(1000, 72);
            this.btnGetComparison.Name = "btnGetComparison";
            this.btnGetComparison.Size = new System.Drawing.Size(162, 28);
            this.btnGetComparison.TabIndex = 40;
            this.btnGetComparison.Text = "Get Comparison";
            this.btnGetComparison.UseSelectable = true;
            this.btnGetComparison.Click += new System.EventHandler(this.btnGetComparison_Click);
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(741, 72);
            this.endDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(230, 29);
            this.endDate.TabIndex = 39;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(671, 76);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(64, 19);
            this.metroLabel3.TabIndex = 38;
            this.metroLabel3.Text = "To Date :";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(440, 72);
            this.startDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(224, 29);
            this.startDate.TabIndex = 37;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(359, 76);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(78, 19);
            this.metroLabel4.TabIndex = 36;
            this.metroLabel4.Text = "Start Date :";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAccountNo.Location = new System.Drawing.Point(18, 74);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(46, 19);
            this.lblAccountNo.TabIndex = 35;
            this.lblAccountNo.Text = "Dept :";
            this.lblAccountNo.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Location = new System.Drawing.Point(22, 95);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(1165, 23);
            this.metroLabel2.TabIndex = 33;
            this.metroLabel2.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "----------------------------";
            // 
            // cbxDepartments
            // 
            this.cbxDepartments.FormattingEnabled = true;
            this.cbxDepartments.ItemHeight = 23;
            this.cbxDepartments.Location = new System.Drawing.Point(63, 71);
            this.cbxDepartments.Name = "cbxDepartments";
            this.cbxDepartments.Size = new System.Drawing.Size(278, 29);
            this.cbxDepartments.TabIndex = 41;
            this.cbxDepartments.UseSelectable = true;
            this.cbxDepartments.SelectedIndexChanged += new System.EventHandler(this.cbxDepartments_SelectedIndexChanged);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(490, 113);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(96, 19);
            this.metroLabel6.TabIndex = 45;
            this.metroLabel6.Text = "Work Report";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(20, 113);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(117, 19);
            this.metroLabel5.TabIndex = 47;
            this.metroLabel5.Text = "Financial Report";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // lblWorkerAmount
            // 
            this.lblWorkerAmount.AutoSize = true;
            this.lblWorkerAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkerAmount.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblWorkerAmount.Location = new System.Drawing.Point(605, 451);
            this.lblWorkerAmount.Name = "lblWorkerAmount";
            this.lblWorkerAmount.Size = new System.Drawing.Size(0, 0);
            this.lblWorkerAmount.TabIndex = 48;
            this.lblWorkerAmount.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // lblWorkerExpenses
            // 
            this.lblWorkerExpenses.AutoSize = true;
            this.lblWorkerExpenses.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkerExpenses.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblWorkerExpenses.Location = new System.Drawing.Point(136, 451);
            this.lblWorkerExpenses.Name = "lblWorkerExpenses";
            this.lblWorkerExpenses.Size = new System.Drawing.Size(0, 0);
            this.lblWorkerExpenses.TabIndex = 49;
            this.lblWorkerExpenses.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // lblWorkerTotalAmount
            // 
            this.lblWorkerTotalAmount.AutoSize = true;
            this.lblWorkerTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkerTotalAmount.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblWorkerTotalAmount.Location = new System.Drawing.Point(491, 451);
            this.lblWorkerTotalAmount.Name = "lblWorkerTotalAmount";
            this.lblWorkerTotalAmount.Size = new System.Drawing.Size(108, 19);
            this.lblWorkerTotalAmount.TabIndex = 46;
            this.lblWorkerTotalAmount.Text = "Total Amount :";
            this.lblWorkerTotalAmount.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // lblFinancialExpense
            // 
            this.lblFinancialExpense.AutoSize = true;
            this.lblFinancialExpense.BackColor = System.Drawing.Color.Transparent;
            this.lblFinancialExpense.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblFinancialExpense.Location = new System.Drawing.Point(22, 451);
            this.lblFinancialExpense.Name = "lblFinancialExpense";
            this.lblFinancialExpense.Size = new System.Drawing.Size(108, 19);
            this.lblFinancialExpense.TabIndex = 44;
            this.lblFinancialExpense.Text = "Total Amount :";
            this.lblFinancialExpense.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // grdWorkerFinance
            // 
            this.grdWorkerFinance.AllowUserToAddRows = false;
            this.grdWorkerFinance.AllowUserToDeleteRows = false;
            this.grdWorkerFinance.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdWorkerFinance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdWorkerFinance.ColumnHeadersHeight = 30;
            this.grdWorkerFinance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescription,
            this.colFinanceAmount,
            this.colCredit});
            this.grdWorkerFinance.EnableHeadersVisualStyles = false;
            this.grdWorkerFinance.Location = new System.Drawing.Point(22, 136);
            this.grdWorkerFinance.Name = "grdWorkerFinance";
            this.grdWorkerFinance.ReadOnly = true;
            this.grdWorkerFinance.RowHeadersVisible = false;
            this.grdWorkerFinance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdWorkerFinance.Size = new System.Drawing.Size(459, 295);
            this.grdWorkerFinance.TabIndex = 42;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "AccountName";
            this.colDescription.HeaderText = "Account Name";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 250;
            // 
            // colFinanceAmount
            // 
            this.colFinanceAmount.DataPropertyName = "Debit";
            this.colFinanceAmount.HeaderText = "Debit";
            this.colFinanceAmount.Name = "colFinanceAmount";
            this.colFinanceAmount.ReadOnly = true;
            // 
            // colCredit
            // 
            this.colCredit.DataPropertyName = "Credit";
            this.colCredit.HeaderText = "Credit";
            this.colCredit.Name = "colCredit";
            this.colCredit.ReadOnly = true;
            // 
            // grdWorkerReport
            // 
            this.grdWorkerReport.AllowUserToAddRows = false;
            this.grdWorkerReport.AllowUserToDeleteRows = false;
            this.grdWorkerReport.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdWorkerReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdWorkerReport.ColumnHeadersHeight = 30;
            this.grdWorkerReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWorkerName,
            this.colGalma,
            this.colPuttha,
            this.colSGalma,
            this.colSPuttha,
            this.colDGalma,
            this.colLotNo,
            this.colQuality,
            this.colCuttingQuantity,
            this.colAmount});
            this.grdWorkerReport.EnableHeadersVisualStyles = false;
            this.grdWorkerReport.Location = new System.Drawing.Point(491, 136);
            this.grdWorkerReport.Name = "grdWorkerReport";
            this.grdWorkerReport.ReadOnly = true;
            this.grdWorkerReport.RowHeadersVisible = false;
            this.grdWorkerReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdWorkerReport.Size = new System.Drawing.Size(750, 295);
            this.grdWorkerReport.TabIndex = 43;
            // 
            // colWorkerName
            // 
            this.colWorkerName.DataPropertyName = "AccountName";
            this.colWorkerName.HeaderText = "Work Name";
            this.colWorkerName.Name = "colWorkerName";
            this.colWorkerName.ReadOnly = true;
            this.colWorkerName.Width = 160;
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
            // colSGalma
            // 
            this.colSGalma.DataPropertyName = "SGalma";
            this.colSGalma.HeaderText = "S.Galma";
            this.colSGalma.Name = "colSGalma";
            this.colSGalma.ReadOnly = true;
            this.colSGalma.Width = 80;
            // 
            // colSPuttha
            // 
            this.colSPuttha.DataPropertyName = "SPuttha";
            this.colSPuttha.HeaderText = "S.Puttha";
            this.colSPuttha.Name = "colSPuttha";
            this.colSPuttha.ReadOnly = true;
            this.colSPuttha.Width = 80;
            // 
            // colDGalma
            // 
            this.colDGalma.DataPropertyName = "DGalma";
            this.colDGalma.HeaderText = "D.Galma";
            this.colDGalma.Name = "colDGalma";
            this.colDGalma.ReadOnly = true;
            this.colDGalma.Width = 80;
            // 
            // colLotNo
            // 
            this.colLotNo.DataPropertyName = "LotNo";
            this.colLotNo.HeaderText = "LotNo";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.ReadOnly = true;
            this.colLotNo.Visible = false;
            // 
            // colQuality
            // 
            this.colQuality.DataPropertyName = "ItemName";
            this.colQuality.HeaderText = "Quality";
            this.colQuality.Name = "colQuality";
            this.colQuality.ReadOnly = true;
            this.colQuality.Visible = false;
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
            // frmDepartmentFinancialAndWorkComparisonReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 494);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.lblWorkerAmount);
            this.Controls.Add(this.lblWorkerExpenses);
            this.Controls.Add(this.lblWorkerTotalAmount);
            this.Controls.Add(this.lblFinancialExpense);
            this.Controls.Add(this.grdWorkerFinance);
            this.Controls.Add(this.grdWorkerReport);
            this.Controls.Add(this.cbxDepartments);
            this.Controls.Add(this.btnGetComparison);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frmDepartmentFinancialAndWorkComparisonReport";
            this.Text = "Departments Comparison Report";
            this.Load += new System.EventHandler(this.frmDepartmentFinancialAndWorkComparisonReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerFinance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnGetComparison;
        private MetroFramework.Controls.MetroDateTime endDate;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime startDate;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel lblAccountNo;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox cbxDepartments;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel lblWorkerAmount;
        private MetroFramework.Controls.MetroLabel lblWorkerExpenses;
        private MetroFramework.Controls.MetroLabel lblWorkerTotalAmount;
        private MetroFramework.Controls.MetroLabel lblFinancialExpense;
        private CustomDataGrid grdWorkerFinance;
        private CustomDataGrid grdWorkerReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinanceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGalma;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPuttha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSGalma;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSPuttha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDGalma;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuality;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}