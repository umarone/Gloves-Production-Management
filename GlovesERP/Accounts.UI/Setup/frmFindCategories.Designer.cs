namespace Accounts.UI
{
    partial class frmFindCategories
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtID = new System.Windows.Forms.TextBox();
            this.grdFindCategories = new Accounts.UI.CustomDataGrid();
            this.colIdCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdFindCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(23, 73);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(544, 20);
            this.txtID.TabIndex = 4;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // grdFindCategories
            // 
            this.grdFindCategories.AllowUserToAddRows = false;
            this.grdFindCategories.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdFindCategories.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdFindCategories.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFindCategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdFindCategories.ColumnHeadersHeight = 25;
            this.grdFindCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCategory,
            this.colCategoryCode,
            this.colDiscription});
            this.grdFindCategories.EnableHeadersVisualStyles = false;
            this.grdFindCategories.Location = new System.Drawing.Point(23, 99);
            this.grdFindCategories.MultiSelect = false;
            this.grdFindCategories.Name = "grdFindCategories";
            this.grdFindCategories.ReadOnly = true;
            this.grdFindCategories.RowHeadersVisible = false;
            this.grdFindCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFindCategories.Size = new System.Drawing.Size(544, 348);
            this.grdFindCategories.TabIndex = 5;
            this.grdFindCategories.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFindCategories_CellDoubleClick);
            this.grdFindCategories.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdFindCategories_KeyPress);
            // 
            // colIdCategory
            // 
            this.colIdCategory.DataPropertyName = "IdCategory";
            this.colIdCategory.HeaderText = "IdCategory";
            this.colIdCategory.Name = "colIdCategory";
            this.colIdCategory.ReadOnly = true;
            this.colIdCategory.Visible = false;
            // 
            // colCategoryCode
            // 
            this.colCategoryCode.DataPropertyName = "CategoryCode";
            this.colCategoryCode.HeaderText = "Category Code";
            this.colCategoryCode.Name = "colCategoryCode";
            this.colCategoryCode.ReadOnly = true;
            this.colCategoryCode.Width = 250;
            // 
            // colDiscription
            // 
            this.colDiscription.DataPropertyName = "CategoryName";
            this.colDiscription.HeaderText = "Discription";
            this.colDiscription.Name = "colDiscription";
            this.colDiscription.ReadOnly = true;
            this.colDiscription.Width = 275;
            // 
            // frmFindCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 450);
            this.Controls.Add(this.grdFindCategories);
            this.Controls.Add(this.txtID);
            this.KeyPreview = true;
            this.Name = "frmFindCategories";
            this.Text = "Find Categories";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFindCategories_FormClosing);
            this.Load += new System.EventHandler(this.frmFindCategories_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmFindCategories_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grdFindCategories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private CustomDataGrid grdFindCategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscription;
    }
}