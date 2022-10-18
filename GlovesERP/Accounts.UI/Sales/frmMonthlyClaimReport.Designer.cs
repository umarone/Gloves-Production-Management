namespace Accounts.UI
{
    partial class frmMonthlyClaimReport
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
            this.btnExcelExport = new MetroFramework.Controls.MetroTile();
            this.btnLoad = new MetroFramework.Controls.MetroTile();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dtEnd = new MetroFramework.Controls.MetroDateTime();
            this.dtStart = new MetroFramework.Controls.MetroDateTime();
            this.lblSearch = new MetroFramework.Controls.MetroLabel();
            this.txtsearch = new MetroFramework.Controls.MetroTextBox();
            this.grdTotalClaims = new System.Windows.Forms.DataGridView();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtotalPersons = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtTotalClaims = new MetroFramework.Controls.MetroTextBox();
            this.txtAmount = new MetroFramework.Controls.MetroTextBox();
            this.colAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalClaims = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalClaims)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.ActiveControl = null;
            this.btnExcelExport.Location = new System.Drawing.Point(738, 55);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(106, 39);
            this.btnExcelExport.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnExcelExport.TabIndex = 17;
            this.btnExcelExport.Text = "Excel Export";
            this.btnExcelExport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcelExport.UseSelectable = true;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.ActiveControl = null;
            this.btnLoad.Location = new System.Drawing.Point(626, 55);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(106, 39);
            this.btnLoad.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnLoad.TabIndex = 16;
            this.btnLoad.Text = "Load";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoad.UseSelectable = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(328, 67);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(62, 19);
            this.metroLabel2.TabIndex = 15;
            this.metroLabel2.Text = "To Date :";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(22, 67);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(74, 19);
            this.metroLabel1.TabIndex = 14;
            this.metroLabel1.Text = "Start Date :";
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(396, 63);
            this.dtEnd.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 29);
            this.dtEnd.TabIndex = 12;
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(119, 63);
            this.dtStart.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 29);
            this.dtStart.TabIndex = 13;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(22, 107);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(91, 19);
            this.lblSearch.TabIndex = 20;
            this.lblSearch.Text = "By Customer :";
            // 
            // txtsearch
            // 
            // 
            // 
            // 
            this.txtsearch.CustomButton.Image = null;
            this.txtsearch.CustomButton.Location = new System.Drawing.Point(195, 1);
            this.txtsearch.CustomButton.Name = "";
            this.txtsearch.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtsearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtsearch.CustomButton.TabIndex = 1;
            this.txtsearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtsearch.CustomButton.UseSelectable = true;
            this.txtsearch.CustomButton.Visible = false;
            this.txtsearch.Lines = new string[0];
            this.txtsearch.Location = new System.Drawing.Point(118, 104);
            this.txtsearch.MaxLength = 32767;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PasswordChar = '\0';
            this.txtsearch.PromptText = "Search Here";
            this.txtsearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtsearch.SelectedText = "";
            this.txtsearch.SelectionLength = 0;
            this.txtsearch.SelectionStart = 0;
            this.txtsearch.ShortcutsEnabled = true;
            this.txtsearch.Size = new System.Drawing.Size(217, 23);
            this.txtsearch.TabIndex = 19;
            this.txtsearch.UseSelectable = true;
            this.txtsearch.WaterMark = "Search Here";
            this.txtsearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtsearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // grdTotalClaims
            // 
            this.grdTotalClaims.AllowUserToAddRows = false;
            this.grdTotalClaims.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdTotalClaims.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTotalClaims.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdTotalClaims.ColumnHeadersHeight = 26;
            this.grdTotalClaims.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountNo,
            this.colAccountName,
            this.colTotalClaims,
            this.colAmount,
            this.colDetail});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTotalClaims.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdTotalClaims.EnableHeadersVisualStyles = false;
            this.grdTotalClaims.Location = new System.Drawing.Point(118, 136);
            this.grdTotalClaims.Name = "grdTotalClaims";
            this.grdTotalClaims.ReadOnly = true;
            this.grdTotalClaims.RowHeadersVisible = false;
            this.grdTotalClaims.Size = new System.Drawing.Size(734, 357);
            this.grdTotalClaims.TabIndex = 18;
            this.grdTotalClaims.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTotalClaims_CellContentClick);
            this.grdTotalClaims.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdTotalClaims_CellFormatting);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(121, 500);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(98, 19);
            this.metroLabel5.TabIndex = 24;
            this.metroLabel5.Text = "Total Persons :";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(400, 499);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(90, 19);
            this.metroLabel4.TabIndex = 25;
            this.metroLabel4.Text = "Total Claims :";
            // 
            // txtotalPersons
            // 
            // 
            // 
            // 
            this.txtotalPersons.CustomButton.Image = null;
            this.txtotalPersons.CustomButton.Location = new System.Drawing.Point(140, 1);
            this.txtotalPersons.CustomButton.Name = "";
            this.txtotalPersons.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtotalPersons.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtotalPersons.CustomButton.TabIndex = 1;
            this.txtotalPersons.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtotalPersons.CustomButton.UseSelectable = true;
            this.txtotalPersons.CustomButton.Visible = false;
            this.txtotalPersons.Lines = new string[0];
            this.txtotalPersons.Location = new System.Drawing.Point(225, 500);
            this.txtotalPersons.MaxLength = 32767;
            this.txtotalPersons.Name = "txtotalPersons";
            this.txtotalPersons.PasswordChar = '\0';
            this.txtotalPersons.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtotalPersons.SelectedText = "";
            this.txtotalPersons.SelectionLength = 0;
            this.txtotalPersons.SelectionStart = 0;
            this.txtotalPersons.ShortcutsEnabled = true;
            this.txtotalPersons.Size = new System.Drawing.Size(162, 23);
            this.txtotalPersons.TabIndex = 23;
            this.txtotalPersons.UseSelectable = true;
            this.txtotalPersons.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtotalPersons.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(631, 500);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(100, 19);
            this.metroLabel3.TabIndex = 26;
            this.metroLabel3.Text = "Total Amount :";
            // 
            // txtTotalClaims
            // 
            // 
            // 
            // 
            this.txtTotalClaims.CustomButton.Image = null;
            this.txtTotalClaims.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.txtTotalClaims.CustomButton.Name = "";
            this.txtTotalClaims.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTotalClaims.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalClaims.CustomButton.TabIndex = 1;
            this.txtTotalClaims.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalClaims.CustomButton.UseSelectable = true;
            this.txtTotalClaims.CustomButton.Visible = false;
            this.txtTotalClaims.Lines = new string[0];
            this.txtTotalClaims.Location = new System.Drawing.Point(495, 499);
            this.txtTotalClaims.MaxLength = 32767;
            this.txtTotalClaims.Name = "txtTotalClaims";
            this.txtTotalClaims.PasswordChar = '\0';
            this.txtTotalClaims.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalClaims.SelectedText = "";
            this.txtTotalClaims.SelectionLength = 0;
            this.txtTotalClaims.SelectionStart = 0;
            this.txtTotalClaims.ShortcutsEnabled = true;
            this.txtTotalClaims.Size = new System.Drawing.Size(131, 23);
            this.txtTotalClaims.TabIndex = 22;
            this.txtTotalClaims.UseSelectable = true;
            this.txtTotalClaims.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalClaims.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtAmount
            // 
            // 
            // 
            // 
            this.txtAmount.CustomButton.Image = null;
            this.txtAmount.CustomButton.Location = new System.Drawing.Point(92, 1);
            this.txtAmount.CustomButton.Name = "";
            this.txtAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAmount.CustomButton.TabIndex = 1;
            this.txtAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAmount.CustomButton.UseSelectable = true;
            this.txtAmount.CustomButton.Visible = false;
            this.txtAmount.Lines = new string[0];
            this.txtAmount.Location = new System.Drawing.Point(732, 500);
            this.txtAmount.MaxLength = 32767;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAmount.SelectedText = "";
            this.txtAmount.SelectionLength = 0;
            this.txtAmount.SelectionStart = 0;
            this.txtAmount.ShortcutsEnabled = true;
            this.txtAmount.Size = new System.Drawing.Size(114, 23);
            this.txtAmount.TabIndex = 21;
            this.txtAmount.UseSelectable = true;
            this.txtAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // colAccountNo
            // 
            this.colAccountNo.DataPropertyName = "AccountNo";
            this.colAccountNo.HeaderText = "AccountNo";
            this.colAccountNo.Name = "colAccountNo";
            this.colAccountNo.ReadOnly = true;
            this.colAccountNo.Visible = false;
            // 
            // colAccountName
            // 
            this.colAccountName.DataPropertyName = "AccountName";
            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 250;
            // 
            // colTotalClaims
            // 
            this.colTotalClaims.DataPropertyName = "TotalSalesReturn";
            this.colTotalClaims.HeaderText = "Total Claims";
            this.colTotalClaims.Name = "colTotalClaims";
            this.colTotalClaims.ReadOnly = true;
            this.colTotalClaims.Width = 150;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "TotalAmount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 150;
            // 
            // colDetail
            // 
            this.colDetail.HeaderText = "......";
            this.colDetail.Name = "colDetail";
            this.colDetail.ReadOnly = true;
            this.colDetail.Width = 150;
            // 
            // frmMonthlyClaimReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 538);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtotalPersons);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtTotalClaims);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.grdTotalClaims);
            this.Controls.Add(this.btnExcelExport);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Name = "frmMonthlyClaimReport";
            this.Text = "Monthly Claim Report";
            this.Load += new System.EventHandler(this.frmMonthlyClaimReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalClaims)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnExcelExport;
        private MetroFramework.Controls.MetroTile btnLoad;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroDateTime dtEnd;
        private MetroFramework.Controls.MetroDateTime dtStart;
        private MetroFramework.Controls.MetroLabel lblSearch;
        private MetroFramework.Controls.MetroTextBox txtsearch;
        private System.Windows.Forms.DataGridView grdTotalClaims;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtotalPersons;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtTotalClaims;
        private MetroFramework.Controls.MetroTextBox txtAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalClaims;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colDetail;
    }
}