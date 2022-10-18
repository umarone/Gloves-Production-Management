namespace Accounts.UI
{
    partial class frmVehicleLots
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
            this.btnLoadLots = new MetroFramework.Controls.MetroButton();
            this.cbxVehicles = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.grdVehicleLots = new Accounts.UI.CustomDataGrid();
            this.colIdLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotQuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotCost = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicleLots)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Blue;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.ForeColor = System.Drawing.Color.Blue;
            this.metroLabel2.Location = new System.Drawing.Point(23, 53);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(698, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "---------------------------------------------------------------------------------" +
    "-----------------";
            // 
            // btnLoadLots
            // 
            this.btnLoadLots.Location = new System.Drawing.Point(313, 80);
            this.btnLoadLots.Name = "btnLoadLots";
            this.btnLoadLots.Size = new System.Drawing.Size(113, 28);
            this.btnLoadLots.TabIndex = 5;
            this.btnLoadLots.Text = "Load";
            this.btnLoadLots.UseSelectable = true;
            this.btnLoadLots.Click += new System.EventHandler(this.btnLoadLots_Click);
            // 
            // cbxVehicles
            // 
            this.cbxVehicles.FormattingEnabled = true;
            this.cbxVehicles.ItemHeight = 23;
            this.cbxVehicles.Location = new System.Drawing.Point(150, 80);
            this.cbxVehicles.Name = "cbxVehicles";
            this.cbxVehicles.Size = new System.Drawing.Size(157, 29);
            this.cbxVehicles.TabIndex = 4;
            this.cbxVehicles.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(21, 80);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(125, 25);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Select Vehicle :";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Blue;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.ForeColor = System.Drawing.Color.Blue;
            this.metroLabel3.Location = new System.Drawing.Point(23, 105);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(691, 25);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.TabIndex = 1;
            this.metroLabel3.Text = "---------------------------------------------------------------------------------" +
    "----------------";
            // 
            // grdVehicleLots
            // 
            this.grdVehicleLots.AllowUserToAddRows = false;
            this.grdVehicleLots.AllowUserToDeleteRows = false;
            this.grdVehicleLots.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdVehicleLots.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdVehicleLots.ColumnHeadersHeight = 30;
            this.grdVehicleLots.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdLot,
            this.colLotNo,
            this.colLotWeight,
            this.colLotProcess,
            this.colLotStatus,
            this.colLotQuality,
            this.colLotCost});
            this.grdVehicleLots.EnableHeadersVisualStyles = false;
            this.grdVehicleLots.GridColor = System.Drawing.Color.LemonChiffon;
            this.grdVehicleLots.Location = new System.Drawing.Point(19, 129);
            this.grdVehicleLots.Name = "grdVehicleLots";
            this.grdVehicleLots.ReadOnly = true;
            this.grdVehicleLots.RowHeadersVisible = false;
            this.grdVehicleLots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVehicleLots.Size = new System.Drawing.Size(698, 404);
            this.grdVehicleLots.TabIndex = 6;
            this.grdVehicleLots.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVehicleLots_CellClick);
            this.grdVehicleLots.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdVehicleLots_CellFormatting);
            // 
            // colIdLot
            // 
            this.colIdLot.DataPropertyName = "IdLot";
            this.colIdLot.HeaderText = "IdLot";
            this.colIdLot.Name = "colIdLot";
            this.colIdLot.ReadOnly = true;
            this.colIdLot.Visible = false;
            // 
            // colLotNo
            // 
            this.colLotNo.DataPropertyName = "LotNo";
            this.colLotNo.HeaderText = "Lot No #";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.ReadOnly = true;
            this.colLotNo.Width = 90;
            // 
            // colLotWeight
            // 
            this.colLotWeight.DataPropertyName = "LotWeight";
            this.colLotWeight.HeaderText = "Weight";
            this.colLotWeight.Name = "colLotWeight";
            this.colLotWeight.ReadOnly = true;
            this.colLotWeight.Width = 90;
            // 
            // colLotProcess
            // 
            this.colLotProcess.DataPropertyName = "ProcessName";
            this.colLotProcess.HeaderText = "Stage";
            this.colLotProcess.Name = "colLotProcess";
            this.colLotProcess.ReadOnly = true;
            this.colLotProcess.Width = 130;
            // 
            // colLotStatus
            // 
            this.colLotStatus.DataPropertyName = "Status";
            this.colLotStatus.HeaderText = "Status";
            this.colLotStatus.Name = "colLotStatus";
            this.colLotStatus.ReadOnly = true;
            this.colLotStatus.Width = 130;
            // 
            // colLotQuality
            // 
            this.colLotQuality.DataPropertyName = "QualityName";
            this.colLotQuality.HeaderText = "Quality";
            this.colLotQuality.Name = "colLotQuality";
            this.colLotQuality.ReadOnly = true;
            this.colLotQuality.Width = 150;
            // 
            // colLotCost
            // 
            this.colLotCost.HeaderText = "...";
            this.colLotCost.Name = "colLotCost";
            this.colLotCost.ReadOnly = true;
            // 
            // frmVehicleLots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 556);
            this.Controls.Add(this.grdVehicleLots);
            this.Controls.Add(this.btnLoadLots);
            this.Controls.Add(this.cbxVehicles);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Name = "frmVehicleLots";
            this.Text = "Vehicle Lots";
            this.Load += new System.EventHandler(this.frmVehicleLots_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVehicleLots)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnLoadLots;
        private MetroFramework.Controls.MetroComboBox cbxVehicles;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private CustomDataGrid grdVehicleLots;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotQuality;
        private System.Windows.Forms.DataGridViewButtonColumn colLotCost;
    }
}