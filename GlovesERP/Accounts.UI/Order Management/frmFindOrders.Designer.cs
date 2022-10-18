namespace Accounts.UI
{
    partial class frmFindOrders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDashed = new MetroFramework.Controls.MetroLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkFindByCustomer = new MetroFramework.Controls.MetroCheckBox();
            this.txtFindByCustomer = new MetroFramework.Controls.MetroTextBox();
            this.chkGloves = new System.Windows.Forms.CheckBox();
            this.chkGarments = new System.Windows.Forms.CheckBox();
            this.btnLoadOrders = new System.Windows.Forms.Button();
            this.grdFindOrders = new Accounts.UI.CustomDataGrid();
            this.colOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerPo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFindOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDashed
            // 
            this.lblDashed.AutoSize = true;
            this.lblDashed.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDashed.Location = new System.Drawing.Point(23, 52);
            this.lblDashed.Name = "lblDashed";
            this.lblDashed.Size = new System.Drawing.Size(687, 19);
            this.lblDashed.TabIndex = 0;
            this.lblDashed.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.chkFindByCustomer);
            this.flowLayoutPanel1.Controls.Add(this.txtFindByCustomer);
            this.flowLayoutPanel1.Controls.Add(this.chkGloves);
            this.flowLayoutPanel1.Controls.Add(this.chkGarments);
            this.flowLayoutPanel1.Controls.Add(this.btnLoadOrders);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(23, 74);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(693, 31);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // chkFindByCustomer
            // 
            this.chkFindByCustomer.AutoSize = true;
            this.chkFindByCustomer.Location = new System.Drawing.Point(3, 3);
            this.chkFindByCustomer.Name = "chkFindByCustomer";
            this.chkFindByCustomer.Size = new System.Drawing.Size(91, 15);
            this.chkFindByCustomer.TabIndex = 2;
            this.chkFindByCustomer.Text = "By Customer";
            this.chkFindByCustomer.UseSelectable = true;
            // 
            // txtFindByCustomer
            // 
            // 
            // 
            // 
            this.txtFindByCustomer.CustomButton.Image = null;
            this.txtFindByCustomer.CustomButton.Location = new System.Drawing.Point(271, 1);
            this.txtFindByCustomer.CustomButton.Name = "";
            this.txtFindByCustomer.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtFindByCustomer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFindByCustomer.CustomButton.TabIndex = 1;
            this.txtFindByCustomer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFindByCustomer.CustomButton.UseSelectable = true;
            this.txtFindByCustomer.Lines = new string[0];
            this.txtFindByCustomer.Location = new System.Drawing.Point(100, 3);
            this.txtFindByCustomer.MaxLength = 32767;
            this.txtFindByCustomer.Name = "txtFindByCustomer";
            this.txtFindByCustomer.PasswordChar = '\0';
            this.txtFindByCustomer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFindByCustomer.SelectedText = "";
            this.txtFindByCustomer.SelectionLength = 0;
            this.txtFindByCustomer.SelectionStart = 0;
            this.txtFindByCustomer.ShortcutsEnabled = true;
            this.txtFindByCustomer.ShowButton = true;
            this.txtFindByCustomer.Size = new System.Drawing.Size(293, 23);
            this.txtFindByCustomer.TabIndex = 2;
            this.txtFindByCustomer.UseSelectable = true;
            this.txtFindByCustomer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFindByCustomer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtFindByCustomer.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtFindByCustomer_ButtonClick);
            // 
            // chkGloves
            // 
            this.chkGloves.AutoSize = true;
            this.chkGloves.Location = new System.Drawing.Point(399, 3);
            this.chkGloves.Name = "chkGloves";
            this.chkGloves.Size = new System.Drawing.Size(59, 17);
            this.chkGloves.TabIndex = 3;
            this.chkGloves.Text = "Gloves";
            this.chkGloves.UseVisualStyleBackColor = true;
            this.chkGloves.CheckedChanged += new System.EventHandler(this.chkGloves_CheckedChanged);
            // 
            // chkGarments
            // 
            this.chkGarments.AutoSize = true;
            this.chkGarments.Location = new System.Drawing.Point(464, 3);
            this.chkGarments.Name = "chkGarments";
            this.chkGarments.Size = new System.Drawing.Size(71, 17);
            this.chkGarments.TabIndex = 3;
            this.chkGarments.Text = "Garments";
            this.chkGarments.UseVisualStyleBackColor = true;
            this.chkGarments.CheckedChanged += new System.EventHandler(this.chkGarments_CheckedChanged);
            // 
            // btnLoadOrders
            // 
            this.btnLoadOrders.Location = new System.Drawing.Point(541, 3);
            this.btnLoadOrders.Name = "btnLoadOrders";
            this.btnLoadOrders.Size = new System.Drawing.Size(75, 23);
            this.btnLoadOrders.TabIndex = 4;
            this.btnLoadOrders.Text = "Orders";
            this.btnLoadOrders.UseVisualStyleBackColor = true;
            this.btnLoadOrders.Click += new System.EventHandler(this.btnLoadOrders_Click);
            // 
            // grdFindOrders
            // 
            this.grdFindOrders.AllowUserToResizeRows = false;
            this.grdFindOrders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdFindOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdFindOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdFindOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFindOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFindOrders.ColumnHeadersHeight = 28;
            this.grdFindOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderId,
            this.colIdCurrency,
            this.colorderDate,
            this.colOrderNo,
            this.colBrandName,
            this.colOrderCurrency,
            this.colCustomerPo,
            this.colOrderStatus});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdFindOrders.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdFindOrders.EnableHeadersVisualStyles = false;
            this.grdFindOrders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdFindOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdFindOrders.Location = new System.Drawing.Point(23, 111);
            this.grdFindOrders.Name = "grdFindOrders";
            this.grdFindOrders.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFindOrders.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdFindOrders.RowHeadersVisible = false;
            this.grdFindOrders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdFindOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFindOrders.Size = new System.Drawing.Size(693, 364);
            this.grdFindOrders.TabIndex = 2;
            this.grdFindOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFindOrders_CellDoubleClick);
            this.grdFindOrders.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdFindOrders_KeyPress);
            // 
            // colOrderId
            // 
            this.colOrderId.DataPropertyName = "IdOrder";
            this.colOrderId.HeaderText = "IdOrder";
            this.colOrderId.Name = "colOrderId";
            this.colOrderId.Visible = false;
            // 
            // colIdCurrency
            // 
            this.colIdCurrency.DataPropertyName = "IdCurrency";
            this.colIdCurrency.HeaderText = "IdCurrency";
            this.colIdCurrency.Name = "colIdCurrency";
            this.colIdCurrency.Visible = false;
            // 
            // colorderDate
            // 
            this.colorderDate.DataPropertyName = "OrderDate";
            dataGridViewCellStyle2.Format = "d";
            this.colorderDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colorderDate.HeaderText = "Order Date";
            this.colorderDate.Name = "colorderDate";
            // 
            // colOrderNo
            // 
            this.colOrderNo.DataPropertyName = "OrderNo";
            this.colOrderNo.HeaderText = "Order No";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.Width = 120;
            // 
            // colBrandName
            // 
            this.colBrandName.DataPropertyName = "BrandName";
            this.colBrandName.HeaderText = "Brand Name";
            this.colBrandName.Name = "colBrandName";
            this.colBrandName.Width = 125;
            // 
            // colOrderCurrency
            // 
            this.colOrderCurrency.DataPropertyName = "CurrencyName";
            this.colOrderCurrency.HeaderText = "Currency";
            this.colOrderCurrency.Name = "colOrderCurrency";
            this.colOrderCurrency.Width = 125;
            // 
            // colCustomerPo
            // 
            this.colCustomerPo.DataPropertyName = "PoNumber";
            this.colCustomerPo.HeaderText = "Customer PO";
            this.colCustomerPo.Name = "colCustomerPo";
            // 
            // colOrderStatus
            // 
            this.colOrderStatus.DataPropertyName = "OrderStatus";
            this.colOrderStatus.HeaderText = "Complete Status";
            this.colOrderStatus.Name = "colOrderStatus";
            this.colOrderStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOrderStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colOrderStatus.Width = 120;
            // 
            // frmFindOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 508);
            this.Controls.Add(this.grdFindOrders);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblDashed);
            this.Name = "frmFindOrders";
            this.Text = "Track Customer Orders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFindOrders_FormClosing);
            this.Load += new System.EventHandler(this.frmFindOrders_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFindOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblDashed;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroCheckBox chkFindByCustomer;
        private MetroFramework.Controls.MetroTextBox txtFindByCustomer;
        private CustomDataGrid grdFindOrders;
        private System.Windows.Forms.CheckBox chkGloves;
        private System.Windows.Forms.CheckBox chkGarments;
        private System.Windows.Forms.Button btnLoadOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerPo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colOrderStatus;
    }
}