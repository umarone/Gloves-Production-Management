namespace Accounts.UI
{
    partial class frmExpenses
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadExpense = new MetroFramework.Controls.MetroTile();
            this.lblToDate = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dtEnd = new MetroFramework.Controls.MetroDateTime();
            this.dtStart = new MetroFramework.Controls.MetroDateTime();
            this.ExpPanel = new System.Windows.Forms.GroupBox();
            this.dgvExpenses = new System.Windows.Forms.DataGridView();
            this.colVoucherNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtExpenseAmount = new MetroFramework.Controls.MetroTextBox();
            this.panel1.SuspendLayout();
            this.ExpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnLoadExpense);
            this.panel1.Controls.Add(this.lblToDate);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Controls.Add(this.dtEnd);
            this.panel1.Controls.Add(this.dtStart);
            this.panel1.Location = new System.Drawing.Point(3, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 52);
            this.panel1.TabIndex = 2;
            // 
            // btnLoadExpense
            // 
            this.btnLoadExpense.ActiveControl = null;
            this.btnLoadExpense.Location = new System.Drawing.Point(643, 6);
            this.btnLoadExpense.Name = "btnLoadExpense";
            this.btnLoadExpense.Size = new System.Drawing.Size(109, 39);
            this.btnLoadExpense.Style = MetroFramework.MetroColorStyle.Silver;
            this.btnLoadExpense.TabIndex = 6;
            this.btnLoadExpense.Text = "Load";
            this.btnLoadExpense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLoadExpense.UseSelectable = true;
            this.btnLoadExpense.Click += new System.EventHandler(this.btnLoadExpense_Click);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(340, 15);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(69, 19);
            this.lblToDate.Style = MetroFramework.MetroColorStyle.Black;
            this.lblToDate.TabIndex = 7;
            this.lblToDate.Text = "End Date :";
            this.lblToDate.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(19, 16);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(74, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Start Date :";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel1.UseStyleColors = true;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(417, 12);
            this.dtEnd.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 29);
            this.dtEnd.TabIndex = 6;
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(99, 12);
            this.dtStart.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 29);
            this.dtStart.TabIndex = 6;
            // 
            // ExpPanel
            // 
            this.ExpPanel.Controls.Add(this.dgvExpenses);
            this.ExpPanel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpPanel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ExpPanel.Location = new System.Drawing.Point(3, 115);
            this.ExpPanel.Name = "ExpPanel";
            this.ExpPanel.Size = new System.Drawing.Size(766, 332);
            this.ExpPanel.TabIndex = 3;
            this.ExpPanel.TabStop = false;
            this.ExpPanel.Text = "Expense Detail";
            // 
            // dgvExpenses
            // 
            this.dgvExpenses.AllowUserToAddRows = false;
            this.dgvExpenses.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dgvExpenses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExpenses.BackgroundColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExpenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExpenses.ColumnHeadersHeight = 25;
            this.dgvExpenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVoucherNo,
            this.colAccountName,
            this.colDescription,
            this.colAmount});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExpenses.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExpenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExpenses.EnableHeadersVisualStyles = false;
            this.dgvExpenses.Location = new System.Drawing.Point(3, 23);
            this.dgvExpenses.Name = "dgvExpenses";
            this.dgvExpenses.ReadOnly = true;
            this.dgvExpenses.RowHeadersVisible = false;
            this.dgvExpenses.Size = new System.Drawing.Size(760, 306);
            this.dgvExpenses.TabIndex = 0;
            this.dgvExpenses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpenses_CellContentClick);
            // 
            // colVoucherNo
            // 
            this.colVoucherNo.HeaderText = "V . #";
            this.colVoucherNo.Name = "colVoucherNo";
            this.colVoucherNo.ReadOnly = true;
            // 
            // colAccountName
            // 
            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            this.colAccountName.Width = 200;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 300;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // txtExpenseAmount
            // 
            // 
            // 
            // 
            this.txtExpenseAmount.CustomButton.Image = null;
            this.txtExpenseAmount.CustomButton.Location = new System.Drawing.Point(125, 1);
            this.txtExpenseAmount.CustomButton.Name = "";
            this.txtExpenseAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtExpenseAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtExpenseAmount.CustomButton.TabIndex = 1;
            this.txtExpenseAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtExpenseAmount.CustomButton.UseSelectable = true;
            this.txtExpenseAmount.CustomButton.Visible = false;
            this.txtExpenseAmount.Lines = new string[0];
            this.txtExpenseAmount.Location = new System.Drawing.Point(619, 453);
            this.txtExpenseAmount.MaxLength = 32767;
            this.txtExpenseAmount.Name = "txtExpenseAmount";
            this.txtExpenseAmount.PasswordChar = '\0';
            this.txtExpenseAmount.PromptText = "Total Expenses";
            this.txtExpenseAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtExpenseAmount.SelectedText = "";
            this.txtExpenseAmount.SelectionLength = 0;
            this.txtExpenseAmount.SelectionStart = 0;
            this.txtExpenseAmount.ShortcutsEnabled = true;
            this.txtExpenseAmount.Size = new System.Drawing.Size(147, 23);
            this.txtExpenseAmount.TabIndex = 7;
            this.txtExpenseAmount.UseSelectable = true;
            this.txtExpenseAmount.WaterMark = "Total Expenses";
            this.txtExpenseAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtExpenseAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // frmExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 498);
            this.Controls.Add(this.txtExpenseAmount);
            this.Controls.Add(this.ExpPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmExpenses";
            this.Text = "Expense Register";
            this.Load += new System.EventHandler(this.frmExpenses_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ExpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox ExpPanel;
        private System.Windows.Forms.DataGridView dgvExpenses;
        private MetroFramework.Controls.MetroLabel lblToDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroDateTime dtEnd;
        private MetroFramework.Controls.MetroDateTime dtStart;
        private MetroFramework.Controls.MetroTile btnLoadExpense;
        private MetroFramework.Controls.MetroTextBox txtExpenseAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoucherNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
    }
}