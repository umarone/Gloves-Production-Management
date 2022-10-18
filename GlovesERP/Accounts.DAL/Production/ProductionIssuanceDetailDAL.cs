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
    public class ProductionIssuanceDetailDAL
    {
        IDataReader objReader;
        public bool InsertProductionIssuanceDetail(List<VoucherDetailEL> oelProcessCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdProductionDetail = new SqlCommand("[Production].[Proc_CreateInventoryIssuanceDetail]", objConn);
            cmdProductionDetail.CommandType = CommandType.StoredProcedure;
            cmdProductionDetail.Transaction = objTran;
            for (int i = 0; i < oelProcessCollection.Count; i++)
            {
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdInventoryIssuanceDetail", DbType.Guid)).Value = oelProcessCollection[i].IdVoucherDetail;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdInventoryIssuance", DbType.Int64)).Value = oelProcessCollection[i].IdVoucher;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelProcessCollection[i].IdItem;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = oelProcessCollection[i].IdArticle;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelProcessCollection[i].IdBrand;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdSize", DbType.Guid)).Value = oelProcessCollection[i].IdSize;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdColor", DbType.Guid)).Value = oelProcessCollection[i].IdColor;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Width", DbType.String)).Value = oelProcessCollection[i].IssuanceWidth;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int64)).Value = oelProcessCollection[i].Seq;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IssuanceDept", DbType.Int64)).Value = oelProcessCollection[i].IssuanceDept;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@ExtraAvailableQuantity", DbType.Decimal)).Value = oelProcessCollection[i].ExtraAvailableQuantity;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IssuedExtraQuantity", DbType.Decimal)).Value = oelProcessCollection[i].IssuedExtraQuantity;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Quantity", DbType.Int64)).Value = oelProcessCollection[i].Units;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelProcessCollection[i].UnitPrice;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelProcessCollection[i].Amount;
                cmdProductionDetail.ExecuteNonQuery();
                cmdProductionDetail.Parameters.Clear();

            }
            return true;
        }
        public bool UpdateProductionIssanceDetail(List<VoucherDetailEL> oelProcessCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdProductionDetail = new SqlCommand();
            cmdProductionDetail.CommandType = CommandType.StoredProcedure;
            cmdProductionDetail.Connection = objConn;
            cmdProductionDetail.Transaction = objTran;
            for (int i = 0; i < oelProcessCollection.Count; i++)
            {
                if (oelProcessCollection[i].IsNew)
                {
                    cmdProductionDetail.CommandText = "[Production].[Proc_CreateInventoryIssuanceDetail]";
                }
                else
                {
                    cmdProductionDetail.CommandText = "[Production].[Proc_UpdateInventoryIssuanceDetail]";
                }
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdInventoryIssuanceDetail", DbType.Guid)).Value = oelProcessCollection[i].IdVoucherDetail;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdInventoryIssuance", DbType.Int64)).Value = oelProcessCollection[i].IdVoucher;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelProcessCollection[i].IdItem;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = oelProcessCollection[i].IdArticle;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelProcessCollection[i].IdBrand;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdSize", DbType.Guid)).Value = oelProcessCollection[i].IdSize;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdColor", DbType.Guid)).Value = oelProcessCollection[i].IdColor;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Width", DbType.String)).Value = oelProcessCollection[i].IssuanceWidth;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int64)).Value = oelProcessCollection[i].Seq;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IssuanceDept", DbType.Int64)).Value = oelProcessCollection[i].IssuanceDept;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@ExtraAvailableQuantity", DbType.Decimal)).Value = oelProcessCollection[i].ExtraAvailableQuantity;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IssuedExtraQuantity", DbType.Decimal)).Value = oelProcessCollection[i].IssuedExtraQuantity;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Quantity", DbType.Int64)).Value = oelProcessCollection[i].Units;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelProcessCollection[i].UnitPrice;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelProcessCollection[i].Amount;
                cmdProductionDetail.ExecuteNonQuery();
                cmdProductionDetail.Parameters.Clear();
            }
            return true;
        }
        public bool InsertProductionCuffTalliCuttingIssuanceDetail(List<VoucherDetailEL> oelProcessCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdProductionDetail = new SqlCommand("[Production].[Proc_CreateCuffTaliInventoryIssuanceDetail]", objConn);
            cmdProductionDetail.CommandType = CommandType.StoredProcedure;
            cmdProductionDetail.Transaction = objTran;
            for (int i = 0; i < oelProcessCollection.Count; i++)
            {
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdInventoryIssuanceDetail", DbType.Guid)).Value = oelProcessCollection[i].IdVoucherDetail;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdInventoryIssuance", DbType.Int64)).Value = oelProcessCollection[i].IdVoucher;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelProcessCollection[i].IdItem;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@SeqNo", DbType.Int32)).Value = oelProcessCollection[i].Seq;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@PackingSize", DbType.String)).Value = oelProcessCollection[i].PackingSize;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Quantity", DbType.Int32)).Value = oelProcessCollection[i].Qty;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@MeterYardQty", DbType.Decimal)).Value = oelProcessCollection[i].MeterYardQty;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@BariSize", DbType.Decimal)).Value = oelProcessCollection[i].BariSize;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@TotalBari", DbType.Decimal)).Value = oelProcessCollection[i].TotalBari;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@TaliBariWidth", DbType.Decimal)).Value = oelProcessCollection[i].TalliBariWidth;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@TaliBariSize", DbType.Decimal)).Value = oelProcessCollection[i].TalliBariSize;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@CalculatedQty", DbType.Decimal)).Value = oelProcessCollection[i].CalculatedQty;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Total", DbType.Decimal)).Value = oelProcessCollection[i].TotalCuffs;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Dozen", DbType.Decimal)).Value = oelProcessCollection[i].Dozen;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@EstimatedQuantity", DbType.Decimal)).Value = oelProcessCollection[i].EstimatedQty;
                cmdProductionDetail.ExecuteNonQuery();
                cmdProductionDetail.Parameters.Clear();

            }
            return true;
        }
        public bool UpdateProductionCuffTalliCuttingIssanceDetail(List<VoucherDetailEL> oelProcessCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdProductionDetail = new SqlCommand();
            cmdProductionDetail.CommandType = CommandType.StoredProcedure;
            cmdProductionDetail.Connection = objConn;
            cmdProductionDetail.Transaction = objTran;
            for (int i = 0; i < oelProcessCollection.Count; i++)
            {
                if (oelProcessCollection[i].IsNew)
                {
                    cmdProductionDetail.CommandText = "[Production].[Proc_CreateCuffTaliInventoryIssuanceDetail]";
                }
                else
                {
                    cmdProductionDetail.CommandText = "[Production].[Proc_UpdateCuffTaliInventoryIssuanceDetail]";
                }
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdInventoryIssuanceDetail", DbType.Guid)).Value = oelProcessCollection[i].IdVoucherDetail;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdInventoryIssuance", DbType.Int64)).Value = oelProcessCollection[i].IdVoucher;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelProcessCollection[i].IdItem;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@SeqNo", DbType.Int32)).Value = oelProcessCollection[i].Seq;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@PackingSize", DbType.String)).Value = oelProcessCollection[i].PackingSize;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Quantity", DbType.Int32)).Value = oelProcessCollection[i].Qty;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@MeterYardQty", DbType.Decimal)).Value = oelProcessCollection[i].MeterYardQty;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@BariSize", DbType.Decimal)).Value = oelProcessCollection[i].BariSize;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@TotalBari", DbType.Decimal)).Value = oelProcessCollection[i].TotalBari;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@TalliBariWidth", DbType.Decimal)).Value = oelProcessCollection[i].TalliBariWidth;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@TalliBariSize", DbType.Decimal)).Value = oelProcessCollection[i].TalliBariSize;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@CalculatedQty", DbType.Decimal)).Value = oelProcessCollection[i].CalculatedQty;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Total", DbType.Decimal)).Value = oelProcessCollection[i].TotalCuffs;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Dozen", DbType.Decimal)).Value = oelProcessCollection[i].Dozen;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@EstimatedQuantity", DbType.Decimal)).Value = oelProcessCollection[i].EstimatedQty;
                cmdProductionDetail.ExecuteNonQuery();
                cmdProductionDetail.Parameters.Clear();
            }
            return true;
        }
        public bool InsertProductionIssuanceMaterialDetail(List<VoucherDetailEL> oelProcessCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdProductionDetail = new SqlCommand("[Production].[Proc_CreateMaterials]", objConn);
            cmdProductionDetail.CommandType = CommandType.StoredProcedure;
            cmdProductionDetail.Transaction = objTran;
            for (int i = 0; i < oelProcessCollection.Count; i++)
            {
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelProcessCollection[i].IdVoucherDetail;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelProcessCollection[i].IdVoucher;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelProcessCollection[i].Seq;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelProcessCollection[i].IdAccount;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Units", DbType.Int64)).Value = oelProcessCollection[i].Units;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelProcessCollection[i].UnitPrice;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelProcessCollection[i].Amount;
                cmdProductionDetail.ExecuteNonQuery();
                cmdProductionDetail.Parameters.Clear();

            }
            return true;
        }
        public bool UpdateProductionIssuanceMaterialDetail(List<VoucherDetailEL> oelProcessCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdProductionDetail = new SqlCommand("[Production].[Proc_UpdateMaterials]", objConn);
            cmdProductionDetail.CommandType = CommandType.StoredProcedure;
            cmdProductionDetail.Transaction = objTran;
            for (int i = 0; i < oelProcessCollection.Count; i++)
            {
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelProcessCollection[i].IdVoucherDetail;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelProcessCollection[i].IdVoucher;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelProcessCollection[i].Seq;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelProcessCollection[i].IdAccount;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Units", DbType.Int64)).Value = oelProcessCollection[i].Units;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelProcessCollection[i].UnitPrice;
                cmdProductionDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelProcessCollection[i].Amount;
                cmdProductionDetail.ExecuteNonQuery();
                cmdProductionDetail.Parameters.Clear();

            }
            return true;
        }
        public bool DeleteProductionIssuanceMaterialDetail(Guid Id, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdProductionDetail = new SqlCommand("[Production].[Proc_DeleteMaterial]", objConn);
            cmdProductionDetail.CommandType = CommandType.StoredProcedure;
            cmdProductionDetail.Transaction = objTran;

            cmdProductionDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = Id;

            cmdProductionDetail.ExecuteNonQuery();

            return true;
        }
        public List<VoucherDetailEL> GetProductionStockIssuanceByNo(Int64 IssuanceNo, Guid IdCompany, int IssuanceType, int ProductionType, Guid IdProductionIssuance, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetProductionStockIssuance]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdProduction.Parameters.Add(new SqlParameter("@IdProductionIssuance", DbType.Guid)).Value = IdProductionIssuance;
                //cmdProduction.Parameters.Add(new SqlParameter("@IssuanceNo", DbType.Int64)).Value = IssuanceNo;
                //cmdProduction.Parameters.Add("@IssuanceType", SqlDbType.Int).Value = IssuanceType;
                //cmdProduction.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
                objReader = cmdProduction.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelIssuanceDetail = new VoucherDetailEL();
                    oelIssuanceDetail.IdVoucher = new Guid(objReader["ProductionIssuance_Id"].ToString());
                    oelIssuanceDetail.IdVoucherDetail = Validation.GetSafeGuid(objReader["InventoryIssuanceDetail_Id"]);
                    oelIssuanceDetail.VoucherNo = Validation.GetSafeLong(objReader["IssuanceNo"]);
                    oelIssuanceDetail.IdUser = Validation.GetSafeGuid(objReader["User_Id"]);
                    oelIssuanceDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelIssuanceDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelIssuanceDetail.VDate = Validation.GetSafeDateTime(objReader["IssuanceDate"]);

                    oelIssuanceDetail.IdBrand = Validation.GetSafeGuid(objReader["Brand_Id"]);
                    oelIssuanceDetail.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                    oelIssuanceDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelIssuanceDetail.ItemType = Validation.GetSafeInteger(objReader["ItemType"]);
                    oelIssuanceDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelIssuanceDetail.IdArticle = Validation.GetSafeGuid(objReader["Article_Id"]);
                    oelIssuanceDetail.ArticleName = Validation.GetSafeString(objReader["ArticleName"]);
                    oelIssuanceDetail.IdSubArticle = Validation.GetSafeGuid(objReader["IdSubArticle"]);
                    oelIssuanceDetail.SubArticle = Validation.GetSafeString(objReader["SubArticle"]);
                    oelIssuanceDetail.IdSize = Validation.GetSafeGuid(objReader["Size_Id"]);
                    oelIssuanceDetail.IdColor = Validation.GetSafeGuid(objReader["Color_Id"]);
                    oelIssuanceDetail.IssuanceWidth = Validation.GetSafeString(objReader["Width"]);
                    oelIssuanceDetail.IssuanceDept = Validation.GetSafeLong(objReader["IssuanceDept"]);
                    oelIssuanceDetail.ExtraAvailableQuantity = Validation.GetSafeLong(objReader["ExtraAvailableQuantity"]);
                    oelIssuanceDetail.IssuedExtraQuantity = Validation.GetSafeLong(objReader["IssuedExtraQuantity"]);
                    oelIssuanceDetail.Qty = Validation.GetSafeLong(objReader["Quantity"]);
                    oelIssuanceDetail.PackingSize = Validation.GetSafeString(objReader["packingsize"]);
                    oelIssuanceDetail.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                    oelIssuanceDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelIssuanceDetail);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetProductionStockIssuanceDetailForTalliBariByNo(Int64 IssuanceNo, Guid IdCompany, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetProductionStockIssuanceDetailForTalliBari]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdProduction.Parameters.Add(new SqlParameter("@IssuanceNo", DbType.Int64)).Value = IssuanceNo;
                objReader = cmdProduction.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelIssuanceDetail = new VoucherDetailEL();
                    oelIssuanceDetail.IdVoucher = new Guid(objReader["ProductionIssuance_Id"].ToString());
                    oelIssuanceDetail.IdVoucherDetail = Validation.GetSafeGuid(objReader["InventoryIssuanceDetail_Id"]);
                    oelIssuanceDetail.IdDepartment = Validation.GetSafeGuid(objReader["Department_Id"]);
                    oelIssuanceDetail.VoucherNo = Validation.GetSafeLong(objReader["IssuanceNo"]);
                    oelIssuanceDetail.IdUser = Validation.GetSafeGuid(objReader["User_Id"]);
                    oelIssuanceDetail.Description = Validation.GetSafeString(objReader["Description"]);
                    oelIssuanceDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelIssuanceDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelIssuanceDetail.ProcessType = Validation.GetSafeInteger(objReader["IssuanceType"]);
                    oelIssuanceDetail.CreatedDateTime = Validation.GetSafeDateTime(objReader["IssuanceDate"]);

                    oelIssuanceDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelIssuanceDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelIssuanceDetail.Seq = Validation.GetSafeInteger(objReader["SeqNo"]);
                    oelIssuanceDetail.PackingSize = Validation.GetSafeString(objReader["packingsize"]);
                    oelIssuanceDetail.Qty = Validation.GetSafeLong(objReader["Quantity"]);
                    oelIssuanceDetail.MeterYardQty = Validation.GetSafeDecimal(objReader["MeterYardQty"]);
                    oelIssuanceDetail.BariSize = Validation.GetSafeDecimal(objReader["BariSize"]);
                    oelIssuanceDetail.TotalBari = Validation.GetSafeDecimal(objReader["TotalBari"]);
                    oelIssuanceDetail.TalliBariSize = Validation.GetSafeDecimal(objReader["TaliBariWidth"]);
                    oelIssuanceDetail.TalliBariSize = Validation.GetSafeDecimal(objReader["TaliBariSize"]);

                    oelIssuanceDetail.CalculatedQty = Validation.GetSafeDecimal(objReader["CalculatedQty"]);
                    oelIssuanceDetail.TotalCuffs = Validation.GetSafeDecimal(objReader["Total"]);
                    oelIssuanceDetail.Dozen = Validation.GetSafeDecimal(objReader["Dozen"]);
                    oelIssuanceDetail.EstimatedQty = Validation.GetSafeDecimal(objReader["EstimatedQuantity"]);


                    list.Add(oelIssuanceDetail);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetRubberingStockById(Guid IdItem, Guid IdCompany, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            SqlCommand cmdStock = new SqlCommand("[Production].[Proc_GetRubberizingStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
            cmdStock.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                VoucherDetailEL objDetail = new VoucherDetailEL();
                objDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                objDetail.AccountName = Validation.GetSafeString(objReader["ItemName"]);
                objDetail.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                objDetail.ClosingUnits = Validation.GetSafeLong(objReader["Closing"]);
                objDetail.Amount = Validation.GetSafeDecimal(objReader["RemainingBalance"]);

                list.Add(objDetail);
            }

            return list;
        }

        public List<VoucherDetailEL> GetProcessWiseWorkerReport(Guid IdCompany, string AccountNo, int OperationType, int ProductionType, string OutPutProcessName, string MaterialProcessName, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetProcessWiseWorkerReport]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdProduction.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
                //cmdProduction.Parameters.Add("@OperationType", SqlDbType.Int).Value = OperationType;
                cmdProduction.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
                cmdProduction.Parameters.Add("@OutPutprocessName", SqlDbType.VarChar).Value = OutPutProcessName;
                cmdProduction.Parameters.Add("@MaterialProcessName", SqlDbType.VarChar).Value = MaterialProcessName;
                objReader = cmdProduction.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelIssuanceDetail = new VoucherDetailEL();
                    //oelIssuanceDetail.IdVoucher = new Guid(objReader["ProductionIssuance_Id"].ToString());
                    //oelIssuanceDetail.IdVoucherDetail = Validation.GetSafeGuid(objReader["InventoryIssuanceDetail_Id"]);
                    oelIssuanceDetail.ProcessType = Validation.GetSafeInteger(objReader["IssuanceType"]);
                    //oelIssuanceDetail.VoucherNo = Validation.GetSafeLong(objReader["IssuanceNo"]);
                    //oelIssuanceDetail.IdUser = Validation.GetSafeGuid(objReader["User_Id"]);
                    oelIssuanceDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelIssuanceDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelIssuanceDetail.CreatedDateTime = Validation.GetSafeDateTime(objReader["IssuanceDate"]);
                    oelIssuanceDetail.WorkDate = Validation.GetSafeString(objReader["WorkDate"]);

                    oelIssuanceDetail.IdBrand = Validation.GetSafeGuid(objReader["Brand_Id"]);
                    oelIssuanceDetail.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                    //oelIssuanceDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelIssuanceDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    //oelIssuanceDetail.IdArticle = Validation.GetSafeGuid(objReader["Article_Id"]);
                    //oelIssuanceDetail.ArticleName = Validation.GetSafeString(objReader["ArticleName"]);
                    //oelIssuanceDetail.IdSubArticle = Validation.GetSafeGuid(objReader["IdSubArticle"]);
                    //oelIssuanceDetail.SubArticle = Validation.GetSafeString(objReader["SubArticle"]);
                    //oelIssuanceDetail.IdSize = Validation.GetSafeGuid(objReader["Size_Id"]);
                    //oelIssuanceDetail.IssuanceWidth = Validation.GetSafeString(objReader["Width"]);
                    oelIssuanceDetail.Qty = Validation.GetSafeDecimal(objReader["Quantity"]);
                    oelIssuanceDetail.PackingSize = Validation.GetSafeString(objReader["packingsize"]);
                    //oelIssuanceDetail.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                    oelIssuanceDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    //oelIssuanceDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);

                    list.Add(oelIssuanceDetail);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetProcessWiseWorkerReportByDate(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate, int OperationType, int ProductionType, string OutPutProcessName, string MaterialProcessName, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetProcessWiseWorkerReportByDate]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdProduction.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
                cmdProduction.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = StartDate;
                cmdProduction.Parameters.Add(new SqlParameter("@EndDate", DbType.Date)).Value = EndDate;
                //cmdProduction.Parameters.Add("@IssuanceType", SqlDbType.Int).Value = OperationType;
                cmdProduction.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
                cmdProduction.Parameters.Add("@OutPutprocessName", SqlDbType.VarChar).Value = OutPutProcessName;
                cmdProduction.Parameters.Add("@MaterialProcessName", SqlDbType.VarChar).Value = MaterialProcessName;
                objReader = cmdProduction.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelIssuanceDetail = new VoucherDetailEL();
                    //oelIssuanceDetail.IdVoucher = new Guid(objReader["ProductionIssuance_Id"].ToString());
                    //oelIssuanceDetail.IdVoucherDetail = Validation.GetSafeGuid(objReader["InventoryIssuanceDetail_Id"]);
                    //oelIssuanceDetail.VoucherNo = Validation.GetSafeLong(objReader["IssuanceNo"]);
                    oelIssuanceDetail.ProcessType = Validation.GetSafeInteger(objReader["IssuanceType"]);
                    //oelIssuanceDetail.IdUser = Validation.GetSafeGuid(objReader["User_Id"]);
                    oelIssuanceDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelIssuanceDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelIssuanceDetail.CreatedDateTime = Validation.GetSafeDateTime(objReader["IssuanceDate"]);
                    oelIssuanceDetail.WorkDate = Validation.GetSafeString(objReader["WorkDate"]);

                    oelIssuanceDetail.IdBrand = Validation.GetSafeGuid(objReader["Brand_Id"]);
                    //oelIssuanceDetail.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                    //oelIssuanceDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelIssuanceDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    //oelIssuanceDetail.IdArticle = Validation.GetSafeGuid(objReader["Article_Id"]);
                    //oelIssuanceDetail.ArticleName = Validation.GetSafeString(objReader["ArticleName"]);
                    //oelIssuanceDetail.IdSubArticle = Validation.GetSafeGuid(objReader["IdSubArticle"]);
                    //oelIssuanceDetail.SubArticle = Validation.GetSafeString(objReader["SubArticle"]);
                    //oelIssuanceDetail.IdSize = Validation.GetSafeGuid(objReader["Size_Id"]);
                    //oelIssuanceDetail.IssuanceWidth = Validation.GetSafeString(objReader["Width"]);
                    oelIssuanceDetail.Qty = Validation.GetSafeDecimal(objReader["Quantity"]);
                    oelIssuanceDetail.PackingSize = Validation.GetSafeString(objReader["packingsize"]);
                    //oelIssuanceDetail.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                    oelIssuanceDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    //oelIssuanceDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);

                    list.Add(oelIssuanceDetail);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetWorkInProcessReportByWorker(Guid IdArticle, int ProductionType, string AccountNo, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetWorkInProcessReportByWorker]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = IdArticle;
                cmdProduction.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
                cmdProduction.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                objReader = cmdProduction.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelIssuanceDetail = new VoucherDetailEL();

                    oelIssuanceDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelIssuanceDetail.CreatedDateTime = Validation.GetSafeDateTime(objReader["IssuanceDate"]);
                    oelIssuanceDetail.VoucherNo = Validation.GetSafeLong(objReader["IssuanceNo"]);
                    oelIssuanceDetail.StockIn = Validation.GetSafeDecimal(objReader["In"]);
                    oelIssuanceDetail.StockOut = Validation.GetSafeDecimal(objReader["Out"]);


                    list.Add(oelIssuanceDetail);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetDateWiseWorkInProcessReportByWorker(Guid IdArticle, int ProductionType, string AccountNo, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetDateWiseWorkInProcessReportByWorker]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = IdArticle;
                cmdProduction.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
                cmdProduction.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdProduction.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdProduction.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdProduction.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelIssuanceDetail = new VoucherDetailEL();

                    oelIssuanceDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelIssuanceDetail.CreatedDateTime = Validation.GetSafeDateTime(objReader["IssuanceDate"]);
                    oelIssuanceDetail.VoucherNo = Validation.GetSafeLong(objReader["IssuanceNo"]);
                    oelIssuanceDetail.StockIn = Validation.GetSafeDecimal(objReader["In"]);
                    oelIssuanceDetail.StockOut = Validation.GetSafeDecimal(objReader["Out"]);


                    list.Add(oelIssuanceDetail);
                }
            }
            return list;
        }

        public List<VoucherDetailEL> GetGlovesGarmentsWorkerFinancialReport(Int64 OperationType, string AccountNo, Guid IdCompany, int ProductionType,
            DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetGlovesGarmentsWorkersFinancialReport]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdProduction.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
                cmdProduction.Parameters.Add(new SqlParameter("@OperationType", DbType.Int64)).Value = OperationType;
                cmdProduction.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
                cmdProduction.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = StartDate;
                cmdProduction.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = EndDate;

                objReader = cmdProduction.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelIssuanceDetail = new VoucherDetailEL();
                    oelIssuanceDetail.IdVoucher = new Guid(objReader["ProductionIssuance_Id"].ToString());
                    oelIssuanceDetail.IdVoucherDetail = Validation.GetSafeGuid(objReader["InventoryIssuanceDetail_Id"]);
                    oelIssuanceDetail.VoucherNo = Validation.GetSafeLong(objReader["IssuanceNo"]);
                    oelIssuanceDetail.IdUser = Validation.GetSafeGuid(objReader["User_Id"]);
                    oelIssuanceDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelIssuanceDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelIssuanceDetail.CreatedDateTime = Validation.GetSafeDateTime(objReader["IssuanceDate"]);

                    oelIssuanceDetail.IdBrand = Validation.GetSafeGuid(objReader["Brand_Id"]);
                    oelIssuanceDetail.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                    oelIssuanceDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelIssuanceDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelIssuanceDetail.IdArticle = Validation.GetSafeGuid(objReader["Article_Id"]);
                    oelIssuanceDetail.ArticleName = Validation.GetSafeString(objReader["ArticleName"]);
                    oelIssuanceDetail.IdSubArticle = Validation.GetSafeGuid(objReader["IdSubArticle"]);
                    oelIssuanceDetail.SubArticle = Validation.GetSafeString(objReader["SubArticle"]);
                    oelIssuanceDetail.IdSize = Validation.GetSafeGuid(objReader["Size_Id"]);
                    oelIssuanceDetail.ItemSize = Validation.GetSafeString(objReader["Size"]);
                    oelIssuanceDetail.IssuanceWidth = Validation.GetSafeString(objReader["Width"]);
                    oelIssuanceDetail.Qty = Validation.GetSafeLong(objReader["Quantity"]);
                    oelIssuanceDetail.PackingSize = Validation.GetSafeString(objReader["packingsize"]);
                    oelIssuanceDetail.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                    oelIssuanceDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelIssuanceDetail);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetProcessWiseStock(int ProcessIndex, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_ProcessWiseStock]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add("@ProcessIndex", SqlDbType.Int).Value = ProcessIndex;
                objReader = cmdProduction.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelIssuanceDetail = new VoucherDetailEL();
                    oelIssuanceDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelIssuanceDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelIssuanceDetail.OpeningStock = Validation.GetSafeDecimal(objReader["Opening"]);
                    oelIssuanceDetail.StockIn = Validation.GetSafeDecimal(objReader["In"]);
                    oelIssuanceDetail.StockOut = Validation.GetSafeDecimal(objReader["Out"]);
                    oelIssuanceDetail.RemainingStock = Validation.GetSafeDecimal(objReader["Balance"]);

                    list.Add(oelIssuanceDetail);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetProcessWiseStockByItem(Guid IdItem, int ProcessIndex, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_ProcessWiseStockByItem]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
                cmdProduction.Parameters.Add("@ProcessIndex", SqlDbType.Int).Value = ProcessIndex;
                objReader = cmdProduction.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelIssuanceDetail = new VoucherDetailEL();
                    oelIssuanceDetail.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelIssuanceDetail.InWardGatePassNo = Validation.GetSafeString(objReader["GatePass"]);
                    oelIssuanceDetail.OpeningStock = Validation.GetSafeDecimal(objReader["Opening"]);
                    oelIssuanceDetail.StockIn = Validation.GetSafeDecimal(objReader["In"]);
                    oelIssuanceDetail.StockOut = Validation.GetSafeDecimal(objReader["Out"]);

                    list.Add(oelIssuanceDetail);
                }
            }
            return list;
        }
        public decimal GetGlovesBatchWiseItemAvgCosting(Guid IdItem, Int64 BatchNo, int ProductionType, string OperationType, SqlConnection objConn)
        {

            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetGlovesBatchWiseItemAvgCosting]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
                cmdProduction.Parameters.Add("@BatchNo", SqlDbType.BigInt).Value = BatchNo;
                cmdProduction.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
                cmdProduction.Parameters.Add("@OperationType", SqlDbType.VarChar).Value = OperationType;
                return Validation.GetSafeDecimal(cmdProduction.ExecuteScalar());

            }

        }
        public decimal GetGlovesStitchingAvgCosting(Guid IdItem, int ProductionType, int IdDepartment, SqlConnection objConn)
        {
            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetGlovesStitchingAvgCosting]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
                cmdProduction.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
                cmdProduction.Parameters.Add("@IdDepartment", SqlDbType.Int).Value = IdDepartment;
                return Validation.GetSafeDecimal(cmdProduction.ExecuteScalar());

            }
        }
        public decimal GetGlovesBatchWiseItemClosingStock(Guid IdItem, Int64 BatchNo, int ProductionType, int IssuanceType, string OperationType, int IdDepartment, SqlConnection objConn)
        {

            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetGlovesBatchWiseItemClosingStock]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
                cmdProduction.Parameters.Add("@BatchNo", SqlDbType.BigInt).Value = BatchNo;
                cmdProduction.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
                cmdProduction.Parameters.Add("@IssuanceType", SqlDbType.Int).Value = IssuanceType;
                cmdProduction.Parameters.Add("@OperationType", SqlDbType.VarChar).Value = OperationType;
                cmdProduction.Parameters.Add("@IdDepartment", SqlDbType.Int).Value = IdDepartment;
                return Validation.GetSafeDecimal(cmdProduction.ExecuteScalar());

            }
        }
        public decimal GetBatchWiseCuffsCost(Guid IdItem, int ProductionType, Int64 BatchNo, SqlConnection objConn)
        {
            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetBatchWiseCuffsCost]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
                cmdProduction.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
                cmdProduction.Parameters.Add("@BatchNo", SqlDbType.BigInt).Value = BatchNo;
                return Validation.GetSafeDecimal(cmdProduction.ExecuteScalar());

            }
        }
        public List<BrandEL> GetBrandByBatch(Int64 BatchNo, int ProductionType, SqlConnection objConn)
        {
            List<BrandEL> list = new List<BrandEL>();
            SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetBrandByBatch]", objConn);
            cmdProduction.CommandType = CommandType.StoredProcedure;
            cmdProduction.CommandTimeout = 0;
            cmdProduction.Parameters.Add("@BatchNo", SqlDbType.BigInt).Value = BatchNo;
            cmdProduction.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
            objReader = cmdProduction.ExecuteReader();
            while (objReader.Read())
            {
                BrandEL obj = new BrandEL();
                obj.IdBrand = Validation.GetSafeGuid(objReader["Brand_Id"]);
                obj.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);

                list.Add(obj);
            }
            return list;
        }
        public decimal GetProductionOpeningPurchasedExtraUnitsByItem(Guid IdItem, SqlConnection objConn)
        {
            SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetProductionOpeningPurchasedExtraUnitsByItem]", objConn);
            cmdProduction.CommandType = CommandType.StoredProcedure;
            cmdProduction.CommandTimeout = 0;
            cmdProduction.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
            return Validation.GetSafeDecimal(cmdProduction.ExecuteScalar());

        }
        public decimal GetStockForStitching(Guid IdItem, int ProductionType, int IdDepartment, SqlConnection objConn)
        {

            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetStockForStitching]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
                cmdProduction.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
                cmdProduction.Parameters.Add("@IdDepartment", SqlDbType.Int).Value = IdDepartment;
                return Validation.GetSafeDecimal(cmdProduction.ExecuteScalar());

            }

        }
        public decimal GetRepairStockClosingStockForAllArticles(Guid IdItem, Guid IdOrder, string AccountNo, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            SqlCommand cmdClosingStock = new SqlCommand("[Transactions].[Proc_GetRepairStockClosingStockForAllArticles]", objConn);
            cmdClosingStock.CommandType = CommandType.StoredProcedure;
            cmdClosingStock.CommandTimeout = 0;
            cmdClosingStock.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = IdItem;
            cmdClosingStock.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = IdOrder;
            cmdClosingStock.Parameters.Add(new SqlParameter("@AccountNo", DbType.Guid)).Value = AccountNo;
            return Validation.GetSafeDecimal(cmdClosingStock.ExecuteScalar());                
        }
    }
}
