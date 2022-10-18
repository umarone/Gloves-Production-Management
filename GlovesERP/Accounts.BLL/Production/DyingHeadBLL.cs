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
    public class DyingHeadBLL
    {
        #region Variables
        DyingHeadDAL dal;
        DyingDetailDAL DyingDetaildal;
        EntityoperationInfo infoResult;
        #endregion
        #region Dying Head Section
        public DyingHeadBLL()
        {
            dal = new DyingHeadDAL();
            DyingDetaildal = new DyingDetailDAL();
        }
        public Int64 GetMaxDyingVoucherNumber(Guid IdCompany, int IssuanceType)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetMaxDyingVoucherNumber(IdCompany, IssuanceType, objconn);
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
        public EntityoperationInfo InsertDyingHead(VouchersEL oelVoucher, List<VoucherDetailEL> oelDyingCollection, List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                infoResult = dal.InsertDyingHead(oelVoucher, oelDyingCollection, oelTransactionsCollection, objConn);
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
        public EntityoperationInfo UpdateDyingHead(VouchersEL oelVoucher, List<VoucherDetailEL> oelDyingCollection, List<TransactionsEL> oelTransactionsCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                infoResult = dal.UpdateDyingHead(oelVoucher, oelDyingCollection, oelTransactionsCollection, objConn);
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
        public bool DeleteDyingHead(Guid IdVoucher)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.DeleteDyingHead(IdVoucher, objconn);
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
        #endregion
        #region Dying Detail Section
        public List<VoucherDetailEL> GetDyingByIssuanceTypeAndNumber(Guid IdCompany, Int64 IssuanceNo, int IssuanceType)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return DyingDetaildal.GetDyingByIssuanceTypeAndNumber(IdCompany, IssuanceNo, IssuanceType, objconn);
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
        #endregion
    }
}
