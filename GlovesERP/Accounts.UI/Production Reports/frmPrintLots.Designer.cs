namespace Accounts.UI
{
    partial class frmPrintLots
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
            this.cbxStatus = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnLoad = new MetroFramework.Controls.MetroButton();
            this.LotReportDoc = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cbxStatus
            // 
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.ItemHeight = 23;
            this.cbxStatus.Items.AddRange(new object[] {
            "",
            "Open",
            "Closed",
            "Open/New"});
            this.cbxStatus.Location = new System.Drawing.Point(116, 63);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(219, 29);
            this.cbxStatus.TabIndex = 0;
            this.cbxStatus.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 65);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(88, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Select Status :";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(357, 63);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(118, 29);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load Report";
            this.btnLoad.UseSelectable = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // LotReportDoc
            // 
            this.LotReportDoc.ActiveViewIndex = -1;
            this.LotReportDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LotReportDoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.LotReportDoc.Location = new System.Drawing.Point(23, 98);
            this.LotReportDoc.Name = "LotReportDoc";
            this.LotReportDoc.Size = new System.Drawing.Size(1200, 536);
            this.LotReportDoc.TabIndex = 3;
            this.LotReportDoc.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmPrintLots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 666);
            this.Controls.Add(this.LotReportDoc);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cbxStatus);
            this.Name = "frmPrintLots";
            this.Text = "Print Lots";
            this.Load += new System.EventHandler(this.frmPrintLots_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cbxStatus;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnLoad;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer LotReportDoc;
    }
}