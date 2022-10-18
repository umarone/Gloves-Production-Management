namespace Accounts.UI
{
    partial class frmLogin
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
            this.mtxtUserName = new MetroFramework.Controls.MetroTextBox();
            this.mtxtPassword = new MetroFramework.Controls.MetroTextBox();
            this.mbtnLogin = new MetroFramework.Controls.MetroTile();
            this.mbtnExit = new MetroFramework.Controls.MetroTile();
            this.cbxCompany = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mtxtUserName
            // 
            // 
            // 
            // 
            this.mtxtUserName.CustomButton.Image = null;
            this.mtxtUserName.CustomButton.Location = new System.Drawing.Point(305, 1);
            this.mtxtUserName.CustomButton.Name = "";
            this.mtxtUserName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mtxtUserName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxtUserName.CustomButton.TabIndex = 1;
            this.mtxtUserName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxtUserName.CustomButton.UseSelectable = true;
            this.mtxtUserName.CustomButton.Visible = false;
            this.mtxtUserName.Lines = new string[0];
            this.mtxtUserName.Location = new System.Drawing.Point(86, 33);
            this.mtxtUserName.MaxLength = 32767;
            this.mtxtUserName.Name = "mtxtUserName";
            this.mtxtUserName.PasswordChar = '\0';
            this.mtxtUserName.PromptText = "User Name";
            this.mtxtUserName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxtUserName.SelectedText = "";
            this.mtxtUserName.SelectionLength = 0;
            this.mtxtUserName.SelectionStart = 0;
            this.mtxtUserName.ShortcutsEnabled = true;
            this.mtxtUserName.Size = new System.Drawing.Size(327, 23);
            this.mtxtUserName.TabIndex = 0;
            this.mtxtUserName.UseSelectable = true;
            this.mtxtUserName.UseStyleColors = true;
            this.mtxtUserName.WaterMark = "User Name";
            this.mtxtUserName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxtUserName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtxtUserName.Click += new System.EventHandler(this.mtxtUserName_Click);
            this.mtxtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtUserName_KeyPress);
            // 
            // mtxtPassword
            // 
            // 
            // 
            // 
            this.mtxtPassword.CustomButton.Image = null;
            this.mtxtPassword.CustomButton.Location = new System.Drawing.Point(305, 1);
            this.mtxtPassword.CustomButton.Name = "";
            this.mtxtPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mtxtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxtPassword.CustomButton.TabIndex = 1;
            this.mtxtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxtPassword.CustomButton.UseSelectable = true;
            this.mtxtPassword.CustomButton.Visible = false;
            this.mtxtPassword.Lines = new string[0];
            this.mtxtPassword.Location = new System.Drawing.Point(86, 67);
            this.mtxtPassword.MaxLength = 32767;
            this.mtxtPassword.Name = "mtxtPassword";
            this.mtxtPassword.PasswordChar = '●';
            this.mtxtPassword.PromptText = "Password";
            this.mtxtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxtPassword.SelectedText = "";
            this.mtxtPassword.SelectionLength = 0;
            this.mtxtPassword.SelectionStart = 0;
            this.mtxtPassword.ShortcutsEnabled = true;
            this.mtxtPassword.ShowClearButton = true;
            this.mtxtPassword.Size = new System.Drawing.Size(327, 23);
            this.mtxtPassword.TabIndex = 1;
            this.mtxtPassword.UseSelectable = true;
            this.mtxtPassword.UseSystemPasswordChar = true;
            this.mtxtPassword.WaterMark = "Password";
            this.mtxtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtxtPassword.Click += new System.EventHandler(this.mtxtPassword_Click);
            this.mtxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtPassword_KeyPress);
            // 
            // mbtnLogin
            // 
            this.mbtnLogin.ActiveControl = null;
            this.mbtnLogin.BackColor = System.Drawing.Color.DarkCyan;
            this.mbtnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.mbtnLogin.Location = new System.Drawing.Point(240, 102);
            this.mbtnLogin.Name = "mbtnLogin";
            this.mbtnLogin.Size = new System.Drawing.Size(87, 41);
            this.mbtnLogin.Style = MetroFramework.MetroColorStyle.Silver;
            this.mbtnLogin.TabIndex = 3;
            this.mbtnLogin.Text = "Login";
            this.mbtnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mbtnLogin.UseCustomBackColor = true;
            this.mbtnLogin.UseSelectable = true;
            this.mbtnLogin.Click += new System.EventHandler(this.mbtnLogin_Click);
            // 
            // mbtnExit
            // 
            this.mbtnExit.ActiveControl = null;
            this.mbtnExit.BackColor = System.Drawing.Color.DarkCyan;
            this.mbtnExit.Location = new System.Drawing.Point(328, 102);
            this.mbtnExit.Name = "mbtnExit";
            this.mbtnExit.Size = new System.Drawing.Size(87, 41);
            this.mbtnExit.Style = MetroFramework.MetroColorStyle.Silver;
            this.mbtnExit.TabIndex = 4;
            this.mbtnExit.Text = "Cancel";
            this.mbtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mbtnExit.UseCustomBackColor = true;
            this.mbtnExit.UseSelectable = true;
            this.mbtnExit.Click += new System.EventHandler(this.mbtnExit_Click);
            // 
            // cbxCompany
            // 
            this.cbxCompany.FormattingEnabled = true;
            this.cbxCompany.ItemHeight = 23;
            this.cbxCompany.Location = new System.Drawing.Point(86, 183);
            this.cbxCompany.Name = "cbxCompany";
            this.cbxCompany.Size = new System.Drawing.Size(327, 29);
            this.cbxCompany.Style = MetroFramework.MetroColorStyle.Silver;
            this.cbxCompany.TabIndex = 2;
            this.cbxCompany.UseSelectable = true;
            this.cbxCompany.Visible = false;
            this.cbxCompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxCompany_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(67, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 34);
            this.label1.TabIndex = 15;
            this.label1.Text = "FEROZ SONS Gloves";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 219);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxCompany);
            this.Controls.Add(this.mbtnExit);
            this.Controls.Add(this.mbtnLogin);
            this.Controls.Add(this.mtxtPassword);
            this.Controls.Add(this.mtxtUserName);
            this.DisplayHeader = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Movable = false;
            this.Name = "frmLogin";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox mtxtUserName;
        private MetroFramework.Controls.MetroTextBox mtxtPassword;
        private MetroFramework.Controls.MetroTile mbtnLogin;
        private MetroFramework.Controls.MetroTile mbtnExit;
        private MetroFramework.Controls.MetroComboBox cbxCompany;
        private System.Windows.Forms.Label label1;
    }
}