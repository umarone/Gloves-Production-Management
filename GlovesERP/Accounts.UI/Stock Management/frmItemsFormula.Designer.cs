namespace Accounts.UI
{
    partial class frmItemsFormula
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
            this.txtPerUnitQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalUnits = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grdFormulas = new Accounts.UI.TabDataGrid();
            this.colIdCalculation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPerunitQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.cbxOperationType = new MetroFramework.Controls.MetroComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxProductType = new MetroFramework.Controls.MetroComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdFormulas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPerUnitQty
            // 
            this.txtPerUnitQty.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPerUnitQty.Location = new System.Drawing.Point(183, 135);
            this.txtPerUnitQty.Multiline = true;
            this.txtPerUnitQty.Name = "txtPerUnitQty";
            this.txtPerUnitQty.Size = new System.Drawing.Size(60, 36);
            this.txtPerUnitQty.TabIndex = 0;
            this.txtPerUnitQty.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quantity(Per Unit)";
            // 
            // txtTotalUnits
            // 
            this.txtTotalUnits.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalUnits.Location = new System.Drawing.Point(559, 135);
            this.txtTotalUnits.Multiline = true;
            this.txtTotalUnits.Name = "txtTotalUnits";
            this.txtTotalUnits.Size = new System.Drawing.Size(70, 36);
            this.txtTotalUnits.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(480, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Qty";
            // 
            // grdFormulas
            // 
            this.grdFormulas.AllowUserToAddRows = false;
            this.grdFormulas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.grdFormulas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFormulas.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFormulas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdFormulas.ColumnHeadersHeight = 25;
            this.grdFormulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCalculation,
            this.colPerunitQty,
            this.colTotalUnits,
            this.colTotal,
            this.colDelete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdFormulas.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdFormulas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdFormulas.EnableHeadersVisualStyles = false;
            this.grdFormulas.Location = new System.Drawing.Point(45, 181);
            this.grdFormulas.MultiSelect = false;
            this.grdFormulas.Name = "grdFormulas";
            this.grdFormulas.ReadOnly = true;
            this.grdFormulas.RowHeadersVisible = false;
            this.grdFormulas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdFormulas.Size = new System.Drawing.Size(679, 239);
            this.grdFormulas.TabIndex = 6;
            this.grdFormulas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFormulas_CellClick);
            this.grdFormulas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFormulas_CellDoubleClick);
            this.grdFormulas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdFormulas_CellFormatting);
            // 
            // colIdCalculation
            // 
            this.colIdCalculation.HeaderText = "IdOrderDetail";
            this.colIdCalculation.Name = "colIdCalculation";
            this.colIdCalculation.ReadOnly = true;
            this.colIdCalculation.Visible = false;
            this.colIdCalculation.Width = 150;
            // 
            // colPerunitQty
            // 
            this.colPerunitQty.HeaderText = "Qty(Per Unit)";
            this.colPerunitQty.Name = "colPerunitQty";
            this.colPerunitQty.ReadOnly = true;
            this.colPerunitQty.Width = 150;
            // 
            // colTotalUnits
            // 
            this.colTotalUnits.HeaderText = "Total Units";
            this.colTotalUnits.Name = "colTotalUnits";
            this.colTotalUnits.ReadOnly = true;
            this.colTotalUnits.Width = 150;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 150;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "...";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Width = 150;
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(635, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 40);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxOperationType
            // 
            this.cbxOperationType.FormattingEnabled = true;
            this.cbxOperationType.ItemHeight = 23;
            this.cbxOperationType.Items.AddRange(new object[] {
            "",
            "Multiply",
            "Divide"});
            this.cbxOperationType.Location = new System.Drawing.Point(373, 140);
            this.cbxOperationType.Name = "cbxOperationType";
            this.cbxOperationType.Size = new System.Drawing.Size(103, 29);
            this.cbxOperationType.TabIndex = 12;
            this.cbxOperationType.UseSelectable = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(251, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Operation Type";
            // 
            // cbxProductType
            // 
            this.cbxProductType.FormattingEnabled = true;
            this.cbxProductType.ItemHeight = 23;
            this.cbxProductType.Location = new System.Drawing.Point(168, 81);
            this.cbxProductType.Name = "cbxProductType";
            this.cbxProductType.Size = new System.Drawing.Size(201, 29);
            this.cbxProductType.TabIndex = 13;
            this.cbxProductType.UseSelectable = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "Material Types";
            // 
            // frmItemsFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 480);
            this.Controls.Add(this.cbxProductType);
            this.Controls.Add(this.cbxOperationType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdFormulas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalUnits);
            this.Controls.Add(this.txtPerUnitQty);
            this.Name = "frmItemsFormula";
            this.Text = "frmItemsFormula";
            this.Load += new System.EventHandler(this.frmItemsFormula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdFormulas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPerUnitQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalUnits;
        private System.Windows.Forms.Label label2;
        private TabDataGrid grdFormulas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCalculation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPerunitQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroComboBox cbxOperationType;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroComboBox cbxProductType;
        private System.Windows.Forms.Label label4;
    }
}