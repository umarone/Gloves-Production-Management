namespace Accounts.UI
{
    partial class frmLinkItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLinkItems));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddItems = new MetroFramework.Controls.MetroButton();
            this.txtSearchStock = new MetroFramework.Controls.MetroTextBox();
            this.btnClear = new MetroFramework.Controls.MetroTile();
            this.btnSaveLinkItems = new MetroFramework.Controls.MetroTile();
            this.grdLinkItems = new Accounts.UI.CustomDataGrid();
            this.colIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdLinkItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddItems
            // 
            this.btnAddItems.Location = new System.Drawing.Point(402, 76);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(101, 23);
            this.btnAddItems.TabIndex = 55;
            this.btnAddItems.Text = "Add Item";
            this.btnAddItems.UseSelectable = true;
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            // 
            // txtSearchStock
            // 
            // 
            // 
            // 
            this.txtSearchStock.CustomButton.Image = null;
            this.txtSearchStock.CustomButton.Location = new System.Drawing.Point(350, 1);
            this.txtSearchStock.CustomButton.Name = "";
            this.txtSearchStock.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSearchStock.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSearchStock.CustomButton.TabIndex = 1;
            this.txtSearchStock.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSearchStock.CustomButton.UseSelectable = true;
            this.txtSearchStock.Lines = new string[0];
            this.txtSearchStock.Location = new System.Drawing.Point(23, 76);
            this.txtSearchStock.MaxLength = 32767;
            this.txtSearchStock.Name = "txtSearchStock";
            this.txtSearchStock.PasswordChar = '\0';
            this.txtSearchStock.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearchStock.SelectedText = "";
            this.txtSearchStock.SelectionLength = 0;
            this.txtSearchStock.SelectionStart = 0;
            this.txtSearchStock.ShortcutsEnabled = true;
            this.txtSearchStock.ShowButton = true;
            this.txtSearchStock.Size = new System.Drawing.Size(372, 23);
            this.txtSearchStock.Style = MetroFramework.MetroColorStyle.Green;
            this.txtSearchStock.TabIndex = 54;
            this.txtSearchStock.UseSelectable = true;
            this.txtSearchStock.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSearchStock.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnClear
            // 
            this.btnClear.ActiveControl = null;
            this.btnClear.Location = new System.Drawing.Point(447, 331);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(159, 84);
            this.btnClear.Style = MetroFramework.MetroColorStyle.Green;
            this.btnClear.TabIndex = 52;
            this.btnClear.Text = "Clear Items";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.TileImage = ((System.Drawing.Image)(resources.GetObject("btnClear.TileImage")));
            this.btnClear.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClear.UseSelectable = true;
            this.btnClear.UseTileImage = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSaveLinkItems
            // 
            this.btnSaveLinkItems.ActiveControl = null;
            this.btnSaveLinkItems.Location = new System.Drawing.Point(268, 331);
            this.btnSaveLinkItems.Name = "btnSaveLinkItems";
            this.btnSaveLinkItems.Size = new System.Drawing.Size(177, 84);
            this.btnSaveLinkItems.Style = MetroFramework.MetroColorStyle.Green;
            this.btnSaveLinkItems.TabIndex = 51;
            this.btnSaveLinkItems.Text = "Save Link Items";
            this.btnSaveLinkItems.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveLinkItems.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSaveLinkItems.TileImage")));
            this.btnSaveLinkItems.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveLinkItems.UseSelectable = true;
            this.btnSaveLinkItems.UseTileImage = true;
            this.btnSaveLinkItems.Click += new System.EventHandler(this.btnSaveLinkItems_Click);
            // 
            // grdLinkItems
            // 
            this.grdLinkItems.AllowUserToAddRows = false;
            this.grdLinkItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdLinkItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLinkItems.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLinkItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdLinkItems.ColumnHeadersHeight = 25;
            this.grdLinkItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdItem,
            this.colItemCode,
            this.colPackingSize,
            this.colName,
            this.colDelete});
            this.grdLinkItems.EnableHeadersVisualStyles = false;
            this.grdLinkItems.Location = new System.Drawing.Point(23, 105);
            this.grdLinkItems.MultiSelect = false;
            this.grdLinkItems.Name = "grdLinkItems";
            this.grdLinkItems.ReadOnly = true;
            this.grdLinkItems.RowHeadersVisible = false;
            this.grdLinkItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLinkItems.Size = new System.Drawing.Size(582, 220);
            this.grdLinkItems.TabIndex = 53;
            this.grdLinkItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLinkItems_CellClick);
            this.grdLinkItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdLinkItems_CellFormatting);
            // 
            // colIdItem
            // 
            this.colIdItem.DataPropertyName = "IdItem";
            this.colIdItem.HeaderText = "IdItem";
            this.colIdItem.Name = "colIdItem";
            this.colIdItem.ReadOnly = true;
            this.colIdItem.Visible = false;
            // 
            // colItemCode
            // 
            this.colItemCode.DataPropertyName = "ItemNo";
            this.colItemCode.HeaderText = "Item Code";
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.ReadOnly = true;
            this.colItemCode.Width = 125;
            // 
            // colPackingSize
            // 
            this.colPackingSize.DataPropertyName = "PackingSize";
            this.colPackingSize.HeaderText = "UOM";
            this.colPackingSize.Name = "colPackingSize";
            this.colPackingSize.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "ItemName";
            this.colName.HeaderText = "Product Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 250;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "....";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            // 
            // frmLinkItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 464);
            this.Controls.Add(this.btnAddItems);
            this.Controls.Add(this.txtSearchStock);
            this.Controls.Add(this.grdLinkItems);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSaveLinkItems);
            this.Name = "frmLinkItems";
            this.Text = "frmLinkItems";
            this.Load += new System.EventHandler(this.frmLinkItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdLinkItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnAddItems;
        private MetroFramework.Controls.MetroTextBox txtSearchStock;
        private CustomDataGrid grdLinkItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private MetroFramework.Controls.MetroTile btnClear;
        private MetroFramework.Controls.MetroTile btnSaveLinkItems;
    }
}