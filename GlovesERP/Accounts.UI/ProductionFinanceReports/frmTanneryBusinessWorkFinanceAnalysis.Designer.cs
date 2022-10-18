namespace Accounts.UI
{
    partial class frmTanneryBusinessWorkFinanceAnalysis
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
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.grdWorkFinance = new Accounts.UI.CustomDataGrid();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNarration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGetAnalysis = new MetroFramework.Controls.MetroButton();
            this.endDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.startDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblTotalAmount = new MetroFramework.Controls.MetroLabel();
            this.lblAmount = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkFinance)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(23, 131);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(117, 19);
            this.metroLabel5.TabIndex = 58;
            this.metroLabel5.Text = "Financial Report";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // grdWorkFinance
            // 
            this.grdWorkFinance.AllowUserToAddRows = false;
            this.grdWorkFinance.AllowUserToDeleteRows = false;
            this.grdWorkFinance.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdWorkFinance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdWorkFinance.ColumnHeadersHeight = 30;
            this.grdWorkFinance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescription,
            this.colNarration,
            this.colAmount});
            this.grdWorkFinance.EnableHeadersVisualStyles = false;
            this.grdWorkFinance.Location = new System.Drawing.Point(23, 153);
            this.grdWorkFinance.Name = "grdWorkFinance";
            this.grdWorkFinance.ReadOnly = true;
            this.grdWorkFinance.RowHeadersVisible = false;
            this.grdWorkFinance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdWorkFinance.Size = new System.Drawing.Size(707, 323);
            this.grdWorkFinance.TabIndex = 57;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "AccountName";
            this.colDescription.HeaderText = "Account Name";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 300;
            // 
            // colNarration
            // 
            this.colNarration.DataPropertyName = "TransactionType";
            this.colNarration.HeaderText = "Narration";
            this.colNarration.Name = "colNarration";
            this.colNarration.ReadOnly = true;
            this.colNarration.Width = 200;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 200;
            // 
            // btnGetAnalysis
            // 
            this.btnGetAnalysis.Location = new System.Drawing.Point(607, 84);
            this.btnGetAnalysis.Name = "btnGetAnalysis";
            this.btnGetAnalysis.Size = new System.Drawing.Size(124, 28);
            this.btnGetAnalysis.TabIndex = 56;
            this.btnGetAnalysis.Text = "Get Analysis";
            this.btnGetAnalysis.UseSelectable = true;
            this.btnGetAnalysis.Click += new System.EventHandler(this.btnGetAnalysis_Click);
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(389, 84);
            this.endDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(208, 29);
            this.endDate.TabIndex = 55;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(317, 88);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(64, 19);
            this.metroLabel3.TabIndex = 54;
            this.metroLabel3.Text = "To Date :";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(101, 84);
            this.startDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(211, 29);
            this.startDate.TabIndex = 53;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(20, 88);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(78, 19);
            this.metroLabel4.TabIndex = 52;
            this.metroLabel4.Text = "Start Date :";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Location = new System.Drawing.Point(23, 116);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(708, 23);
            this.metroLabel2.TabIndex = 50;
            this.metroLabel2.Text = "---------------------------------------------------------------------------------" +
    "-----------------------------------";
            // 
            // metroLabel1
            // 
            this.metroLabel1.Location = new System.Drawing.Point(23, 58);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(708, 23);
            this.metroLabel1.TabIndex = 51;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "-----------------------------------";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTotalAmount.Location = new System.Drawing.Point(549, 488);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(108, 19);
            this.lblTotalAmount.TabIndex = 52;
            this.lblTotalAmount.Text = "Total Amount :";
            this.lblTotalAmount.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblAmount.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAmount.Location = new System.Drawing.Point(673, 488);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(0, 0);
            this.lblAmount.TabIndex = 52;
            this.lblAmount.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // frmTanneryBusinessWorkFinanceAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 546);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.grdWorkFinance);
            this.Controls.Add(this.btnGetAnalysis);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.Name = "frmTanneryBusinessWorkFinanceAnalysis";
            this.Text = "Tannery Business Work Finance Analysis";
            this.Load += new System.EventHandler(this.frmTanneryBusinessWorkFinanceAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkFinance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel5;
        private CustomDataGrid grdWorkFinance;
        private MetroFramework.Controls.MetroButton btnGetAnalysis;
        private MetroFramework.Controls.MetroDateTime endDate;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime startDate;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNarration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private MetroFramework.Controls.MetroLabel lblTotalAmount;
        private MetroFramework.Controls.MetroLabel lblAmount;
    }
}