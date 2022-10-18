namespace Accounts.UI
{
    partial class frmRecoveryReport
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
            this.chkAllCustomers = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dtStart = new MetroFramework.Controls.MetroDateTime();
            this.dtEnd = new MetroFramework.Controls.MetroDateTime();
            this.chkDate = new MetroFramework.Controls.MetroCheckBox();
            this.btnExport = new MetroFramework.Controls.MetroTile();
            this.btnLoad = new MetroFramework.Controls.MetroTile();
            this.AccEditBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.grdRecovery = new System.Windows.Forms.DataGridView();
            this.colAccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecoveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalRecievedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecovery)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkAllCustomers);
            this.panel1.Controls.Add(this.metroLabel3);
            this.panel1.Controls.Add(this.metroLabel2);
            this.panel1.Controls.Add(this.dtStart);
            this.panel1.Controls.Add(this.dtEnd);
            this.panel1.Controls.Add(this.chkDate);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.AccEditBox);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Location = new System.Drawing.Point(3, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1107, 56);
            this.panel1.TabIndex = 1;
            // 
            // chkAllCustomers
            // 
            this.chkAllCustomers.AutoSize = true;
            this.chkAllCustomers.Location = new System.Drawing.Point(223, 28);
            this.chkAllCustomers.Name = "chkAllCustomers";
            this.chkAllCustomers.Size = new System.Drawing.Size(103, 15);
            this.chkAllCustomers.TabIndex = 3;
            this.chkAllCustomers.Text = "All Customers :";
            this.chkAllCustomers.UseSelectable = true;
            this.chkAllCustomers.CheckedChanged += new System.EventHandler(this.chkAllCustomers_CheckedChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(644, 25);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(69, 19);
            this.metroLabel3.TabIndex = 13;
            this.metroLabel3.Text = "End Date :";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(421, 26);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(74, 19);
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "Start Date :";
            // 
            // dtStart
            // 
            this.dtStart.Enabled = false;
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStart.Location = new System.Drawing.Point(502, 20);
            this.dtStart.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(136, 29);
            this.dtStart.TabIndex = 12;
            // 
            // dtEnd
            // 
            this.dtEnd.Enabled = false;
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(719, 20);
            this.dtEnd.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(142, 29);
            this.dtEnd.TabIndex = 12;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(328, 29);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(95, 15);
            this.chkDate.TabIndex = 11;
            this.chkDate.Text = "Include Date :";
            this.chkDate.UseSelectable = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.ActiveControl = null;
            this.btnExport.BackColor = System.Drawing.Color.DarkCyan;
            this.btnExport.Location = new System.Drawing.Point(991, 13);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(110, 37);
            this.btnExport.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExport.UseCustomBackColor = true;
            this.btnExport.UseSelectable = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.ActiveControl = null;
            this.btnLoad.BackColor = System.Drawing.Color.DarkCyan;
            this.btnLoad.Location = new System.Drawing.Point(880, 13);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(110, 37);
            this.btnLoad.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLoad.UseCustomBackColor = true;
            this.btnLoad.UseSelectable = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // AccEditBox
            // 
            // 
            // 
            // 
            this.AccEditBox.CustomButton.Image = null;
            this.AccEditBox.CustomButton.Location = new System.Drawing.Point(128, 1);
            this.AccEditBox.CustomButton.Name = "";
            this.AccEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.AccEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.AccEditBox.CustomButton.TabIndex = 1;
            this.AccEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.AccEditBox.CustomButton.UseSelectable = true;
            this.AccEditBox.Lines = new string[0];
            this.AccEditBox.Location = new System.Drawing.Point(64, 20);
            this.AccEditBox.MaxLength = 32767;
            this.AccEditBox.Name = "AccEditBox";
            this.AccEditBox.PasswordChar = '\0';
            this.AccEditBox.PromptText = "Account Code Here";
            this.AccEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AccEditBox.SelectedText = "";
            this.AccEditBox.SelectionLength = 0;
            this.AccEditBox.SelectionStart = 0;
            this.AccEditBox.ShortcutsEnabled = true;
            this.AccEditBox.ShowButton = true;
            this.AccEditBox.Size = new System.Drawing.Size(150, 23);
            this.AccEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.AccEditBox.TabIndex = 6;
            this.AccEditBox.UseSelectable = true;
            this.AccEditBox.WaterMark = "Account Code Here";
            this.AccEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.AccEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.AccEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.AccEditBox_ButtonClick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(1, 20);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(61, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "A/C No :";
            // 
            // grdRecovery
            // 
            this.grdRecovery.AllowUserToAddRows = false;
            this.grdRecovery.AllowUserToDeleteRows = false;
            this.grdRecovery.AllowUserToResizeColumns = false;
            this.grdRecovery.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.grdRecovery.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdRecovery.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRecovery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdRecovery.ColumnHeadersHeight = 26;
            this.grdRecovery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountCode,
            this.colAccountName,
            this.colDiscription,
            this.colRecoveryDate,
            this.colTotalRecievedAmount});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRecovery.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdRecovery.EnableHeadersVisualStyles = false;
            this.grdRecovery.Location = new System.Drawing.Point(3, 130);
            this.grdRecovery.MultiSelect = false;
            this.grdRecovery.Name = "grdRecovery";
            this.grdRecovery.ReadOnly = true;
            this.grdRecovery.RowHeadersVisible = false;
            this.grdRecovery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdRecovery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdRecovery.Size = new System.Drawing.Size(1102, 347);
            this.grdRecovery.TabIndex = 2;
            this.grdRecovery.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRecovery_CellContentClick);
            // 
            // colAccountCode
            // 
            this.colAccountCode.DataPropertyName = "AccountNo";
            this.colAccountCode.HeaderText = "Account Code";
            this.colAccountCode.Name = "colAccountCode";
            this.colAccountCode.ReadOnly = true;
            // 
            // colAccountName
            // 
            this.colAccountName.DataPropertyName = "AccountName";
            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 300;
            // 
            // colDiscription
            // 
            this.colDiscription.DataPropertyName = "Description";
            this.colDiscription.HeaderText = "Discription";
            this.colDiscription.Name = "colDiscription";
            this.colDiscription.ReadOnly = true;
            this.colDiscription.Width = 350;
            // 
            // colRecoveryDate
            // 
            this.colRecoveryDate.DataPropertyName = "Date";
            this.colRecoveryDate.HeaderText = "Recovery Date";
            this.colRecoveryDate.Name = "colRecoveryDate";
            this.colRecoveryDate.ReadOnly = true;
            this.colRecoveryDate.Width = 150;
            // 
            // colTotalRecievedAmount
            // 
            this.colTotalRecievedAmount.DataPropertyName = "Credit";
            this.colTotalRecievedAmount.HeaderText = "Total Recovered Amount";
            this.colTotalRecievedAmount.Name = "colTotalRecievedAmount";
            this.colTotalRecievedAmount.ReadOnly = true;
            this.colTotalRecievedAmount.Width = 150;
            // 
            // frmRecoveryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 472);
            this.Controls.Add(this.grdRecovery);
            this.Controls.Add(this.panel1);
            this.Name = "frmRecoveryReport";
            this.Text = "Customer\'s Recovery Report";
            this.Load += new System.EventHandler(this.frmRecoveryReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecovery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTile btnExport;
        private MetroFramework.Controls.MetroTile btnLoad;
        private MetroFramework.Controls.MetroTextBox AccEditBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridView grdRecovery;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime dtStart;
        private MetroFramework.Controls.MetroDateTime dtEnd;
        private MetroFramework.Controls.MetroCheckBox chkDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecoveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalRecievedAmount;
        private MetroFramework.Controls.MetroCheckBox chkAllCustomers;

    }
}