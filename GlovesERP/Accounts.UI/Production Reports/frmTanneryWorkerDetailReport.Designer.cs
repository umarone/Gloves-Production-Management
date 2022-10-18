namespace Accounts.UI
{
    partial class frmTanneryWorkerDetailReport
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
            this.btnPrintReport = new MetroFramework.Controls.MetroTile();
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
            this.grdWorkerReport = new Accounts.UI.CustomDataGrid();
            this.colWorkingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVehicleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGalma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPuttha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSGalma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSPuttha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDGalma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDPuttha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuttingQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdvancesDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoanDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerReport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.ActiveControl = null;
            this.btnPrintReport.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPrintReport.Location = new System.Drawing.Point(976, 391);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(133, 219);
            this.btnPrintReport.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrintReport.TabIndex = 25;
            this.btnPrintReport.Text = "Print Report";
            this.btnPrintReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrintReport.UseCustomBackColor = true;
            this.btnPrintReport.UseSelectable = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // grdPaymentDetail
            // 
            this.grdPaymentDetail.AllowUserToAddRows = false;
            this.grdPaymentDetail.AllowUserToDeleteRows = false;
            this.grdPaymentDetail.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
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
            this.grdPaymentDetail.Location = new System.Drawing.Point(649, 391);
            this.grdPaymentDetail.Name = "grdPaymentDetail";
            this.grdPaymentDetail.ReadOnly = true;
            this.grdPaymentDetail.RowHeadersVisible = false;
            this.grdPaymentDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPaymentDetail.Size = new System.Drawing.Size(321, 219);
            this.grdPaymentDetail.TabIndex = 24;
            // 
            // colPaymentDesc
            // 
            this.colPaymentDesc.DataPropertyName = "Description";
            this.colPaymentDesc.HeaderText = "Desc";
            this.colPaymentDesc.Name = "colPaymentDesc";
            this.colPaymentDesc.ReadOnly = true;
            this.colPaymentDesc.Width = 150;
            // 
            // colPaymentAmount
            // 
            this.colPaymentAmount.DataPropertyName = "Balance";
            this.colPaymentAmount.HeaderText = "Amount";
            this.colPaymentAmount.Name = "colPaymentAmount";
            this.colPaymentAmount.ReadOnly = true;
            this.colPaymentAmount.Width = 150;
            // 
            // grdAdvancesDetail
            // 
            this.grdAdvancesDetail.AllowUserToAddRows = false;
            this.grdAdvancesDetail.AllowUserToDeleteRows = false;
            this.grdAdvancesDetail.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
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
            this.grdAdvancesDetail.Location = new System.Drawing.Point(328, 391);
            this.grdAdvancesDetail.Name = "grdAdvancesDetail";
            this.grdAdvancesDetail.ReadOnly = true;
            this.grdAdvancesDetail.RowHeadersVisible = false;
            this.grdAdvancesDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAdvancesDetail.Size = new System.Drawing.Size(312, 219);
            this.grdAdvancesDetail.TabIndex = 24;
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
            this.grdLoanDetail.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Teal;
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
            this.grdLoanDetail.Location = new System.Drawing.Point(23, 391);
            this.grdLoanDetail.Name = "grdLoanDetail";
            this.grdLoanDetail.ReadOnly = true;
            this.grdLoanDetail.RowHeadersVisible = false;
            this.grdLoanDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLoanDetail.Size = new System.Drawing.Size(299, 219);
            this.grdLoanDetail.TabIndex = 24;
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
            // grdWorkerReport
            // 
            this.grdWorkerReport.AllowUserToAddRows = false;
            this.grdWorkerReport.AllowUserToDeleteRows = false;
            this.grdWorkerReport.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdWorkerReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdWorkerReport.ColumnHeadersHeight = 30;
            this.grdWorkerReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWorkingDate,
            this.colQuality,
            this.colLotNo,
            this.colVehicleNo,
            this.colProcess,
            this.colGalma,
            this.colPuttha,
            this.colSGalma,
            this.colSPuttha,
            this.colDGalma,
            this.colDPuttha,
            this.colCuttingQuantity,
            this.colAmount});
            this.grdWorkerReport.EnableHeadersVisualStyles = false;
            this.grdWorkerReport.Location = new System.Drawing.Point(23, 79);
            this.grdWorkerReport.Name = "grdWorkerReport";
            this.grdWorkerReport.ReadOnly = true;
            this.grdWorkerReport.RowHeadersVisible = false;
            this.grdWorkerReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdWorkerReport.Size = new System.Drawing.Size(1110, 306);
            this.grdWorkerReport.TabIndex = 24;
            // 
            // colWorkingDate
            // 
            this.colWorkingDate.DataPropertyName = "WorkingDate";
            this.colWorkingDate.HeaderText = "Date";
            this.colWorkingDate.Name = "colWorkingDate";
            this.colWorkingDate.ReadOnly = true;
            this.colWorkingDate.Width = 90;
            // 
            // colQuality
            // 
            this.colQuality.DataPropertyName = "QualityName";
            this.colQuality.HeaderText = "Quality";
            this.colQuality.Name = "colQuality";
            this.colQuality.ReadOnly = true;
            this.colQuality.Width = 150;
            // 
            // colLotNo
            // 
            this.colLotNo.DataPropertyName = "LotNo";
            this.colLotNo.HeaderText = "Lot";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.ReadOnly = true;
            this.colLotNo.Width = 90;
            // 
            // colVehicleNo
            // 
            this.colVehicleNo.DataPropertyName = "VehicleNo";
            this.colVehicleNo.HeaderText = "Vehicle No";
            this.colVehicleNo.Name = "colVehicleNo";
            this.colVehicleNo.ReadOnly = true;
            this.colVehicleNo.Width = 110;
            // 
            // colProcess
            // 
            this.colProcess.DataPropertyName = "ProcessName";
            this.colProcess.HeaderText = "Process";
            this.colProcess.Name = "colProcess";
            this.colProcess.ReadOnly = true;
            // 
            // colGalma
            // 
            this.colGalma.DataPropertyName = "Pieces";
            this.colGalma.HeaderText = "Galma";
            this.colGalma.Name = "colGalma";
            this.colGalma.ReadOnly = true;
            this.colGalma.Width = 90;
            // 
            // colPuttha
            // 
            this.colPuttha.DataPropertyName = "PPieces";
            this.colPuttha.HeaderText = "Puttha";
            this.colPuttha.Name = "colPuttha";
            this.colPuttha.ReadOnly = true;
            this.colPuttha.Width = 90;
            // 
            // colSGalma
            // 
            this.colSGalma.DataPropertyName = "SGalma";
            this.colSGalma.HeaderText = "S.Galma";
            this.colSGalma.Name = "colSGalma";
            this.colSGalma.ReadOnly = true;
            this.colSGalma.Width = 90;
            // 
            // colSPuttha
            // 
            this.colSPuttha.DataPropertyName = "SPuttha";
            this.colSPuttha.HeaderText = "S. Puttha";
            this.colSPuttha.Name = "colSPuttha";
            this.colSPuttha.ReadOnly = true;
            this.colSPuttha.Width = 90;
            // 
            // colDGalma
            // 
            this.colDGalma.HeaderText = "D.Galma";
            this.colDGalma.Name = "colDGalma";
            this.colDGalma.ReadOnly = true;
            this.colDGalma.Width = 90;
            // 
            // colDPuttha
            // 
            this.colDPuttha.HeaderText = "D.Puttha";
            this.colDPuttha.Name = "colDPuttha";
            this.colDPuttha.ReadOnly = true;
            this.colDPuttha.Width = 90;
            // 
            // colCuttingQuantity
            // 
            this.colCuttingQuantity.DataPropertyName = "Cutting";
            this.colCuttingQuantity.HeaderText = "Quantity";
            this.colCuttingQuantity.Name = "colCuttingQuantity";
            this.colCuttingQuantity.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 120;
            // 
            // frmTanneryWorkerDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 617);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.grdPaymentDetail);
            this.Controls.Add(this.grdAdvancesDetail);
            this.Controls.Add(this.grdLoanDetail);
            this.Controls.Add(this.grdWorkerReport);
            this.Name = "frmTanneryWorkerDetailReport";
            this.Text = "frmTanneryWorkerDetailReport";
            this.Load += new System.EventHandler(this.frmTanneryWorkerDetailReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdvancesDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoanDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkerReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomDataGrid grdWorkerReport;
        private CustomDataGrid grdLoanDetail;
        private CustomDataGrid grdAdvancesDetail;
        private CustomDataGrid grdPaymentDetail;
        private MetroFramework.Controls.MetroTile btnPrintReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colloanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoanDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoanAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdvancesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdvancesDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdvancesAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuality;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVehicleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGalma;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPuttha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSGalma;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSPuttha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDGalma;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDPuttha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuttingQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}