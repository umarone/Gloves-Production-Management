namespace Accounts.UI
{
    partial class frmLotDetail
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
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.grdChemicals = new Accounts.UI.TabDataGrid();
            this.colIdChemical = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalCrustIssueQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalCrustIssuedValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalDyingIssueQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalDyingIssuedValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalRedyingIssueQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalRedyingIssuedValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalQtyStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChemicalCurrentValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdLotDetail = new Accounts.UI.CustomDataGrid();
            this.colProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdChemicals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLotDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Blue;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.ForeColor = System.Drawing.Color.Blue;
            this.metroLabel2.Location = new System.Drawing.Point(20, 49);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(670, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "---------------------------------------------------------------------------------" +
    "-------------";
            // 
            // grdChemicals
            // 
            this.grdChemicals.AllowUserToAddRows = false;
            this.grdChemicals.AllowUserToDeleteRows = false;
            this.grdChemicals.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdChemicals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdChemicals.ColumnHeadersHeight = 27;
            this.grdChemicals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdChemical,
            this.colChemicalIdItem,
            this.colChemicalName,
            this.colChemicalCrustIssueQuantity,
            this.colChemicalCrustIssuedValue,
            this.colChemicalDyingIssueQuantity,
            this.colChemicalDyingIssuedValue,
            this.colChemicalRedyingIssueQuantity,
            this.colChemicalRedyingIssuedValue,
            this.colChemicalQtyStock,
            this.colChemicalCurrentValue});
            this.grdChemicals.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdChemicals.EnableHeadersVisualStyles = false;
            this.grdChemicals.Location = new System.Drawing.Point(19, 337);
            this.grdChemicals.Name = "grdChemicals";
            this.grdChemicals.RowHeadersVisible = false;
            this.grdChemicals.Size = new System.Drawing.Size(664, 256);
            this.grdChemicals.TabIndex = 13;
            // 
            // colIdChemical
            // 
            this.colIdChemical.DataPropertyName = "IdChemical";
            this.colIdChemical.HeaderText = "IdChemical";
            this.colIdChemical.Name = "colIdChemical";
            this.colIdChemical.ReadOnly = true;
            this.colIdChemical.Visible = false;
            // 
            // colChemicalIdItem
            // 
            this.colChemicalIdItem.DataPropertyName = "IdItem";
            this.colChemicalIdItem.HeaderText = "IdItem";
            this.colChemicalIdItem.Name = "colChemicalIdItem";
            this.colChemicalIdItem.ReadOnly = true;
            this.colChemicalIdItem.Visible = false;
            // 
            // colChemicalName
            // 
            this.colChemicalName.DataPropertyName = "ItemName";
            this.colChemicalName.HeaderText = "Chemical Name";
            this.colChemicalName.Name = "colChemicalName";
            this.colChemicalName.ReadOnly = true;
            this.colChemicalName.Width = 135;
            // 
            // colChemicalCrustIssueQuantity
            // 
            this.colChemicalCrustIssueQuantity.DataPropertyName = "CrustIssuedQuantity";
            this.colChemicalCrustIssueQuantity.HeaderText = "Crust";
            this.colChemicalCrustIssueQuantity.Name = "colChemicalCrustIssueQuantity";
            this.colChemicalCrustIssueQuantity.Width = 85;
            // 
            // colChemicalCrustIssuedValue
            // 
            this.colChemicalCrustIssuedValue.DataPropertyName = "CrustIssuedValue";
            this.colChemicalCrustIssuedValue.HeaderText = "Issued Value";
            this.colChemicalCrustIssuedValue.Name = "colChemicalCrustIssuedValue";
            this.colChemicalCrustIssuedValue.ReadOnly = true;
            this.colChemicalCrustIssuedValue.Width = 85;
            // 
            // colChemicalDyingIssueQuantity
            // 
            this.colChemicalDyingIssueQuantity.DataPropertyName = "DyingIssuedQuantity";
            this.colChemicalDyingIssueQuantity.HeaderText = "Dying";
            this.colChemicalDyingIssueQuantity.Name = "colChemicalDyingIssueQuantity";
            this.colChemicalDyingIssueQuantity.Width = 85;
            // 
            // colChemicalDyingIssuedValue
            // 
            this.colChemicalDyingIssuedValue.DataPropertyName = "DyingIssuedValue";
            this.colChemicalDyingIssuedValue.HeaderText = "Issued Value";
            this.colChemicalDyingIssuedValue.Name = "colChemicalDyingIssuedValue";
            this.colChemicalDyingIssuedValue.ReadOnly = true;
            this.colChemicalDyingIssuedValue.Width = 85;
            // 
            // colChemicalRedyingIssueQuantity
            // 
            this.colChemicalRedyingIssueQuantity.DataPropertyName = "ReDyingIssuedQuantity";
            this.colChemicalRedyingIssueQuantity.HeaderText = "ReDying";
            this.colChemicalRedyingIssueQuantity.Name = "colChemicalRedyingIssueQuantity";
            this.colChemicalRedyingIssueQuantity.Width = 85;
            // 
            // colChemicalRedyingIssuedValue
            // 
            this.colChemicalRedyingIssuedValue.DataPropertyName = "ReDyingIssuedValue";
            this.colChemicalRedyingIssuedValue.HeaderText = "Issued Value";
            this.colChemicalRedyingIssuedValue.Name = "colChemicalRedyingIssuedValue";
            this.colChemicalRedyingIssuedValue.ReadOnly = true;
            this.colChemicalRedyingIssuedValue.Width = 85;
            // 
            // colChemicalQtyStock
            // 
            this.colChemicalQtyStock.DataPropertyName = "CurrentQuantity";
            this.colChemicalQtyStock.HeaderText = "Qty Stock";
            this.colChemicalQtyStock.Name = "colChemicalQtyStock";
            this.colChemicalQtyStock.ReadOnly = true;
            this.colChemicalQtyStock.Visible = false;
            this.colChemicalQtyStock.Width = 85;
            // 
            // colChemicalCurrentValue
            // 
            this.colChemicalCurrentValue.DataPropertyName = "CurrentValue";
            dataGridViewCellStyle2.NullValue = "2.2";
            this.colChemicalCurrentValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.colChemicalCurrentValue.HeaderText = "Current Value";
            this.colChemicalCurrentValue.Name = "colChemicalCurrentValue";
            this.colChemicalCurrentValue.ReadOnly = true;
            this.colChemicalCurrentValue.Visible = false;
            this.colChemicalCurrentValue.Width = 85;
            // 
            // grdLotDetail
            // 
            this.grdLotDetail.AllowUserToAddRows = false;
            this.grdLotDetail.AllowUserToDeleteRows = false;
            this.grdLotDetail.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLotDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdLotDetail.ColumnHeadersHeight = 30;
            this.grdLotDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProcessName,
            this.colAccountName,
            this.colQuality,
            this.colQty,
            this.colAmount});
            this.grdLotDetail.EnableHeadersVisualStyles = false;
            this.grdLotDetail.Location = new System.Drawing.Point(19, 77);
            this.grdLotDetail.Name = "grdLotDetail";
            this.grdLotDetail.ReadOnly = true;
            this.grdLotDetail.RowHeadersVisible = false;
            this.grdLotDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLotDetail.Size = new System.Drawing.Size(664, 254);
            this.grdLotDetail.TabIndex = 12;
            // 
            // colProcessName
            // 
            this.colProcessName.DataPropertyName = "ProcessName";
            this.colProcessName.HeaderText = "Work Type";
            this.colProcessName.Name = "colProcessName";
            this.colProcessName.ReadOnly = true;
            // 
            // colAccountName
            // 
            this.colAccountName.DataPropertyName = "AccountName";
            this.colAccountName.HeaderText = "Vendor Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 150;
            // 
            // colQuality
            // 
            this.colQuality.DataPropertyName = "ItemName";
            this.colQuality.HeaderText = "Quality";
            this.colQuality.Name = "colQuality";
            this.colQuality.ReadOnly = true;
            this.colQuality.Width = 210;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Cutting";
            this.colQty.HeaderText = "Quantity";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            this.colQty.Width = 90;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // frmLotDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 616);
            this.Controls.Add(this.grdChemicals);
            this.Controls.Add(this.grdLotDetail);
            this.Controls.Add(this.metroLabel2);
            this.Name = "frmLotDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lot Detail";
            this.Load += new System.EventHandler(this.frmLotDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdChemicals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLotDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomDataGrid grdLotDetail;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private TabDataGrid grdChemicals;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdChemical;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalCrustIssueQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalCrustIssuedValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalDyingIssueQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalDyingIssuedValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalRedyingIssueQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalRedyingIssuedValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalQtyStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChemicalCurrentValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuality;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}