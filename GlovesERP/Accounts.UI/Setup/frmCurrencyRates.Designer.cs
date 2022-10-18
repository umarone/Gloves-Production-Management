namespace Accounts.UI
{
    partial class frmCurrencyRates
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdCurrencyRates = new MetroFramework.Controls.MetroGrid();
            this.cbxCurrencies = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtCurrencyRates = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dtCurrency = new MetroFramework.Controls.MetroDateTime();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.txtDiscription = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdCurrencyRates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrencyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrencySymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrencyRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsCurrent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrencyRates)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdCurrencyRates);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(397, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 396);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Currencies";
            // 
            // grdCurrencyRates
            // 
            this.grdCurrencyRates.AllowUserToAddRows = false;
            this.grdCurrencyRates.AllowUserToDeleteRows = false;
            this.grdCurrencyRates.AllowUserToResizeRows = false;
            this.grdCurrencyRates.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdCurrencyRates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdCurrencyRates.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdCurrencyRates.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCurrencyRates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCurrencyRates.ColumnHeadersHeight = 28;
            this.grdCurrencyRates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCurrency,
            this.colIdCurrencyRates,
            this.colCurrencyName,
            this.colCurrencySymbol,
            this.colCurrencyRate,
            this.colIsCurrent,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCurrencyRates.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdCurrencyRates.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdCurrencyRates.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdCurrencyRates.Location = new System.Drawing.Point(10, 29);
            this.grdCurrencyRates.Name = "grdCurrencyRates";
            this.grdCurrencyRates.ReadOnly = true;
            this.grdCurrencyRates.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCurrencyRates.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdCurrencyRates.RowHeadersVisible = false;
            this.grdCurrencyRates.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdCurrencyRates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCurrencyRates.Size = new System.Drawing.Size(605, 359);
            this.grdCurrencyRates.TabIndex = 2;
            this.grdCurrencyRates.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCurrencyRates_CellClick);
            this.grdCurrencyRates.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdCurrencyRates_CellFormatting);
            // 
            // cbxCurrencies
            // 
            this.cbxCurrencies.FormattingEnabled = true;
            this.cbxCurrencies.ItemHeight = 23;
            this.cbxCurrencies.Location = new System.Drawing.Point(116, 82);
            this.cbxCurrencies.Name = "cbxCurrencies";
            this.cbxCurrencies.Size = new System.Drawing.Size(275, 29);
            this.cbxCurrencies.TabIndex = 0;
            this.cbxCurrencies.UseSelectable = true;
            this.cbxCurrencies.SelectedIndexChanged += new System.EventHandler(this.cbxCurrencies_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(-1, 86);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(116, 19);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "Choose Currency :";
            // 
            // txtCurrencyRates
            // 
            // 
            // 
            // 
            this.txtCurrencyRates.CustomButton.Image = null;
            this.txtCurrencyRates.CustomButton.Location = new System.Drawing.Point(253, 1);
            this.txtCurrencyRates.CustomButton.Name = "";
            this.txtCurrencyRates.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCurrencyRates.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCurrencyRates.CustomButton.TabIndex = 1;
            this.txtCurrencyRates.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCurrencyRates.CustomButton.UseSelectable = true;
            this.txtCurrencyRates.CustomButton.Visible = false;
            this.txtCurrencyRates.Lines = new string[0];
            this.txtCurrencyRates.Location = new System.Drawing.Point(116, 117);
            this.txtCurrencyRates.MaxLength = 32767;
            this.txtCurrencyRates.Name = "txtCurrencyRates";
            this.txtCurrencyRates.PasswordChar = '\0';
            this.txtCurrencyRates.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrencyRates.SelectedText = "";
            this.txtCurrencyRates.SelectionLength = 0;
            this.txtCurrencyRates.SelectionStart = 0;
            this.txtCurrencyRates.ShortcutsEnabled = true;
            this.txtCurrencyRates.Size = new System.Drawing.Size(275, 23);
            this.txtCurrencyRates.TabIndex = 1;
            this.txtCurrencyRates.UseSelectable = true;
            this.txtCurrencyRates.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrencyRates.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(2, 117);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(98, 19);
            this.metroLabel2.TabIndex = 10;
            this.metroLabel2.Text = "Cur Rate(PKR) :";
            // 
            // dtCurrency
            // 
            this.dtCurrency.Location = new System.Drawing.Point(116, 262);
            this.dtCurrency.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtCurrency.Name = "dtCurrency";
            this.dtCurrency.Size = new System.Drawing.Size(275, 29);
            this.dtCurrency.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.Location = new System.Drawing.Point(227, 311);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 43);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(116, 311);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 43);
            this.btnSave.TabIndex = 4;
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
            this.txtDiscription.CustomButton.Location = new System.Drawing.Point(167, 1);
            this.txtDiscription.CustomButton.Name = "";
            this.txtDiscription.CustomButton.Size = new System.Drawing.Size(107, 107);
            this.txtDiscription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDiscription.CustomButton.TabIndex = 1;
            this.txtDiscription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDiscription.CustomButton.UseSelectable = true;
            this.txtDiscription.CustomButton.Visible = false;
            this.txtDiscription.Lines = new string[0];
            this.txtDiscription.Location = new System.Drawing.Point(116, 146);
            this.txtDiscription.MaxLength = 32767;
            this.txtDiscription.Multiline = true;
            this.txtDiscription.Name = "txtDiscription";
            this.txtDiscription.PasswordChar = '\0';
            this.txtDiscription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDiscription.SelectedText = "";
            this.txtDiscription.SelectionLength = 0;
            this.txtDiscription.SelectionStart = 0;
            this.txtDiscription.ShortcutsEnabled = true;
            this.txtDiscription.Size = new System.Drawing.Size(275, 109);
            this.txtDiscription.TabIndex = 2;
            this.txtDiscription.UseSelectable = true;
            this.txtDiscription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDiscription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(2, 146);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(77, 19);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Discription :";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IdCurrency";
            this.dataGridViewTextBoxColumn1.HeaderText = "IdCurrency";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "IdCurrencyRate";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CurrencyName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Currency Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 170;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CurrencySymbol";
            this.dataGridViewTextBoxColumn4.HeaderText = "Currency Symbol";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CurrencyRates";
            this.dataGridViewTextBoxColumn5.HeaderText = "Rates";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // colIdCurrency
            // 
            this.colIdCurrency.DataPropertyName = "IdCurrency";
            this.colIdCurrency.HeaderText = "IdCurrency";
            this.colIdCurrency.Name = "colIdCurrency";
            this.colIdCurrency.ReadOnly = true;
            this.colIdCurrency.Visible = false;
            // 
            // colIdCurrencyRates
            // 
            this.colIdCurrencyRates.DataPropertyName = "IdCurrencyRates";
            this.colIdCurrencyRates.HeaderText = "IdCurrencyRate";
            this.colIdCurrencyRates.Name = "colIdCurrencyRates";
            this.colIdCurrencyRates.ReadOnly = true;
            this.colIdCurrencyRates.Visible = false;
            // 
            // colCurrencyName
            // 
            this.colCurrencyName.DataPropertyName = "CurrencyName";
            this.colCurrencyName.HeaderText = "Currency Name";
            this.colCurrencyName.Name = "colCurrencyName";
            this.colCurrencyName.ReadOnly = true;
            this.colCurrencyName.Width = 170;
            // 
            // colCurrencySymbol
            // 
            this.colCurrencySymbol.DataPropertyName = "CurrencySymbol";
            this.colCurrencySymbol.HeaderText = "Currency Symbol";
            this.colCurrencySymbol.Name = "colCurrencySymbol";
            this.colCurrencySymbol.ReadOnly = true;
            this.colCurrencySymbol.Width = 150;
            // 
            // colCurrencyRate
            // 
            this.colCurrencyRate.DataPropertyName = "CurrencyRates";
            this.colCurrencyRate.HeaderText = "Rates";
            this.colCurrencyRate.Name = "colCurrencyRate";
            this.colCurrencyRate.ReadOnly = true;
            // 
            // colIsCurrent
            // 
            this.colIsCurrent.DataPropertyName = "IsCurrent";
            this.colIsCurrent.HeaderText = "Current";
            this.colIsCurrent.Name = "colIsCurrent";
            this.colIsCurrent.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "....";
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Width = 80;
            // 
            // frmCurrencyRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 476);
            this.Controls.Add(this.dtCurrency);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDiscription);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtCurrencyRates);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cbxCurrencies);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmCurrencyRates";
            this.Text = "Currency Rates Setup";
            this.Load += new System.EventHandler(this.frmCurrencyRates_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCurrencyRates_KeyPress);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrencyRates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroGrid grdCurrencyRates;
        private MetroFramework.Controls.MetroComboBox cbxCurrencies;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtCurrencyRates;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime dtCurrency;
        private MetroFramework.Controls.MetroTile btnClose;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroTextBox txtDiscription;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCurrencyRates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrencyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrencySymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrencyRate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsCurrent;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
    }
}