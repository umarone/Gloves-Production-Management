namespace Accounts.UI
{
    partial class frmCurreny
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtCurrencyName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtCurrencySymbol = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtDiscription = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.btnClose = new MetroFramework.Controls.MetroTile();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdCurrencies = new MetroFramework.Controls.MetroGrid();
            this.txtsearch = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrencyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrencySymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCurrency = new MetroFramework.Controls.MetroDateTime();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrencies)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 76);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(108, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Currency Name :";
            // 
            // txtCurrencyName
            // 
            // 
            // 
            // 
            this.txtCurrencyName.CustomButton.Image = null;
            this.txtCurrencyName.CustomButton.Location = new System.Drawing.Point(253, 1);
            this.txtCurrencyName.CustomButton.Name = "";
            this.txtCurrencyName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCurrencyName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCurrencyName.CustomButton.TabIndex = 1;
            this.txtCurrencyName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCurrencyName.CustomButton.UseSelectable = true;
            this.txtCurrencyName.CustomButton.Visible = false;
            this.txtCurrencyName.Lines = new string[0];
            this.txtCurrencyName.Location = new System.Drawing.Point(117, 76);
            this.txtCurrencyName.MaxLength = 32767;
            this.txtCurrencyName.Name = "txtCurrencyName";
            this.txtCurrencyName.PasswordChar = '\0';
            this.txtCurrencyName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrencyName.SelectedText = "";
            this.txtCurrencyName.SelectionLength = 0;
            this.txtCurrencyName.SelectionStart = 0;
            this.txtCurrencyName.ShortcutsEnabled = true;
            this.txtCurrencyName.Size = new System.Drawing.Size(275, 23);
            this.txtCurrencyName.TabIndex = 0;
            this.txtCurrencyName.UseSelectable = true;
            this.txtCurrencyName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrencyName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 102);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(116, 19);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "Currency Symbol :";
            // 
            // txtCurrencySymbol
            // 
            // 
            // 
            // 
            this.txtCurrencySymbol.CustomButton.Image = null;
            this.txtCurrencySymbol.CustomButton.Location = new System.Drawing.Point(253, 1);
            this.txtCurrencySymbol.CustomButton.Name = "";
            this.txtCurrencySymbol.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCurrencySymbol.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCurrencySymbol.CustomButton.TabIndex = 1;
            this.txtCurrencySymbol.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCurrencySymbol.CustomButton.UseSelectable = true;
            this.txtCurrencySymbol.CustomButton.Visible = false;
            this.txtCurrencySymbol.Lines = new string[0];
            this.txtCurrencySymbol.Location = new System.Drawing.Point(117, 102);
            this.txtCurrencySymbol.MaxLength = 32767;
            this.txtCurrencySymbol.Name = "txtCurrencySymbol";
            this.txtCurrencySymbol.PasswordChar = '\0';
            this.txtCurrencySymbol.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrencySymbol.SelectedText = "";
            this.txtCurrencySymbol.SelectionLength = 0;
            this.txtCurrencySymbol.SelectionStart = 0;
            this.txtCurrencySymbol.ShortcutsEnabled = true;
            this.txtCurrencySymbol.Size = new System.Drawing.Size(275, 23);
            this.txtCurrencySymbol.TabIndex = 1;
            this.txtCurrencySymbol.UseSelectable = true;
            this.txtCurrencySymbol.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrencySymbol.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(3, 128);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(77, 19);
            this.metroLabel3.TabIndex = 0;
            this.metroLabel3.Text = "Discription :";
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
            this.txtDiscription.Location = new System.Drawing.Point(117, 128);
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
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(117, 293);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 43);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.ActiveControl = null;
            this.btnClose.Location = new System.Drawing.Point(228, 293);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 43);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdCurrencies);
            this.groupBox1.Controls.Add(this.txtsearch);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(398, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 396);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Currencies";
            // 
            // grdCurrencies
            // 
            this.grdCurrencies.AllowUserToAddRows = false;
            this.grdCurrencies.AllowUserToDeleteRows = false;
            this.grdCurrencies.AllowUserToResizeRows = false;
            this.grdCurrencies.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdCurrencies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdCurrencies.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdCurrencies.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCurrencies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCurrencies.ColumnHeadersHeight = 28;
            this.grdCurrencies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCurrency,
            this.colCurrencyName,
            this.colCurrencySymbol,
            this.colEdit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCurrencies.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdCurrencies.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdCurrencies.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdCurrencies.Location = new System.Drawing.Point(10, 55);
            this.grdCurrencies.Name = "grdCurrencies";
            this.grdCurrencies.ReadOnly = true;
            this.grdCurrencies.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCurrencies.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdCurrencies.RowHeadersVisible = false;
            this.grdCurrencies.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdCurrencies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCurrencies.Size = new System.Drawing.Size(501, 333);
            this.grdCurrencies.TabIndex = 2;
            this.grdCurrencies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCurrencies_CellClick);
            this.grdCurrencies.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdCurrencies_CellFormatting);
            // 
            // txtsearch
            // 
            // 
            // 
            // 
            this.txtsearch.CustomButton.Image = null;
            this.txtsearch.CustomButton.Location = new System.Drawing.Point(365, 1);
            this.txtsearch.CustomButton.Name = "";
            this.txtsearch.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtsearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtsearch.CustomButton.TabIndex = 1;
            this.txtsearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtsearch.CustomButton.UseSelectable = true;
            this.txtsearch.CustomButton.Visible = false;
            this.txtsearch.Lines = new string[0];
            this.txtsearch.Location = new System.Drawing.Point(124, 28);
            this.txtsearch.MaxLength = 32767;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PasswordChar = '\0';
            this.txtsearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtsearch.SelectedText = "";
            this.txtsearch.SelectionLength = 0;
            this.txtsearch.SelectionStart = 0;
            this.txtsearch.ShortcutsEnabled = true;
            this.txtsearch.Size = new System.Drawing.Size(387, 23);
            this.txtsearch.TabIndex = 0;
            this.txtsearch.UseSelectable = true;
            this.txtsearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtsearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtsearch.Click += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(10, 29);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(111, 19);
            this.metroLabel4.TabIndex = 0;
            this.metroLabel4.Text = "Search Currency :";
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "....";
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IdCurrency";
            this.dataGridViewTextBoxColumn1.HeaderText = "IdCurrency";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CurrencyName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Currency Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 270;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CurrencySymbol";
            this.dataGridViewTextBoxColumn3.HeaderText = "Currency Symbol";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // colIdCurrency
            // 
            this.colIdCurrency.DataPropertyName = "IdCurrency";
            this.colIdCurrency.HeaderText = "IdCurrency";
            this.colIdCurrency.Name = "colIdCurrency";
            this.colIdCurrency.ReadOnly = true;
            this.colIdCurrency.Visible = false;
            // 
            // colCurrencyName
            // 
            this.colCurrencyName.DataPropertyName = "CurrencyName";
            this.colCurrencyName.HeaderText = "Currency Name";
            this.colCurrencyName.Name = "colCurrencyName";
            this.colCurrencyName.ReadOnly = true;
            this.colCurrencyName.Width = 270;
            // 
            // colCurrencySymbol
            // 
            this.colCurrencySymbol.DataPropertyName = "CurrencySymbol";
            this.colCurrencySymbol.HeaderText = "Currency Symbol";
            this.colCurrencySymbol.Name = "colCurrencySymbol";
            this.colCurrencySymbol.ReadOnly = true;
            this.colCurrencySymbol.Width = 150;
            // 
            // dtCurrency
            // 
            this.dtCurrency.Location = new System.Drawing.Point(117, 244);
            this.dtCurrency.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtCurrency.Name = "dtCurrency";
            this.dtCurrency.Size = new System.Drawing.Size(275, 29);
            this.dtCurrency.TabIndex = 3;
            // 
            // frmCurreny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 482);
            this.Controls.Add(this.dtCurrency);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDiscription);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtCurrencySymbol);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtCurrencyName);
            this.Controls.Add(this.metroLabel1);
            this.KeyPreview = true;
            this.Name = "frmCurreny";
            this.Text = "Currency Setup";
            this.Load += new System.EventHandler(this.frmCurreny_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCurreny_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrencies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtCurrencyName;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtCurrencySymbol;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtDiscription;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroTile btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroTextBox txtsearch;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroGrid grdCurrencies;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrencyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrencySymbol;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private MetroFramework.Controls.MetroDateTime dtCurrency;
    }
}