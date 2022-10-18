namespace Accounts.UI
{
    partial class frmDayBook
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAuthorized = new MetroFramework.Controls.MetroCheckBox();
            this.btnLoad = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dtStart = new MetroFramework.Controls.MetroDateTime();
            this.ExpPanel = new System.Windows.Forms.GroupBox();
            this.grdDayBook = new System.Windows.Forms.DataGridView();
            this.colTransactionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVoucherType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAuthorize = new MetroFramework.Controls.MetroTile();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblRemainingCashInHand = new MetroFramework.Controls.MetroLabel();
            this.lblTotalExpense = new MetroFramework.Controls.MetroLabel();
            this.lblTotalReceipts = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.ExpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDayBook)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkAuthorized);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Controls.Add(this.dtStart);
            this.panel1.Location = new System.Drawing.Point(23, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 40);
            this.panel1.TabIndex = 3;
            // 
            // chkAuthorized
            // 
            this.chkAuthorized.AutoSize = true;
            this.chkAuthorized.Location = new System.Drawing.Point(476, 11);
            this.chkAuthorized.Name = "chkAuthorized";
            this.chkAuthorized.Size = new System.Drawing.Size(81, 15);
            this.chkAuthorized.TabIndex = 8;
            this.chkAuthorized.Text = "Authorized";
            this.chkAuthorized.UseSelectable = true;
            this.chkAuthorized.Visible = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(365, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(96, 30);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseSelectable = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(8, 8);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(77, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Book Date :";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel1.UseStyleColors = true;
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(88, 4);
            this.dtStart.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(265, 29);
            this.dtStart.TabIndex = 6;
            // 
            // ExpPanel
            // 
            this.ExpPanel.Controls.Add(this.grdDayBook);
            this.ExpPanel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpPanel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ExpPanel.Location = new System.Drawing.Point(23, 106);
            this.ExpPanel.Name = "ExpPanel";
            this.ExpPanel.Size = new System.Drawing.Size(1018, 420);
            this.ExpPanel.TabIndex = 4;
            this.ExpPanel.TabStop = false;
            this.ExpPanel.Text = "Book Detail";
            // 
            // grdDayBook
            // 
            this.grdDayBook.AllowUserToAddRows = false;
            this.grdDayBook.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.grdDayBook.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDayBook.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDayBook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdDayBook.ColumnHeadersHeight = 25;
            this.grdDayBook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTransactionId,
            this.colAccountName,
            this.colAccountType,
            this.colBookType,
            this.colDescription,
            this.colVoucherType,
            this.colAmount,
            this.colCredit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDayBook.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdDayBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDayBook.EnableHeadersVisualStyles = false;
            this.grdDayBook.Location = new System.Drawing.Point(3, 23);
            this.grdDayBook.Name = "grdDayBook";
            this.grdDayBook.ReadOnly = true;
            this.grdDayBook.RowHeadersVisible = false;
            this.grdDayBook.Size = new System.Drawing.Size(1012, 394);
            this.grdDayBook.TabIndex = 0;
            // 
            // colTransactionId
            // 
            this.colTransactionId.DataPropertyName = "TransactionID";
            this.colTransactionId.HeaderText = "IdTransaction";
            this.colTransactionId.Name = "colTransactionId";
            this.colTransactionId.ReadOnly = true;
            this.colTransactionId.Visible = false;
            // 
            // colAccountName
            // 
            this.colAccountName.DataPropertyName = "AccountName";
            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 200;
            // 
            // colAccountType
            // 
            this.colAccountType.DataPropertyName = "AccountType";
            this.colAccountType.HeaderText = "Acc. Type";
            this.colAccountType.Name = "colAccountType";
            this.colAccountType.ReadOnly = true;
            // 
            // colBookType
            // 
            this.colBookType.DataPropertyName = "DayBook";
            this.colBookType.HeaderText = "BookType";
            this.colBookType.Name = "colBookType";
            this.colBookType.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 300;
            // 
            // colVoucherType
            // 
            this.colVoucherType.DataPropertyName = "VoucherType";
            this.colVoucherType.HeaderText = "VType";
            this.colVoucherType.Name = "colVoucherType";
            this.colVoucherType.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Debit";
            this.colAmount.HeaderText = "Debit";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colCredit
            // 
            this.colCredit.DataPropertyName = "Credit";
            this.colCredit.HeaderText = "Credit";
            this.colCredit.Name = "colCredit";
            this.colCredit.ReadOnly = true;
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.ActiveControl = null;
            this.btnAuthorize.Location = new System.Drawing.Point(897, 533);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Size = new System.Drawing.Size(144, 38);
            this.btnAuthorize.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAuthorize.TabIndex = 5;
            this.btnAuthorize.Text = "Authorize Day Book";
            this.btnAuthorize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAuthorize.UseSelectable = true;
            this.btnAuthorize.Click += new System.EventHandler(this.btnAuthorize_Click);
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.lblRemainingCashInHand);
            this.pnlDetail.Controls.Add(this.lblTotalExpense);
            this.pnlDetail.Controls.Add(this.lblTotalReceipts);
            this.pnlDetail.Controls.Add(this.metroLabel5);
            this.pnlDetail.Controls.Add(this.metroLabel4);
            this.pnlDetail.Controls.Add(this.metroLabel3);
            this.pnlDetail.Controls.Add(this.metroLabel2);
            this.pnlDetail.Location = new System.Drawing.Point(25, 529);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(562, 112);
            this.pnlDetail.TabIndex = 6;
            this.pnlDetail.Visible = false;
            // 
            // lblRemainingCashInHand
            // 
            this.lblRemainingCashInHand.AutoSize = true;
            this.lblRemainingCashInHand.Location = new System.Drawing.Point(238, 82);
            this.lblRemainingCashInHand.Name = "lblRemainingCashInHand";
            this.lblRemainingCashInHand.Size = new System.Drawing.Size(0, 0);
            this.lblRemainingCashInHand.TabIndex = 2;
            // 
            // lblTotalExpense
            // 
            this.lblTotalExpense.AutoSize = true;
            this.lblTotalExpense.Location = new System.Drawing.Point(238, 41);
            this.lblTotalExpense.Name = "lblTotalExpense";
            this.lblTotalExpense.Size = new System.Drawing.Size(0, 0);
            this.lblTotalExpense.TabIndex = 2;
            // 
            // lblTotalReceipts
            // 
            this.lblTotalReceipts.AutoSize = true;
            this.lblTotalReceipts.Location = new System.Drawing.Point(238, 10);
            this.lblTotalReceipts.Name = "lblTotalReceipts";
            this.lblTotalReceipts.Size = new System.Drawing.Size(0, 0);
            this.lblTotalReceipts.TabIndex = 2;
            // 
            // metroLabel5
            // 
            this.metroLabel5.Location = new System.Drawing.Point(9, 60);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(547, 23);
            this.metroLabel5.TabIndex = 1;
            this.metroLabel5.Text = "---------------------------------------------------------------------------------" +
    "--------";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(6, 80);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(221, 25);
            this.metroLabel4.TabIndex = 0;
            this.metroLabel4.Text = "Remaining Cash In Hand";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(6, 35);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(149, 25);
            this.metroLabel3.TabIndex = 0;
            this.metroLabel3.Text = "Total Expenses :";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(6, 4);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(143, 25);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "Total Receipts :";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TransactionID";
            this.dataGridViewTextBoxColumn1.HeaderText = "IdTransaction";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AccountName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Account Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "AccountType";
            this.dataGridViewTextBoxColumn3.HeaderText = "Acc. Type";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DayBook";
            this.dataGridViewTextBoxColumn4.HeaderText = "BookType";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn5.HeaderText = "Description";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 300;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Debit";
            this.dataGridViewTextBoxColumn6.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Credit";
            this.dataGridViewTextBoxColumn7.HeaderText = "Credit";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Credit";
            this.dataGridViewTextBoxColumn8.HeaderText = "Credit";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // frmDayBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 664);
            this.Controls.Add(this.pnlDetail);
            this.Controls.Add(this.btnAuthorize);
            this.Controls.Add(this.ExpPanel);
            this.Controls.Add(this.panel1);
            this.Name = "frmDayBook";
            this.Text = "Daily Cash Book Activity";
            this.Load += new System.EventHandler(this.frmDayBook_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ExpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDayBook)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroDateTime dtStart;
        private MetroFramework.Controls.MetroButton btnLoad;
        private MetroFramework.Controls.MetroCheckBox chkAuthorized;
        private System.Windows.Forms.GroupBox ExpPanel;
        private System.Windows.Forms.DataGridView grdDayBook;
        private MetroFramework.Controls.MetroTile btnAuthorize;
        private System.Windows.Forms.Panel pnlDetail;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblRemainingCashInHand;
        private MetroFramework.Controls.MetroLabel lblTotalExpense;
        private MetroFramework.Controls.MetroLabel lblTotalReceipts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransactionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoucherType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}