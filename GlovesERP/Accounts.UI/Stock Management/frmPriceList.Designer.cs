namespace Accounts.UI
{
    partial class frmPriceList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvPriceList = new System.Windows.Forms.DataGridView();
            this.colItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPriceList = new System.Windows.Forms.Panel();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.btnPrint = new MetroFramework.Controls.MetroTile();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPriceList)).BeginInit();
            this.pnlPriceList.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvPriceList
            // 
            this.DgvPriceList.AllowUserToAddRows = false;
            this.DgvPriceList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvPriceList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvPriceList.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPriceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvPriceList.ColumnHeadersHeight = 26;
            this.DgvPriceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemNo,
            this.colItemName,
            this.colItemSize,
            this.colDescription,
            this.colUnitPrice});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvPriceList.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvPriceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPriceList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DgvPriceList.EnableHeadersVisualStyles = false;
            this.DgvPriceList.Location = new System.Drawing.Point(0, 0);
            this.DgvPriceList.Name = "DgvPriceList";
            this.DgvPriceList.RowHeadersVisible = false;
            this.DgvPriceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPriceList.Size = new System.Drawing.Size(764, 277);
            this.DgvPriceList.TabIndex = 0;
            // 
            // colItemNo
            // 
            this.colItemNo.DataPropertyName = "ItemNo";
            this.colItemNo.FillWeight = 203.0457F;
            this.colItemNo.HeaderText = "Product No.";
            this.colItemNo.Name = "colItemNo";
            this.colItemNo.Width = 90;
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "ItemName";
            this.colItemName.FillWeight = 37.58076F;
            this.colItemName.HeaderText = "Product Name";
            this.colItemName.Name = "colItemName";
            this.colItemName.Width = 150;
            // 
            // colItemSize
            // 
            this.colItemSize.DataPropertyName = "packingsize";
            this.colItemSize.HeaderText = "Product Size";
            this.colItemSize.Name = "colItemSize";
            this.colItemSize.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.FillWeight = 55.31648F;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 300;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            this.colUnitPrice.FillWeight = 104.0571F;
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            // 
            // pnlPriceList
            // 
            this.pnlPriceList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPriceList.Controls.Add(this.DgvPriceList);
            this.pnlPriceList.Location = new System.Drawing.Point(0, 64);
            this.pnlPriceList.Name = "pnlPriceList";
            this.pnlPriceList.Size = new System.Drawing.Size(766, 279);
            this.pnlPriceList.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(444, 348);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 46);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ActiveControl = null;
            this.btnPrint.Location = new System.Drawing.Point(552, 348);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(106, 46);
            this.btnPrint.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.UseSelectable = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.Location = new System.Drawing.Point(659, 348);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 46);
            this.btnClose.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 406);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlPriceList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPriceList";
            this.Text = "Price List";
            this.Load += new System.EventHandler(this.frmPriceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPriceList)).EndInit();
            this.pnlPriceList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPriceList;
        private System.Windows.Forms.Panel pnlPriceList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroTile btnPrint;
        private MetroFramework.Controls.MetroTile btnClose;
    }
}