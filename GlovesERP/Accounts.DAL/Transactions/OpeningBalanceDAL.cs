using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Accounts.EL;
using Accounts.Common;

namespace Accounts.DAL
{
    public class OpeningBalanceDAL
    {
        IDataReader objReader;
        TransactionsDAL dal;
        public OpeningBalanceDAL()
        {
            dal = new TransactionsDAL();
        }
        //public EntityoperationInfo InsertOpeningBalance(List<OpeningBalanceEL> oelOpeninBalanceCollection, List<TransactionsEL> oelTransactionsCollection,List<StockReceiptEL> oelOpeningStockCollection, SqlConnection objConn)
        //{
        //    EntityoperationInfo InfoResult = new EntityoperationInfo();
        //    SqlTransaction oTran = null;
        //    using (SqlCommand cmdOpeningBalance = new SqlCommand("sp_InsertOpeningBalnce", objConn))
        //    {
        //        try
        //        {
        //            oTran = objConn.BeginTransaction();
        //            SqlCommand cmdTransactions = new SqlCommand("sp_insertTransactions", objConn);
        //            for (int i = 0; i < oelTransactionsCollection.Count; i++)
        //            {                                       
        //            cmdOpeningBalance.Transaction = oTran;
        //            cmdOpeningBalance.CommandType = CommandType.StoredProcedure;
        //            cmdOpeningBalance.Parameters.Add(new SqlParameter("@AccountNo", DbType.Guid)).Value = oelOpeninBalanceCollection[i].AccountNo;
        //            cmdOpeningBalance.Parameters.Add(new SqlParameter("@AccountName", DbType.DateTime)).Value = oelOpeninBalanceCollection[i].AccountName;
        //            cmdOpeningBalance.Parameters.Add(new SqlParameter("@Units", DbType.String)).Value = oelOpeninBalanceCollection[i].Units;
        //            cmdOpeningBalance.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelOpeninBalanceCollection[i].Amount;
        //            cmdOpeningBalance.Parameters.Add(new SqlParameter("@IsCurrent", DbType.Decimal)).Value = oelOpeninBalanceCollection[i].IsCurrent;
        //            cmdOpeningBalance.Parameters.Add(new SqlParameter("@Date", DbType.Boolean)).Value = oelOpeninBalanceCollection[i].OpeningBalanceDate;
        //            cmdOpeningBalance.ExecuteNonQuery();
        //            cmdOpeningBalance.Parameters.Clear();

        //            cmdTransactions.CommandType = CommandType.StoredProcedure;
        //            cmdTransactions.Transaction = oTran;
        //            cmdTransactions.Parameters.Add(new SqlParameter("@IdTransaction", DbType.Guid)).Value = oelTransactionsCollection[i].TransactionID;
        //            cmdTransactions.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelTransactionsCollection[i].AccountNo;
        //            cmdTransactions.Parameters.Add(new SqlParameter("@Date", DbType.DateTime)).Value = oelTransactionsCollection[i].Date;
        //            cmdTransactions.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelTransactionsCollection[i].Seq;
        //            cmdTransactions.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int32)).Value = oelTransactionsCollection[i].VoucherNo;
        //            cmdTransactions.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelTransactionsCollection[i].Description;
        //            cmdTransactions.Parameters.Add(new SqlParameter("@Debit", DbType.Int64)).Value = oelTransactionsCollection[i].Debit;
        //            cmdTransactions.Parameters.Add(new SqlParameter("@Credit", DbType.Int64)).Value = oelTransactionsCollection[i].Credit;
        //            cmdTransactions.Parameters.Add(new SqlParameter("@Qty", DbType.Int16)).Value = oelTransactionsCollection[i].Qty;
        //            cmdTransactions.Parameters.Add(new SqlParameter("@Type", DbType.String)).Value = oelTransactionsCollection[i].VoucherType;
        //            cmdTransactions.ExecuteNonQuery();
        //            cmdTransactions.Parameters.Clear();                    
        //            }
        //            if (oelOpeningStockCollection.Count > 0)
        //            {
        //                SqlCommand cmdStockReceiptDetail = new SqlCommand("sp_InsertStockReceipt", objConn);
        //                cmdStockReceiptDetail.CommandType = CommandType.StoredProcedure;
        //                cmdStockReceiptDetail.Transaction = oTran;
        //                for (int j = 0; j < oelOpeningStockCollection.Count; j++)
        //                {
        //                    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@IdStockReceipt", DbType.Guid)).Value = oelOpeningStockCollection[j].IdStockReceipt;
        //                    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelOpeningStockCollection[j].IdUser;
        //                    //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelOpeningStockCollection[j].VoucherNo;
        //                    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@ItemNo", DbType.String)).Value = oelOpeningStockCollection[j].ItemNo;
        //                    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@units", DbType.Int64)).Value = oelOpeningStockCollection[j].Units;
        //                    cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@ActionType", DbType.Int64)).Value = oelOpeningStockCollection[j].ActionType;
        //                    //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@RemainingUnits", DbType.Int64)).Value = oelOpeningStockCollection[j].RemainingUnits;
        //                    //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelOpeningStockCollection[j].Amount;
        //                    //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@stockdate", DbType.DateTime)).Value = oelOpeningStockCollection[j].StockDate;
        //                    cmdStockReceiptDetail.ExecuteNonQuery();
        //                    cmdStockReceiptDetail.Parameters.Clear();
        //                }
        //            }
        //            oTran.Commit();
        //            InfoResult.IsSuccess = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            oTran.Rollback();
        //            throw ex;
        //        }

        //    }

        //    return InfoResult;
        //}
        public EntityoperationInfo InsertOpeningBalance(List<OpeningBalanceEL> oelOpeningBalanceCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            EntityoperationInfo InfoResult = new EntityoperationInfo();
            SqlTransaction objTran = null;
            SqlCommand cmdOpeningBalance = new SqlCommand("[Transactions].[Proc_CreateOpeningBalance]", objConn);
            objTran = objConn.BeginTransaction();
            try
            {
                for (int i = 0; i < oelOpeningBalanceCollection.Count; i++)
                {
                    cmdOpeningBalance.Transaction = objTran;
                    cmdOpeningBalance.CommandType = CommandType.StoredProcedure;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@IdOpeningBalance", DbType.Guid)).Value = oelOpeningBalanceCollection[i].IdOpeningBalance;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelOpeningBalanceCollection[i].IdCompany;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@IdUser", DbType.DateTime)).Value = oelOpeningBalanceCollection[i].UserId;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelOpeningBalanceCollection[i].BookNo;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@AccountNo", DbType.Int64)).Value = oelOpeningBalanceCollection[i].AccountNo;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@EmpCode", DbType.DateTime)).Value = oelOpeningBalanceCollection[i].EmpCode;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelOpeningBalanceCollection[i].Amount;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@Debit", DbType.Decimal)).Value = oelOpeningBalanceCollection[i].Debit;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@Credit", DbType.Decimal)).Value = oelOpeningBalanceCollection[i].Credit;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelOpeningBalanceCollection[i].Discription;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@IsCurrent", DbType.Boolean)).Value = oelOpeningBalanceCollection[i].IsCurrent;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelOpeningBalanceCollection[i].OpeningBalanceDate;
                    cmdOpeningBalance.ExecuteNonQuery();
                    cmdOpeningBalance.Parameters.Clear();
                }

                dal.InsertTransactions(oelTransactionsCollection, objConn, objTran);

                objTran.Commit();
                InfoResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                objTran.Rollback();
                throw ex;
            }

            return InfoResult;
        }
         //public EntityoperationInfo UpdateOpeningBalance(OpeningBalanceEL oelOpeninBalance, List<TransactionsEL> oelTransactionsCollection,List<StockReceiptEL> oelOpeningStockCollection, SqlConnection objConn)
        //{
        //    EntityoperationInfo InfoResult = new EntityoperationInfo();
        //    SqlTransaction oTran = null;
        //    using (SqlCommand cmdOpeningBalance = new SqlCommand("sp_updateOpeningBalance", objConn))
        //    {
        //        try
        //        {
        //            oTran = objConn.BeginTransaction();
        //            cmdOpeningBalance.Transaction = oTran;
        //            cmdOpeningBalance.CommandType = CommandType.StoredProcedure;
        //            cmdOpeningBalance.Parameters.Add(new SqlParameter("@AccountNo", DbType.Guid)).Value = oelOpeninBalance.AccountNo;
        //            cmdOpeningBalance.Parameters.Add(new SqlParameter("@AccountName", DbType.DateTime)).Value = oelOpeninBalance.AccountName;
        //            cmdOpeningBalance.Parameters.Add(new SqlParameter("@Units", DbType.String)).Value = oelOpeninBalance.Units;
        //            cmdOpeningBalance.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelOpeninBalance.Amount;
        //            cmdOpeningBalance.Parameters.Add(new SqlParameter("@IsCurrent", DbType.Decimal)).Value = oelOpeninBalance.IsCurrent;
        //            cmdOpeningBalance.Parameters.Add(new SqlParameter("@Date", DbType.Boolean)).Value = oelOpeninBalance.OpeningBalanceDate;
        //            cmdOpeningBalance.ExecuteNonQuery();

        //           SqlCommand cmdTransactions = new SqlCommand();
        //           cmdTransactions.CommandType = CommandType.StoredProcedure;
        //           cmdTransactions.Transaction = oTran;
        //           cmdTransactions.Connection = objConn;
        //           for (int i = 0; i < oelTransactionsCollection.Count; i++)
        //           {
        //               //if (oelTransactionsCollection[i].IsNew)
        //               //{
        //               //    cmdTransactions.CommandText = "sp_insertTransactions";
        //               //}
        //               //else
        //               //{
        //                   cmdTransactions.CommandText = "sp_updateTransactions";
        //               //}
        //               cmdTransactions.Parameters.Add(new SqlParameter("@IdTransaction", DbType.Guid)).Value = oelTransactionsCollection[i].TransactionID;
        //               cmdTransactions.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelTransactionsCollection[i].AccountNo;
        //               cmdTransactions.Parameters.Add(new SqlParameter("@Date", DbType.DateTime)).Value = oelTransactionsCollection[i].Date;
        //               cmdTransactions.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelTransactionsCollection[i].Seq;
        //               cmdTransactions.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int32)).Value = oelTransactionsCollection[i].VoucherNo;
        //               cmdTransactions.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelTransactionsCollection[i].Description;
        //               cmdTransactions.Parameters.Add(new SqlParameter("@Debit", DbType.Int64)).Value = oelTransactionsCollection[i].Debit;
        //               cmdTransactions.Parameters.Add(new SqlParameter("@Credit", DbType.Int64)).Value = oelTransactionsCollection[i].Credit;
        //               cmdTransactions.Parameters.Add(new SqlParameter("@Qty", DbType.Int16)).Value = oelTransactionsCollection[i].Qty;
        //               cmdTransactions.Parameters.Add(new SqlParameter("@Type", DbType.String)).Value = oelTransactionsCollection[i].VoucherType;
        //               cmdTransactions.ExecuteNonQuery();
        //               cmdTransactions.Parameters.Clear();
        //           }
        //           if (oelOpeningStockCollection.Count > 0)
        //           {
        //               //SqlCommand cmdStockReceiptDetail = new SqlCommand("sp_updateStockReceipt", objConn);
        //               SqlCommand cmdStockReceiptDetail = new SqlCommand("sp_InsertStockReceipt", objConn);
        //               cmdStockReceiptDetail.CommandType = CommandType.StoredProcedure;
        //               cmdStockReceiptDetail.Transaction = oTran;
        //               for (int j = 0; j < oelOpeningStockCollection.Count; j++)
        //               {
        //                   cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@IdStockReceipt", DbType.Guid)).Value = oelOpeningStockCollection[j].IdStockReceipt;
        //                   cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelOpeningStockCollection[j].IdUser;
        //                   //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelOpeningStockCollection[j].VoucherNo;
        //                   cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@ItemNo", DbType.String)).Value = oelOpeningStockCollection[j].ItemNo;
        //                   cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@units", DbType.Int64)).Value = oelOpeningStockCollection[j].Units;
        //                   //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@RemainingUnits", DbType.Int64)).Value = oelOpeningStockCollection[j].RemainingUnits;
        //                   //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelOpeningStockCollection[j].Amount;
        //                   //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@stockdate", DbType.DateTime)).Value = oelOpeningStockCollection[j].StockDate;
        //                   cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@ActionType", DbType.Int64)).Value = oelOpeningStockCollection[j].ActionType;                           
        //                   cmdStockReceiptDetail.ExecuteNonQuery();
        //                   cmdStockReceiptDetail.Parameters.Clear();
        //               }
        //           }
        //               oTran.Commit();
        //               InfoResult.IsSuccess = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            oTran.Rollback();
        //            throw ex;
        //        }

        //    }

        //    return InfoResult;
        //}
        public EntityoperationInfo UpdateOpeningBalance(List<OpeningBalanceEL> oelOpeningBalanceCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            EntityoperationInfo InfoResult = new EntityoperationInfo();
            SqlTransaction objTran = objConn.BeginTransaction(); ;
            SqlCommand cmdOpeningBalance = new SqlCommand("[Transactions].[Proc_UpdateOpeningBalance]", objConn);
            try
            {

                cmdOpeningBalance.Transaction = objTran;
                for (int i = 0; i < oelOpeningBalanceCollection.Count; i++)
                {
                    if (oelOpeningBalanceCollection[i].IsNew)
                    {
                        cmdOpeningBalance.CommandText = "[Transactions].[Proc_CreateOpeningBalance]";
                    }
                    else
                    {
                        cmdOpeningBalance.CommandText = "[Transactions].[Proc_UpdateOpeningBalance]";
                    }
                    cmdOpeningBalance.CommandType = CommandType.StoredProcedure;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@IdOpeningBalance", DbType.Guid)).Value = oelOpeningBalanceCollection[i].IdOpeningBalance;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelOpeningBalanceCollection[i].IdCompany;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@IdUser", DbType.DateTime)).Value = oelOpeningBalanceCollection[i].UserId;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelOpeningBalanceCollection[i].BookNo;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@AccountNo", DbType.Int64)).Value = oelOpeningBalanceCollection[i].AccountNo;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@EmpCode", DbType.DateTime)).Value = oelOpeningBalanceCollection[i].EmpCode;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelOpeningBalanceCollection[i].Amount;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@Debit", DbType.Decimal)).Value = oelOpeningBalanceCollection[i].Debit;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@Credit", DbType.Decimal)).Value = oelOpeningBalanceCollection[i].Credit;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelOpeningBalanceCollection[i].Discription;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@IsCurrent", DbType.Boolean)).Value = oelOpeningBalanceCollection[i].IsCurrent;
                    cmdOpeningBalance.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelOpeningBalanceCollection[i].OpeningBalanceDate;
                    cmdOpeningBalance.ExecuteNonQuery();
                    cmdOpeningBalance.Parameters.Clear();

                }

                dal.UpdateTransactions(oelTransactionsCollection, objConn, objTran);
                objTran.Commit();
                InfoResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                objTran.Rollback();
                throw ex;
            }
            return InfoResult;
        }
        public List<OpeningBalanceEL> GetOpeningBalance(string AccountNo, string OpeningType, Guid IdCompany, SqlConnection objConn)
        {
            List<OpeningBalanceEL> list = new List<OpeningBalanceEL>();
            using (SqlCommand cmdOpeningBalance = new SqlCommand("[Transactions].[Proc_GetOpeningBalanceAndStock]", objConn))
            {
                cmdOpeningBalance.CommandType = CommandType.StoredProcedure;
                cmdOpeningBalance.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdOpeningBalance.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdOpeningBalance.Parameters.Add("@Type", SqlDbType.NVarChar).Value = OpeningType;
                objReader = cmdOpeningBalance.ExecuteReader();
                while (objReader.Read())
                {
                    OpeningBalanceEL oelOpeningBalance = new OpeningBalanceEL();
                    oelOpeningBalance.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelOpeningBalance.LinkAccountNo = Validation.GetSafeString(objReader["LinkAccountNo"]);
                    oelOpeningBalance.AccountName = objReader["AccountName"].ToString();
                    oelOpeningBalance.Amount = Convert.ToDecimal(objReader["Amount"]);
                    oelOpeningBalance.IdTransaction = new Guid(objReader["transaction_Id"].ToString());
                    oelOpeningBalance.IdHead = Validation.GetSafeInteger(objReader["Head_Id"]);
                    oelOpeningBalance.SettlementType = Validation.GetSafeString(objReader["SettlementType"]);
                    oelOpeningBalance.Description = Validation.GetSafeString(objReader["Description"]);
                    list.Add(oelOpeningBalance);
                }
            }
            return list;
        }
        public List<OpeningBalanceEL> GetOpeningBalancesByType(string OpeningType, Guid IdCompany, SqlConnection objConn)
        {
            List<OpeningBalanceEL> list = new List<OpeningBalanceEL>();
            using (SqlCommand cmdOpeningBalance = new SqlCommand("[Transactions].[proc_GetOpeningBalancesByType]", objConn))
            {
                cmdOpeningBalance.CommandType = CommandType.StoredProcedure;
                cmdOpeningBalance.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdOpeningBalance.Parameters.Add("@Type", SqlDbType.NVarChar).Value = OpeningType;
                objReader = cmdOpeningBalance.ExecuteReader();
                while (objReader.Read())
                {
                    OpeningBalanceEL oelOpeningBalance = new OpeningBalanceEL();
                    oelOpeningBalance.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelOpeningBalance.AccountName = objReader["AccountName"].ToString();
                    oelOpeningBalance.Amount = Convert.ToDecimal(objReader["Amount"]);
                    oelOpeningBalance.Description = Validation.GetSafeString(objReader["Description"]);
                    list.Add(oelOpeningBalance);
                }
            }
            return list;
        }
        public EntityoperationInfo DeleteOpeningBalance(Int64 AccountNo, Guid IdTransaction, Guid IdCompany, SqlConnection objConn)
        {
            EntityoperationInfo DeleteInfo = new EntityoperationInfo();
            int rowseffected = -1;
            using (SqlTransaction oTran = objConn.BeginTransaction())
            {
                SqlCommand cmdDelete = new SqlCommand("[Transactions].[Proc_deleteOpeningBalance]", objConn);
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.Transaction = oTran;
                cmdDelete.Parameters.Add("@IdTransaction", SqlDbType.UniqueIdentifier).Value = IdTransaction;
                cmdDelete.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdDelete.Parameters.Add("@AccountNo", SqlDbType.BigInt).Value = AccountNo;

                rowseffected = cmdDelete.ExecuteNonQuery();

                if (rowseffected > -1)
                {
                    oTran.Commit();
                    DeleteInfo.IsSuccess = true;
                }
                else
                {
                    oTran.Rollback();
                    DeleteInfo.IsSuccess = false;
                }
            }
            return DeleteInfo;
        }
    }
}
