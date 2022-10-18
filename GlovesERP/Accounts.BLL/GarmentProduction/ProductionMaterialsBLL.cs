using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;
using System.Data.SqlClient;

namespace Accounts.BLL
{
    public class ProductionMaterialsBLL
    {
        ProductionMaterialsDAL dal;
        public ProductionMaterialsBLL()
        {
            dal = new ProductionMaterialsDAL();
        }
        public bool CreateMaterialsUsed(ProductionProcessesHeadEL oelProductionHead, List<ProductionMaterialUsedEL> oelMaterialsCollection, List<ProductionMaterialUsedEL> oelMaterialsWastageCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.CreateMaterialsUsed(oelProductionHead, oelMaterialsCollection, oelMaterialsWastageCollection, objConn);
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
        public List<ProductionMaterialUsedEL> GetProductionMaterialByVoucher(Guid IdVoucher, int ProcessHead, string SubProcessHead)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProductionMaterialByVoucher(IdVoucher, ProcessHead, SubProcessHead, objConn);
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
        public List<ProductionMaterialUsedEL> GetProductionMaterialByCustomerPO(string CustomerPo, int ProcessHead, string SubProcessHead)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProductionMaterialByCustomerPO(CustomerPo, ProcessHead, SubProcessHead, objConn);
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
        public List<ProductionMaterialUsedEL> GetProductionWastageByVoucher(Guid IdVoucher, int ProcessHead, string SubProcessHead)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProductionWastageByVoucher(IdVoucher, ProcessHead, SubProcessHead, objConn);
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
        public EntityoperationInfo DeleteMaterialEntry(Guid Id)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.DeleteMaterialEntry(Id, objConn);
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
        public EntityoperationInfo DeleteWastageEntry(Guid Id)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.DeleteWastageEntry(Id, objConn);
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
