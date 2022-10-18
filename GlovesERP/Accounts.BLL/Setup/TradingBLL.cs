using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accounts.DAL;
using Accounts.EL;
using Accounts.Common;
using System.Data.SqlClient;

namespace Accounts.BLL
{
    public class TradingBLL
    {
        TradingDAL dal;
        EntityoperationInfo infoResult;
        public TradingBLL()
        {
            dal = new TradingDAL();
        }
        public EntityoperationInfo InsertTradingCo(TradingEL oelTrading)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                infoResult = dal.InsertTradingCo(oelTrading, objConn);
            }
            catch
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
        public EntityoperationInfo UpdateTradingCo(TradingEL oelTrading)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                infoResult = dal.UpdateTradingCo(oelTrading, objConn);
            }
            catch
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
        public EntityoperationInfo DeleteTradingCo(Guid IdTrading)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                infoResult = dal.DeleteTradingCo(IdTrading, objConn);
            }
            catch
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
        public Int64 GetMaxTradingCode(Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetMaxTradingCode(IdCompany, objConn);
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
        public List<TradingEL> GetTradingCoById(Guid? Id)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetTradingCoById(Id, objConn);
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
        public List<TradingEL> GetAllTradingCo(Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetAllTradingCo(IdCompany, objConn);
            }
            catch(Exception ex)
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
