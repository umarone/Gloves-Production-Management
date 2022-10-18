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
    public class CurrencyBLL
    {
        CurrencyDAL dal;
        public CurrencyBLL()
        {
            dal = new CurrencyDAL();
        }
        public EntityoperationInfo CreateCurrency(CurrencyEL oelCurrency)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.CreateCurrency(oelCurrency, objConn);
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
        public EntityoperationInfo UpdateCurrency(CurrencyEL oelCurrency)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.UpdateCurrency(oelCurrency, objConn);
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
        public List<CurrencyEL> GetCurrencyById(Int64 IdCurrency)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetCurrencyById(IdCurrency, objConn);
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
        public List<CurrencyEL> GetAllCurrencies()
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetAllCurrencies(objConn);
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
