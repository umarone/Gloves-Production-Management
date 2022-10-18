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
    public class DyingHeadDAL
    {
        DyingDetailDAL dal;
        TransactionsDAL Tdal;
        public DyingHeadDAL()
        {
            dal = new DyingDetailDAL();
            Tdal = new TransactionsDAL();
        }
        public Int64 GetMaxDyingVoucherNumber(Guid IdCompany, int IssuanceType, SqlConnection objConn)
        {
            using (SqlCommand cmdGatePass = new SqlCommand("[Production].[Proc_GetMaxDyingNumberByType]", objConn))
            {
                cmdGatePass.CommandType = CommandType.StoredProcedure;
                cmdGatePass.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdGatePass.Parameters.Add("@WorkType", SqlDbType.Int).Value = IssuanceType;
                return Validation.GetSafeLong(cmdGatePass.ExecuteScalar());
            }
        }
        public EntityoperationInfo InsertDyingHead(VouchersEL oelVoucher, List<VoucherDetailEL> oelDyingCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = null;
                SqlCommand cmdDying = new SqlCommand("[Production].[Proc_CreateDyingHead]", objConn);

                try
                {
                    objTran = objConn.BeginTransaction();
                    cmdDying.Transaction = objTran;
                    cmdDying.CommandType = CommandType.StoredProcedure;
                    cmdDying.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdDying.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdDying.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdDying.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdDying.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelVoucher.BookNo;
                    cmdDying.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.VDate;
                    cmdDying.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdDying.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelVoucher.VDiscription;
                    cmdDying.Parameters.Add(new SqlParameter("@WorkType", DbType.Boolean)).Value = oelVoucher.WorkType;
                    cmdDying.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdDying.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdDying.ExecuteNonQuery();

                    // Insert Dying Detial...
                    dal.InsertDyingDetail(oelDyingCollection, objConn, objTran);

                    // Insert Dying Transactions...
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
        public EntityoperationInfo UpdateDyingHead(VouchersEL oelVoucher, List<VoucherDetailEL> oelDyingCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = null;
                SqlCommand cmdDying = new SqlCommand("[Production].[Proc_UpdateDyingHead]", objConn);
                try
                {
                    objTran = objConn.BeginTransaction();

                    cmdDying.Transaction = objTran;
                    cmdDying.CommandType = CommandType.StoredProcedure;
                    cmdDying.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdDying.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdDying.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdDying.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdDying.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelVoucher.BookNo;
                    cmdDying.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.VDate;
                    cmdDying.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdDying.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelVoucher.VDiscription;
                    cmdDying.Parameters.Add(new SqlParameter("@WorkType", DbType.Boolean)).Value = oelVoucher.WorkType;
                    cmdDying.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdDying.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdDying.ExecuteNonQuery();

                    // Insert Process Collection...
                    dal.UpdateDyingDetail(oelDyingCollection, objConn, objTran);

                    // Insert Purchase Transactions...
                    Tdal.UpdateTransactions(oelTransactionsCollection, objConn, objTran);
                
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
        public bool DeleteDyingHead(Guid IdVoucher, SqlConnection objConn)
        {
            using (SqlCommand cmdDying = new SqlCommand("[Production].[Proc_DeleteDyingByVoucher]", objConn))
            {
                cmdDying.CommandType = CommandType.StoredProcedure;
                cmdDying.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
                cmdDying.ExecuteNonQuery();
                return true;
            }
        }

    }
}
