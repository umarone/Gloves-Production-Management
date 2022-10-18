namespace Accounts.UI
{
    partial class frmPrintCloseProcessGatePass
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
            this.GatePassReportDoc.Location = new System.Drawing.Point(23, 63);
            this.GatePassReportDoc.Name = "GatePassReportDoc";
            this.GatePassReportDoc.Size = new System.Drawing.Size(1202, 464);
            this.GatePassReportDoc.TabIndex = 6;
            this.GatePassReportDoc.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmPrintCloseProcessGatePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 562);
            this.Controls.Add(this.GatePassReportDoc);
            this.Name = "frmPrintCloseProcessGatePass";
            this.Text = "Rubberizing Gate Pass";
            this.Load += new System.EventHandler(this.frmPrintCloseProcessGatePass_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer GatePassReportDoc;
    }
}