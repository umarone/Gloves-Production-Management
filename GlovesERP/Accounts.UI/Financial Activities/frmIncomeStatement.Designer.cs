namespace Accounts.UI
{
    partial class frmIncomeStatement
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
            this.dtStart = new MetroFramework.Controls.MetroDateTime();
            this.dtEndDate = new MetroFramework.Controls.MetroDateTime();
            this.lblStart = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnIncome = new MetroFramework.Controls.MetroTile();
            this.lblCompanyName = new MetroFramework.Controls.MetroLabel();
            this.grdIncome = new Accounts.UI.CustomDataGrid();
            this.colIncomeDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIncome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdIncome)).BeginInit();
            this.SuspendLayout();
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(116, 73);
            this.dtStart.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 29);
            this.dtStart.TabIndex = 5;
            this.dtStart.ValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(454, 73);
            this.dtEndDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(200, 29);
            this.dtEndDate.TabIndex = 5;
            this.dtEndDate.ValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(36, 78);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(74, 19);
            this.lblStart.TabIndex = 6;
            this.lblStart.Text = "Start Date :";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(384, 77);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(62, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "To Date :";
            // 
            // btnIncome
            // 
            this.btnIncome.ActiveControl = null;
            this.btnIncome.Location = new System.Drawing.Point(674, 70);
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(100, 35);
            this.btnIncome.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnIncome.TabIndex = 7;
            this.btnIncome.Text = "Show Income";
            this.btnIncome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIncome.UseSelectable = true;
            this.btnIncome.Click += new System.EventHandler(this.btnIncome_Click);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblCompanyName.Location = new System.Drawing.Point(222, 124);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(303, 35);
            this.lblCompanyName.TabIndex = 8;
            this.lblCompanyName.Text = "                 Company Name";
            // 
            // grdIncome
            // 
            this.grdIncome.AllowUserToAddRows = false;
            this.grdIncome.AllowUserToDeleteRows = false;
            this.grdIncome.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdIncome.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIncome.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIncomeDetail,
            this.ColIncome});
            this.grdIncome.EnableHeadersVisualStyles = false;
            this.grdIncome.Location = new System.Drawing.Point(2, 174);
            this.grdIncome.Name = "grdIncome";
            this.grdIncome.ReadOnly = true;
            this.grdIncome.RowHeadersVisible = false;
            this.grdIncome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdIncome.Size = new System.Drawing.Size(782, 354);
            this.grdIncome.TabIndex = 4;
            // 
            // colIncomeDetail
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIncomeDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.colIncomeDetail.HeaderText = "Incom Detail";
            this.colIncomeDetail.Name = "colIncomeDetail";
            this.colIncomeDetail.ReadOnly = true;
            this.colIncomeDetail.Width = 500;
            // 
            // ColIncome
            // 
            this.ColIncome.HeaderText = ".....";
            this.ColIncome.Name = "ColIncome";
            this.ColIncome.ReadOnly = true;
            this.ColIncome.Width = 200;
            // 
            // frmIncomeStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 552);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.btnIncome);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.grdIncome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "frmIncomeStatement";
            this.Text = "Income Statement";
            this.Load += new System.EventHandler(this.frmIncomeStatement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdIncome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomDataGrid grdIncome;
        private MetroFramework.Controls.MetroDateTime dtStart;
        private MetroFramework.Controls.MetroDateTime dtEndDate;
        private MetroFramework.Controls.MetroLabel lblStart;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile btnIncome;
        private MetroFramework.Controls.MetroLabel lblCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIncomeDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIncome;
    }
}