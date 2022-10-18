namespace Accounts.UI
{
    partial class frmPrintWorkerReports
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
            this.WorkerReportDoc = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // WorkerReportDoc
            // 
            this.WorkerReportDoc.ActiveViewIndex = -1;
            this.WorkerReportDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WorkerReportDoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.WorkerReportDoc.Location = new System.Drawing.Point(23, 63);
            this.WorkerReportDoc.Name = "WorkerReportDoc";
            this.WorkerReportDoc.Size = new System.Drawing.Size(1066, 576);
            this.WorkerReportDoc.TabIndex = 4;
            this.WorkerReportDoc.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmPrintWorkerReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 674);
            this.Controls.Add(this.WorkerReportDoc);
            this.Name = "frmPrintWorkerReports";
            this.Text = "frmPrintWorkerReports";
            this.Load += new System.EventHandler(this.frmPrintWorkerReports_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer WorkerReportDoc;
    }
}