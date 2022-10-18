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
    public class GeneralStockIssuanceDetailDAL
    {
        IDataReader objReader;
        public bool CreateGeneralInventoryIssuanceDetail(List<VoucherDetailEL> oelIssuanceCollection, SqlConnection objConn, SqlTransaction oTran)
        {
            SqlCommand cmdIssuanceDetail = new SqlCommand("[Transactions].[Proc_CreateGeneralInventoryIssuanceDetail]", objConn);
            cmdIssuanceDetail.CommandType = CommandType.StoredProcedure;
            cmdIssuanceDetail.CommandTimeout = 0;
            cmdIssuanceDetail.Transaction = oTran;
            for (int i = 0; i < oelIssuanceCollection.Count; i++)
            {
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelIssuanceCollection[i].IdVoucherDetail;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelIssuanceCollection[i].IdVoucher;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelIssuanceCollection[i].Seq;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelIssuanceCollection[i].IdItem;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelSaleCollection[i].BatchNo;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@Expiry", DbType.String)).Value = oelSaleCollection[i].Expiry;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@CurrentStock", DbType.Int64)).Value = oelIssuanceCollection[i].CurrentStock;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelIssuanceCollection[i].Discription;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@ItemName", DbType.String)).Value = oelSaleCollection[i].ItemName;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelSaleDetail.BatchNo;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@Units", DbType.Decimal)).Value = oelIssuanceCollection[i].Units;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@Bonus", DbType.Int32)).Value = oelSaleCollection[i].Bonus;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelIssuanceCollection[i].UnitPrice;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelIssuanceCollection[i].Amount;
                cmdIssuanceDetail.ExecuteNonQuery();
                cmdIssuanceDetail.Parameters.Clear();
            }
            return true;
        }
        public bool UpdateGeneralInventoryIssuanceDetail(List<VoucherDetailEL> oelIssuanceCollection, SqlConnection objConn, SqlTransaction oTran)
        {
            SqlCommand cmdIssuanceDetail = new SqlCommand();
            cmdIssuanceDetail.CommandType = CommandType.StoredProcedure;
            cmdIssuanceDetail.Connection = objConn;
            cmdIssuanceDetail.Transaction = oTran;
            for (int i = 0; i < oelIssuanceCollection.Count; i++)
            {
                if (oelIssuanceCollection[i].IsNew)
                {
                    cmdIssuanceDetail.CommandText = "[Transactions].[Proc_CreateGeneralInventoryIssuanceDetail]";
                }
                else
                {
                    cmdIssuanceDetail.CommandText = "[Transactions].[Proc_UpdateGeneralInventoryIssuanceDetail]";
                }
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelIssuanceCollection[i].IdVoucherDetail;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelIssuanceCollection[i].IdVoucher;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelIssuanceCollection[i].Seq;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelIssuanceCollection[i].IdItem;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelSaleCollection[i].BatchNo;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@Expiry", DbType.String)).Value = oelSaleCollection[i].Expiry;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@CurrentStock", DbType.Int64)).Value = oelIssuanceCollection[i].CurrentStock;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelIssuanceCollection[i].Discription;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@ItemName", DbType.String)).Value = oelSaleCollection[i].ItemName;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelSaleDetail.BatchNo;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@Units", DbType.Decimal)).Value = oelIssuanceCollection[i].Units;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@Bonus", DbType.Int32)).Value = oelSaleCollection[i].Bonus;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelIssuanceCollection[i].UnitPrice;
                cmdIssuanceDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelIssuanceCollection[i].Amount;
                cmdIssuanceDetail.ExecuteNonQuery();
                cmdIssuanceDetail.Parameters.Clear();
            }

            return true;
        }

        public List<SaleDetailEL> GetEmployeeIssuanceReport(string AccountNo, Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdPrescriberSale = new SqlCommand("[Transactions].[Proc_GetEmployeeIssuance]", objConn))
            {
                cmdPrescriberSale.CommandType = CommandType.StoredProcedure;
                cmdPrescriberSale.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdPrescriberSale.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                objReader = cmdPrescriberSale.ExecuteReader();
                while (objReader.Read())
                {
                    SaleDetailEL oelSaleDetail = new SaleDetailEL();
                    oelSaleDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelSaleDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelSaleDetail.Units = Validation.GetSafeLong(objReader["TotalUnits"]);
                    oelSaleDetail.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                    oelSaleDetail.Amount = Validation.GetSafeDecimal(objReader["TotalSaleAmount"]);
                    list.Add(oelSaleDetail);
                }
            }
            return list;
        }
        public List<SaleDetailEL> GetEmployeeIssuanceReportByDate(string AccountNo, DateTime StartDate, DateTime EndDate, Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdCustomerSale = new SqlCommand("[Transactions].[Proc_GetEmployeeIssuanceReportByDate]", objConn))
            {
                cmdCustomerSale.CommandType = CommandType.StoredProcedure;
                cmdCustomerSale.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdCustomerSale.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdCustomerSale.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdCustomerSale.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdCustomerSale.ExecuteReader();
                while (objReader.Read())
                {
                    SaleDetailEL oelSaleDetail = new SaleDetailEL();
                    oelSaleDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelSaleDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelSaleDetail.Units = Validation.GetSafeLong(objReader["TotalUnits"]);
                    oelSaleDetail.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                    oelSaleDetail.Amount = Validation.GetSafeDecimal(objReader["TotalSaleAmount"]);
                    list.Add(oelSaleDetail);
                }
            }
            return list;
        }
        public List<SaleDetailEL> GetGeneralProductsTotalIssuance(Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdProductSale = new SqlCommand("[Transactions].[Proc_GetGeneralProductsTotalIssuance]", objConn))
            {
                cmdProductSale.CommandType = CommandType.StoredProcedure;
                cmdProductSale.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                objReader = cmdProductSale.ExecuteReader();
                while (objReader.Read())
                {
                    SaleDetailEL oelSaleDetail = new SaleDetailEL();
                    oelSaleDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelSaleDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelSaleDetail.Units = Validation.GetSafeLong(objReader["TotalUnits"]);
                    oelSaleDetail.Amount = Validation.GetSafeDecimal(objReader["TotalSaleAmount"]);
                    list.Add(oelSaleDetail);
                }
            }
            return list;
        }
        public List<SaleDetailEL> GetGeneralProductsTotalIssuanceByDate(DateTime StartDate, DateTime EndDate, Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdProductSale = new SqlCommand("[Transactions].[Proc_GetGeneralProductsTotalIssuanceByDate]", objConn))
            {
                cmdProductSale.CommandType = CommandType.StoredProcedure;
                cmdProductSale.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdProductSale.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdProductSale.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdProductSale.ExecuteReader();
                while (objReader.Read())
                {
                    SaleDetailEL oelSaleDetail = new SaleDetailEL();
                    oelSaleDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelSaleDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelSaleDetail.Units = Validation.GetSafeLong(objReader["TotalUnits"]);
                    oelSaleDetail.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                    oelSaleDetail.Amount = Validation.GetSafeDecimal(objReader["TotalSaleAmount"]);
                    list.Add(oelSaleDetail);
                }
            }
            return list;
        }
        public List<SaleDetailEL> GetGeneralProductDetailIssuance(Int64 AccountNo, Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdProductSale = new SqlCommand("[Transactions].[Proc_GetGeneralProductDetailIssuance]", objConn))
            {
                cmdProductSale.CommandType = CommandType.StoredProcedure;

                cmdProductSale.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdProductSale.Parameters.Add("@AccountNo", SqlDbType.BigInt).Value = AccountNo;
                objReader = cmdProductSale.ExecuteReader();
                while (objReader.Read())
                {
                    SaleDetailEL oelSaleDetail = new SaleDetailEL();
                    oelSaleDetail.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelSaleDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelSaleDetail.Units = Validation.GetSafeLong(objReader["Units"]);
                    oelSaleDetail.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                    oelSaleDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    if (objReader["CustomerName"] != null)
                    {
                        oelSaleDetail.AccountName = Validation.GetSafeString(objReader["CustomerName"]);
                    }
                    list.Add(oelSaleDetail);
                }
            }
            return list;
        }
        public List<SaleDetailEL> GetGeneralProductDetailIssuanceByDate(Int64 AccountNo, DateTime StartDate, DateTime EndDate, Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdProductSale = new SqlCommand("[Transactions].[Proc_GetGeneralProductDetailIssuanceByDate]", objConn))
            {
                cmdProductSale.CommandType = CommandType.StoredProcedure;
                cmdProductSale.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdProductSale.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdProductSale.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                cmdProductSale.Parameters.Add("@AccountNo", SqlDbType.BigInt).Value = AccountNo;
                objReader = cmdProductSale.ExecuteReader();
                while (objReader.Read())
                {
                    SaleDetailEL oelSaleDetail = new SaleDetailEL();
                    oelSaleDetail.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelSaleDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelSaleDetail.Units = Validation.GetSafeLong(objReader["Units"]);
                    oelSaleDetail.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                    oelSaleDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    oelSaleDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    list.Add(oelSaleDetail);
                }
            }
            return list;
        }
    }
}
