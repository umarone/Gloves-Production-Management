namespace Accounts.UI
{
    partial class frmAllVehiclesProfitLoss
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
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.grdVehicleProfitLoss = new Accounts.UI.CustomDataGrid();
            this.btnLoadVehicles = new MetroFramework.Controls.MetroButton();
            this.colVehicleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicleProfitLoss)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Blue;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.ForeColor = System.Drawing.Color.Blue;
            this.metroLabel2.Location = new System.Drawing.Point(24, 55);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(565, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "-------------------------------------------------------------------------------";
            // 
            // grdVehicleProfitLoss
            // 
            this.grdVehicleProfitLoss.AllowUserToAddRows = false;
            this.grdVehicleProfitLoss.AllowUserToDeleteRows = false;
            this.grdVehicleProfitLoss.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdVehicleProfitLoss.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdVehicleProfitLoss.ColumnHeadersHeight = 30;
            this.grdVehicleProfitLoss.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVehicleNo,
            this.colCredit,
            this.colDebit,
            this.colBalance});
            this.grdVehicleProfitLoss.EnableHeadersVisualStyles = false;
            this.grdVehicleProfitLoss.Location = new System.Drawing.Point(26, 85);
            this.grdVehicleProfitLoss.Name = "grdVehicleProfitLoss";
            this.grdVehicleProfitLoss.ReadOnly = true;
            this.grdVehicleProfitLoss.RowHeadersVisible = false;
            this.grdVehicleProfitLoss.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVehicleProfitLoss.Size = new System.Drawing.Size(562, 377);
            this.grdVehicleProfitLoss.TabIndex = 4;
            // 
            // btnLoadVehicles
            // 
            this.btnLoadVehicles.Location = new System.Drawing.Point(26, 468);
            this.btnLoadVehicles.Name = "btnLoadVehicles";
            this.btnLoadVehicles.Size = new System.Drawing.Size(562, 37);
            this.btnLoadVehicles.TabIndex = 5;
            this.btnLoadVehicles.Text = "Load All Vehicles";
            this.btnLoadVehicles.UseSelectable = true;
            this.btnLoadVehicles.Click += new System.EventHandler(this.btnLoadVehicles_Click);
            // 
            // colVehicleNo
            // 
            this.colVehicleNo.DataPropertyName = "VehicalNo";
            this.colVehicleNo.HeaderText = "Vehicle No";
            this.colVehicleNo.Name = "colVehicleNo";
            this.colVehicleNo.ReadOnly = true;
            this.colVehicleNo.Width = 200;
            // 
            // colCredit
            // 
            this.colCredit.DataPropertyName = "Credit";
            this.colCredit.HeaderText = "Credit";
            this.colCredit.Name = "colCredit";
            this.colCredit.ReadOnly = true;
            this.colCredit.Width = 125;
            // 
            // colDebit
            // 
            this.colDebit.DataPropertyName = "Debit";
            this.colDebit.HeaderText = "Debit";
            this.colDebit.Name = "colDebit";
            this.colDebit.ReadOnly = true;
            this.colDebit.Width = 125;
            // 
            // colBalance
            // 
            this.colBalance.DataPropertyName = "ClosingBalance";
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.ReadOnly = true;
            // 
            // frmAllVehiclesProfitLoss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 530);
            this.Controls.Add(this.btnLoadVehicles);
            this.Controls.Add(this.grdVehicleProfitLoss);
            this.Controls.Add(this.metroLabel2);
            this.MaximizeBox = false;
            this.Name = "frmAllVehiclesProfitLoss";
            this.Text = "All Vehicles Profit And Loss";
            this.Load += new System.EventHandler(this.frmAllVehiclesProfitLoss_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicleProfitLoss)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel2;
        private CustomDataGrid grdVehicleProfitLoss;
        private MetroFramework.Controls.MetroButton btnLoadVehicles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVehicleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
    }
}