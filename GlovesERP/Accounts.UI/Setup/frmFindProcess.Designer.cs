namespace Accounts.UI
{
    partial class frmFindProcess
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
            this.grdFindProcesses = new Accounts.UI.CustomDataGrid();
            this.txtID = new System.Windows.Forms.TextBox();
            this.colIdProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdFindProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // grdFindProcesses
            // 
            this.grdFindProcesses.AllowUserToAddRows = false;
            this.grdFindProcesses.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdFindProcesses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFindProcesses.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFindProcesses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdFindProcesses.ColumnHeadersHeight = 25;
            this.grdFindProcesses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdProcess,
            this.colProcessCode,
            this.colDiscription});
            this.grdFindProcesses.EnableHeadersVisualStyles = false;
            this.grdFindProcesses.Location = new System.Drawing.Point(4, 105);
            this.grdFindProcesses.MultiSelect = false;
            this.grdFindProcesses.Name = "grdFindProcesses";
            this.grdFindProcesses.ReadOnly = true;
            this.grdFindProcesses.RowHeadersVisible = false;
            this.grdFindProcesses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFindProcesses.Size = new System.Drawing.Size(544, 346);
            this.grdFindProcesses.TabIndex = 9;
            this.grdFindProcesses.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFindProcesses_CellDoubleClick);
            this.grdFindProcesses.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdFindProcesses_KeyPress);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(4, 77);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(544, 20);
            this.txtID.TabIndex = 8;
            // 
            // colIdProcess
            // 
            this.colIdProcess.DataPropertyName = "IdProcess";
            this.colIdProcess.HeaderText = "IdProcess";
            this.colIdProcess.Name = "colIdProcess";
            this.colIdProcess.ReadOnly = true;
            this.colIdProcess.Visible = false;
            // 
            // colProcessCode
            // 
            this.colProcessCode.DataPropertyName = "ProcessCode";
            this.colProcessCode.HeaderText = "Process Code";
            this.colProcessCode.Name = "colProcessCode";
            this.colProcessCode.ReadOnly = true;
            this.colProcessCode.Width = 250;
            // 
            // colDiscription
            // 
            this.colDiscription.DataPropertyName = "ProcessName";
            this.colDiscription.HeaderText = "Discription";
            this.colDiscription.Name = "colDiscription";
            this.colDiscription.ReadOnly = true;
            this.colDiscription.Width = 275;
            // 
            // frmFindProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 476);
            this.Controls.Add(this.grdFindProcesses);
            this.Controls.Add(this.txtID);
            this.Name = "frmFindProcess";
            this.Text = "Find Processes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFindProcess_FormClosing);
            this.Load += new System.EventHandler(this.frmFindProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdFindProcesses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomDataGrid grdFindProcesses;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscription;
    }
}