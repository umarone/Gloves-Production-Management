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
    public partial class frmPrintMaterialsIssuance : MetroForm
    {
        #region Variables
        public Int64 IssuanceNo { get; set; }
        public Int64 IssuanceType { get; set; }
        public Int64 ProductionType { get; set; }
        public Guid IdVoucher { get; set; }
        ConnectionInfo oConnectionInfo = new ConnectionInfo();
        #endregion
        public frmPrintMaterialsIssuance()
        {
            InitializeComponent();
        }

        private void frmPrintMaterialsIssuance_Load(object sender, EventArgs e)
        {
            this.Text = "Materials Issuance GatePass";
            PrintReport();
        }
        private void PrintReport()
        {
            string strSchemaName = "Production";
            ReportDocument RptDocument = new ReportDocument();
            RptDocument.Load("..//..//Reports/rptGatePassMaterials.rpt");

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
                    if (def.ParameterFieldName == "@IdCompany")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = "{" + Operations.IdCompany + "}";
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@IdProductionIssuance")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        crParamDiscreteValue.Value = "{" + IdVoucher + "}";
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    //else if (def.ParameterFieldName == "@IssuanceNo")
                    //{
                    //    ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                    //    ParameterValues crCurrentValues = def.CurrentValues;


                    //    crParamDiscreteValue.Value = IssuanceNo;
                    //    crCurrentValues.Add(crParamDiscreteValue);
                    //    def.ApplyCurrentValues(crCurrentValues);
                    //}
                    //else if (def.ParameterFieldName == "@IssuanceType")
                    //{
                    //    ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                    //    ParameterValues crCurrentValues = def.CurrentValues;


                    //    crParamDiscreteValue.Value = IssuanceType;
                    //    crCurrentValues.Add(crParamDiscreteValue);
                    //    def.ApplyCurrentValues(crCurrentValues);
                    //}
                    //else if (def.ParameterFieldName == "@ProductionType")
                    //{
                    //    ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                    //    ParameterValues crCurrentValues = def.CurrentValues;


                    //    crParamDiscreteValue.Value = ProductionType;
                    //    crCurrentValues.Add(crParamDiscreteValue);
                    //    def.ApplyCurrentValues(crCurrentValues);
                    //}
                }
            }
            GatePassReportDoc.ReportSource = RptDocument;
        }
    }
}
