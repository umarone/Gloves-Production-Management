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
    public class GeneralStockIssuanceHeadBLL
    {
        GeneralStockIssuanceHeadDAL dal;
        public GeneralStockIssuanceHeadBLL()
        {
            dal = new GeneralStockIssuanceHeadDAL();
        }
        public string GetMaxGeneralStockNumber(Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetMaxGeneralStockNumber(IdCompany, objconn);
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
        public bool CreateGeneralStockIssuance(VouchersEL oelVoucher, List<VoucherDetailEL> oelIssuanceDetail)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.CreateGeneralStockIssuance(oelVoucher, oelIssuanceDetail, objconn);
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
        public bool UpdateGeneralStockIssuance(VouchersEL oelVoucher, List<VoucherDetailEL> oelIssuanceDetail)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.UpdateGeneralStockIssuance(oelVoucher, oelIssuanceDetail, objconn);
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
        public List<VoucherDetailEL> GetGeneralIssuanceWithIssuanceNumber(Int64 IssuanceNo, Guid IdCompany)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetGeneralIssuanceWithIssuanceNumber(IssuanceNo, IdCompany, objconn);
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
