using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Common;

using MetroFramework.Forms;
using MetroFramework.Controls;
using Accounts.Common;


namespace Accounts.UI
{
    public partial class frmPurchaseOrderPrint : MetroForm
    {
        public Int64 VoucherNo { get; set; }
        public Guid IdVoucher { get; set; }
        public string PrintType { get; set; }
        ConnectionInfo oConnectionInfo = new ConnectionInfo();
        public frmPurchaseOrderPrint()
        {
            InitializeComponent();
        }
        private void frmPurchaseOrderPrint_Load(object sender, EventArgs e)
        {
            PrintReport();
        }
        private void PrintReport()
        {
            string strSchemaName = "";
            if (PrintType == "PurchaseOrder")
            {
                strSchemaName = "Transactions";
            }
            else
            {
                strSchemaName = "Reports";
            }
            ReportDocument RptDocument = new ReportDocument();

            if (PrintType == "PurchaseOrder")
            {
                RptDocument.Load("..//..//Reports/rptPurchaseOrder.rpt");
            }
            else
            {
                RptDocument.Load("..//..//Reports/rptPurchases.rpt");
            }
            TableLogOnInfo oTableLogOnInfo = new TableLogOnInfo();
            DbConnectionStringBuilder connectionBuilder = new DbConnectionStringBuilder();
            connectionBuilder.ConnectionString = DBHelper.DataConnection;
            oConnectionInfo.ServerName = connectionBuilder["Data Source"].ToString();
            oConnectionInfo.DatabaseName = connectionBuilder["initial catalog"].ToString();
            oConnectionInfo.UserID = connectionBuilder["user id"].ToString();
            oConnectionInfo.Password = connectionBuilder["password"].ToString();
            //oConnectionInfo.IntegratedSecurity = true;
            oConnectionInfo.Type = ConnectionInfoType.SQL;


            foreach (CrystalDecisions.CrystalReports.Engine.Table oTable in RptDocument.Database.Tables)
            {
                oTableLogOnInfo = oTable.LogOnInfo;
                oTableLogOnInfo.ConnectionInfo = oConnectionInfo;
                oTable.ApplyLogOnInfo(oTableLogOnInfo);
            }

            for (int i = 0; i <= RptDocument.Database.Tables.Count - 1; i++)
            {
                RptDocument.Database.Tables[i].Location = oConnectionInfo.DatabaseName + "." + strSchemaName + "." + RptDocument.Database.Tables[i].Location.Substring(RptDocument.Database.Tables[i].Location.LastIndexOf(".") + 1);
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


                        //string TayloringNumber = VoucherNo;

                        crParamDiscreteValue.Value = "{"+Operations.IdCompany+"}";
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@IdVoucher")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        //string TayloringNumber = VoucherNo;

                        crParamDiscreteValue.Value = "{" + IdVoucher + "}";
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                    else if (def.ParameterFieldName == "@VoucherNo")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;


                        //string TayloringNumber = VoucherNo;

                        crParamDiscreteValue.Value = VoucherNo;
                        crCurrentValues.Add(crParamDiscreteValue);
                        def.ApplyCurrentValues(crCurrentValues);
                    }
                }

            }
            ReportViewer.ReportSource = RptDocument;
        }
    }
}
