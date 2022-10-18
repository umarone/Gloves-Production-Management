namespace Accounts.UI
{
    partial class frmFindBrand
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.grdFindBrand = new Accounts.UI.CustomDataGrid();
            this.colIdBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrandCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrandCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrandDiscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdFindBrand)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(27, 60);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(564, 20);
            this.txtID.TabIndex = 5;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // grdFindBrand
            // 
            this.grdFindBrand.AllowUserToAddRows = false;
            this.grdFindBrand.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdFindBrand.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFindBrand.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFindBrand.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdFindBrand.ColumnHeadersHeight = 25;
            this.grdFindBrand.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdBrand,
            this.colBrandCode,
            this.colBrandCustomer,
            this.colBrandDiscription});
            this.grdFindBrand.EnableHeadersVisualStyles = false;
            this.grdFindBrand.Location = new System.Drawing.Point(27, 86);
            this.grdFindBrand.MultiSelect = false;
            this.grdFindBrand.Name = "grdFindBrand";
            this.grdFindBrand.ReadOnly = true;
            this.grdFindBrand.RowHeadersVisible = false;
            this.grdFindBrand.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFindBrand.Size = new System.Drawing.Size(564, 321);
            this.grdFindBrand.TabIndex = 6;
            this.grdFindBrand.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFindBrand_CellDoubleClick);
            this.grdFindBrand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdFindBrand_KeyPress);
            // 
            // colIdBrand
            // 
            this.colIdBrand.DataPropertyName = "IdBrand";
            this.colIdBrand.HeaderText = "IdCategory";
            this.colIdBrand.Name = "colIdBrand";
            this.colIdBrand.ReadOnly = true;
            this.colIdBrand.Visible = false;
            // 
            // colBrandCode
            // 
            this.colBrandCode.DataPropertyName = "BrandCode";
            this.colBrandCode.HeaderText = "Category Code";
            this.colBrandCode.Name = "colBrandCode";
            this.colBrandCode.ReadOnly = true;
            this.colBrandCode.Width = 150;
            // 
            // colBrandCustomer
            // 
            this.colBrandCustomer.DataPropertyName = "AccountName";
            this.colBrandCustomer.HeaderText = "Customer";
            this.colBrandCustomer.Name = "colBrandCustomer";
            this.colBrandCustomer.ReadOnly = true;
            this.colBrandCustomer.Width = 180;
            // 
            // colBrandDiscription
            // 
            this.colBrandDiscription.DataPropertyName = "BrandName";
            this.colBrandDiscription.HeaderText = "Brand Name";
            this.colBrandDiscription.Name = "colBrandDiscription";
            this.colBrandDiscription.ReadOnly = true;
            this.colBrandDiscription.Width = 230;
            // 
            // frmFindBrand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 433);
            this.Controls.Add(this.grdFindBrand);
            this.Controls.Add(this.txtID);
            this.Name = "frmFindBrand";
            this.Text = "Find Brands";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFindBrand_FormClosing);
            this.Load += new System.EventHandler(this.frmFindBrand_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFindBrand_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmFindBrand_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grdFindBrand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private CustomDataGrid grdFindBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrandCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrandCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrandDiscription;
    }
}