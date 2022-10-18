namespace Accounts.UI
{
    partial class frmCurrentStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrentStock));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.CbxCategories = new MetroFramework.Controls.MetroComboBox();
            this.lblProductDiscription = new MetroFramework.Controls.MetroLabel();
            this.grdCurrentStock = new Accounts.UI.TabDataGrid();
            this.lblSearch = new MetroFramework.Controls.MetroLabel();
            this.txtsearch = new MetroFramework.Controls.MetroTextBox();
            this.colIdCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrentStock)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSave.Location = new System.Drawing.Point(716, 417);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 84);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Green;
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSave.TileImage")));
            this.btnSave.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseCustomBackColor = true;
            this.btnSave.UseSelectable = true;
            this.btnSave.UseTileImage = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CbxCategories
            // 
            this.CbxCategories.FormattingEnabled = true;
            this.CbxCategories.ItemHeight = 23;
            this.CbxCategories.Location = new System.Drawing.Point(108, 74);
            this.CbxCategories.Name = "CbxCategories";
            this.CbxCategories.Size = new System.Drawing.Size(322, 29);
            this.CbxCategories.TabIndex = 15;
            this.CbxCategories.UseSelectable = true;
            this.CbxCategories.SelectedIndexChanged += new System.EventHandler(this.CbxCategories_SelectedIndexChanged);
            // 
            // lblProductDiscription
            // 
            this.lblProductDiscription.AutoSize = true;
            this.lblProductDiscription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblProductDiscription.Location = new System.Drawing.Point(33, 77);
            this.lblProductDiscription.Name = "lblProductDiscription";
            this.lblProductDiscription.Size = new System.Drawing.Size(72, 19);
            this.lblProductDiscription.TabIndex = 25;
            this.lblProductDiscription.Text = "Category :";
            // 
            // grdCurrentStock
            // 
            this.grdCurrentStock.AllowUserToAddRows = false;
            this.grdCurrentStock.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCurrentStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCurrentStock.ColumnHeadersHeight = 26;
            this.grdCurrentStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCurrentStock,
            this.colIdItem,
            this.colBatchNo,
            this.colItemName,
            this.colPackingSize,
            this.colUnits,
            this.colUnitPrice,
            this.colTotalAmount});
            this.grdCurrentStock.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdCurrentStock.EnableHeadersVisualStyles = false;
            this.grdCurrentStock.Location = new System.Drawing.Point(23, 120);
            this.grdCurrentStock.Name = "grdCurrentStock";
            this.grdCurrentStock.RowHeadersVisible = false;
            this.grdCurrentStock.Size = new System.Drawing.Size(798, 291);
            this.grdCurrentStock.TabIndex = 13;
            this.grdCurrentStock.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCurrentStock_CellEndEdit);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(441, 78);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(90, 19);
            this.lblSearch.TabIndex = 27;
            this.lblSearch.Text = "Search Stock :";
            // 
            // txtsearch
            // 
            // 
            // 
            // 
            this.txtsearch.CustomButton.Image = null;
            this.txtsearch.CustomButton.Location = new System.Drawing.Point(256, 1);
            this.txtsearch.CustomButton.Name = "";
            this.txtsearch.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtsearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtsearch.CustomButton.TabIndex = 1;
            this.txtsearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtsearch.CustomButton.UseSelectable = true;
            this.txtsearch.CustomButton.Visible = false;
            this.txtsearch.Lines = new string[0];
            this.txtsearch.Location = new System.Drawing.Point(535, 78);
            this.txtsearch.MaxLength = 32767;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PasswordChar = '\0';
            this.txtsearch.PromptText = "Search Here";
            this.txtsearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtsearch.SelectedText = "";
            this.txtsearch.SelectionLength = 0;
            this.txtsearch.SelectionStart = 0;
            this.txtsearch.ShortcutsEnabled = true;
            this.txtsearch.Size = new System.Drawing.Size(278, 23);
            this.txtsearch.TabIndex = 26;
            this.txtsearch.UseSelectable = true;
            this.txtsearch.WaterMark = "Search Here";
            this.txtsearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtsearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // colIdCurrentStock
            // 
            this.colIdCurrentStock.DataPropertyName = "IdCurrentStock";
            this.colIdCurrentStock.HeaderText = "IdCurrentStock";
            this.colIdCurrentStock.Name = "colIdCurrentStock";
            this.colIdCurrentStock.Visible = false;
            // 
            // colIdItem
            // 
            this.colIdItem.DataPropertyName = "IdItem";
            this.colIdItem.HeaderText = "IdItem";
            this.colIdItem.Name = "colIdItem";
            this.colIdItem.Visible = false;
            // 
            // colBatchNo
            // 
            this.colBatchNo.DataPropertyName = "ItemNo";
            this.colBatchNo.HeaderText = "Item Code";
            this.colBatchNo.Name = "colBatchNo";
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "ItemName";
            this.colItemName.HeaderText = "Description";
            this.colItemName.Name = "colItemName";
            this.colItemName.Width = 200;
            // 
            // colPackingSize
            // 
            this.colPackingSize.DataPropertyName = "PackingSize";
            this.colPackingSize.HeaderText = "Packing Size";
            this.colPackingSize.Name = "colPackingSize";
            this.colPackingSize.Width = 120;
            // 
            // colUnits
            // 
            this.colUnits.DataPropertyName = "Qty";
            this.colUnits.HeaderText = "Qty";
            this.colUnits.Name = "colUnits";
            this.colUnits.Width = 120;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Width = 150;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.DataPropertyName = "TotalAmount";
            this.colTotalAmount.HeaderText = "TotalAmount";
            this.colTotalAmount.Name = "colTotalAmount";
            // 
            // frmCurrentStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 528);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.lblProductDiscription);
            this.Controls.Add(this.CbxCategories);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdCurrentStock);
            this.Name = "frmCurrentStock";
            this.Text = "Add Current Stock";
            this.Load += new System.EventHandler(this.frmCurrentStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrentStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabDataGrid grdCurrentStock;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroComboBox CbxCategories;
        private MetroFramework.Controls.MetroLabel lblProductDiscription;
        private MetroFramework.Controls.MetroLabel lblSearch;
        private MetroFramework.Controls.MetroTextBox txtsearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
    }
}