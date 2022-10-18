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
    public class WagesDAL
    {
        IDataReader objReader;
        public bool CreateWages(List<WagesEL> oelWages, SqlConnection objConn)
        {
            using (SqlCommand cmdWages = new SqlCommand("[Setup].[Proc_CreateUpdateWages]", objConn))
            {
                for (int i = 0; i < oelWages.Count; i++)
                {
                    cmdWages.CommandType = CommandType.StoredProcedure;
                    cmdWages.Parameters.Add(new SqlParameter("@SerialNo", DbType.Int32)).Value = oelWages[i].SerialNo;
                    cmdWages.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int32)).Value = oelWages[i].ProductionType;
                    cmdWages.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = oelWages[i].ProcessName;
                    cmdWages.Parameters.Add(new SqlParameter("@WorkType", DbType.String)).Value = oelWages[i].WorkType;
                    cmdWages.Parameters.Add(new SqlParameter("@WorkRate", DbType.Decimal)).Value = oelWages[i].WorkRate;
                    cmdWages.Parameters.Add(new SqlParameter("@CuttingRate", DbType.Decimal)).Value = oelWages[i].CuttingRate;
                    
                    cmdWages.ExecuteNonQuery();
                    cmdWages.Parameters.Clear();
                }
            }
            return true;
        }
        public List<WagesEL> GetWagesByProcess(String ProcessName, SqlConnection objConn)
        {
            List<WagesEL> WagesCollection = new List<WagesEL>();
            using (SqlCommand cmdGetWages = new SqlCommand("[Setup].[Proc_GetWagesByProcess]", objConn))
            {
                cmdGetWages.CommandType = CommandType.StoredProcedure;
                cmdGetWages.Parameters.Add("@ProcessName", SqlDbType.VarChar).Value = ProcessName;
                objReader = cmdGetWages.ExecuteReader();
                while (objReader.Read())
                {
                    WagesEL oelWages = new WagesEL();
                    oelWages.SerialNo = Validation.GetSafeInteger(objReader["SerialNo"]);
                    oelWages.ProductionType = Validation.GetSafeInteger(objReader["ProductionType"]);
                    oelWages.ProcessName = Validation.GetSafeString(objReader["ProcessName"]);
                    oelWages.WorkType = Validation.GetSafeString(objReader["WorkType"]);
                    oelWages.WorkRate = Validation.GetSafeDecimal(objReader["WorkRate"]);
                    oelWages.CuttingRate = Validation.GetSafeDecimal(objReader["CuttingRates"]);
                    WagesCollection.Add(oelWages);
                }
            }
            return WagesCollection;
        }
    }
 
}
