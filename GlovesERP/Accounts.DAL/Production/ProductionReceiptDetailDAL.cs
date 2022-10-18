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
    public class ProductionReceiptDetailDAL
    {
        public bool InsertProductionReceiptDetail(List<VoucherDetailEL> oelProcessCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdProductionReceiptDetail = new SqlCommand("[Production].[Proc_CreateProductionReceiptDetail]", objConn);
            cmdProductionReceiptDetail.CommandType = CommandType.StoredProcedure;
            cmdProductionReceiptDetail.Transaction = objTran;
            for (int i = 0; i < oelProcessCollection.Count; i++)
            {
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@IdProductionReceiptDetail", DbType.Guid)).Value = oelProcessCollection[i].IdVoucherDetail;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@IdProductionReceipt", DbType.Int64)).Value = oelProcessCollection[i].IdVoucher;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelProcessCollection[i].Seq;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@Description", DbType.Int32)).Value = oelProcessCollection[i].Description;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelProcessCollection[i].IdItem;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelProcessCollection[i].IdBrand;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@Quantity", DbType.Int64)).Value = oelProcessCollection[i].Units;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelProcessCollection[i].UnitPrice;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelProcessCollection[i].Amount;
                cmdProductionReceiptDetail.ExecuteNonQuery();
                cmdProductionReceiptDetail.Parameters.Clear();

            }
            return true;
        }
        public bool UpdateProductionReceiptDetail(List<VoucherDetailEL> oelProductionCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdProductionReceiptDetail = new SqlCommand();
            cmdProductionReceiptDetail.CommandType = CommandType.StoredProcedure;
            cmdProductionReceiptDetail.Connection = objConn;
            cmdProductionReceiptDetail.Transaction = objTran;
            for (int i = 0; i < oelProductionCollection.Count; i++)
            {
                if (oelProductionCollection[i].IsNew)
                {
                    cmdProductionReceiptDetail.CommandText = "[Production].[Proc_CreateProductionReceiptDetail]";
                }
                else
                {
                    cmdProductionReceiptDetail.CommandText = "[Production].[Proc_UpdateProductionReceiptDetail]";
                }
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@IdProductionReceiptDetail", DbType.Guid)).Value = oelProductionCollection[i].IdVoucherDetail;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@IdProductionReceipt", DbType.Int64)).Value = oelProductionCollection[i].IdVoucher;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelProductionCollection[i].Seq;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@Description", DbType.Int32)).Value = oelProductionCollection[i].Description;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelProductionCollection[i].IdItem;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelProductionCollection[i].IdAccount;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@Quantity", DbType.Int64)).Value = oelProductionCollection[i].Units;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelProductionCollection[i].UnitPrice;
                cmdProductionReceiptDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelProductionCollection[i].Amount;

                cmdProductionReceiptDetail.ExecuteNonQuery();
                cmdProductionReceiptDetail.Parameters.Clear();
            }
            return true;
        }
        public bool InsertProductionWastageDetail(List<VoucherDetailEL> oelWastageCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdWastage = new SqlCommand("[Production].[Proc_CreateProductionInventoryWastageDetail]", objConn);
            cmdWastage.CommandType = CommandType.StoredProcedure;
            cmdWastage.Transaction = objTran;
            for (int i = 0; i < oelWastageCollection.Count; i++)
            {
                cmdWastage.Parameters.Add(new SqlParameter("@IdProductionWastageDetail", DbType.Guid)).Value = oelWastageCollection[i].IdVoucherDetail;
                cmdWastage.Parameters.Add(new SqlParameter("@IdProductionReceipt", DbType.Int64)).Value = oelWastageCollection[i].IdVoucher;
                cmdWastage.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelWastageCollection[i].Seq;
                cmdWastage.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelWastageCollection[i].IdItem;
                cmdWastage.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelWastageCollection[i].IdAccount;
                cmdWastage.Parameters.Add(new SqlParameter("@Quantity", DbType.Int64)).Value = oelWastageCollection[i].Units;
                cmdWastage.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelWastageCollection[i].UnitPrice;
                cmdWastage.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelWastageCollection[i].Amount;
                cmdWastage.ExecuteNonQuery();
                cmdWastage.Parameters.Clear();

            }
            return true;
        }
        public bool UpdateProductionWastageDetail(List<VoucherDetailEL> oelWastageCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdWastage = new SqlCommand();
            cmdWastage.CommandType = CommandType.StoredProcedure;
            cmdWastage.Connection = objConn;
            cmdWastage.Transaction = objTran;
            for (int i = 0; i < oelWastageCollection.Count; i++)
            {
                if (oelWastageCollection[i].IsNew)
                {
                    cmdWastage.CommandText = "[Production].[Proc_CreateProductionInventoryWastageDetail]";
                }
                else
                {
                    cmdWastage.CommandText = "[Production].[Proc_UpdateProductionInventoryWastageDetail]";
                }
                cmdWastage.Parameters.Add(new SqlParameter("@IdProductionWastageDetail", DbType.Guid)).Value = oelWastageCollection[i].IdVoucherDetail;
                cmdWastage.Parameters.Add(new SqlParameter("@IdProductionReceipt", DbType.Int64)).Value = oelWastageCollection[i].IdVoucher;
                cmdWastage.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelWastageCollection[i].Seq;
                cmdWastage.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelWastageCollection[i].IdItem;
                cmdWastage.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelWastageCollection[i].IdAccount;
                cmdWastage.Parameters.Add(new SqlParameter("@Quantity", DbType.Int64)).Value = oelWastageCollection[i].Units;
                cmdWastage.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelWastageCollection[i].UnitPrice;
                cmdWastage.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelWastageCollection[i].Amount;

                cmdWastage.ExecuteNonQuery();
                cmdWastage.Parameters.Clear();
            }
            return true;
        }
    }
}
