namespace Accounts.UI
{
    partial class frmBrandSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrandSetup));
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.btnSearch = new MetroFramework.Controls.MetroTile();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.chkActive = new MetroFramework.Controls.MetroCheckBox();
            this.BrandDate = new System.Windows.Forms.DateTimePicker();
            this.txtBrandName = new MetroFramework.Controls.MetroTextBox();
            this.txtBrandCode = new MetroFramework.Controls.MetroTextBox();
            this.BrandCreatedDate = new MetroFramework.Controls.MetroLabel();
            this.BrandName = new MetroFramework.Controls.MetroLabel();
            this.BrandCode = new MetroFramework.Controls.MetroLabel();
            this.txtAccountNo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.Location = new System.Drawing.Point(506, 271);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 84);
            this.btnClose.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.TileImage = ((System.Drawing.Image)(resources.GetObject("btnClose.TileImage")));
            this.btnClose.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseSelectable = true;
            this.btnClose.UseTileImage = true;
            // 
            // btnDelete
            // 
            this.btnDelete.ActiveControl = null;
            this.btnDelete.Location = new System.Drawing.Point(294, 271);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 84);
            this.btnDelete.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.TileImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.TileImage")));
            this.btnDelete.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.UseTileImage = true;
            // 
            // btnSearch
            // 
            this.btnSearch.ActiveControl = null;
            this.btnSearch.Location = new System.Drawing.Point(400, 271);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 84);
            this.btnSearch.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.TileImage")));
            this.btnSearch.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.UseSelectable = true;
            this.btnSearch.UseTileImage = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(188, 271);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 84);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSave.TileImage")));
            this.btnSave.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseSelectable = true;
            this.btnSave.UseTileImage = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(188, 227);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 15);
            this.chkActive.TabIndex = 22;
            this.chkActive.Text = "Active";
            this.chkActive.UseSelectable = true;
            // 
            // BrandDate
            // 
            this.BrandDate.Location = new System.Drawing.Point(188, 195);
            this.BrandDate.Name = "BrandDate";
            this.BrandDate.Size = new System.Drawing.Size(277, 20);
            this.BrandDate.TabIndex = 21;
            // 
            // txtBrandName
            // 
            // 
            // 
            // 
            this.txtBrandName.CustomButton.Image = null;
            this.txtBrandName.CustomButton.Location = new System.Drawing.Point(255, 1);
            this.txtBrandName.CustomButton.Name = "";
            this.txtBrandName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBrandName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBrandName.CustomButton.TabIndex = 1;
            this.txtBrandName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBrandName.CustomButton.UseSelectable = true;
            this.txtBrandName.CustomButton.Visible = false;
            this.txtBrandName.Lines = new string[0];
            this.txtBrandName.Location = new System.Drawing.Point(188, 163);
            this.txtBrandName.MaxLength = 32767;
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.PasswordChar = '\0';
            this.txtBrandName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBrandName.SelectedText = "";
            this.txtBrandName.SelectionLength = 0;
            this.txtBrandName.SelectionStart = 0;
            this.txtBrandName.ShortcutsEnabled = true;
            this.txtBrandName.Size = new System.Drawing.Size(277, 23);
            this.txtBrandName.TabIndex = 20;
            this.txtBrandName.UseSelectable = true;
            this.txtBrandName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBrandName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBrandCode
            // 
            // 
            // 
            // 
            this.txtBrandCode.CustomButton.Image = null;
            this.txtBrandCode.CustomButton.Location = new System.Drawing.Point(147, 1);
            this.txtBrandCode.CustomButton.Name = "";
            this.txtBrandCode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBrandCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBrandCode.CustomButton.TabIndex = 1;
            this.txtBrandCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBrandCode.CustomButton.UseSelectable = true;
            this.txtBrandCode.CustomButton.Visible = false;
            this.txtBrandCode.Lines = new string[0];
            this.txtBrandCode.Location = new System.Drawing.Point(188, 86);
            this.txtBrandCode.MaxLength = 32767;
            this.txtBrandCode.Name = "txtBrandCode";
            this.txtBrandCode.PasswordChar = '\0';
            this.txtBrandCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBrandCode.SelectedText = "";
            this.txtBrandCode.SelectionLength = 0;
            this.txtBrandCode.SelectionStart = 0;
            this.txtBrandCode.ShortcutsEnabled = true;
            this.txtBrandCode.Size = new System.Drawing.Size(169, 23);
            this.txtBrandCode.TabIndex = 19;
            this.txtBrandCode.UseSelectable = true;
            this.txtBrandCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBrandCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // BrandCreatedDate
            // 
            this.BrandCreatedDate.AutoSize = true;
            this.BrandCreatedDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.BrandCreatedDate.Location = new System.Drawing.Point(78, 193);
            this.BrandCreatedDate.Name = "BrandCreatedDate";
            this.BrandCreatedDate.Size = new System.Drawing.Size(87, 19);
            this.BrandCreatedDate.TabIndex = 17;
            this.BrandCreatedDate.Text = "Created On :";
            // 
            // BrandName
            // 
            this.BrandName.AutoSize = true;
            this.BrandName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.BrandName.Location = new System.Drawing.Point(80, 163);
            this.BrandName.Name = "BrandName";
            this.BrandName.Size = new System.Drawing.Size(85, 19);
            this.BrandName.TabIndex = 16;
            this.BrandName.Text = "Description :";
            // 
            // BrandCode
            // 
            this.BrandCode.AutoSize = true;
            this.BrandCode.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.BrandCode.Location = new System.Drawing.Point(78, 86);
            this.BrandCode.Name = "BrandCode";
            this.BrandCode.Size = new System.Drawing.Size(88, 19);
            this.BrandCode.TabIndex = 18;
            this.BrandCode.Text = "Brand Code :";
            // 
            // txtAccountNo
            // 
            // 
            // 
            // 
            this.txtAccountNo.CustomButton.Image = null;
            this.txtAccountNo.CustomButton.Location = new System.Drawing.Point(150, 1);
            this.txtAccountNo.CustomButton.Name = "";
            this.txtAccountNo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAccountNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAccountNo.CustomButton.TabIndex = 1;
            this.txtAccountNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAccountNo.CustomButton.UseSelectable = true;
            this.txtAccountNo.Lines = new string[0];
            this.txtAccountNo.Location = new System.Drawing.Point(188, 125);
            this.txtAccountNo.MaxLength = 32767;
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.PasswordChar = '\0';
            this.txtAccountNo.PromptText = "AccountNo";
            this.txtAccountNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccountNo.SelectedText = "";
            this.txtAccountNo.SelectionLength = 0;
            this.txtAccountNo.SelectionStart = 0;
            this.txtAccountNo.ShortcutsEnabled = true;
            this.txtAccountNo.ShowButton = true;
            this.txtAccountNo.Size = new System.Drawing.Size(172, 23);
            this.txtAccountNo.TabIndex = 27;
            this.txtAccountNo.UseSelectable = true;
            this.txtAccountNo.WaterMark = "AccountNo";
            this.txtAccountNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAccountNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtAccountNo.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtAccountNo_ButtonClick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(70, 126);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(112, 19);
            this.metroLabel1.TabIndex = 18;
            this.metroLabel1.Text = "Customer Code :";
            // 
            // frmBrandSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 409);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.BrandDate);
            this.Controls.Add(this.txtBrandName);
            this.Controls.Add(this.txtBrandCode);
            this.Controls.Add(this.BrandCreatedDate);
            this.Controls.Add(this.BrandName);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.BrandCode);
            this.Name = "frmBrandSetup";
            this.Text = "Brand Setup";
            this.Load += new System.EventHandler(this.frmBrandSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnClose;
        private MetroFramework.Controls.MetroTile btnDelete;
        private MetroFramework.Controls.MetroTile btnSearch;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroCheckBox chkActive;
        private System.Windows.Forms.DateTimePicker BrandDate;
        private MetroFramework.Controls.MetroTextBox txtBrandName;
        private MetroFramework.Controls.MetroTextBox txtBrandCode;
        private MetroFramework.Controls.MetroLabel BrandCreatedDate;
        private MetroFramework.Controls.MetroLabel BrandName;
        private MetroFramework.Controls.MetroLabel BrandCode;
        private MetroFramework.Controls.MetroTextBox txtAccountNo;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}