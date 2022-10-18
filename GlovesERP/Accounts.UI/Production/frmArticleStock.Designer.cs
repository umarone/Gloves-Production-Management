namespace Accounts.UI
{
    partial class frmArticleStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdArticles = new Accounts.UI.TabDataGrid();
            this.colPackingVDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGatePass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDate = new MetroFramework.Controls.MetroPanel();
            this.EndDate = new MetroFramework.Controls.MetroDateTime();
            this.btnLoadbyFilter = new MetroFramework.Controls.MetroButton();
            this.StartDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.chkApplyDateFilter = new MetroFramework.Controls.MetroCheckBox();
            this.btnLoad = new MetroFramework.Controls.MetroButton();
            this.AccEditBox = new MetroFramework.Controls.MetroTextBox();
            this.txtArticleName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.lblAccountName = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.txtTotalOut = new System.Windows.Forms.TextBox();
            this.txtTotalIn = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdArticles)).BeginInit();
            this.pnlDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdArticles
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdArticles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdArticles.ColumnHeadersHeight = 28;
            this.grdArticles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPackingVDate,
            this.colGatePass,
            this.colMaker,
            this.colIn,
            this.colOut,
            this.colBalance});
            this.grdArticles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdArticles.EnableHeadersVisualStyles = false;
            this.grdArticles.Location = new System.Drawing.Point(15, 219);
            this.grdArticles.Name = "grdArticles";
            this.grdArticles.RowHeadersVisible = false;
            this.grdArticles.Size = new System.Drawing.Size(866, 328);
            this.grdArticles.TabIndex = 55;
            // 
            // colPackingVDate
            // 
            this.colPackingVDate.DataPropertyName = "CreatedDateTime";
            dataGridViewCellStyle7.Format = "d";
            this.colPackingVDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.colPackingVDate.HeaderText = "Date";
            this.colPackingVDate.Name = "colPackingVDate";
            // 
            // colGatePass
            // 
            this.colGatePass.DataPropertyName = "VoucherNo";
            this.colGatePass.HeaderText = "Gate Pass #";
            this.colGatePass.Name = "colGatePass";
            // 
            // colMaker
            // 
            this.colMaker.DataPropertyName = "AccountName";
            this.colMaker.HeaderText = "Maker / Customer";
            this.colMaker.Name = "colMaker";
            this.colMaker.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMaker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMaker.Width = 350;
            // 
            // colIn
            // 
            this.colIn.DataPropertyName = "StockIn";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.colIn.DefaultCellStyle = dataGridViewCellStyle8;
            this.colIn.HeaderText = "In";
            this.colIn.Name = "colIn";
            this.colIn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colOut
            // 
            this.colOut.DataPropertyName = "StockOut";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colOut.DefaultCellStyle = dataGridViewCellStyle9;
            this.colOut.HeaderText = "Out";
            this.colOut.Name = "colOut";
            // 
            // colBalance
            // 
            this.colBalance.DataPropertyName = "Balance";
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Yellow;
            this.colBalance.DefaultCellStyle = dataGridViewCellStyle10;
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            // 
            // pnlDate
            // 
            this.pnlDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDate.Controls.Add(this.EndDate);
            this.pnlDate.Controls.Add(this.btnLoadbyFilter);
            this.pnlDate.Controls.Add(this.StartDate);
            this.pnlDate.Controls.Add(this.metroLabel4);
            this.pnlDate.Controls.Add(this.metroLabel5);
            this.pnlDate.Enabled = false;
            this.pnlDate.HorizontalScrollbarBarColor = true;
            this.pnlDate.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlDate.HorizontalScrollbarSize = 10;
            this.pnlDate.Location = new System.Drawing.Point(16, 140);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(867, 50);
            this.pnlDate.TabIndex = 54;
            this.pnlDate.VerticalScrollbarBarColor = true;
            this.pnlDate.VerticalScrollbarHighlightOnWheel = false;
            this.pnlDate.VerticalScrollbarSize = 10;
            // 
            // EndDate
            // 
            this.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDate.Location = new System.Drawing.Point(352, 9);
            this.EndDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(160, 29);
            this.EndDate.TabIndex = 15;
            // 
            // btnLoadbyFilter
            // 
            this.btnLoadbyFilter.Location = new System.Drawing.Point(524, 9);
            this.btnLoadbyFilter.Name = "btnLoadbyFilter";
            this.btnLoadbyFilter.Size = new System.Drawing.Size(137, 27);
            this.btnLoadbyFilter.TabIndex = 10;
            this.btnLoadbyFilter.Text = "Load By Date Filter";
            this.btnLoadbyFilter.UseSelectable = true;
            this.btnLoadbyFilter.Click += new System.EventHandler(this.btnLoadbyFilter_Click);
            // 
            // StartDate
            // 
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDate.Location = new System.Drawing.Point(103, 9);
            this.StartDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(150, 29);
            this.StartDate.TabIndex = 14;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(268, 13);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(74, 19);
            this.metroLabel4.TabIndex = 13;
            this.metroLabel4.Text = "To Period :";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(9, 13);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(88, 19);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "Start Period :";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(13, 193);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(869, 23);
            this.metroLabel2.TabIndex = 52;
            this.metroLabel2.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------";
            // 
            // metroLabel3
            // 
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(14, 114);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(869, 23);
            this.metroLabel3.TabIndex = 53;
            this.metroLabel3.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(765, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 23);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkApplyDateFilter
            // 
            this.chkApplyDateFilter.AutoSize = true;
            this.chkApplyDateFilter.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkApplyDateFilter.Location = new System.Drawing.Point(445, 89);
            this.chkApplyDateFilter.Name = "chkApplyDateFilter";
            this.chkApplyDateFilter.Size = new System.Drawing.Size(127, 19);
            this.chkApplyDateFilter.TabIndex = 51;
            this.chkApplyDateFilter.Text = "Apply Date Filter";
            this.chkApplyDateFilter.UseSelectable = true;
            this.chkApplyDateFilter.CheckedChanged += new System.EventHandler(this.chkApplyDateFilter_CheckedChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(349, 85);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(87, 23);
            this.btnLoad.TabIndex = 49;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseSelectable = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // AccEditBox
            // 
            // 
            // 
            // 
            this.AccEditBox.CustomButton.Image = null;
            this.AccEditBox.CustomButton.Location = new System.Drawing.Point(196, 1);
            this.AccEditBox.CustomButton.Name = "";
            this.AccEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.AccEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.AccEditBox.CustomButton.TabIndex = 1;
            this.AccEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.AccEditBox.CustomButton.UseSelectable = true;
            this.AccEditBox.Lines = new string[0];
            this.AccEditBox.Location = new System.Drawing.Point(541, 19);
            this.AccEditBox.MaxLength = 32767;
            this.AccEditBox.Name = "AccEditBox";
            this.AccEditBox.PasswordChar = '\0';
            this.AccEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AccEditBox.SelectedText = "";
            this.AccEditBox.SelectionLength = 0;
            this.AccEditBox.SelectionStart = 0;
            this.AccEditBox.ShortcutsEnabled = true;
            this.AccEditBox.ShowButton = true;
            this.AccEditBox.Size = new System.Drawing.Size(218, 23);
            this.AccEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.AccEditBox.TabIndex = 47;
            this.AccEditBox.UseSelectable = true;
            this.AccEditBox.Visible = false;
            this.AccEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.AccEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.AccEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.AccEditBox_ButtonClick);
            // 
            // txtArticleName
            // 
            // 
            // 
            // 
            this.txtArticleName.CustomButton.Image = null;
            this.txtArticleName.CustomButton.Location = new System.Drawing.Point(196, 1);
            this.txtArticleName.CustomButton.Name = "";
            this.txtArticleName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtArticleName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtArticleName.CustomButton.TabIndex = 1;
            this.txtArticleName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtArticleName.CustomButton.UseSelectable = true;
            this.txtArticleName.Lines = new string[0];
            this.txtArticleName.Location = new System.Drawing.Point(125, 84);
            this.txtArticleName.MaxLength = 32767;
            this.txtArticleName.Name = "txtArticleName";
            this.txtArticleName.PasswordChar = '\0';
            this.txtArticleName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtArticleName.SelectedText = "";
            this.txtArticleName.SelectionLength = 0;
            this.txtArticleName.SelectionStart = 0;
            this.txtArticleName.ShortcutsEnabled = true;
            this.txtArticleName.ShowButton = true;
            this.txtArticleName.Size = new System.Drawing.Size(218, 23);
            this.txtArticleName.Style = MetroFramework.MetroColorStyle.Green;
            this.txtArticleName.TabIndex = 48;
            this.txtArticleName.UseSelectable = true;
            this.txtArticleName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtArticleName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtArticleName.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtArticleName_ButtonClick);
            this.txtArticleName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArticleName_KeyPress);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(433, 20);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(108, 19);
            this.metroLabel6.TabIndex = 45;
            this.metroLabel6.Text = "Filter By Maker :";
            this.metroLabel6.Visible = false;
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAccountName.Location = new System.Drawing.Point(17, 85);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(93, 19);
            this.lblAccountName.TabIndex = 46;
            this.lblAccountName.Text = "Select Aritcle :";
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(16, 58);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(867, 23);
            this.metroLabel1.TabIndex = 44;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(782, 553);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(100, 20);
            this.txtBalance.TabIndex = 58;
            // 
            // txtTotalOut
            // 
            this.txtTotalOut.Location = new System.Drawing.Point(679, 553);
            this.txtTotalOut.Name = "txtTotalOut";
            this.txtTotalOut.Size = new System.Drawing.Size(100, 20);
            this.txtTotalOut.TabIndex = 57;
            // 
            // txtTotalIn
            // 
            this.txtTotalIn.Location = new System.Drawing.Point(576, 553);
            this.txtTotalIn.Name = "txtTotalIn";
            this.txtTotalIn.Size = new System.Drawing.Size(100, 20);
            this.txtTotalIn.TabIndex = 56;
            // 
            // frmArticleStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 618);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.txtTotalOut);
            this.Controls.Add(this.txtTotalIn);
            this.Controls.Add(this.grdArticles);
            this.Controls.Add(this.pnlDate);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkApplyDateFilter);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.AccEditBox);
            this.Controls.Add(this.txtArticleName);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.lblAccountName);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frmArticleStock";
            this.Load += new System.EventHandler(this.frmArticleStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdArticles)).EndInit();
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabDataGrid grdArticles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackingVDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGatePass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
        private MetroFramework.Controls.MetroPanel pnlDate;
        private MetroFramework.Controls.MetroDateTime EndDate;
        private MetroFramework.Controls.MetroButton btnLoadbyFilter;
        private MetroFramework.Controls.MetroDateTime StartDate;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroCheckBox chkApplyDateFilter;
        private MetroFramework.Controls.MetroButton btnLoad;
        private MetroFramework.Controls.MetroTextBox AccEditBox;
        private MetroFramework.Controls.MetroTextBox txtArticleName;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel lblAccountName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.TextBox txtTotalOut;
        private System.Windows.Forms.TextBox txtTotalIn;
    }
}