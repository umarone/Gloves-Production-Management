namespace Accounts.UI
{
    partial class frmAritcleRequisitionMaterials
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.grdRequisitionMaterials = new Accounts.UI.TabDataGrid();
            this.colIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new DataGridViewProductWaterMarkColumn(); //new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUOM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colOperationType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colcuff = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTalli = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPerunitQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequiredPerUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrandTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdRequisitionMaterials)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.Location = new System.Drawing.Point(895, 423);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 44);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grdRequisitionMaterials
            // 
            this.grdRequisitionMaterials.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.grdRequisitionMaterials.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdRequisitionMaterials.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRequisitionMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdRequisitionMaterials.ColumnHeadersHeight = 25;
            this.grdRequisitionMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdItem,
            this.colIsNew,
            this.colItemName,
            this.colUOM,
            this.colOperationType,
            this.colcuff,
            this.colTalli,
            this.colPerunitQty,
            this.colRequiredPerUnit,
            this.colGrandTotal,
            this.colDelete});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRequisitionMaterials.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdRequisitionMaterials.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdRequisitionMaterials.EnableHeadersVisualStyles = false;
            this.grdRequisitionMaterials.Location = new System.Drawing.Point(23, 78);
            this.grdRequisitionMaterials.MultiSelect = false;
            this.grdRequisitionMaterials.Name = "grdRequisitionMaterials";
            this.grdRequisitionMaterials.RowHeadersVisible = false;
            this.grdRequisitionMaterials.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdRequisitionMaterials.Size = new System.Drawing.Size(1004, 339);
            this.grdRequisitionMaterials.TabIndex = 7;
            this.grdRequisitionMaterials.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRequisitionMaterials_CellClick);
            this.grdRequisitionMaterials.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRequisitionMaterials_CellEndEdit);
            this.grdRequisitionMaterials.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRequisitionMaterials_CellEnter);
            this.grdRequisitionMaterials.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdRequisitionMaterials_CellFormatting);
            this.grdRequisitionMaterials.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdRequisitionMaterials_EditingControlShowing);
            this.grdRequisitionMaterials.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRequisitionMaterials_RowEnter);
            // 
            // colIdItem
            // 
            this.colIdItem.HeaderText = "IdItem";
            this.colIdItem.Name = "colIdItem";
            this.colIdItem.Visible = false;
            // 
            // colIsNew
            // 
            this.colIsNew.HeaderText = "IsNew";
            this.colIsNew.Name = "colIsNew";
            this.colIsNew.Visible = false;
            // 
            // colItemName
            // 
            this.colItemName.HeaderText = "Material Name";
            this.colItemName.Name = "colItemName";
            this.colItemName.Width = 200;
            // 
            // colUOM
            // 
            this.colUOM.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colUOM.HeaderText = "Measurement";
            this.colUOM.Items.AddRange(new object[] {
            "",
            "KG",
            "Meter",
            "Dozen",
            "Pair",
            "Pcs",
            "Meter",
            "Yard"});
            this.colUOM.Name = "colUOM";
            this.colUOM.Width = 120;
            // 
            // colOperationType
            // 
            this.colOperationType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colOperationType.HeaderText = "Operation Type";
            this.colOperationType.Items.AddRange(new object[] {
            "",
            "Multiply",
            "Divide"});
            this.colOperationType.Name = "colOperationType";
            this.colOperationType.Width = 120;
            // 
            // colcuff
            // 
            this.colcuff.HeaderText = "Cuff";
            this.colcuff.Name = "colcuff";
            this.colcuff.Width = 70;
            // 
            // colTalli
            // 
            this.colTalli.HeaderText = "Talli";
            this.colTalli.Name = "colTalli";
            this.colTalli.Width = 70;
            // 
            // colPerunitQty
            // 
            dataGridViewCellStyle3.Format = "1";
            this.colPerunitQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPerunitQty.HeaderText = "Qty(Per Unit)";
            this.colPerunitQty.Name = "colPerunitQty";
            // 
            // colRequiredPerUnit
            // 
            this.colRequiredPerUnit.HeaderText = "Total Required";
            this.colRequiredPerUnit.Name = "colRequiredPerUnit";
            this.colRequiredPerUnit.Width = 110;
            // 
            // colGrandTotal
            // 
            this.colGrandTotal.HeaderText = "Total";
            this.colGrandTotal.Name = "colGrandTotal";
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "...";
            this.colDelete.Name = "colDelete";
            this.colDelete.Width = 110;
            // 
            // frmAritcleRequisitionMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 506);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdRequisitionMaterials);
            this.Name = "frmAritcleRequisitionMaterials";
            this.Text = "frmAritcleRequisitionMaterials";
            this.Load += new System.EventHandler(this.frmAritcleRequisitionMaterials_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdRequisitionMaterials)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabDataGrid grdRequisitionMaterials;
        private MetroFramework.Controls.MetroTile btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colUOM;
        private System.Windows.Forms.DataGridViewComboBoxColumn colOperationType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colcuff;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTalli;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPerunitQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequiredPerUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrandTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}