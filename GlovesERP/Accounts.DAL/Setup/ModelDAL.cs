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
    public class ModelDAL
    {
        IDataReader objReader;
        public ModelDAL()
        { 
        
        }
        public EntityoperationInfo CreateModel(ModelEL oelModel, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdModel = new SqlCommand("[Setup].[Proc_CreateBrandModel]", objConn))
            {
                cmdModel.CommandType = CommandType.StoredProcedure;
                cmdModel.Parameters.Add(new SqlParameter("@IdBrandModel", DbType.Guid)).Value = oelModel.IdModel;
                cmdModel.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelModel.IdBrand;
                cmdModel.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelModel.UserId;
                cmdModel.Parameters.Add(new SqlParameter("@BrandModelCode", DbType.String)).Value = oelModel.ModelCode;
                cmdModel.Parameters.Add(new SqlParameter("@BrandModelName", DbType.String)).Value = oelModel.ModelName;
                cmdModel.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelModel.CreatedDateTime;

                //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
                if (cmdModel.ExecuteNonQuery() > -1)
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
        public EntityoperationInfo UpdateModel(ModelEL oelModel, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdModel = new SqlCommand("[Setup].[Proc_UpdateBrandModel]", objConn))
            {
                cmdModel.Parameters.Add(new SqlParameter("@IdBrandModel", DbType.Guid)).Value = oelModel.IdModel;
                cmdModel.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelModel.IdBrand;
                cmdModel.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelModel.UserId;
                cmdModel.Parameters.Add(new SqlParameter("@BrandModelCode", DbType.String)).Value = oelModel.ModelCode;
                cmdModel.Parameters.Add(new SqlParameter("@BrandModelName", DbType.String)).Value = oelModel.ModelName;
                cmdModel.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelModel.CreatedDateTime;

                //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
                if (cmdModel.ExecuteNonQuery() > -1)
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
        public EntityoperationInfo DeleteModel(Guid IdModel, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdModel = new SqlCommand("[Setup].[Proc_DeleteBrandModel]", objConn))
            {
                cmdModel.Parameters.Add(new SqlParameter("@IdBrandModel", DbType.Guid)).Value = IdModel;
                if (cmdModel.ExecuteNonQuery() > -1)
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
    }
}
