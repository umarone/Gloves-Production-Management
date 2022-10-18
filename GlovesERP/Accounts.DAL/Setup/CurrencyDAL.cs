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
    public class CurrencyDAL
    {
        IDataReader objReader;
        public EntityoperationInfo CreateCurrency(CurrencyEL oelCurrency, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdCurrency = new SqlCommand("[Setup].[Proc_CreateCurrency]", objConn))
            {
                cmdCurrency.CommandType = CommandType.StoredProcedure;
                cmdCurrency.Parameters.Add(new SqlParameter("@IdCurrency", DbType.Int64)).Value = oelCurrency.IdCurrency;
                cmdCurrency.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelCurrency.UserId;
                cmdCurrency.Parameters.Add(new SqlParameter("@CurrencyName", DbType.String)).Value = oelCurrency.CurrencyName;
                cmdCurrency.Parameters.Add(new SqlParameter("@CurrencySymbol", DbType.String)).Value = oelCurrency.CurrencySymbol;
                cmdCurrency.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelCurrency.Discription;
                cmdCurrency.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelCurrency.CreatedDateTime;                

                if (cmdCurrency.ExecuteNonQuery() > -1)
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
        public EntityoperationInfo UpdateCurrency(CurrencyEL oelCurrency, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdCurrency = new SqlCommand("[Setup].[Proc_UpdateCurrency]", objConn))
            {
                cmdCurrency.CommandType = CommandType.StoredProcedure;
                cmdCurrency.Parameters.Add(new SqlParameter("@IdCurrency", DbType.Int64)).Value = oelCurrency.IdCurrency;
                cmdCurrency.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelCurrency.UserId;
                cmdCurrency.Parameters.Add(new SqlParameter("@CurrencyName", DbType.String)).Value = oelCurrency.CurrencyName;
                cmdCurrency.Parameters.Add(new SqlParameter("@CurrencySymbol", DbType.String)).Value = oelCurrency.CurrencySymbol;
                cmdCurrency.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelCurrency.Discription;
                cmdCurrency.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelCurrency.CreatedDateTime;  

                if (cmdCurrency.ExecuteNonQuery() > -1)
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
        public List<CurrencyEL> GetCurrencyById(Int64 IdCurrency, SqlConnection objConn)
        {
            List<CurrencyEL> list = new List<CurrencyEL>();
            SqlCommand cmdBrand = new SqlCommand("[Setup].[Proc_GetCurrencyById]", objConn);

            cmdBrand.Parameters.Add("@IdCurrency", SqlDbType.BigInt).Value = IdCurrency;

            cmdBrand.CommandType = CommandType.StoredProcedure;
            objReader = cmdBrand.ExecuteReader();
            while (objReader.Read())
            {
                CurrencyEL oelCurrency = new CurrencyEL();
                oelCurrency.IdCurrency = Validation.GetSafeLong(objReader["Currency_Id"]);
                oelCurrency.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                oelCurrency.CurrencyName = Validation.GetSafeString(objReader["CurrencyName"]);
                oelCurrency.CurrencySymbol = Validation.GetSafeString(objReader["CurrencySymbol"]);
                oelCurrency.UserName = Validation.GetSafeString(objReader["UserName"]);
                oelCurrency.Discription = Validation.GetSafeString(objReader["Discription"]);
                oelCurrency.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelCurrency);
            }
            return list;
        }
        public List<CurrencyEL> GetAllCurrencies(SqlConnection objConn)
        {
            List<CurrencyEL> list = new List<CurrencyEL>();
            SqlCommand cmdBrand = new SqlCommand("[Setup].[Proc_GetAllCurrencies]", objConn);
            cmdBrand.CommandType = CommandType.StoredProcedure;
            objReader = cmdBrand.ExecuteReader();
            while (objReader.Read())
            {
                CurrencyEL oelCurrency = new CurrencyEL();
                oelCurrency.IdCurrency = Validation.GetSafeLong(objReader["Currency_Id"]);
                oelCurrency.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                oelCurrency.CurrencyName = Validation.GetSafeString(objReader["CurrencyName"]);
                oelCurrency.CurrencySymbol = Validation.GetSafeString(objReader["CurrencySymbol"]);
                oelCurrency.UserName = Validation.GetSafeString(objReader["UserName"]);
                oelCurrency.Discription = Validation.GetSafeString(objReader["Discription"]);

                oelCurrency.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelCurrency);
            }
            return list;
        }
    }
}
