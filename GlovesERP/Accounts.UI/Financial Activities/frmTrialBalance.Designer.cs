namespace Accounts.UI
{
    partial class frmTrialBalance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlPeriod = new System.Windows.Forms.GroupBox();
            this.btnExportTrial = new MetroFramework.Controls.MetroTile();
            this.lblToPeriod = new MetroFramework.Controls.MetroLabel();
            this.btnGetTrial = new MetroFramework.Controls.MetroTile();
            this.chkDate = new MetroFramework.Controls.MetroCheckBox();
            this.lblStartPeriod = new MetroFramework.Controls.MetroLabel();
            this.StartDate = new MetroFramework.Controls.MetroDateTime();
            this.EndDate = new MetroFramework.Controls.MetroDateTime();
            this.DgvTrial = new System.Windows.Forms.DataGridView();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpeningBalanceDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpeningBalanceCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClosingBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTrial)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.btnExportTrial);
            this.pnlPeriod.Controls.Add(this.lblToPeriod);
            this.pnlPeriod.Controls.Add(this.btnGetTrial);
            this.pnlPeriod.Controls.Add(this.chkDate);
            this.pnlPeriod.Controls.Add(this.lblStartPeriod);
            this.pnlPeriod.Controls.Add(this.StartDate);
            this.pnlPeriod.Controls.Add(this.EndDate);
            this.pnlPeriod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPeriod.ForeColor = System.Drawing.Color.Black;
            this.pnlPeriod.Location = new System.Drawing.Point(1, 57);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(980, 62);
            this.pnlPeriod.TabIndex = 6;
            this.pnlPeriod.TabStop = false;
            this.pnlPeriod.Text = "Trial Pane";
            // 
            // btnExportTrial
            // 
            this.btnExportTrial.ActiveControl = null;
            this.btnExportTrial.BackColor = System.Drawing.Color.DarkCyan;
            this.btnExportTrial.Location = new System.Drawing.Point(864, 18);
            this.btnExportTrial.Name = "btnExportTrial";
            this.btnExportTrial.Size = new System.Drawing.Size(109, 38);
            this.btnExportTrial.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnExportTrial.TabIndex = 8;
            this.btnExportTrial.Text = "Export Trial";
            this.btnExportTrial.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExportTrial.UseCustomBackColor = true;
            this.btnExportTrial.UseSelectable = true;
            this.btnExportTrial.Click += new System.EventHandler(this.btnExportTrial_Click);
            // 
            // lblToPeriod
            // 
            this.lblToPeriod.AutoSize = true;
            this.lblToPeriod.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblToPeriod.Location = new System.Drawing.Point(323, 24);
            this.lblToPeriod.Name = "lblToPeriod";
            this.lblToPeriod.Size = new System.Drawing.Size(74, 19);
            this.lblToPeriod.TabIndex = 8;
            this.lblToPeriod.Text = "To Period :";
            // 
            // btnGetTrial
            // 
            this.btnGetTrial.ActiveControl = null;
            this.btnGetTrial.BackColor = System.Drawing.Color.DarkCyan;
            this.btnGetTrial.Location = new System.Drawing.Point(755, 18);
            this.btnGetTrial.Name = "btnGetTrial";
            this.btnGetTrial.Size = new System.Drawing.Size(107, 38);
            this.btnGetTrial.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnGetTrial.TabIndex = 8;
            this.btnGetTrial.Text = "Load";
            this.btnGetTrial.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGetTrial.UseCustomBackColor = true;
            this.btnGetTrial.UseSelectable = true;
            this.btnGetTrial.Click += new System.EventHandler(this.btnGetTrial_Click);
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(630, 27);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(90, 15);
            this.chkDate.TabIndex = 10;
            this.chkDate.Text = "Exclude Date";
            this.chkDate.UseSelectable = true;
            // 
            // lblStartPeriod
            // 
            this.lblStartPeriod.AutoSize = true;
            this.lblStartPeriod.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblStartPeriod.Location = new System.Drawing.Point(6, 25);
            this.lblStartPeriod.Name = "lblStartPeriod";
            this.lblStartPeriod.Size = new System.Drawing.Size(88, 19);
            this.lblStartPeriod.TabIndex = 8;
            this.lblStartPeriod.Text = "Start Period :";
            // 
            // StartDate
            // 
            this.StartDate.Location = new System.Drawing.Point(101, 20);
            this.StartDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(200, 29);
            this.StartDate.TabIndex = 8;
            // 
            // EndDate
            // 
            this.EndDate.Location = new System.Drawing.Point(403, 20);
            this.EndDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(200, 29);
            this.EndDate.TabIndex = 8;
            // 
            // DgvTrial
            // 
            this.DgvTrial.AllowUserToAddRows = false;
            this.DgvTrial.AllowUserToDeleteRows = false;
            this.DgvTrial.AllowUserToResizeColumns = false;
            this.DgvTrial.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.DgvTrial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvTrial.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvTrial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvTrial.ColumnHeadersHeight = 26;
            this.DgvTrial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountNo,
            this.colAccountName,
            this.colOpeningBalanceDebit,
            this.colOpeningBalanceCredit,
            this.colDebit,
            this.colCredit,
            this.colClosingBalance});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvTrial.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvTrial.EnableHeadersVisualStyles = false;
            this.DgvTrial.Location = new System.Drawing.Point(1, 125);
            this.DgvTrial.MultiSelect = false;
            this.DgvTrial.Name = "DgvTrial";
            this.DgvTrial.ReadOnly = true;
            this.DgvTrial.RowHeadersVisible = false;
            this.DgvTrial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DgvTrial.Size = new System.Drawing.Size(980, 418);
            this.DgvTrial.TabIndex = 7;
            // 
            // colAccountNo
            // 
            this.colAccountNo.HeaderText = "Account No.";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.ReadOnly = true;
            this.colAccountNo.Width = 120;
            // 
            // colAccountName
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAccountName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 225;
            // 
            // colOpeningBalanceDebit
            // 
            this.colOpeningBalanceDebit.HeaderText = "Debit X";
            this.colOpeningBalanceDebit.Name = "colOpeningBalanceDebit";
            this.colOpeningBalanceDebit.ReadOnly = true;
            this.colOpeningBalanceDebit.Width = 125;
            // 
            // colOpeningBalanceCredit
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
            this.colOpeningBalanceCredit.DefaultCellStyle = dataGridViewCellStyle4;
            this.colOpeningBalanceCredit.HeaderText = "Credit X";
            this.colOpeningBalanceCredit.Name = "colOpeningBalanceCredit";
            this.colOpeningBalanceCredit.ReadOnly = true;
            this.colOpeningBalanceCredit.Width = 125;
            // 
            // colDebit
            // 
            this.colDebit.HeaderText = "Debit";
            this.colDebit.Name = "colDebit";
            this.colDebit.ReadOnly = true;
            this.colDebit.Width = 125;
            // 
            // colCredit
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Red;
            this.colCredit.DefaultCellStyle = dataGridViewCellStyle5;
            this.colCredit.HeaderText = "Credit";
            this.colCredit.Name = "colCredit";
            this.colCredit.ReadOnly = true;
            this.colCredit.Width = 125;
            // 
            // colClosingBalance
            // 
            this.colClosingBalance.HeaderText = "Closing Balance";
            this.colClosingBalance.Name = "colClosingBalance";
            this.colClosingBalance.ReadOnly = true;
            this.colClosingBalance.Width = 125;
            // 
            // frmTrialBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 566);
            this.Controls.Add(this.DgvTrial);
            this.Controls.Add(this.pnlPeriod);
            this.Name = "frmTrialBalance";
            this.Text = "Trial Balance";
            this.Load += new System.EventHandler(this.frmTrialBalance_Load);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTrial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox pnlPeriod;
        private System.Windows.Forms.DataGridView DgvTrial;
        private MetroFramework.Controls.MetroLabel lblToPeriod;
        private MetroFramework.Controls.MetroCheckBox chkDate;
        private MetroFramework.Controls.MetroLabel lblStartPeriod;
        private MetroFramework.Controls.MetroDateTime StartDate;
        private MetroFramework.Controls.MetroDateTime EndDate;
        private MetroFramework.Controls.MetroTile btnExportTrial;
        private MetroFramework.Controls.MetroTile btnGetTrial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpeningBalanceDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpeningBalanceCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClosingBalance;
    }
}