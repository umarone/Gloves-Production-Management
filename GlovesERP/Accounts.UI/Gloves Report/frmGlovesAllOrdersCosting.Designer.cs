namespace Accounts.UI
{
    partial class frmGlovesAllOrdersCosting
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
            this.txtCustomerName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnLoad = new MetroFramework.Controls.MetroButton();
            this.btnExport = new MetroFramework.Controls.MetroButton();
            this.grdOrders = new Accounts.UI.TabDataGrid();
            this.colIdVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLabourCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialsCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMiscExpenses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCustomerName
            // 
            // 
            // 
            // 
            this.txtCustomerName.CustomButton.Image = null;
            this.txtCustomerName.CustomButton.Location = new System.Drawing.Point(569, 1);
            this.txtCustomerName.CustomButton.Name = "";
            this.txtCustomerName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCustomerName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCustomerName.CustomButton.TabIndex = 1;
            this.txtCustomerName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCustomerName.CustomButton.UseSelectable = true;
            this.txtCustomerName.CustomButton.Visible = false;
            this.txtCustomerName.Lines = new string[0];
            this.txtCustomerName.Location = new System.Drawing.Point(154, 64);
            this.txtCustomerName.MaxLength = 32767;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PasswordChar = '\0';
            this.txtCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCustomerName.SelectedText = "";
            this.txtCustomerName.SelectionLength = 0;
            this.txtCustomerName.SelectionStart = 0;
            this.txtCustomerName.ShortcutsEnabled = true;
            this.txtCustomerName.Size = new System.Drawing.Size(591, 23);
            this.txtCustomerName.TabIndex = 5;
            this.txtCustomerName.UseSelectable = true;
            this.txtCustomerName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCustomerName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 64);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(124, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Filter By Customer :";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(751, 63);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(140, 26);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseSelectable = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(893, 63);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(140, 26);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseSelectable = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // grdOrders
            // 
            this.grdOrders.AllowUserToAddRows = false;
            this.grdOrders.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdOrders.ColumnHeadersHeight = 28;
            this.grdOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdVoucher,
            this.colCustomerName,
            this.colBrandName,
            this.colCustomerPO,
            this.colLabourCost,
            this.colMaterialsCost,
            this.colMiscExpenses,
            this.colTotalCost,
            this.colDetail});
            this.grdOrders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdOrders.EnableHeadersVisualStyles = false;
            this.grdOrders.Location = new System.Drawing.Point(23, 96);
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.ReadOnly = true;
            this.grdOrders.RowHeadersVisible = false;
            this.grdOrders.Size = new System.Drawing.Size(1010, 421);
            this.grdOrders.TabIndex = 4;
            this.grdOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOrders_CellClick);
            this.grdOrders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdOrders_CellFormatting);
            // 
            // colIdVoucher
            // 
            this.colIdVoucher.DataPropertyName = "IdOrder";
            this.colIdVoucher.HeaderText = "IdVoucher";
            this.colIdVoucher.Name = "colIdVoucher";
            this.colIdVoucher.ReadOnly = true;
            this.colIdVoucher.Visible = false;
            // 
            // colCustomerName
            // 
            this.colCustomerName.DataPropertyName = "AccountName";
            this.colCustomerName.HeaderText = "Customer Name";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            this.colCustomerName.Width = 200;
            // 
            // colBrandName
            // 
            this.colBrandName.DataPropertyName = "BrandName";
            this.colBrandName.HeaderText = "Brand Name";
            this.colBrandName.Name = "colBrandName";
            this.colBrandName.ReadOnly = true;
            this.colBrandName.Width = 150;
            // 
            // colCustomerPO
            // 
            this.colCustomerPO.DataPropertyName = "CustomerPO";
            this.colCustomerPO.HeaderText = "PO Number #";
            this.colCustomerPO.Name = "colCustomerPO";
            this.colCustomerPO.ReadOnly = true;
            this.colCustomerPO.Width = 120;
            // 
            // colLabourCost
            // 
            this.colLabourCost.DataPropertyName = "LabourCost";
            this.colLabourCost.HeaderText = "Labour Cost";
            this.colLabourCost.Name = "colLabourCost";
            this.colLabourCost.ReadOnly = true;
            this.colLabourCost.Width = 110;
            // 
            // colMaterialsCost
            // 
            this.colMaterialsCost.DataPropertyName = "MaterialsCost";
            this.colMaterialsCost.HeaderText = "Material Cost";
            this.colMaterialsCost.Name = "colMaterialsCost";
            this.colMaterialsCost.ReadOnly = true;
            this.colMaterialsCost.Width = 110;
            // 
            // colMiscExpenses
            // 
            this.colMiscExpenses.DataPropertyName = "Amount";
            this.colMiscExpenses.HeaderText = "Misc Expenses";
            this.colMiscExpenses.Name = "colMiscExpenses";
            this.colMiscExpenses.ReadOnly = true;
            this.colMiscExpenses.Width = 110;
            // 
            // colTotalCost
            // 
            this.colTotalCost.DataPropertyName = "TotalAmount";
            this.colTotalCost.HeaderText = "Total Cost";
            this.colTotalCost.Name = "colTotalCost";
            this.colTotalCost.ReadOnly = true;
            this.colTotalCost.Width = 110;
            // 
            // colDetail
            // 
            this.colDetail.HeaderText = "...";
            this.colDetail.Name = "colDetail";
            this.colDetail.ReadOnly = true;
            this.colDetail.Width = 90;
            // 
            // frmGlovesAllOrdersCosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 534);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.grdOrders);
            this.Name = "frmGlovesAllOrdersCosting";
            this.Text = "Gloves Order Costing";
            this.Load += new System.EventHandler(this.frmGlovesAllOrdersCosting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabDataGrid grdOrders;
        private MetroFramework.Controls.MetroTextBox txtCustomerName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnLoad;
        private MetroFramework.Controls.MetroButton btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLabourCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialsCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMiscExpenses;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCost;
        private System.Windows.Forms.DataGridViewButtonColumn colDetail;
    }
}