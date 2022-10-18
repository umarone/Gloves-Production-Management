namespace Accounts.UI
{
    partial class frmWorkPurchases
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkPurchases));
            this.VEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblVoucherNo = new MetroFramework.Controls.MetroLabel();
            this.VDate = new MetroFramework.Controls.MetroDateTime();
            this.lblDate = new MetroFramework.Controls.MetroLabel();
            this.grpSales = new System.Windows.Forms.GroupBox();
            this.cbxNaturalAccounts = new MetroFramework.Controls.MetroComboBox();
            this.lblSelectAccount = new MetroFramework.Controls.MetroLabel();
            this.txtPurchasesAccountName = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.lblDiscription = new MetroFramework.Controls.MetroLabel();
            this.txtDescription = new MetroFramework.Controls.MetroTextBox();
            this.txtCreditAmount = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnAddAccount = new MetroFramework.Controls.MetroTile();
            this.btnRefresh = new MetroFramework.Controls.MetroTile();
            this.grpSales.SuspendLayout();
            this.SuspendLayout();
            // 
            // VEditBox
            // 
            // 
            // 
            // 
            this.VEditBox.CustomButton.Image = null;
            this.VEditBox.CustomButton.Location = new System.Drawing.Point(145, 1);
            this.VEditBox.CustomButton.Name = "";
            this.VEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.VEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.VEditBox.CustomButton.TabIndex = 1;
            this.VEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.VEditBox.CustomButton.UseSelectable = true;
            this.VEditBox.Enabled = false;
            this.VEditBox.Lines = new string[0];
            this.VEditBox.Location = new System.Drawing.Point(114, 80);
            this.VEditBox.MaxLength = 32767;
            this.VEditBox.Name = "VEditBox";
            this.VEditBox.PasswordChar = '\0';
            this.VEditBox.PromptText = "Voucher No";
            this.VEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.VEditBox.SelectedText = "";
            this.VEditBox.SelectionLength = 0;
            this.VEditBox.SelectionStart = 0;
            this.VEditBox.ShortcutsEnabled = true;
            this.VEditBox.ShowButton = true;
            this.VEditBox.Size = new System.Drawing.Size(167, 23);
            this.VEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.VEditBox.TabIndex = 2;
            this.VEditBox.UseSelectable = true;
            this.VEditBox.WaterMark = "Voucher No";
            this.VEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.VEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblVoucherNo.Location = new System.Drawing.Point(18, 80);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(89, 19);
            this.lblVoucherNo.TabIndex = 22;
            this.lblVoucherNo.Text = "Voucher No :";
            // 
            // VDate
            // 
            this.VDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.VDate.Location = new System.Drawing.Point(360, 77);
            this.VDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.VDate.Name = "VDate";
            this.VDate.Size = new System.Drawing.Size(170, 29);
            this.VDate.TabIndex = 25;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDate.Location = new System.Drawing.Point(309, 79);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 19);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date :";
            // 
            // grpSales
            // 
            this.grpSales.Controls.Add(this.cbxNaturalAccounts);
            this.grpSales.Controls.Add(this.lblSelectAccount);
            this.grpSales.Controls.Add(this.txtPurchasesAccountName);
            this.grpSales.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSales.Location = new System.Drawing.Point(21, 163);
            this.grpSales.Name = "grpSales";
            this.grpSales.Size = new System.Drawing.Size(512, 66);
            this.grpSales.TabIndex = 0;
            this.grpSales.TabStop = false;
            this.grpSales.Text = "Purchases Information";
            // 
            // cbxNaturalAccounts
            // 
            this.cbxNaturalAccounts.FormattingEnabled = true;
            this.cbxNaturalAccounts.ItemHeight = 23;
            this.cbxNaturalAccounts.Location = new System.Drawing.Point(107, 24);
            this.cbxNaturalAccounts.Name = "cbxNaturalAccounts";
            this.cbxNaturalAccounts.Size = new System.Drawing.Size(175, 29);
            this.cbxNaturalAccounts.TabIndex = 2;
            this.cbxNaturalAccounts.UseSelectable = true;
            this.cbxNaturalAccounts.SelectedIndexChanged += new System.EventHandler(this.cbxNaturalAccounts_SelectedIndexChanged);
            this.cbxNaturalAccounts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxNaturalAccounts_KeyPress);
            // 
            // lblSelectAccount
            // 
            this.lblSelectAccount.AutoSize = true;
            this.lblSelectAccount.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblSelectAccount.Location = new System.Drawing.Point(1, 28);
            this.lblSelectAccount.Name = "lblSelectAccount";
            this.lblSelectAccount.Size = new System.Drawing.Size(104, 19);
            this.lblSelectAccount.TabIndex = 1;
            this.lblSelectAccount.Text = "Purchases A/C :";
            // 
            // txtPurchasesAccountName
            // 
            // 
            // 
            // 
            this.txtPurchasesAccountName.CustomButton.Image = null;
            this.txtPurchasesAccountName.CustomButton.Location = new System.Drawing.Point(125, 1);
            this.txtPurchasesAccountName.CustomButton.Name = "";
            this.txtPurchasesAccountName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPurchasesAccountName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPurchasesAccountName.CustomButton.TabIndex = 1;
            this.txtPurchasesAccountName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPurchasesAccountName.CustomButton.UseSelectable = true;
            this.txtPurchasesAccountName.CustomButton.Visible = false;
            this.txtPurchasesAccountName.Enabled = false;
            this.txtPurchasesAccountName.Lines = new string[0];
            this.txtPurchasesAccountName.Location = new System.Drawing.Point(287, 26);
            this.txtPurchasesAccountName.MaxLength = 32767;
            this.txtPurchasesAccountName.Name = "txtPurchasesAccountName";
            this.txtPurchasesAccountName.PasswordChar = '\0';
            this.txtPurchasesAccountName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPurchasesAccountName.SelectedText = "";
            this.txtPurchasesAccountName.SelectionLength = 0;
            this.txtPurchasesAccountName.SelectionStart = 0;
            this.txtPurchasesAccountName.ShortcutsEnabled = true;
            this.txtPurchasesAccountName.Size = new System.Drawing.Size(147, 23);
            this.txtPurchasesAccountName.TabIndex = 1;
            this.txtPurchasesAccountName.UseSelectable = true;
            this.txtPurchasesAccountName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPurchasesAccountName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(429, 299);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 40);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Post";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDiscription
            // 
            this.lblDiscription.AutoSize = true;
            this.lblDiscription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDiscription.Location = new System.Drawing.Point(18, 119);
            this.lblDiscription.Name = "lblDiscription";
            this.lblDiscription.Size = new System.Drawing.Size(81, 19);
            this.lblDiscription.TabIndex = 30;
            this.lblDiscription.Text = "Discription :";
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.CustomButton.Image = null;
            this.txtDescription.CustomButton.Location = new System.Drawing.Point(378, 2);
            this.txtDescription.CustomButton.Name = "";
            this.txtDescription.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.txtDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDescription.CustomButton.TabIndex = 1;
            this.txtDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDescription.CustomButton.UseSelectable = true;
            this.txtDescription.CustomButton.Visible = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(114, 112);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(416, 40);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.UseSelectable = true;
            this.txtDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtCreditAmount
            // 
            // 
            // 
            // 
            this.txtCreditAmount.CustomButton.Image = null;
            this.txtCreditAmount.CustomButton.Location = new System.Drawing.Point(132, 1);
            this.txtCreditAmount.CustomButton.Name = "";
            this.txtCreditAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCreditAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCreditAmount.CustomButton.TabIndex = 1;
            this.txtCreditAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCreditAmount.CustomButton.UseSelectable = true;
            this.txtCreditAmount.CustomButton.Visible = false;
            this.txtCreditAmount.Enabled = false;
            this.txtCreditAmount.Lines = new string[0];
            this.txtCreditAmount.Location = new System.Drawing.Point(379, 252);
            this.txtCreditAmount.MaxLength = 32767;
            this.txtCreditAmount.Name = "txtCreditAmount";
            this.txtCreditAmount.PasswordChar = '\0';
            this.txtCreditAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCreditAmount.SelectedText = "";
            this.txtCreditAmount.SelectionLength = 0;
            this.txtCreditAmount.SelectionStart = 0;
            this.txtCreditAmount.ShortcutsEnabled = true;
            this.txtCreditAmount.Size = new System.Drawing.Size(154, 23);
            this.txtCreditAmount.TabIndex = 2;
            this.txtCreditAmount.UseSelectable = true;
            this.txtCreditAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCreditAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(269, 253);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(100, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Total Amount :";
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.ActiveControl = null;
            this.btnAddAccount.Location = new System.Drawing.Point(223, 299);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(205, 40);
            this.btnAddAccount.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnAddAccount.TabIndex = 1;
            this.btnAddAccount.Text = "Add Purchasing Account Here";
            this.btnAddAccount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddAccount.UseSelectable = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ActiveControl = null;
            this.btnRefresh.Location = new System.Drawing.Point(24, 235);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(193, 104);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnRefresh.TileImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.TileImage")));
            this.btnRefresh.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRefresh.UseSelectable = true;
            this.btnRefresh.UseTileImage = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmWorkPurchases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 362);
            this.ControlBox = false;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblDiscription);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtCreditAmount);
            this.Controls.Add(this.btnAddAccount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpSales);
            this.Controls.Add(this.VDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.VEditBox);
            this.Controls.Add(this.lblVoucherNo);
            this.MinimizeBox = false;
            this.Name = "frmWorkPurchases";
            this.Text = "Work Purchases Voucher";
            this.Load += new System.EventHandler(this.frmWorkPurchases_Load);
            this.grpSales.ResumeLayout(false);
            this.grpSales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox VEditBox;
        private MetroFramework.Controls.MetroLabel lblVoucherNo;
        private MetroFramework.Controls.MetroDateTime VDate;
        private MetroFramework.Controls.MetroLabel lblDate;
        private System.Windows.Forms.GroupBox grpSales;
        private MetroFramework.Controls.MetroComboBox cbxNaturalAccounts;
        private MetroFramework.Controls.MetroLabel lblSelectAccount;
        private MetroFramework.Controls.MetroTextBox txtPurchasesAccountName;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroLabel lblDiscription;
        private MetroFramework.Controls.MetroTextBox txtDescription;
        private MetroFramework.Controls.MetroTextBox txtCreditAmount;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTile btnAddAccount;
        private MetroFramework.Controls.MetroTile btnRefresh;
    }
}