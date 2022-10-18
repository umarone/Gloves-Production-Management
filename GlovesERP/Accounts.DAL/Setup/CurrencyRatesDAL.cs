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
    public class CurrencyRatesDAL
    {
        IDataReader objReader;
        public EntityoperationInfo CreateCurrencyRates(CurrencyRatesEL oelCurrencyRate, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdCurrencyRates = new SqlCommand("[Setup].[Proc_CreateCurrencyRates]", objConn))
            {
                cmdCurrencyRates.CommandType = CommandType.StoredProcedure;
                cmdCurrencyRates.Parameters.Add(new SqlParameter("@IdCurrencyRate", DbType.Int64)).Value = oelCurrencyRate.IdCurrencyRates;
                cmdCurrencyRates.Parameters.Add(new SqlParameter("@IdCurrency", DbType.Int64)).Value = oelCurrencyRate.IdCurrency;
                cmdCurrencyRates.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelCurrencyRate.UserId;
                cmdCurrencyRates.Parameters.Add(new SqlParameter("@CurrencyRates", DbType.String)).Value = oelCurrencyRate.CurrencyRates;
                cmdCurrencyRates.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelCurrencyRate.Discription;
                cmdCurrencyRates.Parameters.Add(new SqlParameter("@IsCurrent", DbType.Boolean)).Value = oelCurrencyRate.IsCurrent;
                cmdCurrencyRates.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelCurrencyRate.CreatedDateTime;

                if (cmdCurrencyRates.ExecuteNonQuery() > -1)
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
        public EntityoperationInfo UpdateCurrencyRates(CurrencyRatesEL oelCurrencyRate, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdCurrencyRates = new SqlCommand("[Setup].[Proc_UpdateCurrencyRates]", objConn))
            {
                cmdCurrencyRates.CommandType = CommandType.StoredProcedure;
                cmdCurrencyRates.Parameters.Add(new SqlParameter("@IdCurrencyRate", DbType.Int64)).Value = oelCurrencyRate.IdCurrencyRates;
                cmdCurrencyRates.Parameters.Add(new SqlParameter("@IdCurrency", DbType.Int64)).Value = oelCurrencyRate.IdCurrency;
                cmdCurrencyRates.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelCurrencyRate.UserId;
                cmdCurrencyRates.Parameters.Add(new SqlParameter("@CurrencyRates", DbType.String)).Value = oelCurrencyRate.CurrencyRates;
                cmdCurrencyRates.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelCurrencyRate.Discription;
                cmdCurrencyRates.Parameters.Add(new SqlParameter("@IsCurrent", DbType.Boolean)).Value = oelCurrencyRate.IsCurrent;
                cmdCurrencyRates.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelCurrencyRate.CreatedDateTime;

                if (cmdCurrencyRates.ExecuteNonQuery() > -1)
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
        public List<CurrencyRatesEL> GetCurrencyRateById(Int64 IdCurrencyRate, SqlConnection objConn)
        {
            List<CurrencyRatesEL> list = new List<CurrencyRatesEL>();
            SqlCommand cmdCurrencyRates = new SqlCommand("[Setup].[Proc_GetCurrencyRateById]", objConn);

            cmdCurrencyRates.Parameters.Add("@IdCurrencyRate", SqlDbType.BigInt).Value = IdCurrencyRate;

            cmdCurrencyRates.CommandType = CommandType.StoredProcedure;
            objReader = cmdCurrencyRates.ExecuteReader();
            while (objReader.Read())
            {
                CurrencyRatesEL oelCurrencyRate = new CurrencyRatesEL();
                oelCurrencyRate.IdCurrencyRates = Validation.GetSafeLong(objReader["CurrencyRate_Id"]);
                oelCurrencyRate.IdCurrency = Validation.GetSafeLong(objReader["Currency_Id"]);
                oelCurrencyRate.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                oelCurrencyRate.CurrencyName = Validation.GetSafeString(objReader["CurrencyName"]);
                oelCurrencyRate.CurrencySymbol = Validation.GetSafeString(objReader["CurrencySymbol"]);
                oelCurrencyRate.CurrencyRates = Validation.GetSafeDecimal(objReader["CurrencyRates"]);
                oelCurrencyRate.UserName = Validation.GetSafeString(objReader["UserName"]);
                oelCurrencyRate.IsCurrent = Validation.GetSafeBoolean(objReader["IsCurrent"]);
                oelCurrencyRate.Discription = Validation.GetSafeString(objReader["Discription"]);
                oelCurrencyRate.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);

                list.Add(oelCurrencyRate);
            }
            return list;
        }
        public List<CurrencyRatesEL> GetCurrentCurrencyRate(Int64 IdCurrency, SqlConnection objConn)
        {
            List<CurrencyRatesEL> list = new List<CurrencyRatesEL>();
            SqlCommand cmdCurrencyRates = new SqlCommand("[Setup].[Proc_GetCurrentCurrencyRate]", objConn);

            cmdCurrencyRates.Parameters.Add("@IdCurrency", SqlDbType.BigInt).Value = IdCurrency;

            cmdCurrencyRates.CommandType = CommandType.StoredProcedure;
            objReader = cmdCurrencyRates.ExecuteReader();
            while (objReader.Read())
            {
                CurrencyRatesEL oelCurrencyRate = new CurrencyRatesEL();
                oelCurrencyRate.IdCurrencyRates = Validation.GetSafeLong(objReader["CurrencyRate_Id"]);
                oelCurrencyRate.IdCurrency = Validation.GetSafeLong(objReader["Currency_Id"]);
                oelCurrencyRate.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                oelCurrencyRate.CurrencyName = Validation.GetSafeString(objReader["CurrencyName"]);
                oelCurrencyRate.CurrencySymbol = Validation.GetSafeString(objReader["CurrencySymbol"]);
                oelCurrencyRate.CurrencyRates = Validation.GetSafeDecimal(objReader["CurrencyRates"]);
                oelCurrencyRate.UserName = Validation.GetSafeString(objReader["UserName"]);
                oelCurrencyRate.IsCurrent = Validation.GetSafeBoolean(objReader["IsCurrent"]);
                oelCurrencyRate.Discription = Validation.GetSafeString(objReader["Discription"]);
                oelCurrencyRate.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);

                list.Add(oelCurrencyRate);
            }
            return list;
        }
        public List<CurrencyRatesEL> GetCurrentCurrencyRateByDate(Int64 IdCurrency, DateTime CurrentDate, SqlConnection objConn)
        {
            List<CurrencyRatesEL> list = new List<CurrencyRatesEL>();
            SqlCommand cmdCurrencyRates = new SqlCommand("[Setup].[Proc_GetCurrentCurrencyRateByDate]", objConn);

            cmdCurrencyRates.Parameters.Add("@IdCurrency", SqlDbType.BigInt).Value = IdCurrency;
            cmdCurrencyRates.Parameters.Add("@CreatedDateTime", SqlDbType.DateTime).Value = CurrentDate;

            cmdCurrencyRates.CommandType = CommandType.StoredProcedure;
            objReader = cmdCurrencyRates.ExecuteReader();
            while (objReader.Read())
            {
                CurrencyRatesEL oelCurrencyRate = new CurrencyRatesEL();
                oelCurrencyRate.IdCurrencyRates = Validation.GetSafeLong(objReader["CurrencyRate_Id"]);
                oelCurrencyRate.IdCurrency = Validation.GetSafeLong(objReader["Currency_Id"]);
                oelCurrencyRate.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                oelCurrencyRate.CurrencyName = Validation.GetSafeString(objReader["CurrencyName"]);
                oelCurrencyRate.CurrencySymbol = Validation.GetSafeString(objReader["CurrencySymbol"]);
                oelCurrencyRate.CurrencyRates = Validation.GetSafeDecimal(objReader["CurrencyRates"]);
                oelCurrencyRate.UserName = Validation.GetSafeString(objReader["UserName"]);
                oelCurrencyRate.Discription = Validation.GetSafeString(objReader["Discription"]);
                oelCurrencyRate.IsCurrent = Validation.GetSafeBoolean(objReader["IsCurrent"]);
                oelCurrencyRate.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);

                list.Add(oelCurrencyRate);
            }
            return list;
        }
    }
}
