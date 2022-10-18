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
    public class OpeningBalanceBLL
    {
        OpeningBalanceDAL dal;
        public OpeningBalanceBLL()
        {
            dal = new OpeningBalanceDAL();
        }

        //public EntityoperationInfo InsertOpeningBalance(List<OpeningBalanceEL> oelOpeninBalanceCollection, List<TransactionsEL> oelTransactionsCollection, List<StockReceiptEL> oelOpeningStockCollection)
        //{
        //    SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
        //    try
        //    {
        //        objConn.Open();
        //        return dal.InsertOpeningBalance(oelOpeninBalanceCollection, oelTransactionsCollection,oelOpeningStockCollection, objConn);
        //    }
        //    catch (Exception ex)
        //    {
        //        objConn.Close();
        //        objConn.Dispose();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (objConn.State == ConnectionState.Open)
        //        {
        //            objConn.Close();
        //            objConn.Dispose();
        //        }
        //    }
        //}
        public EntityoperationInfo InsertOpeningBalance(List<OpeningBalanceEL> oelOpeninBalanceCollection, List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.InsertOpeningBalance(oelOpeninBalanceCollection, oelTransactionsCollection, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        //public EntityoperationInfo UpdateOpeningBalance(OpeningBalanceEL oelOpeninBalance, List<TransactionsEL> oelTransactionsCollection,List<StockReceiptEL> oelOpeningStockCollection)
        //{
        //    SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
        //    try
        //    {
        //        objConn.Open();
        //        return dal.UpdateOpeningBalance(oelOpeninBalance, oelTransactionsCollection,oelOpeningStockCollection, objConn);
        //    }
        //    catch (Exception ex)
        //    {
        //        objConn.Close();
        //        objConn.Dispose();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (objConn.State == ConnectionState.Open)
        //        {
        //            objConn.Close();
        //            objConn.Dispose();
        //        }
        //    }
        //}
        public EntityoperationInfo UpdateOpeningBalance(List<OpeningBalanceEL> oelOpeninBalanceCollection, List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.UpdateOpeningBalance(oelOpeninBalanceCollection, oelTransactionsCollection, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }  
        public List<OpeningBalanceEL> GetOpeningBalance(string AccountNo, string OpeningType, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetOpeningBalance(AccountNo,OpeningType, IdCompany, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<OpeningBalanceEL> GetOpeningBalancesByType(string OpeningType, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetOpeningBalancesByType(OpeningType, IdCompany, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public EntityoperationInfo DeleteOpeningBalance(Int64 AccountNo, Guid IdTransaction, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.DeleteOpeningBalance(AccountNo, IdTransaction, IdCompany, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
    }
}
