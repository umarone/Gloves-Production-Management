namespace Accounts.UI
{
    partial class frmVehicleProfitLoss
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbxVehicles = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnLoadProfitLoss = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.lblProfit = new MetroFramework.Controls.MetroLabel();
            this.lblTotalExpense = new MetroFramework.Controls.MetroLabel();
            this.lblCuttingValue = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.grdVehicleProfitLoss = new Accounts.UI.CustomDataGrid();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicleProfitLoss)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(12, 84);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(125, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Select Vehicle :";
            // 
            // cbxVehicles
            // 
            this.cbxVehicles.FormattingEnabled = true;
            this.cbxVehicles.ItemHeight = 23;
            this.cbxVehicles.Location = new System.Drawing.Point(141, 84);
            this.cbxVehicles.Name = "cbxVehicles";
            this.cbxVehicles.Size = new System.Drawing.Size(157, 29);
            this.cbxVehicles.TabIndex = 1;
            this.cbxVehicles.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Blue;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.ForeColor = System.Drawing.Color.Blue;
            this.metroLabel2.Location = new System.Drawing.Point(22, 56);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(852, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "---------------------------------------------------------------------------------" +
    "---------------------------------------";
            // 
            // btnLoadProfitLoss
            // 
            this.btnLoadProfitLoss.Location = new System.Drawing.Point(304, 84);
            this.btnLoadProfitLoss.Name = "btnLoadProfitLoss";
            this.btnLoadProfitLoss.Size = new System.Drawing.Size(113, 28);
            this.btnLoadProfitLoss.TabIndex = 2;
            this.btnLoadProfitLoss.Text = "Load";
            this.btnLoadProfitLoss.UseSelectable = true;
            this.btnLoadProfitLoss.Click += new System.EventHandler(this.btnLoadProfitLoss_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.lblProfit);
            this.metroPanel1.Controls.Add(this.lblTotalExpense);
            this.metroPanel1.Controls.Add(this.lblCuttingValue);
            this.metroPanel1.Controls.Add(this.metroLabel6);
            this.metroPanel1.Controls.Add(this.metroLabel4);
            this.metroPanel1.Controls.Add(this.metroLabel5);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(666, 119);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(199, 384);
            this.metroPanel1.TabIndex = 4;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // lblProfit
            // 
            this.lblProfit.AutoSize = true;
            this.lblProfit.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblProfit.Location = new System.Drawing.Point(91, 140);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(0, 0);
            this.lblProfit.TabIndex = 3;
            // 
            // lblTotalExpense
            // 
            this.lblTotalExpense.AutoSize = true;
            this.lblTotalExpense.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTotalExpense.Location = new System.Drawing.Point(89, 68);
            this.lblTotalExpense.Name = "lblTotalExpense";
            this.lblTotalExpense.Size = new System.Drawing.Size(0, 0);
            this.lblTotalExpense.TabIndex = 3;
            // 
            // lblCuttingValue
            // 
            this.lblCuttingValue.AutoSize = true;
            this.lblCuttingValue.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblCuttingValue.Location = new System.Drawing.Point(98, 24);
            this.lblCuttingValue.Name = "lblCuttingValue";
            this.lblCuttingValue.Size = new System.Drawing.Size(0, 0);
            this.lblCuttingValue.TabIndex = 3;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(6, 140);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(85, 19);
            this.metroLabel6.TabIndex = 2;
            this.metroLabel6.Text = "Total Profit : ";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(6, 68);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(72, 19);
            this.metroLabel4.TabIndex = 2;
            this.metroLabel4.Text = "Expenses : ";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.Color.Blue;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.ForeColor = System.Drawing.Color.Blue;
            this.metroLabel5.Location = new System.Drawing.Point(3, 102);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(194, 25);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel5.TabIndex = 0;
            this.metroLabel5.Text = "--------------------------";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(2, 24);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(98, 19);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Cutting Value : ";
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
            this.colAccountName,
            this.colAmount});
            this.grdVehicleProfitLoss.EnableHeadersVisualStyles = false;
            this.grdVehicleProfitLoss.Location = new System.Drawing.Point(13, 119);
            this.grdVehicleProfitLoss.Name = "grdVehicleProfitLoss";
            this.grdVehicleProfitLoss.ReadOnly = true;
            this.grdVehicleProfitLoss.RowHeadersVisible = false;
            this.grdVehicleProfitLoss.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVehicleProfitLoss.Size = new System.Drawing.Size(638, 384);
            this.grdVehicleProfitLoss.TabIndex = 3;
            // 
            // colAccountName
            // 
            this.colAccountName.DataPropertyName = "AccountName";
            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 400;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 200;
            // 
            // frmVehicleProfitLoss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 520);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.grdVehicleProfitLoss);
            this.Controls.Add(this.btnLoadProfitLoss);
            this.Controls.Add(this.cbxVehicles);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVehicleProfitLoss";
            this.Text = "Vehicle Profit Loss";
            this.Load += new System.EventHandler(this.frmVehicleProfitLoss_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicleProfitLoss)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cbxVehicles;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnLoadProfitLoss;
        private CustomDataGrid grdVehicleProfitLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel lblCuttingValue;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel lblProfit;
        private MetroFramework.Controls.MetroLabel lblTotalExpense;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
    }
}