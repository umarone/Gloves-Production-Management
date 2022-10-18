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
   public class TanneryLotQualityDAL
    {
       IDataReader objReader;
       public EntityoperationInfo CreateQuality (TanneryLotQualityEL oelQuality, SqlConnection objConn)
       {
           EntityoperationInfo infoResult = new EntityoperationInfo();
           using (SqlCommand cmdQuality = new SqlCommand("[Tannery].[Proc_InsertQuality]"))
           {
               cmdQuality.CommandType = CommandType.StoredProcedure;

               cmdQuality.Parameters.Add(new SqlParameter("@IdQuality", DbType.Guid)).Value = oelQuality.IdQuality;
               cmdQuality.Parameters.Add(new SqlParameter("@QualityCode", DbType.Int32)).Value = oelQuality.QualityCode;
               cmdQuality.Parameters.Add(new SqlParameter("@QualityName", DbType.String)).Value = oelQuality.QualityName;
               cmdQuality.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelQuality.CreatedDateTime;
                if (cmdQuality.ExecuteNonQuery() > -1)
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
       public EntityoperationInfo UpdateQuality(TanneryLotQualityEL oelQuality, SqlConnection objConn)
       {
           EntityoperationInfo infoResult = new EntityoperationInfo();
           using (SqlCommand cmdQuality = new SqlCommand("[Tannery].[Proc_UpdateLotDetail]", objConn))
           {
               cmdQuality.CommandType = CommandType.StoredProcedure;

               cmdQuality.Parameters.Add(new SqlParameter("@IdQuality", DbType.Guid)).Value = oelQuality.IdQuality;
               cmdQuality.Parameters.Add(new SqlParameter("@QualityCode", DbType.Int32)).Value = oelQuality.QualityCode;
               cmdQuality.Parameters.Add(new SqlParameter("@QualityName", DbType.String)).Value = oelQuality.QualityName;
               cmdQuality.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelQuality.CreatedDateTime;

               if (cmdQuality.ExecuteNonQuery() > -1)

                   //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
                   
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
       public EntityoperationInfo Quality(Guid IdQuality, SqlConnection objConn)
       {
           EntityoperationInfo deleteInfo = new EntityoperationInfo();
           int rowsEffected = -1;
           using (SqlCommand cmdQuality = new SqlCommand("[Tannery].[[Proc_DeleteQuality]", objConn))
           {
               cmdQuality.CommandType = CommandType.StoredProcedure;
               cmdQuality.Parameters.Add("@IdQuality", SqlDbType.UniqueIdentifier).Value = IdQuality;

               if (rowsEffected > -1)
               {
                   deleteInfo.IsSuccess = true;
               }
               else
               {
                   deleteInfo.IsSuccess = false;
               }
           }
           return deleteInfo;
       }

           }
       }

   
