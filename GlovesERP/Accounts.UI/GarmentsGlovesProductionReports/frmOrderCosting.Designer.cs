namespace Accounts.UI
{
    partial class frmOrderCosting
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
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnGetReport = new MetroFramework.Controls.MetroButton();
            this.txtCustomerPo = new MetroFramework.Controls.MetroTextBox();
            this.lblAccountNo = new MetroFramework.Controls.MetroLabel();
            this.grdOrderCosting = new Accounts.UI.CustomDataGrid();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderCosting)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Blue;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.ForeColor = System.Drawing.Color.Blue;
            this.metroLabel2.Location = new System.Drawing.Point(22, 55);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(446, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "--------------------------------------------------------------";
            // 
            // btnGetReport
            // 
            this.btnGetReport.Location = new System.Drawing.Point(295, 87);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(130, 28);
            this.btnGetReport.TabIndex = 23;
            this.btnGetReport.Text = "Get Order Costing";
            this.btnGetReport.UseSelectable = true;
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // txtCustomerPo
            // 
            // 
            // 
            // 
            this.txtCustomerPo.CustomButton.Image = null;
            this.txtCustomerPo.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.txtCustomerPo.CustomButton.Name = "";
            this.txtCustomerPo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCustomerPo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCustomerPo.CustomButton.TabIndex = 1;
            this.txtCustomerPo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCustomerPo.CustomButton.UseSelectable = true;
            this.txtCustomerPo.Lines = new string[0];
            this.txtCustomerPo.Location = new System.Drawing.Point(132, 92);
            this.txtCustomerPo.MaxLength = 32767;
            this.txtCustomerPo.Name = "txtCustomerPo";
            this.txtCustomerPo.PasswordChar = '\0';
            this.txtCustomerPo.PromptText = "Customer Po Here";
            this.txtCustomerPo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCustomerPo.SelectedText = "";
            this.txtCustomerPo.SelectionLength = 0;
            this.txtCustomerPo.SelectionStart = 0;
            this.txtCustomerPo.ShortcutsEnabled = true;
            this.txtCustomerPo.ShowButton = true;
            this.txtCustomerPo.Size = new System.Drawing.Size(131, 23);
            this.txtCustomerPo.Style = MetroFramework.MetroColorStyle.Red;
            this.txtCustomerPo.TabIndex = 24;
            this.txtCustomerPo.UseSelectable = true;
            this.txtCustomerPo.WaterMark = "Customer Po Here";
            this.txtCustomerPo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCustomerPo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountNo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblAccountNo.Location = new System.Drawing.Point(23, 92);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(103, 19);
            this.lblAccountNo.TabIndex = 25;
            this.lblAccountNo.Text = "Customer Po :";
            this.lblAccountNo.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // grdOrderCosting
            // 
            this.grdOrderCosting.AllowUserToAddRows = false;
            this.grdOrderCosting.AllowUserToDeleteRows = false;
            this.grdOrderCosting.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOrderCosting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdOrderCosting.ColumnHeadersHeight = 30;
            this.grdOrderCosting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountName,
            this.colAmount});
            this.grdOrderCosting.EnableHeadersVisualStyles = false;
            this.grdOrderCosting.Location = new System.Drawing.Point(22, 126);
            this.grdOrderCosting.Name = "grdOrderCosting";
            this.grdOrderCosting.ReadOnly = true;
            this.grdOrderCosting.RowHeadersVisible = false;
            this.grdOrderCosting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdOrderCosting.Size = new System.Drawing.Size(438, 385);
            this.grdOrderCosting.TabIndex = 26;
            // 
            // colAccountName
            // 
            this.colAccountName.DataPropertyName = "AccountName";
            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 300;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 130;
            // 
            // frmOrderCosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 534);
            this.Controls.Add(this.grdOrderCosting);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.txtCustomerPo);
            this.Controls.Add(this.btnGetReport);
            this.Controls.Add(this.metroLabel2);
            this.Name = "frmOrderCosting";
            this.Text = "Order Costing";
            this.Load += new System.EventHandler(this.frmOrderCosting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderCosting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnGetReport;
        private MetroFramework.Controls.MetroTextBox txtCustomerPo;
        private MetroFramework.Controls.MetroLabel lblAccountNo;
        private CustomDataGrid grdOrderCosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}