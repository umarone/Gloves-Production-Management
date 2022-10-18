namespace Accounts.UI.Production
{
    partial class frmCuffTalliCalculation
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
            this.grdCuffing = new Accounts.UI.TabDataGrid();
            this.colcuffingEstimated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuffingDozen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalCuffBari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuffingCalculatedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcuffTaliBariSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcuffingWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcuffingTotalBari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuffingBariSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcuffingMeterYard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuffingQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuffingPacking = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCuffingProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcuffingIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuffingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdCuffing)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCuffing
            // 
            this.grdCuffing.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.grdCuffing.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCuffing.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCuffing.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdCuffing.ColumnHeadersHeight = 25;
            this.grdCuffing.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCuffingId,
            this.colcuffingIdItem,
            this.dataGridViewTextBoxColumn3,
            this.colCuffingProduct,
            this.colCuffingPacking,
            this.colCuffingQty,
            this.colcuffingMeterYard,
            this.colCuffingBariSize,
            this.colcuffingTotalBari,
            this.colcuffingWidth,
            this.colcuffTaliBariSize,
            this.colCuffingCalculatedQty,
            this.colTotalCuffBari,
            this.colCuffingDozen,
            this.colcuffingEstimated});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCuffing.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdCuffing.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdCuffing.EnableHeadersVisualStyles = false;
            this.grdCuffing.Location = new System.Drawing.Point(25, 69);
            this.grdCuffing.MultiSelect = false;
            this.grdCuffing.Name = "grdCuffing";
            this.grdCuffing.RowHeadersVisible = false;
            this.grdCuffing.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdCuffing.Size = new System.Drawing.Size(1014, 242);
            this.grdCuffing.TabIndex = 29;
            this.grdCuffing.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCuffing_CellEndEdit);
            this.grdCuffing.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCuffing_CellEnter);
            this.grdCuffing.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCuffing_CellLeave);
            this.grdCuffing.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdCuffing_EditingControlShowing);
            // 
            // colcuffingEstimated
            // 
            this.colcuffingEstimated.HeaderText = "Estimated OutPut";
            this.colcuffingEstimated.Name = "colcuffingEstimated";
            this.colcuffingEstimated.Width = 110;
            // 
            // colCuffingDozen
            // 
            this.colCuffingDozen.HeaderText = "Dozen";
            this.colCuffingDozen.Name = "colCuffingDozen";
            this.colCuffingDozen.Width = 70;
            // 
            // colTotalCuffBari
            // 
            this.colTotalCuffBari.HeaderText = "Total";
            this.colTotalCuffBari.Name = "colTotalCuffBari";
            this.colTotalCuffBari.ReadOnly = true;
            this.colTotalCuffBari.Width = 70;
            // 
            // colCuffingCalculatedQty
            // 
            this.colCuffingCalculatedQty.HeaderText = "Cuff/Bari (Qty)";
            this.colCuffingCalculatedQty.Name = "colCuffingCalculatedQty";
            this.colCuffingCalculatedQty.ReadOnly = true;
            this.colCuffingCalculatedQty.Width = 80;
            // 
            // colcuffTaliBariSize
            // 
            this.colcuffTaliBariSize.HeaderText = "Cuff/Tali Size";
            this.colcuffTaliBariSize.Name = "colcuffTaliBariSize";
            this.colcuffTaliBariSize.Width = 80;
            // 
            // colcuffingWidth
            // 
            this.colcuffingWidth.HeaderText = "Width";
            this.colcuffingWidth.Name = "colcuffingWidth";
            this.colcuffingWidth.Width = 70;
            // 
            // colcuffingTotalBari
            // 
            this.colcuffingTotalBari.HeaderText = "Total Bari";
            this.colcuffingTotalBari.Name = "colcuffingTotalBari";
            this.colcuffingTotalBari.ReadOnly = true;
            this.colcuffingTotalBari.Width = 70;
            // 
            // colCuffingBariSize
            // 
            this.colCuffingBariSize.HeaderText = "Bari Size";
            this.colCuffingBariSize.Name = "colCuffingBariSize";
            this.colCuffingBariSize.Width = 70;
            // 
            // colcuffingMeterYard
            // 
            this.colcuffingMeterYard.HeaderText = "Meter/Yard";
            this.colcuffingMeterYard.Name = "colcuffingMeterYard";
            this.colcuffingMeterYard.ReadOnly = true;
            this.colcuffingMeterYard.Width = 70;
            // 
            // colCuffingQty
            // 
            this.colCuffingQty.DataPropertyName = "Qty";
            this.colCuffingQty.HeaderText = "Qty";
            this.colCuffingQty.Name = "colCuffingQty";
            this.colCuffingQty.Width = 70;
            // 
            // colCuffingPacking
            // 
            this.colCuffingPacking.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colCuffingPacking.HeaderText = "UOM";
            this.colCuffingPacking.Items.AddRange(new object[] {
            "Meter",
            "Yard"});
            this.colCuffingPacking.Name = "colCuffingPacking";
            this.colCuffingPacking.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCuffingPacking.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCuffingPacking.Width = 80;
            // 
            // colCuffingProduct
            // 
            this.colCuffingProduct.HeaderText = "Material Description";
            this.colCuffingProduct.Name = "colCuffingProduct";
            this.colCuffingProduct.Width = 160;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "AccountNo";
            this.dataGridViewTextBoxColumn3.HeaderText = "Product Code";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // colcuffingIdItem
            // 
            this.colcuffingIdItem.HeaderText = "IdItem";
            this.colcuffingIdItem.Name = "colcuffingIdItem";
            this.colcuffingIdItem.Visible = false;
            // 
            // colCuffingId
            // 
            this.colCuffingId.HeaderText = "IdDetail";
            this.colCuffingId.Name = "colCuffingId";
            this.colCuffingId.Visible = false;
            // 
            // frmCuffTalliCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 340);
            this.Controls.Add(this.grdCuffing);
            this.Name = "frmCuffTalliCalculation";
            this.Text = "Cuff / Talli Calculation";
            this.Load += new System.EventHandler(this.frmCuffTalliCalculation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCuffing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabDataGrid grdCuffing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuffingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcuffingIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuffingProduct;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCuffingPacking;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuffingQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcuffingMeterYard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuffingBariSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcuffingTotalBari;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcuffingWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcuffTaliBariSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuffingCalculatedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCuffBari;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuffingDozen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcuffingEstimated;
    }
}