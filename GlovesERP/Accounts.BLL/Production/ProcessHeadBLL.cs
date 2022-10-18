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
    public class ProcessHeadBLL
    {
        ProcessHeadDAL dal;
        EntityoperationInfo infoResult;
        public ProcessHeadBLL()
        {
            dal = new ProcessHeadDAL();
        }
        public EntityoperationInfo InsertWorkProcess(VouchersEL oelVoucher, List<VoucherDetailEL> oelProcessCollection, List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                infoResult = dal.InsertWorkProcess(oelVoucher, oelProcessCollection, oelTransactionsCollection, objConn);
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
        public EntityoperationInfo UpdateWorkProcess(VouchersEL oelVoucher, List<VoucherDetailEL> oelProcessCollection, List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                infoResult = dal.UpdateWorkProcess(oelVoucher, oelProcessCollection, oelTransactionsCollection, objConn);
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
        public Int64 GetMaxRubberizingVoucherNumber(Guid IdCompany, int IssuanceType)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetMaxRubberizingVoucherNumber(IdCompany, IssuanceType, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public List<ItemsEL> GetRubberingClosingStockToParty(Guid IdItem, string AccountNo)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetRubberingClosingStockToParty(IdItem, AccountNo, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public List<ItemsEL> GetRubberingClosingStockToPartyLastEntry(Guid IdVoucher, Guid IdItem, string AccountNo)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetRubberingClosingStockToPartyLastEntry(IdVoucher, IdItem, AccountNo, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public bool DeleteProcessHead(Guid IdVoucher)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.DeleteProcessHead(IdVoucher, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
    }
}
