using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using Accounts.EL;
using Accounts.Common;

namespace Accounts.DAL
{
    public class GeneralStockIssuanceHeadDAL
    {
        GeneralStockIssuanceDetailDAL dal;
        IDataReader objReader;
        public GeneralStockIssuanceHeadDAL()
        {
            dal = new GeneralStockIssuanceDetailDAL();
        }
        public string GetMaxGeneralStockNumber(Guid IdCompany, SqlConnection objConn)
        {
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetMaxGeneralStockNumber]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                return cmdVouchers.ExecuteScalar().ToString();
            }
        }
        public bool CreateGeneralStockIssuance(VouchersEL oelVoucher, List<VoucherDetailEL> oelIssuanceDetail,SqlConnection objConn)
        {
            lock (this)
            {
                SqlTransaction objTran = objConn.BeginTransaction();
                try
                {
                    //// Insert Sale Voucher
                    SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_CreateGeneralInventoryIssuanceHead]", objConn);

                    cmdSales.CommandType = CommandType.StoredProcedure;
                    cmdSales.Transaction = objTran;
                    cmdSales.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                    cmdSales.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                    cmdSales.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdSales.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdSales.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.Date;
                    cmdSales.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@DemandNo", DbType.String)).Value = oelVoucher.DemandNo;
                    cmdSales.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelVoucher.Discription;
                    cmdSales.Parameters.Add(new SqlParameter("@OutWardGatePassNo", DbType.String)).Value = oelVoucher.OutWardGatePassNo;
                    cmdSales.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdSales.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdSales.ExecuteNonQuery();

                    //// Insert Detail Sales In Sale Record
                    dal.CreateGeneralInventoryIssuanceDetail(oelIssuanceDetail, objConn, objTran);
                
                    objTran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }
            }
        }
        public bool UpdateGeneralStockIssuance(VouchersEL oelVoucher, List<VoucherDetailEL> oelIssuanceDetail, SqlConnection objConn)
        {
            lock (this)
            {
                SqlTransaction objTran = objConn.BeginTransaction();
                try
                {
                    SqlCommand cmdIssuance = new SqlCommand("[Transactions].[Proc_UpdateGeneralInventoryIssuanceHead]", objConn);
                    cmdIssuance.CommandType = CommandType.StoredProcedure;
                    cmdIssuance.Transaction = objTran;

                    cmdIssuance.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                    cmdIssuance.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                    cmdIssuance.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdIssuance.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdIssuance.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.Date;
                    cmdIssuance.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdIssuance.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelVoucher.Discription;
                    cmdIssuance.Parameters.Add(new SqlParameter("@DemandNo", DbType.String)).Value = oelVoucher.DemandNo;
                    cmdIssuance.Parameters.Add(new SqlParameter("@OutWardGatePassNo", DbType.String)).Value = oelVoucher.OutWardGatePassNo;
                    cmdIssuance.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdIssuance.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdIssuance.ExecuteNonQuery();


                    dal.UpdateGeneralInventoryIssuanceDetail(oelIssuanceDetail, objConn, objTran);

             

                    objTran.Commit();
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }
                finally
                {

                }
                return true;
            }
        }
        public List<VoucherDetailEL> GetGeneralIssuanceWithIssuanceNumber(Int64 IssuanceNo, Guid IdCompany, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdIssuance = new SqlCommand("[Transactions].[Proc_GetGeneralIssuanceWithIssuanceNumber]", objConn))
            {
                cmdIssuance.CommandType = CommandType.StoredProcedure;
                cmdIssuance.CommandTimeout = 0;
                cmdIssuance.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdIssuance.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = IssuanceNo;
                objReader = cmdIssuance.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelIssuanceDetail = new VoucherDetailEL();
                    oelIssuanceDetail.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                    oelIssuanceDetail.IdVoucherDetail = Validation.GetSafeGuid(objReader["VoucherDetail_Id"]);
                    oelIssuanceDetail.Date = Convert.ToDateTime(objReader["VDate"]);

                    oelIssuanceDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelIssuanceDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelIssuanceDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);

                    oelIssuanceDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelIssuanceDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelIssuanceDetail.PackingSize = Validation.GetSafeString(objReader["packingsize"]);
                    //oelSaleDetail.BatchNo = Validation.GetSafeString(objReader["BatchNo"]);
                    //oelSaleDetail.Expiry = Validation.GetSafeString(objReader["Expiry"]);
                    oelIssuanceDetail.CurrentStock = Validation.GetSafeLong(objReader["CurrentStock"]);
                    oelIssuanceDetail.Discription = Validation.GetSafeString(objReader["Discription"]);
                    oelIssuanceDetail.Units = Validation.GetSafeLong(objReader["units"]);
                    //oelSaleDetail.Bonus = Validation.GetSafeInteger(objReader["Bonus"]);
                    oelIssuanceDetail.UnitPrice = Validation.GetSafeDecimal(objReader["unitprice"]);
                    oelIssuanceDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    oelIssuanceDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);

                    list.Add(oelIssuanceDetail);
                }
            }
            return list;
        }
    }
}
