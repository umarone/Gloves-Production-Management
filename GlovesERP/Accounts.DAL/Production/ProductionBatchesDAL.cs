using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accounts.EL;
using System.Data.SqlClient;
using System.Data;
using Accounts.Common;

namespace Accounts.DAL
{
    public class ProductionBatchesDAL
    {
        IDataReader objReader;
        public Int64 CreateBatch(List<ProductionBatchesEL> oelProductionBatch, SqlConnection objConn, SqlTransaction objTran)
        {
            EntityoperationInfo InfoResult = new EntityoperationInfo();
            SqlCommand cmdBatch = new SqlCommand("[Production].[Proc_CreateProductionBatches]", objConn, objTran);
            Int64 BatchNo = 0;
            cmdBatch.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < oelProductionBatch.Count; i++)
            {
                if (oelProductionBatch[i].IdBatch == Guid.Empty)
                {
                    oelProductionBatch[i].IdBatch = Guid.NewGuid();
                }
                cmdBatch.Parameters.Add(new SqlParameter("@IdBatch", DbType.Guid)).Value = oelProductionBatch[i].IdBatch;
                cmdBatch.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelProductionBatch[i].IdCompany;
                cmdBatch.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelProductionBatch[i].BookNo;
                cmdBatch.Parameters.Add(new SqlParameter("@OutWardStatus", DbType.Int64)).Value = oelProductionBatch[i].OutWardStatus;
                cmdBatch.Parameters.Add(new SqlParameter("@InWardStatus", DbType.Int64)).Value = oelProductionBatch[i].InWardStatus;
                cmdBatch.Parameters.Add(new SqlParameter("@BatchStatus", DbType.Int64)).Value = oelProductionBatch[i].BatchStatus;
                cmdBatch.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int64)).Value = oelProductionBatch[i].ProductionType;
                cmdBatch.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelProductionBatch[i].CreatedDateTime;

                BatchNo = Validation.GetSafeLong(cmdBatch.ExecuteScalar());
            }
            return BatchNo;
        }
        public bool CompleteBatch(Guid IdBatch, SqlConnection objConn)
        {
            EntityoperationInfo InfoResult = new EntityoperationInfo();
            SqlCommand cmdBatch = new SqlCommand("[Production].[Proc_CompleteBatches]", objConn);
            cmdBatch.CommandType = CommandType.StoredProcedure;
            cmdBatch.Parameters.Add(new SqlParameter("@IdBatch", DbType.Guid)).Value = IdBatch;
            cmdBatch.ExecuteNonQuery();
            return true;
        }
        public List<ProductionBatchesEL> GetProductionBatchById(Guid IdBatch, SqlConnection objConn)
        {
            List<ProductionBatchesEL> list = new List<ProductionBatchesEL>();
            SqlCommand cmdParents = new SqlCommand("[Production].[Proc_GetProductionBatchById]", objConn);
            cmdParents.CommandType = CommandType.StoredProcedure;
            cmdParents.Parameters.Add(new SqlParameter("@IdBatch", DbType.Guid)).Value = IdBatch;
            objReader = cmdParents.ExecuteReader();
            while (objReader.Read())
            {
                ProductionBatchesEL obj = new ProductionBatchesEL();

                obj.IdBatch = Validation.GetSafeGuid(objReader["Batch_Id"]);
                obj.BatchNo = Validation.GetSafeString(objReader["BatchNumber"]);
                obj.OutWardStatus = Validation.GetSafeString(objReader["OutWardStatus"]);
                //obj.OpeningStock = Validation.GetSafeDecimal(objReader["BatchOutWardQuantity"]);
                //obj.RemainingStock = Validation.GetSafeDecimal(objReader["BatchInWardQuantity"]);
                obj.InWardStatus = Validation.GetSafeString(objReader["InWardStatus"]);
                obj.BatchStatus = Validation.GetSafeInteger(objReader["BatchStatus"]);
                obj.BatchCost = Validation.GetSafeDecimal(objReader["BatchCost"]);
                obj.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);

                list.Add(obj);
            }
            return list;
        }
        public List<ProductionBatchesEL> GetAllProductionBatches(Guid IdCompany, int ProductionType, int BatchStatus, SqlConnection objConn)
        {
            List<ProductionBatchesEL> list = new List<ProductionBatchesEL>();
            SqlCommand cmdParents = new SqlCommand("[Production].[Proc_GetProductionBatches]", objConn);
            cmdParents.CommandType = CommandType.StoredProcedure;
            cmdParents.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdParents.Parameters.Add(new SqlParameter("@ProductionType", DbType.Guid)).Value = ProductionType;
            cmdParents.Parameters.Add(new SqlParameter("@BatchStatus", DbType.Guid)).Value = BatchStatus;
            objReader = cmdParents.ExecuteReader();
            while (objReader.Read())
            {
                ProductionBatchesEL obj = new ProductionBatchesEL();

                obj.IdBatch = Validation.GetSafeGuid(objReader["Batch_Id"]);
                obj.BatchNo = Validation.GetSafeString(objReader["BatchNumber"]);
                obj.OutWardStatus = Validation.GetSafeString(objReader["OutWardStatus"]);
                obj.OpeningStock = Validation.GetSafeDecimal(objReader["BatchOutWardQuantity"]);
                obj.RemainingStock = Validation.GetSafeDecimal(objReader["BatchInWardQuantity"]);
                obj.InWardStatus = Validation.GetSafeString(objReader["InWardStatus"]);
                obj.BatchStatus = Validation.GetSafeInteger(objReader["BatchStatus"]);
                obj.BatchCompletionStatus = Validation.GetSafeString(objReader["BatchCompletionStatus"]);
                obj.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);

                list.Add(obj);
            }
            return list;
        }
    }
}
