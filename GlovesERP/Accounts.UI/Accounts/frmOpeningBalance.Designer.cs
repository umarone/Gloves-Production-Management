namespace Accounts.UI
{
    partial class frmOpeningBalance
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatuMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxEmployees = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblBalanceDate = new MetroFramework.Controls.MetroLabel();
            this.dtOpeningBalance = new MetroFramework.Controls.MetroDateTime();
            this.chkStock = new MetroFramework.Controls.MetroCheckBox();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnClose = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.DgvOpeningBalance = new Accounts.UI.TabDataGrid();
            this.ColTransaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeadId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLinkAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdjustmentTypes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDiscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvOpeningBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatuMessage});
            this.statusStrip1.Location = new System.Drawing.Point(20, 386);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(976, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatuMessage
            // 
            this.lblStatuMessage.Name = "lblStatuMessage";
            this.lblStatuMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbxEmployees);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Controls.Add(this.lblBalanceDate);
            this.panel1.Controls.Add(this.dtOpeningBalance);
            this.panel1.Location = new System.Drawing.Point(0, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 45);
            this.panel1.TabIndex = 4;
            // 
            // cbxEmployees
            // 
            this.cbxEmployees.FormattingEnabled = true;
            this.cbxEmployees.ItemHeight = 23;
            this.cbxEmployees.Location = new System.Drawing.Point(439, 7);
            this.cbxEmployees.Name = "cbxEmployees";
            this.cbxEmployees.Size = new System.Drawing.Size(242, 29);
            this.cbxEmployees.TabIndex = 13;
            this.cbxEmployees.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(340, 11);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(83, 19);
            this.metroLabel1.TabIndex = 12;
            this.metroLabel1.Text = "Employees : ";
            // 
            // lblBalanceDate
            // 
            this.lblBalanceDate.AutoSize = true;
            this.lblBalanceDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblBalanceDate.Location = new System.Drawing.Point(10, 12);
            this.lblBalanceDate.Name = "lblBalanceDate";
            this.lblBalanceDate.Size = new System.Drawing.Size(95, 19);
            this.lblBalanceDate.TabIndex = 4;
            this.lblBalanceDate.Text = "Balance Date :";
            // 
            // dtOpeningBalance
            // 
            this.dtOpeningBalance.Location = new System.Drawing.Point(110, 7);
            this.dtOpeningBalance.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtOpeningBalance.Name = "dtOpeningBalance";
            this.dtOpeningBalance.Size = new System.Drawing.Size(200, 29);
            this.dtOpeningBalance.TabIndex = 1;
            // 
            // chkStock
            // 
            this.chkStock.AutoSize = true;
            this.chkStock.Location = new System.Drawing.Point(542, 18);
            this.chkStock.Name = "chkStock";
            this.chkStock.Size = new System.Drawing.Size(96, 15);
            this.chkStock.TabIndex = 2;
            this.chkStock.Text = "Stock Balance";
            this.chkStock.UseSelectable = true;
            this.chkStock.Visible = false;
            this.chkStock.CheckedChanged += new System.EventHandler(this.chkStock_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(837, 345);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 31);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(922, 345);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 31);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(751, 345);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 31);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DgvOpeningBalance
            // 
            this.DgvOpeningBalance.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvOpeningBalance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvOpeningBalance.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvOpeningBalance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvOpeningBalance.ColumnHeadersHeight = 25;
            this.DgvOpeningBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColTransaction,
            this.colHeadId,
            this.colAccount,
            this.colLinkAccount,
            this.colAccountName,
            this.colAdjustmentTypes,
            this.colDiscription,
            this.colAmount});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvOpeningBalance.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvOpeningBalance.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DgvOpeningBalance.EnableHeadersVisualStyles = false;
            this.DgvOpeningBalance.Location = new System.Drawing.Point(0, 116);
            this.DgvOpeningBalance.MultiSelect = false;
            this.DgvOpeningBalance.Name = "DgvOpeningBalance";
            this.DgvOpeningBalance.RowHeadersVisible = false;
            this.DgvOpeningBalance.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvOpeningBalance.Size = new System.Drawing.Size(1006, 223);
            this.DgvOpeningBalance.TabIndex = 0;
            this.DgvOpeningBalance.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvOpeningBalance_CellEnter);
            this.DgvOpeningBalance.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvOpeningBalance_EditingControlShowing);
            // 
            // ColTransaction
            // 
            this.ColTransaction.DataPropertyName = "TransactionID";
            this.ColTransaction.HeaderText = "TransactionId";
            this.ColTransaction.Name = "ColTransaction";
            this.ColTransaction.Visible = false;
            // 
            // colHeadId
            // 
            this.colHeadId.HeaderText = "HeadId";
            this.colHeadId.Name = "colHeadId";
            this.colHeadId.Visible = false;
            // 
            // colAccount
            // 
            this.colAccount.DataPropertyName = "AccountNo";
            this.colAccount.HeaderText = "Acc. #";
            this.colAccount.Name = "colAccount";
            this.colAccount.Visible = false;
            // 
            // colLinkAccount
            // 
            this.colLinkAccount.HeaderText = "Link Acc. #";
            this.colLinkAccount.Name = "colLinkAccount";
            this.colLinkAccount.Visible = false;
            // 
            // colAccountName
            // 
            this.colAccountName.HeaderText = "AccountName";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.Width = 250;
            // 
            // colAdjustmentTypes
            // 
            this.colAdjustmentTypes.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colAdjustmentTypes.HeaderText = "Adjustment Types";
            this.colAdjustmentTypes.Items.AddRange(new object[] {
            "",
            "Advances To Employees",
            "Advances Deduction from Employees",
            "Loan To Employees",
            "Loan Deduction from Employees",
            "Others"});
            this.colAdjustmentTypes.Name = "colAdjustmentTypes";
            this.colAdjustmentTypes.Width = 300;
            // 
            // colDiscription
            // 
            this.colDiscription.HeaderText = "Narration";
            this.colDiscription.Name = "colDiscription";
            this.colDiscription.Width = 300;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Opening Balance";
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 150;
            // 
            // frmOpeningBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 428);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chkStock);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.DgvOpeningBalance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmOpeningBalance";
            this.Text = "GL Opening Balances";
            this.Load += new System.EventHandler(this.frmOpeningBalance_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvOpeningBalance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatuMessage;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroLabel lblBalanceDate;
        private MetroFramework.Controls.MetroDateTime dtOpeningBalance;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnClose;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroCheckBox chkStock;
        private TabDataGrid DgvOpeningBalance;
        private MetroFramework.Controls.MetroComboBox cbxEmployees;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeadId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinkAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAdjustmentTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;

    }
}