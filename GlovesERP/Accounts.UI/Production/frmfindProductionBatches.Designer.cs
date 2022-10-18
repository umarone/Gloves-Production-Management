namespace Accounts.UI
{
    partial class frmfindProductionBatches
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
            this.grdBatches = new MetroFramework.Controls.MetroGrid();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btnLoadBatches = new MetroFramework.Controls.MetroButton();
            this.chkContinueBatches = new MetroFramework.Controls.MetroCheckBox();
            this.chkCompletedBatches = new MetroFramework.Controls.MetroCheckBox();
            this.colIdBatches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchOutWardStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutWardQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchInWardStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInWardQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdBatches)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdBatches
            // 
            this.grdBatches.AllowUserToAddRows = false;
            this.grdBatches.AllowUserToDeleteRows = false;
            this.grdBatches.AllowUserToResizeRows = false;
            this.grdBatches.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdBatches.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdBatches.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdBatches.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBatches.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdBatches.ColumnHeadersHeight = 28;
            this.grdBatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdBatches,
            this.colBatchNo,
            this.colBatchOutWardStatus,
            this.colOutWardQty,
            this.colBatchInWardStatus,
            this.colInWardQty,
            this.colBatchStatus,
            this.colCreatedDateTime});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdBatches.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdBatches.EnableHeadersVisualStyles = false;
            this.grdBatches.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdBatches.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdBatches.Location = new System.Drawing.Point(23, 102);
            this.grdBatches.Name = "grdBatches";
            this.grdBatches.ReadOnly = true;
            this.grdBatches.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBatches.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdBatches.RowHeadersVisible = false;
            this.grdBatches.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdBatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBatches.Size = new System.Drawing.Size(804, 392);
            this.grdBatches.TabIndex = 1;
            this.grdBatches.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBatches_CellDoubleClick);
            this.grdBatches.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdBatches_KeyPress);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.metroPanel1.Controls.Add(this.btnLoadBatches);
            this.metroPanel1.Controls.Add(this.chkContinueBatches);
            this.metroPanel1.Controls.Add(this.chkCompletedBatches);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 53);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(804, 45);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // btnLoadBatches
            // 
            this.btnLoadBatches.Location = new System.Drawing.Point(599, 14);
            this.btnLoadBatches.Name = "btnLoadBatches";
            this.btnLoadBatches.Size = new System.Drawing.Size(181, 24);
            this.btnLoadBatches.TabIndex = 3;
            this.btnLoadBatches.Text = "Load Batches";
            this.btnLoadBatches.UseSelectable = true;
            this.btnLoadBatches.Click += new System.EventHandler(this.btnLoadBatches_Click);
            // 
            // chkContinueBatches
            // 
            this.chkContinueBatches.AutoSize = true;
            this.chkContinueBatches.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkContinueBatches.Location = new System.Drawing.Point(37, 16);
            this.chkContinueBatches.Name = "chkContinueBatches";
            this.chkContinueBatches.Size = new System.Drawing.Size(159, 19);
            this.chkContinueBatches.TabIndex = 2;
            this.chkContinueBatches.Text = "In Completed Batches";
            this.chkContinueBatches.UseCustomBackColor = true;
            this.chkContinueBatches.UseSelectable = true;
            this.chkContinueBatches.CheckedChanged += new System.EventHandler(this.chkContinueBatches_CheckedChanged);
            // 
            // chkCompletedBatches
            // 
            this.chkCompletedBatches.AutoSize = true;
            this.chkCompletedBatches.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkCompletedBatches.Location = new System.Drawing.Point(421, 16);
            this.chkCompletedBatches.Name = "chkCompletedBatches";
            this.chkCompletedBatches.Size = new System.Drawing.Size(143, 19);
            this.chkCompletedBatches.TabIndex = 2;
            this.chkCompletedBatches.Text = "Completed Batches";
            this.chkCompletedBatches.UseCustomBackColor = true;
            this.chkCompletedBatches.UseSelectable = true;
            this.chkCompletedBatches.CheckedChanged += new System.EventHandler(this.chkCompletedBatches_CheckedChanged);
            // 
            // colIdBatches
            // 
            this.colIdBatches.DataPropertyName = "IdBatch";
            this.colIdBatches.HeaderText = "IdBatch";
            this.colIdBatches.Name = "colIdBatches";
            this.colIdBatches.ReadOnly = true;
            this.colIdBatches.Visible = false;
            // 
            // colBatchNo
            // 
            this.colBatchNo.DataPropertyName = "BatchNo";
            this.colBatchNo.HeaderText = "Batch No";
            this.colBatchNo.Name = "colBatchNo";
            this.colBatchNo.ReadOnly = true;
            // 
            // colBatchOutWardStatus
            // 
            this.colBatchOutWardStatus.DataPropertyName = "OutWardStatus";
            this.colBatchOutWardStatus.HeaderText = "Outward Status";
            this.colBatchOutWardStatus.Name = "colBatchOutWardStatus";
            this.colBatchOutWardStatus.ReadOnly = true;
            this.colBatchOutWardStatus.Width = 135;
            // 
            // colOutWardQty
            // 
            this.colOutWardQty.DataPropertyName = "OpeningStock";
            this.colOutWardQty.HeaderText = "OutWard Qty";
            this.colOutWardQty.Name = "colOutWardQty";
            this.colOutWardQty.ReadOnly = true;
            // 
            // colBatchInWardStatus
            // 
            this.colBatchInWardStatus.DataPropertyName = "InWardStatus";
            this.colBatchInWardStatus.HeaderText = "InWard Status";
            this.colBatchInWardStatus.Name = "colBatchInWardStatus";
            this.colBatchInWardStatus.ReadOnly = true;
            this.colBatchInWardStatus.Width = 135;
            // 
            // colInWardQty
            // 
            this.colInWardQty.DataPropertyName = "RemainingStock";
            this.colInWardQty.HeaderText = "InWard Qty";
            this.colInWardQty.Name = "colInWardQty";
            this.colInWardQty.ReadOnly = true;
            // 
            // colBatchStatus
            // 
            this.colBatchStatus.DataPropertyName = "BatchCompletionStatus";
            this.colBatchStatus.HeaderText = "Batch Status";
            this.colBatchStatus.Name = "colBatchStatus";
            this.colBatchStatus.ReadOnly = true;
            this.colBatchStatus.Width = 120;
            // 
            // colCreatedDateTime
            // 
            this.colCreatedDateTime.DataPropertyName = "CreatedDateTime";
            dataGridViewCellStyle2.Format = "d";
            this.colCreatedDateTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCreatedDateTime.HeaderText = "Created Date";
            this.colCreatedDateTime.Name = "colCreatedDateTime";
            this.colCreatedDateTime.ReadOnly = true;
            this.colCreatedDateTime.Width = 110;
            // 
            // frmfindProductionBatches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 519);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.grdBatches);
            this.Name = "frmfindProductionBatches";
            this.Text = "Production Batches";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmfindProductionBatches_FormClosing);
            this.Load += new System.EventHandler(this.frmfindProductionBatches_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBatches)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroGrid grdBatches;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroCheckBox chkContinueBatches;
        private MetroFramework.Controls.MetroCheckBox chkCompletedBatches;
        private MetroFramework.Controls.MetroButton btnLoadBatches;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdBatches;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchOutWardStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutWardQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchInWardStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInWardQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedDateTime;
    }
}