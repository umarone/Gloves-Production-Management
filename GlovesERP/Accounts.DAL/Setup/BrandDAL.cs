using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using Accounts.EL;
using Accounts.Common;

namespace Accounts
{
   public class BrandDAL
    {
        IDataReader objReader;
        public EntityoperationInfo CreateBrand(BrandEL oelBrand, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdBrand = new SqlCommand("[Setup].[Proc_CreateBrand]", objConn))
            {
                cmdBrand.CommandType = CommandType.StoredProcedure;
                cmdBrand.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelBrand.IdBrand;
                cmdBrand.Parameters.Add(new SqlParameter("@BrandCode", DbType.Int64)).Value = oelBrand.BrandCode;
                cmdBrand.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelBrand.AccountNo;
                cmdBrand.Parameters.Add(new SqlParameter("@BrandName", DbType.String)).Value = oelBrand.BrandName;
                cmdBrand.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelBrand.IdCompany;
                cmdBrand.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelBrand.UserId;
                cmdBrand.Parameters.Add(new SqlParameter("@IsActive", DbType.Boolean)).Value = oelBrand.IsActive;
                cmdBrand.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelBrand.CreatedDateTime;

                //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
                if (cmdBrand.ExecuteNonQuery() > -1)
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
        public EntityoperationInfo UpdateBrand(BrandEL oelBrand, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdBrand = new SqlCommand("[Setup].[Proc_UpdateBrand]", objConn))
            {
                cmdBrand.CommandType = CommandType.StoredProcedure;
                cmdBrand.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelBrand.IdBrand;
                cmdBrand.Parameters.Add(new SqlParameter("@BrandCode", DbType.Int64)).Value = oelBrand.BrandCode;
                cmdBrand.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelBrand.AccountNo;
                cmdBrand.Parameters.Add(new SqlParameter("@BrandName", DbType.String)).Value = oelBrand.BrandName;
                cmdBrand.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelBrand.IdCompany;
                cmdBrand.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelBrand.UserId;
                cmdBrand.Parameters.Add(new SqlParameter("@IsActive", DbType.Boolean)).Value = oelBrand.IsActive;
                cmdBrand.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelBrand.CreatedDateTime;

                //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
                if (cmdBrand.ExecuteNonQuery() > -1)
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
        public Int64 GetMaxBrandCode(Guid IdCompany, SqlConnection objConn)
        {
            SqlCommand cmdAccount = new SqlCommand("[Setup].[Proc_GetMaxBrandCode]", objConn);
            cmdAccount.CommandType = CommandType.StoredProcedure;
            cmdAccount.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            return Validation.GetSafeLong(cmdAccount.ExecuteScalar());

        }
        public List<BrandEL> GetBrandById(Guid IdBrand, SqlConnection objConn)
        {
            List<BrandEL> list = new List<BrandEL>();
            SqlCommand cmdBrand = new SqlCommand("[Setup].[Proc_GetBrandById]", objConn);

            cmdBrand.Parameters.Add("@IdBrand", SqlDbType.UniqueIdentifier).Value = IdBrand;

            cmdBrand.CommandType = CommandType.StoredProcedure;
            objReader = cmdBrand.ExecuteReader();
            while (objReader.Read())
            {
                BrandEL oelBrand = new BrandEL();
                oelBrand.IdBrand = Validation.GetSafeGuid(objReader["Brand_Id"]);
                oelBrand.BrandCode = Validation.GetSafeString(objReader["Brand_Code"]);
                oelBrand.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelBrand.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelBrand.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                oelBrand.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                oelBrand.IsActive = Validation.GetSafeBooleanNullable(objReader["IsActive"]);
                oelBrand.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelBrand);
            }
            return list;
        }
        public List<BrandEL> GetAllBrands(Guid IdCompany, SqlConnection objConn)
        {
            List<BrandEL> list = new List<BrandEL>();
            SqlCommand cmdBrand = new SqlCommand("[Setup].[Proc_GetAllBrands]", objConn);
            cmdBrand.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdBrand.CommandType = CommandType.StoredProcedure;
            objReader = cmdBrand.ExecuteReader();
            while (objReader.Read())
            {
                BrandEL oelBrand = new BrandEL();
                oelBrand.IdBrand = Validation.GetSafeGuid(objReader["Brand_Id"]);
                oelBrand.BrandCode = Validation.GetSafeString(objReader["Brand_Code"]);
                oelBrand.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelBrand.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelBrand.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                oelBrand.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                oelBrand.IsActive = Validation.GetSafeBooleanNullable(objReader["IsActive"]);
                oelBrand.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelBrand);
            }
            return list;
        }
        public List<BrandEL> GetAllBrandsByCustomer(Guid IdCompany, string AccountNo, SqlConnection objConn)
        {
            List<BrandEL> list = new List<BrandEL>();
            SqlCommand cmdBrand = new SqlCommand("[Setup].[Proc_GetAllBrandsByCustomer]", objConn);
            cmdBrand.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdBrand.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
            cmdBrand.CommandType = CommandType.StoredProcedure;
            objReader = cmdBrand.ExecuteReader();
            while (objReader.Read())
            {
                BrandEL oelBrand = new BrandEL();
                oelBrand.IdBrand = Validation.GetSafeGuid(objReader["Brand_Id"]);
                oelBrand.BrandCode = Validation.GetSafeString(objReader["Brand_Code"]);
                oelBrand.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelBrand.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelBrand.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                oelBrand.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                oelBrand.IsActive = Validation.GetSafeBooleanNullable(objReader["IsActive"]);
                oelBrand.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelBrand);
            }
            return list;
        }
    }
}
