namespace Accounts.UI
{
    partial class frmHeadsSetup
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
            this.cbxHeadsLevel2 = new MetroFramework.Controls.MetroComboBox();
            this.btnSaveLevel2 = new MetroFramework.Controls.MetroTile();
            this.txtAccountNumberLevel2 = new MetroFramework.Controls.MetroTextBox();
            this.txtAccountNameLevel2 = new MetroFramework.Controls.MetroTextBox();
            this.cbxHeadsLevel3 = new MetroFramework.Controls.MetroComboBox();
            this.cbxSubHeadsLevel3 = new MetroFramework.Controls.MetroComboBox();
            this.btnSaveLevel3 = new MetroFramework.Controls.MetroTile();
            this.txtAccountNumberLevel3 = new MetroFramework.Controls.MetroTextBox();
            this.txtAccountNameLevel3 = new MetroFramework.Controls.MetroTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkLevel2InActive = new System.Windows.Forms.CheckBox();
            this.chkLevel3InActive = new System.Windows.Forms.CheckBox();
            this.grdHeadsLevel2 = new Accounts.UI.CustomDataGrid();
            this.colAccountId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdParent1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colACTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdHeadsLevel3 = new Accounts.UI.CustomDataGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHeadsLevel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHeadsLevel3)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxHeadsLevel2
            // 
            this.cbxHeadsLevel2.FormattingEnabled = true;
            this.cbxHeadsLevel2.ItemHeight = 23;
            this.cbxHeadsLevel2.Location = new System.Drawing.Point(23, 83);
            this.cbxHeadsLevel2.Name = "cbxHeadsLevel2";
            this.cbxHeadsLevel2.Size = new System.Drawing.Size(193, 29);
            this.cbxHeadsLevel2.Style = MetroFramework.MetroColorStyle.Silver;
            this.cbxHeadsLevel2.TabIndex = 2;
            this.cbxHeadsLevel2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cbxHeadsLevel2.UseSelectable = true;
            this.cbxHeadsLevel2.SelectedIndexChanged += new System.EventHandler(this.CbxHeads_SelectedIndexChanged);
            // 
            // btnSaveLevel2
            // 
            this.btnSaveLevel2.ActiveControl = null;
            this.btnSaveLevel2.Location = new System.Drawing.Point(14, 208);
            this.btnSaveLevel2.Name = "btnSaveLevel2";
            this.btnSaveLevel2.Size = new System.Drawing.Size(94, 71);
            this.btnSaveLevel2.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnSaveLevel2.TabIndex = 9;
            this.btnSaveLevel2.Text = "Save";
            this.btnSaveLevel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveLevel2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnSaveLevel2.UseSelectable = true;
            this.btnSaveLevel2.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAccountNumberLevel2
            // 
            // 
            // 
            // 
            this.txtAccountNumberLevel2.CustomButton.Image = null;
            this.txtAccountNumberLevel2.CustomButton.Location = new System.Drawing.Point(171, 1);
            this.txtAccountNumberLevel2.CustomButton.Name = "";
            this.txtAccountNumberLevel2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAccountNumberLevel2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAccountNumberLevel2.CustomButton.TabIndex = 1;
            this.txtAccountNumberLevel2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAccountNumberLevel2.CustomButton.UseSelectable = true;
            this.txtAccountNumberLevel2.CustomButton.Visible = false;
            this.txtAccountNumberLevel2.Enabled = false;
            this.txtAccountNumberLevel2.Lines = new string[0];
            this.txtAccountNumberLevel2.Location = new System.Drawing.Point(23, 126);
            this.txtAccountNumberLevel2.MaxLength = 32767;
            this.txtAccountNumberLevel2.Name = "txtAccountNumberLevel2";
            this.txtAccountNumberLevel2.PasswordChar = '\0';
            this.txtAccountNumberLevel2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccountNumberLevel2.SelectedText = "";
            this.txtAccountNumberLevel2.SelectionLength = 0;
            this.txtAccountNumberLevel2.SelectionStart = 0;
            this.txtAccountNumberLevel2.ShortcutsEnabled = true;
            this.txtAccountNumberLevel2.Size = new System.Drawing.Size(193, 23);
            this.txtAccountNumberLevel2.TabIndex = 11;
            this.txtAccountNumberLevel2.UseSelectable = true;
            this.txtAccountNumberLevel2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAccountNumberLevel2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtAccountNameLevel2
            // 
            // 
            // 
            // 
            this.txtAccountNameLevel2.CustomButton.Image = null;
            this.txtAccountNameLevel2.CustomButton.Location = new System.Drawing.Point(171, 1);
            this.txtAccountNameLevel2.CustomButton.Name = "";
            this.txtAccountNameLevel2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAccountNameLevel2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAccountNameLevel2.CustomButton.TabIndex = 1;
            this.txtAccountNameLevel2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAccountNameLevel2.CustomButton.UseSelectable = true;
            this.txtAccountNameLevel2.CustomButton.Visible = false;
            this.txtAccountNameLevel2.Lines = new string[0];
            this.txtAccountNameLevel2.Location = new System.Drawing.Point(23, 157);
            this.txtAccountNameLevel2.MaxLength = 32767;
            this.txtAccountNameLevel2.Name = "txtAccountNameLevel2";
            this.txtAccountNameLevel2.PasswordChar = '\0';
            this.txtAccountNameLevel2.PromptText = "Head Title";
            this.txtAccountNameLevel2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccountNameLevel2.SelectedText = "";
            this.txtAccountNameLevel2.SelectionLength = 0;
            this.txtAccountNameLevel2.SelectionStart = 0;
            this.txtAccountNameLevel2.ShortcutsEnabled = true;
            this.txtAccountNameLevel2.Size = new System.Drawing.Size(193, 23);
            this.txtAccountNameLevel2.TabIndex = 11;
            this.txtAccountNameLevel2.UseSelectable = true;
            this.txtAccountNameLevel2.WaterMark = "Head Title";
            this.txtAccountNameLevel2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAccountNameLevel2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cbxHeadsLevel3
            // 
            this.cbxHeadsLevel3.FormattingEnabled = true;
            this.cbxHeadsLevel3.ItemHeight = 23;
            this.cbxHeadsLevel3.Location = new System.Drawing.Point(481, 85);
            this.cbxHeadsLevel3.Name = "cbxHeadsLevel3";
            this.cbxHeadsLevel3.Size = new System.Drawing.Size(193, 29);
            this.cbxHeadsLevel3.Style = MetroFramework.MetroColorStyle.Silver;
            this.cbxHeadsLevel3.TabIndex = 2;
            this.cbxHeadsLevel3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cbxHeadsLevel3.UseSelectable = true;
            this.cbxHeadsLevel3.SelectedIndexChanged += new System.EventHandler(this.CbxHeads_SelectedIndexChanged);
            // 
            // cbxSubHeadsLevel3
            // 
            this.cbxSubHeadsLevel3.FormattingEnabled = true;
            this.cbxSubHeadsLevel3.ItemHeight = 23;
            this.cbxSubHeadsLevel3.Location = new System.Drawing.Point(481, 122);
            this.cbxSubHeadsLevel3.Name = "cbxSubHeadsLevel3";
            this.cbxSubHeadsLevel3.Size = new System.Drawing.Size(193, 29);
            this.cbxSubHeadsLevel3.Style = MetroFramework.MetroColorStyle.Silver;
            this.cbxSubHeadsLevel3.TabIndex = 2;
            this.cbxSubHeadsLevel3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cbxSubHeadsLevel3.UseSelectable = true;
            this.cbxSubHeadsLevel3.SelectedIndexChanged += new System.EventHandler(this.CbxHeads_SelectedIndexChanged);
            // 
            // btnSaveLevel3
            // 
            this.btnSaveLevel3.ActiveControl = null;
            this.btnSaveLevel3.Location = new System.Drawing.Point(14, 208);
            this.btnSaveLevel3.Name = "btnSaveLevel3";
            this.btnSaveLevel3.Size = new System.Drawing.Size(94, 71);
            this.btnSaveLevel3.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnSaveLevel3.TabIndex = 9;
            this.btnSaveLevel3.Text = "Save";
            this.btnSaveLevel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveLevel3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnSaveLevel3.UseSelectable = true;
            this.btnSaveLevel3.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAccountNumberLevel3
            // 
            // 
            // 
            // 
            this.txtAccountNumberLevel3.CustomButton.Image = null;
            this.txtAccountNumberLevel3.CustomButton.Location = new System.Drawing.Point(171, 1);
            this.txtAccountNumberLevel3.CustomButton.Name = "";
            this.txtAccountNumberLevel3.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAccountNumberLevel3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAccountNumberLevel3.CustomButton.TabIndex = 1;
            this.txtAccountNumberLevel3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAccountNumberLevel3.CustomButton.UseSelectable = true;
            this.txtAccountNumberLevel3.CustomButton.Visible = false;
            this.txtAccountNumberLevel3.Enabled = false;
            this.txtAccountNumberLevel3.Lines = new string[0];
            this.txtAccountNumberLevel3.Location = new System.Drawing.Point(481, 160);
            this.txtAccountNumberLevel3.MaxLength = 32767;
            this.txtAccountNumberLevel3.Name = "txtAccountNumberLevel3";
            this.txtAccountNumberLevel3.PasswordChar = '\0';
            this.txtAccountNumberLevel3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccountNumberLevel3.SelectedText = "";
            this.txtAccountNumberLevel3.SelectionLength = 0;
            this.txtAccountNumberLevel3.SelectionStart = 0;
            this.txtAccountNumberLevel3.ShortcutsEnabled = true;
            this.txtAccountNumberLevel3.Size = new System.Drawing.Size(193, 23);
            this.txtAccountNumberLevel3.TabIndex = 11;
            this.txtAccountNumberLevel3.UseSelectable = true;
            this.txtAccountNumberLevel3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAccountNumberLevel3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtAccountNameLevel3
            // 
            // 
            // 
            // 
            this.txtAccountNameLevel3.CustomButton.Image = null;
            this.txtAccountNameLevel3.CustomButton.Location = new System.Drawing.Point(171, 1);
            this.txtAccountNameLevel3.CustomButton.Name = "";
            this.txtAccountNameLevel3.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAccountNameLevel3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAccountNameLevel3.CustomButton.TabIndex = 1;
            this.txtAccountNameLevel3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAccountNameLevel3.CustomButton.UseSelectable = true;
            this.txtAccountNameLevel3.CustomButton.Visible = false;
            this.txtAccountNameLevel3.Lines = new string[0];
            this.txtAccountNameLevel3.Location = new System.Drawing.Point(481, 195);
            this.txtAccountNameLevel3.MaxLength = 32767;
            this.txtAccountNameLevel3.Name = "txtAccountNameLevel3";
            this.txtAccountNameLevel3.PasswordChar = '\0';
            this.txtAccountNameLevel3.PromptText = "Head Title";
            this.txtAccountNameLevel3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccountNameLevel3.SelectedText = "";
            this.txtAccountNameLevel3.SelectionLength = 0;
            this.txtAccountNameLevel3.SelectionStart = 0;
            this.txtAccountNameLevel3.ShortcutsEnabled = true;
            this.txtAccountNameLevel3.Size = new System.Drawing.Size(193, 23);
            this.txtAccountNameLevel3.TabIndex = 11;
            this.txtAccountNameLevel3.UseSelectable = true;
            this.txtAccountNameLevel3.WaterMark = "Head Title";
            this.txtAccountNameLevel3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAccountNameLevel3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLevel2InActive);
            this.groupBox1.Controls.Add(this.grdHeadsLevel2);
            this.groupBox1.Controls.Add(this.btnSaveLevel2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 483);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Level2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkLevel3InActive);
            this.groupBox2.Controls.Add(this.grdHeadsLevel3);
            this.groupBox2.Controls.Add(this.btnSaveLevel3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(467, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 483);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Level 3 ";
            // 
            // chkLevel2InActive
            // 
            this.chkLevel2InActive.AutoSize = true;
            this.chkLevel2InActive.Location = new System.Drawing.Point(14, 173);
            this.chkLevel2InActive.Name = "chkLevel2InActive";
            this.chkLevel2InActive.Size = new System.Drawing.Size(74, 20);
            this.chkLevel2InActive.TabIndex = 0;
            this.chkLevel2InActive.Text = "InActive";
            this.chkLevel2InActive.UseVisualStyleBackColor = true;
            // 
            // chkLevel3InActive
            // 
            this.chkLevel3InActive.AutoSize = true;
            this.chkLevel3InActive.Location = new System.Drawing.Point(15, 175);
            this.chkLevel3InActive.Name = "chkLevel3InActive";
            this.chkLevel3InActive.Size = new System.Drawing.Size(74, 20);
            this.chkLevel3InActive.TabIndex = 0;
            this.chkLevel3InActive.Text = "InActive";
            this.chkLevel3InActive.UseVisualStyleBackColor = true;
            // 
            // grdHeadsLevel2
            // 
            this.grdHeadsLevel2.AllowUserToAddRows = false;
            this.grdHeadsLevel2.AllowUserToDeleteRows = false;
            this.grdHeadsLevel2.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdHeadsLevel2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdHeadsLevel2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdHeadsLevel2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountId,
            this.colIdParent1,
            this.colAccountCode,
            this.colACTitle,
            this.colDiscription,
            this.colHeader});
            this.grdHeadsLevel2.EnableHeadersVisualStyles = false;
            this.grdHeadsLevel2.Location = new System.Drawing.Point(14, 285);
            this.grdHeadsLevel2.Name = "grdHeadsLevel2";
            this.grdHeadsLevel2.ReadOnly = true;
            this.grdHeadsLevel2.RowHeadersVisible = false;
            this.grdHeadsLevel2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdHeadsLevel2.Size = new System.Drawing.Size(426, 192);
            this.grdHeadsLevel2.TabIndex = 12;
            this.grdHeadsLevel2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdHeadsLevel2_CellDoubleClick);
            // 
            // colAccountId
            // 
            this.colAccountId.DataPropertyName = "IdAccount";
            this.colAccountId.HeaderText = "AccountId";
            this.colAccountId.Name = "colAccountId";
            this.colAccountId.ReadOnly = true;
            this.colAccountId.Visible = false;
            // 
            // colIdParent1
            // 
            this.colIdParent1.DataPropertyName = "IdParent";
            this.colIdParent1.HeaderText = "IdParent";
            this.colIdParent1.Name = "colIdParent1";
            this.colIdParent1.ReadOnly = true;
            this.colIdParent1.Visible = false;
            // 
            // colAccountCode
            // 
            this.colAccountCode.DataPropertyName = "AccountNo";
            this.colAccountCode.HeaderText = "Head Code";
            this.colAccountCode.Name = "colAccountCode";
            this.colAccountCode.ReadOnly = true;
            // 
            // colACTitle
            // 
            this.colACTitle.DataPropertyName = "AccountName";
            this.colACTitle.HeaderText = "Head Title";
            this.colACTitle.Name = "colACTitle";
            this.colACTitle.ReadOnly = true;
            this.colACTitle.Width = 170;
            // 
            // colDiscription
            // 
            this.colDiscription.DataPropertyName = "Discription";
            this.colDiscription.HeaderText = "Discription";
            this.colDiscription.Name = "colDiscription";
            this.colDiscription.ReadOnly = true;
            this.colDiscription.Visible = false;
            this.colDiscription.Width = 210;
            // 
            // colHeader
            // 
            this.colHeader.DataPropertyName = "AccountType";
            this.colHeader.HeaderText = "Head";
            this.colHeader.Name = "colHeader";
            this.colHeader.ReadOnly = true;
            this.colHeader.Width = 150;
            // 
            // grdHeadsLevel3
            // 
            this.grdHeadsLevel3.AllowUserToAddRows = false;
            this.grdHeadsLevel3.AllowUserToDeleteRows = false;
            this.grdHeadsLevel3.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdHeadsLevel3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdHeadsLevel3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdHeadsLevel3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.grdHeadsLevel3.EnableHeadersVisualStyles = false;
            this.grdHeadsLevel3.Location = new System.Drawing.Point(14, 285);
            this.grdHeadsLevel3.Name = "grdHeadsLevel3";
            this.grdHeadsLevel3.ReadOnly = true;
            this.grdHeadsLevel3.RowHeadersVisible = false;
            this.grdHeadsLevel3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdHeadsLevel3.Size = new System.Drawing.Size(424, 192);
            this.grdHeadsLevel3.TabIndex = 12;
            this.grdHeadsLevel3.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdHeadsLevel3_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IdAccount";
            this.dataGridViewTextBoxColumn1.HeaderText = "AccountId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "IdParent";
            this.dataGridViewTextBoxColumn2.HeaderText = "IdParent";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "AccountNo";
            this.dataGridViewTextBoxColumn3.HeaderText = "Head Code";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "AccountName";
            this.dataGridViewTextBoxColumn4.HeaderText = "Head Title";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 170;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Discription";
            this.dataGridViewTextBoxColumn5.HeaderText = "Discription";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 210;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "AccountType";
            this.dataGridViewTextBoxColumn6.HeaderText = "Head";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // frmHeadsSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 567);
            this.Controls.Add(this.txtAccountNameLevel3);
            this.Controls.Add(this.txtAccountNumberLevel3);
            this.Controls.Add(this.txtAccountNameLevel2);
            this.Controls.Add(this.txtAccountNumberLevel2);
            this.Controls.Add(this.cbxSubHeadsLevel3);
            this.Controls.Add(this.cbxHeadsLevel3);
            this.Controls.Add(this.cbxHeadsLevel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmHeadsSetup";
            this.Text = "Heads Setup";
            this.Load += new System.EventHandler(this.frmHeadsSetup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHeadsLevel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHeadsLevel3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cbxHeadsLevel2;
        private MetroFramework.Controls.MetroTile btnSaveLevel2;
        private MetroFramework.Controls.MetroTextBox txtAccountNumberLevel2;
        private MetroFramework.Controls.MetroTextBox txtAccountNameLevel2;
        private CustomDataGrid grdHeadsLevel2;
        private MetroFramework.Controls.MetroComboBox cbxHeadsLevel3;
        private MetroFramework.Controls.MetroComboBox cbxSubHeadsLevel3;
        private MetroFramework.Controls.MetroTile btnSaveLevel3;
        private MetroFramework.Controls.MetroTextBox txtAccountNumberLevel3;
        private MetroFramework.Controls.MetroTextBox txtAccountNameLevel3;
        private CustomDataGrid grdHeadsLevel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdParent1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colACTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkLevel2InActive;
        private System.Windows.Forms.CheckBox chkLevel3InActive;
    }
}