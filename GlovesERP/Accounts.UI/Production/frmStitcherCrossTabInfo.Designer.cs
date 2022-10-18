namespace Accounts.UI
{
    partial class frmStitcherCrossTabInfo
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
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnLoad = new MetroFramework.Controls.MetroButton();
            this.AccEditBox = new MetroFramework.Controls.MetroTextBox();
            this.lblAccountName = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.grdStitcherArticlesInfo = new System.Windows.Forms.DataGridView();
            this.txtPackingSearch = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnExcelExport = new MetroFramework.Controls.MetroButton();
            this.BtnFilter = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdStitcherArticlesInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel3
            // 
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(-8, 116);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(1153, 23);
            this.metroLabel3.TabIndex = 39;
            this.metroLabel3.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "-----------------------------";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(450, 87);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(87, 23);
            this.btnLoad.TabIndex = 38;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseSelectable = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // AccEditBox
            // 
            // 
            // 
            // 
            this.AccEditBox.CustomButton.Image = null;
            this.AccEditBox.CustomButton.Location = new System.Drawing.Point(289, 1);
            this.AccEditBox.CustomButton.Name = "";
            this.AccEditBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.AccEditBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.AccEditBox.CustomButton.TabIndex = 1;
            this.AccEditBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.AccEditBox.CustomButton.UseSelectable = true;
            this.AccEditBox.Lines = new string[0];
            this.AccEditBox.Location = new System.Drawing.Point(133, 86);
            this.AccEditBox.MaxLength = 32767;
            this.AccEditBox.Name = "AccEditBox";
            this.AccEditBox.PasswordChar = '\0';
            this.AccEditBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AccEditBox.SelectedText = "";
            this.AccEditBox.SelectionLength = 0;
            this.AccEditBox.SelectionStart = 0;
            this.AccEditBox.ShortcutsEnabled = true;
            this.AccEditBox.ShowButton = true;
            this.AccEditBox.Size = new System.Drawing.Size(311, 23);
            this.AccEditBox.Style = MetroFramework.MetroColorStyle.Green;
            this.AccEditBox.TabIndex = 37;
            this.AccEditBox.UseSelectable = true;
            this.AccEditBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.AccEditBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.AccEditBox.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.AccEditBox_ButtonClick);
            this.AccEditBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AccEditBox_KeyPress);
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAccountName.Location = new System.Drawing.Point(14, 87);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(101, 19);
            this.lblAccountName.TabIndex = 36;
            this.lblAccountName.Text = "Select Stitcher :";
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(-6, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(1151, 23);
            this.metroLabel1.TabIndex = 35;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "-----------------------------";
            // 
            // grdStitcherArticlesInfo
            // 
            this.grdStitcherArticlesInfo.AllowUserToAddRows = false;
            this.grdStitcherArticlesInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdStitcherArticlesInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdStitcherArticlesInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdStitcherArticlesInfo.EnableHeadersVisualStyles = false;
            this.grdStitcherArticlesInfo.Location = new System.Drawing.Point(-3, 174);
            this.grdStitcherArticlesInfo.Name = "grdStitcherArticlesInfo";
            this.grdStitcherArticlesInfo.ReadOnly = true;
            this.grdStitcherArticlesInfo.RowHeadersVisible = false;
            this.grdStitcherArticlesInfo.Size = new System.Drawing.Size(1148, 351);
            this.grdStitcherArticlesInfo.TabIndex = 40;
            // 
            // txtPackingSearch
            // 
            // 
            // 
            // 
            this.txtPackingSearch.CustomButton.Image = null;
            this.txtPackingSearch.CustomButton.Location = new System.Drawing.Point(289, 1);
            this.txtPackingSearch.CustomButton.Name = "";
            this.txtPackingSearch.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPackingSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPackingSearch.CustomButton.TabIndex = 1;
            this.txtPackingSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPackingSearch.CustomButton.UseSelectable = true;
            this.txtPackingSearch.Lines = new string[0];
            this.txtPackingSearch.Location = new System.Drawing.Point(133, 142);
            this.txtPackingSearch.MaxLength = 32767;
            this.txtPackingSearch.Name = "txtPackingSearch";
            this.txtPackingSearch.PasswordChar = '\0';
            this.txtPackingSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPackingSearch.SelectedText = "";
            this.txtPackingSearch.SelectionLength = 0;
            this.txtPackingSearch.SelectionStart = 0;
            this.txtPackingSearch.ShortcutsEnabled = true;
            this.txtPackingSearch.ShowButton = true;
            this.txtPackingSearch.Size = new System.Drawing.Size(311, 23);
            this.txtPackingSearch.TabIndex = 41;
            this.txtPackingSearch.UseSelectable = true;
            this.txtPackingSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPackingSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPackingSearch.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtPackingSearch_ButtonClick);
            this.txtPackingSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPackingSearch_KeyPress);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(14, 143);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(110, 19);
            this.metroLabel2.TabIndex = 36;
            this.metroLabel2.Text = "Search By Article";
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Location = new System.Drawing.Point(539, 88);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(87, 23);
            this.btnExcelExport.TabIndex = 38;
            this.btnExcelExport.Text = "Excel Export";
            this.btnExcelExport.UseSelectable = true;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // BtnFilter
            // 
            this.BtnFilter.Location = new System.Drawing.Point(450, 141);
            this.BtnFilter.Name = "BtnFilter";
            this.BtnFilter.Size = new System.Drawing.Size(167, 23);
            this.BtnFilter.TabIndex = 38;
            this.BtnFilter.Text = "Filter By Article";
            this.BtnFilter.UseSelectable = true;
            this.BtnFilter.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // frmStitcherCrossTabInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 554);
            this.Controls.Add(this.txtPackingSearch);
            this.Controls.Add(this.grdStitcherArticlesInfo);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnExcelExport);
            this.Controls.Add(this.BtnFilter);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.AccEditBox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.lblAccountName);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frmStitcherCrossTabInfo";
            this.Text = "Stitcher Aritcles Info";
            this.Load += new System.EventHandler(this.frmStitcherCrossTabInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdStitcherArticlesInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton btnLoad;
        private MetroFramework.Controls.MetroTextBox AccEditBox;
        private MetroFramework.Controls.MetroLabel lblAccountName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridView grdStitcherArticlesInfo;
        private MetroFramework.Controls.MetroTextBox txtPackingSearch;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnExcelExport;
        private MetroFramework.Controls.MetroButton BtnFilter;
    }
}