namespace Accounts.UI
{
    partial class frmFindTradingCo
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
            this.grdFindTradingCo = new Accounts.UI.CustomDataGrid();
            this.txtID = new System.Windows.Forms.TextBox();
            this.colIdTrading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTradingCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdFindTradingCo)).BeginInit();
            this.SuspendLayout();
            // 
            // grdFindTradingCo
            // 
            this.grdFindTradingCo.AllowUserToAddRows = false;
            this.grdFindTradingCo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdFindTradingCo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdFindTradingCo.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFindTradingCo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdFindTradingCo.ColumnHeadersHeight = 25;
            this.grdFindTradingCo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdTrading,
            this.colTradingCode,
            this.colDiscription});
            this.grdFindTradingCo.EnableHeadersVisualStyles = false;
            this.grdFindTradingCo.Location = new System.Drawing.Point(6, 96);
            this.grdFindTradingCo.MultiSelect = false;
            this.grdFindTradingCo.Name = "grdFindTradingCo";
            this.grdFindTradingCo.ReadOnly = true;
            this.grdFindTradingCo.RowHeadersVisible = false;
            this.grdFindTradingCo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFindTradingCo.Size = new System.Drawing.Size(544, 348);
            this.grdFindTradingCo.TabIndex = 7;
            this.grdFindTradingCo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFindTradingCo_CellDoubleClick);
            this.grdFindTradingCo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdFindTradingCo_KeyPress);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(6, 70);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(544, 20);
            this.txtID.TabIndex = 6;
            // 
            // colIdTrading
            // 
            this.colIdTrading.DataPropertyName = "IdTrading";
            this.colIdTrading.HeaderText = "IdTradingCo";
            this.colIdTrading.Name = "colIdTrading";
            this.colIdTrading.ReadOnly = true;
            this.colIdTrading.Visible = false;
            // 
            // colTradingCode
            // 
            this.colTradingCode.DataPropertyName = "TradingCode";
            this.colTradingCode.HeaderText = "Category Code";
            this.colTradingCode.Name = "colTradingCode";
            this.colTradingCode.ReadOnly = true;
            this.colTradingCode.Width = 250;
            // 
            // colDiscription
            // 
            this.colDiscription.DataPropertyName = "TradingName";
            this.colDiscription.HeaderText = "Discription";
            this.colDiscription.Name = "colDiscription";
            this.colDiscription.ReadOnly = true;
            this.colDiscription.Width = 275;
            // 
            // frmFindTradingCo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 450);
            this.Controls.Add(this.grdFindTradingCo);
            this.Controls.Add(this.txtID);
            this.Name = "frmFindTradingCo";
            this.Text = "Find Tradings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFindTradingCo_FormClosing);
            this.Load += new System.EventHandler(this.frmFindTradingCo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdFindTradingCo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomDataGrid grdFindTradingCo;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdTrading;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTradingCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscription;
    }
}