namespace Accounts.UI
{
    partial class frmProcessWiseItemStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.grdProcessStock = new Accounts.UI.TabDataGrid();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGatePass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpeningStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcessStock)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(12, 58);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(699, 23);
            this.metroLabel1.TabIndex = 36;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------";
            // 
            // grdProcessStock
            // 
            this.grdProcessStock.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdProcessStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdProcessStock.ColumnHeadersHeight = 28;
            this.grdProcessStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colGatePass,
            this.colOpeningStock,
            this.colIn,
            this.colOut,
            this.colBalance});
            this.grdProcessStock.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdProcessStock.EnableHeadersVisualStyles = false;
            this.grdProcessStock.Location = new System.Drawing.Point(13, 84);
            this.grdProcessStock.Name = "grdProcessStock";
            this.grdProcessStock.ReadOnly = true;
            this.grdProcessStock.RowHeadersVisible = false;
            this.grdProcessStock.Size = new System.Drawing.Size(698, 467);
            this.grdProcessStock.TabIndex = 43;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "Date";
            dataGridViewCellStyle2.Format = "d";
            this.colDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colGatePass
            // 
            this.colGatePass.DataPropertyName = "InWardGatePassNo";
            this.colGatePass.HeaderText = "GatePass #";
            this.colGatePass.Name = "colGatePass";
            this.colGatePass.ReadOnly = true;
            // 
            // colOpeningStock
            // 
            this.colOpeningStock.DataPropertyName = "OpeningStock";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.colOpeningStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.colOpeningStock.HeaderText = "Opening";
            this.colOpeningStock.Name = "colOpeningStock";
            this.colOpeningStock.ReadOnly = true;
            this.colOpeningStock.Width = 120;
            // 
            // colIn
            // 
            this.colIn.DataPropertyName = "StockIn";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.colIn.DefaultCellStyle = dataGridViewCellStyle4;
            this.colIn.HeaderText = "In";
            this.colIn.Name = "colIn";
            this.colIn.ReadOnly = true;
            this.colIn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colIn.Width = 120;
            // 
            // colOut
            // 
            this.colOut.DataPropertyName = "StockOut";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colOut.DefaultCellStyle = dataGridViewCellStyle5;
            this.colOut.HeaderText = "Out";
            this.colOut.Name = "colOut";
            this.colOut.ReadOnly = true;
            this.colOut.Width = 120;
            // 
            // colBalance
            // 
            this.colBalance.DataPropertyName = "Balance";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Yellow;
            this.colBalance.DefaultCellStyle = dataGridViewCellStyle6;
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.ReadOnly = true;
            this.colBalance.Width = 120;
            // 
            // frmProcessWiseItemStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 574);
            this.Controls.Add(this.grdProcessStock);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frmProcessWiseItemStock";
            this.Text = "frmWorkInProcessReport";
            this.Load += new System.EventHandler(this.frmProcessWiseItemStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdProcessStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private TabDataGrid grdProcessStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGatePass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpeningStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
    }
}