namespace Accounts.UI
{
    partial class frmGroupsSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroupsSetup));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkActive = new MetroFramework.Controls.MetroCheckBox();
            this.BrandDate = new System.Windows.Forms.DateTimePicker();
            this.txtGroupName = new MetroFramework.Controls.MetroTextBox();
            this.txtGroupCode = new MetroFramework.Controls.MetroTextBox();
            this.BrandCreatedDate = new MetroFramework.Controls.MetroLabel();
            this.lblGroupName = new MetroFramework.Controls.MetroLabel();
            this.lblGroupCode = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtSearchStock = new MetroFramework.Controls.MetroTextBox();
            this.btnAddItems = new MetroFramework.Controls.MetroButton();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.btnClear = new MetroFramework.Controls.MetroTile();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.btnSearch = new MetroFramework.Controls.MetroTile();
            this.btnSaveGroupItems = new MetroFramework.Controls.MetroTile();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.chkMandatory = new MetroFramework.Controls.MetroCheckBox();
            this.grdGroupItems = new Accounts.UI.CustomDataGrid();
            this.colIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackingSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupItems)).BeginInit();
            this.SuspendLayout();
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(130, 167);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 15);
            this.chkActive.TabIndex = 22;
            this.chkActive.Text = "Active";
            this.chkActive.UseSelectable = true;
            // 
            // BrandDate
            // 
            this.BrandDate.Location = new System.Drawing.Point(130, 135);
            this.BrandDate.Name = "BrandDate";
            this.BrandDate.Size = new System.Drawing.Size(277, 20);
            this.BrandDate.TabIndex = 21;
            // 
            // txtGroupName
            // 
            // 
            // 
            // 
            this.txtGroupName.CustomButton.Image = null;
            this.txtGroupName.CustomButton.Location = new System.Drawing.Point(255, 1);
            this.txtGroupName.CustomButton.Name = "";
            this.txtGroupName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtGroupName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtGroupName.CustomButton.TabIndex = 1;
            this.txtGroupName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtGroupName.CustomButton.UseSelectable = true;
            this.txtGroupName.CustomButton.Visible = false;
            this.txtGroupName.Lines = new string[0];
            this.txtGroupName.Location = new System.Drawing.Point(130, 103);
            this.txtGroupName.MaxLength = 32767;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.PasswordChar = '\0';
            this.txtGroupName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtGroupName.SelectedText = "";
            this.txtGroupName.SelectionLength = 0;
            this.txtGroupName.SelectionStart = 0;
            this.txtGroupName.ShortcutsEnabled = true;
            this.txtGroupName.Size = new System.Drawing.Size(277, 23);
            this.txtGroupName.TabIndex = 20;
            this.txtGroupName.UseSelectable = true;
            this.txtGroupName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtGroupName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtGroupCode
            // 
            // 
            // 
            // 
            this.txtGroupCode.CustomButton.Image = null;
            this.txtGroupCode.CustomButton.Location = new System.Drawing.Point(147, 1);
            this.txtGroupCode.CustomButton.Name = "";
            this.txtGroupCode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtGroupCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtGroupCode.CustomButton.TabIndex = 1;
            this.txtGroupCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtGroupCode.CustomButton.UseSelectable = true;
            this.txtGroupCode.CustomButton.Visible = false;
            this.txtGroupCode.Lines = new string[0];
            this.txtGroupCode.Location = new System.Drawing.Point(130, 74);
            this.txtGroupCode.MaxLength = 32767;
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.PasswordChar = '\0';
            this.txtGroupCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtGroupCode.SelectedText = "";
            this.txtGroupCode.SelectionLength = 0;
            this.txtGroupCode.SelectionStart = 0;
            this.txtGroupCode.ShortcutsEnabled = true;
            this.txtGroupCode.Size = new System.Drawing.Size(169, 23);
            this.txtGroupCode.TabIndex = 19;
            this.txtGroupCode.UseSelectable = true;
            this.txtGroupCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtGroupCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // BrandCreatedDate
            // 
            this.BrandCreatedDate.AutoSize = true;
            this.BrandCreatedDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.BrandCreatedDate.Location = new System.Drawing.Point(20, 133);
            this.BrandCreatedDate.Name = "BrandCreatedDate";
            this.BrandCreatedDate.Size = new System.Drawing.Size(87, 19);
            this.BrandCreatedDate.TabIndex = 17;
            this.BrandCreatedDate.Text = "Created On :";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblGroupName.Location = new System.Drawing.Point(22, 103);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(95, 19);
            this.lblGroupName.TabIndex = 16;
            this.lblGroupName.Text = "Group Name :";
            // 
            // lblGroupCode
            // 
            this.lblGroupCode.AutoSize = true;
            this.lblGroupCode.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblGroupCode.Location = new System.Drawing.Point(20, 74);
            this.lblGroupCode.Name = "lblGroupCode";
            this.lblGroupCode.Size = new System.Drawing.Size(91, 19);
            this.lblGroupCode.TabIndex = 18;
            this.lblGroupCode.Text = "Group Code :";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(570, 24);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(172, 25);
            this.metroLabel1.TabIndex = 18;
            this.metroLabel1.Text = "Add Group Items  :";
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
            this.txtSearchStock.Location = new System.Drawing.Point(570, 74);
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
            this.txtSearchStock.TabIndex = 49;
            this.txtSearchStock.UseSelectable = true;
            this.txtSearchStock.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSearchStock.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearchStock.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtSearchStock_ButtonClick);
            // 
            // btnAddItems
            // 
            this.btnAddItems.Location = new System.Drawing.Point(949, 74);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(101, 23);
            this.btnAddItems.TabIndex = 50;
            this.btnAddItems.Text = "Add Item";
            this.btnAddItems.UseSelectable = true;
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.Location = new System.Drawing.Point(444, 193);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 84);
            this.btnClose.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.TileImage = ((System.Drawing.Image)(resources.GetObject("btnClose.TileImage")));
            this.btnClose.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseSelectable = true;
            this.btnClose.UseTileImage = true;
            // 
            // btnClear
            // 
            this.btnClear.ActiveControl = null;
            this.btnClear.Location = new System.Drawing.Point(970, 287);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(159, 84);
            this.btnClear.Style = MetroFramework.MetroColorStyle.Green;
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear Items";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.TileImage = ((System.Drawing.Image)(resources.GetObject("btnClear.TileImage")));
            this.btnClear.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClear.UseSelectable = true;
            this.btnClear.UseTileImage = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ActiveControl = null;
            this.btnDelete.Location = new System.Drawing.Point(232, 193);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 84);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.TileImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.TileImage")));
            this.btnDelete.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.UseTileImage = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ActiveControl = null;
            this.btnSearch.Location = new System.Drawing.Point(338, 193);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 84);
            this.btnSearch.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.TileImage")));
            this.btnSearch.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.UseSelectable = true;
            this.btnSearch.UseTileImage = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSaveGroupItems
            // 
            this.btnSaveGroupItems.ActiveControl = null;
            this.btnSaveGroupItems.Location = new System.Drawing.Point(791, 287);
            this.btnSaveGroupItems.Name = "btnSaveGroupItems";
            this.btnSaveGroupItems.Size = new System.Drawing.Size(177, 84);
            this.btnSaveGroupItems.Style = MetroFramework.MetroColorStyle.Green;
            this.btnSaveGroupItems.TabIndex = 23;
            this.btnSaveGroupItems.Text = "Save Group Items";
            this.btnSaveGroupItems.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveGroupItems.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSaveGroupItems.TileImage")));
            this.btnSaveGroupItems.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveGroupItems.UseSelectable = true;
            this.btnSaveGroupItems.UseTileImage = true;
            this.btnSaveGroupItems.Click += new System.EventHandler(this.btnSaveGroupItems_Click);
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(126, 193);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 84);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSave.TileImage")));
            this.btnSave.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseSelectable = true;
            this.btnSave.UseTileImage = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkMandatory
            // 
            this.chkMandatory.AutoSize = true;
            this.chkMandatory.Location = new System.Drawing.Point(202, 167);
            this.chkMandatory.Name = "chkMandatory";
            this.chkMandatory.Size = new System.Drawing.Size(81, 15);
            this.chkMandatory.TabIndex = 22;
            this.chkMandatory.Text = "Mandatory";
            this.chkMandatory.UseSelectable = true;
            // 
            // grdGroupItems
            // 
            this.grdGroupItems.AllowUserToAddRows = false;
            this.grdGroupItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdGroupItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdGroupItems.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdGroupItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdGroupItems.ColumnHeadersHeight = 25;
            this.grdGroupItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdItem,
            this.colItemCode,
            this.colPackingSize,
            this.colName,
            this.colDelete});
            this.grdGroupItems.EnableHeadersVisualStyles = false;
            this.grdGroupItems.Location = new System.Drawing.Point(570, 103);
            this.grdGroupItems.MultiSelect = false;
            this.grdGroupItems.Name = "grdGroupItems";
            this.grdGroupItems.ReadOnly = true;
            this.grdGroupItems.RowHeadersVisible = false;
            this.grdGroupItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdGroupItems.Size = new System.Drawing.Size(582, 174);
            this.grdGroupItems.TabIndex = 27;
            this.grdGroupItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdGroupItems_CellClick);
            this.grdGroupItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdGroupItems_CellFormatting);
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
            // frmGroupsSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 394);
            this.Controls.Add(this.btnAddItems);
            this.Controls.Add(this.txtSearchStock);
            this.Controls.Add(this.grdGroupItems);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSaveGroupItems);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkMandatory);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.BrandDate);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.txtGroupCode);
            this.Controls.Add(this.BrandCreatedDate);
            this.Controls.Add(this.lblGroupName);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.lblGroupCode);
            this.Name = "frmGroupsSetup";
            this.Text = "Groups Setup";
            this.Load += new System.EventHandler(this.frmGroupsSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnClose;
        private MetroFramework.Controls.MetroTile btnDelete;
        private MetroFramework.Controls.MetroTile btnSearch;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroCheckBox chkActive;
        private System.Windows.Forms.DateTimePicker BrandDate;
        private MetroFramework.Controls.MetroTextBox txtGroupName;
        private MetroFramework.Controls.MetroTextBox txtGroupCode;
        private MetroFramework.Controls.MetroLabel BrandCreatedDate;
        private MetroFramework.Controls.MetroLabel lblGroupName;
        private MetroFramework.Controls.MetroLabel lblGroupCode;
        private CustomDataGrid grdGroupItems;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtSearchStock;
        private MetroFramework.Controls.MetroButton btnAddItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private MetroFramework.Controls.MetroTile btnSaveGroupItems;
        private MetroFramework.Controls.MetroTile btnClear;
        private MetroFramework.Controls.MetroCheckBox chkMandatory;
    }
}