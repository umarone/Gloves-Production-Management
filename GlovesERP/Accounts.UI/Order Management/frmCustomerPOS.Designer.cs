namespace Accounts.UI
{
    partial class frmCustomerPOS
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
            this.chkGloves = new MetroFramework.Controls.MetroCheckBox();
            this.chkGarments = new MetroFramework.Controls.MetroCheckBox();
            this.grdPos = new Accounts.UI.CustomDataGrid();
            this.colIdOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPoNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdPos)).BeginInit();
            this.SuspendLayout();
            // 
            // chkGloves
            // 
            this.chkGloves.AutoSize = true;
            this.chkGloves.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkGloves.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkGloves.Location = new System.Drawing.Point(159, 84);
            this.chkGloves.Name = "chkGloves";
            this.chkGloves.Size = new System.Drawing.Size(70, 19);
            this.chkGloves.TabIndex = 3;
            this.chkGloves.Text = "Gloves";
            this.chkGloves.UseSelectable = true;
            this.chkGloves.CheckedChanged += new System.EventHandler(this.chkGloves_CheckedChanged);
            // 
            // chkGarments
            // 
            this.chkGarments.AutoSize = true;
            this.chkGarments.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkGarments.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkGarments.Location = new System.Drawing.Point(470, 84);
            this.chkGarments.Name = "chkGarments";
            this.chkGarments.Size = new System.Drawing.Size(89, 19);
            this.chkGarments.TabIndex = 3;
            this.chkGarments.Text = "Garments";
            this.chkGarments.UseSelectable = true;
            this.chkGarments.CheckedChanged += new System.EventHandler(this.chkGloves_CheckedChanged);
            // 
            // grdPos
            // 
            this.grdPos.AllowUserToAddRows = false;
            this.grdPos.AllowUserToDeleteRows = false;
            this.grdPos.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPos.ColumnHeadersHeight = 28;
            this.grdPos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdOrder,
            this.colOrderNumber,
            this.colPoNumber,
            this.colCustomer,
            this.colBrand});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPos.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdPos.EnableHeadersVisualStyles = false;
            this.grdPos.Location = new System.Drawing.Point(21, 127);
            this.grdPos.Name = "grdPos";
            this.grdPos.ReadOnly = true;
            this.grdPos.RowHeadersVisible = false;
            this.grdPos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPos.Size = new System.Drawing.Size(708, 358);
            this.grdPos.TabIndex = 2;
            this.grdPos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPos_CellDoubleClick);
            this.grdPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdPos_KeyPress);
            // 
            // colIdOrder
            // 
            this.colIdOrder.DataPropertyName = "IdOrder";
            this.colIdOrder.HeaderText = "IdOrder";
            this.colIdOrder.Name = "colIdOrder";
            this.colIdOrder.ReadOnly = true;
            this.colIdOrder.Visible = false;
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.DataPropertyName = "OrderNo";
            this.colOrderNumber.HeaderText = "Order No";
            this.colOrderNumber.Name = "colOrderNumber";
            this.colOrderNumber.ReadOnly = true;
            // 
            // colPoNumber
            // 
            this.colPoNumber.DataPropertyName = "PoNumber";
            this.colPoNumber.HeaderText = "Po Number";
            this.colPoNumber.Name = "colPoNumber";
            this.colPoNumber.ReadOnly = true;
            this.colPoNumber.Width = 200;
            // 
            // colCustomer
            // 
            this.colCustomer.DataPropertyName = "AccountName";
            this.colCustomer.HeaderText = "Customer Name";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Width = 250;
            // 
            // colBrand
            // 
            this.colBrand.DataPropertyName = "BrandName";
            this.colBrand.HeaderText = "Brand";
            this.colBrand.Name = "colBrand";
            this.colBrand.ReadOnly = true;
            this.colBrand.Width = 150;
            // 
            // frmCustomerPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 518);
            this.Controls.Add(this.chkGarments);
            this.Controls.Add(this.chkGloves);
            this.Controls.Add(this.grdPos);
            this.Name = "frmCustomerPOS";
            this.Text = "Customer Pos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCustomerPOS_FormClosing);
            this.Load += new System.EventHandler(this.frmCustomerPOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomDataGrid grdPos;
        private MetroFramework.Controls.MetroCheckBox chkGloves;
        private MetroFramework.Controls.MetroCheckBox chkGarments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPoNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrand;
    }
}