namespace Accounts.UI
{
    partial class frmFindGroups
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
            this.grdFindGroups = new Accounts.UI.CustomDataGrid();
            this.colIdGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdFindGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(27, 60);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(396, 20);
            this.txtID.TabIndex = 5;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // grdFindGroups
            // 
            this.grdFindGroups.AllowUserToAddRows = false;
            this.grdFindGroups.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdFindGroups.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFindGroups.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFindGroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdFindGroups.ColumnHeadersHeight = 25;
            this.grdFindGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdGroup,
            this.colGroupCode,
            this.colGroupName});
            this.grdFindGroups.EnableHeadersVisualStyles = false;
            this.grdFindGroups.Location = new System.Drawing.Point(27, 86);
            this.grdFindGroups.MultiSelect = false;
            this.grdFindGroups.Name = "grdFindGroups";
            this.grdFindGroups.ReadOnly = true;
            this.grdFindGroups.RowHeadersVisible = false;
            this.grdFindGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFindGroups.Size = new System.Drawing.Size(396, 321);
            this.grdFindGroups.TabIndex = 6;
            this.grdFindGroups.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFindGroup_CellDoubleClick);
            this.grdFindGroups.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdFindGroup_KeyPress);
            // 
            // colIdGroup
            // 
            this.colIdGroup.DataPropertyName = "IdGroup";
            this.colIdGroup.HeaderText = "IdGroup";
            this.colIdGroup.Name = "colIdGroup";
            this.colIdGroup.ReadOnly = true;
            this.colIdGroup.Visible = false;
            // 
            // colGroupCode
            // 
            this.colGroupCode.DataPropertyName = "GroupCode";
            this.colGroupCode.HeaderText = "Group Code";
            this.colGroupCode.Name = "colGroupCode";
            this.colGroupCode.ReadOnly = true;
            this.colGroupCode.Width = 150;
            // 
            // colGroupName
            // 
            this.colGroupName.DataPropertyName = "GroupName";
            this.colGroupName.HeaderText = "Group Name";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.ReadOnly = true;
            this.colGroupName.Width = 230;
            // 
            // frmFindGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 433);
            this.Controls.Add(this.grdFindGroups);
            this.Controls.Add(this.txtID);
            this.Name = "frmFindGroups";
            this.Text = "Find Groups";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFindGroups_FormClosing);
            this.Load += new System.EventHandler(this.frmFindGroups_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmFindGroups_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grdFindGroups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private CustomDataGrid grdFindGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupName;
    }
}