using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;

namespace Accounts.BLL
{
    public class ProductionReceiptHeadBLL
    {
        ProductionReceiptHeadDAL dal;
        EntityoperationInfo infoResult;
        public ProductionReceiptHeadBLL()
        {
            dal = new ProductionReceiptHeadDAL();
        }
        public EntityoperationInfo InsertProductionReceipt(VouchersEL oelVoucher, List<VoucherDetailEL> oelProductionCollection, List<VoucherDetailEL> oelWastageCollection, List<TransactionsEL> oelTransactionsCollection, bool WorkType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                infoResult = dal.InsertProductionReceipt(oelVoucher, oelProductionCollection, oelWastageCollection, oelTransactionsCollection, WorkType, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return infoResult;
        }
        public EntityoperationInfo UpdateProductionReceipt(VouchersEL oelVoucher, List<VoucherDetailEL> oelProductionCollection, List<VoucherDetailEL> oelWastageCollection, List<TransactionsEL> oelTransactionsCollection, bool WorkType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                infoResult = dal.UpdateProductionReceipt(oelVoucher, oelProductionCollection, oelWastageCollection, oelTransactionsCollection, WorkType, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return infoResult;
        }
    }
}
