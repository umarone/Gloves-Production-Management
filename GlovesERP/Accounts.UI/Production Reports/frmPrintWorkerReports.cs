using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MetroFramework.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Common;
using Accounts.Common;

namespace Accounts.UI
{
    public partial class frmPrintWorkerReports : MetroForm
    {
        #region Variables
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string WorkType { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        ConnectionInfo oConnectionInfo = new ConnectionInfo();
        #endregion
        public frmPrintWorkerReports()
        {
            InitializeComponent();
        }
        private void frmPrintWorkerReports_Load(object sender, EventArgs e)
        {
            this.Text = AccountName + " " + "Report";
            PrintReport();
        }
        private void PrintReport()
        {
            string strSchemaName = "Reports";
            ReportDocument RptDocument = new ReportDocument();
            if (WorkType == "Trimming")
            {
                RptDocument.Load("..//..//Reports/rptWorkerTrimming.rpt");
            }
            else if (WorkType == "Splitting")
            {
                RptDocument.Load("..//..//Reports/rptWorkerSplitting.rpt");
            }
            else if (WorkType == "ReTrimming")
            {
                RptDocument.Load("..//..//Reports/rptWorkerRetrimming.rpt");
            }
            else if (WorkType == "Shaving")
            {
                RptDocument.Load("..//..//Reports/rptWorkerShaving.rpt");
            }
            else if (WorkType == "Drumming")
            {
                RptDocument.Load("..//..//Reports/rptWorkerDrumming.rpt");
            }
            else if (WorkType == "Buffing")
            {
                RptDocument.Load("..//..//Reports/rptWorkerBuffing.rpt");
            }
            else if (WorkType == "Cutting")
            {
                RptDocument.Load("..//..//Reports/rptWorkerCutting.rpt");
            }
            TableLogOnInfo oTableLogOnInfo = new TableLogOnInfo();
            DbConnectionStringBuilder connectionBuilder = new DbConnectionStringBuilder();
            connectionBuilder.ConnectionString = DBHelper.DataConnection;
            oConnectionInfo.ServerName = connectionBuilder["Data Source"].ToString();
            oConnectionInfo.DatabaseName = connectionBuilder["initial catalog"].ToString();
            oConnectionInfo.UserID = connectionBuilder["user id"].ToString();
            oConnectionInfo.Password = connectionBuilder["password"].ToString();
            //oConnectionInfo.IntegratedSecurity = true;
            //oConnectionInfo.Type = ConnectionInfoType.SQL;


            foreach (CrystalDecisions.CrystalReports.Engine.Table oTable in RptDocument.Database.Tables)
            {
                oTableLogOnInfo = oTable.LogOnInfo;
                oTableLogOnInfo.ConnectionInfo = oConnectionInfo;
                oTable.ApplyLogOnInfo(oTableLogOnInfo);
            }

            for (int i = 0; i <= RptDocument.Database.Tables.Count - 1; i++)
            {
                try
                {
                    RptDocument.Database.Tables[i].Location = oConnectionInfo.DatabaseName + "." + strSchemaName + "." + RptDocument.Database.Tables[i].Location.Substring(RptDocument.Database.Tables[i].Location.LastIndexOf(".") + 1);
                }
                catch (Exception ex)
                { 
                
                }
            }

            ParameterFieldDefinitions crParamFieldDefinitions = RptDocument.DataDefinition.ParameterFields;
            foreach (ParameterFieldDefinition def in crParamFieldDefinitions)
            {

                if (def.ReportName == "")
                {
                    if (def.ParameterFieldName == "@AccountNo")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = AccountNo;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@WorkType")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = WorkType;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@StartDate")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = startDate;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@EndDate")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = endDate;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                }
                else if (def.ReportName == "rptWorkerLoan")
                {
                    if (def.ParameterFieldName == "@IdCompany")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = "{" + Operations.IdCompany + "}";
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@AccountNo")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = AccountNo;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@StartDate")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = startDate;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@EndDate")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = endDate;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                }
                else if (def.ReportName == "rptWorkerAdvances")
                {
                    if (def.ParameterFieldName == "@IdCompany")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = "{" + Operations.IdCompany + "}";
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@AccountNo")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = AccountNo;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@StartDate")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = startDate;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@EndDate")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = endDate;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                }
                else if (def.ReportName == "rptWorkerPaymentDetail")
                {
                    if (def.ParameterFieldName == "@IdCompany")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = "{" + Operations.IdCompany + "}";
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@AccountNo")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = AccountNo;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@WorkType")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = WorkType;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@StartDate")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = startDate;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@EndDate")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = endDate;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                }             
            }
            WorkerReportDoc.ReportSource = RptDocument;
        }
    }
}
