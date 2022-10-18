namespace Accounts.UI
{
    partial class frmProductLedger
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDashed = new MetroFramework.Controls.MetroLabel();
            this.grdProductLedger = new System.Windows.Forms.DataGridView();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.PEditBox = new MetroFramework.Controls.MetroTextBox();
            this.btnProductReport = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkSupplier = new MetroFramework.Controls.MetroCheckBox();
            this.txtSupplier = new MetroFramework.Controls.MetroTextBox();
            this.chkByPO = new MetroFramework.Controls.MetroCheckBox();
            this.txtPoNumber = new MetroFramework.Controls.MetroTextBox();
            this.chkByStitcher = new MetroFramework.Controls.MetroCheckBox();
            this.txtStitcherName = new MetroFramework.Controls.MetroTextBox();
            this.chkByPeriod = new MetroFramework.Controls.MetroCheckBox();
            this.dtStart = new MetroFramework.Controls.MetroDateTime();
            this.dtEnd = new MetroFramework.Controls.MetroDateTime();
            this.btnLoad = new MetroFramework.Controls.MetroButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClosing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductLedger)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDashed
            // 
            this.lblDashed.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblDashed.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblDashed.Location = new System.Drawing.Point(24, 52);
            this.lblDashed.Name = "lblDashed";
            this.lblDashed.Size = new System.Drawing.Size(728, 23);
            this.lblDashed.TabIndex = 0;
            this.lblDashed.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------";
            this.lblDashed.UseCustomForeColor = true;
            // 
            // grdProductLedger
            // 
            this.grdProductLedger.AllowUserToAddRows = false;
            this.grdProductLedger.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.grdProductLedger.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdProductLedger.BackgroundColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdProductLedger.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdProductLedger.ColumnHeadersHeight = 25;
            this.grdProductLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescription,
            this.colType,
            this.colDate,
            this.colAccountName,
            this.colUnits,
            this.colClosing});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdProductLedger.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdProductLedger.EnableHeadersVisualStyles = false;
            this.grdProductLedger.Location = new System.Drawing.Point(24, 180);
            this.grdProductLedger.Name = "grdProductLedger";
            this.grdProductLedger.ReadOnly = true;
            this.grdProductLedger.RowHeadersVisible = false;
            this.grdProductLedger.Size = new System.Drawing.Size(742, 367);
            this.grdProductLedger.TabIndex = 10;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(24, 78);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(62, 19);
            this.metroLabel10.TabIndex = 14;
            this.metroLabel10.Text = "Product :";
            // 
            // PEditBox
            // 
            // 
            // 
            // 
            this.PEditBox.CustomButton.Image = null;
            this.PEditBox.CustomButton.Location = new System.Drawing.Point(363, 1);
            this.PEditBox.CustomButton.Name = "";
            this.PEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.PEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PEditBox.CustomButton.TabIndex = 1;
            this.PEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PEditBox.CustomButton.UseSelectable = true;
            this.PEditBox.Lines = new string[0];
            this.PEditBox.Location = new System.Drawing.Point(90, 78);
            this.PEditBox.MaxLength = 32767;
            this.PEditBox.Name = "PEditBox";
            this.PEditBox.PasswordChar = '\0';
            this.PEditBox.PromptText = "Product Here";
            this.PEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PEditBox.SelectedText = "";
            this.PEditBox.SelectionLength = 0;
            this.PEditBox.SelectionStart = 0;
            this.PEditBox.ShortcutsEnabled = true;
            this.PEditBox.ShowButton = true;
            this.PEditBox.Size = new System.Drawing.Size(385, 23);
            this.PEditBox.TabIndex = 13;
            this.PEditBox.UseSelectable = true;
            this.PEditBox.WaterMark = "Product Here";
            this.PEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.PEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.PEditBox_ButtonClick);
            this.PEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PEditBox_KeyPress);
            // 
            // btnProductReport
            // 
            this.btnProductReport.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnProductReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductReport.ForeColor = System.Drawing.Color.Black;
            this.btnProductReport.Location = new System.Drawing.Point(481, 78);
            this.btnProductReport.Name = "btnProductReport";
            this.btnProductReport.Size = new System.Drawing.Size(101, 25);
            this.btnProductReport.TabIndex = 15;
            this.btnProductReport.Text = "Load Report";
            this.btnProductReport.UseVisualStyleBackColor = false;
            this.btnProductReport.Click += new System.EventHandler(this.btnProductReport_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.chkSupplier);
            this.flowLayoutPanel1.Controls.Add(this.txtSupplier);
            this.flowLayoutPanel1.Controls.Add(this.chkByStitcher);
            this.flowLayoutPanel1.Controls.Add(this.txtStitcherName);
            this.flowLayoutPanel1.Controls.Add(this.chkByPO);
            this.flowLayoutPanel1.Controls.Add(this.txtPoNumber);
            this.flowLayoutPanel1.Controls.Add(this.chkByPeriod);
            this.flowLayoutPanel1.Controls.Add(this.dtStart);
            this.flowLayoutPanel1.Controls.Add(this.dtEnd);
            this.flowLayoutPanel1.Controls.Add(this.btnLoad);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(24, 103);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(742, 71);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // chkSupplier
            // 
            this.chkSupplier.AutoSize = true;
            this.chkSupplier.Location = new System.Drawing.Point(3, 3);
            this.chkSupplier.Name = "chkSupplier";
            this.chkSupplier.Size = new System.Drawing.Size(82, 15);
            this.chkSupplier.TabIndex = 2;
            this.chkSupplier.Text = "By Supplier";
            this.chkSupplier.UseSelectable = true;
            this.chkSupplier.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // txtSupplier
            // 
            // 
            // 
            // 
            this.txtSupplier.CustomButton.Image = null;
            this.txtSupplier.CustomButton.Location = new System.Drawing.Point(133, 1);
            this.txtSupplier.CustomButton.Name = "";
            this.txtSupplier.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSupplier.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSupplier.CustomButton.TabIndex = 1;
            this.txtSupplier.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSupplier.CustomButton.UseSelectable = true;
            this.txtSupplier.Lines = new string[0];
            this.txtSupplier.Location = new System.Drawing.Point(91, 3);
            this.txtSupplier.MaxLength = 32767;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.PasswordChar = '\0';
            this.txtSupplier.PromptText = "Supplier Name Here";
            this.txtSupplier.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSupplier.SelectedText = "";
            this.txtSupplier.SelectionLength = 0;
            this.txtSupplier.SelectionStart = 0;
            this.txtSupplier.ShortcutsEnabled = true;
            this.txtSupplier.ShowButton = true;
            this.txtSupplier.Size = new System.Drawing.Size(155, 23);
            this.txtSupplier.TabIndex = 3;
            this.txtSupplier.UseSelectable = true;
            this.txtSupplier.WaterMark = "Supplier Name Here";
            this.txtSupplier.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSupplier.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSupplier.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtSupplier_ButtonClick);
            // 
            // chkByPO
            // 
            this.chkByPO.AutoSize = true;
            this.chkByPO.Location = new System.Drawing.Point(494, 3);
            this.chkByPO.Name = "chkByPO";
            this.chkByPO.Size = new System.Drawing.Size(100, 15);
            this.chkByPO.TabIndex = 9;
            this.chkByPO.Text = "By Po Number";
            this.chkByPO.UseSelectable = true;
            this.chkByPO.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // txtPoNumber
            // 
            // 
            // 
            // 
            this.txtPoNumber.CustomButton.Image = null;
            this.txtPoNumber.CustomButton.Location = new System.Drawing.Point(123, 1);
            this.txtPoNumber.CustomButton.Name = "";
            this.txtPoNumber.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPoNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPoNumber.CustomButton.TabIndex = 1;
            this.txtPoNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPoNumber.CustomButton.UseSelectable = true;
            this.txtPoNumber.Lines = new string[0];
            this.txtPoNumber.Location = new System.Drawing.Point(3, 32);
            this.txtPoNumber.MaxLength = 32767;
            this.txtPoNumber.Name = "txtPoNumber";
            this.txtPoNumber.PasswordChar = '\0';
            this.txtPoNumber.PromptText = "Customer Po Number";
            this.txtPoNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPoNumber.SelectedText = "";
            this.txtPoNumber.SelectionLength = 0;
            this.txtPoNumber.SelectionStart = 0;
            this.txtPoNumber.ShortcutsEnabled = true;
            this.txtPoNumber.ShowButton = true;
            this.txtPoNumber.Size = new System.Drawing.Size(145, 23);
            this.txtPoNumber.TabIndex = 10;
            this.txtPoNumber.UseSelectable = true;
            this.txtPoNumber.WaterMark = "Customer Po Number";
            this.txtPoNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPoNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPoNumber.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtPoNumber_ButtonClick);
            // 
            // chkByStitcher
            // 
            this.chkByStitcher.AutoSize = true;
            this.chkByStitcher.Location = new System.Drawing.Point(252, 3);
            this.chkByStitcher.Name = "chkByStitcher";
            this.chkByStitcher.Size = new System.Drawing.Size(79, 15);
            this.chkByStitcher.TabIndex = 11;
            this.chkByStitcher.Text = "By Stitcher";
            this.chkByStitcher.UseSelectable = true;
            this.chkByStitcher.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // txtStitcherName
            // 
            // 
            // 
            // 
            this.txtStitcherName.CustomButton.Image = null;
            this.txtStitcherName.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.txtStitcherName.CustomButton.Name = "";
            this.txtStitcherName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtStitcherName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtStitcherName.CustomButton.TabIndex = 1;
            this.txtStitcherName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtStitcherName.CustomButton.UseSelectable = true;
            this.txtStitcherName.Lines = new string[0];
            this.txtStitcherName.Location = new System.Drawing.Point(337, 3);
            this.txtStitcherName.MaxLength = 32767;
            this.txtStitcherName.Name = "txtStitcherName";
            this.txtStitcherName.PasswordChar = '\0';
            this.txtStitcherName.PromptText = "Stitcher Name Here";
            this.txtStitcherName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtStitcherName.SelectedText = "";
            this.txtStitcherName.SelectionLength = 0;
            this.txtStitcherName.SelectionStart = 0;
            this.txtStitcherName.ShortcutsEnabled = true;
            this.txtStitcherName.ShowButton = true;
            this.txtStitcherName.Size = new System.Drawing.Size(151, 23);
            this.txtStitcherName.TabIndex = 12;
            this.txtStitcherName.UseSelectable = true;
            this.txtStitcherName.WaterMark = "Stitcher Name Here";
            this.txtStitcherName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtStitcherName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtStitcherName.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtStitcherName_ButtonClick);
            // 
            // chkByPeriod
            // 
            this.chkByPeriod.AutoSize = true;
            this.chkByPeriod.Location = new System.Drawing.Point(154, 32);
            this.chkByPeriod.Name = "chkByPeriod";
            this.chkByPeriod.Size = new System.Drawing.Size(73, 15);
            this.chkByPeriod.TabIndex = 5;
            this.chkByPeriod.Text = "By Period";
            this.chkByPeriod.UseSelectable = true;
            this.chkByPeriod.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtStart
            // 
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStart.Location = new System.Drawing.Point(233, 32);
            this.dtStart.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(98, 29);
            this.dtStart.TabIndex = 6;
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(337, 32);
            this.dtEnd.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(104, 29);
            this.dtEnd.TabIndex = 7;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(447, 32);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(103, 29);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "L&oad";
            this.btnLoad.UseSelectable = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Description";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "Descriptoin";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 130;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AccountType";
            this.dataGridViewTextBoxColumn2.HeaderText = "Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "StockOnHandDate";
            dataGridViewCellStyle7.Format = "d";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "Date";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "AccountName";
            this.dataGridViewTextBoxColumn4.HeaderText = "Account Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 160;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Qty";
            this.dataGridViewTextBoxColumn5.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Closing";
            this.dataGridViewTextBoxColumn6.HeaderText = "Available Stock";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDescription.HeaderText = "Descriptoin";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 130;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "AccountType";
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 80;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "StockOnHandDate";
            dataGridViewCellStyle4.Format = "d";
            this.colDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colAccountName
            // 
            this.colAccountName.DataPropertyName = "AccountName";
            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 160;
            // 
            // colUnits
            // 
            this.colUnits.DataPropertyName = "Qty";
            this.colUnits.HeaderText = "Qty";
            this.colUnits.Name = "colUnits";
            this.colUnits.ReadOnly = true;
            // 
            // colClosing
            // 
            this.colClosing.DataPropertyName = "Closing";
            this.colClosing.HeaderText = "Available Stock";
            this.colClosing.Name = "colClosing";
            this.colClosing.ReadOnly = true;
            this.colClosing.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "UnitPrice";
            this.dataGridViewTextBoxColumn7.HeaderText = "Value";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Avg / Unit";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Total Avg Value";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 140;
            // 
            // frmProductLedger
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(792, 572);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.PEditBox);
            this.Controls.Add(this.btnProductReport);
            this.Controls.Add(this.grdProductLedger);
            this.Controls.Add(this.lblDashed);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.HelpButton = true;
            this.Name = "frmProductLedger";
            this.Text = "Products Ledger";
            this.Load += new System.EventHandler(this.frmProductLedger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdProductLedger)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblDashed;
        private System.Windows.Forms.DataGridView grdProductLedger;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox PEditBox;
        private System.Windows.Forms.Button btnProductReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroCheckBox chkSupplier;
        private MetroFramework.Controls.MetroTextBox txtSupplier;
        private MetroFramework.Controls.MetroCheckBox chkByPeriod;
        private MetroFramework.Controls.MetroDateTime dtStart;
        private MetroFramework.Controls.MetroDateTime dtEnd;
        private MetroFramework.Controls.MetroButton btnLoad;
        private MetroFramework.Controls.MetroCheckBox chkByPO;
        private MetroFramework.Controls.MetroTextBox txtPoNumber;
        private MetroFramework.Controls.MetroCheckBox chkByStitcher;
        private MetroFramework.Controls.MetroTextBox txtStitcherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClosing;
    }
}