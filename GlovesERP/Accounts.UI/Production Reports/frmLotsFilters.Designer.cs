namespace Accounts.UI
{
    partial class frmLotsFilters
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
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkLotNo = new MetroFramework.Controls.MetroCheckBox();
            this.txtLotNo = new MetroFramework.Controls.MetroTextBox();
            this.chkDrumMan = new MetroFramework.Controls.MetroCheckBox();
            this.txtDrumMan = new MetroFramework.Controls.MetroTextBox();
            this.chkQuality = new MetroFramework.Controls.MetroCheckBox();
            this.txtQuality = new MetroFramework.Controls.MetroTextBox();
            this.chkByPeriod = new MetroFramework.Controls.MetroCheckBox();
            this.chkByPieces = new MetroFramework.Controls.MetroCheckBox();
            this.cbxSearchByPiecesType = new MetroFramework.Controls.MetroComboBox();
            this.dtStart = new MetroFramework.Controls.MetroDateTime();
            this.dtEnd = new MetroFramework.Controls.MetroDateTime();
            this.btnLoad = new MetroFramework.Controls.MetroButton();
            this.grdLotsByFilter = new Accounts.UI.CustomDataGrid();
            this.colIdLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVehicleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotQuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotCost = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colLotPL = new System.Windows.Forms.DataGridViewButtonColumn();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLotsByFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel2
            // 
            this.metroLabel2.BackColor = System.Drawing.Color.Blue;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.ForeColor = System.Drawing.Color.Blue;
            this.metroLabel2.Location = new System.Drawing.Point(21, 51);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(910, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "---------------------------------------------------------------------------------" +
    "-----------------------------------------------";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.chkLotNo);
            this.flowLayoutPanel1.Controls.Add(this.txtLotNo);
            this.flowLayoutPanel1.Controls.Add(this.chkDrumMan);
            this.flowLayoutPanel1.Controls.Add(this.txtDrumMan);
            this.flowLayoutPanel1.Controls.Add(this.chkQuality);
            this.flowLayoutPanel1.Controls.Add(this.txtQuality);
            this.flowLayoutPanel1.Controls.Add(this.chkByPeriod);
            this.flowLayoutPanel1.Controls.Add(this.chkByPieces);
            this.flowLayoutPanel1.Controls.Add(this.cbxSearchByPiecesType);
            this.flowLayoutPanel1.Controls.Add(this.dtStart);
            this.flowLayoutPanel1.Controls.Add(this.dtEnd);
            this.flowLayoutPanel1.Controls.Add(this.btnLoad);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(23, 76);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(908, 71);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // chkLotNo
            // 
            this.chkLotNo.AutoSize = true;
            this.chkLotNo.Location = new System.Drawing.Point(3, 3);
            this.chkLotNo.Name = "chkLotNo";
            this.chkLotNo.Size = new System.Drawing.Size(75, 15);
            this.chkLotNo.TabIndex = 0;
            this.chkLotNo.Text = "By Lot No";
            this.chkLotNo.UseSelectable = true;
            this.chkLotNo.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // txtLotNo
            // 
            // 
            // 
            // 
            this.txtLotNo.CustomButton.Image = null;
            this.txtLotNo.CustomButton.Location = new System.Drawing.Point(119, 1);
            this.txtLotNo.CustomButton.Name = "";
            this.txtLotNo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtLotNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLotNo.CustomButton.TabIndex = 1;
            this.txtLotNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLotNo.CustomButton.UseSelectable = true;
            this.txtLotNo.CustomButton.Visible = false;
            this.txtLotNo.Lines = new string[0];
            this.txtLotNo.Location = new System.Drawing.Point(84, 3);
            this.txtLotNo.MaxLength = 32767;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.PasswordChar = '\0';
            this.txtLotNo.PromptText = "Lot No";
            this.txtLotNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLotNo.SelectedText = "";
            this.txtLotNo.SelectionLength = 0;
            this.txtLotNo.SelectionStart = 0;
            this.txtLotNo.ShortcutsEnabled = true;
            this.txtLotNo.Size = new System.Drawing.Size(141, 23);
            this.txtLotNo.TabIndex = 1;
            this.txtLotNo.UseSelectable = true;
            this.txtLotNo.WaterMark = "Lot No";
            this.txtLotNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLotNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // chkDrumMan
            // 
            this.chkDrumMan.AutoSize = true;
            this.chkDrumMan.Location = new System.Drawing.Point(231, 3);
            this.chkDrumMan.Name = "chkDrumMan";
            this.chkDrumMan.Size = new System.Drawing.Size(96, 15);
            this.chkDrumMan.TabIndex = 2;
            this.chkDrumMan.Text = "By Drum Man";
            this.chkDrumMan.UseSelectable = true;
            this.chkDrumMan.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // txtDrumMan
            // 
            // 
            // 
            // 
            this.txtDrumMan.CustomButton.Image = null;
            this.txtDrumMan.CustomButton.Location = new System.Drawing.Point(157, 1);
            this.txtDrumMan.CustomButton.Name = "";
            this.txtDrumMan.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtDrumMan.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDrumMan.CustomButton.TabIndex = 1;
            this.txtDrumMan.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDrumMan.CustomButton.UseSelectable = true;
            this.txtDrumMan.Lines = new string[0];
            this.txtDrumMan.Location = new System.Drawing.Point(333, 3);
            this.txtDrumMan.MaxLength = 32767;
            this.txtDrumMan.Name = "txtDrumMan";
            this.txtDrumMan.PasswordChar = '\0';
            this.txtDrumMan.PromptText = "Drum Man Account";
            this.txtDrumMan.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDrumMan.SelectedText = "";
            this.txtDrumMan.SelectionLength = 0;
            this.txtDrumMan.SelectionStart = 0;
            this.txtDrumMan.ShortcutsEnabled = true;
            this.txtDrumMan.ShowButton = true;
            this.txtDrumMan.Size = new System.Drawing.Size(179, 23);
            this.txtDrumMan.TabIndex = 3;
            this.txtDrumMan.UseSelectable = true;
            this.txtDrumMan.WaterMark = "Drum Man Account";
            this.txtDrumMan.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDrumMan.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtDrumMan.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtDrumMan_ButtonClick);
            // 
            // chkQuality
            // 
            this.chkQuality.AutoSize = true;
            this.chkQuality.Location = new System.Drawing.Point(518, 3);
            this.chkQuality.Name = "chkQuality";
            this.chkQuality.Size = new System.Drawing.Size(97, 15);
            this.chkQuality.TabIndex = 4;
            this.chkQuality.Text = "By Lot Quality";
            this.chkQuality.UseSelectable = true;
            this.chkQuality.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // txtQuality
            // 
            // 
            // 
            // 
            this.txtQuality.CustomButton.Image = null;
            this.txtQuality.CustomButton.Location = new System.Drawing.Point(133, 1);
            this.txtQuality.CustomButton.Name = "";
            this.txtQuality.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtQuality.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtQuality.CustomButton.TabIndex = 1;
            this.txtQuality.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtQuality.CustomButton.UseSelectable = true;
            this.txtQuality.Lines = new string[0];
            this.txtQuality.Location = new System.Drawing.Point(621, 3);
            this.txtQuality.MaxLength = 32767;
            this.txtQuality.Name = "txtQuality";
            this.txtQuality.PasswordChar = '\0';
            this.txtQuality.PromptText = "Choose Quality";
            this.txtQuality.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtQuality.SelectedText = "";
            this.txtQuality.SelectionLength = 0;
            this.txtQuality.SelectionStart = 0;
            this.txtQuality.ShortcutsEnabled = true;
            this.txtQuality.ShowButton = true;
            this.txtQuality.Size = new System.Drawing.Size(155, 23);
            this.txtQuality.TabIndex = 3;
            this.txtQuality.UseSelectable = true;
            this.txtQuality.WaterMark = "Choose Quality";
            this.txtQuality.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtQuality.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtQuality.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtQuality_ButtonClick);
            // 
            // chkByPeriod
            // 
            this.chkByPeriod.AutoSize = true;
            this.chkByPeriod.Location = new System.Drawing.Point(782, 3);
            this.chkByPeriod.Name = "chkByPeriod";
            this.chkByPeriod.Size = new System.Drawing.Size(73, 15);
            this.chkByPeriod.TabIndex = 5;
            this.chkByPeriod.Text = "By Period";
            this.chkByPeriod.UseSelectable = true;
            this.chkByPeriod.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkByPieces
            // 
            this.chkByPieces.AutoSize = true;
            this.chkByPieces.Location = new System.Drawing.Point(3, 32);
            this.chkByPieces.Name = "chkByPieces";
            this.chkByPieces.Size = new System.Drawing.Size(72, 15);
            this.chkByPieces.TabIndex = 9;
            this.chkByPieces.Text = "By Pieces";
            this.chkByPieces.UseSelectable = true;
            this.chkByPieces.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // cbxSearchByPiecesType
            // 
            this.cbxSearchByPiecesType.FormattingEnabled = true;
            this.cbxSearchByPiecesType.ItemHeight = 23;
            this.cbxSearchByPiecesType.Items.AddRange(new object[] {
            "",
            "Galma",
            "Puttha",
            "S. Galma",
            "S. Puttha"});
            this.cbxSearchByPiecesType.Location = new System.Drawing.Point(81, 32);
            this.cbxSearchByPiecesType.Name = "cbxSearchByPiecesType";
            this.cbxSearchByPiecesType.Size = new System.Drawing.Size(139, 29);
            this.cbxSearchByPiecesType.TabIndex = 10;
            this.cbxSearchByPiecesType.UseSelectable = true;
            // 
            // dtStart
            // 
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStart.Location = new System.Drawing.Point(226, 32);
            this.dtStart.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(120, 29);
            this.dtStart.TabIndex = 6;
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(352, 32);
            this.dtEnd.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(130, 29);
            this.dtEnd.TabIndex = 7;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(488, 32);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(103, 29);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "L&oad";
            this.btnLoad.UseSelectable = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // grdLotsByFilter
            // 
            this.grdLotsByFilter.AllowUserToAddRows = false;
            this.grdLotsByFilter.AllowUserToDeleteRows = false;
            this.grdLotsByFilter.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLotsByFilter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLotsByFilter.ColumnHeadersHeight = 30;
            this.grdLotsByFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdLot,
            this.colLotDate,
            this.colLotNo,
            this.colLotWeight,
            this.colVehicleNo,
            this.colLotProcess,
            this.colLotStatus,
            this.colLotQuality,
            this.colLotCost,
            this.colLotPL});
            this.grdLotsByFilter.EnableHeadersVisualStyles = false;
            this.grdLotsByFilter.GridColor = System.Drawing.Color.LemonChiffon;
            this.grdLotsByFilter.Location = new System.Drawing.Point(23, 153);
            this.grdLotsByFilter.Name = "grdLotsByFilter";
            this.grdLotsByFilter.ReadOnly = true;
            this.grdLotsByFilter.RowHeadersVisible = false;
            this.grdLotsByFilter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLotsByFilter.Size = new System.Drawing.Size(908, 314);
            this.grdLotsByFilter.TabIndex = 7;
            this.grdLotsByFilter.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLotsByFilter_CellClick);
            this.grdLotsByFilter.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdLotsByFilter_CellFormatting);
            // 
            // colIdLot
            // 
            this.colIdLot.DataPropertyName = "IdLot";
            this.colIdLot.HeaderText = "IdLot";
            this.colIdLot.Name = "colIdLot";
            this.colIdLot.ReadOnly = true;
            this.colIdLot.Visible = false;
            // 
            // colLotDate
            // 
            this.colLotDate.DataPropertyName = "LotDate";
            dataGridViewCellStyle2.Format = "d";
            this.colLotDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLotDate.HeaderText = "Date";
            this.colLotDate.Name = "colLotDate";
            this.colLotDate.ReadOnly = true;
            this.colLotDate.Width = 90;
            // 
            // colLotNo
            // 
            this.colLotNo.DataPropertyName = "LotNo";
            this.colLotNo.HeaderText = "Lot No #";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.ReadOnly = true;
            this.colLotNo.Width = 90;
            // 
            // colLotWeight
            // 
            this.colLotWeight.DataPropertyName = "LotWeight";
            this.colLotWeight.HeaderText = "Lot Weight";
            this.colLotWeight.Name = "colLotWeight";
            this.colLotWeight.ReadOnly = true;
            this.colLotWeight.Width = 90;
            // 
            // colVehicleNo
            // 
            this.colVehicleNo.DataPropertyName = "VehicleNo";
            this.colVehicleNo.HeaderText = "Vehicle No";
            this.colVehicleNo.Name = "colVehicleNo";
            this.colVehicleNo.ReadOnly = true;
            this.colVehicleNo.Width = 90;
            // 
            // colLotProcess
            // 
            this.colLotProcess.DataPropertyName = "ProcessName";
            this.colLotProcess.HeaderText = "Stage";
            this.colLotProcess.Name = "colLotProcess";
            this.colLotProcess.ReadOnly = true;
            this.colLotProcess.Width = 130;
            // 
            // colLotStatus
            // 
            this.colLotStatus.DataPropertyName = "Status";
            this.colLotStatus.HeaderText = "Status";
            this.colLotStatus.Name = "colLotStatus";
            this.colLotStatus.ReadOnly = true;
            // 
            // colLotQuality
            // 
            this.colLotQuality.DataPropertyName = "QualityName";
            this.colLotQuality.HeaderText = "Quality";
            this.colLotQuality.Name = "colLotQuality";
            this.colLotQuality.ReadOnly = true;
            this.colLotQuality.Width = 130;
            // 
            // colLotCost
            // 
            this.colLotCost.HeaderText = "...";
            this.colLotCost.Name = "colLotCost";
            this.colLotCost.ReadOnly = true;
            this.colLotCost.Width = 90;
            // 
            // colLotPL
            // 
            this.colLotPL.HeaderText = "...";
            this.colLotPL.Name = "colLotPL";
            this.colLotPL.ReadOnly = true;
            this.colLotPL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLotPL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLotPL.Width = 90;
            // 
            // frmLotsFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 490);
            this.Controls.Add(this.grdLotsByFilter);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.metroLabel2);
            this.Name = "frmLotsFilters";
            this.Text = "Lots Filters";
            this.Load += new System.EventHandler(this.frmLotsFilters_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLotsByFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroCheckBox chkLotNo;
        private MetroFramework.Controls.MetroTextBox txtLotNo;
        private MetroFramework.Controls.MetroCheckBox chkDrumMan;
        private MetroFramework.Controls.MetroTextBox txtDrumMan;
        private MetroFramework.Controls.MetroCheckBox chkQuality;
        private MetroFramework.Controls.MetroTextBox txtQuality;
        private MetroFramework.Controls.MetroCheckBox chkByPeriod;
        private MetroFramework.Controls.MetroDateTime dtStart;
        private MetroFramework.Controls.MetroDateTime dtEnd;
        private MetroFramework.Controls.MetroButton btnLoad;
        private CustomDataGrid grdLotsByFilter;
        private MetroFramework.Controls.MetroCheckBox chkByPieces;
        private MetroFramework.Controls.MetroComboBox cbxSearchByPiecesType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVehicleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotQuality;
        private System.Windows.Forms.DataGridViewButtonColumn colLotCost;
        private System.Windows.Forms.DataGridViewButtonColumn colLotPL;
    }
}