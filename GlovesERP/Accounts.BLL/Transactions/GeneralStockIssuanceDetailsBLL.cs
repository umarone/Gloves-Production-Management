using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;
using System.Data.SqlClient;

namespace Accounts.BLL
{
    public class GeneralStockIssuanceDetailsBLL
    {
        GeneralStockIssuanceDetailDAL dal;
        public GeneralStockIssuanceDetailsBLL()
        {
            dal = new GeneralStockIssuanceDetailDAL();
        }
        public List<SaleDetailEL> GetEmployeeIssuanceReport(string AccountNo, Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetEmployeeIssuanceReport(AccountNo, IdCompany, objconn);
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
        public List<SaleDetailEL> GetEmployeeIssuanceReportByDate(string AccountNo, DateTime StartDate, DateTime EndDate, Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetEmployeeIssuanceReportByDate(AccountNo, StartDate, EndDate, IdCompany, objconn);
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
        public List<SaleDetailEL> GetGeneralProductsTotalIssuance(Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetGeneralProductsTotalIssuance(IdCompany, objconn);
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
        public List<SaleDetailEL> GetGeneralProductsTotalIssuanceByDate(DateTime StartDate, DateTime EndDate, Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetGeneralProductsTotalIssuanceByDate(StartDate, EndDate, IdCompany, objconn);
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
        public List<SaleDetailEL> GetGeneralProductDetailIssuance(Int64 AccountNo, Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetGeneralProductDetailIssuance(AccountNo, IdCompany, objconn);
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
        public List<SaleDetailEL> GetGeneralProductDetailIssuanceByDate(Int64 AccountNo, DateTime StartDate, DateTime EndDate, Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetGeneralProductDetailIssuanceByDate(AccountNo, StartDate, EndDate, IdCompany, objconn);
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
