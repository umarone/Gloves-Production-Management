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
    public class PurchaseDetailDAL
    {
        IDataReader objReader;
        public static bool InsertPurchaseDetail(PurchaseDetailEL oelPurchaseDetail, SqlConnection oConn)
        {
            using (SqlCommand cmdPurchaseDetail = new SqlCommand("sp_insertPurchaseDetail", oConn))
            {
                cmdPurchaseDetail.CommandType = CommandType.StoredProcedure;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelPurchaseDetail.VoucherNo;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelPurchaseDetail.Seq;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@ItemNo", DbType.String)).Value = oelPurchaseDetail.ItemNo;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@ItemName", DbType.String)).Value = oelPurchaseDetail.ItemName;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelPurchaseDetail.BatchNo;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelPurchaseDetail.Discription;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Qty", DbType.Decimal)).Value = oelPurchaseDetail.Units;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelPurchaseDetail.UnitPrice;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelPurchaseDetail.Amount;
                cmdPurchaseDetail.ExecuteNonQuery();
                cmdPurchaseDetail.Parameters.Clear();
                return true;

            }
        }
        public bool InsertPurchaseDetail(List<VoucherDetailEL> oelPurchaseCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdPurchaseDetail = new SqlCommand("[Transactions].[Proc_CreatePurchaseDetail]", objConn);
            cmdPurchaseDetail.CommandType = CommandType.StoredProcedure;
            cmdPurchaseDetail.Transaction = objTran;
            for (int i = 0; i < oelPurchaseCollection.Count; i++)
            {
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelPurchaseCollection[i].IdVoucherDetail;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelPurchaseCollection[i].IdVoucher;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelPurchaseCollection[i].Seq;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelPurchaseCollection[i].IdItem;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelPurchaseCollection[i].Discription;
                //cmdPurchaseDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelPurchaseCollection[i].BatchNo;
                //cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Expiry", DbType.String)).Value = oelPurchaseCollection[i].Expiry;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Units", DbType.Decimal)).Value = oelPurchaseCollection[i].Units;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@BonusUnits", DbType.Int64)).Value = oelPurchaseCollection[i].Bonus;
                //cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Bonus", DbType.Int64)).Value = oelPurchaseCollection[i].Bonus;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@RemainingUnits", DbType.Int64)).Value = oelPurchaseCollection[i].RemainingUnits;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelPurchaseCollection[i].UnitPrice;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelPurchaseCollection[i].Amount;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@DiscPercentage", DbType.Decimal)).Value = oelPurchaseCollection[i].Discount;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@DiscountAmount", DbType.Decimal)).Value = oelPurchaseCollection[i].DiscountAmount;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@FlatDiscount", DbType.Decimal)).Value = oelPurchaseCollection[i].FlatDiscount;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@NetAmount", DbType.Decimal)).Value = oelPurchaseCollection[i].NetAmount;
                cmdPurchaseDetail.ExecuteNonQuery();
                cmdPurchaseDetail.Parameters.Clear();

            }
            return true;
        }        
        public bool InsertWorkPurchaseDetail(List<VoucherDetailEL> oelPurchaseCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdPurchaseDetail = new SqlCommand("[Transactions].[Proc_CreatePurchaseWorkDetail]", objConn);
            cmdPurchaseDetail.CommandType = CommandType.StoredProcedure;
            cmdPurchaseDetail.Transaction = objTran;
            for (int i = 0; i < oelPurchaseCollection.Count; i++)
            {
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelPurchaseCollection[i].IdVoucherDetail;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelPurchaseCollection[i].IdVoucher;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelPurchaseCollection[i].AccountNo;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelPurchaseCollection[i].Seq;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Discription", DbType.Int32)).Value = oelPurchaseCollection[i].Description;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelPurchaseCollection[i].Amount;
                cmdPurchaseDetail.ExecuteNonQuery();
                cmdPurchaseDetail.Parameters.Clear();

            }
            return true;
        }
        public bool UpdateWorkPurchaseDetail(List<VoucherDetailEL> oelPurchaseCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdPurchaseDetail = new SqlCommand("[Transactions].[Proc_UpdatePurchaseWorkDetail]", objConn);
            cmdPurchaseDetail.CommandType = CommandType.StoredProcedure;
            cmdPurchaseDetail.Transaction = objTran;
            for (int i = 0; i < oelPurchaseCollection.Count; i++)
            {
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelPurchaseCollection[i].IdVoucherDetail;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelPurchaseCollection[i].IdVoucher;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelPurchaseCollection[i].AccountNo;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelPurchaseCollection[i].Seq;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Discription", DbType.Int32)).Value = oelPurchaseCollection[i].Description;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelPurchaseCollection[i].Amount;
                cmdPurchaseDetail.ExecuteNonQuery();
                cmdPurchaseDetail.Parameters.Clear();

            }
            return true;
        }
        public bool InsertPurchaseReturnDetail(List<VoucherDetailEL> oelPurchaseCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdPurchaseDetail = new SqlCommand("[Transactions].[Proc_CreatePurchaseReturnDetail]", objConn);
            cmdPurchaseDetail.CommandType = CommandType.StoredProcedure;
            cmdPurchaseDetail.Transaction = objTran;
            for (int i = 0; i < oelPurchaseCollection.Count; i++)
            {
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelPurchaseCollection[i].IdVoucherDetail;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelPurchaseCollection[i].IdVoucher;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelPurchaseCollection[i].Seq;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelPurchaseCollection[i].IdItem;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelPurchaseCollection[i].Discription;
                //cmdPurchaseDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelPurchaseCollection[i].BatchNo;
                //cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Expiry", DbType.String)).Value = oelPurchaseCollection[i].Expiry;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Units", DbType.Int64)).Value = oelPurchaseCollection[i].Units;
                //cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Bonus", DbType.Int64)).Value = oelPurchaseCollection[i].Bonus;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelPurchaseCollection[i].UnitPrice;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Disc", DbType.Decimal)).Value = oelPurchaseCollection[i].Discount;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelPurchaseCollection[i].Amount;
                cmdPurchaseDetail.ExecuteNonQuery();
                cmdPurchaseDetail.Parameters.Clear();

            }
            return true;
        }
        public static bool UpdatePurchaseDetail(PurchaseDetailEL oelPurchaseDetail, SqlConnection oConn)
        {
            using (SqlCommand cmdPurchaseDetail = new SqlCommand("sp_updatePurchaseDetail", oConn))
            {
                cmdPurchaseDetail.CommandType = CommandType.StoredProcedure;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelPurchaseDetail.VoucherNo;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelPurchaseDetail.Seq;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@ItemNo", DbType.String)).Value = oelPurchaseDetail.ItemNo;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@ItemName", DbType.String)).Value = oelPurchaseDetail.ItemName;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelPurchaseDetail.Discription;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelPurchaseDetail.BatchNo;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Qty", DbType.Decimal)).Value = oelPurchaseDetail.Units;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelPurchaseDetail.UnitPrice;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelPurchaseDetail.Amount;
                cmdPurchaseDetail.ExecuteNonQuery();
                cmdPurchaseDetail.Parameters.Clear();
                return true;

            }
        }
        public bool UpdatePurchaseDetail(List<VoucherDetailEL> oelPurchaseCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdPurchaseDetail = new SqlCommand();
            cmdPurchaseDetail.CommandType = CommandType.StoredProcedure;
            cmdPurchaseDetail.Connection = objConn;
            cmdPurchaseDetail.Transaction = objTran;
            for (int i = 0; i < oelPurchaseCollection.Count; i++)
            {
                if (oelPurchaseCollection[i].IsNew)
                {
                    cmdPurchaseDetail.CommandText = "[Transactions].[Proc_CreatePurchaseDetail]";
                }
                else
                {
                    cmdPurchaseDetail.CommandText = "[Transactions].[Proc_UpdatePurchaseDetail]";
                }
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelPurchaseCollection[i].IdVoucherDetail;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelPurchaseCollection[i].IdVoucher;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelPurchaseCollection[i].Seq;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelPurchaseCollection[i].IdItem;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelPurchaseCollection[i].Discription;
                //cmdPurchaseDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelPurchaseCollection[i].BatchNo;
                //cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Expiry", DbType.String)).Value = oelPurchaseCollection[i].Expiry;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Units", DbType.Decimal)).Value = oelPurchaseCollection[i].Units;
                //cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Bonus", DbType.Int64)).Value = oelPurchaseCollection[i].Bonus;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@BonusUnits", DbType.Int64)).Value = oelPurchaseCollection[i].Bonus;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@RemainingUnits", DbType.Int32)).Value = oelPurchaseCollection[i].RemainingUnits;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelPurchaseCollection[i].UnitPrice;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelPurchaseCollection[i].Amount;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@DiscPercentage", DbType.Decimal)).Value = oelPurchaseCollection[i].Discount;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@DiscountAmount", DbType.Decimal)).Value = oelPurchaseCollection[i].DiscountAmount;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@FlatDiscount", DbType.Decimal)).Value = oelPurchaseCollection[i].FlatDiscount;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@NetAmount", DbType.Decimal)).Value = oelPurchaseCollection[i].NetAmount;
                cmdPurchaseDetail.ExecuteNonQuery();
                cmdPurchaseDetail.Parameters.Clear();
            }
            return true;
        }
        public bool InsertPurchaseOrderDetail(List<VoucherDetailEL> oelPurchaseCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdPurchaseDetail = new SqlCommand("[Transactions].[Proc_CreatePurchaseOrderDetail]", objConn);
            cmdPurchaseDetail.CommandType = CommandType.StoredProcedure;
            cmdPurchaseDetail.Transaction = objTran;
            for (int i = 0; i < oelPurchaseCollection.Count; i++)
            {
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelPurchaseCollection[i].IdVoucherDetail;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelPurchaseCollection[i].IdVoucher;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelPurchaseCollection[i].Seq;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelPurchaseCollection[i].IdItem;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdSize", DbType.Guid)).Value = oelPurchaseCollection[i].IdSize;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelPurchaseCollection[i].Discription;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Units", DbType.Decimal)).Value = oelPurchaseCollection[i].Units;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelPurchaseCollection[i].UnitPrice;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelPurchaseCollection[i].Amount;
                cmdPurchaseDetail.ExecuteNonQuery();
                cmdPurchaseDetail.Parameters.Clear();

            }
            return true;
        }
        public bool UpdatePurchaseOrderDetail(List<VoucherDetailEL> oelPurchaseOrderCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdPurchaseDetail = new SqlCommand();
            cmdPurchaseDetail.CommandType = CommandType.StoredProcedure;
            cmdPurchaseDetail.Connection = objConn;
            cmdPurchaseDetail.Transaction = objTran;
            for (int i = 0; i < oelPurchaseOrderCollection.Count; i++)
            {
                if (oelPurchaseOrderCollection[i].IsNew)
                {
                    cmdPurchaseDetail.CommandText = "[Transactions].[Proc_CreatePurchaseOrderDetail]";
                }
                else
                {
                    cmdPurchaseDetail.CommandText = "[Transactions].[Proc_UpdatePurchaseOrderDetail]";
                }
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelPurchaseOrderCollection[i].IdVoucherDetail;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelPurchaseOrderCollection[i].IdVoucher;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelPurchaseOrderCollection[i].Seq;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelPurchaseOrderCollection[i].IdItem;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdSize", DbType.Guid)).Value = oelPurchaseOrderCollection[i].IdSize;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelPurchaseOrderCollection[i].Discription;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Units", DbType.Decimal)).Value = oelPurchaseOrderCollection[i].Units;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelPurchaseOrderCollection[i].UnitPrice;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelPurchaseOrderCollection[i].Amount;
                cmdPurchaseDetail.ExecuteNonQuery();
                cmdPurchaseDetail.Parameters.Clear();
            }
            return true;
        }
        public bool UpdatePurchaseReturnDetail(List<VoucherDetailEL> oelPurchaseCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdPurchaseDetail = new SqlCommand();
            cmdPurchaseDetail.CommandType = CommandType.StoredProcedure;
            cmdPurchaseDetail.Connection = objConn;
            cmdPurchaseDetail.Transaction = objTran;
            for (int i = 0; i < oelPurchaseCollection.Count; i++)
            {
                if (oelPurchaseCollection[i].IsNew)
                {
                    cmdPurchaseDetail.CommandText = "[Transactions].[Proc_CreatePurchaseReturnDetail]";
                }
                else
                {
                    cmdPurchaseDetail.CommandText = "[Transactions].[Proc_UpdatePurchaseReturnDetail]";
                }
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelPurchaseCollection[i].IdVoucherDetail;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelPurchaseCollection[i].IdVoucher;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelPurchaseCollection[i].Seq;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelPurchaseCollection[i].IdItem;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelPurchaseCollection[i].Discription;
                //cmdPurchaseDetail.Parameters.Add(new SqlParameter("@BatchNo", DbType.String)).Value = oelPurchaseCollection[i].BatchNo;
                //cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Expiry", DbType.String)).Value = oelPurchaseCollection[i].Expiry;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Units", DbType.Int64)).Value = oelPurchaseCollection[i].Units;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Bonus", DbType.Int64)).Value = oelPurchaseCollection[i].Bonus;
                //cmdPurchaseDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelPurchaseCollection[i].UnitPrice;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Disc", DbType.Decimal)).Value = oelPurchaseCollection[i].Discount;
                cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelPurchaseCollection[i].Amount;
                cmdPurchaseDetail.ExecuteNonQuery();
                cmdPurchaseDetail.Parameters.Clear();
            }
            return true;
        }
        public bool InsertPurchaseTransactionsDetail(List<VoucherDetailEL> oelDetailCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdVoucherDetail = new SqlCommand("[Transactions].[Proc_CreatePurchaseTransactionsDetails]", objConn);
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
        public bool UpdatePurchaseTransactionsDetail(List<VoucherDetailEL> oelDetailCollection, SqlConnection objConn, SqlTransaction objTran)
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
                    cmdVoucherDetail.CommandText = "[Transactions].[Proc_CreatePurchaseTransactionsDetails]";
                }
                else
                {
                    cmdVoucherDetail.CommandText = "[Transactions].[Proc_UpdatePurchaseTransactionsDetails]";
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
        public List<VoucherDetailEL> GetPurchaseOrderDetailByPONumber(Guid IdCompany, Guid IdVoucher, Int64 VoucherNo, SqlConnection objConn)
        {
            List<VoucherDetailEL> oelPOCollection = new List<VoucherDetailEL>();
            using (SqlCommand cmdTransaction = new SqlCommand("[Transactions].[Proc_GetPurchaseOrderDetailByPONumber]", objConn))
            {
                cmdTransaction.CommandType = CommandType.StoredProcedure;
                cmdTransaction.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdTransaction.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
                cmdTransaction.Parameters.Add("@VoucherNo", SqlDbType.BigInt).Value = VoucherNo;
                objReader = cmdTransaction.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelDetail = new VoucherDetailEL();
                    oelDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    if (objReader["Size_Id"] != DBNull.Value)
                    {
                        oelDetail.IdSize = Validation.GetSafeGuid(objReader["Size_Id"]);
                    }
                    else
                    {
                        oelDetail.IdSize = Guid.Empty;
                    }
                    oelDetail.IdOrder = Validation.GetSafeGuid(objReader["Order_Id"]);
                    oelDetail.IdBrand = Validation.GetSafeGuid(objReader["Brand_Id"]);
                    oelDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelDetail.PaymentTerms = Validation.GetSafeString(objReader["PaymentTerms"]);
                    oelDetail.DeliveryTerms = Validation.GetSafeString(objReader["DeliveryTerms"]);
                    oelDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelDetail.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                    oelDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    if (objReader["VoucherDetail_Id"] != DBNull.Value)
                    {

                        oelDetail.IdVoucherDetail = Validation.GetSafeGuid(objReader["VoucherDetail_Id"].ToString());
                        oelDetail.Discription = Validation.GetSafeString(objReader["Discription"]);
                        oelDetail.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                        oelDetail.Qty = Validation.GetSafeDecimal(objReader["units"]);
                        oelDetail.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                        oelDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                        oelDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                        oelDetail.PoNumber = Validation.GetSafeString(objReader["PoNumber"]);
                    }

                    oelPOCollection.Add(oelDetail);
                }
                return oelPOCollection;
            }
        }
        public List<PurchaseDetailEL> GetSupplierPurchase(Int64 AccountNo, Guid IdCompany, SqlConnection objConn)
        {
            List<PurchaseDetailEL> list = new List<PurchaseDetailEL>();
            using (SqlCommand cmdSupplierPurchase = new SqlCommand("[Transactions].[Proc_GetSupplierPurchase]", objConn))
            {
                cmdSupplierPurchase.CommandType = CommandType.StoredProcedure;
                cmdSupplierPurchase.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSupplierPurchase.Parameters.Add("@AccountNo", SqlDbType.BigInt).Value = AccountNo;
                objReader = cmdSupplierPurchase.ExecuteReader();
                while (objReader.Read())
                {
                    PurchaseDetailEL oelPurchaseDetail = new PurchaseDetailEL();
                    oelPurchaseDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelPurchaseDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelPurchaseDetail.Units = Validation.GetSafeLong(objReader["TotalUnits"]);
                    oelPurchaseDetail.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                    oelPurchaseDetail.Amount = Validation.GetSafeDecimal(objReader["TotalPurchaseAmount"]);
                    list.Add(oelPurchaseDetail);
                }
            }
            return list;
        }
        public List<PurchaseDetailEL> GetSupplierPurchaseByDate(Int64 AccountNo, DateTime StartDate, DateTime EndDate, Guid IdCompany, SqlConnection objConn)
        {
            List<PurchaseDetailEL> list = new List<PurchaseDetailEL>();
            using (SqlCommand cmdSupplierPurchase = new SqlCommand("[Transactions].[Proc_GetSupplierPurchaseByDate]", objConn))
            {
                cmdSupplierPurchase.CommandType = CommandType.StoredProcedure;
                cmdSupplierPurchase.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSupplierPurchase.Parameters.Add("@AccountNo", SqlDbType.BigInt).Value = AccountNo;
                cmdSupplierPurchase.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdSupplierPurchase.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdSupplierPurchase.ExecuteReader();
                while (objReader.Read())
                {
                    PurchaseDetailEL oelPurchaseDetail = new PurchaseDetailEL();
                    oelPurchaseDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelPurchaseDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelPurchaseDetail.Units = Validation.GetSafeLong(objReader["TotalUnits"]);
                    oelPurchaseDetail.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                    oelPurchaseDetail.Amount = Validation.GetSafeDecimal(objReader["TotalPurchaseAmount"]);
                    list.Add(oelPurchaseDetail);
                }
            }
            return list;
        }
        public List<PurchaseDetailEL> GetProductsTotalPurchase(Guid IdCompany, SqlConnection objConn)
        {
            List<PurchaseDetailEL> list = new List<PurchaseDetailEL>();
            using (SqlCommand cmdProductPurchase = new SqlCommand("[Transactions].[Proc_GetProductsTotalPurchase]", objConn))
            {
                cmdProductPurchase.CommandType = CommandType.StoredProcedure;
                cmdProductPurchase.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                objReader = cmdProductPurchase.ExecuteReader();
                while (objReader.Read())
                {
                    PurchaseDetailEL oelPurchaseDetail = new PurchaseDetailEL();
                    oelPurchaseDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelPurchaseDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelPurchaseDetail.Units = Validation.GetSafeLong(objReader["TotalUnits"]);
                    oelPurchaseDetail.Amount = Validation.GetSafeDecimal(objReader["TotalPurchaseAmount"]);
                    list.Add(oelPurchaseDetail);
                }
            }
            return list;
        }
        public List<PurchaseDetailEL> GetProductsTotalPurchaseByDate(DateTime StartDate, DateTime EndDate, Guid IdCompany, SqlConnection objConn)
        {
            List<PurchaseDetailEL> list = new List<PurchaseDetailEL>();
            using (SqlCommand cmdProductPurchase = new SqlCommand("[Transactions].[Proc_GetProductsTotalPurchaseByDate]", objConn))
            {
                cmdProductPurchase.CommandType = CommandType.StoredProcedure;
                cmdProductPurchase.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdProductPurchase.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdProductPurchase.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdProductPurchase.ExecuteReader();
                while (objReader.Read())
                {
                    PurchaseDetailEL oelPurchaseDetail = new PurchaseDetailEL();
                    oelPurchaseDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelPurchaseDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelPurchaseDetail.Units = Validation.GetSafeLong(objReader["TotalUnits"]);
                    oelPurchaseDetail.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                    oelPurchaseDetail.Amount = Validation.GetSafeDecimal(objReader["TotalPurchaseAmount"]);
                    list.Add(oelPurchaseDetail);
                }
            }
            return list;
        }
        public List<PurchaseDetailEL> GetProductDetailPurchase(Int64 AccountNo, Guid IdCompany, SqlConnection objConn)
        {
            List<PurchaseDetailEL> list = new List<PurchaseDetailEL>();
            using (SqlCommand cmdProductPurchase = new SqlCommand("[Transactions].[Proc_GetProductDetailPurchase]", objConn))
            {
                cmdProductPurchase.CommandType = CommandType.StoredProcedure;
                cmdProductPurchase.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdProductPurchase.Parameters.Add("@AccountNo", SqlDbType.BigInt).Value = AccountNo;
                objReader = cmdProductPurchase.ExecuteReader();
                while (objReader.Read())
                {
                    PurchaseDetailEL oelPurchaseDetail = new PurchaseDetailEL();
                    oelPurchaseDetail.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelPurchaseDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelPurchaseDetail.Units = Validation.GetSafeLong(objReader["Units"]);
                    oelPurchaseDetail.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                    oelPurchaseDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    if (objReader["SupplierName"] != null)
                    {
                        oelPurchaseDetail.AccountName = Validation.GetSafeString(objReader["SupplierName"]);
                    }
                    list.Add(oelPurchaseDetail);
                }
            }
            return list;
        }
        public List<PurchaseDetailEL> GetProductDetailPurchaseByDate(Int64 AccountNo, DateTime StartDate, DateTime EndDate, Guid IdCompany, SqlConnection objConn)
        {
            List<PurchaseDetailEL> list = new List<PurchaseDetailEL>();
            using (SqlCommand cmdProductPurchase = new SqlCommand("[Transactions].[Proc_GetProductDetailPurchaseByDate]", objConn))
            {
                cmdProductPurchase.CommandType = CommandType.StoredProcedure;

                cmdProductPurchase.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdProductPurchase.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdProductPurchase.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                cmdProductPurchase.Parameters.Add("@AccountNo", SqlDbType.BigInt).Value = AccountNo;
                objReader = cmdProductPurchase.ExecuteReader();
                while (objReader.Read())
                {
                    PurchaseDetailEL oelPurchaseDetail = new PurchaseDetailEL();
                    oelPurchaseDetail.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelPurchaseDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelPurchaseDetail.Units = Validation.GetSafeLong(objReader["Units"]);
                    oelPurchaseDetail.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                    oelPurchaseDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    oelPurchaseDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    list.Add(oelPurchaseDetail);
                }
            }
            return list;
        }
    }
}
