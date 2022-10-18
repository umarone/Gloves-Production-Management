namespace Accounts.UI
{
    partial class frmTanneryGenerateLotNo
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbxVehicles = new System.Windows.Forms.ComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnDrummingGenerateLot = new MetroFramework.Controls.MetroTile();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.DtLot = new MetroFramework.Controls.MetroDateTime();
            this.txtLotNo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cbxLotType = new MetroFramework.Controls.MetroComboBox();
            this.txtQuality = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtLotWeight = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(833, 23);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------";
            // 
            // cbxVehicles
            // 
            this.cbxVehicles.FormattingEnabled = true;
            this.cbxVehicles.Location = new System.Drawing.Point(112, 89);
            this.cbxVehicles.Name = "cbxVehicles";
            this.cbxVehicles.Size = new System.Drawing.Size(157, 21);
            this.cbxVehicles.TabIndex = 33;
            this.cbxVehicles.SelectedIndexChanged += new System.EventHandler(this.cbxVehicles_SelectedIndexChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(28, 87);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(81, 19);
            this.metroLabel2.TabIndex = 32;
            this.metroLabel2.Text = "Vehicle No :";
            // 
            // btnDrummingGenerateLot
            // 
            this.btnDrummingGenerateLot.ActiveControl = null;
            this.btnDrummingGenerateLot.Location = new System.Drawing.Point(729, 172);
            this.btnDrummingGenerateLot.Name = "btnDrummingGenerateLot";
            this.btnDrummingGenerateLot.Size = new System.Drawing.Size(127, 59);
            this.btnDrummingGenerateLot.Style = MetroFramework.MetroColorStyle.Green;
            this.btnDrummingGenerateLot.TabIndex = 34;
            this.btnDrummingGenerateLot.Text = "Generate Lot";
            this.btnDrummingGenerateLot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDrummingGenerateLot.UseSelectable = true;
            this.btnDrummingGenerateLot.Click += new System.EventHandler(this.btnDrummingGenerateLot_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(24, 125);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(58, 19);
            this.metroLabel3.TabIndex = 37;
            this.metroLabel3.Text = "Lot No :";
            // 
            // DtLot
            // 
            this.DtLot.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtLot.Location = new System.Drawing.Point(250, 124);
            this.DtLot.MinimumSize = new System.Drawing.Size(0, 29);
            this.DtLot.Name = "DtLot";
            this.DtLot.Size = new System.Drawing.Size(122, 29);
            this.DtLot.TabIndex = 41;
            // 
            // txtLotNo
            // 
            // 
            // 
            // 
            this.txtLotNo.CustomButton.Image = null;
            this.txtLotNo.CustomButton.Location = new System.Drawing.Point(69, 1);
            this.txtLotNo.CustomButton.Name = "";
            this.txtLotNo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtLotNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLotNo.CustomButton.TabIndex = 1;
            this.txtLotNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLotNo.CustomButton.UseSelectable = true;
            this.txtLotNo.CustomButton.Visible = false;
            this.txtLotNo.Lines = new string[0];
            this.txtLotNo.Location = new System.Drawing.Point(83, 125);
            this.txtLotNo.MaxLength = 32767;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.PasswordChar = '\0';
            this.txtLotNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLotNo.SelectedText = "";
            this.txtLotNo.SelectionLength = 0;
            this.txtLotNo.SelectionStart = 0;
            this.txtLotNo.ShortcutsEnabled = true;
            this.txtLotNo.Size = new System.Drawing.Size(91, 23);
            this.txtLotNo.TabIndex = 39;
            this.txtLotNo.UseSelectable = true;
            this.txtLotNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLotNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(178, 127);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(69, 19);
            this.metroLabel4.TabIndex = 40;
            this.metroLabel4.Text = "Lot Date :";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel9.Location = new System.Drawing.Point(375, 128);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(45, 19);
            this.metroLabel9.TabIndex = 35;
            this.metroLabel9.Text = "Type :";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(540, 126);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(60, 19);
            this.metroLabel5.TabIndex = 36;
            this.metroLabel5.Text = "Quality :";
            // 
            // cbxLotType
            // 
            this.cbxLotType.FormattingEnabled = true;
            this.cbxLotType.ItemHeight = 23;
            this.cbxLotType.Items.AddRange(new object[] {
            "",
            "Galma",
            "Puttha"});
            this.cbxLotType.Location = new System.Drawing.Point(420, 124);
            this.cbxLotType.Name = "cbxLotType";
            this.cbxLotType.Size = new System.Drawing.Size(118, 29);
            this.cbxLotType.TabIndex = 42;
            this.cbxLotType.UseSelectable = true;
            // 
            // txtQuality
            // 
            // 
            // 
            // 
            this.txtQuality.CustomButton.Image = null;
            this.txtQuality.CustomButton.Location = new System.Drawing.Point(100, 1);
            this.txtQuality.CustomButton.Name = "";
            this.txtQuality.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtQuality.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtQuality.CustomButton.TabIndex = 1;
            this.txtQuality.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtQuality.CustomButton.UseSelectable = true;
            this.txtQuality.Lines = new string[0];
            this.txtQuality.Location = new System.Drawing.Point(601, 126);
            this.txtQuality.MaxLength = 32767;
            this.txtQuality.Name = "txtQuality";
            this.txtQuality.PasswordChar = '\0';
            this.txtQuality.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtQuality.SelectedText = "";
            this.txtQuality.SelectionLength = 0;
            this.txtQuality.SelectionStart = 0;
            this.txtQuality.ShortcutsEnabled = true;
            this.txtQuality.ShowButton = true;
            this.txtQuality.Size = new System.Drawing.Size(122, 23);
            this.txtQuality.TabIndex = 38;
            this.txtQuality.UseSelectable = true;
            this.txtQuality.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtQuality.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtQuality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuality_KeyPress);
            // 
            // metroLabel6
            // 
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(28, 234);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(831, 23);
            this.metroLabel6.TabIndex = 0;
            this.metroLabel6.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------";
            // 
            // txtLotWeight
            // 
            this.txtLotWeight.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            // 
            // 
            // 
            this.txtLotWeight.CustomButton.Image = null;
            this.txtLotWeight.CustomButton.Location = new System.Drawing.Point(105, 1);
            this.txtLotWeight.CustomButton.Name = "";
            this.txtLotWeight.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtLotWeight.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLotWeight.CustomButton.TabIndex = 1;
            this.txtLotWeight.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLotWeight.CustomButton.UseSelectable = true;
            this.txtLotWeight.CustomButton.Visible = false;
            this.txtLotWeight.Lines = new string[0];
            this.txtLotWeight.Location = new System.Drawing.Point(729, 126);
            this.txtLotWeight.MaxLength = 32767;
            this.txtLotWeight.Name = "txtLotWeight";
            this.txtLotWeight.PasswordChar = '\0';
            this.txtLotWeight.PromptText = "Lot Weight";
            this.txtLotWeight.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLotWeight.SelectedText = "";
            this.txtLotWeight.SelectionLength = 0;
            this.txtLotWeight.SelectionStart = 0;
            this.txtLotWeight.ShortcutsEnabled = true;
            this.txtLotWeight.Size = new System.Drawing.Size(127, 23);
            this.txtLotWeight.TabIndex = 43;
            this.txtLotWeight.UseSelectable = true;
            this.txtLotWeight.WaterMark = "Lot Weight";
            this.txtLotWeight.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLotWeight.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // frmTanneryGenerateLotNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 288);
            this.Controls.Add(this.txtLotWeight);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.DtLot);
            this.Controls.Add(this.txtLotNo);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.cbxLotType);
            this.Controls.Add(this.txtQuality);
            this.Controls.Add(this.btnDrummingGenerateLot);
            this.Controls.Add(this.cbxVehicles);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frmTanneryGenerateLotNo";
            this.Text = "Generate Custom Lot No";
            this.Load += new System.EventHandler(this.frmTanneyGenerateLotNo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ComboBox cbxVehicles;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTile btnDrummingGenerateLot;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime DtLot;
        private MetroFramework.Controls.MetroTextBox txtLotNo;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox cbxLotType;
        private MetroFramework.Controls.MetroTextBox txtQuality;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtLotWeight;
    }
}