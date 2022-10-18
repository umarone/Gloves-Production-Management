namespace Accounts.UI
{
    partial class frmPersons
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersons));
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.txtDiscription = new MetroFramework.Controls.MetroTextBox();
            this.txtSalary = new MetroFramework.Controls.MetroTextBox();
            this.txtNTN = new MetroFramework.Controls.MetroTextBox();
            this.txtNIC = new MetroFramework.Controls.MetroTextBox();
            this.txtContact = new MetroFramework.Controls.MetroTextBox();
            this.txtLastName = new MetroFramework.Controls.MetroTextBox();
            this.txtAccountNo = new MetroFramework.Controls.MetroTextBox();
            this.txtFirstName = new MetroFramework.Controls.MetroTextBox();
            this.PersonPic = new System.Windows.Forms.PictureBox();
            this.txtPersonalCode = new MetroFramework.Controls.MetroTextBox();
            this.picDialog = new System.Windows.Forms.OpenFileDialog();
            this.mtlPic = new MetroFramework.Controls.MetroTile();
            this.btnNew = new MetroFramework.Controls.MetroTile();
            this.cbxDepartments = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbxCurrencies = new MetroFramework.Controls.MetroComboBox();
            this.CbxDepartmentsHead = new MetroFramework.Controls.MetroComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PersonPic)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(25, 407);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(222, 41);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDiscription
            // 
            // 
            // 
            // 
            this.txtDiscription.CustomButton.Image = null;
            this.txtDiscription.CustomButton.Location = new System.Drawing.Point(624, 1);
            this.txtDiscription.CustomButton.Name = "";
            this.txtDiscription.CustomButton.Size = new System.Drawing.Size(51, 51);
            this.txtDiscription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDiscription.CustomButton.TabIndex = 1;
            this.txtDiscription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDiscription.CustomButton.UseSelectable = true;
            this.txtDiscription.CustomButton.Visible = false;
            this.txtDiscription.Lines = new string[0];
            this.txtDiscription.Location = new System.Drawing.Point(25, 348);
            this.txtDiscription.MaxLength = 32767;
            this.txtDiscription.Multiline = true;
            this.txtDiscription.Name = "txtDiscription";
            this.txtDiscription.PasswordChar = '\0';
            this.txtDiscription.PromptText = "Person Additional Information";
            this.txtDiscription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDiscription.SelectedText = "";
            this.txtDiscription.SelectionLength = 0;
            this.txtDiscription.SelectionStart = 0;
            this.txtDiscription.ShortcutsEnabled = true;
            this.txtDiscription.Size = new System.Drawing.Size(676, 53);
            this.txtDiscription.Style = MetroFramework.MetroColorStyle.Green;
            this.txtDiscription.TabIndex = 8;
            this.txtDiscription.UseSelectable = true;
            this.txtDiscription.WaterMark = "Person Additional Information";
            this.txtDiscription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDiscription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtSalary
            // 
            // 
            // 
            // 
            this.txtSalary.CustomButton.Image = null;
            this.txtSalary.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.txtSalary.CustomButton.Name = "";
            this.txtSalary.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSalary.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSalary.CustomButton.TabIndex = 1;
            this.txtSalary.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSalary.CustomButton.UseSelectable = true;
            this.txtSalary.CustomButton.Visible = false;
            this.txtSalary.Lines = new string[0];
            this.txtSalary.Location = new System.Drawing.Point(281, 216);
            this.txtSalary.MaxLength = 32767;
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.PasswordChar = '\0';
            this.txtSalary.PromptText = "Salary";
            this.txtSalary.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSalary.SelectedText = "";
            this.txtSalary.SelectionLength = 0;
            this.txtSalary.SelectionStart = 0;
            this.txtSalary.ShortcutsEnabled = true;
            this.txtSalary.Size = new System.Drawing.Size(222, 23);
            this.txtSalary.TabIndex = 7;
            this.txtSalary.UseSelectable = true;
            this.txtSalary.WaterMark = "Salary";
            this.txtSalary.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSalary.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtNTN
            // 
            // 
            // 
            // 
            this.txtNTN.CustomButton.Image = null;
            this.txtNTN.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.txtNTN.CustomButton.Name = "";
            this.txtNTN.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNTN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNTN.CustomButton.TabIndex = 1;
            this.txtNTN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNTN.CustomButton.UseSelectable = true;
            this.txtNTN.CustomButton.Visible = false;
            this.txtNTN.Lines = new string[0];
            this.txtNTN.Location = new System.Drawing.Point(25, 216);
            this.txtNTN.MaxLength = 32767;
            this.txtNTN.Name = "txtNTN";
            this.txtNTN.PasswordChar = '\0';
            this.txtNTN.PromptText = "VAT Number";
            this.txtNTN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNTN.SelectedText = "";
            this.txtNTN.SelectionLength = 0;
            this.txtNTN.SelectionStart = 0;
            this.txtNTN.ShortcutsEnabled = true;
            this.txtNTN.Size = new System.Drawing.Size(222, 23);
            this.txtNTN.TabIndex = 6;
            this.txtNTN.UseSelectable = true;
            this.txtNTN.WaterMark = "VAT Number";
            this.txtNTN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNTN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtNIC
            // 
            // 
            // 
            // 
            this.txtNIC.CustomButton.Image = null;
            this.txtNIC.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.txtNIC.CustomButton.Name = "";
            this.txtNIC.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNIC.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNIC.CustomButton.TabIndex = 1;
            this.txtNIC.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNIC.CustomButton.UseSelectable = true;
            this.txtNIC.CustomButton.Visible = false;
            this.txtNIC.Lines = new string[0];
            this.txtNIC.Location = new System.Drawing.Point(25, 173);
            this.txtNIC.MaxLength = 32767;
            this.txtNIC.Name = "txtNIC";
            this.txtNIC.PasswordChar = '\0';
            this.txtNIC.PromptText = "CNIC";
            this.txtNIC.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNIC.SelectedText = "";
            this.txtNIC.SelectionLength = 0;
            this.txtNIC.SelectionStart = 0;
            this.txtNIC.ShortcutsEnabled = true;
            this.txtNIC.Size = new System.Drawing.Size(222, 23);
            this.txtNIC.TabIndex = 4;
            this.txtNIC.UseSelectable = true;
            this.txtNIC.WaterMark = "CNIC";
            this.txtNIC.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNIC.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtContact
            // 
            // 
            // 
            // 
            this.txtContact.CustomButton.Image = null;
            this.txtContact.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.txtContact.CustomButton.Name = "";
            this.txtContact.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtContact.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtContact.CustomButton.TabIndex = 1;
            this.txtContact.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtContact.CustomButton.UseSelectable = true;
            this.txtContact.CustomButton.Visible = false;
            this.txtContact.Lines = new string[0];
            this.txtContact.Location = new System.Drawing.Point(280, 173);
            this.txtContact.MaxLength = 32767;
            this.txtContact.Name = "txtContact";
            this.txtContact.PasswordChar = '\0';
            this.txtContact.PromptText = "Contact";
            this.txtContact.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContact.SelectedText = "";
            this.txtContact.SelectionLength = 0;
            this.txtContact.SelectionStart = 0;
            this.txtContact.ShortcutsEnabled = true;
            this.txtContact.Size = new System.Drawing.Size(222, 23);
            this.txtContact.TabIndex = 5;
            this.txtContact.UseSelectable = true;
            this.txtContact.WaterMark = "Contact";
            this.txtContact.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContact.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtLastName
            // 
            // 
            // 
            // 
            this.txtLastName.CustomButton.Image = null;
            this.txtLastName.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.txtLastName.CustomButton.Name = "";
            this.txtLastName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtLastName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLastName.CustomButton.TabIndex = 1;
            this.txtLastName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLastName.CustomButton.UseSelectable = true;
            this.txtLastName.CustomButton.Visible = false;
            this.txtLastName.Lines = new string[0];
            this.txtLastName.Location = new System.Drawing.Point(281, 130);
            this.txtLastName.MaxLength = 32767;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PasswordChar = '\0';
            this.txtLastName.PromptText = "Last Name";
            this.txtLastName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLastName.SelectedText = "";
            this.txtLastName.SelectionLength = 0;
            this.txtLastName.SelectionStart = 0;
            this.txtLastName.ShortcutsEnabled = true;
            this.txtLastName.Size = new System.Drawing.Size(222, 23);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.UseSelectable = true;
            this.txtLastName.WaterMark = "Last Name";
            this.txtLastName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLastName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtAccountNo
            // 
            // 
            // 
            // 
            this.txtAccountNo.CustomButton.Image = null;
            this.txtAccountNo.CustomButton.Location = new System.Drawing.Point(180, 1);
            this.txtAccountNo.CustomButton.Name = "";
            this.txtAccountNo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAccountNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAccountNo.CustomButton.TabIndex = 1;
            this.txtAccountNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAccountNo.CustomButton.UseSelectable = true;
            this.txtAccountNo.Lines = new string[0];
            this.txtAccountNo.Location = new System.Drawing.Point(25, 92);
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
            this.txtAccountNo.Size = new System.Drawing.Size(202, 23);
            this.txtAccountNo.TabIndex = 0;
            this.txtAccountNo.UseSelectable = true;
            this.txtAccountNo.WaterMark = "AccountNo";
            this.txtAccountNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAccountNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtAccountNo.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtAccountNo_ButtonClick);
            // 
            // txtFirstName
            // 
            // 
            // 
            // 
            this.txtFirstName.CustomButton.Image = null;
            this.txtFirstName.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.txtFirstName.CustomButton.Name = "";
            this.txtFirstName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtFirstName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFirstName.CustomButton.TabIndex = 1;
            this.txtFirstName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFirstName.CustomButton.UseSelectable = true;
            this.txtFirstName.CustomButton.Visible = false;
            this.txtFirstName.Enabled = false;
            this.txtFirstName.Lines = new string[0];
            this.txtFirstName.Location = new System.Drawing.Point(25, 130);
            this.txtFirstName.MaxLength = 32767;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PasswordChar = '\0';
            this.txtFirstName.PromptText = "First Name";
            this.txtFirstName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFirstName.SelectedText = "";
            this.txtFirstName.SelectionLength = 0;
            this.txtFirstName.SelectionStart = 0;
            this.txtFirstName.ShortcutsEnabled = true;
            this.txtFirstName.Size = new System.Drawing.Size(222, 23);
            this.txtFirstName.TabIndex = 2;
            this.txtFirstName.UseSelectable = true;
            this.txtFirstName.WaterMark = "First Name";
            this.txtFirstName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFirstName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // PersonPic
            // 
            this.PersonPic.Image = ((System.Drawing.Image)(resources.GetObject("PersonPic.Image")));
            this.PersonPic.Location = new System.Drawing.Point(529, 92);
            this.PersonPic.Name = "PersonPic";
            this.PersonPic.Size = new System.Drawing.Size(164, 147);
            this.PersonPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PersonPic.TabIndex = 17;
            this.PersonPic.TabStop = false;
            // 
            // txtPersonalCode
            // 
            // 
            // 
            // 
            this.txtPersonalCode.CustomButton.Image = null;
            this.txtPersonalCode.CustomButton.Location = new System.Drawing.Point(200, 1);
            this.txtPersonalCode.CustomButton.Name = "";
            this.txtPersonalCode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPersonalCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPersonalCode.CustomButton.TabIndex = 1;
            this.txtPersonalCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPersonalCode.CustomButton.UseSelectable = true;
            this.txtPersonalCode.CustomButton.Visible = false;
            this.txtPersonalCode.Lines = new string[0];
            this.txtPersonalCode.Location = new System.Drawing.Point(280, 92);
            this.txtPersonalCode.MaxLength = 32767;
            this.txtPersonalCode.Name = "txtPersonalCode";
            this.txtPersonalCode.PasswordChar = '\0';
            this.txtPersonalCode.PromptText = "Personal Code";
            this.txtPersonalCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPersonalCode.SelectedText = "";
            this.txtPersonalCode.SelectionLength = 0;
            this.txtPersonalCode.SelectionStart = 0;
            this.txtPersonalCode.ShortcutsEnabled = true;
            this.txtPersonalCode.Size = new System.Drawing.Size(222, 23);
            this.txtPersonalCode.TabIndex = 1;
            this.txtPersonalCode.UseSelectable = true;
            this.txtPersonalCode.WaterMark = "Personal Code";
            this.txtPersonalCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPersonalCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // picDialog
            // 
            this.picDialog.FileName = "openFileDialog1";
            // 
            // mtlPic
            // 
            this.mtlPic.ActiveControl = null;
            this.mtlPic.Location = new System.Drawing.Point(529, 249);
            this.mtlPic.Name = "mtlPic";
            this.mtlPic.Size = new System.Drawing.Size(164, 41);
            this.mtlPic.Style = MetroFramework.MetroColorStyle.Silver;
            this.mtlPic.TabIndex = 9;
            this.mtlPic.Text = "Browse Picture";
            this.mtlPic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtlPic.UseSelectable = true;
            this.mtlPic.Click += new System.EventHandler(this.mtlPic_Click);
            // 
            // btnNew
            // 
            this.btnNew.ActiveControl = null;
            this.btnNew.Location = new System.Drawing.Point(253, 407);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(222, 41);
            this.btnNew.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "New Customer";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNew.UseSelectable = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // cbxDepartments
            // 
            this.cbxDepartments.FormattingEnabled = true;
            this.cbxDepartments.ItemHeight = 23;
            this.cbxDepartments.Location = new System.Drawing.Point(281, 295);
            this.cbxDepartments.Name = "cbxDepartments";
            this.cbxDepartments.Size = new System.Drawing.Size(222, 29);
            this.cbxDepartments.TabIndex = 18;
            this.cbxDepartments.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(21, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(680, 23);
            this.metroLabel1.TabIndex = 19;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "------------------------------";
            // 
            // cbxCurrencies
            // 
            this.cbxCurrencies.FormattingEnabled = true;
            this.cbxCurrencies.ItemHeight = 23;
            this.cbxCurrencies.Location = new System.Drawing.Point(25, 249);
            this.cbxCurrencies.Name = "cbxCurrencies";
            this.cbxCurrencies.Size = new System.Drawing.Size(477, 29);
            this.cbxCurrencies.TabIndex = 18;
            this.cbxCurrencies.UseSelectable = true;
            // 
            // CbxDepartmentsHead
            // 
            this.CbxDepartmentsHead.FormattingEnabled = true;
            this.CbxDepartmentsHead.ItemHeight = 23;
            this.CbxDepartmentsHead.Items.AddRange(new object[] {
            "",
            "Gloves Departments",
            "Garments Departments"});
            this.CbxDepartmentsHead.Location = new System.Drawing.Point(23, 295);
            this.CbxDepartmentsHead.Name = "CbxDepartmentsHead";
            this.CbxDepartmentsHead.Size = new System.Drawing.Size(222, 29);
            this.CbxDepartmentsHead.TabIndex = 18;
            this.CbxDepartmentsHead.UseSelectable = true;
            this.CbxDepartmentsHead.SelectedIndexChanged += new System.EventHandler(this.CbxDepartmentsHead_SelectedIndexChanged);
            // 
            // frmPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 498);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cbxCurrencies);
            this.Controls.Add(this.CbxDepartmentsHead);
            this.Controls.Add(this.cbxDepartments);
            this.Controls.Add(this.PersonPic);
            this.Controls.Add(this.mtlPic);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDiscription);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.txtNTN);
            this.Controls.Add(this.txtNIC);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.txtPersonalCode);
            this.Controls.Add(this.txtFirstName);
            this.KeyPreview = true;
            this.Name = "frmPersons";
            this.Text = "Person Setup";
            this.Load += new System.EventHandler(this.frmPersons_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmPersons_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.PersonPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroTextBox txtDiscription;
        private MetroFramework.Controls.MetroTextBox txtSalary;
        private MetroFramework.Controls.MetroTextBox txtNTN;
        private MetroFramework.Controls.MetroTextBox txtNIC;
        private MetroFramework.Controls.MetroTextBox txtContact;
        private MetroFramework.Controls.MetroTextBox txtLastName;
        private MetroFramework.Controls.MetroTextBox txtAccountNo;
        private MetroFramework.Controls.MetroTextBox txtFirstName;
        private System.Windows.Forms.PictureBox PersonPic;
        private MetroFramework.Controls.MetroTextBox txtPersonalCode;
        private System.Windows.Forms.OpenFileDialog picDialog;
        private MetroFramework.Controls.MetroTile mtlPic;
        private MetroFramework.Controls.MetroTile btnNew;
        private MetroFramework.Controls.MetroComboBox cbxDepartments;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cbxCurrencies;
        private MetroFramework.Controls.MetroComboBox CbxDepartmentsHead;

    }
}