using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using Accounts.Common;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace Accounts.UI
{
    public partial class frmReports : Form
    {
        ConnectionInfo oConnectionInfo = new ConnectionInfo();
        public Int64 VoucherNo
        {
            get;
            set;
        }
        public Guid IdVoucher
        {
            get;
            set;
        }
        public Int32 InvoiceType
        {
            get;
            set;
        }
        public bool IsWithoutWarranty
        {
            get;
            set;
        }
        public frmReports()
        {
            InitializeComponent();
        }
        private void frmReports_Load(object sender, EventArgs e)
        {
            PrintReport();
        }
        private void PrintReport()
        {
            ReportDocument RptDocument = new ReportDocument();
            if (InvoiceType == 1)
            {
                RptDocument.Load("..//..//Reports/rptSalesWithoutWarrant.rpt");
            }
            else if (InvoiceType == 1)
            {
                RptDocument.Load("..//..//Reports/rptSales.rpt");
            }
            else if (InvoiceType == 3)
            {
                RptDocument.Load("..//..//Reports/rptExportSales.rpt");
            }
            TableLogOnInfo oTableLogOnInfo = new TableLogOnInfo();
            DbConnectionStringBuilder connectionBuilder = new DbConnectionStringBuilder();
            connectionBuilder.ConnectionString = DBHelper.DataConnection;
            oConnectionInfo.ServerName = connectionBuilder["Data Source"].ToString();
            oConnectionInfo.DatabaseName = connectionBuilder["initial catalog"].ToString();
            //oConnectionInfo.UserID = connectionBuilder["user id"].ToString();
            //oConnectionInfo.Password = connectionBuilder["password"].ToString();
            oConnectionInfo.IntegratedSecurity = true;
            oConnectionInfo.Type = ConnectionInfoType.SQL;


            foreach (CrystalDecisions.CrystalReports.Engine.Table oTable in RptDocument.Database.Tables)
            {
                oTableLogOnInfo = oTable.LogOnInfo;
                oTableLogOnInfo.ConnectionInfo = oConnectionInfo;
                oTable.ApplyLogOnInfo(oTableLogOnInfo);
            }

            for (int i = 0; i <= RptDocument.Database.Tables.Count - 1; i++)
            {
                RptDocument.Database.Tables[i].Location = oConnectionInfo.DatabaseName + "." + "Reports" + "." + RptDocument.Database.Tables[i].Location.Substring(RptDocument.Database.Tables[i].Location.LastIndexOf(".") + 1);
            }

            ParameterFieldDefinitions crParamFieldDefinitions = RptDocument.DataDefinition.ParameterFields;
            foreach (ParameterFieldDefinition def in crParamFieldDefinitions)
            {

                if (def.ReportName == "")
                {
                    if (def.ParameterFieldName == "@IdVoucher")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        //string TayloringNumber = VoucherNo;

                        crParamDiscreteValue.Value = "{" + IdVoucher + "}";
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@IdCompany")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        //string TayloringNumber = VoucherNo;

                        crParamDiscreteValue.Value = "{" + Operations.IdCompany + "}";
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@InvoiceType")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        //string TayloringNumber = VoucherNo;

                        crParamDiscreteValue.Value = InvoiceType;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }

                }
            }
            //PageMargins margins = RptDocument.PrintOptions.PageMargins;
            //margins.bottomMargin = 350;/
            //margins.leftMargin = 350;
            //margins.rightMargin = 350;
            //margins.topMargin = 350;   
            //RptDocument.PrintOptions.ApplyPageMargins(margins);

            ReportViewer.ReportSource = RptDocument;
            //RptDocument.PrintToPrinter(1, false, 0, 0);
            //reportViewer1.repo = RptDocument;

            // crystalReportViewer1.ReportSource = RptDocument;
        }
    }
}
