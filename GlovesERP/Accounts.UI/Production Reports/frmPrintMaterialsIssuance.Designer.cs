namespace Accounts.UI
{
    partial class frmPrintMaterialsIssuance
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
            this.GatePassReportDoc = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // GatePassReportDoc
            // 
            this.GatePassReportDoc.ActiveViewIndex = -1;
            this.GatePassReportDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GatePassReportDoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.GatePassReportDoc.Location = new System.Drawing.Point(7, 63);
            this.GatePassReportDoc.Name = "GatePassReportDoc";
            this.GatePassReportDoc.Size = new System.Drawing.Size(1180, 460);
            this.GatePassReportDoc.TabIndex = 5;
            this.GatePassReportDoc.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmPrintMaterialsIssuance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 588);
            this.Controls.Add(this.GatePassReportDoc);
            this.Name = "frmPrintMaterialsIssuance";
            this.Text = "frmPrintMaterialsIssuance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrintMaterialsIssuance_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer GatePassReportDoc;
    }
}