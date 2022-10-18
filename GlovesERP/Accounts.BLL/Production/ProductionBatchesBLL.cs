using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;


namespace Accounts.BLL
{
    public class ProductionBatchesBLL
    {
        ProductionBatchesDAL dal;
        public ProductionBatchesBLL()
        {
            dal = new ProductionBatchesDAL();
        }
        public bool CompleteBatch(Guid IdBatch)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.CompleteBatch(IdBatch, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<ProductionBatchesEL> GetProductionBatchById(Guid IdBatch)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProductionBatchById(IdBatch, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<ProductionBatchesEL> GetAllProductionBatches(Guid IdCompany, int ProductionType, int BatchStatus)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetAllProductionBatches(IdCompany, ProductionType, BatchStatus, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
    }
}
