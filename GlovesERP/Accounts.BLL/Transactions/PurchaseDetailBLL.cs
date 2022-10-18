using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;
using System.Data.SqlClient;
using System.Data;

namespace Accounts.BLL
{
    public class PurchaseDetailBLL
    {
        PurchaseDetailDAL dal;
        public PurchaseDetailBLL()
        {
            dal = new PurchaseDetailDAL();
        }
        public List<VoucherDetailEL> GetPurchaseOrderDetailByPONumber(Guid IdCompany, Guid IdVoucher, Int64 VoucherNo)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetPurchaseOrderDetailByPONumber(IdCompany, IdVoucher, VoucherNo, objconn);
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
        public List<PurchaseDetailEL> GetSupplierPurchase(Int64 AccountNo,Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetSupplierPurchase(AccountNo, IdCompany, objconn);
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
        public List<PurchaseDetailEL> GetSupplierPurchaseByDate(Int64 AccountNo, DateTime StartDate, DateTime EndDate, Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetSupplierPurchaseByDate(AccountNo, StartDate, EndDate, IdCompany, objconn);
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
        public List<PurchaseDetailEL> GetProductsTotalPurchase(Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetProductsTotalPurchase(IdCompany,objconn);
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
        public List<PurchaseDetailEL> GetProductsTotalPurchaseByDate(DateTime StartDate, DateTime EndDate, Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetProductsTotalPurchaseByDate(StartDate, EndDate, IdCompany, objconn);
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
        public List<PurchaseDetailEL> GetProductDetailPurchase(Int64 AccountNo, Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetProductDetailPurchase(AccountNo, IdCompany, objconn);
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
        public List<PurchaseDetailEL> GetProductDetailPurchaseByDate(Int64 AccountNo, DateTime StartDate, DateTime EndDate, Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetProductDetailPurchaseByDate(AccountNo, StartDate, EndDate, IdCompany, objconn);
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
