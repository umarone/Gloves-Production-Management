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
    public class TradingDAL
    {
        public TradingDAL()
        { 
            
        }
        IDataReader ObjReader;
        public EntityoperationInfo InsertTradingCo(TradingEL oelTrading, SqlConnection objConn)
        {
            EntityoperationInfo InfoResult = new EntityoperationInfo();
            using (SqlCommand cmdTradingCo = new SqlCommand("[Setup].[Proc_CreateTradingCo]", objConn))
            {
                cmdTradingCo.CommandType = CommandType.StoredProcedure;
                cmdTradingCo.Parameters.Add(new SqlParameter("@IdTrading", DbType.Guid)).Value = oelTrading.IdTrading;
                cmdTradingCo.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelTrading.IdCompany;
                cmdTradingCo.Parameters.Add(new SqlParameter("@TradingCode", DbType.String)).Value = oelTrading.TradingCode;
                cmdTradingCo.Parameters.Add(new SqlParameter("@TradingName", DbType.String)).Value = oelTrading.TradingName;
                cmdTradingCo.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelTrading.TradingDiscription;

                if (cmdTradingCo.ExecuteNonQuery() > -1)
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
        public EntityoperationInfo UpdateTradingCo(TradingEL oelTrading, SqlConnection objConn)
        {
            EntityoperationInfo InfoResult = new EntityoperationInfo();
            using (SqlCommand cmdTradingCo = new SqlCommand("[Setup].[Proc_UpdateTradingCo]", objConn))
            {
                cmdTradingCo.CommandType = CommandType.StoredProcedure;
                cmdTradingCo.Parameters.Add(new SqlParameter("@IdTrading", DbType.Guid)).Value = oelTrading.IdTrading;
                cmdTradingCo.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelTrading.IdCompany;
                cmdTradingCo.Parameters.Add(new SqlParameter("@TradingCode", DbType.Guid)).Value = oelTrading.TradingCode;
                cmdTradingCo.Parameters.Add(new SqlParameter("@TradingName", DbType.Guid)).Value = oelTrading.TradingName;
                cmdTradingCo.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelTrading.TradingDiscription;

                if (cmdTradingCo.ExecuteNonQuery() > -1)
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
        public EntityoperationInfo DeleteTradingCo(Guid IdTrading, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdCategory = new SqlCommand("[Setup].[Proc_DeleteTradingCo]", objConn))
            {
                cmdCategory.CommandType = CommandType.StoredProcedure;
                cmdCategory.Parameters.Add(new SqlParameter("@IdTradingCo", DbType.Guid)).Value = IdTrading;

                //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
                if (cmdCategory.ExecuteNonQuery() > -1)
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
        public Int64 GetMaxTradingCode(Guid IdCompany, SqlConnection objConn)
        {
            SqlCommand cmdAccount = new SqlCommand("[Setup].[Proc_GetMaxTradingCode]", objConn);
            cmdAccount.CommandType = CommandType.StoredProcedure;
            cmdAccount.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            return Validation.GetSafeLong(cmdAccount.ExecuteScalar());

        }
        public List<TradingEL> GetAllTradingCo(Guid IdCompany,SqlConnection objConn)
        {
            List<TradingEL> list = new List<TradingEL>();
            SqlCommand cmdTradingCo = new SqlCommand("[Setup].[Proc_GetAllTradingCo]", objConn);
            cmdTradingCo.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdTradingCo.CommandType = CommandType.StoredProcedure;
            ObjReader = cmdTradingCo.ExecuteReader();
            while (ObjReader.Read())
            {
                TradingEL objTrading = new TradingEL();
                objTrading.IdTrading = Validation.GetSafeGuid(ObjReader["Trading_Id"]);
                objTrading.IdCompany = Validation.GetSafeGuid(ObjReader["Company_Id"]);
                objTrading.TradingCode = Validation.GetSafeString(ObjReader["Trading_Code"]);
                objTrading.TradingName = Validation.GetSafeString(ObjReader["Trading_Name"]);
                objTrading.TradingDiscription = Validation.GetSafeString(ObjReader["Discription"]);
                list.Add(objTrading);
            }
            return list;
        }
        public List<TradingEL> GetTradingCoById(Guid? Id,SqlConnection objConn)
        {
            List<TradingEL> list = new List<TradingEL>();
            SqlCommand cmdTradingCo = new SqlCommand("[Setup].[Proc_GetTradingCoById]", objConn);
            cmdTradingCo.Parameters.Add(new SqlParameter("@IdTradingCo", DbType.Guid)).Value = Id.Value;
            cmdTradingCo.CommandType = CommandType.StoredProcedure;
            ObjReader = cmdTradingCo.ExecuteReader();
            while (ObjReader.Read())
            {
                TradingEL objTrading = new TradingEL();
                objTrading.IdTrading = Validation.GetSafeGuid(ObjReader["Trading_Id"]);
                objTrading.IdCompany = Validation.GetSafeGuid(ObjReader["Company_Id"]);
                objTrading.TradingCode = Validation.GetSafeString(ObjReader["Trading_Code"]);
                objTrading.TradingName = Validation.GetSafeString(ObjReader["Trading_Name"]);
                objTrading.TradingDiscription = Validation.GetSafeString(ObjReader["Discription"]);
                list.Add(objTrading);
            }
            return list;
        }
    }
}
