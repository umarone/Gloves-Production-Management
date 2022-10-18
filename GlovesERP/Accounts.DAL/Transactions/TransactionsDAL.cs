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
    public class TransactionsDAL
    {

        IDataReader objReader;
        public static bool InsertTransactions(TransactionsEL oelTransactions, SqlConnection oConn)
        {
            using (SqlCommand cmdTransactions = new SqlCommand("sp_insertTransactions", oConn))
            {
                cmdTransactions.CommandType = CommandType.StoredProcedure;
                cmdTransactions.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelTransactions.AccountNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelTransactions.SubAccountNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@Date", DbType.DateTime)).Value = oelTransactions.VDate;
                cmdTransactions.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelTransactions.Seq;
                cmdTransactions.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelTransactions.VoucherNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelTransactions.Discription;
                cmdTransactions.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelTransactions.Amount;
                cmdTransactions.Parameters.Add(new SqlParameter("@Qty", DbType.Decimal)).Value = oelTransactions.Qty;
                cmdTransactions.Parameters.Add(new SqlParameter("@Type", DbType.String)).Value = oelTransactions.VoucherType;
                //cmdTransactions.Parameters.Add(new SqlParameter("@Posted", DbType.String)).Value = oelTransactions.Posted;
                cmdTransactions.ExecuteNonQuery();
                return true;

            }
        }
        public void InsertTransactions(List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdTransactions = new SqlCommand("[Transactions].[Proc_CreateTransactions]", objConn);
            cmdTransactions.CommandType = CommandType.StoredProcedure;
            cmdTransactions.Transaction = objTran;
            for (int i = 0; i < oelTransactionsCollection.Count; i++)
            {
                cmdTransactions.Parameters.Add(new SqlParameter("@IdTransaction", DbType.Guid)).Value = oelTransactionsCollection[i].TransactionID;
                cmdTransactions.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelTransactionsCollection[i].IdCompany;
                cmdTransactions.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelTransactionsCollection[i].IdVoucher;
                cmdTransactions.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelTransactionsCollection[i].IdUser;
                cmdTransactions.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelTransactionsCollection[i].BookNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelTransactionsCollection[i].AccountNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelTransactionsCollection[i].LinkAccountNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelTransactionsCollection[i].SubAccountNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelTransactionsCollection[i].VDate;
                cmdTransactions.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelTransactionsCollection[i].Seq;
                cmdTransactions.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelTransactionsCollection[i].VoucherNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelTransactionsCollection[i].VDiscription;
                cmdTransactions.Parameters.Add(new SqlParameter("@ClosingBalance", DbType.Decimal)).Value = oelTransactionsCollection[i].ClosingBalance;
                cmdTransactions.Parameters.Add(new SqlParameter("@Debit", DbType.Decimal)).Value = oelTransactionsCollection[i].Debit;
                cmdTransactions.Parameters.Add(new SqlParameter("@Credit", DbType.Decimal)).Value = oelTransactionsCollection[i].Credit;
                cmdTransactions.Parameters.Add(new SqlParameter("@TransactionType", DbType.String)).Value = oelTransactionsCollection[i].TransactionType;
                cmdTransactions.Parameters.Add(new SqlParameter("@VType", DbType.String)).Value = oelTransactionsCollection[i].VoucherType;
                cmdTransactions.Parameters.Add(new SqlParameter("@SettlementType", DbType.String)).Value = oelTransactionsCollection[i].SettlementType;
                cmdTransactions.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelTransactionsCollection[i].Posted;

                cmdTransactions.ExecuteNonQuery();
                cmdTransactions.Parameters.Clear();
            }
        }
        public void UpdateTransactions(List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdTransactions = new SqlCommand();
            cmdTransactions.CommandType = CommandType.StoredProcedure;
            cmdTransactions.Transaction = objTran;
            cmdTransactions.Connection = objConn;
            for (int i = 0; i < oelTransactionsCollection.Count; i++)
            {
                if (oelTransactionsCollection[i].IsNew)
                {
                    cmdTransactions.CommandText = "[Transactions].[Proc_CreateTransactions]";
                }
                else
                {
                    cmdTransactions.CommandText = "[Transactions].[Proc_UpdateTransactions]";
                }
                cmdTransactions.Parameters.Add(new SqlParameter("@IdTransaction", DbType.Guid)).Value = oelTransactionsCollection[i].TransactionID;
                cmdTransactions.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelTransactionsCollection[i].IdCompany;
                cmdTransactions.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelTransactionsCollection[i].IdVoucher;
                cmdTransactions.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelTransactionsCollection[i].IdUser;
                cmdTransactions.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelTransactionsCollection[i].BookNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelTransactionsCollection[i].AccountNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelTransactionsCollection[i].LinkAccountNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelTransactionsCollection[i].SubAccountNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelTransactionsCollection[i].VDate;
                cmdTransactions.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelTransactionsCollection[i].Seq;
                cmdTransactions.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelTransactionsCollection[i].VoucherNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelTransactionsCollection[i].VDiscription;
                cmdTransactions.Parameters.Add(new SqlParameter("@ClosingBalance", DbType.Decimal)).Value = oelTransactionsCollection[i].ClosingBalance;
                cmdTransactions.Parameters.Add(new SqlParameter("@Debit", DbType.Decimal)).Value = oelTransactionsCollection[i].Debit;
                cmdTransactions.Parameters.Add(new SqlParameter("@Credit", DbType.Decimal)).Value = oelTransactionsCollection[i].Credit;
                cmdTransactions.Parameters.Add(new SqlParameter("@TransactionType", DbType.String)).Value = oelTransactionsCollection[i].TransactionType;
                cmdTransactions.Parameters.Add(new SqlParameter("@VType", DbType.String)).Value = oelTransactionsCollection[i].VoucherType;
                cmdTransactions.Parameters.Add(new SqlParameter("@SettlementType", DbType.String)).Value = oelTransactionsCollection[i].SettlementType;
                cmdTransactions.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelTransactionsCollection[i].Posted;

                cmdTransactions.ExecuteNonQuery();
                cmdTransactions.Parameters.Clear();
            }
        }
        public bool AuthorizeDayBook(List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            SqlTransaction objTran = objConn.BeginTransaction();
            SqlCommand cmdTransactions = new SqlCommand();
            cmdTransactions.CommandType = CommandType.StoredProcedure;
            cmdTransactions.Transaction = objTran;
            cmdTransactions.Connection = objConn;
            for (int i = 0; i < oelTransactionsCollection.Count; i++)
            {
                cmdTransactions.CommandText = "[Transactions].[Pro_AuthorizeDayBook]";
                
                cmdTransactions.Parameters.Add(new SqlParameter("@IdTransaction", DbType.Guid)).Value = oelTransactionsCollection[i].TransactionID;
                cmdTransactions.ExecuteNonQuery();
                cmdTransactions.Parameters.Clear();
            }
            objTran.Commit();
            return true;
        }
        public static bool UpdateTransactions(TransactionsEL oelTransactions, SqlConnection oConn)
        {
            using (SqlCommand cmdTransactions = new SqlCommand("sp_updateTransactions", oConn))
            {
                cmdTransactions.CommandType = CommandType.StoredProcedure;
                cmdTransactions.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelTransactions.AccountNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@Date", DbType.DateTime)).Value = oelTransactions.Date;
                cmdTransactions.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelTransactions.Seq;
                cmdTransactions.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelTransactions.VoucherNo;
                cmdTransactions.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelTransactions.Description;
                cmdTransactions.Parameters.Add(new SqlParameter("@Ammount", DbType.Decimal)).Value = oelTransactions.Amount;
                cmdTransactions.Parameters.Add(new SqlParameter("@Qty", DbType.Decimal)).Value = oelTransactions.Qty;
                cmdTransactions.Parameters.Add(new SqlParameter("@Type", DbType.String)).Value = oelTransactions.VoucherType;
                cmdTransactions.Parameters.Add(new SqlParameter("@Posted", DbType.String)).Value = oelTransactions.Posted;
                cmdTransactions.ExecuteNonQuery();
                return true;

            }
        }
        public bool DeleteTransactions(Guid IdVoucher, string TransactionType, Guid IdCompany, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdDeleteTransaction = new SqlCommand("[Transactions].[Proc_DeleteTransaction]", objConn, objTran);
            cmdDeleteTransaction.CommandType = CommandType.StoredProcedure;
          
            cmdDeleteTransaction.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
            cmdDeleteTransaction.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
            cmdDeleteTransaction.Parameters.Add("@TransactionType", SqlDbType.VarChar).Value = TransactionType;
            cmdDeleteTransaction.ExecuteNonQuery();

            //cmdDeleteTransaction.ExecuteNonQuery();
            
            return true;
        }
        public List<TransactionsEL> GetAccountLedger(string AccountNo, Guid IdCompany, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdAccountLedger = new SqlCommand("[Reports].[Proc_GetLedger]", objConn))
            {
                cmdAccountLedger.CommandType = CommandType.StoredProcedure;
                cmdAccountLedger.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdAccountLedger.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                objReader = cmdAccountLedger.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.TransactionID = new Guid(objReader["Transaction_Id"].ToString());
                    oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                    oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);
                    oelTransaction.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.IdHead = Validation.GetSafeInteger(objReader["Head_Id"]);
                    oelTransaction.VoucherType = Validation.GetSafeString(objReader["VType"]);
                    oelTransaction.TransactionType = Validation.GetSafeString(objReader["TransactionType"]);
                    oelTransaction.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelTransaction.Description = Validation.GetSafeString(objReader["VDiscription"]);
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetControlAccountLedger(string AccountNo, Guid IdCompany, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdAccountLedger = new SqlCommand("[Reports].[Proc_GetControlAccountLedger]", objConn))
            {
                cmdAccountLedger.CommandType = CommandType.StoredProcedure;
                cmdAccountLedger.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdAccountLedger.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                objReader = cmdAccountLedger.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.TransactionID = Validation.GetSafeGuid(objReader["Transaction_Id"].ToString());
                    oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                    oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);
                    oelTransaction.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelTransaction.IdHead = Validation.GetSafeInteger(objReader["Head_Id"]);
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.VoucherType = Validation.GetSafeString(objReader["VType"]);
                    oelTransaction.TransactionType = Validation.GetSafeString(objReader["TransactionType"]);
                    oelTransaction.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelTransaction.Description = Validation.GetSafeString(objReader["VDiscription"]);
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetControlAccountsDateWiseLedger(string AccountNo, DateTime StartPeriod, DateTime ToPeriod, Guid IdCompany, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdAccountLedger = new SqlCommand("[Reports].[Proc_GetControlAccountDateWiseLedger]", objConn))
            {
                cmdAccountLedger.CommandType = CommandType.StoredProcedure;
                cmdAccountLedger.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdAccountLedger.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdAccountLedger.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartPeriod;
                cmdAccountLedger.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = ToPeriod;
                objReader = cmdAccountLedger.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    //oelTransaction.TransactionID = new Guid(objReader["Transaction_Id"].ToString());
                    oelTransaction.OpeningBalance = Validation.GetSafeLong(objReader["Opening"]);
                    oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                    oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);
                    oelTransaction.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelTransaction.IdHead = Validation.GetSafeInteger(objReader["Head_Id"]);
                    oelTransaction.VoucherType = Validation.GetSafeString(objReader["VType"]);
                    oelTransaction.TransactionType = Validation.GetSafeString(objReader["TransactionType"]);
                    oelTransaction.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelTransaction.Description = Validation.GetSafeString(objReader["VDiscription"]);
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetAccountsDateWiseLedger(string AccountNo, DateTime StartPeriod, DateTime ToPeriod, Guid IdCompany, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdAccountLedger = new SqlCommand("[Reports].[Proc_GetDateWiseLedger]", objConn))
            {
                cmdAccountLedger.CommandType = CommandType.StoredProcedure;
                cmdAccountLedger.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdAccountLedger.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdAccountLedger.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartPeriod;
                cmdAccountLedger.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = ToPeriod;
                objReader = cmdAccountLedger.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    //oelTransaction.TransactionID = new Guid(objReader["Transaction_Id"].ToString());
                    oelTransaction.OpeningBalance = Validation.GetSafeLong(objReader["Opening"]);
                    oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                    oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);
                    oelTransaction.VoucherNo = Convert.ToInt64(objReader["VoucherNo"]);
                    //oelTransaction.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
                    oelTransaction.IdHead = Validation.GetSafeInteger(objReader["Head_Id"]);
                    oelTransaction.VoucherType = Validation.GetSafeString(objReader["VType"]);
                    oelTransaction.TransactionType = Validation.GetSafeString(objReader["TransactionType"]);
                    oelTransaction.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelTransaction.Description = Validation.GetSafeString(objReader["VDiscription"]);
                    list.Add(oelTransaction);
                }
            }
            return list;
        }

        public DataTable GetLedgerByAccount(string AccountNo, Guid IdProject, Int64 BookNo, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdAccountLedger = new SqlCommand("[Reports].[Proc_GetLedger]", objConn))
            {
                cmdAccountLedger.CommandType = CommandType.StoredProcedure;
                cmdAccountLedger.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdAccountLedger.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdProject;
                //cmdAccountLedger.Parameters.Add("@BookNo", SqlDbType.BigInt).Value = BookNo;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmdAccountLedger);
                da.Fill(dt);
                return dt;
                //objReader = cmdAccountLedger.ExecuteReader();
                //while (objReader.Read())
                //{
                //    TransactionsEL oelTransaction = new TransactionsEL();
                //    oelTransaction.TransactionID = Validation.GetSafeLong(objReader["VoucherDetail_Id"]);
                //    oelTransaction.Discription = Validation.GetSafeString(objReader["Narration"]);
                //    oelTransaction.VDate = Validation.GetSafeDateTime(objReader["VDate"]);
                //    oelTransaction.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                //    oelTransaction.VoucherType = Validation.GetSafeString(objReader["LedgerVoucherNo"]);
                //    oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                //    oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);
                //    oelTransaction.Balance = Validation.GetSafeDecimal(objReader["RunningBalance"]);
                //    oelTransaction.TransactionMode = Validation.GetSafeString(objReader["BType"]);
                //    oelTransaction.ClosingBalance = Validation.GetSafeDecimal(objReader["ClosingBalance"]);
                //    oelTransaction.BalanceType = Validation.GetSafeString(objReader["FinalBalanceType"]);


                //    list.Add(oelTransaction);
                //}
            }
            //return list;
        }
        //public List<TransactionsEL> GetDateWiseLedgerByAccount(string AccountNo, Int64 IdProject, Int64 BookNo, DateTime StartPeriod, DateTime ToPeriod, SqlConnection objConn)
        public DataTable GetDateWiseLedgerByAccount(string AccountNo, Guid IdProject, Int64 BookNo, DateTime StartPeriod, DateTime ToPeriod, SqlConnection objConn)
        {
            //List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdAccountLedger = new SqlCommand("[Reports].[Proc_GetDateWiseLedger]", objConn))
            {
                cmdAccountLedger.CommandType = CommandType.StoredProcedure;
                cmdAccountLedger.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdAccountLedger.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdProject;
                //cmdAccountLedger.Parameters.Add("@BookNo", SqlDbType.BigInt).Value = BookNo;
                cmdAccountLedger.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartPeriod;
                cmdAccountLedger.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = ToPeriod;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmdAccountLedger);
                da.Fill(dt);
                return dt;
                //    objReader = cmdAccountLedger.ExecuteReader();
                //    while (objReader.Read())
                //    {
                //        TransactionsEL oelTransaction = new TransactionsEL();
                //        oelTransaction.Discription = Validation.GetSafeString(objReader["Narration"]);
                //        oelTransaction.VDate = Validation.GetSafeDateTime(objReader["VDate"]);
                //        oelTransaction.VoucherType = Validation.GetSafeString(objReader["LedgerVoucherNo"]);
                //        oelTransaction.OpeningBalance = Validation.GetSafeDecimal(objReader["Opening"]);
                //        oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                //        oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);
                //        oelTransaction.Balance = Validation.GetSafeDecimal(objReader["RunningBalance"]);
                //        oelTransaction.TransactionMode = Validation.GetSafeString(objReader["BType"]);
                //        oelTransaction.ClosingBalance = Validation.GetSafeDecimal(objReader["ClosingBalance"]);
                //        oelTransaction.BalanceType = Validation.GetSafeString(objReader["FinalBalanceType"]);
                //        list.Add(oelTransaction);
                //    }
            }
            //return list;
        }
        public List<TransactionsEL> GetAccountsBalance(string AccountType, Guid IdCompany, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdAccountsBalance = new SqlCommand("[Transactions].[rpt_GetAccountsBalance]", objConn))
            {
                cmdAccountsBalance.CommandType = CommandType.StoredProcedure;
                cmdAccountsBalance.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdAccountsBalance.Parameters.Add("@AccountType", SqlDbType.VarChar).Value = AccountType;
                //cmdAccountsBalance.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                //cmdAccountsBalance.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdAccountsBalance.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    //oelTransaction.TransactionID = new Guid(objReader["Transaction_Id"].ToString());
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.AccountName = objReader["AccountName"].ToString();
                    oelTransaction.AccountType = objReader["AccountType"].ToString();
                    if (AccountType != "Stock")
                    {
                        if (objReader["Debit"] != DBNull.Value)
                        {
                            oelTransaction.Debit = Convert.ToDecimal(objReader["Debit"]);
                        }
                        else
                        {
                            oelTransaction.Debit = 0;
                        }
                        if (objReader["Credit"] != DBNull.Value)
                        {
                            oelTransaction.Credit = Convert.ToDecimal(objReader["Credit"]);
                        }
                        else
                        {
                            oelTransaction.Credit = 0;
                        }
                    }
                    else
                    {
                        //oelTransaction.VoucherNo = Convert.ToInt64(objReader["VoucherNo"]);
                        oelTransaction.Qty = Convert.ToInt32(objReader["qty"]);
                        //oelTransaction.VoucherType = objReader["Type"].ToString();
                        //oelTransaction.Date = Convert.ToDateTime(objReader["Date"]);
                        //oelTransaction.Description = objReader["Description"].ToString();
                    }
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetDateWiseAccountsBalance(string AccountType, DateTime StartDate, DateTime EndDate, Guid IdCompany, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdAccountsBalance = new SqlCommand("[Transactions].[rpt_GetDateWiseAccountsBalance]", objConn))
            {
                cmdAccountsBalance.CommandType = CommandType.StoredProcedure;
                cmdAccountsBalance.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdAccountsBalance.Parameters.Add("@AccountType", SqlDbType.VarChar).Value = AccountType;
                cmdAccountsBalance.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdAccountsBalance.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdAccountsBalance.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    //oelTransaction.TransactionID = new Guid(objReader["Transaction_Id"].ToString());
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.AccountName = objReader["AccountName"].ToString();
                    oelTransaction.AccountType = objReader["AccountType"].ToString();
                    if (AccountType != "Stock")
                    {
                        if (objReader["Debit"] != DBNull.Value)
                        {
                            oelTransaction.Debit = Convert.ToDecimal(objReader["Debit"]);
                        }
                        else
                        {
                            oelTransaction.Debit = 0;
                        }
                        if (objReader["Credit"] != DBNull.Value)
                        {
                            oelTransaction.Credit = Convert.ToDecimal(objReader["Credit"]);
                        }
                        else
                        {
                            oelTransaction.Credit = 0;
                        }
                    }
                    else
                    {
                        //oelTransaction.VoucherNo = Convert.ToInt64(objReader["VoucherNo"]);
                        oelTransaction.Qty = Convert.ToInt32(objReader["qty"]);
                        //oelTransaction.VoucherType = objReader["Type"].ToString();
                        //oelTransaction.Date = Convert.ToDateTime(objReader["Date"]);
                        //oelTransaction.Description = objReader["Description"].ToString();
                    }
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public Int64 GetItemCount(string AccountNo, Int64 VoucherNo, string TransactionType, SqlConnection objconn)
        {
            SqlCommand cmdItemCount = new SqlCommand("sp_GetItemCount", objconn);
            cmdItemCount.CommandType = CommandType.StoredProcedure;
            cmdItemCount.Parameters.Add("@VoucherNo", SqlDbType.NVarChar).Value = VoucherNo;
            cmdItemCount.Parameters.Add("@AccountNo", SqlDbType.NVarChar).Value = AccountNo;
            cmdItemCount.Parameters.Add("@TransactionType", SqlDbType.NVarChar).Value = TransactionType;
            return Convert.ToInt64(cmdItemCount.ExecuteScalar());

        }
        public List<TransactionsEL> GetAccountInTransaction(String AccountNo, SqlConnection objConn)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            using (SqlCommand cmdTransaction = new SqlCommand("sp_CheckAccountInTransaction", objConn))
            {
                try
                {
                    cmdTransaction.CommandType = CommandType.StoredProcedure;
                    cmdTransaction.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                    objReader = cmdTransaction.ExecuteReader();
                    while (objReader.Read())
                    {
                        TransactionsEL obj = new TransactionsEL();
                        obj.TransactionID = new Guid(objReader["Transaction_Id"].ToString());
                        obj.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);

                        oelTransactionCollection.Add(obj);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return oelTransactionCollection;
        }
        public List<TransactionsEL> ListDailySale(DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdDailySale = new SqlCommand("sp_GetDailySale", objConn))
            {
                cmdDailySale.CommandType = CommandType.StoredProcedure;
                cmdDailySale.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdDailySale.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdDailySale.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL obj = new TransactionsEL();
                    obj.VoucherNo = Convert.ToInt64(objReader["VoucherNo"]);
                    obj.Debit = Convert.ToInt64(objReader["Sale"]);
                    obj.Credit = Convert.ToInt64(objReader["CostOfGoods"]);
                    obj.Amount = Convert.ToInt64(objReader["Profit"]);

                    list.Add(obj);
                }
            }

            return list;
        }
        public List<TransactionsEL> ListExpenses(DateTime StartDate, DateTime EndDate, Guid IdCompany, SqlConnection objConn)
        {

            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdExpenses = new SqlCommand("[Transactions].[Proc_GetExpensesDetail]", objConn))
            {
                cmdExpenses.CommandType = CommandType.StoredProcedure;
                //cmdExpenses.Parameters.Add("@AccountNo", SqlDbType.NVarChar).Value = AccountNo;
                cmdExpenses.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdExpenses.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdExpenses.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdExpenses.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL obj = new TransactionsEL();
                    obj.AccountName = objReader["AccountName"].ToString();
                    obj.VoucherNo = Convert.ToInt64(objReader["VoucherNo"]);
                    obj.Debit = Convert.ToInt64(objReader["Debit"]);
                    obj.Description = Validation.GetSafeString(objReader["Description"]);
                    //obj.Credit = Validation.GetSafeInteger(objReader["Credit"]);
                    //obj.TransactionType = Validation.GetSafeString(objReader["TransactionType"]);
                    obj.Date = Convert.ToDateTime(objReader["VDate"]);
                    list.Add(obj);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetHeadAccountTransactionId(Int64 VoucherNo, string VoucherType, string AccountNo, Guid IdCompany, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdTransaction = new SqlCommand("[Transactions].[Proc_GetHeadAccountTransactionId]", objConn))
            {
                cmdTransaction.CommandType = CommandType.StoredProcedure;
                cmdTransaction.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdTransaction.Parameters.Add("@VoucherNo", SqlDbType.BigInt).Value = VoucherNo;
                cmdTransaction.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdTransaction.Parameters.Add("@VoucherType", SqlDbType.VarChar).Value = VoucherType;
                objReader = cmdTransaction.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.TransactionID = Validation.GetSafeGuid(objReader["transaction_id"]);
                    oelTransaction.Date = Convert.ToDateTime(objReader["Vdate"]);
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetDateWiseTrialBalance(DateTime StartPeriod, DateTime ToPeriod, Guid IdComapny, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdDateWiseTrial = new SqlCommand("[Transactions].[Proc_GetDateWiseTrialBalance]", objConn))
            {
                cmdDateWiseTrial.CommandType = CommandType.StoredProcedure;
                cmdDateWiseTrial.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdComapny;
                cmdDateWiseTrial.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartPeriod;
                cmdDateWiseTrial.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = ToPeriod;
                objReader = cmdDateWiseTrial.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelTransaction.OpeningBalance = Validation.GetSafeDecimal(objReader["OpeningBalance"]);
                    oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                    oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);

                    list.Add(oelTransaction);
                }
            }
            return list;
        }       
        public List<TransactionsEL> GetTrialBalance(Guid IdCompany, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdTrial = new SqlCommand("[Transactions].[Proc_GetTrialBalance]", objConn))
            {
                cmdTrial.CommandType = CommandType.StoredProcedure;
                cmdTrial.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                objReader = cmdTrial.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                    oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);

                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetMiniTrialBalance(Guid IdCompany, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdTrial = new SqlCommand("[Transactions].[Proc_GetMiniTrialBalance]", objConn))
            {
                cmdTrial.CommandType = CommandType.StoredProcedure;
                cmdTrial.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                objReader = cmdTrial.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                    oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);
                    oelTransaction.ClosingBalance = oelTransaction.Debit - oelTransaction.Credit;
                    oelTransaction.VoucherType = Validation.GetSafeString(objReader["VType"]);

                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetDateWiseMiniTrialBalance(Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdTrial = new SqlCommand("[Transactions].[Proc_GetDateWiseMiniTrialBalance]", objConn))
            {
                cmdTrial.CommandType = CommandType.StoredProcedure;
                cmdTrial.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdTrial.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdTrial.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdTrial.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    //oelTransaction.OpeningBalance = Validation.GetSafeDecimal(objReader["OpeningBalance"]);
                    oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                    oelTransaction.OpeningBalance = Validation.GetSafeDecimal(objReader["OpeningDebit"]);
                    oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);
                    oelTransaction.Amount = Validation.GetSafeDecimal(objReader["OpeningCredit"]);
                    oelTransaction.ClosingBalance = (oelTransaction.Debit + oelTransaction.OpeningBalance) - (oelTransaction.Credit + oelTransaction.Amount);
                    oelTransaction.VoucherType = Validation.GetSafeString(objReader["VType"]);

                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetEmployeesTransactions(Guid IdCompany, string EmpCode, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdSalesMan = new SqlCommand("[Transactions].[Proc_GetEmployeesTransactions]", objConn))
            {
                cmdSalesMan.CommandType = CommandType.StoredProcedure;
                
                cmdSalesMan.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSalesMan.Parameters.Add("@EmpCode", SqlDbType.VarChar).Value = EmpCode;

                objReader = cmdSalesMan.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelTransaction.TotalSales = Validation.GetSafeLong(objReader["TotalSales"]);
                    oelTransaction.TotalRecieveables = Validation.GetSafeLong(objReader["Receivables"]);
                    oelTransaction.TotalRecieved = Validation.GetSafeLong(objReader["TotalRecieved"]);
                    oelTransaction.TotalReturns = Validation.GetSafeLong(objReader["TotalReturns"]);
                    oelTransaction.TotalPayables = Validation.GetSafeLong(objReader["ReturnAmount"]);
                    oelTransaction.OpeningBalance = Validation.GetSafeLong(objReader["OpeningBalance"]);
                    oelTransaction.ClosingBalance = Validation.GetSafeLong(objReader["Closing"]);

                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetDateWiseEmployeesTransactions(Guid IdCompany, string EmpCode, DateTime startDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdSalesMan = new SqlCommand("[Transactions].[Proc_GetDateWiseEmployeesTransactions]", objConn))
            {
                cmdSalesMan.CommandType = CommandType.StoredProcedure;

                cmdSalesMan.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSalesMan.Parameters.Add("@EmpCode", SqlDbType.VarChar).Value = EmpCode;
                cmdSalesMan.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                cmdSalesMan.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;

                objReader = cmdSalesMan.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelTransaction.OpeningBalance = Validation.GetSafeLong(objReader["Opening"]);
                    oelTransaction.TotalSales = Validation.GetSafeLong(objReader["TotalSales"]);
                    oelTransaction.TotalRecieveables = Validation.GetSafeLong(objReader["Receivables"]);
                    oelTransaction.TotalRecieved = Validation.GetSafeLong(objReader["TotalRecieved"]);
                    oelTransaction.TotalReturns = Validation.GetSafeLong(objReader["TotalReturns"]);
                    oelTransaction.TotalPayables = Validation.GetSafeLong(objReader["ReturnAmount"]);
                    oelTransaction.ClosingBalance = (oelTransaction.OpeningBalance + oelTransaction.TotalRecieveables) - (oelTransaction.TotalRecieved - oelTransaction.TotalPayables); 

                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetCustomerRecoveryReport(string AccountNo, Guid IdCompany, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdReoveryReport = new SqlCommand("[Transactions].[Proc_GetCustomerRecoveryReport]", objConn))
            {
                cmdReoveryReport.CommandType = CommandType.StoredProcedure;
                cmdReoveryReport.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdReoveryReport.Parameters.Add("@AccountNo", SqlDbType.BigInt).Value = AccountNo;
                objReader = cmdReoveryReport.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelTransaction.Credit = Convert.ToDecimal(objReader["Credit"]);
                    oelTransaction.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelTransaction.Description = objReader["Description"].ToString();
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetCustomerRecoveryReportByDate(string AccountNo,DateTime StartDate,DateTime EndDate, Guid IdCompany, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdRecoveryReport = new SqlCommand("[Transactions].[Proc_GetCustomerRecoveryReportByDate]", objConn))
            {
                cmdRecoveryReport.CommandType = CommandType.StoredProcedure;
                cmdRecoveryReport.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdRecoveryReport.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdRecoveryReport.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdRecoveryReport.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdRecoveryReport.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelTransaction.Credit = Convert.ToDecimal(objReader["Credit"]);
                    oelTransaction.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelTransaction.Description = objReader["Description"].ToString();
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetAllCustomersRecoveryReport(Guid IdCompany, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdReoveryReport = new SqlCommand("[Transactions].[Proc_GetAllCustomersRecoveryReport]", objConn))
            {
                cmdReoveryReport.CommandType = CommandType.StoredProcedure;
                cmdReoveryReport.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                objReader = cmdReoveryReport.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelTransaction.Credit = Convert.ToDecimal(objReader["Credit"]);
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetAllCustomersByRecoveryReportByDate(Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdRecoveryReport = new SqlCommand("[Transactions].[Proc_GetAllCustomersRecoveryReportByDate]", objConn))
            {
                cmdRecoveryReport.CommandType = CommandType.StoredProcedure;
                cmdRecoveryReport.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdRecoveryReport.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdRecoveryReport.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdRecoveryReport.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelTransaction.Credit = Convert.ToDecimal(objReader["Credit"]);
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetDateWiseEmployeesLoans(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdRecoveryReport = new SqlCommand("[Reports].[Proc_GetDateWiseEmployeesLoans]", objConn))
            {
                cmdRecoveryReport.CommandType = CommandType.StoredProcedure;
                cmdRecoveryReport.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdRecoveryReport.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdRecoveryReport.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdRecoveryReport.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdRecoveryReport.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.Date = Convert.ToDateTime(objReader["VDate"]);
                    //oelTransaction.Description = Validation.GetSafeString(objReader["Description"]);
                    oelTransaction.Balance = Convert.ToDecimal(objReader["Balance"]);
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetDateWiseEmployeesAdvances(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdRecoveryReport = new SqlCommand("[Reports].[Proc_GetDateWiseEmployeesAdvances]", objConn))
            {
                cmdRecoveryReport.CommandType = CommandType.StoredProcedure;
                cmdRecoveryReport.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdRecoveryReport.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdRecoveryReport.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdRecoveryReport.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdRecoveryReport.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelTransaction.Description = Validation.GetSafeString(objReader["Description"]);
                    oelTransaction.Balance = Convert.ToDecimal(objReader["Balance"]);
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetDateWiseEmployeesPaymentDetail(Guid IdCompany, string AccountNo, string WorkType, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdRecoveryReport = new SqlCommand("[Reports].[Proc_GetDateWiseEmployeesPaymentReport]", objConn))
            {
                cmdRecoveryReport.CommandType = CommandType.StoredProcedure;
                cmdRecoveryReport.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdRecoveryReport.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdRecoveryReport.Parameters.Add("@WorkType", SqlDbType.VarChar).Value = WorkType;
                cmdRecoveryReport.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdRecoveryReport.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdRecoveryReport.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.Description = Validation.GetSafeString(objReader["Description"]);
                    oelTransaction.Balance = Validation.GetSafeDecimal(objReader["Balance"]);
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetDayBookDetail(Guid IdCompany, DateTime BookDate, SqlConnection objConn)
        {

            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdExpenses = new SqlCommand("[Transactions].[Proc_GetDayBookDetail]", objConn))
            {
                cmdExpenses.CommandType = CommandType.StoredProcedure;
                //cmdExpenses.Parameters.Add("@AccountNo", SqlDbType.NVarChar).Value = AccountNo;
                cmdExpenses.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdExpenses.Parameters.Add("@VDate", SqlDbType.DateTime).Value = BookDate;
                objReader = cmdExpenses.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL obj = new TransactionsEL();
                    obj.TransactionID = Validation.GetSafeGuid(objReader["Transaction_Id"]);
                    obj.AccountName =  Validation.GetSafeString(objReader["AccountName"]);
                    obj.AccountType = Validation.GetSafeString(objReader["AccountType"]);
                    obj.IdHead = Validation.GetSafeInteger(objReader["Head_Id"]);
                    obj.DayBook = Validation.GetSafeString(objReader["BookType"]);
                    obj.Description = Validation.GetSafeString(objReader["Description"]);
                    obj.VoucherType = Validation.GetSafeString(objReader["VType"]);
                    obj.Debit = Validation.GetSafeLong(objReader["Debit"]);
                    obj.Credit = Validation.GetSafeLong(objReader["Credit"]);
                    obj.IsAuthorized = Convert.ToBoolean(objReader["IsAuthorized"]);
                    list.Add(obj);
                }
            }
            return list;
        }
        public decimal GetAccountClosingBalance(String AccountNo, Guid IdCompany, SqlConnection objConn)
        {
            using (SqlCommand cmdTransaction = new SqlCommand("[Transactions].[Proc_GetAccountClosingBalance]", objConn))
            {
                try
                {
                    cmdTransaction.CommandType = CommandType.StoredProcedure;
                    cmdTransaction.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                    cmdTransaction.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                    return Validation.GetSafeDecimal(cmdTransaction.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public List<TransactionsEL> GetDateWiseTransactionsByAccount(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdTransactions = new SqlCommand("[Transactions].[Proc_GetDateWiseTransactionsByAccount]", objConn))
            {
                cmdTransactions.CommandType = CommandType.StoredProcedure;
                cmdTransactions.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdTransactions.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdTransactions.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdTransactions.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdTransactions.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.Date = Convert.ToDateTime(objReader["VDate"]); 
                    oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]); 
                    oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);
                    oelTransaction.SettlementType = Validation.GetSafeString(objReader["SettlementType"]);
                    oelTransaction.VoucherType = Validation.GetSafeString(objReader["VType"]);

                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetDateWiseDepartmentTransactions(Guid IdCompany, Guid IdDepartment, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdTransactions = new SqlCommand("[Transactions].[Proc_GetDateWiseDepartmentTransactions]", objConn))
            {
                cmdTransactions.CommandType = CommandType.StoredProcedure;
                cmdTransactions.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdTransactions.Parameters.Add("@IdDepartment", SqlDbType.UniqueIdentifier).Value = IdDepartment;
                cmdTransactions.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdTransactions.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdTransactions.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                    oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);

                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetTanneryBusinessFinanceAnalysis(DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdTransactions = new SqlCommand("[Transactions].[Pro_GetTanneryBusinessFinanceAnalysis]", objConn))
            {
                cmdTransactions.CommandType = CommandType.StoredProcedure;
                cmdTransactions.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdTransactions.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdTransactions.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["Narration"]);
                    oelTransaction.TransactionType = Validation.GetSafeString(objReader["Type"]);
                    oelTransaction.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetTanneryBusinessWorkFinanceAnalysis(DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdTransactions = new SqlCommand("[Transactions].[Pro_GetTanneryBusinessWorkFinanceAnalysis]", objConn))
            {
                cmdTransactions.CommandType = CommandType.StoredProcedure;
                cmdTransactions.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdTransactions.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdTransactions.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["Narration"]);
                    oelTransaction.TransactionType = Validation.GetSafeString(objReader["Type"]);
                    oelTransaction.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelTransaction);
                }
            }
            return list;
        }

        public List<TransactionsEL> GetBalanceSheetAccountsBalances(Guid IdCompany,Guid IdParent,int BType, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdBalanceSheetAccounts = new SqlCommand("[Transactions].[Proc_GetBalanceSheetAccountsBalances]", objConn))
            {
                cmdBalanceSheetAccounts.CommandType = CommandType.StoredProcedure;
                cmdBalanceSheetAccounts.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdBalanceSheetAccounts.Parameters.Add("@IdParent", SqlDbType.UniqueIdentifier).Value = IdParent;
                cmdBalanceSheetAccounts.Parameters.Add("@Type", SqlDbType.Int).Value = BType;
                objReader = cmdBalanceSheetAccounts.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelTransaction.Balance = Validation.GetSafeDecimal(objReader["Balance"]);
                    oelTransaction.TransactionType = Validation.GetSafeString(objReader["BType"]);

                    if (BType == 1)
                    {
                        oelTransaction.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAssets"]);
                    }
                    else
                    {
                        oelTransaction.TotalAmount = Validation.GetSafeDecimal(objReader["TotalLibilities"]);
                    }

                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetWorkerCompleteLedger(string AccountNo, string WorkerType, int HeadDepartment, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdWorkerLedger = new SqlCommand("[Reports].[Proc_GetWorkerCompleteLedger]", objConn))
            {
                cmdWorkerLedger.CommandType = CommandType.StoredProcedure;
                cmdWorkerLedger.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdWorkerLedger.Parameters.Add("@WorkType", SqlDbType.VarChar).Value = WorkerType;
                cmdWorkerLedger.Parameters.Add("@IdHeadDepartment ", SqlDbType.Int).Value = HeadDepartment; 
                objReader = cmdWorkerLedger.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();

                    oelTransaction.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelTransaction.Description = Validation.GetSafeString(objReader["Description"]);
                    oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                    oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);
                    oelTransaction.TransactionType = Validation.GetSafeString(objReader["TransactionType"]);
                    
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetDateWiseWorkerLedger(string AccountNo, string WorkerType, int HeadDepartment, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdWorkerLedger = new SqlCommand("[Reports].[Proc_GetDateWiseWorkerLedger]", objConn))
            {
                cmdWorkerLedger.CommandType = CommandType.StoredProcedure;
                cmdWorkerLedger.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdWorkerLedger.Parameters.Add("@WorkType", SqlDbType.VarChar).Value = WorkerType;
                cmdWorkerLedger.Parameters.Add("@IdHeadDepartment ", SqlDbType.Int).Value = HeadDepartment; 
                cmdWorkerLedger.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdWorkerLedger.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdWorkerLedger.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();

                    oelTransaction.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelTransaction.Description = Validation.GetSafeString(objReader["Description"]);
                    oelTransaction.OpeningBalance = Validation.GetSafeDecimal(objReader["Opening"]);
                    oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                    oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);
                    oelTransaction.TransactionType = Validation.GetSafeString(objReader["TransactionType"]);

                    list.Add(oelTransaction);
                }
            }
            return list;
        }

        public List<TransactionsEL> GetVouchersByUserAndDateForActivity(Guid IdUser, DateTime ActivityDate, string VType, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdBalanceSheetAccounts = new SqlCommand("[Transactions].[Proc_GetVouchersByUserAndDateForActivity]", objConn))
            {
                cmdBalanceSheetAccounts.CommandType = CommandType.StoredProcedure;
                cmdBalanceSheetAccounts.Parameters.Add("@IdUser", SqlDbType.UniqueIdentifier).Value = IdUser;
                cmdBalanceSheetAccounts.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = ActivityDate;
                cmdBalanceSheetAccounts.Parameters.Add("@VoucherType", SqlDbType.VarChar).Value = VType;
                objReader = cmdBalanceSheetAccounts.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();

                    oelTransaction.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);                    
                    oelTransaction.TotalAmount = Validation.GetSafeDecimal(objReader["Amount"]);
                    oelTransaction.CreatedDateTime = Validation.GetSafeDateTime(objReader["VDate"]);
                    oelTransaction.Posted = Validation.GetSafeBoolean(objReader["Posted"]);

                    list.Add(oelTransaction);
                }
            }
            return list;
        }


        #region Accounts Financial Ledger Reporting Section
        public List<TransactionsEL> GetClosingBalanceByAccount(Guid IdCompany, Int64 BookNo, string AccountNo, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdTrial = new SqlCommand("[Transactions].[Proc_GetClosingBalanceByAccount]", objConn))
            {
                cmdTrial.CommandType = CommandType.StoredProcedure;
                cmdTrial.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdTrial.Parameters.Add("@BookNo", SqlDbType.BigInt).Value = BookNo;
                cmdTrial.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                objReader = cmdTrial.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.ClosingBalance = Validation.GetSafeDecimal(objReader["ClosingBalance"]);
                    oelTransaction.BalanceType = Validation.GetSafeString(objReader["BalanceType"]);
                    oelTransaction.TypedClosingBalance = oelTransaction.ClosingBalance + " " + oelTransaction.BalanceType;
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetUnPostedClosingBalanceByAccount(Guid IdCompany, Int64 BookNo, string AccountNo, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdTrial = new SqlCommand("[Transactions].[Proc_GetUnPostedClosingBalanceByAccount]", objConn))
            {
                cmdTrial.CommandType = CommandType.StoredProcedure;
                cmdTrial.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdTrial.Parameters.Add("@BookNo", SqlDbType.BigInt).Value = BookNo;
                cmdTrial.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                objReader = cmdTrial.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.ClosingBalance = Validation.GetSafeDecimal(objReader["ClosingBalance"]);
                    oelTransaction.BalanceType = Validation.GetSafeString(objReader["BalanceType"]);
                    oelTransaction.TypedClosingBalance = oelTransaction.ClosingBalance + " " + oelTransaction.BalanceType;
                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        #endregion
    }
}
