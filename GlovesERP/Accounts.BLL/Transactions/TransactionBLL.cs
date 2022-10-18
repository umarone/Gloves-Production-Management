using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;
using System.Data;

namespace Accounts.BLL
{
    public class TransactionBLL
    {
        TransactionsDAL dal;
        public TransactionBLL()
        {
            dal = new TransactionsDAL();
        }
        public DataTable GetAccountLedger(string AccountNo, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetLedgerByAccount(AccountNo, IdCompany,1,objConn);
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
        public List<TransactionsEL> GetControlAccountLedger(string AccountNo, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetControlAccountLedger(AccountNo, IdCompany, objConn);
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
        public List<TransactionsEL> GetControlAccountsDateWiseLedger(string AccountNo, DateTime StartPeriod, DateTime ToPeriod, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetControlAccountsDateWiseLedger(AccountNo, StartPeriod, ToPeriod, IdCompany, objConn);
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
        public List<TransactionsEL> GetAccountsBalance(string AccountType,Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetAccountsBalance(AccountType, IdCompany, objConn);
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
        public List<TransactionsEL> GetDateWiseAccountsBalance(string AccountType, DateTime StartDate, DateTime EndDate, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetDateWiseAccountsBalance(AccountType, StartDate, EndDate, IdCompany, objConn);
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
        public DataTable GetAccountsDateWiseLedger(string AccountNo, DateTime StartPeriod, DateTime ToPeriod, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetDateWiseLedgerByAccount(AccountNo, IdCompany,1,StartPeriod, ToPeriod, objConn);
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
        public Int64 GetItemCount(string AccountNo, Int64 VoucherNo, string TransactionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetItemCount(AccountNo, VoucherNo, TransactionType, objConn);
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
        public List<TransactionsEL> GetAccountInTransaction(String AccountNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetAccountInTransaction(AccountNo, objConn);
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
        public List<TransactionsEL> ListDailySale(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.ListDailySale(StartDate, EndDate, objConn);
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
        public List<TransactionsEL> ListExpenses(DateTime StartDate, DateTime EndDate,Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.ListExpenses(StartDate, EndDate, IdCompany, objConn);
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
        public List<TransactionsEL> GetHeadAccountTransactionId(Int64 VoucherNo, string VoucherType, string AccountNo, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetHeadAccountTransactionId(VoucherNo, VoucherType, AccountNo, IdCompany, objConn);
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
        public List<TransactionsEL> GetDateWiseTrialBalance(DateTime StartPeriod, DateTime ToPeriod,Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetDateWiseTrialBalance(StartPeriod,ToPeriod, IdCompany, objConn);
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
        public List<TransactionsEL> GetTrialBalance(Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetTrialBalance(IdCompany, objConn);
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
        public List<TransactionsEL> GetMiniTrialBalance(Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetMiniTrialBalance(IdCompany, objConn);
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
        public List<TransactionsEL> GetDateWiseMiniTrialBalance(Guid IdCompany, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetDateWiseMiniTrialBalance(IdCompany, StartDate, EndDate, objConn);
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
        public List<TransactionsEL> GetEmployeesTransactions(Guid IdCompany, string EmpCode)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetEmployeesTransactions(IdCompany, EmpCode, objConn);
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
        public List<TransactionsEL> GetDateWiseEmployeesTransactions(Guid IdCompany, string EmpCode, DateTime startDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetDateWiseEmployeesTransactions(IdCompany,EmpCode, startDate, EndDate, objConn);
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
        public List<TransactionsEL> GetCustomerRecoveryReport(string AccountNo, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetCustomerRecoveryReport(AccountNo, IdCompany, objConn);
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
        public List<TransactionsEL> GetCustomerRecoveryReportByDate(string AccountNo, DateTime StartDate, DateTime EndDate, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetCustomerRecoveryReportByDate(AccountNo,StartDate,EndDate, IdCompany, objConn);
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
        public List<TransactionsEL> GetAllCustomersRecoveryReport(Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetAllCustomersRecoveryReport(IdCompany, objConn);
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
        public List<TransactionsEL> GetAllCustomersByRecoveryReportByDate(Guid IdCompany, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetAllCustomersByRecoveryReportByDate(IdCompany, StartDate, EndDate, objConn);
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
        public List<TransactionsEL> GetDateWiseEmployeesLoans(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetDateWiseEmployeesLoans(IdCompany, AccountNo, StartDate, EndDate, objConn);
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
        public List<TransactionsEL> GetDateWiseEmployeesAdvances(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetDateWiseEmployeesAdvances(IdCompany, AccountNo, StartDate, EndDate, objConn);
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
        public List<TransactionsEL> GetDateWiseEmployeesPaymentDetail(Guid IdCompany, string AccountNo, string WorkType, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetDateWiseEmployeesPaymentDetail(IdCompany, AccountNo, WorkType, StartDate, EndDate, objConn);
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

        public bool AuthorizeDayBook(List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.AuthorizeDayBook(oelTransactionsCollection, objConn);
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
        public List<TransactionsEL> GetDayBookDetail(Guid IdCompany, DateTime BookDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetDayBookDetail(IdCompany, BookDate, objConn);
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
        public decimal GetAccountClosingBalance(String AccountNo, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetAccountClosingBalance(AccountNo, IdCompany, objConn);
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
        public List<TransactionsEL> GetDateWiseTransactionsByAccount(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetDateWiseTransactionsByAccount(IdCompany, AccountNo, StartDate, EndDate, objConn);
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
        public List<TransactionsEL> GetDateWiseDepartmentTransactions(Guid IdCompany, Guid IdDepartment, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetDateWiseDepartmentTransactions(IdCompany, IdDepartment, StartDate, EndDate, objConn);
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
        public List<TransactionsEL> GetTanneryBusinessFinanceAnalysis(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetTanneryBusinessFinanceAnalysis(StartDate, EndDate, objConn);
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
        public List<TransactionsEL> GetTanneryBusinessWorkFinanceAnalysis(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetTanneryBusinessWorkFinanceAnalysis(StartDate, EndDate, objConn);
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
        public List<TransactionsEL> GetBalanceSheetAccountsBalances(Guid IdCompany, Guid IdParent, int BType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetBalanceSheetAccountsBalances(IdCompany, IdParent, BType, objConn);
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
        public List<TransactionsEL> GetWorkerCompleteLedger(string AccountNo, string WorkerType, int HeadDepartment)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetWorkerCompleteLedger(AccountNo, WorkerType, HeadDepartment, objConn);
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
        public List<TransactionsEL> GetDateWiseWorkerLedger(string AccountNo, string WorkerType, int HeadDepartment, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetDateWiseWorkerLedger(AccountNo, WorkerType, HeadDepartment, StartDate, EndDate, objConn);
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

        public List<TransactionsEL> GetVouchersByUserAndDateForActivity(Guid IdUser, DateTime ActivityDate, string VType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetVouchersByUserAndDateForActivity(IdUser, ActivityDate, VType, objConn);
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
        #region Accounts Financial Ledger Reporting Section
        public List<TransactionsEL> GetClosingBalanceByAccount(Guid IdCompany, Int64 BookNo, string AccountNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetClosingBalanceByAccount(IdCompany, BookNo, AccountNo, objConn);
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
        public List<TransactionsEL> GetUnPostedClosingBalanceByAccount(Guid IdCompany, Int64 BookNo, string AccountNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetUnPostedClosingBalanceByAccount(IdCompany, BookNo, AccountNo, objConn);
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
        #endregion
    }
}
