using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using Accounts.EL;
using Accounts.Common;

namespace Accounts.DAL
{
    public class ProductionProcessesDAL
    {
        IDataReader objReader;
        ProductionProcessesDetailsDAL PDal;
        public ProductionProcessesDAL()
        {
            PDal = new ProductionProcessesDetailsDAL();
        }
        public EntityoperationInfo CreateProductionProcesses(ProductionProcessesEL oelProductionProcess, List<ProductionProcessDetailEL> oelProductionProcessDetailCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdProcesses = new SqlCommand("[Production].[Proc_CreateProcesses]", objConn, objTran);

            cmdProcesses.CommandType = CommandType.StoredProcedure;
            cmdProcesses.Parameters.Add(new SqlParameter("@IdProcess", DbType.Guid)).Value = oelProductionProcess.IdProductionProcess;
            cmdProcesses.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelProductionProcess.IdVoucher;
            cmdProcesses.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = oelProductionProcess.ProductionProcessName;

            cmdProcesses.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelProductionProcess.VDate;

            if (!IsProductionProcessChildExists(oelProductionProcess.IdVoucher, oelProductionProcess.ProductionProcessName, objConn, objTran))
            {
                if (cmdProcesses.ExecuteNonQuery() > -1)
                {
                    infoResult.IsSuccess = true;
                }
                else
                {
                    infoResult.IsSuccess = false;
                }
            }

            PDal.CreateProductionProcessesDetails(oelProductionProcessDetailCollection, objConn, objTran);

            return infoResult;
        }
        public EntityoperationInfo UpdateProductionProcesses(ProductionProcessesEL oelProductionProcess, List<ProductionProcessDetailEL> oelProductionProcessDetailCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdProcesses = new SqlCommand("[Production].[Proc_UpdateProcesses]", objConn, objTran);

            cmdProcesses.CommandType = CommandType.StoredProcedure;
            cmdProcesses.Parameters.Add(new SqlParameter("@IdProcess", DbType.Guid)).Value = oelProductionProcess.IdProductionProcess;
            cmdProcesses.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelProductionProcess.IdVoucher;
            cmdProcesses.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = oelProductionProcess.ProductionProcessName;

            cmdProcesses.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelProductionProcess.VDate;

            cmdProcesses.ExecuteNonQuery();

            PDal.UpdateProductionProcessesDetails(oelProductionProcessDetailCollection, objConn, objTran);

            return infoResult;
        }
        private bool IsProductionProcessChildExists(Guid IdVoucher, string ProcessName, SqlConnection objConn, SqlTransaction objTran)
        {
            bool Status = false;
            SqlCommand cmdProcess = new SqlCommand("[Production].[Proc_IsProductionProcessChildExists]", objConn, objTran);

            cmdProcess.CommandType = CommandType.StoredProcedure;
            cmdProcess.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = IdVoucher;
            cmdProcess.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = ProcessName;
            objReader = cmdProcess.ExecuteReader();
            while (objReader.Read())
            {
                Status = true;
                break;
            }
            objReader.Close();
            return Status;
        }        
    }
}
