using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using Accounts.EL;
using Accounts.Common;
namespace Accounts
{
    public class IncomeDAL
    {
        IDataReader objReader;
        public List<TransactionsEL> GetTotalIncomeSale(DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {            
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            using (SqlCommand cmdIncome = new SqlCommand("sp_IncomeTotalSale", objConn))
            {
                cmdIncome.CommandType = CommandType.StoredProcedure;
                cmdIncome.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdIncome.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdIncome.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    if (objReader["TotalSale"] != DBNull.Value)
                    {
                        oelTransaction.Amount = Convert.ToDecimal(objReader["TotalSale"]);
                    }
                    else
                    {
                        oelTransaction.Amount = 0;
                    }
                    if (objReader["TotalDiscount"] != DBNull.Value)
                    {
                        oelTransaction.TotalDiscount = Convert.ToDecimal(objReader["TotalDiscount"]);
                    }
                    else
                    {
                        oelTransaction.TotalDiscount = 0;
                    }
                    oelTransactionCollection.Add(oelTransaction);
                }
                return oelTransactionCollection;
            }
        }
        public List<TransactionsEL> GetTotalIncomeCommission(DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            using (SqlCommand cmdIncome = new SqlCommand("sp_IncomeTotalCommission", objConn))
            {
                cmdIncome.CommandType = CommandType.StoredProcedure;
                cmdIncome.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdIncome.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdIncome.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    if (objReader["TotalDiscountAmount"] != DBNull.Value)
                    {
                        oelTransaction.Amount = Convert.ToDecimal(objReader["TotalDiscountAmount"]);
                    }
                    else
                    {
                        oelTransaction.Amount = 0;
                    }
                    oelTransactionCollection.Add(oelTransaction);
                }
                return oelTransactionCollection;
            }
        }
        public List<TransactionsEL> GetTotalIncomeSalary(DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            using (SqlCommand cmdIncome = new SqlCommand("sp_IncomeTotalSalary", objConn))
            {
                cmdIncome.CommandType = CommandType.StoredProcedure;
                cmdIncome.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdIncome.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdIncome.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    if (objReader["TotalSalary"] != DBNull.Value)
                    {
                        oelTransaction.Amount = Convert.ToDecimal(objReader["TotalSalary"]);
                    }
                    else
                    {
                        oelTransaction.Amount = 0;
                    }
                    oelTransactionCollection.Add(oelTransaction);
                }
                return oelTransactionCollection;
            }
        }
        public List<TransactionsEL> GetTotalIncomeCostOfGoods(DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            using (SqlCommand cmdIncome = new SqlCommand("sp_IncomeCostOgGoodsSolds", objConn))
            {
                cmdIncome.CommandType = CommandType.StoredProcedure;
                cmdIncome.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdIncome.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdIncome.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    if (objReader["CostOfGoodsSold"] != DBNull.Value)
                    {
                        oelTransaction.Amount = Convert.ToDecimal(objReader["CostOfGoodsSold"]);
                    }
                    else
                    {
                        oelTransaction.Amount = 0;
                    }
                    oelTransactionCollection.Add(oelTransaction);
                }
                return oelTransactionCollection;
            }
        }
        public List<TransactionsEL> GetTotalIncomeExpense(Guid IdCompany,DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            using (SqlCommand cmdIncome = new SqlCommand("[Transactions].[Proc_GetIncomeTotalExpense]", objConn))
            {
                cmdIncome.CommandType = CommandType.StoredProcedure;
                cmdIncome.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdIncome.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdIncome.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdIncome.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountType"]);
                    oelTransaction.Amount = Convert.ToDecimal(objReader["TotalExpenses"]);
                    oelTransactionCollection.Add(oelTransaction);
                }
                return oelTransactionCollection;
            }
        }
        public List<TransactionsEL> GetTotalOtherIncome(Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            using (SqlCommand cmdIncome = new SqlCommand("[Transactions].[Proc_GetOtherIncome]", objConn))
            {
                cmdIncome.CommandType = CommandType.StoredProcedure;
                cmdIncome.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdIncome.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdIncome.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdIncome.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountType"]);
                    oelTransaction.Amount = Convert.ToDecimal(objReader["TotalExpenses"]);
                    oelTransactionCollection.Add(oelTransaction);
                }
                return oelTransactionCollection;
            }
        }        
        public List<TransactionsEL> GetTotalSaleRevenue(Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            using (SqlCommand cmdIncome = new SqlCommand("[Transactions].[Proc_GetTotalRevenue]", objConn))
            {
                cmdIncome.CommandType = CommandType.StoredProcedure;
                cmdIncome.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdIncome.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdIncome.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdIncome.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelTransaction.Amount = Validation.GetSafeDecimal(objReader["TotalRevenue"]);
                    oelTransactionCollection.Add(oelTransaction);
                }
                return oelTransactionCollection;
            }
        }
        public List<TransactionsEL> GetTotalSaleReturnRevenue(Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            using (SqlCommand cmdIncome = new SqlCommand("[Transactions].[Proc_GetTotalSalesReturn]", objConn))
            {
                cmdIncome.CommandType = CommandType.StoredProcedure;
                cmdIncome.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdIncome.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdIncome.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdIncome.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelTransaction.Amount = Convert.ToDecimal(objReader["TotalSaleReturnAmount"]);
                    oelTransactionCollection.Add(oelTransaction);
                }
                return oelTransactionCollection;
            }
        }
        public List<TransactionsEL> GetTotalPurchases(Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            using (SqlCommand cmdIncome = new SqlCommand("[Transactions].[Proc_GetTotalPurchases]", objConn))
            {
                cmdIncome.CommandType = CommandType.StoredProcedure;
                cmdIncome.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdIncome.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdIncome.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdIncome.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelTransaction.Amount = Validation.GetSafeDecimal(objReader["TotalPurchases"]);
                    oelTransactionCollection.Add(oelTransaction);
                }
                return oelTransactionCollection;
            }
        }
        public List<TransactionsEL> GetStockOpeningAndClosingBalances(Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            using (SqlCommand cmdIncome = new SqlCommand("[Reports].[Proc_GetStockOpeningAndClosingBalances]", objConn))
            {
                cmdIncome.CommandType = CommandType.StoredProcedure;
                cmdIncome.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdIncome.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdIncome.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdIncome.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["ItemName"]);
                    oelTransaction.OpeningBalance = Validation.GetSafeDecimal(objReader["OpeningBalance"]);
                    oelTransaction.ClosingBalance = Validation.GetSafeDecimal(objReader["RemainingBalance"]);
                    oelTransactionCollection.Add(oelTransaction);
                }
                return oelTransactionCollection;
            }
        }
        public List<TransactionsEL> GetOpeningStockAmount(Guid IdCompany, DateTime StartDate, SqlConnection objConn)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            using (SqlCommand cmdIncome = new SqlCommand("[Transactions].[Proc_GetOpeningStockAmount]", objConn))
            {
                cmdIncome.CommandType = CommandType.StoredProcedure;
                cmdIncome.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdIncome.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                objReader = cmdIncome.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountType"]);
                    oelTransaction.Amount = Convert.ToDecimal(objReader["OpeningAmount"]);
                    oelTransactionCollection.Add(oelTransaction);
                }
                return oelTransactionCollection;
            }
        }
        public List<TransactionsEL> GetClosingStockAmount(Guid IdCompany, DateTime StartDate,DateTime EndDate, SqlConnection objConn)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            using (SqlCommand cmdIncome = new SqlCommand("[Transactions].[Proc_GetClosingStockAmount]", objConn))
            {
                cmdIncome.CommandType = CommandType.StoredProcedure;
                cmdIncome.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdIncome.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdIncome.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdIncome.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountType"]);
                    oelTransaction.Amount = Convert.ToDecimal(objReader["ClosingAmount"]);
                    oelTransactionCollection.Add(oelTransaction);
                }
                return oelTransactionCollection;
            }
        }

    }
}
