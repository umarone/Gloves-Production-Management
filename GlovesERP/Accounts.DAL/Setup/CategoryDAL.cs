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
    public class CategoryDAL
    {
        IDataReader objReader;
        public EntityoperationInfo CreateCategory(CategoryEL oelCategory, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdCategory = new SqlCommand("[Setup].[Proc_CreateCategory]", objConn))
            {
                cmdCategory.CommandType = CommandType.StoredProcedure;
                cmdCategory.Parameters.Add(new SqlParameter("@IdCategory", DbType.Guid)).Value = oelCategory.IdCategory;
                cmdCategory.Parameters.Add(new SqlParameter("@CategoryCode", DbType.Int64)).Value = oelCategory.CategoryCode;
                cmdCategory.Parameters.Add(new SqlParameter("@CategoryName", DbType.String)).Value = oelCategory.CategoryName;
                cmdCategory.Parameters.Add(new SqlParameter("@CategoryType", DbType.String)).Value = oelCategory.SubCategoryName;
                cmdCategory.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelCategory.IdCompany;                
                cmdCategory.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelCategory.UserId;
                cmdCategory.Parameters.Add(new SqlParameter("@BossCategory", DbType.Int32)).Value = oelCategory.BossCategory;
                cmdCategory.Parameters.Add(new SqlParameter("@IsActive", DbType.Boolean)).Value = oelCategory.IsActive;
                cmdCategory.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelCategory.CreatedDateTime;

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
        public EntityoperationInfo UpdateCategory(CategoryEL oelCategory, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdCategory = new SqlCommand("[Setup].[Proc_UpdateCategory]", objConn))
            {
                cmdCategory.CommandType = CommandType.StoredProcedure;
                cmdCategory.Parameters.Add(new SqlParameter("@IdCategory", DbType.Guid)).Value = oelCategory.IdCategory;
                cmdCategory.Parameters.Add(new SqlParameter("@CategoryCode", DbType.Int64)).Value = oelCategory.CategoryCode;
                cmdCategory.Parameters.Add(new SqlParameter("@CategoryName", DbType.String)).Value = oelCategory.CategoryName;
                cmdCategory.Parameters.Add(new SqlParameter("@CategoryType", DbType.String)).Value = oelCategory.SubCategoryName;
                cmdCategory.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelCategory.IdCompany;
                cmdCategory.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelCategory.UserId;
                cmdCategory.Parameters.Add(new SqlParameter("@BossCategory", DbType.Int32)).Value = oelCategory.BossCategory;
                cmdCategory.Parameters.Add(new SqlParameter("@IsActive", DbType.Boolean)).Value = oelCategory.IsActive;
                cmdCategory.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelCategory.CreatedDateTime;

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
        public EntityoperationInfo DeleteCategory(Guid IdCategory, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdCategory = new SqlCommand("[Setup].[Proc_DeleteCategory]", objConn))
            {
                cmdCategory.CommandType = CommandType.StoredProcedure;
                cmdCategory.Parameters.Add(new SqlParameter("@IdCategory", DbType.Guid)).Value = IdCategory;

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
        public Int64 GetMaxCategoryCode(Guid IdCompany, SqlConnection objConn)
        {
            SqlCommand cmdAccount = new SqlCommand("[Setup].[Proc_GetMaxCategoryCode]", objConn);
            cmdAccount.CommandType = CommandType.StoredProcedure;
            cmdAccount.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            return Validation.GetSafeLong(cmdAccount.ExecuteScalar());

        }
        public List<CategoryEL> GetCategoryById(Guid IdCategory, SqlConnection objConn)
        {
            List<CategoryEL> list = new List<CategoryEL>();
            SqlCommand cmdCategory = new SqlCommand("[Setup].[Proc_GetCategoryById]", objConn);

            cmdCategory.Parameters.Add("@IdCategory", SqlDbType.UniqueIdentifier).Value = IdCategory;

            cmdCategory.CommandType = CommandType.StoredProcedure;
            objReader = cmdCategory.ExecuteReader();
            while (objReader.Read())
            {
                CategoryEL oelCategory = new CategoryEL();
                oelCategory.IdCategory = Validation.GetSafeGuid(objReader["Category_Id"]);
                oelCategory.CategoryCode = Validation.GetSafeString(objReader["Category_Code"]);
                oelCategory.CategoryName = Validation.GetSafeString(objReader["Category_Name"]);
                oelCategory.SubCategoryName = Validation.GetSafeString(objReader["Category_Type"]);
                oelCategory.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                oelCategory.BossCategory = Validation.GetSafeInteger(objReader["BossCategory"]);
                oelCategory.IsActive = Validation.GetSafeBooleanNullable(objReader["IsActive"]);
                oelCategory.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelCategory);
            }
            return list;
        }
        public List<CategoryEL> GetAllCategories(Guid IdCompany,SqlConnection objConn)
        {
            List<CategoryEL> list = new List<CategoryEL>();
            SqlCommand cmdCategory = new SqlCommand("[Setup].[Proc_GetAllCategories]", objConn);
            cmdCategory.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdCategory.CommandType = CommandType.StoredProcedure;
            objReader = cmdCategory.ExecuteReader();
            while (objReader.Read())
            {
                CategoryEL oelCategory = new CategoryEL();
                oelCategory.IdCategory = Validation.GetSafeGuid(objReader["Category_Id"]);
                oelCategory.CategoryCode = Validation.GetSafeString(objReader["Category_Code"]);
                oelCategory.CategoryName = Validation.GetSafeString(objReader["Category_Name"]);
                oelCategory.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                oelCategory.IsActive = Validation.GetSafeBooleanNullable(objReader["IsActive"]);
                oelCategory.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelCategory);
            }
            return list;
        }
        public List<CategoryEL> GetAllCategoriesByBoss(Guid IdCompany, int BossCategory, SqlConnection objConn)
        {
            List<CategoryEL> list = new List<CategoryEL>();
            SqlCommand cmdCategory = new SqlCommand("[Setup].[Proc_GetAllCategoriesByBoss]", objConn);
            cmdCategory.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdCategory.Parameters.Add(new SqlParameter("@BossCategory", DbType.Int32)).Value = BossCategory;
            cmdCategory.CommandType = CommandType.StoredProcedure;
            objReader = cmdCategory.ExecuteReader();
            while (objReader.Read())
            {
                CategoryEL oelCategory = new CategoryEL();
                oelCategory.IdCategory = Validation.GetSafeGuid(objReader["Category_Id"]);
                oelCategory.CategoryCode = Validation.GetSafeString(objReader["Category_Code"]);
                oelCategory.CategoryName = Validation.GetSafeString(objReader["Category_Name"]);
                oelCategory.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                oelCategory.IsActive = Validation.GetSafeBooleanNullable(objReader["IsActive"]);
                oelCategory.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelCategory);
            }
            return list;
        }
        public List<CategoryEL> GetAllCategoriesByCategoryTypes(Guid IdCompany, string CategoryType, SqlConnection objConn)
        {
            List<CategoryEL> list = new List<CategoryEL>();
            SqlCommand cmdCategory = new SqlCommand("[Setup].[Proc_GetAllCategoriesByCategoryTypes]", objConn);
            cmdCategory.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdCategory.Parameters.Add(new SqlParameter("@CategoryType", DbType.String)).Value = CategoryType;
            cmdCategory.CommandType = CommandType.StoredProcedure;
            objReader = cmdCategory.ExecuteReader();
            while (objReader.Read())
            {
                CategoryEL oelCategory = new CategoryEL();
                oelCategory.IdCategory = Validation.GetSafeGuid(objReader["Category_Id"]);
                oelCategory.CategoryCode = Validation.GetSafeString(objReader["Category_Code"]);
                oelCategory.CategoryName = Validation.GetSafeString(objReader["Category_Name"]);
                oelCategory.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                oelCategory.IsActive = Validation.GetSafeBooleanNullable(objReader["IsActive"]);
                oelCategory.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelCategory);
            }
            return list;
        }

        public List<CategoryEL> SearchCategoriesByCategoryName(string CategoryName, Guid IdCompany, SqlConnection objConn)
        {
            List<CategoryEL> list = new List<CategoryEL>();
            SqlCommand cmdSearchStock = new SqlCommand("[Setup].[Proc_SearchCategoriesByCategoryName]", objConn);

            cmdSearchStock.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdSearchStock.Parameters.Add("@CategoryName", SqlDbType.VarChar).Value = CategoryName;

            cmdSearchStock.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdSearchStock.ExecuteReader();
            while (oReader.Read())
            {
                CategoryEL oelCategory = new CategoryEL();
                
                oelCategory.IdCategory = Validation.GetSafeGuid(oReader["Category_Id"]);
                oelCategory.CategoryCode = Validation.GetSafeString(oReader["Category_Code"]);
                oelCategory.CategoryName = Validation.GetSafeString(oReader["Category_Name"]);
                oelCategory.UserId = Validation.GetSafeGuid(oReader["User_Id"]);
                oelCategory.IsActive = Validation.GetSafeBooleanNullable(oReader["IsActive"]);
                oelCategory.CreatedDateTime = Validation.GetSafeDateTime(oReader["Created_DateTime"]);
                
                list.Add(oelCategory);
            }
            return list;
        }
    }
}
