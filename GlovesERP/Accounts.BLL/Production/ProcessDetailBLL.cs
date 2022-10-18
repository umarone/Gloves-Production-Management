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
    public class ProcessDetailBLL
    {
        ProcessDetailDAL dal;
        public ProcessDetailBLL()
        {
            dal = new ProcessDetailDAL();
        }
        public List<VoucherDetailEL> GetRubberizingByIssuanceTypeAndNumber(Guid IdCompany, Int64 IssuanceNo, int IssuanceType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRubberizingByIssuanceTypeAndNumber(IdCompany, IssuanceNo, IssuanceType, objConn);
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
        public List<VoucherDetailEL> GetRubberizingStockByParty(Guid IdCompany, string AccountNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRubberizingStockByParty(IdCompany, AccountNo, objConn);
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
        public List<VoucherDetailEL> GetRubberizingStockByPartyAndDate(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRubberizingStockByPartyAndDate(IdCompany, AccountNo, StartDate, EndDate, objConn);
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
        public List<VoucherDetailEL> GetRubberizingStockByItemAndParty(Guid IdCompany, Guid IdItem, string AccountNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRubberizingStockByItemAndParty(IdCompany, IdItem, AccountNo, objConn);
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
        public List<VoucherDetailEL> GetRubberizingStockByItemAndDateAndParty(Guid IdCompany, Guid IdItem, string AccountNo, DateTime StartDate, DateTime EndDate)
        {
             SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRubberizingStockByItemAndDateAndParty(IdCompany, IdItem, AccountNo, StartDate, EndDate, objConn);
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
        public List<VoucherDetailEL> GetRubberizingPartySummary(Guid IdCompany, string AccountNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRubberizingPartySummary(IdCompany, AccountNo, objConn);
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
        public List<VoucherDetailEL> GetRubberizingStockByPartySummaryAndDate(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRubberizingStockByPartySummaryAndDate(IdCompany, AccountNo, StartDate, EndDate, objConn);
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
        public List<VoucherDetailEL> GetRubberizingStockByItem(Guid IdCompany, Guid IdItem)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRubberizingStockByItem(IdCompany, IdItem, objConn);
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
        public List<VoucherDetailEL> GetRubberizingStockByItemAndDate(Guid IdCompany, Guid IdItem, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRubberizingStockByItemAndDate(IdCompany, IdItem, StartDate, EndDate, objConn);
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
        public List<VoucherDetailEL> GetRubberizingItemSummary(Guid IdCompany, Guid IdItem)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRubberizingItemSummary(IdCompany, IdItem, objConn);
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
        public List<VoucherDetailEL> GetRubberizingItemSummaryAndDate(Guid IdCompany, Guid IdItem, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRubberizingItemSummaryAndDate(IdCompany, IdItem, StartDate, EndDate, objConn);
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
