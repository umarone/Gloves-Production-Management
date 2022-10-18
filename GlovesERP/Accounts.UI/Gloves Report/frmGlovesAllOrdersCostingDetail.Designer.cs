namespace Accounts.UI
{
    partial class frmGlovesAllOrdersCostingDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pnlOrders = new MetroFramework.Controls.MetroPanel();
            this.txtOrderNo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnSelectOrder = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.btnLoadCosting = new MetroFramework.Controls.MetroButton();
            this.txtOrderType = new MetroFramework.Controls.MetroTextBox();
            this.txtOrderedCustomer = new MetroFramework.Controls.MetroTextBox();
            this.txtOrderStatus = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbllabourCost = new MetroFramework.Controls.MetroLabel();
            this.lblMaterialsCost = new MetroFramework.Controls.MetroLabel();
            this.lblMiscCost = new MetroFramework.Controls.MetroLabel();
            this.lblTotalCost = new MetroFramework.Controls.MetroLabel();
            this.grdMiscCost = new Accounts.UI.TabDataGrid();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdLabourCost = new Accounts.UI.TabDataGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdMaterialCost = new Accounts.UI.TabDataGrid();
            this.colMaterialDiscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlOrders.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMiscCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLabourCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterialCost)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(20, 53);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(1119, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "------------------------";
            // 
            // pnlOrders
            // 
            this.pnlOrders.BackColor = System.Drawing.Color.PeachPuff;
            this.pnlOrders.Controls.Add(this.txtOrderNo);
            this.pnlOrders.Controls.Add(this.metroLabel3);
            this.pnlOrders.Controls.Add(this.btnSelectOrder);
            this.pnlOrders.Controls.Add(this.metroLabel4);
            this.pnlOrders.Controls.Add(this.btnLoadCosting);
            this.pnlOrders.Controls.Add(this.txtOrderType);
            this.pnlOrders.Controls.Add(this.txtOrderedCustomer);
            this.pnlOrders.Controls.Add(this.txtOrderStatus);
            this.pnlOrders.Controls.Add(this.metroLabel5);
            this.pnlOrders.HorizontalScrollbarBarColor = true;
            this.pnlOrders.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlOrders.HorizontalScrollbarSize = 10;
            this.pnlOrders.Location = new System.Drawing.Point(23, 75);
            this.pnlOrders.Name = "pnlOrders";
            this.pnlOrders.Size = new System.Drawing.Size(1112, 33);
            this.pnlOrders.TabIndex = 54;
            this.pnlOrders.UseCustomBackColor = true;
            this.pnlOrders.VerticalScrollbarBarColor = true;
            this.pnlOrders.VerticalScrollbarHighlightOnWheel = false;
            this.pnlOrders.VerticalScrollbarSize = 10;
            // 
            // txtOrderNo
            // 
            // 
            // 
            // 
            this.txtOrderNo.CustomButton.Image = null;
            this.txtOrderNo.CustomButton.Location = new System.Drawing.Point(113, 1);
            this.txtOrderNo.CustomButton.Name = "";
            this.txtOrderNo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtOrderNo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOrderNo.CustomButton.TabIndex = 1;
            this.txtOrderNo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOrderNo.CustomButton.UseSelectable = true;
            this.txtOrderNo.CustomButton.Visible = false;
            this.txtOrderNo.Enabled = false;
            this.txtOrderNo.Lines = new string[0];
            this.txtOrderNo.Location = new System.Drawing.Point(98, 5);
            this.txtOrderNo.MaxLength = 32767;
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.PasswordChar = '\0';
            this.txtOrderNo.PromptText = "Order Number";
            this.txtOrderNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOrderNo.SelectedText = "";
            this.txtOrderNo.SelectionLength = 0;
            this.txtOrderNo.SelectionStart = 0;
            this.txtOrderNo.ShortcutsEnabled = true;
            this.txtOrderNo.Size = new System.Drawing.Size(135, 23);
            this.txtOrderNo.TabIndex = 3;
            this.txtOrderNo.UseSelectable = true;
            this.txtOrderNo.WaterMark = "Order Number";
            this.txtOrderNo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOrderNo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(8, 5);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(91, 19);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Select Order :";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // btnSelectOrder
            // 
            this.btnSelectOrder.Location = new System.Drawing.Point(877, 5);
            this.btnSelectOrder.Name = "btnSelectOrder";
            this.btnSelectOrder.Size = new System.Drawing.Size(109, 23);
            this.btnSelectOrder.TabIndex = 4;
            this.btnSelectOrder.Text = "Select Order";
            this.btnSelectOrder.UseSelectable = true;
            this.btnSelectOrder.Click += new System.EventHandler(this.btnSelectOrder_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(240, 7);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(85, 19);
            this.metroLabel4.TabIndex = 2;
            this.metroLabel4.Text = "Order Type :";
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // btnLoadCosting
            // 
            this.btnLoadCosting.Location = new System.Drawing.Point(987, 5);
            this.btnLoadCosting.Name = "btnLoadCosting";
            this.btnLoadCosting.Size = new System.Drawing.Size(109, 23);
            this.btnLoadCosting.TabIndex = 4;
            this.btnLoadCosting.Text = "Load Costing";
            this.btnLoadCosting.UseSelectable = true;
            this.btnLoadCosting.Click += new System.EventHandler(this.btnLoadCosting_Click);
            // 
            // txtOrderType
            // 
            // 
            // 
            // 
            this.txtOrderType.CustomButton.Image = null;
            this.txtOrderType.CustomButton.Location = new System.Drawing.Point(114, 1);
            this.txtOrderType.CustomButton.Name = "";
            this.txtOrderType.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtOrderType.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOrderType.CustomButton.TabIndex = 1;
            this.txtOrderType.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOrderType.CustomButton.UseSelectable = true;
            this.txtOrderType.CustomButton.Visible = false;
            this.txtOrderType.Enabled = false;
            this.txtOrderType.Lines = new string[0];
            this.txtOrderType.Location = new System.Drawing.Point(328, 7);
            this.txtOrderType.MaxLength = 32767;
            this.txtOrderType.Name = "txtOrderType";
            this.txtOrderType.PasswordChar = '\0';
            this.txtOrderType.PromptText = "Order Type";
            this.txtOrderType.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOrderType.SelectedText = "";
            this.txtOrderType.SelectionLength = 0;
            this.txtOrderType.SelectionStart = 0;
            this.txtOrderType.ShortcutsEnabled = true;
            this.txtOrderType.Size = new System.Drawing.Size(136, 23);
            this.txtOrderType.TabIndex = 3;
            this.txtOrderType.UseSelectable = true;
            this.txtOrderType.WaterMark = "Order Type";
            this.txtOrderType.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOrderType.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtOrderedCustomer
            // 
            // 
            // 
            // 
            this.txtOrderedCustomer.CustomButton.Image = null;
            this.txtOrderedCustomer.CustomButton.Location = new System.Drawing.Point(122, 1);
            this.txtOrderedCustomer.CustomButton.Name = "";
            this.txtOrderedCustomer.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtOrderedCustomer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOrderedCustomer.CustomButton.TabIndex = 1;
            this.txtOrderedCustomer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOrderedCustomer.CustomButton.UseSelectable = true;
            this.txtOrderedCustomer.CustomButton.Visible = false;
            this.txtOrderedCustomer.Enabled = false;
            this.txtOrderedCustomer.Lines = new string[0];
            this.txtOrderedCustomer.Location = new System.Drawing.Point(727, 5);
            this.txtOrderedCustomer.MaxLength = 32767;
            this.txtOrderedCustomer.Name = "txtOrderedCustomer";
            this.txtOrderedCustomer.PasswordChar = '\0';
            this.txtOrderedCustomer.PromptText = "Customer Name";
            this.txtOrderedCustomer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOrderedCustomer.SelectedText = "";
            this.txtOrderedCustomer.SelectionLength = 0;
            this.txtOrderedCustomer.SelectionStart = 0;
            this.txtOrderedCustomer.ShortcutsEnabled = true;
            this.txtOrderedCustomer.Size = new System.Drawing.Size(144, 23);
            this.txtOrderedCustomer.TabIndex = 3;
            this.txtOrderedCustomer.UseSelectable = true;
            this.txtOrderedCustomer.WaterMark = "Customer Name";
            this.txtOrderedCustomer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOrderedCustomer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtOrderStatus
            // 
            // 
            // 
            // 
            this.txtOrderStatus.CustomButton.Image = null;
            this.txtOrderStatus.CustomButton.Location = new System.Drawing.Point(108, 1);
            this.txtOrderStatus.CustomButton.Name = "";
            this.txtOrderStatus.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtOrderStatus.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOrderStatus.CustomButton.TabIndex = 1;
            this.txtOrderStatus.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOrderStatus.CustomButton.UseSelectable = true;
            this.txtOrderStatus.CustomButton.Visible = false;
            this.txtOrderStatus.Enabled = false;
            this.txtOrderStatus.Lines = new string[0];
            this.txtOrderStatus.Location = new System.Drawing.Point(467, 7);
            this.txtOrderStatus.MaxLength = 32767;
            this.txtOrderStatus.Name = "txtOrderStatus";
            this.txtOrderStatus.PasswordChar = '\0';
            this.txtOrderStatus.PromptText = "Order Status";
            this.txtOrderStatus.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOrderStatus.SelectedText = "";
            this.txtOrderStatus.SelectionLength = 0;
            this.txtOrderStatus.SelectionStart = 0;
            this.txtOrderStatus.ShortcutsEnabled = true;
            this.txtOrderStatus.Size = new System.Drawing.Size(130, 23);
            this.txtOrderStatus.TabIndex = 3;
            this.txtOrderStatus.UseSelectable = true;
            this.txtOrderStatus.WaterMark = "Order Status";
            this.txtOrderStatus.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOrderStatus.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(607, 6);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(116, 19);
            this.metroLabel5.TabIndex = 2;
            this.metroLabel5.Text = "Customer Name :";
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdMaterialCost);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(20, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 310);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Material Cost";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdLabourCost);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(395, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 308);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Labour Cost";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdMiscCost);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(773, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 309);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Misc Cost";
            // 
            // lbllabourCost
            // 
            this.lbllabourCost.AutoSize = true;
            this.lbllabourCost.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbllabourCost.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lbllabourCost.Location = new System.Drawing.Point(401, 426);
            this.lbllabourCost.Name = "lbllabourCost";
            this.lbllabourCost.Size = new System.Drawing.Size(0, 0);
            this.lbllabourCost.TabIndex = 56;
            // 
            // lblMaterialsCost
            // 
            this.lblMaterialsCost.AutoSize = true;
            this.lblMaterialsCost.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblMaterialsCost.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMaterialsCost.Location = new System.Drawing.Point(24, 426);
            this.lblMaterialsCost.Name = "lblMaterialsCost";
            this.lblMaterialsCost.Size = new System.Drawing.Size(0, 0);
            this.lblMaterialsCost.TabIndex = 57;
            // 
            // lblMiscCost
            // 
            this.lblMiscCost.AutoSize = true;
            this.lblMiscCost.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblMiscCost.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblMiscCost.Location = new System.Drawing.Point(779, 425);
            this.lblMiscCost.Name = "lblMiscCost";
            this.lblMiscCost.Size = new System.Drawing.Size(0, 0);
            this.lblMiscCost.TabIndex = 58;
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTotalCost.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTotalCost.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotalCost.Location = new System.Drawing.Point(395, 464);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(0, 0);
            this.lblTotalCost.TabIndex = 59;
            this.lblTotalCost.UseCustomForeColor = true;
            // 
            // grdMiscCost
            // 
            this.grdMiscCost.AllowUserToAddRows = false;
            this.grdMiscCost.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMiscCost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdMiscCost.ColumnHeadersHeight = 28;
            this.grdMiscCost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.grdMiscCost.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdMiscCost.EnableHeadersVisualStyles = false;
            this.grdMiscCost.Location = new System.Drawing.Point(6, 23);
            this.grdMiscCost.Name = "grdMiscCost";
            this.grdMiscCost.ReadOnly = true;
            this.grdMiscCost.RowHeadersVisible = false;
            this.grdMiscCost.Size = new System.Drawing.Size(356, 280);
            this.grdMiscCost.TabIndex = 56;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Discription";
            this.dataGridViewTextBoxColumn3.HeaderText = "Discription";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TotalAmount";
            this.dataGridViewTextBoxColumn4.HeaderText = "Cost";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // grdLabourCost
            // 
            this.grdLabourCost.AllowUserToAddRows = false;
            this.grdLabourCost.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLabourCost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdLabourCost.ColumnHeadersHeight = 28;
            this.grdLabourCost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.grdLabourCost.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdLabourCost.EnableHeadersVisualStyles = false;
            this.grdLabourCost.Location = new System.Drawing.Point(6, 22);
            this.grdLabourCost.Name = "grdLabourCost";
            this.grdLabourCost.ReadOnly = true;
            this.grdLabourCost.RowHeadersVisible = false;
            this.grdLabourCost.Size = new System.Drawing.Size(356, 280);
            this.grdLabourCost.TabIndex = 56;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Discription";
            this.dataGridViewTextBoxColumn1.HeaderText = "Discription";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LabourCost";
            this.dataGridViewTextBoxColumn2.HeaderText = "Cost";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // grdMaterialCost
            // 
            this.grdMaterialCost.AllowUserToAddRows = false;
            this.grdMaterialCost.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMaterialCost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdMaterialCost.ColumnHeadersHeight = 28;
            this.grdMaterialCost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaterialDiscription,
            this.colMaterialCost});
            this.grdMaterialCost.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdMaterialCost.EnableHeadersVisualStyles = false;
            this.grdMaterialCost.Location = new System.Drawing.Point(6, 22);
            this.grdMaterialCost.Name = "grdMaterialCost";
            this.grdMaterialCost.ReadOnly = true;
            this.grdMaterialCost.RowHeadersVisible = false;
            this.grdMaterialCost.Size = new System.Drawing.Size(356, 282);
            this.grdMaterialCost.TabIndex = 56;
            // 
            // colMaterialDiscription
            // 
            this.colMaterialDiscription.DataPropertyName = "Discription";
            this.colMaterialDiscription.HeaderText = "Discription";
            this.colMaterialDiscription.Name = "colMaterialDiscription";
            this.colMaterialDiscription.ReadOnly = true;
            this.colMaterialDiscription.Width = 250;
            // 
            // colMaterialCost
            // 
            this.colMaterialCost.DataPropertyName = "MaterialsCost";
            this.colMaterialCost.HeaderText = "Cost";
            this.colMaterialCost.Name = "colMaterialCost";
            this.colMaterialCost.ReadOnly = true;
            // 
            // frmGlovesAllOrdersCostingDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 494);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.lblMiscCost);
            this.Controls.Add(this.lblMaterialsCost);
            this.Controls.Add(this.lbllabourCost);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlOrders);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frmGlovesAllOrdersCostingDetail";
            this.Text = "Gloves Orders Costing Detail";
            this.Load += new System.EventHandler(this.frmGlovesAllOrdersCostingDetail_Load);
            this.pnlOrders.ResumeLayout(false);
            this.pnlOrders.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMiscCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLabourCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterialCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel pnlOrders;
        private MetroFramework.Controls.MetroTextBox txtOrderNo;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton btnSelectOrder;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtOrderType;
        private MetroFramework.Controls.MetroTextBox txtOrderedCustomer;
        private MetroFramework.Controls.MetroTextBox txtOrderStatus;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private MetroFramework.Controls.MetroButton btnLoadCosting;
        private TabDataGrid grdMaterialCost;
        private TabDataGrid grdLabourCost;
        private TabDataGrid grdMiscCost;
        private MetroFramework.Controls.MetroLabel lbllabourCost;
        private MetroFramework.Controls.MetroLabel lblMaterialsCost;
        private MetroFramework.Controls.MetroLabel lblMiscCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialDiscription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private MetroFramework.Controls.MetroLabel lblTotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}