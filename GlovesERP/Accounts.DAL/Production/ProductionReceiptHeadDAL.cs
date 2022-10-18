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
    public class ProductionReceiptHeadDAL
    {
        ProductionReceiptDetailDAL dal;
        TransactionsDAL Tdal;
        public ProductionReceiptHeadDAL()
        {
            dal = new ProductionReceiptDetailDAL();
            Tdal = new TransactionsDAL();
        }
        public EntityoperationInfo InsertProductionReceipt(VouchersEL oelVoucher, List<VoucherDetailEL> oelProductionIssuanceCollection, List<VoucherDetailEL> oelWastageCollection, List<TransactionsEL> oelTransactionsCollection, bool WorkType, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = null;
                SqlCommand cmdProductionReceipt = new SqlCommand("[Production].[Proc_CreateInventoryProductionReceiptHead]", objConn);

                try
                {
                    objTran = objConn.BeginTransaction();
                    cmdProductionReceipt.Transaction = objTran;
                    cmdProductionReceipt.CommandType = CommandType.StoredProcedure;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@IdInventoryReceipt", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@IdDepartment", DbType.Guid)).Value = oelVoucher.IdDepartment;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@ReceiptType", DbType.Int32)).Value = oelVoucher.ProcessType;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@WorkType", DbType.Boolean)).Value = oelVoucher.WorkType;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@ReceiptDate", DbType.DateTime)).Value = oelVoucher.CreatedDateTime;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelVoucher.Amount;
                    cmdProductionReceipt.ExecuteNonQuery();

                    //// Insert Purchase Collection...
                    //if (!WorkType)
                    //{
                    //    dal.InsertProductionCuffTalliCuttingIssuanceDetail(oelProductionIssuanceCollection, objConn, objTran);
                    //}
                    //else
                    {
                        dal.InsertProductionReceiptDetail(oelProductionIssuanceCollection, objConn, objTran);

                        dal.InsertProductionWastageDetail(oelWastageCollection, objConn, objTran);

                        Tdal.InsertTransactions(oelTransactionsCollection, objConn, objTran);
                    }
                    objTran.Commit();

                    infoResult.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }



                return infoResult;
            }
        }
        public EntityoperationInfo UpdateProductionReceipt(VouchersEL oelVoucher, List<VoucherDetailEL> oelProductionCollection, List<VoucherDetailEL> oelWastageCollection, List<TransactionsEL> oelTransactionsCollection, bool WorkType, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = null;
                SqlCommand cmdProductionReceipt = new SqlCommand("[Production].[Proc_UpdateInventoryProductionReceiptHead]", objConn);
                try
                {
                    objTran = objConn.BeginTransaction();

                    cmdProductionReceipt.Transaction = objTran;
                    cmdProductionReceipt.CommandType = CommandType.StoredProcedure;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@IdInventoryReceipt", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@IdDepartment", DbType.Guid)).Value = oelVoucher.IdDepartment;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@ReceiptType", DbType.Int32)).Value = oelVoucher.ProcessType;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@WorkType", DbType.Boolean)).Value = oelVoucher.WorkType;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@ReceiptDate", DbType.DateTime)).Value = oelVoucher.CreatedDateTime;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdProductionReceipt.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelVoucher.Amount;

                    cmdProductionReceipt.ExecuteNonQuery();


                    dal.UpdateProductionReceiptDetail(oelProductionCollection, objConn, objTran);

                    dal.UpdateProductionWastageDetail(oelWastageCollection, objConn, objTran);

                    Tdal.InsertTransactions(oelTransactionsCollection, objConn, objTran);
                    objTran.Commit();

                    infoResult.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }

                return infoResult;
            }
        }
    }
}
