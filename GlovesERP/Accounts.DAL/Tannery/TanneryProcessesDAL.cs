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
    public class TanneryProcessesDAL
    {
        IDataReader objReader;
        TanneryProcessesDetailsDAL PDal;
        TanneryLotDetailDAL TDal;
        public TanneryProcessesDAL()
        {
            PDal = new TanneryProcessesDetailsDAL();
            TDal = new TanneryLotDetailDAL();
        }
        public EntityoperationInfo CreateProcesses(TanneryProcessesEL oelProcess, List<TanneryProcessDetailsEL> oelProcessDetailCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdProcesses = new SqlCommand("[Tannery].[Proc_CreateProcesses]", objConn, objTran);

            cmdProcesses.CommandType = CommandType.StoredProcedure;
            cmdProcesses.Parameters.Add(new SqlParameter("@IdProcess", DbType.Guid)).Value = oelProcess.IdProcess;
            cmdProcesses.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelProcess.IdVoucher;
            cmdProcesses.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelProcess.IdUser;
            cmdProcesses.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = oelProcess.ProcessName;

            cmdProcesses.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelProcess.VDate;

            if (!IsProcessChildExists(oelProcess.IdVoucher, oelProcess.ProcessName, objConn, objTran))
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

            PDal.CreateProcessesDetails(oelProcessDetailCollection, objConn, objTran);

            return infoResult;
        }
        public EntityoperationInfo UpdateProcesses(TanneryProcessesEL oelProcess, List<TanneryProcessDetailsEL> oelProcessDetailCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdProcesses = new SqlCommand("[Tannery].[Proc_UpdateProcesses]", objConn, objTran);

            cmdProcesses.CommandType = CommandType.StoredProcedure;
            cmdProcesses.Parameters.Add(new SqlParameter("@IdProcess", DbType.Guid)).Value = oelProcess.IdProcess;
            cmdProcesses.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelProcess.IdVoucher;
            cmdProcesses.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelProcess.IdUser;
            cmdProcesses.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = oelProcess.ProcessName;

            cmdProcesses.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelProcess.VDate;

            cmdProcesses.ExecuteNonQuery();

            PDal.UpdateProcessesDetails(oelProcessDetailCollection, objConn, objTran);

            return infoResult;
        }
        private bool IsProcessChildExists(Guid IdVoucher, string ProcessName, SqlConnection objConn, SqlTransaction objTran)
        {
            bool Status = false;
            SqlCommand cmdProcess = new SqlCommand("[Tannery].[Proc_IsProcessChildExists]", objConn, objTran);

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
        public EntityoperationInfo CreateProcessesWithLots(List<TanneryProcessesEL> oelProcessesCollection, List<TanneryLotDetailEL> oelTanneryLotDetailsCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdProcesses = new SqlCommand("[Tannery].[Proc_CreateProcesses]", objConn, objTran);

            cmdProcesses.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelProcessesCollection.Count; i++)
            {
                cmdProcesses.Parameters.Add(new SqlParameter("@IdProcess", DbType.Guid)).Value = oelProcessesCollection[i].IdProcess;
                cmdProcesses.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelProcessesCollection[i].IdVoucher;
                cmdProcesses.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelProcessesCollection[i].IdUser;
                cmdProcesses.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = oelProcessesCollection[i].ProcessName;
                cmdProcesses.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelProcessesCollection[i].VDate;
                if (!IsProcessChildExists(oelProcessesCollection[i].IdVoucher, oelProcessesCollection[i].ProcessName, objConn, objTran))
                {
                    cmdProcesses.ExecuteNonQuery();
                    cmdProcesses.Parameters.Clear();
                }
            }
            TDal.CreateLotDetail(oelTanneryLotDetailsCollection, objConn, objTran);

            return infoResult;
        }
        public EntityoperationInfo UpdateProcessesWithLots(List<TanneryProcessesEL> oelProcessesCollection, List<TanneryLotDetailEL> oelTanneryLotDetailsCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdProcesses = new SqlCommand("[Tannery].[Proc_UpdateProcesses]", objConn, objTran);

            cmdProcesses.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelProcessesCollection.Count; i++)
            {
                if (!IsTanneryProcessExists(oelProcessesCollection[i].IdVoucher, oelProcessesCollection[i].ProcessName, objConn, objTran))
                {
                    cmdProcesses.CommandText = "[Tannery].[Proc_CreateProcesses]";
                }
                else
                {
                    cmdProcesses.CommandText = "[Tannery].[Proc_UpdateProcesses]";
                }

                cmdProcesses.Parameters.Add(new SqlParameter("@IdProcess", DbType.Guid)).Value = oelProcessesCollection[i].IdProcess;
                cmdProcesses.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelProcessesCollection[i].IdVoucher;
                cmdProcesses.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelProcessesCollection[i].IdUser;
                cmdProcesses.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = oelProcessesCollection[i].ProcessName;
                cmdProcesses.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelProcessesCollection[i].VDate;
                cmdProcesses.ExecuteNonQuery();
                cmdProcesses.Parameters.Clear();
            }

            TDal.UpdateLotDetail(oelTanneryLotDetailsCollection, objConn, objTran);

            return infoResult;
        }
        private bool IsTanneryProcessExists(Guid IdVoucher, string ProcessName, SqlConnection objConn, SqlTransaction objTran)
        {
            bool Status = false;
            SqlCommand cmdProcessHead = new SqlCommand("[Transactions].[Proc_IsTanneryProcessExists]", objConn, objTran);

            cmdProcessHead.CommandType = CommandType.StoredProcedure;
            cmdProcessHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = IdVoucher;
            cmdProcessHead.Parameters.Add(new SqlParameter("@ProcessName", DbType.Guid)).Value = ProcessName;
            objReader = cmdProcessHead.ExecuteReader();
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
