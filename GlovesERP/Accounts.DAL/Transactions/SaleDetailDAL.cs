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
    public class SaleDetailDAL
    {
        IDataReader objReader;
        public bool InsertSaleDetail(List<VoucherDetailEL> oelSaleCollection, SqlConnection objConn, SqlTransaction oTran)
        {
            SqlCommand cmdSaleDetail = new SqlCommand("[Transactions].[Proc_CreateSalesDetail]", objConn);
            cmdSaleDetail.CommandType = CommandType.StoredProcedure;
            cmdSaleDetail.CommandTimeout = 0;
            cmdSaleDetail.Transaction = oTran;
            for (int i = 0; i < oelSaleCollection.Count; i++)
            {
                cmdSaleDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelSaleCollection[i].IdVoucherDetail;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelSaleCollection[i].IdVoucher;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@SeqNo", DbType.Int32)).Value = oelSaleCollection[i].Seq;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelSaleCollection[i].IdItem;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelSaleCollection[i].BatchNo;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@Expiry", DbType.String)).Value = oelSaleCollection[i].Expiry;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@CurrentStock", DbType.Int64)).Value = oelSaleCollection[i].CurrentStock;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@TotalCartons", DbType.Int64)).Value = oelSaleCollection[i].TotalCartons;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@ItemName", DbType.String)).Value = oelSaleCollection[i].ItemName;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelSaleDetail.BatchNo;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@Units", DbType.Decimal)).Value = oelSaleCollection[i].Units;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@Bonus", DbType.Int32)).Value = oelSaleCollection[i].Bonus;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelSaleCollection[i].UnitPrice;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelSaleCollection[i].Amount;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@DiscPercentage", DbType.Decimal)).Value = oelSaleCollection[i].Discount;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@Discount", DbType.Decimal)).Value = oelSaleCollection[i].DiscountAmount;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@NetAmount", DbType.Decimal)).Value = oelSaleCollection[i].NetAmount;
                cmdSaleDetail.ExecuteNonQuery();
                cmdSaleDetail.Parameters.Clear();
            }
            return true;
        }
        public bool UpdatePurchaseUnits(List<PurchaseDetailEL> oelPurchaseDetailCollection, SqlConnection objConn, SqlTransaction oTran)
        {
            SqlCommand cmdPurchseDetail = new SqlCommand("sp_UpdatePurchaseUnits", objConn);
            cmdPurchseDetail.CommandType = CommandType.StoredProcedure;
            cmdPurchseDetail.CommandTimeout = 0;
            cmdPurchseDetail.Transaction = oTran;
            for (int i = 0; i < oelPurchaseDetailCollection.Count; i++)
            {
                cmdPurchseDetail.Parameters.Add(new SqlParameter("@IdPurchaseDetail", DbType.Guid)).Value = oelPurchaseDetailCollection[i].IdPurchaseDetail;
                cmdPurchseDetail.Parameters.Add(new SqlParameter("@RemainingUnits", DbType.Int32)).Value = oelPurchaseDetailCollection[i].RemainingUnits;

                cmdPurchseDetail.ExecuteNonQuery();
                cmdPurchseDetail.Parameters.Clear();
            }
            return true;
        }
        public bool UpdateSaleDetail(List<VoucherDetailEL> oelSaleCollection, SqlConnection objConn, SqlTransaction oTran)
        {
            SqlCommand cmdSaleDetail = new SqlCommand();
            cmdSaleDetail.CommandType = CommandType.StoredProcedure;
            cmdSaleDetail.Connection = objConn;
            cmdSaleDetail.Transaction = oTran;
            for (int i = 0; i < oelSaleCollection.Count; i++)
            {
                if (oelSaleCollection[i].IsNew)
                {
                    cmdSaleDetail.CommandText = "[Transactions].[Proc_CreateSalesDetail]";
                }
                else
                {
                    cmdSaleDetail.CommandText = "[Transactions].[Proc_UpdateSalesDetail]";
                }
                cmdSaleDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelSaleCollection[i].IdVoucherDetail;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelSaleCollection[i].IdVoucher;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@SeqNo", DbType.Int32)).Value = oelSaleCollection[i].Seq;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelSaleCollection[i].IdItem;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelSaleCollection[i].BatchNo;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@Expiry", DbType.String)).Value = oelSaleCollection[i].Expiry;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@CurrentStock", DbType.Int64)).Value = oelSaleCollection[i].CurrentStock;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@TotalCartons", DbType.Int64)).Value = oelSaleCollection[i].TotalCartons;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@Units", DbType.Decimal)).Value = oelSaleCollection[i].Units;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@Bonus", DbType.Int32)).Value = oelSaleCollection[i].Bonus;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelSaleCollection[i].UnitPrice;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelSaleCollection[i].Amount;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@DiscPercentage", DbType.Decimal)).Value = oelSaleCollection[i].Discount;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@Discount", DbType.Decimal)).Value = oelSaleCollection[i].DiscountAmount;
                cmdSaleDetail.Parameters.Add(new SqlParameter("@NetAmount", DbType.Decimal)).Value = oelSaleCollection[i].NetAmount;
                cmdSaleDetail.ExecuteNonQuery();
                cmdSaleDetail.Parameters.Clear();
            }

            return true;
        }
        public bool InsertSalesReturnDetail(List<VoucherDetailEL> oelSaleCollection, SqlConnection objConn, SqlTransaction oTran)
        {
            SqlCommand cmdSalesReturn = new SqlCommand("[Transactions].[Proc_CreateSalesReturnDetail]", objConn);
            cmdSalesReturn.CommandType = CommandType.StoredProcedure;
            cmdSalesReturn.CommandTimeout = 0;
            cmdSalesReturn.Transaction = oTran;
            for (int i = 0; i < oelSaleCollection.Count; i++)
            {
                cmdSalesReturn.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelSaleCollection[i].IdVoucherDetail;
                cmdSalesReturn.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelSaleCollection[i].IdVoucher;
                cmdSalesReturn.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelSaleCollection[i].Seq;
                cmdSalesReturn.Parameters.Add(new SqlParameter("@ItemNo", DbType.String)).Value = oelSaleCollection[i].ItemNo;
                cmdSalesReturn.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelSaleCollection[i].IdItem;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@ItemName", DbType.String)).Value = oelSaleCollection[i].ItemName;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelSaleDetail.BatchNo;
                cmdSalesReturn.Parameters.Add(new SqlParameter("@Units", DbType.Decimal)).Value = oelSaleCollection[i].Units;
                cmdSalesReturn.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelSaleCollection[i].UnitPrice;
                cmdSalesReturn.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelSaleCollection[i].Amount;
                cmdSalesReturn.ExecuteNonQuery();
                cmdSalesReturn.Parameters.Clear();
            }
            return true;
        }
        public bool UpdateSalesReturnDetail(List<VoucherDetailEL> oelSaleCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdSalesReturn = new SqlCommand();
            cmdSalesReturn.CommandType = CommandType.StoredProcedure;
            cmdSalesReturn.Connection = objConn;
            cmdSalesReturn.Transaction = objTran;
            for (int i = 0; i < oelSaleCollection.Count; i++)
            {
                if (oelSaleCollection[i].IsNew)
                {
                    cmdSalesReturn.CommandText = "[Transactions].[Proc_CreateSalesReturnDetail]";
                }
                else
                {
                    cmdSalesReturn.CommandText = "[Transactions].[Proc_UpdateSalesReturnDetail]";
                }
                cmdSalesReturn.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelSaleCollection[i].IdVoucherDetail;
                cmdSalesReturn.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelSaleCollection[i].IdVoucher;
                cmdSalesReturn.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelSaleCollection[i].Seq;
                cmdSalesReturn.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelSaleCollection[i].IdItem;
                cmdSalesReturn.Parameters.Add(new SqlParameter("@ItemNo", DbType.String)).Value = oelSaleCollection[i].ItemNo;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@ItemName", DbType.String)).Value = oelSaleCollection[i].ItemName;
                //cmdSaleDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelSaleDetail.BatchNo;
                cmdSalesReturn.Parameters.Add(new SqlParameter("@Units", DbType.Decimal)).Value = oelSaleCollection[i].Units;
                cmdSalesReturn.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelSaleCollection[i].UnitPrice;
                cmdSalesReturn.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelSaleCollection[i].Amount;
                cmdSalesReturn.ExecuteNonQuery();
                cmdSalesReturn.Parameters.Clear();
            }

            return true;
        }
        public bool InsertSalesTransactionsDetail(List<VoucherDetailEL> oelDetailCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdVoucherDetail = new SqlCommand("[Transactions].[Proc_CreateSalesTransactionsDetails]", objConn);
            cmdVoucherDetail.CommandType = CommandType.StoredProcedure;
            cmdVoucherDetail.CommandTimeout = 0;
            cmdVoucherDetail.Transaction = objTran;
            for (int i = 0; i < oelDetailCollection.Count; i++)
            {
                cmdVoucherDetail.CommandType = CommandType.StoredProcedure;
                cmdVoucherDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelDetailCollection[i].IdVoucherDetail;
                cmdVoucherDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelDetailCollection[i].IdVoucher;
                cmdVoucherDetail.Parameters.Add(new SqlParameter("@IdAccount", DbType.Guid)).Value = oelDetailCollection[i].IdAccount;
                cmdVoucherDetail.Parameters.Add(new SqlParameter("@AccountNo", DbType.Int64)).Value = oelDetailCollection[i].AccountNo;
                cmdVoucherDetail.Parameters.Add(new SqlParameter("@Narration", DbType.String)).Value = oelDetailCollection[i].Description;
                cmdVoucherDetail.Parameters.Add(new SqlParameter("@Debit", DbType.Decimal)).Value = oelDetailCollection[i].Debit;
                cmdVoucherDetail.Parameters.Add(new SqlParameter("@Credit", DbType.Decimal)).Value = oelDetailCollection[i].Credit;
                cmdVoucherDetail.ExecuteNonQuery();
                cmdVoucherDetail.Parameters.Clear();
            }
            return true;
        }
        public bool UpdateSalesTransactionsDetail(List<VoucherDetailEL> oelDetailCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdVoucherDetail = new SqlCommand();
            cmdVoucherDetail.Connection = objConn;
            cmdVoucherDetail.CommandType = CommandType.StoredProcedure;
            cmdVoucherDetail.CommandTimeout = 0;
            cmdVoucherDetail.Transaction = objTran;
            for (int i = 0; i < oelDetailCollection.Count; i++)
            {
                if (oelDetailCollection[i].IsNew)
                {
                    cmdVoucherDetail.CommandText = "[Transactions].[Proc_CreateSalesTransactionsDetails]";
                }
                else
                {
                    cmdVoucherDetail.CommandText = "[Transactions].[Proc_UpdateSalesTransactionsDetails]";
                }
                cmdVoucherDetail.CommandType = CommandType.StoredProcedure;
                cmdVoucherDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelDetailCollection[i].IdVoucherDetail;
                cmdVoucherDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelDetailCollection[i].IdVoucher;
                cmdVoucherDetail.Parameters.Add(new SqlParameter("@IdAccount", DbType.Guid)).Value = oelDetailCollection[i].IdAccount;
                cmdVoucherDetail.Parameters.Add(new SqlParameter("@AccountNo", DbType.Int64)).Value = oelDetailCollection[i].AccountNo;
                cmdVoucherDetail.Parameters.Add(new SqlParameter("@Narration", DbType.String)).Value = oelDetailCollection[i].Description;
                cmdVoucherDetail.Parameters.Add(new SqlParameter("@Debit", DbType.Decimal)).Value = oelDetailCollection[i].Debit;
                cmdVoucherDetail.Parameters.Add(new SqlParameter("@Credit", DbType.Decimal)).Value = oelDetailCollection[i].Credit;
                cmdVoucherDetail.ExecuteNonQuery();
                cmdVoucherDetail.Parameters.Clear();
            }
            return true;
        }
        public List<VoucherDetailEL> GetSaleWithInvoiceNumber(Int64 InvoiceNumber,Guid IdCompany, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_GetSaleWithInvoiceNumber]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.CommandTimeout = 0;
                cmdSales.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdSales.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = InvoiceNumber;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelSaleDetail = new VoucherDetailEL();
                    oelSaleDetail.VehicalNo = Validation.GetSafeString(objReader["VehicleNo"]);
                    oelSaleDetail.IdVoucherDetail = new Guid(objReader["VoucherDetail_Id"].ToString());
                    //oelSaleDetail.IdTransaction = new Guid(objReader["transaction_id"].ToString());
                    //oelSaleDetail.IdPrescriberTransaction = new Guid(objReader["PrescriberTransaction_Id"].ToString());
                    oelSaleDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelSaleDetail.IdArticle = Validation.GetSafeGuid(objReader["Article_Id"]);
                    oelSaleDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelSaleDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelSaleDetail.ArticleName = Validation.GetSafeString(objReader["ArticleName"]);
                    oelSaleDetail.AccountNo = Validation.GetSafeString(objReader["MakerAccountNo"]);
                    oelSaleDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelSaleDetail.PackingSize = Validation.GetSafeString(objReader["packingsize"]);
                    //oelSaleDetail.BatchNo = Validation.GetSafeString(objReader["BatchNo"]);
                    //oelSaleDetail.Expiry = Validation.GetSafeString(objReader["Expiry"]);
                    oelSaleDetail.CurrentStock = Validation.GetSafeLong(objReader["CurrentStock"]);
                    oelSaleDetail.TotalCartons = Validation.GetSafeLong(objReader["TotalCartons"]);
                    oelSaleDetail.Discription = Validation.GetSafeString(objReader["Description"]);
                    oelSaleDetail.Units = Validation.GetSafeLong(objReader["units"]);
                    //oelSaleDetail.Bonus = Validation.GetSafeInteger(objReader["Bonus"]);
                    oelSaleDetail.UnitPrice = Validation.GetSafeDecimal(objReader["unitprice"]);
                    oelSaleDetail.Amount = Validation.GetSafeDecimal(objReader["amount"]);
                    oelSaleDetail.Discount = Validation.GetSafeDecimal(objReader["DiscPercentage"]);
                    oelSaleDetail.DiscountAmount = Validation.GetSafeDecimal(objReader["Discount"]);
                    //oelSaleDetail.TotalDiscount = Validation.GetSafeDecimal(objReader["TotalDiscount"]);
                    //oelSaleDetail.NetSaleAmount = Validation.GetSafeDecimal(objReader["NetSale"]);

                    //oelSaleDetail.Discount = Convert.ToDecimal(objReader["discount"]);
                    //if (objReader["Description"] != DBNull.Value)
                    //{
                    //    oelSaleDetail.Description = objReader["Description"].ToString();
                    //}
                    //else
                    //{
                    //    oelSaleDetail.Description = "";
                    //}
                    list.Add(oelSaleDetail);
                }
            }
            return list;
        }
        public Guid GetSalePrescriberIdWithInvoiceNumber(Int64 InvoiceNumber, string AccountNo, SqlConnection objConn)
        {
            using (SqlCommand cmdSales = new SqlCommand("sp_GetSalePrescriberIdWithInvoiceNumber", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.CommandTimeout = 0;
                cmdSales.Parameters.Add(new SqlParameter("@AccountNo", DbType.Guid)).Value = AccountNo;
                cmdSales.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = InvoiceNumber;
                return new Guid(cmdSales.ExecuteScalar().ToString());
            }

        }
        public List<VoucherDetailEL> GetSalesReturnWithInvoiceNumber(Int64 InvoiceNumber, Guid IdCompany, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_GetSalesReturnWithInvoiceNumber]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.CommandTimeout = 0;
                cmdSales.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdSales.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = InvoiceNumber;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelSaleDetail = new VoucherDetailEL();
                    oelSaleDetail.IdVoucherDetail = new Guid(objReader["VoucherDetail_Id"].ToString());                    
                    oelSaleDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelSaleDetail.ItemNo = objReader["itemNo"].ToString();
                    oelSaleDetail.ItemName = objReader["ItemName"].ToString();                   
                    oelSaleDetail.PackingSize = objReader["PackingSize"].ToString();
                    //oelSaleDetail.BatchNo = objReader["BatchNo"].ToString();
                    //oelSaleDetail.Expiry = objReader["Expiry"].ToString();
                    oelSaleDetail.Units = Convert.ToInt64(objReader["units"]);
                    oelSaleDetail.UnitPrice = Convert.ToInt64(objReader["unitprice"]);
                    oelSaleDetail.Amount = Convert.ToDecimal(objReader["amount"]);
                    //if (objReader["Description"] != DBNull.Value)
                    //{
                    //    oelSaleDetail.Description = objReader["Description"].ToString();
                    //}
                    //else
                    //{
                    //    oelSaleDetail.Description = "";
                    //}
                    list.Add(oelSaleDetail);
                }
            }
            return list;
        }
        public List<SaleDetailEL> GetCustomerDiscountDetail(Guid IdCompany, Guid IdItem, string AccountNo, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_GetCustomerDiscountDetail]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.CommandTimeout = 0;
                cmdSales.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdSales.Parameters.Add(new SqlParameter("@IdItem", DbType.Int64)).Value = IdItem;
                cmdSales.Parameters.Add(new SqlParameter("@AccountNo", DbType.Int64)).Value = AccountNo;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    SaleDetailEL oelSaleDetail = new SaleDetailEL();
                    oelSaleDetail.Discount = Validation.GetSafeDecimal(objReader["DiscPercentage"]);
                    oelSaleDetail.DiscountAmount = Validation.GetSafeDecimal(objReader["DisCount"]);
                    oelSaleDetail.UnitPrice = Convert.ToInt64(objReader["unitprice"]);
                    oelSaleDetail.Amount = Convert.ToDecimal(objReader["amount"]);

                    list.Add(oelSaleDetail);
                }
            }
            return list;
        }      
        public List<SaleDetailEL> GetPrescriberSale(string AccountNo, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdPrescriberSale = new SqlCommand("sp_GetPrescriberSale", objConn))
            {
                cmdPrescriberSale.CommandType = CommandType.StoredProcedure;
                cmdPrescriberSale.Parameters.Add("@PrescriberAccountNo", SqlDbType.NVarChar).Value = AccountNo;
                objReader = cmdPrescriberSale.ExecuteReader();
                while (objReader.Read())
                {
                    SaleDetailEL oelSaleDetail = new SaleDetailEL();
                    oelSaleDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelSaleDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelSaleDetail.Units = Validation.GetSafeLong(objReader["TotalUnits"]);
                    oelSaleDetail.Amount = Validation.GetSafeDecimal(objReader["TotalSaleAmount"]);
                    oelSaleDetail.CommissionPercentage = Validation.GetSafeDecimal(objReader["TotalCommissionPercentage"]);
                    oelSaleDetail.TotalCommissionAmount = Validation.GetSafeDecimal(objReader["TotalCommissionAmount"]);
                    list.Add(oelSaleDetail);
                }
            }
            return list;
        }
        public List<SaleDetailEL> GetPrescriberSaleByDate(string AccountNo, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdPrescriberSale = new SqlCommand("sp_GetPrescriberSaleByDate", objConn))
            {
                cmdPrescriberSale.CommandType = CommandType.StoredProcedure;
                cmdPrescriberSale.Parameters.Add("@PrescriberAccountNo", SqlDbType.NVarChar).Value = AccountNo;
                cmdPrescriberSale.Parameters.Add("@StartDate", SqlDbType.NVarChar).Value = StartDate;
                cmdPrescriberSale.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = EndDate;
                objReader = cmdPrescriberSale.ExecuteReader();
                while (objReader.Read())
                {
                    SaleDetailEL oelSaleDetail = new SaleDetailEL();
                    oelSaleDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelSaleDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelSaleDetail.Units = Validation.GetSafeLong(objReader["TotalUnits"]);
                    oelSaleDetail.Amount = Validation.GetSafeDecimal(objReader["TotalSaleAmount"]);
                    oelSaleDetail.CommissionPercentage = Validation.GetSafeDecimal(objReader["TotalCommissionPercentage"]);
                    oelSaleDetail.TotalCommissionAmount = Validation.GetSafeDecimal(objReader["TotalCommissionAmount"]);
                    list.Add(oelSaleDetail);
                }
            }
            return list;
        }
        public List<SaleDetailEL> GetCustomerSale(Int64 AccountNo, Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdPrescriberSale = new SqlCommand("[Transactions].[Proc_GetCustomerSale]", objConn))
            {
                cmdPrescriberSale.CommandType = CommandType.StoredProcedure;
                cmdPrescriberSale.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdPrescriberSale.Parameters.Add("@AccountNo", SqlDbType.BigInt).Value = AccountNo;
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
        public List<SaleDetailEL> GetCustomerSaleByDate(Int64 AccountNo, DateTime StartDate, DateTime EndDate,Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdCustomerSale = new SqlCommand("[Transactions].[Proc_GetCustomerSaleByDate]", objConn))
            {
                cmdCustomerSale.CommandType = CommandType.StoredProcedure;
                cmdCustomerSale.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdCustomerSale.Parameters.Add("@AccountNo", SqlDbType.BigInt).Value = AccountNo;
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
        public List<SaleDetailEL> GetProductsTotalSale(Guid IdCompany,SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdProductSale = new SqlCommand("[Transactions].[Proc_GetProductsTotalSale]", objConn))
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
        public List<SaleDetailEL> GetProductsTotalSaleByDate(DateTime StartDate, DateTime EndDate, Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdProductSale = new SqlCommand("[Transactions].[Proc_GetProductsTotalSaleByDate]", objConn))
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
        public List<SaleDetailEL> GetProductDetailSale(Int64 AccountNo, Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdProductSale = new SqlCommand("[Transactions].[Proc_GetProductDetailSale]", objConn))
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
        public List<SaleDetailEL> GetProductDetailSaleByDate(Int64 AccountNo, DateTime StartDate, DateTime EndDate, Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdProductSale = new SqlCommand("[Transactions].[Proc_GetProductDetailSaleByDate]", objConn))
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


        public List<SaleDetailEL> GetMakerReportSale(Int64 AccountNo, Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdPrescriberSale = new SqlCommand("[Transactions].[Proc_GetMakerSaleReport]", objConn))
            {
                cmdPrescriberSale.CommandType = CommandType.StoredProcedure;
                cmdPrescriberSale.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdPrescriberSale.Parameters.Add("@AccountNo", SqlDbType.BigInt).Value = AccountNo;
                objReader = cmdPrescriberSale.ExecuteReader();
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
        public List<SaleDetailEL> GetMakerSaleReportByDate(string AccountNo, DateTime StartDate, DateTime EndDate, Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdCustomerSale = new SqlCommand("[Transactions].[Proc_GetMakerSaleReportByDate]", objConn))
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
                    oelSaleDetail.Amount = Validation.GetSafeDecimal(objReader["TotalSaleAmount"]);
                    list.Add(oelSaleDetail);
                }
            }
            return list;
        }
        public List<SaleDetailEL> GetArticleDetailSaleReport(Guid IdItem, Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdProductSale = new SqlCommand("[Transactions].[Proc_GetArticleDetailSaleReport]", objConn))
            {
                cmdProductSale.CommandType = CommandType.StoredProcedure;

                cmdProductSale.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdProductSale.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
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
        public List<SaleDetailEL> GetArticleDetailSaleReportByDate(Guid IdItem, DateTime StartDate, DateTime EndDate, Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdProductSale = new SqlCommand("[Transactions].[Proc_GetArticleDetailSaleReportByDate]", objConn))
            {
                cmdProductSale.CommandType = CommandType.StoredProcedure;
                cmdProductSale.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdProductSale.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdProductSale.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                cmdProductSale.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
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
        public List<SaleDetailEL> GetArticlesTotalSalesReport(Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdProductSale = new SqlCommand("[Transactions].[Proc_GetArticlesTotalSalesReport]", objConn))
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
        public List<SaleDetailEL> GetArticlesTotalSaleByDate(DateTime StartDate, DateTime EndDate, Guid IdCompany, SqlConnection objConn)
        {
            List<SaleDetailEL> list = new List<SaleDetailEL>();
            using (SqlCommand cmdProductSale = new SqlCommand("[Transactions].[Proc_GetArticlesTotalSaleReportByDate]", objConn))
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
    }
}
