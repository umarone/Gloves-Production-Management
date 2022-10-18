using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Accounts.EL;
using Accounts.Common;

namespace Accounts.DAL
{
    public class ProcessesDAL
    {
        IDataReader ObjReader;
        public ProcessesDAL()
        { 
            
        }
        public EntityoperationInfo InsertProcesses(ProcessesEL oelProcess, SqlConnection objConn)
        {
            EntityoperationInfo InfoResult = new EntityoperationInfo();
            using (SqlCommand cmdProcess = new SqlCommand("[Setup].[Proc_CreateDepartment]", objConn))
            {
                cmdProcess.CommandType = CommandType.StoredProcedure;
                cmdProcess.Parameters.Add(new SqlParameter("@IdDepartment", DbType.Guid)).Value = oelProcess.IdProcess;
                cmdProcess.Parameters.Add(new SqlParameter("@DeptCode", DbType.String)).Value = oelProcess.ProcessCode;
                cmdProcess.Parameters.Add(new SqlParameter("@DeptType", DbType.Int32)).Value = oelProcess.ProcessType;
                cmdProcess.Parameters.Add(new SqlParameter("@DeptName", DbType.String)).Value = oelProcess.ProcessName;
                cmdProcess.Parameters.Add(new SqlParameter("@DeptRate", DbType.Decimal)).Value = oelProcess.ProcessRate;
                cmdProcess.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelProcess.Discription;
                cmdProcess.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelProcess.CreatedDateTime;

                if (cmdProcess.ExecuteNonQuery() > -1)
                {
                    InfoResult.IsSuccess = true;
                }
                else
                {
                    InfoResult.IsSuccess = false;
                }

            }
            return InfoResult;
        }
        public EntityoperationInfo UpdateProcesses(ProcessesEL oelProcess, SqlConnection objConn)
        {
            EntityoperationInfo InfoResult = new EntityoperationInfo();
            using (SqlCommand cmdProcess = new SqlCommand("[Setup].[Proc_UpdateDepartment]", objConn))
            {
                cmdProcess.CommandType = CommandType.StoredProcedure;
                cmdProcess.Parameters.Add(new SqlParameter("@IdDepartment", DbType.Guid)).Value = oelProcess.IdProcess;
                cmdProcess.Parameters.Add(new SqlParameter("@DeptCode", DbType.String)).Value = oelProcess.ProcessCode;
                cmdProcess.Parameters.Add(new SqlParameter("@DeptType", DbType.Int32)).Value = oelProcess.ProcessType;
                cmdProcess.Parameters.Add(new SqlParameter("@DeptName", DbType.String)).Value = oelProcess.ProcessName;
                cmdProcess.Parameters.Add(new SqlParameter("@DeptRate", DbType.Decimal)).Value = oelProcess.ProcessRate;
                cmdProcess.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelProcess.Discription;
                cmdProcess.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelProcess.CreatedDateTime;

                if (cmdProcess.ExecuteNonQuery() > -1)
                {
                    InfoResult.IsSuccess = true;
                }
                else
                {
                    InfoResult.IsSuccess = false;
                }

            }
            return InfoResult;
        }
        public EntityoperationInfo DeleteProcesses(Guid IdDept, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdProcess = new SqlCommand("[Setup].[Proc_DeleteDepartment]", objConn))
            {
                cmdProcess.CommandType = CommandType.StoredProcedure;
                cmdProcess.Parameters.Add(new SqlParameter("@IdDepartment", DbType.Guid)).Value = IdDept;

                //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
                if (cmdProcess.ExecuteNonQuery() > -1)
                {
                    infoResult.IsSuccess = true;
                }
                else
                {
                    infoResult.IsSuccess = false;
                }
            }
            return infoResult;
        }
        public Int64 GetMaxProcessCode(SqlConnection objConn)
        {
            SqlCommand cmdProcess = new SqlCommand("[Setup].[Proc_GetMaxDepartmentProcessCode]", objConn);
            cmdProcess.CommandType = CommandType.StoredProcedure;
            return Validation.GetSafeLong(cmdProcess.ExecuteScalar());

        }
        public List<ProcessesEL> GetAllProcesses(SqlConnection objConn)
        {
            List<ProcessesEL> list = new List<ProcessesEL>();
            SqlCommand cmdTradingCo = new SqlCommand("[Setup].[GetAllDepartments]", objConn);
            cmdTradingCo.CommandType = CommandType.StoredProcedure;
            ObjReader = cmdTradingCo.ExecuteReader();
            while (ObjReader.Read())
            {
                ProcessesEL objProcess = new ProcessesEL();
                objProcess.IdProcess = Validation.GetSafeGuid(ObjReader["Department_Id"]);
                objProcess.ProcessCode = Validation.GetSafeString(ObjReader["Department_Code"]);
                //objProcess.ProcessCode = Validation.GetSafeString(ObjReader["DepartmentType_Code"]);
                objProcess.ProcessName = Validation.GetSafeString(ObjReader["Department_Name"]);
                objProcess.Discription = Validation.GetSafeString(ObjReader["Description"]);
                objProcess.CreatedDateTime = Validation.GetSafeNullableDateTime(ObjReader["Created_DateTime"]);
                list.Add(objProcess);
            }
            return list;
        }
        public List<ProcessesEL> GetAllDepartmentsByType(Int32 Id, SqlConnection objConn)
        {
            List<ProcessesEL> list = new List<ProcessesEL>();
            SqlCommand cmdDepartments = new SqlCommand("[Setup].[Proc_GetAllDeparmentsByType]", objConn);
            cmdDepartments.Parameters.Add(new SqlParameter("@Type", DbType.Guid)).Value = Id;
            cmdDepartments.CommandType = CommandType.StoredProcedure;
            ObjReader = cmdDepartments.ExecuteReader();
            while (ObjReader.Read())
            {
                ProcessesEL objProcess = new ProcessesEL();
                objProcess.IdProcess = Validation.GetSafeGuid(ObjReader["Department_Id"]);
                objProcess.ProcessCode = Validation.GetSafeString(ObjReader["Department_Code"]);
                //objProcess.ProcessCode = Validation.GetSafeString(ObjReader["DepartmentType_Code"]);
                objProcess.ProcessName = Validation.GetSafeString(ObjReader["Department_Name"]);
                objProcess.Discription = Validation.GetSafeString(ObjReader["Description"]);
                objProcess.CreatedDateTime = Validation.GetSafeNullableDateTime(ObjReader["Created_DateTime"]);
                list.Add(objProcess);
            }
            return list;
        }
        public List<ProcessesEL> GetProcessById(Guid? Id,SqlConnection objConn)
        {
            List<ProcessesEL> list = new List<ProcessesEL>();
            SqlCommand cmdTradingCo = new SqlCommand("[Setup].[GetDepartmentById]", objConn);
            cmdTradingCo.Parameters.Add(new SqlParameter("@IdDepartment", DbType.Guid)).Value = Id.Value;
            cmdTradingCo.CommandType = CommandType.StoredProcedure;
            ObjReader = cmdTradingCo.ExecuteReader();
            while (ObjReader.Read())
            {
                ProcessesEL objProcess = new ProcessesEL();
                objProcess.IdProcess = Validation.GetSafeGuid(ObjReader["Department_Id"]);
                objProcess.ProcessCode = Validation.GetSafeString(ObjReader["Department_Code"]);
                objProcess.ProcessType = Validation.GetSafeInteger(ObjReader["Department_Type"]);
                objProcess.ProcessName = Validation.GetSafeString(ObjReader["Department_Name"]);
                objProcess.ProcessRate = Validation.GetSafeDecimal(ObjReader["Department_Rate"]);
                objProcess.Discription = Validation.GetSafeString(ObjReader["Description"]);
                objProcess.CreatedDateTime = Validation.GetSafeNullableDateTime(ObjReader["Created_DateTime"]);

                list.Add(objProcess);
            }
            return list;
        }
    }
}
